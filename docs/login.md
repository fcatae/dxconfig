
Github integration

    dxconfig login http://<endpoint_url>
        - client/server handshake:
            - set clientinfo=hostname+whoami+(password)  (fabricio@localhost 983465)
            - post https://<endpoint_url>/api/session/init (clientinfo -> seed=left(sessionid)             
                (sessionid=hash(clientinfo,serverseed),serverseedhash) - serverseedhash expires in minutes

        - open browser and visit the portal:
            - portal: https://<endpoint_url>/session
            - open https://<endpoint_url>/session/<seed>  (seed=left(sessionid))
            - (optional) enter the client password to validate
            - redirect to https://<endpoint_url>/portal/login-provider?sessionid=<secret>
            - portal validates the current session (cookie present) and get github identity

        - server: initiate oauth2 authentication
            - if there is no active session
            - redirect to github
            - redirect back to https://<endpoint_url>/portal/signin-github?<oauth_token>
            - create the session (cookie)

        - server: (complete) associate github user
            - receive: accesstoken from github
            - create a profile with (clientinfo,access_token,profile)
            - validate clientinfo
            - create IPassKey with (git,username)

        - client: download IPassKey
            - exchange sessionid to retrieve the credentials
            - provide a clientinfo+serverseedhash
            - trigger update on <secret>
            - request access to <secret>

    dxconfig get
        app: 
            - git remote get-url origin 
            - https://github.com/<org>/<proj>.git
        env:
            - github

    
Workflow:

Client: Command line
1. Client calls /api/session/init with clientinfo = { hostname, username, (pincode) }
2. Server returns a {session_url, session_token, signed(clientinfo)}

Client: Browser
3. User open session_url = https://<endpoint_url>/portal?session=token (type pincode)
4. Session redirects the user to the correct login page (portal github)
5. Portal initiates the oath2: redirects the user to Github
6. User completes the Github authentication and returns to the Portal
7. Portal identifies the user and notifies /api/session/complete
8. Portal workflow is complete

Client: Command line
9. Client polls /api/session/wait?session_token
10. Session API receives the Github token at /api/session/complete (auth?)
11. Client is notified at /api/session/wait of successful auth
12. Client downloads IPassKey at /api/session/retrieve with clientinfo



Portal 
========

1. Login in the Portal using GitHub
2. Create a user Profile
3. Generate a link for login

    dxconfig login http://<endpointurl>/api/session/login_token=123456789

4. Client application calls the login_token
