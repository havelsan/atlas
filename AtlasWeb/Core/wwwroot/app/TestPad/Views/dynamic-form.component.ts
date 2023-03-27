import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { FormRow, FormFieldConfig } from '../Models/form-field-config';

@Component({
    exportAs: 'DynamicForm',
    selector: 'dynamic-form',
    template: `
    <form
      [formGroup]="form"
      (submit)="handleSubmit($event)">
      <ng-container *ngFor="let row of config">
        <div class="row">
            <ng-container *ngFor="let field of row.fields">
                <ng-container [ngSwitch]="field.type">

                    <ng-container *ngSwitchCase="'text'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>{{ field.label }}</label>
                                <dx-text-box [formControlName]="field?.name" [value]="field?.value" [style.margin-top]="field?.marginTop"></dx-text-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'password'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>{{ field.label }}</label>
                                <dx-text-box mode="password" [formControlName]="field?.name" [value]="field?.value" [style.margin-top]="field?.marginTop"></dx-text-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'numeric'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>{{ field.label }}</label>
                                <dx-number-box [formControlName]="field?.name" [value]="field?.value" [style.margin-top]="field?.marginTop"></dx-number-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'date'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>{{ field.label }}</label>
                                <dx-date-box dateSerializationFormat ="yyyy-MM-ddTHH:mm:ss" [formControlName]="field?.name" [value]="field?.value" type="date" [style.margin-top]="field?.marginTop"></dx-date-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'check'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>&nbsp;</label>
                                <dx-check-box [formControlName]="field?.name" [value]="field?.value" [text]="field?.label" [style.margin-top]="field?.marginTop" ></dx-check-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'definition'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <label>{{ field.label }}</label>
                                <dx-select-box [formControlName]="field?.name" [value]="field?.value" [style.margin-top]="field?.marginTop"></dx-select-box>
                            </div>
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'hidden'">
                        <div [class]="field?.class" [formGroup]="form">
                            <input [formControlName]="field?.name" type="hidden" [value]="field?.value" [style.margin-top]="field?.marginTop">
                        </div>
                    </ng-container>

                    <ng-container *ngSwitchCase="'button'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <dx-button [text]="field?.label" useSubmitBehavior="true" [style.margin-top]="field?.marginTop"></dx-button>
                            </div>
                        </div>
                    </ng-container>
                    
                    <ng-container *ngSwitchCase="'grid'">
                        <div [class]="field?.class" [formGroup]="form">
                            <div class="form-group" >
                                <dx-data-grid [dataSource]="field?.value" [style.margin-top]="field?.marginTop" showBorders="true">
                                <dxo-editing mode="cell" [allowUpdating]="true"></dxo-editing>
                                <dxo-selection mode="single"></dxo-selection>
                                </dx-data-grid>
                            </div>
                        </div>
                    </ng-container>

                </ng-container>
            </ng-container>
        </div>
      </ng-container>
    </form>
  `
})
export class DynamicFormComponent implements OnChanges, OnInit, OnChanges {

    @Input() objectId: string;
    @Input() config: FormRow[] = [];
    @Output() submit: EventEmitter<any> = new EventEmitter<any>();
    @Input() editObject: any;

    public form: FormGroup;

    get controls() {
        const fieldConfigList = new Array<FormFieldConfig>();
        if (this.config) {
            for (const row of this.config) {
                for (const fieldConfig of row.fields) {
                    if (fieldConfig.type !== 'button') {
                        fieldConfigList.push(fieldConfig);
                    }
                }
            }
        }
        return fieldConfigList;
    }
    get changes() { return this.form.valueChanges; }
    get valid() { return this.form.valid; }
    get value() { return this.form.value; }

    constructor(private fb: FormBuilder) {
    }

    ngOnInit() {
        this.form = this.createGroup();
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['form']) {

            if (this.form) {
                const controls = Object.keys(this.form.controls);
                const configControls = this.controls.map((item) => item.name);

                controls
                    .filter((control) => !configControls.includes(control))
                    .forEach((control) => this.form.removeControl(control));

                configControls
                    .filter((control) => !controls.includes(control))
                    .forEach((name) => {
                        const config = this.controls.find((control) => control.name === name);
                        this.form.addControl(name, this.createControl(config));
                    });
            }
        }

        if (changes['editObject']) {
            const targetEditObject = changes['editObject'].currentValue;
            if (targetEditObject) {
                this.setFormValue(targetEditObject);
            } else {
                this.clearFormValues();
            }
        }

    }

    createGroup() {
        const group = this.fb.group({});
        this.controls.forEach(control => group.addControl(control.name, this.createControl(control)));
        return group;
    }

    createControl(config: FormFieldConfig) {
        const { disabled, validation, value } = config;
        return this.fb.control({ disabled, value }, validation);
    }

    handleSubmit(event: Event) {
        event.preventDefault();
        event.stopPropagation();
        if (this.editObject) {
            const modifedItem = Object.assign(this.editObject, this.value);
            this.submit.emit(modifedItem);
        } else {
            this.submit.emit(this.value);
        }
    }

    setDisabled(name: string, disable: boolean) {
        if (this.form.controls[name]) {
            const method = disable ? 'disable' : 'enable';
            this.form.controls[name][method]();
            return;
        }

        this.controls.forEach((item) => {
            if (item.name === name) {
                item.disabled = disable;
            }
        });
    }

    public clearFormValues() {
        if (this.form)
            this.form.reset();
    }

    public setFormValue(value: any) {
        const keys = Object.keys(value);
        for (const key of keys) {
            if (key !== '$type') {
                const fieldItem = this.controls.find((control) => control.name === key);
                if (fieldItem) {
                    const fieldValue = value[key];
                    this.form.controls[key].setValue(fieldValue, { emitEvent: true });
                    if (fieldItem.type === 'grid') {
                        fieldItem.value = fieldValue;
                    }
                }
            }
        }
    }

    public setValue(name: string, value: any) {
        this.form.controls[name].setValue(value, { emitEvent: true });
    }
}