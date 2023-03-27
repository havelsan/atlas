//$46EF5615
import { Component, ViewChild, OnInit, ApplicationRef, NgZone, EventEmitter } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { MainStoreDistDocApprovalFormViewModel } from './MainStoreDistDocApprovalFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseMainStoreDistributionDocForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Ana_Depo_Dagitim_Belgesi_Modulu/BaseMainStoreDistributionDocForm";
import { MainStoreDistributionDoc, StockLevelTypeEnum, StockActionDetailStatusEnum, DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MainStoreDistDocDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { TTButtonTextBox } from 'app/NebulaClient/Visual/Controls/TTButtonTextBox';
@Component({
    selector: 'MainStoreDistDocApprovalForm',
    templateUrl: './MainStoreDistDocApprovalForm.html',
    providers: [MessageService]
})
export class MainStoreDistDocApprovalForm extends BaseMainStoreDistributionDocForm implements OnInit {
    public MainStoreDistDocDetailsColumns = [];
    public selectedMaterial: Material;
    public storeListFiltred: string = "";
    public TagNoPopupMaterialName: string;
    public TagNoPopupVisible = false;
    public PopupTagNo: string;
    OnInserted: EventEmitter<any> = new EventEmitter<any>();
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public mainStoreDistDocApprovalFormViewModel: MainStoreDistDocApprovalFormViewModel = new MainStoreDistDocApprovalFormViewModel();
    public get _MainStoreDistributionDoc(): MainStoreDistributionDoc {
        return this._TTObject as MainStoreDistributionDoc;
    }
    private MainStoreDistDocApprovalForm_DocumentUrl: string = '/api/MainStoreDistributionDocService/MainStoreDistDocApprovalForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, private reportService: AtlasReportService, protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.MainStoreDistDocApprovalForm_DocumentUrl;
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
            dataType: 'number'
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
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: 'auto',
            cellTemplate: 'deleteCellTemplate'
        },
    ];

    // ***** Method declarations start *****


    // *****Method declarations end *****

    public preventNewForm = false;
    public resultMessage = "";

    public initViewModel(): void {
        this._TTObject = new MainStoreDistributionDoc();
        this.mainStoreDistDocApprovalFormViewModel = new MainStoreDistDocApprovalFormViewModel();
        this._ViewModel = this.mainStoreDistDocApprovalFormViewModel;
        this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc = this._TTObject as MainStoreDistributionDoc;
        this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.Store = new Store();
        this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.DestinationStore = new Store();
        this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = new Array<MainStoreDistDocDetail>();
    }


    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._MainStoreDistributionDoc.MainStoreDistDocDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: MainStoreDistDocDetail = new MainStoreDistDocDetail();
                newRow.IsNew = true;
                newRow.Material = this.selectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                this.setStoreStock(newRow);
                if (this.selectedMaterial.IsTagNoRequired) {
                    this.TagNoPopupMaterialName = this.selectedMaterial.Name;
                    this.TagNoPopupVisible = true;
                    this.PopupTagNo = "";
                }
                this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
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
    }

    public async setStoreStock(mainStoreDistributionDocumentMaterial: MainStoreDistDocDetail): Promise<any> {
        if (mainStoreDistributionDocumentMaterial.Status === undefined) {
            mainStoreDistributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            mainStoreDistributionDocumentMaterial.StockLevelType = stockLeveltypeArray[0];
        }
        if (mainStoreDistributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(mainStoreDistributionDocumentMaterial.Material.ObjectID, this._MainStoreDistributionDoc.Store.ObjectID, mainStoreDistributionDocumentMaterial.StockLevelType.ObjectID);
            mainStoreDistributionDocumentMaterial.StoreStock = stockInheld;
        }

        if (mainStoreDistributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(mainStoreDistributionDocumentMaterial.Material.ObjectID, this._MainStoreDistributionDoc.DestinationStore.ObjectID, mainStoreDistributionDocumentMaterial.StockLevelType.ObjectID);
            mainStoreDistributionDocumentMaterial.DestinationStoreStock = stockInheldSubStore;
        }

    }


    protected loadViewModel() {
        let that = this;
        that.mainStoreDistDocApprovalFormViewModel = this._ViewModel as MainStoreDistDocApprovalFormViewModel;
        that._TTObject = this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc;
        if (this.mainStoreDistDocApprovalFormViewModel == null)
            this.mainStoreDistDocApprovalFormViewModel = new MainStoreDistDocApprovalFormViewModel();
        if (this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc == null)
            this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc = new MainStoreDistributionDoc();
        let storeObjectID = that.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc["Store"];
        if (storeObjectID != null && (typeof storeObjectID === "string")) {
            let store = that.mainStoreDistDocApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.Store = store;
            }
        }


        let destinationStoreObjectID = that.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc["DestinationStore"];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === "string")) {
            let destinationStore = that.mainStoreDistDocApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.DestinationStore = destinationStore;
            }
        }


        that.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails = that.mainStoreDistDocApprovalFormViewModel.MainStoreDistDocDetailsGridList;
        for (let detailItem of that.mainStoreDistDocApprovalFormViewModel.MainStoreDistDocDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.mainStoreDistDocApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }


                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.mainStoreDistDocApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }


                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.mainStoreDistDocApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.mainStoreDistDocApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }

        }

    }
    async ngOnInit() {
        await this.load(MainStoreDistDocApprovalFormViewModel);
        if (this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M12436", "Ana Depo Dağıtım Belgesi ( Onay )");
    }


    @ViewChild('mainStoreDistributionDocumentApprovalFormMaterialGrid') mainStoreDistributionDocumentApprovalFormMaterialGrid: DxDataGridComponent;
    async mainStoreDistributionDocumentApprovalFormMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew == null) {
                            this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            if (data.row.key.IsNew) {
                                this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.deleteRow(data.rowIndex);
                            }
                            else {
                                data.key.EntityState = EntityStateEnum.Deleted;
                                this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.filter(['EntityState', '<>', 1]);
                                this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.refresh();
                            }
                        }
                    }
                }
            }
        }
    }



    public async stateChange(event: FormSaveInfo) {
        if (this.preventNewForm) {
            ServiceLocator.MessageService.showError(this.resultMessage);
            return;
        }
        let IsTagNoEmpty = false;
        for (var i = 0; i < this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.length; i++)
            if (this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].Material.IsTagNoRequired && (this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].TagNo == "" || this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].TagNo == null)) {
                TTVisual.InfoBox.Alert(this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].Material.Name + " malzemesi için Künye Numarası girmeniz gerekmektedir !");
                IsTagNoEmpty = true;
                return;
            }

        if (!IsTagNoEmpty) {
            if (event.transDef.ToStateDefID.valueOf() === MainStoreDistributionDoc.MainStoreDistributionDocStates.Approval.id) {
                this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.closeEditCell();
                this.mainStoreDistributionDocumentApprovalFormMaterialGrid.instance.saveEditData();
                let isAmountEligable = true;
                this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.forEach(element => {
                    if (element.Amount > element.StoreStock)
                        isAmountEligable = false;
                });
                if (isAmountEligable)
                    await super.setState(event.transDef, event);
                else
                    ServiceLocator.MessageService.showError(i18n("", "İstenen Miktar Depo Mevcudunu aşamaz!"));
            }
            else
                await super.setState(event.transDef, event);
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

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._MainStoreDistributionDoc.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimAlan !== event) {
                this._MainStoreDistributionDoc.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._MainStoreDistributionDoc.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._MainStoreDistributionDoc != null && this._MainStoreDistributionDoc.MKYS_TeslimEden !== event) {
                this._MainStoreDistributionDoc.MKYS_TeslimEden = event;
            }
        }
    }

    public async materialGridRowUpdating(event: any) {
        if (event.newData.Amount != null) {
            if (!isNaN(event.newData.Amount)) {
                if (event.newData.Amount > event.oldData.StoreStock) {
                    ServiceLocator.MessageService.showError(i18n("", "Dağıtılan Miktar Depo Mevcudunu aşamaz!"));
                    event.cancel = true;
                }
                else
                    event.oldData.Amount = event.newData.SendedAmount;
            }
        }
        if (event.newData.TagNo != null) {
            event.oldData.TagNo = event.newData.TagNo;
        }
    }

    public inserTagNo() {
        this.TagNoPopupVisible = false;
        if (this.PopupTagNo != "")
            for (var i = 0; i < this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails.length; i++)
                if (this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].Material.Name == this.TagNoPopupMaterialName) {
                    this.mainStoreDistDocApprovalFormViewModel._MainStoreDistributionDoc.MainStoreDistDocDetails[i].TagNo = this.PopupTagNo;
                }
    }
    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.TransactionDate, "Value", this.__ttObject, "TransactionDate");
        redirectProperty(this.tttextbox3, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
    }

    public initFormControls(): void {
        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = "Açıklama";
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 32;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 31;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 0;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = "Gönderen Depo";
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 8;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 7;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = "Alan Depo";
        this.labelDestinationStore.Name = "labelDestinationStore";
        this.labelDestinationStore.TabIndex = 6;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ListDefName = "SubStoreList";
        this.DestinationStore.Name = "DestinationStore";
        this.DestinationStore.TabIndex = 5;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = "İşlem Tarihi";
        this.labelTransactionDate.Name = "labelTransactionDate";
        this.labelTransactionDate.TabIndex = 3;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Name = "TransactionDate";
        this.TransactionDate.TabIndex = 2;

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
        this.MKYS_TeslimAlan.TabIndex = 136

        this.MainStoreDistDocDetailsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.MainStoreDistDocDetails];
        this.Controls = [this.labelDescription, this.Description, this.StockActionID, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.labelTransactionDate, this.TransactionDate, this.labelStockActionID, this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage, this.MainStoreDistDocDetails, this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType, this.SendedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.ttlabel2, this.tttextbox2, this.tttextbox3, this.ttlabel3, this.MKYS_TeslimAlan, this.MKYS_TeslimEden];

    }


}
