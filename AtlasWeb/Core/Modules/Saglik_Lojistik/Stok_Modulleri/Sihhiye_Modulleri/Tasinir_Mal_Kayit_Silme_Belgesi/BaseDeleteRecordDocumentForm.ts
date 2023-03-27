//$4BAA89A0
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseDeleteRecordDocumentFormViewModel } from './BaseDeleteRecordDocumentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDeleteRecordDocument } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

@Component({
    selector: 'BaseDeleteRecordDocumentForm',
    templateUrl: './BaseDeleteRecordDocumentForm.html',
    providers: [MessageService]
})
export class BaseDeleteRecordDocumentForm extends StockActionBaseForm implements OnInit {
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    EmploymentRecordIDStockActionInspectionDetail: TTVisual.ITTTextBoxColumn;
    FreeTextSignUser: TTVisual.ITTTextBoxColumn;
    InspectionDate: TTVisual.ITTDateTimePicker;
    InspectionTabpage: TTVisual.ITTTabPage;
    InspectionUserStockActionInspectionDetail: TTVisual.ITTListBoxColumn;
    InspectionUserTypeStockActionInspectionDetail: TTVisual.ITTEnumComboBoxColumn;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelInspectionDate: TTVisual.ITTLabel;
    labelMKYS_CikisIslemTuru: TTVisual.ITTLabel;
    labelMKYS_CikisStokHareketTuru: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelReturningDocumentNumber: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    MKYS_CikisStokHareketTuru: TTVisual.ITTEnumComboBox;
    MKYS_TeslimAlan:  TTButtonTextBox;
    MKYS_TeslimEden:  TTButtonTextBox;
    NameStringStockActionInspectionDetail: TTVisual.ITTTextBoxColumn;
    ReportNO: TTVisual.ITTTextBox;
    ReturningDocumentNumber: TTVisual.ITTTextBox;
    ShortMilitaryClassStockActionInspectionDetail: TTVisual.ITTTextBoxColumn;
    ShortRankStockActionInspectionDetail: TTVisual.ITTTextBoxColumn;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionInspectionDetailsStockActionInspectionDetail: TTVisual.ITTGrid;
    StockActionSignDetails: TTVisual.ITTGrid;
    Store: TTVisual.ITTObjectListBox;
    TechnicalReportTabpage: TTVisual.ITTTabPage;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttrichtextboxcontrol1: TTVisual.ITTRichTextBoxControl;
    ttrichtextboxcontrol2: TTVisual.ITTRichTextBoxControl;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    public StockActionInspectionDetailsStockActionInspectionDetailColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseDeleteRecordDocumentFormViewModel: BaseDeleteRecordDocumentFormViewModel = new BaseDeleteRecordDocumentFormViewModel();
    public get _BaseDeleteRecordDocument(): BaseDeleteRecordDocument {
        return this._TTObject as BaseDeleteRecordDocument;
    }
    private BaseDeleteRecordDocumentForm_DocumentUrl: string = '/api/BaseDeleteRecordDocumentService/BaseDeleteRecordDocumentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseDeleteRecordDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async StockActionSignDetails_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {

    }
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
            this._StockAction.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
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
            this._StockAction.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PreScript() {
        super.PreScript();
        this._BaseDeleteRecordDocument.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckKullanilmazHaleGelmeYokOlma;
        this._BaseDeleteRecordDocument.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        this.MKYS_CikisIslemTuru.ReadOnly = true;
        this.MKYS_CikisStokHareketTuru.ReadOnly = true;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseDeleteRecordDocument();
        this.baseDeleteRecordDocumentFormViewModel = new BaseDeleteRecordDocumentFormViewModel();
        this._ViewModel = this.baseDeleteRecordDocumentFormViewModel;
        this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument = this._TTObject as BaseDeleteRecordDocument;
        this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.Store = new Store();
        this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.StockActionInspection = new StockActionInspection();
        this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.StockActionInspection.StockActionInspectionDetails = new Array<StockActionInspectionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseDeleteRecordDocumentFormViewModel = this._ViewModel as BaseDeleteRecordDocumentFormViewModel;
        that._TTObject = this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument;
        if (this.baseDeleteRecordDocumentFormViewModel == null)
            this.baseDeleteRecordDocumentFormViewModel = new BaseDeleteRecordDocumentFormViewModel();
        if (this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument == null)
            this.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument = new BaseDeleteRecordDocument();
        that.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.StockActionSignDetails = that.baseDeleteRecordDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseDeleteRecordDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseDeleteRecordDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        let storeObjectID = that.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseDeleteRecordDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.Store = store;
            }
        }
        let stockActionInspectionObjectID = that.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument["StockActionInspection"];
        if (stockActionInspectionObjectID != null && (typeof stockActionInspectionObjectID === 'string')) {
            let stockActionInspection = that.baseDeleteRecordDocumentFormViewModel.StockActionInspections.find(o => o.ObjectID.toString() === stockActionInspectionObjectID.toString());
             if (stockActionInspection) {
                that.baseDeleteRecordDocumentFormViewModel._BaseDeleteRecordDocument.StockActionInspection = stockActionInspection;
            }
            if (stockActionInspection != null) {
                stockActionInspection.StockActionInspectionDetails = that.baseDeleteRecordDocumentFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList;
                for (let detailItem of that.baseDeleteRecordDocumentFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList) {
                    let inspectionUserObjectID = detailItem["InspectionUser"];
                    if (inspectionUserObjectID != null && (typeof inspectionUserObjectID === 'string')) {
                        let inspectionUser = that.baseDeleteRecordDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === inspectionUserObjectID.toString());
                         if (inspectionUser) {
                            detailItem.InspectionUser = inspectionUser;
                        }
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseDeleteRecordDocumentFormViewModel);

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.Description != event) {
                this._BaseDeleteRecordDocument.Description = event;
            }
        }
    }

    public onInspectionDateChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null &&
                this._BaseDeleteRecordDocument.StockActionInspection != null && this._BaseDeleteRecordDocument.StockActionInspection.InspectionDate != event) {
                this._BaseDeleteRecordDocument.StockActionInspection.InspectionDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.MKYS_CikisIslemTuru != event) {
                this._BaseDeleteRecordDocument.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.MKYS_CikisStokHareketTuru != event) {
                this._BaseDeleteRecordDocument.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.MKYS_TeslimAlan != event) {
                this._BaseDeleteRecordDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.MKYS_TeslimEden != event) {
                this._BaseDeleteRecordDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onReportNOChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null &&
                this._BaseDeleteRecordDocument.StockActionInspection != null && this._BaseDeleteRecordDocument.StockActionInspection.ReportNumberNotSeq != event) {
                this._BaseDeleteRecordDocument.StockActionInspection.ReportNumberNotSeq = event;
            }
        }
    }

    public onReturningDocumentNumberChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.ReturningDocumentNumber != event) {
                this._BaseDeleteRecordDocument.ReturningDocumentNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.StockActionID != event) {
                this._BaseDeleteRecordDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.Store != event) {
                this._BaseDeleteRecordDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.TransactionDate != event) {
                this._BaseDeleteRecordDocument.TransactionDate = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null && this._BaseDeleteRecordDocument.TechnicalReport != event) {
                this._BaseDeleteRecordDocument.TechnicalReport = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._BaseDeleteRecordDocument != null &&
                this._BaseDeleteRecordDocument.StockActionInspection != null && this._BaseDeleteRecordDocument.StockActionInspection.InspectionReport != event) {
                this._BaseDeleteRecordDocument.StockActionInspection.InspectionReport = event;
            }
        }
    }



    StockActionSignDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionSignDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionSignDetails.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.StockActionSignDetails_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.ReturningDocumentNumber, "Text", this.__ttObject, "ReturningDocumentNumber");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "TechnicalReport");
        redirectProperty(this.ttrichtextboxcontrol2, "Rtf", this.__ttObject, "StockActionInspection.InspectionReport");
        redirectProperty(this.InspectionDate, "Value", this.__ttObject, "StockActionInspection.InspectionDate");
        redirectProperty(this.ReportNO, "Text", this.__ttObject, "StockActionInspection.ReportNumberNotSeq");
    }

    public initFormControls(): void {
        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.MKYS_TeslimEden = new TTVisual.TTTextBox();
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 39;

        this.MKYS_TeslimAlan = new TTVisual.TTTextBox();
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 37;

        this.ReturningDocumentNumber = new TTVisual.TTTextBox();
        this.ReturningDocumentNumber.BackColor = "#F0F0F0";
        this.ReturningDocumentNumber.ReadOnly = true;
        this.ReturningDocumentNumber.Name = "ReturningDocumentNumber";
        this.ReturningDocumentNumber.TabIndex = 5;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Visible = false;

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
        this.SignUser.Width = 300;

        this.FreeTextSignUser = new TTVisual.TTTextBoxColumn();
        this.FreeTextSignUser.DataMember = "NameString";
        this.FreeTextSignUser.DisplayIndex = 2;
        this.FreeTextSignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.FreeTextSignUser.Name = "FreeTextSignUser";
        this.FreeTextSignUser.Width = 300;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 3;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 40;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 38;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12364", "Çıkış  Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 36;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 35;
        this.MKYS_CikisStokHareketTuru.ReadOnly = true;
        this.MKYS_CikisStokHareketTuru.Enabled = false;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 34;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 33;
        this.MKYS_CikisIslemTuru.ReadOnly = true;
        this.MKYS_CikisIslemTuru.Enabled = false;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 32;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 31;

        this.labelReturningDocumentNumber = new TTVisual.TTLabel();
        this.labelReturningDocumentNumber.Text = i18n("M10651", "Aktarılan Belge Numarası");
        this.labelReturningDocumentNumber.Name = "labelReturningDocumentNumber";
        this.labelReturningDocumentNumber.TabIndex = 30;

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

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 6;

        this.TechnicalReportTabpage = new TTVisual.TTTabPage();
        this.TechnicalReportTabpage.DisplayIndex = 0;
        this.TechnicalReportTabpage.TabIndex = 2;
        this.TechnicalReportTabpage.Text = i18n("M23096", "Teknik Rapor");
        this.TechnicalReportTabpage.Name = "TechnicalReportTabpage";

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 7;

        this.InspectionTabpage = new TTVisual.TTTabPage();
        this.InspectionTabpage.DisplayIndex = 1;
        this.InspectionTabpage.TabIndex = 3;
        this.InspectionTabpage.Text = i18n("M19196", "Muayene Komisyonu");
        this.InspectionTabpage.Name = "InspectionTabpage";

        this.StockActionInspectionDetailsStockActionInspectionDetail = new TTVisual.TTGrid();
        this.StockActionInspectionDetailsStockActionInspectionDetail.Name = "StockActionInspectionDetailsStockActionInspectionDetail";
        this.StockActionInspectionDetailsStockActionInspectionDetail.TabIndex = 33;

        this.InspectionUserTypeStockActionInspectionDetail = new TTVisual.TTEnumComboBoxColumn();
        this.InspectionUserTypeStockActionInspectionDetail.DataTypeName = "InspectionUserTypeEnum";
        this.InspectionUserTypeStockActionInspectionDetail.DataMember = "InspectionUserType";
        this.InspectionUserTypeStockActionInspectionDetail.Required = true;
        this.InspectionUserTypeStockActionInspectionDetail.DisplayIndex = 0;
        this.InspectionUserTypeStockActionInspectionDetail.HeaderText = "Görevi";
        this.InspectionUserTypeStockActionInspectionDetail.Name = "InspectionUserTypeStockActionInspectionDetail";
        this.InspectionUserTypeStockActionInspectionDetail.Width = 100;

        this.InspectionUserStockActionInspectionDetail = new TTVisual.TTListBoxColumn();
        this.InspectionUserStockActionInspectionDetail.ListDefName = "UserListDefinition";
        this.InspectionUserStockActionInspectionDetail.DataMember = "InspectionUser";
        this.InspectionUserStockActionInspectionDetail.DisplayIndex = 1;
        this.InspectionUserStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.InspectionUserStockActionInspectionDetail.Name = "InspectionUserStockActionInspectionDetail";
        this.InspectionUserStockActionInspectionDetail.Width = 300;

        this.NameStringStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.NameStringStockActionInspectionDetail.DataMember = "NameString";
        this.NameStringStockActionInspectionDetail.Required = true;
        this.NameStringStockActionInspectionDetail.DisplayIndex = 2;
        this.NameStringStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.NameStringStockActionInspectionDetail.Name = "NameStringStockActionInspectionDetail";
        this.NameStringStockActionInspectionDetail.Width = 200;

        this.ShortMilitaryClassStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortMilitaryClassStockActionInspectionDetail.DataMember = "ShortMilitaryClass";
        this.ShortMilitaryClassStockActionInspectionDetail.DisplayIndex = 3;
        this.ShortMilitaryClassStockActionInspectionDetail.HeaderText = i18n("M21810", "Sınıf Kısaltması");
        this.ShortMilitaryClassStockActionInspectionDetail.Name = "ShortMilitaryClassStockActionInspectionDetail";
        this.ShortMilitaryClassStockActionInspectionDetail.Width = 80;
        this.ShortMilitaryClassStockActionInspectionDetail.Visible = false;

        this.ShortRankStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortRankStockActionInspectionDetail.DataMember = "ShortRank";
        this.ShortRankStockActionInspectionDetail.DisplayIndex = 4;
        this.ShortRankStockActionInspectionDetail.HeaderText = i18n("M21078", "Rütbe Kısaltması");
        this.ShortRankStockActionInspectionDetail.Name = "ShortRankStockActionInspectionDetail";
        this.ShortRankStockActionInspectionDetail.Width = 80;
        this.ShortRankStockActionInspectionDetail.Visible = false;

        this.EmploymentRecordIDStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.EmploymentRecordIDStockActionInspectionDetail.DataMember = "EmploymentRecordID";
        this.EmploymentRecordIDStockActionInspectionDetail.DisplayIndex = 5;
        this.EmploymentRecordIDStockActionInspectionDetail.HeaderText = i18n("M21831", "Sicil No");
        this.EmploymentRecordIDStockActionInspectionDetail.Name = "EmploymentRecordIDStockActionInspectionDetail";
        this.EmploymentRecordIDStockActionInspectionDetail.Width = 80;
        this.EmploymentRecordIDStockActionInspectionDetail.Visible = false;

        this.ttrichtextboxcontrol2 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol2.DisplayText = i18n("M19212", "Muayene Raporu");
        this.ttrichtextboxcontrol2.TemplateGroupName = i18n("M22331", "Stok İşlemleri Muayene Raporları");
        this.ttrichtextboxcontrol2.Name = "ttrichtextboxcontrol2";
        this.ttrichtextboxcontrol2.TabIndex = 2;

        this.labelInspectionDate = new TTVisual.TTLabel();
        this.labelInspectionDate.Text = i18n("M19222", "Muayene Tarihi");
        this.labelInspectionDate.BackColor = "#DCDCDC";
        this.labelInspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInspectionDate.ForeColor = "#000000";
        this.labelInspectionDate.Name = "labelInspectionDate";
        this.labelInspectionDate.TabIndex = 11;

        this.ReportNO = new TTVisual.TTTextBox();
        this.ReportNO.Name = "ReportNO";
        this.ReportNO.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20824", "Rapor Numarası");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.InspectionDate = new TTVisual.TTDateTimePicker();
        this.InspectionDate.CustomFormat = "";
        this.InspectionDate.Format = DateTimePickerFormat.Short;
        this.InspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InspectionDate.Name = "InspectionDate";
        this.InspectionDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10469", "Açıklama");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 16;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.FreeTextSignUser, this.IsDeputy];
        this.StockActionInspectionDetailsStockActionInspectionDetailColumns = [this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail];
        this.DescriptionAndSignTabControl.Controls = [this.TechnicalReportTabpage, this.InspectionTabpage];
        this.TechnicalReportTabpage.Controls = [this.ttrichtextboxcontrol1];
        this.InspectionTabpage.Controls = [this.StockActionInspectionDetailsStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate];
        this.Controls = [this.Description, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.ReturningDocumentNumber, this.StockActionID, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.FreeTextSignUser, this.IsDeputy, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.labelMKYS_CikisStokHareketTuru, this.MKYS_CikisStokHareketTuru, this.labelMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.labelStore, this.Store, this.labelReturningDocumentNumber, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.DescriptionAndSignTabControl, this.TechnicalReportTabpage, this.ttrichtextboxcontrol1, this.InspectionTabpage, this.StockActionInspectionDetailsStockActionInspectionDetail, this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate, this.TTTeslimEdenButon, this.TTTeslimAlanButon, this.ttlabel6];

    }


}
