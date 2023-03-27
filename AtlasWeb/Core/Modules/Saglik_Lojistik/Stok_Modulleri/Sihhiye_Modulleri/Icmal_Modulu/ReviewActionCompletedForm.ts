//$3216DC40
import { Component, OnInit, NgZone } from '@angular/core';
import { ReviewActionCompletedFormViewModel } from './ReviewActionCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseReviewActionForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Icmal_Modulu/BaseReviewActionForm";
import { ReviewAction } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionService } from "ObjectClassService/ReviewActionService";
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import { ReviewActionPatientDet } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'ReviewActionCompletedForm',
    templateUrl: './ReviewActionCompletedForm.html',
    providers: [MessageService]
})
export class ReviewActionCompletedForm extends BaseReviewActionForm implements OnInit {
    BudgeTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    ReceiptNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;

    public DocumentRecordLogsColumns = [];
    public ReviewActionDetailsColumns = [];
    public reviewActionCompletedFormViewModel: ReviewActionCompletedFormViewModel = new ReviewActionCompletedFormViewModel();
    public get _ReviewAction(): ReviewAction {
        return this._TTObject as ReviewAction;
    }
    private ReviewActionCompletedForm_DocumentUrl: string = '/api/ReviewActionService/ReviewActionCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.ReviewActionCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public mkysSonucMesaj: string = '';
    popupVisible: boolean = false;

