import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LibraryPageFilter } from '../../library/data-sources/library-data-source';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { Observable } from 'rxjs';
import { LibraryPageModel } from '../../library/models/library-page.model';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { FriendsPageModel } from '../models/friends-page.model';
import { FriendsPageFilter } from '../data-sources/friends-data-source';

@Injectable()
export class FriendsService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.basseMicroservicesUrl}`;

    constructor(private _httpClient: HttpClient) { }

    public getFriends(filter: FriendsPageFilter, architectureType: ArchitectureTypeEnum): Observable<FriendsPageModel> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.FRIENDS_GET_FRIENDS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.FRIENDS_GET_FRIENDS}` ;
                break;
        }
        return this._httpClient.post<FriendsPageModel>(url, filter);
    }
}