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
import { FriendsDialogFilter } from '../models/friend-dialog.model';
import { Friend } from '../models/friend.model';
import {  AddRemoveFriendModel } from '../models/add-remove-friend.model';

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

    public getAllPossibleFriends(filter: FriendsDialogFilter, architectureType: ArchitectureTypeEnum): Observable<Friend[]> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.FRIENDS_GET_ALL_POSSIBLE_FRIENDS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.FRIENDS_GET_ALL_POSSIBLE_FRIENDS}` ;
                break;
        }
        var params = {
            userId: filter.userId
        }
        // return this.httpClient.get<StudentDetailsModel>(url, {params});

        console.log("url    ", url);
        return this._httpClient.get<Friend[]>(url,{params});
    }

    public removeFriend(model: AddRemoveFriendModel, architectureType: ArchitectureTypeEnum): Observable<void> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.FRIENDS_REMOVE_FRIEND}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.FRIENDS_REMOVE_FRIEND}` ;
                break;
        }
        return this._httpClient.post<void>(url, model);
    }

    public addFriend(model: AddRemoveFriendModel, architectureType: ArchitectureTypeEnum): Observable<void> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.FRIENDS_ADD_FRIEND}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.FRIENDS_ADD_FRIEND}` ;
                break;
        }
        return this._httpClient.post<void>(url, model);
    }

}