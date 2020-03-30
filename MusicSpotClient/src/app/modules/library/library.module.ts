import { LibraryPageComponent } from './pages/library-page/library-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LibraryPageContentComponent } from './components/library-page-content/library-page-content.component';

@NgModule({
    declarations: [
      LibraryPageComponent,
      LibraryPageContentComponent
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