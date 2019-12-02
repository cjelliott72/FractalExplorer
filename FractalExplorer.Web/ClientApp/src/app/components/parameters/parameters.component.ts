import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { FractalService } from '../../services/fractal.service';
import { ErrorStateMatcher } from '@angular/material/core';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
})
export class ParametersComponent implements OnInit {
  imageToShow: any;
  isImageLoading: boolean = true;
  imageWidth: number = 600;
  imageHeight: number = 600;
  fractalList: string[];
  parametersForm: FormGroup;
  errorMatcher = new CrossFieldErrorMatcher();
  originalData: any;

  constructor(
    private fb: FormBuilder,
    private fractalService: FractalService,
    private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.fractalService.getFractalList().subscribe((fractals: string[]) => {
      this.fractalList = fractals;
    }, error => {
      console.log(error);
    });

    this.parametersForm = this.fb.group({
      xGroup: this.fb.group({
        xMinimum: ['-2', Validators.required],
        xMaximum: ['2', Validators.required]
      }, { validators: MinimumLessThanMaximumValidator('xMinimum', 'xMaximum') }),
      yGroup: this.fb.group({
        yMinimum: ['-2', Validators.required],
        yMaximum: ['2', Validators.required]
      }, { validators: MinimumLessThanMaximumValidator('yMinimum', 'yMaximum') }),
      maxIterations: ['80', [Validators.required, Validators.min(1)]],
      colorType: ['1', Validators.required],
      fractalName: ['', Validators.required]
    });

    this.originalData = this.parametersForm.value;
  }

  onSubmit() {
    this.isImageLoading = true;
    this.fractalService.getFractalImage(this.imageHeight, this.imageWidth,
      this.parametersForm.get("xGroup.xMinimum").value, this.parametersForm.get("xGroup.xMaximum").value,
      this.parametersForm.get("yGroup.yMinimum").value, this.parametersForm.get("yGroup.yMaximum").value,
      this.parametersForm.get("maxIterations").value, this.parametersForm.get("colorType").value,
      this.parametersForm.get("fractalName").value)
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

function MinimumLessThanMaximumValidator(minControl: string, maxControl: string) {
  return function (control: FormGroup) {
    const cMin = control.get(minControl);
    const cMax = control.get(maxControl);
    const condition = cMin && cMax && cMin.value != null && cMax.value != null && cMin.value >= cMax.value;

    return condition ? { 'minNotLessThanMax': true } : null;
  }
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
