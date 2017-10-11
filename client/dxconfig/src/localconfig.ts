import * as files from './platform/files';

class LocalConfig {
    app: string;
    secret?: string | null;

    load() {
        var filename = files.getLocalConfigPath();
        var json = files.readJson(filename);

        this.validateJsonFormat(json);

        this.app = json.app;
        this.secret = json.secret;
    }
    exist() : boolean {
        var filename = files.getLocalConfigPath();
        return files.existFile(filename);
    }
    save() {
        this.validateJsonFormat(this);

        var filename = files.getLocalConfigPath();
        files.writeJson(filename, this);
    }

    private validateJsonFormat(json) {
        if( json.app == null )
            throw "local config object has null values";
    }
}

class TestLocalConfig {
    app: string;
    secret?: string | null;

    load() {
        console.log('local configuration file loaded')
        console.dir(this);
    }
    exist() : boolean {
        return true;
    }
    save() {
        console.log('local configuration file saved')
        console.dir(this);
    }
}

export var Config = new LocalConfig();
