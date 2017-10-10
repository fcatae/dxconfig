"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var path = require("path");
var http = require("http");
var fs = require("fs");
var os = require("os");
var request = require("request");
var endpoint = 'http://localhost:5000/api/config';
var application = 'myapp001';
var argv = process.argv.slice(2);
// use parameters if supplied by the user
(argv.length > 0) && (application = argv[0]);
var dxHome = getDxConfigHomeDir();
var exists = fs.existsSync(dxHome);
console.log(exists);
if (!exists) {
    fs.mkdirSync(dxHome, '700');
}
console.log(getDxConfigHomeDir());
var foldername = getDxConfigHomeDir();
download(foldername, 'http://bing.com', '');
//download(foldername, endpoint, application)
function getHomeDir() {
    return process.env.LOCALAPPDATA || os.homedir();
}
function getDxConfigHomeDir() {
    // if Windows
    if (process.env.LOCALAPPDATA) {
        return path.join(process.env.LOCALAPPDATA, 'DXConfig');
    }
    // if Unix    
    return path.join(os.homedir(), '.dxconfig');
}
function download(foldername, endpoint, application) {
    console.log('Download application configuration: ' + application);
    // define the remote url and local filename
    var downloadUrl = resolveName(endpoint, application);
    var localFilename = resolveFile(foldername, application);
    downloadFile(downloadUrl, localFilename);
}
// resolve the name
function resolveName(url, filename) {
    return url + '/' + filename;
}
// resolve the name
function resolveFile(foldername, filename) {
    return path.join(foldername, filename + '.json');
}
// download the file
function downloadFileHttp(url, filename) {
    var file = fs.createWriteStream(filename);
    var request = http.get(url, function (response) {
        // http lib does not do redirection
        console.log(response.statusMessage);
        response.pipe(file);
        file.close();
    });
}
function downloadFile(url, filename) {
    request
        .get(url)
        .on('error', function (err) {
        console.log(err);
    })
        .pipe(fs.createWriteStream(filename));
}
