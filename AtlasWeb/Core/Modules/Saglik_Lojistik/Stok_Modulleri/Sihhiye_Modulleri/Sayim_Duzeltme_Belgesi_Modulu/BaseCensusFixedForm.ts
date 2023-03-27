//$71804261
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseCensusFixedFormViewModel } from './BaseCensusFixedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CensusFixed } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialIn } from 'NebulaClient/Model/AtlasClientModel';
import { CensusFixedMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from "ObjectClassService/ResUserService";
import { StockActionBaseForm } from "Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm";
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';

import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelService } from "ObjectClassService/StockLevelService";
import { StockLevelTypeService } from "ObjectClassService/StockLevelTypeService";
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { DxDataGridComponent } from 'devextreme-angular';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';



@Component({
    selector: 'BaseCensusFixedForm',
    templateUrl: './BaseCensusFixedForm.html',
    providers: [MessageService]
})
export class BaseCensusFixedForm extends StockActionBaseForm implements OnInit {
    Amount: TTVisual.ITTTextBoxColumn;
    AmountOut: TTVisual.ITTTextBoxColumn;
    AproximateUnitPriceOut: TTVisual.ITTTextBoxColumn;
    BarcodeA: TTVisual.ITTTextBoxColumn;
    BarcodeE: TTVisual.ITTTextBoxColumn;
    BudgetTypeDefinition: TTVisual.ITTObjectListBox;
    CardAmount: TTVisual.ITTTextBoxColumn;
    CardAmountOut: TTVisual.ITTTextBoxColumn;
    CensusAmount: TTVisual.ITTTextBoxColumn;
    CensusAmountOut: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    DescriptionTabpage: TTVisual.ITTTabPage;
    Detail: TTVisual.ITTButtonColumn;
    DetailOut: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    DistributionTypeOut: TTVisual.ITTTextBoxColumn;
    ExpirationDate: TTVisual.ITTDateTimePickerColumn;
    InMaterialsGroupBox: TTVisual.ITTGroupBox;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelBudgetTypeDefinition: TTVisual.ITTLabel;
    labelMKYS_EMalzemeGrup: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    LotNo: TTVisual.ITTTextBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    MaterialOut: TTVisual.ITTListBoxColumn;
    MKYS_EMalzemeGrup: TTVisual.ITTEnumComboBox;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    OrderSequenceNumber: TTVisual.ITTTextBoxColumn;
    OrderSequenceNumberOut: TTVisual.ITTTextBoxColumn;
    OutMaterialsGroupBox: TTVisual.ITTGroupBox;
    SignTabpage: TTVisual.ITTTabPage;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionInDetails: TTVisual.ITTGrid;
    StockActionOutDetails: TTVisual.ITTGrid;
    StockActionSignDetails: TTVisual.ITTGrid;
    StockLevelType: TTVisual.ITTListDefComboBoxColumn;
    StockLevelTypeOut: TTVisual.ITTListDefComboBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreStock: TTVisual.ITTTextBoxColumn;
    StoreStockOut: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    Unitprice: TTVisual.ITTTextBoxColumn;
    //public StockActionInDetailsColumns = [];
    //public StockActionOutDetailsColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseCensusFixedFormViewModel: BaseCensusFixedFormViewModel = new BaseCensusFixedFormViewModel();
    public get _CensusFixed(): CensusFixed {
        return this._TTObject as CensusFixed;
    }
    private BaseCensusFixedForm_DocumentUrl: string = '/api/CensusFixedService/BaseCensusFixedForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseCensusFixedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    //#region dx-data-grid çevirme
    public stockActionInDetailSelectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public stockActionOutDetailSelectedMaterial: Material;

    @ViewChild('stockActionInDetailGrid') stockActionInDetailGrid: DxDataGridComponent;
    @ViewChild('stockActionOutDetailGrid') stockActionOutDetailGrid: DxDataGridComponent;
    public async stateChange(event: FormSaveInfo) {
        this.stockActionInDetailGrid.instance.closeEditCell();
        this.stockActionInDetailGrid.instance.saveEditData();
        this.stockActionOutDetailGrid.instance.closeEditCell();
        this.stockActionOutDetailGrid.instance.saveEditData();
        await super.setState(event.transDef, event);
    }

