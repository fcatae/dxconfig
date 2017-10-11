import { Command } from './command';
import { HubNotImplemented } from './commandhub';

console.log('dxconfig v0.1');

//var client = require('./client');

//var client = require('./config');
//var client = require('./session');


Command.dispatch(HubNotImplemented);
