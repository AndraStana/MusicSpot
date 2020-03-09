import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LoginPageComponent } from './pages/login-page/login-page.component';


@NgModule({
  declarations: [
    LoginPageComponent
  ],
  imports: [
    BrowserModule,
  ],
  exports:[LoginPageComponent],
  providers: [],
})
export class AuthenticationModule { }
