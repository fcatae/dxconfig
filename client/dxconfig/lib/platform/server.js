"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const http = require("./http");
const url = require("url");
process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
const CONFIG_STATUS = "config";
const CONFIG_CREATE = (app) => `config/${app}`;
const CONFIG_RETRIEVE = (app) => `config/${app}`;
function apiConfigStatusAsync(config) {
    return httpGetAsync(config, CONFIG_STATUS, null);
}
exports.apiConfigStatusAsync = apiConfigStatusAsync;
function apiConfigCreateAsync(config, appname, data) {
    return httpPostAsync(config, CONFIG_CREATE(appname), data);
}
exports.apiConfigCreateAsync = apiConfigCreateAsync;
function apiConfigRetrieveAsync(config, appname) {
    return httpGetAsync(config, CONFIG_RETRIEVE(appname), null);
}
exports.apiConfigRetrieveAsync = apiConfigRetrieveAsync;
function httpGetAsync(config, action, parameters) {
    var endpoint = url.resolve(config.endpoint, action);
    return http.getAsync(endpoint, config.jwtToken, parameters);
}
function httpPostAsync(config, action, parameters) {
    var endpoint = url.resolve(config.endpoint, action);
    return http.postAsync(endpoint, config.jwtToken, parameters);
}
