import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-friends-page-content',
  templateUrl: './friends-page-content.component.html',
  styleUrls: ['./friends-page-content.component.scss']
})
export class FriendsPageContentComponent implements OnInit {


  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "MY FRIENDS";

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

