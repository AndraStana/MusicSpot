import { DataSource } from '@angular/cdk/table';
import { Song } from 'src/app/shared/models/song.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { LibraryService } from '../services/library.service';
import { CollectionViewer } from '@angular/cdk/collections';
import { GenreEnum, DecadeEnum, ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

import {PopularityRanking} from './../models/popularity-ranking.model';

export class LibraryDataSource implements DataSource<Song> {

    private librarySubject = new BehaviorSubject<Song[]>([]);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public loading$ = this.loadingSubject.asObservable();

    constructor(private libraryService: LibraryService) {}

    connect(collectionViewer: CollectionViewer): Observable<Song[]> {
        return this.librarySubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.librarySubject.complete();
        this.loadingSubject.complete();
    }

    // loadLessons(courseId: number, filter = '',
    //             sortDirection = 'asc', pageIndex = 0, pageSize = 3) {


        public getLibrarySongs(filter: LibraryPageFilter,architectureType: ArchitectureTypeEnum): void{
            this.loadingSubject.next(true);
            this.libraryService.getLibrarySongs(filter, architectureType)
                .subscribe(songs =>
                    {
                        this.loadingSubject.next(false);
                        this.librarySubject.next(songs);
                    });

        // this.coursesService.findLessons(courseId, filter, sortDirection,
        //     pageIndex, pageSize).pipe(
        //     catchError(() => of([])),
        //     finalize(() => this.loadingSubject.next(false))
        // )
        // .subscribe(lessons => this.librarySubject.next(lessons));
    }    
}


export class LibraryPageFilter{
    public userId: string;
    public genre: GenreEnum;
    public decade: DecadeEnum;
    public popularityRankingId: PopularityRanking; 
    public pageIndex: number;
    public pageSize: number;
}