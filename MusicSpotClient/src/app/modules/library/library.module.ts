import { LibraryPageComponent } from './pages/library-page/library-page.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LibraryPageContentComponent } from './components/library-page-content/library-page-content.component';
import { LibraryTableComponent } from './components/library-table/library-table.component';
import { LibraryService } from './services/library.service';

@NgModule({
    declarations: [
      LibraryPageComponent,
      LibraryPageContentComponent,
      LibraryTableComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[LibraryPageComponent],
    providers: [LibraryService],
  })
  export class LibraryModule { }