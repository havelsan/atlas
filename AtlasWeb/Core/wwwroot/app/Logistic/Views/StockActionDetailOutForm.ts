import { Component, ViewChild } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DxDataGridComponent } from 'devextreme-angular';
import { DrugOrderInfo_Output } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { OuttableLot } from 'app/NebulaClient/Model/AtlasClientModel';
import { GetOuttableLots_Output, GetOuttableLots_Input, StockActionService, OpenStockActionDetailOutput_Input, ParseQRcode_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { OuttableLotDTO } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/ChattelDocumentOutputWithAccountancyNewFormViewModel';


@Component({
    selector: 'stockactiondetailout-component',
    template: `
    <div class="row">
        <div class="col-sm-12" style="text-align:center">
            <p style="color:red;font-size: 15px;font-weight: bold;">{{detailCaption}}</p>
        </div>
    </div>
    <div class="row" style="padding-top: 1%;padding-left: 2%;">
        <div class="col-sm-4">
            <dx-radio-group [items]="selectTypes" [(value)]="selectType" layout="horizontal"
                            (onValueChanged)="onValueChangedCombo($event)"> </dx-radio-group>
        </div>
        <div class="col-sm-8">
            <dx-text-box placeholder="Karekod..." [(value)]="qrCodeValue" [(disabled)]="IsDisableReadQRCode"
                         valueChangeEvent="keyup" (keypress)="QRCodeValue_KeyPress($event)"></dx-text-box>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-12">
            <dx-data-grid #outtableLotGrid  keyExpr="TrxObjectID" [height]="300" [dataSource]="outtableLots" [columns]="OuttableLotsGridColumns"
                          [(disabled)]="IsDisableGrid" [(selectedRowKeys)]="selectedOuttableLotGridRowKeys">
                <dxo-paging [pageSize]="100" id="A31078"></dxo-paging>
                <dxo-selection mode="multiple"></dxo-selection>
            </dx-data-grid>
            <br />
            <div style="float: left">
                <dx-button type="default" text="Seç" style="width:80px" (onClick)="okClick()"></dx-button>
            </div>
            <div style="float: right">
                <dx-button type="danger" text="Vazgeç" style="width:80px" (onClick)="cancelClick()"></dx-button>
            </div>
        </div>
    </div>
    <dx-load-panel #loadPanel shadingColor="rgba(0,0,0,0.4)" [position]="{ of: '#outtableLotGrid' }"
        [(visible)]="loadingVisible" [showIndicator]="true" [showPane]="true" [shading]="true" message="Girişler Getiriliyor.."
        [closeOnOutsideClick]="false">
    </dx-load-panel>
 `
})
export class StockActionDetailOutForm implements IModal {

    public componentInfo: DynamicComponentInfo;
    private _modalInfo: ModalInfo;
    public inputParameterDTO: OpenStockActionDetailOutput_Input;
    public materialID: Guid;
    public materialName: string;
    public requestAmount: number;
    public barcode: string;
    public distributionTypeName: string;
    public detailCaption: string;
    public selectTypes: string[];
    public selectType: string;
    public IsDisableReadQRCode: boolean;
    public IsDisableGrid: boolean;
    public qrCodeValue: string;
    public loadingVisible: boolean = false;
    @ViewChild('outtableLotGrid') outtableLotGrid: DxDataGridComponent;
    public outtableLots: Array<GetOuttableLots_Output> = new Array<GetOuttableLots_Output>();
    public selectedOuttableLots: Array<GetOuttableLots_Output> = new Array<GetOuttableLots_Output>();
    public selectedOuttableLotGridRowKeys: Array<Guid> = new Array<Guid>();
    public OuttableLotsGridColumns = [
        {
            caption: 'Lot No',
            dataField: 'LotNo',
            dataType: 'string',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'S.K. Tarihi',
            dataField: 'ExpirationDate',
            dataType: "date",
            format: "shortDate",
            allowEditing: false,
            sortOrder: 'asc'
        },
        {
            caption: 'Seri No',
            dataField: 'SerialNo',
            dataType: "string",
            allowEditing: false
        },
        {
            caption: 'Bütçe Tipi',
            dataField: 'BudgetTypeName',
            dataType: "string",
            allowEditing: false
        },
        {
            caption: 'Kalan Miktar',
            dataField: 'RestAmount',
            dataType: "number",
            allowEditing: false
        },
        {
            caption: 'TrxObjectID',
            dataField: 'TrxObjectID',
            allowEditing: false,
            width: 'auto',
            visible: false
        },
    ];

    constructor(private modalStateService: ModalStateService, private http: NeHttpService) {
        this.selectTypes = [
            "Serbest Seçim",
            "QR Kod Okut"
        ];
        this.selectType = this.selectTypes[0];
        this.IsDisableGrid = false;
        this.IsDisableReadQRCode = true;
    }

    public async setInputParam(value: OpenStockActionDetailOutput_Input) {
        this.loadingVisible = true;
        this.inputParameterDTO = value as OpenStockActionDetailOutput_Input;
        this.materialName = this.inputParameterDTO.MaterialName;
        this.requestAmount = this.inputParameterDTO.RequestAmount;
        this.barcode = this.inputParameterDTO.Barcode;
        if (this.inputParameterDTO.DistributionTypeName != null)
            this.distributionTypeName = this.inputParameterDTO.DistributionTypeName;
        else
            this.distributionTypeName = "ADET";
        this.detailCaption = this.materialName + " - " + this.requestAmount.toString() + " " + this.distributionTypeName;
        this.outtableLots = await StockActionService.GetOuttableLots(this.inputParameterDTO.StoreID, this.inputParameterDTO.MaterialID);
        if (this.inputParameterDTO.selectedOuttableLots.length > 0) {
            this.outtableLots.forEach(lot => {
                let findLot: OuttableLotDTO = this.inputParameterDTO.selectedOuttableLots.find(x => x.BudgetTypeName === lot.BudgetTypeName && x.ExpirationDate === lot.ExpirationDate
                    && x.LotNo === lot.LotNo && x.SerialNo === lot.SerialNo && x.TrxObjectID === lot.TrxObjectID)
                    if(findLot != null){
                        this.selectedOuttableLotGridRowKeys.push(lot.TrxObjectID);
                    }
            });
            if(this.selectedOuttableLotGridRowKeys.length > 0){
                this.outtableLotGrid.instance.selectRows(this.selectedOuttableLotGridRowKeys,true);
            }
        }
        this.loadingVisible = false;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public onValueChangedCombo($event) {
        if ('QR Kod Okut' === $event.value) {
            this.IsDisableReadQRCode = false;
            this.IsDisableGrid = true;
            this.selectedOuttableLotGridRowKeys = new Array<Guid>();
        }
        else if ('Serbest Seçim' === $event.value) {
            this.IsDisableReadQRCode = true;
            this.IsDisableGrid = false;
            this.selectedOuttableLotGridRowKeys = new Array<Guid>();
        }
    }

    async QRCodeValue_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let qrCode: ParseQRcode_Output;
            await StockActionService.ParseQRCode(this.qrCodeValue).then(res => {
                qrCode = res;
                if (qrCode.Barcode.toString() === this.barcode) {
                    let findTRX: Array<GetOuttableLots_Output> = this.outtableLots.filter(x => x.LotNo == qrCode.BatchNo && x.ExpirationDate == qrCode.ExpirationDate && x.SerialNo == qrCode.PackageCode);
                    if (findTRX != null) {
                        for (let trx of findTRX) {
                            this.selectedOuttableLotGridRowKeys.push(trx.TrxObjectID);
                        }
                        this.qrCodeValue = "";
                    } else {
                        ServiceLocator.MessageService.showError("Okuttuğunuz barkoddan çıkılabilir giriş bulunmamaktadır. Lot No: " + qrCode.BatchNo + " Seri No: " + qrCode.PackageCode);
                    }
                } else {
                    ServiceLocator.MessageService.showError("Okuttuğunuz barkod " + this.materialName + " değildir. Barkod: " + qrCode.Barcode.toString());
                }
            }).catch(err => {
                ServiceLocator.MessageService.showInfo(err);
            });
        }
    }

    public okClick(): void {
        let selectAmount: number = 0;
        for (let selectedLot of this.outtableLotGrid.instance.getSelectedRowsData()) {
            this.selectedOuttableLots.push(selectedLot);
            selectAmount = selectAmount + selectedLot.RestAmount;
        }
        if (selectAmount < this.requestAmount) {
            ServiceLocator.MessageService.showError("Yetreli miktarda giriş seçmediniz. Seçilen Miktar: " + selectAmount.toString() + " İstenen Miktar: " + this.requestAmount.toString());
        } else {
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.selectedOuttableLots);
        }
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, null);
    }
}