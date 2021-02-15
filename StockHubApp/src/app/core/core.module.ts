import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [NavBarComponent, FooterComponent],
  imports: [
    SharedModule
  ],
  exports: [
    NavBarComponent,
    FooterComponent
  ]
})
export class CoreModule { }
