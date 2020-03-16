import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule
    ],
  exports:[
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule

],
  providers: [],
})
export class SharedModule { }




