import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FriendsService } from '../../services/friends.service';
import { Friend } from '../../models/friend.model';
import { FriendsDialogFilter } from '../../models/friend-dialog.model';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';

@Component({
  selector: 'app-friends-dialog',
  templateUrl: './friends-dialog.component.html',
  styleUrls: ['./friends-dialog.component.scss']
})
export class FriendsDialogComponent implements OnInit {

    constructor(
      public dialogRef: MatDialogRef<FriendsDialogComponent>,
      @Inject(MAT_DIALOG_DATA) public data: ArchitectureTypeEnum ,
      private _friendsService: FriendsService,
      private _localStorage: LocalStorageService)
      {}


      allFriends: Friend[];
  
    
      ngOnInit() {
        this._friendsService.getAllPossibleFriends(<FriendsDialogFilter>
          {userId: this._localStorage.getItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID)},
          this.data).subscribe(res=>{
            this.allFriends = res;
        });      
    }
  
    public onSave(): void{
        this.dialogRef.close("on save");
      }
    
    public onCancel(): void {
      this.dialogRef.close("on cancel");
    }

    public onBtnClicked(friendId: string, isFriend: boolean): void{
      this.dialogRef.close(<FriendsDialogOutput> {friendId, isFriend} );
    }
  
}

export class FriendsDialogOutput{
  friendId: string;
  isFriend: boolean; 
}