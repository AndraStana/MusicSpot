import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { ArchitectureTypeEnum } from 'src/app/shared/enums/enums';
import { Observable } from 'rxjs';
import { NewsModel } from '../models/news.model';
import { ApplicationAPI } from 'src/app/shared/routing/api-urls';
import { BasicPageFilter } from 'src/app/shared/models/basic-page.filter';

@Injectable()
export class NewsService {
    private baseMonolithUrl = `${environment.baseMonolithUrl}`;
    private baseMicroservicesUrl = `${environment.baseMicroservicesNewsUrl}`;

    constructor(private _httpClient: HttpClient) { }

    public getNews(filter: BasicPageFilter, architectureType: ArchitectureTypeEnum): Observable<NewsModel[]> {
        var url = "";

        switch (architectureType){
            case ArchitectureTypeEnum.Monolith:
                url = `${this.baseMonolithUrl}${ApplicationAPI.NEWS_GET_NEWS}` ;
                break;
            case ArchitectureTypeEnum.Microservices:
                url = `${this.baseMicroservicesUrl}${ApplicationAPI.NEWS_GET_NEWS}` ;
                break;
        }
        return this._httpClient.post<NewsModel[]>(url, filter);
    }
}