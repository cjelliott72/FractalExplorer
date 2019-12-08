import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { ZoomDialogComponent } from '../zoom-dialog/zoom-dialog.component';

@Component({
  selector: 'app-explorer',
  templateUrl: './explorer.component.html',
})
export class ExplorerComponent {
  zoomDialogRef: MatDialogRef<ZoomDialogComponent>;
  isImageEmpty: boolean = true;
  isImageLoading: boolean = false;
  imageToShow: any;
  height: number = 500;
  width: number = 500;
  xMin: number;
  xMax: number;
  yMin: number;
  yMax: number;

  constructor(private dialog: MatDialog) { }

  beginZoomIn() {
    if (this.isImageEmpty || this.isImageLoading) return;

    this.zoomDialogRef = this.dialog.open(ZoomDialogComponent, { height: "200px", width: "200px", hasBackdrop: false });
  }

  setRequestedState() {
    this.isImageEmpty = false;
    this.isImageLoading = true;
  }

  setReceivedImage($event) {
    this.isImageLoading = false;
    this.imageToShow = $event;
  }

  setReceivedError($event) {
    this.isImageLoading = false;
    console.error($event);
  }

  setImageDimensions($event) {
    this.height = $event.height;
    this.width = $event.width;
    this.xMin = $event.xMin;
    this.xMax = $event.xMax;
    this.yMin = $event.yMin;
    this.yMax = $event.yMax;
  }
}
