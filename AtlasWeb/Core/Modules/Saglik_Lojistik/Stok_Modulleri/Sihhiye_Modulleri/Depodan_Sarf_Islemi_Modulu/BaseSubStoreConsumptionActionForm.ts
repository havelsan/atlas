//$DFBC6888
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { BaseSubStoreConsumptionActionFormViewModel } from './BaseSubStoreConsumptionActionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreConsumptionAction } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreConsumptionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from 'ObjectClassService/StockLevelService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { MaterialService } from "ObjectClassService/MaterialService";
import { DxDataGridComponent } from 'devextreme-angular';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";



@Component({
    selector: 'BaseSubStoreConsumptionActionForm',
    templateUrl: './BaseSubStoreConsumptionActionForm.html',
    providers: [MessageService]
})
export class BaseSubStoreConsumptionActionForm extends StockActionBaseForm implements OnInit {
    ActionDate: TTVisual.ITTDateTimePicker;
    AmountSubStoreConsumptionDetail: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    Detail: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    Existing: TTVisual.ITTTextBoxColumn;
    labelActionDate: TTVisual.ITTLabel;
    labelDescription: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    Material: TTVisual.ITTListBoxColumn;
    MaterialOutTabPage: TTVisual.ITTTabPage;
    StockActionID: TTVisual.ITTTextBox;
    StockLevelTypeSubStoreConsumptionDetail: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    SubStoreConsumptionActionDetails: TTVisual.ITTGrid;
    TransactionDate: TTVisual.ITTDateTimePicker;
    tttabcontrol1: TTVisual.ITTTabControl;



    //#region dx-data-grid çevirme
    public selectedMaterial: Material;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public SubStoreConsumptionActionDetailsColumns = [

        {
            caption: i18n("M18550", "Malzeme Adı"),
            dataField: 'Material.Name',
            allowEditing: false,
            // width: 'auto'
        },
        {
            caption: 'Barkod',
            dataField: 'Material.Barcode',
            allowEditing: false,
            // width: 'auto'
        },
        {
            caption: i18n("M19908", "Ölçü Birimi"),
            dataField: 'Material.DistributionTypeName',
            allowEditing: false,
            // width: 'auto'
        },
        {
            caption: i18n("M18519", "Malın Durumu"),
            dataField: 'StockLevelType.Description',
            allowEditing: false,
            //  width: 'auto'
        },
        {
            caption: i18n("M18957", "Mevcut"),
            dataField: 'StoreStock',
            allowEditing: false,
            // width: 'auto'
        },
        {
            caption: i18n("M19030", "Miktar"),
            dataField: 'Amount',
            dataType: 'number',
            // format: "#",
            // editorOptions: {
            //     onKeyPress: function (e) {
            //         var event = e.event,
            //             str = String.fromCharCode(event.keyCode);
            //         if (!/[0-9]/.test(str))
            //             event.preventDefault();
            //     }
            // },
            //  width: 'auto'
        },
        {
            caption: "Durumu",
            dataField: 'Status',
            allowEditing: false,
            //   width: 'auto',
            lookup: { dataSource: StockActionDetailStatusEnum.Items, valueExpr: "ordinal", displayExpr: "description" },
            visible: this.getIsReadOnly()
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            //   width: 'auto',
            cellTemplate: 'deleteCellTemplate',
            visible: !this.getIsReadOnly()
        },
        {
            caption: "İptal",
            name: 'RowCancel',
            //   width: 'auto',
            cellTemplate: 'cancelCellTemplate',
            visible: this.getIsReadOnly()
        }
    ];

    public getIsReadOnly() {
        return false;
    }

