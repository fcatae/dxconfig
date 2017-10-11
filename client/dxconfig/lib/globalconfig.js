"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const files = require("./platform/files");
class GlobalConfig {
    constructor() {
        this.endpoint = null;
        this.jwtToken = null;
    }
    load() {
        var filename = files.getGlobalConfigPath();
        var json = files.readJson(filename);
        if (json.endpoint == null || json.jwtToken == null)
            throw "json file format is incorrect";
        this.endpoint = json.endpoint;
        this.jwtToken = json.jwtToken;
    }
    exist() {
        var filename = files.getGlobalConfigPath();
        return files.existFile(filename);
    }
    save() {
        if (this.endpoint == null || this.jwtToken == null)
            throw "globalConfig object has null values";
        var filename = files.getGlobalConfigPath();
        files.writeJson(filename, this);
    }
    delete() {
        var filename = files.getGlobalConfigPath();
        files.deleteFile(filename);
        this.endpoint = null;
        this.jwtToken = null;
    }
}
class TestGlobalConfig {
    constructor() {
        this.endpoint = null;
        this.jwtToken = null;
    }
    load() {
        console.log('global configuration file loaded');
        console.dir(this);
    }
    exist() {
        return (this.endpoint != null) || (this.jwtToken != null);
    }
    save() {
        console.log('global configuration file saved');
        console.dir(this);
    }
    delete() {
        this.endpoint = null;
        this.jwtToken = null;
    }
}
exports.Config = new GlobalConfig();
