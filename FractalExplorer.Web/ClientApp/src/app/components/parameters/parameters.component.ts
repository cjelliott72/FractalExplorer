import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-parameters',
  templateUrl: './parameters.component.html',
})
export class ParametersComponent {
  parametersForm = this.fb.group({
    xMinimum: ['', Validators.required],
    xMaximum: ['', Validators.required],
    yMinimum: ['', Validators.required],
    yMaximum: ['', Validators.required],
  });

  constructor(private fb: FormBuilder) { }

  onSubmit() {
    console.warn(this.parametersForm.value);
  }

  updateY() {
    this.parametersForm.patchValue({
      yMinimum: 2,
      yMaximum: 4,
    });
  }
}
