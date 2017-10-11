"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var CONFIGAPPCONST = "<enter app name>";
var CONFIGSECCONST = "<enter secret file path>";
var Config = /** @class */ (function () {
    function Config(config) {
        this.config = config;
    }
    Config.prototype.init = function () {
        // ignore if this was already initialized
        if (this.config.exist())
            return;
        this.config.app = CONFIGAPPCONST;
        this.config.secret = null;
        this.config.save();
    };
    Config.prototype.addSecret = function (path) {
        this.config.load();
        this.config.secret = path;
        this.config.save();
    };
    return Config;
}());
function GetConfig(config) {
    return new Config(config);
}
exports.GetConfig = GetConfig;
