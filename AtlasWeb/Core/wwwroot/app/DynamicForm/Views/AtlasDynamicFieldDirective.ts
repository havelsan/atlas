import { ComponentFactoryResolver, ComponentRef, Directive, Input, OnChanges, OnInit, Type, ViewContainerRef } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { AtlasFormTextInputComponent } from "./AtlasFormTextInputComponent";
import { AtlasFormCheckBoxInputComponent } from "./AtlasFormCheckBoxInputComponent";
import { AtlasFormNumericInputComponent } from "./AtlasFormNumericInputComponent";
import { AtlasFormDateInputComponent } from "./AtlasFormDateInputComponent";
import { AtlasFormSelectComponent } from "./AtlasFormSelectComponent";
import { AtlasFormEnumSelectComponent } from "./AtlasFormEnumSelectComponent";
import { AtlasFormButtonComponent } from "./AtlasFormButtonComponent";
import { AtlasFormListDefComponent } from "./AtlasFormListDefComponent";

import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';

const components: { [type: string]: Type<AtlasFormField> } = {
    button: AtlasFormButtonComponent,
    text: AtlasFormTextInputComponent,
    check: AtlasFormCheckBoxInputComponent,
    date: AtlasFormDateInputComponent,
    numeric: AtlasFormNumericInputComponent,
    select: AtlasFormSelectComponent,
    enum: AtlasFormEnumSelectComponent,
    list: AtlasFormListDefComponent,
};

@Directive({
    selector: '[atlas-dynamic-field]'
})
export class AtlasDynamicFieldDirective implements AtlasFormField, OnChanges, OnInit {
    @Input() config: AtlasFormFieldConfig;
    @Input() group: FormGroup;

    component: ComponentRef<AtlasFormField>;

    constructor(
        private resolver: ComponentFactoryResolver,
        private container: ViewContainerRef
    ) { }

    ngOnChanges() {
        if (this.component) {
            this.component.instance.config = this.config;
            this.component.instance.group = this.group;
        }
    }

    ngOnInit() {
        if (!components[this.config.type]) {
            const supportedTypes = Object.keys(components).join(', ');
            throw new Error(
                `Trying to use an unsupported type (${this.config.type}).
        Supported types: ${supportedTypes}`
            );
        }
        const component = this.resolver.resolveComponentFactory<AtlasFormField>(components[this.config.type]);
        this.component = this.container.createComponent(component);
        this.component.instance.config = this.config;
        this.component.instance.group = this.group;
    }
}