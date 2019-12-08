import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-zoom-dialog',
  templateUrl: './zoom-dialog.component.html',
})
export class ZoomDialogComponent {
  @Output() onCancel = new EventEmitter();
  @Output() onConfirm = new EventEmitter();

  constructor() { }

}
