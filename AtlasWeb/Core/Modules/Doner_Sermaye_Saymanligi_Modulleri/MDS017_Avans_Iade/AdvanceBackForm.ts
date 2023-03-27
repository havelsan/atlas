//$6E91353C
import { Component, OnInit, NgZone } from '@angular/core';
import { AdvanceBackFormViewModel } from './AdvanceBackFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AdvanceBack } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceBackAdvanceDetail } from 'NebulaClient/Model/AtlasClientModel';
import { AdvanceBackDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTObjectStateTransitionDef } from "NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef";
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

@Component({
    selector: 'AdvanceBackForm',
    templateUrl: './AdvanceBackForm.html',
    providers: [MessageService]
})
export class AdvanceBackForm extends TTVisual.TTForm implements OnInit {
    ADVANCEBACKTOTAL: TTVisual.ITTTextBox;
    ADVANCETOTAL: TTVisual.ITTTextBox;
    CASHIERLOGID: TTVisual.ITTTextBox;
    CASHIERNAME: TTVisual.ITTTextBox;
    CASHOFFICENAME: TTVisual.ITTTextBox;
    CREDITCARDRECEIPTNO: TTVisual.ITTComboBoxColumn;
    DATE: TTVisual.ITTDateTimePickerColumn;
    DOCUMENTDATE: TTVisual.ITTDateTimePicker;
    GRIDAdvanceDetail: TTVisual.ITTGrid;
    //labelCashierLogId: TTVisual.ITTLabel;
    labelCashOfficeName: TTVisual.ITTLabel;
    labelOfficerName: TTVisual.ITTLabel;
    labelTotalPrice: TTVisual.ITTLabel;
    NO: TTVisual.ITTTextBoxColumn;
    REASONOFRETURN: TTVisual.ITTTextBox;
    RECEIPTBACKTOTAL: TTVisual.ITTTextBox;
    RECEIPTTOTAL: TTVisual.ITTTextBox;
    selectedCashOffice: CashOfficeDefinition;
    SERVICETOTAL: TTVisual.ITTTextBox;
    STATUS: TTVisual.ITTTextBoxColumn;
    TOTALPRICE: TTVisual.ITTTextBox;
    TOTALPRICEG: TTVisual.ITTTextBoxColumn;
    BONDTOTAL: TTVisual.ITTTextBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    public GRIDAdvanceDetailColumns = [];
    public advanceBackFormViewModel: AdvanceBackFormViewModel = new AdvanceBackFormViewModel();
    public get _AdvanceBack(): AdvanceBack {
        return this._TTObject as AdvanceBack;
    }
    private AdvanceBackForm_DocumentUrl: string = '/api/AdvanceBackService/AdvanceBackForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("ADVANCEBACK", "AdvanceBackForm");
        this._DocumentServiceUrl = this.AdvanceBackForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {
        if (this._AdvanceBack.CurrentStateDefID.valueOf() === AdvanceBack.AdvanceBackStates.New.id) {
            //     let advanceTotal: number = 0;
            //     let receiptTotal: number = 0;
            //     let advanceBackTotal: number = 0;
            //     let receiptBackTotal: number = 0;
            //     let serviceTotal: number = 0;
            //     let resUser: ResUser =await UserHelper.CurrentResource;
            //     this.selectedCashOffice = (await ResUserService.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser));
            //     if (this.selectedCashOffice === null)
            //         throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Avans iade etmeye yetikiniz bulunmamaktadır!");
            //     //this.cmdOK.Visible = false;,
            //     //Episode da tamamlanmamis bir Avans Iade varsa yenisi baslatilmayacak
            //     for (let ea of this.advanceBackFormViewModel.EpisodeActions) {
            //         if (ea.Cancelled === false) {
            //             let advanceBackAct: AdvanceBack = ea as AdvanceBack;
            //             if (advanceBackAct !== null) {
            //                 if (advanceBackAct.ObjectID !== this._AdvanceBack.ObjectID && advanceBackAct.CurrentStateDefID !== AdvanceBack.AdvanceBackStates.Paid)
            //                     throw new TTException((await SystemMessageService.GetMessage(181)));
            //             }
            //         }
            //     }
            //     this._AdvanceBack.CashOfficeName = this.selectedCashOffice.Name;
            //     if (this._AdvanceBack.AdvanceBackDocument === null) {
            //         this._AdvanceBack.AdvanceBackDocument = new AdvanceBackDocument(this._AdvanceBack.ObjectContext);
            //         this._AdvanceBack.AdvanceBackDocument.CashOffice = this.selectedCashOffice;
            //         this._AdvanceBack.AdvanceBackDocument.DocumentDate = Date.Now.Date;
            //         this._AdvanceBack.AdvanceBackDocument.PatientName = this._AdvanceBack.Episode.Patient.Name + " " + this._AdvanceBack.Episode.Patient.Surname;
            //         this._AdvanceBack.AdvanceBackDocument.PatientNo = this._AdvanceBack.Episode.Patient.ID.Value;
            //         this._AdvanceBack.AdvanceBackDocument.CurrentStateDefID = AdvanceBackDocument.AdvanceBackDocumentStates.New;
            //         this._AdvanceBack.AdvanceBackDocument.ResUser = resUser;
            //         for (let ea of this.advanceBackFormViewModel.EpisodeActions) {
            //             if (ea.Cancelled === false) {
            //                 let advanceAct: Advance = ea as Advance;
            //                 if (advanceAct !== null) {
            //                     let advDetail: AdvanceBackAdvanceDetail = new AdvanceBackAdvanceDetail(this._AdvanceBack.ObjectContext);
            //                     advDetail.AdvanceDate = advanceAct.AdvanceDocument.DocumentDate;
            //                     advDetail.AdvanceDocumentNo = advanceAct.AdvanceDocument.DocumentNo;
            //                     advDetail.AdvanceCrCardDocumentNo = advanceAct.AdvanceDocument.CreditCardDocumentNo;
            //                     advDetail.TotalPrice = advanceAct.AdvanceDocument.TotalPrice;
            //                     advDetail.Status = advanceAct.AdvanceDocument.CurrentStateDef.DisplayText;
            //                     this._AdvanceBack.AdvanceBackAdvanceDetail.push(advDetail);
            //                     if (advanceAct.AdvanceDocument.CurrentStateDefID === AdvanceDocument.AdvanceDocumentStates.Paid)
            //                         advanceTotal = advanceTotal + <number>advanceAct.AdvanceDocument.TotalPrice;
            //                 }
            //                 let receiptAct: Receipt = ea as Receipt;
            //                 if (receiptAct !== null) {
            //                     if (receiptAct.ReceiptDocument.CurrentStateDefID === ReceiptDocument.ReceiptDocumentStates.Paid)
            //                         receiptTotal = receiptTotal + <number>receiptAct.TotalPayment;
            //                 }
            //                 let advBackAct: AdvanceBack = ea as AdvanceBack;
            //                 if (advBackAct !== null) {
            //                     if (advBackAct.AdvanceBackDocument.CurrentStateDefID === AdvanceBackDocument.AdvanceBackDocumentStates.Paid)
            //                         advanceBackTotal = advanceBackTotal + <number>advBackAct.AdvanceBackDocument.TotalPrice;
            //                 }
            //                 let ReceiptBackAct: ReceiptBack = ea as ReceiptBack;
            //                 if (ReceiptBackAct !== null) {
            //                     if (ReceiptBackAct.ReceiptBackDocument.CurrentStateDefID === ReceiptBackDocument.ReceiptBackDocumentStates.Paid)
            //                         receiptBackTotal = receiptBackTotal + <number>ReceiptBackAct.ReceiptBackDocument.TotalPrice;
            //                 }
            //             }
            //         }
            //         let transactionsList: Array<any> = (await AccountTransactionService.GetIncludedTrxsExceptCancelledByEpisode(this._AdvanceBack.Episode.Patient.APR[0].ObjectID, this._AdvanceBack.Episode.ObjectID));
            //         for (let accTrx of transactionsList) {
            //             if (accTrx.PackageDefinition === null && accTrx.InvoiceInclusion === true)
            //                 serviceTotal = serviceTotal + <number>(accTrx.UnitPrice * accTrx.Amount);
            //         }
            //         this._AdvanceBack.ADVANCETOTAL = advanceTotal;
            //         this._AdvanceBack.RECEIPTTOTAL = receiptTotal;
            //         this._AdvanceBack.ADVANCEBACKTOTAL = advanceBackTotal;
            //         this._AdvanceBack.RECEIPTBACKTOTAL = receiptBackTotal;
            //         this._AdvanceBack.SERVICETOTAL = serviceTotal;
            //         if ((advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal) <= 0)
            //             throw new TTException((await SystemMessageService.GetMessage(177)));
            //         else this._AdvanceBack.TotalPrice = (advanceTotal + receiptTotal) - (advanceBackTotal + receiptBackTotal + serviceTotal);
            //         this._AdvanceBack.AdvanceBackDocument.TotalPrice = this._AdvanceBack.TotalPrice;
            //     }
        }
        else {
            this.ttcheckbox1.ReadOnly = true;
            this.REASONOFRETURN.ReadOnly = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new AdvanceBack();
        this.advanceBackFormViewModel = new AdvanceBackFormViewModel();
        this._ViewModel = this.advanceBackFormViewModel;
        this.advanceBackFormViewModel._AdvanceBack = this._TTObject as AdvanceBack;
        this.advanceBackFormViewModel._AdvanceBack.AdvanceBackDocument = new AdvanceBackDocument();
        this.advanceBackFormViewModel._AdvanceBack.AdvanceBackDocument.ResUser = new ResUser();
        this.advanceBackFormViewModel._AdvanceBack.AdvanceBackAdvanceDetail = new Array<AdvanceBackAdvanceDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.advanceBackFormViewModel = this._ViewModel as AdvanceBackFormViewModel;
        that._TTObject = this.advanceBackFormViewModel._AdvanceBack;
        if (this.advanceBackFormViewModel == null)
            this.advanceBackFormViewModel = new AdvanceBackFormViewModel();
        if (this.advanceBackFormViewModel._AdvanceBack == null)
            this.advanceBackFormViewModel._AdvanceBack = new AdvanceBack();
        let advanceBackDocumentObjectID = that.advanceBackFormViewModel._AdvanceBack["AdvanceBackDocument"];
        if (advanceBackDocumentObjectID != null && (typeof advanceBackDocumentObjectID === 'string')) {
            let advanceBackDocument = that.advanceBackFormViewModel.AdvanceBackDocuments.find(o => o.ObjectID.toString() === advanceBackDocumentObjectID.toString());
             if (advanceBackDocument) {
                that.advanceBackFormViewModel._AdvanceBack.AdvanceBackDocument = advanceBackDocument;
            }
            if (advanceBackDocument != null) {
                let resUserObjectID = advanceBackDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.advanceBackFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                     if (resUser) {
                        advanceBackDocument.ResUser = resUser;
                    }
                }
            }
        }
        that.advanceBackFormViewModel._AdvanceBack.AdvanceBackAdvanceDetail = that.advanceBackFormViewModel.GRIDAdvanceDetailGridList;
        for (let detailItem of that.advanceBackFormViewModel.GRIDAdvanceDetailGridList) {
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        // this.cashOfficePatientForm.btnSearchPatientClick(true);
        // this.cashOfficePatientForm.systemApiService.componentInfo = null;
    }
    async ngOnInit()  {
        let that = this;
        await this.load(AdvanceBackFormViewModel);
        $('#paymentType .dx-clear-button-area').css({ display: 'none' });
  
    }

    protected async loadErrorOccurred(err: any) {
        let error: string = err.Value;
        // if(!error.split('-')[0].Contains('SM0177'))
        //     this.cashOfficePatientForm.systemApiService.componentInfo = null;
    }
    public onADVANCEBACKTOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.ADVANCEBACKTOTAL != event) {
                this._AdvanceBack.ADVANCEBACKTOTAL = event;
            }
        }
    }

    public onADVANCETOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.ADVANCETOTAL != event) {
                this._AdvanceBack.ADVANCETOTAL = event;
            }
        }
    }

    public onCASHIERNAMEChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null &&
                this._AdvanceBack.AdvanceBackDocument != null &&
                this._AdvanceBack.AdvanceBackDocument.ResUser != null && this._AdvanceBack.AdvanceBackDocument.ResUser.Name != event) {
                this._AdvanceBack.AdvanceBackDocument.ResUser.Name = event;
            }
        }
    }

    public onCASHOFFICENAMEChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.CashOfficeName != event) {
                this._AdvanceBack.CashOfficeName = event;
            }
        }
    }

    public onDOCUMENTDATEChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null &&
                this._AdvanceBack.AdvanceBackDocument != null && this._AdvanceBack.AdvanceBackDocument.DocumentDate != event) {
                this._AdvanceBack.AdvanceBackDocument.DocumentDate = event;
            }
        }
    }

    public onREASONOFRETURNChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.REASONOFRETURN != event) {
                this._AdvanceBack.REASONOFRETURN = event;
            }
        }
    }

    public onRECEIPTBACKTOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.RECEIPTBACKTOTAL != event) {
                this._AdvanceBack.RECEIPTBACKTOTAL = event;
            }
        }
    }

    public onRECEIPTTOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.RECEIPTTOTAL != event) {
                this._AdvanceBack.RECEIPTTOTAL = event;
            }
        }
    }

    public onSERVICETOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.SERVICETOTAL != event) {
                this._AdvanceBack.SERVICETOTAL = event;
            }
        }
    }

    public onBONDTOTALChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.BONDTOTAL != event) {
                this._AdvanceBack.BONDTOTAL = event;
            }
        }
    }

    public onTOTALPRICEChanged(event): void {
        if (event != null) {
            if (this._AdvanceBack != null && this._AdvanceBack.TotalPrice != event) {
                this._AdvanceBack.TotalPrice = event;
            }
        }
    }

    public onttcheckbox1Changed(event): void {
        if (event != null) {
            if (this._AdvanceBack != null &&
                this._AdvanceBack.AdvanceBackDocument != null && this._AdvanceBack.AdvanceBackDocument.AccountantShipBack != event) {
                this._AdvanceBack.AdvanceBackDocument.AccountantShipBack = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.CASHOFFICENAME, "Text", this.__ttObject, "CashOfficeName");
        redirectProperty(this.CASHIERNAME, "Text", this.__ttObject, "AdvanceBackDocument.ResUser.Name");
        redirectProperty(this.DOCUMENTDATE, "Value", this.__ttObject, "AdvanceBackDocument.DocumentDate");
        redirectProperty(this.REASONOFRETURN, "Text", this.__ttObject, "REASONOFRETURN");
        redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "AdvanceBackDocument.AccountantShipBack");
        redirectProperty(this.ADVANCETOTAL, "Text", this.__ttObject, "ADVANCETOTAL");
        redirectProperty(this.RECEIPTTOTAL, "Text", this.__ttObject, "RECEIPTTOTAL");
        redirectProperty(this.SERVICETOTAL, "Text", this.__ttObject, "SERVICETOTAL");
        redirectProperty(this.ADVANCEBACKTOTAL, "Text", this.__ttObject, "ADVANCEBACKTOTAL");
        redirectProperty(this.RECEIPTBACKTOTAL, "Text", this.__ttObject, "RECEIPTBACKTOTAL");
        redirectProperty(this.TOTALPRICE, "Text", this.__ttObject, "TotalPrice");
        redirectProperty(this.BONDTOTAL, "Text", this.__ttObject, "BondTotal");
    }

    public initFormControls(): void {
        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = i18n("M21470", "Saymanlıktan İade");
        this.ttcheckbox1.Name = "ttcheckbox1";
        this.ttcheckbox1.TabIndex = 31;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "Hastadan Yapılan Tahsilat Toplam Tutarı";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 22;

        this.RECEIPTTOTAL = new TTVisual.TTTextBox();
        this.RECEIPTTOTAL.BackColor = "#F0F0F0";
        this.RECEIPTTOTAL.ReadOnly = true;
        this.RECEIPTTOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTTOTAL.Name = "RECEIPTTOTAL";
        this.RECEIPTTOTAL.TabIndex = 12;

        this.CASHIERNAME = new TTVisual.TTTextBox();
        this.CASHIERNAME.BackColor = "#F0F0F0";
        this.CASHIERNAME.ReadOnly = true;
        this.CASHIERNAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERNAME.Name = "CASHIERNAME";
        this.CASHIERNAME.TabIndex = 1;

        this.CASHOFFICENAME = new TTVisual.TTTextBox();
        this.CASHOFFICENAME.BackColor = "#F0F0F0";
        this.CASHOFFICENAME.ReadOnly = true;
        this.CASHOFFICENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHOFFICENAME.Name = "CASHOFFICENAME";
        this.CASHOFFICENAME.TabIndex = 0;

        this.REASONOFRETURN = new TTVisual.TTTextBox();
        this.REASONOFRETURN.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.REASONOFRETURN.Name = "REASONOFRETURN";
        this.REASONOFRETURN.TabIndex = 4;

        this.CASHIERLOGID = new TTVisual.TTTextBox();
        this.CASHIERLOGID.BackColor = "#F0F0F0";
        this.CASHIERLOGID.ReadOnly = true;
        this.CASHIERLOGID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERLOGID.Name = "CASHIERLOGID";
        this.CASHIERLOGID.TabIndex = 2;
        this.CASHIERLOGID.Visible = false;

        this.ADVANCETOTAL = new TTVisual.TTTextBox();
        this.ADVANCETOTAL.BackColor = "#F0F0F0";
        this.ADVANCETOTAL.ReadOnly = true;
        this.ADVANCETOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ADVANCETOTAL.Name = "ADVANCETOTAL";
        this.ADVANCETOTAL.TabIndex = 11;

        this.SERVICETOTAL = new TTVisual.TTTextBox();
        this.SERVICETOTAL.BackColor = "#F0F0F0";
        this.SERVICETOTAL.ReadOnly = true;
        this.SERVICETOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SERVICETOTAL.Name = "SERVICETOTAL";
        this.SERVICETOTAL.TabIndex = 13;

        this.TOTALPRICE = new TTVisual.TTTextBox();
        this.TOTALPRICE.BackColor = "#F0F0F0";
        this.TOTALPRICE.ReadOnly = true;
        this.TOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TOTALPRICE.Name = "TOTALPRICE";
        this.TOTALPRICE.TabIndex = 16;

        this.BONDTOTAL = new TTVisual.TTTextBox();
        this.BONDTOTAL.BackColor = "#F0F0F0";
        this.BONDTOTAL.ReadOnly = true;
        this.BONDTOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BONDTOTAL.Name = "TOTALPRICE";
        this.BONDTOTAL.TabIndex = 16;

        this.ADVANCEBACKTOTAL = new TTVisual.TTTextBox();
        this.ADVANCEBACKTOTAL.BackColor = "#F0F0F0";
        this.ADVANCEBACKTOTAL.ReadOnly = true;
        this.ADVANCEBACKTOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ADVANCEBACKTOTAL.Name = "ADVANCEBACKTOTAL";
        this.ADVANCEBACKTOTAL.TabIndex = 14;

        this.RECEIPTBACKTOTAL = new TTVisual.TTTextBox();
        this.RECEIPTBACKTOTAL.BackColor = "#F0F0F0";
        this.RECEIPTBACKTOTAL.ReadOnly = true;
        this.RECEIPTBACKTOTAL.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTBACKTOTAL.Name = "RECEIPTBACKTOTAL";
        this.RECEIPTBACKTOTAL.TabIndex = 15;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M10704", "Alınan Avanslar");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 10;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M16076", "İade Tarihi");
        this.ttlabel7.BackColor = "#DCDCDC";
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 6;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = i18n("M16071", "İade Sebebi");
        this.ttlabel10.BackColor = "#DCDCDC";
        this.ttlabel10.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.ForeColor = "#000000";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 8;

        this.labelCashOfficeName = new TTVisual.TTLabel();
        this.labelCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.labelCashOfficeName.BackColor = "#DCDCDC";
        this.labelCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashOfficeName.ForeColor = "#000000";
        this.labelCashOfficeName.Name = "labelCashOfficeName";
        this.labelCashOfficeName.TabIndex = 0;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M24111", "Verilen Hizmet Toplam Tutarı");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 14;

        // this.labelCashierLogId = new TTVisual.TTLabel();
        // this.labelCashierLogId.Text = "Vezne Açılış İz Sürme No";
        // this.labelCashierLogId.BackColor = "#DCDCDC";
        // this.labelCashierLogId.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.labelCashierLogId.ForeColor = "#000000";
        // this.labelCashierLogId.Name = "labelCashierLogId";
        // this.labelCashierLogId.TabIndex = 4;
        // this.labelCashierLogId.Visible = false;

        this.labelTotalPrice = new TTVisual.TTLabel();
        this.labelTotalPrice.Text = i18n("M16063", "İade Edilecek Tutar");
        this.labelTotalPrice.BackColor = "#DCDCDC";
        this.labelTotalPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTotalPrice.ForeColor = "#000000";
        this.labelTotalPrice.Name = "labelTotalPrice";
        this.labelTotalPrice.TabIndex = 20;

        this.GRIDAdvanceDetail = new TTVisual.TTGrid();
        this.GRIDAdvanceDetail.BackColor = "#DCDCDC";
        this.GRIDAdvanceDetail.ReadOnly = true;
        this.GRIDAdvanceDetail.Name = "GRIDAdvanceDetail";
        this.GRIDAdvanceDetail.TabIndex = 10;
        this.GRIDAdvanceDetail.AllowUserToAddRows = false;
        this.GRIDAdvanceDetail.AllowUserToDeleteRows = false;
        this.GRIDAdvanceDetail.AllowUserToResizeColumns = true;
        this.GRIDAdvanceDetail.ReadOnly = true;
        this.GRIDAdvanceDetail.Height = 220;

        this.DATE = new TTVisual.TTDateTimePickerColumn();
        this.DATE.CustomFormat = "dd.MM.yyyy";
        this.DATE.DataMember = "AdvanceDate";
        this.DATE.DisplayIndex = 0;
        this.DATE.HeaderText = i18n("M22846", "Tarihi");
        this.DATE.Name = "DATE";
        //this.DATE.Width = 150;
        this.DATE.ReadOnly = true;

        this.NO = new TTVisual.TTTextBoxColumn();
        this.NO.DataMember = "AdvanceDocumentNo";
        this.NO.DisplayIndex = 1;
        this.NO.HeaderText = i18n("M18478", "Makbuz No");
        this.NO.Name = "NO";
        //this.NO.Width = 150;
        this.NO.ReadOnly = true;
        this.NO.Alignment = DataGridViewContentAlignment.MiddleCenter;

        this.CREDITCARDRECEIPTNO = new TTVisual.TTComboBoxColumn();
        this.CREDITCARDRECEIPTNO.DataMember = "AdvanceCrCardDocumentNo";
        this.CREDITCARDRECEIPTNO.DisplayIndex = 2;
        this.CREDITCARDRECEIPTNO.HeaderText = i18n("M17854", "Kredi Kartı Alındı No");
        this.CREDITCARDRECEIPTNO.Name = "CREDITCARDRECEIPTNO";
        this.CREDITCARDRECEIPTNO.Width = 135;
        this.CREDITCARDRECEIPTNO.ReadOnly = true;
        this.CREDITCARDRECEIPTNO.Visible = false;

        this.TOTALPRICEG = new TTVisual.TTTextBoxColumn();
        this.TOTALPRICEG.DataMember = "TotalPrice";
        this.TOTALPRICEG.DisplayIndex = 3;
        this.TOTALPRICEG.HeaderText = i18n("M23613", "Tutarı");
        this.TOTALPRICEG.Name = "TOTALPRICEG";
        //this.TOTALPRICEG.Width = 120;
        this.TOTALPRICEG.ReadOnly = true;

        this.STATUS = new TTVisual.TTTextBoxColumn();
        this.STATUS.DataMember = "Status";
        this.STATUS.DisplayIndex = 4;
        this.STATUS.HeaderText = "Durum";
        this.STATUS.Name = "STATUS";
        //this.STATUS.Width = 120;
        this.STATUS.ReadOnly = true;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M16065", "İade Edilen Avans Toplam Tutarı");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 16;

        this.labelOfficerName = new TTVisual.TTLabel();
        this.labelOfficerName.Text = i18n("M24065", "Venedar");
        this.labelOfficerName.BackColor = "#DCDCDC";
        this.labelOfficerName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelOfficerName.ForeColor = "#000000";
        this.labelOfficerName.Name = "labelOfficerName";
        this.labelOfficerName.TabIndex = 2;

        this.DOCUMENTDATE = new TTVisual.TTDateTimePicker();
        this.DOCUMENTDATE.BackColor = "#F0F0F0";
        this.DOCUMENTDATE.CustomFormat = "";
        this.DOCUMENTDATE.Format = DateTimePickerFormat.Short;
        this.DOCUMENTDATE.Enabled = false;
        this.DOCUMENTDATE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DOCUMENTDATE.Name = "DOCUMENTDATE";
        this.DOCUMENTDATE.TabIndex = 3;
        this.DOCUMENTDATE.ReadOnly = true;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M10703", "Alınan Avans Toplam Tutarı");
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 12;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = i18n("M15523", "Hastaya Yapılan İadeı Toplam Tutarı");
        this.ttlabel11.BackColor = "#DCDCDC";
        this.ttlabel11.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.ForeColor = "#000000";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 16;

        this.GRIDAdvanceDetailColumns = [this.DATE, this.NO, this.TOTALPRICEG, this.STATUS];
        this.Controls = [this.ttcheckbox1, this.ttlabel5, this.RECEIPTTOTAL, this.CASHIERNAME, this.CASHOFFICENAME, this.REASONOFRETURN, this.CASHIERLOGID, this.ADVANCETOTAL, this.SERVICETOTAL, this.TOTALPRICE, this.ADVANCEBACKTOTAL, this.RECEIPTBACKTOTAL, this.ttlabel2, this.ttlabel7, this.ttlabel10, this.labelCashOfficeName, this.ttlabel4, /*this.labelCashierLogId,*/ this.labelTotalPrice, this.GRIDAdvanceDetail, this.DATE, this.NO, this.CREDITCARDRECEIPTNO, this.TOTALPRICEG, this.STATUS, this.ttlabel1, this.labelOfficerName, this.DOCUMENTDATE, this.ttlabel3, this.ttlabel11];

    }


}
