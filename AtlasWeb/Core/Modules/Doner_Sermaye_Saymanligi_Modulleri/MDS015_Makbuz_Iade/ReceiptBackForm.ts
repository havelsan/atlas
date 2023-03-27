//$D7B3224E
import { Component, OnInit, NgZone } from '@angular/core';
import { ReceiptBackFormViewModel } from './ReceiptBackFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Receipt } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptBack } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptBackDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptBackDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ReceiptBackDetailViewModel } from "./ReceiptBackFormViewModel";

@Component({
    selector: 'ReceiptBackForm',
    templateUrl: './ReceiptBackForm.html',
    providers: [MessageService]
})
export class ReceiptBackForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePickerColumn;
    Amount: TTVisual.ITTTextBoxColumn;
    BTNLISTDETAIL: TTVisual.ITTButton;
    CASHIERLOGID: TTVisual.ITTTextBox;
    CASHIERNAME: TTVisual.ITTTextBox;
    CASHOFFICENAME: TTVisual.ITTTextBox;
    DATEOFRETURN: TTVisual.ITTDateTimePicker;
    Description: TTVisual.ITTTextBoxColumn;
    EXTERNALCODE: TTVisual.ITTTextBoxColumn;
    GRIDReceiptBackDetails: TTVisual.ITTGrid;
    labelCashierLogId: TTVisual.ITTLabel;
    labelCashOfficeName: TTVisual.ITTLabel;
    labelOfficerName: TTVisual.ITTLabel;
    lstBoxReceipts: TTVisual.ITTObjectListBox;
    PAYMENTPRICE: TTVisual.ITTTextBoxColumn;
    READONLYFLAG: TTVisual.ITTTextBoxColumn;
    REASONOFRETURN: TTVisual.ITTTextBox;
    RECEIPTNO: TTVisual.ITTTextBox;
    //RECEIPTTOTALPRICE: TTVisual.ITTTextBox;
    RETURN: TTVisual.ITTCheckBoxColumn;
    RETURNTOTALPRICE: TTVisual.ITTTextBox;
    STATE: TTVisual.ITTTextBoxColumn;
    TOTALDISCOUNTEDPRICE: TTVisual.ITTTextBoxColumn;
    TOTALPRICE: TTVisual.ITTTextBoxColumn;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    //tttabpage1: TTVisual.ITTTabPage;
    UNITPRICE: TTVisual.ITTTextBoxColumn;
    public GRIDReceiptBackDetailsColumns = [];
    public receiptBackFormViewModel: ReceiptBackFormViewModel = new ReceiptBackFormViewModel();
    public get _ReceiptBack(): ReceiptBack {
        return this._TTObject as ReceiptBack;
    }
    private ReceiptBackForm_DocumentUrl: string = '/api/ReceiptBackService/ReceiptBackForm';
    constructor(protected http: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super("RECEIPTBACK", "ReceiptBackForm");
        this._DocumentServiceUrl = this.ReceiptBackForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async BTNLISTDETAIL_Click(): Promise<void> {

    }
    private async GRIDReceiptBackDetails_CellValueChanged(rowIndex: number, columnIndex: number): Promise<void> {
        if (columnIndex === 8) {
            //     let childTotal: number = 0;
            //     // Kan bankası için eklenen kısım
            //     let checkedsp: ReceiptBackDetail = this.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList[rowIndex];
            let totalPayment: number = 0;
            for (let receiptBack of this.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList) {
                if (receiptBack.Return)
                    totalPayment += Math.Round(receiptBack.PaymentPrice, 2);
            }
            this._ReceiptBack.ReturnTotalPrice = Math.Round(totalPayment, 2);
            //   if (checkedsp.AccountTransaction[0].SubActionProcedure instanceof BloodBankBloodProducts && !(checkedsp.AccountTransaction[0].SubActionProcedure instanceof BloodBankSubProduct)) {
            //         for (let receiptBackDetail of this.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList) {
            //             //let detChild: ReceiptBackDetail = receiptBackDetail;
            //             if (receiptBackDetail !== null) {
            //                 if (receiptBackDetail.AccountTransaction[0].SubActionProcedure.MasterSubActionProcedure === checkedsp.AccountTransaction[0].SubActionProcedure) {
            //                     let testDef: BloodBankTestDefinition = receiptBackDetail.AccountTransaction[0].SubActionProcedure.ProcedureObject as BloodBankTestDefinition;
            //                     if (testDef !== null) {
            //                         if (testDef.OnlyChargeWithProduct === true) {
            //                             receiptBackDetail.Return = checkedsp.Return;
            //                             childTotal = childTotal + Convert.ToDouble(receiptBackDetail.PaymentPrice.Value);
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            //     }
            //     if (checkedsp.Return === false)
            //         this._ReceiptBack.ReturnTotalPrice -= (Convert.ToDouble(this.GRIDReceiptBackDetails.Rows[rowIndex].Cells[6].Value) + childTotal);
            //     else this._ReceiptBack.ReturnTotalPrice += (Convert.ToDouble(this.GRIDReceiptBackDetails.Rows[rowIndex].Cells[6].Value) + childTotal);
        }
    }
    private async lstBoxReceipts_SelectedObjectChanged(): Promise<void> {
        if (this._ReceiptBack.Receipt.ObjectID !== undefined && this._ReceiptBack.Receipt.ObjectID !== null) {

            // this.receiptBackFormViewModel.Receipts = new Array<Receipt>();
            // this.receiptBackFormViewModel.Receipts.push(this.receiptBackFormViewModel._ReceiptBack.Receipt);

            let url: string = '/api/ReceiptBackService/GetReceiptsForReceiptBack?receiptObjID=' + this.receiptBackFormViewModel._ReceiptBack.Receipt.ObjectID;

            this.http.get<ReceiptBackDetailViewModel>(url).then(response => {

                let result: ReceiptBackDetailViewModel = response;
                this.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList = result.ReceiptBackDetails;
                this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDetails = result.ReceiptBackDetails;
                this.receiptBackFormViewModel.Receipts = new Array<Receipt>();
                this.receiptBackFormViewModel.Receipts.push(result.receipt);
                this.receiptBackFormViewModel.AccountTransactions = new Array<AccountTransaction>();
                this.receiptBackFormViewModel.AccountTransactions = result.AccountTransactions;
                this._ReceiptBack.ReturnTotalPrice = 0;
                // for (let i: number = 0; i < this.GRIDReceiptBackDetails.Rows.length; i++) {
                //     this.GRIDReceiptBackDetails.Rows[i].Cells[8].ReadOnly = <boolean>this.GRIDReceiptBackDetails.Rows[i].Cells[9].Value;
                // }
            });
            //IList receiptList = null;
            /*
            receiptList = ReceiptDocument.GetByDocumentNoAndState(_ReceiptBack.ObjectContext, _ReceiptBack.ReceiptNo.ToString().ToUpper(), ReceiptDocument.States.Paid.ToString(), _ReceiptBack.Episode.ObjectID.ToString());
            if(receiptList.Count == 0)
                receiptList = ReceiptDocument.GetByCreditCardDocumentNoAndState(_ReceiptBack.ObjectContext, _ReceiptBack.ReceiptNo.ToString().ToUpper(), ReceiptDocument.States.Paid.ToString(), _ReceiptBack.Episode.ObjectID.ToString());
            */
            /*receiptList = Receipt.GetByEpisodeStateAndDocumentNo(_ReceiptBack.ObjectContext, _ReceiptBack.Episode.ObjectID.ToString(), Receipt.States.Paid.ToString(), _ReceiptBack.ReceiptNo.ToUpper());
            if (receiptList.Count == 0)
                receiptList = Receipt.GetByEpisodeStateAndCreditCardDocumentNo(_ReceiptBack.ObjectContext, _ReceiptBack.Episode.ObjectID.ToString(), Receipt.States.Paid.ToString(), _ReceiptBack.ReceiptNo.ToUpper());

            if (receiptList.Count == 0)
                throw new TTException("Vakada " + _ReceiptBack.ReceiptNo + " numaralı ve Ödendi durumunda olan Muhasebe Yetkilisi Mutemedi Alındısı işlemi bulunamadı. Muhasebe Yetkilisi Mutemedi Alındı numarasını kontrol ediniz!");*/
            //else
            //{

            //let receipt: Receipt = this._ReceiptBack.Receipt;/*(Receipt)receiptList[0];*/
            /*if (_ReceiptBack.ReceiptBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice && receipt.ReceiptDocument.CashierLog.ClosingDate != null)
            {
                string msg = _ReceiptBack.ReceiptNo.ToString() + " numaralı Muhasebe Yetkilisi Mutemedi Alındısı işleminin yapıldığı Muhasebe Yetkilisi Mutemetliği kapandığı için iade işlemi yapılamaz! İade işlemi Vezne tarafından yapılmalıdır.";
                InfoBox.Show(msg);
            }*/
            //else
            //{

            //_ReceiptBack.ReceiptTotalPrice = (double)receipt.ReceiptDocument.PaymentPrice;

            /*for (let backDetail of this._ReceiptBack.ReceiptBackDetails) {
                backDetail.AccountTransaction.Clear();
            }
            //this._ReceiptBack.ReceiptBackDetails.DeleteChildren();
            for (let receiptDocGroup of receipt.ReceiptDocument.ReceiptDocumentGroups) {
                for (let receiptDocDetail of receiptDocGroup.ReceiptDocumentDetails) {
                    let _receiptBackDetail: ReceiptBackDetail = new ReceiptBackDetail(this._ReceiptBack.ObjectContext);
                    let ppDetail: PatientPaymentDetail = (await ReceiptDocumentService.GetPatientPaymentDetail(receiptDocDetail.AccountTrxDocument[0].AccountTransaction.ObjectID, receipt.ReceiptDocument));
                    if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID !== AccountTransaction.AccountTransactionStates.Cancelled)
                        _receiptBackDetail.AccountTransaction.push(receiptDocDetail.AccountTrxDocument[0].AccountTransaction);
                    _receiptBackDetail.ReceiptDocumentDetail = receiptDocDetail;
                    _receiptBackDetail.ActionDate = <Date>receiptDocDetail.AccountTrxDocument[0].AccountTransaction.TransactionDate;
                    _receiptBackDetail.Amount = receiptDocDetail.Amount;
                    _receiptBackDetail.ExternalCode = receiptDocDetail.ExternalCode;
                    _receiptBackDetail.Description = receiptDocDetail.Description;
                    _receiptBackDetail.UnitPrice = receiptDocDetail.UnitPrice;
                    //_receiptBackDetail.TotalDiscountedPrice = receiptDocDetail.TotalDiscountedPrice;
                    _receiptBackDetail.TotalPrice = <number>receiptDocDetail.Amount * <number>receiptDocDetail.UnitPrice;
                    _receiptBackDetail.PaymentPrice = ppDetail.PaymentPrice;
                    if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure) !== null) {
                        if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure).ObjectDef.toString() === "LABORATORYPROCEDURE") {
                            if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID === LaboratoryProcedure.LaboratoryProcedureStates.PendingCancel) {
                                _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.toString();
                                _receiptBackDetail.ReadOnlyFlag = false;
                            }
                            else if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID === LaboratoryProcedure.LaboratoryProcedureStates.Completed) {
                                _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.toString();
                                _receiptBackDetail.ReadOnlyFlag = true;
                            }
                            else {
                                _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.toString();
                                _receiptBackDetail.ReadOnlyFlag = true;
                            }
                        }
                        else {
                            if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID === SubActionProcedure.SubActionProcedureStates.Completed) {
                                _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.toString();
                                _receiptBackDetail.ReadOnlyFlag = true;
                            }
                            else {
                                _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.toString();
                                if (receiptDocDetail.CurrentStateDefID === ReceiptDocumentDetail.ReceiptDocumentDetailStates.ReturnBack)
                                    _receiptBackDetail.ReadOnlyFlag = true;
                                else _receiptBackDetail.ReadOnlyFlag = false;
                            }
                        }
                    }
                    else {
                        if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDefID === SubActionMaterial.SubActionMaterialStates.Completed) {
                            _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDef.DisplayText.toString();
                            _receiptBackDetail.ReadOnlyFlag = true;
                        }
                        else {
                            _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.toString();
                            if (receiptDocDetail.CurrentStateDefID === ReceiptDocumentDetail.ReceiptDocumentDetailStates.ReturnBack)
                                _receiptBackDetail.ReadOnlyFlag = true;
                            else _receiptBackDetail.ReadOnlyFlag = false;
                        }
                    }
                    _receiptBackDetail.Return = false;
                    this._ReceiptBack.ReceiptBackDetails.push(_receiptBackDetail);
                    this._ReceiptBack.ReturnTotalPrice = 0;
                }
                //}
                for (let i: number = 0; i < this.GRIDReceiptBackDetails.Rows.length; i++) {
                    this.GRIDReceiptBackDetails.Rows[i].Cells[8].ReadOnly = <boolean>this.GRIDReceiptBackDetails.Rows[i].Cells[9].Value;
                }
        }*/
        }
    }
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        //this.lstBoxReceipts.ListFilterExpression = "EPISODE = " + "'" + this._ReceiptBack.Episode.ObjectID + "'";
        if (this._ReceiptBack.CurrentStateDefID.valueOf() === ReceiptBack.ReceiptBackStates.New.id) {

            // let resUser: ResUser = TTUser.CurrentUser.UserObject as ResUser;
            // let selectedCashOffice: CashOfficeDefinition = (await ResUserService.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser));
            // if (selectedCashOffice === null)
            //     throw new TTException("Bu kullanıcı için tanımlı bir vezne yok ya da Makbuz kesmeye yetikiniz bulunmamaktadır!!");
            // //this.cmdOK.Visible = false;
            // this._ReceiptBack.CashOfficeName = selectedCashOffice.Name;
            // if (this._ReceiptBack.ReceiptBackDocument === null) {
            //     this._ReceiptBack.ReceiptBackDocument = new ReceiptBackDocument(this._ReceiptBack.ObjectContext);
            //     this._ReceiptBack.ReceiptBackDocument.CashOffice = selectedCashOffice;
            //     this._ReceiptBack.CashOfficeName = selectedCashOffice.Name;
            //     this._ReceiptBack.ReceiptBackDocument.DocumentDate = Date.Now.Date;
            //     this._ReceiptBack.ReceiptBackDocument.CurrentStateDefID = ReceiptBackDocument.ReceiptBackDocumentStates.New;
            //     this._ReceiptBack.ReceiptBackDocument.ResUser = resUser;
            // }
        }
        else {
            this.DATEOFRETURN.ReadOnly = true;
            this.lstBoxReceipts.Enabled = false;
            this.REASONOFRETURN.ReadOnly = true;
            this.BTNLISTDETAIL.ReadOnly = true;
            this.GRIDReceiptBackDetails.ReadOnly = true;
            this.ttcheckbox1.ReadOnly = true;
            this.RETURN.ReadOnly = true;
        }
        this.lstBoxReceipts.ListFilterExpression = "EPISODE = " + "'" + this.receiptBackFormViewModel._ReceiptBack.Episode + "' AND CURRENTSTATE = '" + Receipt.ReceiptStates.Paid + "'";
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        //            CashierLog  _myCashierLog;
        //            ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
        //            _myCashierLog = (CashierLog) _myResUser.GetOpenCashCashierLog();
        //
        //
        //            if (_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.SubCashOffice && _ReceiptBack.ReceiptBackDocument.CashierLog.ClosingDate != null )
        //            {
        //                throw new TTException("Sayman Mutemedi Alındısının kesildiği Sayman Mutemetliği kapandığı için Sayman Mutemedi Alındısı İade işlemi yapılamaz!");
        //            }
        //            else if(_myCashierLog.CashOffice.Type == CashOfficeTypeEnum.InvoicingService)
        //            {
        //                throw new TTException("Fatura Servisinden Sayman Mutemedi Alındısı İade işlemi yapılamaz!");
        //            }
        //            else
        //            {
        this._ReceiptBack.ReceiptBackDocument.TotalPrice = this._ReceiptBack.ReturnTotalPrice;
    }
    protected async PreScript() {

    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        // this.cashOfficePatientForm.btnSearchPatientClick(true);
        // this.cashOfficePatientForm.systemApiService.componentInfo = null;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReceiptBack();
        this.receiptBackFormViewModel = new ReceiptBackFormViewModel();
        this._ViewModel = this.receiptBackFormViewModel;
        this.receiptBackFormViewModel._ReceiptBack = this._TTObject as ReceiptBack;
        this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDocument = new ReceiptBackDocument();
        this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDocument.CashierLog = new CashierLog();
        this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDocument.ResUser = new ResUser();
        this.receiptBackFormViewModel._ReceiptBack.Receipt = new Receipt();
        this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDetails = new Array<ReceiptBackDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.receiptBackFormViewModel = this._ViewModel as ReceiptBackFormViewModel;
        that._TTObject = this.receiptBackFormViewModel._ReceiptBack;
        if (this.receiptBackFormViewModel == null)
            this.receiptBackFormViewModel = new ReceiptBackFormViewModel();
        if (this.receiptBackFormViewModel._ReceiptBack == null)
            this.receiptBackFormViewModel._ReceiptBack = new ReceiptBack();
        let receiptBackDocumentObjectID = that.receiptBackFormViewModel._ReceiptBack["ReceiptBackDocument"];
        if (receiptBackDocumentObjectID != null && (typeof receiptBackDocumentObjectID === 'string')) {
            let receiptBackDocument = that.receiptBackFormViewModel.ReceiptBackDocuments.find(o => o.ObjectID.toString() === receiptBackDocumentObjectID.toString());
             if (receiptBackDocument) {
                that.receiptBackFormViewModel._ReceiptBack.ReceiptBackDocument = receiptBackDocument;
            }
            // if (receiptBackDocument != null) {
            //     let cashierLogObjectID = receiptBackDocument["CashierLog"];
            //     if (cashierLogObjectID != null && (typeof cashierLogObjectID === 'string')) {
            //         let cashierLog = that.receiptBackFormViewModel.CashierLogs.find(o => o.ObjectID.toString() === cashierLogObjectID.toString());
            //         receiptBackDocument.CashierLog = cashierLog;
            //     }
            // }
            if (receiptBackDocument != null) {
                let resUserObjectID = receiptBackDocument["ResUser"];
                if (resUserObjectID != null && (typeof resUserObjectID === 'string')) {
                    let resUser = that.receiptBackFormViewModel.ResUsers.find(o => o.ObjectID.toString() === resUserObjectID.toString());
                     if (resUser) {
                        receiptBackDocument.ResUser = resUser;
                    }
                }
            }
        }
        let receiptObjectID = that.receiptBackFormViewModel._ReceiptBack["Receipt"];
        if (receiptObjectID != null && (typeof receiptObjectID === 'string')) {
            let receipt = that.receiptBackFormViewModel.Receipts.find(o => o.ObjectID.toString() === receiptObjectID.toString());
             if (receipt) {
                that.receiptBackFormViewModel._ReceiptBack.Receipt = receipt;
            }
        }
        that.receiptBackFormViewModel._ReceiptBack.ReceiptBackDetails = that.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList;
        // for (let detailItem of that.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList) {
        // }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(ReceiptBackFormViewModel);
  
    }


    public onCASHIERLOGIDChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null &&
                this._ReceiptBack.ReceiptBackDocument != null &&
                this._ReceiptBack.ReceiptBackDocument.CashierLog != null && this._ReceiptBack.ReceiptBackDocument.CashierLog.LogID != event) {
                this._ReceiptBack.ReceiptBackDocument.CashierLog.LogID = event;
            }
        }
    }

    public onCASHIERNAMEChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null &&
                this._ReceiptBack.ReceiptBackDocument != null &&
                this._ReceiptBack.ReceiptBackDocument.ResUser != null && this._ReceiptBack.ReceiptBackDocument.ResUser.Name != event) {
                this._ReceiptBack.ReceiptBackDocument.ResUser.Name = event;
            }
        }
    }

    public onCASHOFFICENAMEChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null && this._ReceiptBack.CashOfficeName != event) {
                this._ReceiptBack.CashOfficeName = event;
            }
        }
    }

    public onDATEOFRETURNChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null &&
                this._ReceiptBack.ReceiptBackDocument != null && this._ReceiptBack.ReceiptBackDocument.DocumentDate != event) {
                this._ReceiptBack.ReceiptBackDocument.DocumentDate = event;
            }
        }
    }

    public onlstBoxReceiptsChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null && this._ReceiptBack.Receipt != event) {
                this._ReceiptBack.Receipt = event;
                this.lstBoxReceipts_SelectedObjectChanged();
            }
        }
        else {
            this._ReceiptBack.Receipt = null;
            this.receiptBackFormViewModel.GRIDReceiptBackDetailsGridList = new Array<ReceiptBackDetail>();
            this.receiptBackFormViewModel._ReceiptBack.ReceiptBackDetails = new Array<ReceiptBackDetail>();
            this.receiptBackFormViewModel.AccountTransactions = new Array<AccountTransaction>();
        }


    }

    public onREASONOFRETURNChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null && this._ReceiptBack.ReasonOfReturn != event) {
                this._ReceiptBack.ReasonOfReturn = event;
            }
        }
    }

    public onRECEIPTNOChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null && this._ReceiptBack.ReceiptNo != event) {
                this._ReceiptBack.ReceiptNo = event;
            }
        }
    }

    // public onRECEIPTTOTALPRICEChanged(event): void {
    //     if (event != null) {
    //         if (this._ReceiptBack != null && this._ReceiptBack.ReceiptTotalPrice != event) {
    //             this._ReceiptBack.ReceiptTotalPrice = event;
    //         }
    //     }
    // }

    public onRETURNTOTALPRICEChanged(event): void {
        if (event != null) {
            if (this._ReceiptBack != null && this._ReceiptBack.ReturnTotalPrice != event) {
                this._ReceiptBack.ReturnTotalPrice = event;
            }
        }
    }

    public onttcheckbox1Changed(event): void {
        if (event != null) {
            if (this._ReceiptBack != null &&
                this._ReceiptBack.ReceiptBackDocument != null && this._ReceiptBack.ReceiptBackDocument.AccountantShipBack != event) {
                this._ReceiptBack.ReceiptBackDocument.AccountantShipBack = event;
            }
        }
    }



    GRIDReceiptBackDetails_CellValueChangedEmitted(data: any) {
        if (data && this.GRIDReceiptBackDetails_CellValueChanged && data.Row && data.Column) {
            this.GRIDReceiptBackDetails.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.GRIDReceiptBackDetails_CellValueChanged(data.RowIndex, data.ColIndex);
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.CASHOFFICENAME, "Text", this.__ttObject, "CashOfficeName");
        redirectProperty(this.CASHIERNAME, "Text", this.__ttObject, "ReceiptBackDocument.ResUser.Name");
        redirectProperty(this.CASHIERLOGID, "Text", this.__ttObject, "ReceiptBackDocument.CashierLog.LogID");
        redirectProperty(this.DATEOFRETURN, "Value", this.__ttObject, "ReceiptBackDocument.DocumentDate");
        redirectProperty(this.REASONOFRETURN, "Text", this.__ttObject, "ReasonOfReturn");
        redirectProperty(this.RECEIPTNO, "Text", this.__ttObject, "ReceiptNo");
        //redirectProperty(this.RECEIPTTOTALPRICE, "Text", this.__ttObject, "ReceiptTotalPrice");
        redirectProperty(this.RETURNTOTALPRICE, "Text", this.__ttObject, "ReturnTotalPrice");
        redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "ReceiptBackDocument.AccountantShipBack");
    }

    public initFormControls(): void {
        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = i18n("M21470", "Saymanlıktan İade");
        this.ttcheckbox1.Name = "ttcheckbox1";
        this.ttcheckbox1.TabIndex = 33;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M16060", "İade Edilecek Makbuz");
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 32;

        this.lstBoxReceipts = new TTVisual.TTObjectListBox();
        this.lstBoxReceipts.ListDefName = "ReceiptListDefinition";
        this.lstBoxReceipts.Name = "lstBoxReceipts";
        this.lstBoxReceipts.TabIndex = 31;

        this.DATEOFRETURN = new TTVisual.TTDateTimePicker();
        this.DATEOFRETURN.CustomFormat = "";
        this.DATEOFRETURN.Format = DateTimePickerFormat.Short;
        this.DATEOFRETURN.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DATEOFRETURN.Name = "DATEOFRETURN";
        this.DATEOFRETURN.TabIndex = 5;

        this.labelOfficerName = new TTVisual.TTLabel();
        this.labelOfficerName.Text = i18n("M24159", "Veznedar");
        this.labelOfficerName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelOfficerName.ForeColor = "#000000";
        this.labelOfficerName.Name = "labelOfficerName";
        this.labelOfficerName.TabIndex = 9;

        // this.RECEIPTTOTALPRICE = new TTVisual.TTTextBox();
        // this.RECEIPTTOTALPRICE.BackColor = "#F0F0F0";
        // this.RECEIPTTOTALPRICE.ReadOnly = true;
        // this.RECEIPTTOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.RECEIPTTOTALPRICE.Name = "RECEIPTTOTALPRICE";
        // this.RECEIPTTOTALPRICE.TabIndex = 8;
        // this.RECEIPTTOTALPRICE.Visible = false;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = i18n("M19301", "Muhasebe Yetkilisi Mutemedi Alındısı No");
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 11;
        this.ttlabel3.Visible = false;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = i18n("M16076", "İade Tarihi");
        this.ttlabel7.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.ForeColor = "#000000";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 12;

        this.labelCashierLogId = new TTVisual.TTLabel();
        this.labelCashierLogId.Text = i18n("M24128", "Vezne Açılış İz Sürme No");
        this.labelCashierLogId.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashierLogId.ForeColor = "#000000";
        this.labelCashierLogId.Name = "labelCashierLogId";
        this.labelCashierLogId.TabIndex = 10;
        this.labelCashierLogId.Visible = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 7;

        // this.tttabpage1 = new TTVisual.TTTabPage();
        // this.tttabpage1.DisplayIndex = 0;
        // this.tttabpage1.BackColor = "#FFFFFF";
        // this.tttabpage1.TabIndex = 0;
        // this.tttabpage1.Text = "Hizmet/Malzeme/İlaç Kalemleri";
        // this.tttabpage1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        // this.tttabpage1.Name = "tttabpage1";

        this.GRIDReceiptBackDetails = new TTVisual.TTGrid();
        this.GRIDReceiptBackDetails.HideCancelledData = false;
        this.GRIDReceiptBackDetails.AllowUserToDeleteRows = false;
        this.GRIDReceiptBackDetails.AllowUserToOrderColumns = true;
        this.GRIDReceiptBackDetails.AllowUserToResizeRows = false;
        this.GRIDReceiptBackDetails.AllowUserToAddRows = false;
        this.GRIDReceiptBackDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GRIDReceiptBackDetails.Text = "GRIDReceiptBackDetails";
        this.GRIDReceiptBackDetails.Name = "GRIDReceiptBackDetails";
        this.GRIDReceiptBackDetails.TabIndex = 0;
        this.GRIDReceiptBackDetails.Height = 220;

        this.ActionDate = new TTVisual.TTDateTimePickerColumn();
        this.ActionDate.Format = DateTimePickerFormat.Custom;
        this.ActionDate.CustomFormat = "dd.MM.yyyy";
        this.ActionDate.DataMember = "ActionDate";
        this.ActionDate.DisplayIndex = 0;
        this.ActionDate.HeaderText = i18n("M16886", "İşlem Tarihi");
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.ReadOnly = true;
        //this.ActionDate.Width = 70;

        this.EXTERNALCODE = new TTVisual.TTTextBoxColumn();
        this.EXTERNALCODE.DataMember = "ExternalCode";
        this.EXTERNALCODE.DisplayIndex = 1;
        this.EXTERNALCODE.HeaderText = i18n("M16860", "İşlem Kodu");
        this.EXTERNALCODE.Name = "EXTERNALCODE";
        this.EXTERNALCODE.ReadOnly = true;
        //this.EXTERNALCODE.Width = 80;

        this.Description = new TTVisual.TTTextBoxColumn();
        this.Description.DataMember = "Description";
        this.Description.DisplayIndex = 2;
        this.Description.HeaderText = i18n("M16819", "İşlem Açıklaması");
        this.Description.Name = "Description";
        this.Description.ReadOnly = true;
        this.Description.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 3;
        this.Amount.HeaderText = i18n("M10505", "Adet");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        //this.Amount.Width = 40;

        this.UNITPRICE = new TTVisual.TTTextBoxColumn();
        this.UNITPRICE.DataMember = "UnitPrice";
        this.UNITPRICE.DisplayIndex = 4;
        this.UNITPRICE.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UNITPRICE.Name = "UNITPRICE";
        this.UNITPRICE.ReadOnly = true;
        //this.UNITPRICE.Width = 80;

        this.TOTALPRICE = new TTVisual.TTTextBoxColumn();
        this.TOTALPRICE.DataMember = "TotalPrice";
        this.TOTALPRICE.DisplayIndex = 5;
        this.TOTALPRICE.HeaderText = i18n("M23492", "Toplam Fiyatı");
        this.TOTALPRICE.Name = "TOTALPRICE";
        this.TOTALPRICE.ReadOnly = true;
        //this.TOTALPRICE.Width = 80;

        this.PAYMENTPRICE = new TTVisual.TTTextBoxColumn();
        this.PAYMENTPRICE.DataMember = "PaymentPrice";
        this.PAYMENTPRICE.DisplayIndex = 6;
        this.PAYMENTPRICE.HeaderText = i18n("M19887", "Ödenen Tutar");
        this.PAYMENTPRICE.Name = "PAYMENTPRICE";
        this.PAYMENTPRICE.ReadOnly = true;
        //this.PAYMENTPRICE.Width = 100;

        this.STATE = new TTVisual.TTTextBoxColumn();
        this.STATE.DataMember = "State";
        this.STATE.DisplayIndex = 7;
        this.STATE.HeaderText = "Durum";
        this.STATE.Name = "STATE";
        this.STATE.ReadOnly = true;
        //this.STATE.Width = 60;

        this.RETURN = new TTVisual.TTCheckBoxColumn();
        this.RETURN.DataMember = "Return";
        this.RETURN.DisplayIndex = 8;
        this.RETURN.HeaderText = i18n("M16044", "İade");
        this.RETURN.Name = "RETURN";
        this.RETURN.EnabledBindingPath = "Editable";
        //this.RETURN.Width = 60;

        this.READONLYFLAG = new TTVisual.TTTextBoxColumn();
        this.READONLYFLAG.DataMember = "ReadOnlyFlag";
        this.READONLYFLAG.DisplayIndex = 9;
        this.READONLYFLAG.HeaderText = "ReadOnlyFlag";
        this.READONLYFLAG.Name = "READONLYFLAG";
        this.READONLYFLAG.ReadOnly = true;
        this.READONLYFLAG.Visible = false;
        //this.READONLYFLAG.Width = 100;

        this.TOTALDISCOUNTEDPRICE = new TTVisual.TTTextBoxColumn();
        this.TOTALDISCOUNTEDPRICE.DataMember = "TotalDiscountedPrice";
        this.TOTALDISCOUNTEDPRICE.DisplayIndex = 10;
        this.TOTALDISCOUNTEDPRICE.HeaderText = "İnd.Topl.Fiyat";
        this.TOTALDISCOUNTEDPRICE.Name = "TOTALDISCOUNTEDPRICE";
        this.TOTALDISCOUNTEDPRICE.ReadOnly = true;
        this.TOTALDISCOUNTEDPRICE.Visible = false;
        //this.TOTALDISCOUNTEDPRICE.Width = 80;

        this.CASHOFFICENAME = new TTVisual.TTTextBox();
        this.CASHOFFICENAME.BackColor = "#F0F0F0";
        this.CASHOFFICENAME.ReadOnly = true;
        this.CASHOFFICENAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHOFFICENAME.Name = "CASHOFFICENAME";
        this.CASHOFFICENAME.TabIndex = 0;

        this.RETURNTOTALPRICE = new TTVisual.TTTextBox();
        this.RETURNTOTALPRICE.BackColor = "#F0F0F0";
        this.RETURNTOTALPRICE.ReadOnly = true;
        this.RETURNTOTALPRICE.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RETURNTOTALPRICE.Name = "RETURNTOTALPRICE";
        this.RETURNTOTALPRICE.TabIndex = 9;

        this.CASHIERLOGID = new TTVisual.TTTextBox();
        this.CASHIERLOGID.BackColor = "#F0F0F0";
        this.CASHIERLOGID.ReadOnly = true;
        this.CASHIERLOGID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERLOGID.Name = "CASHIERLOGID";
        this.CASHIERLOGID.TabIndex = 2;
        this.CASHIERLOGID.Visible = false;

        this.CASHIERNAME = new TTVisual.TTTextBox();
        this.CASHIERNAME.BackColor = "#F0F0F0";
        this.CASHIERNAME.ReadOnly = true;
        this.CASHIERNAME.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CASHIERNAME.Name = "CASHIERNAME";
        this.CASHIERNAME.TabIndex = 1;

        this.REASONOFRETURN = new TTVisual.TTTextBox();
        this.REASONOFRETURN.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.REASONOFRETURN.Name = "REASONOFRETURN";
        this.REASONOFRETURN.TabIndex = 6;

        this.RECEIPTNO = new TTVisual.TTTextBox();
        this.RECEIPTNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RECEIPTNO.Name = "RECEIPTNO";
        this.RECEIPTNO.TabIndex = 3;
        this.RECEIPTNO.Visible = false;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M23526", "Toplam Tutar");
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 16;
        this.ttlabel1.Visible = false;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = i18n("M16071", "İade Sebebi");
        this.ttlabel8.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.ForeColor = "#000000";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 13;

        this.BTNLISTDETAIL = new TTVisual.TTButton();
        this.BTNLISTDETAIL.Text = i18n("M19292", "Muhasebe Yetkilisi Mutemedi Alındısı Detaylarını Listele");
        this.BTNLISTDETAIL.Name = "BTNLISTDETAIL";
        this.BTNLISTDETAIL.TabIndex = 4;
        this.BTNLISTDETAIL.Visible = false;

        this.labelCashOfficeName = new TTVisual.TTLabel();
        this.labelCashOfficeName.Text = i18n("M24129", "Vezne Adı");
        this.labelCashOfficeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCashOfficeName.ForeColor = "#000000";
        this.labelCashOfficeName.Name = "labelCashOfficeName";
        this.labelCashOfficeName.TabIndex = 8;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M16063", "İade Edilecek Tutar");
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 17;

        this.GRIDReceiptBackDetailsColumns = [this.ActionDate, this.EXTERNALCODE, this.Description, this.Amount, this.UNITPRICE, this.TOTALPRICE, this.PAYMENTPRICE, this.STATE, this.RETURN, this.READONLYFLAG, this.TOTALDISCOUNTEDPRICE];
        /*this.tttabcontrol1.Controls = [this.tttabpage1];*/
        /*this.tttabpage1.Controls = [this.GRIDReceiptBackDetails];*/
        this.Controls = [this.ttcheckbox1, this.ttlabel4, this.lstBoxReceipts, this.DATEOFRETURN, this.labelOfficerName, /*this.RECEIPTTOTALPRICE*/, this.ttlabel3, this.ttlabel7, this.labelCashierLogId, this.tttabcontrol1, /*this.tttabpage1,*/ this.GRIDReceiptBackDetails, this.ActionDate, this.EXTERNALCODE, this.Description, this.Amount, this.UNITPRICE, this.TOTALPRICE, this.PAYMENTPRICE, this.STATE, this.RETURN, this.READONLYFLAG, this.TOTALDISCOUNTEDPRICE, this.CASHOFFICENAME, this.RETURNTOTALPRICE, this.CASHIERLOGID, this.CASHIERNAME, this.REASONOFRETURN, this.RECEIPTNO, this.ttlabel1, this.ttlabel8, this.BTNLISTDETAIL, this.labelCashOfficeName, this.ttlabel2];

    }


}
