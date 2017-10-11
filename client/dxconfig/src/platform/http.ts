import request = require('request-promise');
import url = require('url');

export function getAsync(endpoint: string, jwtToken: string, parameters: any) {

    var options : request.RequestPromiseOptions = {
        auth: { bearer: jwtToken },
        qs: parameters
    };
    
    return request.get(endpoint, options);
}

export async function postAsync(endpoint: string, jwtToken: string, parameters: any) {
    
    var options : request.RequestPromiseOptions = {
        auth: { bearer: jwtToken },
        json: parameters
    };
    
    return request.post(endpoint, options);
}