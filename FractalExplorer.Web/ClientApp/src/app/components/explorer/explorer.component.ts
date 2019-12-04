import { Component } from '@angular/core';

@Component({
  selector: 'app-explorer',
  templateUrl: './explorer.component.html',
})
export class ExplorerComponent {
  isImageEmpty: boolean = true;
  isImageLoading: boolean = false;
  imageToShow: any;

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
}
