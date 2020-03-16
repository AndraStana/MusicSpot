import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { RegisterAccount } from '../../models/account.model';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
     private _accountService: AccountService) { }

  ngOnInit() {

    this.registerForm = this.formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null),
      username: new FormControl(null),
      yearOfBirth: new FormControl()
    })
  }


  public register(): void{
    var email = this.registerForm.get("email").value;
    var password =  this.registerForm.get("password").value;
    
    var username = this.registerForm.get("username").value;
    var yearOfBirth =  this.registerForm.get("yearOfBirth").value;

    if(email && password && username && yearOfBirth){

      this._accountService.register(<RegisterAccount>{email, password, username, yearOfBirth: Number(yearOfBirth)}).subscribe(res =>{
        if(res === true){
          console.log("registered in");
        }
        else{
          console.log("nope");
        }
      });
      }
    }

}
