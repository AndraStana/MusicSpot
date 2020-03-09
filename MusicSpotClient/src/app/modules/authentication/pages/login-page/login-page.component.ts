import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {

    this.loginForm = this.formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null)
    })
  }

  login(){
    alert( this.loginForm.get("email").value + '... ' + this.loginForm.get("password").value );


  }

  register(){
    alert("register");
  }

}
