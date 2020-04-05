import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Song } from 'src/app/shared/models/song.model';
import { Observable, of } from 'rxjs';
import { LibraryPageFilter } from '../data-sources/library-data-source';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { environment } from 'src/environments/environment';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

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
        // return of(
        //     [
        //         <Song>{
        //             name: "song1",
        //             artist: "artist1",
        //             album: "album1",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song2",
        //             artist: "artist2",
        //             album: "album2",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song3",
        //             artist: "artist1",
        //             album: "album1",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song4",
        //             artist: "artist2",
        //             album: "album2",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song5",
        //             artist: "artist1",
        //             album: "album1",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song6",
        //             artist: "artist2",
        //             album: "album2",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song7",
        //             artist: "artist1",
        //             album: "album1",
        //             year: 1993
        //         },
        //         <Song>{
        //             name: "song8",
        //             artist: "artist2",
        //             album: "album2",
        //             year: 1993
        //         }

        //     ]
    }
}