//$92606AE5
import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MainStoreDistDocComplatedFormViewModel } from './MainStoreDistDocComplatedFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMainStoreDistributionDocForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/BaseMainStoreDistributionDocForm";
import { MainStoreDistributionDoc, DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DocumentRecordLog } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDistDocDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { StockActionService, OutputForReGeneration, DocumentRecordLogReceiptNumber_Input } from 'ObjectClassService/StockActionService';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { TTButtonTextBox } from 'app/NebulaClient/Visual/Controls/TTButtonTextBox';
import { MkysServis } from 'app/NebulaClient/Services/External/MkysServis';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'MainStoreDistDocComplatedForm',
    templateUrl: './MainStoreDistDocComplatedForm.html',
    providers: [MessageService]
})
export class MainStoreDistDocComplatedForm extends BaseMainStoreDistributionDocForm implements OnInit {
    DocumentRecordLogs: TTVisual.ITTGrid;
    DocumentRecordLogSearch: TTVisual.ITTButtonColumn;
    BudgeTypeEnum: TTVisual.ITTEnumComboBoxColumn;
    ttdatetimepickercolumn2: TTVisual.ITTDateTimePickerColumn;
    ttenumcomboboxcolumn4: TTVisual.ITTEnumComboBoxColumn;
    ttenumcomboboxcolumn5: TTVisual.ITTEnumComboBoxColumn;
    ttgrid3: TTVisual.ITTGrid;
    tttextboxcolumn13: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn14: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn15: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn16: TTVisual.ITTTextBoxColumn;
    DescriptionsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    tttextboxcolumn17: TTVisual.ITTTextBoxColumn;
    DocumentDateTimeDocumentRecordLog: TTVisual.ITTDateTimePickerColumn;
    DocumentRecordLogNumberDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentrecordLogTab: TTVisual.ITTTabPage;
    DocumentTransactionTypeDocumentRecordLog: TTVisual.ITTEnumComboBoxColumn;
    NumberOfRowsDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    ReceiptNumber: TTVisual.ITTTextBoxColumn;
    RegistrationNumber: TTVisual.ITTTextBox;
    SubjectDocumentRecordLog: TTVisual.ITTTextBoxColumn;
    DocumentRecordLogDeleteMKYS: TTVisual.ITTButtonColumn;
    SequenceNumber: TTVisual.ITTTextBox;
    public MainStoreDistDocDetailsColumns = [];
    public DocumentRecordLogsColumns = [];
    public ttgrid3Columns = [];
    public mainStoreDistDocComplatedFormViewModel: MainStoreDistDocComplatedFormViewModel = new MainStoreDistDocComplatedFormViewModel();
    public get _MainStoreDistributionDoc(): MainStoreDistributionDoc {
        return this._TTObject as MainStoreDistributionDoc;
    }
    private MainStoreDistDocComplatedForm_DocumentUrl: string = '/api/MainStoreDistributionDocService/MainStoreDistDocComplatedForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private reportService: AtlasReportService, protected modalService: IModalService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.MainStoreDistDocComplatedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    public MainStoreDistributionDocumentMaterialsColumns = [
        // {
        //     caption: ' ',
        //     dataField: 'ObjectID',
        //     cellTemplate: 'buttonCellTemplate',
        //     width: 100
        // },
        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 350
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false
        },
        {
            caption: 'Gönderilen Miktar',
            dataField: 'SendedAmount',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Kabul Edilen Miktar',
            dataField: 'Amount',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Ana Depo Mevcudu',
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false,
            Visible: false
        },
        {
            caption: 'Cep Depo Mevcudu',
            dataField: 'DestinationStoreStock',
            dataType: 'number',
            allowEditing: false,
            Visible: false
        },
        {
            caption: 'Künye No',
            dataField: 'TagNo',
            allowEditing: true
        },
        {
            caption: 'Malın Durumu',
            dataField: 'StockLevelType.Description',
            allowEditing: false
            //width: 250
        }
    ];

    // ***** Method declarations start *****
    public mkysSonucMesaj: string;
    popupVisible: boolean = false;
    reGenerateButtonVisible: boolean = true;
    public async ttMkysSend_Click(): Promise<void> {
        this.mkysSonucMesaj = '';
        if (this._MainStoreDistributionDoc.CurrentStateDefID.toString() === MainStoreDistributionDoc.MainStoreDistributionDocStates.Completed.id) {
            let result = await UsernamePwdBox.Show(true);
            for (let log of this._MainStoreDistributionDoc.DocumentRecordLogs) {
                if (log.ReceiptNumber == null) {
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        this.mkysSonucMesaj += await StockActionService.SendMKYSForOutputDocumentTS(this._MainStoreDistributionDoc, params.password);
                    }
                }
                if (log.ReceiptNumber != null) {
                    this.mkysSonucMesaj += log.ReceiptNumber.toString() + ' Ayniyat numarası ile MKYSye kaydolmuştur.';
                }
            }
        }
        if (this._MainStoreDistributionDoc.CurrentStateDefID.toString() === MainStoreDistributionDoc.MainStoreDistributionDocStates.Cancelled.id) {
            let result = await UsernamePwdBox.Show(true);
            for (let log of this._MainStoreDistributionDoc.DocumentRecordLogs) {
                if (log.ReceiptNumber != null) {
                    if ((<ModalActionResult>result).Result == DialogResult.OK) {
                        let params = <any>(<ModalActionResult>result).Param;
                        this.mkysSonucMesaj = await StockActionService.SendDeleteMessageToMkysTS(this._MainStoreDistributionDoc, true, log.ReceiptNumber.Value, params.password);
                    }
                }
            }
        }
        if (String.isNullOrEmpty(this.mkysSonucMesaj) == false)
            this.popupVisible = true;
    }

    public async prepareDocument_Click(): Promise<void> {
        let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._MainStoreDistributionDoc.ObjectID.toString());
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


    public async stateChange(event: FormSaveInfo) {
                await super.setState(event.transDef, event);
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new MainStoreDistributionDoc();
        this.mainStoreDistDocComplatedFormViewModel = new MainStoreDistDocComplatedFormViewModel();
        this._ViewModel = this.mainStoreDistDocComplatedFormViewModel;
        this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc = this._TTObject as MainStoreDistributionDoc;
        this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.DocumentRecordLogs = new Array<DocumentRecordLog>();
        this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.Store = new Store();
        this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.DestinationStore = new Store();
        this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = new Array<MainStoreDistDocDetail>();
    }

    protected loadViewModel() {
        let that = this;
        that.mainStoreDistDocComplatedFormViewModel = this._ViewModel as MainStoreDistDocComplatedFormViewModel;
        that._TTObject = this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc;
        if (this.mainStoreDistDocComplatedFormViewModel == null)
            this.mainStoreDistDocComplatedFormViewModel = new MainStoreDistDocComplatedFormViewModel();
        if (this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc == null)
            this.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc = new MainStoreDistributionDoc();
        that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.DocumentRecordLogs = that.mainStoreDistDocComplatedFormViewModel.ttgrid3GridList;
        for (let detailItem of that.mainStoreDistDocComplatedFormViewModel.ttgrid3GridList) {
        }
        let storeObjectID = that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.mainStoreDistDocComplatedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.Store = store;
            }
        }


        let destinationStoreObjectID = that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === "string")) {
            let destinationStore = that.mainStoreDistDocComplatedFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.DestinationStore = destinationStore;
            }
        }


        that.mainStoreDistDocComplatedFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = that.mainStoreDistDocComplatedFormViewModel.MainStoreDistDocDetailsGridList;
        for (let detailItem of that.mainStoreDistDocComplatedFormViewModel.MainStoreDistDocDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.mainStoreDistDocComplatedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }


                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.mainStoreDistDocComplatedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }


                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.mainStoreDistDocComplatedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }

                        }
                    }
                }
            }



            let stockLevelTypeObjectID = detailItem["StockLevelType"];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === "string")) {
                let stockLevelType = that.mainStoreDistDocComplatedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }

    }
    async ngOnInit() {
        let that = this;
        await this.load(MainStoreDistDocComplatedFormViewModel);
        this.MKYS_TeslimAlan.ButtonEnabled = false;
        this.MKYS_TeslimEden.ButtonEnabled = false;
        this.DocumentRecordLogDeleteMKYS.ReadOnly = false;
        if (this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._MainStoreDistributionDoc.CurrentStateDefID.toString() == MainStoreDistributionDoc.MainStoreDistributionDocStates.Completed.id.toString()) {
            this.FormCaption = i18n("M12437", "Ana Depo Dağıtım Belgesi ( Tamamlandı )");
        }
        if (this._MainStoreDistributionDoc.CurrentStateDefID.toString() == MainStoreDistributionDoc.MainStoreDistributionDocStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M12435", "Ana Depo Dağıtım Belgesi ( İptal Edildi )");
        }

    }

    public onDescriptionChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.Description != event) {
            this._MainStoreDistributionDoc.Description = event;
        }
    }

    public onDestinationStoreChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.DestinationStore != event) {
            this._MainStoreDistributionDoc.DestinationStore = event;
        }
    }

    public onStockActionIDChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.StockActionID != event) {
            this._MainStoreDistributionDoc.StockActionID = event;
        }
    }

    public onStoreChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.Store != event) {
            this._MainStoreDistributionDoc.Store = event;
        }
    }

    public onTransactionDateChanged(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.TransactionDate != event) {
            this._MainStoreDistributionDoc.TransactionDate = event;
        }
    }

    public ontttextbox2Changed(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimEden != event) {
            this._MainStoreDistributionDoc.MKYS_TeslimEden = event;
        }
    }

    public ontttextbox3Changed(event): void {
        if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimAlan != event) {
            this._MainStoreDistributionDoc.MKYS_TeslimAlan = event;
        }
    }
    receiptNumberError: string ="";
    controlOfCancelMKYS: boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        for (let log of this._MainStoreDistributionDoc.DocumentRecordLogs) {
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
                    let resultMessage: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', documentLog.DocumentRecordLogNumber + " Tif numaralı fişi silmek istediğinizden emin misiniz?");
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


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.SequenceNumber, "Text", this.__ttObject, "SequenceNumber");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 32;

        this.ttgrid3 = new TTVisual.TTGrid();
        this.ttgrid3.Name = "ttgrid3";
        this.ttgrid3.TabIndex = 0;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 31;

        this.ttdatetimepickercolumn2 = new TTVisual.TTDateTimePickerColumn();
        this.ttdatetimepickercolumn2.DataMember = "DocumentDateTime";
        this.ttdatetimepickercolumn2.DisplayIndex = 0;
        this.ttdatetimepickercolumn2.HeaderText = "Belge Tarihi";
        this.ttdatetimepickercolumn2.Name = "ttdatetimepickercolumn2";
        this.ttdatetimepickercolumn2.Width = 180;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.tttextboxcolumn13 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn13.DataMember = "DocumentRecordLogNumber";
        this.tttextboxcolumn13.DisplayIndex = 1;
        this.tttextboxcolumn13.HeaderText = "Belge Kayıt Numarası";
        this.tttextboxcolumn13.Name = "tttextboxcolumn13";
        this.tttextboxcolumn13.Width = 80;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Gönderen Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 8;

        this.ttenumcomboboxcolumn4 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn4.DataTypeName = "DocumentTransactionTypeEnum";
        this.ttenumcomboboxcolumn4.DataMember = "DocumentTransactionType";
        this.ttenumcomboboxcolumn4.DisplayIndex = 2;
        this.ttenumcomboboxcolumn4.HeaderText = "İşlem Çeşidi";
        this.ttenumcomboboxcolumn4.Name = "ttenumcomboboxcolumn4";
        this.ttenumcomboboxcolumn4.Width = 80;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 7;

        this.tttextboxcolumn14 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn14.DataMember = "NumberOfRows";
        this.tttextboxcolumn14.DisplayIndex = 3;
        this.tttextboxcolumn14.HeaderText = "Kalem Adedi";
        this.tttextboxcolumn14.Name = "tttextboxcolumn14";
        this.tttextboxcolumn14.Width = 80;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = "Alan Depo";
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 6;

        this.ttenumcomboboxcolumn5 = new TTVisual.TTEnumComboBoxColumn();
        this.ttenumcomboboxcolumn5.DataTypeName = "MKYS_EButceTurEnum";
        this.ttenumcomboboxcolumn5.DataMember = "BudgeType";
        this.ttenumcomboboxcolumn5.DisplayIndex = 4;
        this.ttenumcomboboxcolumn5.HeaderText = "Bütçe Tipi";
        this.ttenumcomboboxcolumn5.Name = "ttenumcomboboxcolumn5";
        this.ttenumcomboboxcolumn5.ReadOnly = true;
        this.ttenumcomboboxcolumn5.Width = 100;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 5;

        this.tttextboxcolumn15 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn15.DataMember = "Subject";
        this.tttextboxcolumn15.DisplayIndex = 5;
        this.tttextboxcolumn15.HeaderText = "Giriş ve Çıkış Nedenleri";
        this.tttextboxcolumn15.Name = "tttextboxcolumn15";
        this.tttextboxcolumn15.Width = 80;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 3;

        this.tttextboxcolumn16 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn16.DataMember = "ReceiptNumber";
        this.tttextboxcolumn16.DisplayIndex = 6;
        this.tttextboxcolumn16.HeaderText = "Ayniyat MakbuzNo";
        this.tttextboxcolumn16.Name = "tttextboxcolumn16";
        this.tttextboxcolumn16.ReadOnly = true;
        this.tttextboxcolumn16.Width = 100;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 2;

        this.tttextboxcolumn17 = new TTVisual.TTTextBoxColumn();
        this.tttextboxcolumn17.DataMember = "Descriptions";
        this.tttextboxcolumn17.DisplayIndex = 7;
        this.tttextboxcolumn17.HeaderText = "Açıklamalar";
        this.tttextboxcolumn17.Name = "tttextboxcolumn17";
        this.tttextboxcolumn17.Width = 80;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = "İşlem No";
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 1;

        this.DistributionDocumentMaterialsTabcontrol = new TTVisual.TTTabControl();
        this.DistributionDocumentMaterialsTabcontrol.Name = "DistributionDocumentMaterialsTabcontrol";
        this.DistributionDocumentMaterialsTabcontrol.TabIndex = 30;

        this.DistributionDocumentMaterialsTabpage = new TTVisual.TTTabPage();
        this.DistributionDocumentMaterialsTabpage.DisplayIndex = 0;
        this.DistributionDocumentMaterialsTabpage.TabIndex = 0;
        this.DistributionDocumentMaterialsTabpage.Text = "Taşınır Malın";
        this.DistributionDocumentMaterialsTabpage.Name = "DistributionDocumentMaterialsTabpage";

        this.MainStoreDistDocDetails = new TTVisual.TTGrid();
        this.MainStoreDistDocDetails.Name = "MainStoreDistDocDetails";
        this.MainStoreDistDocDetails.TabIndex = 29;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = "Detay";
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = "Detay";
        this.Detail.Width = 80;

        this.MaterialDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialDistributionDocumentMaterial.AllowMultiSelect = true;
        this.MaterialDistributionDocumentMaterial.ListDefName = "MaterialListDefinition";
        this.MaterialDistributionDocumentMaterial.DataMember = "Material";
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = "Malzeme Adı";
        this.MaterialDistributionDocumentMaterial.Name = "MaterialDistributionDocumentMaterial";
        this.MaterialDistributionDocumentMaterial.Width = 300;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = "Ölçü Birimi";
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 75;

        this.SendedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.SendedAmountDistributionDocumentMaterial.DataMember = "SendedAmount";
        this.SendedAmountDistributionDocumentMaterial.Required = true;
        this.SendedAmountDistributionDocumentMaterial.Format = "N4";
        this.SendedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SendedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.SendedAmountDistributionDocumentMaterial.HeaderText = "Gönderilen Miktar";
        this.SendedAmountDistributionDocumentMaterial.Name = "SendedAmountDistributionDocumentMaterial";
        this.SendedAmountDistributionDocumentMaterial.Width = 75;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = "Amount";
        this.AmountDistributionDocumentMaterial.Format = "N4";
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = "Verilen Miktar";
        this.AmountDistributionDocumentMaterial.Name = "AmountDistributionDocumentMaterial";
        this.AmountDistributionDocumentMaterial.Width = 75;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = "StoreStock";
        this.StoreInheld.Format = "N4";
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = "Depo Mevcudu";
        this.StoreInheld.Name = "StoreInheld";
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Visible = false;
        this.StoreInheld.Width = 75;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = "StockLevelType";
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = "Malın Durumu";
        this.StockLevelTypeDistributionDocumentMaterial.Name = "StockLevelTypeDistributionDocumentMaterial";
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = true;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 75;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = "Birim Fiyatı";
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 75;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = "Price";
        this.Price.Format = "N4";
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = "Tutarı";
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 75;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = "StockActionDetailStatusEnum";
        this.StatusDistributionDocumentMaterial.DataMember = "Status";
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = "Durum";
        this.StatusDistributionDocumentMaterial.Name = "StatusDistributionDocumentMaterial";
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 75;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "Teslim Eden";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 139;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Required = true;
        this.tttextbox2.BackColor = "#FFE3C6";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 138;

        this.tttextbox3 = new TTVisual.TTTextBox();
        this.tttextbox3.Required = true;
        this.tttextbox3.BackColor = "#FFE3C6";
        this.tttextbox3.Name = "tttextbox3";
        this.tttextbox3.TabIndex = 136;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Teslim Alan";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 137;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 138;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 136;

        this.SequenceNumber = new TTVisual.TTTextBox();
        this.SequenceNumber.BackColor = "#F0F0F0";
        this.SequenceNumber.ReadOnly = true;
        this.SequenceNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SequenceNumber.Name = "SequenceNumber";
        this.SequenceNumber.TabIndex = 3;

        this.BudgeTypeEnum = new TTVisual.TTEnumComboBoxColumn();
        this.BudgeTypeEnum.DataTypeName = 'MKYS_EButceTurEnum';
        this.BudgeTypeEnum.DataMember = 'BudgeType';
        this.BudgeTypeEnum.DisplayIndex = 4;
        this.BudgeTypeEnum.HeaderText = i18n("M12145", "Bütçe Tipi");
        this.BudgeTypeEnum.Name = 'BudgeTypeEnum';
        this.BudgeTypeEnum.ReadOnly = true;
        this.BudgeTypeEnum.Width = 140;

        this.DescriptionsDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DescriptionsDocumentRecordLog.DataMember = 'Descriptions';
        this.DescriptionsDocumentRecordLog.DisplayIndex = 7;
        this.DescriptionsDocumentRecordLog.HeaderText = i18n("M10483", "Açıklamalar");
        this.DescriptionsDocumentRecordLog.Name = 'DescriptionsDocumentRecordLog';
        this.DescriptionsDocumentRecordLog.Width = 120;

        this.DocumentDateTimeDocumentRecordLog = new TTVisual.TTDateTimePickerColumn();
        this.DocumentDateTimeDocumentRecordLog.DataMember = "DocumentDateTime";
        this.DocumentDateTimeDocumentRecordLog.DisplayIndex = 0;
        this.DocumentDateTimeDocumentRecordLog.HeaderText = i18n("M11748", "Belge Tarihi");
        this.DocumentDateTimeDocumentRecordLog.Name = "DocumentDateTimeDocumentRecordLog";
        this.DocumentDateTimeDocumentRecordLog.Width = 180;
        this.DocumentDateTimeDocumentRecordLog.ReadOnly = true;

        this.DocumentRecordLogNumberDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.DocumentRecordLogNumberDocumentRecordLog.DataMember = "DocumentRecordLogNumber";
        this.DocumentRecordLogNumberDocumentRecordLog.DisplayIndex = 1;
        this.DocumentRecordLogNumberDocumentRecordLog.HeaderText = i18n("M11746", "Belge Numarası");
        this.DocumentRecordLogNumberDocumentRecordLog.Name = "DocumentRecordLogNumberDocumentRecordLog";
        this.DocumentRecordLogNumberDocumentRecordLog.Width = 120;
        this.DocumentRecordLogNumberDocumentRecordLog.ReadOnly = true;

        this.SubjectDocumentRecordLog = new TTVisual.TTTextBoxColumn();
        this.SubjectDocumentRecordLog.DataMember = "Subject";
        this.SubjectDocumentRecordLog.DisplayIndex = 4;
        this.SubjectDocumentRecordLog.HeaderText = i18n("M14805", "Giriş ve Çıkış Nedenleri");
        this.SubjectDocumentRecordLog.Name = "SubjectDocumentRecordLog";
        this.SubjectDocumentRecordLog.Width = 140;
        this.SubjectDocumentRecordLog.Visible = false;
        this.SubjectDocumentRecordLog.ReadOnly = true;

        this.ReceiptNumber = new TTVisual.TTTextBoxColumn();
        this.ReceiptNumber.DataMember = "ReceiptNumber";
        this.ReceiptNumber.DisplayIndex = 5;
        this.ReceiptNumber.HeaderText = "Ayniyat Makbuz No";
        this.ReceiptNumber.Name = "ReceiptNumber";
        this.ReceiptNumber.ReadOnly = true;
        this.ReceiptNumber.Width = 140;

        this.DocumentTransactionTypeDocumentRecordLog = new TTVisual.TTEnumComboBoxColumn();
        this.DocumentTransactionTypeDocumentRecordLog.DataTypeName = "DocumentTransactionTypeEnum";
        this.DocumentTransactionTypeDocumentRecordLog.DataMember = "DocumentTransactionType";
        this.DocumentTransactionTypeDocumentRecordLog.DisplayIndex = 2;
        this.DocumentTransactionTypeDocumentRecordLog.HeaderText = i18n("M16834", "İşlem Çeşidi");
        this.DocumentTransactionTypeDocumentRecordLog.Name = "DocumentTransactionTypeDocumentRecordLog";
        this.DocumentTransactionTypeDocumentRecordLog.Width = 140;
        this.DocumentTransactionTypeDocumentRecordLog.ReadOnly = true;

        this.DocumentRecordLogs = new TTVisual.TTGrid();
        this.DocumentRecordLogs.Name = "DocumentRecordLogs";
        this.DocumentRecordLogs.TabIndex = 129;
        this.DocumentRecordLogs.Height = 350;
        this.DocumentRecordLogs.AllowUserToAddRows = false;
        this.DocumentRecordLogs.AllowUserToDeleteRows = false;
        this.DocumentRecordLogs.ReadOnly = true;

        this.DocumentRecordLogSearch = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogSearch.Text = 'MKYS Log Sorgula';
        this.DocumentRecordLogSearch.Name = 'GetLogFromMkys';

        this.DocumentRecordLogDeleteMKYS = new TTVisual.TTButtonColumn();
        this.DocumentRecordLogDeleteMKYS.Text = 'MKYS Kayıt Sil';
        this.DocumentRecordLogDeleteMKYS.Name = 'DeleteMkysRow';
        

        this.DocumentRecordLogsColumns = [this.DocumentDateTimeDocumentRecordLog, this.DocumentRecordLogNumberDocumentRecordLog,
        this.DocumentTransactionTypeDocumentRecordLog, this.BudgeTypeEnum, this.SubjectDocumentRecordLog,
        this.ReceiptNumber, this.DescriptionsDocumentRecordLog,this.DocumentRecordLogDeleteMKYS,this.DocumentRecordLogSearch];
        this.ttgrid3Columns = [this.ttdatetimepickercolumn2, this.tttextboxcolumn13, this.ttenumcomboboxcolumn4, this.tttextboxcolumn14, this.ttenumcomboboxcolumn5, this.tttextboxcolumn15, this.tttextboxcolumn16, this.tttextboxcolumn17];
        this.MainStoreDistDocDetailsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.DocumentRecordLogs.Controls = [this.ttgrid3];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DocumentRecordLogs, this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.MainStoreDistDocDetails];
        this.Controls = [this.DocumentRecordLogs, this.labelDescription, this.ttgrid3, this.Description, this.ttdatetimepickercolumn2, this.StockActionID, this.tttextboxcolumn13, this.labelStore, this.ttenumcomboboxcolumn4, this.Store, this.tttextboxcolumn14, this.labelDestinationStore, this.ttenumcomboboxcolumn5, this.DestinationStore, this.tttextboxcolumn15, this.labelTransactionDate, this.tttextboxcolumn16, this.TransactionDate, this.tttextboxcolumn17, this.labelStockActionID, this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage, this.MainStoreDistDocDetails, this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.ttlabel2, this.tttextbox2, this.tttextbox3, this.ttlabel3, this.MKYS_TeslimAlan, this.MKYS_TeslimEden,this.DocumentRecordLogDeleteMKYS];

    }


}
