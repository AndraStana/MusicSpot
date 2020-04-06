import { DataSource } from '@angular/cdk/table';
import { Song } from 'src/app/shared/models/song.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { LibraryService } from '../services/library.service';
import { CollectionViewer } from '@angular/cdk/collections';
import { GenreEnum, DecadeEnum, ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

import {PopularityRanking} from './../models/popularity-ranking.model';

export class LibraryDataSource implements DataSource<Song> {

    private librarySubject = new BehaviorSubject<Song[]>([]);
    private libraryCountSubject = new BehaviorSubject<number>(0);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public loading$ = this.loadingSubject.asObservable();
    public libraryCount$ = this.libraryCountSubject.asObservable();

    constructor(private libraryService: LibraryService) {}

    connect(collectionViewer: CollectionViewer): Observable<Song[]> {
        return this.librarySubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.librarySubject.complete();
        this.loadingSubject.complete();
    }

        public getLibrarySongs(filter: LibraryPageFilter,architectureType: ArchitectureTypeEnum): void{
            this.loadingSubject.next(true);
            this.libraryService.getLibrarySongs(filter, architectureType)
                .subscribe(libraryPage =>
                    {
                        this.loadingSubject.next(false);
                        this.librarySubject.next(libraryPage.songs);
                        this.libraryCountSubject.next(libraryPage.totalNumber);

                    });
    }    
}

export class LibraryPageFilter{
    public userId: string;
    public genre: GenreEnum;
    public decade: DecadeEnum;
    public popularityRankingId: string; 
    public pageIndex: number;
    public pageSize: number;
}