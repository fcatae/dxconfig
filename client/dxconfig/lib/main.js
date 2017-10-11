"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var command_1 = require("./command");
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
command_1.Command.dispatch(hub);
