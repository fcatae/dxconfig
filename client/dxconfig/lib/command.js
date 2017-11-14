"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class YargsCommand {
    dispatch(hub) {
        require('yargs')
            .command('login <token>', 'Log on configuration server', {}, (argv) => {
            if (argv.token == null) {
                hub.login();
            }
            else {
                hub.loginToken(argv.token);
            }
        })
            .command('init', 'Create a DX configuration file', {}, (argv) => {
            hub.configInit();
        })
            .command('add <file>', 'Add secret file', {}, (argv) => {
            hub.configAddSecret(argv.file);
        })
            .command('push', 'Update remote configuration server', {}, (argv) => {
            hub.serverPush();
        })
            .command('pull', 'Fetch configuration from remote server', {}, (argv) => {
            hub.serverPull();
        })
            .command('logout', 'Log out from the server', {}, (argv) => {
            hub.logout();
        })
            .command('debug', 'Debug command', {}, (argv) => {
            console.log('DEBUG');
        })
            .demandCommand()
            .help('help').alias('help', '?')
            .argv;
    }
}
exports.Command = new YargsCommand();
