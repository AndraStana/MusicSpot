import { Component, OnInit, Input } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-recommended-page',
  templateUrl: './recommended-page.component.html',
  styleUrls: ['./recommended-page.component.scss']
})
export class RecommendedPageComponent implements OnInit {

  public title = "RECOMMENDED";
  ArchitectureTypeEnum = ArchitectureTypeEnum;

  constructor() { }

  ngOnInit() {
  }

}
