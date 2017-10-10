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

    dxconfig login blablabla@<endpoint_url>

Write to userhome
Read .dxconfig
Init .dxconfig

Pull configuration

    dxconfig pull

Push configuration

    dxconfig push

Get configuration

    dxconfig fetch http://<endpoint_url>


Login to server

    dxconfig login http://<endpoint_url>

    dxconfig get arda
