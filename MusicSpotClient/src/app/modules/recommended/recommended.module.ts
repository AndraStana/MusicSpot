import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { RecommendedPageComponent } from './pages/recommended-page/recommended-page.component';

@NgModule({
    declarations: [
      RecommendedPageComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[RecommendedPageComponent],
    // providers: [AccountService],
  })
  export class RecommendedModule { }