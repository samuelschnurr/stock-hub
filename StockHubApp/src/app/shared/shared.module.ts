import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ModalDialogComponent } from './modal-dialog/modal-dialog.component';

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
