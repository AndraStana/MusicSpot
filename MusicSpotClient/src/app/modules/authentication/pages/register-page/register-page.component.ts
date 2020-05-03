import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { RegisterAccount } from '../../models/account.model';
import { Router } from '@angular/router';
import { LocalStorageService, LocalStorageKeys } from 'src/app/shared/services/local-storage.service';
import { UserAddModel } from '../../models/user-add.model';
import { LibraryAddModel } from '../../models/library-add.model';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent implements OnInit {

  registerForm: FormGroup;
  errorMessage = "";

  constructor(private formBuilder: FormBuilder,
    private _accountService: AccountService,
    private _localStorage: LocalStorageService,
    private _router: Router) { }

  ngOnInit() {

    this.registerForm = this.formBuilder.group({
      email: new FormControl(null),
      password: new FormControl(null),
      username: new FormControl(null),
      yearOfBirth: new FormControl()
    })
  }


  public register(): void {
    var email = this.registerForm.get("email").value;
    var password = this.registerForm.get("password").value;

    var username = this.registerForm.get("username").value;
    var yearOfBirth = this.registerForm.get("yearOfBirth").value;

    if (email && password && username && yearOfBirth) {

      this._accountService.register(<RegisterAccount>{ email, password, username, yearOfBirth: Number(yearOfBirth) }).subscribe(user => {
        if (user) {

          this._accountService.createMicroserviceLibrary(
            <LibraryAddModel>{
              id: user.libraryId,
              name: email+'_Library'
            }
          ).subscribe();

          this._accountService.createMicroserviceUser(<UserAddModel>{
         
            id: user.userId,
            username: username,
            email: email,
            yearOfBirth: Number(yearOfBirth),
            libraryId: user.libraryId

          }).subscribe();

          this._localStorage.setItem<boolean>(LocalStorageKeys.IS_LOGGED_IN, true);
          this._localStorage.setItem<string>(LocalStorageKeys.LOGGED_IN_USER_NAME, user.username);
          this._localStorage.setItem<string>(LocalStorageKeys.LOGGED_IN_USER_ID, user.userId);
          this._localStorage.setItem<string>(LocalStorageKeys.USER_LIBRARY_ID, user.libraryId);


          this._router.navigateByUrl('/library/'+user.userId);
        }
        else {
          this.errorMessage = "Could not register this account";
        }
      });
    }
  }

}
