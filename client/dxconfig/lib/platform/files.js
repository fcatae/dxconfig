"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const fs = require("fs");
const os = require("os");
const path = require("path");
const GLOBALCONFIGSERVER = 'configserver.json';
const DXCONFIG_WINDOWS = 'DXConfig';
const DXCONFIG_LINUX = '.dxconfig';
const LOCALCONFIG = 'dxconfig.json';
function readJson(filename) {
    var data = fs.readFileSync(filename, 'utf8');
    return JSON.parse(data);
}
exports.readJson = readJson;
function writeJson(filename, json) {
    var data = JSON.stringify(json, null, ' ');
    fs.writeFileSync(filename, data);
}
exports.writeJson = writeJson;
function readFile(filename) {
    var data = fs.readFileSync(filename, 'utf8');
    return data;
}
exports.readFile = readFile;
function writeFile(filename, data) {
    fs.writeFileSync(filename, data);
}
exports.writeFile = writeFile;
function existFile(filename) {
    return fs.existsSync(filename);
}
exports.existFile = existFile;
function deleteFile(filename) {
    fs.unlinkSync(filename);
}
exports.deleteFile = deleteFile;
function getGlobalConfigPath() {
    if (process.env.LOCALAPPDATA) {
        // Windows
        // path = %APPDATA%\DXConfig\configserver.json
        return path.join(process.env.LOCALAPPDATA, DXCONFIG_WINDOWS, GLOBALCONFIGSERVER);
    }
    else {
        // Linux
        // path = /home/<user>/.dxconfig/configserver.json
        return path.join(os.homedir(), DXCONFIG_LINUX, GLOBALCONFIGSERVER);
    }
}
exports.getGlobalConfigPath = getGlobalConfigPath;
function getLocalConfigPath() {
    // load dxconfig.json in the current folder
    return LOCALCONFIG;
}
exports.getLocalConfigPath = getLocalConfigPath;
function getDxConfigHomeDir() {
    // if Windows
    if (process.env.LOCALAPPDATA) {
        return path.join(process.env.LOCALAPPDATA, 'DXConfig');
    }
    // if Unix    
    return path.join(os.homedir(), '.dxconfig');
}
exports.getDxConfigHomeDir = getDxConfigHomeDir;
function getDxUserConfiguration() {
    var filename = 'configserver.json';
    // if Windows
    if (process.env.LOCALAPPDATA) {
        return path.join(process.env.LOCALAPPDATA, 'DXConfig', filename);
    }
    // if Unix    
    return path.join(os.homedir(), '.dxconfig', filename);
}
exports.getDxUserConfiguration = getDxUserConfiguration;
function hasConfig(filename) {
    return fs.existsSync(filename);
}
function saveConfig(filename, endpoint, jwtToken) {
    if (hasConfig(filename)) {
        console.log('file already exists');
        return;
    }
    var data = JSON.stringify({ endpoint: endpoint, token: jwtToken });
    fs.writeFileSync(filename, data);
}
exports.saveConfig = saveConfig;
function logoutConfig(filename) {
    fs.unlinkSync(filename);
}
function loadConfig(filename) {
    var data = fs.readFileSync(filename, 'utf8');
    return JSON.parse(data);
}
exports.loadConfig = loadConfig;
