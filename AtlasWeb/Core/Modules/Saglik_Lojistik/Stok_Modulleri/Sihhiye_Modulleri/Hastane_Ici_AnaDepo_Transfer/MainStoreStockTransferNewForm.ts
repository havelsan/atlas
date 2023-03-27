//$B7BD8071
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { MainStoreStockTransferNewFormViewModel } from './MainStoreStockTransferNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseMainStoreStockTransferForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/XXXXXX_Ici_AnaDepo_Transfer/BaseMainStoreStockTransferForm';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreStockTransfer } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EAlimYontemiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreStockTransferMat } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'MainStoreStockTransferNewForm',
    templateUrl: './MainStoreStockTransferNewForm.html',
    providers: [MessageService]
})
export class MainStoreStockTransferNewForm extends BaseMainStoreStockTransferForm implements OnInit {
    public StockActionSignDetailsColumns = [];
    public mainStoreStockTransferNewFormViewModel: MainStoreStockTransferNewFormViewModel = new MainStoreStockTransferNewFormViewModel();
    public get _MainStoreStockTransfer(): MainStoreStockTransfer {
        return this._TTObject as MainStoreStockTransfer;
    }
    private MainStoreStockTransferNewForm_DocumentUrl: string = '/api/MainStoreStockTransferService/MainStoreStockTransferNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private changeDetectorRef: ChangeDetectorRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.MainStoreStockTransferNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();

