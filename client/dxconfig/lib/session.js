"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SessionImpl = /** @class */ (function () {
    function SessionImpl(config) {
        this.config = config;
    }
    SessionImpl.prototype.login = function () {
        console.log('login not implemented');
    };
    SessionImpl.prototype.loginToken = function (serverCode) {
        // serverCode = <jwtToken>@<endpoint>      
        var components = serverCode.split('@');
        if (components.length != 2)
            throw "invalid token parameter";
        var jwtToken = components[0];
        var endpoint = components[1];
        // check if user is already logged in
        if (this.config.exist())
            throw "config already exists";
        // save the session
        this.config.endpoint = endpoint;
        this.config.jwtToken = jwtToken;
        this.config.save();
    };
    SessionImpl.prototype.logout = function () {
        if (this.config.exist()) {
            this.config.delete();
        }
    };
    return SessionImpl;
}());
function GetSession(config) {
    return new SessionImpl(config);
}
exports.GetSession = GetSession;
