import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { FriendsPageComponent } from './pages/friends-page/friends-page.component';
import { FriendsTableComponent } from './components/friends-table/friends-table.component';
import { FriendsPageContentComponent } from './components/friends-page-content/friends-page-content.component';
import { FriendsService } from './services/friends.service';

@NgModule({
    declarations: [
      FriendsPageComponent,
      FriendsTableComponent,
      FriendsPageContentComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[FriendsPageComponent],
    providers: [FriendsService],
  })
  export class FriendsModule { }