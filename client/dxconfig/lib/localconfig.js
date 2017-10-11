"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
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
