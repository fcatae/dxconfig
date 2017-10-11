import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');
import url = require('url');

export function httpGet(endpoint: string, jwtToken: string) {

    var authOptions : request.CoreOptions = {
        auth: { bearer: jwtToken }
    };

    request.get(endpoint, authOptions)
        .on('error', function(err) {
            console.log('httpGet:error')
            console.log(err)
        })
        .on('complete', r => { console.log('httpGet:complete');})
        ;

}

function old() {
    
    function testSession(endpoint, jwtToken) {
        console.log('endpoint: ' + endpoint)
            
        var authOptions : request.CoreOptions = {
            auth: { bearer: jwtToken }
        };
    
        console.dir(authOptions);
    
        request
        .get(endpoint, authOptions)
        .on('error', function(err) {
          console.log(err)
        })
        .on('complete', r => { console.log('initSession:complete');})
        ;
    }
    
    
function uploadSecrets(appname, filename) {
    
    //     var data = fs.readFileSync(filename, 'utf8');
    
    //     console.log('filename: ' + filename);
    
    //     if( data == null || data.length == 0 ) {
    //         console.log('no data');
    //         return;
    //     }
    //     console.log('data: ' + data.length);
    
    //     var endpoint = configserver.endpoint;
    //     var authOptions : request.CoreOptions = {
    //         auth: { bearer: configserver.token },
    //         json: data
    //     };
    
    //     // warning - almost string concatenation
    //     var urlConfigCreate = url.resolve(endpoint, '/api/config/' + appname);
    //     console.log( urlConfigCreate)
        
    //     request
    //     .post(urlConfigCreate, authOptions)
    //     .on('error', function(err) {
    //       console.log(err)
    //     })
    //     .on('complete', r => { console.log('uploadSecrets');});
    // }

    }

   
}



// function download(foldername, endpoint, application) {
    
// console.log('Download application configuration: ' + application);

// // define the remote url and local filename
// var downloadUrl = resolveName(endpoint, application);
// var localFilename = resolveFile(foldername, application);

// downloadFile(downloadUrl, localFilename);
// }

// // resolve the name
// function resolveName(url, filename) {
// return url + '/' + filename;
// }

// // resolve the name
// function resolveFile(foldername, filename) {
// return path.join(foldername, filename + '.json');
// }

// // download the file
// function downloadFileHttp(url, filename) {
// var file = fs.createWriteStream(filename);
// var request = http.get(url, function(response) {
//   // http lib does not do redirection
//   console.log(response.statusMessage);
//   response.pipe(file);      
//   file.close();
// });    
// }

// function downloadFile(url, filename) {
// request
//   .get(url)
//   .on('error', function(err) {
//     console.log(err)
//   })
//   .pipe(fs.createWriteStream(filename))
// }
