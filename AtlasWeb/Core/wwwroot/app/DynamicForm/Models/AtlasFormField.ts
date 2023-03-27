import { FormGroup } from '@angular/forms';
import { AtlasFormFieldConfig } from './AtlasFormFieldConfig';

export interface AtlasFormField {
  config: AtlasFormFieldConfig;
  group: FormGroup;
}