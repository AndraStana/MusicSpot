import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';

@Component({
  selector: 'app-library-page-content',
  templateUrl: './library-page-content.component.html',
  styleUrls: ['./library-page-content.component.scss']
})
export class LibraryPageContentComponent implements OnInit {

  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "MY LIBRARY";

  constructor() { }

  ngOnInit() {
  }

  requestFinish(){
    this.timer.stopTimerAsync().then();
  }
  requestStart(){
    this.timer.startTimerAsync().then();
  }

}


