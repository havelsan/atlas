//$22FF3661
import { Component, OnInit, NgZone } from '@angular/core';
import { ReceiptFormViewModel, DailyRateDefinitionsDTO } from "./ReceiptFormViewModel";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "Fw/Services/MessageService";

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { Episode, DailyRateDefinition, CurrencyTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from "NebulaClient/Utils/Enums/MessageIconEnum";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PaymentTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Receipt } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";

import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { DiscountTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from "NebulaClient/Utils/Enums/DateTimePickerFormat";
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo, IModal } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { CashOfficeFormsService } from 'app/CashOfficeForms/CashOfficeFormsService';


@Component({
    selector: 'ReceiptForm',
    templateUrl: './ReceiptForm.html',
    providers: [MessageService]
})
export class ReceiptForm extends TTVisual.TTForm implements OnInit, IModal {

    private cashOfficeService: CashOfficeFormsService;

    setInputParam(value: any) {
        this.cashOfficeService = value;
        this.CurrencyTypes = value.CurrencyTypes;// as Array<CurrencyTypeDefinition>;
        //this.selectedCurrencyType = this.CurrencyTypes.find(x => x.Qref === 'TL');
    }
    setModalInfo(value: ModalInfo) {

    }

    public showDailyRate = 'hidden';
    //public ConvertedTotalPayment: number;
    public MoneyPaidVisible = true;
    //public minOfMoneyPaid: number;
    //Hastadan Alınan Ücret
    //public moneyPaid: number;
    //Para üzeri
    //public remainderOfMoney: number;
    public moneyPaidFormat = "#,##0.## TL";
    public CurrencyTypes: Array<CurrencyTypeDefinition>;
    public selectedCurrencyType: CurrencyTypeDefinition;
    public selectedCurrencyRate?: DailyRateDefinitionsDTO;
    public currencyTypeReadOnly = true;
    BUTTONDISCOUNT: TTVisual.ITTButton;
    CASHIERLOGID: TTVisual.ITTTextBox;
    CASHIERNAME: TTVisual.ITTTextBox;
    CASHOFFICENAME: TTVisual.ITTTextBox;
    cbxPaymentType: TTVisual.ITTEnumComboBox;
    CREDITCARDDOCUMENTNO: TTVisual.ITTTextBox;
    CREDITCARDSPECIALNO: TTVisual.ITTTextBox;
    DISCOUNTTYPE: TTVisual.ITTObjectListBox;
    DOCUMENTDATE: TTVisual.ITTDateTimePicker;
    GENERALTOTALPRICE: TTVisual.ITTTextBox;
    //GRIDReceiptMaterials: TTVisual.ITTGrid;
    GRIDReceiptProcedures: TTVisual.ITTGrid;
    labelCashOfficeName: TTVisual.ITTLabel;
    labelTotalPrice: TTVisual.ITTLabel;
    MACTIONDATE: TTVisual.ITTDateTimePickerColumn;
    MAMOUNT: TTVisual.ITTTextBoxColumn;
    MDESCRIPTION: TTVisual.ITTTextBoxColumn;
    MEXTERNALCODE: TTVisual.ITTTextBoxColumn;
    MPAID: TTVisual.ITTCheckBoxColumn;
    MPAYMENTPRICE: TTVisual.ITTTextBoxColumn;
    MREMAININGPRICE: TTVisual.ITTTextBoxColumn;
    //MTOTALDISCOUNTEDPRICE: TTVisual.ITTTextBoxColumn;
    //MTOTALDISCOUNTPRICE: TTVisual.ITTTextBoxColumn;
    MTOTALPRICE: TTVisual.ITTTextBoxColumn;
    MUNITPRICE: TTVisual.ITTTextBoxColumn;
    PACTIONDATE: TTVisual.ITTDateTimePickerColumn;
    PAMOUNT: TTVisual.ITTTextBoxColumn;
    PATIENTNAME: TTVisual.ITTTextBox;
    PAYEENAME: TTVisual.ITTTextBox;
    PDESCRIPTION: TTVisual.ITTTextBoxColumn;
    PEXTERNALCODE: TTVisual.ITTTextBoxColumn;
    PPAID: TTVisual.ITTCheckBoxColumn;
    PPAYMENTPRICE: TTVisual.ITTTextBoxColumn;
    PREMAININGPRICE: TTVisual.ITTTextBoxColumn;
    PREVENUETYPE: TTVisual.ITTTextBoxColumn;
    //PTOTALDISCOUNTEDPRICE: TTVisual.ITTTextBoxColumn;
    //PTOTALDISCOUNTPRICE: TTVisual.ITTTextBoxColumn;
    PTOTALPRICE: TTVisual.ITTTextBoxColumn;
    PUNITPRICE: TTVisual.ITTTextBoxColumn;
    RECEIPTNO: TTVisual.ITTTextBox;
    RECEIPTSPECIALNO: TTVisual.ITTTextBox;
    //selectedCashOffice: CashOfficeDefinition;
    TOTALDISCOUNTENTRY: TTVisual.ITTTextBox;
    //TOTALDISCOUNTPRICE: TTVisual.ITTTextBox;
    totalRemainingPrice: number = 0;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    //tttabcontrol1: TTVisual.ITTTabControl;
    //tttabpage1: TTVisual.ITTTabPage;
    //tttabpage2: TTVisual.ITTTabPage;
    tttextbox1: TTVisual.ITTTextBox;
    //txtTotalPayment: TTVisual.ITTTextBox;
    txtTotalPaymentReadOnly: boolean = false;
    txtTotalPrice: TTVisual.ITTTextBox;
    UNDETAILEDREPORT: TTVisual.ITTCheckBox;
    //public GRIDReceiptMaterialsColumns = [];
    public GRIDReceiptProceduresColumns = [];
    public GRIDReceiptProceduresColumns2 = [];
    public saveCommandVisible = false;
    public showCustomButton = false;
    /*dx-data-grid için*/
    checkBoxAllowEditing = true;
    public receiptFormViewModel: ReceiptFormViewModel = new ReceiptFormViewModel();
    public get _Receipt(): Receipt {
        return this._TTObject as Receipt;
    }
    private ReceiptForm_DocumentUrl: string = '/api/ReceiptService/ReceiptForm';


    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone,
        protected modalService: IModalService) {
        super("RECEIPT", "ReceiptForm");
        this._DocumentServiceUrl = this.ReceiptForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    // private async GRIDReceiptMaterials_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
    //     if (columnIndex === 8)
    //         this.CalculateSelectedProcsAndMatsPrice();
    // }
    private async GRIDReceiptProcedures_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (columnIndex === 9)
            this.CalculateSelectedProcsAndMatsPrice();
    }
    //  GRIDReceiptMaterials_CellValueChangedEmitted(data: any) {
    //     if (data && this.GRIDReceiptMaterials_CellValueChanged && data.Row && data.Column) {
    //         this.GRIDReceiptMaterials.CurrentCell =
    //             {
    //                 OwningRow: data.Row,
    //                 OwningColumn: data.Column
    //             };
    //         this.GRIDReceiptMaterials_CellValueChanged(data.RowIndex, data.ColIndex);
    //     }
    // }

    GRIDReceiptProcedures_CellValueChangedEmitted(data: any) {
        if (data && this.GRIDReceiptProcedures_CellValueChanged && data.Row && data.Column) {
            this.GRIDReceiptProcedures.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.GRIDReceiptProcedures_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (transDef != null && transDef.ToStateDefID != null && transDef.ToStateDefID.id === Receipt.ReceiptStates.Paid.id)
            this.printReport();
    }

    public printReport() {

        let data: DynamicReportParameters = {
            Code: 'ReceiptDetailedReportNew',
            ReportParams: { RECEIPTOBJECTID: this._Receipt.ObjectID },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Vezne Makbuzu"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public async setStateChange(e: FormSaveInfo) {

        if (this.receiptFormViewModel.SelectedCurrencyTypeDefinition == null) {
            ServiceLocator.MessageService.showError('Lütfen döviz türü seçiniz!');
            return;
        }

        if (this.selectedCurrencyType.Qref != 'TL' && (this.receiptFormViewModel.MoneyPaid != null && this.receiptFormViewModel.MoneyPaid <= 0) || this.receiptFormViewModel.MoneyPaid == null) {
            ServiceLocator.MessageService.showError('Dövizle yapılan ödemelerde Alınan Tutar (yani hastadan alınan döviz) miktarını girmek zorunludur.');
            return;
        }
        if (this.receiptFormViewModel.MoneyPaid <= 0 || Math.Round(this.receiptFormViewModel.MoneyPaid * this.selectedCurrencyRate.DailyRate, 2) < this.receiptFormViewModel._Receipt.TotalPayment) {
            ServiceLocator.MessageService.showError('Alınan Tutar alanı sıfırdan büyük, Ödenen Tutar alanından ise eşit veya büyük olmalıdır.');
            return;
        }

        if (this.receiptFormViewModel.RemainderOfMoney < 0) {
            ServiceLocator.MessageService.showError('Para Üstü alanı sıfır ya da sıfırdan büyük olmalıdır.');
            return;
        }

        let paymentTypeString = '';
        if (this._Receipt.ReceiptDocument.PaymentType == PaymentTypeEnum._Cash.ordinal)
            paymentTypeString = i18n("M19411", "Nakit");
        else
            paymentTypeString = i18n("M17853", "Kredi Kartı");
        let qref = this.selectedCurrencyRate.Qref;
        if (e.transDef.ToStateDefID.valueOf() === Receipt.ReceiptStates.Paid.id) {
            let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '',
                '<b>Para Üzeri:' + this.receiptFormViewModel.RemainderOfMoney + ' TL' + '<br> </b>' +
                '<b>Alınan Tutar:' + this.receiptFormViewModel.MoneyPaid + ' ' + qref + ' </b><br><br>' +
                this._Receipt.ReceiptDocument.PayeeName + i18n("M10521", " adına ") + this.receiptFormViewModel._Receipt.TotalPayment + 'TL tutarında ' + paymentTypeString + i18n("M19857", " ödeme makbuzu kesilecektir. Onaylıyor musunuz?"));
            if (result === "OK")
                await super.setState(e.transDef, e);
        }
        else if (e.transDef.ToStateDefID.valueOf() === Receipt.ReceiptStates.Cancelled.id) {
            let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', this._Receipt.ReceiptDocument.DocumentNo + i18n("M19520", " numaralı makbuzu iptal etmek istediğinize emin misiniz?"));
            if (result === "OK")
                await super.setState(e.transDef, e);
        }
        // else if (true) {

        // }
        // else
        //     super.setState(e);
    }

    protected async ClientSidePreScript(): Promise<void> {
        //$('nestatepanelcomponent > div.row > div.col-lg-10').css({"padding-left":"29px","margin-bottom": "10px"})
        super.ClientSidePreScript();
        if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.New.id) {
            if (this.receiptFormViewModel._Receipt.AdvanceTaken > this.receiptFormViewModel._Receipt.TotalPrice) {
                this.PPAID.ReadOnly = true;
                this.PAYEENAME.ReadOnly = true;
                this.cbxPaymentType.ReadOnly = true;
                this.txtTotalPaymentReadOnly = true;
                //this.txtTotalPayment.ReadOnly = true;
                this.DOCUMENTDATE.ReadOnly = true;
            }
        }
        else {
            this.BUTTONDISCOUNT.ReadOnly = true;
            this.PPAID.ReadOnly = true;
            this.PAYEENAME.ReadOnly = true;
            if (!this.receiptFormViewModel.HasRoleToChangePaymentTpye) {
                this.cbxPaymentType.ReadOnly = true;
            }
            else if (this.receiptFormViewModel.SelectedCurrencyTypeDefinition != this.CurrencyTypes.find(x => x.Qref === 'TL').ObjectID) {
                this.cbxPaymentType.ReadOnly = true;
            }
            else {
                if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.Paid.id)
                    this.saveCommandVisible = true;
                if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.Cancelled.id)
                    this.cbxPaymentType.ReadOnly = true;
            }
            if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.Paid.id)
                this.showCustomButton = true;
            this.txtTotalPaymentReadOnly = true;
            //this.txtTotalPayment.ReadOnly = true;
            this.DOCUMENTDATE.ReadOnly = true;

            //dx-data-grid için
            this.checkBoxAllowEditing = false;
            this.genrateColumns();
            //this.Grid.instance.repaint();
            
            //if (this._Receipt.ReceiptDocument.CashPayment.Count == 0)
            //{
            //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptReport));
            //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptDetailedReport));
            //}

            //if (this._Receipt.ReceiptDocument.CreditCardPayments.Count == 0)
            //{
            //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptCreditCardReport));
            //    this.DropCurrentStateReport(typeof(TTReportClasses.I_ReceiptCreditCardDetailedReport));
            //}

            /*if (this._Receipt.UnDetailedReport === true) {
                this.DropCurrentStateReport(typeof TTReportClasses.I_ReceiptDetailedReport);
                this.DropCurrentStateReport(typeof TTReportClasses.I_ReceiptCreditCardDetailedReport);
            }*/
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {

    }
    protected async PreScript() {

    }
    vTotalPrice: number = 0;
    public async CalculateSelectedProcsAndMatsPrice(): Promise<void> {
        this.vTotalPrice = 0;
        if (this._Receipt.ReceiptProcedures.length !== 0) {
            for (let rp of this._Receipt.ReceiptProcedures.filter(x => x.Paid == true)) {
                this.vTotalPrice += Math.Round(rp.RemainingPrice.Value, 2);
            }
        }
        // if (this._Receipt.ReceiptMaterials.length !== 0) {
        //     for (let rm of this._Receipt.ReceiptMaterials) {
        //         if (rm.Paid === true) {
        //             vTotalPrice += Number(rm.RemainingPrice.Value);
        //         }
        //     }
        // }
        if (this.vTotalPrice > Convert.ToDouble(this._Receipt.AdvanceTaken)) {
            //this._Receipt.TotalPrice = vTotalPrice - this._Receipt.AdvanceTaken;
            this._Receipt.TotalPayment = this.vTotalPrice - this._Receipt.AdvanceTaken;
        }
        else {
            //TTVisual.InfoBox.Alert("Hastadan alınan avans toplamı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız, Seçilmeyen Hizmet/Malzeme var ise seçiniz ya da Avans İade yapınız!", MessageIconEnum.ErrorMessage);
            this.UpdatePaymentPrices(0);
        }
    }
    public async IsChildHasUnpaidCharge(): Promise<void> {
        let msg: string = "\"\"";
        for (let child of this._Receipt.Episode.Patient.Child) {
            for (let episode of child.Episodes) {
                //todo bg
                /*
                if (episode.PatientAdmission.AdmissionType.Value === AdmissionTypeEnum.NewBorn) {
                    for (let accTrx of (await EpisodeService.GetTransactionsForReceipt(this._Receipt.Episode))) { msg += child.FullName + "     " + episode.OpeningDate + "\n"; }
                }*/
            }
        }
        if (!String.isNullOrEmpty(msg))
            TTVisual.InfoBox.Alert(i18n("M15437", "Hastanın çocuklarının aşağıdaki gelişlerinde ödenmemiş hizmet/malzeme vardır! :\n") + msg, MessageIconEnum.InformationMessage);
    }
    public async UpdatePaymentPrices(totalPayment: number): Promise<void> {
        if (totalPayment > 0) {
            for (let rp of this._Receipt.ReceiptProcedures) {
                if (rp.Paid === true) {
                    if (rp.RemainingPrice <= totalPayment) {
                        totalPayment -= Math.Round(rp.RemainingPrice.Value, 2);
                        rp.PaymentPrice = Math.Round(rp.RemainingPrice.Value, 2);
                    }
                    else {
                        if (totalPayment > 0) {
                            rp.PaymentPrice = Math.Round(totalPayment, 2);
                            totalPayment = 0;
                        }
                        else {
                            rp.PaymentPrice = 0;
                        }
                    }
                }
                else rp.PaymentPrice = 0;
            }
            // for (let rm of this._Receipt.ReceiptMaterials) {
            //     if (rm.Paid === true) {
            //         if (rm.RemainingPrice <= totalPayment) {
            //             totalPayment -= rm.RemainingPrice.Value;
            //             rm.PaymentPrice = rm.RemainingPrice.Value;
            //         }
            //         else {
            //             if (totalPayment > 0) {
            //                 rm.PaymentPrice = totalPayment;
            //                 totalPayment = 0;
            //             }
            //             else {
            //                 rm.PaymentPrice = 0
            //             };
            //         }
            //     }
            //     else rm.PaymentPrice = 0;
            // }
        }
        else
            this._Receipt.TotalPayment = 0;

        this._Receipt.TotalPayment = Math.Round(this._Receipt.TotalPayment, 2);
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Receipt();
        this.receiptFormViewModel = new ReceiptFormViewModel();
        this._ViewModel = this.receiptFormViewModel;
        this.receiptFormViewModel._Receipt = this._TTObject as Receipt;
        this.receiptFormViewModel._Receipt.Episode = new Episode();
        this.receiptFormViewModel._Receipt.Episode.Patient = new Patient();
        this.receiptFormViewModel._Receipt.ReceiptDocument = new ReceiptDocument();
        this.receiptFormViewModel._Receipt.ReceiptDocument.ResUser = new ResUser();
        this.receiptFormViewModel._Receipt.ReceiptDocument.CashierLog = new CashierLog();
        this.receiptFormViewModel._Receipt.DiscountTypeDefinition = new DiscountTypeDefinition();
        this.receiptFormViewModel._Receipt.ReceiptProcedures = new Array<ReceiptProcedure>();
        this.receiptFormViewModel._Receipt.ReceiptMaterials = new Array<ReceiptMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.receiptFormViewModel = this._ViewModel as ReceiptFormViewModel;
        that._TTObject = this.receiptFormViewModel._Receipt;
        if (this.receiptFormViewModel == null)
            this.receiptFormViewModel = new ReceiptFormViewModel();
        if (this.receiptFormViewModel._Receipt == null)
            this.receiptFormViewModel._Receipt = new Receipt();
        let episodeObjectID = that.receiptFormViewModel._Receipt["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            //let episode = that.receiptFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            //that.receiptFormViewModel._Receipt.Episode = episode;
            if (that.receiptFormViewModel._Receipt.Episode != null) {
                let patientObjectID = that.receiptFormViewModel._Receipt.Episode["Patient"];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.receiptFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        that.receiptFormViewModel._Receipt.Episode.Patient = patient;
                    }
                }
            }
        }
        let receiptDocumentObjectID = that.receiptFormViewModel._Receipt["ReceiptDocument"];
        if (receiptDocumentObjectID != null && (typeof receiptDocumentObjectID === 'string')) {
            let receiptDocument = that.receiptFormViewModel.ReceiptDocuments.find(o => o.ObjectID.toString() === receiptDocumentObjectID.toString());
            if (receiptDocument) {
                that.receiptFormViewModel._Receipt.ReceiptDocument = receiptDocument;
            }
            if (receiptDocument != null) {
                let resUserObjectID = receiptDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.receiptFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                    if (resUser) {
                        receiptDocument.ResUser = resUser;
                    }
                }
            }
            if (receiptDocument != null) {
                let cashierLogObjectID = receiptDocument["CashierLog"];
                if (cashierLogObjectID != null && (typeof cashierLogObjectID === 'string')) {
                    let cashierLog = that.receiptFormViewModel.CashierLogs.find(o => o.ObjectID.toString() === cashierLogObjectID.toString());
                    if (cashierLog) {
                        receiptDocument.CashierLog = cashierLog;
                    }
                }
            }
        }
        let discountTypeDefinitionObjectID = that.receiptFormViewModel._Receipt["DiscountTypeDefinition"];
        if (discountTypeDefinitionObjectID != null && (typeof discountTypeDefinitionObjectID === 'string')) {
            let discountTypeDefinition = that.receiptFormViewModel.DiscountTypeDefinitions.find(o => o.ObjectID.toString() === discountTypeDefinitionObjectID.toString());
            if (discountTypeDefinition) {
                that.receiptFormViewModel._Receipt.DiscountTypeDefinition = discountTypeDefinition;
            }
        }
        that.receiptFormViewModel._Receipt.ReceiptProcedures = that.receiptFormViewModel.GRIDReceiptProceduresGridList;
        that.selectedCurrencyRate = that.receiptFormViewModel.SelectedCurrencyRate;
        that.selectedCurrencyType = that.CurrencyTypes.find(x => x.ObjectID == that.receiptFormViewModel.SelectedCurrencyTypeDefinition);
        // for (let detailItem of that.receiptFormViewModel.GRIDReceiptProceduresGridList) {
        // }
        // that.receiptFormViewModel._Receipt.ReceiptMaterials = that.receiptFormViewModel.GRIDReceiptMaterialsGridList;
        // for (let detailItem of that.receiptFormViewModel.GRIDReceiptMaterialsGridList) {
        // }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ReceiptFormViewModel);

    }

    async loadErrorOccurred(err: any) {
        //this.cashOfficePatientForm.systemApiService.componentInfo = null;
    }


    totalPaymentKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            event.preventDefault();
    }

    // private txtTotalPayment_TextChanged() {
    //     if (Math.Round(this._Receipt.TotalPayment, 2) > Math.Round(this._Receipt.TotalPrice, 2))
    //         this.receiptFormViewModel._Receipt.TotalPayment = Math.Round(this._Receipt.TotalPrice, 2);
    //     //throw new TTException("Hastadan alınan avans ve girilen miktarın toplamı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız. Seçilmeyen hizmet/malzeme varsa seçiniz ya da daha az bir tutar giriniz!");
    //     else
    //         this.UpdatePaymentPrices(Math.Round(this._Receipt.TotalPayment, 2) + Math.Round(this._Receipt.AdvanceTaken.Value, 2));
    // }

    public async ontxtTotalPaymentValueChanged(event: any): Promise<void> {
        if (event != null) {
            // if (this._Receipt != null && this._Receipt.TotalPayment != event) {
            //     this._Receipt.TotalPayment = event;
            // }
            if (this._Receipt != null && this._Receipt.TotalPayment !== undefined && this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.New.id) {
                //this.txtTotalPayment_TextChanged();
                if (Math.Round(this.receiptFormViewModel._Receipt.TotalPayment, 2) > Math.Round(this._Receipt.TotalPrice, 2))
                    this.receiptFormViewModel._Receipt.TotalPayment = Math.Round(this._Receipt.TotalPrice, 2);
                else
                    this.receiptFormViewModel._Receipt.TotalPayment = Math.Round(event.value, 2);
                //throw new TTException("Hastadan alınan avans ve girilen miktarın toplamı, ödenmemiş hizmet/malzeme toplamından fazladır. Makbuz kesme işlemini tamamlayamazsınız. Seçilmeyen hizmet/malzeme varsa seçiniz ya da daha az bir tutar giriniz!");
                if (this.selectedCurrencyRate != null) {
                    this.receiptFormViewModel.ConvertedTotalPayment = Math.Round(this.receiptFormViewModel._Receipt.TotalPayment / this.selectedCurrencyRate.DailyRate, 4);
                    this.cashOfficeService.ChangeMoneyPaid(this.receiptFormViewModel, this.receiptFormViewModel.ConvertedTotalPayment, this.selectedCurrencyType)

                    // if (this.selectedCurrencyType != null && this.selectedCurrencyType.Qref === 'TL')
                    //     this.receiptFormViewModel.MoneyPaid = this.receiptFormViewModel.ConvertedTotalPayment;
                    // else
                    //     this.receiptFormViewModel.MoneyPaid = null;
                    this.receiptFormViewModel.RemainderOfMoney = this.cashOfficeService.CalculateRemainderOfMoney(this.receiptFormViewModel.MoneyPaid, this.selectedCurrencyRate.DailyRate, this.receiptFormViewModel._Receipt.TotalPayment, this.receiptFormViewModel._Receipt.AdvanceTaken);
                }
                this.UpdatePaymentPrices(Math.Round(this._Receipt.TotalPayment, 2) + Math.Round(this._Receipt.AdvanceTaken.Value, 2));
            }
        }
    }

    public onCASHIERLOGIDChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null &&
                this._Receipt.ReceiptDocument.CashierLog != null && this._Receipt.ReceiptDocument.CashierLog.LogID != event) {
                this._Receipt.ReceiptDocument.CashierLog.LogID = event;
            }
        }
    }

    public onCASHIERNAMEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null &&
                this._Receipt.ReceiptDocument.ResUser != null && this._Receipt.ReceiptDocument.ResUser.Name != event) {
                this._Receipt.ReceiptDocument.ResUser.Name = event;
            }
        }
    }

    public onCASHOFFICENAMEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.CashOfficeName != event) {
                this._Receipt.CashOfficeName = event;
            }
        }
    }

    public oncbxPaymentTypeChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.PaymentType != event) {
                this._Receipt.ReceiptDocument.PaymentType = event;
            }
            if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.New.id) {
                if (this._Receipt.ReceiptDocument.PaymentType == PaymentTypeEnum.CreditCard) {
                    this.currencyTypeReadOnly = true;
                    this.MoneyPaidVisible = false;
                    this.cashOfficeService.ChangeMoneyPaid(this.receiptFormViewModel, this.receiptFormViewModel.ConvertedTotalPayment, this.selectedCurrencyType)

                    // if (this.selectedCurrencyType != null && this.selectedCurrencyType.Qref === 'TL')
                    //     this.receiptFormViewModel.MoneyPaid = this.receiptFormViewModel.ConvertedTotalPayment;
                    // else
                    //     this.receiptFormViewModel.MoneyPaid = null;
                    this.receiptFormViewModel.RemainderOfMoney = 0;
                }
                else {
                    this.currencyTypeReadOnly = false;
                    this.MoneyPaidVisible = true;
                }

                this.receiptFormViewModel.SelectedCurrencyTypeDefinition = this.CurrencyTypes.find(x => x.Qref === 'TL').ObjectID;
            }
        }
    }

    public SetMoneyFormat(rate: DailyRateDefinition.GetDailyRateDefinitions_Class) {
        this.moneyPaidFormat = '#,##0.##' + ' ' + rate.Qref;
    }

    public async onCurrencyTypeValueChanged(event: any) {

        if (event.value != null && event.value != Guid.Empty) {
            this.selectedCurrencyType = this.CurrencyTypes.find(x => x.ObjectID == event.value);
            let res = await this.cashOfficeService.GetCurrecnyValue(this.selectedCurrencyType.Qref).then(res => {
                if (res != null) {
                    this.SetMoneyFormat(res);
                    if (res.Qref === 'TL')
                        this.showDailyRate = 'hidden';
                    else
                        this.showDailyRate = 'visible';
                    if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.New.id) {
                        this.selectedCurrencyRate = res;
                        this.receiptFormViewModel.DailyRateDefinition = res.ObjectID;
                        this.receiptFormViewModel.ConvertedTotalPayment = Math.Round(this.receiptFormViewModel._Receipt.TotalPayment / res.DailyRate, 4);
                        this.cashOfficeService.ChangeMoneyPaid(this.receiptFormViewModel, this.receiptFormViewModel.ConvertedTotalPayment, this.selectedCurrencyType)

                        // if (this.selectedCurrencyType.Qref != 'TL')
                        //     this.receiptFormViewModel.MoneyPaid = null;
                        // else
                        //     this.receiptFormViewModel.MoneyPaid = this.receiptFormViewModel.ConvertedTotalPayment;
                        this.receiptFormViewModel.RemainderOfMoney = this.cashOfficeService.CalculateRemainderOfMoney(this.receiptFormViewModel.MoneyPaid, res.DailyRate, this.receiptFormViewModel._Receipt.TotalPayment, this.receiptFormViewModel._Receipt.AdvanceTaken)
                    }
                }
            }).catch(err => {
                ServiceLocator.MessageService.showError(err);
                this.receiptFormViewModel.SelectedCurrencyTypeDefinition = null;
            });
        }
    }

    // public setMinOfMoneyPaid() {
    //     this.minOfMoneyPaid = Math.Round(this.receiptFormViewModel._Receipt.TotalPayment / this.selectedCurrencyRate.DailyRate, 4);
    // }

    public onMoneyPaidValueChanged(event: any) {
        if (this._Receipt.CurrentStateDefID.valueOf() === Receipt.ReceiptStates.New.id) {
            if (event.value != null)
                this.receiptFormViewModel.RemainderOfMoney = this.cashOfficeService.CalculateRemainderOfMoney(event.value, this.selectedCurrencyRate.DailyRate, this.receiptFormViewModel._Receipt.TotalPayment, this.receiptFormViewModel._Receipt.AdvanceTaken);
            else if (event.value == null)
                this.receiptFormViewModel.RemainderOfMoney = null;
        }
    }

    public onCREDITCARDDOCUMENTNOChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.CreditCardDocumentNo != event) {
                this._Receipt.ReceiptDocument.CreditCardDocumentNo = event;
            }
        }
    }

    public onCREDITCARDSPECIALNOChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.CreditCardSpecialNo != event) {
                this._Receipt.ReceiptDocument.CreditCardSpecialNo = event;
            }
        }
    }

    public onDISCOUNTTYPEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.DiscountTypeDefinition != event) {
                this._Receipt.DiscountTypeDefinition = event;
            }
        }
    }

    public onDOCUMENTDATEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.DocumentDate != event) {
                this._Receipt.ReceiptDocument.DocumentDate = event;
            }
        }
    }

    public onGENERALTOTALPRICEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.GeneralTotalPrice != event) {
                this._Receipt.GeneralTotalPrice = event;
            }
        }
    }

    public onPATIENTNAMEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.Episode != null &&
                this._Receipt.Episode.Patient != null && this._Receipt.Episode.Patient.Name != event) {
                this._Receipt.Episode.Patient.Name = event;
            }
        }
    }

    public onPAYEENAMEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.PayeeName != event) {
                this._Receipt.ReceiptDocument.PayeeName = event;
            }
        }
    }

    public onRECEIPTNOChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.DocumentNo != event) {
                this._Receipt.ReceiptDocument.DocumentNo = event;
            }
        }
    }

    public onRECEIPTSPECIALNOChanged(event): void {
        if (event != null) {
            if (this._Receipt != null &&
                this._Receipt.ReceiptDocument != null && this._Receipt.ReceiptDocument.SpecialNo != event) {
                this._Receipt.ReceiptDocument.SpecialNo = event;
            }
        }
    }

    public onTOTALDISCOUNTENTRYChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.TotalDiscountEntry != event) {
                this._Receipt.TotalDiscountEntry = event;
            }
        }
    }

    public onTOTALDISCOUNTPRICEChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.TotalDiscountPrice != event) {
                this._Receipt.TotalDiscountPrice = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.AdvanceTaken != event) {
                this._Receipt.AdvanceTaken = event;
            }
        }
    }

    public ontxtTotalPriceChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.TotalPrice != event) {
                this._Receipt.TotalPrice = event;
            }
        }
    }

    public onUNDETAILEDREPORTChanged(event): void {
        if (event != null) {
            if (this._Receipt != null && this._Receipt.UnDetailedReport != event) {
                this._Receipt.UnDetailedReport = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.UNDETAILEDREPORT, "Value", this.__ttObject, "UnDetailedReport");
        redirectProperty(this.CASHOFFICENAME, "Text", this.__ttObject, "CashOfficeName");
        redirectProperty(this.CASHIERNAME, "Text", this.__ttObject, "ReceiptDocument.ResUser.Name");
        redirectProperty(this.PAYEENAME, "Text", this.__ttObject, "ReceiptDocument.PayeeName");
        redirectProperty(this.RECEIPTNO, "Text", this.__ttObject, "ReceiptDocument.DocumentNo");
        redirectProperty(this.cbxPaymentType, "Value", this.__ttObject, "ReceiptDocument.PaymentType");
        redirectProperty(this.DOCUMENTDATE, "Value", this.__ttObject, "ReceiptDocument.DocumentDate");
        redirectProperty(this.CREDITCARDDOCUMENTNO, "Text", this.__ttObject, "ReceiptDocument.CreditCardDocumentNo");
        redirectProperty(this.CREDITCARDSPECIALNO, "Text", this.__ttObject, "ReceiptDocument.CreditCardSpecialNo");
        redirectProperty(this.TOTALDISCOUNTENTRY, "Text", this.__ttObject, "TotalDiscountEntry");
        redirectProperty(this.CASHIERLOGID, "Text", this.__ttObject, "ReceiptDocument.CashierLog.LogID");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "AdvanceTaken");
        //redirectProperty(this.TOTALDISCOUNTPRICE, "Text", this.__ttObject, "TotalDiscountPrice");
        redirectProperty(this.GENERALTOTALPRICE, "Text", this.__ttObject, "GeneralTotalPrice");
        redirectProperty(this.txtTotalPrice, "Text", this.__ttObject, "TotalPrice");
        redirectProperty(this.PATIENTNAME, "Text", this.__ttObject, "Episode.Patient.Name");
        //redirectProperty(this.txtTotalPayment, "Text", this.__ttObject, "TotalPayment");
        redirectProperty(this.RECEIPTSPECIALNO, "Text", this.__ttObject, "ReceiptDocument.SpecialNo");
    }

    public initFormControls(): void {
        this.PATIENTNAME = new TTVisual.TTTextBox();
        this.PATIENTNAME.Name = "PATIENTNAME";
        this.PATIENTNAME.TabIndex = 38;
        this.PATIENTNAME.Visible = false;

        this.TOTALDISCOUNTENTRY = new TTVisual.TTTextBox();
        this.TOTALDISCOUNTENTRY.Name = "TOTALDISCOUNTENTRY";
        this.TOTALDISCOUNTENTRY.TabIndex = 10;
        this.TOTALDISCOUNTENTRY.Visible = false;

        this.GENERALTOTALPRICE = new TTVisual.TTTextBox();
        this.GENERALTOTALPRICE.Text = "GENERALTOTALPRICE";
        this.GENERALTOTALPRICE.BackColor = "#F0F0F0";
        this.GENERALTOTALPRICE.ReadOnly = true;
        this.GENERALTOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
        this.GENERALTOTALPRICE.TabIndex = 26;
        this.GENERALTOTALPRICE.Visible = false;

        //this.TOTALDISCOUNTPRICE = new TTVisual.TTTextBox();
        //this.TOTALDISCOUNTPRICE.Text = "TOTALDISCOUNTPRICE";
        //this.TOTALDISCOUNTPRICE.BackColor = "#F0F0F0";
        //this.TOTALDISCOUNTPRICE.ReadOnly = true;
        //this.TOTALDISCOUNTPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
        //this.TOTALDISCOUNTPRICE.TabIndex = 25;
        //this.TOTALDISCOUNTPRICE.Visible = false;

        this.CREDITCARDDOCUMENTNO = new TTVisual.TTTextBox();
        this.CREDITCARDDOCUMENTNO.BackColor = "#F0F0F0";
        this.CREDITCARDDOCUMENTNO.ReadOnly = true;
        this.CREDITCARDDOCUMENTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CREDITCARDDOCUMENTNO.Name = "CREDITCARDDOCUMENTNO";
        this.CREDITCARDDOCUMENTNO.TabIndex = 5;
        this.CREDITCARDDOCUMENTNO.Visible = false;

        this.CASHIERNAME = new TTVisual.TTTextBox();
        this.CASHIERNAME.BackColor = "#F0F0F0";
        this.CASHIERNAME.ReadOnly = true;
        this.CASHIERNAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERNAME.Name = "CASHIERNAME";
        this.CASHIERNAME.TabIndex = 1;

        this.txtTotalPrice = new TTVisual.TTTextBox();
        this.txtTotalPrice.Text = "TOTALPRICE";
        this.txtTotalPrice.BackColor = "#F0F0F0";
        this.txtTotalPrice.ReadOnly = true;
        this.txtTotalPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtTotalPrice.Name = "txtTotalPrice";
        this.txtTotalPrice.TabIndex = 0;

        this.RECEIPTSPECIALNO = new TTVisual.TTTextBox();
        this.RECEIPTSPECIALNO.BackColor = "#F0F0F0";
        this.RECEIPTSPECIALNO.ReadOnly = true;
        this.RECEIPTSPECIALNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
        this.RECEIPTSPECIALNO.TabIndex = 4;
        this.RECEIPTSPECIALNO.Visible = false;

        this.PAYEENAME = new TTVisual.TTTextBox();
        this.PAYEENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PAYEENAME.Name = "PAYEENAME";
        this.PAYEENAME.TabIndex = 8;

        this.CREDITCARDSPECIALNO = new TTVisual.TTTextBox();
        this.CREDITCARDSPECIALNO.BackColor = "#F0F0F0";
        this.CREDITCARDSPECIALNO.ReadOnly = true;
        this.CREDITCARDSPECIALNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CREDITCARDSPECIALNO.Name = "CREDITCARDSPECIALNO";
        this.CREDITCARDSPECIALNO.TabIndex = 6;
        this.CREDITCARDSPECIALNO.Visible = false;

        this.CASHIERLOGID = new TTVisual.TTTextBox();
        this.CASHIERLOGID.BackColor = "#F0F0F0";
        this.CASHIERLOGID.ReadOnly = true;
        this.CASHIERLOGID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERLOGID.Name = "CASHIERLOGID";
        this.CASHIERLOGID.TabIndex = 2;
        this.CASHIERLOGID.Visible = false;

        this.RECEIPTNO = new TTVisual.TTTextBox();
        this.RECEIPTNO.BackColor = "#F0F0F0";
        this.RECEIPTNO.ReadOnly = true;
        this.RECEIPTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTNO.Name = "RECEIPTNO";
        this.RECEIPTNO.TabIndex = 3;

        this.CASHOFFICENAME = new TTVisual.TTTextBox();
        this.CASHOFFICENAME.BackColor = "#F0F0F0";
        this.CASHOFFICENAME.ReadOnly = true;
        this.CASHOFFICENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHOFFICENAME.Name = "CASHOFFICENAME";
        this.CASHOFFICENAME.TabIndex = 0;

        this.cbxPaymentType = new TTVisual.TTEnumComboBox();
        this.cbxPaymentType.DataTypeName = "PaymentTypeEnum";
        this.cbxPaymentType.Required = true;
        this.cbxPaymentType.BackColor = "#FFE3C6";
        this.cbxPaymentType.Name = "cbxPaymentType";
        this.cbxPaymentType.IncludeOnly = [0, 1];
        this.cbxPaymentType.TabIndex = 37;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = i18n("M19865", "Ödeme Tipi");
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 36;

        this.UNDETAILEDREPORT = new TTVisual.TTCheckBox();
        this.UNDETAILEDREPORT.Value = false;
        this.UNDETAILEDREPORT.Text = i18n("M18491", "Makbuzu Detaysız Dök");
        this.UNDETAILEDREPORT.Name = "UNDETAILEDREPORT";
        this.UNDETAILEDREPORT.TabIndex = 34;
        this.UNDETAILEDREPORT.Visible = false;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = i18n("M16488", "İndirilecek Tutar");
        this.ttlabel12.BackColor = "#DCDCDC";
        this.ttlabel12.ForeColor = "#000000";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 29;
        this.ttlabel12.Visible = false;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M16507", "İndirimli Tutar");
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 24;
        this.ttlabel10.Visible = false;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16489", "İndirim");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 23;
        this.ttlabel2.Visible = false;

        this.BUTTONDISCOUNT = new TTVisual.TTButton();
        this.BUTTONDISCOUNT.BackColor = "#DCDCDC";
        this.BUTTONDISCOUNT.Text = i18n("M16502", "İndirim Uygula");
        this.BUTTONDISCOUNT.Name = "BUTTONDISCOUNT";
        this.BUTTONDISCOUNT.TabIndex = 11;
        this.BUTTONDISCOUNT.Visible = false;

        this.DISCOUNTTYPE = new TTVisual.TTObjectListBox();
        this.DISCOUNTTYPE.ListDefName = "DiscountTypeListDefinition";
        this.DISCOUNTTYPE.Name = "DISCOUNTTYPE";
        this.DISCOUNTTYPE.TabIndex = 9;
        this.DISCOUNTTYPE.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16493", "İndirim Tipi");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 20;
        this.ttlabel1.Visible = false;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "Tarih";
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 14;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = i18n("M17856", "Kredi Kartı Alındı Özel No");
        this.ttlabel5.BackColor = "#DCDCDC";
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 12;
        this.ttlabel5.Visible = false;

        this.labelCashOfficeName = new TTVisual.TTLabel();
        this.labelCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.labelCashOfficeName.BackColor = "#DCDCDC";
        this.labelCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashOfficeName.ForeColor = "#000000";
        this.labelCashOfficeName.Name = "labelCashOfficeName";
        this.labelCashOfficeName.TabIndex = 0;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M18485", "Makbuz Seri No");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 6;

        this.labelTotalPrice = new TTVisual.TTLabel();
        this.labelTotalPrice.Text = i18n("M23526", "Toplam Tutar");
        this.labelTotalPrice.BackColor = "#DCDCDC";
        this.labelTotalPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTotalPrice.ForeColor = "#000000";
        this.labelTotalPrice.Name = "labelTotalPrice";
        this.labelTotalPrice.TabIndex = 1;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M24159", "Veznedar");
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 2;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Açılış İz Sürme No";
        this.ttlabel6.BackColor = "#DCDCDC";
        this.ttlabel6.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.ForeColor = "#000000";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 4;
        this.ttlabel6.Visible = false;

        this.DOCUMENTDATE = new TTVisual.TTDateTimePicker();
        this.DOCUMENTDATE.CustomFormat = "";
        this.DOCUMENTDATE.Format = DateTimePickerFormat.Short;
        this.DOCUMENTDATE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DOCUMENTDATE.Name = "DOCUMENTDATE";
        this.DOCUMENTDATE.TabIndex = 7;
        this.DOCUMENTDATE.CustomFormat = "dd/MM/yyyy";
        this.DOCUMENTDATE.ReadOnly = true;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M19870", "Ödeme Yapan Kişi");
        this.ttlabel8.BackColor = "#DCDCDC";
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 16;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M17854", "Kredi Kartı Alındı No");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 10;
        this.ttlabel4.Visible = false;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M18482", "Makbuz Özel No");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 8;
        this.ttlabel9.Visible = false;

        // this.tttabcontrol1 = new TTVisual.TTTabControl();
        // this.tttabcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.tttabcontrol1.Name = "tttabcontrol1";
        // this.tttabcontrol1.TabIndex = 12;

        // this.tttabpage1 = new TTVisual.TTTabPage();
        // this.tttabpage1.DisplayIndex = 0;
        // this.tttabpage1.BackColor = "#FFFFFF";
        // this.tttabpage1.TabIndex = 0;
        // this.tttabpage1.Text = "Verilen Hizmetler";
        // this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.tttabpage1.Name = "tttabpage1";

        this.GRIDReceiptProcedures = new TTVisual.TTGrid();
        this.GRIDReceiptProcedures.AllowUserToDeleteRows = false;
        this.GRIDReceiptProcedures.AllowUserToOrderColumns = true;
        this.GRIDReceiptProcedures.AllowUserToResizeRows = false;
        this.GRIDReceiptProcedures.AllowUserToAddRows = false;
        this.GRIDReceiptProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GRIDReceiptProcedures.Name = "GRIDReceiptProcedures";
        this.GRIDReceiptProcedures.TabIndex = 49;
        this.GRIDReceiptProcedures.Height = "80%";

        this.PACTIONDATE = new TTVisual.TTDateTimePickerColumn();
        this.PACTIONDATE.Format = DateTimePickerFormat.Custom;
        this.PACTIONDATE.CustomFormat = "dd.MM.yyyy";
        this.PACTIONDATE.DataMember = "ActionDate";
        this.PACTIONDATE.DisplayIndex = 0;
        this.PACTIONDATE.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.PACTIONDATE.Name = "PACTIONDATE";
        this.PACTIONDATE.ReadOnly = true;
        this.PACTIONDATE.Width = '10%';

        this.PEXTERNALCODE = new TTVisual.TTTextBoxColumn();
        this.PEXTERNALCODE.DataMember = "ExternalCode";
        this.PEXTERNALCODE.DisplayIndex = 1;
        this.PEXTERNALCODE.HeaderText = "Kodu";
        this.PEXTERNALCODE.Name = "PEXTERNALCODE";
        this.PEXTERNALCODE.ReadOnly = true;
        this.PEXTERNALCODE.Width = '10%';

        this.PDESCRIPTION = new TTVisual.TTTextBoxColumn();
        this.PDESCRIPTION.DataMember = "Description";
        this.PDESCRIPTION.DisplayIndex = 2;
        this.PDESCRIPTION.HeaderText = i18n("M10514", "Adı");
        this.PDESCRIPTION.Name = "PDESCRIPTION";
        this.PDESCRIPTION.ReadOnly = true;
        this.PDESCRIPTION.Width = '34%';

        this.PREVENUETYPE = new TTVisual.TTTextBoxColumn();
        this.PREVENUETYPE.DataMember = "RevenueType";
        this.PREVENUETYPE.DisplayIndex = 3;
        this.PREVENUETYPE.HeaderText = i18n("M14657", "Gelir Türü");
        this.PREVENUETYPE.Name = "PREVENUETYPE";
        this.PREVENUETYPE.ReadOnly = true;
        this.PREVENUETYPE.Visible = false;
        //this.PREVENUETYPE.Width = 120;

        this.PAMOUNT = new TTVisual.TTTextBoxColumn();
        this.PAMOUNT.DataMember = "Amount";
        this.PAMOUNT.DisplayIndex = 4;
        this.PAMOUNT.HeaderText = i18n("M10505", "Adet");
        this.PAMOUNT.Name = "PAMOUNT";
        this.PAMOUNT.ReadOnly = true;
        this.PAMOUNT.Width = '5%';

        this.PUNITPRICE = new TTVisual.TTTextBoxColumn();
        this.PUNITPRICE.DataMember = "UnitPrice";
        this.PUNITPRICE.DisplayIndex = 5;
        this.PUNITPRICE.HeaderText = i18n("M11855", "Birim Fiyat");
        this.PUNITPRICE.Name = "PUNITPRICE";
        this.PUNITPRICE.ReadOnly = true;
        this.PUNITPRICE.Width = '8%';

        this.PTOTALPRICE = new TTVisual.TTTextBoxColumn();
        this.PTOTALPRICE.DataMember = "TotalPrice";
        this.PTOTALPRICE.DisplayIndex = 6;
        this.PTOTALPRICE.HeaderText = i18n("M23491", "Toplam Fiyat");
        this.PTOTALPRICE.Name = "PTOTALPRICE";
        this.PTOTALPRICE.ReadOnly = true;
        this.PTOTALPRICE.Width = '8%';

        this.PREMAININGPRICE = new TTVisual.TTTextBoxColumn();
        this.PREMAININGPRICE.DataMember = "RemainingPrice";
        this.PREMAININGPRICE.DisplayIndex = 7;
        this.PREMAININGPRICE.HeaderText = i18n("M17087", "Kalan Tutar");
        this.PREMAININGPRICE.Name = "PREMAININGPRICE";
        this.PREMAININGPRICE.ReadOnly = true;
        this.PREMAININGPRICE.Width = '8%';

        this.PPAYMENTPRICE = new TTVisual.TTTextBoxColumn();
        this.PPAYMENTPRICE.DataMember = "PaymentPrice";
        this.PPAYMENTPRICE.DisplayIndex = 8;
        this.PPAYMENTPRICE.HeaderText = i18n("M19887", "Ödenen Tutar");
        this.PPAYMENTPRICE.Name = "PPAYMENTPRICE";
        this.PPAYMENTPRICE.ReadOnly = true;
        this.PPAYMENTPRICE.Width = '10%';

        this.PPAID = new TTVisual.TTCheckBoxColumn();
        this.PPAID.DataMember = "Paid";
        this.PPAID.DisplayIndex = 9;
        this.PPAID.HeaderText = i18n("M19881", "Ödenecek");
        this.PPAID.Name = "PPAID";
        this.PPAID.Width = '7%';

        //this.PTOTALDISCOUNTEDPRICE = new TTVisual.TTTextBoxColumn();
        //this.PTOTALDISCOUNTEDPRICE.DataMember = "TotalDiscountedPrice";
        //this.PTOTALDISCOUNTEDPRICE.DisplayIndex = 10;
        //this.PTOTALDISCOUNTEDPRICE.HeaderText = "İnd.Topl. Fiyat";
        //this.PTOTALDISCOUNTEDPRICE.Name = "PTOTALDISCOUNTEDPRICE";
        //this.PTOTALDISCOUNTEDPRICE.ReadOnly = true;
        //this.PTOTALDISCOUNTEDPRICE.Visible = false;
        //this.PTOTALDISCOUNTEDPRICE.Width = 80;

        //this.PTOTALDISCOUNTPRICE = new TTVisual.TTTextBoxColumn();
        //this.PTOTALDISCOUNTPRICE.DataMember = "TotalDiscountPrice";
        //this.PTOTALDISCOUNTPRICE.DisplayIndex = 11;
        //this.PTOTALDISCOUNTPRICE.HeaderText = "İndirim Tutarı";
        //this.PTOTALDISCOUNTPRICE.Name = "PTOTALDISCOUNTPRICE";
        //this.PTOTALDISCOUNTPRICE.ReadOnly = true;
        //this.PTOTALDISCOUNTPRICE.Visible = false;
        //this.PTOTALDISCOUNTPRICE.Width = 100;

        // this.tttabpage2 = new TTVisual.TTTabPage();
        // this.tttabpage2.DisplayIndex = 0;
        // this.tttabpage2.BackColor = "#FFFFFF";
        // this.tttabpage2.TabIndex = 0;
        // this.tttabpage2.Text = "Verilen İlaç/Malzemeler";
        // this.tttabpage2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.tttabpage2.Name = "tttabpage2";

        // this.GRIDReceiptMaterials = new TTVisual.TTGrid();
        // this.GRIDReceiptMaterials.AllowUserToDeleteRows = false;
        // this.GRIDReceiptMaterials.AllowUserToOrderColumns = true;
        // this.GRIDReceiptMaterials.AllowUserToResizeRows = false;
        // this.GRIDReceiptMaterials.AllowUserToAddRows = false;
        // this.GRIDReceiptMaterials.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.GRIDReceiptMaterials.Name = "GRIDReceiptMaterials";
        // this.GRIDReceiptMaterials.TabIndex = 0;

        this.MACTIONDATE = new TTVisual.TTDateTimePickerColumn();
        this.MACTIONDATE.Format = DateTimePickerFormat.Custom;
        this.MACTIONDATE.CustomFormat = "dd.MM.yyyy";
        this.MACTIONDATE.DataMember = "ActionDate";
        this.MACTIONDATE.DisplayIndex = 0;
        this.MACTIONDATE.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.MACTIONDATE.Name = "MACTIONDATE";
        this.MACTIONDATE.ReadOnly = true;
        //this.MACTIONDATE.Width = 120;

        this.MEXTERNALCODE = new TTVisual.TTTextBoxColumn();
        this.MEXTERNALCODE.DataMember = "ExternalCode";
        this.MEXTERNALCODE.DisplayIndex = 1;
        this.MEXTERNALCODE.HeaderText = "İlaç/Malzeme Kodu";
        this.MEXTERNALCODE.Name = "MEXTERNALCODE";
        this.MEXTERNALCODE.ReadOnly = true;
        //this.MEXTERNALCODE.Width = 110;

        this.MDESCRIPTION = new TTVisual.TTTextBoxColumn();
        this.MDESCRIPTION.DataMember = "Description";
        this.MDESCRIPTION.DisplayIndex = 2;
        this.MDESCRIPTION.HeaderText = "İlaç/Malzeme Adı";
        this.MDESCRIPTION.Name = "MDESCRIPTION";
        this.MDESCRIPTION.ReadOnly = true;
        //this.MDESCRIPTION.Width = 250;

        this.MAMOUNT = new TTVisual.TTTextBoxColumn();
        this.MAMOUNT.DataMember = "Amount";
        this.MAMOUNT.DisplayIndex = 3;
        this.MAMOUNT.HeaderText = i18n("M10505", "Adet");
        this.MAMOUNT.Name = "MAMOUNT";
        this.MAMOUNT.ReadOnly = true;
        //this.MAMOUNT.Width = 40;

        this.MUNITPRICE = new TTVisual.TTTextBoxColumn();
        this.MUNITPRICE.DataMember = "UnitPrice";
        this.MUNITPRICE.DisplayIndex = 4;
        this.MUNITPRICE.HeaderText = i18n("M11855", "Birim Fiyat");
        this.MUNITPRICE.Name = "MUNITPRICE";
        this.MUNITPRICE.ReadOnly = true;
        //this.MUNITPRICE.Width = 80;

        this.MTOTALPRICE = new TTVisual.TTTextBoxColumn();
        this.MTOTALPRICE.DataMember = "TotalPrice";
        this.MTOTALPRICE.DisplayIndex = 5;
        this.MTOTALPRICE.HeaderText = i18n("M23491", "Toplam Fiyat");
        this.MTOTALPRICE.Name = "MTOTALPRICE";
        this.MTOTALPRICE.ReadOnly = true;
        //this.MTOTALPRICE.Width = 80;

        this.MREMAININGPRICE = new TTVisual.TTTextBoxColumn();
        this.MREMAININGPRICE.DataMember = "RemainingPrice";
        this.MREMAININGPRICE.DisplayIndex = 6;
        this.MREMAININGPRICE.HeaderText = i18n("M17087", "Kalan Tutar");
        this.MREMAININGPRICE.Name = "MREMAININGPRICE";
        this.MREMAININGPRICE.ReadOnly = true;
        //this.MREMAININGPRICE.Width = 100;

        this.MPAYMENTPRICE = new TTVisual.TTTextBoxColumn();
        this.MPAYMENTPRICE.DataMember = "PaymentPrice";
        this.MPAYMENTPRICE.DisplayIndex = 7;
        this.MPAYMENTPRICE.HeaderText = i18n("M19884", "Ödenecek Tutar");
        this.MPAYMENTPRICE.Name = "MPAYMENTPRICE";
        this.MPAYMENTPRICE.ReadOnly = true;
        //this.MPAYMENTPRICE.Width = 100;

        this.MPAID = new TTVisual.TTCheckBoxColumn();
        this.MPAID.DataMember = "Paid";
        this.MPAID.DisplayIndex = 8;
        this.MPAID.HeaderText = i18n("M19881", "Ödenecek");
        this.MPAID.Name = "MPAID";
        //this.MPAID.Width = 60;

        //this.MTOTALDISCOUNTEDPRICE = new TTVisual.TTTextBoxColumn();
        //this.MTOTALDISCOUNTEDPRICE.DataMember = "TotalDiscountedPrice";
        //this.MTOTALDISCOUNTEDPRICE.DisplayIndex = 9;
        //this.MTOTALDISCOUNTEDPRICE.HeaderText = "İnd.Topl.Fiyat";
        //this.MTOTALDISCOUNTEDPRICE.Name = "MTOTALDISCOUNTEDPRICE";
        //this.MTOTALDISCOUNTEDPRICE.ReadOnly = true;
        //this.MTOTALDISCOUNTEDPRICE.Visible = false;
        //this.MTOTALDISCOUNTEDPRICE.Width = 80;

        //this.MTOTALDISCOUNTPRICE = new TTVisual.TTTextBoxColumn();
        //this.MTOTALDISCOUNTPRICE.DataMember = "TotalDiscountPrice";
        //this.MTOTALDISCOUNTPRICE.DisplayIndex = 10;
        //this.MTOTALDISCOUNTPRICE.HeaderText = "Toplam Indirim Tutarı";
        //this.MTOTALDISCOUNTPRICE.Name = "MTOTALDISCOUNTPRICE";
        //this.MTOTALDISCOUNTPRICE.ReadOnly = true;
        //this.MTOTALDISCOUNTPRICE.Visible = false;
        //this.MTOTALDISCOUNTPRICE.Width = 100;

        // this.txtTotalPayment = new TTVisual.TTTextBox();
        // this.txtTotalPayment.Required = true;
        // this.txtTotalPayment.BackColor = "#FFE3C6";
        // this.txtTotalPayment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.txtTotalPayment.Name = "txtTotalPayment";
        // this.txtTotalPayment.TabIndex = 32;
        this.txtTotalPaymentReadOnly = false;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = "#F0F0F0";
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 32;

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = i18n("M19887", "Ödenen Tutar");
        this.ttlabel15.BackColor = "#DCDCDC";
        this.ttlabel15.ForeColor = "#000000";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 31;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = i18n("M10720", "Alınmış Avanslar");
        this.ttlabel13.BackColor = "#DCDCDC";
        this.ttlabel13.ForeColor = "#000000";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 31;

        this.GRIDReceiptProceduresColumns = [this.PACTIONDATE, this.PEXTERNALCODE, this.PDESCRIPTION, this.PREVENUETYPE, this.PAMOUNT, this.PUNITPRICE, this.PTOTALPRICE, this.PREMAININGPRICE, this.PPAYMENTPRICE, this.PPAID, /*this.PTOTALDISCOUNTEDPRICE, this.PTOTALDISCOUNTPRICE*/]; //this.GRIDReceiptMaterialsColumns = [this.MACTIONDATE, this.MEXTERNALCODE, this.MDESCRIPTION, this.MAMOUNT, this.MUNITPRICE, this.MTOTALPRICE, this.MREMAININGPRICE, this.MPAYMENTPRICE, this.MPAID, /*this.MTOTALDISCOUNTEDPRICE, this.MTOTALDISCOUNTPRICE*/];
        /* dx-data-grid içinthis.genrateColumns();*/
        this.genrateColumns();
    }
    //dx-data-grid için
    genrateColumns() {
        let that = this;
        that.GRIDReceiptProceduresColumns2 = [

            {
                caption: 'Ödenecek',
                dataField: 'ActionDate',
                allowEditing: false,
                dataType: 'date',
                format: 'dd/MM/yyyy'
            },
            {
                caption: 'Kodu',
                dataField: 'ExternalCode',
                allowEditing: false,
            },
            {
                caption: 'Adı',
                dataField: 'Description',
                allowEditing: false,
                width: 250
            },
            {
                caption: 'Adet',
                dataField: 'Amount',
                allowEditing: false,
            },
            {
                caption: 'Birim Fiyat',
                dataField: 'UnitPrice',
                allowEditing: false,
            },
            {
                caption: 'Toplam Fiyat',
                dataField: 'TotalPrice',
                allowEditing: false,
            },
            {
                caption: 'Kalan Tutar',
                dataField: 'RemainingPrice',
                allowEditing: false,
            },
            {
                caption: 'Ödenen Tutar',
                dataField: 'PaymentPrice',
                allowEditing: false,
            },
            {
                caption: 'Ödenecek',
                dataField: 'Paid',
                //allowEditing: false,
                //cellTemplate: 'checkBoxTemplateCell',
                allowSorting: false,
                allowEditing: this.checkBoxAllowEditing
            },
        ];
    }
    grdProcOnRowUpdated(event:any) {
        if (event.data.Paid != undefined)
            this.CalculateSelectedProcsAndMatsPrice();
    }
}