    public async onSaveButtonClick(event: FormSaveInfo)
    {
        this.stockActionInDetailGrid.instance.closeEditCell();
        this.stockActionInDetailGrid.instance.saveEditData();
        this.stockActionOutDetailGrid.instance.closeEditCell();
        this.stockActionOutDetailGrid.instance.saveEditData();
        await super.saveForm(event);
    }

    private SequenceNumberIn: number;
    public onCensusFixedInOrderSequenceNumberChanged(event: any){
        if (event != null){
            this.SequenceNumberIn = event;
         }else{
            TTVisual.InfoBox.Alert("Geçerli bir fiş numarası giriniz.");
        }

        this._CensusFixed.CensusFixedInMaterials.forEach(element => {
            element.OrderSequenceNumber = this.SequenceNumberIn;
        });
    }

    private SequenceNumberOut: number;
    public onCensusFixedOutOrderSequenceNumberChanged(event: any){
        if (event != null){
            this.SequenceNumberOut = event;
         }else{
            TTVisual.InfoBox.Alert("Geçerli bir fiş numarası giriniz.");
        }

        this._CensusFixed.CensusFixedOutMaterials.forEach(element => {
            element.OrderSequenceNumber = this.SequenceNumberOut;
        });
    }
    public async onStockActionInDetailMaterialSelectionChange(event: any) {
        let seqNumber = this.SequenceNumberIn;

        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.stockActionInDetailSelectedMaterial == null)
        ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
    else
        if (!this._CensusFixed.CensusFixedInMaterials.find(x => x.Material.ObjectID == this.stockActionInDetailSelectedMaterial.ObjectID)) {
            let newRow: CensusFixedMaterialIn = new CensusFixedMaterialIn();
            newRow.Material = this.stockActionInDetailSelectedMaterial;
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            newRow.OrderSequenceNumber = seqNumber;
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._CensusFixed.Store.ObjectID, newRow.StockLevelType.ObjectID);
            newRow.StoreStock = stockInheld;
            //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
            this._CensusFixed.CensusFixedInMaterials.push(newRow);
        }
        else
            ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }
    public async onStockActionOutDetailMaterialSelectionChange(event: any) {
        let seqNumber = this.SequenceNumberOut;

        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.stockActionOutDetailSelectedMaterial == null)
        ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
    else
        if (!this._CensusFixed.CensusFixedOutMaterials.find(x => x.Material.ObjectID == this.stockActionOutDetailSelectedMaterial.ObjectID)) {
            let newRow: CensusFixedMaterialOut = new CensusFixedMaterialOut();
            newRow.Material = this.stockActionOutDetailSelectedMaterial;
            newRow.StockLevelType = this.selectedStockLevelType;
            newRow.Status = StockActionDetailStatusEnum.New;
            newRow.OrderSequenceNumber = seqNumber;
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._CensusFixed.Store.ObjectID, newRow.StockLevelType.ObjectID);
            newRow.StoreStock = stockInheld;
            //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
            this._CensusFixed.CensusFixedOutMaterials.push(newRow);
        }
        else
            ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }


  /*  public async btnAddStockActionInDetailClick() {
        if (this.stockActionInDetailSelectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._CensusFixed.CensusFixedInMaterials.find(x => x.Material.ObjectID == this.stockActionInDetailSelectedMaterial.ObjectID)) {
                let newRow: CensusFixedMaterialIn = new CensusFixedMaterialIn();
                newRow.Material = this.stockActionInDetailSelectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._CensusFixed.Store.ObjectID, newRow.StockLevelType.ObjectID);
                newRow.StoreStock = stockInheld;
                //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
                this._CensusFixed.CensusFixedInMaterials.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }
    public async btnAddStockActionOutDetailClick() {
        if (this.stockActionOutDetailSelectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._CensusFixed.CensusFixedOutMaterials.find(x => x.Material.ObjectID == this.stockActionOutDetailSelectedMaterial.ObjectID)) {
                let newRow: CensusFixedMaterialOut = new CensusFixedMaterialOut();
                newRow.Material = this.stockActionOutDetailSelectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(newRow.Material.ObjectID, this._CensusFixed.Store.ObjectID, newRow.StockLevelType.ObjectID);
                newRow.StoreStock = stockInheld;
                //newRow.VatRate = this.selectedMaterial.MaterialVatRates.find(x => x.StartDate <= this._ChattelDocumentWithPurchase.TransactionDate && x.EndDate >= this._ChattelDocumentWithPurchase.TransactionDate).VatRate;
                this._CensusFixed.CensusFixedOutMaterials.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }*/
    public onStockActionInDetailGridRowRemoving(event: any)
    {
        if (event.key.ObjectID != null && this._CensusFixed.CurrentStateDefID == CensusFixed.CensusFixedStates.New) {
            this._CensusFixed.CensusFixedInMaterials.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.stockActionInDetailGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onStockActionOutDetailGridRowRemoving(event: any)
    {
        if (event.key.ObjectID != null && this._CensusFixed.CurrentStateDefID == CensusFixed.CensusFixedStates.New) {
            this._CensusFixed.CensusFixedInMaterials.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.stockActionInDetailGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onStockActionInDetailGridRowRemoved(event: any) {
        //this.CalculateFormTotalPrice();
    }

    public onStockActionOutDetailGridRowRemoved(event: any) {
        //this.CalculateFormTotalPrice();
        if (event.key.ObjectID != null && this._CensusFixed.CurrentStateDefID == CensusFixed.CensusFixedStates.New) {
            this._CensusFixed.CensusFixedOutMaterials.find(x => x.ObjectID == event.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.stockActionOutDetailGrid.instance.filter(['EntityState', '<>', 1]);
            event.cancel = true;
        }
    }

    public onStockActionInDetailGridRowUpdated(event: any) {
        //console.log(event);
        this.StockActionInDetailGridCellChanged(event);
    }

    public onStockActionOutDetailGridRowUpdated(event: any) {
        //console.log(event);
        this.StockActionInDetailGridCellChanged(event);
    }

    public async StockActionInDetailGridCellChanged(event: any) {
        let detail: CensusFixedMaterialIn = <CensusFixedMaterialIn>event.key;
        if (detail.Status === undefined) {
            detail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            detail.StockLevelType = stockLeveltypeArray[0];
        }
        if (this._CensusFixed.CurrentStateDefID.toString() === "1b960acc-0ba5-4b0c-ab2d-8c4ba1f46e6a") {
            if (detail.Material != null && detail.StockLevelType != null) {
                if (detail.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(detail.Material.ObjectID, this._CensusFixed.Store.ObjectID, detail.StockLevelType.ObjectID);
                    detail.StoreStock = stockInheld;
                    detail.CardAmount = stockInheld;
                }
            }
            let amountIn: number = 0;
            if (detail.CardAmount != null && detail.CensusAmount != null) {
                amountIn = detail.CensusAmount - detail.CardAmount;
                detail.Amount = amountIn;
            }
        }
        if (detail.ExpirationDate != null) {
            let currentDate: Date = new Date();
            let endOfMonth: Date = new Date(detail.ExpirationDate.getFullYear(), detail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            if (currentDate <= detail.ExpirationDate) {
                detail.ExpirationDate = endOfMonth;
            } else {
                TTVisual.InfoBox.Alert(i18n("M22059", "Son kullanma tarihi bugunden küçük olamaz."));
                detail.ExpirationDate = null;
            }
        }
    }

    public async StockActionOutDetailGridCellChanged(event: any) {
        let detail: CensusFixedMaterialOut = <CensusFixedMaterialOut>event.key;
        if (this._CensusFixed.CurrentStateDefID.toString() === "1b960acc-0ba5-4b0c-ab2d-8c4ba1f46e6a") {
            if (detail.Status === undefined) {
                detail.Status = StockActionDetailStatusEnum.New;
                let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
                detail.StockLevelType = stockLeveltypeArray[0];
            }
            if (detail.Material != null && detail.StockLevelType != null) {
                if (detail.Material.ObjectID != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(detail.Material.ObjectID, this._CensusFixed.Store.ObjectID, detail.StockLevelType.ObjectID);
                    detail.StoreStock = stockInheld;
                    detail.CardAmount = stockInheld;
                }
            }
            let amountOut: number = 0;
            if (detail.CardAmount != null && detail.CensusAmount != null) {
                amountOut = detail.CardAmount - detail.CensusAmount;
                detail.Amount = amountOut;
            }
        }
    }

    public StockActionInDetailsGridColumns = [
        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M12625", "Depo Mevcudu"),
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false,
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            //width: 'auto'
        },
        {
            caption: i18n("M21427", "Sayım Fişi Nu."),
            dataField: 'OrderSequenceNumber',
            allowEditing: false,
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            //width: 'auto'
        },
        {
            caption: i18n("M21404", "Sayılan Miktar"),
            dataField: 'CensusAmount',
            dataType: 'number',
            //width: 'auto'
        },
        {
            caption: i18n("M22335", "Stok Kart Kayıt Nevi"),
            dataField: 'CardAmount',
            dataType: 'number',
            visible: false,
            editorOptions: {
                format: function (value) {
                    return Math.Round(value, 2) + '';
                }
                //format: "#,##0.## TL",
            },
            //width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            allowEditing: false,
            editorOptions: {
                format: function (value) {
                    return Math.Round(value, 2) + '';
                }
                //format: "#,##0.## TL",
            },
            //width: 'auto'
        },
        {
            caption: i18n("M11855", "Birim Fiyat"),
            dataField: 'UnitPrice',
            dataType: 'number',
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            //width: 'auto'
        },
        {
            caption: i18n("M18356", "Lot Nu."),
            dataField: 'LotNo',
            width: 100
        },
        {
            caption: 'Son Kul. Tarihi',
            dataField: 'ExpirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 150
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //width: 'auto'
        }
    ];

    public StockActionOutDetailsGridColumns = [
        {
            caption: 'Malzeme Adı',
            dataField: 'Material.Name',
            allowEditing: false,
            width: 300
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            width: 120
        },
        {
            caption: 'Ölçü Birimi',
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            //width: 'auto'
        },
        {
            caption: i18n("M12625", "Depo Mevcudu"),
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false,
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            //width: 'auto'
        },
        {
            caption: i18n("M21427", "Sayım Fişi Nu."),
            dataField: 'OrderSequenceNumber',
            allowEditing: false,
            // editorOptions: {
            //     format: function (value) {
            //         return Math.Round(value, 6) + ' TL';
            //     }
            //     //format: "#,##0.## TL",
            // },
            //width: 'auto'
        },
        {
            caption: i18n("M21404", "Sayılan Miktar"),
            dataField: 'CensusAmount',
            dataType: 'number',
            //width: 'auto'
        },
        {
            caption: i18n("M22335", "Stok Kart Kayıt Nevi"),
            dataField: 'CardAmount',
            dataType: 'number',
            visible: false,
            editorOptions: {
                format: function (value) {
                    return Math.Round(value, 2) + '';
                }
                //format: "#,##0.## TL",
            },
            //width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            allowEditing: false,
            editorOptions: {
                format: function (value) {
                    return Math.Round(value, 2) + '';
                }
                //format: "#,##0.## TL",
            },
            //width: 'auto'
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //width: 'auto'
        }
    ];
    //#endregion

    // ***** Method declarations start *****

    private async StockActionInDetails_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.StockActionInDetails.CurrentCell.OwningColumn.Name === "Detail")
            this.ShowStockActionDetailForm(<StockActionDetail>this.StockActionInDetails.CurrentCell.OwningRow.TTObject);
    }
    private async StockActionInDetails_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        this.CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.StockActionInDetails);
    }
    public async StockActionInDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let detail: CensusFixedMaterialIn = <CensusFixedMaterialIn>data.Row.TTObject;
        if (detail.Status === undefined) {
            detail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            detail.StockLevelType = stockLeveltypeArray[0];
        }
        if (this._CensusFixed.CurrentStateDefID.toString() === "1b960acc-0ba5-4b0c-ab2d-8c4ba1f46e6a") {
            if (data.Column.Name === "Material" || data.Column.Name === "StockLevelType" || data.Column.Name === "CensusAmount") {
                if (detail.Material != null && detail.StockLevelType != null) {
                    if (detail.Material.ObjectID != null) {
                        let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(detail.Material.ObjectID, this._CensusFixed.Store.ObjectID, detail.StockLevelType.ObjectID);
                        detail.StoreStock = stockInheld;
                        detail.CardAmount = stockInheld;
                    }
                }
                let amountIn: number = 0;
                if (detail.CardAmount != null && detail.CensusAmount != null) {
                    amountIn = detail.CensusAmount - detail.CardAmount;
                    (<CensusFixedMaterialIn>data.Row.TTObject).Amount = amountIn;
                }
            }
        }

        if (data.Column.Name === "ExpirationDate") {
            let currentDate: Date = new Date();
            let endOfMonth: Date = new Date(detail.ExpirationDate.getFullYear(), detail.ExpirationDate.getMonth() + 1, 1).AddDays(-1);
            if (currentDate <= detail.ExpirationDate) {
                detail.ExpirationDate = endOfMonth;
            } else {
                TTVisual.InfoBox.Alert(i18n("M22059", "Son kullanma tarihi bugunden küçük olamaz."));
                detail.ExpirationDate = null;
            }
        }
    }
    private async StockActionOutDetails_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.StockActionOutDetails.CurrentCell.OwningColumn.Name === "DetailOut")
            this.ShowStockActionDetailForm(<StockActionDetail>this.StockActionOutDetails.CurrentCell.OwningRow.TTObject);
    }
    private async StockActionOutDetails_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
        this.CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, this.StockActionOutDetails);
    }
    public async StockActionOutDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        if (this._CensusFixed.CurrentStateDefID.toString() === "1b960acc-0ba5-4b0c-ab2d-8c4ba1f46e6a") {
            let detail: CensusFixedMaterialOut = <CensusFixedMaterialOut>data.Row.TTObject;
            if (detail.Status === undefined) {
                detail.Status = StockActionDetailStatusEnum.New;
                let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
                detail.StockLevelType = stockLeveltypeArray[0];
            }
            if (data.Column.Name === "MaterialOut" || data.Column.Name === "StockLevelTypeOut" || data.Column.Name === "CensusAmountOut") {
                if (detail.Material != null && detail.StockLevelType != null) {
                    if (detail.Material.ObjectID != null) {
                        let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(detail.Material.ObjectID, this._CensusFixed.Store.ObjectID, detail.StockLevelType.ObjectID);
                        detail.StoreStock = stockInheld;
                        detail.CardAmount = stockInheld;
                    }
                }
                let amountOut: number = 0;
                if (detail.CardAmount != null && detail.CensusAmount != null) {
                    amountOut = detail.CardAmount - detail.CensusAmount;
                    (<CensusFixedMaterialOut>data.Row.TTObject).Amount = amountOut;
                }
            }
        }
    }
    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(" WHERE ISACTIVE = 1 "));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._CensusFixed.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser(" WHERE ISACTIVE = 1 "));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this.ParentForm, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key))
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._CensusFixed.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        for (let censusFixedMaterialIn of this._CensusFixed.CensusFixedInMaterials) {
            if (censusFixedMaterialIn.NotDiscountedUnitPrice == null || censusFixedMaterialIn.NotDiscountedUnitPrice == undefined) {
                censusFixedMaterialIn.NotDiscountedUnitPrice = censusFixedMaterialIn.UnitPrice;
            }
        }
    }
    protected async PreScript() {
        super.PreScript();
        if (this._CensusFixed.MasterAction !== null) {
            this.StockActionInDetails.ReadOnly = true;
            this.StockActionOutDetails.ReadOnly = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new CensusFixed();
        this.baseCensusFixedFormViewModel = new BaseCensusFixedFormViewModel();
        this._ViewModel = this.baseCensusFixedFormViewModel;
        this.baseCensusFixedFormViewModel._CensusFixed = this._TTObject as CensusFixed;
        this.baseCensusFixedFormViewModel._CensusFixed.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.baseCensusFixedFormViewModel._CensusFixed.Store = new Store();
        this.baseCensusFixedFormViewModel._CensusFixed.CensusFixedInMaterials = new Array<CensusFixedMaterialIn>();
        this.baseCensusFixedFormViewModel._CensusFixed.StockActionSignDetails = new Array<StockActionSignDetail>();
        this.baseCensusFixedFormViewModel._CensusFixed.CensusFixedOutMaterials = new Array<CensusFixedMaterialOut>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseCensusFixedFormViewModel = this._ViewModel as BaseCensusFixedFormViewModel;
        that._TTObject = this.baseCensusFixedFormViewModel._CensusFixed;
        if (this.baseCensusFixedFormViewModel == null)
            this.baseCensusFixedFormViewModel = new BaseCensusFixedFormViewModel();
        if (this.baseCensusFixedFormViewModel._CensusFixed == null)
            this.baseCensusFixedFormViewModel._CensusFixed = new CensusFixed();
        let budgetTypeDefinitionObjectID = that.baseCensusFixedFormViewModel._CensusFixed["BudgetTypeDefinition"];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.baseCensusFixedFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.baseCensusFixedFormViewModel._CensusFixed.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.baseCensusFixedFormViewModel._CensusFixed["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseCensusFixedFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseCensusFixedFormViewModel._CensusFixed.Store = store;
            }
        }
        that.baseCensusFixedFormViewModel._CensusFixed.CensusFixedInMaterials = that.baseCensusFixedFormViewModel.StockActionInDetailsGridList;
        for (let detailItem of that.baseCensusFixedFormViewModel.StockActionInDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseCensusFixedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseCensusFixedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseCensusFixedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseCensusFixedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseCensusFixedFormViewModel._CensusFixed.StockActionSignDetails = that.baseCensusFixedFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseCensusFixedFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem["SignUser"];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseCensusFixedFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
        that.baseCensusFixedFormViewModel._CensusFixed.CensusFixedOutMaterials = that.baseCensusFixedFormViewModel.StockActionOutDetailsGridList;
        for (let detailItem of that.baseCensusFixedFormViewModel.StockActionOutDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseCensusFixedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseCensusFixedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseCensusFixedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseCensusFixedFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseCensusFixedFormViewModel);
  
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
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.labelBudgetTypeDefinition = new TTVisual.TTLabel();
        this.labelBudgetTypeDefinition.Text = i18n("M12146", "Bütçe Türü");
        this.labelBudgetTypeDefinition.Name = "labelBudgetTypeDefinition";
        this.labelBudgetTypeDefinition.TabIndex = 141;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.Required = true;
        this.BudgetTypeDefinition.ListDefName = 'BugdetTypeList';
        this.BudgetTypeDefinition.BackColor = '#FFE3C6';
        this.BudgetTypeDefinition.Name = "BudgetTypeDefinition";
        this.BudgetTypeDefinition.TabIndex = 140;
        this.BudgetTypeDefinition.AutoCompleteDialogHeight = "10%";
        this.BudgetTypeDefinition.AutoCompleteDialogWidth = "20%";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.labelMKYS_EMalzemeGrup = new TTVisual.TTLabel();
        this.labelMKYS_EMalzemeGrup.Text = i18n("M18581", "Malzeme Grup");
        this.labelMKYS_EMalzemeGrup.Name = "labelMKYS_EMalzemeGrup";
        this.labelMKYS_EMalzemeGrup.TabIndex = 114;

        this.MKYS_EMalzemeGrup = new TTVisual.TTEnumComboBox();
        this.MKYS_EMalzemeGrup.DataTypeName = "MKYS_EMalzemeGrupEnum";
        this.MKYS_EMalzemeGrup.BackColor = "#F0F0F0";
        this.MKYS_EMalzemeGrup.Enabled = false;
        this.MKYS_EMalzemeGrup.Name = "MKYS_EMalzemeGrup";
        this.MKYS_EMalzemeGrup.TabIndex = 113;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M16901", "İşlem Yapılan Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 112;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 111;

        this.InMaterialsGroupBox = new TTVisual.TTGroupBox();
        this.InMaterialsGroupBox.Text = i18n("M11114", "Arttırılanlar");
        this.InMaterialsGroupBox.Name = "InMaterialsGroupBox";
        this.InMaterialsGroupBox.TabIndex = 110;

        this.StockActionInDetails = new TTVisual.TTGrid();
        this.StockActionInDetails.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockActionInDetails.Name = "StockActionInDetails";
        this.StockActionInDetails.TabIndex = 0;
        this.StockActionInDetails.Height = 350;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = "";
        this.Detail.Name = "Detail";
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.AllowMultiSelect = true;
        this.Material.ListDefName = "MaterialListDefinition";
        this.Material.DataMember = "Material";
        this.Material.AutoCompleteDialogHeight = "60%";
        this.Material.AutoCompleteDialogWidth = "50%";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M22362", "Stok Nu., Cins ve Özellikleri");
        this.Material.Name = "Material";
        this.Material.Width = 400;

        this.BarcodeA = new TTVisual.TTTextBoxColumn();
        this.BarcodeA.DataMember = "Material.Barcode";
        this.BarcodeA.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.BarcodeA.DisplayIndex = 2;
        this.BarcodeA.HeaderText = "Barkod";
        this.BarcodeA.Name = "BarcodeA";
        this.BarcodeA.ReadOnly = true;
        this.BarcodeA.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.StoreStock = new TTVisual.TTTextBoxColumn();
        this.StoreStock.DataMember = "StoreStock";
        this.StoreStock.Format = "N2";
        this.StoreStock.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStock.DisplayIndex = 4;
        this.StoreStock.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStock.Name = "StoreStock";
        this.StoreStock.ReadOnly = true;
        this.StoreStock.Width = 120;

        this.OrderSequenceNumber = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumber.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumber.DisplayIndex = 5;
        this.OrderSequenceNumber.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumber.Name = "OrderSequenceNumber";
        this.OrderSequenceNumber.Width = 120;

        this.CardAmount = new TTVisual.TTTextBoxColumn();
        this.CardAmount.DataMember = "CardAmount";
        this.CardAmount.Format = "N2";
        this.CardAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmount.DisplayIndex = 6;
        this.CardAmount.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmount.Name = "CardAmount";
        this.CardAmount.Width = 125;

        this.CensusAmount = new TTVisual.TTTextBoxColumn();
        this.CensusAmount.DataMember = "CensusAmount";
        this.CensusAmount.Format = "N2";
        this.CensusAmount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmount.DisplayIndex = 7;
        this.CensusAmount.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmount.Name = "CensusAmount";
        this.CensusAmount.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.Format = "N2";
        this.Amount.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Amount.DisplayIndex = 8;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.ReadOnly = true;
        this.Amount.Width = 75;

        this.Unitprice = new TTVisual.TTTextBoxColumn();
        this.Unitprice.DataMember = "UnitPrice";
        this.Unitprice.Format = "N2";
        this.Unitprice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Unitprice.DisplayIndex = 9;
        this.Unitprice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.Unitprice.Name = "Unitprice";
        this.Unitprice.Width = 100;

        this.LotNo = new TTVisual.TTTextBoxColumn();
        this.LotNo.DataMember = "LotNo";
        this.LotNo.Format = "N2";
        this.LotNo.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.LotNo.DisplayIndex = 10;
        this.LotNo.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNo.Name = "LotNo";
        this.LotNo.Width = 150;

        this.ExpirationDate = new TTVisual.TTDateTimePickerColumn();
        this.ExpirationDate.DataMember = "ExpirationDate";
        this.ExpirationDate.DisplayIndex = 11;
        this.ExpirationDate.HeaderText = "S.K.Tarihi";
        this.ExpirationDate.Name = "ExpirationDate";
        this.ExpirationDate.Width = 125;

        this.StockLevelType = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelType.ListDefName = "StockLevelTypeList";
        this.StockLevelType.DataMember = "StockLevelType";
        this.StockLevelType.DisplayIndex = 12;
        this.StockLevelType.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelType.Name = "StockLevelType";
        this.StockLevelType.Width = 100;

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
        this.BarcodeE.Width = 100;

        this.DistributionTypeOut = new TTVisual.TTTextBoxColumn();
        this.DistributionTypeOut.DataMember = "Material.DistributionTypeName";
        this.DistributionTypeOut.DisplayIndex = 3;
        this.DistributionTypeOut.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionTypeOut.Name = "DistributionTypeOut";
        this.DistributionTypeOut.ReadOnly = true;
        this.DistributionTypeOut.Width = 100;

        this.StoreStockOut = new TTVisual.TTTextBoxColumn();
        this.StoreStockOut.DataMember = "StoreStock";
        this.StoreStockOut.Format = "N2";
        this.StoreStockOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreStockOut.DisplayIndex = 4;
        this.StoreStockOut.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreStockOut.Name = "StoreStockOut";
        this.StoreStockOut.ReadOnly = true;
        this.StoreStockOut.Width = 100;

        this.OrderSequenceNumberOut = new TTVisual.TTTextBoxColumn();
        this.OrderSequenceNumberOut.DataMember = "OrderSequenceNumber";
        this.OrderSequenceNumberOut.DisplayIndex = 5;
        this.OrderSequenceNumberOut.HeaderText = i18n("M21427", "Sayım Fişi Nu.");
        this.OrderSequenceNumberOut.Name = "OrderSequenceNumberOut";
        this.OrderSequenceNumberOut.Width = 100;

        this.CardAmountOut = new TTVisual.TTTextBoxColumn();
        this.CardAmountOut.DataMember = "CardAmount";
        this.CardAmountOut.Format = "N2";
        this.CardAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CardAmountOut.DisplayIndex = 6;
        this.CardAmountOut.HeaderText = i18n("M22335", "Stok Kart Kayıt Nevi");
        this.CardAmountOut.Name = "CardAmountOut";
        this.CardAmountOut.Width = 125;

        this.CensusAmountOut = new TTVisual.TTTextBoxColumn();
        this.CensusAmountOut.DataMember = "CensusAmount";
        this.CensusAmountOut.Format = "N2";
        this.CensusAmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.CensusAmountOut.DisplayIndex = 7;
        this.CensusAmountOut.HeaderText = i18n("M21404", "Sayılan Miktar");
        this.CensusAmountOut.Name = "CensusAmountOut";
        this.CensusAmountOut.Width = 100;

        this.AmountOut = new TTVisual.TTTextBoxColumn();
        this.AmountOut.DataMember = "Amount";
        this.AmountOut.Format = "N2";
        this.AmountOut.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountOut.DisplayIndex = 8;
        this.AmountOut.HeaderText = i18n("M19030", "Miktar");
        this.AmountOut.Name = "AmountOut";
        this.AmountOut.ReadOnly = true;
        this.AmountOut.Width = 75;

        this.AproximateUnitPriceOut = new TTVisual.TTTextBoxColumn();
        this.AproximateUnitPriceOut.DataMember = "AproximateUnitPrice";
        this.AproximateUnitPriceOut.DisplayIndex = 9;
        this.AproximateUnitPriceOut.HeaderText = i18n("M11036", "Anlık Birim Fiyat");
        this.AproximateUnitPriceOut.Name = "AproximateUnitPriceOut";
        this.AproximateUnitPriceOut.ReadOnly = true;
        this.AproximateUnitPriceOut.Width = 100;

        this.StockLevelTypeOut = new TTVisual.TTListDefComboBoxColumn();
        this.StockLevelTypeOut.ListDefName = "StockLevelTypeList";
        this.StockLevelTypeOut.DataMember = "StockLevelType";
        this.StockLevelTypeOut.DisplayIndex = 10;
        this.StockLevelTypeOut.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeOut.Name = "StockLevelTypeOut";
        this.StockLevelTypeOut.Width = 100;

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

        //this.StockActionInDetailsColumns = [this.Detail, this.Material, this.BarcodeA, this.DistributionType, this.StoreStock, this.OrderSequenceNumber, this.CardAmount, this.CensusAmount, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        //this.StockActionOutDetailsColumns = [this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut];
        this.InMaterialsGroupBox.Controls = [this.StockActionInDetails];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.OutMaterialsGroupBox.Controls = [this.StockActionOutDetails];
        this.Controls = [this.labelBudgetTypeDefinition, this.BudgetTypeDefinition, this.Description, this.labelMKYS_EMalzemeGrup, this.MKYS_EMalzemeGrup, this.labelStore, this.Store, this.InMaterialsGroupBox, this.StockActionInDetails, this.Detail, this.Material, this.BarcodeA, this.DistributionType, this.StoreStock, this.OrderSequenceNumber, this.CardAmount, this.CensusAmount, this.Amount, this.Unitprice, this.LotNo, this.ExpirationDate, this.StockLevelType, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.StockActionID, this.MKYS_TeslimAlan, this.MKYS_TeslimEden, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate, this.OutMaterialsGroupBox, this.StockActionOutDetails, this.DetailOut, this.MaterialOut, this.BarcodeE, this.DistributionTypeOut, this.StoreStockOut, this.OrderSequenceNumberOut, this.CardAmountOut, this.CensusAmountOut, this.AmountOut, this.AproximateUnitPriceOut, this.StockLevelTypeOut, this.ttlabel1, this.labelMKYS_TeslimEden, this.labelMKYS_TeslimAlan, this.TTTeslimAlanButon, this.TTTeslimEdenButon];

    }


}
