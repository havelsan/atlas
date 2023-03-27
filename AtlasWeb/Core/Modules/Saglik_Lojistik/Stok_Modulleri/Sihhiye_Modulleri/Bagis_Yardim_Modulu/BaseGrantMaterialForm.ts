//$646EF5E2
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseGrantMaterialFormViewModel } from './BaseGrantMaterialFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseChattelDocumentForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentForm';
import { GrantMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';
import { SupplierService } from 'ObjectClassService/SupplierService';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';

import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { GrantMaterialDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";

@Component({
    selector: 'BaseGrantMaterialForm',
    templateUrl: './BaseGrantMaterialForm.html',
    providers: [MessageService]
})
export class BaseGrantMaterialForm extends BaseChattelDocumentForm implements OnInit {
    AmountGrantMaterialDetail: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    ChattelDocumentDetailTabpage: TTVisual.ITTTabPage;
    ChattelDocumentTabcontrol: TTVisual.ITTTabControl;
    Detail: TTVisual.ITTButtonColumn;
    DistiributionType: TTVisual.ITTTextBoxColumn;
    ExpirationDateGrantMaterialDetail: TTVisual.ITTDateTimePickerColumn;
    GrantMaterialDetails: TTVisual.ITTGrid;
    GranttedByUniqNo: TTVisual.ITTTextBox;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelDestinationStore: TTVisual.ITTLabel;
    labelGranttedByUniqNo: TTVisual.ITTLabel;
    labelMaterialGranttedBy: TTVisual.ITTLabel;
    labelMKYS_EMalzemeGrup: TTVisual.ITTLabel;
    labelMKYS_ETedarikTuru: TTVisual.ITTLabel;
    LotNoGrantMaterialDetail: TTVisual.ITTTextBoxColumn;
    MaterialGMaterialDetail: TTVisual.ITTListBoxColumn;
    MaterialGrantMaterialDetail: TTVisual.ITTListBoxColumn;
    MaterialGranttedBy: TTButtonTextBox;
    MKYS_EMalzemeGrup: TTVisual.ITTEnumComboBox;
    MKYS_ETedarikTuru: TTVisual.ITTEnumComboBox;
    NotDiscountedUnitPrice: TTVisual.ITTTextBoxColumn;
    ProductionDateGrantMaterialDetail: TTVisual.ITTDateTimePickerColumn;
    RetrievalYearGrantMaterialDetail: TTVisual.ITTTextBoxColumn;
    StockLevelType: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    TTFirma: TTVisual.ITTButton;
    UnitPrice: TTVisual.ITTTextBoxColumn;
    public expirationMinDate: Date = new Date(Date.now());
    public StockActionSignDetailsColumns = [];
    public baseGrantMaterialFormViewModel: BaseGrantMaterialFormViewModel = new BaseGrantMaterialFormViewModel();
    public get _GrantMaterial(): GrantMaterial {
        return this._TTObject as GrantMaterial;
    }
    private BaseGrantMaterialForm_DocumentUrl: string = '/api/GrantMaterialService/BaseGrantMaterialForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseGrantMaterialForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    public async GrantMaterialDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let grantMaterialDetail: GrantMaterialDetail = <GrantMaterialDetail>(data.Row.TTObject);
        if (data.Column.Name === 'MaterialGrantMaterialDetail') {
            //grantMaterialDetail.UnitPrice = 1;
            //grantMaterialDetail.NotDiscountedUnitPrice = 1;
            let today = new Date();
            let year = today.getFullYear();
            grantMaterialDetail.RetrievalYear = year;
        }
        if (grantMaterialDetail.Status === undefined) {
            grantMaterialDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            grantMaterialDetail.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === "ExpirationDateGrantMaterialDetail") {
            let endOfMonth: Date = new Date(grantMaterialDetail.ExpirationDate.getFullYear(), grantMaterialDetail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            grantMaterialDetail.ExpirationDate = endOfMonth;
        }
    }


    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
    }

    public btnAddClick() {
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._GrantMaterial.GrantMaterialDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: GrantMaterialDetail = new GrantMaterialDetail();
                newRow.Material = this.selectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.IsNew = true;
                let today = new Date();
                let year = today.getFullYear();
                newRow.RetrievalYear = year;
                this._GrantMaterial.GrantMaterialDetails.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public onGrantMaterialGridRowRemoved(event: any) {

    }

    public onGrantMaterialGridRowUpdated(event: any) {
        //console.log(event);
        let grantMaterialDetail: GrantMaterialDetail = <GrantMaterialDetail>(event.key);
        if (event.data.ExpirationDate != undefined) {
            let endOfMonth: Date = new Date(grantMaterialDetail.ExpirationDate.getFullYear(), grantMaterialDetail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            grantMaterialDetail.ExpirationDate = endOfMonth;
        }
    }
    public getIsReadOnly() {
        return false;
    }

    @ViewChild('gridGrantMaterial') gridGrantMaterial: DxDataGridComponent;
    async gridGrantMaterial_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.gridGrantMaterial.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.gridGrantMaterial.instance.filter(['EntityState', '<>', 1]);
                            this.gridGrantMaterial.instance.refresh();

                        }
                    }
                }

            }

        }
    }

    public async stateChange(event: FormSaveInfo) {
        this.gridGrantMaterial.instance.closeEditCell();
        this.gridGrantMaterial.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo) {
        this.gridGrantMaterial.instance.closeEditCell();
        this.gridGrantMaterial.instance.saveEditData();
        await super.saveForm(event);
    }

    public GrantMaterialGridColumns = [

        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
         //   width: 'auto'
        },
        {
            caption: i18n("M10707", "Alınan Miktar"),
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
            caption: i18n("M16508", "İndirimsiz Birim Fiyat"),
            dataField: 'NotDiscountedUnitPrice',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
           // width: 'auto'
        },
        {
            caption: i18n("M11855", "Birim Fiyat"),
            dataField: 'UnitPrice',
            dataType: 'number',
          //  width: 'auto'
        },
        {
            caption: i18n("M18356", "Lot Nu."),
            dataField: 'LotNo',
          //  width: 'auto'
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            editorOptions: {
                min: this.expirationMinDate,
            }
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
          //  width: 'auto'
        },
        {
            caption: 'Edinim Yılı',
            dataField: 'RetrievalYear',
            dataType: 'number',
         //   width: 'auto'
        },
        {
            caption: 'Üretim Tarihi',
            dataField: 'ProductionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
          //  width: 'auto'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
           // width: 'auto',
            cellTemplate: 'deleteCellTemplate',
            visible: !this.getIsReadOnly()
        },
    ];

    //#endregion


    public async TTFirma_Click(): Promise<void> {
        let context: TTObjectContext = new TTObjectContext(false);
        let suppliers: Array<Supplier.SupplierDefFormNQL_Class> = (await SupplierService.SupplierDefFormNQL(''));
        let supplier: Supplier = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let sp of suppliers) {
            multiSelectForm.AddMSItem(sp.Name, sp.Name, sp);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M22974", "Tedarikçi Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15737", "Herhangibir Tedarikçi Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            supplier = multiSelectForm.MSSelectedItemObject as Supplier;
            if (supplier.Name != null)
                this.MaterialGranttedBy.Text = supplier.Name.toString();
            if (supplier.TaxNo != undefined) {
                this.GranttedByUniqNo.Text = supplier.TaxNo.toString();
            }
        }
    }

    public async onDocumentRecordLogsCellContentClickedEmmited(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        /* let documentLog: DocumentRecordLog = <DocumentRecordLog>(data.Row.TTObject);
         if (data.Column.Name === 'GetLogFromMkys') {
             let input: DocumentRecordLogReceiptNumber_Input = new DocumentRecordLogReceiptNumber_Input();
             input.receiptNumber = documentLog.ReceiptNumber;
             let getLogs: Array<MkysServis.stokHareketLogItem> = await StockActionService.GetMkysLogSearch(input);
             console.log(getLogs);
         }
         */
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GrantMaterial();
        this.baseGrantMaterialFormViewModel = new BaseGrantMaterialFormViewModel();
        this._ViewModel = this.baseGrantMaterialFormViewModel;
        this.baseGrantMaterialFormViewModel._GrantMaterial = this._TTObject as GrantMaterial;
        this.baseGrantMaterialFormViewModel._GrantMaterial.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.baseGrantMaterialFormViewModel._GrantMaterial.Store = new Store();
        this.baseGrantMaterialFormViewModel._GrantMaterial.GrantMaterialDetails = new Array<GrantMaterialDetail>();
        this.baseGrantMaterialFormViewModel._GrantMaterial.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseGrantMaterialFormViewModel = this._ViewModel as BaseGrantMaterialFormViewModel;
        that._TTObject = this.baseGrantMaterialFormViewModel._GrantMaterial;
        if (this.baseGrantMaterialFormViewModel == null) {
            this.baseGrantMaterialFormViewModel = new BaseGrantMaterialFormViewModel();
        }
        if (this.baseGrantMaterialFormViewModel._GrantMaterial == null) {
            this.baseGrantMaterialFormViewModel._GrantMaterial = new GrantMaterial();
        }
        let budgetTypeDefinitionObjectID = that.baseGrantMaterialFormViewModel._GrantMaterial['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.baseGrantMaterialFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.baseGrantMaterialFormViewModel._GrantMaterial.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.baseGrantMaterialFormViewModel._GrantMaterial['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseGrantMaterialFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseGrantMaterialFormViewModel._GrantMaterial.Store = store;
            }
        }
        that.baseGrantMaterialFormViewModel._GrantMaterial.GrantMaterialDetails = that.baseGrantMaterialFormViewModel.GrantMaterialDetailsGridList;
        for (let detailItem of that.baseGrantMaterialFormViewModel.GrantMaterialDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseGrantMaterialFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseGrantMaterialFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseGrantMaterialFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseGrantMaterialFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseGrantMaterialFormViewModel._GrantMaterial.StockActionSignDetails = that.baseGrantMaterialFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseGrantMaterialFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseGrantMaterialFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseGrantMaterialFormViewModel);

    }

    public onAdditionalDocumentCountChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.AdditionalDocumentCount !== event) {
                this._GrantMaterial.AdditionalDocumentCount = event;
            }
        }
    }

    public onBudgetTypeDefinitionChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.BudgetTypeDefinition !== event) {
                this._GrantMaterial.BudgetTypeDefinition = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.Description !== event) {
                this._GrantMaterial.Description = event;
            }
        }
    }

    public onGranttedByUniqNoChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.GranttedByUniqNo !== event) {
                this._GrantMaterial.GranttedByUniqNo = event;
            }
        }
    }

    public onMaterialGranttedByChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MaterialGranttedBy != null) {
                this.MaterialGranttedBy.BackColor = '#F0F0F0';
                this.MaterialGranttedBy.ReadOnly = true;
            }
            if (this._GrantMaterial.GranttedByUniqNo != null) {
                this.GranttedByUniqNo.BackColor = '#F0F0F0';
                this.GranttedByUniqNo.ReadOnly = true;
            }
            if (this._GrantMaterial != null && this._GrantMaterial.MaterialGranttedBy !== event) {
                this._GrantMaterial.MaterialGranttedBy = event;
            }
        }
    }

    public onMKYS_EMalzemeGrupChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_EMalzemeGrup !== event) {
                this._GrantMaterial.MKYS_EMalzemeGrup = event;
            }
        }
    }

    public onMKYS_ETedarikTuruChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_ETedarikTuru !== event) {
                this._GrantMaterial.MKYS_ETedarikTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_TeslimAlan !== event) {
                this._GrantMaterial.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }

            if (this._GrantMaterial != null && this._GrantMaterial.MKYS_TeslimEden !== event) {
                this._GrantMaterial.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.StockActionID !== event) {
                this._GrantMaterial.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.Store !== event) {
                this._GrantMaterial.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._GrantMaterial != null && this._GrantMaterial.TransactionDate !== event) {
                this._GrantMaterial.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.MaterialGranttedBy, 'Text', this.__ttObject, 'MaterialGranttedBy');
        redirectProperty(this.GranttedByUniqNo, 'Text', this.__ttObject, 'GranttedByUniqNo');
        redirectProperty(this.MKYS_EMalzemeGrup, 'Value', this.__ttObject, 'MKYS_EMalzemeGrup');
        redirectProperty(this.MKYS_ETedarikTuru, 'Value', this.__ttObject, 'MKYS_ETedarikTuru');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
    }

    public initFormControls(): void {
        this.GranttedByUniqNo = new TTVisual.TTTextBox();
        this.GranttedByUniqNo.Required = true;
        this.GranttedByUniqNo.BackColor = '#FFE3C6';
        this.GranttedByUniqNo.Name = 'GranttedByUniqNo';
        this.GranttedByUniqNo.TabIndex = 129;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.MaterialGranttedBy = new TTButtonTextBox();
        this.MaterialGranttedBy.Required = true;
        this.MaterialGranttedBy.BackColor = '#FFE3C6';
        this.MaterialGranttedBy.Name = 'MaterialGranttedBy';
        this.MaterialGranttedBy.TabIndex = 122;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTFirma = new TTVisual.TTButton();
        this.TTFirma.Text = i18n("M14301", "Firma");
        this.TTFirma.Name = 'TTFirma';
        this.TTFirma.TabIndex = 133;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 119;

        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = 'labelBudgetTypeDefinition';
        this.labelBudgetTypeDefinition.TabIndex = 132;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = '#FFE3C6';
        //this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 118;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ReadOnly = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = 'BudgetTypeDefinition';
        this.BudgetTypeDefinition.TabIndex = 131;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = '10%';
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = '20%';


        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = '#FFE3C6';
        this.MKYS_TeslimAlan.Name = 'MKYS_TeslimAlan';
        this.MKYS_TeslimAlan.TabIndex = 116;

        this.labelGranttedByUniqNo = new TTVisual.TTLabel();
        this.labelGranttedByUniqNo.Text = i18n("M11416", "Bağış Yapan TC / Kurum Vergi No");
        this.labelGranttedByUniqNo.Name = 'labelGranttedByUniqNo';
        this.labelGranttedByUniqNo.TabIndex = 130;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = 'labelMKYS_EMalzemeGrup';
        this.labelMKYS_EMalzemeGrup.TabIndex = 128;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = 'MKYS_EMalzemeGrupEnum';
        this.MKYS_EMalzemeGrup.BackColor = '#F0F0F0';
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = 'MKYS_EMalzemeGrup';
        this.MKYS_EMalzemeGrup.TabIndex = 127;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 117;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 126;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 115;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M11412", "Bağış / Yardım Yapılan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 125;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelMaterialGranttedBy = new TTVisual.TTLabel();
        this.labelMaterialGranttedBy.Text = i18n("M11415", "Bağış Yapan Kişi / Kurum");
        this.labelMaterialGranttedBy.Name = 'labelMaterialGranttedBy';
        this.labelMaterialGranttedBy.TabIndex = 123;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 113;

        this.ChattelDocumentTabcontrol = new TTVisual.TTTabControl();
        this.ChattelDocumentTabcontrol.Name = 'ChattelDocumentTabcontrol';
        this.ChattelDocumentTabcontrol.TabIndex = 120;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 5;
        this.DescriptionAndSignTabControl.Visible = false;

        this.ChattelDocumentDetailTabpage = new TTVisual.TTTabPage();
        this.ChattelDocumentDetailTabpage.DisplayIndex = 0;
        this.ChattelDocumentDetailTabpage.TabIndex = 0;
        this.ChattelDocumentDetailTabpage.Text = 'Taşınır Malın';
        this.ChattelDocumentDetailTabpage.Name = 'ChattelDocumentDetailTabpage';

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.GrantMaterialDetails = new TTVisual.TTGrid();
        this.GrantMaterialDetails.Name = 'GrantMaterialDetails';
        this.GrantMaterialDetails.TabIndex = 127;


        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.Width = 100;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        /*this.MaterialGMaterialDetail = new TTVisual.ITTListBoxColumn();
        this.MaterialGMaterialDetail.ListDefName = "MaterialListDefinition";
        this.MaterialGMaterialDetail.DataMember = "Material";
        this.MaterialGMaterialDetail.AutoCompleteDialogHeight = "60%";
        this.MaterialGMaterialDetail.AutoCompleteDialogWidth = "50%";
        this.MaterialGMaterialDetail.DisplayIndex = 1;
        this.MaterialGMaterialDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialGMaterialDetail.Name = "MaterialGMaterialDetail";*/


        this.MaterialGrantMaterialDetail = new TTVisual.TTListBoxColumn();
        this.MaterialGrantMaterialDetail.ListDefName = 'MaterialListDefinition';
        this.MaterialGrantMaterialDetail.DataMember = 'Material';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogWidth = '50%';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogWidth = '50%';
        this.MaterialGrantMaterialDetail.DisplayIndex = 1;
        this.MaterialGrantMaterialDetail.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialGrantMaterialDetail.Name = 'MaterialGrantMaterialDetail';
        this.MaterialGrantMaterialDetail.Width = 300;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Barcode';
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DistiributionType = new TTVisual.TTTextBoxColumn();
        this.DistiributionType.DataMember = 'DistributionType';
        this.DistiributionType.DisplayIndex = 3;
        this.DistiributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistiributionType.Name = 'DistiributionType';
        this.DistiributionType.ReadOnly = true;
        this.DistiributionType.Width = 100;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 111;

        this.AmountGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.AmountGrantMaterialDetail.DataMember = 'Amount';
        this.AmountGrantMaterialDetail.Format = '#,###.#########';
        this.AmountGrantMaterialDetail.DisplayIndex = 4;
        this.AmountGrantMaterialDetail.HeaderText = i18n("M10707", "Alınan Miktar");
        this.AmountGrantMaterialDetail.Name = 'AmountGrantMaterialDetail';
        this.AmountGrantMaterialDetail.Width = 80;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.DisplayIndex = 5;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16508", "İndirimsiz Birim Fiyat");
        this.NotDiscountedUnitPrice.Name = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.Width = 100;


        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.Width = 100;

        this.LotNoGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.LotNoGrantMaterialDetail.DataMember = 'LotNo';
        this.LotNoGrantMaterialDetail.DisplayIndex = 7;
        this.LotNoGrantMaterialDetail.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNoGrantMaterialDetail.Name = 'LotNoGrantMaterialDetail';
        this.LotNoGrantMaterialDetail.Width = 80;

        this.ExpirationDateGrantMaterialDetail = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDateGrantMaterialDetail.CustomFormat = 'MM/yyyy';
        this.ExpirationDateGrantMaterialDetail.DataMember = 'ExpirationDate';
        this.ExpirationDateGrantMaterialDetail.DisplayIndex = 8;
        this.ExpirationDateGrantMaterialDetail.HeaderText = i18n("M22057", "Son Kullanma Tarihi");
        this.ExpirationDateGrantMaterialDetail.Name = 'ExpirationDateGrantMaterialDetail';
        this.ExpirationDateGrantMaterialDetail.Width = 180;

        this.StockLevelType = new TTVisual.TTListBoxColumn();
        this.StockLevelType.ListDefName = 'StockLevelTypeList';
        this.StockLevelType.DataMember = 'StockLevelType';
        this.StockLevelType.DisplayIndex = 9;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = 'StockLevelType';
        this.StockLevelType.Width = 100;

        this.RetrievalYearGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.RetrievalYearGrantMaterialDetail.DataMember = 'RetrievalYear';
        this.RetrievalYearGrantMaterialDetail.DisplayIndex = 10;
        this.RetrievalYearGrantMaterialDetail.HeaderText = 'EdinimYili';
        this.RetrievalYearGrantMaterialDetail.Name = 'RetrievalYearGrantMaterialDetail';
        this.RetrievalYearGrantMaterialDetail.Width = 80;

        this.ProductionDateGrantMaterialDetail = new TTVisual.TTDateTimePickerColumn();
        this.ProductionDateGrantMaterialDetail.DataMember = 'ProductionDate';
        this.ProductionDateGrantMaterialDetail.DisplayIndex = 11;
        this.ProductionDateGrantMaterialDetail.HeaderText = 'UretimTarihi';
        this.ProductionDateGrantMaterialDetail.Name = 'ProductionDateGrantMaterialDetail';
        this.ProductionDateGrantMaterialDetail.Width = 180;

        this.MKYS_ETedarikTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_ETedarikTuru.DataTypeName = 'MKYS_ETedarikTurEnum';
        this.MKYS_ETedarikTuru.Required = true;
        this.MKYS_ETedarikTuru.BackColor = '#F0F0F0';
        this.MKYS_ETedarikTuru.Enabled = false;
        this.MKYS_ETedarikTuru.Name = 'MKYS_ETedarikTuru';
        this.MKYS_ETedarikTuru.TabIndex = 15;

        this.labelMKYS_ETedarikTuru = new TTVisual.TTLabel();
        this.labelMKYS_ETedarikTuru.Text = i18n("M22969", "Tedarik Türü");
        this.labelMKYS_ETedarikTuru.Name = 'labelMKYS_ETedarikTuru';
        this.labelMKYS_ETedarikTuru.TabIndex = 14;

        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.ChattelDocumentTabcontrol.Controls = [this.ChattelDocumentDetailTabpage];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage];
        this.ChattelDocumentDetailTabpage.Controls = [this.GrantMaterialDetails];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.GranttedByUniqNo, this.TTTeslimEdenButon, this.MaterialGranttedBy, this.TTTeslimAlanButon, this.TTFirma,
        this.labelMKYS_TeslimEden, this.labelBudgetTypeDefinition, this.MKYS_TeslimEden, this.BudgetTypeDefinition, this.MKYS_TeslimAlan,
        this.labelGranttedByUniqNo, this.Description, this.labelMKYS_EMalzemeGrup, this.StockActionID, this.MKYS_EMalzemeGrup, this.labelMKYS_TeslimAlan,
        this.Store, this.labelTransactionDate, this.labelDestinationStore, this.TransactionDate, this.labelMaterialGranttedBy, this.labelStockActionID,
        this.ChattelDocumentTabcontrol, this.DescriptionAndSignTabControl, this.ChattelDocumentDetailTabpage, this.SignTabpage, this.GrantMaterialDetails,
        this.StockActionSignDetails, this.Detail, this.SignUserType, this.MaterialGrantMaterialDetail, this.SignUser, this.Barcode, this.IsDeputy,
        this.DistiributionType, this.ttlabel1, this.AmountGrantMaterialDetail, this.NotDiscountedUnitPrice, this.UnitPrice, this.LotNoGrantMaterialDetail,
        this.ExpirationDateGrantMaterialDetail, this.StockLevelType, this.RetrievalYearGrantMaterialDetail, this.ProductionDateGrantMaterialDetail,
        this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru, this.MaterialGMaterialDetail];

    }


}
