"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
var request = require("request");
var url = require("url");
var globalrequire = require("./global");
var files = require("./platform/files");
var LocalConfig = /** @class */ (function () {
    function LocalConfig() {
    }
    LocalConfig.prototype.load = function () {
        var filename = files.getLocalConfigPath();
        var json = files.readJson(filename);
        this.validateJsonFormat(json);
        this.app = json.app;
        this.secret = json.secret;
    };
    LocalConfig.prototype.exist = function () {
        var filename = files.getLocalConfigPath();
        return files.existFile(filename);
    };
    LocalConfig.prototype.save = function () {
        this.validateJsonFormat(this);
        var filename = files.getLocalConfigPath();
        files.writeJson(filename, this);
    };
    LocalConfig.prototype.validateJsonFormat = function (json) {
        if (json.app == null)
            throw "local config object has null values";
    };
    return LocalConfig;
}());
var TestLocalConfig = /** @class */ (function () {
    function TestLocalConfig() {
    }
    TestLocalConfig.prototype.load = function () {
        console.log('local configuration file loaded');
        console.dir(this);
    };
    TestLocalConfig.prototype.exist = function () {
        return true;
    };
    TestLocalConfig.prototype.save = function () {
        console.log('local configuration file saved');
        console.dir(this);
    };
    return TestLocalConfig;
}());
exports.Config = new LocalConfig();
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
}
