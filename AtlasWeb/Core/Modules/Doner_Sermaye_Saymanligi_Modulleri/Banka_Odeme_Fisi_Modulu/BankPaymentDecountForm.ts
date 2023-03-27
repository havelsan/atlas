//$2901D9B2
import { Component, OnInit, NgZone } from '@angular/core';
import { BankPaymentDecountFormViewModel } from './BankPaymentDecountFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BankPaymentDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BankPaymentDecountDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'BankPaymentDecountForm',
    templateUrl: './BankPaymentDecountForm.html',
    providers: [MessageService]
})
export class BankPaymentDecountForm extends TTVisual.TTForm implements OnInit {
    BANKACCOUNT: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DOCUMENTDATE: TTVisual.ITTDateTimePicker;
    lblBankDecountDate: TTVisual.ITTLabel;
    dtPickerDecountDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    txtDecountNo: TTVisual.ITTTextBox;
    txtCashierName: TTVisual.ITTTextBox;
    txtCashOffice: TTVisual.ITTTextBox;
    //txtTotalPrice: TTVisual.ITTTextBox;
    txtTotalPriceReadOnly: boolean = false;

    public bankPaymentDecountFormViewModel: BankPaymentDecountFormViewModel = new BankPaymentDecountFormViewModel();
    public get _BankPaymentDecount(): BankPaymentDecount {
        return this._TTObject as BankPaymentDecount;
    }
    private BankPaymentDecountForm_DocumentUrl: string = '/api/BankPaymentDecountService/BankPaymentDecountForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('BANKPAYMENTDECOUNT', 'BankPaymentDecountForm');
        this._DocumentServiceUrl = this.BankPaymentDecountForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    totalPriceKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        //cmdOK.Visible = false;
        if (this._BankPaymentDecount.IsNew) {
            // let resUser: ResUser = TTUser.CurrentUser.UserObject as ResUser;
            // let selectedCashOffice: CashOfficeDefinition = (await ResUserService.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser));
            // if (selectedCashOffice === null)
            //     throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Diğer Tahsilatları yapmaya yetikiniz bulunmamaktadır!");
            // this._BankPaymentDecount.BankPaymentDecountDocument = new BankPaymentDecountDocument(this._BankPaymentDecount.ObjectContext);
            // this._BankPaymentDecount.BankPaymentDecountDocument.CashOffice = selectedCashOffice;
            // this._BankPaymentDecount.BankPaymentDecountDocument.ResUser = resUser;
            // this._BankPaymentDecount.BankPaymentDecountDocument.CurrentStateDefID = BankPaymentDecountDocument.BankPaymentDecountDocumentStates.New;
            // this._BankPaymentDecount.BankPaymentDecountDocument.DocumentDate = (await CommonService.RecTime());
        }
        else {
            this.BANKACCOUNT.Enabled = false;
            this.Description.ReadOnly = true;
            this.txtTotalPriceReadOnly = true;
            this.txtDecountNo.ReadOnly = true;
            this.dtPickerDecountDate.ReadOnly = true;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        // if (this._BankPaymentDecount.TotalPrice === 0)
        //     throw new TTException((await SystemMessageService.GetMessage(187)));
        // else {
        // }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BankPaymentDecount();
        this.bankPaymentDecountFormViewModel = new BankPaymentDecountFormViewModel();
        this._ViewModel = this.bankPaymentDecountFormViewModel;
        this.bankPaymentDecountFormViewModel._BankPaymentDecount = this._TTObject as BankPaymentDecount;
        this.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument = new BankPaymentDecountDocument();
        this.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument.BankDecount = new BankDecount();
        this.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.BankAccount = new BankAccountDefinition();
        this.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument.CashOffice = new CashOfficeDefinition();
        this.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument.ResUser = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.bankPaymentDecountFormViewModel = this._ViewModel as BankPaymentDecountFormViewModel;
        that._TTObject = this.bankPaymentDecountFormViewModel._BankPaymentDecount;
        if (this.bankPaymentDecountFormViewModel == null)
            this.bankPaymentDecountFormViewModel = new BankPaymentDecountFormViewModel();
        if (this.bankPaymentDecountFormViewModel._BankPaymentDecount == null)
            this.bankPaymentDecountFormViewModel._BankPaymentDecount = new BankPaymentDecount();
        let bankPaymentDecountDocumentObjectID = that.bankPaymentDecountFormViewModel._BankPaymentDecount["BankPaymentDecountDocument"];
        if (bankPaymentDecountDocumentObjectID != null && (typeof bankPaymentDecountDocumentObjectID === 'string')) {
            let bankPaymentDecountDocument = that.bankPaymentDecountFormViewModel.BankPaymentDecountDocuments.find(o => o.ObjectID.toString() === bankPaymentDecountDocumentObjectID.toString());
             if (bankPaymentDecountDocument) {
                that.bankPaymentDecountFormViewModel._BankPaymentDecount.BankPaymentDecountDocument = bankPaymentDecountDocument;
            }
            if (bankPaymentDecountDocument != null) {
                let bankDecountObjectID = bankPaymentDecountDocument["BankDecount"];
                if (bankDecountObjectID != null && (typeof bankDecountObjectID === 'string')) {
                    let bankDecount = that.bankPaymentDecountFormViewModel.BankDecounts.find(o => o.ObjectID.toString() === bankDecountObjectID.toString());
                     if (bankDecount) {
                        bankPaymentDecountDocument.BankDecount = bankDecount;
                    }
                    if (bankDecount != null) {
                        let bankAccountObjectID = bankDecount["BankAccount"];
                        if (bankAccountObjectID != null && (typeof bankAccountObjectID === 'string')) {
                            let bankAccount = that.bankPaymentDecountFormViewModel.BankAccountDefinitions.find(o => o.ObjectID.toString() === bankAccountObjectID.toString());
                             if (bankAccount) {
                                bankDecount.BankAccount = bankAccount;
                            }
                        }
                    }
                }
            }
            if (bankPaymentDecountDocument != null) {
                let cashOfficeObjectID = bankPaymentDecountDocument["CashOffice"];
                if (cashOfficeObjectID != null && (typeof cashOfficeObjectID === 'string')) {
                    let cashOffice = that.bankPaymentDecountFormViewModel.CashOfficeDefinitions.find(o => o.ObjectID.toString() === cashOfficeObjectID.toString());
                     if (cashOffice) {
                        bankPaymentDecountDocument.CashOffice = cashOffice;
                    }
                }
            }
            if (bankPaymentDecountDocument != null) {
                let resUserObjectID = bankPaymentDecountDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.bankPaymentDecountFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                     if (resUser) {
                        bankPaymentDecountDocument.ResUser = resUser;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(BankPaymentDecountFormViewModel);
  
    }


    public onBANKACCOUNTChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount != null && this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.BankAccount != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.BankAccount = event;
            }
        }
    }

