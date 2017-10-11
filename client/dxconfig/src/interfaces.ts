export interface ICommandHub {
    login();
    loginToken(token: string);
    configInit();
    configAddSecret(path: string)
    serverPush();
    serverPull();
}