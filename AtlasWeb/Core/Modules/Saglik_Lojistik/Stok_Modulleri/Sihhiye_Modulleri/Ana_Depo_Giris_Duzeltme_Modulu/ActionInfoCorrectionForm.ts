//$C9D110BE
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { ActionInfoCorrectionFormViewModel } from './ActionInfoCorrectionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ActionInfoCorrection, MainStoreDefinition, PharmacyStoreDefinition, Store, SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ActionInfoCorrectionDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { StockActionService, GetPurchaseStockAction_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { BaseChattelDocumentForm } from '../Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { TTBoundFormBase } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';

@Component({
    selector: 'ActionInfoCorrectionForm',
    templateUrl: './ActionInfoCorrectionForm.html',
    providers: [MessageService]
})
export class ActionInfoCorrectionForm extends TTBoundFormBase implements OnInit {
    ActionInfoCorrectionDets: TTVisual.ITTGrid;
    AmountActionInfoCorrectionDet: TTVisual.ITTTextBoxColumn;
    BaseDateTime: TTVisual.ITTDateTimePicker;
    BaseNumber: TTVisual.ITTTextBox;
    ExaminationReportDate: TTVisual.ITTDateTimePicker;
    ExaminationReportNo: TTVisual.ITTTextBox;
    PurchaseActionID: TTVisual.ITTTextBox;
    labelBaseDateTime: TTVisual.ITTLabel;
    labelBaseNumber: TTVisual.ITTLabel;
    labelExaminationReportDate: TTVisual.ITTLabel;
    labelExaminationReportNo: TTVisual.ITTLabel;
    labelPurchaseActionID: TTVisual.ITTLabel;
    Store: TTVisual.ITTObjectListBox;
    labelStore: TTVisual.ITTLabel;
    MaterialActionInfoCorrectionDet: TTVisual.ITTListBoxColumn;
    public ActionInfoCorrectionDetsColumns = [];
    public actionInfoCorrectionFormViewModel: ActionInfoCorrectionFormViewModel = new ActionInfoCorrectionFormViewModel();
    public get _ActionInfoCorrection(): ActionInfoCorrection {
        return this._TTObject as ActionInfoCorrection;
    }
    private ActionInfoCorrectionForm_DocumentUrl: string = '/api/ActionInfoCorrectionService/ActionInfoCorrectionForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected objectContextService: ObjectContextService, protected ngZone: NgZone) {
        super('ACTIONINFOCORRECTION', 'ActionInfoCorrectionForm');
        this._DocumentServiceUrl = this.ActionInfoCorrectionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public CorrectionMaterialGridColumns = [
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            allowEditing: false,
            width: 120,
        },
        {
            caption: i18n("M17464", "KDV\'siz Fiyatı"),
            dataField: 'StockActionDetailIn.UnitPriceWithOutVat',
            dataType: 'number',
            allowEditing: false,
            width: 'auto',
        },
        {
            caption: i18n("M17457", "KDV Oranı"),
            dataField: 'StockActionDetailIn.VatRate',
            dataType: 'number',
            allowEditing: false,
            width: 100,

        },
        {
            caption: i18n("M17462", "KDV\'li Fiyatı"),
            dataField: 'StockActionDetailIn.UnitPriceWithInVat',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16504", "İndirimli Birim Fiyat"),
            dataField: 'StockActionDetailIn.UnitPrice',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: i18n("M16006", "Indirim Tutarı"),
            dataField: 'StockActionDetailIn.DiscountAmount',
            dataType: 'number',
            allowEditing: false,
            width: 'auto'
        },
        {
            caption: 'Lot No.',
            dataField: 'StockActionDetailIn.LotNo',
            allowEditing: false,
            width: 85
        },
        {
            caption: 'Seri No.',
            dataField: 'StockActionDetailIn.SerialNo',
            allowEditing: false,
            width: 85
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'StockActionDetailIn.ExpirationDate',
            allowEditing: false,
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
    ];
    public async getPurchaseAction() {
        let result: GetPurchaseStockAction_Output = await StockActionService.GetPurchaseStockAction(this._ActionInfoCorrection.PurchaseActionID.toString(), this._ActionInfoCorrection.Store.ObjectID);
        if (result.PurchaseAction != null) {
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.BaseChattelDocument = result.PurchaseAction;
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.BaseDateTime = result.PurchaseAction.WaybillDate;
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.BaseNumber = result.PurchaseAction.Waybill;
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.ExaminationReportDate = result.PurchaseAction.ExaminationReportDate;
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.ExaminationReportNo = result.PurchaseAction.ExaminationReportNo;

            for (let purchaseDetail of result.PurchaseActionDetails) {
                let detail: ActionInfoCorrectionDet = new ActionInfoCorrectionDet();
                detail.Amount = purchaseDetail.Amount;
                detail.AddedAmount = purchaseDetail.Amount;
                detail.AuctionDate = purchaseDetail.AuctionDate;
                let guidMaterial: Guid = new Guid(purchaseDetail["Material"].toString());
                detail.Material = result.Materials.find(x => x.ObjectID == guidMaterial);
                detail.SerialNo = purchaseDetail.SerialNo;
                detail.Status = purchaseDetail.Status;
                detail.StockLevelType = purchaseDetail.StockLevelType;
                detail.StockActionDetailIn = purchaseDetail;
                //this.extendExpDateInFormViewModel.ExtendExpDateInDetailsGridList.push(detail);
                this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.ActionInfoCorrectionDets.push(detail);
            }
        }
    }

