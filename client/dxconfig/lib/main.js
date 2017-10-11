"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var command_1 = require("./command");
var commandhub_1 = require("./commandhub");
console.log('dxconfig v0.1');
//var client = require('./client');
//var client = require('./config');
//var client = require('./session');
command_1.Command.dispatch(commandhub_1.HubNotImplemented);
