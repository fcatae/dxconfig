import { ICommandHub } from './interfaces';
import { HubNotImplemented } from './commandhub';

class YargsCommand {

    dispatch(hub: ICommandHub) {

        require('yargs')

        // dxconfig login
        .command('login <token>', 'Log on configuration server', {}, (argv) => {
            if( argv.token == null ) {
                hub.login();
            } else {
                hub.loginToken(argv.token);
            }        
        })

        // dxconfig init
        .command('init', 'Create a DX configuration file', {}, (argv) => {
            hub.configInit();            
        })

        // dxconfig add secret.json
        .command('add <file>', 'Add secret file', {}, (argv) => {
            hub.configAddSecret(argv.file);
        })

        // dxconfig push
        .command('push', 'Update remote configuration server', {}, (argv) => {
            hub.serverPush();
        })

        // dxconfig pull
        .command('pull', 'Fetch configuration from remote server', {}, (argv) => {
            hub.serverPull();
        })

        // logout
        .command('logout', 'Log out from the server', {}, (argv) => {
            hub.logout();
        })

        // debug
        .command('debug', 'Debug command', {}, (argv) => {
            console.log('DEBUG');
        })

        .demandCommand()
        .help('help').alias('help', '?')
        // add examples:
        // .example('dxconfig init', 'Init a simple configuration')
        .argv;
    }

}

export var Command = new YargsCommand();
