import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { LoginAccount, RegisterAccount, LoggedInUser } from '../models/account.model';

@Injectable()
export class AccountService{
    private baseUrl = `${environment.baseMonolithUrl}`;

    constructor(private httpClient: HttpClient) {
    }

    public login( model: LoginAccount): Observable<LoggedInUser>{
        var url = `${this.baseUrl}${ApplicationAPI.ACCOUNT_LOGIN}` ;

        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public register( model: RegisterAccount): Observable<LoggedInUser>{
        var url = `${this.baseUrl}${ApplicationAPI.ACCOUNT_REGISTER}` ;
        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public logout(): Observable<void>{
        var url = `${this.baseUrl}${ApplicationAPI.ACCOUNT_LOGOUT}` ;
        return this.httpClient.post<void>(url, null);
    }
}