import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, OnInit } from '@angular/core';
import { QueryParams } from '../../QueryList/Models/QueryParams';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { FormRow, FormFieldConfig } from 'app/TestPad/Models/form-field-config';

@Component({
    selector: 'dynamic-form-test-component',
    template: `


    <hvl-dynamic-form (OnPostScriptCompleted)="OnScript($event)" [Code]="'DemoTest'" [Mode]="2" [ShowGrid]="true" [Parameters]='{MateryalAdi:"75 MG", HastaAdi: "DENEMEHASTA", EpisodeID : "aaabbb", Result: true}'>
    </hvl-dynamic-form>
    `
    ,
})
export class DynamicFormTestComponent implements OnInit {

    public targetObject: any;

    public formConfig: Array<FormRow> = [
        {
            fields: [
                { label: 'Procedure Code', name: 'procedureCode', type: 'text', class: 'col-md-3' }
                , { label: 'Procedure Name', name: 'procedureName', type: 'text', class: 'col-md-7' }
                , { label: 'Is Active', name: 'isActive', type: 'check', class: 'col-md-2 checkBox' }
            ]
        },
        {
            fields: [
                { label: 'Save', name: 'save', type: 'button', class: 'col-md-2 default' }
            ]
        },
    ];
    OnScript(e) {
        debugger;
    }

    constructor() {
    }

    ngOnInit() {
    }

    public saveChanges(formValue: any) {
        console.log(formValue);
    }

}