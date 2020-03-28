import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-recommended-page',
  templateUrl: './recommended-page.component.html',
  styleUrls: ['./recommended-page.component.scss']
})
export class RecommendedPageComponent implements OnInit {

  public title= "RECOMMENDED";

  constructor() { }

  ngOnInit() {
  }

}
