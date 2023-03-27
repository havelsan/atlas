import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-numeric-input',
  template: `
    <div [formGroup]="group">
      <label>{{ config.label }}</label>
      <dx-number-box [formControlName]="config?.name" [showClearButton]="true"></dx-number-box>
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
export class AtlasFormNumericInputComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}