import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');

function getDxUserConfiguration() {
    var filename = 'configserver.json';
    // if Windows
    if( process.env.LOCALAPPDATA ) {
        return path.join(process.env.LOCALAPPDATA, 'DXConfig', filename);
    } 
    
    // if Unix    
    return path.join(os.homedir(), '.dxconfig', filename);    
}

function loadConfig(filename) {
    var data = fs.readFileSync(filename, 'utf8');
    return JSON.parse(data);
}

export var globalconf = {
    data: loadConfig(getDxUserConfiguration())
}