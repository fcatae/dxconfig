import * as http from './http'
import * as url from 'url';

process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";

const CONFIG_STATUS = "config";
const CONFIG_CREATE = (app) => `config/${app}`;
const CONFIG_RETRIEVE = (app) => `config/${app}`;

export function apiConfigStatusAsync(config) {   
    return httpGetAsync(config, CONFIG_STATUS, null);
}

export function apiConfigCreateAsync(config, appname: string, data: string) {   
    return httpPostAsync(config, CONFIG_CREATE(appname), data);
}

export function apiConfigRetrieveAsync(config, appname: string) {   
    return httpGetAsync(config, CONFIG_RETRIEVE(appname), null);
}

function httpGetAsync(config, action, parameters) {
    var endpoint = url.resolve(config.endpoint, action);
    return http.getAsync(endpoint, config.jwtToken, parameters);
}

function httpPostAsync(config, action, parameters) {
    var endpoint = url.resolve(config.endpoint, action);
    return http.postAsync(endpoint, config.jwtToken, parameters);
}    