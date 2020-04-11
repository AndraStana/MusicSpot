import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { DropdownItem } from 'src/app/shared/components/dropdown/dropdown.component';
import { MatPaginator } from '@angular/material';
import { FriendsService as FriendsService } from 'src/app/modules/friends/services/friends.service';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { ActivatedRoute } from '@angular/router';
import { tap } from 'rxjs/operators';
import { FriendsDataSource, FriendsPageFilter } from '../../data-sources/friends-data-source';

@Component({
  selector: 'app-friends-table',
  templateUrl: './friends-table.component.html',
  styleUrls: ['./friends-table.component.scss']
})
export class FriendsTableComponent implements OnInit {


  @Input() public architectureType: ArchitectureTypeEnum;
  @Output() public onRequestFinish: EventEmitter<void> = new EventEmitter<void>();
  @Output() public onRequestStart: EventEmitter<void> = new EventEmitter<void>();

  public displayedColumns = ["name", "age", "libraryName", "actions"];
  public friendsNumber: number;
  public filter: FriendsPageFilter = null;
  public userId: string;

  public displayTable = false;

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  public dataSource: FriendsDataSource;

    constructor(private _friendsService: FriendsService,
      private _localStorage: LocalStorageService,
      private _route: ActivatedRoute) {}

    ngOnInit() {

      this.userId = this._localStorage.getItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID);
      this.initFilter();

      this.dataSource = new FriendsDataSource(this._friendsService);
      this.dataSource.getFriends(this.filter, this.architectureType);
   }

    public ngAfterViewInit(): void {
      this.dataSource.loading$.subscribe(res=>{
        if(res === false){
          this.onRequestFinish.emit();
          this.displayTable = true;
        }
        if(res === true){
          this.onRequestStart.emit();
          this.displayTable = false;

        }
      });

      this.dataSource.friendsCount$.subscribe(res=>{
          this.friendsNumber = res;
        });

      this.paginator.page.pipe(
              tap(() => {
                this.filter.pageIndex =  this.paginator.pageIndex;
                this.filter.pageSize =  this.paginator.pageSize;

                this.loadFriendsSongs();
              })).subscribe();
      }

    public loadFriendsSongs() {
        this.dataSource.getFriends(this.filter, this.architectureType);
    }

    public refreshTable(): void{
      this.loadFriendsSongs();
    }
 
  
    private initFilter(): void{
      this.filter = <FriendsPageFilter>{
        userId: this.userId,
        pageIndex: 0,
        pageSize: 7
     }
    }

}
