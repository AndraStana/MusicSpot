import { Component, OnInit, Input } from '@angular/core';
import { ArtistModel } from '../../models/artist.model';

@Component({
  selector: 'app-artist-panel',
  templateUrl: './artist-panel.component.html',
  styleUrls: ['./artist-panel.component.scss']
})
export class ArtistPanelComponent implements OnInit {

  @Input() artist: ArtistModel;

  constructor() { }

  ngOnInit() {
  }

}
