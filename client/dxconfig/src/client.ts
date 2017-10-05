console.log('dxconfig v0.1');

import path = require('path');
import http = require('http');
import fs = require('fs');

var endpoint = 'http://localhost:5000/api/config';
var application = 'myapp001';

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
    var request = http.get(url, function(response) {
      response.pipe(file);
    });    
}
