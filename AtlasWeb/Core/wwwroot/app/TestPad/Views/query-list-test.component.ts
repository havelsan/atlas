import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component } from '@angular/core';
import { QueryParams } from '../../QueryList/Models/QueryParams';

@Component({
    selector: 'query-list-test-component',
    template: `<h1>Query List Test </h1>
    <div id="content">
      <dx-form
        #dxForm
        [formData]="formData"
        labelLocation="top">
              <dxi-item
                dataField="objectDefID"
                editorType="dxTextBox">
            </dxi-item>
            <dxi-item
                dataField="queryDefID"
                editorType="dxTextBox">
            </dxi-item>
            <dxi-item
                dataField="queryName"
                editorType="dxTextBox">
            </dxi-item>
    </dx-form>
    <dx-button (onClick)="doQuery(dxForm)" text="Query"></dx-button>

    <atlas-query-list-component [QueryParameters]="queryParameters"
            (onSelectedItemChanged)="selectionChanged($event)"
            (onGridDataLoaded)="gridDataLoaded($event)"></atlas-query-list-component>
</div>

<dx-load-panel
    #loadPanel
    shadingColor="rgba(0,0,0,0.4)"
    [position]="{ of: '#content' }"
    [(visible)]="loadingVisible"
    [showIndicator]="true"
    [showPane]="true"
    [shading]="false"
    [closeOnOutsideClick]="false">
</dx-load-panel>
    `,
})
export class QueryListTestComponent {
    public queryParameters: QueryParams;
    public formData: any;
    public loadingVisible = false;

    constructor() {
        this.formData = { objectDefID: '3d2f1e54-0d74-468f-b931-4c51ac60b090', queryDefID: '', queryName: 'GetAllProcedureDefinitions' };
    }

    doQuery(dxForm: any) {
        console.log(dxForm);
        // let validationResult = dxForm.instance.validate();
        // if (validationResult.isValid) {
        // }
        let queryParameters = new QueryParams();
        queryParameters.QueryName = this.formData.queryName;
        queryParameters.ObjectDefID = new Guid(this.formData.objectDefID);
        queryParameters.QueryDefID = new Guid(this.formData.queryDefID);
        this.queryParameters = queryParameters;
        this.loadingVisible = true;
    }

    gridDataLoaded(e: any) {
        this.loadingVisible = false;
        let visibleColumnlist = ['ID', 'CODE', 'NAME'];
        let columnList = e as Array<any>;

        for (let dataColumnInfo of columnList) {
            dataColumnInfo.visible = false;

            let findResult = visibleColumnlist.find(c => dataColumnInfo.dataField === c);
            if (findResult != null) {
                dataColumnInfo.visible = true;
            }
        }
    }

    selectionChanged(e: any) {

    }

}
