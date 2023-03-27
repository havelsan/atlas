//$1B9CCB71
import { Component, OnInit, NgZone } from '@angular/core';
import { SubStoreStockTransferComplatedFormViewModel } from './SubStoreStockTransferComplatedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseSubStoreStockTransferForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/XXXXXXici_Dagitim_Belgesi_Modulu/BaseSubStoreStockTransferForm";
import { SubStoreStockTransfer } from 'NebulaClient/Model/AtlasClientModel';

import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreStockTransferMat } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';



import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'SubStoreStockTransferComplatedForm',
    templateUrl: './SubStoreStockTransferComplatedForm.html',
    providers: [MessageService]
})
export class SubStoreStockTransferComplatedForm extends BaseSubStoreStockTransferForm implements OnInit {
    public StockActionSignDetailsColumns = [];
    public SubStoreStockTransferMaterialsColumns = [];
    public subStoreStockTransferComplatedFormViewModel: SubStoreStockTransferComplatedFormViewModel = new SubStoreStockTransferComplatedFormViewModel();
    public get _SubStoreStockTransfer(): SubStoreStockTransfer {
        return this._TTObject as SubStoreStockTransfer;
    }
    private SubStoreStockTransferComplatedForm_DocumentUrl: string = '/api/SubStoreStockTransferService/SubStoreStockTransferComplatedForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SubStoreStockTransferComplatedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    DocumentRecordLogs_CellValueChangedEmitted(data: any){}
    initDocumentRecordLogsNewRow(data: any){}
    onDocumentRecordLogsRowInserting(data: any){}
    onSelectionChangeDocumentRecordLogs(data: any){}
    onSelectionChange(data: any){}
    onRowInserting(data: any){}
    initNewRow(data: any){}
    onCellContentClicked(data: any){}
    SubStoreStockTransferMaterials_CellValueChangedEmitted(data: any){}
    popupVisible: false;
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreStockTransfer();
        this.subStoreStockTransferComplatedFormViewModel = new SubStoreStockTransferComplatedFormViewModel();
        this._ViewModel = this.subStoreStockTransferComplatedFormViewModel;
        this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer = this._TTObject as SubStoreStockTransfer;
        this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.DestinationStore = new Store();
        this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.Store = new Store();
        this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = new Array<SubStoreStockTransferMat>();
    }

    protected loadViewModel() {
        let that = this;

        that.subStoreStockTransferComplatedFormViewModel = this._ViewModel as SubStoreStockTransferComplatedFormViewModel;
        that._TTObject = this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer;
        if (this.subStoreStockTransferComplatedFormViewModel == null)
            this.subStoreStockTransferComplatedFormViewModel = new SubStoreStockTransferComplatedFormViewModel();
        if (this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer == null)
            this.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer = new SubStoreStockTransfer();
        let destinationStoreObjectID = that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.subStoreStockTransferComplatedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.DestinationStore = destinationStore;
            }
        }
        let storeObjectID = that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.subStoreStockTransferComplatedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.Store = store;
            }
        }
        that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.StockActionSignDetails = that.subStoreStockTransferComplatedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.subStoreStockTransferComplatedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.subStoreStockTransferComplatedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.subStoreStockTransferComplatedFormViewModel._SubStoreStockTransfer.SubStoreStockTransferMaterials = that.subStoreStockTransferComplatedFormViewModel.SubStoreStockTransferMaterialsGridList;
        for (let detailItem of that.subStoreStockTransferComplatedFormViewModel.SubStoreStockTransferMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.subStoreStockTransferComplatedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.subStoreStockTransferComplatedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.subStoreStockTransferComplatedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.subStoreStockTransferComplatedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(SubStoreStockTransferComplatedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        if (this._SubStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._SubStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21673", "Servisler Arası Transfer Belgesi ( Tamamlandı )");

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.ActionDate != event) {
                this._SubStoreStockTransfer.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.Description != event) {
                this._SubStoreStockTransfer.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.DestinationStore != event) {
                this._SubStoreStockTransfer.DestinationStore = event;
            }
        }
        //this.DestinationStore_SelectedObjectChanged();
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.MKYS_TeslimAlan != event) {
                this._SubStoreStockTransfer.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.MKYS_TeslimEden != event) {
                this._SubStoreStockTransfer.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.StockActionID != event) {
                this._SubStoreStockTransfer.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._SubStoreStockTransfer != null && this._SubStoreStockTransfer.Store != event) {
                this._SubStoreStockTransfer.Store = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 7;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 6;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 5;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "SubStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 4;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 2;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 1;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
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

        this.SubStoreStockTransferMaterials = new TTVisual.TTGrid();
        this.SubStoreStockTransferMaterials.Name = "SubStoreStockTransferMaterials";
        this.SubStoreStockTransferMaterials.TabIndex = 8;
        this.SubStoreStockTransferMaterials.Height = 350;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 100;

        this.MaterialSubStoreStockTransferMat = new TTVisual.TTListBoxColumn();
        this.MaterialSubStoreStockTransferMat.ListDefName = "MaterialListDefinition";
        this.MaterialSubStoreStockTransferMat.DataMember = "Material";
     this.MaterialSubStoreStockTransferMat.AutoCompleteDialogHeight = '60%';
        this.MaterialSubStoreStockTransferMat.AutoCompleteDialogWidth = '90%';
        this.MaterialSubStoreStockTransferMat.DisplayIndex = 1;
        this.MaterialSubStoreStockTransferMat.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialSubStoreStockTransferMat.Name = "MaterialSubStoreStockTransferMat";
        this.MaterialSubStoreStockTransferMat.Width = 400;

        this.MaterialBarcode = new TTVisual.TTTextBoxColumn();
        this.MaterialBarcode.DataMember = "Material.Barcode";
        this.MaterialBarcode.DisplayIndex = 2;
        this.MaterialBarcode.HeaderText = "Barkod";
        this.MaterialBarcode.Name = "MaterialBarcode";
        this.MaterialBarcode.ReadOnly = true;
        this.MaterialBarcode.Width = 120;

        this.Distrubitontype = new TTVisual.TTTextBoxColumn();
        this.Distrubitontype.DataMember = "Material.DistributionTypeName";
        this.Distrubitontype.DisplayIndex = 3;
        this.Distrubitontype.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.Distrubitontype.Name = "Distrubitontype";
        this.Distrubitontype.ReadOnly = true;
        this.Distrubitontype.Width = 140;

        this.RequestAmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSubStoreStockTransferMat.DataMember = "RequestAmount";
        this.RequestAmountSubStoreStockTransferMat.Required = true;
        this.RequestAmountSubStoreStockTransferMat.DisplayIndex = 4;
        this.RequestAmountSubStoreStockTransferMat.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmountSubStoreStockTransferMat.Name = "RequestAmountSubStoreStockTransferMat";
        this.RequestAmountSubStoreStockTransferMat.Width = 120;
        this.RequestAmountSubStoreStockTransferMat.IsNumeric = true;

        this.AmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreStockTransferMat.DataMember = "Amount";
        this.AmountSubStoreStockTransferMat.DisplayIndex = 5;
        this.AmountSubStoreStockTransferMat.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreStockTransferMat.Name = "AmountSubStoreStockTransferMat";
        this.AmountSubStoreStockTransferMat.Width = 120;
        this.AmountSubStoreStockTransferMat.IsNumeric = true;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 120;

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

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 7;

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

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.SubStoreStockTransferMaterialsColumns = [this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat, this.StockLevelType];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.SubStoreStockTransferMaterials];
        this.Controls = [this.Description, this.StockActionID, this.labelDestinationStore, this.DestinationStore, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.SubStoreStockTransferMaterials, this.Detail, this.MaterialSubStoreStockTransferMat, this.MaterialBarcode, this.Distrubitontype, this.RequestAmountSubStoreStockTransferMat, this.AmountSubStoreStockTransferMat, this.StockLevelType, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];


    }


}
