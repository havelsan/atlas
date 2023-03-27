//$64E4DC0C
import { Component, OnInit, NgZone } from '@angular/core';
import { SubStoreConsumptionApprovalFormViewModel } from './SubStoreConsumptionApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseSubStoreConsumptionActionForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Depodan_Sarf_Islemi_Modulu/BaseSubStoreConsumptionActionForm';
import { SubStoreConsumptionAction } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreConsumptionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';


@Component({
    selector: 'SubStoreConsumptionApprovalForm',
    templateUrl: './SubStoreConsumptionApprovalForm.html',
    providers: [MessageService]
})
export class SubStoreConsumptionApprovalForm extends BaseSubStoreConsumptionActionForm implements OnInit {
    public SubStoreConsumptionActionDetailsColumns = [];
    public subStoreConsumptionApprovalFormViewModel: SubStoreConsumptionApprovalFormViewModel = new SubStoreConsumptionApprovalFormViewModel();
    public get _SubStoreConsumptionAction(): SubStoreConsumptionAction {
        return this._TTObject as SubStoreConsumptionAction;
    }
    private SubStoreConsumptionApprovalForm_DocumentUrl: string = '/api/SubStoreConsumptionActionService/SubStoreConsumptionApprovalForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SubStoreConsumptionApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreConsumptionAction();
        this.subStoreConsumptionApprovalFormViewModel = new SubStoreConsumptionApprovalFormViewModel();
        this._ViewModel = this.subStoreConsumptionApprovalFormViewModel;
        this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction = this._TTObject as SubStoreConsumptionAction;
        this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails = new Array<SubStoreConsumptionDetail>();
        this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.subStoreConsumptionApprovalFormViewModel = this._ViewModel as SubStoreConsumptionApprovalFormViewModel;
        that._TTObject = this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction;
        if (this.subStoreConsumptionApprovalFormViewModel == null) {
            this.subStoreConsumptionApprovalFormViewModel = new SubStoreConsumptionApprovalFormViewModel();
        }
        if (this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction == null) {
            this.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction = new SubStoreConsumptionAction();
        }
        that.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails =
            that.subStoreConsumptionApprovalFormViewModel.SubStoreConsumptionActionDetailsGridList;
        for (let detailItem of that.subStoreConsumptionApprovalFormViewModel.SubStoreConsumptionActionDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.subStoreConsumptionApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                 if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.subStoreConsumptionApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                         if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.subStoreConsumptionApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.subStoreConsumptionApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                 if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let storeObjectID = that.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.subStoreConsumptionApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
             if (store) {
                that.subStoreConsumptionApprovalFormViewModel._SubStoreConsumptionAction.Store = store;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(SubStoreConsumptionApprovalFormViewModel);
        this.FormCaption = i18n("M11240", "Atık Depoya Çıkış ( Onay )");

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
    SubStoreConsumptionActionDetails_CellValueChangedEmitted(data: any) {
        if (data && this.SubStoreConsumptionActionDetails_CellValueChangedEmitted && data.Row && data.Column) {
            //this.SubStoreConsumptionActionDetails.CurrentCell =
            //    {
            //        OwningRow: data.Row,
            //        OwningColumn: data.Column
            //    };
            this.SubStoreConsumptionActionDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {
    }

    public async SubStoreConsumptionActionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.SubStoreConsumptionActionDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: SubStoreConsumptionDetail) {
    }

    onCellContentClicked(data: any) {

    }
    async initNewRow(data: any) {
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
        this.SubStoreConsumptionActionDetails.Height = 350;
        this.SubStoreConsumptionActionDetails.AllowUserToDeleteRows = true;
        this.SubStoreConsumptionActionDetails.DeleteButtonWidth = 50;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = 'MaterialListDefinition';
        this.Material.DataMember = 'Material';
        this.Material.AutoCompleteDialogHeight = '60%';
        this.Material.AutoCompleteDialogWidth = '90%';
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M18550", "Malzeme Adı");
        this.Material.Name = 'Material';
        this.Material.Width = 500;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M12449", "Dağıtım Şekli");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 140;

        this.AmountSubStoreConsumptionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountSubStoreConsumptionDetail.DataMember = 'Amount';
        this.AmountSubStoreConsumptionDetail.DisplayIndex = 5;
        this.AmountSubStoreConsumptionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountSubStoreConsumptionDetail.Name = 'AmountSubStoreConsumptionDetail';
        this.AmountSubStoreConsumptionDetail.Width = 80;
        this.AmountSubStoreConsumptionDetail.IsNumeric = true;

        this.Existing = new TTVisual.TTTextBoxColumn();
        this.Existing.DataMember = 'StoreStock';
        this.Existing.Format = 'N2';
        this.Existing.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Existing.DisplayIndex = 4;
        this.Existing.HeaderText = i18n("M18957", "Mevcut");
        this.Existing.Name = 'Existing';
        this.Existing.ReadOnly = true;
        this.Existing.Width = 120;

        this.StockLevelTypeSubStoreConsumptionDetail = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeSubStoreConsumptionDetail.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeSubStoreConsumptionDetail.DataMember = 'StockLevelType';
        this.StockLevelTypeSubStoreConsumptionDetail.DisplayIndex = 6;
        this.StockLevelTypeSubStoreConsumptionDetail.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeSubStoreConsumptionDetail.Name = 'StockLevelTypeSubStoreConsumptionDetail';
        this.StockLevelTypeSubStoreConsumptionDetail.Width = 140;

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

        this.SubStoreConsumptionActionDetailsColumns = [this.Detail, this.Material, this.Barcode, this.DistributionType, this.Existing, this.AmountSubStoreConsumptionDetail,
        this.StockLevelTypeSubStoreConsumptionDetail];
        this.tttabcontrol1.Controls = [this.MaterialOutTabPage];
        this.MaterialOutTabPage.Controls = [this.SubStoreConsumptionActionDetails];
        this.Controls = [this.labelTransactionDate, this.TransactionDate, this.tttabcontrol1, this.MaterialOutTabPage, this.SubStoreConsumptionActionDetails,
        this.Detail, this.Barcode, this.Material, this.DistributionType, this.AmountSubStoreConsumptionDetail, this.Existing, this.StockLevelTypeSubStoreConsumptionDetail,
        this.StockActionID, this.Description, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelDescription];

    }


}
