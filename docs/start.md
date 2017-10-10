Install

    npm install --global dxconfig

Help

    dxconfig

Open browser (Anonymous navigation)

    https://<endpoint_url>/api/locator/app

Create links (Anonymous navigation)

    https://<endpoint_url>/api/applink/create?link=<>&location=<> (for testing)
    https://<endpoint_url>/api/applink/<link>

Cookie authentication and multiple logins

    https://<endpoint_url>/portal
    https://<endpoint_url>/portal/login

Show applink only if logged

    https://<endpoint_url>/applink/show?link=<>
    https://<endpoint_url>/applink/create?link=<>&location=<>

Download user identity if logged

    https://<endpoint_url>/portal/clientidentity

Add a command line to initialize

    dxconfig login <session_token>@<endpoint_url>
    (download configuration to dxhome: token.endpoint_url.json)

validate the session token

Use command line

    (app=group/project)
    (env=dev/branch)

    dxconfig init                      (create the file dxconfig.json)
    dxconfig secret add <path>/secret.json    (make sure it is in git ignore)
    dxconfig push               (upload to the server)

    dxconfig pull               (download from the config server)

Using shortcuts

    dxconfig applink create     (returns http://<endpoint_url>/applink/blabla)


Test environment

    dxconfig login ($TOKEN)@<endpoint_url>
    dxconfig pull
    
    dxconfig applink create dxbrazil/dxconfig --password abc
    (returns http://<endpoint_url>/applink/blabla)

    curl https://<endpoint_url>/applink/<resource>/salt+hash(salt,user,resource,anonymous=true)
    curl https://<endpoint_url>/applink/schema.user/blabla/hash(salt,user,resource,password=abc) -u user:password

Interactive (???)

    dxconfig github login
    dxconfig login <endpoint_url>


Chamar a API usando Bearer Tokens

