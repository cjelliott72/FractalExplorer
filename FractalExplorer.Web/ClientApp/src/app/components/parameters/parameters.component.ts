import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, ValidatorFn, ValidationErrors, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { FractalService } from '../../services/fractal.service';
import { ErrorStateMatcher } from '@angular/material/core';

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
  errorMatcher = new CrossFieldErrorMatcher();
  originalData: any;

  constructor(
    private fb: FormBuilder,
    private fractalService: FractalService,
    private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.parametersForm = this.fb.group({
      xGroup: this.fb.group({
        xMinimum: ['-2', Validators.required],
        xMaximum: ['2', Validators.required]
      }, { validators: xMinimumLessThanMaximumValidator }),
      yGroup: this.fb.group({
        yMinimum: ['-2', Validators.required],
        yMaximum: ['2', Validators.required]
      }, { validators: yMinimumLessThanMaximumValidator }),
    });

    this.originalData = this.parametersForm.value;
  }

  onSubmit() {
    this.isImageLoading = true;
    this.fractalService.getFractalImage(this.imageHeight, this.imageWidth,
      this.parametersForm.get("xGroup.xMinimum").value, this.parametersForm.get("xGroup.xMaximum").value,
      this.parametersForm.get("yGroup.yMinimum").value, this.parametersForm.get("yGroup.yMaximum").value)
      .subscribe((blob: any) => {
        let objectURL = 'data:image/jpeg;base64,' + blob;
        this.imageToShow = this.sanitizer.bypassSecurityTrustUrl(objectURL);
        this.isImageLoading = false;
      }, error => {
        this.isImageLoading = false;
        console.log(error);
      });
  }

  protected resetFormData() {
    this.parametersForm.setValue(this.originalData);
    this.parametersForm.markAsPristine();
  }
}

export const xMinimumLessThanMaximumValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
  const xMin = control.get('xMinimum');
  const xMax = control.get('xMaximum');
  const condition = xMin.value != null && xMax.value != null && xMin.value >= xMax.value;

  return condition ? { 'xMinNotLessThanMax': true } : null;
}

export const yMinimumLessThanMaximumValidator: ValidatorFn = (control: FormGroup): ValidationErrors | null => {
  const yMin = control.get('yMinimum');
  const yMax = control.get('yMaximum');
  const condition = yMin.value != null && yMax.value != null && yMin.value >= yMax.value;

  return condition ? { 'yMinNotLessThanMax': true } : null;
}

/** Error when the parent is invalid */
class CrossFieldErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    if (control) {
      return (control.dirty || control.touched) && control.parent.invalid;
    }
    return false;
  }
}
