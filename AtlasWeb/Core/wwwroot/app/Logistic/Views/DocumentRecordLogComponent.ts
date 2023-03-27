import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DxDataGridComponent } from 'devextreme-angular';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { StockActionService, DocumentRecordLogInitDVO, MainStoreDVO, OutTypeDVO, GetDocumentRecordLogsSameMKYS_Output, GetDocumentRecordLogsDetails_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { MKYSControlEnum, MKYS_EButceTurEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';


@Component({
    selector: 'documentrecordlog-component',
    template: `
    <div class="row" style="padding-top: 1%;padding-left: 2%;">
    <div class="col-sm-8">
        <dx-data-grid #documentRecordLogGrid keyExpr="DocumentRecordLogID" [height]="300" [dataSource]="documentRecordLogs" 
        (onSelectionChanged)="onSelectionChanged($event)" (onRowPrepared)="onRowPrepared($event)" [columns]="DocumentRecordLogGridColumns">
            <dxo-paging [pageSize]="100" ></dxo-paging>
            <dxo-selection mode="single"></dxo-selection>
        </dx-data-grid>
    </div>
    <div class="col-sm-4">
        <div class="row">
            <div class="col-sm-12">
                <label class="control-label">Ana Depo</label>
                <dx-select-box [dataSource]="mainStores"
                               displayExpr="Name"
                               valueExpr="ObjectID"
                               [(value)]="selectedMainStoreID"></dx-select-box>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <label class="control-label">Çıkış Türleri</label>
                <dx-select-box [items]="outTypes"
                               displayExpr="TypeName"
                               [(value)]="selectedOutType" [showClearButton]="true"></dx-select-box>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <label class="control-label">Tarih Aralığı</label>
                <div class="col-sm-6">
                    <dx-date-box [acceptCustomValue]="false" [(value)]="startDate" pickerType="calendar" type="date"
                                 displayFormat="dd/MM/yyyy" style="width:100%"> </dx-date-box>
                </div>
                <div class="col-sm-6">
                    <dx-date-box [acceptCustomValue]="false" [(value)]="endDate" pickerType="calendar" type="date"
                                 displayFormat="dd/MM/yyyy" style="width:100%"> </dx-date-box>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <label class="control-label">Belge No Aralığı</label>
                <div class="col-sm-6">
                    <dx-number-box #numberBox [min]="0" [max]="9999" [showSpinButtons]="true" [(value)]="startTIFNo">
                    </dx-number-box>
                </div>
                <div class="col-sm-6">
                    <dx-number-box #numberBox [min]="0" [max]="9999" [showSpinButtons]="true" [(value)]="endTIFNo">
                    </dx-number-box>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-12">
                <div style="float: right">
                    <dx-button type="default" text="Listele" style="width:80px" (onClick)="searchClick()"></dx-button>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="row" style="padding-top: 1%;padding-left: 2%;">
    <div class="col-sm-12">
        <dx-data-grid #materialGrid [height]="400" [dataSource]="materials" [columns]="MaterialGridColumns">
            <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
            <dxo-summary>
                <dxi-total-item column="Amount" summaryType="sum" displayFormat="T.M.: {0}"></dxi-total-item>
                <dxi-total-item column="TotalPrice" summaryType="sum" displayFormat="T.T.: {0}"></dxi-total-item>
            </dxo-summary>
        </dx-data-grid>
    </div>
</div>
<dx-load-panel #loadPanel shadingColor="rgba(0,0,0,0.4)" [position]="{ of: '#outtableLotGrid' }"
               [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true" [shading]="true" message="Girişler Getiriliyor.."
               [closeOnOutsideClick]="false">
</dx-load-panel>
 `
})
export class DocumentRecordLogComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public documentRecordLogInitDVO: DocumentRecordLogInitDVO;
    public loadingVisible: boolean = false;
    @ViewChild('documentRecordLogGrid') documentRecordLogGrid: DxDataGridComponent;
    public documentRecordLogs: Array<GetDocumentRecordLogsSameMKYS_Output> = new Array<GetDocumentRecordLogsSameMKYS_Output>();
    public materials: Array<GetDocumentRecordLogsDetails_Output> = new Array<GetDocumentRecordLogsDetails_Output>();
    public mainStores: Array<MainStoreDVO> = new Array<MainStoreDVO>();
    public outTypes: Array<OutTypeDVO> = new Array<OutTypeDVO>();
    public startDate: Date;
    public endDate: Date;
    public startTIFNo: number;
    public endTIFNo: number;
    public selectedOutType: OutTypeDVO;
    public selectedMainStoreID: Guid;
    public DocumentRecordLogGridColumns = [
        {
            caption: 'Belge No',
            dataField: 'TIFNo',
            dataType: 'string',
            allowEditing: false,
            width: 'auto',
            sortOrder: 'asc'
        },
        {
            caption: 'Tarihi',
            dataField: 'TransactionDate',
            dataType: "date",
            format: "shortDate",
            allowEditing: false,
            width: 90,
        },
        {
            caption: 'Birim',
            dataField: 'TakenGivenPlace',
            dataType: "string",
            allowEditing: false,
            width: 250,
        },
        {
            caption: 'Hareket Türü',
            dataField: 'Subject',
            dataType: "string",
            allowEditing: false,
            width: 180,
        },
        {
            caption: "Bütçe",
            dataField: 'BudgetType',
            lookup: { dataSource: MKYS_EButceTurEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 90,
        },
        {
            caption: "MKYS Durumu",
            dataField: 'MKYSStatus',
            lookup: { dataSource: MKYSControlEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: false,
            width: 90,
        },
    ];

    public MaterialGridColumns = [
        {
            caption: 'Taşınır kodu',
            dataField: 'NatoStockNo',
            dataType: 'string',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'Malzeme Adı',
            dataField: 'MaterialName',
            dataType: 'string',
            allowEditing: false,
            width: 300,
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            dataType: 'number',
            alignment: 'right',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'Dağıtım Şekli',
            dataField: 'DistributionType',
            dataType: 'string',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'Birim Fiyat',
            dataField: 'UnitPrice',
            dataType: 'number',
            alignment: 'right',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Tutar',
            dataField: 'TotalPrice',
            dataType: 'number',
            alignment: 'right',
            allowEditing: false,
            width: 200,
        },
    ];

    constructor(private modalStateService: ModalStateService) {

    }

    public async setInputParam(value: string) {
        this.loadingVisible = true;
        let mainStoreID: string = value as string;
        this.documentRecordLogInitDVO = await StockActionService.GetDocumentRecordLogInitDVO();
        this.mainStores = this.documentRecordLogInitDVO.mainStores;
        this.outTypes = this.documentRecordLogInitDVO.outTypes;
        this.startDate = this.documentRecordLogInitDVO.startDate;
        this.endDate = this.documentRecordLogInitDVO.endDate;
        this.startTIFNo = this.documentRecordLogInitDVO.startTIFNo;
        this.endTIFNo = this.documentRecordLogInitDVO.endTIFNo;
        let seletedMainStoreDVO: MainStoreDVO = this.mainStores.find(x => x.ObjectID == new Guid(mainStoreID));
        if (seletedMainStoreDVO != null)
            this.selectedMainStoreID = seletedMainStoreDVO.ObjectID;

        this.loadingVisible = false;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    onRowPrepared(e: any): void {
        if (e.rowType == 'data' && e.data != null) {

            if (e.data.MKYSStatus != null && e.rowElement.firstItem() != null) {

                let colorEnum: MKYSControlEnum = e.data.MKYSStatus;

                if (colorEnum.Value === MKYSControlEnum.Completed) {
                    e.rowElement.firstItem().style.backgroundColor = '#DC143C';
                    e.rowElement.firstItem().style.color = '#F8F8FF';
                }
                if (colorEnum.Value === MKYSControlEnum.CompletedSent) {
                    e.rowElement.firstItem().style.backgroundColor = '#ffffff';
                    e.rowElement.firstItem().style.color = '#000000';
                }
            }
        }
    }

    public async onSelectionChanged() {
        let selectedDocument: GetDocumentRecordLogsSameMKYS_Output = this.documentRecordLogGrid.instance.getSelectedRowsData()[0];
        this.materials = await StockActionService.GetDocumentRecordLogsDetails(selectedDocument.StockActionID, selectedDocument.BudgetType);
    }

    public async searchClick(): Promise<void> {
        let outType: string = "";
        this.materials = new Array<GetDocumentRecordLogsDetails_Output>();
        
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

        if (this.selectedOutType != null)
            outType = this.selectedOutType.TypeName;
        this.documentRecordLogs = await StockActionService.GetDocumentRecordLogsSameMKYS(this.selectedMainStoreID, outType, this.startDate, this.endDate, this.startTIFNo, this.endTIFNo);
    }
}