import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';

/**
 * The core module contains basic implementations which are instantiated only once.
 * Registered singletons are accessible via dependency injection from all classes.
 * Other code in the core module will only be used in the app.module.
 */
@NgModule({
  declarations: [NavBarComponent, FooterComponent],
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    })
  ],
  exports: [
    NavBarComponent,
    FooterComponent,
  ]
})
export class CoreModule { }
