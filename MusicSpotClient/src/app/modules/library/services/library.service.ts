import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song } from 'src/app/shared/models/song.model';
import { Observable, of } from 'rxjs';
import { LibraryPageFilter } from '../data-sources/library-data-source';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { environment } from 'src/environments/environment';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { PopularityRanking } from '../models/popularity-ranking.model';

@Injectable()
export class LibraryService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.basseMicroservicesUrl}`;

    constructor(private _httpClient: HttpClient) { }

    public getLibrarySongsNumber(userId: string, architectureType: ArchitectureTypeEnum): Observable<number>{
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.LIBRARY_GET_SONGS_NUMBER}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.LIBRARY_GET_SONGS_NUMBER}` ;
                break;
        }

        var params = {
            userId
        }
        return this._httpClient.get<number>(url, {params});
    }

    public getLibrarySongs(filter: LibraryPageFilter, architectureType: ArchitectureTypeEnum): Observable<Song[]> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.LIBRARY_GET_SONGS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.LIBRARY_GET_SONGS}` ;
                break;
        }
        return this._httpClient.post<Song[]>(url, filter);
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