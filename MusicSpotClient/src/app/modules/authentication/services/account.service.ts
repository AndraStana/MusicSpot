import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountAPI } from 'src/app/shared/routing/api-urls';
import { LoginAccount, RegisterAccount, LoggedInUser } from '../models/account.model';

@Injectable()
export class AccountService{
    private baseUrl = `${environment.baseUrl}`;

    constructor(private httpClient: HttpClient) {
    }

    
    public login( model: LoginAccount): Observable<LoggedInUser>{
        var url = `${this.baseUrl}${AccountAPI.LOGIN}` ;

        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public register( model: RegisterAccount): Observable<LoggedInUser>{
        var url = `${this.baseUrl}${AccountAPI.REGISTER}` ;
        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public logout(): Observable<void>{
        var url = `${this.baseUrl}${AccountAPI.LOGOUT}` ;
        return this.httpClient.post<void>(url, null);
    }
}