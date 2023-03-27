//$51D9E641
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseChattelDocumentFormViewModel } from './BaseChattelDocumentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

import { BaseChattelDocument } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";

import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';





@Component({
    selector: 'BaseChattelDocumentForm',
    templateUrl: './BaseChattelDocumentForm.html',
    providers: [MessageService]
})
export class BaseChattelDocumentForm extends StockActionBaseForm implements OnInit {
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    SignTabpage: TTVisual.ITTTabPage;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionSignDetails: TTVisual.ITTGrid;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
      public AdditionalDocumentCount: TTVisual.ITTTextBox;
    public StockActionSignDetailsColumns = [];
    public baseChattelDocumentFormViewModel: BaseChattelDocumentFormViewModel = new BaseChattelDocumentFormViewModel();
    public get _BaseChattelDocument(): BaseChattelDocument {
        return this._TTObject as BaseChattelDocument;
    }
    private BaseChattelDocumentForm_DocumentUrl: string = '/api/BaseChattelDocumentService/BaseChattelDocumentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseChattelDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser( " WHERE ISACTIVE = 1 "));
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
            this._BaseChattelDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;

        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser( "WHERE ISACTIVE = 1 "));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            let that = this;
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                that.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
                that._BaseChattelDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;

        }
    }
    protected async PreScript() {
        super.PreScript();
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BaseChattelDocument();
        this.baseChattelDocumentFormViewModel = new BaseChattelDocumentFormViewModel();
        this._ViewModel = this.baseChattelDocumentFormViewModel;
        this.baseChattelDocumentFormViewModel._BaseChattelDocument = this._TTObject as BaseChattelDocument;
        this.baseChattelDocumentFormViewModel._BaseChattelDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseChattelDocumentFormViewModel = this._ViewModel as BaseChattelDocumentFormViewModel;
        that._TTObject = this.baseChattelDocumentFormViewModel._BaseChattelDocument;
        if (this.baseChattelDocumentFormViewModel == null)
            this.baseChattelDocumentFormViewModel = new BaseChattelDocumentFormViewModel();
        if (this.baseChattelDocumentFormViewModel._BaseChattelDocument == null)
            this.baseChattelDocumentFormViewModel._BaseChattelDocument = new BaseChattelDocument();
        that.baseChattelDocumentFormViewModel._BaseChattelDocument.StockActionSignDetails = that.baseChattelDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseChattelDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseChattelDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                 if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BaseChattelDocumentFormViewModel);

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._BaseChattelDocument != null && this._BaseChattelDocument.Description != event) {
                this._BaseChattelDocument.Description = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._BaseChattelDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._BaseChattelDocument != null && this._BaseChattelDocument.MKYS_TeslimAlan != event) {
                this._BaseChattelDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._BaseChattelDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._BaseChattelDocument != null && this._BaseChattelDocument.MKYS_TeslimEden != event) {
                this._BaseChattelDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._BaseChattelDocument != null && this._BaseChattelDocument.StockActionID != event) {
                this._BaseChattelDocument.StockActionID = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._BaseChattelDocument != null && this._BaseChattelDocument.TransactionDate != event) {
                this._BaseChattelDocument.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this._TTObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this._TTObject, "TransactionDate");
        redirectProperty(this.AdditionalDocumentCount, "Text", this._TTObject, "AdditionalDocumentCount");
        redirectProperty(this.Description, "Text", this._TTObject, "Description");
    }

    public initFormControls(): void {
        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 0;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 115;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = "#F0F0F0";
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 113;

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

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 111;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.TTTeslimEdenButon, this.TTTeslimAlanButon, this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description, this.StockActionID, this.labelMKYS_TeslimAlan, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.ttlabel1];

    }


}
