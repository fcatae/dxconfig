"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
var request = require("request");
var url = require("url");
var globalrequire = require("./global");
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
    if (fs.existsSync(filename)) {
        console.log(filename);
        uploadSecrets(appname, filename);
    }
}
function uploadSecrets(appname, filename) {
    var data = fs.readFileSync(filename, 'utf8');
    console.log('filename: ' + filename);
    if (data == null || data.length == 0) {
        console.log('no data');
        return;
    }
    console.log('data: ' + data.length);
    var endpoint = configserver.endpoint;
    var authOptions = {
        auth: { bearer: configserver.token },
        json: data
    };
    // warning - almost string concatenation
    var urlConfigCreate = url.resolve(endpoint, '/api/config/' + appname);
    console.log(urlConfigCreate);
    request
        .post(urlConfigCreate, authOptions)
        .on('error', function (err) {
        console.log(err);
    })
        .on('complete', function (r) { console.log('uploadSecrets'); });
}
function write(config) {
    var data = JSON.stringify(config, null, ' ');
    fs.writeFileSync(CONFIGFILE, data);
}
function read() {
    var data = fs.readFileSync(CONFIGFILE, 'utf8');
    return JSON.parse(data);
}