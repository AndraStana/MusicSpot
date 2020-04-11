import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { MatDialog } from '@angular/material';
import { FriendsDialogComponent } from '../friends-dialog/friends-dialog.component';
import { FriendsService } from '../../services/friends.service';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { AddRemoveFriendModel } from '../../models/add-remove-friend.model';

@Component({
  selector: 'app-friends-page-content',
  templateUrl: './friends-page-content.component.html',
  styleUrls: ['./friends-page-content.component.scss']
})
export class FriendsPageContentComponent implements OnInit {

  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "MY FRIENDS";

  constructor( private _dialog: MatDialog, private _friendsService: FriendsService,
    private _localStorage: LocalStorageService
    ){
    
  }

  ngOnInit() {
  }

  requestFinish(){
    this.timer.stopTimerAsync().then();
  }
  requestStart(){
    this.timer.startTimerAsync("Get user's friends").then();
  }


  public openFriendsModal(): void{
    const dialogRef = this._dialog.open(FriendsDialogComponent, {
      width: '600px',
      height: '600px',
      data: this.architectureType
    });

    dialogRef.afterClosed().subscribe(result => {

      console.log('The dialog was closed', result);
        if(result !== undefined && result !== null ){

          var userId = this._localStorage.getItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID);
          this.timer.resetTimer();

          if(result.isFriend == true){
            this.removeFriend(userId, result.friendId);
        }
          if(result.isFriend == false){
            this.addFriend(userId, result.friendId);
          }
        }
      }
    );
  }

  private removeFriend(userId, friendId): void{
    this.timer.startTimerAsync("Remove friend").then();

    this._friendsService.removeFriend(
      <AddRemoveFriendModel>{
          userId: userId,
          friendId: friendId
        }, this.architectureType
      ).subscribe(
        res =>{
          this.timer.stopTimerAsync().then();

    
        }
      )
  }


  private addFriend(userId, friendId): void{
    this.timer.startTimerAsync("Add friend").then();

    this._friendsService.addFriend(
      <AddRemoveFriendModel>{
          userId: userId,
          friendId: friendId
        }, this.architectureType
      ).subscribe(
        res =>{
          this.timer.stopTimerAsync().then();
        }
      )
  }




}