    @ViewChild('subStoreConsumption') gridGrantMaterial: DxDataGridComponent;
    async subStoreConsumption_CellContentClicked(data: any) {
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




    public onMaterialGridRowUpdated(event: any) {
        //console.log(event);
        let data = <SubStoreConsumptionDetail>event.key;
        //let detail: ChattelDocumentInputDetailWithAccountancy = <ChattelDocumentInputDetailWithAccountancy>data.Row.TTObject;
        if (data.Amount <= 0) {
            ServiceLocator.MessageService.showError('Miktar Birim Fiyat sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }
        if (data.VatRate < 0) {
            ServiceLocator.MessageService.showError('KDV Oranı sıfırdan küçük olamaz!');
            event.cancel = true;
            return;
        }

    }

    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
    }

    onStockLevelTypeChange(event: any) {

    }
    public async btnAddClick() {
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.IsNew == true)) {
                let newRow: SubStoreConsumptionDetail = new SubStoreConsumptionDetail();
                newRow.Material = this.selectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                newRow.IsNew = true;
                if (this._SubStoreConsumptionAction.TransactionDate != null)
                    newRow.VatRate = await MaterialService.GetVatrateFromMaterialTS(this.selectedMaterial, this._SubStoreConsumptionAction.TransactionDate);

                if (this.selectedStockLevelType != null) {
                    let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(this.selectedMaterial.ObjectID, this._SubStoreConsumptionAction.Store.ObjectID, this.selectedStockLevelType.ObjectID);
                    newRow.StoreStock = stockInheld;
                }

                this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public baseSubStoreConsumptionActionFormViewModel: BaseSubStoreConsumptionActionFormViewModel = new BaseSubStoreConsumptionActionFormViewModel();
    public get _SubStoreConsumptionAction(): SubStoreConsumptionAction {
        return this._TTObject as SubStoreConsumptionAction;
    }
    private BaseSubStoreConsumptionActionForm_DocumentUrl: string = '/api/SubStoreConsumptionActionService/BaseSubStoreConsumptionActionForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseSubStoreConsumptionActionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async SubStoreConsumptionActionDetails_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.SubStoreConsumptionActionDetails.CurrentCell.OwningColumn.Name === 'Detail') {
            this.ShowStockActionDetailForm(<StockActionDetail>this.SubStoreConsumptionActionDetails.CurrentCell.OwningRow.TTObject);
        }
    }
    protected async PreScript() {
        super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreConsumptionAction();
        this.baseSubStoreConsumptionActionFormViewModel = new BaseSubStoreConsumptionActionFormViewModel();
        this._ViewModel = this.baseSubStoreConsumptionActionFormViewModel;
        this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction = this._TTObject as SubStoreConsumptionAction;
        this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails = new Array<SubStoreConsumptionDetail>();
        this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.baseSubStoreConsumptionActionFormViewModel = this._ViewModel as BaseSubStoreConsumptionActionFormViewModel;
        that._TTObject = this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction;
        if (this.baseSubStoreConsumptionActionFormViewModel == null) {
            this.baseSubStoreConsumptionActionFormViewModel = new BaseSubStoreConsumptionActionFormViewModel();
        }
        if (this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction == null) {
            this.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction = new SubStoreConsumptionAction();
        }
        that.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails =
            that.baseSubStoreConsumptionActionFormViewModel.SubStoreConsumptionActionDetailsGridList;
        for (let detailItem of that.baseSubStoreConsumptionActionFormViewModel.SubStoreConsumptionActionDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseSubStoreConsumptionActionFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseSubStoreConsumptionActionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.baseSubStoreConsumptionActionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseSubStoreConsumptionActionFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let storeObjectID = that.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseSubStoreConsumptionActionFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseSubStoreConsumptionActionFormViewModel._SubStoreConsumptionAction.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseSubStoreConsumptionActionFormViewModel);

    }


    public onActionDateChanged(event): void {
        if (event != null) {
            if (this._SubStoreConsumptionAction != null && this._SubStoreConsumptionAction.ActionDate !== event) {
                this._SubStoreConsumptionAction.ActionDate = event;
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._SubStoreConsumptionAction != null && this._SubStoreConsumptionAction.Description !== event) {
                this._SubStoreConsumptionAction.Description = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._SubStoreConsumptionAction != null && this._SubStoreConsumptionAction.StockActionID !== event) {
                this._SubStoreConsumptionAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._SubStoreConsumptionAction != null && this._SubStoreConsumptionAction.Store !== event) {
                this._SubStoreConsumptionAction.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._SubStoreConsumptionAction != null && this._SubStoreConsumptionAction.TransactionDate !== event) {
                this._SubStoreConsumptionAction.TransactionDate = event;
            }
        }
    }


