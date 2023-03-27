//$ACCE895A
import { Component, OnInit, NgZone } from '@angular/core';
import { BaseDistributionDocumentFormViewModel } from './BaseDistributionDocumentFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DistributionDocument } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResUserService } from 'ObjectClassService/ResUserService';
import { StockActionBaseForm } from 'Modules/Saglik_Lojistik/Stok_Evrensel_Modulu/StockActionBaseForm';
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { StockLevelTypeService } from 'ObjectClassService/StockLevelTypeService';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelService } from 'ObjectClassService/StockLevelService';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { StockActionService, EquivalentInfo } from 'NebulaClient/Services/ObjectService/StockActionService';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IModalService } from 'Fw/Services/IModalService';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

@Component({
    selector: 'BaseDistributionDocumentForm',
    templateUrl: './BaseDistributionDocumentForm.html',
    providers: [MessageService]
})
export class BaseDistributionDocumentForm extends StockActionBaseForm implements OnInit {
    AcceptedAmountDistributionDocumentMaterial: TTVisual.ITTTextBoxColumn;
    AmountDistributionDocumentMaterial: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    TagNo: TTVisual.ITTTextBoxColumn;
    Description: TTVisual.ITTTextBox;
    DescriptionAndSignTabControl: TTVisual.ITTTabControl;
    DescriptionTabpage: TTVisual.ITTTabPage;
    DestinationStore: TTVisual.ITTObjectListBox;
    Detail: TTVisual.ITTButtonColumn;
    DistributionDocumentMaterials: TTVisual.ITTGrid;
    DistributionDocumentMaterialsTabcontrol: TTVisual.ITTTabControl;
    DistributionDocumentMaterialsTabpage: TTVisual.ITTTabPage;
    DistributionType: TTVisual.ITTTextBoxColumn;
    IsDeputy: TTVisual.ITTCheckBoxColumn;
    labelDestinationStore: TTVisual.ITTLabel;
    labelMKYS_TeslimAlan: TTVisual.ITTLabel;
    labelMKYS_TeslimEden: TTVisual.ITTLabel;
    labelStockActionID: TTVisual.ITTLabel;
    labelStore: TTVisual.ITTLabel;
    labelTransactionDate: TTVisual.ITTLabel;
    lblMKYS_CikisIslemTuru: TTVisual.ITTLabel;
    lblMKYS_CikisStokHareketTuru: TTVisual.ITTLabel;
    MaterialDistributionDocumentMaterial: TTVisual.ITTListBoxColumn;
    MKYS_CikisIslemTuru: TTVisual.ITTEnumComboBox;
    MKYS_CikisStokHareketTuru: TTVisual.ITTEnumComboBox;
    MKYS_TeslimAlan: TTButtonTextBox;
    MKYS_TeslimEden: TTButtonTextBox;
    Price: TTVisual.ITTTextBoxColumn;
    SignTabpage: TTVisual.ITTTabPage;
    SignUser: TTVisual.ITTListBoxColumn;
    SignUserType: TTVisual.ITTEnumComboBoxColumn;
    StatusDistributionDocumentMaterial: TTVisual.ITTEnumComboBoxColumn;
    StockActionID: TTVisual.ITTTextBox;
    StockActionSignDetails: TTVisual.ITTGrid;
    StockLevelTypeDistributionDocumentMaterial: TTVisual.ITTListBoxColumn;
    Store: TTVisual.ITTObjectListBox;
    StoreInheld: TTVisual.ITTTextBoxColumn;
    SubStoreInheld: TTVisual.ITTTextBoxColumn;
    TransactionDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    TTTeslimAlanButon: TTVisual.ITTButton;
    TTTeslimEdenButon: TTVisual.ITTButton;
    public ShowZeroOnDistributionInfo: boolean = true;

