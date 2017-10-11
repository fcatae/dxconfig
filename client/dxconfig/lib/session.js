"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class SessionImpl {
    constructor(config) {
        this.config = config;
    }
    login() {
        console.log('login not implemented');
    }
    loginToken(serverCode) {
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
    }
    logout() {
        if (this.config.exist()) {
            this.config.delete();
        }
    }
}
function GetSession(config) {
    return new SessionImpl(config);
}
exports.GetSession = GetSession;
