export interface ICommandHub {
    login();
    loginToken(token: string);
    logout();
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

export interface ILocalConfig {
    app: string;
    secret?: string | null;
    load();
    exist() : boolean;
    save();
}