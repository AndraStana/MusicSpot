import { DataSource } from '@angular/cdk/table';
import { Song } from 'src/app/shared/models/song.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { FriendsService } from '../services/friends.service';
import { CollectionViewer } from '@angular/cdk/collections';
import { GenreEnum, DecadeEnum, ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

import { Friend } from '../models/friend.model';

export class FriendsDataSource implements DataSource<Friend> {

    private friendsSubject = new BehaviorSubject<Friend[]>([]);
    private friendsCountSubject = new BehaviorSubject<number>(0);
    private loadingSubject = new BehaviorSubject<boolean>(false);

    public loading$ = this.loadingSubject.asObservable();
    public friendsCount$ = this.friendsCountSubject.asObservable();

    constructor(private friendsService: FriendsService) {

    }

    connect(collectionViewer: CollectionViewer): Observable<Friend[]> {
        return this.friendsSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.friendsSubject.complete();
        this.loadingSubject.complete();
    }

        public getFriends(filter: FriendsPageFilter,architectureType: ArchitectureTypeEnum): void{
            this.loadingSubject.next(true);
            this.friendsService.getFriends(filter, architectureType)
                .subscribe(friendsPage =>
                    {
                        this.loadingSubject.next(false);
                        this.friendsSubject.next(friendsPage.friends);
                        this.friendsCountSubject.next(friendsPage.totalNumber);

                    });
    }    
}

export class FriendsPageFilter{
    public userId: string;
    public pageIndex: number;
    public pageSize: number;
}