//$B0F54848
import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DrugOrderTypeEnum, DrugUsageTypeEnum, HospitalTimeSchedule, OrderTemplateStatusEnum, BaseTreatmentMaterial } from 'app/NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DrugInfo } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { OrderTemplateItem, OrderTemplateDetailItem } from './OrderTemplateComponent';
import { OrderTemplateDefinitionInputDTO, GetOrderTemlplateDefinition, OrderTempleateUserResurce, OrderTemplateSpecialityDefinition, OrderTemplateDetailDTO, HospitalTimeSch } from './LogisticDefinitionComponents/OrderTemplateDefComponent';
import { DrugOrderIntroductionGridViewModel } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { TreatmentMaterialTemplateItem, TreatmentMaterialTemplateDetailItem } from './TreatmentMaterialTemplateComponent';

@Component({
    selector: 'treatmentmaterialtemplateaddnew-component',
    providers: [DatePipe],
    template: `
    <div class="container-fluid">
    <div class="row">
        <div class="col-sm-12" style="font-weight: bold;">
            Şablon Adı *
            <dx-text-box [(value)]="activeTemplateDefinition.TemplateName">
            </dx-text-box>
        </div>
    </div>
    <br>
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid [dataSource]="activeTemplateDefinition.TemplateDetails"
                          [columnFixing]="{eneabled:'true'}" columnResizingMode="widget" height="500">
                <dxo-paging [enabled]="true"></dxo-paging>
                <dxo-editing mode="cell" [allowUpdating]="true" [allowDeleting]="true" [allowAdding]="false">
                </dxo-editing>

                <dxi-column dataField="Barcode" caption="Barkod" [width]="100" [allowEditing]="false">
                </dxi-column>
                <dxi-column dataField="MKYSNo" caption="MKYS Kodu" [width]="100" [allowEditing]="false">
                </dxi-column>
                <dxi-column dataField="MaterialName" caption="İlaç / Malzeme  Adı" [width]="600" [allowEditing]="false">
                </dxi-column>
                <dxi-column dataField="Amount" caption="Miktarı" [width]="100" [allowEditing]="true">
                </dxi-column>
            </dx-data-grid>
        </div>
    </div>
    <br />
    <div class="row">
        <div style="float: left">
            <dx-button type="btn btn-default" text="Kaydet" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class TreatmentMaterialTemplateAddNewComponent implements IModal {
    private _modalInfo: ModalInfo;
    public activeTemplateDefinition: TreatmentMaterialTemplateItem = new TreatmentMaterialTemplateItem();


    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
    }

    public setInputParam(value: Array<BaseTreatmentMaterial>) {
        this.activeTemplateDefinition.TemplateDetails = new Array<TreatmentMaterialTemplateDetailItem>();
        for (let treatmentMaterial of value) {
            let templateDetail: TreatmentMaterialTemplateDetailItem = new TreatmentMaterialTemplateDetailItem();
            templateDetail.Amount = treatmentMaterial.Amount;
            templateDetail.Barcode = treatmentMaterial.Material.Barcode;
            templateDetail.MKYSNo = treatmentMaterial.Material.StockCard.NATOStockNO;
            templateDetail.MaterialName = treatmentMaterial.Material.Name;
            templateDetail.MaterialObjectID = treatmentMaterial.Material.ObjectID;
            this.activeTemplateDefinition.TemplateDetails.push(templateDetail);
        }
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        if (this.activeTemplateDefinition != null) {
            if (String.isNullOrEmpty(this.activeTemplateDefinition.TemplateName)) {
                ServiceLocator.MessageService.showError("Şablon Adı Boş Olamaz!");
                return;
            }
        }
        if (this.activeTemplateDefinition.TemplateDetails.length == 0) {
            ServiceLocator.MessageService.showError("Şablon için detay bilgileri Boş Olamaz!");
            return;
        }

        let that = this;
        let fullApiUrl: string = 'api/TreatmentMaterialTemplate/saveObject';
        this.http.post(fullApiUrl, that.activeTemplateDefinition)
            .then((res) => {
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, res.toString());
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }
}




