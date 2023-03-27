//$93AA1C6D
import { Component, OnInit, NgZone } from '@angular/core';
import { MainCashOfficeOperationFormViewModel } from "./MainCashOfficeOperationFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { MainCashOfficeOperation } from 'NebulaClient/Model/AtlasClientModel';
import { MainCashOfficePaymentTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PaymentTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptCashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { SubmittedCashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { HorizontalAlignment } from "NebulaClient/Utils/Enums/HorizontalAlignment";
import { CharacterCasing } from "NebulaClient/Utils/Enums/CharacterCasing";
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';


@Component({
    selector: 'MainCashOfficeOperationForm',
    templateUrl: './MainCashOfficeOperationForm.html',
    providers: [MessageService]
})
export class MainCashOfficeOperationForm extends TTVisual.TTForm implements OnInit {
    BANKACCOUNT: TTVisual.ITTObjectListBox;
    BANKDECOUNTDATE: TTVisual.ITTDateTimePicker;
    BANKDECOUNTNO: TTVisual.ITTTextBox;
    CASHIERLOGID: TTVisual.ITTTextBox;
    CASHIERNAME: TTVisual.ITTTextBox;
    //CashierLogsGrid: TTVisual.ITTGrid;
    CASHOFFICE: TTVisual.ITTTextBoxColumn;
    cbxPaymentType: TTVisual.ITTEnumComboBox;
    CLOSINGDATE: TTVisual.ITTDateTimePickerColumn;
    Description: TTVisual.ITTTextBox;
    DOCUMENTDATE: TTVisual.ITTDateTimePicker;
    labelCashOfficeName: TTVisual.ITTLabel;
    lblBankDecountDate: TTVisual.ITTLabel;
    LOGID: TTVisual.ITTTextBoxColumn;
    MONEYRECEIVEDTYPE: TTVisual.ITTObjectListBox;
    OPENINGDATE: TTVisual.ITTDateTimePickerColumn;
    RECEIPTNO: TTVisual.ITTTextBox;
    RECEIPTSPECIALNO: TTVisual.ITTTextBox;
    RESUSER: TTVisual.ITTTextBoxColumn;
    selectedCashOffice: CashOfficeDefinition;
    selectedRCODef: ReceiptCashOfficeDefinition;
    SUBMIT: TTVisual.ITTCheckBoxColumn;
    SUBMITTEDTOTAL: TTVisual.ITTTextBoxColumn;
    TOTALPRICE: TTVisual.ITTTextBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    SUPPLIER: TTVisual.ITTObjectListBox;
    CASHOFFICENAME: TTVisual.ITTTextBox;
    TENDERNAME: TTVisual.ITTTextBox;
    TENDERNO: TTVisual.ITTTextBox;
    PAYEENAME: TTVisual.ITTTextBox;
    //PHONE: TTVisual.ITTTextBox;
    PHONE: TTVisual.ITTMaskedTextBox;
    //PAYEEUNIQUEREFNO: TTVisual.ITTTextBox;
    PAYEEADDRESS: TTVisual.ITTTextBox;
    //
    documentNo: string;
    txtTotalPriceReadOnly: boolean = false;
    txtUniqueRefNoReadOnly = false;
    public showCustomButton = false;
    //phoneReadOnly = false;
    //public CashierLogsGridColumns = [];
    public mainCashOfficeOperationFormViewModel: MainCashOfficeOperationFormViewModel = new MainCashOfficeOperationFormViewModel();
    public get _MainCashOfficeOperation(): MainCashOfficeOperation {
        return this._TTObject as MainCashOfficeOperation;
    }
    private MainCashOfficeOperationForm_DocumentUrl: string = '/api/MainCashOfficeOperationService/MainCashOfficeOperationForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected modalService: IModalService) {
        super("MAINCASHOFFICEOPERATION", "MainCashOfficeOperationForm");
        this._DocumentServiceUrl = this.MainCashOfficeOperationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async cbxPaymentTypeEnum_SelectedIndexChange(): Promise<void> {
        if (this._MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType === PaymentTypeEnum.Bank) {
            this.BANKACCOUNT.ReadOnly = false;
            this.BANKACCOUNT.Enabled = true;
            this.BANKDECOUNTNO.ReadOnly = false;
            this.BANKDECOUNTNO.BackColor = "#FFF";
            this.BANKDECOUNTDATE.ReadOnly = false;
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = null;
        }
        else {
            this.BANKACCOUNT.ReadOnly = true;
            this.BANKACCOUNT.Enabled = false;
            this.BANKDECOUNTNO.ReadOnly = true;
            this.BANKDECOUNTNO.BackColor = "#F0F0F0";
            this.BANKDECOUNTDATE.ReadOnly = true;
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.BankAccount = null;
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountNo = null;
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountDate = null;
            //this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = (await ReceiptCashOfficeDefinitionService.GetCurrentReceiptNumber(this.selectedRCODef));
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = this.documentNo;
        }
    }
    private async MONEYRECEIVEDTYPE_SelectedObjectChanged(): Promise<void> {
        let _myPaymentType: MainCashOfficePaymentTypeDefinition = null;
        _myPaymentType = this._MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType;

        if (_myPaymentType != null && _myPaymentType.IsBankOperation != null && _myPaymentType.IsBankOperation == true) {
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Bank;
            this.cbxPaymentType.ReadOnly = true;
        }
        else {
            //this._MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = PaymentTypeEnum.Cash;
            this.cbxPaymentType.ReadOnly = false;
        }
        this.cbxPaymentTypeEnum_SelectedIndexChange();
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (transDef.ToStateDefID.id === MainCashOfficeOperation.MainCashOfficeOperationStates.Completed.id)
            this.printReport();
    }
    protected async ClientSidePreScript(): Promise<void> {
        if (this._MainCashOfficeOperation.IsNew) {
            this.documentNo = this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo;
            this.cbxPaymentTypeEnum_SelectedIndexChange();
        }
        else {
            this.txtTotalPriceReadOnly = true;
            this.cbxPaymentType.ReadOnly = true;
            this.MONEYRECEIVEDTYPE.Enabled = false;
            this.SUPPLIER.ReadOnly = true;
            this.SUPPLIER.Enabled = false;
            this.BANKACCOUNT.Enabled = false;
            this.BANKDECOUNTDATE.ReadOnly = true;
            this.BANKDECOUNTNO.ReadOnly = true;
            this.Description.ReadOnly = true;
            this.TENDERNAME.ReadOnly = true;
            this.TENDERNO.ReadOnly = true;
            this.PAYEENAME.ReadOnly = true;
            this.PHONE.ReadOnly = true;
            if (this._MainCashOfficeOperation.CurrentStateDefID.valueOf() === MainCashOfficeOperation.MainCashOfficeOperationStates.Completed.id)
                this.showCustomButton = true;
            //this.phoneReadOnly = true;
            this.txtUniqueRefNoReadOnly = true;
            this.PAYEEADDRESS.ReadOnly = true;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {

    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainCashOfficeOperation();
        this.mainCashOfficeOperationFormViewModel = new MainCashOfficeOperationFormViewModel();
        this._ViewModel = this.mainCashOfficeOperationFormViewModel;
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation = this._TTObject as MainCashOfficeOperation;
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument = new CashOfficeReceiptDocument();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.CashOffice = new CashOfficeDefinition();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount = new BankDecount();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.BankAccount = new BankAccountDefinition();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.ResUser = new ResUser();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.CashierLog = new CashierLog();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType = new MainCashOfficePaymentTypeDefinition();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument.Supplier = new Supplier();
        this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.SubmittedCashierLogs = new Array<SubmittedCashierLog>();
    }

    protected loadViewModel() {
        let that = this;
        that.mainCashOfficeOperationFormViewModel = this._ViewModel;
        that._TTObject = this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation;
        if (this.mainCashOfficeOperationFormViewModel == null)
            this.mainCashOfficeOperationFormViewModel = new MainCashOfficeOperationFormViewModel();
        if (this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation == null)
            this.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation = new MainCashOfficeOperation();
        let cashOfficeReceiptDocumentObjectID = that.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation["CashOfficeReceiptDocument"];
        if (cashOfficeReceiptDocumentObjectID != null && (typeof cashOfficeReceiptDocumentObjectID === 'string')) {
            let cashOfficeReceiptDocument = that.mainCashOfficeOperationFormViewModel.CashOfficeReceiptDocuments.find(o => o.ObjectID.toString() === cashOfficeReceiptDocumentObjectID.toString());
            if (cashOfficeReceiptDocument) {
                that.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.CashOfficeReceiptDocument = cashOfficeReceiptDocument;
            }
            if (cashOfficeReceiptDocument != null) {
                let cashOfficeObjectID = cashOfficeReceiptDocument["CashOffice"];
                if (cashOfficeObjectID != null && (typeof cashOfficeObjectID === 'string')) {
                    let cashOffice = that.mainCashOfficeOperationFormViewModel.CashOfficeDefinitions.find(o => o.ObjectID.toString() === cashOfficeObjectID.toString());
                    if (cashOffice) {
                        cashOfficeReceiptDocument.CashOffice = cashOffice;
                    }
                }
            }
            if (cashOfficeReceiptDocument != null) {
                let bankDecountObjectID = cashOfficeReceiptDocument["BankDecount"];
                if (bankDecountObjectID != null && (typeof bankDecountObjectID === 'string')) {
                    let bankDecount = that.mainCashOfficeOperationFormViewModel.BankDecounts.find(o => o.ObjectID.toString() === bankDecountObjectID.toString());
                    if (bankDecount) {
                        cashOfficeReceiptDocument.BankDecount = bankDecount;
                    }
                    if (bankDecount != null) {
                        let bankAccountObjectID = bankDecount["BankAccount"];
                        if (bankAccountObjectID != null && (typeof bankAccountObjectID === 'string')) {
                            let bankAccount = that.mainCashOfficeOperationFormViewModel.BankAccountDefinitions.find(o => o.ObjectID.toString() === bankAccountObjectID.toString());
                            if (bankAccount) {
                                bankDecount.BankAccount = bankAccount;
                            }
                        }
                    }
                }
            }
            if (cashOfficeReceiptDocument != null) {
                let resUserObjectID = cashOfficeReceiptDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.mainCashOfficeOperationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                    if (resUser) {
                        cashOfficeReceiptDocument.ResUser = resUser;
                    }
                }
            }
            if (cashOfficeReceiptDocument != null) {
                let cashierLogObjectID = cashOfficeReceiptDocument["CashierLog"];
                if (cashierLogObjectID != null && (typeof cashierLogObjectID === 'string')) {
                    let cashierLog = that.mainCashOfficeOperationFormViewModel.CashierLogs.find(o => o.ObjectID.toString() === cashierLogObjectID.toString());
                    if (cashierLog) {
                        cashOfficeReceiptDocument.CashierLog = cashierLog;
                    }
                }
            }
            if (cashOfficeReceiptDocument != null) {
                let moneyReceivedTypeObjectID = cashOfficeReceiptDocument["MoneyReceivedType"];
                if (moneyReceivedTypeObjectID != null && (typeof moneyReceivedTypeObjectID === 'string')) {
                    let moneyReceivedType = that.mainCashOfficeOperationFormViewModel.MainCashOfficePaymentTypeDefinitions.find(o => o.ObjectID.toString() === moneyReceivedTypeObjectID.toString());
                    if (moneyReceivedType) {
                        cashOfficeReceiptDocument.MoneyReceivedType = moneyReceivedType;
                    }
                }
            }
            if (cashOfficeReceiptDocument != null) {
                let supplierObjectID = cashOfficeReceiptDocument["Supplier"];
                if (supplierObjectID != null && (typeof supplierObjectID === 'string')) {
                    let supplier = that.mainCashOfficeOperationFormViewModel.Suppliers.find(o => o.ObjectID.toString() === supplierObjectID.toString());
                    if (supplier) {
                        cashOfficeReceiptDocument.Supplier = supplier;
                    }
                }
            }
        }
        //that.mainCashOfficeOperationFormViewModel._MainCashOfficeOperation.SubmittedCashierLogs = that.mainCashOfficeOperationFormViewModel.CashierLogsGridGridList;
        // for (let detailItem of that.mainCashOfficeOperationFormViewModel.CashierLogsGridGridList) {
        //     let cashierLogObjectID = detailItem["CashierLog"];
        //     if (cashierLogObjectID != null && (typeof cashierLogObjectID === 'string')) {
        //         let cashierLog = that.mainCashOfficeOperationFormViewModel.CashierLogs.find(o => o.ObjectID.toString() === cashierLogObjectID.toString());
        //         detailItem.CashierLog = cashierLog;
        //         if (cashierLog != null) {
        //             let cashOfficeObjectID = cashierLog["CashOffice"];
        //             if (cashOfficeObjectID != null && (typeof cashOfficeObjectID === 'string')) {
        //                 let cashOffice = that.mainCashOfficeOperationFormViewModel.CashOfficeDefinitions.find(o => o.ObjectID.toString() === cashOfficeObjectID.toString());
        //                 cashierLog.CashOffice = cashOffice;
        //             }
        //         }
        //         if (cashierLog != null) {
        //             let resUserObjectID = cashierLog["ResUser"];
        //             if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
        //                 let resUser = that.mainCashOfficeOperationFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
        //                 cashierLog.ResUser = resUser;
        //             }
        //         }
        //     }
        // }
    }


    async ngOnInit() {
        let that = this;
        await this.load(MainCashOfficeOperationFormViewModel);

    }


    public onBANKACCOUNTChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.BankAccount != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.BankAccount = event;
            }
        }
    }

    public onBANKDECOUNTDATEChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountDate != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountDate = event;
            }
        }
    }

    public onBANKDECOUNTNOChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountNo != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.DecountNo = event;
            }
        }
    }

    public onCASHIERLOGIDChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashierLog != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashierLog.LogID != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashierLog.LogID = event;
            }
        }
    }

    public onCASHIERNAMEChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.ResUser != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.ResUser.Name != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.ResUser.Name = event;
            }
        }
    }

    public oncbxPaymentTypeChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PaymentType = event;
                this.cbxPaymentTypeEnum_SelectedIndexChange();
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null && this._MainCashOfficeOperation.Description != event) {
                this._MainCashOfficeOperation.Description = event;
            }
        }
    }

    public onDOCUMENTDATEChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentDate != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentDate = event;
            }
        }
    }

    public onMONEYRECEIVEDTYPEChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.MoneyReceivedType = event;
            }
        }
        this.MONEYRECEIVEDTYPE_SelectedObjectChanged();
    }

    public onRECEIPTNOChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.DocumentNo = event;
            }
        }
    }

    public onRECEIPTSPECIALNOChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.SpecialNo != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.SpecialNo = event;
            }
        }
    }

    public onTOTALPRICEChanged(event): void {
        // if (event != null) {
        //     if (this._MainCashOfficeOperation != null && this._MainCashOfficeOperation.TotalPrice != event) {
        //         this._MainCashOfficeOperation.TotalPrice = event;
        //     }
        // }
        if (this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount != null)
            this._MainCashOfficeOperation.CashOfficeReceiptDocument.BankDecount.Price = Math.Round(event.value, 2);
        this._MainCashOfficeOperation.CashOfficeReceiptDocument.TotalPrice = Math.Round(event.value, 2);
    }

    public onSupplierChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.Supplier != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.Supplier = event;
            }
        }
    }

    public onCashOfficeNameChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashOffice != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashOffice.Name != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.CashOffice.Name = event;
            }
        }
    }

    public onTenderNameChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.TenderName != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.TenderName = event;
            }
        }
    }

    public onTenderNoChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.TenderNo != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.TenderNo = event;
            }
        }
    }

    public onPayeeNameChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeName != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeName = event;
            }
        }
    }

    // public onPhoneChanged(event): void {
    //     if (event != null) {
    //         if (this._MainCashOfficeOperation != null &&
    //             this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.Phone != event) {
    //             this._MainCashOfficeOperation.CashOfficeReceiptDocument.Phone = event;
    //         }
    //     }
    // }


    public onMobilePhoneChanged(event): void {

        if (this.mainCashOfficeOperationFormViewModel.CashOfficeReceiptDocuments[0].Phone != event) {
            this.mainCashOfficeOperationFormViewModel.CashOfficeReceiptDocuments[0].Phone = event;
        }
    }

    public onPayeeUniqueRefNoChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeUniqueRefNo != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeUniqueRefNo = event;
            }
        }
    }

    onPayeeAddressChanged(event): void {
        if (event != null) {
            if (this._MainCashOfficeOperation != null &&
                this._MainCashOfficeOperation.CashOfficeReceiptDocument != null && this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeAddress != event) {
                this._MainCashOfficeOperation.CashOfficeReceiptDocument.PayeeAddress = event;
            }
        }
    }

    txtUniqueRefNoKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)))
            event.preventDefault();
    }

    txtPhoneKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    totalPriceKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    // CashierLogsGrid_CellValueChangedEmitted(data: any) {
    //     if (data && this.CashierLogsGrid_CellValueChanged && data.Row && data.Column) {
    //         this.CashierLogsGrid.CurrentCell =
    //             {
    //                 OwningRow: data.Row,
    //                 OwningColumn: data.Column
    //             };
    //         this.CashierLogsGrid_CellValueChanged(data.RowIndex, data.ColIndex);
    //     }
    // }

    protected redirectProperties(): void {
        redirectProperty(this.PAYEENAME, "Text", this.__ttObject, "CashOfficeReceiptDocument.PayeeName");
        redirectProperty(this.PHONE, "Text", this.__ttObject, "CashOfficeReceiptDocument.Phone");
        //redirectProperty(this.PAYEEUNIQUEREFNO, "Text", this.__ttObject, "CashOfficeReceiptDocument.PayeeUniqueRefNo");
        redirectProperty(this.PAYEEADDRESS, "Text", this.__ttObject, "CashOfficeReceiptDocument.PayeeAddress");
        redirectProperty(this.CASHOFFICENAME, "Text", this.__ttObject, "CashOfficeReceiptDocument.CashOffice.Name");
        redirectProperty(this.CASHIERNAME, "Text", this.__ttObject, "CashOfficeReceiptDocument.ResUser.Name");
        redirectProperty(this.RECEIPTNO, "Text", this.__ttObject, "CashOfficeReceiptDocument.DocumentNo");
        redirectProperty(this.DOCUMENTDATE, "Value", this.__ttObject, "CashOfficeReceiptDocument.DocumentDate");
        redirectProperty(this.cbxPaymentType, "Value", this.__ttObject, "CashOfficeReceiptDocument.PaymentType");
        redirectProperty(this.BANKDECOUNTNO, "Text", this.__ttObject, "CashOfficeReceiptDocument.BankDecount.DecountNo");
        redirectProperty(this.BANKDECOUNTDATE, "Value", this.__ttObject, "CashOfficeReceiptDocument.BankDecount.DecountDate");
        redirectProperty(this.TENDERNAME, "Text", this.__ttObject, "CashOfficeReceiptDocument.TenderName");
        redirectProperty(this.TENDERNO, "Text", this.__ttObject, "CashOfficeReceiptDocument.TenderNo");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.TOTALPRICE, "Text", this.__ttObject, "TotalPrice");
        redirectProperty(this.CASHIERLOGID, "Text", this.__ttObject, "CashOfficeReceiptDocument.CashierLog.LogID");
        redirectProperty(this.RECEIPTSPECIALNO, "Text", this.__ttObject, "CashOfficeReceiptDocument.SpecialNo");
    }

    public printReport() {

        let data: DynamicReportParameters = {
            Code: 'CashOfficeReceiptDocumentReportNew',
            ReportParams: { MAINCASHOFFICEOPERATIONOBJECTID: this._MainCashOfficeOperation.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Diğer Tahsilat Makbuzu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public initFormControls(): void {
        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = i18n("M19875", "Ödeme Yapanın");
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 42;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M10553", "Adresi");
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 7;

        this.PAYEEADDRESS = new TTVisual.TTTextBox();
        this.PAYEEADDRESS.Multiline = true;
        this.PAYEEADDRESS.Name = "PAYEEADDRESS";
        this.PAYEEADDRESS.TabIndex = 6;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M22513", "T.C. Kimlik No");
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 5;

        // this.PAYEEUNIQUEREFNO = new TTVisual.TTTextBox();
        // this.PAYEEUNIQUEREFNO.Name = "PAYEEUNIQUEREFNO";
        // this.PAYEEUNIQUEREFNO.TabIndex = 4;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M23147", "Telefonu");
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 3;

        this.PHONE = new TTVisual.TTMaskedTextBox();
        this.PHONE.Mask = "999 9999999";
        this.PHONE.Name = "PHONE";
        this.PHONE.TabIndex = 7;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M10519", "Adı Soyadı/Unvanı");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 1;

        this.PAYEENAME = new TTVisual.TTTextBox();
        this.PAYEENAME.Name = "PAYEENAME";
        this.PAYEENAME.TabIndex = 0;

        this.CASHOFFICENAME = new TTVisual.TTTextBox();
        this.CASHOFFICENAME.TextAlign = HorizontalAlignment.Right;
        this.CASHOFFICENAME.BackColor = "#F0F0F0";
        this.CASHOFFICENAME.ReadOnly = true;
        this.CASHOFFICENAME.Name = "CASHOFFICENAME";
        this.CASHOFFICENAME.TabIndex = 41;

        this.TENDERNO = new TTVisual.TTTextBox();
        this.TENDERNO.Name = "TENDERNO";
        this.TENDERNO.TabIndex = 39;

        this.TENDERNAME = new TTVisual.TTTextBox();
        this.TENDERNAME.Name = "TENDERNAME";
        this.TENDERNAME.TabIndex = 38;

        this.BANKDECOUNTNO = new TTVisual.TTTextBox();
        this.BANKDECOUNTNO.BackColor = "#F0F0F0";
        this.BANKDECOUNTNO.ReadOnly = true;
        this.BANKDECOUNTNO.Name = "BANKDECOUNTNO";
        this.BANKDECOUNTNO.TabIndex = 36;

        this.RECEIPTNO = new TTVisual.TTTextBox();
        this.RECEIPTNO.CharacterCasing = CharacterCasing.Upper;
        this.RECEIPTNO.TextAlign = HorizontalAlignment.Right;
        this.RECEIPTNO.BackColor = "#F0F0F0";
        this.RECEIPTNO.ReadOnly = true;
        this.RECEIPTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTNO.Name = "RECEIPTNO";
        this.RECEIPTNO.TabIndex = 4;

        this.CASHIERNAME = new TTVisual.TTTextBox();
        this.CASHIERNAME.TextAlign = HorizontalAlignment.Right;
        this.CASHIERNAME.BackColor = "#F0F0F0";
        this.CASHIERNAME.ReadOnly = true;
        this.CASHIERNAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERNAME.Name = "CASHIERNAME";
        this.CASHIERNAME.TabIndex = 1;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.CASHIERLOGID = new TTVisual.TTTextBox();
        this.CASHIERLOGID.BackColor = "#F0F0F0";
        this.CASHIERLOGID.ReadOnly = true;
        this.CASHIERLOGID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERLOGID.Name = "CASHIERLOGID";
        this.CASHIERLOGID.TabIndex = 2;
        this.CASHIERLOGID.Visible = false;

        this.RECEIPTSPECIALNO = new TTVisual.TTTextBox();
        this.RECEIPTSPECIALNO.BackColor = "#F0F0F0";
        this.RECEIPTSPECIALNO.ReadOnly = true;
        this.RECEIPTSPECIALNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
        this.RECEIPTSPECIALNO.TabIndex = 5;
        this.RECEIPTSPECIALNO.Visible = false;

        this.TOTALPRICE = new TTVisual.TTTextBox();
        this.TOTALPRICE.Required = true;
        this.TOTALPRICE.BackColor = "#FFE3C6";
        this.TOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TOTALPRICE.Name = "TOTALPRICE";
        this.TOTALPRICE.TabIndex = 20;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = i18n("M16200", "İhale Adı");
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 40;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = i18n("M12545", "Dekont No");
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 37;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M19869", "Ödeme Türü");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 33;

        this.cbxPaymentType = new TTVisual.TTEnumComboBox();
        this.cbxPaymentType.DataTypeName = "PaymentTypeEnum";
        this.cbxPaymentType.IncludeOnly = [0, 1, 3];
        this.cbxPaymentType.Name = "cbxPaymentType";
        this.cbxPaymentType.TabIndex = 32;

        // this.CashierLogsGrid = new TTVisual.TTGrid();
        // this.CashierLogsGrid.AllowUserToDeleteRows = false;
        // this.CashierLogsGrid.Name = "CashierLogsGrid";
        // this.CashierLogsGrid.TabIndex = 19;
        // this.CashierLogsGrid.Visible = false;

        this.LOGID = new TTVisual.TTTextBoxColumn();
        this.LOGID.DataMember = "LogID";
        this.LOGID.DisplayIndex = 0;
        this.LOGID.HeaderText = "Aç.İz Sürme No";
        this.LOGID.Name = "LOGID";
        this.LOGID.ReadOnly = true;
        this.LOGID.Width = 90;

        this.OPENINGDATE = new TTVisual.TTDateTimePickerColumn();
        this.OPENINGDATE.DataMember = "OpeningDate";
        this.OPENINGDATE.DisplayIndex = 1;
        this.OPENINGDATE.HeaderText = i18n("M10486", "Açılış");
        this.OPENINGDATE.Name = "OPENINGDATE";
        this.OPENINGDATE.ReadOnly = true;
        this.OPENINGDATE.Width = 70;

        this.CLOSINGDATE = new TTVisual.TTDateTimePickerColumn();
        this.CLOSINGDATE.DataMember = "ClosingDate";
        this.CLOSINGDATE.DisplayIndex = 2;
        this.CLOSINGDATE.HeaderText = i18n("M17244", "Kapanış");
        this.CLOSINGDATE.Name = "CLOSINGDATE";
        this.CLOSINGDATE.ReadOnly = true;
        this.CLOSINGDATE.Width = 75;

        this.CASHOFFICE = new TTVisual.TTTextBoxColumn();
        this.CASHOFFICE.DataMember = "Name";
        this.CASHOFFICE.DisplayIndex = 3;
        this.CASHOFFICE.HeaderText = i18n("M19269", "Muh.Yetkilisi Mutemetliği");
        this.CASHOFFICE.Name = "CASHOFFICE";
        this.CASHOFFICE.ReadOnly = true;
        this.CASHOFFICE.Width = 200;

        this.RESUSER = new TTVisual.TTTextBoxColumn();
        this.RESUSER.DataMember = "Name";
        this.RESUSER.DisplayIndex = 4;
        this.RESUSER.HeaderText = "Muh.Yetkilisi Mutemedi";
        this.RESUSER.Name = "RESUSER";
        this.RESUSER.ReadOnly = true;
        this.RESUSER.Width = 200;

        this.SUBMITTEDTOTAL = new TTVisual.TTTextBoxColumn();
        this.SUBMITTEDTOTAL.DataMember = "SubmittedTotal";
        this.SUBMITTEDTOTAL.DisplayIndex = 5;
        this.SUBMITTEDTOTAL.HeaderText = i18n("M23606", "Tutar");
        this.SUBMITTEDTOTAL.Name = "SUBMITTEDTOTAL";
        this.SUBMITTEDTOTAL.ReadOnly = true;
        this.SUBMITTEDTOTAL.Width = 80;

        this.SUBMIT = new TTVisual.TTCheckBoxColumn();
        this.SUBMIT.DataMember = "Submit";
        this.SUBMIT.DisplayIndex = 6;
        this.SUBMIT.HeaderText = i18n("M23223", "Teslim");
        this.SUBMIT.Name = "SUBMIT";
        this.SUBMIT.Width = 50;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16895", "İşlem Türü");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 30;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M18485", "Makbuz Seri No");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 16;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M24135", "Vezne Alındı Tarihi");
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

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M24128", "Vezne Açılış İz Sürme No");
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 10;
        this.ttlabel6.Visible = false;

        this.MONEYRECEIVEDTYPE = new TTVisual.TTObjectListBox();
        this.MONEYRECEIVEDTYPE.ListDefName = "MainCashOfficePaymentTypeListDefinition";
        this.MONEYRECEIVEDTYPE.Text = "MONEYRECEIVEDTYPE";
        this.MONEYRECEIVEDTYPE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MONEYRECEIVEDTYPE.Name = "MONEYRECEIVEDTYPE";
        this.MONEYRECEIVEDTYPE.TabIndex = 7;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Tahsilat Tutarı";
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 31;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M24159", "Veznedar");
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 8;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M24134", "Vezne Alındı Özel No");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 18;
        this.ttlabel9.Visible = false;

        this.labelCashOfficeName = new TTVisual.TTLabel();
        this.labelCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.labelCashOfficeName.BackColor = "#DCDCDC";
        this.labelCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashOfficeName.ForeColor = "#000000";
        this.labelCashOfficeName.Name = "labelCashOfficeName";
        this.labelCashOfficeName.TabIndex = 6;

        this.DOCUMENTDATE = new TTVisual.TTDateTimePicker();
        this.DOCUMENTDATE.BackColor = "#F0F0F0";
        this.DOCUMENTDATE.CustomFormat = "";
        this.DOCUMENTDATE.Format = DateTimePickerFormat.Short;
        //this.DOCUMENTDATE.Enabled = false;
        this.DOCUMENTDATE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DOCUMENTDATE.Name = "DOCUMENTDATE";
        this.DOCUMENTDATE.TabIndex = 3;
        this.DOCUMENTDATE.ReadOnly = true;

        this.BANKACCOUNT = new TTVisual.TTObjectListBox();
        this.BANKACCOUNT.ReadOnly = true;
        this.BANKACCOUNT.ListDefName = "BankAccountListDefinition";
        this.BANKACCOUNT.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BANKACCOUNT.Name = "BANKACCOUNT";
        this.BANKACCOUNT.TabIndex = 8;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M11507", "Banka Hesap Numarası");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 30;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M23241", "Teslim Edilen Muhasebe Yetkilisi Mutemetliği Kapama İşlemleri");
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 28;
        this.ttlabel13.Visible = false;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M16214", "İhale No");
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 40;

        this.BANKDECOUNTDATE = new TTVisual.TTDateTimePicker();
        this.BANKDECOUNTDATE.Format = DateTimePickerFormat.Short;
        this.BANKDECOUNTDATE.Name = "BANKDECOUNTDATE";
        this.BANKDECOUNTDATE.TabIndex = 50;

        this.lblBankDecountDate = new TTVisual.TTLabel();
        this.lblBankDecountDate.Text = i18n("M12547", "Dekont Tarihi");
        this.lblBankDecountDate.Name = "lblBankDecountDate";
        this.lblBankDecountDate.TabIndex = 51;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = i18n("M14301", "Firma");
        this.ttlabel19.BackColor = "#DCDCDC";
        this.ttlabel19.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel19.ForeColor = "#000000";
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 30;

        this.SUPPLIER = new TTVisual.TTObjectListBox();
        this.SUPPLIER.ListDefName = "SupplierListDefinition";
        this.SUPPLIER.Text = "MONEYRECEIVEDTYPE";
        this.SUPPLIER.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SUPPLIER.Name = "SUPPLIER";
        this.SUPPLIER.TabIndex = 7;

        //this.CashierLogsGridColumns = [this.LOGID, this.OPENINGDATE, this.CLOSINGDATE, this.CASHOFFICE, this.RESUSER, this.SUBMITTEDTOTAL, this.SUBMIT];
        this.ttgroupbox1.Controls = [this.ttlabel15, this.PAYEEADDRESS, this.ttlabel12, /*this.PAYEEUNIQUEREFNO, this.ttlabel5,*/ this.PHONE, this.ttlabel4, this.PAYEENAME];
        this.Controls = [this.ttgroupbox1, this.ttlabel15, this.PAYEEADDRESS, this.ttlabel12, /*this.PAYEEUNIQUEREFNO, this.ttlabel5*/, this.PHONE, this.ttlabel4, this.PAYEENAME, this.CASHOFFICENAME, this.TENDERNO, this.TENDERNAME, this.BANKDECOUNTNO, this.RECEIPTNO, this.CASHIERNAME, this.Description, this.CASHIERLOGID, this.RECEIPTSPECIALNO, this.TOTALPRICE, this.ttlabel17, this.ttlabel16, this.ttlabel14, this.cbxPaymentType, /*this.CashierLogsGrid,*/ this.LOGID, this.OPENINGDATE, this.CLOSINGDATE, this.CASHOFFICE, this.RESUSER, this.SUBMITTEDTOTAL, this.SUBMIT, this.ttlabel1, this.ttlabel3, this.ttlabel7, this.ttlabel10, this.ttlabel6, this.MONEYRECEIVEDTYPE, this.ttlabel2, this.ttlabel11, this.ttlabel9, this.labelCashOfficeName, this.DOCUMENTDATE, this.BANKACCOUNT, this.ttlabel8, this.ttlabel13, this.ttlabel18, this.ttlabel19, this.SUPPLIER, this.BANKDECOUNTDATE, this.lblBankDecountDate];

    }


}
