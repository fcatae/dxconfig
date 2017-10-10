"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
var CONFIGFILE = 'dxconfig.json';
// configInit();
function configInit() {
    var config = {
        app: '<enter_app_name>'
    };
    write(config);
}
function write(config) {
    var data = JSON.stringify(config, null, ' ');
    fs.writeFileSync(CONFIGFILE, data);
}
function read() {
    var data = fs.readFileSync(CONFIGFILE, 'utf8');
    return JSON.parse(data);
}
