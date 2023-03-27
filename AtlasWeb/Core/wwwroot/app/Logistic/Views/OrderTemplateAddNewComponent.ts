//$B0F54848
import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DatePipe } from '@angular/common';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DrugOrderTypeEnum, DrugUsageTypeEnum, HospitalTimeSchedule, OrderTemplateStatusEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { DrugInfo } from 'app/NebulaClient/Services/ObjectService/DrugOrderIntroductionService';
import { OrderTemplateItem, OrderTemplateDetailItem } from './OrderTemplateComponent';
import { OrderTemplateDefinitionInputDTO, GetOrderTemlplateDefinition, OrderTempleateUserResurce, OrderTemplateSpecialityDefinition, OrderTemplateDetailDTO, HospitalTimeSch } from './LogisticDefinitionComponents/OrderTemplateDefComponent';
import { DrugOrderIntroductionGridViewModel } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

@Component({
    selector: 'ordertemplateaddnew-component',
    providers: [DatePipe],
    template: `
    <div class="container-fluid">
    <div class="row">
        <div class="col-sm-7" style="font-weight: bold;">
            Şablon Adı *
            <dx-text-box [(value)]="activeOrderTemplateDefinition.Name">
            </dx-text-box>
        </div>
        <div class="col-sm-2" style="font-weight: bold;">
            Şablon Tipi *
            <dx-select-box [dataSource]="OrderTemplateStatus" valueExpr="ordinal" displayExpr="description"
                           (onSelectionChanged)="onOrderTemplateStatus($event)" [(value)]="activeOrderTemplateDefinition.OrderTemplateStatus">
            </dx-select-box>
        </div>

        <div *ngIf="clinicSeleted" class="col-sm-2" style="font-weight: bold;">
            Klinik Seçiniz *
            <dx-select-box [dataSource]="UserResources" valueExpr="ResourceObjectID" displayExpr="ResourceName"
                           [(value)]="SeletedResource">
            </dx-select-box>
        </div>
        <div *ngIf="bransSeleted" class="col-sm-2" style="font-weight: bold;">
            Branş Seçiniz *
            <dx-select-box [dataSource]="UserSpecialityDefinitions" valueExpr="SpecialityDefObjectID" displayExpr="SpecialityDefName"
                           [(value)]="SeletedSpecialityDef">
            </dx-select-box>
        </div>
    </div>
    <br>
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid [dataSource]="activeOrderTemplateDefinition.OrderTemplateDetails"
                          [columnFixing]="{eneabled:'true'}" columnResizingMode="widget" height="500">
                <dxo-paging [enabled]="true"></dxo-paging>
                <dxo-editing mode="cell" [allowUpdating]="true" [allowDeleting]="true" [allowAdding]="false">
                </dxo-editing>

                <dxi-column dataField="MaterialName" caption="İlaç Adı" [width]="600" [allowEditing]="false">
                </dxi-column>

                <dxi-column dataField="HospitalTimeSchedule.ObjectID" caption="Doz Aralığı" [width]="100">
                    <dxo-lookup [dataSource]="timeScheduleDataSource" displayExpr="Name" valueExpr="ObjectID">
                    </dxo-lookup>
                </dxi-column>

                <dxi-column dataField="DoseAmount" caption="Doz Miktarı" [width]="100" [allowEditing]="true">
                </dxi-column>


                <dxi-column dataField="DrugUsageType" caption="Kullanım Şekli" [width]="100">
                    <dxo-lookup [dataSource]="DrugUsageType" displayExpr="description" valueExpr="ordinal">
                    </dxo-lookup>
                </dxi-column>

                <dxi-column dataField="DrugOrderType" caption="Tedavi Türü" [width]="100">
                    <dxo-lookup [dataSource]="DrugOrderType" displayExpr="description" valueExpr="ordinal">
                    </dxo-lookup>
                </dxi-column>

                <dxi-column dataField="Description" caption="Açıklama" [width]="100" [allowEditing]="true">
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
export class OrderTemplateAddNewComponent implements IModal {
    private _modalInfo: ModalInfo;

    public timeScheduleDataSource: Array<HospitalTimeSch>;
    public selectedItemFromOpen: boolean = false;
    public activeOrderTemplateDefinition: OrderTemplateDefinitionInputDTO = new OrderTemplateDefinitionInputDTO();
    public selectionGridObjectID: any;
    public isActive: boolean;
    public DrugOrderType: Array<EnumItem> = DrugOrderTypeEnum.Items;
    public DrugUsageType: Array<EnumItem> = DrugUsageTypeEnum.Items;
    public OrderTemplateStatus: Array<EnumItem> = OrderTemplateStatusEnum.Items;

    public clinicSeleted: boolean = false;
    public bransSeleted: boolean = false;

    public SeletedResource: Guid;
    public SeletedSpecialityDef: Guid;

    public UserResources: Array<OrderTempleateUserResurce> = Array<OrderTempleateUserResurce>();
    public UserSpecialityDefinitions: Array<OrderTemplateSpecialityDefinition> = Array<OrderTemplateSpecialityDefinition>();


    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
        this.getAllOrderTemplateDefinition();
    }

    public setInputParam(value: Array<DrugOrderIntroductionGridViewModel>) {
        this.activeOrderTemplateDefinition.IsActive = true;
        this.activeOrderTemplateDefinition.isNew = true;
        this.activeOrderTemplateDefinition.OrderTemplateDetails = new Array<OrderTemplateDetailDTO>();
        for (let order of value) {
            let templateDetail: OrderTemplateDetailDTO = new OrderTemplateDetailDTO();
            templateDetail.Description = order.UsageNote;
            templateDetail.DoseAmount = order.DoseAmount;
            templateDetail.DrugOrderType = order.DrugOrderType;
            templateDetail.DrugUsageType = order.DrugUsageType;
            templateDetail.HospitalTimeSchedule = order.HospitalTimeSchedule;
            templateDetail.MaterialName = order.Material.name;
            templateDetail.MaterialObjectID = new Guid(order.Material.drugObjectId);
            this.activeOrderTemplateDefinition.OrderTemplateDetails.push(templateDetail);
        }
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        if (this.activeOrderTemplateDefinition != null) {
            if (String.isNullOrEmpty(this.activeOrderTemplateDefinition.Name)) {
                ServiceLocator.MessageService.showError("Şablon Adı Boş Olamaz!");
                return;
            }
        }
        if (this.activeOrderTemplateDefinition.OrderTemplateDetails.length == 0) {
            ServiceLocator.MessageService.showError("Şablon için order birgileri Boş Olamaz!");
            return;
        }
        if (this.activeOrderTemplateDefinition.OrderTemplateStatus == null) {
            ServiceLocator.MessageService.showError("Şablon tipi Boş Olamaz!");
            return;
        }

        if (this.bransSeleted == true && this.SeletedResource == Guid.Empty) {
            ServiceLocator.MessageService.showError("Şablon tipi Branş Boş Olamaz!");
            return;
        }

        if (this.clinicSeleted == true && this.SeletedSpecialityDef == Guid.Empty) {
            ServiceLocator.MessageService.showError("Şablon tipi Klinik Boş Olamaz!");
            return;
        }

        this.activeOrderTemplateDefinition.SpecialityDefinition = this.SeletedSpecialityDef;
        this.activeOrderTemplateDefinition.Resource = this.SeletedResource;

        let that = this;
        let fullApiUrl: string = 'api/OrderTemplateDefintion/saveObject';
        this.http.post(fullApiUrl, that.activeOrderTemplateDefinition)
            .then((res) => {
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, res.toString());
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    getAllOrderTemplateDefinition() {
        let that = this;
        let fullApiUrl: string = 'api/OrderTemplateDefintion/getAllOrderTemplateDefinition';
        this.http.post<GetOrderTemlplateDefinition>(fullApiUrl, null)
            .then((res) => {
                that.timeScheduleDataSource = res.HospitalTimeScheduleList as Array<HospitalTimeSch>;
                that.UserResources = res.UserResources as Array<OrderTempleateUserResurce>;
                that.UserSpecialityDefinitions = res.UserSpecialityDefinitions as Array<OrderTemplateSpecialityDefinition>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    onOrderTemplateStatus(data: any) {
        this.clinicSeleted = false;
        this.bransSeleted = false;
        if (this.activeOrderTemplateDefinition.OrderTemplateStatus != null) {
            if(this.activeOrderTemplateDefinition.OrderTemplateStatus == OrderTemplateStatusEnum.JustMyBranch){
                this.bransSeleted = true;
                this.activeOrderTemplateDefinition.Resource = new Guid();
                this.activeOrderTemplateDefinition.SpecialityDefinition =new Guid();
            }
            if(this.activeOrderTemplateDefinition.OrderTemplateStatus == OrderTemplateStatusEnum.OnlyMyClinic){
                this.clinicSeleted = true;
                this.activeOrderTemplateDefinition.Resource = new Guid();
                this.activeOrderTemplateDefinition.SpecialityDefinition =new Guid();
            }
        }
    }
}




