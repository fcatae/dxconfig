# Getting Started

Install

    npm install --global dxconfig

Login to the server

    dxconfig login <token>

Download the server configuration

    dxconfig pull


## Create a configuration ##

Initialize a local file

    dxconfig init
    dxconfig add file.secrets

Push configuration to the server

    dxconfig push
   

## Debugging ##

The configuration is stored at:

    <HOME_USER>/dxconfig/configserver.json
