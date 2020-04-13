import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song } from 'src/app/shared/models/song.model';
import { Observable, of } from 'rxjs';
import { LibraryPageFilter } from '../data-sources/library-data-source';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { environment } from 'src/environments/environment';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { PopularityRanking } from '../models/popularity-ranking.model';
import { LibraryPageModel } from '../models/library-page.model';

@Injectable()
export class LibraryService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.baseMicroservicesUrl}`;

    constructor(private _httpClient: HttpClient) { }


    public getLibrarySongs(filter: LibraryPageFilter, architectureType: ArchitectureTypeEnum): Observable<LibraryPageModel> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.LIBRARY_GET_SONGS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.LIBRARY_GET_SONGS}` ;
                break;
        }
        return this._httpClient.post<LibraryPageModel>(url, filter);
    }

    public getPopularityRankings(architectureType: ArchitectureTypeEnum): Observable<PopularityRanking[]>{
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.LIBRARY_GET_POPULARITY_RANKINGS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.LIBRARY_GET_POPULARITY_RANKINGS}` ;
                break;
        }
        return this._httpClient.get<PopularityRanking[]>(url);
    }
}