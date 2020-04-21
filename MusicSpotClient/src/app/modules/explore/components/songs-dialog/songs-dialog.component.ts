import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { SongSimpleModel } from '../../models/song-simple-model';
import { LibraryService } from 'src/app/modules/library/services/library.service';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { AlbumModel } from '../../models/album.model';
import { AddRemoveSongModel } from 'src/app/shared/models/add-remove-song.model';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-songs-dialog',
  templateUrl: './songs-dialog.component.html',
  styleUrls: ['./songs-dialog.component.scss']
})
export class SongsDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<SongsDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SongsDialogData ,
    private _libraryService: LibraryService,
    private _localStorage: LocalStorageService)
    {}

  
    ngOnInit() {
    
  }

  public onClose(): void {
    this.dialogRef.close();
  }


  onBtnClicked(songId: string, isInLibrary: boolean){
    this.data.album.songs.find(s=> s.id === songId).isInLibrary = !isInLibrary;

    var libraryId = this._localStorage.getItem<string>(LocalStorageKeys.USER_LIBRARY_ID);
    if(isInLibrary == true){
      this.removeSongFromLibrary(libraryId, songId);
  }
    if( isInLibrary == false){
      this.addSongToLibrary(libraryId, songId);
    }

  }

  private removeSongFromLibrary(libraryId, songId): void{

    this._libraryService.removeSongFromLibrary(
      <AddRemoveSongModel>{
        libraryId: libraryId,
        songId: songId
        }, this.data.architectureType
      ).subscribe(
        res =>{
        }
      )
  }


  private addSongToLibrary(libraryId, songId): void{

    this._libraryService.addSongToLibrary(
      <AddRemoveSongModel>{
        libraryId: libraryId,
        songId: songId
        }, this.data.architectureType
      ).subscribe(
        res =>{
        }
      )
  }

}


export class SongsDialogData{
  album: AlbumModel;
  architectureType: ArchitectureTypeEnum;
}