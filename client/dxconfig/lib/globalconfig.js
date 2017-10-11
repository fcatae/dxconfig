"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var files = require("./platform/files");
function initSession(initParam) {
    var comps = initParam.split('@');
    var jwtToken = comps[0];
    var endpoint = comps[1];
    console.log('initSession');
    // console.log(endpoint);
    // console.log(jwtToken);
    var filename = files.getDxUserConfiguration();
    files.saveConfig(filename, endpoint, jwtToken);
    var config = files.loadConfig(filename);
    // //testSession(endpoint, jwtToken);
    // var jwtToken = config.token;
    // var endpoint = config.endpoint;
    // console.log(endpoint);
    // console.log(jwtToken);    
    // testSession(endpoint, jwtToken);
}
var GlobalConfig = /** @class */ (function () {
    function GlobalConfig() {
        this.endpoint = null;
        this.jwtToken = null;
    }
    GlobalConfig.prototype.load = function () {
        var filename = files.getGlobalConfigPath();
        var json = files.readJson(filename);
        if (json.endpoint == null || json.jwtToken == null)
            throw "json file format is incorrect";
        this.endpoint = json.endpoint;
        this.jwtToken = json.jwtToken;
    };
    GlobalConfig.prototype.exist = function () {
        var filename = files.getGlobalConfigPath();
        return files.existFile(filename);
    };
    GlobalConfig.prototype.save = function () {
        if (this.endpoint == null || this.jwtToken == null)
            throw "globalConfig object has null values";
        var filename = files.getGlobalConfigPath();
        files.writeJson(filename, this);
    };
    GlobalConfig.prototype.delete = function () {
        var filename = files.getGlobalConfigPath();
        files.deleteFile(filename);
        this.endpoint = null;
        this.jwtToken = null;
    };
    return GlobalConfig;
}());
var TestGlobalConfig = /** @class */ (function () {
    function TestGlobalConfig() {
        this.endpoint = null;
        this.jwtToken = null;
    }
    TestGlobalConfig.prototype.load = function () {
        console.log('global configuration file loaded');
        console.dir(this);
    };
    TestGlobalConfig.prototype.exist = function () {
        return (this.endpoint != null) || (this.jwtToken != null);
    };
    TestGlobalConfig.prototype.save = function () {
        console.log('global configuration file saved');
        console.dir(this);
    };
    TestGlobalConfig.prototype.delete = function () {
        this.endpoint = null;
        this.jwtToken = null;
    };
    return TestGlobalConfig;
}());
exports.Config = new GlobalConfig();
