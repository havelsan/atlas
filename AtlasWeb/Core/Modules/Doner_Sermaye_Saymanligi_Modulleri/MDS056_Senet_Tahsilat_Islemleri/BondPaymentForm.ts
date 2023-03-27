//$C2997CF3
import { Component, OnInit, NgZone } from '@angular/core';
import { BondPaymentFormViewModel } from './BondPaymentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BondPayment } from 'NebulaClient/Model/AtlasClientModel';
import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BondPaymentDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BondPaymentDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { PaymentTypeEnum } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'BondPaymentForm',
    templateUrl: './BondPaymentForm.html',
    providers: [MessageService]
})
export class BondPaymentForm extends TTVisual.TTForm implements OnInit {
    cbxPaymentType: TTVisual.ITTEnumComboBox;
    dtPickerBankDecountDate: TTVisual.ITTDateTimePicker;
    dtPickerDocumentDate: TTVisual.ITTDateTimePicker;
    GRDBONDDETAILDATE: TTVisual.ITTDateTimePickerColumn;
    GRDBONDNO: TTVisual.ITTTextBoxColumn;
    GRDPAID: TTVisual.ITTCheckBoxColumn;
    GRDPRICE: TTVisual.ITTTextBoxColumn;
    lblBankAccount: TTVisual.ITTLabel;
    lblBankDeceountNo: TTVisual.ITTLabel;
    lblBankDecountDate: TTVisual.ITTLabel;
    lblCashierName: TTVisual.ITTLabel;
    lblCashOfficeName: TTVisual.ITTLabel;
    lblDescription: TTVisual.ITTLabel;
    lblDocumentNo: TTVisual.ITTLabel;
    lblPayeeName: TTVisual.ITTLabel;
    lblPaymentPrice: TTVisual.ITTLabel;
    lblPaymentType: TTVisual.ITTLabel;
    lblProcessDate: TTVisual.ITTLabel;
    lblTotalPrice: TTVisual.ITTLabel;
    lstBoxBankAccount: TTVisual.ITTObjectListBox;
    ttgrid1: TTVisual.ITTGrid;
    tttextbox1: TTVisual.ITTTextBox;
    txtBankDecountNo: TTVisual.ITTTextBox;
    txtCashierName: TTVisual.ITTTextBox;
    txtDescription: TTVisual.ITTTextBox;
    txtDocumentNo: TTVisual.ITTTextBox;
    txtPayeeName: TTVisual.ITTTextBox;
    txtPaymentPrice: TTVisual.ITTTextBox;
    txtTotalPrice: TTVisual.ITTTextBox;
    public ttgrid1Columns = [];

    PaymentPrice: Currency = 0;
    documentNo: string;

