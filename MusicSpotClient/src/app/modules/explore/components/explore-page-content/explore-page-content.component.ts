import { Component, OnInit, ViewChild, Input, AfterViewInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ExploreService } from '../../services/explore.services';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { ArtistPageFilter } from '../../models/artist-page-filter';
import { ArtistModel } from '../../models/artist.model';

@Component({
  selector: 'app-explore-page-content',
  templateUrl: './explore-page-content.component.html',
  styleUrls: ['./explore-page-content.component.scss']
})
export class ExplorePageContentComponent implements OnInit, AfterViewInit {


  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "EXPLORE";

  public allArtists: ArtistModel[] = [];

  page: ArtistPageFilter = <ArtistPageFilter> {
    pageIndex : 0,
    pageSize : 30,
    libraryId: this._localStorage.getItem<string>(LocalStorageKeys.USER_LIBRARY_ID),
    searchText: ""
  };  

  constructor(private _exploreService: ExploreService,
    private _localStorage: LocalStorageService
    ) { }


  ngOnInit(): void {
  }


  ngAfterViewInit(): void {
    this.getArtists();
  }

  getArtists() { 
    this.timer.resetTimer();
    this.timer.startTimerAsync("Get artists");
    this._exploreService.getArtists(this.page, this.architectureType).subscribe((res) => {  
      this.allArtists = this.allArtists.concat(res);
      this.timer.stopTimerAsync();
    });  
  }  
  onScroll() {  
    this.page.pageIndex = this.page.pageIndex + 1;  
    this.getArtists();  
  }

  public search(text: string){
    this.page.searchText = text !== null && text!== undefined ?  text: "";
    this.page.pageIndex = 0;
    this.allArtists=[];

    this.getArtists();
  }

}
