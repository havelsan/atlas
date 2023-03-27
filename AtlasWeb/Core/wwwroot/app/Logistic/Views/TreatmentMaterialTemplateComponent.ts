//$B0F54848
import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DrugOrderTypeEnum, DrugUsageTypeEnum, HospitalTimeSchedule } from 'app/NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DrugInfo } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'treatmentmaterialtemplate-component',
    providers: [DatePipe],
    template: `
 <div class="container-fluid">
    <div class="row">
        <div style="float:left; width:20%; padding-top: 20px;">
            <dx-list 
                #list
                [dataSource]="treatmentMaterialTemplates"
                [height]="600"
                [searchEnabled]="true"
                searchExpr="TemplateName"
                searchMode="contains"
                (onItemClick)="selectItem($event)">
                    <div *dxTemplate="let data of 'item'">
                        <div>{{data.TemplateName}}</div>
                    </div>
            </dx-list>
        </div>
        <div style="float:right; width:79%; padding-top: 20px;">
            <dx-data-grid
                          [dataSource]="templateDetails"
                          [filterRow]="{visible: true}"
                          (onRowClick)="select($event)"
                          [(selectedRowKeys)]="selectedDetails"
                          style="height: 650px;float:left">
                          <dxo-selection mode="multiple" id="A3487"></dxo-selection>
                          <dxi-column dataField="Barcode" caption="Barkod" [width]="150" [allowEditing]="false">
                          </dxi-column>
                          <dxi-column dataField="MKYSNo" caption="MKYS Kodu" [width]="150" [allowEditing]="false">
                          </dxi-column>
                          <dxi-column dataField="MaterialName" caption="İlaç / Malzeme  Adı" [width]="400" [allowEditing]="false">
                          </dxi-column>
                          <dxi-column dataField="Amount" caption="Miktarı" [width]="80" [allowEditing]="true">
                          </dxi-column>
                          <dxi-column dataField="Inheld" caption="Depo Mevcudu" [width]="80" [allowEditing]="true">
                          </dxi-column>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="btn btn-default" text="Ekle" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class TreatmentMaterialTemplateComponent implements IModal {
    treatmentMaterialTemplates: TreatmentMaterialTemplateItem[];
    currentItem: TreatmentMaterialTemplateItem;
    templateDetails: Array<TreatmentMaterialTemplateDetailItem>;
    selectedDetails: Array<TreatmentMaterialTemplateDetailItem>;
    public selectedMaterialList: Array<TreatmentMaterialTemplateDetailItem> = new Array<TreatmentMaterialTemplateDetailItem>();
    public storeID: Guid;
    private _modalInfo: ModalInfo;


    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    public setInputParam(value: any) {
        this.storeID = value as Guid;
        this.getTemplateList();
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    onAmountChanged(data, row) {

    }

    public okClick(): void {
        if (this.selectedDetails.length > 0) {
            if(this.selectedDetails.find(x => x.Inheld === 0) == null){
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedDetails);
            } else {
                ServiceLocator.MessageService.showError("Şeçmiş olduğunuz malzemelerde Depo Mevcudu olmayan malzemeler bulunmaktadır. Bunları düzeltip tekrar deneyebilirsiniz.")
            }
        } else {
            ServiceLocator.MessageService.showError("Hiç Malzeme seçmediniz.")
        }
    }

    editorPreparing(e: any) {

    }

    getTemplateList() {
        let that = this;
        let fullApiUrl: string = 'api/TreatmentMaterialTemplate/getAllTemplate';
        let inputDTO: getAllTemplate_Input = new getAllTemplate_Input();
        inputDTO.StoreID = this.storeID;
        this.http.post<Array<TreatmentMaterialTemplateItem>>(fullApiUrl, inputDTO)
            .then((res) => {
                that.treatmentMaterialTemplates = res as Array<TreatmentMaterialTemplateItem>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


    selectItem(e) {
        this.selectedDetails = new Array<TreatmentMaterialTemplateDetailItem>();
        this.currentItem = e.itemData;
        this.templateDetails = this.currentItem.TemplateDetails;
    }

    select(value: any) {

    }

    selectMaterial(value: any) {

    }
}

export class getAllTemplate_Input {
    public StoreID: Guid;
}

export class TreatmentMaterialTemplateItem {
    public ObjectID: Guid;
    public TemplateName: string;
    public TemplateDetails: Array<TreatmentMaterialTemplateDetailItem>;
}

export class TreatmentMaterialTemplateDetailItem {
    public Amount: number;
    public MKYSNo: string;
    public Barcode: string;
    public MaterialName: string;
    public MaterialObjectID: Guid;
    public Inheld: number;
}