    public bondPaymentFormViewModel: BondPaymentFormViewModel = new BondPaymentFormViewModel();
    public get _BondPayment(): BondPayment {
        return this._TTObject as BondPayment;
    }
    private BondPaymentForm_DocumentUrl: string = '/api/BondPaymentService/BondPaymentForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super('BONDPAYMENT', 'BondPaymentForm');
        this._DocumentServiceUrl = this.BondPaymentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new BondPayment();
        this.bondPaymentFormViewModel = new BondPaymentFormViewModel();
        this._ViewModel = this.bondPaymentFormViewModel;
        this.bondPaymentFormViewModel._BondPayment = this._TTObject as BondPayment;
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument = new BondPaymentDocument();
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.CashOffice = new CashOfficeDefinition();
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.ResUser = new ResUser();
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.BankDecount = new BankDecount();
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.BankDecount.BankAccount = new BankAccountDefinition();
        this.bondPaymentFormViewModel._BondPayment.BondPaymentDetails = new Array<BondPaymentDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.bondPaymentFormViewModel = this._ViewModel as BondPaymentFormViewModel;
        that._TTObject = this.bondPaymentFormViewModel._BondPayment;
        if (this.bondPaymentFormViewModel == null)
            this.bondPaymentFormViewModel = new BondPaymentFormViewModel();
        if (this.bondPaymentFormViewModel._BondPayment == null)
            this.bondPaymentFormViewModel._BondPayment = new BondPayment();
        let bondPaymentDocumentObjectID = that.bondPaymentFormViewModel._BondPayment["BondPaymentDocument"];
        if (bondPaymentDocumentObjectID != null && (typeof bondPaymentDocumentObjectID === 'string')) {
            let bondPaymentDocument = that.bondPaymentFormViewModel.BondPaymentDocuments.find(o => o.ObjectID.toString() === bondPaymentDocumentObjectID.toString());
             if (bondPaymentDocument) {
                that.bondPaymentFormViewModel._BondPayment.BondPaymentDocument = bondPaymentDocument;
            }
            if (bondPaymentDocument != null) {
                let cashOfficeObjectID = bondPaymentDocument["CashOffice"];
                if (cashOfficeObjectID != null && (typeof cashOfficeObjectID === 'string')) {
                    let cashOffice = that.bondPaymentFormViewModel.CashOfficeDefinitions.find(o => o.ObjectID.toString() === cashOfficeObjectID.toString());
                     if (cashOffice) {
                        bondPaymentDocument.CashOffice = cashOffice;
                    }
                }
            }
            if (bondPaymentDocument != null) {
                let resUserObjectID = bondPaymentDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.bondPaymentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                     if (resUser) {
                        bondPaymentDocument.ResUser = resUser;
                    }
                }
            }
            if (bondPaymentDocument != null) {
                let bankDecountObjectID = bondPaymentDocument["BankDecount"];
                if (bankDecountObjectID != null && (typeof bankDecountObjectID === 'string')) {
                    let bankDecount = that.bondPaymentFormViewModel.BankDecounts.find(o => o.ObjectID.toString() === bankDecountObjectID.toString());
                     if (bankDecount) {
                        bondPaymentDocument.BankDecount = bankDecount;
                    }
                    if (bankDecount != null) {
                        let bankAccountObjectID = bankDecount["BankAccount"];
                        if (bankAccountObjectID != null && (typeof bankAccountObjectID === 'string')) {
                            let bankAccount = that.bondPaymentFormViewModel.BankAccountDefinitions.find(o => o.ObjectID.toString() === bankAccountObjectID.toString());
                             if (bankAccount) {
                                bankDecount.BankAccount = bankAccount;
                            }
                        }
                    }
                }
            }
        }
        that.bondPaymentFormViewModel._BondPayment.BondPaymentDetails = that.bondPaymentFormViewModel.ttgrid1GridList;
        for (let detailItem of that.bondPaymentFormViewModel.ttgrid1GridList) {
        }
    }

    protected async ClientSidePreScript(): Promise<void> {
        this.documentNo = this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.DocumentNo;
        if (this._BondPayment.IsNew) {
            if (String.isNullOrEmpty(this._BondPayment.CashOfficeName)) {
                this.cbxPaymentType.IncludeOnly = [3];
                this.cbxPaymentType.Enabled = false;
                this.cbxPaymentType.ReadOnly = true;
                this._BondPayment.BondPaymentDocument.PaymentType = PaymentTypeEnum.Bank;
            }
            this.cbxPaymentTypeEnum_SelectedIndexChange();
        }
        else {
            this.lstBoxBankAccount.Enabled = false;
            this.txtBankDecountNo.ReadOnly = true;
            this.dtPickerBankDecountDate.ReadOnly = true;
            this.cbxPaymentType.ReadOnly = true;
        }
    }

    async ngOnInit()  {
        let that = this;
        await this.load(BondPaymentFormViewModel);
  
    }


    private cbxPaymentTypeEnum_SelectedIndexChange(): void {
        if (this._BondPayment.BondPaymentDocument.PaymentType === PaymentTypeEnum.Bank) {
            this.lstBoxBankAccount.ReadOnly = false;
            this.lstBoxBankAccount.Enabled = true;
            this.txtBankDecountNo.ReadOnly = false;
            this.txtBankDecountNo.BackColor = "#FFF";
            this.dtPickerBankDecountDate.ReadOnly = false;
            this._BondPayment.BondPaymentDocument.BankDecount.BankAccount = null;
            this._BondPayment.BondPaymentDocument.BankDecount.DecountNo = null;
            this._BondPayment.BondPaymentDocument.BankDecount.DecountDate = null;
            this._BondPayment.BondPaymentDocument.DocumentNo = null;
        }
        else {
            this.lstBoxBankAccount.ReadOnly = true;
            this.lstBoxBankAccount.Enabled = false;
            this.txtBankDecountNo.ReadOnly = true;
            this.txtBankDecountNo.BackColor = "#F0F0F0";
            this.dtPickerBankDecountDate.ReadOnly = true;
            //this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = (await ReceiptCashOfficeDefinitionService.GetCurrentReceiptNumber(this.selectedRCODef));
            this._BondPayment.BondPaymentDocument.DocumentNo = this.documentNo;
            this._BondPayment.BondPaymentDocument.BankDecount.DecountNo = null;
            this._BondPayment.BondPaymentDocument.BankDecount.DecountDate = null;
        }
    }

    public oncbxPaymentTypeChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null && this._BondPayment.BondPaymentDocument.PaymentType != event) {
                this._BondPayment.BondPaymentDocument.PaymentType = event;
                this.cbxPaymentTypeEnum_SelectedIndexChange();
            }
        }
    }

    public ondtPickerBankDecountDateChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null &&
                this._BondPayment.BondPaymentDocument.BankDecount != null && this._BondPayment.BondPaymentDocument.BankDecount.DecountDate != event) {
                this._BondPayment.BondPaymentDocument.BankDecount.DecountDate = event;
            }
        }
    }

    public ondtPickerDocumentDateChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null && this._BondPayment.BondPaymentDocument.DocumentDate != event) {
                this._BondPayment.BondPaymentDocument.DocumentDate = event;
            }
        }
    }

    public onlstBoxBankAccountChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null &&
                this._BondPayment.BondPaymentDocument.BankDecount != null && this._BondPayment.BondPaymentDocument.BankDecount.BankAccount != event) {
                this._BondPayment.BondPaymentDocument.BankDecount.BankAccount = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null &&
                this._BondPayment.BondPaymentDocument.CashOffice != null && this._BondPayment.BondPaymentDocument.CashOffice.Name != event) {
                this._BondPayment.BondPaymentDocument.CashOffice.Name = event;
            }
        }
    }

    public ontxtBankDecountNoChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null &&
                this._BondPayment.BondPaymentDocument.BankDecount != null && this._BondPayment.BondPaymentDocument.BankDecount.DecountNo != event) {
                this._BondPayment.BondPaymentDocument.BankDecount.DecountNo = event;
            }
        }
    }

    public ontxtCashierNameChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null &&
                this._BondPayment.BondPaymentDocument.ResUser != null && this._BondPayment.BondPaymentDocument.ResUser.Name != event) {
                this._BondPayment.BondPaymentDocument.ResUser.Name = event;
            }
        }
    }

    public ontxtDescriptionChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null && this._BondPayment.Description != event) {
                this._BondPayment.Description = event;
            }
        }
    }

    public ontxtDocumentNoChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null && this._BondPayment.BondPaymentDocument.DocumentNo != event) {
                this._BondPayment.BondPaymentDocument.DocumentNo = event;
            }
        }
    }

    public ontxtPayeeNameChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null &&
                this._BondPayment.BondPaymentDocument != null && this._BondPayment.BondPaymentDocument.PayeeName != event) {
                this._BondPayment.BondPaymentDocument.PayeeName = event;
            }
        }
    }

    public ontxtPaymentPriceChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null && this._BondPayment.PaymentPrice != event) {
                this._BondPayment.PaymentPrice = event;
            }
        }
    }

    public ontxtTotalPriceChanged(event): void {
        if (event != null) {
            if (this._BondPayment != null && this._BondPayment.TotalPrice != event) {
                this._BondPayment.TotalPrice = event;
            }
        }
    }

    onRowPrepared(event: any) {

    }

    onGrdDeilCellValueChanged(event: any) {
        if (event.Row != null && event.Column instanceof TTVisual.TTCheckBoxColumn) {
            let selectedItem: BondPaymentDetail = <BondPaymentDetail>event.Row.TTObject;
            if (selectedItem.Paid)
                this.PaymentPrice += selectedItem.BondDetailPrice;
            else
                this.PaymentPrice -= selectedItem.BondDetailPrice;
            if (this.PaymentPrice < 0)
                this.PaymentPrice = 0;
            this.bondPaymentFormViewModel._BondPayment.PaymentPrice = Math.Round(this.PaymentPrice, 2);
            this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.BankDecount.Price = Math.Round(this.PaymentPrice, 2);
            this.bondPaymentFormViewModel._BondPayment.BondPaymentDocument.TotalPrice = Math.Round(this.PaymentPrice, 2);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "BondPaymentDocument.CashOffice.Name");
        redirectProperty(this.txtCashierName, "Text", this.__ttObject, "BondPaymentDocument.ResUser.Name");
        redirectProperty(this.txtDocumentNo, "Text", this.__ttObject, "BondPaymentDocument.DocumentNo");
        redirectProperty(this.dtPickerDocumentDate, "Value", this.__ttObject, "BondPaymentDocument.DocumentDate");
        redirectProperty(this.txtPayeeName, "Text", this.__ttObject, "BondPaymentDocument.PayeeName");
        redirectProperty(this.cbxPaymentType, "Value", this.__ttObject, "BondPaymentDocument.PaymentType");
        redirectProperty(this.txtBankDecountNo, "Text", this.__ttObject, "BondPaymentDocument.BankDecountNo");
        redirectProperty(this.dtPickerBankDecountDate, "Value", this.__ttObject, "BondPaymentDocument.BankDecountDate");
        redirectProperty(this.txtDescription, "Text", this.__ttObject, "Description");
        redirectProperty(this.txtTotalPrice, "Text", this.__ttObject, "TotalPrice");
        redirectProperty(this.txtPaymentPrice, "Text", this.__ttObject, "PaymentPrice");
    }

    public initFormControls(): void {
        this.cbxPaymentType = new TTVisual.TTEnumComboBox();
        this.cbxPaymentType.DataTypeName = "PaymentTypeEnum";
        this.cbxPaymentType.Name = "cbxPaymentType";
        this.cbxPaymentType.TabIndex = 59;
        this.cbxPaymentType.IncludeOnly = [0, 1, 3];

        this.lblPaymentPrice = new TTVisual.TTLabel();
        this.lblPaymentPrice.Text = i18n("M19887", "Ödenen Tutar");
        this.lblPaymentPrice.Name = "lblPaymentPrice";
        this.lblPaymentPrice.TabIndex = 58;

        this.txtPaymentPrice = new TTVisual.TTTextBox();
        this.txtPaymentPrice.BackColor = "#F0F0F0";
        this.txtPaymentPrice.ReadOnly = true;
        this.txtPaymentPrice.Name = "txtPaymentPrice";
        this.txtPaymentPrice.TabIndex = 57;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 55;

        this.txtDescription = new TTVisual.TTTextBox();
        this.txtDescription.Name = "txtDescription";
        this.txtDescription.TabIndex = 52;

        this.txtPayeeName = new TTVisual.TTTextBox();
        this.txtPayeeName.Name = "txtPayeeName";
        this.txtPayeeName.TabIndex = 42;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.TextAlign = HorizontalAlignment.Right;
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 41;

        this.txtDocumentNo = new TTVisual.TTTextBox();
        this.txtDocumentNo.CharacterCasing = CharacterCasing.Upper;
        this.txtDocumentNo.TextAlign = HorizontalAlignment.Right;
        this.txtDocumentNo.BackColor = "#F0F0F0";
        this.txtDocumentNo.ReadOnly = true;
        this.txtDocumentNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtDocumentNo.Name = "txtDocumentNo";
        this.txtDocumentNo.TabIndex = 4;

        this.txtCashierName = new TTVisual.TTTextBox();
        this.txtCashierName.TextAlign = HorizontalAlignment.Right;
        this.txtCashierName.BackColor = "#F0F0F0";
        this.txtCashierName.ReadOnly = true;
        this.txtCashierName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtCashierName.Name = "txtCashierName";
        this.txtCashierName.TabIndex = 1;

        this.txtBankDecountNo = new TTVisual.TTTextBox();
        this.txtBankDecountNo.Name = "txtBankDecountNo";
        this.txtBankDecountNo.TabIndex = 47;

        this.lblTotalPrice = new TTVisual.TTLabel();
        this.lblTotalPrice.Text = i18n("M23526", "Toplam Tutar");
        this.lblTotalPrice.Name = "lblTotalPrice";
        this.lblTotalPrice.TabIndex = 56;

        this.ttgrid1 = new TTVisual.TTGrid();
        this.ttgrid1.Name = "ttgrid1";
        this.ttgrid1.AllowUserToDeleteRows = false;
        this.ttgrid1.AllowUserToResizeColumns = false;
        this.ttgrid1.AllowUserToResizeRows = false;
        this.ttgrid1.AllowUserToAddRows = false;
        this.ttgrid1.AllowUserToDeleteRows = false;
        this.ttgrid1.AllowUserToOrderColumns = false;
        this.ttgrid1.AllowUserToResizeColumns = false;
        this.ttgrid1.AllowUserToResizeRows = false;
        this.ttgrid1.TabIndex = 54;

        this.GRDBONDNO = new TTVisual.TTTextBoxColumn();
        this.GRDBONDNO.DataMember = "BondNo";
        this.GRDBONDNO.DisplayIndex = 0;
        this.GRDBONDNO.HeaderText = i18n("M21606", "Senet No");
        this.GRDBONDNO.Name = "GRDBONDNO";
        this.GRDBONDNO.ReadOnly = true;
        //this.GRDBONDNO.Width = 100;

        this.GRDBONDDETAILDATE = new TTVisual.TTDateTimePickerColumn();
        this.GRDBONDDETAILDATE.DataMember = "BondDetailDate";
        this.GRDBONDDETAILDATE.DisplayIndex = 1;
        this.GRDBONDDETAILDATE.HeaderText = i18n("M24007", "Vade Tarihi");
        this.GRDBONDDETAILDATE.Name = "GRDBONDDETAILDATE";
        this.GRDBONDDETAILDATE.ReadOnly = true;
        //this.GRDBONDDETAILDATE.Width = 100;

        this.GRDPRICE = new TTVisual.TTTextBoxColumn();
        this.GRDPRICE.DataMember = "BondDetailPrice";
        this.GRDPRICE.DisplayIndex = 2;
        this.GRDPRICE.HeaderText = i18n("M23606", "Tutar");
        this.GRDPRICE.Name = "GRDPRICE";
        this.GRDPRICE.ReadOnly = true;
        //this.GRDPRICE.Width = 100;

        this.GRDPAID = new TTVisual.TTCheckBoxColumn();
        this.GRDPAID.DataMember = "Paid";
        this.GRDPAID.DisplayIndex = 3;
        this.GRDPAID.HeaderText = i18n("M19880", "Ödendi");
        this.GRDPAID.Name = "GRDPAID";
        this.GRDPAID.Width = 80;

        this.lblDescription = new TTVisual.TTLabel();
        this.lblDescription.Text = i18n("M10469", "Açıklama");
        this.lblDescription.Name = "lblDescription";
        this.lblDescription.TabIndex = 53;

        this.lblBankDecountDate = new TTVisual.TTLabel();
        this.lblBankDecountDate.Text = i18n("M12547", "Dekont Tarihi");
        this.lblBankDecountDate.Name = "lblBankDecountDate";
        this.lblBankDecountDate.TabIndex = 51;

        this.dtPickerBankDecountDate = new TTVisual.TTDateTimePicker();
        this.dtPickerBankDecountDate.Format = DateTimePickerFormat.Long;
        this.dtPickerBankDecountDate.Name = "dtPickerBankDecountDate";
        this.dtPickerBankDecountDate.TabIndex = 50;

        this.lblBankDeceountNo = new TTVisual.TTLabel();
        this.lblBankDeceountNo.Text = i18n("M12545", "Dekont No");
        this.lblBankDeceountNo.Name = "lblBankDeceountNo";
        this.lblBankDeceountNo.TabIndex = 49;

        this.lblBankAccount = new TTVisual.TTLabel();
        this.lblBankAccount.Text = i18n("M11507", "Banka Hesap Numarası");
        this.lblBankAccount.Name = "lblBankAccount";
        this.lblBankAccount.TabIndex = 48;

        this.lstBoxBankAccount = new TTVisual.TTObjectListBox();
        this.lstBoxBankAccount.ListDefName = "BankAccountListDefinition";
        this.lstBoxBankAccount.Name = "lstBoxBankAccount";
        this.lstBoxBankAccount.TabIndex = 46;

        this.lblPaymentType = new TTVisual.TTLabel();
        this.lblPaymentType.Text = i18n("M19869", "Ödeme Türü");
        this.lblPaymentType.Name = "lblPaymentType";
        this.lblPaymentType.TabIndex = 45;

        this.lblPayeeName = new TTVisual.TTLabel();
        this.lblPayeeName.Text = i18n("M19877", "Ödemeyi Yapan");
        this.lblPayeeName.Name = "lblPayeeName";
        this.lblPayeeName.TabIndex = 43;

        this.lblDocumentNo = new TTVisual.TTLabel();
        this.lblDocumentNo.Text = i18n("M11745", "Belge No");
        this.lblDocumentNo.BackColor = "#DCDCDC";
        this.lblDocumentNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblDocumentNo.ForeColor = "#000000";
        this.lblDocumentNo.Name = "lblDocumentNo";
        this.lblDocumentNo.TabIndex = 16;

        this.lblProcessDate = new TTVisual.TTLabel();
        this.lblProcessDate.Text = i18n("M16886", "İşlem Tarihi");
        this.lblProcessDate.BackColor = "#DCDCDC";
        this.lblProcessDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblProcessDate.ForeColor = "#000000";
        this.lblProcessDate.Name = "lblProcessDate";
        this.lblProcessDate.TabIndex = 20;

        this.lblCashierName = new TTVisual.TTLabel();
        this.lblCashierName.Text = i18n("M16934", "İşlemi Yapan Kullanıcı");
        this.lblCashierName.BackColor = "#DCDCDC";
        this.lblCashierName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblCashierName.ForeColor = "#000000";
        this.lblCashierName.Name = "lblCashierName";
        this.lblCashierName.TabIndex = 8;

        this.lblCashOfficeName = new TTVisual.TTLabel();
        this.lblCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.lblCashOfficeName.BackColor = "#DCDCDC";
        this.lblCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblCashOfficeName.ForeColor = "#000000";
        this.lblCashOfficeName.Name = "lblCashOfficeName";
        this.lblCashOfficeName.TabIndex = 6;

        this.dtPickerDocumentDate = new TTVisual.TTDateTimePicker();
        this.dtPickerDocumentDate.BackColor = "#F0F0F0";
        this.dtPickerDocumentDate.CustomFormat = "";
        this.dtPickerDocumentDate.Format = DateTimePickerFormat.Long;
        this.dtPickerDocumentDate.Enabled = false;
        this.dtPickerDocumentDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.dtPickerDocumentDate.Name = "dtPickerDocumentDate";
        this.dtPickerDocumentDate.TabIndex = 3;

        this.ttgrid1Columns = [this.GRDBONDNO, this.GRDBONDDETAILDATE, this.GRDPRICE, this.GRDPAID];

        this.Controls = [this.cbxPaymentType, this.lblPaymentPrice, this.txtPaymentPrice, this.txtTotalPrice, this.txtDescription, this.txtPayeeName,
        this.tttextbox1, this.txtDocumentNo, this.txtCashierName, this.txtBankDecountNo, this.lblTotalPrice, this.ttgrid1, this.GRDBONDNO, this.GRDBONDDETAILDATE,
        this.GRDPRICE, this.GRDPAID, this.lblDescription, this.lblBankDecountDate, this.dtPickerBankDecountDate, this.lblBankDeceountNo, this.lblBankAccount,
        this.lstBoxBankAccount, this.lblPaymentType, this.lblPayeeName, this.lblDocumentNo, this.lblProcessDate, this.lblCashierName, this.lblCashOfficeName,
        this.dtPickerDocumentDate];

    }
}
