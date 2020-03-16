import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './modules/authentication/authentication.module';
import { RouterModule } from '@angular/router';
import { LoginPageComponent } from './modules/authentication/pages/login-page/login-page.component';
import { RegisterPageComponent } from './modules/authentication/pages/register-page/register-page.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthenticationModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    

    RouterModule.forRoot([
      { path: 'login', component: LoginPageComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterPageComponent, pathMatch: 'full' },
    
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
