import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountAPI } from 'src/app/shared/routing/api-urls';
import { UserAccount } from '../models/account.model';

@Injectable()
export class AccountService{
    private baseUrl = `${environment.baseUrl}`;

    constructor(private httpClient: HttpClient) {
    }

    
    public login( model: UserAccount): Observable<boolean>{
        var url = `${this.baseUrl}${AccountAPI.LOGIN}` ;
        return this.httpClient.post<boolean>(url, model );
    }

    public register( model: UserAccount): Observable<boolean>{
        var url = `${this.baseUrl}${AccountAPI.REGISTER}` ;
        return this.httpClient.post<boolean>(url, model );
    }
}