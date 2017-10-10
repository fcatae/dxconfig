"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var path = require("path");
var fs = require("fs");
var os = require("os");
function getDxUserConfiguration() {
    var filename = 'configserver.json';
    // if Windows
    if (process.env.LOCALAPPDATA) {
        return path.join(process.env.LOCALAPPDATA, 'DXConfig', filename);
    }
    // if Unix    
    return path.join(os.homedir(), '.dxconfig', filename);
}
function loadConfig(filename) {
    var data = fs.readFileSync(filename, 'utf8');
    return JSON.parse(data);
}
exports.globalconf = {
    data: loadConfig(getDxUserConfiguration())
};
