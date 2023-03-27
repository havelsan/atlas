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

@Component({
    selector: 'ordertemplate-component',
    providers: [DatePipe],
    template: `
 <div class="container-fluid">
    <div class="row">
        <div style="float:left; width:20%; padding-top: 20px;">
            <dx-text-box #textBox
                         placeholder="Şablon Ara"
                         [width]="240"
                         mode="search"
                         valueChangeEvent="keyup"
                         value="">
            </dx-text-box>
            <br />
            <dx-tree-view id="simple-treeview"
                          [items]="orderTemplateTree"
                          [width]="250"
                          [height]="600"
                          [searchValue]="textBox.value"
                          (onItemClick)="selectItem($event)">
            </dx-tree-view>
        </div>

        <div style="float:right; width:79%; padding-top: 20px;">
            <dx-data-grid
                          [dataSource]="orderTemplateDetails"
                          [filterRow]="{visible: true}"
                          (onRowClick)="select($event)"
                          [selection]="{mode: 'single',allowSelectAll: false}"
                          style="height: 650px;float:left">

                          <dxi-column dataField="MaterialName" caption="İlaç Adı" [width]="400" [allowEditing]="false">
                          </dxi-column>
      
                          <dxi-column dataField="HospitalTimeSchedule" caption="Doz Aralığı" [width]="100">
                              <dxo-lookup [dataSource]="timeScheduleDataSource" displayExpr="Name" valueExpr="ObjectID">
                              </dxo-lookup>
                          </dxi-column>
      
                          <dxi-column dataField="DoseAmount" caption="Doz Miktarı" [width]="80" [allowEditing]="true">
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
            <dx-button type="btn btn-default" text="Ekle" style="width:80px" (onClick)="okClick()"></dx-button>
        </div>
        <div style="float: right">
            <dx-button type="btn btn-default" text="Vazgec" style="width:80px" (onClick)="cancelClick()"></dx-button>
        </div>
    </div>
</div>
 `
})
export class OrderTemplateComponent implements IModal {
    orderTemplateTree: OrderTemplateItem[];
    currentItem: OrderTemplateItem;
    orderTemplateDetails: Array<OrderTemplateDetailItem>;
    public selectedMaterialList: Array<OrderTemplateDetailItem> = new Array<OrderTemplateDetailItem>();
    private _modalInfo: ModalInfo;
    public DrugOrderType: Array<EnumItem> = DrugOrderTypeEnum.Items;
    public DrugUsageType: Array<EnumItem> = DrugUsageTypeEnum.Items;
    public timeScheduleDataSource: Array<HospitalTimeSch>;


    constructor(private modalStateService: ModalStateService, private http: NeHttpService, private datePipe: DatePipe) {
        this.getTreeList();
    }

    public setInputParam(value: any) {

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
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.orderTemplateDetails);
    }

    editorPreparing(e: any) {

    }

    getTreeList() {
        let that = this;
        let fullApiUrl: string = 'api/OrderTemplate/getAllOrderTemplate';
        let inputDTO:AllOrderTemplateInput = new AllOrderTemplateInput();
        inputDTO.resourceID = new Guid();//klinik  Resource Obj ID
        inputDTO.spcialityDefID = new Guid();//branş bilgileri SpcialityDefinition Obj ID
        this.http.post<GetDataSource>(fullApiUrl, inputDTO)
            .then((res) => {
                that.orderTemplateTree = res.OrderTemplateItemList as Array<OrderTemplateItem>;
                that.timeScheduleDataSource = res.HospitalTimeScheduleList as Array<HospitalTimeSch>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


    selectItem(e) {
        this.currentItem = e.itemData;
        this.orderTemplateDetails = this.currentItem.OrderTemplateDetails;
    }
    
    select(value: any) {

    }

    selectMaterial(value: any) {

    }
}

export class GetDataSource{
    public OrderTemplateItemList:Array<OrderTemplateItem>;
    public HospitalTimeScheduleList: Array<HospitalTimeSch>;
}

export class HospitalTimeSch {
    public ObjectID: Guid;
    public Name: string;
}

export class AllOrderTemplateInput {
    public spcialityDefID: Guid;
    public resourceID: Guid;
}

export class OrderTemplateItem {
    public ObjectID: Guid;
    public text: string;
    public ParentID: number;
    public expanded?: boolean;
    public items?: OrderTemplateItem[];
    public OrderTemplateDetails: Array<OrderTemplateDetailItem>;
}

export class OrderTemplateDetailItem {
    public Description: string;
    public DoseAmount: number;
    public DrugOrderType: DrugOrderTypeEnum;
    public DrugUsageType: DrugUsageTypeEnum;
    public MaterialName: string;
    public MaterialObjectID: Guid;
    public HospitalTimeSchedule: Guid;
    public drugInfo: DrugInfo;
}