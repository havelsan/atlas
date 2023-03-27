//$2429E19F
import { Component, OnInit, NgZone } from '@angular/core';
import { AdvanceFormViewModel } from './AdvanceFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Advance } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeComputerUserDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

@Component({
    selector: 'AdvanceForm',
    templateUrl: './AdvanceForm.html',
    providers: [MessageService]
})
export class AdvanceForm extends TTVisual.TTForm implements OnInit {
    public CASHIERLOGID: TTVisual.ITTTextBox;
    public CASHIERNAME: TTVisual.ITTTextBox;
    public CASHOFFICENAME: TTVisual.ITTTextBox;
    public cashOfficeCompUserList: Array<CashOfficeComputerUserDefinition> = new Array<CashOfficeComputerUserDefinition>();
    //public CREDITCARDDOCUMENTNO: TTVisual.ITTTextBox;
    //public CREDITCARDSPECIALNO: TTVisual.ITTTextBox;
    public Description: TTVisual.ITTTextBox;
    public DOCUMENTDATE: TTVisual.ITTDateTimePicker;
    public labelCashOfficeName: TTVisual.ITTLabel;
    public labelTotalPrice: TTVisual.ITTLabel;
    public PAYEENAME: TTVisual.ITTTextBox;
    public RECEIPTNO: TTVisual.ITTTextBox;
    //public RECEIPTSPECIALNO: TTVisual.ITTTextBox;
    public selectedCashOffice: CashOfficeDefinition;
    //public TOTALPRICE: TTVisual.ITTTextBox;
    txtTotalPaymentReadOnly: boolean = false;
    public ttenumcombobox1: TTVisual.ITTEnumComboBox;
    public ttlabel1: TTVisual.ITTLabel;
    public ttlabel10: TTVisual.ITTLabel;
    public ttlabel14: TTVisual.ITTLabel;
    public ttlabel2: TTVisual.ITTLabel;
    public ttlabel3: TTVisual.ITTLabel;
    public ttlabel4: TTVisual.ITTLabel;
    public ttlabel5: TTVisual.ITTLabel;
    public ttlabel6: TTVisual.ITTLabel;
    public ttlabel7: TTVisual.ITTLabel;
    public ttlabel8: TTVisual.ITTLabel;
    public advanceFormViewModel: AdvanceFormViewModel = new AdvanceFormViewModel();
    public get _Advance(): Advance {
        return this._TTObject as Advance;
    }
    private AdvanceForm_DocumentUrl: string = '/api/AdvanceService/AdvanceForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("ADVANCE", "AdvanceForm");
        this._DocumentServiceUrl = this.AdvanceForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async Update_TotalPrice(): Promise<void> {
        this._Advance.TotalPrice = Convert.ToDouble(this.advanceFormViewModel._Advance.TotalPrice);
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        // this.cashOfficePatientForm.systemApiService.componentInfo = null;
        // this.cashOfficePatientForm.btnSearchPatientClick(true);

        // Nakit ve Kredi Kartı makbuzları dökülür
        /*if (transDef !== null && transDef.ToStateDefID === Advance.AdvanceStates.Paid) {
            if (this._Advance.AdvanceDocument.CashPayment.length > 0) {
                let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
                let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
                cache.push("VALUE", this._Advance.ObjectID.toString());
                parameters.push("TTOBJECTID", cache);
                TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_AdvanceDocumentCashReport, true, 1, parameters);
            }
            if (this._Advance.AdvanceDocument.CreditCardPayments.length > 0) {
                let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
                let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
                cache.push("VALUE", this._Advance.ObjectID.toString());
                parameters.push("TTOBJECTID", cache);
                TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_AdvanceDocumentCreditCardReport, true, 1, parameters);
            }
            if (this._Advance.AdvanceDocument.DebenturePayments.length > 0) {
                let parameters: Dictionary<string, TTReportTool.PropertyCache<Object>> = new Dictionary<string, TTReportTool.PropertyCache<Object>>();
                let cache: TTReportTool.PropertyCache<Object> = new TTReportTool.PropertyCache<Object>();
                cache.push("VALUE", this._Advance.ObjectID.toString());
                parameters.push("TTOBJECTID", cache);
                TTReportTool.TTReport.PrintReport(typeof TTReportClasses.I_AdvanceDebentureReport, true, 1, parameters);
            }
        }*/
    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        if (this._Advance.CurrentStateDefID.valueOf() === Advance.AdvanceStates.New.id) {
            //     let resUser: ResUser = await UserHelper.CurrentResource; /*TTUser.CurrentUser.UserObject as ResUser;*/
            //     this.selectedCashOffice = (await ResUserService.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser));
            //     if (this.selectedCashOffice === undefined)
            //         throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Avans almaya yetikiniz bulunmamaktadır!!");
            //     let receiptCashOfficeDefList: Array<ReceiptCashOfficeDefinition> = (await ReceiptCashOfficeDefinitionService.GetByCashOffice(this.selectedCashOffice.ObjectID.toString()));
            //     //Aktif vezne alındı numarası tanımlanmamış
            //     if (receiptCashOfficeDefList.filter(x => x.IsActive === true).length === 0) {
            //         throw new TTException("Vezne için aktif vezne alındı numarası bulunmamaktadır!");
            //     }
            //     else {
            //         let selectedRCODef: ReceiptCashOfficeDefinition = new ReceiptCashOfficeDefinition();
            //         selectedRCODef = (await ReceiptCashOfficeDefinitionService.GetActiveCashOfficeDefinition(this._Advance.ObjectContext, this.selectedCashOffice.ObjectID)); /*receiptCashOfficeDefList.OrderBy(x => x.OrderNo.Value).Where(x => x.IsActive == true).FirstOrDefault();*/
            //         //this.cmdOK.Visible = false;
            //         this._Advance.CashOfficeName = this.selectedCashOffice.Name;
            //         if (this._Advance.AdvanceDocument === undefined) {
            //             this._Advance.AdvanceDocument = new AdvanceDocument(this._Advance.ObjectContext);
            //             this._Advance.AdvanceDocument.PatientName = this.advanceFormViewModel.Patient.Name;/*this._Advance.Episode.Patient.Name + " " + this._Advance.Episode.Patient.Surname;*/
            //             this._Advance.AdvanceDocument.PatientNo = this.advanceFormViewModel.Patient.ID;/*this._Advance.Episode.Patient.ID.Value;*/
            //             this._Advance.AdvanceDocument.DocumentDate = (await CommonService.RecTime());
            //             this._Advance.AdvanceDocument.PayeeName = this.advanceFormViewModel.Patient.Name + " " +  this.advanceFormViewModel.Patient.Surname; /*this._Advance.Episode.Patient.FullName;*/
            //             this._Advance.AdvanceDocument.ResUser = resUser;
            //             this._Advance.AdvanceDocument.CashOffice = this.selectedCashOffice;
            //             this._Advance.AdvanceDocument.PaymentType = PaymentTypeEnum.Cash;
            //             this._Advance.AdvanceDocument.DocumentNo = (await ReceiptCashOfficeDefinitionService.GetCurrentReceiptNumber(selectedRCODef));
            //         }
            //     }
        }
        else if (this._Advance.CurrentStateDefID === Advance.AdvanceStates.Paid) {
            // if (this._Advance.AdvanceDocument.CashPayment.length === 0)
            //     this.DropCurrentStateReport(typeof TTReportClasses.I_AdvanceDocumentCashReport);
            // if (this._Advance.AdvanceDocument.CreditCardPayments.length === 0)
            //     this.DropCurrentStateReport(typeof TTReportClasses.I_AdvanceDocumentCreditCardReport);
            // if (this._Advance.AdvanceDocument.DebenturePayments.length === 0)
            //     this.DropCurrentStateReport(typeof TTReportClasses.I_AdvanceDebentureReport);
        }
        if (this._Advance.CurrentStateDefID.valueOf() !== Advance.AdvanceStates.New.id) {
            //this.TOTALPRICE.ReadOnly = true;
            this.txtTotalPaymentReadOnly = true;
            this.Description.ReadOnly = true;
            this.DOCUMENTDATE.ReadOnly = true;
            this.PAYEENAME.ReadOnly = true;
            this.ttenumcombobox1.ReadOnly = true;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        this._Advance.AdvanceDocument.TotalPrice = this._Advance.TotalPrice;
        /*if (this._Advance.AdvanceDocument.CreditCardPayments.length === 0)
            this._Advance.AdvanceDocument.CreditCardDocumentNo = null;
        if (this._Advance.AdvanceDocument.CashPayment.length === 0)
            this._Advance.AdvanceDocument.DocumentNo = null;*/
    }
    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Advance();
        this.advanceFormViewModel = new AdvanceFormViewModel();
        this._ViewModel = this.advanceFormViewModel;
        this.advanceFormViewModel._Advance = this._TTObject as Advance;
        this.advanceFormViewModel._Advance.AdvanceDocument = new AdvanceDocument();
        this.advanceFormViewModel._Advance.AdvanceDocument.ResUser = new ResUser();
        this.advanceFormViewModel._Advance.AdvanceDocument.CashierLog = new CashierLog();
    }

