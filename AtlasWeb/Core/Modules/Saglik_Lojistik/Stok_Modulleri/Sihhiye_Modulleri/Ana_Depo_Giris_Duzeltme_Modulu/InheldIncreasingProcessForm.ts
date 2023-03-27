//$016100E7
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { InheldIncreasingProcessFormViewModel } from './InheldIncreasingProcessFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { InheldIncreasingProcess, Store, MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { InheldIncreasingProcessDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTBoundFormBase } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { StockActionService, GetPurchaseStockAction_Output } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';

@Component({
    selector: 'InheldIncreasingProcessForm',
    templateUrl: './InheldIncreasingProcessForm.html',
    providers: [MessageService]
})
export class InheldIncreasingProcessForm extends TTBoundFormBase implements OnInit {
    AddedAmountInheldIncreasingProcessDet: TTVisual.ITTTextBoxColumn;
    AmountInheldIncreasingProcessDet: TTVisual.ITTTextBoxColumn;
    BaseDateTime: TTVisual.ITTDateTimePicker;
    BaseNumber: TTVisual.ITTTextBox;
    ExaminationReportDate: TTVisual.ITTDateTimePicker;
    ExaminationReportNo: TTVisual.ITTTextBox;
    PurchaseActionID: TTVisual.ITTTextBox;
    //InheldIncreasingProcessDets: TTVisual.ITTGrid;
    labelBaseDateTime: TTVisual.ITTLabel;
    labelBaseNumber: TTVisual.ITTLabel;
    labelExaminationReportDate: TTVisual.ITTLabel;
    labelExaminationReportNo: TTVisual.ITTLabel;
    labelPurchaseActionID: TTVisual.ITTLabel;
    Store: TTVisual.ITTObjectListBox;
    labelStore: TTVisual.ITTLabel;
    MaterialInheldIncreasingProcessDet: TTVisual.ITTListBoxColumn;
    public InheldIncreasingProcessDetsColumns = [];
    public inheldIncreasingProcessFormViewModel: InheldIncreasingProcessFormViewModel = new InheldIncreasingProcessFormViewModel();
    public get _InheldIncreasingProcess(): InheldIncreasingProcess {
        return this._TTObject as InheldIncreasingProcess;
    }
    private InheldIncreasingProcessForm_DocumentUrl: string = '/api/InheldIncreasingProcessService/InheldIncreasingProcessForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected objectContextService: ObjectContextService, protected ngZone: NgZone) {
        super('INHELDINCREASINGPROCESS', 'InheldIncreasingProcessForm');
        this._DocumentServiceUrl = this.InheldIncreasingProcessForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public IncreasingMaterialGridColumns = [
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
            caption: "Eklenecek Miktar",
            dataField: 'AddedAmount',
            dataType: 'number',
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
        let result: GetPurchaseStockAction_Output = await StockActionService.GetPurchaseStockAction(this._InheldIncreasingProcess.PurchaseActionID.toString(), this._InheldIncreasingProcess.Store.ObjectID);
        if (result.PurchaseAction != null) {
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.BaseChattelDocument = result.PurchaseAction;
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.BaseDateTime = result.PurchaseAction.WaybillDate;
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.BaseNumber = result.PurchaseAction.Waybill;
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.ExaminationReportDate = result.PurchaseAction.ExaminationReportDate;
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.ExaminationReportNo = result.PurchaseAction.ExaminationReportNo;

            for (let purchaseDetail of result.PurchaseActionDetails) {
                let detail: InheldIncreasingProcessDet = new InheldIncreasingProcessDet();
                detail.Amount = purchaseDetail.Amount;
                detail.AddedAmount = 0;
                detail.AuctionDate = purchaseDetail.AuctionDate;
                let guidMaterial: Guid = new Guid(purchaseDetail["Material"].toString());
                detail.Material = result.Materials.find(x => x.ObjectID == guidMaterial);
                detail.SerialNo = purchaseDetail.SerialNo;
                detail.Status = purchaseDetail.Status;
                detail.StockLevelType = purchaseDetail.StockLevelType;
                detail.StockActionDetailIn = purchaseDetail;
                //this.extendExpDateInFormViewModel.ExtendExpDateInDetailsGridList.push(detail);
                this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.InheldIncreasingProcessDets.push(detail);
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
        if (this._InheldIncreasingProcess.Store == null) {
            this._InheldIncreasingProcess.Store = this.inputStore;
            //await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }
    }

    public async stateChange(event: FormSaveInfo) {
        await super.setState(event.transDef, event);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InheldIncreasingProcess();
        this.inheldIncreasingProcessFormViewModel = new InheldIncreasingProcessFormViewModel();
        this._ViewModel = this.inheldIncreasingProcessFormViewModel;
        this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess = this._TTObject as InheldIncreasingProcess;
        this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.Store = new Store();
        this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.InheldIncreasingProcessDets = new Array<InheldIncreasingProcessDet>();
    }

    protected loadViewModel() {
        let that = this;
        that.inheldIncreasingProcessFormViewModel = this._ViewModel as InheldIncreasingProcessFormViewModel;
        that._TTObject = this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess;
        if (this.inheldIncreasingProcessFormViewModel == null)
            this.inheldIncreasingProcessFormViewModel = new InheldIncreasingProcessFormViewModel();
        if (this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess == null)
            this.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess = new InheldIncreasingProcess();
        that.inheldIncreasingProcessFormViewModel._InheldIncreasingProcess.InheldIncreasingProcessDets = that.inheldIncreasingProcessFormViewModel.InheldIncreasingProcessDetsGridList;
        if (that.inheldIncreasingProcessFormViewModel && that.inheldIncreasingProcessFormViewModel.InheldIncreasingProcessDetsGridList) {
            for (let detailItem of that.inheldIncreasingProcessFormViewModel.InheldIncreasingProcessDetsGridList) {
                let materialObjectID = detailItem["Material"];
                if (materialObjectID != null && (typeof materialObjectID === "string")) {
                    let material = that.inheldIncreasingProcessFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                    if (material) {
                        detailItem.Material = material;
                    }
                }
            }
        }
    }

    async ngOnInit() {
        await this.load();
        this.FormCaption = "Satınalma Mevcut Arttırma ( Yeni )";
    }

    public onBaseDateTimeChanged(event): void {
        if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.BaseDateTime != event) {
            this._InheldIncreasingProcess.BaseDateTime = event;
        }
    }

    public onBaseNumberChanged(event): void {
        if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.BaseNumber != event) {
            this._InheldIncreasingProcess.BaseNumber = event;
        }
    }

    public onExaminationReportDateChanged(event): void {
        if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.ExaminationReportDate != event) {
            this._InheldIncreasingProcess.ExaminationReportDate = event;
        }
    }

