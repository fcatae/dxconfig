import path = require('path');
import http = require('http');
import fs = require('fs');
import os = require('os');
import request = require('request');
import url = require('url');

import globalrequire = require('./global');

import { ILocalConfig } from './interfaces';

var CONFIGFILE = 'dxconfig.json';

var configserver = globalrequire.globalconf.data;

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
