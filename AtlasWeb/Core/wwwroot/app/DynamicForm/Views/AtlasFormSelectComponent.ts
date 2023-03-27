import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-select',
  template: `
    <div
      [formGroup]="group">
      <label>{{ config.label }}</label>
      <select [formControlName]="config.name">
        <option value="">{{ config.placeholder }}</option>
        <option *ngFor="let option of config.options">
          {{ option }}
        </option>
      </select>
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
export class AtlasFormSelectComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}