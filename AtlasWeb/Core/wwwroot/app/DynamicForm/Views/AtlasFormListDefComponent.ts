//$91E99D9C
import { Component, OnInit, forwardRef } from '@angular/core';
import { FormGroup, NG_VALUE_ACCESSOR } from '@angular/forms';
import { AtlasFormField } from '../Models/AtlasFormField';
import { AtlasFormFieldConfig } from '../Models/AtlasFormFieldConfig';
import { AtlasObjectDefinitionService } from 'Fw/Services/AtlasObjectDefinitionService';
import { IModalService } from 'Fw/Services/IModalService';
import { AtlasListDefComponent } from 'Fw/Components/AtlasListDefComponent';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

const noop = () => {
};

const CUSTOM_VALUE_ACCESSOR_PROVIDER = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => AtlasFormListDefComponent),
    multi: true
};

@Component({
    selector: 'atlas-form-listdef',
    template: `
    <div [formGroup]="group">
      <label>{{ config.label }}</label>
        <dx-box direction="row" width="100%">
             <dxi-item [ratio]="96"><dx-text-box [value]="displayText" [readOnly]="true" [showClearButton]="true" (onValueChanged)="valueChanged($event)"></dx-text-box></dxi-item>
             <dxi-item [ratio]="4" [baseSize]="30"><dx-button text="..." style="border: none; height: 22px; wdith:30px; margin-left: 2px;" (onClick)="showList()"></dx-button></dxi-item>
        </dx-box>
        <input type="hidden" [ngModel]="innerValue" [formControlName]="config?.name" >
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
],
    providers: [CUSTOM_VALUE_ACCESSOR_PROVIDER]
})
export class AtlasFormListDefComponent implements OnInit, AtlasFormField {
    config: AtlasFormFieldConfig;
    group: FormGroup;

    //The internal data model
    public innerValue: any = '';
    public displayText: string = '';

    constructor(private objectDefinitionService: AtlasObjectDefinitionService, private modalService: IModalService) {
    }

    //Placeholders for the callbacks which are later providesd
    //by the Control Value Accessor
    private onTouchedCallback: () => void = noop;
    private onChangeCallback: (_: any) => void = noop;

    //get accessor
    get value(): any {
        return this.innerValue;
    }

    //set accessor including call the onchange callback
    set value(v: any) {
        if (v !== this.innerValue) {
            this.innerValue = v;
            this.onChangeCallback(v);
        }
    }

    //Set touched on blur
    onBlur() {
        this.onTouchedCallback();
    }

    //From ControlValueAccessor interface
    writeValue(value: any) {
        if (value !== this.innerValue) {
            this.innerValue = value;
        }
    }

    //From ControlValueAccessor interface
    registerOnChange(fn: any) {
        this.onChangeCallback = fn;
    }

    //From ControlValueAccessor interface
    registerOnTouched(fn: any) {
        this.onTouchedCallback = fn;
    }

    ngOnInit() {
    }

    private processModalResult(result: ModalActionResult) {
        if (result.Result === DialogResult.OK) {

            if (result.Param) {
                let displayText = '';
                if (result.Param.hasOwnProperty('DisplayText')) {
                    displayText = result.Param['DisplayText'];
                }
                let itemValue = '';
                if (result.Param.hasOwnProperty('Value')) {
                    itemValue = result.Param['Value'];
                }

                this.value = itemValue;
                if (displayText) {
                    this.displayText = displayText;
                } else {
                    this.displayText = itemValue;
                }

            }
        } else if (result.Result === DialogResult.Cancel) {
            this.displayText = null;
            this.value = null;
        }
    }

    showList(): void {
        let that = this;
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasListDefComponent;
        dynamicComponentInfo.InputParam = { ListDefID: this.config.listDefID, UserFilterExpression: this.config.userFilterExpression };
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 500;
        modalInfo.Title = i18n("M18394", "Lütfen seçim yapınız (") + this.config.label + ')';
        this.modalService.create(dynamicComponentInfo, modalInfo).then(res => {
            let result: ModalActionResult = res;
            if (result) {
                that.processModalResult(result);
            }
        });
    }

    valueChanged(e: any) {

    }
}