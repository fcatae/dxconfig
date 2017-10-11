import { ICommandHub } from './interfaces'
import { Command } from './command';
import { GetSession } from './session';
import { HubNotImplemented } from './commandhub';

import { Config as GlobalConfig } from './globalconfig';

var Session = GetSession(GlobalConfig);

console.log('dxconfig v0.1');

//var client = require('./client');

//var client = require('./config');
//var client = require('./session');


//Command.dispatch(HubNotImplemented);

var hub = HubNotImplemented;

hub.loginToken = (token) => Session.loginToken(token);

// ICommandHub
    // login();
    // loginToken: Session.loginToken
    // configInit();
    // configAddSecret(path: string)
    // serverPush();
    // serverPull();

// Command.dispatch(hub);

GlobalConfig.load();
console.dir(GlobalConfig);
