"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var request = require("request");
console.log('session');
var arg0 = process.argv[2];
initSession(arg0);
function initSession(initParam) {
    var comps = initParam.split('@');
    var jwtToken = comps[0];
    var endpoint = comps[1];
    console.log('initSession');
    testSession(endpoint, jwtToken);
}
function testSession(endpoint, jwtToken) {
    console.log('endpoint: ' + endpoint);
    var authOptions = {
        auth: { bearer: jwtToken }
    };
    request
        .get(endpoint, authOptions)
        .on('error', function (err) {
        console.log(err);
    })
        .on('complete', function (r) { console.log('initSession:complete'); });
}
