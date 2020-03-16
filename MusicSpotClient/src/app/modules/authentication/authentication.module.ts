import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountService } from './services/account.service';
import { SharedModule } from 'src/app/shared/routing/shared.module';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    LoginPageComponent
    

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    SharedModule
  ],
  exports:[LoginPageComponent],
  providers: [AccountService],
})
export class AuthenticationModule { }