        if (this._MainStoreStockTransfer.Store == null) {
            this._MainStoreStockTransfer.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.UseMainStoreResources);
        }

        if (this._MainStoreStockTransfer.MKYS_EMalzemeGrup == null) {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey)) {
                this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            }
            this._MainStoreStockTransfer.MKYS_EMalzemeGrup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
        }
        if (this._MainStoreStockTransfer.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
            this.MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID ='58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL";

        }
        if (this._MainStoreStockTransfer.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.ilac) {
            this.MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID ='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
        if (this._MainStoreStockTransfer.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiCihaz) {
            this.MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID ='f38f2111-0ee4-4b9f-9707-a63ac02d29f4'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
        this.MaterialMainStoreStockTransferMat.ListFilterExpression += " AND STOCKS.STORE= '" + this._MainStoreStockTransfer.Store.ObjectID + "' AND STOCKS.INHELD > 0";
        this._MainStoreStockTransfer.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.ambarlarArasiDevir;
        this._MainStoreStockTransfer.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        this._MainStoreStockTransfer.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckAmbarlarArasiDevir;
        if (this._MainStoreStockTransfer.Store instanceof MainStoreDefinition) {
            if ((<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant !== null &&
                (<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant !== undefined) {
                this._MainStoreStockTransfer.MKYS_TeslimEden = (<MainStoreDefinition>this._MainStoreStockTransfer.Store).GoodsAccountant.Name;
                this._MainStoreStockTransfer.MKYS_TeslimEdenObjID = (<MainStoreDefinition>this._MainStoreStockTransfer.Store).GoodsAccountant.ObjectID;
            }
        }
        if (this._MainStoreStockTransfer.DestinationStore instanceof MainStoreDefinition) {
            if ((<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant !== null &&
                (<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant !== undefined) {
                this._MainStoreStockTransfer.MKYS_TeslimAlan = (<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant.Name;
                this._MainStoreStockTransfer.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._MainStoreStockTransfer.DestinationStore).GoodsAccountant.ObjectID;
            }
        }

    }
    protected async PreScript() {
        await super.PreScript();

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreStockTransfer();
        this.mainStoreStockTransferNewFormViewModel = new MainStoreStockTransferNewFormViewModel();
        this._ViewModel = this.mainStoreStockTransferNewFormViewModel;
        this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer = this._TTObject as MainStoreStockTransfer;
        this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.Store = new Store();
        this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.DestinationStore = new Store();
        this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.MainStoreStockTransferMats = new Array<MainStoreStockTransferMat>();
    }

    protected loadViewModel() {
        let that = this;

        that.mainStoreStockTransferNewFormViewModel = this._ViewModel as MainStoreStockTransferNewFormViewModel;
        that._TTObject = this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer;
        if (this.mainStoreStockTransferNewFormViewModel == null) {
            this.mainStoreStockTransferNewFormViewModel = new MainStoreStockTransferNewFormViewModel();
        }
        if (this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer == null) {
            this.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer = new MainStoreStockTransfer();
        }
        let storeObjectID = that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.mainStoreStockTransferNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.Store = store;
            }
        }
        let destinationStoreObjectID = that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.mainStoreStockTransferNewFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
             if (destinationStore) {
                that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.DestinationStore = destinationStore;
            }
        }
        that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.StockActionSignDetails = that.mainStoreStockTransferNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.mainStoreStockTransferNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.mainStoreStockTransferNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.mainStoreStockTransferNewFormViewModel._MainStoreStockTransfer.MainStoreStockTransferMats = that.mainStoreStockTransferNewFormViewModel.MainStoreStockTransferMaterialsGridList;
        for (let detailItem of that.mainStoreStockTransferNewFormViewModel.MainStoreStockTransferMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.mainStoreStockTransferNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.mainStoreStockTransferNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.mainStoreStockTransferNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                 if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem['StockLevelType'];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.mainStoreStockTransferNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(MainStoreStockTransferNewFormViewModel);
        if (this._MainStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._MainStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M10909", "Ana Depolar Arası Transfer ( Yeni )");
        this.changeDetectorRef.detectChanges();

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.ActionDate !== event) {
                this._MainStoreStockTransfer.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.Description !== event) {
                this._MainStoreStockTransfer.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.DestinationStore !== event) {
                this._MainStoreStockTransfer.DestinationStore = event;
            }
        }
        // this.DestinationStore_SelectedObjectChanged();
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.StockActionID !== event) {
                this._MainStoreStockTransfer.StockActionID = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_EMalzemeGrup !== event) {
                this._MainStoreStockTransfer.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_TeslimAlan !== event) {
                this._MainStoreStockTransfer.MKYS_TeslimAlan = event;
            }
        }
    }

    MainStoreStockTransferMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.MainStoreStockTransferMaterials_CellValueChangedEmitted && data.Row && data.Column) {
            this.MainStoreStockTransferMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }

    public async MainStoreStockTransferMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.MainStoreStockTransferMaterials_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInsertting(data: MainStoreStockTransferMat) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.MKYS_TeslimEden !== event) {
                this._MainStoreStockTransfer.MKYS_TeslimEden = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._MainStoreStockTransfer != null && this._MainStoreStockTransfer.Store !== event) {
                this._MainStoreStockTransfer.Store = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 0;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 9;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 8;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 7;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 6;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 5;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'MainStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 4;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 3;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 2;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = i18n("M16869", "İşlem Nu.");
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 1;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
      //  this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
       // this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
     //   this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = 'DescriptionTabpage';

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 4;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = '#FFFFFF';
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = 'Taşınır Malın';
        this.MaterialTabPage.Name = 'MaterialTabPage';

        this.MainStoreStockTransferMaterials = new TTVisual.TTGrid();
        this.MainStoreStockTransferMaterials.Name = 'MainStoreStockTransferMaterials';
        this.MainStoreStockTransferMaterials.TabIndex = 8;
        this.MainStoreStockTransferMaterials.Height = 350;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
      //  this.Detail.Width = 100;

        this.MaterialMainStoreStockTransferMat = new TTVisual.TTListBoxColumn();
        this.MaterialMainStoreStockTransferMat.ListDefName = 'MaterialListDefinition';
        this.MaterialMainStoreStockTransferMat.DataMember = 'Material';
        this.MaterialMainStoreStockTransferMat.AutoCompleteDialogHeight = '60%';
        this.MaterialMainStoreStockTransferMat.AutoCompleteDialogWidth = '90%';
        this.MaterialMainStoreStockTransferMat.DisplayIndex = 1;
        this.MaterialMainStoreStockTransferMat.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialMainStoreStockTransferMat.Name = 'MaterialMainStoreStockTransferMat';
       // this.MaterialMainStoreStockTransferMat.Width = 300;

        this.MaterialBarcode = new TTVisual.TTTextBoxColumn();
        this.MaterialBarcode.DataMember = 'Material.Barcode';
        this.MaterialBarcode.DisplayIndex = 2;
        this.MaterialBarcode.HeaderText = 'Barkod';
        this.MaterialBarcode.Name = 'MaterialBarcode';
        this.MaterialBarcode.ReadOnly = true;
      //  this.MaterialBarcode.Width = 120;

        this.Distrubitontype = new TTVisual.TTTextBoxColumn();
        this.Distrubitontype.DataMember = 'Material.DistributionTypeName';
        this.Distrubitontype.DisplayIndex = 3;
        this.Distrubitontype.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.Distrubitontype.Name = 'Distrubitontype';
        this.Distrubitontype.ReadOnly = true;
       // this.Distrubitontype.Width = 140;

        this.RequestAmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.RequestAmountSubStoreStockTransferMat.DataMember = 'RequestAmount';
        this.RequestAmountSubStoreStockTransferMat.Required = true;
        this.RequestAmountSubStoreStockTransferMat.DisplayIndex = 4;
        this.RequestAmountSubStoreStockTransferMat.HeaderText = i18n("M16713", "İstenen Miktar");
        this.RequestAmountSubStoreStockTransferMat.Name = 'RequestAmountSubStoreStockTransferMat';
       // this.RequestAmountSubStoreStockTransferMat.Width = 120;
        this.RequestAmountSubStoreStockTransferMat.IsNumeric = true;

        this.AmountSubStoreStockTransferMat = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreStockTransferMat.DataMember = 'Amount';
        this.AmountSubStoreStockTransferMat.DisplayIndex = 5;
        this.AmountSubStoreStockTransferMat.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreStockTransferMat.Name = 'AmountSubStoreStockTransferMat';
      //  this.AmountSubStoreStockTransferMat.Width = 120;
        this.AmountSubStoreStockTransferMat.Visible = false;
        this.AmountSubStoreStockTransferMat.IsNumeric = true;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = 'StockLevelTypeList';
        this.StockLevelType.DataMember = 'StockLevelType';
        this.StockLevelType.DisplayIndex = 6;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = 'StockLevelType';
       // this.StockLevelType.Width = 120;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 5;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.Existing = new TTVisual.TTTextBoxColumn();
        this.Existing.DataMember = 'StoreStock';
        this.Existing.Format = 'N2';
        this.Existing.DisplayIndex = 4;
        this.Existing.HeaderText = i18n("M22360", "Stok Miktarı");
        this.Existing.Name = 'Existing';
        this.Existing.ReadOnly = true;
       // this.Existing.Width = 100;


        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.tttabcontrol1.Controls = [this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.MainStoreStockTransferMaterials];
        this.Controls = [this.Existing, this.Description, this.ID, this.labelMKYS_EMalzemeGrup, this.MKYS_EMalzemeGrup, this.labelStore, this.Store, this.labelDestinationStore,
        this.DestinationStore, this.labelActionDate, this.ActionDate, this.labelID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType,
        this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.tttabcontrol1, this.MaterialTabPage, this.MainStoreStockTransferMaterials,  this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];
    }
}