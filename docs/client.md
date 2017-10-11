Client Architecture
=====================

# Managers #

Cmd
    command
    parameters

Session
    dxconfig login
    $DXHOME

Config
    dxconfig init                      (create the file dxconfig.json)
    dxconfig add <path>/secret.json    (make sure it is in git ignore)
    ./dxconfig.json
    add a property to file { "dxconfigserver": "http://<endpoint_url>" }
        { "dxconfig_hash": "<hash>.<hash>" }

Server    
    dxconfig push               (upload to the server)
    dxconfig pull               (download from the config server)
    check property { "dxconfig_hash": "<hash>.<hash>" }


# Platform #

Folder
    path concatenation
    path combine
    known paths
File
    read
    write
    exists
Http
API


v2
===

Help
    helpmsgs

AppLink
    dxconfig applink create     (returns http://<endpoint_url>/applink/blabla)

Permission

Test environment

    dxconfig login ($TOKEN)@<endpoint_url>
    dxconfig pull
    
Environment
    setenv
    docker launch
