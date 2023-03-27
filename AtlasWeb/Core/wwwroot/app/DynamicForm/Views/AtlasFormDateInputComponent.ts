import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-date-input',
  template: `
    <div [formGroup]="group">
      <label>{{ config.label }}</label>
      <dx-date-box [formControlName]="config?.name" [(ngModel)]="now" [showClearButton]="true" [style.width]="'175px'" type="datetime"></dx-date-box>
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


export class AtlasFormDateInputComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
  public now: Date = new Date();
      constructor() {
        this.now = new Date();
    }
}