"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var session_1 = require("./session");
var commandhub_1 = require("./commandhub");
var globalconfig_1 = require("./globalconfig");
var Session = session_1.GetSession(globalconfig_1.Config);
console.log('dxconfig v0.1');
//var client = require('./client');
//var client = require('./config');
//var client = require('./session');
//Command.dispatch(HubNotImplemented);
var hub = commandhub_1.HubNotImplemented;
hub.loginToken = function (token) { return Session.loginToken(token); };
// ICommandHub
// login();
// loginToken: Session.loginToken
// configInit();
// configAddSecret(path: string)
// serverPush();
// serverPull();
// Command.dispatch(hub);
globalconfig_1.Config.load();
console.dir(globalconfig_1.Config);
