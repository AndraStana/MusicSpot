import { NgModule } from '@angular/core';
import { ExplorePageComponent } from './pages/explore-page/explore-page.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from 'src/app/shared/shared.module';
import { ExplorePageContentComponent } from './components/explore-page-content/explore-page-content.component';
import { ArtistPanelComponent } from './components/artist-panel/artist-panel.component';
import { ExploreService } from './services/explore.services';

@NgModule({
    declarations: [
      ExplorePageComponent,
      ExplorePageContentComponent,
      ArtistPanelComponent
    ],
    imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      ReactiveFormsModule,
      SharedModule
      
    ],
    exports:[ExplorePageComponent],
    providers: [ExploreService],
  })
  export class ExploreModule { }