    inputStore: Store;
    public setInputParam(value: Store) {

        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        if (this._ActionInfoCorrection.Store == null) {
            this._ActionInfoCorrection.Store = this.inputStore;
            //await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }
    }

    public async stateChange(event: FormSaveInfo) {
        await super.setState(event.transDef, event);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ActionInfoCorrection();
        this.actionInfoCorrectionFormViewModel = new ActionInfoCorrectionFormViewModel();
        this._ViewModel = this.actionInfoCorrectionFormViewModel;
        this.actionInfoCorrectionFormViewModel._ActionInfoCorrection = this._TTObject as ActionInfoCorrection;
        this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.Store = new Store();
        this.actionInfoCorrectionFormViewModel._ActionInfoCorrection.ActionInfoCorrectionDets = new Array<ActionInfoCorrectionDet>();
    }

    protected loadViewModel() {
        let that = this;
        that.actionInfoCorrectionFormViewModel = this._ViewModel as ActionInfoCorrectionFormViewModel;
        that._TTObject = this.actionInfoCorrectionFormViewModel._ActionInfoCorrection;
        if (this.actionInfoCorrectionFormViewModel == null)
            this.actionInfoCorrectionFormViewModel = new ActionInfoCorrectionFormViewModel();
        if (this.actionInfoCorrectionFormViewModel._ActionInfoCorrection == null)
            this.actionInfoCorrectionFormViewModel._ActionInfoCorrection = new ActionInfoCorrection();
        that.actionInfoCorrectionFormViewModel._ActionInfoCorrection.ActionInfoCorrectionDets = that.actionInfoCorrectionFormViewModel.ActionInfoCorrectionDetsGridList;
        for (let detailItem of that.actionInfoCorrectionFormViewModel.ActionInfoCorrectionDetsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.actionInfoCorrectionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
            }

        }

        /*let storeObjectID = that.actionInfoCorrectionFormViewModel._ActionInfoCorrection["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.actionInfoCorrectionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.actionInfoCorrectionFormViewModel._ActionInfoCorrection.Store = store;
            }
        }*/
    }

    async ngOnInit() {
        await this.load();
        this.FormCaption = "Satınalma Fatura Güncelleme ( Yeni )";
    }

