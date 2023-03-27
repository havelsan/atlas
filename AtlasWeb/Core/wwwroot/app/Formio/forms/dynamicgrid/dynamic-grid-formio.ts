import { Injector } from '@angular/core';
import { FormioCustomComponentInfo, registerCustomFormioComponent } from 'angular-formio';
import { DynamicGrid } from './dynamic-grid';

const COMPONENT_OPTIONS: FormioCustomComponentInfo = {
  type: 'Atlas Grid', // custom type. Formio will identify the field with this type.
  selector: 'my-custom-component', // custom selector. Angular Elements will create a custom html tag with this selector
  title: 'Atlas Grid', // Title of the component
  group: 'basic', // Build Group
  icon: 'table', // Icon,

  //  template: 'input', // Optional: define a template for the element. Default: input
  //  changeEvent: 'valueChange', // Optional: define the changeEvent when the formio updates the value in the state. Default: 'valueChange',
  editForm: minimalEditForm, // Optional: define the editForm of the field. Default: the editForm of a textfield
  //  documentation: '', // Optional: define the documentation of the field
  //  weight: 0, // Optional: define the weight in the builder group
  //  schema: {}, // Optional: define extra default schema for the field
  //  extraValidators: [], // Optional: define extra validators  for the field
  //  emptyValue: null, // Optional: the emptyValue of the field
};

export function minimalEditForm() {
  return {
    components: [
      { key: 'type', type: 'hidden' },
      {
        weight: 0,
        type: 'textfield',
        input: true,
        key: 'label',
        label: 'Label',
        placeholder: 'Label',
        validate: {
          required: false,
        },
      },
      {
        weight: 10,
        type: 'textfield',
        input: true,
        key: 'key',
        label: 'Field Code',
        placeholder: 'Field Code',
        tooltip: 'The code/key/ID/name of the field.',
        validate: {
          required: true,
          maxLength: 128,
          pattern: '[A-Za-z]\\w*',
          patternMessage:
            'The property name must only contain alphanumeric characters, underscores and should only be started by any letter character.',
        },
      },
      {
        weight: 20,
        type: 'textfield',
        input: true,
        key: 'customOptions.gridConfig',
        label: 'OData URL',
        placeholder: 'OData URL',
        validate: {
          required: false,
        },
      },
      {
        weight: 20,
        type: 'textfield',
        input: true,
        key: 'customOptions.gridColumns',
        label: 'Kolonlar',
        placeholder: 'Kolonlar',
        validate: {
          required: false,
        }
      },
      {
        label: 'OData Key',
        key: 'customOptions.dataSourceId',
        type: 'input',
        disabled: true
      },
    ],
  };
}

export function registerCustomComponent(injector: Injector) {
  registerCustomFormioComponent(COMPONENT_OPTIONS, DynamicGrid, injector);
}