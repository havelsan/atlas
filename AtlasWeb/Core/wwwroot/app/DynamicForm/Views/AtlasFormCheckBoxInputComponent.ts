import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-checkbox-input',
  template: `
    <div [formGroup]="group">
      <label>{{ config.label }}</label>
      <dx-check-box [formControlName]="config?.name"></dx-check-box>
    </div>
  `,
  styles: [
    `
.ng-valid[required]:not(label):not(div), .ng-valid.required:not(label):not(div) {
      border-left: 5px solid #42A948;
  }
.ng-invalid:not(form):not(label):not(div) {
      border-left: 5px solid #a94442;
  }`
]
})
export class AtlasFormCheckBoxInputComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}