    public async SubStoreConsumptionActionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let subStoreConsumptionDetail: SubStoreConsumptionDetail = <SubStoreConsumptionDetail>(data.Row.TTObject);
        if (subStoreConsumptionDetail.Status === undefined) {
            subStoreConsumptionDetail.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            subStoreConsumptionDetail.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.Column.Name === 'Material' || data.Column.Name === 'StockLevelTypeSubStoreConsumptionDetail') {

            if (subStoreConsumptionDetail.Material != null && subStoreConsumptionDetail.StockLevelType != null) {
                if (subStoreConsumptionDetail.Material.ObjectID != null) {
                    let stockInheld: number =
                        await StockLevelService.StockInheldWithStockLevel(subStoreConsumptionDetail.Material.ObjectID, this._SubStoreConsumptionAction.Store.ObjectID,
                            subStoreConsumptionDetail.StockLevelType.ObjectID);
                    subStoreConsumptionDetail.StoreStock = stockInheld;
                }
            }
        }
        if (data.Column.Name === 'AmountSubStoreConsumptionDetail') {
            let detail: SubStoreConsumptionDetail = <SubStoreConsumptionDetail>data.Row.TTObject;
            if (detail.Amount > subStoreConsumptionDetail.StoreStock) {
                detail.Amount = subStoreConsumptionDetail.StoreStock;
            }
        }
    }


    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M21329", "Sarf Tarihi");
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 12;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.Format = DateTimePickerFormat.Long;
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 11;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = 'tttabcontrol1';
        this.tttabcontrol1.TabIndex = 10;

        this.MaterialOutTabPage = new TTVisual.TTTabPage();
        this.MaterialOutTabPage.DisplayIndex = 0;
        this.MaterialOutTabPage.TabIndex = 0;
        this.MaterialOutTabPage.Text = i18n("M21317", "Sarf Edilen Malzemeler");
        this.MaterialOutTabPage.Name = 'MaterialOutTabPage';

        this.SubStoreConsumptionActionDetails = new TTVisual.TTGrid();
        this.SubStoreConsumptionActionDetails.Name = 'SubStoreConsumptionActionDetails';
        this.SubStoreConsumptionActionDetails.TabIndex = 7;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = 'MaterialListDefinition';
        this.Material.DataMember = 'Material';
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '50%';
        this.Material.DisplayIndex = 2;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = 'Material';
        this.Material.Width = 600;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 140;

        this.AmountSubStoreConsumptionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreConsumptionDetail.DataMember = 'Amount';
        this.AmountSubStoreConsumptionDetail.DisplayIndex = 4;
        this.AmountSubStoreConsumptionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreConsumptionDetail.Name = 'AmountSubStoreConsumptionDetail';
        this.AmountSubStoreConsumptionDetail.Width = 80;

        this.Existing = new TTVisual.TTTextBoxColumn();
        this.Existing.DataMember = 'StoreStock';
        this.Existing.Format = 'N2';
        this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Existing.DisplayIndex = 5;
        this.Existing.HeaderText = i18n("M18957", "Mevcut");
        this.Existing.Name = 'Existing';
        this.Existing.ReadOnly = true;
        this.Existing.Width = 100;

        this.StockLevelTypeSubStoreConsumptionDetail = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeSubStoreConsumptionDetail.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeSubStoreConsumptionDetail.DataMember = 'StockLevelType';
        this.StockLevelTypeSubStoreConsumptionDetail.DisplayIndex = 6;
        this.StockLevelTypeSubStoreConsumptionDetail.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeSubStoreConsumptionDetail.Name = 'StockLevelTypeSubStoreConsumptionDetail';
        this.StockLevelTypeSubStoreConsumptionDetail.Width = 100;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 2;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = 'Description';
        this.Description.TabIndex = 0;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M21310", "Sarf Eden Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 9;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'StoreListDefinition';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = 'labelActionDate';
        this.labelActionDate.TabIndex = 5;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        this.ActionDate.BackColor = '#F0F0F0';
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Enabled = false;
        this.ActionDate.Name = 'ActionDate';
        this.ActionDate.TabIndex = 4;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 3;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = 'labelDescription';
        this.labelDescription.TabIndex = 1;

        this.tttabcontrol1.Controls = [this.MaterialOutTabPage];
        this.MaterialOutTabPage.Controls = [this.SubStoreConsumptionActionDetails];
        this.Controls = [this.labelTransactionDate, this.TransactionDate, this.tttabcontrol1, this.MaterialOutTabPage, this.SubStoreConsumptionActionDetails,
        this.Detail, this.Barcode, this.Material, this.DistributionType, this.AmountSubStoreConsumptionDetail, this.Existing, this.StockLevelTypeSubStoreConsumptionDetail,
        this.StockActionID, this.Description, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelDescription];

    }


}
