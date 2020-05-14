import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { Observable } from 'rxjs';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { BasicPageFilter } from 'src/app/shared/models/basic-page.filter';
import { Song } from 'src/app/shared/models/song.model';

@Injectable()
export class RecommendedService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.baseMicroservicesMusicUrl}`;

    constructor(private _httpClient: HttpClient) { }

    public getRecommendedSongs(filter: BasicPageFilter, architectureType: ArchitectureTypeEnum): Observable<Song[]> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.RECOMMENDED_GET_RECOMMENDED_SONGS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.RECOMMENDED_GET_RECOMMENDED_SONGS}` ;
                break;
        }
        return this._httpClient.post<Song[]>(url, filter);
    }
}