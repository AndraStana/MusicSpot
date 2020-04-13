import { Component, OnInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-news-page',
  templateUrl: './news-page.component.html',
  styleUrls: ['./news-page.component.scss']
})
export class NewsPageComponent implements OnInit {

  public title = "NEWS";
  ArchitectureTypeEnum = ArchitectureTypeEnum;

  constructor() { }

  ngOnInit() {
  }

}