    protected async PreScript() {
        await super.PreScript();

        if (this._ReviewAction.CurrentStateDefID.toString() === ReviewAction.ReviewActionStates.Cancelled.id) {
            this.FormCaption = "İlaç İcmal ( İptal Edildi )";
        }
        if (this._ReviewAction.CurrentStateDefID.toString() === ReviewAction.ReviewActionStates.Completed.id) {
            this.FormCaption = "İlaç İcmal ( Tamamlandı )";
        }

    }
    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        
        let result = await UsernamePwdBox.Show(true);
        this.mkysSonucMesaj = '';
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel = true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._ReviewAction.CurrentStateDefID.toString() === ReviewAction.ReviewActionStates.Completed.id) {
                this.mkysSonucMesaj += (await ReviewActionService.SendMkysOutputDocumentForReviewActionTS(this._ReviewAction, params.password));
            }
            
            if (this._ReviewAction.CurrentStateDefID.toString() === ReviewAction.ReviewActionStates.Cancelled.id) {
                let result = await UsernamePwdBox.Show(true);
                if ((<ModalActionResult>result).Result == DialogResult.OK) {
                    let params = <any>(<ModalActionResult>result).Param;
                    this.mkysSonucMesaj += (await ReviewActionService.SendDeleteMkysOutputDocumentForReviewActionTS(this._ReviewAction, params.password));
                }
            }
            this.showLoadPanel = false;
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
            else
                ServiceLocator.MessageService.showInfo(this.mkysSonucMesaj);
        }
        this.showLoadPanel = false;

        let DocumentRecordLogs: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();
        let fullApiUrl: string = '/api/ReviewActionService/DocumentRecordlogReceiptNumber?stockactionID=' + this._ReviewAction.ObjectID;
        await this.httpService.get(fullApiUrl)
            .then((res) => {
                DocumentRecordLogs = res as Array<DocumentRecordLog>;
                for (let drl of this._ReviewAction.DocumentRecordLogs) {
                    drl.ReceiptNumber = DocumentRecordLogs.find(x => x.ObjectID == drl.ObjectID).ReceiptNumber;
                }
            })
            .catch(error => {
                // this.loadingVisible = false;
            });
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ReviewAction.ObjectID.toString());
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

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReviewAction();
        this.reviewActionCompletedFormViewModel = new ReviewActionCompletedFormViewModel();
        this._ViewModel = this.reviewActionCompletedFormViewModel;
        this.reviewActionCompletedFormViewModel._ReviewAction = this._TTObject as ReviewAction;
        this.reviewActionCompletedFormViewModel._ReviewAction.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.reviewActionCompletedFormViewModel._ReviewAction.ReviewActionDetails = new Array<ReviewActionDetail>();
        this.reviewActionCompletedFormViewModel._ReviewAction.ReviewActionPatientDets = new Array<ReviewActionPatientDet>();
        this.reviewActionCompletedFormViewModel._ReviewAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.reviewActionCompletedFormViewModel = this._ViewModel as ReviewActionCompletedFormViewModel;
        that._TTObject = this.reviewActionCompletedFormViewModel._ReviewAction;
        if (this.reviewActionCompletedFormViewModel == null)
            this.reviewActionCompletedFormViewModel = new ReviewActionCompletedFormViewModel();
        if (this.reviewActionCompletedFormViewModel._ReviewAction == null)
            this.reviewActionCompletedFormViewModel._ReviewAction = new ReviewAction();
        that.reviewActionCompletedFormViewModel._ReviewAction.DocumentRecordLogs = that.reviewActionCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.reviewActionCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        that.reviewActionCompletedFormViewModel._ReviewAction.ReviewActionDetails = that.reviewActionCompletedFormViewModel.ReviewActionDetailsGridList;
        that.reviewActionCompletedFormViewModel._ReviewAction.ReviewActionPatientDets = that.reviewActionCompletedFormViewModel.ReviewActionPatientDetsGridList;
        for (let detailItem of that.reviewActionCompletedFormViewModel.ReviewActionDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.reviewActionCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.reviewActionCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.reviewActionCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.reviewActionCompletedFormViewModel._ReviewAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.reviewActionCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.reviewActionCompletedFormViewModel._ReviewAction.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ReviewActionCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        if (this._ReviewAction.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ReviewAction.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._ReviewAction.ReviewActionDetails.length > 0) {
            this.TTGetDrugButton.ReadOnly = true;
            this.TTGetDrugButton.BackColor = "#F0F0F0";
            this.StartDate.ReadOnly = true;
            this.StartDate.BackColor = "#F0F0F0";
            this.EndDate.ReadOnly = true;
            this.EndDate.BackColor = "#F0F0F0";
        }

        that.DocumentRecordLogDeleteMKYS.ReadOnly = false;




    }

    receiptNumberError: string = "";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._ReviewAction.DocumentRecordLogs) {
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
                if (data.Column.Name === 'DeleteMkysRow') {
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
                    if (resultMessage === "OK") {
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

    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.ActionDate != event) {
                this._ReviewAction.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Description != event) {
                this._ReviewAction.Description = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.EndDate != event) {
                this._ReviewAction.EndDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisIslemTuru != event) {
                this._ReviewAction.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisStokHareketTuru != event) {
                this._ReviewAction.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimAlan != event) {
                this._ReviewAction.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimEden != event) {
                this._ReviewAction.MKYS_TeslimEden = event;
            }
        }
    }

    public onStartDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StartDate != event) {
                this._ReviewAction.StartDate = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StockActionID != event) {
                this._ReviewAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Store != event) {
                this._ReviewAction.Store = event;
            }
        }
    }

    ReviewActionDetails_CellValueChangedEmitted(data: any) {
        if (data && this.ReviewActionDetails_CellValueChanged && data.Row && data.Column) {
            this.ReviewActionDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }
    onSelectionChange(data: any) {
    }
    public async ReviewActionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ReviewActionDetails_CellValueChanged(data, rowIndex, columnIndex);
    }
    onRowInserting(data: any) {
    }
    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.ReviewActionType, "Value", this.__ttObject, "ReviewActionType");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgeleri";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.TTGetDrugButton = new TTVisual.TTButton();
        this.TTGetDrugButton.Text = i18n("M14767", "Getir");
        this.TTGetDrugButton.Name = "TTGetDrugButton";
        this.TTGetDrugButton.TabIndex = 128;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.ReadOnly = true;
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 129;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.AllowUserToAddRows = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 127;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.ReadOnly = true;
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 180;

        this.ReviewActionTabPanel = new TTVisual.TTTabPage();
        this.ReviewActionTabPanel.DisplayIndex = 0;
        this.ReviewActionTabPanel.TabIndex = 0;
        this.ReviewActionTabPanel.Text = "Taşınır Malın";
        this.ReviewActionTabPanel.Name = "ReviewActionTabPanel";

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 1;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.ReadOnly = true;
        this.DocumentDateTimeDocumentRecordLog.Width = 200;

        this.ReviewActionDetails = new TTVisual.TTGrid();
        this.ReviewActionDetails.Name = "ReviewActionDetails";
        this.ReviewActionDetails.TabIndex = 126;
        this.ReviewActionDetails.Height = 350;
        this.ReviewActionDetails.AllowUserToDeleteRows = false;
        this.ReviewActionDetails.AllowUserToAddRows = false;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.ReadOnly = true;
        this.DocumentTransactionTypeDocumentRecordLog.Width = 180;

        this.MaterialRewiewActionDetail = new TTVisual.TTListBoxColumn();
        this.MaterialRewiewActionDetail.ListDefName = "DrugList";
        this.MaterialRewiewActionDetail.DataMember = "Material";
        this.MaterialRewiewActionDetail.DisplayIndex = 0;
        this.MaterialRewiewActionDetail.HeaderText = i18n("M16287", "İlaç");
        this.MaterialRewiewActionDetail.Name = "MaterialRewiewActionDetail";
        this.MaterialRewiewActionDetail.ReadOnly = true;
        this.MaterialRewiewActionDetail.Width = 400;

        this.ReceiptNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumberDocumentRecordLog.DataMember = "ReceiptNumber";
        this.ReceiptNumberDocumentRecordLog.DisplayIndex = 3;
        this.ReceiptNumberDocumentRecordLog.HeaderText = "MKYS Ayniyat Numarası";
        this.ReceiptNumberDocumentRecordLog.Name = "ReceiptNumberDocumentRecordLog";
        this.ReceiptNumberDocumentRecordLog.ReadOnly = true;
        this.ReceiptNumberDocumentRecordLog.Width = 180;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.BudgeTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeDocumentRecordLog.DataTypeName = "MKYS_EButceTurEnum";
        this.BudgeTypeDocumentRecordLog.DataMember = "BudgeType";
        this.BudgeTypeDocumentRecordLog.DisplayIndex = 4;
        this.BudgeTypeDocumentRecordLog.HeaderText = "MKYS Bütçe Türü";
        this.BudgeTypeDocumentRecordLog.Name = "BudgeTypeDocumentRecordLog";
        this.BudgeTypeDocumentRecordLog.ReadOnly = true;
        this.BudgeTypeDocumentRecordLog.Width = 200;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 5;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 260;

        this.AmountRewiewActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountRewiewActionDetail.DataMember = "Amount";
        this.AmountRewiewActionDetail.DisplayIndex = 3;
        this.AmountRewiewActionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountRewiewActionDetail.Name = "AmountRewiewActionDetail";
        this.AmountRewiewActionDetail.ReadOnly = true;
        this.AmountRewiewActionDetail.Width = 120;
        this.AmountRewiewActionDetail.IsNumeric = true;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 126;

        this.PatinetName = new TTVisual.TTTextBoxColumn();
        this.PatinetName.DataMember = "Patient";
        this.PatinetName.DisplayIndex = 4;
        this.PatinetName.HeaderText = i18n("M15131", "Hasta Adı");
        this.PatinetName.Name = "PatinetName";
        this.PatinetName.ReadOnly = true;
        this.PatinetName.Width = 180;

        this.PatientUniqurefNo = new TTVisual.TTTextBoxColumn();
        this.PatientUniqurefNo.DataMember = "UniqueRefNo";
        this.PatientUniqurefNo.DisplayIndex = 5;
        this.PatientUniqurefNo.HeaderText = "Hasta TCK No";
        this.PatientUniqurefNo.Name = "PatientUniqurefNo";
        this.PatientUniqurefNo.ReadOnly = true;
        this.PatientUniqurefNo.Width = 120;

        this.ClinicName = new TTVisual.TTTextBoxColumn();
        this.ClinicName.DataMember = "Clinic";
        this.ClinicName.DisplayIndex = 6;
        this.ClinicName.HeaderText = i18n("M12031", "Bölüm");
        this.ClinicName.Name = "ClinicName";
        this.ClinicName.ReadOnly = true;
        this.ClinicName.Width = 120;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 122;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 14;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 12;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 4;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 125;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 124;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 123;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 15;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 13;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 11;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 10;

        this.labelReviewActionType = new TTVisual.TTLabel();
        this.labelReviewActionType.Text = "İcmal Tipi";
        this.labelReviewActionType.Name = "labelReviewActionType";
        this.labelReviewActionType.TabIndex = 11;

        this.ReviewActionType = new TTVisual.TTEnumComboBox();
        this.ReviewActionType.DataTypeName = "ReviewActionTypeEnum";
        this.ReviewActionType.BackColor = "#F0F0F0";
        this.ReviewActionType.Enabled = false;
        this.ReviewActionType.Name = "ReviewActionType";
        this.ReviewActionType.TabIndex = 10;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12365", "Çıkış  Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 9;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 6;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 3;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Long;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 2;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 1;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Long;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.StoreName = new TTVisual.TTTextBoxColumn();
        this.StoreName.DataMember = "StoreName";
        this.StoreName.DisplayIndex = 6;
        this.StoreName.HeaderText = i18n("M12031", "Bölüm");
        this.StoreName.Name = "StoreName";
        this.StoreName.ReadOnly = true;
        this.StoreName.Width = 300;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 100;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.ReceiptNumberDocumentRecordLog, this.BudgeTypeDocumentRecordLog, this.DescriptionsDocumentRecordLog, this.DocumentRecordLogDeleteMKYS,];
        this.ReviewActionDetailsColumns = [this.MaterialRewiewActionDetail, this.Barcode, this.DistributionType, this.AmountRewiewActionDetail, this.StoreName, this.UnitPrice];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.tttabcontrol1.Controls = [this.DocumentRecordLogTab, this.ReviewActionTabPanel];
        this.ReviewActionTabPanel.Controls = [this.ReviewActionDetails];
        this.Controls = [this.DocumentRecordLogTab, this.TTGetDrugButton, this.DocumentRecordLogs, this.tttabcontrol1, this.DocumentRecordLogNumberDocumentRecordLog,
        this.ReviewActionTabPanel, this.DocumentDateTimeDocumentRecordLog, this.ReviewActionDetails, this.DocumentTransactionTypeDocumentRecordLog,
        this.MaterialRewiewActionDetail, this.ReceiptNumberDocumentRecordLog, this.Barcode, this.BudgeTypeDocumentRecordLog, this.DistributionType, this.DescriptionsDocumentRecordLog, this.AmountRewiewActionDetail, this.SendToMKYS, this.PatinetName, this.PatientUniqurefNo, this.ClinicName, this.Description, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.StockActionID, this.labelStore, this.Store, this.labelDescription, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan,
        this.labelMKYS_CikisStokHareketTuru, this.MKYS_CikisStokHareketTuru, this.labelReviewActionType, this.ReviewActionType, this.labelMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate, this.TTTeslimEdenButon, this.TTTeslimAlanButon];

    }


}
