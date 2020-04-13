import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { NewsPageComponent } from './pages/news-page/news-page.component';
import { NewsPageContentComponent } from './components/news-page-content/news-page-content.component';
import { NewsService } from './services/news.service';

@NgModule({
    declarations: [
      NewsPageComponent,
      NewsPageContentComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[NewsPageComponent],
    providers: [NewsService],
  })
  export class NewsModule { }