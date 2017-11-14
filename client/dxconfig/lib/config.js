"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const server = require("./platform/server");
const CONFIGAPPCONST = "<enter app name>";
const CONFIGSECCONST = "<enter secret file path>";
class Config {
    constructor(globalConfig, config) {
        this.config = config;
        this.globalConfig = globalConfig;
    }
    init() {
        // ignore if this was already initialized
        if (this.config.exist()) {
            console.log('Configuration already exist');
            return;
        }
        this.config.app = CONFIGAPPCONST;
        this.config.secret = null;
        this.config.save();
        console.log('Configuration created');
    }
    addSecret(path) {
        this.config.load();
        this.config.secret = path;
        this.config.save();
    }
    serverPush() {
        this.globalConfig.load();
        this.config.load();
        var appname = this.config.app;
        console.log('appname: ' + appname);
        return server.apiConfigCreateAsync(this.globalConfig, appname, '--aaaa--');
    }
    serverPull() {
        this.globalConfig.load();
        this.config.load();
        var appname = this.config.app;
        server.apiConfigRetrieveAsync(this.globalConfig, appname).then((data) => {
            console.log('appname: ' + appname);
            console.log(data);
        });
    }
}
function GetConfig(globalConfig, config) {
    return new Config(globalConfig, config);
}
exports.GetConfig = GetConfig;
