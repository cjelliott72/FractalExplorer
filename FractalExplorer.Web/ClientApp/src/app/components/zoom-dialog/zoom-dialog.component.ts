import { Component, Output, EventEmitter } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-zoom-dialog',
  templateUrl: './zoom-dialog.component.html',
})
export class ZoomDialogComponent {

  constructor(private dialogRef: MatDialogRef<ZoomDialogComponent>) { }

  confirm() {
    //pass out an object with the coords below
    this.dialogRef.close();
  }
}
