import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';

/**
 * The shared module provides global access to a set of common used implementations.
 */
@NgModule({
  declarations: [ModalDialogComponent],
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
    AppRoutingModule,
    ModalDialogComponent
  ]
})
export class SharedModule { }
