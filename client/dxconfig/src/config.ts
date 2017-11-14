import * as server from './platform/server';
import { ILocalConfig, IGlobalConfig } from './interfaces';

const CONFIGAPPCONST = "<enter app name>";
const CONFIGSECCONST = "<enter secret file path>";

class Config {

    private config : ILocalConfig
    private globalConfig : IGlobalConfig

    constructor(globalConfig: IGlobalConfig, config: ILocalConfig) {
        this.config = config;
        this.globalConfig = globalConfig;
    }

    init() {
        // ignore if this was already initialized
        if(this.config.exist()) {
            console.log('Configuration already exist');
            return;
        }
        
        this.config.app = CONFIGAPPCONST;
        this.config.secret = null;
        this.config.save();

        console.log('Configuration created');
    }

    addSecret(path: string) {
        this.config.load();
        this.config.secret = path;
        this.config.save();
    }    

    serverPush() {
        this.globalConfig.load();
        this.config.load();

        var appname = this.config.app;
        console.log('appname: ' + appname);

        return server.apiConfigCreateAsync(this.globalConfig, appname, '--aaaa--');        
    }

    serverPull() {
        this.globalConfig.load();
        this.config.load();
        var appname = this.config.app;

        server.apiConfigRetrieveAsync(this.globalConfig, appname).then( (data)=>{
            console.log('appname: ' + appname);
            console.log(data);
        }); 
    }
}

export function GetConfig(globalConfig, config) {
    return new Config(globalConfig, config);
} 
