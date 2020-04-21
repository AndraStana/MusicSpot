import { Component, OnInit, Input } from '@angular/core';
import { ArtistModel } from '../../models/artist.model';
import { MatDialog } from '@angular/material';
import { SongsDialogComponent, SongsDialogData } from '../songs-dialog/songs-dialog.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-artist-panel',
  templateUrl: './artist-panel.component.html',
  styleUrls: ['./artist-panel.component.scss']
})
export class ArtistPanelComponent implements OnInit {

  @Input() artist: ArtistModel;
  @Input() architectureType: ArchitectureTypeEnum;


  constructor(private _dialog: MatDialog) { }

  ngOnInit() {
  }

  public onAlbumClicked(albumId: string): void{

    var album = this.artist.albums.find(a => a.id=== albumId );

    const dialogRef = this._dialog.open(SongsDialogComponent, {
      width: '600px',
      height: '600px',
      data: <SongsDialogData>{
        album: album,
        architectureType: this.architectureType
      }
    });

    dialogRef.afterClosed().subscribe();
  }

}
