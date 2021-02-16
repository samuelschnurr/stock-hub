import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html'
})
export class ModalDialogComponent {
  /**
   * The EventEmitter for the id which has been submitted by the modal dialog.
   * Is equals to the id property if the the modal dialog was submitted, but not canceled.
   * Is required to pass id of a record to the modal dialog and pass it to the submit function.
   */
  @Output() public idSubmitEvent = new EventEmitter<number>();
  /**
   * The id of the clicked record which opened the modal dialog.
   * Is required to pass id of a record to the modal dialog and pass it to the submit function.
   */
  @Input() public id = 0;
  /**
   * The title which will be shown at the top of the modal dialog.
   * Can be set from outside, otherwise it shows a default value.
   */
  @Input() public title = 'Confirmation required';
  /**
   * The text body of the modal dialog.
   * Can be set from outside, otherwise it shows a default value.
   */
  @Input() public body = 'Do you want to submit this action?';
  /**
   * The text which will be shown for the cancel button modal dialog.
   * Can be set from outside, otherwise it shows a default value.
   */
  @Input() public cancelLabel = 'Cancel';
  /**
   * The text which will be shown for the submit button of the modal dialog.
   * Can be set from outside, otherwise it shows a default value.
   */
  @Input() public submitLabel = 'Submit';

  /**
   * Emits the idSubmitEvent with the value of the submitted id.
   */
  public submitModal(): void {
    this.idSubmitEvent.emit(this.id);
  }
}
