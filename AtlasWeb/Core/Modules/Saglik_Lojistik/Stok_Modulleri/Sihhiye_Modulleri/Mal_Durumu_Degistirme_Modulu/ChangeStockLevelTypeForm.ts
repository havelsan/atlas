//$0E0C2BFA
import { Component, ViewChild, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ChangeStockLevelTypeFormViewModel } from './ChangeStockLevelTypeFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ChangeStockLevelType, StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { StockLevelService } from 'ObjectClassService/StockLevelService';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ChangeStockLevelTypeDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';

import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { DxDataGridComponent } from "devextreme-angular";
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

@Component({
    selector: 'ChangeStockLevelTypeForm',
    templateUrl: './ChangeStockLevelTypeForm.html',
    providers: [MessageService]
})
export class ChangeStockLevelTypeForm extends StockActionBaseForm implements OnInit {
    AmountStockActionDetailIn: TTVisual.ITTTextBoxColumn;
    MaterialStockActionDetailIn: TTVisual.ITTListBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    Description: TTVisual.ITTTextBox;
    DistributionType: TTVisual.ITTTextBoxColumn;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    MaterialDetails: TTVisual.ITTGrid;
    MaterialStockActionDetail: TTVisual.ITTListBoxColumn;
    MaterialTabPanel: TTVisual.ITTTabPage;
    StockActionID: TTVisual.ITTTextBox;
    StockLevelTypeStockActionDetailIn: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreStock: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    tttabcontrol1: TTVisual.ITTTabControl;

