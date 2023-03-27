import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

@Component({
  selector: 'atlas-form-button',
  template: `
    <div [formGroup]="group">
      <button
        [disabled]="config.disabled"
        type="submit">
        {{ config.label }}
      </button>
    </div>
  `
})
export class AtlasFormButtonComponent implements AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}