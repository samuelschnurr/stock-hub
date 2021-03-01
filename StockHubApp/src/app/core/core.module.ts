import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from '../shared/shared.module';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { BodyComponent } from './body/body.component';

/**
 * The core module contains basic implementations which are instantiated only once.
 * Registered singletons are accessible via dependency injection from all classes.
 * Other code in the core module will only be used in the app.module.
 */
@NgModule({
  declarations: [NavBarComponent, FooterComponent, BodyComponent],
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    SharedModule
  ],
  exports: [
    NavBarComponent,
    FooterComponent,
    BodyComponent
  ]
})
export class CoreModule { }
