//$78BC1124
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseCostActionFormViewModel } from './BaseCostActionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CostAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { CostActionMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


@Component({
    selector: 'BaseCostActionForm',
    templateUrl: './BaseCostActionForm.html',
    providers: [MessageService]
})
export class BaseCostActionForm extends StockActionBaseForm implements OnInit {
    AvarageUnitePriceCostActionMaterial: TTVisual.ITTTextBoxColumn;
    CostActionMaterials: TTVisual.ITTGrid;
    Description: TTVisual.ITTTextBox;
    DifAvarageUnitePriceCostActionMaterial: TTVisual.ITTTextBoxColumn;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MaterialCostActionMaterial: TTVisual.ITTListBoxColumn;
    MaterialPriceCostActionMaterial: TTVisual.ITTTextBoxColumn;
    PreviousMonthPriceCostActionMaterial: TTVisual.ITTTextBoxColumn;
    PreviousMothInheldCostActionMaterial: TTVisual.ITTTextBoxColumn;
    ProfitAndLossCostActionMaterial: TTVisual.ITTTextBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    Store: TTVisual.ITTObjectListBox;
    TotalAmountCostActionMaterial: TTVisual.ITTTextBoxColumn;
    TotalOutAmuntCostActionMaterial: TTVisual.ITTTextBoxColumn;
    TotalPrice: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    TransferredAmount: TTVisual.ITTTextBoxColumn;
    TTDatetime: TTVisual.ITTLabel;
    ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    ttdatetimepicker2: TTVisual.ITTDateTimePicker;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttlabel2: TTVisual.ITTLabel;
    public CostActionMaterialsColumns = [];
    public baseCostActionFormViewModel: BaseCostActionFormViewModel = new BaseCostActionFormViewModel();
    public get _CostAction(): CostAction {
        return this._TTObject as CostAction;
    }
    private BaseCostActionForm_DocumentUrl: string = '/api/CostActionService/BaseCostActionForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseCostActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CostAction();
        this.baseCostActionFormViewModel = new BaseCostActionFormViewModel();
        this._ViewModel = this.baseCostActionFormViewModel;
        this.baseCostActionFormViewModel._CostAction = this._TTObject as CostAction;
        this.baseCostActionFormViewModel._CostAction.CostActionMaterials = new Array<CostActionMaterial>();
        this.baseCostActionFormViewModel._CostAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.baseCostActionFormViewModel = this._ViewModel as BaseCostActionFormViewModel;
        that._TTObject = this.baseCostActionFormViewModel._CostAction;
        if (this.baseCostActionFormViewModel == null)
            this.baseCostActionFormViewModel = new BaseCostActionFormViewModel();
        if (this.baseCostActionFormViewModel._CostAction == null)
            this.baseCostActionFormViewModel._CostAction = new CostAction();
        that.baseCostActionFormViewModel._CostAction.CostActionMaterials = that.baseCostActionFormViewModel.CostActionMaterialsGridList;
        for (let detailItem of that.baseCostActionFormViewModel.CostActionMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseCostActionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
            }
        }
        let storeObjectID = that.baseCostActionFormViewModel._CostAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseCostActionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.baseCostActionFormViewModel._CostAction.Store = store;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseCostActionFormViewModel);
  
    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.Description != event) {
                this._CostAction.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.StockActionID != event) {
                this._CostAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.Store != event) {
                this._CostAction.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.TransactionDate != event) {
                this._CostAction.TransactionDate = event;
            }
        }
    }

    public onttdatetimepicker1Changed(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.StartDate != event) {
                this._CostAction.StartDate = event;
            }
        }
    }

    public onttdatetimepicker2Changed(event): void {
        if (event != null) {
            if (this._CostAction != null && this._CostAction.EndDate != event) {
                this._CostAction.EndDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.ttdatetimepicker1, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.ttdatetimepicker2, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 15;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 14;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 13;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 12;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = i18n("M10469", "Açıklama");
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 11;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 9;

        this.TTDatetime = new TTVisual.TTLabel();
        this.TTDatetime.Text = i18n("M11637", "Başlangıç Tarihi");
        this.TTDatetime.Name = "TTDatetime";
        this.TTDatetime.TabIndex = 8;

        this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker2.BackColor = "#F0F0F0";
        this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker2.Enabled = false;
        this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        this.ttdatetimepicker2.TabIndex = 7;

        this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        this.ttdatetimepicker1.BackColor = "#F0F0F0";
        this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        this.ttdatetimepicker1.Enabled = false;
        this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        this.ttdatetimepicker1.TabIndex = 6;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M18564", "Malzeme Detayları");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 5;

        this.CostActionMaterials = new TTVisual.TTGrid();
        this.CostActionMaterials.Name = "CostActionMaterials";
        this.CostActionMaterials.TabIndex = 16;

        this.MaterialCostActionMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialCostActionMaterial.ListDefName = "MaterialListDefinition";
        this.MaterialCostActionMaterial.DataMember = "Material";
        this.MaterialCostActionMaterial.DisplayIndex = 0;
        this.MaterialCostActionMaterial.HeaderText = i18n("M18545", "Malzeme");
        this.MaterialCostActionMaterial.Name = "MaterialCostActionMaterial";
        this.MaterialCostActionMaterial.Width = 300;

        this.PreviousMothInheldCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.PreviousMothInheldCostActionMaterial.DataMember = "PreviousMothInheld";
        this.PreviousMothInheldCostActionMaterial.DisplayIndex = 1;
        this.PreviousMothInheldCostActionMaterial.HeaderText = "Bir Önceki Aydan Devreden Miktar";
        this.PreviousMothInheldCostActionMaterial.Name = "PreviousMothInheldCostActionMaterial";
        this.PreviousMothInheldCostActionMaterial.Width = 80;

        this.PreviousMonthPriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.PreviousMonthPriceCostActionMaterial.DataMember = "PreviousMonthPrice";
        this.PreviousMonthPriceCostActionMaterial.DisplayIndex = 2;
        this.PreviousMonthPriceCostActionMaterial.HeaderText = i18n("M11837", "Bir Önceki Aydan Devreden Toplam Maliyet");
        this.PreviousMonthPriceCostActionMaterial.Name = "PreviousMonthPriceCostActionMaterial";
        this.PreviousMonthPriceCostActionMaterial.Width = 80;

        this.TotalAmountCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.TotalAmountCostActionMaterial.DataMember = "TotalAmount";
        this.TotalAmountCostActionMaterial.DisplayIndex = 3;
        this.TotalAmountCostActionMaterial.HeaderText = i18n("M23499", "Toplam Giriş");
        this.TotalAmountCostActionMaterial.Name = "TotalAmountCostActionMaterial";
        this.TotalAmountCostActionMaterial.Width = 80;

        this.TotalOutAmuntCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.TotalOutAmuntCostActionMaterial.DataMember = "TotalOutAmunt";
        this.TotalOutAmuntCostActionMaterial.DisplayIndex = 4;
        this.TotalOutAmuntCostActionMaterial.HeaderText = i18n("M23489", "Toplam Çıkış");
        this.TotalOutAmuntCostActionMaterial.Name = "TotalOutAmuntCostActionMaterial";
        this.TotalOutAmuntCostActionMaterial.Width = 80;

        this.TotalPrice = new TTVisual.TTTextBoxColumn();
        this.TotalPrice.DataMember = "TotalPrice";
        this.TotalPrice.DisplayIndex = 5;
        this.TotalPrice.HeaderText = i18n("M23500", "Toplam Giriş Fiyatı");
        this.TotalPrice.Name = "TotalPrice";
        this.TotalPrice.Width = 100;

        this.AvarageUnitePriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.AvarageUnitePriceCostActionMaterial.DataMember = "AvarageUnitePrice";
        this.AvarageUnitePriceCostActionMaterial.DisplayIndex = 6;
        this.AvarageUnitePriceCostActionMaterial.HeaderText = i18n("M11867", "Birim Maliyet");
        this.AvarageUnitePriceCostActionMaterial.Name = "AvarageUnitePriceCostActionMaterial";
        this.AvarageUnitePriceCostActionMaterial.Width = 80;

        this.MaterialPriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.MaterialPriceCostActionMaterial.DataMember = "MaterialPrice";
        this.MaterialPriceCostActionMaterial.DisplayIndex = 7;
        this.MaterialPriceCostActionMaterial.HeaderText = i18n("M21392", "Satış Fiyatı");
        this.MaterialPriceCostActionMaterial.Name = "MaterialPriceCostActionMaterial";
        this.MaterialPriceCostActionMaterial.Width = 80;

        this.ProfitAndLossCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.ProfitAndLossCostActionMaterial.DataMember = "ProfitAndLoss";
        this.ProfitAndLossCostActionMaterial.DisplayIndex = 8;
        this.ProfitAndLossCostActionMaterial.HeaderText = i18n("M17260", "Kar / Zarar");
        this.ProfitAndLossCostActionMaterial.Name = "ProfitAndLossCostActionMaterial";
        this.ProfitAndLossCostActionMaterial.Width = 80;

        this.DifAvarageUnitePriceCostActionMaterial = new TTVisual.TTTextBoxColumn();
        this.DifAvarageUnitePriceCostActionMaterial.DataMember = "DifAvarageUnitePrice";
        this.DifAvarageUnitePriceCostActionMaterial.DisplayIndex = 9;
        this.DifAvarageUnitePriceCostActionMaterial.HeaderText = i18n("M11842", "Bir Sonraki Aya Devreden Toplam Maliyet");
        this.DifAvarageUnitePriceCostActionMaterial.Name = "DifAvarageUnitePriceCostActionMaterial";
        this.DifAvarageUnitePriceCostActionMaterial.Width = 80;

        this.TransferredAmount = new TTVisual.TTTextBoxColumn();
        this.TransferredAmount.DataMember = "TransferredAmount";
        this.TransferredAmount.DisplayIndex = 10;
        this.TransferredAmount.HeaderText = "Bir Sonraki Aya Devreden Miktar";
        this.TransferredAmount.Name = "TransferredAmount";
        this.TransferredAmount.Width = 100;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M10896", "Ana Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 1;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 0;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M11939", "Bitiş Tarihi");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 8;

        this.CostActionMaterialsColumns = [this.MaterialCostActionMaterial, this.PreviousMothInheldCostActionMaterial, this.PreviousMonthPriceCostActionMaterial, this.TotalAmountCostActionMaterial, this.TotalOutAmuntCostActionMaterial, this.TotalPrice, this.AvarageUnitePriceCostActionMaterial, this.MaterialPriceCostActionMaterial, this.ProfitAndLossCostActionMaterial, this.DifAvarageUnitePriceCostActionMaterial, this.TransferredAmount];
        this.ttgroupbox2.Controls = [this.Description];
        this.ttgroupbox1.Controls = [this.CostActionMaterials];
        this.Controls = [this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.StockActionID, this.ttgroupbox2, this.Description, this.TTDatetime, this.ttdatetimepicker2, this.ttdatetimepicker1, this.ttgroupbox1, this.CostActionMaterials, this.MaterialCostActionMaterial, this.PreviousMothInheldCostActionMaterial, this.PreviousMonthPriceCostActionMaterial, this.TotalAmountCostActionMaterial, this.TotalOutAmuntCostActionMaterial, this.TotalPrice, this.AvarageUnitePriceCostActionMaterial, this.MaterialPriceCostActionMaterial, this.ProfitAndLossCostActionMaterial, this.DifAvarageUnitePriceCostActionMaterial, this.TransferredAmount, this.labelStore, this.Store, this.ttlabel2];

    }


}
