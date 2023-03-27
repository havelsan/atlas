//$BE4A63C6
import { Component, OnInit, NgZone } from '@angular/core';
import { DeleteRecordDocumentDestroyableCompletedFormViewModel } from './DeleteRecordDocumentDestroyableCompletedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseDeleteRecordDocumentDestroyableForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Kayit_Silme_Belgesi/BaseDeleteRecordDocumentDestroyableForm";
import { DeleteAnimalRecordDocument } from 'NebulaClient/Model/AtlasClientModel';
import { DeleteRecordDocumentDestroyable } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DeleteRecordDocumentDestroyableMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockActionService, DocumentRecordLogReceiptNumber_Input } from "ObjectClassService/StockActionService";
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { ModalActionResult } from "Fw/Models/ModalInfo";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'DeleteRecordDocumentDestroyableCompletedForm',
    templateUrl: './DeleteRecordDocumentDestroyableCompletedForm.html',
    providers: [MessageService]
})
export class DeleteRecordDocumentDestroyableCompletedForm extends BaseDeleteRecordDocumentDestroyableForm implements OnInit {
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    DucumentRecordLogReceiptNO: TTVisual.ITTTextBoxColumn;
    SendToMKYS: TTVisual.ITTButton;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    TakenGivenPlaceDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    public DocumentRecordLogsColumns = [];
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    public StockActionInspectionDetailsStockActionInspectionDetailColumns = [];
    // public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public deleteRecordDocumentDestroyableCompletedFormViewModel: DeleteRecordDocumentDestroyableCompletedFormViewModel = new DeleteRecordDocumentDestroyableCompletedFormViewModel();
    public get _DeleteRecordDocumentDestroyable(): DeleteRecordDocumentDestroyable {
        return this._TTObject as DeleteRecordDocumentDestroyable;
    }
    private DeleteRecordDocumentDestroyableCompletedForm_DocumentUrl: string = '/api/DeleteRecordDocumentDestroyableService/DeleteRecordDocumentDestroyableCompletedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.DeleteRecordDocumentDestroyableCompletedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._DeleteRecordDocumentDestroyable.ObjectID.toString());
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

    public mkysSonucMesaj: string;
    popupVisible: boolean = false;

    public showLoadPanel: boolean = false;
    public LoadPanelMessage: string = "MKYS İşlemi yapılıyor Lütfen Bekleyiniz...";

