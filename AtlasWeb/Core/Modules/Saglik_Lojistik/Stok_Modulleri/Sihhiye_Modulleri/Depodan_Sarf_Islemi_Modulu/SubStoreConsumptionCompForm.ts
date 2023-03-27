//$FF65A4DC
import { Component, OnInit, NgZone } from '@angular/core';
import { SubStoreConsumptionCompFormViewModel, GetMaterialDetail_Input, UTSOutputDTO, UTSInputDTO } from './SubStoreConsumptionCompFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseSubStoreConsumptionActionForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Depodan_Sarf_Islemi_Modulu/BaseSubStoreConsumptionActionForm';
import { SubStoreConsumptionAction, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { SubStoreConsumptionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';

import { StockActionService } from 'ObjectClassService/StockActionService';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import Exception from 'app/NebulaClient/System/Exception';

@Component({
    selector: 'SubStoreConsumptionCompForm',
    templateUrl: './SubStoreConsumptionCompForm.html',
    providers: [MessageService]
})
export class SubStoreConsumptionCompForm extends BaseSubStoreConsumptionActionForm implements OnInit {

    public showUpdateUTSbutton: boolean = false;

    public subStoreConsumptionCompFormViewModel: SubStoreConsumptionCompFormViewModel = new SubStoreConsumptionCompFormViewModel();
    public get _SubStoreConsumptionAction(): SubStoreConsumptionAction {
        return this._TTObject as SubStoreConsumptionAction;
    }
    private SubStoreConsumptionCompForm_DocumentUrl: string = '/api/SubStoreConsumptionActionService/SubStoreConsumptionCompForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SubStoreConsumptionCompForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    SubStoreConsumptionActionDetails_CellValueChangedEmitted(data: any) { }
    onSelectionChangeDocumentRecordLogs(data: any) { }
    onSelectionChange(data: any) { }
    onRowInserting(data: any) { }
    initNewRow(data: any) { }
    onCellContentClicked(data: any) { }
    MainStoreStockTransferMaterials_CellValueChangedEmitted(data: any) { }
    popupVisible = false;
    public utsMessage: string;
    public popupUTSVisible: boolean = false;
    public LoadPanelMessage: string = "Lütfen Bekleyiniz İşleminiz Gerçekleştiriliyor.....";
    public loadingVisible: boolean = false;


    public SubStoreConsActionDetailsColumns = [

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
            caption: "UTS Kullanım Bildirimi",
            name: "UTSNotification",
            dataField: "UTSNotification",
            alignment: "center",
            width: '10%',
            allowEditing: false,
        },
        {
            caption: 'UTS Bildirim İptal',
            name: "RowUTSDelete",
            alignment: "center",
            width: '9%',
            cellTemplate: "deleteUTSCellTemplate",
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

    async MakeUTSNotificationForSubStoreConsumption() {
        this.loadingVisible = true;
        let apiUrl = '/api/SubStoreConsumptionActionService/MakeUTSNotificationForSubStoreConsumption';

        let inputDTO:UTSInputDTO =new UTSInputDTO;
        inputDTO.stockactionID = this._SubStoreConsumptionAction.ObjectID;
        await this.httpService.post<any>(apiUrl, inputDTO).then(response => {
            let result: UTSOutputDTO = response as UTSOutputDTO;
            if (result != null) {
                for (var item of result.stockActionDetails) {
                    this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails.find(x => x.ObjectID == item.ObjectID).UTSNotification = item.UTSNotification;
                }
                for (var det of this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails) {
                    if (det.UTSNotification != null && det.Material.IsIndividualTrackingRequired == true) {
                        this.showUpdateUTSbutton = true;
                    }
                }
            }

            for (var det of this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails) {
                if (det.UTSNotification != null) {
                    this.showUpdateUTSbutton = true;
                }
            }
            this.loadingVisible = false;
        }).catch(error => {
            ServiceLocator.MessageService.showError("Hata : " + error.returnMessage);
            this.loadingVisible = false;
        });
    }

    async  gridMaterialGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowCancel") {
            if (data.data.Status !== StockActionDetailStatusEnum.Cancelled) {
                try {
                    this.loadingVisible = true;
                    let res: boolean = await StockActionService.CancelStockActionDetail(data.data.ObjectID);
                    if (res === true) {
                        TTVisual.InfoBox.Alert("UYARI !", "İptal İşlemi Başarılıdır.", MessageIconEnum.InformationMessage);
                        this.loadingVisible = false;
                    }
                }
                catch (err) {
                    ServiceLocator.MessageService.showError(err);
                    this.loadingVisible = false;
                }
            } else {
                ServiceLocator.MessageService.showError('Şeçmiş olduğunuz malzeme zaten iptal edilmiştir.');
                this.loadingVisible = false;
            }
        }


        if (data.column.name == "RowUTSDelete") {
            if (data.row.key != null) {
                try {
                    this.loadingVisible = true;
                    let that = this;
                    let input = new GetMaterialDetail_Input();
                    input.StockActionDetailObjectID = data.data.ObjectID;
                    let fullApiUrl: string = 'api/SubStoreConsumptionActionService/DeleteUTSNotificationForSubStoreConsumption';
                    this.httpService.post(fullApiUrl, input)
                        .then((res) => {
                            if (res) {
                                this.loadingVisible = false;
                                this.showUpdateUTSbutton = false;
                                this.utsMessage = res.toString();
                                if(this.utsMessage == "ÜTS iptal Yapıldı."){
                                    data.row.key.UTSNotification = null;
                                }

                                this.popupUTSVisible = true;
                               
                            }
                        })
                        .catch(error => {
                            this.loadingVisible = false;
                            this.utsMessage = error;
                            this.popupUTSVisible = true;

                        });
                }
                catch (ex) {
                    this.loadingVisible = false;
                    this.utsMessage = ex;
                    this.popupUTSVisible = true;
                }
            }
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SubStoreConsumptionAction();
        this.subStoreConsumptionCompFormViewModel = new SubStoreConsumptionCompFormViewModel();
        this._ViewModel = this.subStoreConsumptionCompFormViewModel;
        this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction = this._TTObject as SubStoreConsumptionAction;
        this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails = new Array<SubStoreConsumptionDetail>();
        this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction.Store = new Store();
    }

    protected loadViewModel() {
        let that = this;

        that.subStoreConsumptionCompFormViewModel = this._ViewModel as SubStoreConsumptionCompFormViewModel;
        that._TTObject = this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction;
        if (this.subStoreConsumptionCompFormViewModel == null) {
            this.subStoreConsumptionCompFormViewModel = new SubStoreConsumptionCompFormViewModel();
        }
        if (this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction == null) {
            this.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction = new SubStoreConsumptionAction();
        }
        that.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction.SubStoreConsumptionActionDetails = that.subStoreConsumptionCompFormViewModel.SubStoreConsumptionActionDetailsGridList;
        for (let detailItem of that.subStoreConsumptionCompFormViewModel.SubStoreConsumptionActionDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.subStoreConsumptionCompFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.subStoreConsumptionCompFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.subStoreConsumptionCompFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.subStoreConsumptionCompFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        let storeObjectID = that.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.subStoreConsumptionCompFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.subStoreConsumptionCompFormViewModel._SubStoreConsumptionAction.Store = store;
            }
        }

        for (var det of this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails) {
            if (det.UTSNotification != null) {
                this.showUpdateUTSbutton = true;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(SubStoreConsumptionCompFormViewModel);

        if (this._SubStoreConsumptionAction.CurrentStateDefID.toString() == SubStoreConsumptionAction.SubStoreConsumptionActionStates.Completed.id.toString()) {
            this.FormCaption = i18n("M11241", "Atık Depoya Çıkış ( Tamamlandı )");
        }
        if (this._SubStoreConsumptionAction.CurrentStateDefID.toString() == SubStoreConsumptionAction.SubStoreConsumptionActionStates.Cancelled.id.toString()) {
            this.FormCaption = i18n("M11241", "Atık Depoya Çıkış ( İptal Edildi )");
            this.showUpdateUTSbutton = true;
        }
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

    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.ActionDate, 'Value', this.__ttObject, 'ActionDate');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public getIsReadOnly() {
        return true;
    }

    public controlOfCancelMKYS:boolean = true;
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef) {
        this.controlOfCancelMKYS = true;
        for (let log of this._SubStoreConsumptionAction.SubStoreConsumptionActionDetails) {
            if (log.UTSNotification != null) {
                this.controlOfCancelMKYS = false;
            }
        }

        if (this.controlOfCancelMKYS) {
            await super.ClientSidePostScript(transDef);
        }
        else {
            throw new Exception("ÜTS'den silinmeyen fiş iptal edilemez. Lütfen önce fişi siliniz!");
        }
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
        this.SubStoreConsumptionActionDetails.AllowUserToDeleteRows = false;
        this.SubStoreConsumptionActionDetails.AllowUserToDeleteRows = false;

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

        this.tttabcontrol1.Controls = [this.MaterialOutTabPage];
        this.MaterialOutTabPage.Controls = [this.SubStoreConsumptionActionDetails];
        this.Controls = [this.labelTransactionDate, this.TransactionDate, this.tttabcontrol1, this.MaterialOutTabPage, this.SubStoreConsumptionActionDetails,
        this.Detail, this.Barcode, this.Material, this.DistributionType, this.AmountSubStoreConsumptionDetail, this.Existing, this.StockLevelTypeSubStoreConsumptionDetail,
        this.StockActionID, this.Description, this.labelStore, this.Store, this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelDescription];

    }
}
