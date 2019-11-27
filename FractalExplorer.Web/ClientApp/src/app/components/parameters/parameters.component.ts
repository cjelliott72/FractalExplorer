import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { FractalService } from '../../services/fractal.service';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
})
export class ParametersComponent implements OnInit {
  imageToShow: any;
  isImageLoading: any;
  imageWidth: number = 600;
  imageHeight: number = 600;
  parametersForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private fractalService: FractalService,
    private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.parametersForm = this.fb.group({
      xMinimum: ['-2', Validators.required],
      xMaximum: ['2', Validators.required],
      yMinimum: ['-2', Validators.required],
      yMaximum: ['2', Validators.required],
    });
  }

  onSubmit() {
    this.isImageLoading = true;
    this.fractalService.getFractalImage(this.imageHeight, this.imageWidth,
      this.parametersForm.get("xMinimum").value, this.parametersForm.get("xMaximum").value,
      this.parametersForm.get("yMinimum").value, this.parametersForm.get("yMaximum").value)
      .subscribe((blob: any) => {
        let objectURL = 'data:image/jpeg;base64,' + blob;
        this.imageToShow = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        this.isImageLoading = false;
      }, error => {
        this.isImageLoading = false;
        console.log(error);
      });
  }
}
