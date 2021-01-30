import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing/app-routing.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  exports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule
  ]
})
export class SharedModule { }