    public MaterialDetailsColumns = [];
    public changeStockLevelTypeFormViewModel: ChangeStockLevelTypeFormViewModel = new ChangeStockLevelTypeFormViewModel();
    public get _ChangeStockLevelType(): ChangeStockLevelType {
        return this._TTObject as ChangeStockLevelType;
    }
    private ChangeStockLevelTypeForm_DocumentUrl: string = '/api/ChangeStockLevelTypeService/ChangeStockLevelTypeForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        protected changeDetectorRef: ChangeDetectorRef,
        protected reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.ChangeStockLevelTypeForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    // ***** Method declarations start *****
    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ChangeStockLevelType.ObjectID.toString());
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

    public getIsCompleted() {
        return false;
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        super.PreScript();

        if (this._ChangeStockLevelType.Store == null) {
            this._ChangeStockLevelType.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if (this._ChangeStockLevelType.CurrentStateDefID.toString() === ChangeStockLevelType.ChangeStockLevelTypeStates.Registry.id) {
            this.MaterialStockActionDetailIn.ListFilterExpression = " STOCKS.STORE= '" + this._ChangeStockLevelType.Store.ObjectID + "' AND STOCKS.INHELD > 0";
        }

        if ((<MainStoreDefinition>this._ChangeStockLevelType.Store).MKYS_ButceTuru != undefined) {
            if ((<MainStoreDefinition>this._ChangeStockLevelType.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChangeStockLevelType.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._ChangeStockLevelType.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._ChangeStockLevelType.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }


        this.MaterialStockActionDetail.ListFilterExpression = 'STOCKS.STORE = \'' + this._ChangeStockLevelType.Store.ObjectID + '\' AND STOCKS.INHELD > 0 ';
        this._ChangeStockLevelType.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.ihtiyacFazlasi;
        this._ChangeStockLevelType.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckIhtiyacFazlasi;
        this._ChangeStockLevelType.MKYS_EButceTur = (<MainStoreDefinition>(this._ChangeStockLevelType.Store)).MKYS_ButceTuru;
    }
    onRowInserting(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ChangeStockLevelType();
        this.changeStockLevelTypeFormViewModel = new ChangeStockLevelTypeFormViewModel();
        this._ViewModel = this.changeStockLevelTypeFormViewModel;
        this.changeStockLevelTypeFormViewModel._ChangeStockLevelType = this._TTObject as ChangeStockLevelType;
        this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails = new Array<ChangeStockLevelTypeDetail>();
        this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.changeStockLevelTypeFormViewModel = this._ViewModel as ChangeStockLevelTypeFormViewModel;
        that._TTObject = this.changeStockLevelTypeFormViewModel._ChangeStockLevelType;
        if (this.changeStockLevelTypeFormViewModel == null) {
            this.changeStockLevelTypeFormViewModel = new ChangeStockLevelTypeFormViewModel();
        }
        if (this.changeStockLevelTypeFormViewModel._ChangeStockLevelType == null) {
            this.changeStockLevelTypeFormViewModel._ChangeStockLevelType = new ChangeStockLevelType();
        }
        that.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails = that.changeStockLevelTypeFormViewModel.MaterialDetailsGridList;
        for (let detailItem of that.changeStockLevelTypeFormViewModel.MaterialDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.changeStockLevelTypeFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.changeStockLevelTypeFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.changeStockLevelTypeFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let stockLevelTypeObjectID = detailItem['StockLevelType'];
            if (stockLevelTypeObjectID != null && (typeof stockLevelTypeObjectID === 'string')) {
                let stockLevelType = that.changeStockLevelTypeFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let budgetTypeDefinitionObjectID = that.changeStockLevelTypeFormViewModel._ChangeStockLevelType['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.changeStockLevelTypeFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.changeStockLevelTypeFormViewModel._ChangeStockLevelType.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.changeStockLevelTypeFormViewModel._ChangeStockLevelType['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.changeStockLevelTypeFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.changeStockLevelTypeFormViewModel._ChangeStockLevelType.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ChangeStockLevelTypeFormViewModel);
        this.FormCaption = i18n("M16243", "İhtiyaç Fazlası Bildirme( Yeni )");
        this.changeDetectorRef.detectChanges();

    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.BudgetTypeDefinition !== event) {
                this._ChangeStockLevelType.BudgetTypeDefinition = event;
            }
        }
    }
    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.Description !== event) {
                this._ChangeStockLevelType.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.StockActionID !== event) {
                this._ChangeStockLevelType.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.Store !== event) {
                this._ChangeStockLevelType.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._ChangeStockLevelType != null && this._ChangeStockLevelType.TransactionDate !== event) {
                this._ChangeStockLevelType.TransactionDate = event;
            }
        }
    }

    MaterialDetails_CellValueChangedEmitted(data: any) {
        if (data && this.MaterialDetails_CellValueChanged && data.Row && data.Column) {
            this.MaterialDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }

    //#region dx-data-grid çevirme
    public isCompletedForm: boolean = false;
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: ChangeStockLevelTypeDetail = new ChangeStockLevelTypeDetail();
                newRow.IsNew = true;
                newRow.Material = this.selectedMaterial;
                let stockCardObj: Guid = <any>this.selectedMaterial['StockCard'];
                let stockCard: StockCard = await this.objectContextService.getObject(stockCardObj, StockCard.ObjectDefID);
                newRow.Material.StockCard = stockCard;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                this.setStoreStock(newRow);
                this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }
    public ChangeStockLevelTypeGridColumns = [

        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'Material.StockCard.NATOStockNO',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            //    width: 'auto',
            visible: this.getIsCompleted(),
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: 'Stok Miktarı',
            dataField: 'StoreStock',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: 'Miktar',
            dataField: 'Amount',
            dataType: 'number',
            format: '#',
            editorOptions: {
                onKeyPress: function (e) {
                    let event = e.event,
                        str = String.fromCharCode(event.keyCode);
                    if (!/[0-9]/.test(str))
                        event.preventDefault();
                }
            },
            //  width: 'auto'
        },
        {
            caption: 'Malın Durumu',
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            //  width: 'auto',
            cellTemplate: 'deleteCellTemplate',
            visible: !this.getIsCompleted()
        },
    ];
    /*  public btnAddClick() {
          if (this.selectedMaterial == null)
              ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
          else
              if (!this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                  let newRow: ChangeStockLevelTypeDetail = new ChangeStockLevelTypeDetail();
                  newRow.IsNew = true;
                  newRow.Material = this.selectedMaterial;
                  newRow.StockLevelType = this.selectedStockLevelType;
                  newRow.Status = StockActionDetailStatusEnum.New;
                  this.setStoreStock(newRow);
                  this.changeStockLevelTypeFormViewModel._ChangeStockLevelType.ChangeStockLevelTypeDetails.push(newRow);
              }
              else
                  ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
      }*/

    public async setStoreStock(changeStockLevelTypeDetail: ChangeStockLevelTypeDetail): Promise<any> {
        if (changeStockLevelTypeDetail.Status === undefined) {
            changeStockLevelTypeDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            changeStockLevelTypeDetail.StockLevelType = stockLeveltypeArray[0];
        }
        if (changeStockLevelTypeDetail.Material.ObjectID != null) {
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(changeStockLevelTypeDetail.Material.ObjectID, this._ChangeStockLevelType.Store.ObjectID, changeStockLevelTypeDetail.StockLevelType.ObjectID);
            changeStockLevelTypeDetail.StoreStock = stockInheld;
        }
    }

    public async stateChange(event: FormSaveInfo) {
        this.gridChangeStockLevelTypeDetail.instance.closeEditCell();
        this.gridChangeStockLevelTypeDetail.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.gridChangeStockLevelTypeDetail.instance.closeEditCell();
        this.gridChangeStockLevelTypeDetail.instance.saveEditData();
        await super.saveForm(event);
    }

    @ViewChild('gridChangeStockLevelTypeDetail') gridChangeStockLevelTypeDetail: DxDataGridComponent;
    async gridChangeStockLevelTypeDetail_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.gridChangeStockLevelTypeDetail.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.gridChangeStockLevelTypeDetail.instance.filter(['EntityState', '<>', 1]);
                            this.gridChangeStockLevelTypeDetail.instance.refresh();

                        }
                    }
                }

            }

        }

    }

    public async MaterialDetails_RowUpdated(event: any) {
    }

    public MaterialDetails_RowRemoved(event: any) {

    }

    //#endregion

    public async MaterialDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await this.MaterialDetails_CellValueChangedBase(data, rowIndex, columnIndex);
    }

    public async MaterialDetails_CellValueChangedBase(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let changeStockLevelTypeDetail: ChangeStockLevelTypeDetail = <ChangeStockLevelTypeDetail>(data.Row.TTObject);
        if (changeStockLevelTypeDetail.Status === undefined) {
            changeStockLevelTypeDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            changeStockLevelTypeDetail.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === 'MaterialStockActionDetail' || data.Column.Name === 'StockLevelTypeStockActionDetailIn') {

            if (changeStockLevelTypeDetail.Material != null && changeStockLevelTypeDetail.StockLevelType != null) {
                if (changeStockLevelTypeDetail.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(changeStockLevelTypeDetail.Material.ObjectID,
                        this._ChangeStockLevelType.Store.ObjectID, changeStockLevelTypeDetail.StockLevelType.ObjectID);
                    changeStockLevelTypeDetail.StoreStock = stockInheld;
                }
            }
        }
    }



    onRowInsertting(data: ChangeStockLevelTypeDetail) {
    }

    onCellContentClicked(data: any) {
    }

    async initNewRow(data: any) {
    }


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.MaterialStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetailIn.AllowMultiSelect = true;
        this.MaterialStockActionDetailIn.ListDefName = "MaterialListDefinition";
        this.MaterialStockActionDetailIn.DataMember = "Material";
        this.MaterialStockActionDetailIn.AutoCompleteDialogHeight = "60%";
        this.MaterialStockActionDetailIn.AutoCompleteDialogWidth = "50%";
        this.MaterialStockActionDetailIn.DisplayIndex = 1;
        this.MaterialStockActionDetailIn.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetailIn.Name = "MaterialStockActionDetailIn";
        this.MaterialStockActionDetailIn.Width = 300;


        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = 'labelDescription';
        this.labelDescription.TabIndex = 13;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 12;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = 'labelBudgetTypeDefinition';
        this.labelBudgetTypeDefinition.TabIndex = 15;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 14;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M10896", "Ana Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 11;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 10;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.CustomFormat = '';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.BackColor = '#DCDCDC';
        this.labelStockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStockActionID.ForeColor = '#000000';
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 5;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = '#DCDCDC';
        this.labelTransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelTransactionDate.ForeColor = '#000000';
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 9;

        this.MaterialDetails = new TTVisual.TTGrid();
        this.MaterialDetails.Required = true;
        this.MaterialDetails.Name = 'MaterialDetails';
        this.MaterialDetails.TabIndex = 0;
        this.MaterialDetails.Height = 350;

        this.MaterialStockActionDetail = new TTVisual.TTListBoxColumn();
        this.MaterialStockActionDetail.ListDefName = 'MaterialListDefinition';
        this.MaterialStockActionDetail.DataMember = 'Material';
        this.MaterialStockActionDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialStockActionDetail.AutoCompleteDialogWidth = '90%';
        this.MaterialStockActionDetail.DisplayIndex = 0;
        this.MaterialStockActionDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialStockActionDetail.Name = 'MaterialStockActionDetail';
        this.MaterialStockActionDetail.Width = 500;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 1;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 140;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = 'StoreStock';
        this.StoreStock.DisplayIndex = 2;
        this.StoreStock.HeaderText = i18n("M22360", "Stok Miktarı");
        this.StoreStock.Name = 'StoreStock';
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.AmountStockActionDetailIn = new TTVisual.TTTextBoxColumn();
        this.AmountStockActionDetailIn.DataMember = 'Amount';
        this.AmountStockActionDetailIn.Format = '#,###.####';
        this.AmountStockActionDetailIn.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountStockActionDetailIn.DisplayIndex = 3;
        this.AmountStockActionDetailIn.HeaderText = i18n("M19030", "Miktar");
        this.AmountStockActionDetailIn.Name = 'AmountStockActionDetailIn';
        this.AmountStockActionDetailIn.Width = 75;
        this.AmountStockActionDetailIn.IsNumeric = true;

        this.MaterialTabPanel = new TTVisual.TTTabPage();
        this.MaterialTabPanel.DisplayIndex = 0;
        this.MaterialTabPanel.TabIndex = 0;
        this.MaterialTabPanel.Text = 'Taşınır Malın';
        this.MaterialTabPanel.Name = 'MaterialTabPanel';

        this.StockLevelTypeStockActionDetailIn = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeStockActionDetailIn.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeStockActionDetailIn.DataMember = 'StockLevelType';
        this.StockLevelTypeStockActionDetailIn.Required = true;
        this.StockLevelTypeStockActionDetailIn.DisplayIndex = 4;
        this.StockLevelTypeStockActionDetailIn.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeStockActionDetailIn.Name = 'StockLevelTypeStockActionDetailIn';
        this.StockLevelTypeStockActionDetailIn.ReadOnly = true;
        this.StockLevelTypeStockActionDetailIn.Width = 140;

        this.MaterialDetailsColumns = [this.MaterialStockActionDetail, this.DistributionType, this.StoreStock, this.AmountStockActionDetailIn, this.StockLevelTypeStockActionDetailIn];
        //this.tttabcontrol1.Controls = [this.MaterialTabPanel];
        this.MaterialTabPanel.Controls = [this.MaterialDetails];
        this.Controls = [this.MaterialStockActionDetailIn, this.MaterialTabPanel, this.MaterialDetails, this.MaterialStockActionDetail, this.DistributionType, this.StoreStock,
        this.AmountStockActionDetailIn, this.StockLevelTypeStockActionDetailIn, this.Description, this.StockActionID, this.labelBudgetTypeDefinition,
        this.BudgetTypeDefinition, this.labelDescription, this.labelStore, this.Store, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate];



    }


}