    public ondtPickerDecountDateChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount != null && this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.DecountDate != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.DecountDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null && this._BankPaymentDecount.Description != event) {
                this._BankPaymentDecount.Description = event;
            }
        }
    }

    public onDOCUMENTDATEChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null && this._BankPaymentDecount.BankPaymentDecountDocument.DocumentDate != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.DocumentDate = event;
            }
        }
    }

    public ontxtDecountNoChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount != null && this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.DecountNo != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.DecountNo = event;
            }
        }
    }

    public ontxtCashierNameChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument.ResUser != null && this._BankPaymentDecount.BankPaymentDecountDocument.ResUser.Name != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.ResUser.Name = event;
            }
        }
    }

    public ontxtCashOfficeChanged(event): void {
        if (event != null) {
            if (this._BankPaymentDecount != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument != null &&
                this._BankPaymentDecount.BankPaymentDecountDocument.CashOffice != null && this._BankPaymentDecount.BankPaymentDecountDocument.CashOffice.Name != event) {
                this._BankPaymentDecount.BankPaymentDecountDocument.CashOffice.Name = event;
            }
        }
    }

    public ontxtTotalPriceChanged(event): void {
        if (event != null) {
            this._BankPaymentDecount.BankPaymentDecountDocument.TotalPrice = Math.Round(this._BankPaymentDecount.TotalPrice, 2);
            this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.Price = Math.Round(this._BankPaymentDecount.TotalPrice, 2);
        }
        else
            this._BankPaymentDecount.BankPaymentDecountDocument.BankDecount.Price = 0;
    }


    protected redirectProperties(): void {
        redirectProperty(this.txtCashierName, "Text", this.__ttObject, "BankPaymentDecountDocument.ResUser.Name");
        redirectProperty(this.txtCashOffice, "Text", this.__ttObject, "BankPaymentDecountDocument.CashOffice.Name");
        redirectProperty(this.DOCUMENTDATE, "Value", this.__ttObject, "BankPaymentDecountDocument.DocumentDate");
        redirectProperty(this.txtDecountNo, "Text", this.__ttObject, "BankPaymentDecountDocument.BankDecount.DecountNo");
        redirectProperty(this.dtPickerDecountDate, "Value", this.__ttObject, "BankPaymentDecountDocument.BankDecount.DecountDate");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        //redirectProperty(this.txtTotalPrice, "Text", this.__ttObject, "TotalPrice");
    }

    public initFormControls(): void {

        this.dtPickerDecountDate = new TTVisual.TTDateTimePicker();
        this.dtPickerDecountDate.Format = DateTimePickerFormat.Short;
        this.dtPickerDecountDate.Name = "dtPickerDecountDate";
        this.dtPickerDecountDate.TabIndex = 30;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M24419", "Yatırılan Tutar");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 23;

        // this.txtTotalPrice = new TTVisual.TTTextBox();
        // this.txtTotalPrice.Required = true;
        // this.txtTotalPrice.BackColor = "#FFE3C6";
        // this.txtTotalPrice.Name = "txtTotalPrice";
        // this.txtTotalPrice.TabIndex = 22;

        this.txtCashOffice = new TTVisual.TTTextBox();
        this.txtCashOffice.BackColor = "#F0F0F0";
        this.txtCashOffice.ReadOnly = true;
        this.txtCashOffice.Name = "txtCashOffice";
        this.txtCashOffice.TabIndex = 12;

        this.txtCashierName = new TTVisual.TTTextBox();
        this.txtCashierName.BackColor = "#F0F0F0";
        this.txtCashierName.ReadOnly = true;
        this.txtCashierName.Name = "txtCashierName";
        this.txtCashierName.TabIndex = 10;

        this.txtDecountNo = new TTVisual.TTTextBox();
        //this.txtDecountNo.Required = true;
        this.txtDecountNo.Name = "txtDecountNo";
        this.txtDecountNo.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M12545", "Dekont No");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 21;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M24129", "Vezne Adı");
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 13;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M24159", "Veznedar");
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 11;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M11515", "Banka Şubesi");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 9;

        this.BANKACCOUNT = new TTVisual.TTObjectListBox();
        //this.BANKACCOUNT.Required = true;
        this.BANKACCOUNT.ListDefName = "BankAccountListDefinition";
        this.BANKACCOUNT.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BANKACCOUNT.Name = "BANKACCOUNT";
        this.BANKACCOUNT.TabIndex = 8;

        this.DOCUMENTDATE = new TTVisual.TTDateTimePicker();
        this.DOCUMENTDATE.CustomFormat = "";
        this.DOCUMENTDATE.Format = DateTimePickerFormat.Short;
        this.DOCUMENTDATE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DOCUMENTDATE.Name = "DOCUMENTDATE";
        this.DOCUMENTDATE.TabIndex = 3;
        this.DOCUMENTDATE.ReadOnly = true;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M19864", "Ödeme Tarihi");
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 20;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M10469", "Açıklama");
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 28;

        this.Controls = [this.dtPickerDecountDate, this.lblBankDecountDate, this.ttlabel5, /*this.txtTotalPrice,*/ this.txtCashOffice, this.txtCashierName,
        this.txtDecountNo, this.Description, this.ttlabel4, this.ttlabel3, this.ttlabel2, this.ttlabel1, this.BANKACCOUNT, this.DOCUMENTDATE, this.ttlabel7, this.ttlabel10];
    }
}
