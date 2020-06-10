import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { LoginAccount } from '../../models/account.model';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { RouterLink, Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginForm: FormGroup;
  errorMessage = "";

  constructor(private _formBuilder: FormBuilder,
     private _accountService: AccountService,
     private _localStorage: LocalStorageService,
     private _router: Router) { }

  ngOnInit() {

    this.loginForm = this._formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null)
    })
  }

  login(){

    var email = this.loginForm.get("email").value;
    var password =  this.loginForm.get("password").value;
    if(email && password)
    {
        this._accountService.login(<LoginAccount>{email, password}).subscribe(user =>{
          if(user){
            this._localStorage.setItem<boolean>(LocalStorageKeys.IS_LOGGED_IN, true);
            this._localStorage.setItem<string>(LocalStorageKeys.LOGGED_IN_USER_NAME, user.username);
            this._localStorage.setItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID, user.userId);
            this._localStorage.setItem<string>(LocalStorageKeys.USER_LIBRARY_ID, user.libraryId);

            this._localStorage.setItem(LocalStorageKeys.LIBRARY_PAGE_TITLE, "MY LIBRARY");

            this._router.navigateByUrl('/library/' +user.userId);
          }
          else{
            this.errorMessage = "Invalid Credentials";
          }
        });
      }
    }
}
