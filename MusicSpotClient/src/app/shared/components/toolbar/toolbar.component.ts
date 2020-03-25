import { Component, OnInit } from '@angular/core';
import { LocalStorageService, LocalStorageKeys } from '../../services/local-storage.service';
import { AccountService } from 'src/app/modules/authentication/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  public username = "";

  constructor(private _localStorage : LocalStorageService,
    private _accountService: AccountService,
    private _router: Router
    ) { }

  ngOnInit() {
    this.username = this._localStorage.getItem(LocalStorageKeys.LOGGED_IN_USER_NAME);
  }

  logout(): void{
    this._accountService.logout().subscribe(res=>
      {
        this._localStorage.setItem<boolean>(LocalStorageKeys.IS_LOGGED_IN, false);
        this._localStorage.removeItem(LocalStorageKeys.LOGGED_IN_USER_NAME);
        this._router.navigateByUrl("/login");
      });
  }



}
