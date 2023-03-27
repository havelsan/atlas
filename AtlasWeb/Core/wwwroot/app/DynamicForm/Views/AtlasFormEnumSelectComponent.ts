import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-enum-select',
  template: `
    <div
      [formGroup]="group">
      <label>{{ config.label }}</label>
      <dx-select-box [items]="config?.enumList" displayExpr="Name" valueExpr="Value" [formControlName]="config?.name" [showClearButton]="true">
      </dx-select-box>
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
export class AtlasFormEnumSelectComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}