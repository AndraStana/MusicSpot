import { NgModule } from '@angular/core';
import { ExplorePageComponent } from './pages/explore-page/explore-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    declarations: [
      ExplorePageComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[ExplorePageComponent],
    // providers: [AccountService],
  })
  export class ExploreModule { }