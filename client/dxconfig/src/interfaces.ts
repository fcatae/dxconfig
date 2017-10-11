export interface ICommandHub {
    login();
    loginToken(token: string);
    configInit();
    configAddSecret(path: string)
    serverPush();
    serverPull();
}

export interface IGlobalConfig {
    endpoint: string | null;
    jwtToken: string | null;
    load();
    exist() : boolean;
    save();
    delete();
}