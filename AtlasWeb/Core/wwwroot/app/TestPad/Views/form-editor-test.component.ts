import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, OnInit } from '@angular/core';
import { QueryParams } from '../../QueryList/Models/QueryParams';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';

@Component({
    selector: 'form-editor-test-component',
    template: `


<button (click)="testFormEditor()">Test Form Editor</button>
<hr/>
    <atlas-form-editor  [QueryParameters]="queryParameters" [ComponentInfo]="componentInfo"></atlas-form-editor>
    `
    ,
})
export class FormEditorTestComponent implements OnInit {

    public queryParameters: QueryParams;
    public componentInfo: DynamicComponentInfo;

    constructor() {
    }

    ngOnInit() {
    }

    onDataChanged(e: any) {
    }

    testFormEditor() {
        let queryParameters = new QueryParams();
        queryParameters.ObjectDefID = new Guid('caeb7c84-3d38-4168-b106-852ab5dfd303');
        queryParameters.QueryDefID = new Guid('de43a400-cbf5-48b2-83e6-12d8cb957234');
        this.queryParameters = queryParameters;
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'EditorTestComponent';
        componentInfo.ModuleName = 'EditorTestModule';
        componentInfo.ModulePath = '/app/TestPad/EditorTestModule';
        this.componentInfo = componentInfo;

    }
}