    public onBaseDateTimeChanged(event): void {
        if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.BaseDateTime != event) {
            this._ActionInfoCorrection.BaseDateTime = event;
        }
    }

    public onBaseNumberChanged(event): void {
        if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.BaseNumber != event) {
            this._ActionInfoCorrection.BaseNumber = event;
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.ExaminationReportDate != event) {
            this._ActionInfoCorrection.ExaminationReportDate = event;
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.ExaminationReportNo != event) {
            this._ActionInfoCorrection.ExaminationReportNo = event;
        }
    }

    public onPurchaseActionIDChanged(event): void {
        if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.PurchaseActionID != event) {
            this._ActionInfoCorrection.PurchaseActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ActionInfoCorrection != null && this._ActionInfoCorrection.Store != event) {
                this._ActionInfoCorrection.Store = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.BaseDateTime, "Value", this.__ttObject, "BaseDateTime");
        redirectProperty(this.BaseNumber, "Text", this.__ttObject, "BaseNumber");
        redirectProperty(this.ExaminationReportDate, "Value", this.__ttObject, "ExaminationReportDate");
        redirectProperty(this.ExaminationReportNo, "Text", this.__ttObject, "ExaminationReportNo");
        redirectProperty(this.PurchaseActionID, "Text", this.__ttObject, "PurchaseActionID");
    }

    public initFormControls(): void {
        this.ActionInfoCorrectionDets = new TTVisual.TTGrid();
        this.ActionInfoCorrectionDets.Name = "ActionInfoCorrectionDets";
        this.ActionInfoCorrectionDets.TabIndex = 8;

        this.MaterialActionInfoCorrectionDet = new TTVisual.TTListBoxColumn();
        this.MaterialActionInfoCorrectionDet.ListDefName = "MaterialListDefinition";
        this.MaterialActionInfoCorrectionDet.DataMember = "Material";
        this.MaterialActionInfoCorrectionDet.DisplayIndex = 0;
        this.MaterialActionInfoCorrectionDet.HeaderText = "Malzeme";
        this.MaterialActionInfoCorrectionDet.Name = "MaterialActionInfoCorrectionDet";
        this.MaterialActionInfoCorrectionDet.Width = 300;

        this.AmountActionInfoCorrectionDet = new TTVisual.TTTextBoxColumn();
        this.AmountActionInfoCorrectionDet.DataMember = "Amount";
        this.AmountActionInfoCorrectionDet.DisplayIndex = 1;
        this.AmountActionInfoCorrectionDet.HeaderText = "Miktar";
        this.AmountActionInfoCorrectionDet.Name = "AmountActionInfoCorrectionDet";
        this.AmountActionInfoCorrectionDet.Width = 80;

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = "Muayene Komisyonu Rapor Sayısı";
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 7;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.TabIndex = 6;

        this.BaseNumber = new TTVisual.TTTextBox();
        this.BaseNumber.Name = "BaseNumber";
        this.BaseNumber.TabIndex = 2;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = "Muayene Komisyonu Rapor Tarihi";
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 5;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Short;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.TabIndex = 4;

        this.labelBaseNumber = new TTVisual.TTLabel();
        this.labelBaseNumber.Text = "Dayanak Numarası";
        this.labelBaseNumber.Name = "labelBaseNumber";
        this.labelBaseNumber.TabIndex = 3;

        this.labelBaseDateTime = new TTVisual.TTLabel();
        this.labelBaseDateTime.Text = "Dayanak Tarihi";
        this.labelBaseDateTime.Name = "labelBaseDateTime";
        this.labelBaseDateTime.TabIndex = 1;

        this.BaseDateTime = new TTVisual.TTDateTimePicker();
        this.BaseDateTime.Format = DateTimePickerFormat.Short;
        this.BaseDateTime.Name = "BaseDateTime";
        this.BaseDateTime.TabIndex = 0;

        this.labelPurchaseActionID = new TTVisual.TTLabel();
        this.labelPurchaseActionID.Text = "Satınalma İşlem ID";
        this.labelPurchaseActionID.Name = "labelPurchaseActionID";
        this.labelPurchaseActionID.TabIndex = 123;

        this.PurchaseActionID = new TTVisual.TTTextBox();
        this.PurchaseActionID.Name = "PurchaseActionID";
        this.PurchaseActionID.TabIndex = 122;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14807", "Giriş Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 142;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 141;

        this.ActionInfoCorrectionDetsColumns = [this.MaterialActionInfoCorrectionDet, this.AmountActionInfoCorrectionDet];
        this.Controls = [this.ActionInfoCorrectionDets, this.MaterialActionInfoCorrectionDet, this.AmountActionInfoCorrectionDet, this.labelExaminationReportNo, this.ExaminationReportNo, this.BaseNumber, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelBaseNumber, this.labelBaseDateTime, this.BaseDateTime, 
            this.labelPurchaseActionID, this.PurchaseActionID, this.labelStore, this.Store];

    }
}
