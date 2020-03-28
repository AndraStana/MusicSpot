import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {

  public startTime: Date;
  public endTime: Date;

  public duration;

  public intervalListener: any; 

  constructor() { }

  ngOnInit() {
  }
 

  public async startTimerAsync():  Promise<void> {
    this.startTime = new Date();
    this.endTime = new Date();

    this.intervalListener = setInterval(() => {
        this.endTime = new Date();
    },1);
  }

  public async stopTimerAsync(): Promise<void> {
    clearInterval(this.intervalListener);

    this.duration = this.getDataDiff(this.startTime,this.endTime);
  }

  getDataDiff(startDate, endDate) {
    var diff = endDate.getTime() - startDate.getTime();
    var days = Math.floor(diff / (60 * 60 * 24 * 1000));
    var hours = Math.floor(diff / (60 * 60 * 1000)) - (days * 24);
    var minutes = Math.floor(diff / (60 * 1000)) - ((days * 24 * 60) + (hours * 60));
    var seconds = Math.floor(diff / 1000) - ((days * 24 * 60 * 60) + (hours * 60 * 60) + (minutes * 60));
    var miliseconds = Math.floor(diff) - ((days * 24 * 60 * 60 *1000) + (hours * 60 * 60 * 1000) + (minutes * 60 * 1000) + (seconds * 1000) );
    
    return { days: days, hours: hours, minutes: minutes, seconds: seconds, miliseconds: miliseconds };
  }


}
