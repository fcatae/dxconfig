var argv = require('yargs')
    .command('login [token]', 'Log on configuration server', {}, (argv) => {
        console.log(argv._[0] + ': Not implemented yet')
    })

    .command('init', 'Create a DX configuration file', {}, (argv) => {
        console.log(argv._[0] + ': Not implemented yet')
    })

    .command('add <file>', 'Add secret file', {}, (argv) => {
        console.log(argv._[0] + ': Not implemented yet')
    })

    .command('push', 'Update remote configuration server', {}, (argv) => {
        console.log(argv._[0] + ': Not implemented yet')
    })

    .command('pull', 'Fetch configuration from remote server', {}, (argv) => {
        console.log(argv._[0] + ': Not implemented yet')
    })

    .command({
        command: 'exemple <key> [value]',
        aliases: ['e'],
        desc: 'Example command',
        builder: (yargs) => yargs.default('value', 'true'),
        handler: (argv) => {
            console.log(argv._[0] + ': Not implemented yet')            
            console.log(`Example setting ${argv.key} to ${argv.value}`)
        }
    })
    .demandCommand()
    .help()
    .argv;
