import { Injectable } from '@angular/core';

@Injectable()
export class LocalStorageService{

    public getItem<T> (key: string): T{
        return <T> JSON.parse(localStorage.getItem(key));
    }

    public setItem<T>(key: string, object: T): void{
        localStorage.setItem(key, JSON.stringify(object));
    }

    public removeItem(key: string): void{
        localStorage.removeItem(key);
    }
}

export enum LocalStorageKeys{
    IS_LOGGED_IN = "IS_LOGGED_IN",
    LOGGED_IN_USER_NAME = "LOGGED_IN_USER_NAME",
    LOGGED_IN_USER_ID = "LOGGED_IN_USER_ID",
}