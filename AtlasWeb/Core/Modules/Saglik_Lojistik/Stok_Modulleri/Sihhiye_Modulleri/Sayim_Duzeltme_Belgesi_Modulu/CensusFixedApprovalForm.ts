//$E852DCC6
import { Component, OnInit, NgZone } from '@angular/core';
import { CensusFixedApprovalFormViewModel } from './CensusFixedApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseCensusFixedForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Sayim_Duzeltme_Belgesi_Modulu/BaseCensusFixedForm";
import { CensusFixed } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialIn } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'CensusFixedApprovalForm',
    templateUrl: './CensusFixedApprovalForm.html',
    providers: [MessageService]
})
export class CensusFixedApprovalForm extends BaseCensusFixedForm implements OnInit {
    public StockActionInDetailsColumns = [];
    public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public censusFixedApprovalFormViewModel: CensusFixedApprovalFormViewModel = new CensusFixedApprovalFormViewModel();
    public get _CensusFixed(): CensusFixed {
        return this._TTObject as CensusFixed;
    }
    private CensusFixedApprovalForm_DocumentUrl: string = '/api/CensusFixedService/CensusFixedApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.CensusFixedApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
  protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
      if(transDef != null){
        super.AfterContextSavedScript(transDef);
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._CensusFixed.ObjectID.toString());
        for (let document of documentRecordLogs) {
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
            }
			if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
            }
        }
    }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CensusFixed();
        this.censusFixedApprovalFormViewModel = new CensusFixedApprovalFormViewModel();
        this._ViewModel = this.censusFixedApprovalFormViewModel;
        this.censusFixedApprovalFormViewModel._CensusFixed = this._TTObject as CensusFixed;
        this.censusFixedApprovalFormViewModel._CensusFixed.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.censusFixedApprovalFormViewModel._CensusFixed.Store = new Store();
        this.censusFixedApprovalFormViewModel._CensusFixed.CensusFixedInMaterials = new Array<CensusFixedMaterialIn>();
        this.censusFixedApprovalFormViewModel._CensusFixed.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.censusFixedApprovalFormViewModel._CensusFixed.CensusFixedOutMaterials = new Array<CensusFixedMaterialOut>();
    }

    protected loadViewModel() {
        let that = this;

        that.censusFixedApprovalFormViewModel = this._ViewModel as CensusFixedApprovalFormViewModel;
        that._TTObject = this.censusFixedApprovalFormViewModel._CensusFixed;
        if (this.censusFixedApprovalFormViewModel == null)
            this.censusFixedApprovalFormViewModel = new CensusFixedApprovalFormViewModel();
        if (this.censusFixedApprovalFormViewModel._CensusFixed == null)
            this.censusFixedApprovalFormViewModel._CensusFixed = new CensusFixed();
        let budgetTypeDefinitionObjectID = that.censusFixedApprovalFormViewModel._CensusFixed["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.censusFixedApprovalFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
             if (budgetTypeDefinition) {
                that.censusFixedApprovalFormViewModel._CensusFixed.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.censusFixedApprovalFormViewModel._CensusFixed["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.censusFixedApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.censusFixedApprovalFormViewModel._CensusFixed.Store = store;
            }
        }
        that.censusFixedApprovalFormViewModel._CensusFixed.CensusFixedInMaterials = that.censusFixedApprovalFormViewModel.StockActionInDetailsGridList;
        for (let detailItem of that.censusFixedApprovalFormViewModel.StockActionInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.censusFixedApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.censusFixedApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.censusFixedApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.censusFixedApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.censusFixedApprovalFormViewModel._CensusFixed.StockActionSignDetails = that.censusFixedApprovalFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.censusFixedApprovalFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.censusFixedApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.censusFixedApprovalFormViewModel._CensusFixed.CensusFixedOutMaterials = that.censusFixedApprovalFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.censusFixedApprovalFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.censusFixedApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.censusFixedApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.censusFixedApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.censusFixedApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(CensusFixedApprovalFormViewModel);
        if (this._CensusFixed.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._CensusFixed.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21413", "Sayım Düzeltme Belgesi ( Onay )");

    }


    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.BudgetTypeDefinition != event) {
                this._CensusFixed.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.Description != event) {
                this._CensusFixed.Description = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.MKYS_EMalzemeGrup != event) {
                this._CensusFixed.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._CensusFixed.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._CensusFixed != null && this._CensusFixed.MKYS_TeslimAlan != event) {
                this._CensusFixed.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._CensusFixed.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._CensusFixed != null && this._CensusFixed.MKYS_TeslimEden != event) {
                this._CensusFixed.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.StockActionID != event) {
                this._CensusFixed.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.Store != event) {
                this._CensusFixed.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.TransactionDate != event) {
                this._CensusFixed.TransactionDate = event;
            }
        }
    }



    StockActionInDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionInDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionInDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChangeInDetail(data: any) {

    }
    public async StockActionInDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.StockActionInDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserttingInDetail(data: CensusFixedMaterialIn) {
    }

    onCellContentClickedInDetail(data: any) {
    }

    async initNewRowInDetail(data: any) {
    }


    StockActionOutDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }
    onSelectionChangeOutDetail(data: any) {

    }
    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.StockActionOutDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserttingOutDetail(data: CensusFixedMaterialOut) {
    }

    onCellContentClickedOutDetail(data: any) {
    }

    async initNewRowOutDetail(data: any) {
    }
    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 141;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 140;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 114;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 113;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 112;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 111;

        this.InMaterialsGroupBox = new TTVisual.TTGroupBox();
        this.InMaterialsGroupBox.Text = i18n("M11114", "Arttırılanlar");
        this.InMaterialsGroupBox.Name = "InMaterialsGroupBox";
        this.InMaterialsGroupBox.TabIndex = 110;

        this.StockActionInDetails = new TTVisual.TTGrid();
        this.StockActionInDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionInDetails.Name = "StockActionInDetails";
        this.StockActionInDetails.TabIndex = 0;
        this.StockActionInDetails.Height = 350;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = "60%";
        this.Material.AutoCompleteDialogWidth = "50%";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.Material.Name = "Material";
        this.Material.Width = 300;

        this.BarcodeA = new TTVisual.TTTextBoxColumn();
        this.BarcodeA.DataMember = "Material.Barcode";
        this.BarcodeA.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.BarcodeA.DisplayIndex = 2;
        this.BarcodeA.HeaderText = "Barkod";
        this.BarcodeA.Name = "BarcodeA";
        this.BarcodeA.ReadOnly = true;
        this.BarcodeA.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 100;

        this.OrderSequenceNumber = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumber.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumber.DisplayIndex = 5;
        this.OrderSequenceNumber.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumber.Name = "OrderSequenceNumber";
        this.OrderSequenceNumber.Width = 100;

        this.CardAmount = new TTVisual.TTTextBoxColumn();
        this.CardAmount.DataMember = "CardAmount";
        this.CardAmount.Format = "N2";
        this.CardAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmount.DisplayIndex = 6;
        this.CardAmount.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmount.Name = "CardAmount";
        this.CardAmount.Width = 125;
        this.CardAmount.Visible = false;
        this.CardAmount.IsNumeric = true;

        this.CensusAmount = new TTVisual.TTTextBoxColumn();
        this.CensusAmount.DataMember = "CensusAmount";
        this.CensusAmount.Format = "N2";
        this.CensusAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmount.DisplayIndex = 7;
        this.CensusAmount.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmount.Name = "CensusAmount";
        this.CensusAmount.Width = 100;
        this.CensusAmount.IsNumeric = true;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 8;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 75;
        this.Amount.IsNumeric = true;

        this.Unitprice = new TTVisual.TTTextBoxColumn();
        this.Unitprice.DataMember = "UnitPrice";
        this.Unitprice.Format = "N2";
        this.Unitprice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Unitprice.DisplayIndex = 9;
        this.Unitprice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.Unitprice.Name = "Unitprice";
        this.Unitprice.Width = 100;
        this.Unitprice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Format = "N2";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.LotNo.DisplayIndex = 10;
        this.LotNo.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 150;

        this.ExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDate.DataMember = "ExpirationDate";
        this.ExpirationDate.DisplayIndex = 11;
        this.ExpirationDate.HeaderText = "S.K.Tarihi";
        this.ExpirationDate.Name = "ExpirationDate";
        this.ExpirationDate.Width = 125;

        this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 12;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 109;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 76;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = "DescriptionTabpage";

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 138;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.CustomFormat = "";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = "#DCDCDC";
        this.labelStockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockActionID.ForeColor = "#000000";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 9;

        this.OutMaterialsGroupBox = new TTVisual.TTGroupBox();
        this.OutMaterialsGroupBox.Text = i18n("M13593", "Eksiltilenler");
        this.OutMaterialsGroupBox.Name = "OutMaterialsGroupBox";
        this.OutMaterialsGroupBox.TabIndex = 110;

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;

        this.DetailOut = new TTVisual.TTButtonColumn();
        this.DetailOut.Text = i18n("M12671", "Detay");
        this.DetailOut.UseColumnTextForButtonValue = true;
        this.DetailOut.DisplayIndex = 0;
        this.DetailOut.HeaderText = "";
        this.DetailOut.Name = "DetailOut";
        this.DetailOut.ToolTipText = i18n("M12671", "Detay");
        this.DetailOut.Width = 80;

        this.MaterialOut = new TTVisual.TTListBoxColumn();
        this.MaterialOut.AllowMultiSelect = true;
        this.MaterialOut.ListDefName = "MaterialListDefinition";
        this.MaterialOut.DataMember = "Material";
        this.MaterialOut.AutoCompleteDialogHeight = "60%";
        this.MaterialOut.AutoCompleteDialogWidth = "50%";
        this.MaterialOut.DisplayIndex = 1;
        this.MaterialOut.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.MaterialOut.Name = "MaterialOut";
        this.MaterialOut.Width = 300;

        this.BarcodeE = new TTVisual.TTTextBoxColumn();
        this.BarcodeE.DataMember = "Material.Barcode";
        this.BarcodeE.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.BarcodeE.DisplayIndex = 2;
        this.BarcodeE.HeaderText = "Barkod";
        this.BarcodeE.Name = "BarcodeE";
        this.BarcodeE.ReadOnly = true;
        this.BarcodeE.Width = 100;

        this.DistributionTypeOut = new TTVisual.TTTextBoxColumn();
        this.DistributionTypeOut.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeOut.DisplayIndex = 3;
        this.DistributionTypeOut.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeOut.Name = "DistributionTypeOut";
        this.DistributionTypeOut.ReadOnly = true;
        this.DistributionTypeOut.Width = 100;

        this.StoreStockOut = new TTVisual.TTTextBoxColumn();
        this.StoreStockOut.DataMember = "StoreStock";
        this.StoreStockOut.Format = "N2";
        this.StoreStockOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStockOut.DisplayIndex = 4;
        this.StoreStockOut.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStockOut.Name = "StoreStockOut";
        this.StoreStockOut.ReadOnly = true;
        this.StoreStockOut.Width = 100;

        this.OrderSequenceNumberOut = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumberOut.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumberOut.DisplayIndex = 5;
        this.OrderSequenceNumberOut.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumberOut.Name = "OrderSequenceNumberOut";
        this.OrderSequenceNumberOut.Width = 100;

        this.CardAmountOut = new TTVisual.TTTextBoxColumn();
        this.CardAmountOut.DataMember = "CardAmount";
        this.CardAmountOut.Format = "N2";
        this.CardAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmountOut.DisplayIndex = 6;
        this.CardAmountOut.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmountOut.Name = "CardAmountOut";
        this.CardAmountOut.Width = 125;

        this.CensusAmountOut = new TTVisual.TTTextBoxColumn();
        this.CensusAmountOut.DataMember = "CensusAmount";
        this.CensusAmountOut.Format = "N2";
        this.CensusAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmountOut.DisplayIndex = 7;
        this.CensusAmountOut.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmountOut.Name = "CensusAmountOut";
        this.CensusAmountOut.Width = 100;
        this.CensusAmountOut.Visible = false;
        this.CensusAmountOut.IsNumeric = true;

        this.AmountOut = new TTVisual.TTTextBoxColumn();
        this.AmountOut.DataMember = "Amount";
        this.AmountOut.Format = "N2";
        this.AmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountOut.DisplayIndex = 8;
        this.AmountOut.HeaderText = i18n("M19030", "Miktar");
        this.AmountOut.Name = "AmountOut";
        this.AmountOut.ReadOnly = true;
        this.AmountOut.Width = 75;
        this.AmountOut.IsNumeric = true;

        this.AproximateUnitPriceOut = new TTVisual.TTTextBoxColumn();
        this.AproximateUnitPriceOut.DataMember = "AproximateUnitPrice";
        this.AproximateUnitPriceOut.DisplayIndex = 9;
        this.AproximateUnitPriceOut.HeaderText = i18n("M11036", "Anlık Birim Fiyat");
        this.AproximateUnitPriceOut.Name = "AproximateUnitPriceOut";
        this.AproximateUnitPriceOut.ReadOnly = true;
        this.AproximateUnitPriceOut.Width = 100;
        this.AproximateUnitPriceOut.Visible = false;
        this.AproximateUnitPriceOut.IsNumeric = true;

        this.StockLevelTypeOut = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeOut.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeOut.DataMember = "StockLevelType";
        this.StockLevelTypeOut.DisplayIndex = 10;
        this.StockLevelTypeOut.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeOut.Name = "StockLevelTypeOut";
        this.StockLevelTypeOut.Width = 100;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 114;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.StockActionInDetailsColumns = [this.Detail, this.Material, this.BarcodeA, this.DistributionType, this.StoreStock, this.OrderSequenceNumber, this.CardAmount, this.CensusAmount, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.StockActionOutDetailsColumns = [this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut];
        this.InMaterialsGroupBox.Controls = [this.StockActionInDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.OutMaterialsGroupBox.Controls = [this.StockActionOutDetails];
        this.Controls = [this.labelBudgetTypeDefinition, this.BudgetTypeDefinition, this.Description, this.labelMKYS_EMalzemeGrup, this.MKYS_EMalzemeGrup, this.labelStore, this.Store, this.InMaterialsGroupBox, this.StockActionInDetails, this.Detail, this.Material, this.BarcodeA, this.DistributionType, this.StoreStock, this.OrderSequenceNumber, this.CardAmount, this.CensusAmount, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.StockActionID, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.OutMaterialsGroupBox, this.StockActionOutDetails, this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