    protected loadViewModel() {
     let that = this;

        that.advanceFormViewModel = this._ViewModel as AdvanceFormViewModel;
        that._TTObject = this.advanceFormViewModel._Advance;
        if (this.advanceFormViewModel == null)
            this.advanceFormViewModel = new AdvanceFormViewModel();
        if (this.advanceFormViewModel._Advance == null)
            this.advanceFormViewModel._Advance = new Advance();
        let advanceDocumentObjectID = that.advanceFormViewModel._Advance["AdvanceDocument"];
        if (advanceDocumentObjectID != null && (typeof advanceDocumentObjectID === 'string')) {
            let advanceDocument = that.advanceFormViewModel.AdvanceDocuments.find(o => o.ObjectID.toString() === advanceDocumentObjectID.toString());
             if (advanceDocument) {
                that.advanceFormViewModel._Advance.AdvanceDocument = advanceDocument;
            }
            if (advanceDocument != null) {
                let resUserObjectID = advanceDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.advanceFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                     if (resUser) {
                        advanceDocument.ResUser = resUser;
                    }
                }
            }
            if (advanceDocument != null) {
                let cashierLogObjectID = advanceDocument["CashierLog"];
                if (cashierLogObjectID != null && (typeof cashierLogObjectID === 'string')) {
                    let cashierLog = that.advanceFormViewModel.CashierLogs.find(o => o.ObjectID.toString() === cashierLogObjectID.toString());
                     if (cashierLog) {
                        advanceDocument.CashierLog = cashierLog;
                    }
                }
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(AdvanceFormViewModel);
        this.redirectProperties();
        //$('#paymentType .dx-clear-button-area').css({ display: 'none' })
  
    }

    protected async loadErrorOccurred(err: any) {
        // let error: string = err.Value;
        // if (!error.split('-')[0].Contains('SM2829'))
        //     this.cashOfficePatientForm.systemApiService.componentInfo = null;
    }
    public onCASHIERLOGIDChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null &&
                this._Advance.AdvanceDocument.CashierLog != null && this._Advance.AdvanceDocument.CashierLog.LogID != event) {
                this._Advance.AdvanceDocument.CashierLog.LogID = event;
            }
        }
    }

    public onCASHIERNAMEChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null &&
                this._Advance.AdvanceDocument.ResUser != null && this._Advance.AdvanceDocument.ResUser.Name != event) {
                this._Advance.AdvanceDocument.ResUser.Name = event;
            }
        }
    }

    public onCASHOFFICENAMEChanged(event): void {
        if (event != null) {
            if (this._Advance != null && this._Advance.CashOfficeName != event) {
                this._Advance.CashOfficeName = event;
            }
        }
    }

    // public onCREDITCARDDOCUMENTNOChanged(event): void {
    //     if (event != null) {
    //         if (this._Advance != null &&
    //             this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.CreditCardDocumentNo != event) {
    //             this._Advance.AdvanceDocument.CreditCardDocumentNo = event;
    //         }
    //     }
    // }

    // public onCREDITCARDSPECIALNOChanged(event): void {
    //     if (event != null) {
    //         if (this._Advance != null &&
    //             this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.CreditCardSpecialNo != event) {
    //             this._Advance.AdvanceDocument.CreditCardSpecialNo = event;
    //         }
    //     }
    // }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.Description != event) {
                this._Advance.AdvanceDocument.Description = event;
            }
        }
    }

    public onDOCUMENTDATEChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.DocumentDate != event) {
                this._Advance.AdvanceDocument.DocumentDate = event;
            }
        }
    }

    public onPAYEENAMEChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.PayeeName != event) {
                this._Advance.AdvanceDocument.PayeeName = event;
            }
        }
    }

    public onRECEIPTNOChanged(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.DocumentNo != event) {
                this._Advance.AdvanceDocument.DocumentNo = event;
            }
        }
    }

    // public onRECEIPTSPECIALNOChanged(event): void {
    //     if (event != null) {
    //         if (this._Advance != null &&
    //             this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.SpecialNo != event) {
    //             this._Advance.AdvanceDocument.SpecialNo = event;
    //         }
    //     }
    // }

    public onTOTALPRICEChanged(event): void {
        if (event != null) {
            if (this._Advance != null && this._Advance.TotalPrice != event) {
                // this._Advance.TotalPrice = event;
            }
        }
    }

    public onttenumcombobox1Changed(event): void {
        if (event != null) {
            if (this._Advance != null &&
                this._Advance.AdvanceDocument != null && this._Advance.AdvanceDocument.PaymentType != event) {
                this._Advance.AdvanceDocument.PaymentType = event;
            }
        }
    }


    totalPriceKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    public redirectProperties(): void {
        redirectProperty(this.CASHOFFICENAME, "Text", this.__ttObject, "CashOfficeName");
        redirectProperty(this.CASHIERNAME, "Text", this.__ttObject, "AdvanceDocument.ResUser.Name");
        redirectProperty(this.CASHIERLOGID, "Text", this.__ttObject, "AdvanceDocument.CashierLog.LogID");
        redirectProperty(this.RECEIPTNO, "Text", this.__ttObject, "AdvanceDocument.DocumentNo");
        //redirectProperty(this.RECEIPTSPECIALNO, "Text", this.__ttObject, "AdvanceDocument.SpecialNo");
        //redirectProperty(this.CREDITCARDDOCUMENTNO, "Text", this.__ttObject, "AdvanceDocument.CreditCardDocumentNo");
        //redirectProperty(this.CREDITCARDSPECIALNO, "Text", this.__ttObject, "AdvanceDocument.CreditCardSpecialNo");
        redirectProperty(this.ttenumcombobox1, "Value", this.__ttObject, "AdvanceDocument.PaymentType");
        redirectProperty(this.DOCUMENTDATE, "Value", this.__ttObject, "AdvanceDocument.DocumentDate");
        redirectProperty(this.PAYEENAME, "Text", this.__ttObject, "AdvanceDocument.PayeeName");
        redirectProperty(this.Description, "Text", this.__ttObject, "AdvanceDocument.Description");
        //redirectProperty(this.TOTALPRICE, "Text", this.__ttObject, "TotalPrice");
    }

    public initFormControls(): void {
        this.labelCashOfficeName = new TTVisual.TTLabel();
        this.labelCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.labelCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashOfficeName.ForeColor = "#000000";
        this.labelCashOfficeName.Name = "labelCashOfficeName";
        this.labelCashOfficeName.TabIndex = 5;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Açılış İz Sürme No";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 23;
        this.ttlabel6.Visible = false;

        this.CASHIERNAME = new TTVisual.TTTextBox();
        this.CASHIERNAME.BackColor = "#F0F0F0";
        this.CASHIERNAME.ReadOnly = true;
        this.CASHIERNAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERNAME.Name = "CASHIERNAME";
        this.CASHIERNAME.TabIndex = 1;

        this.PAYEENAME = new TTVisual.TTTextBox();
        this.PAYEENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PAYEENAME.Name = "PAYEENAME";
        this.PAYEENAME.TabIndex = 8;

        this.CASHIERLOGID = new TTVisual.TTTextBox();
        this.CASHIERLOGID.BackColor = "#F0F0F0";
        this.CASHIERLOGID.ReadOnly = true;
        this.CASHIERLOGID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERLOGID.Name = "CASHIERLOGID";
        this.CASHIERLOGID.TabIndex = 2;
        this.CASHIERLOGID.Visible = false;

        // this.CREDITCARDDOCUMENTNO = new TTVisual.TTTextBox();
        // this.CREDITCARDDOCUMENTNO.BackColor = "#F0F0F0";
        // this.CREDITCARDDOCUMENTNO.ReadOnly = true;
        // this.CREDITCARDDOCUMENTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.CREDITCARDDOCUMENTNO.Name = "CREDITCARDDOCUMENTNO";
        // this.CREDITCARDDOCUMENTNO.TabIndex = 5;
        // this.CREDITCARDDOCUMENTNO.Visible = false;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Text = "DESCRIPTION";
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 9;

        this.CASHOFFICENAME = new TTVisual.TTTextBox();
        this.CASHOFFICENAME.BackColor = "#F0F0F0";
        this.CASHOFFICENAME.ReadOnly = true;
        this.CASHOFFICENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHOFFICENAME.Name = "CASHOFFICENAME";
        this.CASHOFFICENAME.TabIndex = 0;

        // this.CREDITCARDSPECIALNO = new TTVisual.TTTextBox();
        // this.CREDITCARDSPECIALNO.BackColor = "#F0F0F0";
        // this.CREDITCARDSPECIALNO.ReadOnly = true;
        // this.CREDITCARDSPECIALNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.CREDITCARDSPECIALNO.Name = "CREDITCARDSPECIALNO";
        // this.CREDITCARDSPECIALNO.TabIndex = 6;
        // this.CREDITCARDSPECIALNO.Visible = false;

        // this.TOTALPRICE = new TTVisual.TTTextBox();
        // this.TOTALPRICE.Text = "TOTALPRICE";
        // this.TOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.TOTALPRICE.Name = "TOTALPRICE";
        // this.TOTALPRICE.TabIndex = 11;

        // this.RECEIPTSPECIALNO = new TTVisual.TTTextBox();
        // this.RECEIPTSPECIALNO.BackColor = "#F0F0F0";
        // this.RECEIPTSPECIALNO.ReadOnly = true;
        // this.RECEIPTSPECIALNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
        // this.RECEIPTSPECIALNO.TabIndex = 4;
        // this.RECEIPTSPECIALNO.Visible = false;

        this.RECEIPTNO = new TTVisual.TTTextBox();
        this.RECEIPTNO.BackColor = "#F0F0F0";
        this.RECEIPTNO.ReadOnly = true;
        this.RECEIPTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTNO.Name = "RECEIPTNO";
        this.RECEIPTNO.TabIndex = 3;

        this.labelTotalPrice = new TTVisual.TTLabel();
        this.labelTotalPrice.Text = i18n("M19887", "Ödenen Tutar");
        this.labelTotalPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTotalPrice.ForeColor = "#000000";
        this.labelTotalPrice.Name = "labelTotalPrice";
        this.labelTotalPrice.TabIndex = 1;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Tarih";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 25;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17854", "Kredi Kartı Alındı No");
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 17;
        this.ttlabel4.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M18485", "Makbuz Seri No");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 13;

        this.DOCUMENTDATE = new TTVisual.TTDateTimePicker();
        this.DOCUMENTDATE.CustomFormat = "dd/MM/yyyy";
        this.DOCUMENTDATE.Format = DateTimePickerFormat.Short;
        this.DOCUMENTDATE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DOCUMENTDATE.Name = "DOCUMENTDATE";
        this.DOCUMENTDATE.TabIndex = 7;
        this.DOCUMENTDATE.ReadOnly = true;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M19870", "Ödeme Yapan Kişi");
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 26;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M17856", "Kredi Kartı Alındı Özel No");
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 19;
        this.ttlabel3.Visible = false;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M10469", "Açıklama");
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 35;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M18482", "Makbuz Özel No");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 15;
        this.ttlabel2.Visible = false;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M24159", "Veznedar");
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 21;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M19865", "Ödeme Tipi");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 36;

        this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox1.DataTypeName = "PaymentTypeEnum";
        this.ttenumcombobox1.Required = true;
        this.ttenumcombobox1.BackColor = "#FFE3C6";
        this.ttenumcombobox1.Name = "ttenumcombobox1";
        this.ttenumcombobox1.IncludeOnly = [0, 1];
        this.ttenumcombobox1.TabIndex = 37;
    }
}
