import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-modal-dialog',
  templateUrl: './modal-dialog.component.html'
})
export class ModalDialogComponent {
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
   * The function which will be triggered if the the modal dialog is submitted.
   * Can be set from outside, otherwise it does no action.
   */
  @Input() public submitModal(): void {}
}
