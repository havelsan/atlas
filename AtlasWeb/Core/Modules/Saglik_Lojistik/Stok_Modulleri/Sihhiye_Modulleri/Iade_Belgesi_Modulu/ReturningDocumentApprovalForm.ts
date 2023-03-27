//$78E20B9A
import { Component, OnInit, NgZone } from '@angular/core';
import { ReturningDocumentApprovalFormViewModel } from './ReturningDocumentApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseReturningDocumentForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Iade_Belgesi_Modulu/BaseReturningDocumentForm";
import { ReturningDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'ReturningDocumentApprovalForm',
    templateUrl: './ReturningDocumentApprovalForm.html',
    providers: [MessageService]
})
export class ReturningDocumentApprovalForm extends BaseReturningDocumentForm implements OnInit {
    // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public returningDocumentApprovalFormViewModel: ReturningDocumentApprovalFormViewModel = new ReturningDocumentApprovalFormViewModel();
    public get _ReturningDocument(): ReturningDocument {
        return this._TTObject as ReturningDocument;
    }
    private ReturningDocumentApprovalForm_DocumentUrl: string = '/api/ReturningDocumentService/ReturningDocumentApprovalForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ReturningDocumentApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public StockActionOutDetailsColumns = [
        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M12449", "Dağıtım Şekli"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M22360", "Stok Miktarı"),
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M16068", "İade Miktarı "),
            dataField: 'RequireAmount',
            dataType: 'number',
            format: '#',
            editorOptions: {
                onKeyPress: function (e) {
                    let event = e.event,
                        str = String.fromCharCode(event.keyCode);
                    if (!/[0-9]/.test(str))
                        event.preventDefault();
                }
            },
            allowEditing: this.ReadOnly != true,
            //width: 'auto'
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //width: 'auto'
        },
    ];

    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ReturningDocument.ObjectID.toString());
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
    protected async PreScript() {
        await super.PreScript();
        for (let returningDocumentMaterial of this.returningDocumentApprovalFormViewModel._ReturningDocument.ReturningDocumentMaterials) {
            if (returningDocumentMaterial.Amount === null || returningDocumentMaterial.Amount === 0 || returningDocumentMaterial.Amount !== returningDocumentMaterial.RequireAmount)
                returningDocumentMaterial.Amount = returningDocumentMaterial.RequireAmount;
        }
        if (this._ReturningDocument.CurrentStateDefID === ReturningDocument.ReturningDocumentStates.Approval) {
            if (this._ReturningDocument.ReturnDepStoreObjectID !== null) {
                this.DropStateButton(ReturningDocument.ReturningDocumentStates.New);
                this.DropStateButton(ReturningDocument.ReturningDocumentStates.Cancelled);
            }
        }
        /*if (this._ReturningDocument.StockActionSignDetails.length === 0) {
            let stockActionSignDetail: StockActionSignDetail = this._ReturningDocument.StockActionSignDetails.AddNew();
            stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
            if (this._ReturningDocument.Store instanceof MainStoreDefinition)
                stockActionSignDetail.SignUser = (<MainStoreDefinition>this._ReturningDocument.Store).GoodsAccountant;
            stockActionSignDetail = this._ReturningDocument.StockActionSignDetails.AddNew();
            stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
            if (this._ReturningDocument.DestinationStore instanceof SubStoreDefinition)
                stockActionSignDetail.SignUser = (<SubStoreDefinition>this._ReturningDocument.DestinationStore).StoreResponsible;
        }
        //this._ReturningDocument.SendMYKSProperties();*/
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReturningDocument();
        this.returningDocumentApprovalFormViewModel = new ReturningDocumentApprovalFormViewModel();
        this._ViewModel = this.returningDocumentApprovalFormViewModel;
        this.returningDocumentApprovalFormViewModel._ReturningDocument = this._TTObject as ReturningDocument;
        this.returningDocumentApprovalFormViewModel._ReturningDocument.Store = new Store();
        this.returningDocumentApprovalFormViewModel._ReturningDocument.DestinationStore = new Store();
        this.returningDocumentApprovalFormViewModel._ReturningDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.returningDocumentApprovalFormViewModel._ReturningDocument.ReturningDocumentMaterials = new Array<ReturningDocumentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.returningDocumentApprovalFormViewModel = this._ViewModel as ReturningDocumentApprovalFormViewModel;
        that._TTObject = this.returningDocumentApprovalFormViewModel._ReturningDocument;
        if (this.returningDocumentApprovalFormViewModel == null)
            this.returningDocumentApprovalFormViewModel = new ReturningDocumentApprovalFormViewModel();
        if (this.returningDocumentApprovalFormViewModel._ReturningDocument == null)
            this.returningDocumentApprovalFormViewModel._ReturningDocument = new ReturningDocument();
        let storeObjectID = that.returningDocumentApprovalFormViewModel._ReturningDocument["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.returningDocumentApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.returningDocumentApprovalFormViewModel._ReturningDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.returningDocumentApprovalFormViewModel._ReturningDocument["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.returningDocumentApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.returningDocumentApprovalFormViewModel._ReturningDocument.DestinationStore = destinationStore;
            }
        }
        that.returningDocumentApprovalFormViewModel._ReturningDocument.StockActionSignDetails = that.returningDocumentApprovalFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.returningDocumentApprovalFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.returningDocumentApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.returningDocumentApprovalFormViewModel._ReturningDocument.ReturningDocumentMaterials = that.returningDocumentApprovalFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.returningDocumentApprovalFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.returningDocumentApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.returningDocumentApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.returningDocumentApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.returningDocumentApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ReturningDocumentApprovalFormViewModel);
        if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M16051", " İade Belgesi ( Onay )");

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Description != event) {
                this._ReturningDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.DestinationStore != event) {
                this._ReturningDocument.DestinationStore = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_EMalzemeGrup != event) {
                this._ReturningDocument.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimAlan != event) {
                this._ReturningDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._ReturningDocument != null && this._ReturningDocument.MKYS_TeslimEden != event) {
                this._ReturningDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.StockActionID != event) {
                this._ReturningDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.Store != event) {
                this._ReturningDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ReturningDocument != null && this._ReturningDocument.TransactionDate != event) {
                this._ReturningDocument.TransactionDate = event;
            }
        }
    }




    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.StockActionOutDetails_CellValueChanged(data, rowIndex, columnIndex);
    }


    //<this.StockActionOutDetail gridde kullanılıyordu
    //onCellContentClicked(data: any) {
    //}
    //StockActionOutDetails_CellValueChangedEmitted(data: any) {
    //    if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
    //        this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
    //    }
    //}
    //async initNewRow(data: any) {
    //}
    //async onRowInserting(data: ReturningDocumentMaterial) {
    //}
    //onSelectionChange(data: any) {

    //}

    //this.StockActionOutDetail gridde kullanılıyordu >


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 37;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 36;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 34;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 35;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 33;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 32;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 31;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = "MainStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 30;

        this.cmdHEKReport = new TTVisual.TTButton();
        this.cmdHEKReport.Text = i18n("M15614", "HEK Raporu Bas");
        this.cmdHEKReport.Name = "cmdHEKReport";
        this.cmdHEKReport.TabIndex = 29;
        this.cmdHEKReport.Visible = false;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = "#DCDCDC";
        this.labelTransactionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTransactionDate.ForeColor = "#000000";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 7;

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
        this.labelStockActionID.TabIndex = 3;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Height = 350;

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

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 4;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";
        //<this.StockActionOutDetailsColumns dxgrid e taşındı
        //this.StockActionOutDetails = new TTVisual.TTGrid();
        //this.StockActionOutDetails.Required = true;
        //this.StockActionOutDetails.BackColor = "#FFE3C6";
        //this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.StockActionOutDetails.Name = "StockActionOutDetails";
        //this.StockActionOutDetails.TabIndex = 0;
        //this.StockActionOutDetails.Height = 350;

        //this.Detail = new TTVisual.TTButtonColumn();
        //this.Detail.Text = i18n("M12671", "Detay");
        //this.Detail.UseColumnTextForButtonValue = true;
        //this.Detail.DisplayIndex = 0;
        //this.Detail.HeaderText = "";
        //this.Detail.Name = "Detail";
        //this.Detail.ToolTipText = i18n("M12671", "Detay");
        //this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '90%';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = "Material";
        this.Material.Width = 500;
        this.Material.ReadOnly = this.ReadOnly;

        //this.Barcode = new TTVisual.TTTextBoxColumn();
        //this.Barcode.DataMember = "Material.Barcode";
        //this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //this.Barcode.DisplayIndex = 2;
        //this.Barcode.HeaderText = "Barkod";
        //this.Barcode.Name = "Barcode";
        //this.Barcode.ReadOnly = true;
        //this.Barcode.Width = 120;

        //this.DistributionType = new TTVisual.TTTextBoxColumn();
        //this.DistributionType.DataMember = "Material.DistributionTypeName";
        //this.DistributionType.DisplayIndex = 3;
        //this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        //this.DistributionType.Name = "DistributionType";
        //this.DistributionType.ReadOnly = true;
        //this.DistributionType.Width = 120;

        //this.Existing = new TTVisual.TTTextBoxColumn();
        //this.Existing.DataMember = "StoreStock";
        //this.Existing.Format = "N2";
        //this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Existing.DisplayIndex = 4;
        //this.Existing.HeaderText = i18n("M22360", "Stok Miktarı");
        //this.Existing.Name = "Existing";
        //this.Existing.ReadOnly = true;
        //this.Existing.Width = 120;

        //this.RequireAmount = new TTVisual.TTTextBoxColumn();
        //this.RequireAmount.DataMember = "RequireAmount";
        //this.RequireAmount.Required = true;
        //this.RequireAmount.Format = "N2";
        //this.RequireAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.RequireAmount.DisplayIndex = 5;
        //this.RequireAmount.HeaderText = i18n("M16068", "İade Miktarı");
        //this.RequireAmount.Name = "RequireAmount";
        //this.RequireAmount.Width = 120;
        //this.RequireAmount.IsNumeric = true;

        //this.Amount = new TTVisual.TTTextBoxColumn();
        //this.Amount.DataMember = "Amount";
        //this.Amount.Format = "N2";
        //this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        //this.Amount.DisplayIndex = 6;
        //this.Amount.HeaderText = i18n("M10707", "Alınan Miktar");
        //this.Amount.Name = "Amount";
        //this.Amount.Visible = false;
        //this.Amount.Width = 120;
        //this.Amount.IsNumeric = true;

        //this.StockLevelType = new TTVisual.TTListBoxColumn();
        //this.StockLevelType.ListDefName = "StockLevelTypeList";
        //this.StockLevelType.DataMember = "StockLevelType";
        //this.StockLevelType.DisplayIndex = 7;
        //this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        //this.StockLevelType.Name = "StockLevelType";
        //this.StockLevelType.ReadOnly = true;
        //this.StockLevelType.Width = 120;
        //this.StockActionOutDetailsColumns>

        this.ChooseProductsFromTheTree = new TTVisual.TTButton();
        this.ChooseProductsFromTheTree.Text = i18n("M23971", "Ürün Ağacından Seç");
        this.ChooseProductsFromTheTree.Name = "ChooseProductsFromTheTree";
        this.ChooseProductsFromTheTree.TabIndex = 27;
        this.ChooseProductsFromTheTree.Visible = false;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 17;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 16;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 16;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        //this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails, this.ChooseProductsFromTheTree];
        this.Controls = [this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description, this.StockActionID, this.labelMKYS_TeslimAlan, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.cmdHEKReport, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.StockActionOutDetails, this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.RequireAmount, this.Amount, this.StockLevelType, this.ChooseProductsFromTheTree, this.MKYS_EMalzemeGrup, this.labelMKYS_EMalzemeGrup, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
