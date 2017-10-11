"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var request = require("request");
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
    return SessionImpl;
}());
function GetSession(config) {
    return new SessionImpl(config);
}
exports.GetSession = GetSession;
function old() {
    function testSession(endpoint, jwtToken) {
        console.log('endpoint: ' + endpoint);
        var authOptions = {
            auth: { bearer: jwtToken }
        };
        console.dir(authOptions);
        request
            .get(endpoint, authOptions)
            .on('error', function (err) {
            console.log(err);
        })
            .on('complete', function (r) { console.log('initSession:complete'); });
    }
}
