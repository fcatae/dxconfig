"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var YargsCommand = /** @class */ (function () {
    function YargsCommand() {
    }
    YargsCommand.prototype.dispatch = function (hub) {
        require('yargs')
            .command('login <token>', 'Log on configuration server', {}, function (argv) {
            if (argv.token == null) {
                hub.login();
            }
            else {
                hub.loginToken(argv.token);
            }
        })
            .command('init', 'Create a DX configuration file', {}, function (argv) {
            hub.configInit();
        })
            .command('add <file>', 'Add secret file', {}, function (argv) {
            hub.configAddSecret(argv.file);
        })
            .command('push', 'Update remote configuration server', {}, function (argv) {
            hub.serverPush();
        })
            .command('pull', 'Fetch configuration from remote server', {}, function (argv) {
            hub.serverPull();
        })
            .command('logout', 'Log out from the server', {}, function (argv) {
            hub.logout();
        })
            .demandCommand()
            .help('help').alias('help', '?')
            .argv;
    };
    return YargsCommand;
}());
exports.Command = new YargsCommand();
