import { LibraryPageComponent } from './pages/library-page/library-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

@NgModule({
    declarations: [
      LibraryPageComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[LibraryPageComponent],
    // providers: [AccountService],
  })
  export class LibraryModule { }