    public async SendToMKYS_Click(): Promise<void> {
        //-TODO İlaydax
        this.mkysSonucMesaj = '';
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            this.showLoadPanel=true;
            let params = <any>(<ModalActionResult>result).Param;
            if (this._DeleteRecordDocumentDestroyable.CurrentStateDefID.toString() == "f03feb8a-8777-44df-8000-8f497a1571fb") {
                for (let log of this._DeleteRecordDocumentDestroyable.DocumentRecordLogs) {
                    if (log.ReceiptNumber == null) {
                        this.mkysSonucMesaj = await StockActionService.SendMKYSForOutputDocumentTS(this._DeleteRecordDocumentDestroyable, params.password);
                    }
                }
            }
            //-TODO İlaydax
            if (this._DeleteRecordDocumentDestroyable.CurrentStateDefID === DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableStates.Cancelled) {
                for (let log of this._DeleteRecordDocumentDestroyable.DocumentRecordLogs) {
                    if (log.ReceiptNumber != null) {
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._DeleteRecordDocumentDestroyable, true, log.ReceiptNumber.Value, params.password);
                    }
                }
            }
            this.showLoadPanel=false;
            if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
                this.popupVisible = true;
        }

    }
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

    }
    protected async PreScript() {
        //super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DeleteRecordDocumentDestroyable();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel = new DeleteRecordDocumentDestroyableCompletedFormViewModel();
        this._ViewModel = this.deleteRecordDocumentDestroyableCompletedFormViewModel;
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable = this._TTObject as DeleteRecordDocumentDestroyable;
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials = new Array<DeleteRecordDocumentDestroyableMaterialOut>();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.Store = new Store();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = new StockActionInspection();
        this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection.StockActionInspectionDetails = new Array<StockActionInspectionDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.deleteRecordDocumentDestroyableCompletedFormViewModel = this._ViewModel as DeleteRecordDocumentDestroyableCompletedFormViewModel;
        that._TTObject = this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable;
        if (this.deleteRecordDocumentDestroyableCompletedFormViewModel == null)
            this.deleteRecordDocumentDestroyableCompletedFormViewModel = new DeleteRecordDocumentDestroyableCompletedFormViewModel();
        if (this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable == null)
            this.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable = new DeleteRecordDocumentDestroyable();
        that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.DocumentRecordLogs = that.deleteRecordDocumentDestroyableCompletedFormViewModel.DocumentRecordLogsGridList;
        for (let detailItem of that.deleteRecordDocumentDestroyableCompletedFormViewModel.DocumentRecordLogsGridList) {
        }
        that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableOutMaterials = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.deleteRecordDocumentDestroyableCompletedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.deleteRecordDocumentDestroyableCompletedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.StockActionSignDetails = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.deleteRecordDocumentDestroyableCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        let storeObjectID = that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.deleteRecordDocumentDestroyableCompletedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.Store = store;
            }
        }
        let stockActionInspectionObjectID = that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable["StockActionInspection"];
        if (stockActionInspectionObjectID != null && (typeof stockActionInspectionObjectID === 'string')) {
            let stockActionInspection = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionInspections.find(o => o.ObjectID.toString() === stockActionInspectionObjectID.toString());
            if (stockActionInspection) {
                that.deleteRecordDocumentDestroyableCompletedFormViewModel._DeleteRecordDocumentDestroyable.StockActionInspection = stockActionInspection;
            }
            if (stockActionInspection != null) {
                stockActionInspection.StockActionInspectionDetails = that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList;
                for (let detailItem of that.deleteRecordDocumentDestroyableCompletedFormViewModel.StockActionInspectionDetailsStockActionInspectionDetailGridList) {
                    let inspectionUserObjectID = detailItem["InspectionUser"];
                    if (inspectionUserObjectID != null && (typeof inspectionUserObjectID === 'string')) {
                        let inspectionUser = that.deleteRecordDocumentDestroyableCompletedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === inspectionUserObjectID.toString());
                        if (inspectionUser) {
                            detailItem.InspectionUser = inspectionUser;
                        }
                    }
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(DeleteRecordDocumentDestroyableCompletedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;


        if (that._DeleteRecordDocumentDestroyable.CurrentStateDefID.toString() == DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableStates.Completed.id.toString()) {
            this.FormCaption = "Kayıt Silme Belgesi Yok Edilen ( Tamamlandı )";
        }
        if (that._DeleteRecordDocumentDestroyable.CurrentStateDefID.toString() == DeleteRecordDocumentDestroyable.DeleteRecordDocumentDestroyableStates.Cancelled.id.toString()) {
            this.FormCaption = "Kayıt Silme Belgesi Yok Edilen ( İptal Edildi )";
        }

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.Description != event) {
                this._DeleteRecordDocumentDestroyable.Description = event;
            }
        }
    }

    public onInspectionDateChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionDate != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_CikisIslemTuru != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_CikisStokHareketTuru != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_TeslimAlan != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.MKYS_TeslimEden != event) {
                this._DeleteRecordDocumentDestroyable.MKYS_TeslimEden = event;
            }
        }
    }

    public onReportNOChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.ReportNumberNotSeq != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.ReportNumberNotSeq = event;
            }
        }
    }

    public onReturningDocumentNumberChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.ReturningDocumentNumber != event) {
                this._DeleteRecordDocumentDestroyable.ReturningDocumentNumber = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.StockActionID != event) {
                this._DeleteRecordDocumentDestroyable.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.Store != event) {
                this._DeleteRecordDocumentDestroyable.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.TransactionDate != event) {
                this._DeleteRecordDocumentDestroyable.TransactionDate = event;
            }
        }
    }

    public onttrichtextboxcontrol1Changed(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null && this._DeleteRecordDocumentDestroyable.TechnicalReport != event) {
                this._DeleteRecordDocumentDestroyable.TechnicalReport = event;
            }
        }
    }

    public onttrichtextboxcontrol2Changed(event): void {
        if (event != null) {
            if (this._DeleteRecordDocumentDestroyable != null &&
                this._DeleteRecordDocumentDestroyable.StockActionInspection != null && this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionReport != event) {
                this._DeleteRecordDocumentDestroyable.StockActionInspection.InspectionReport = event;
            }
        }
    }



    StockActionSignDetails_CellValueChangedEmitted(data: any) {
        /*if (data && this.StockActionSignDetails_CellValueChanged && data.Row && data.Column) {
            this.StockActionSignDetails.CurrentCell =
                {
                    OwningRow: data.Row,
                    OwningColumn: data.Column
                };
            this.StockActionSignDetails_CellValueChanged(data.RowIndex, data.ColIndex);
        }*/
    }

    receiptNumberError: string = "";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._DeleteRecordDocumentDestroyable.DocumentRecordLogs) {
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

    DeleteRecordDocumentDestroyableOutMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.StockActionOutDetails && data.Row && data.Column) {
            this.DeleteRecordDocumentDestroyableOutMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }


    public async DeleteRecordDocumentDestroyableOutMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.DeleteRecordDocumentDestroyable_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: any) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }

    onSelectionChange(data: any) {
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.ReturningDocumentNumber, "Text", this.__ttObject, "ReturningDocumentNumber");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.ttrichtextboxcontrol1, "Rtf", this.__ttObject, "TechnicalReport");
        redirectProperty(this.ttrichtextboxcontrol2, "Rtf", this.__ttObject, "StockActionInspection.InspectionReport");
        redirectProperty(this.InspectionDate, "Value", this.__ttObject, "StockActionInspection.InspectionDate");
        redirectProperty(this.ReportNO, "Text", this.__ttObject, "StockActionInspection.ReportNumberNotSeq");
    }

    public initFormControls(): void {
        this.DocumentRecordLogTab = new TTVisual.TTTabPage();
        this.DocumentRecordLogTab.DisplayIndex = 1;
        this.DocumentRecordLogTab.TabIndex = 1;
        this.DocumentRecordLogTab.Text = "Taşınır Mal İşlem Belgesi";
        this.DocumentRecordLogTab.Name = "DocumentRecordLogTab";

        this.tttabcontrol2 = new TTVisual.TTTabControl();
        this.tttabcontrol2.Name = "tttabcontrol2";
        this.tttabcontrol2.TabIndex = 4;

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
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;

        this.MaterialTabPage = new TTVisual.TTTabPage();
        this.MaterialTabPage.DisplayIndex = 0;
        this.MaterialTabPage.BackColor = "#FFFFFF";
        this.MaterialTabPage.TabIndex = 0;
        this.MaterialTabPage.Text = "Taşınır Malın";
        this.MaterialTabPage.Name = "MaterialTabPage";


        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 39;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 0;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11743", "Belge Kayıt Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 80;

        this.StockActionOutDetails = new TTVisual.TTGrid();
        this.StockActionOutDetails.Required = true;
        this.StockActionOutDetails.BackColor = "#FFE3C6";
        this.StockActionOutDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionOutDetails.Name = "StockActionOutDetails";
        this.StockActionOutDetails.TabIndex = 0;
        this.StockActionOutDetails.Height = 350;
        this.StockActionOutDetails.AllowUserToAddRows = false;
        this.StockActionOutDetails.AllowUserToDeleteRows = false;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 37;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 1;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 100;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.ReturningDocumentNumber = new TTVisual.TTTextBox();
        this.ReturningDocumentNumber.BackColor = "#F0F0F0";
        this.ReturningDocumentNumber.ReadOnly = true;
        this.ReturningDocumentNumber.Name = "ReturningDocumentNumber";
        this.ReturningDocumentNumber.TabIndex = 5;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18545", "Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 400;
        this.Material.ReadOnly = this.ReadOnly;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 3;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 200;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod/UBB";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionSignDetails.Name = "StockActionSignDetails";
        this.StockActionSignDetails.TabIndex = 0;
        this.StockActionSignDetails.Visible = false;

        this.TakenGivenPlaceDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.TakenGivenPlaceDocumentRecordLog.DataMember = "TakenGivenPlace";
        this.TakenGivenPlaceDocumentRecordLog.DisplayIndex = 4;
        this.TakenGivenPlaceDocumentRecordLog.HeaderText = i18n("M10714", "Alındığı / Verildiği Yer");
        this.TakenGivenPlaceDocumentRecordLog.Name = "TakenGivenPlaceDocumentRecordLog";
        this.TakenGivenPlaceDocumentRecordLog.Width = 200;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 150;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = "SignUserTypeEnum";
        this.SignUserType.DataMember = "SignUserType";
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = "SignUserType";
        this.SignUserType.Width = 120;

        this.DucumentRecordLogReceiptNO = new TTVisual.TTTextBoxColumn();
        this.DucumentRecordLogReceiptNO.DataMember = "ReceiptNumber";
        this.DucumentRecordLogReceiptNO.DisplayIndex = 5;
        this.DucumentRecordLogReceiptNO.HeaderText = "MKYS Ayniyat No";
        this.DucumentRecordLogReceiptNO.Name = "DucumentRecordLogReceiptNO";
        this.DucumentRecordLogReceiptNO.ReadOnly = true;
        this.DucumentRecordLogReceiptNO.Width = 100;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = "UserListDefinition";
        this.SignUser.DataMember = "SignUser";
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = "SignUser";
        this.SignUser.Width = 300;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = "Descriptions";
        this.DescriptionsDocumentRecordLog.DisplayIndex = 6;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = "DescriptionsDocumentRecordLog";
        this.DescriptionsDocumentRecordLog.Width = 200;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 5;
        this.Amount.HeaderText = i18n("M19036", "Miktarı");
        this.Amount.Name = "Amount";
        this.Amount.Width = 120;
        this.Amount.IsNumeric = true;

        this.FreeTextSignUser = new TTVisual.TTTextBoxColumn();
        this.FreeTextSignUser.DataMember = "NameString";
        this.FreeTextSignUser.DisplayIndex = 2;
        this.FreeTextSignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.FreeTextSignUser.Name = "FreeTextSignUser";
        this.FreeTextSignUser.Width = 300;

        this.SendToMKYS = new TTVisual.TTButton();
        this.SendToMKYS.Text = "MKYS'ye Gönder";
        this.SendToMKYS.Name = "SendToMKYS";
        this.SendToMKYS.TabIndex = 133;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Format = "#,###.#########";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Visible = false;
        this.UnitPrice.Width = 120;
        this.UnitPrice.IsNumeric = true;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = "IsDeputy";
        this.IsDeputy.DisplayIndex = 3;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = "IsDeputy";
        this.IsDeputy.Width = 50;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "#,###.#########";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 7;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Visible = false;
        this.Price.Width = 120;
        this.Price.IsNumeric = true;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 40;

        this.Startdate = new TTVisual.TTDateTimePickerColumn();
        this.Startdate.Format = DateTimePickerFormat.Short;
        this.Startdate.DataMember = "StartDate";
        this.Startdate.DisplayIndex = 8;
        this.Startdate.HeaderText = i18n("M11637", "Başlangıç Tarihi");
        this.Startdate.Name = "Startdate";
        this.Startdate.Width = 125;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 38;

        this.ttenumcomboboxcolumn1 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn1.DataTypeName = "AuthorityClassStatusEnum";
        this.ttenumcomboboxcolumn1.DataMember = "AuthorityClass";
        this.ttenumcomboboxcolumn1.DisplayIndex = 9;
        this.ttenumcomboboxcolumn1.HeaderText = i18n("M24649", "Yetki Sembolü");
        this.ttenumcomboboxcolumn1.Name = "ttenumcomboboxcolumn1";
        this.ttenumcomboboxcolumn1.Width = 100;
        this.ttenumcomboboxcolumn1.Visible = false;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12364", "Çıkış  Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 36;

        this.DeleteRecordReason = new TTVisual.TTEnumComboBoxColumn();
        this.DeleteRecordReason.DataTypeName = "DeleteRecordReasonEnum";
        this.DeleteRecordReason.DataMember = "DeleteRecordReason";
        this.DeleteRecordReason.DisplayIndex = 10;
        this.DeleteRecordReason.HeaderText = i18n("M17417", "Kayıt Silme Nedeni");
        this.DeleteRecordReason.Name = "DeleteRecordReason";
        this.DeleteRecordReason.Width = 100;
        this.DeleteRecordReason.ReadOnly = this.ReadOnly;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 35;
        this.MKYS_CikisStokHareketTuru.ReadOnly = true;
        this.MKYS_CikisStokHareketTuru.Enabled = false;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 11;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;
        this.StockLevelType.ReadOnly = this.ReadOnly;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12381", "Çıkış Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 34;

        this.Opinions = new TTVisual.TTTextBoxColumn();
        this.Opinions.DataMember = "Opinions";
        this.Opinions.DisplayIndex = 12;
        this.Opinions.HeaderText = i18n("M10483", "Açıklamalar");
        this.Opinions.Name = "Opinions";
        this.Opinions.Width = 200;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 33;
        this.MKYS_CikisIslemTuru.ReadOnly = true;
        this.MKYS_CikisIslemTuru.Enabled = false;

        this.DestroyLocation = new TTVisual.TTTextBoxColumn();
        this.DestroyLocation.DataMember = "DestroyLocation";
        this.DestroyLocation.DisplayIndex = 13;
        this.DestroyLocation.HeaderText = i18n("M19442", "Nerede Yok Edildiği");
        this.DestroyLocation.Name = "DestroyLocation";
        this.DestroyLocation.Width = 200;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 32;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 31;

        this.labelReturningDocumentNumber = new TTVisual.TTLabel();
        this.labelReturningDocumentNumber.Text = i18n("M10651", "Aktarılan Belge Numarası");
        this.labelReturningDocumentNumber.Name = "labelReturningDocumentNumber";
        this.labelReturningDocumentNumber.TabIndex = 30;

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

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = "DescriptionAndSignTabControl";
        this.DescriptionAndSignTabControl.TabIndex = 6;

        this.TechnicalReportTabpage = new TTVisual.TTTabPage();
        this.TechnicalReportTabpage.DisplayIndex = 0;
        this.TechnicalReportTabpage.TabIndex = 2;
        this.TechnicalReportTabpage.Text = i18n("M23096", "Teknik Rapor");
        this.TechnicalReportTabpage.Name = "TechnicalReportTabpage";

        this.ttrichtextboxcontrol1 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol1.BackColor = "#FFFFFF";
        this.ttrichtextboxcontrol1.Name = "ttrichtextboxcontrol1";
        this.ttrichtextboxcontrol1.TabIndex = 7;

        this.InspectionTabpage = new TTVisual.TTTabPage();
        this.InspectionTabpage.DisplayIndex = 1;
        this.InspectionTabpage.TabIndex = 3;
        this.InspectionTabpage.Text = i18n("M19196", "Muayene Komisyonu");
        this.InspectionTabpage.Name = "InspectionTabpage";

        this.StockActionInspectionDetailsStockActionInspectionDetail = new TTVisual.TTGrid();
        this.StockActionInspectionDetailsStockActionInspectionDetail.Name = "StockActionInspectionDetailsStockActionInspectionDetail";
        this.StockActionInspectionDetailsStockActionInspectionDetail.TabIndex = 33;
        this.StockActionInspectionDetailsStockActionInspectionDetail.Height = 200;
        this.StockActionInspectionDetailsStockActionInspectionDetail.AllowUserToAddRows = false;
        this.StockActionInspectionDetailsStockActionInspectionDetail.AllowUserToDeleteRows = false;

        this.InspectionUserTypeStockActionInspectionDetail = new TTVisual.TTEnumComboBoxColumn();
        this.InspectionUserTypeStockActionInspectionDetail.DataTypeName = "InspectionUserTypeEnum";
        this.InspectionUserTypeStockActionInspectionDetail.DataMember = "InspectionUserType";
        this.InspectionUserTypeStockActionInspectionDetail.Required = true;
        this.InspectionUserTypeStockActionInspectionDetail.DisplayIndex = 0;
        this.InspectionUserTypeStockActionInspectionDetail.HeaderText = "Görevi";
        this.InspectionUserTypeStockActionInspectionDetail.Name = "InspectionUserTypeStockActionInspectionDetail";
        this.InspectionUserTypeStockActionInspectionDetail.Width = 100;

        this.InspectionUserStockActionInspectionDetail = new TTVisual.TTListBoxColumn();
        this.InspectionUserStockActionInspectionDetail.ListDefName = "UserListDefinition";
        this.InspectionUserStockActionInspectionDetail.DataMember = "InspectionUser";
        this.InspectionUserStockActionInspectionDetail.DisplayIndex = 1;
        this.InspectionUserStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.InspectionUserStockActionInspectionDetail.Name = "InspectionUserStockActionInspectionDetail";
        this.InspectionUserStockActionInspectionDetail.Width = 300;

        this.NameStringStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.NameStringStockActionInspectionDetail.DataMember = "NameString";
        this.NameStringStockActionInspectionDetail.Required = true;
        this.NameStringStockActionInspectionDetail.DisplayIndex = 2;
        this.NameStringStockActionInspectionDetail.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.NameStringStockActionInspectionDetail.Name = "NameStringStockActionInspectionDetail";
        this.NameStringStockActionInspectionDetail.Width = 200;

        this.ShortMilitaryClassStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortMilitaryClassStockActionInspectionDetail.DataMember = "ShortMilitaryClass";
        this.ShortMilitaryClassStockActionInspectionDetail.DisplayIndex = 3;
        this.ShortMilitaryClassStockActionInspectionDetail.HeaderText = i18n("M21810", "Sınıf Kısaltması");
        this.ShortMilitaryClassStockActionInspectionDetail.Name = "ShortMilitaryClassStockActionInspectionDetail";
        this.ShortMilitaryClassStockActionInspectionDetail.Width = 80;
        this.ShortMilitaryClassStockActionInspectionDetail.Visible = false;

        this.ShortRankStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.ShortRankStockActionInspectionDetail.DataMember = "ShortRank";
        this.ShortRankStockActionInspectionDetail.DisplayIndex = 4;
        this.ShortRankStockActionInspectionDetail.HeaderText = i18n("M21078", "Rütbe Kısaltması");
        this.ShortRankStockActionInspectionDetail.Name = "ShortRankStockActionInspectionDetail";
        this.ShortRankStockActionInspectionDetail.Width = 80;
        this.ShortRankStockActionInspectionDetail.Visible = false;

        this.EmploymentRecordIDStockActionInspectionDetail = new TTVisual.TTTextBoxColumn();
        this.EmploymentRecordIDStockActionInspectionDetail.DataMember = "EmploymentRecordID";
        this.EmploymentRecordIDStockActionInspectionDetail.DisplayIndex = 5;
        this.EmploymentRecordIDStockActionInspectionDetail.HeaderText = i18n("M21831", "Sicil No");
        this.EmploymentRecordIDStockActionInspectionDetail.Name = "EmploymentRecordIDStockActionInspectionDetail";
        this.EmploymentRecordIDStockActionInspectionDetail.Width = 80;
        this.EmploymentRecordIDStockActionInspectionDetail.Visible = false;

        this.ttrichtextboxcontrol2 = new TTVisual.TTRichTextBoxControl();
        this.ttrichtextboxcontrol2.DisplayText = i18n("M19212", "Muayene Raporu");
        this.ttrichtextboxcontrol2.TemplateGroupName = i18n("M22331", "Stok İşlemleri Muayene Raporları");
        this.ttrichtextboxcontrol2.Name = "ttrichtextboxcontrol2";
        this.ttrichtextboxcontrol2.TabIndex = 2;

        this.labelInspectionDate = new TTVisual.TTLabel();
        this.labelInspectionDate.Text = i18n("M19222", "Muayene Tarihi");
        this.labelInspectionDate.BackColor = "#DCDCDC";
        this.labelInspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInspectionDate.ForeColor = "#000000";
        this.labelInspectionDate.Name = "labelInspectionDate";
        this.labelInspectionDate.TabIndex = 11;

        this.ReportNO = new TTVisual.TTTextBox();
        this.ReportNO.Name = "ReportNO";
        this.ReportNO.TabIndex = 1;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M20824", "Rapor Numarası");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 11;

        this.InspectionDate = new TTVisual.TTDateTimePicker();
        this.InspectionDate.CustomFormat = "";
        this.InspectionDate.Format = DateTimePickerFormat.Short;
        this.InspectionDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InspectionDate.Name = "InspectionDate";
        this.InspectionDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = i18n("M10469", "Açıklama");
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 16;

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';

        this.DocumentRecordLogsColumns = [this.DocumentRecordLogNumberDocumentRecordLog, this.DocumentDateTimeDocumentRecordLog, this.DocumentTransactionTypeDocumentRecordLog, this.SubjectDocumentRecordLog, this.TakenGivenPlaceDocumentRecordLog, this.DucumentRecordLogReceiptNO, this.DocumentRecordLogDeleteMKYS, this.DescriptionsDocumentRecordLog];
        // this.StockActionOutDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.StoreStock, this.Amount, this.UnitPrice, this.Price, this.Startdate, this.ttenumcomboboxcolumn1, this.DeleteRecordReason, this.StockLevelType, this.Opinions, this.DestroyLocation];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.FreeTextSignUser, this.IsDeputy];
        this.StockActionInspectionDetailsStockActionInspectionDetailColumns = [this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail];
        this.DocumentRecordLogTab.Controls = [this.DocumentRecordLogs];
        this.tttabcontrol2.Controls = [this.DocumentRecordLogTab, this.MaterialTabPage];
        this.MaterialTabPage.Controls = [this.StockActionOutDetails];
        this.DescriptionAndSignTabControl.Controls = [this.TechnicalReportTabpage, this.InspectionTabpage];
        this.TechnicalReportTabpage.Controls = [this.ttrichtextboxcontrol1];
        this.InspectionTabpage.Controls = [this.StockActionInspectionDetailsStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate];
        this.Controls = [this.DocumentRecordLogTab, this.tttabcontrol2, this.Description, this.DocumentRecordLogs, this.MaterialTabPage, this.MKYS_TeslimEden, this.DocumentRecordLogNumberDocumentRecordLog, this.StockActionOutDetails, this.MKYS_TeslimAlan, this.DocumentDateTimeDocumentRecordLog, this.Detail, this.ReturningDocumentNumber, this.DocumentTransactionTypeDocumentRecordLog, this.Material, this.StockActionID, this.SubjectDocumentRecordLog, this.Barcode, this.StockActionSignDetails, this.TakenGivenPlaceDocumentRecordLog, this.DistributionType, this.SignUserType, this.DucumentRecordLogReceiptNO, this.StoreStock, this.SignUser, this.DescriptionsDocumentRecordLog, this.Amount, this.FreeTextSignUser, this.SendToMKYS, this.UnitPrice, this.IsDeputy, this.Price, this.labelMKYS_TeslimEden, this.Startdate, this.labelMKYS_TeslimAlan, this.ttenumcomboboxcolumn1, this.labelMKYS_CikisStokHareketTuru, this.DeleteRecordReason, this.MKYS_CikisStokHareketTuru, this.StockLevelType, this.labelMKYS_CikisIslemTuru, this.Opinions, this.MKYS_CikisIslemTuru, this.DestroyLocation, this.labelStore, this.Store, this.labelReturningDocumentNumber, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.DescriptionAndSignTabControl, this.TechnicalReportTabpage, this.ttrichtextboxcontrol1, this.InspectionTabpage, this.StockActionInspectionDetailsStockActionInspectionDetail, this.InspectionUserTypeStockActionInspectionDetail, this.InspectionUserStockActionInspectionDetail, this.NameStringStockActionInspectionDetail, this.ShortMilitaryClassStockActionInspectionDetail, this.ShortRankStockActionInspectionDetail, this.EmploymentRecordIDStockActionInspectionDetail, this.ttrichtextboxcontrol2, this.labelInspectionDate, this.ReportNO, this.ttlabel1, this.InspectionDate, this.TTTeslimEdenButon, this.TTTeslimAlanButon, this.DocumentRecordLogDeleteMKYS, this.ttlabel6];

    }


}
