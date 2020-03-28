import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';

@Component({
  selector: 'app-library-page',
  templateUrl: './library-page.component.html',
  styleUrls: ['./library-page.component.scss']
})
export class LibraryPageComponent implements OnInit, AfterViewInit {

  public title = "MY LIBRARY";

  @ViewChild("monolithTimer", {static:false} ) monolithTimer: TimerComponent;
  @ViewChild("microservicesTimer", {static:false}) microservicesTimer: TimerComponent;


  constructor(private _datePipe: DatePipe) { 

  }
  ngAfterViewInit(): void {
    this.monolithTimer.startTimerAsync().then();
    this.microservicesTimer.startTimerAsync().then();
  }

  ngOnInit() {


  }




  stop(){ 
    
    this.monolithTimer.stopTimerAsync().then();
    this.microservicesTimer.stopTimerAsync().then();

  }










}
