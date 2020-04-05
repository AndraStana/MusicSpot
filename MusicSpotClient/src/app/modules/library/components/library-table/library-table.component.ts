import { Component, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { LibraryDataSource, LibraryPageFilter } from '../../data-sources/library-data-source';
import { LibraryService } from '../../services/library.service';
import { ActivatedRoute } from '@angular/router';
import { MatPaginator } from '@angular/material';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';


@Component({
  selector: 'app-library-table',
  templateUrl: './library-table.component.html',
  styleUrls: ['./library-table.component.scss']
})
export class LibraryTableComponent implements OnInit {

  @Input() public architectureType: ArchitectureTypeEnum;
  @Output() public onRequestFinish: EventEmitter<void> =new EventEmitter<void>();
  @Output() public onRequestStart: EventEmitter<void> = new EventEmitter<void>();


  public displayedColumns = ["name", "artist", "album", "year"];
  public songsNumber: number;
  public filter: LibraryPageFilter = null;
  public userId: string;

  public displayTable = false;


  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;

  public dataSource: LibraryDataSource;

    constructor(private _libraryService: LibraryService,
      private _localStorage: LocalStorageService,
      private _route: ActivatedRoute) {}

    ngOnInit() {
      this.userId = this._route.snapshot.paramMap.get('userId');
      this.initFilter();

     

      this._libraryService.getLibrarySongsNumber(this.filter.userId, this.architectureType ).subscribe(
        res => {this.songsNumber = res;}
      );

      this.dataSource = new LibraryDataSource(this._libraryService);
      this.dataSource.getLibrarySongs(this.filter, this.architectureType);
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
      })

      this.paginator.page.pipe(
              tap(() => {
                this.filter.pageIndex =  this.paginator.pageIndex;
                this.filter.pageSize =  this.paginator.pageSize;

                this.loadLibrarySongs(this.filter);
              })).subscribe();
      }

    public loadLibrarySongs(filter: LibraryPageFilter) {
        this.dataSource.getLibrarySongs(this.filter, this.architectureType);
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
}

