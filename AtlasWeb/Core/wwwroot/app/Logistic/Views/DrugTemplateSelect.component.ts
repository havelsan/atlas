import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DrugTemplateSelectViewModel, TemplateItem, GridDetailItem, TempInputDVO } from '../Models/DrugTemplateSelectViewModel';
import { UserTemplateService } from 'ObjectClassService/UserTemplateService';
import { DrugOrderIntroductionDet } from 'NebulaClient/Model/AtlasClientModel';
import DataSource from 'devextreme/data/data_source';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';

@Component({
    selector: 'drugtemplate-select-component',
    template: `
<div class="container-fluid">
    <div class="row">
        <div style="float:left; width:30%; padding-top: 20px;">
            <dx-text-box valueChangeEvent="keyup"
                         placeholder="Şablon Ara"
                         [width]="300"
                         mode="search"
                         (onValueChanged)="search($event)">
            </dx-text-box>
            <br />
            <dx-list [dataSource]="tempDataSource"
                     (onItemClick)="selectedChange($event)">
                <div *dxTemplate="let data of 'item'">
                    <div>{{data.templateName}}</div>
                </div>
            </dx-list>
        </div>
        <div style="float:right; width:69%; padding-top: 20px;">
            <dx-data-grid id="gridContainer"
                          [dataSource]="tempDrugOrders"
                          style="height:430px;">
                <dxi-column dataField="Name" caption="İlaç" [width]="500"></dxi-column>
                <dxi-column dataField="Frequency" caption="Doz Aralığı" [width]="100"></dxi-column>
                <dxi-column dataField="DoseAmount" caption="Doz Miktarı" [width]="100"></dxi-column>
                <dxi-column dataField="Day" caption="Gün" [width]="50"></dxi-column>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="btn btn-default" text="Ekle" style="width:60px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:60px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class DrugTemplateSelectComponent implements IModal {

    public drugTemplate: TemplateItem[];
    public user: ResUser;
    private _modalInfo: ModalInfo;
    private viewModel: DrugTemplateSelectViewModel;
    public tempDrugOrders: Array<GridDetailItem> = new Array<GridDetailItem>();
    public selectedTemplate: Array<DrugOrderIntroductionDet> = new Array<DrugOrderIntroductionDet>();
    public tempDataSource: DataSource;

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
    }

    ngOnInit() {
        this.getTemplates();
    }

    public setInputParam(value: ResUser) {
        this.user = value;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedTemplate);
    }

    async getTemplates() {
        if (this.user !== null) {
            let userTemplates: any = await UserTemplateService.GetDrugOrderIntroductionTemplate(this.user.ObjectID);
            this.drugTemplate = new Array<TemplateItem>();
            let keys = Object.keys(userTemplates);
            if (keys.length > 0) {
                for (let itemKey of keys) {
                    let temp: TemplateItem = new TemplateItem();
                    temp.templateName = itemKey;
                    temp.drugs = new Array<DrugOrderIntroductionDet>();
                    for (let order of userTemplates[itemKey]) {
                        temp.drugs.push(order);
                    }
                    this.drugTemplate.push(temp);
                }
            }
            this.tempDataSource = new DataSource({
                store: this.drugTemplate,
                searchOperation: 'contains',
                searchExpr: 'templateName'
            });
        }
    }

    selectedChange(e) {
        if (e.itemData !== null) {
            this.selectedTemplate = e.itemData.drugs;
            let inputDvo = new TempInputDVO();
            inputDvo.details = e.itemData.drugs;
            let fullApiUrl = 'api/DrugTemplateSelect/GetGridDetails';
            this.http.post(fullApiUrl, inputDvo)
                .then((res: Array<GridDetailItem>) => {
                    this.tempDrugOrders = res;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    search(e) {
        this.tempDataSource.searchValue(e.value);
        this.tempDataSource.load();
    }
}