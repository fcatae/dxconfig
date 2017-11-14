"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const command_1 = require("./command");
const session_1 = require("./session");
const commandhub_1 = require("./commandhub");
const globalconfig_1 = require("./globalconfig");
const localconfig_1 = require("./localconfig");
const config_1 = require("./config");
var Session = session_1.GetSession(globalconfig_1.Config);
var Config = config_1.GetConfig(globalconfig_1.Config, localconfig_1.Config);
console.log('dxconfig v0.1');
var hub = commandhub_1.HubNotImplemented;
hub.loginToken = (token) => Session.loginToken(token);
hub.configInit = () => Config.init();
hub.configAddSecret = (path) => Config.addSecret(path);
hub.serverPull = () => Config.serverPull();
hub.serverPush = () => Config.serverPush();
hub.logout = () => Session.logout();
command_1.Command.dispatch(hub);
(function run() {
    return __awaiter(this, void 0, void 0, function* () {
        //await server.apiConfigStatusAsync(GlobalConfig)
        //GlobalConfig.load();
        //console.log('test')
        //console.dir(GlobalConfig);
        //await server.apiConfigCreateAsync(GlobalConfig, 'myapp001', '--aaaa--');
        // var result = await server.apiConfigRetrieveAsync(GlobalConfig, 'myapp001');
        // console.log(result);
    });
})();
