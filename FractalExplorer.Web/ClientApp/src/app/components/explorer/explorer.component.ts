import { Component } from '@angular/core';

@Component({
  selector: 'app-explorer',
  templateUrl: './explorer.component.html',
})
export class ExplorerComponent {
  isImageEmpty: boolean = true;
  isImageLoading: boolean = false;
  imageToShow: any;
  height: number = 500;
  width: number = 500;

  constructor() { }

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
  }
}
