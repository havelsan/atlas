import { Injector } from '@angular/core';
import { FormioCustomComponentInfo, registerCustomFormioComponent, Components } from 'angular-formio';
import { CustomSelectComponent } from './custom-select';

const COMPONENT_OPTIONS: FormioCustomComponentInfo = {
    type: 'Atlas-select', // custom type. Formio will identify the field with this type.
    selector: 'custom-select-component', // custom selector. Angular Elements will create a custom html tag with this selector
    title: 'Atlas Select', // Title of the component
    group: 'basic', // Build Group
    icon: 'list', // Icon,

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
    let selectEditFormComp = Components.components.select.editForm();
    let editForm = {
        components: [
            { key: 'type', type: 'hidden' },
            {
                type: 'tabs',
                key: 'tabs',
                components: [
                    {
                        label: 'Temel',
                        key: 'basic',
                        components: [
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
                                    required: false,
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
                                key: 'customOptions.selectConfig',
                                label: 'OData URL',
                                placeholder: 'OData URL',
                                validate: {
                                    required: false,
                                },
                            },
                            {
                                label: 'OData Key',
                                key: 'customOptions.dataSourceId',
                                type: 'input',
                                disabled: true
                            },
                            {
                                weight: 20,
                                type: 'textfield',
                                input: true,
                                key: 'customOptions.valueExpr',
                                label: 'Değer Alanı',
                                placeholder: 'Değer Alanı',
                                validate: {
                                    required: false,
                                },
                            },
                            {
                                weight: 20,
                                type: 'textfield',
                                input: true,
                                key: 'customOptions.displayExpr',
                                label: 'Gösterge Alanı',
                                placeholder: 'Gösterge Alanı',
                                validate: {
                                    required: false,
                                },
                            }
                        ]
                    },
                    selectEditFormComp.components.find(p => p.key == 'tabs').components.find(p => p.key == "api"),
                    selectEditFormComp.components.find(p => p.key == 'tabs').components.find(p => p.key == "conditional"),
                    selectEditFormComp.components.find(p => p.key == 'tabs').components.find(p => p.key == "logic"),
                ]
            }
        ],
    };



    return editForm;
}

export function registerCustomSelectComponent(injector: Injector) {
    registerCustomFormioComponent(COMPONENT_OPTIONS, CustomSelectComponent, injector);
}