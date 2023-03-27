import { ValidatorFn } from '@angular/forms';

export interface FormRow {
    fields: Array<FormFieldConfig>;
}

export interface FormFieldConfig {
    disabled?: boolean;
    label?: string;
    name: string;
    options?: string[];
    placeholder?: string;
    type: string;
    validation?: ValidatorFn[];
    value?: any;
    defName?: string;
    class?: string;
    styles?: string;
    marginTop?: string;
    translationCode?: string;
}
