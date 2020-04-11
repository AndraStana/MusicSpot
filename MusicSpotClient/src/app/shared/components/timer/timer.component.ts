import { Component, OnInit, Input } from '@angular/core';
import { ArchitectureTypeEnum } from '../../enums/enums';

@Component({
  selector: 'app-timer',
  templateUrl: './timer.component.html',
  styleUrls: ['./timer.component.scss']
})
export class TimerComponent implements OnInit {

  @Input() architectureType: ArchitectureTypeEnum;
  public title: string;

  public operationName: string;

  public startTime: Date;
  public endTime: Date;

  public duration: any;
  public intervalListener: any; 

  public timerStarted = false;

  constructor() { }

  ngOnInit() {
    this.title =
      this.architectureType === ArchitectureTypeEnum.Monolith ? "Monolith" : "Microservices";
  }
 

  public async startTimerAsync(operationName: string):  Promise<void> {

    this.operationName = operationName;
    this.timerStarted = true;

    this.duration = null;
    this.startTime = new Date();
    this.endTime = new Date();

    this.intervalListener = setInterval(() => {
        this.endTime = new Date();
    },1);

  }

  public async stopTimerAsync(): Promise<void> {
    if(this.timerStarted==true){
      clearInterval(this.intervalListener);
      this.duration = this.getDataDiff(this.startTime,this.endTime);
  }
}


  public resetTimer(): void{
    this.duration = null;
    this.startTime = null;
    this.endTime = null;
  }


  getDataDiff(startDate, endDate) {
    if(startDate !=null && startDate !== undefined 
      && endDate !=null && endDate !== undefined)
      {
        var diff = endDate.getTime() - startDate.getTime();
        var days = Math.floor(diff / (60 * 60 * 24 * 1000));
        var hours = Math.floor(diff / (60 * 60 * 1000)) - (days * 24);
        var minutes = Math.floor(diff / (60 * 1000)) - ((days * 24 * 60) + (hours * 60));
        var seconds = Math.floor(diff / 1000) - ((days * 24 * 60 * 60) + (hours * 60 * 60) + (minutes * 60));
        var miliseconds = Math.floor(diff) - ((days * 24 * 60 * 60 *1000) + (hours * 60 * 60 * 1000) + (minutes * 60 * 1000) + (seconds * 1000) );
      }

    return { days: days, hours: hours, minutes: minutes, seconds: seconds, miliseconds: miliseconds };
  }


}
