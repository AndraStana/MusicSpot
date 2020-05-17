import { Component, OnInit, ViewChild, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { LibraryDataSource, LibraryPageFilter } from '../../data-sources/library-data-source';
import { LibraryService } from '../../services/library.service';
import { ActivatedRoute } from '@angular/router';
import { MatPaginator } from '@angular/material';
import { Observable, of, Subscription } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { DropdownItem } from 'src/app/shared/components/dropdown/dropdown.component';
import { GenreFilterHelper } from 'src/app/shared/helpers/genre-filter-helper';
import { DecadeFilterHelper } from 'src/app/shared/helpers/decade-filter-helper';
import { AddRemoveSongModel } from 'src/app/shared/models/add-remove-song.model';

@Component({
  selector: 'app-library-table',
  templateUrl: './library-table.component.html',
  styleUrls: ['./library-table.component.scss']
})
export class LibraryTableComponent implements OnInit, OnDestroy {

  @Input() public architectureType: ArchitectureTypeEnum;
  @Output() public onRequestFinish: EventEmitter<void> = new EventEmitter<void>();
  @Output() public onRequestStart: EventEmitter<string> = new EventEmitter<string>();

  public displayedColumns = ["name", "artist", "album", "year", "actions"];
  public songsNumber: number;
  public filter: LibraryPageFilter = null;
  public userId: string;

  public displayTable = false;

  public genreDropdownItems: DropdownItem[] = [];
  public decadeDropdownItems: DropdownItem[] = [];
  public popularityDropdownItems: DropdownItem[] = [];

  private deletedSongIds:string[] = [];

  subscriber:Subscription;

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  public dataSource: LibraryDataSource;

    constructor(private _libraryService: LibraryService,
      private _localStorage: LocalStorageService,
      private _route: ActivatedRoute) {}


  ngOnDestroy(): void {
      this.subscriber.unsubscribe();
  }

    ngOnInit() {

      this.initDropdownItems();
      this.userId = this._route.snapshot.paramMap.get('userId');
      this.initFilter();

      this.dataSource = new LibraryDataSource(this._libraryService);

      setTimeout(() => {
      this.dataSource.getLibrarySongs(this.filter, this.architectureType);
        
      });
   }

    public ngAfterViewInit(): void {
    this.subscriber =  this.dataSource.loading$.subscribe(res=>{
        if(res === true){
          this.onRequestStart.emit("Get library's songs");
          this.displayTable = false;

        }
        if(res === false){
          this.onRequestFinish.emit();
          this.displayTable = true;
        }
      });

      this.dataSource.libraryCount$.subscribe(res=>{
          this.songsNumber = res;
        });

      this.paginator.page.pipe(
              tap(() => {
                this.filter.pageIndex =  this.paginator.pageIndex;
                this.filter.pageSize =  this.paginator.pageSize;

                this.loadLibrarySongs();
              })).subscribe();
      }

    public loadLibrarySongs() {
        this.dataSource.getLibrarySongs(this.filter, this.architectureType);
    }

    public onGenreChanged(event: string){
      if(event == "-1"){
        this.filter.genre = null;
      }
      else{
        this.filter.genre = Number(event);
      }

      this.loadLibrarySongs();
    }

    public onDecadeChanged(event: string){
      if(event == "-1"){
        this.filter.decade = null;
      }
      else{
        this.filter.decade = Number(event);
      }
      this.loadLibrarySongs();
    }

    public onPopularityChanged(event: string){

      if(event == "-1"){
        this.filter.popularityRankingId = null;
      }
      else{
        this.filter.popularityRankingId = event;
      }
      this.loadLibrarySongs();
    }

    public refreshTable(): void{
       this.loadLibrarySongs()
    }

    private initFilter(): void{
      this.filter = <LibraryPageFilter>{
        userId: this.userId,
        genre: null,
        decade: null,
        popularityRankingId: null,
        pageIndex: 0,
        pageSize: 5
     }
    }

      private initDropdownItems(): void{
        this.genreDropdownItems = GenreFilterHelper.createGenreDropdownItemList();
        this.decadeDropdownItems = DecadeFilterHelper.createDecadeDropdownItemList();
        this._libraryService.getPopularityRankings(this.architectureType)
          .subscribe(
            res =>{
              this.popularityDropdownItems = res.map(p=> <DropdownItem> p);
              this.popularityDropdownItems.unshift(<DropdownItem> {id : "-1", name : "ALL"})
            }
          )
      }

      onBtnClicked(songId: string, isInLibrary: boolean){
        var libraryId = this._localStorage.getItem<string>(LocalStorageKeys.USER_LIBRARY_ID);
        if(isInLibrary == true){
          this.removeSongFromLibrary(libraryId, songId);
      }
    }
    
      private removeSongFromLibrary(libraryId, songId): void{
        this.onRequestStart.emit("Remove song from library");


        this.deletedSongIds.push(songId);
    
        this._libraryService.removeSongFromLibrary(
          <AddRemoveSongModel>{
            libraryId: libraryId,
            songId: songId
            }, this.architectureType
          ).subscribe(
            res =>{
              this.onRequestFinish.emit();
            }
          )
      }

      public hideButton(songId: string ): boolean{
        return ! this.deletedSongIds.find(sid=> sid == songId);
      }
    
   
  }  