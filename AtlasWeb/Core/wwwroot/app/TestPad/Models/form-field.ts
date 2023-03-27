import { FormGroup } from '@angular/forms';
import { FormFieldConfig } from './form-field-config';

export interface FormField {
    config: FormFieldConfig;
    group: FormGroup;
}
