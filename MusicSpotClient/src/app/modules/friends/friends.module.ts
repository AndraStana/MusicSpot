import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { FriendsPageComponent } from './pages/friends-page/friends-page.component';

@NgModule({
    declarations: [
      FriendsPageComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[FriendsPageComponent],
    // providers: [AccountService],
  })
  export class FriendsModule { }