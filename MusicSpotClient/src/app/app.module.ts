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
import { MyLibraryComponent } from './modules/my-library/pages/my-library/my-library.component';
import { MyLibraryModule } from './modules/my-library/my-library.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard } from './shared/guard/auth-guard';
import { ToolbarComponent } from './shared/components/toolbar/toolbar.component';
import { SharedModule } from './shared/shared.module';

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
    SharedModule,
    ReactiveFormsModule,
    MyLibraryModule,
    
    RouterModule.forRoot([
      { path: '', component: MyLibraryComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      { path: 'login', component: LoginPageComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterPageComponent, pathMatch: 'full' },
    
    ]),
    
    BrowserAnimationsModule,
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