    public onExaminationReportNoChanged(event): void {
        if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.ExaminationReportNo != event) {
            this._InheldIncreasingProcess.ExaminationReportNo = event;
        }
    }

    public onPurchaseActionIDChanged(event): void {
        if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.PurchaseActionID != event) {
            this._InheldIncreasingProcess.PurchaseActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._InheldIncreasingProcess != null && this._InheldIncreasingProcess.Store != event) {
                this._InheldIncreasingProcess.Store = event;
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
        this.MaterialInheldIncreasingProcessDet = new TTVisual.TTListBoxColumn();
        this.MaterialInheldIncreasingProcessDet.ListDefName = "MaterialListDefinition";
        this.MaterialInheldIncreasingProcessDet.DataMember = "Material";
        this.MaterialInheldIncreasingProcessDet.DisplayIndex = 0;
        this.MaterialInheldIncreasingProcessDet.HeaderText = "Malzeme";
        this.MaterialInheldIncreasingProcessDet.Name = "MaterialInheldIncreasingProcessDet";
        this.MaterialInheldIncreasingProcessDet.Width = 300;

        this.AmountInheldIncreasingProcessDet = new TTVisual.TTTextBoxColumn();
        this.AmountInheldIncreasingProcessDet.DataMember = "Amount";
        this.AmountInheldIncreasingProcessDet.DisplayIndex = 1;
        this.AmountInheldIncreasingProcessDet.HeaderText = "Miktar";
        this.AmountInheldIncreasingProcessDet.Name = "AmountInheldIncreasingProcessDet";
        this.AmountInheldIncreasingProcessDet.Width = 80;

        this.AddedAmountInheldIncreasingProcessDet = new TTVisual.TTTextBoxColumn();
        this.AddedAmountInheldIncreasingProcessDet.DataMember = "AddedAmount";
        this.AddedAmountInheldIncreasingProcessDet.DisplayIndex = 2;
        this.AddedAmountInheldIncreasingProcessDet.HeaderText = "Eklenecek Miktar";
        this.AddedAmountInheldIncreasingProcessDet.Name = "AddedAmountInheldIncreasingProcessDet";
        this.AddedAmountInheldIncreasingProcessDet.Width = 80;

        this.labelExaminationReportNo = new TTVisual.TTLabel();
        this.labelExaminationReportNo.Text = "Muayene Komisyonu Rapor Sayısı";
        this.labelExaminationReportNo.Name = "labelExaminationReportNo";
        this.labelExaminationReportNo.TabIndex = 7;

        this.ExaminationReportNo = new TTVisual.TTTextBox();
        this.ExaminationReportNo.Name = "ExaminationReportNo";
        this.ExaminationReportNo.ReadOnly = true;
        this.ExaminationReportNo.TabIndex = 6;

        this.labelExaminationReportDate = new TTVisual.TTLabel();
        this.labelExaminationReportDate.Text = "Muayene Komisyonu Rapor Tarihi";
        this.labelExaminationReportDate.Name = "labelExaminationReportDate";
        this.labelExaminationReportDate.TabIndex = 5;

        this.ExaminationReportDate = new TTVisual.TTDateTimePicker();
        this.ExaminationReportDate.Format = DateTimePickerFormat.Short;
        this.ExaminationReportDate.Name = "ExaminationReportDate";
        this.ExaminationReportDate.ReadOnly = true;
        this.ExaminationReportDate.TabIndex = 4;

        this.labelBaseNumber = new TTVisual.TTLabel();
        this.labelBaseNumber.Text = "Dayanak Numarası";
        this.labelBaseNumber.Name = "labelBaseNumber";
        this.labelBaseNumber.TabIndex = 3;

        this.BaseNumber = new TTVisual.TTTextBox();
        this.BaseNumber.Name = "BaseNumber";
        this.BaseNumber.ReadOnly = true;
        this.BaseNumber.TabIndex = 2;

        this.labelBaseDateTime = new TTVisual.TTLabel();
        this.labelBaseDateTime.Text = "Dayanak Tarihi";
        this.labelBaseDateTime.Name = "labelBaseDateTime";
        this.labelBaseDateTime.TabIndex = 1;

        this.BaseDateTime = new TTVisual.TTDateTimePicker();
        this.BaseDateTime.Format = DateTimePickerFormat.Short;
        this.BaseDateTime.Name = "BaseDateTime";
        this.BaseDateTime.ReadOnly = true;
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

        this.InheldIncreasingProcessDetsColumns = [this.MaterialInheldIncreasingProcessDet, this.AmountInheldIncreasingProcessDet, this.AddedAmountInheldIncreasingProcessDet];
        this.Controls = [this.MaterialInheldIncreasingProcessDet, this.AmountInheldIncreasingProcessDet, this.AddedAmountInheldIncreasingProcessDet, this.labelExaminationReportNo, this.ExaminationReportNo, this.labelExaminationReportDate, this.ExaminationReportDate, this.labelBaseNumber, this.BaseNumber,
        this.labelBaseDateTime, this.BaseDateTime, this.labelPurchaseActionID, this.PurchaseActionID, this.labelStore, this.Store];

    }
}
