//$A62F0774
import { Component, OnInit, NgZone } from '@angular/core';
import { DrugReturnActionCompletedFormViewModel } from './DrugReturnActionCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DrugReturnAction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { DrugReturnActionService } from 'ObjectClassService/DrugReturnActionService';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';

import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";

@Component({
    selector: 'DrugReturnActionCompletedForm',
    templateUrl: './DrugReturnActionCompletedForm.html',
    providers: [MessageService]
})
export class DrugReturnActionCompletedForm extends TTVisual.TTForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountDrugReturnActionDetail: TTVisual.ITTTextBoxColumn;
    DrugOrderTransactionDrugReturnActionDetail: TTVisual.ITTListBoxColumn;
    DrugReturnActionDetails: TTVisual.ITTGrid;
    ID: TTVisual.ITTTextBox;
    DrugReturnReason: TTVisual.ITTTextBox;
    labelActionDate: TTVisual.ITTLabel;
    labelID: TTVisual.ITTLabel;
    labelPharmacyStoreDefinition: TTVisual.ITTLabel;
    PharmacyStoreDefinition: TTVisual.ITTObjectListBox;
    SendAmount: TTVisual.ITTTextBoxColumn;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    tttextbox1: TTVisual.ITTTextBox;

    _documentRecordLogs: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();

    public DrugReturnActionDetailsColumns = [];
    public drugReturnActionCompletedFormViewModel: DrugReturnActionCompletedFormViewModel = new DrugReturnActionCompletedFormViewModel();
    public get _DrugReturnAction(): DrugReturnAction {
        return this._TTObject as DrugReturnAction;
    }
    private DrugReturnActionCompletedForm_DocumentUrl: string = '/api/DrugReturnActionService/DrugReturnActionCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super('DRUGRETURNACTION', 'DrugReturnActionCompletedForm');
        this._DocumentServiceUrl = this.DrugReturnActionCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    protected async PreScript() {
        this._documentRecordLogs = await DrugReturnActionService.GetDocumentRecordLog(new Guid(this.drugReturnActionCompletedFormViewModel._DrugReturnAction.ObjectID.toString()));
        if (this._documentRecordLogs != null) {
            this.disabledCreateDocumentRecordlog = false;
            this.disabledCreateStockIn = true;
            this.disabledReport = false;
            for (let doc of this._documentRecordLogs) {
                if (doc.ReceiptNumber !== null && doc.ReceiptNumber !== undefined) {
                    this.disabledSendMkys = true;
                } else {
                    this.disabledSendMkys = false;
                }
            }
        } else {
            this.disabledCreateDocumentRecordlog = true;
            this.disabledCreateStockIn = false;
            this.disabledReport = true;
            this.disabledSendMkys = true;
        }
    }
    public disabledCreateDocumentRecordlog: boolean = false;
    public disabledCreateStockIn: boolean = false;
    public disabledSendMkys: boolean = false;
    public disabledReport: boolean = false;

    public mkysSonucMesaj: string;
    popupVisible: boolean = false;


    public showLoadPanel:boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            //await this.StockIn_Click();
            let params = <any>(<ModalActionResult>result).Param;
            if (this._DrugReturnAction.CurrentStateDefID.toString() === DrugReturnAction.DrugReturnActionStates.Completed.id) {
                for (let log of this._documentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        let _stockaction: StockAction = await this.objectContextService.getObject<StockAction>(new Guid(log.StockAction.toString()), StockAction.ObjectDefID);
                        this.showLoadPanel = true;
                        this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(_stockaction, params.password);
                        this.showLoadPanel = false;
                    }
                    if (log.ReceiptNumber != null)
                        this.mkysSonucMesaj += log.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                }
            }
            if (this._DrugReturnAction.CurrentStateDefID.toString() === DrugReturnAction.DrugReturnActionStates.Cancelled.id) {
                this.showLoadPanel = true;
                for (let log_1 of this._documentRecordLogs) {
                    if (log_1.ReceiptNumber != null)
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(log_1.StockAction, false, log_1.ReceiptNumber.Value, params.password);

                }
                this.showLoadPanel = false;
            }
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false )
                this.popupVisible = true;
        }
    }

    public async DeleteFromMkys(): Promise<void> {
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            //await this.StockIn_Click();
            let params = <any>(<ModalActionResult>result).Param;
            for (let log_1 of this._documentRecordLogs) {
                if (log_1.ReceiptNumber != null)
                    this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(log_1.StockAction, false, log_1.ReceiptNumber.Value, params.password);

            }
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
        }
    }
    private async StockIn_Click() {
        if (this._DrugReturnAction.StockInActions === undefined || this._DrugReturnAction.StockInActions === null) {
            let stockInbool: boolean = await DrugReturnActionService.CreateStockInAction(this._DrugReturnAction, this._DrugReturnAction.ObjectContext);
            if (stockInbool) {
                this.disabledCreateDocumentRecordlog = true;
                this.disabledCreateStockIn = false;
                this.disabledReport = true;
                this.disabledSendMkys = true;
            }
            else {
                this.disabledCreateDocumentRecordlog = true;
                this.disabledCreateStockIn = false;
                this.disabledReport = true;
                this.disabledSendMkys = true;
            }
        }
    }

    private async StockDocumentRecordlog_Click() {
        try {
            if (this._DrugReturnAction.StockInActions === undefined || this._DrugReturnAction.StockInActions === null) {
                let stockInbool: boolean = await DrugReturnActionService.CreateDocumentRecordLog(this._DrugReturnAction);
                if (stockInbool) {
                    this.disabledCreateDocumentRecordlog = true;
                    this.disabledCreateStockIn = false;
                    this.disabledReport = true;
                    this.disabledSendMkys = true;
                }
                else {
                    this.disabledCreateDocumentRecordlog = true;
                    this.disabledCreateStockIn = false;
                    this.disabledReport = true;
                    this.disabledSendMkys = true;
                }
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }
    }

    public async prepareDocument_Click(): Promise<void> {
        for (let document of this._documentRecordLogs) {
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                const objectIdParam = new GuidParam(document.StockAction.ObjectID);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
            }
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                const objectIdParam = new GuidParam(document.StockAction.ObjectID);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
            }
        }
    }

    // *****Method declarations end *****
    GridDiagnosisGridList;
    public initViewModel(): void {
        this._TTObject = new DrugReturnAction();
        this.drugReturnActionCompletedFormViewModel = new DrugReturnActionCompletedFormViewModel();
        this._ViewModel = this.drugReturnActionCompletedFormViewModel;
        this.drugReturnActionCompletedFormViewModel._DrugReturnAction = this._TTObject as DrugReturnAction;
        this.drugReturnActionCompletedFormViewModel._DrugReturnAction.Episode = new Episode();
        this.drugReturnActionCompletedFormViewModel._DrugReturnAction.Episode.Patient = new Patient();
        this.drugReturnActionCompletedFormViewModel._DrugReturnAction.PharmacyStoreDefinition = new PharmacyStoreDefinition();
        this.drugReturnActionCompletedFormViewModel._DrugReturnAction.DrugReturnActionDetails = new Array<DrugReturnActionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.drugReturnActionCompletedFormViewModel = this._ViewModel as DrugReturnActionCompletedFormViewModel;
        that._TTObject = this.drugReturnActionCompletedFormViewModel._DrugReturnAction;
        if (this.drugReturnActionCompletedFormViewModel == null)
            this.drugReturnActionCompletedFormViewModel = new DrugReturnActionCompletedFormViewModel();
        if (this.drugReturnActionCompletedFormViewModel._DrugReturnAction == null)
            this.drugReturnActionCompletedFormViewModel._DrugReturnAction = new DrugReturnAction();
        /* let episodeObjectID = that.drugReturnActionCompletedFormViewModel._DrugReturnAction["Episode"];
         if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
             let episode = that.drugReturnActionCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             that.drugReturnActionCompletedFormViewModel._DrugReturnAction.Episode = episode;
             if (episode != null) {
                 let patientObjectID = episode["Patient"];
                 if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                     let patient = that.drugReturnActionCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                     episode.Patient = patient;
                 }
             }
         }*/
        let pharmacyStoreDefinitionObjectID = that.drugReturnActionCompletedFormViewModel._DrugReturnAction['PharmacyStoreDefinition'];
        if (pharmacyStoreDefinitionObjectID != null && (typeof pharmacyStoreDefinitionObjectID === 'string')) {
            let pharmacyStoreDefinition = that.drugReturnActionCompletedFormViewModel.PharmacyStoreDefinitions.find(o => o.ObjectID.toString() === pharmacyStoreDefinitionObjectID.toString());
            if (pharmacyStoreDefinition) {
                that.drugReturnActionCompletedFormViewModel._DrugReturnAction.PharmacyStoreDefinition = pharmacyStoreDefinition;
            }
        }
        that.drugReturnActionCompletedFormViewModel._DrugReturnAction.DrugReturnActionDetails = that.drugReturnActionCompletedFormViewModel.DrugReturnActionDetailsGridList;
        for (let detailItem of that.drugReturnActionCompletedFormViewModel.DrugReturnActionDetailsGridList) {
            let drugOrderTransactionObjectID = detailItem['DrugOrderTransaction'];
            if (drugOrderTransactionObjectID != null && (typeof drugOrderTransactionObjectID === 'string')) {
                let drugOrderTransaction = that.drugReturnActionCompletedFormViewModel.DrugOrderTransactions.find(o => o.ObjectID.toString() === drugOrderTransactionObjectID.toString());
                if (drugOrderTransaction) {
                    detailItem.DrugOrderTransaction = drugOrderTransaction;
                }
                if (drugOrderTransaction != null) {
                    let drugOrderObjectID = drugOrderTransaction['DrugOrder'];
                    if (drugOrderObjectID != null && (typeof drugOrderObjectID === 'string')) {
                        let drugOrder = that.drugReturnActionCompletedFormViewModel.DrugOrders.find(o => o.ObjectID.toString() === drugOrderObjectID.toString());
                        if (drugOrder) {
                            drugOrderTransaction.DrugOrder = drugOrder;
                        }
                        if (drugOrder != null) {
                            let materialObjectID = drugOrder['Material'];
                            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                                let material = that.drugReturnActionCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                                if (material) {
                                    drugOrder.Material = material;
                                }
                            }
                        }
                    }
                }
            }
        }
        let episodeObjectID = that.drugReturnActionCompletedFormViewModel._DrugReturnAction['Episode'];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.drugReturnActionCompletedFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.drugReturnActionCompletedFormViewModel._DrugReturnAction.Episode = episode;
            }
            if (episode != null) {
                let patientObjectID = episode['Patient'];
                if (patientObjectID != null && (typeof patientObjectID === 'string')) {
                    let patient = that.drugReturnActionCompletedFormViewModel.Patients.find(o => o.ObjectID.toString() === patientObjectID.toString());
                    if (patient) {
                        episode.Patient = patient;
                    }
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(DrugReturnActionCompletedFormViewModel);
        if (this._DrugReturnAction.CurrentStateDefID.toString() == DrugReturnAction.DrugReturnActionStates.Completed.id.toString()) {
            this.FormCaption = i18n("M12437", "İlaç İade Belgesi ( Tamamlandı )");
        }
        if (this._DrugReturnAction.CurrentStateDefID.toString() == DrugReturnAction.DrugReturnActionStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M12435", "İlaç İade Belgesi ( İptal Edildi )");
        }

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ActionDate !== event) {
                this._DrugReturnAction.ActionDate = event;
            }
        }
    }

    public onIDChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.ID !== event) {
                this._DrugReturnAction.ID = event;
            }
        }
    }

    public onPharmacyStoreDefinitionChanged(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null && this._DrugReturnAction.PharmacyStoreDefinition !== event) {
                this._DrugReturnAction.PharmacyStoreDefinition = event;
            }
        }
    }

    public ontttextbox1Changed(event): void {
        if (event != null) {
            if (this._DrugReturnAction != null &&
                this._DrugReturnAction.Episode != null &&
                this._DrugReturnAction.Episode.Patient != null && this._DrugReturnAction.Episode.Patient.FullName !== event) {
                this._DrugReturnAction.Episode.Patient.FullName = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.ID, 'Text', this.__ttObject, 'ID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.tttextbox1, 'Text', this.__ttObject, 'Episode.Patient.FullName');
    }

    public initFormControls(): void {
        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 5;

        this.labelID = new TTVisual.TTLabel();
        this.labelID.Text = 'İşlem No';
        this.labelID.Name = 'labelID';
        this.labelID.TabIndex = 10;

        this.ID = new TTVisual.TTTextBox();
        this.ID.BackColor = '#F0F0F0';
        this.ID.ReadOnly = true;
        this.ID.Name = 'ID';
        this.ID.TabIndex = 9;

        this.DrugReturnReason = new TTVisual.TTTextBox();
        this.DrugReturnReason.Name = 'DrugReturnReason';
        this.DrugReturnReason.TabIndex = 9;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.BackColor = '#F0F0F0';
        this.tttextbox1.ReadOnly = true;
        this.tttextbox1.Name = 'tttextbox1';
        this.tttextbox1.TabIndex = 11;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = 'İşlem Tarihi';
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = 'Hasta Adı Soyadı';
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 6;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = 'İlaçlar';
        this.ttlabel2.Name = 'ttlabel2';
        this.ttlabel2.TabIndex = 10;

        this.PharmacyStoreDefinition = new TTVisual.TTObjectListBox();
        this.PharmacyStoreDefinition.ReadOnly = true;
        this.PharmacyStoreDefinition.ListDefName = 'StoresList';
        this.PharmacyStoreDefinition.Name = 'PharmacyStoreDefinition';
        this.PharmacyStoreDefinition.TabIndex = 13;

        this.labelPharmacyStoreDefinition = new TTVisual.TTLabel();
        this.labelPharmacyStoreDefinition.Text = i18n("M13452", "Eczane");
        this.labelPharmacyStoreDefinition.Name = 'labelPharmacyStoreDefinition';
        this.labelPharmacyStoreDefinition.TabIndex = 14;

        this.DrugReturnActionDetails = new TTVisual.TTGrid();
        this.DrugReturnActionDetails.ReadOnly = true;
        this.DrugReturnActionDetails.Name = 'DrugReturnActionDetails';
        this.DrugReturnActionDetails.TabIndex = 12;
        this.DrugReturnActionDetails.AllowUserToAddRows = false;
        this.DrugReturnActionDetails.AllowUserToDeleteRows = false;

        this.DrugOrderTransactionDrugReturnActionDetail = new TTVisual.TTListBoxColumn();
        this.DrugOrderTransactionDrugReturnActionDetail.ListDefName = 'DrugList';
        this.DrugOrderTransactionDrugReturnActionDetail.DataMember = 'DrugOrderTransaction.DrugOrder.Material';
        this.DrugOrderTransactionDrugReturnActionDetail.DisplayIndex = 0;
        this.DrugOrderTransactionDrugReturnActionDetail.HeaderText = 'İlaç';
        this.DrugOrderTransactionDrugReturnActionDetail.Name = 'DrugOrderTransactionDrugReturnActionDetail';
        this.DrugOrderTransactionDrugReturnActionDetail.ReadOnly = true;
        this.DrugOrderTransactionDrugReturnActionDetail.Width = 400;

        this.SendAmount = new TTVisual.TTTextBoxColumn();
        this.SendAmount.DataMember = 'SendAmount';
        this.SendAmount.DisplayIndex = 1;
        this.SendAmount.HeaderText = 'Gön. Miktar';
        this.SendAmount.Name = 'SendAmount';
        this.SendAmount.ReadOnly = true;
        this.SendAmount.Width = 100;

        this.AmountDrugReturnActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountDrugReturnActionDetail.DataMember = 'Amount';
        this.AmountDrugReturnActionDetail.DisplayIndex = 2;
        this.AmountDrugReturnActionDetail.HeaderText = i18n("M17019", "Kabul Edilen Miktar");
        this.AmountDrugReturnActionDetail.Name = 'AmountDrugReturnActionDetail';
        this.AmountDrugReturnActionDetail.ReadOnly = true;
        this.AmountDrugReturnActionDetail.Width = 200;

        this.DrugReturnActionDetailsColumns = [this.DrugOrderTransactionDrugReturnActionDetail, this.SendAmount, this.AmountDrugReturnActionDetail];
        this.Controls = [this.ActionDate, this.labelID, this.ID, this.DrugReturnReason, this.tttextbox1, this.labelActionDate, this.ttlabel1, this.ttlabel2,
        this.PharmacyStoreDefinition, this.labelPharmacyStoreDefinition, this.DrugReturnActionDetails, this.DrugOrderTransactionDrugReturnActionDetail,
        this.SendAmount, this.AmountDrugReturnActionDetail];

    }


}
