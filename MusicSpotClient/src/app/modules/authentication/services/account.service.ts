import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { LoginAccount, RegisterAccount, LoggedInUser } from '../models/account.model';
import { LibraryAddModel } from '../models/library-add.model';
import { UserAddModel } from '../models/user-add.model';

@Injectable()
export class AccountService{
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.baseMicroservicesMusicUrl}`;


    constructor(private httpClient: HttpClient) {
    }

    public login( model: LoginAccount): Observable<LoggedInUser>{
        var url = `${this.baseMonolithUrl}${ApplicationAPI.ACCOUNT_LOGIN}` ;

        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public register( model: RegisterAccount): Observable<LoggedInUser>{
        var url = `${this.baseMonolithUrl}${ApplicationAPI.ACCOUNT_REGISTER}` ;
        return this.httpClient.post<LoggedInUser>(url, model );
    }

    public logout(): Observable<void>{
        var url = `${this.baseMonolithUrl}${ApplicationAPI.ACCOUNT_LOGOUT}` ;
        return this.httpClient.post<void>(url, null);
    }

    public createMicroserviceLibrary(model: LibraryAddModel): Observable<void>{
        var url = `${this.baseMicroservicesUrl}${ApplicationAPI.MICROSERVICES_LIBRARY_ADD}` ;
        return this.httpClient.post<void>(url, model);
    }

    public createMicroserviceUser(model: UserAddModel): Observable<void>{
        var url = `${this.baseMicroservicesUrl}${ApplicationAPI.MICROSERVICES_USERS_ADD}` ;
        return this.httpClient.post<void>(url, model);
    }
}