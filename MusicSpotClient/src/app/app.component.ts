import { Component } from '@angular/core';
import { LocalStorageService, LocalStorageKeys } from './shared/services/local-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Music Spot';
 
  constructor(private _localStorage: LocalStorageService) {
  }

  public isLoggedIn(): boolean{
    return this._localStorage.getItem(LocalStorageKeys.IS_LOGGED_IN);
  }

}
