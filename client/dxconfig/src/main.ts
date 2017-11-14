import { ICommandHub } from './interfaces'
import { Command } from './command';
import { GetSession } from './session';
import { HubNotImplemented } from './commandhub';

import { Config as GlobalConfig } from './globalconfig';
import { Config as LocalConfig } from './localconfig';
import { GetConfig } from './config';

var Session = GetSession(GlobalConfig);
var Config = GetConfig(GlobalConfig, LocalConfig);

console.log('dxconfig v0.1');

var hub = HubNotImplemented;

hub.loginToken = (token) => Session.loginToken(token);
hub.configInit = () => Config.init();
hub.configAddSecret = (path) => Config.addSecret(path);
hub.serverPull = () => Config.serverPull();
hub.serverPush = () => Config.serverPush();
hub.logout = () => Session.logout();

Command.dispatch(hub);

// ICommandHub
    // serverPush();
    // serverPull();



// GlobalConfig.load();

import * as server from './platform/server'

(async function run() {

    //await server.apiConfigStatusAsync(GlobalConfig)

    //GlobalConfig.load();

    //console.log('test')
    //console.dir(GlobalConfig);

    //await server.apiConfigCreateAsync(GlobalConfig, 'myapp001', '--aaaa--');

    // var result = await server.apiConfigRetrieveAsync(GlobalConfig, 'myapp001');
    // console.log(result);

})();