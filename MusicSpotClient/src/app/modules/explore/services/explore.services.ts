import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { BasicPageFilter } from 'src/app/shared/models/basic-page.filter';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { Observable } from 'rxjs';
import { Song } from 'src/app/shared/models/song.model';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { ArtistModel } from '../models/artist.model';
import { ArtistPageFilter } from '../models/artist-page-filter';

@Injectable()
export class ExploreService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.baseMicroservicesMusicUrl}`;

    constructor(private _httpClient: HttpClient) { }

    public getArtists(filter: ArtistPageFilter, architectureType: ArchitectureTypeEnum): Observable<ArtistModel[]> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.EXPLORE_GET_ARTISTS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.EXPLORE_GET_ARTISTS}` ;
                break;
        }
        return this._httpClient.post<ArtistModel[]>(url, filter);
    }
}