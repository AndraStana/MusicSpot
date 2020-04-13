import { Component, OnInit, ViewChild, Input, AfterViewInit } from '@angular/core';
import { TimerComponent } from 'src/app/shared/components/timer/timer.component';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { NewsModel } from '../../models/news.model';
import { NewsService } from '../../services/news.service';
import { NewsPageFilter } from '../../models/news-page.filter';
import { concat } from 'rxjs';

@Component({
  selector: 'app-news-page-content',
  templateUrl: './news-page-content.component.html',
  styleUrls: ['./news-page-content.component.scss']
})
export class NewsPageContentComponent implements OnInit, AfterViewInit {

  @ViewChild(TimerComponent, {static:false} ) timer: TimerComponent;

  @Input() architectureType: ArchitectureTypeEnum;
  public title = "NEWS";

  allNews: NewsModel[] = [];  
  page: NewsPageFilter = <NewsPageFilter> {
    pageIndex : 0,
    pageSize : 20
  };  
  constructor(private _newsService: NewsService) { }  
 
  ngOnInit() {  
  }  

  ngAfterViewInit(): void {
    this.getNews();  
  }
  
  getNews() { 
    this.timer.resetTimer();
    this.timer.startTimerAsync("Get news");
    this._newsService.getNews(this.page, this.architectureType).subscribe((res) => {  
      this.allNews = this.allNews.concat(res);
      this.timer.stopTimerAsync();

    });  
  }  
  onScroll() {  
    this.page.pageIndex = this.page.pageIndex + 1;  
    this.getNews();  
  }  
}  

