"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var session_1 = require("./session");
var commandhub_1 = require("./commandhub");
var globalconfig_1 = require("./globalconfig");
var localconfig_1 = require("./localconfig");
var config_1 = require("./config");
var Session = session_1.GetSession(globalconfig_1.Config);
var Config = config_1.GetConfig(localconfig_1.Config);
console.log('dxconfig v0.1');
var hub = commandhub_1.HubNotImplemented;
hub.loginToken = function (token) { return Session.loginToken(token); };
hub.configInit = function () { return Config.init(); };
hub.configAddSecret = function (path) { return Config.addSecret(path); };
hub.logout = function () { return Session.logout(); };
// ICommandHub
// loginToken: Session.loginToken
// configInit();
// configAddSecret(path: string)
// serverPush();
// serverPull();
// Command.dispatch(hub);
globalconfig_1.Config.load();
var api_1 = require("./platform/api");
process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
api_1.httpGet(globalconfig_1.Config.endpoint, globalconfig_1.Config.jwtToken);
console.log('http');
