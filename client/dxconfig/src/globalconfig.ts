import * as files from './platform/files';

function initSession(initParam: string) {
    var comps = initParam.split('@');
    var jwtToken = comps[0];
    var endpoint = comps[1];
    
    console.log('initSession');
    // console.log(endpoint);
    // console.log(jwtToken);

    var filename = files.getDxUserConfiguration();
    files.saveConfig(filename, endpoint, jwtToken);

    var config = files.loadConfig(filename);
    // //testSession(endpoint, jwtToken);

    // var jwtToken = config.token;
    // var endpoint = config.endpoint;

    // console.log(endpoint);
    // console.log(jwtToken);    

    // testSession(endpoint, jwtToken);
}

class GlobalConfig {
    endpoint: string | null = null;
    jwtToken: string | null = null;

    load() {
        var filename = files.getGlobalConfigPath();
        var json = files.readJson(filename);

        if( json.endpoint == null || json.jwtToken == null)
            throw "json file format is incorrect";

        this.endpoint = json.endpoint;
        this.jwtToken = json.jwtToken;

        console.log('global configuration file loaded')
    }
    exist() : boolean {
        var filename = files.getGlobalConfigPath();
        return false;
    }
    save() {
        if( this.endpoint == null || this.jwtToken == null)
            throw "globalConfig object has null values";

        var filename = files.getGlobalConfigPath();
        files.writeJson(filename, this);
        console.log('global configuration file saved')
    }
    delete() {    
        this.endpoint = null;
        this.jwtToken = null;
    }
}

class TestGlobalConfig {
    endpoint: string | null = null;
    jwtToken: string | null = null;

    load() {
        console.log('global configuration file loaded')
        console.dir(this);
    }
    exist() : boolean {
        return (this.endpoint != null) || (this.jwtToken != null);
    }
    save() {
        console.log('global configuration file saved')
        console.dir(this);
    }
    delete() {    
        this.endpoint = null;
        this.jwtToken = null;
    }
}

export var Config = new GlobalConfig();