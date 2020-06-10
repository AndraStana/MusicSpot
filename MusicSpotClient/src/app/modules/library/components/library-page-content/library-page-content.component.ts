import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';

@Component({
  selector: 'app-library-page-content',
  templateUrl: './library-page-content.component.html',
  styleUrls: ['./library-page-content.component.scss']
})
export class LibraryPageContentComponent implements OnInit {

  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "MY LIBRARY";

  constructor(private _localStorage: LocalStorageService) { }

  ngOnInit() {
    this.title = this._localStorage.getItem(LocalStorageKeys.LIBRARY_PAGE_TITLE);
  }

  requestFinish(){
    this.timer.stopTimerAsync().then();
  }
  requestStart(event: string){
    this.timer.startTimerAsync(event).then();
  }

}


