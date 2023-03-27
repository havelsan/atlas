//$51CD9FC5
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';

@Component({
    selector: 'UserMainForm',
    templateUrl: './UserMainForm.html',
    providers: [MessageService, SystemApiService]
})
export class UserMainForm extends TTVisual.TTForm implements OnInit {
    resUserGridDataSource: any;

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected reportService: AtlasReportService, protected systemApiService: SystemApiService) {
        super('', '');
        this.initFormControls();
    }

    //#region Fonksiyonlar
    public showNewUser: boolean = false;
    public btnNewUser() {
        this.showNewUser = false;
        this.openDynamicComponent("RESUSER", null, 'c26f36b3-ad20-4787-8176-8fc44ad3f72e');
        this.showNewUser = true;
    }
    public showUserList() {
        this.showNewUser = false;
    }

    public componentInfo: DynamicComponentInfo;
    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
            });
        } else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
            });
        }


    }

    //public dynamicComponentClosed(e: any) {
    //    this.showNewUser = false;
    //}

    public onGridRowClick($event) {
        console.log($event);
        let i = 0;
    }

    async selectGridRow(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            //this.loadPanelOperation(true, i18n("M14461", "Form haz�rlan�yor, l�tfen bekleyiniz."));
            console.log();
            this.showNewUser = true;
            //let _data: PhysiotherapyWorkListItemModel = value.data as PhysiotherapyWorkListItemModel;

            //this.openDynamicComponent(value.data.ObjectDefName, value.data.ObjectID, null, _inputParam);
            this.openDynamicComponent("RESUSER", value.data.ObjectID, 'c26f36b3-ad20-4787-8176-8fc44ad3f72e');
        }

    }
    //#endregion Fonksiyonlar


    async ngOnInit() {

        let that = this;
        let apiUrl: string = '/api/UserMainService/GetResUserDefinitionList';

        this.resUserGridDataSource = new DataSource({
            store: new CustomStore({
                key: "Name",

                load: (loadOptions: any) => {
                    loadOptions.Params = {

                        definitionName: 'GetResUser'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    return this.httpService.post<any>("/api/UserMainService/GetResUserDefinitionList", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 50
        });
    }


    public initFormControls(): void {



        this.Controls = [];

    }
}


