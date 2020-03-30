import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-library-page',
  templateUrl: './library-page.component.html',
  styleUrls: ['./library-page.component.scss']
})
export class LibraryPageComponent implements OnInit {

  ArchitectureTypeEnum = ArchitectureTypeEnum;

  constructor(private _datePipe: DatePipe) { 
  }

  ngOnInit() {
  }

}
