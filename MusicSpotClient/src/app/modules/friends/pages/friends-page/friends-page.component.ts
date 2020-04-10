import { Component, OnInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-friends-page',
  templateUrl: './friends-page.component.html',
  styleUrls: ['./friends-page.component.scss']
})
export class FriendsPageComponent implements OnInit {

  ArchitectureTypeEnum = ArchitectureTypeEnum;

  constructor(private _datePipe: DatePipe) { 
  }

  ngOnInit() {
  }

}
