import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthenticationModule } from './modules/authentication/authentication.module';
import { RouterModule } from '@angular/router';
import { LoginPageComponent } from './modules/authentication/pages/login-page/login-page.component';
import { RegisterPageComponent } from './modules/authentication/pages/register-page/register-page.component';
import { LibraryModule } from './modules/library/library.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuard } from './shared/guard/auth-guard';
import { SharedModule } from './shared/shared.module';
import { NewsModule } from './modules/news/news.module';
import { FriendsModule } from './modules/friends/friends.module';
import { ExploreModule } from './modules/explore/explore.module';
import { RecommendedModule } from './modules/recommended/recommended.module';
import { FriendsPageComponent } from './modules/friends/pages/friends-page/friends-page.component';
import { NewsPageComponent } from './modules/news/pages/news-page/news-page.component';
import { ExplorePageComponent } from './modules/explore/pages/explore-page/explore-page.component';
import { RecommendedPageComponent } from './modules/recommended/pages/recommended-page/recommended-page.component';
import { LibraryPageComponent } from './modules/library/pages/library-page/library-page.component';

@NgModule({
  declarations: [
    AppComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AuthenticationModule,
    HttpClientModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,

    LibraryModule,
    NewsModule,
    FriendsModule,
    ExploreModule,
    RecommendedModule,
    
    RouterModule.forRoot([

      { path: 'library/:userId', component: LibraryPageComponent },
      // { path: '', component: LibraryPageComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      { path: 'friends', component: FriendsPageComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      { path: 'news', component: NewsPageComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      { path: 'explore', component: ExplorePageComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      { path: 'recommended', component: RecommendedPageComponent, pathMatch: 'full',  canActivate: [AuthGuard] },
      
      { path: 'login', component: LoginPageComponent, pathMatch: 'full' },
      { path: 'register', component: RegisterPageComponent, pathMatch: 'full' },

    ]),
    
    BrowserAnimationsModule,
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
