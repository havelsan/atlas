//$39BBF341
import { Component, OnInit, NgZone } from '@angular/core';
import { CensusFixedCompletedFormViewModel } from './CensusFixedCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseCensusFixedForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Sayim_Duzeltme_Belgesi_Modulu/BaseCensusFixedForm";
import { CensusFixed } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialIn } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import Exception from 'app/NebulaClient/System/Exception';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'CensusFixedCompletedForm',
    templateUrl: './CensusFixedCompletedForm.html',
    providers: [MessageService]
})
export class CensusFixedCompletedForm extends BaseCensusFixedForm implements OnInit {
    BUDGETYPE: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    documentRecordLogTab: TTVisual.ITTTabPage;
    DocumentRecordLogTabpage: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    labelRegistrationNumber: TTVisual.ITTLabel;
    labelSequenceNumber: TTVisual.ITTLabel;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    RegistrationNumber: TTVisual.ITTTextBox;
    SendToMKYS: TTVisual.ITTButton;
    SequenceNumber: TTVisual.ITTTextBox;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttabcontrol1: TTVisual.ITTTabControl;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public DocumentRecordLogsColumns = [];
    public StockActionInDetailsColumns = [];
    public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public censusFixedCompletedFormViewModel: CensusFixedCompletedFormViewModel = new CensusFixedCompletedFormViewModel();
    public get _CensusFixed(): CensusFixed {
        return this._TTObject as CensusFixed;
    }
    private CensusFixedCompletedForm_DocumentUrl: string = '/api/CensusFixedService/CensusFixedCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.CensusFixedCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        this.SendToMKYS.ReadOnly = false;
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._CensusFixed.ObjectID.toString());
        for (let document of documentRecordLogs) {
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
            }
            if (document.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                const objectIdParam = new GuidParam(document['ObjectID']);
                const budgetTypeIdParam = new IntegerParam(document.BudgeType.Value);
                let reportParameters: any = { 'TTOBJECTID': objectIdParam, 'BUDGETTYPE': budgetTypeIdParam };
                this.reportService.showReport('ChattelDocumentOutDetailReport', reportParameters);
            }
        }
    }

    	
	 public showLoadPanel:boolean = false;
     public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        //-TODO İlaydax
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            let documetrecords: Array<DocumentRecordLog> = await this._CensusFixed.DocumentRecordLogs.sort((a, b) => a.DocumentRecordLogNumber - b.DocumentRecordLogNumber);
            if (this._CensusFixed.CurrentStateDefID.toString() === CensusFixed.CensusFixedStates.Completed.id) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_1.ReceiptNumber == null) {
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForOutputDocumentTS(this._CensusFixed, params.password);
                        }
                        if (log_1.ReceiptNumber != null)
                            this.mkysSonucMesaj += log_1.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                    }
                }
                //-TODO İlaydax
                this.popupVisible = true;
                for (let log_2 of documetrecords) {
                    if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_2.ReceiptNumber == null) {
                            let params = <any>(<ModalActionResult>result).Param;
                            this.mkysSonucMesaj = await StockActionService.SendMKYSForInputDocumentTS(this._CensusFixed, params.password);
                        }
                        if (log_2.ReceiptNumber != null)
                            this.mkysSonucMesaj += log_2.ReceiptNumber.toString() + " Ayniyat numarası ile MKYSye kaydolmuştur.";
                    }
                }
                this.popupVisible = true;
            }
            //-TODO İlaydax
            if (this._CensusFixed.CurrentStateDefID.id === CensusFixed.CensusFixedStates.Cancelled.toString()) {
                for (let log_1 of documetrecords) {
                    if (log_1.DocumentTransactionType === DocumentTransactionTypeEnum.In) {
                        if (log_1.ReceiptNumber != null) {
                            this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._CensusFixed, false, log_1.ReceiptNumber.Value, params.password);
                        }
                    }
                }
                //-TODO İlaydax
                this.popupVisible = true;
                for (let log_2 of documetrecords) {
                    if (log_2.DocumentTransactionType === DocumentTransactionTypeEnum.Out) {
                        if (log_2.ReceiptNumber != null) {
                            this.mkysSonucMesaj += await StockActionService.SendDeleteMessageToMkysTS(this._CensusFixed, true, log_2.ReceiptNumber.Value, params.password);
                        }
                    }
                }
                this.showLoadPanel =false;
                this.popupVisible = true;
            }
        }
    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    onCellContentClickedInDetail(data: any) { }
    initNewRowInDetail(data: any) { }
    onRowInserttingInDetail(data: any) { }
    onSelectionChangeInDetail(data: any) { }
    onCellContentClickedOutDetail(data: any) { }
    initNewRowOutDetail(data: any) { }
    onRowInserttingOutDetail(data: any) { }
    onSelectionChangeOutDetail(data: any) { }
    DocumentRecordLogs_CellValueChangedEmitted(data: any) { }
    initDocumentRecordLogsNewRow(data: any) { }
    onDocumentRecordLogsRowInserting(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CensusFixed();
        this.censusFixedCompletedFormViewModel = new CensusFixedCompletedFormViewModel();
        this._ViewModel = this.censusFixedCompletedFormViewModel;
        this.censusFixedCompletedFormViewModel._CensusFixed = this._TTObject as CensusFixed;
        this.censusFixedCompletedFormViewModel._CensusFixed.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.censusFixedCompletedFormViewModel._CensusFixed.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.censusFixedCompletedFormViewModel._CensusFixed.Store = new Store();
        this.censusFixedCompletedFormViewModel._CensusFixed.CensusFixedInMaterials = new Array<CensusFixedMaterialIn>();
        this.censusFixedCompletedFormViewModel._CensusFixed.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.censusFixedCompletedFormViewModel._CensusFixed.CensusFixedOutMaterials = new Array<CensusFixedMaterialOut>();
    }

    protected loadViewModel() {
        let that = this;
        that.censusFixedCompletedFormViewModel = this._ViewModel;
        that._TTObject = this.censusFixedCompletedFormViewModel._CensusFixed;
        if (this.censusFixedCompletedFormViewModel == null)
            this.censusFixedCompletedFormViewModel = new CensusFixedCompletedFormViewModel();
        if (this.censusFixedCompletedFormViewModel._CensusFixed == null)
            this.censusFixedCompletedFormViewModel._CensusFixed = new CensusFixed();
        that.censusFixedCompletedFormViewModel._CensusFixed.DocumentRecordLogs = that.censusFixedCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.censusFixedCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        let budgetTypeDefinitionObjectID = that.censusFixedCompletedFormViewModel._CensusFixed["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.censusFixedCompletedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.censusFixedCompletedFormViewModel._CensusFixed.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.censusFixedCompletedFormViewModel._CensusFixed["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.censusFixedCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.censusFixedCompletedFormViewModel._CensusFixed.Store = store;
            }
        }
        that.censusFixedCompletedFormViewModel._CensusFixed.CensusFixedInMaterials = that.censusFixedCompletedFormViewModel.StockActionInDetailsGridList;
        for (let detailItem of that.censusFixedCompletedFormViewModel.StockActionInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.censusFixedCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.censusFixedCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.censusFixedCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.censusFixedCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.censusFixedCompletedFormViewModel._CensusFixed.StockActionSignDetails = that.censusFixedCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.censusFixedCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.censusFixedCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.censusFixedCompletedFormViewModel._CensusFixed.CensusFixedOutMaterials = that.censusFixedCompletedFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.censusFixedCompletedFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.censusFixedCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.censusFixedCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.censusFixedCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.censusFixedCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(CensusFixedCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        this.DocumentRecordLogSearch.ReadOnly = false;
        if (this._CensusFixed.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._CensusFixed.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M21415", "Sayım Düzeltme Belgesi ( Tamamlandı )");
  
    }

    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._CensusFixed.DocumentRecordLogs) {
            if (log.ReceiptNumber != null) {
                this.receiptNumberError = this.receiptNumberError + "." + log.ReceiptNumber.toString();
                this.controlOfCancelMKYS = false;
            }
        }

        if (this.controlOfCancelMKYS) {
            await super.ClientSidePostScript(transDef);
        }
        else {
            throw new Exception("MKYS'den silinmeyen fiş iptal edilemez. Lütfen önce fişi siliniz!" + this.receiptNumberError + " Ayniyatlı Kayıtları Siliniz.!");
            this.receiptNumberError = "";
        }
    }


    async onDocumentRecordLogsCellContentClicked(data: any) {
        if (data && this.onDocumentRecordLogsCellContentClicked && data.Row && data.Column) {
            let documentLog: DocumentRecordLog = <DocumentRecordLog>(data.Row.TTObject);
            if (documentLog.ReceiptNumber != null) {
                let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
                input.receiptNumber = documentLog.ReceiptNumber;
                if (data.Column.Name === 'GetLogFromMkys') {
                    let result = await UsernamePwdBox.Show(true);
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        input.password = params.password;
                        let getLogs: Array<MkysServis.stokHareketLogItem> = await StockActionService.GetMkysLogSearch(input);
                        this.showSelectMkysLog(getLogs);
                    }
                }
                if (data.Column.Name === 'DeleteMkysRow') {
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '',documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
                    if (resultMessage === "OK"){
                        let result = await UsernamePwdBox.Show(true);
                        if ((<ModalActionResult>result).Result == DialogResult.OK) {
                            let params = <any>(<ModalActionResult>result).Param;
                            input.password = params.password;
                            input.documentRecordLogObjectID = documentLog.ObjectID.toString()
                            let deleteMessage: boolean = await StockActionService.DeleteMkysSelectedRow(input);
                            if (deleteMessage) {
                                ServiceLocator.MessageService.showInfo("MKYS'den Silme yapılmıştır.");
                                documentLog.ReceiptNumber = null;
                            } else {
                                ServiceLocator.MessageService.showError("Tekrar Deneyiniz Silme İşlemi Sırasında Hata Alındı.");
                            }
                        }
                    }
                }
            }
            else {
                ServiceLocator.MessageService.showInfo("Ayniyat ID Boş olduğundan bu işlem yapılamaz!");
            }
        }
    }

    private showSelectMkysLog(data: Array<MkysServis.stokHareketLogItem>): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MkysLogComponent";
            componentInfo.ModuleName = "LogisticFormsModule";
            componentInfo.ModulePath = "/app/Logistic/LogisticFormsModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "MKYS Log Sorgu";
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.BudgetTypeDefinition != event) {
                this._CensusFixed.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.Description != event) {
                this._CensusFixed.Description = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.MKYS_EMalzemeGrup != event) {
                this._CensusFixed.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._CensusFixed.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._CensusFixed != null && this._CensusFixed.MKYS_TeslimAlan != event) {
                this._CensusFixed.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._CensusFixed.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = "#F0F0F0";
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._CensusFixed != null && this._CensusFixed.MKYS_TeslimEden != event) {
                this._CensusFixed.MKYS_TeslimEden = event;
            }
        }
    }

    public onRegistrationNumberChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.RegistrationNumber != event) {
                this._CensusFixed.RegistrationNumber = event;
            }
        }
    }

    public onSequenceNumberChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.SequenceNumber != event) {
                this._CensusFixed.SequenceNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.StockActionID != event) {
                this._CensusFixed.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.Store != event) {
                this._CensusFixed.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._CensusFixed != null && this._CensusFixed.TransactionDate != event) {
                this._CensusFixed.TransactionDate = event;
            }
        }
    }



    StockActionInDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionInDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionInDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    StockActionOutDetails_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionOutDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionOutDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.MKYS_EMalzemeGrup, "Value", this.__ttObject, "MKYS_EMalzemeGrup");
        redirectProperty(this.RegistrationNumber, "Text", this.__ttObject, "RegistrationNumber");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.SequenceNumber, "Text", this.__ttObject, "SequenceNumber");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.DocumentRecordLogTabpage = new TTVisual.TTTabPage();
        this.DocumentRecordLogTabpage.DisplayIndex = 2;
        this.DocumentRecordLogTabpage.TabIndex = 2;
        this.DocumentRecordLogTabpage.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTabpage.Name = "DocumentRecordLogTabpage";

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 141;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 140;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 140;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";


        this.documentRecordLogTab = new TTVisual.TTTabPage();
        this.documentRecordLogTab.DisplayIndex = 0;
        this.documentRecordLogTab.TabIndex = 0;
        this.documentRecordLogTab.Text = "Taşınır Mal İşlem Belgesi";
        this.documentRecordLogTab.Name = "documentRecordLogTab";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.HideCancelledData = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.ReadOnly = true;
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 0;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 114;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 120;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 1;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 180;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 112;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 120;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 111;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 3;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 120;

        this.InMaterialsGroupBox = new TTVisual.TTGroupBox();
        this.InMaterialsGroupBox.Text = i18n("M11114", "Arttırılanlar");
        this.InMaterialsGroupBox.Name = "InMaterialsGroupBox";
        this.InMaterialsGroupBox.TabIndex = 110;

        this.BUDGETYPE = new TTVisual.TTEnumComboBoxColumn();
        this.BUDGETYPE.DataTypeName = "MKYS_EButceTurEnum";
        this.BUDGETYPE.DataMember = "BudgeType";
        this.BUDGETYPE.DisplayIndex = 4;
        this.BUDGETYPE.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BUDGETYPE.Name = "BUDGETYPE";
        this.BUDGETYPE.ReadOnly = true;
        this.BUDGETYPE.Width = 120;

        this.StockActionInDetails = new TTVisual.TTGrid();
        this.StockActionInDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionInDetails.Name = "StockActionInDetails";
        this.StockActionInDetails.TabIndex = 0;
        this.StockActionInDetails.Height = 350;

        this.NumberOfRowsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.NumberOfRowsDocumentRecordLog.DataMember = "NumberOfRows";
        this.NumberOfRowsDocumentRecordLog.DisplayIndex = 5;
        this.NumberOfRowsDocumentRecordLog.HeaderText = i18n("M17091", "Kalem Adedi");
        this.NumberOfRowsDocumentRecordLog.Name = "NumberOfRowsDocumentRecordLog";
        this.NumberOfRowsDocumentRecordLog.Width = 120;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = "TakenGivenPlace";
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 6;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = "TakenGivenPlaceDocumentRecordLog";
        this.TakenGivenPlaceDocumentRecordLog.Width = 120;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = "60%";
        this.Material.AutoCompleteDialogWidth = "50%";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = "Material";
        this.Material.Width = 300;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 7;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 100;

        this.BarcodeA = new TTVisual.TTTextBoxColumn();
        this.BarcodeA.DataMember = "Material.Barcode";
        this.BarcodeA.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.BarcodeA.DisplayIndex = 2;
        this.BarcodeA.HeaderText = "Barkod";
        this.BarcodeA.Name = "BarcodeA";
        this.BarcodeA.ReadOnly = true;
        this.BarcodeA.Width = 120;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 8;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.SequenceNumber = new TTVisual.TTTextBox();
        this.SequenceNumber.BackColor = "#F0F0F0";
        this.SequenceNumber.ReadOnly = true;
        this.SequenceNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SequenceNumber.Name = "SequenceNumber";
        this.SequenceNumber.TabIndex = 3;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.RegistrationNumber = new TTVisual.TTTextBox();
        this.RegistrationNumber.BackColor = "#F0F0F0";
        this.RegistrationNumber.ReadOnly = true;
        this.RegistrationNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RegistrationNumber.Name = "RegistrationNumber";
        this.RegistrationNumber.TabIndex = 2;

        this.OrderSequenceNumber = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumber.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumber.DisplayIndex = 5;
        this.OrderSequenceNumber.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumber.Name = "OrderSequenceNumber";
        this.OrderSequenceNumber.Width = 100;

        this.labelRegistrationNumber = new TTVisual.TTLabel();
        this.labelRegistrationNumber.Text = i18n("M20637", "R.Belge Kayıt Nu.");
        this.labelRegistrationNumber.BackColor = "#DCDCDC";
        this.labelRegistrationNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRegistrationNumber.ForeColor = "#000000";
        this.labelRegistrationNumber.Name = "labelRegistrationNumber";
        this.labelRegistrationNumber.TabIndex = 12;

        this.CardAmount = new TTVisual.TTTextBoxColumn();
        this.CardAmount.DataMember = "CardAmount";
        this.CardAmount.Format = "N2";
        this.CardAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmount.DisplayIndex = 6;
        this.CardAmount.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmount.Name = "CardAmount";
        this.CardAmount.Width = 120;
        this.CardAmount.Visible = false;
        this.CardAmount.IsNumeric = true;

        this.labelSequenceNumber = new TTVisual.TTLabel();
        this.labelSequenceNumber.Text = i18n("M20638", "R.Belge Sıra Nu.");
        this.labelSequenceNumber.BackColor = "#DCDCDC";
        this.labelSequenceNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSequenceNumber.ForeColor = "#000000";
        this.labelSequenceNumber.Name = "labelSequenceNumber";
        this.labelSequenceNumber.TabIndex = 10;

        this.CensusAmount = new TTVisual.TTTextBoxColumn();
        this.CensusAmount.DataMember = "CensusAmount";
        this.CensusAmount.Format = "N2";
        this.CensusAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmount.DisplayIndex = 7;
        this.CensusAmount.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmount.Name = "CensusAmount";
        this.CensusAmount.Width = 100;
        this.CensusAmount.IsNumeric = true;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 8;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 120;
        this.Amount.IsNumeric = true;

        this.Unitprice = new TTVisual.TTTextBoxColumn();
        this.Unitprice.DataMember = "UnitPrice";
        this.Unitprice.Format = "N2";
        this.Unitprice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Unitprice.DisplayIndex = 9;
        this.Unitprice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.Unitprice.Name = "Unitprice";
        this.Unitprice.Width = 120;
        this.Unitprice.IsNumeric = true;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Format = "N2";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.LotNo.DisplayIndex = 10;
        this.LotNo.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 120;

        this.ExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDate.DataMember = "ExpirationDate";
        this.ExpirationDate.DisplayIndex = 11;
        this.ExpirationDate.HeaderText = "S.K.Tarihi";
        this.ExpirationDate.Name = "ExpirationDate";
        this.ExpirationDate.Width = 180;

        this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 12;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 109;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = "SignTabpage";

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 76;

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

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = "DescriptionTabpage";

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 138;

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

        this.OutMaterialsGroupBox = new TTVisual.TTGroupBox();
        this.OutMaterialsGroupBox.Text = i18n("M13593", "Eksiltilenler");
        this.OutMaterialsGroupBox.Name = "OutMaterialsGroupBox";
        this.OutMaterialsGroupBox.TabIndex = 110;

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;

        this.DetailOut = new TTVisual.TTButtonColumn();
        this.DetailOut.Text = i18n("M12671", "Detay");
        this.DetailOut.UseColumnTextForButtonValue = true;
        this.DetailOut.DisplayIndex = 0;
        this.DetailOut.HeaderText = "";
        this.DetailOut.Name = "DetailOut";
        this.DetailOut.ToolTipText = i18n("M12671", "Detay");
        this.DetailOut.Width = 80;

        this.MaterialOut = new TTVisual.TTListBoxColumn();
        this.MaterialOut.AllowMultiSelect = true;
        this.MaterialOut.ListDefName = "MaterialListDefinition";
        this.MaterialOut.DataMember = "Material";
        this.MaterialOut.DisplayIndex = 1;
        this.MaterialOut.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.MaterialOut.Name = "MaterialOut";
        this.MaterialOut.Width = 300;

        this.BarcodeE = new TTVisual.TTTextBoxColumn();
        this.BarcodeE.DataMember = "Material.Barcode";
        this.BarcodeE.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.BarcodeE.DisplayIndex = 2;
        this.BarcodeE.HeaderText = "Barkod";
        this.BarcodeE.Name = "BarcodeE";
        this.BarcodeE.ReadOnly = true;
        this.BarcodeE.Width = 120;

        this.DistributionTypeOut = new TTVisual.TTTextBoxColumn();
        this.DistributionTypeOut.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeOut.DisplayIndex = 3;
        this.DistributionTypeOut.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeOut.Name = "DistributionTypeOut";
        this.DistributionTypeOut.ReadOnly = true;
        this.DistributionTypeOut.Width = 120;

        this.StoreStockOut = new TTVisual.TTTextBoxColumn();
        this.StoreStockOut.DataMember = "StoreStock";
        this.StoreStockOut.Format = "N2";
        this.StoreStockOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStockOut.DisplayIndex = 4;
        this.StoreStockOut.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStockOut.Name = "StoreStockOut";
        this.StoreStockOut.ReadOnly = true;
        this.StoreStockOut.Width = 120;

        this.OrderSequenceNumberOut = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumberOut.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumberOut.DisplayIndex = 5;
        this.OrderSequenceNumberOut.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumberOut.Name = "OrderSequenceNumberOut";
        this.OrderSequenceNumberOut.Width = 120;

        this.CardAmountOut = new TTVisual.TTTextBoxColumn();
        this.CardAmountOut.DataMember = "CardAmount";
        this.CardAmountOut.Format = "N2";
        this.CardAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmountOut.DisplayIndex = 6;
        this.CardAmountOut.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmountOut.Name = "CardAmountOut";
        this.CardAmountOut.Width = 120;
        this.CardAmountOut.Visible = false;
        this.CardAmountOut.IsNumeric = true;

        this.CensusAmountOut = new TTVisual.TTTextBoxColumn();
        this.CensusAmountOut.DataMember = "CensusAmount";
        this.CensusAmountOut.Format = "N2";
        this.CensusAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmountOut.DisplayIndex = 7;
        this.CensusAmountOut.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmountOut.Name = "CensusAmountOut";
        this.CensusAmountOut.Width = 120;
        this.CensusAmountOut.IsNumeric = true;

        this.AmountOut = new TTVisual.TTTextBoxColumn();
        this.AmountOut.DataMember = "Amount";
        this.AmountOut.Format = "N2";
        this.AmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountOut.DisplayIndex = 8;
        this.AmountOut.HeaderText = i18n("M19030", "Miktar");
        this.AmountOut.Name = "AmountOut";
        this.AmountOut.ReadOnly = true;
        this.AmountOut.Width = 120;
        this.AmountOut.IsNumeric = true;

        this.AproximateUnitPriceOut = new TTVisual.TTTextBoxColumn();
        this.AproximateUnitPriceOut.DataMember = "AproximateUnitPrice";
        this.AproximateUnitPriceOut.DisplayIndex = 9;
        this.AproximateUnitPriceOut.HeaderText = i18n("M11036", "Anlık Birim Fiyat");
        this.AproximateUnitPriceOut.Name = "AproximateUnitPriceOut";
        this.AproximateUnitPriceOut.ReadOnly = true;
        this.AproximateUnitPriceOut.Width = 120;
        this.AproximateUnitPriceOut.Visible = false;
        this.AproximateUnitPriceOut.IsNumeric = true;

        this.StockLevelTypeOut = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeOut.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeOut.DataMember = "StockLevelType";
        this.StockLevelTypeOut.DisplayIndex = 10;
        this.StockLevelTypeOut.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeOut.Name = "StockLevelTypeOut";
        this.StockLevelTypeOut.Width = 120;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 114;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 139;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.SubjectDocumentRecordLog, this.BUDGETYPE, this.NumberOfRowsDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.ReceiptNumber, this.DescriptionsDocumentRecordLog,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];
        this.StockActionInDetailsColumns = [this.Detail, this.Material, this.BarcodeA, this.DistributionType, this.StoreStock, this.OrderSequenceNumber, this.CardAmount, this.CensusAmount, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.StockActionOutDetailsColumns = [this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut];
        this.tttabcontrol1.Controls = [this.documentRecordLogTab];
        this.documentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.InMaterialsGroupBox.Controls = [this.StockActionInDetails];
        this.DescriptionAndSignTabControl.Controls = [this.DocumentRecordLogTabpage, this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.OutMaterialsGroupBox.Controls = [this.StockActionOutDetails];
        this.Controls = [this.DocumentRecordLogTabpage, this.labelBudgetTypeDefinition, this.tttabcontrol1, this.BudgetTypeDefinition, this.documentRecordLogTab, this.Description, this.DocumentRecordLogs, this.labelMKYS_EMalzemeGrup, this.DocumentRecordLogNumberDocumentRecordLog, this.MKYS_EMalzemeGrup, this.DocumentDateTimeDocumentRecordLog, this.labelStore, this.DocumentTransactionTypeDocumentRecordLog, this.Store, this.SubjectDocumentRecordLog, this.InMaterialsGroupBox, this.BUDGETYPE, this.StockActionInDetails, this.NumberOfRowsDocumentRecordLog, this.Detail, this.TakenGivenPlaceDocumentRecordLog, this.Material, this.ReceiptNumber, this.BarcodeA, this.DescriptionsDocumentRecordLog, this.DistributionType, this.SequenceNumber, this.StoreStock, this.RegistrationNumber, this.OrderSequenceNumber, this.labelRegistrationNumber, this.CardAmount, this.labelSequenceNumber, this.CensusAmount, this.SendToMKYS, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.StockActionID, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.OutMaterialsGroupBox, this.StockActionOutDetails, this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon,this.DocumentRecordLogDeleteMKYS, this.DocumentRecordLogSearch];


    }


}
