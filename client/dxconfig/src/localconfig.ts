import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');
import url = require('url');
import globalrequire = require('./global');

import * as files from './platform/files';


class LocalConfig {
    app: string;
    secret?: string | null;

    load() {
        var filename = files.getLocalConfigPath();
        var json = files.readJson(filename);

        this.validateJsonFormat(json);

        this.app = json.app;
        this.secret = json.secret;
    }
    exist() : boolean {
        var filename = files.getLocalConfigPath();
        return files.existFile(filename);
    }
    save() {
        this.validateJsonFormat(this);

        var filename = files.getLocalConfigPath();
        files.writeJson(filename, this);
    }

    private validateJsonFormat(json) {
        if( json.app == null )
            throw "local config object has null values";
    }
}

class TestLocalConfig {
    app: string;
    secret?: string | null;

    load() {
        console.log('local configuration file loaded')
        console.dir(this);
    }
    exist() : boolean {
        return true;
    }
    save() {
        console.log('local configuration file saved')
        console.dir(this);
    }
}

export var Config = new LocalConfig();


function old() {
    
var CONFIGFILE = 'dxconfig.json';

var configserver = globalrequire.globalconf.data;

// configInit();
secretsAdd('arda', 'file.json.secrets');

function configInit() {
    var config = {
        app: '<enter_app_name>'
    };
    write(config);
}

function secretsAdd(appname, filename) {
    
    if(fs.existsSync(filename)) {
        console.log(filename);

        uploadSecrets(appname, filename);
    }
    
}

function uploadSecrets(appname, filename) {

    var data = fs.readFileSync(filename, 'utf8');

    console.log('filename: ' + filename);

    if( data == null || data.length == 0 ) {
        console.log('no data');
        return;
    }
    console.log('data: ' + data.length);

    var endpoint = configserver.endpoint;
    var authOptions : request.CoreOptions = {
        auth: { bearer: configserver.token },
        json: data
    };

    // warning - almost string concatenation
    var urlConfigCreate = url.resolve(endpoint, '/api/config/' + appname);
    console.log( urlConfigCreate)
    
    request
    .post(urlConfigCreate, authOptions)
    .on('error', function(err) {
      console.log(err)
    })
    .on('complete', r => { console.log('uploadSecrets');});
}

function write(config) {
    var data = JSON.stringify(config, null, ' ');
    fs.writeFileSync(CONFIGFILE, data);
}

function read() {
    var data = fs.readFileSync(CONFIGFILE, 'utf8');
    return JSON.parse(data);
}
}