import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');

import { IGlobalConfig } from './interfaces';
import * as file from './platform/files';

class SessionImpl {
    private config : IGlobalConfig;

    constructor(config: IGlobalConfig) {
        this.config = config;
    }

    login() {
        console.log('login not implemented');
    }

    loginToken(serverCode: string) {  
        // serverCode = <jwtToken>@<endpoint>      
        var components = serverCode.split('@');

        if(components.length != 2)
            throw "invalid token parameter";

        var jwtToken = components[0];
        var endpoint = components[1];

        // check if user is already logged in
        if(this.config.exist())
            throw "config already exists";

        // save the session
        this.config.endpoint = endpoint;
        this.config.jwtToken = jwtToken;
        this.config.save();
    }
}

export function GetSession(config) {
    return new SessionImpl(config);
} 

function old() {

function testSession(endpoint, jwtToken) {
    console.log('endpoint: ' + endpoint)
        
    var authOptions : request.CoreOptions = {
        auth: { bearer: jwtToken }
    };

    console.dir(authOptions);

    request
    .get(endpoint, authOptions)
    .on('error', function(err) {
      console.log(err)
    })
    .on('complete', r => { console.log('initSession:complete');})
    ;
}

}