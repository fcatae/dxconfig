"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const files = require("./platform/files");
class LocalConfig {
    load() {
        var filename = files.getLocalConfigPath();
        var json = files.readJson(filename);
        this.validateJsonFormat(json);
        this.app = json.app;
        this.secret = json.secret;
    }
    exist() {
        var filename = files.getLocalConfigPath();
        return files.existFile(filename);
    }
    save() {
        this.validateJsonFormat(this);
        var filename = files.getLocalConfigPath();
        files.writeJson(filename, this);
    }
    validateJsonFormat(json) {
        if (json.app == null)
            throw "local config object has null values";
    }
}
class TestLocalConfig {
    load() {
        console.log('local configuration file loaded');
        console.dir(this);
    }
    exist() {
        return true;
    }
    save() {
        console.log('local configuration file saved');
        console.dir(this);
    }
}
exports.Config = new LocalConfig();
