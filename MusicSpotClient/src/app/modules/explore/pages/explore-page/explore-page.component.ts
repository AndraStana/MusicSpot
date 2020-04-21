import { Component, OnInit } from '@angular/core';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-explore-page',
  templateUrl: './explore-page.component.html',
  styleUrls: ['./explore-page.component.scss']
})
export class ExplorePageComponent implements OnInit {

  ArchitectureTypeEnum = ArchitectureTypeEnum;
  constructor() { }

  ngOnInit() {
  }

}
