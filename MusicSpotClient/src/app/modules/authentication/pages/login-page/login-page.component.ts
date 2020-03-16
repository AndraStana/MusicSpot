import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { UserAccount } from '../../models/account.model';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
     private _accountService: AccountService) { }

  ngOnInit() {

    this.loginForm = this.formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null)
    })
  }

  login(){

    var email = this.loginForm.get("email").value;
    var password =  this.loginForm.get("password").value;
    if(email && password)
    alert(  + '... ' );

    this._accountService.login(<UserAccount>{email, password}).subscribe(res =>{
      if(res === true){
        console.log("logged in");
      }
      else{
        console.log("nope");

      }
    });
  }


  public register(): void{
    var email = this.loginForm.get("email").value;
    var password =  this.loginForm.get("password").value;
    if(email && password)
    alert(  + '... ' );

    this._accountService.register(<UserAccount>{email, password}).subscribe(res =>{
      if(res === true){
        console.log("logged in");
      }
      else{
        console.log("nope");

      }
    });

    }




}
