import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'editor-test-component',
    template: `<dx-form  #dxForm
    [formData]="FormData"
    (onFieldDataChanged)="onDataChanged($event)"
    [showColonAfterLabel]="true"
    [labelLocation]="'top'"
     [colCount]="2">
    <dxi-item dataField="NAME" editorType="dxTextBox"></dxi-item>
    <dxi-item dataField="VALUE" editorType="dxTextBox"></dxi-item>
    <dxi-item dataField="DESCRIPTION" [colSpan]="2" editorType="dxTextArea"></dxi-item>
    <dxi-item dataField="ISACTIVE" editorType="dxCheckBox"></dxi-item>
    <dxi-item dataField="LASTUPDATE" editorType="dxDateBox"></dxi-item>
    </dx-form>
     <dx-button (onClick)="submitClicked()" text="Submit"></dx-button>
<code style="line-height: normal;">{{FormData | json}}</code>
    `
    ,
})
export class EditorTestComponent implements OnInit {

    @Input() FormData: any;

    ngOnInit() {
        this.FormData = {};
    }

    onDataChanged(e: any) {
        this.FormData[e.dataField] = e.value;
    }

    submitClicked() {
        console.log('Submit clicked.');
    }
}