    UnitPrice: TTVisual.ITTTextBoxColumn;
    public DistributionDocumentMaterialsColumns = [];
    public StockActionSignDetailsColumns = [];
    public baseDistributionDocumentFormViewModel: BaseDistributionDocumentFormViewModel = new BaseDistributionDocumentFormViewModel();
    public get _DistributionDocument(): DistributionDocument {
        return this._TTObject as DistributionDocument;
    }
    private BaseDistributionDocumentForm_DocumentUrl: string = '/api/DistributionDocumentService/BaseDistributionDocumentForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService, protected modalService: IModalService, protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.BaseDistributionDocumentForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    private async DistributionDocumentMaterials_CellContentClick(rowIndex: number, columnIndex: number): Promise<void> {
        if (this.DistributionDocumentMaterials.CurrentCell.OwningColumn.Name === 'Detail') {
            this.ShowStockActionDetailForm(<StockActionDetail>this.DistributionDocumentMaterials.CurrentCell.OwningRow.TTObject);
        }
    }
    private async DistributionDocumentMaterials_CellDoubleClick(rowIndex: number, columnIndex: number): Promise<void> {
    }





    private showEquivalentDrug(data: Array<EquivalentInfo>): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DrugEquivalentComponentByStockAction';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13913", "Eşdeğer İlaçlar");
            modalInfo.Width = 600;
            modalInfo.Height = 400;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    private checkEquivalent(equivalentDrugs: Array<EquivalentInfo>): Promise<Material> {
        return new Promise<Material>((resolve, reject) => {
            if (equivalentDrugs.length > 0) {
                let drugObjectid: any = null;
                this.showEquivalentDrug(equivalentDrugs).then(result => {
                    let modalActionResult = result as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        let obj = result.Param as EquivalentInfo;
                        drugObjectid = obj.drugObjectId;
                        if (drugObjectid !== null) {
                            this.objectContextService.getObject<Material>(drugObjectid, DrugDefinition.ObjectDefID).then(mat => resolve(mat)).catch(error => reject(error));
                        } else {
                            resolve(null);
                        }
                    } else {
                        resolve(null);
                    }
                }).catch(err => reject(err));
            } else {
                resolve(null);
            }
        });
    }

    public async DistributionDocumentMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        let distributionDocumentMaterial: DistributionDocumentMaterial = <DistributionDocumentMaterial>(data.row.data);
        if (distributionDocumentMaterial.Status === undefined) {
            distributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            distributionDocumentMaterial.StockLevelType = stockLeveltypeArray[0];
        }
        if (data.column.dataField === 'Material' || data.column.dataField === 'StockLevelType') {
            if (data.column.dataField === 'Material') {
                if (distributionDocumentMaterial.Material != null && distributionDocumentMaterial.StockLevelType != null) {
                    if (distributionDocumentMaterial.Material.ObjectID != null) {
                        let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(distributionDocumentMaterial.Material.ObjectID,
                            this._DistributionDocument.Store.ObjectID, distributionDocumentMaterial.StockLevelType.ObjectID);
                        distributionDocumentMaterial.StoreStock = stockInheld;
                        if (stockInheld === 0) {
                            let equivalentInfo: Array<EquivalentInfo> = await StockActionService.GetEquivalentDrug(this._DistributionDocument.Store.ObjectID.toString(), distributionDocumentMaterial.Material.ObjectID.toString());
                            let equivalentDrug: any = await this.checkEquivalent(equivalentInfo);
                            if (equivalentDrug !== null) {
                                distributionDocumentMaterial.Material = equivalentDrug;
                                let stockInheld2: number = await StockLevelService.StockInheldWithStockLevel(distributionDocumentMaterial.Material.ObjectID,
                                    this._DistributionDocument.Store.ObjectID, distributionDocumentMaterial.StockLevelType.ObjectID);
                                distributionDocumentMaterial.StoreStock = stockInheld2;
                            }
                        }
                    }
                }
            }
        }
        /*if (data.Column.Name === 'AcceptedAmountDistributionDocumentMaterial') {
            let detail: DistributionDocumentMaterial = <DistributionDocumentMaterial>data.Row.TTObject;
            if (detail.AcceptedAmount != null) {
                (<DistributionDocumentMaterial>data.Row.TTObject).Amount = detail.AcceptedAmount;
            }
            if (detail.AcceptedAmount > distributionDocumentMaterial.StoreStock)
            {
                detail.AcceptedAmount = distributionDocumentMaterial.StoreStock;
            }
        }*/

        // if (data.column.dataField === 'AcceptedAmount') {
        //     let detail: DistributionDocumentMaterial = <DistributionDocumentMaterial>data.row.data;
        //     if (detail.AcceptedAmount != null) {
        //         (<DistributionDocumentMaterial>data.row.data).Amount = detail.AcceptedAmount;
        //     }
        // }
    }

    public async TTTeslimAlanButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this, i18n("M23225", "Teslim Alan Personel Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimAlan.Text = selectedPersonel.Name.toString();
            this._DistributionDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
        }
    }
    public async TTTeslimEdenButon_Click(): Promise<void> {

        let resUser: Array<ResUser> = (await ResUserService.GetAllUser('WHERE ISACTIVE = 1 '));
        let selectedPersonel: ResUser = null;
        let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
        for (let user of resUser) {
            multiSelectForm.AddMSItem(user.Name, user.ObjectID.toString(), user);
        }
        let key: string = await multiSelectForm.GetMSItem(this, i18n("M23234", "Teslim Eden Personeli Seçin"));
        if (String.isNullOrEmpty(key)) {
            TTVisual.InfoBox.Show(i18n("M15736", "Herhangibir Personel Seçilmedi."), MessageIconEnum.ErrorMessage);
        } else {
            selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
            this.MKYS_TeslimEden.Text = selectedPersonel.Name.toString();
            this._DistributionDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
        }
    }
    protected async PreScript() {
        await super.PreScript();
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DistributionDocument();
        this.baseDistributionDocumentFormViewModel = new BaseDistributionDocumentFormViewModel();
        this._ViewModel = this.baseDistributionDocumentFormViewModel;
        this.baseDistributionDocumentFormViewModel._DistributionDocument = this._TTObject as DistributionDocument;
        this.baseDistributionDocumentFormViewModel._DistributionDocument.Store = new Store();
        this.baseDistributionDocumentFormViewModel._DistributionDocument.DestinationStore = new Store();
        this.baseDistributionDocumentFormViewModel._DistributionDocument.DistributionDocumentMaterials = new Array<DistributionDocumentMaterial>();
        this.baseDistributionDocumentFormViewModel._DistributionDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.baseDistributionDocumentFormViewModel = this._ViewModel as BaseDistributionDocumentFormViewModel;
        that._TTObject = this.baseDistributionDocumentFormViewModel._DistributionDocument;
        if (this.baseDistributionDocumentFormViewModel == null) {
            this.baseDistributionDocumentFormViewModel = new BaseDistributionDocumentFormViewModel();
        }
        if (this.baseDistributionDocumentFormViewModel._DistributionDocument == null) {
            this.baseDistributionDocumentFormViewModel._DistributionDocument = new DistributionDocument();
        }
        let storeObjectID = that.baseDistributionDocumentFormViewModel._DistributionDocument['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.baseDistributionDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.baseDistributionDocumentFormViewModel._DistributionDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.baseDistributionDocumentFormViewModel._DistributionDocument['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.baseDistributionDocumentFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.baseDistributionDocumentFormViewModel._DistributionDocument.DestinationStore = destinationStore;
            }
        }
        that.baseDistributionDocumentFormViewModel._DistributionDocument.DistributionDocumentMaterials = that.baseDistributionDocumentFormViewModel.DistributionDocumentMaterialsGridList;
        for (let detailItem of that.baseDistributionDocumentFormViewModel.DistributionDocumentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.baseDistributionDocumentFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.baseDistributionDocumentFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.baseDistributionDocumentFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.baseDistributionDocumentFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.baseDistributionDocumentFormViewModel._DistributionDocument.StockActionSignDetails = that.baseDistributionDocumentFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.baseDistributionDocumentFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.baseDistributionDocumentFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(BaseDistributionDocumentFormViewModel);

    }


    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Description !== event) {
                this._DistributionDocument.Description = event;
            }
        }
    }

    public onDestinationStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.DestinationStore !== event) {
                this._DistributionDocument.DestinationStore = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisIslemTuru !== event) {
                this._DistributionDocument.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_CikisStokHareketTuru !== event) {
                this._DistributionDocument.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
                this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
                this.MKYS_TeslimAlan.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimAlan !== event) {
                this._DistributionDocument.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
                this.MKYS_TeslimEden.BackColor = '#F0F0F0';
                this.MKYS_TeslimEden.ReadOnly = true;
            }
            if (this._DistributionDocument != null && this._DistributionDocument.MKYS_TeslimEden !== event) {
                this._DistributionDocument.MKYS_TeslimEden = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.StockActionID !== event) {
                this._DistributionDocument.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.Store !== event) {
                this._DistributionDocument.Store = event;
            }
        }
    }

    public onTransactionDateChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this._DistributionDocument.TransactionDate !== event) {
                this._DistributionDocument.TransactionDate = event;
            }
        }
    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_CikisStokHareketTuru, 'Value', this.__ttObject, 'MKYS_CikisStokHareketTuru');
        redirectProperty(this.MKYS_CikisIslemTuru, 'Value', this.__ttObject, 'MKYS_CikisIslemTuru');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = 'labelMKYS_TeslimEden';
        this.labelMKYS_TeslimEden.TabIndex = 139;

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

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.Description.Name = 'Description';
        this.Description.TabIndex = 6;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = 'labelMKYS_TeslimAlan';
        this.labelMKYS_TeslimAlan.TabIndex = 137;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M14859", "Gönderen Depo");
        this.labelStore.Name = 'labelStore';
        this.labelStore.TabIndex = 135;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = 'MainStoreList';
        this.Store.Name = 'Store';
        this.Store.TabIndex = 134;

        this.labelDestinationStore = new TTVisual.TTLabel();
        this.labelDestinationStore.Text = i18n("M10678", "Alan Depo");
        this.labelDestinationStore.Name = 'labelDestinationStore';
        this.labelDestinationStore.TabIndex = 133;

        this.DestinationStore = new TTVisual.TTObjectListBox();
        this.DestinationStore.ReadOnly = true;
        this.DestinationStore.ListDefName = 'SubStoreList';
        this.DestinationStore.Name = 'DestinationStore';
        this.DestinationStore.TabIndex = 132;

        this.DistributionDocumentMaterialsTabcontrol = new TTVisual.TTTabControl();
        this.DistributionDocumentMaterialsTabcontrol.Name = 'DistributionDocumentMaterialsTabcontrol';
        this.DistributionDocumentMaterialsTabcontrol.TabIndex = 30;

        this.DistributionDocumentMaterialsTabpage = new TTVisual.TTTabPage();
        this.DistributionDocumentMaterialsTabpage.DisplayIndex = 0;
        this.DistributionDocumentMaterialsTabpage.TabIndex = 0;
        this.DistributionDocumentMaterialsTabpage.Text = 'Taşınır Malın';
        this.DistributionDocumentMaterialsTabpage.Name = 'DistributionDocumentMaterialsTabpage';

        this.DistributionDocumentMaterials = new TTVisual.TTGrid();
        this.DistributionDocumentMaterials.Name = 'DistributionDocumentMaterials';
        this.DistributionDocumentMaterials.TabIndex = 29;

        this.Detail = new TTVisual.TTButtonColumn();
        this.Detail.Text = i18n("M12671", "Detay");
        this.Detail.UseColumnTextForButtonValue = true;
        this.Detail.DisplayIndex = 0;
        this.Detail.HeaderText = '';
        this.Detail.Name = 'Detail';
        this.Detail.ToolTipText = i18n("M12671", "Detay");
        this.Detail.Width = 80;

        this.MaterialDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.MaterialDistributionDocumentMaterial.AllowMultiSelect = true;
        this.MaterialDistributionDocumentMaterial.ListDefName = 'MaterialListDefinition';
        this.MaterialDistributionDocumentMaterial.DataMember = 'Material';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogHeight = '60%';
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogWidth = '50%';
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialDistributionDocumentMaterial.Name = 'MaterialDistributionDocumentMaterial';
        this.MaterialDistributionDocumentMaterial.Width = 300;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'DistributionType';
        this.DistributionType.DisplayIndex = 3;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 75;

        this.AcceptedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AcceptedAmountDistributionDocumentMaterial.DataMember = 'AcceptedAmount';
        this.AcceptedAmountDistributionDocumentMaterial.Required = true;
        this.AcceptedAmountDistributionDocumentMaterial.Format = 'N4';
        this.AcceptedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AcceptedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.AcceptedAmountDistributionDocumentMaterial.HeaderText = i18n("M16713", "İstenen Miktar");
        this.AcceptedAmountDistributionDocumentMaterial.Name = 'AcceptedAmountDistributionDocumentMaterial';
        this.AcceptedAmountDistributionDocumentMaterial.Width = 75;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = 'Amount';
        this.AmountDistributionDocumentMaterial.Format = 'N4';
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = i18n("M24114", "Verilen Miktar");
        this.AmountDistributionDocumentMaterial.Name = 'AmountDistributionDocumentMaterial';
        this.AmountDistributionDocumentMaterial.Width = 75;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = 'StoreStock';
        this.StoreInheld.Format = 'N4';
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = i18n("M12625", "Depo Mevcudu");
        this.StoreInheld.Name = 'StoreInheld';
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Visible = false;
        this.StoreInheld.Width = 75;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = 'StockLevelType';
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeDistributionDocumentMaterial.Name = 'StockLevelTypeDistributionDocumentMaterial';
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = true;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 75;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 75;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = 'Price';
        this.Price.Format = 'N4';
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = 'Price';
        this.Price.ReadOnly = true;
        this.Price.Width = 75;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusDistributionDocumentMaterial.DataMember = 'Status';
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = 'Durum';
        this.StatusDistributionDocumentMaterial.Name = 'StatusDistributionDocumentMaterial';
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 75;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = '#F0F0F0';
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.StockActionID.Name = 'StockActionID';
        this.StockActionID.TabIndex = 0;

        this.TransactionDate = new TTVisual.TTDateTimePicker();
        this.TransactionDate.BackColor = '#F0F0F0';
        this.TransactionDate.CustomFormat = '';
        this.TransactionDate.Format = DateTimePickerFormat.Short;
        this.TransactionDate.Enabled = false;
        this.TransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.TransactionDate.Name = 'TransactionDate';
        this.TransactionDate.TabIndex = 1;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16869", "İşlem Nu.");
        this.labelStockActionID.BackColor = '#DCDCDC';
        this.labelStockActionID.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelStockActionID.ForeColor = '#000000';
        this.labelStockActionID.Name = 'labelStockActionID';
        this.labelStockActionID.TabIndex = 4;

        this.labelTransactionDate = new TTVisual.TTLabel();
        this.labelTransactionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelTransactionDate.BackColor = '#DCDCDC';
        this.labelTransactionDate.Font = 'Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False';
        this.labelTransactionDate.ForeColor = '#000000';
        this.labelTransactionDate.Name = 'labelTransactionDate';
        this.labelTransactionDate.TabIndex = 8;

        this.DescriptionAndSignTabControl = new TTVisual.TTTabControl();
        this.DescriptionAndSignTabControl.Name = 'DescriptionAndSignTabControl';
        this.DescriptionAndSignTabControl.TabIndex = 4;
        this.DescriptionAndSignTabControl.Visible = false;

        this.SignTabpage = new TTVisual.TTTabPage();
        this.SignTabpage.DisplayIndex = 0;
        this.SignTabpage.TabIndex = 1;
        this.SignTabpage.Text = i18n("M16480", "İmzalar");
        this.SignTabpage.Name = 'SignTabpage';

        this.StockActionSignDetails = new TTVisual.TTGrid();
        this.StockActionSignDetails.AllowUserToDeleteRows = false;
        this.StockActionSignDetails.Name = 'StockActionSignDetails';
        this.StockActionSignDetails.TabIndex = 0;

        this.SignUserType = new TTVisual.TTEnumComboBoxColumn();
        this.SignUserType.DataTypeName = 'SignUserTypeEnum';
        this.SignUserType.DataMember = 'SignUserType';
        this.SignUserType.DisplayIndex = 0;
        this.SignUserType.HeaderText = i18n("M16475", "İmza Tipi");
        this.SignUserType.Name = 'SignUserType';
        this.SignUserType.ReadOnly = true;
        this.SignUserType.Width = 120;

        this.SignUser = new TTVisual.TTListBoxColumn();
        this.SignUser.ListDefName = 'UserListDefinition';
        this.SignUser.DataMember = 'SignUser';
        this.SignUser.DisplayIndex = 1;
        this.SignUser.HeaderText = i18n("M20345", "Personelin Adı, Soyadı");
        this.SignUser.Name = 'SignUser';
        this.SignUser.Width = 400;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DescriptionTabpage = new TTVisual.TTTabPage();
        this.DescriptionTabpage.DisplayIndex = 1;
        this.DescriptionTabpage.TabIndex = 0;
        this.DescriptionTabpage.Text = i18n("M10469", "Açıklama");
        this.DescriptionTabpage.Name = 'DescriptionTabpage';

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = 'MKYS_ECikisStokHareketTurEnum';
        this.MKYS_CikisStokHareketTuru.Required = true;
        this.MKYS_CikisStokHareketTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = 'MKYS_CikisStokHareketTuru';
        this.MKYS_CikisStokHareketTuru.TabIndex = 128;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = 'MKYS_ECikisIslemTuruEnum';
        this.MKYS_CikisIslemTuru.Required = true;
        this.MKYS_CikisIslemTuru.BackColor = '#F0F0F0';
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = 'MKYS_CikisIslemTuru';
        this.MKYS_CikisIslemTuru.TabIndex = 124;

        this.lblMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisIslemTuru.Text = i18n("M16895", "İşlem Türü");
        this.lblMKYS_CikisIslemTuru.Name = 'lblMKYS_CikisIslemTuru';
        this.lblMKYS_CikisIslemTuru.TabIndex = 125;

        this.lblMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.lblMKYS_CikisStokHareketTuru.Text = i18n("M22325", "Stok Hareket Türü");
        this.lblMKYS_CikisStokHareketTuru.Name = 'lblMKYS_CikisStokHareketTuru';
        this.lblMKYS_CikisStokHareketTuru.TabIndex = 129;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10469", "Açıklama");
        this.ttlabel1.Name = 'ttlabel1';
        this.ttlabel1.TabIndex = 129;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = 'TE';
        this.TTTeslimEdenButon.Name = 'TTTeslimEdenButon';
        this.TTTeslimEdenButon.TabIndex = 121;

        this.DistributionDocumentMaterialsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType,
        this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial,
        this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.DistributionDocumentMaterials];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description, this.labelMKYS_TeslimAlan, this.labelStore, this.Store,
        this.labelDestinationStore, this.DestinationStore, this.DistributionDocumentMaterialsTabcontrol, this.DistributionDocumentMaterialsTabpage,
        this.DistributionDocumentMaterials, this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType,
        this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial,
        this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.StockActionID, this.TransactionDate, this.labelStockActionID, this.labelTransactionDate,
        this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType, this.SignUser, this.IsDeputy, this.DescriptionTabpage,
        this.MKYS_CikisStokHareketTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisIslemTuru, this.lblMKYS_CikisStokHareketTuru, this.ttlabel1, this.TTTeslimAlanButon,
        this.TTTeslimEdenButon];

    }


}
