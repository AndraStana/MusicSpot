import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { Song } from 'src/app/shared/models/song.model';
import { BasicPageFilter } from 'src/app/shared/models/basic-page.filter';
import { RecommendedService } from '../../services/recommended.service';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';

@Component({
  selector: 'app-recommended-page-content',
  templateUrl: './recommended-page-content.component.html',
  styleUrls: ['./recommended-page-content.component.scss']
})
export class RecommendedPageContentComponent implements OnInit {

  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "RECOMMENDED";

  allRecommendedSongs: Song[] = [];  
  page: BasicPageFilter = <BasicPageFilter> {
    pageIndex : 0,
    pageSize : 30,
    userId: this._localStorage.getItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID)
  };  
  constructor(private _recommendedService: RecommendedService,
    private _localStorage: LocalStorageService
    ) { }  
 
  ngOnInit() {  
  }  

  ngAfterViewInit(): void {
    this.getRecommendedSongs();  
  }
  
  getRecommendedSongs() { 
    this.timer.resetTimer();
    this.timer.startTimerAsync("Get Recommended songs");
    this._recommendedService.getRecommendedSongs(this.page, this.architectureType).subscribe((res) => {  
      this.allRecommendedSongs = this.allRecommendedSongs.concat(res);
      this.timer.stopTimerAsync();

    });  
  }  
  onScroll() {  
    this.page.pageIndex = this.page.pageIndex + 1;  
    this.getRecommendedSongs();  
  }  
}  

