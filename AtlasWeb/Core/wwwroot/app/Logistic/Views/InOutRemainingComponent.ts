import { Component } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { StockActionService, MainStoreDVO, OutTypeDVO, GetDocumentRecordLogsDetails_Output, InOutRemainingDTO, GetInoutRemaining_Output, BudgetTypeDefDVO } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { MKYS_EButceTurEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { BudgetTypeSource } from '../Models/LogisticDashboardViewModel';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from "Fw/Services/NeHttpService";

@Component({
    selector: 'inOutRemaining-component',
    template: `
    <div class="row" style="padding-top: 1%;padding-left: 2%;">
  
    <div class="row">
        <div class="col-sm-5">
            <div class="row" style="padding-left: 2%;">
            <label class="control-label">Ana Depo</label>
                <dx-select-box [dataSource]="mainStores"
                displayExpr="Name"
                valueExpr="ObjectID"
                [(value)]="selectedMainStoreID"></dx-select-box>
            </div>
            <div class="row" style="padding-left: 2%;">
            <label class="control-label">Bütçe</label>
                <dx-select-box [dataSource]="budgetTypeSources"
                displayExpr="Name"
                valueExpr="ObjectID" 
                [(value)]="budgetTypeObjectID"></dx-select-box>
            </div>
            <div class="row">
                    <label class="control-label" style="padding-left: 2%;">Tarih Aralığı</label>
                    <div class="col-sm-6">
                    <dx-date-box [acceptCustomValue]="false" [(value)]="startDate" pickerType="calendar" type="date"
                                 displayFormat="dd/MM/yyyy" style="width:100%"> </dx-date-box>
                    </div>
                    <div class="col-sm-6">
                    <dx-date-box [acceptCustomValue]="false" [(value)]="endDate" pickerType="calendar" type="date"
                                 displayFormat="dd/MM/yyyy" style="width:100%"> </dx-date-box>
                    </div>
            </div>
            <div class="row" style="padding-left: 2%;">
                <label class="control-label">Taşınır Seçiniz</label>
                <dx-drop-down-box [(value)]="selectedMaterialItem.Name" displayExpr="Name" valueExpr="ObjectID"
                                  [showClearButton]="true" [dataSource]="" (onOpened)="openMaterialDropDown()"
                                (onValueChanged)="onClearMaterial($event)">
                    <div *dxTemplate="let data of 'content'">
                            <dx-data-grid [showColumnLines]="true" [showRowLines]="true" [showBorders]="true"
                                [rowAlternationEnabled]="true" [dataSource]="materialDataSource" (onRowClick)="selectMaterial($event)"
                                [remoteOperations]="true" [customizeColumns]="null">
                            <dxo-filter-row [visible]="true"></dxo-filter-row>
                            <dxo-paging [pageSize]="10"></dxo-paging>
                            <dxo-selection mode="single"></dxo-selection>
                            <dxi-column caption="Barkod" dataField="Barcode" width="100"></dxi-column>
                            <dxi-column caption="Taşınır" dataField="Name"></dxi-column>
                          </dx-data-grid>
                    </div>
                </dx-drop-down-box>
            </div>
        </div>
        <div class="col-sm-1">
            <dx-button type="default" text="Listele" style="width:80px;height: 170px;margin-top: 11%;" (onClick)="searchClick()"></dx-button>
        </div>
        <div class="col-sm-5" style="margin-top: 2%;">
            <div class="row">
                <div class ="col-sm-2"></div>
                <div class ="col-sm-4">Tutar</div>
                <div class ="col-sm-4">Miktar</div>
            </div>
            <div class="row">
                <div class ="col-sm-2">Devir</div>
                <div class ="col-sm-4">
                    <dx-text-box [readOnly]="true" [(value)]="output.devirTutar"></dx-text-box>
                </div>
                <div class ="col-sm-4">
                    <dx-text-box [readOnly]="true" [(value)]="output.devirMiktar"></dx-text-box>
                </div>
            </div>
            <div class="row">
                <div class ="col-sm-2">Girişler</div>
                <div class ="col-sm-4">
                    <dx-text-box [readOnly]="true" [(value)]="output.girisTutar"></dx-text-box>
                </div>
                <div class ="col-sm-4">
                    <dx-text-box [readOnly]="true" [(value)]="output.girisMiktar"></dx-text-box>
                </div>
            </div>
            <div class="row">
                <div class ="col-sm-2">Çıkışlar</div>
                <div class ="col-sm-4">
                <dx-text-box [readOnly]="true" [(value)]="output.cikisTutar"></dx-text-box>
            </div>
            <div class ="col-sm-4">
                <dx-text-box [readOnly]="true" [(value)]="output.cikisMiktar"></dx-text-box>
            </div>
            </div>
            <div class="row">
                <div class ="col-sm-2">Kalan</div>
                <div class ="col-sm-4">
                <dx-text-box [readOnly]="true" [(value)]="output.kalanTutar"></dx-text-box>
            </div>
            <div class ="col-sm-4">
                <dx-text-box [readOnly]="true" [(value)]="output.kalanMiktar"></dx-text-box>
            </div>
            </div>
        </div>
    </div>
</div>

<dx-load-panel #loadPanel shadingColor="rgba(0,0,0,0.4)" [position]="{ of: '#outtableLotGrid' }"
               [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true" [shading]="true" message="Girişler Getiriliyor.."
               [closeOnOutsideClick]="false">
</dx-load-panel>
 `
})
export class InOutRemainingComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public inOutRemainingDTO: InOutRemainingDTO;
    public loadingVisible: boolean = false;
    public output: GetInoutRemaining_Output = new GetInoutRemaining_Output();
    public mainStores: Array<MainStoreDVO> = new Array<MainStoreDVO>();
    public outTypes: Array<OutTypeDVO> = new Array<OutTypeDVO>();
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public selectedMainStoreID: Guid;
    public materialObjectID: Guid;
    public budgetTypeObjectID: Guid;
    public budgetTypeSources: Array<BudgetTypeDefDVO> = new Array<BudgetTypeDefDVO>();




    selectedMaterialItem: any = {};

    constructor(private modalStateService: ModalStateService, protected httpService: NeHttpService) {
        this.startDate = new Date();
        this.endDate = new Date();
    }

    public async setInputParam(value: string) {
        this.loadingVisible = true;
        this.inOutRemainingDTO = await StockActionService.GetInoutRemainingInitDVO();
        let mainStoreID: string = value as string;
        this.budgetTypeSources = this.inOutRemainingDTO.budgetTypeDefinitions;
        this.mainStores = this.inOutRemainingDTO.mainStores;

        let seletedMainStoreDVO: MainStoreDVO = this.mainStores.find(x => x.ObjectID == new Guid(mainStoreID));
        if (seletedMainStoreDVO != null)
            this.selectedMainStoreID = seletedMainStoreDVO.ObjectID;

        this.loadingVisible = false;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    selectBudgetType(data: any) {
        this.budgetTypeObjectID = data.selectedItem.objectID;
    }

    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialObjectID = this.selectedMaterialItem.ObjectID;
    }

    openMaterialDropDown() {
        this.getMaterialDataSource();
    }

    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
            this.materialObjectID = null;
        }
    }

    materialDataSource: DataSource;
    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'MaterialList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/StockActionService/GetMaterialList?storeID=' + this.selectedMainStoreID, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }




    public async searchClick(): Promise<void> {


        if (this.selectedMainStoreID == null) {
            ServiceLocator.MessageService.showError('Ana Depo seçmediniz.');
            return;
        }

        if (this.startDate == null) {
            ServiceLocator.MessageService.showError('Başlangıç Tarihi seçmediniz.');
            return;
        }

        if (this.endDate == null) {
            ServiceLocator.MessageService.showError('Bitiş Tarihi seçmediniz.');
            return;
        }
        if (this.budgetTypeObjectID == null || this.budgetTypeObjectID == Guid.Empty) {
            ServiceLocator.MessageService.showError('Bütçe Türü seçmediniz.');
            return;
        }

        if(this.startDate.Year != this.endDate.Year){
            ServiceLocator.MessageService.showError('Aynı Dönem için seçmeni gerekmektedir.');
            return;
        }

        this.output = await StockActionService.GetInoutRemaining(this.selectedMainStoreID, this.startDate, this.endDate, this.materialObjectID, this.budgetTypeObjectID);
    }
}