import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AppRoutingModule } from './app-routing/app-routing.module';

@NgModule({
  declarations: [NavBarComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports: [
    NavBarComponent,
    AppRoutingModule
  ]
})
export class CoreModule { }
