"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
console.log('dxconfig v0.1');
var http = require("http");
var fs = require("fs");
var endpoint = 'http://localhost:5000/api/config';
var application = 'myapp001';
var argv = process.argv.slice(2);
// use parameters if supplied by the user
(argv.length > 0) && (application = argv[0]);
console.log('Download application configuration: ' + application);
// define the remote url and local filename
var downloadUrl = resolveName(endpoint, application);
var localFilename = resolveFile(application);
downloadFile(downloadUrl, localFilename);
// resolve the name
function resolveName(url, filename) {
    return url + '/' + filename;
}
// resolve the name
function resolveFile(filename) {
    return filename + '.json';
}
// download the file
function downloadFile(url, filename) {
    var file = fs.createWriteStream(filename);
    var request = http.get(url, function (response) {
        response.pipe(file);
    });
}
