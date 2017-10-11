import { ICommandHub } from './interfaces'
import { Command } from './command';
import { GetSession } from './session';
import { HubNotImplemented } from './commandhub';

import { Config as GlobalConfig } from './globalconfig';
import { Config as LocalConfig } from './localconfig';
import { GetConfig } from './config';

var Session = GetSession(GlobalConfig);
var Config = GetConfig(LocalConfig);

console.log('dxconfig v0.1');

//var client = require('./client');

//var client = require('./config');
//var client = require('./session');


//Command.dispatch(HubNotImplemented);

var hub = HubNotImplemented;

hub.loginToken = (token) => Session.loginToken(token);
hub.configInit = () => Config.init();
hub.configAddSecret = (path) => Config.addSecret(path);

// ICommandHub
    // loginToken: Session.loginToken
    // configInit();
    // configAddSecret(path: string)
    // serverPush();
    // serverPull();

Command.dispatch(hub);
