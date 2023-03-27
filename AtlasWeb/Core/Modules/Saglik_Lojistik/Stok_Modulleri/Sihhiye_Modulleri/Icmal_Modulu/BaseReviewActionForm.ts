//$9795A7B5
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseReviewActionFormViewModel } from './BaseReviewActionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { ReviewAction } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { ReviewActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ReviewActionPatientDet } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'BaseReviewActionForm',
    templateUrl: './BaseReviewActionForm.html',
    providers: [MessageService]
})
export class BaseReviewActionForm extends StockActionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountRewiewActionDetail: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    ClinicName: TTVisual.ITTTextBoxColumn;
    StoreName: TTVisual.ITTTextBoxColumn;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    EndDate: TTVisual.ITTDateTimePicker;
    labelActionDate: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelEndDate: TTVisual.ITTLabel;
    labelMKYS_CikisIslemTuru: TTVisual.ITTLabel;
    labelMKYS_CikisStokHareketTuru: TTVisual.ITTLabel;
    labelReviewActionType: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStartDate: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    MaterialRewiewActionDetail: TTVisual.ITTListBoxColumn;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    MKYS_CikisStokHareketTuru: TTVisual.ITTEnumComboBox;
    ReviewActionType: TTVisual.ITTEnumComboBox;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    PatientUniqurefNo: TTVisual.ITTTextBoxColumn;
    PatinetName: TTVisual.ITTTextBoxColumn;
    ReviewActionDetails: TTVisual.ITTGrid;
    ReviewActionTabPanel: TTVisual.ITTTabPage;
    StartDate: TTVisual.ITTDateTimePicker;
    StockActionID: TTVisual.ITTTextBox;
    Store: TTVisual.ITTObjectListBox;
    TTGetDrugButton: TTVisual.ITTButton;
    ClearButton: TTVisual.ITTButton;
    tttabcontrol1: TTVisual.ITTTabControl;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    public ReviewActionDetailsColumns = [];
    public baseReviewActionFormViewModel: BaseReviewActionFormViewModel = new BaseReviewActionFormViewModel();
    public get _ReviewAction(): ReviewAction {
        return this._TTObject as ReviewAction;
    }
    private BaseReviewActionForm_DocumentUrl: string = '/api/ReviewActionService/BaseReviewActionForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseReviewActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    public async TTTeslimAlanButon_Click(): Promise<void> {
        let context: TTObjectContext = new TTObjectContext(false);
        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._ReviewAction.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {
        let context: TTObjectContext = new TTObjectContext(false);
        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._ReviewAction.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PreScript() {
        super.PreScript();
        this._ReviewAction.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        this._ReviewAction.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketimYatanHastaTedavisi;
    }

    TTGetDrugButton_Click() { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReviewAction();
        this.baseReviewActionFormViewModel = new BaseReviewActionFormViewModel();
        this._ViewModel = this.baseReviewActionFormViewModel;
        this.baseReviewActionFormViewModel._ReviewAction = this._TTObject as ReviewAction;
        this.baseReviewActionFormViewModel._ReviewAction.ReviewActionDetails = new Array<ReviewActionDetail>();
        this.baseReviewActionFormViewModel._ReviewAction.ReviewActionPatientDets = new Array<ReviewActionPatientDet>();
        this.baseReviewActionFormViewModel._ReviewAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.baseReviewActionFormViewModel = this._ViewModel as BaseReviewActionFormViewModel;
        that._TTObject = this.baseReviewActionFormViewModel._ReviewAction;
        if (this.baseReviewActionFormViewModel == null)
            this.baseReviewActionFormViewModel = new BaseReviewActionFormViewModel();
        if (this.baseReviewActionFormViewModel._ReviewAction == null)
            this.baseReviewActionFormViewModel._ReviewAction = new ReviewAction();
        that.baseReviewActionFormViewModel._ReviewAction.ReviewActionDetails = that.baseReviewActionFormViewModel.ReviewActionDetailsGridList;
        that.baseReviewActionFormViewModel._ReviewAction.ReviewActionPatientDets = that.baseReviewActionFormViewModel.ReviewActionPatientDetsGridList;
        for (let detailItem of that.baseReviewActionFormViewModel.ReviewActionDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseReviewActionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseReviewActionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseReviewActionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.baseReviewActionFormViewModel._ReviewAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseReviewActionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseReviewActionFormViewModel._ReviewAction.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseReviewActionFormViewModel);

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.ActionDate !== event) {
                this._ReviewAction.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Description !== event) {
                this._ReviewAction.Description = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.EndDate !== event) {
                this._ReviewAction.EndDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisIslemTuru !== event) {
                this._ReviewAction.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisStokHareketTuru !== event) {
                this._ReviewAction.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimAlan !== event) {
                this._ReviewAction.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimEden !== event) {
                this._ReviewAction.MKYS_TeslimEden = event;
            }
        }
    }

    public onStartDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StartDate !== event) {
                this._ReviewAction.StartDate = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StockActionID !== event) {
                this._ReviewAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Store !== event) {
                this._ReviewAction.Store = event;
            }
        }
    }

    public async ReviewActionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {

    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.TTGetDrugButton = new TTVisual.TTButton();
        this.TTGetDrugButton.Text = i18n("M14767", "Getir");
        this.TTGetDrugButton.Name = "TTGetDrugButton";
        this.TTGetDrugButton.TabIndex = 128;

        this.ClearButton = new TTVisual.TTButton();
        this.ClearButton.Text = "Temizle";
        this.ClearButton.Name = "ClearButton";
        this.ClearButton.TabIndex = 128;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 127;

        this.ReviewActionTabPanel = new TTVisual.TTTabPage();
        this.ReviewActionTabPanel.DisplayIndex = 0;
        this.ReviewActionTabPanel.TabIndex = 0;
        this.ReviewActionTabPanel.Text = "Taşınır Malın";
        this.ReviewActionTabPanel.Name = "ReviewActionTabPanel";

        this.ReviewActionDetails = new TTVisual.TTGrid();
        this.ReviewActionDetails.Name = "ReviewActionDetails";
        this.ReviewActionDetails.TabIndex = 126;

        this.MaterialRewiewActionDetail = new TTVisual.TTListBoxColumn();
        this.MaterialRewiewActionDetail.ListDefName = "DrugList";
        this.MaterialRewiewActionDetail.DataMember = "Material";
        this.MaterialRewiewActionDetail.DisplayIndex = 0;
        this.MaterialRewiewActionDetail.HeaderText = i18n("M16287", "İlaç");
        this.MaterialRewiewActionDetail.Name = "MaterialRewiewActionDetail";
        this.MaterialRewiewActionDetail.ReadOnly = true;
        this.MaterialRewiewActionDetail.Width = 300;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.AmountRewiewActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountRewiewActionDetail.DataMember = "Amount";
        this.AmountRewiewActionDetail.DisplayIndex = 3;
        this.AmountRewiewActionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountRewiewActionDetail.Name = "AmountRewiewActionDetail";
        this.AmountRewiewActionDetail.ReadOnly = true;
        this.AmountRewiewActionDetail.Width = 80;

        this.PatinetName = new TTVisual.TTTextBoxColumn();
        this.PatinetName.DataMember = "Patient";
        this.PatinetName.DisplayIndex = 4;
        this.PatinetName.HeaderText = i18n("M15131", "Hasta Adı");
        this.PatinetName.Name = "PatinetName";
        this.PatinetName.ReadOnly = true;
        this.PatinetName.Width = 100;

        this.PatientUniqurefNo = new TTVisual.TTTextBoxColumn();
        this.PatientUniqurefNo.DataMember = "UniqueRefNo";
        this.PatientUniqurefNo.DisplayIndex = 5;
        this.PatientUniqurefNo.HeaderText = "Hasta TCK No";
        this.PatientUniqurefNo.Name = "PatientUniqurefNo";
        this.PatientUniqurefNo.ReadOnly = true;
        this.PatientUniqurefNo.Width = 100;

        this.ClinicName = new TTVisual.TTTextBoxColumn();
        this.ClinicName.DataMember = "Clinic";
        this.ClinicName.DisplayIndex = 6;
        this.ClinicName.HeaderText = i18n("M12031", "Bölüm");
        this.ClinicName.Name = "ClinicName";
        this.ClinicName.ReadOnly = true;
        this.ClinicName.Width = 100;

        this.StoreName = new TTVisual.TTTextBoxColumn();
        this.StoreName.DataMember = "StoreName";
        this.StoreName.DisplayIndex = 6;
        this.StoreName.HeaderText = i18n("M12031", "Bölüm");
        this.StoreName.Name = "StoreName";
        this.StoreName.ReadOnly = true;
        this.StoreName.Width = 100;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 122;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 14;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 12;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 4;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 125;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 124;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 123;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 15;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 13;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 11;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 10;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12365", "Çıkış  Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 9;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.ReadOnly = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 3;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Long;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 2;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 1;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Long;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ReviewActionDetailsColumns = [this.MaterialRewiewActionDetail, this.Barcode, this.DistributionType, this.AmountRewiewActionDetail, this.PatinetName, this.PatientUniqurefNo, this.ClinicName];
        this.tttabcontrol1.Controls = [this.ReviewActionTabPanel];
        this.ReviewActionTabPanel.Controls = [this.ReviewActionDetails];
        this.Controls = [this.TTGetDrugButton, this.ClearButton, this.tttabcontrol1, this.ReviewActionTabPanel, this.ReviewActionDetails,
        this.MaterialRewiewActionDetail, this.Barcode, this.DistributionType, this.AmountRewiewActionDetail, this.PatinetName, this.PatientUniqurefNo,
        this.ClinicName, this.Description, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.StockActionID, this.labelStore, this.Store, this.labelDescription,
        this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.labelMKYS_CikisStokHareketTuru, this.MKYS_CikisStokHareketTuru, this.labelMKYS_CikisIslemTuru,
        this.MKYS_CikisIslemTuru, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate, this.TTTeslimEdenButon, this.TTTeslimAlanButon];

    }


}
