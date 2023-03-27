//$B2F8CB61
import { Component, ViewChild, OnInit, NgZone } from '@angular/core';
import { DistributionDocumentApprovalFormViewModel } from './DistributionDocumentApprovalFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseDistributionDocumentForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Dagitim_Belgesi_Modulu/BaseDistributionDocumentForm';
import { DistributionDocument, StockLevelTypeEnum, StockActionDetailStatusEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DistributionDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { DataGridViewContentAlignment } from 'NebulaClient/Utils/Enums/DataGridViewContentAlignment';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService, OpenStockActionDetailOutput_Input, GetOuttableLots_Output } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';

import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IModalService } from 'Fw/Services/IModalService';
import { EntityStateEnum } from 'NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { StockLevelTypeService } from 'app/NebulaClient/Services/ObjectService/StockLevelTypeService';
import { StockLevelService } from 'app/NebulaClient/Services/ObjectService/StockLevelService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { OuttableLotDTO } from '../Tasinir_Mal_Islem_Modulu/ChattelDocumentOutputWithAccountancyNewFormViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'DistributionDocumentApprovalForm',
    templateUrl: './DistributionDocumentApprovalForm.html',
    providers: [MessageService]
})
export class DistributionDocumentApprovalForm extends BaseDistributionDocumentForm implements OnInit {
    IsAutoDistribution: TTVisual.ITTCheckBox;
    public isVisible: boolean;
    public stockActionOrderNoCount: number = 0;
    //public DistributionDocumentMaterialsColumns = [];
    public DistributionDocumentMaterialsColumns = [
        // {
        //     caption: ' ',
        //     dataField: 'ObjectID',
        //     cellTemplate: 'buttonCellTemplate',
        //     width: 100
        // },
        {
            name: 'GetDetail',
            width: 'auto',
            cellTemplate: 'detailCellTemplate',
            visible: this.isVisible
        },
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
            caption: 'İstenen Miktar',
            dataField: 'AcceptedAmount',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Verilen Miktar',
            dataField: 'Amount',
            dataType: 'number',
        },
        {
            caption: 'Ana Depo Mevcudu',
            dataField: 'StoreStock',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Cep Depo Mevcudu',
            dataField: 'DestinationStoreStock',
            dataType: 'number',
            allowEditing: false
        },
        {
            caption: 'Cep Depo Max Seviye',
            dataField: 'DestinationStoreMaxLevel',
            dataType: 'number',
            allowEditing: false
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
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: 'auto',
            cellTemplate: 'deleteCellTemplate'
        },
    ];
    public StockActionSignDetailsColumns = [];
    public distributionDocumentApprovalFormViewModel: DistributionDocumentApprovalFormViewModel = new DistributionDocumentApprovalFormViewModel();
    @ViewChild('distributionDocumentMaterialGrid') distributionDocumentMaterialGrid: DxDataGridComponent;
    async distributionDocumentMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key.IsNew) {
                            this.distributionDocumentMaterialGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.distributionDocumentMaterialGrid.instance.filter(['EntityState', '<>', 1]);
                            this.distributionDocumentMaterialGrid.instance.refresh();

                        }
                    }
                }

            }

        }

    }

    async getDetail_CellContentClicked(data: any) {


        if (this._DistributionDocument.CurrentStateDefID.toString() === DistributionDocument.DistributionDocumentStates.StoreApproval.id) {
            ServiceLocator.MessageService.showInfo('Sadece Ana Depo tarafından seçilebilinir.');
            return;
        }
        if (data.data == null) {
            ServiceLocator.MessageService.showInfo('Malzeme seçmediniz.');
            return;
        }
        if (this._DistributionDocument.Store == null) {
            ServiceLocator.MessageService.showInfo('Depo seçmediniz.');
            return;
        }
        if (data.data.Amount == null) {
            ServiceLocator.MessageService.showInfo('Miktar girmediniz.');
            return;
        }
        let inputParam: OpenStockActionDetailOutput_Input = new OpenStockActionDetailOutput_Input();
        inputParam.MaterialID = data.data.Material.ObjectID;
        inputParam.StoreID = this._DistributionDocument.Store.ObjectID;
        inputParam.MaterialName = data.data.Material.Name;
        inputParam.RequestAmount = data.data.Amount;
        inputParam.Barcode = data.data.Material.Barcode;
        inputParam.DistributionTypeName = data.data.Material.DistributionTypeName;
        if (this.distributionDocumentApprovalFormViewModel.OuttableLotList != null)
            inputParam.selectedOuttableLots = this.distributionDocumentApprovalFormViewModel.OuttableLotList.filter(x => x.StockActionDetailOrderNo === data.data.ChattelDocDetailOrderNo);
        else
            inputParam.selectedOuttableLots = new Array<OuttableLotDTO>();
        this.showStockActionDetailOutForm(inputParam).then(res => {
            let modalActionResult = res as ModalActionResult;
            if (modalActionResult.Result === DialogResult.OK) {
                this.distributionDocumentApprovalFormViewModel.OuttableLotList = this.distributionDocumentApprovalFormViewModel.OuttableLotList.
                filter(x => x.StockActionDetailOrderNo !== data.data.ChattelDocDetailOrderNo);
                let outtableLots = res.Param as Array<GetOuttableLots_Output>;
                this.stockActionOrderNoCount = this.stockActionOrderNoCount + 1;
                data.data.ChattelDocDetailOrderNo = this.stockActionOrderNoCount;
                data.data.UserSelectedOutableTrx = true;
                for (let outTRX of outtableLots) {
                    let outtableLot: OuttableLotDTO = new OuttableLotDTO();
                    outtableLot.Amount = outTRX.RestAmount;
                    outtableLot.BudgetTypeName = outTRX.BudgetTypeName;
                    outtableLot.ExpirationDate = outTRX.ExpirationDate;
                    outtableLot.LotNo = outTRX.LotNo;
                    outtableLot.RestAmount = outTRX.RestAmount;
                    outtableLot.SerialNo = outTRX.SerialNo;
                    outtableLot.TrxObjectID = outTRX.TrxObjectID;
                    outtableLot.StockActionDetailOrderNo = this.stockActionOrderNoCount;
                    this.distributionDocumentApprovalFormViewModel.OuttableLotList.push(outtableLot);
                }
            }
        });
    }

    private showStockActionDetailOutForm(data: OpenStockActionDetailOutput_Input): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'StockActionDetailOutForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Çıkılabilir Girişler';
            modalInfo.Width = 800;
            modalInfo.Height = 500;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public amountEditting: boolean = true;

    public get _DistributionDocument(): DistributionDocument {
        return this._TTObject as DistributionDocument;
    }
    private DistributionDocumentApprovalForm_DocumentUrl: string = '/api/DistributionDocumentService/DistributionDocumentApprovalForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private reportService: AtlasReportService, protected modalService: IModalService, protected objectContextService: ObjectContextService,
        protected ngZone: NgZone) {
        super(httpService, messageService, modalService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.DistributionDocumentApprovalForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._DistributionDocument.ObjectID.toString());
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

    protected async PreScript() {
        await super.PreScript();
        this.isVisible = true;
        this.MaterialDistributionDocumentMaterial.ListFilterExpression = ' STOCKS.STORE=\'' + this._DistributionDocument.Store.ObjectID + '\' AND STOCKS.INHELD > 0 AND ( ShowZeroOnDistributionInfo IS NULL OR ShowZeroOnDistributionInfo = 0 )';

        if (this._DistributionDocument.DistributionDepStoreObjectID !== null) {
            this.DropStateButton(DistributionDocument.DistributionDocumentStates.New);
        }
        for (let stockActionOutDetailRow of this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials) {
            if (this._DistributionDocument.CurrentStateDefID === DistributionDocument.DistributionDocumentStates.Approval)
                stockActionOutDetailRow.Amount = stockActionOutDetailRow.AcceptedAmount;
        }
        if (this._DistributionDocument.CurrentStateDefID.toString() === DistributionDocument.DistributionDocumentStates.StoreApproval.id) {
            this.amountEditting = false;
            this.isVisible = false;
        }
    }
    initNewRow(data: any) { }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new DistributionDocument();
        this.distributionDocumentApprovalFormViewModel = new DistributionDocumentApprovalFormViewModel();
        this._ViewModel = this.distributionDocumentApprovalFormViewModel;
        this.distributionDocumentApprovalFormViewModel._DistributionDocument = this._TTObject as DistributionDocument;
        this.distributionDocumentApprovalFormViewModel._DistributionDocument.Store = new Store();
        this.distributionDocumentApprovalFormViewModel._DistributionDocument.DestinationStore = new Store();
        this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials = new Array<DistributionDocumentMaterial>();
        this.distributionDocumentApprovalFormViewModel._DistributionDocument.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    public IsEmergencyMaterial: boolean;
    protected loadViewModel() {
        let that = this;
        that.distributionDocumentApprovalFormViewModel = this._ViewModel as DistributionDocumentApprovalFormViewModel;
        this.IsEmergencyMaterial = this.distributionDocumentApprovalFormViewModel._DistributionDocument.IsEmergencyMaterial;
        that._TTObject = this.distributionDocumentApprovalFormViewModel._DistributionDocument;
        if (this.distributionDocumentApprovalFormViewModel == null) {
            this.distributionDocumentApprovalFormViewModel = new DistributionDocumentApprovalFormViewModel();
        }
        if (this.distributionDocumentApprovalFormViewModel._DistributionDocument == null) {
            this.distributionDocumentApprovalFormViewModel._DistributionDocument = new DistributionDocument();
        }
        let storeObjectID = that.distributionDocumentApprovalFormViewModel._DistributionDocument['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.distributionDocumentApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.distributionDocumentApprovalFormViewModel._DistributionDocument.Store = store;
            }
        }
        let destinationStoreObjectID = that.distributionDocumentApprovalFormViewModel._DistributionDocument['DestinationStore'];
        if (destinationStoreObjectID != null && (typeof destinationStoreObjectID === 'string')) {
            let destinationStore = that.distributionDocumentApprovalFormViewModel.Stores.find(o => o.ObjectID.toString() === destinationStoreObjectID.toString());
            if (destinationStore) {
                that.distributionDocumentApprovalFormViewModel._DistributionDocument.DestinationStore = destinationStore;
            }
        }
        that.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials = that.distributionDocumentApprovalFormViewModel.DistributionDocumentMaterialsGridList;
        for (let detailItem of that.distributionDocumentApprovalFormViewModel.DistributionDocumentMaterialsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.distributionDocumentApprovalFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.distributionDocumentApprovalFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType =
                                    that.distributionDocumentApprovalFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.distributionDocumentApprovalFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.distributionDocumentApprovalFormViewModel._DistributionDocument.StockActionSignDetails = that.distributionDocumentApprovalFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.distributionDocumentApprovalFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.distributionDocumentApprovalFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(DistributionDocumentApprovalFormViewModel);
        if (this._DistributionDocument.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._DistributionDocument.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        this.FormCaption = i18n("M12436", "Dağıtım Belgesi ( Onay )");

        this.stockActionOrderNoCount = this._DistributionDocument.DistributionDocumentMaterials.filter(x => x.ChattelDocDetailOrderNo != null).length

        if (this.distributionDocumentApprovalFormViewModel.OuttableLotList == null) {
            this.distributionDocumentApprovalFormViewModel.OuttableLotList = new Array<OuttableLotDTO>();
        }

        for(let material of this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials){
           this.setStoreStock(material);
        }
        


    }

    public async stateChange(event: FormSaveInfo) {
        let IsTagNoEmpty = false;
        for (var i = 0; i < this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.length; i++)
            if (this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.IsTagNoRequired && (this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo == "" || this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo == null)) {
                TTVisual.InfoBox.Alert(this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.Name + " malzemesi için Künye Numarası girmeniz gerekmektedir !");
                IsTagNoEmpty = true;
                return;
            }

        if (!IsTagNoEmpty) {
            if (event.transDef.ToStateDefID.valueOf() === DistributionDocument.DistributionDocumentStates.Completed.id) {
                this.distributionDocumentMaterialGrid.instance.closeEditCell();
                this.distributionDocumentMaterialGrid.instance.saveEditData();
                let isAmountEligable = true;
                this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.forEach(element => {
                    if (element.Amount <= 0 && element.Status !== StockActionDetailStatusEnum.Cancelled)
                        isAmountEligable = false;
                });
                if (isAmountEligable)
                    await super.setState(event.transDef, event);
                else
                    ServiceLocator.MessageService.showError(i18n("", "Verilen Miktar sıfırdan büyük olmalıdır!"));
            }
            else
                await super.setState(event.transDef, event);
        }
    }

    public async materialGridRowUpdating(event: any) {
        if (event.newData.Amount != null) {
            if (!isNaN(event.newData.Amount)) {
                if (event.newData.Amount < 0) {
                    ServiceLocator.MessageService.showError(i18n("", "Verilen Miktar sıfırdan büyük olmalıdır!"));
                    event.cancel = true;
                }
                else if (event.newData.Amount > event.oldData.StoreStock) {
                    ServiceLocator.MessageService.showError(i18n("", "İstenen Miktar Depo Mevcudunu aşamaz!"));
                    event.cancel = true;
                }
            }
        }

        if (event.newData.TagNo != null) {
            event.oldData.TagNo = event.newData.TagNo;
        }

        let stockSitesName: string = (await SystemParameterService.GetParameterValue("STOCKSITESNAME", "GAZİLER"));
        if (stockSitesName === "PURSAKLAR") {
            if (this.amountEditting === false && event.newData.Amount != null && event.newData.Amount !== event.oldData.Amount) {
                ServiceLocator.MessageService.showError(i18n("", "Onay adımında mevcudu değiştiremezsiniz."));
                event.cancel = true;
                event.newData.Amount = event.oldData.Amount;
            }
        }
    }

    public onEditingStartMaterialGrid(event: any) {
        if (event.data.Material == null) {
            event.cancel = true;
            this.distributionDocumentMaterialGrid.instance.saveEditData();
        }
    }

    onMaterialRowRemoving(e: any) {
        if (e.data.ObjectID != null) {
            this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.find(x => x.ObjectID === e.data.ObjectID).EntityState = EntityStateEnum.Deleted;
            this.distributionDocumentMaterialGrid.instance.filter(['EntityState', '<>', 1]);
            e.cancel = true;
        }
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

    public onIsAutoDistributionChanged(event): void {
        if (event != null) {
            if (this._DistributionDocument != null && this.IsAutoDistribution !== event) {
                this.IsAutoDistribution = event;
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

    DistributionDocumentMaterials_CellValueChangedEmitted(data: any) {
        if (data && this.DistributionDocumentMaterials_CellValueChanged && data.Row && data.Column) {
            this.DistributionDocumentMaterials_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    public async onSelectionChange(data: any) {
        await super.DistributionDocumentMaterials_CellValueChanged(data, 0, 0);
        this.distributionDocumentMaterialGrid.instance.closeEditCell();
        this.distributionDocumentMaterialGrid.instance.saveEditData();
        this.distributionDocumentMaterialGrid.instance.refresh();
        this.distributionDocumentMaterialGrid.instance.repaint();
    }

    public isCompletedForm: boolean = false;
    public selectedMaterial: Material;
    public PopupTagNo: string;
    public TagNoPopupVisible = false;
    public TagNoPopupMaterialName: string;
    public selectedStockLevelType: StockLevelType;
    public stockLeveltypeArray: Array<StockLevelType> = new Array<StockLevelType>();
    public async onMaterialSelectionChange(event: any) {
        if (this.stockLeveltypeArray.length == 0)
            this.stockLeveltypeArray = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
        this.selectedStockLevelType = this.stockLeveltypeArray.find(x => x.StockLevelTypeStatus.Value == StockLevelTypeEnum.New);
        if (this.selectedMaterial == null)
            ServiceLocator.MessageService.showError('Malzeme seçimi yapınız!');
        else
            if (!this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.find(x => x.Material.ObjectID == this.selectedMaterial.ObjectID && x.EntityState != EntityStateEnum.Deleted)) {
                let newRow: DistributionDocumentMaterial = new DistributionDocumentMaterial();
                newRow.IsNew = true;
                newRow.Material = this.selectedMaterial;
                newRow.StockLevelType = this.selectedStockLevelType;
                newRow.Status = StockActionDetailStatusEnum.New;
                if (this.selectedMaterial.IsTagNoRequired) {
                    this.TagNoPopupMaterialName = this.selectedMaterial.Name;
                    this.TagNoPopupVisible = true;
                    this.PopupTagNo = "";
                }
                this.setStoreStock(newRow);
                this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.push(newRow);
            }
            else
                ServiceLocator.MessageService.showError("Aynı malzeme daha önce eklenmiş! Ekli malzeme üzerinden güncelleme yapabilirsiniz.");
    }

    public inserTagNo() {
        this.TagNoPopupVisible = false;
        if (this.PopupTagNo != "")
            for (var i = 0; i < this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials.length; i++)
                if (this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].Material.Name == this.TagNoPopupMaterialName) {
                    this.distributionDocumentApprovalFormViewModel._DistributionDocument.DistributionDocumentMaterials[i].TagNo = this.PopupTagNo;
                }
    }

    public async setStoreStock(distributionDocumentMaterial: DistributionDocumentMaterial): Promise<any> {
        if (distributionDocumentMaterial.Status === undefined) {
            distributionDocumentMaterial.Status = StockActionDetailStatusEnum.New;
            let stockLeveltypeArray: Array<StockLevelType> = await StockLevelTypeService.GetStockLevelType(StockLevelTypeEnum.New);
            distributionDocumentMaterial.StockLevelType = stockLeveltypeArray[0];
        }
        if (distributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheld: number = await StockLevelService.StockInheldWithStockLevel(distributionDocumentMaterial.Material.ObjectID, this._DistributionDocument.Store.ObjectID, distributionDocumentMaterial.StockLevelType.ObjectID);
            distributionDocumentMaterial.StoreStock = stockInheld;
        }
        if (distributionDocumentMaterial.Material.ObjectID != null) {
            let stockInheldSubStore: number = await StockLevelService.StockInheldWithStockLevel(distributionDocumentMaterial.Material.ObjectID, this._DistributionDocument.DestinationStore.ObjectID, distributionDocumentMaterial.StockLevelType.ObjectID);
            distributionDocumentMaterial.DestinationStoreStock = stockInheldSubStore;
        }
    }

    public async DistributionDocumentMaterials_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.DistributionDocumentMaterials_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: DistributionDocumentMaterial) {

    }

    onCellContentClicked(data: any) {

    }



    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        redirectProperty(this.MKYS_CikisStokHareketTuru, 'Value', this.__ttObject, 'MKYS_CikisStokHareketTuru');
        redirectProperty(this.MKYS_CikisIslemTuru, 'Value', this.__ttObject, 'MKYS_CikisIslemTuru');
        redirectProperty(this.MKYS_TeslimAlan, 'Text', this.__ttObject, 'MKYS_TeslimAlan');
        redirectProperty(this.MKYS_TeslimEden, 'Text', this.__ttObject, 'MKYS_TeslimEden');
        redirectProperty(this.IsAutoDistribution, 'Value', this.__ttObject, 'IsAutoDistribution');
        redirectProperty(this.Description, 'Text', this.__ttObject, 'Description');
    }

    public initFormControls(): void {
        this.IsAutoDistribution = new TTVisual.TTCheckBox();
        this.IsAutoDistribution.Value = false;
        this.IsAutoDistribution.Title = i18n("M19814", "Otomatik Dağıtım Belgesi");
        this.IsAutoDistribution.Enabled = false;
        this.IsAutoDistribution.Name = 'IsAutoDistribution';
        this.IsAutoDistribution.TabIndex = 140;
        this.IsAutoDistribution.ReadOnly = true;


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
        this.DistributionDocumentMaterials.Height = 350;
        this.DistributionDocumentMaterials.AllowUserToDeleteRows = true;
        this.DistributionDocumentMaterials.AllowUserToAddRows = true;
        this.DistributionDocumentMaterials.DeleteButtonWidth = "%5";

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
        this.MaterialDistributionDocumentMaterial.AutoCompleteDialogWidth = '90%';
        this.MaterialDistributionDocumentMaterial.DisplayIndex = 1;
        this.MaterialDistributionDocumentMaterial.HeaderText = i18n("M18550", "Malzeme Adı");
        this.MaterialDistributionDocumentMaterial.Name = 'MaterialDistributionDocumentMaterial';
        this.MaterialDistributionDocumentMaterial.Width = 400;
        this.MaterialDistributionDocumentMaterial.ReadOnly = false;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = 'Material.DistributionTypeName';
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = 'DistributionType';
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AcceptedAmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AcceptedAmountDistributionDocumentMaterial.DataMember = 'AcceptedAmount';
        this.AcceptedAmountDistributionDocumentMaterial.Required = true;
        this.AcceptedAmountDistributionDocumentMaterial.Format = 'N4';
        this.AcceptedAmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AcceptedAmountDistributionDocumentMaterial.DisplayIndex = 4;
        this.AcceptedAmountDistributionDocumentMaterial.HeaderText = i18n("M16713", "İstenen Miktar");
        this.AcceptedAmountDistributionDocumentMaterial.Name = 'AcceptedAmountDistributionDocumentMaterial';
        this.AcceptedAmountDistributionDocumentMaterial.Width = 120;
        this.AcceptedAmountDistributionDocumentMaterial.IsNumeric = true;

        this.AmountDistributionDocumentMaterial = new TTVisual.TTTextBoxColumn();
        this.AmountDistributionDocumentMaterial.DataMember = 'Amount';
        this.AmountDistributionDocumentMaterial.Format = 'N4';
        this.AmountDistributionDocumentMaterial.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.AmountDistributionDocumentMaterial.DisplayIndex = 5;
        this.AmountDistributionDocumentMaterial.HeaderText = i18n("M24114", "Verilen Miktar");
        this.AmountDistributionDocumentMaterial.Name = 'AmountDistributionDocumentMaterial';
        this.AmountDistributionDocumentMaterial.Width = 120;
        this.AmountDistributionDocumentMaterial.IsNumeric = true;

        this.StoreInheld = new TTVisual.TTTextBoxColumn();
        this.StoreInheld.DataMember = 'StoreStock';
        this.StoreInheld.Format = 'N4';
        this.StoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.StoreInheld.DisplayIndex = 6;
        this.StoreInheld.HeaderText = i18n("M12625", "Ana Depo Mevcudu");
        this.StoreInheld.Name = 'StoreInheld';
        this.StoreInheld.ReadOnly = true;
        this.StoreInheld.Visible = true;
        this.StoreInheld.Width = 120;

        this.SubStoreInheld = new TTVisual.TTTextBoxColumn();
        this.SubStoreInheld.DataMember = 'DestinationStoreStock';
        this.SubStoreInheld.Format = 'N4';
        this.SubStoreInheld.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.SubStoreInheld.DisplayIndex = 6;
        this.SubStoreInheld.HeaderText = i18n("M12625", "Cep Depo Mevcudu");
        this.SubStoreInheld.Name = 'StoreInheld';
        this.SubStoreInheld.ReadOnly = true;
        this.SubStoreInheld.Visible = true;
        this.SubStoreInheld.Width = 120;

        this.StockLevelTypeDistributionDocumentMaterial = new TTVisual.TTListBoxColumn();
        this.StockLevelTypeDistributionDocumentMaterial.ListDefName = 'StockLevelTypeList';
        this.StockLevelTypeDistributionDocumentMaterial.DataMember = 'StockLevelType';
        this.StockLevelTypeDistributionDocumentMaterial.DisplayIndex = 7;
        this.StockLevelTypeDistributionDocumentMaterial.HeaderText = i18n("M18519", "Malın Durumu");
        this.StockLevelTypeDistributionDocumentMaterial.Name = 'StockLevelTypeDistributionDocumentMaterial';
        this.StockLevelTypeDistributionDocumentMaterial.ReadOnly = false;
        this.StockLevelTypeDistributionDocumentMaterial.Width = 120;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.UnitPrice.DisplayIndex = 8;
        this.UnitPrice.HeaderText = i18n("M11860", "Birim Fiyatı");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 120;
        this.UnitPrice.Visible = false;
        this.UnitPrice.IsNumeric = true;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DataMember = 'Price';
        this.Price.Format = 'N4';
        this.Price.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.Price.DisplayIndex = 9;
        this.Price.HeaderText = i18n("M23613", "Tutarı");
        this.Price.Name = 'Price';
        this.Price.ReadOnly = true;
        this.Price.Width = 120;
        this.Price.Visible = false;
        this.Price.IsNumeric = true;

        this.StatusDistributionDocumentMaterial = new TTVisual.TTEnumComboBoxColumn();
        this.StatusDistributionDocumentMaterial.DataTypeName = 'StockActionDetailStatusEnum';
        this.StatusDistributionDocumentMaterial.DataMember = 'Status';
        this.StatusDistributionDocumentMaterial.DisplayIndex = 10;
        this.StatusDistributionDocumentMaterial.HeaderText = 'Durum';
        this.StatusDistributionDocumentMaterial.Name = 'StatusDistributionDocumentMaterial';
        this.StatusDistributionDocumentMaterial.ReadOnly = true;
        this.StatusDistributionDocumentMaterial.Visible = false;
        this.StatusDistributionDocumentMaterial.Width = 120;

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

        // this.DistributionDocumentMaterialsColumns = [this.Detail, this.MaterialDistributionDocumentMaterial, this.Barcode, this.DistributionType,
        // this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.StockLevelTypeDistributionDocumentMaterial,
        // this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial];
        this.StockActionSignDetailsColumns = [this.SignUserType, this.SignUser, this.IsDeputy];
        this.DistributionDocumentMaterialsTabcontrol.Controls = [this.DistributionDocumentMaterialsTabpage];
        this.DistributionDocumentMaterialsTabpage.Controls = [this.DistributionDocumentMaterials];
        this.DescriptionAndSignTabControl.Controls = [this.SignTabpage, this.DescriptionTabpage];
        this.SignTabpage.Controls = [this.StockActionSignDetails];
        this.Controls = [this.IsAutoDistribution, this.labelMKYS_TeslimEden, this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.Description,
        this.labelMKYS_TeslimAlan, this.labelStore, this.Store, this.labelDestinationStore, this.DestinationStore, this.DistributionDocumentMaterialsTabcontrol,
        this.DistributionDocumentMaterialsTabpage, this.DistributionDocumentMaterials, this.Detail, this.MaterialDistributionDocumentMaterial,
        this.Barcode, this.DistributionType, this.AcceptedAmountDistributionDocumentMaterial, this.AmountDistributionDocumentMaterial, this.StoreInheld, this.SubStoreInheld,
        this.StockLevelTypeDistributionDocumentMaterial, this.UnitPrice, this.Price, this.StatusDistributionDocumentMaterial, this.StockActionID, this.TransactionDate,
        this.labelStockActionID, this.labelTransactionDate, this.DescriptionAndSignTabControl, this.SignTabpage, this.StockActionSignDetails, this.SignUserType,
        this.SignUser, this.IsDeputy, this.DescriptionTabpage, this.MKYS_CikisStokHareketTuru, this.MKYS_CikisIslemTuru, this.lblMKYS_CikisIslemTuru,
        this.lblMKYS_CikisStokHareketTuru, this.ttlabel1, this.TTTeslimAlanButon, this.TTTeslimEdenButon];
    }
}
