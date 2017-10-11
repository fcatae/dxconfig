import { ICommandHub } from './interfaces';

export var HubNotImplemented : ICommandHub = {
    login: () => {
        console.log('login not implemented');
    },
    loginToken: (token: string) => {
        console.log('loginToken not implemented');
    },
    logout: () => {
        console.log('logout not implemented');
    },
    configInit: () => {
        console.log('configInit not implemented');
    },
    configAddSecret: (path: string) => {
        console.log('configAddSecret not implemented');
    },
    serverPush: () => {
        console.log('serverPush not implemented');
    },
    serverPull: () => {
        console.log('serverPull not implemented');
    }
};