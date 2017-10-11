import { ILocalConfig } from './interfaces';

const CONFIGAPPCONST = "<enter app name>";
const CONFIGSECCONST = "<enter secret file path>";

class Config {

    private config : ILocalConfig

    constructor(config: ILocalConfig) {
        this.config = config;
    }

    init() {
        // ignore if this was already initialized
        if(this.config.exist())
            return;
        
        this.config.app = CONFIGAPPCONST;
        this.config.secret = null;
        this.config.save();
    }

    addSecret(path: string) {
        this.config.load();
        this.config.secret = path;
        this.config.save();
    }    
}

export function GetConfig(config) {
    return new Config(config);
} 
