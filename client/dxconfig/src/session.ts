import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');

console.log('session')

var arg0 = process.argv[2];

initSession(arg0)

function initSession(initParam: string) {
    var comps = initParam.split('@');
    var jwtToken = comps[0];
    var endpoint = comps[1];
    
    console.log('initSession');

    testSession(endpoint, jwtToken);
}

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