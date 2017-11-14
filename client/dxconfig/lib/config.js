"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const CONFIGAPPCONST = "<enter app name>";
const CONFIGSECCONST = "<enter secret file path>";
class Config {
    constructor(config) {
        this.config = config;
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
}
function GetConfig(config) {
    return new Config(config);
}
exports.GetConfig = GetConfig;
