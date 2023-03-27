//$C3F6E6DB
import { Component, OnInit, ApplicationRef, ChangeDetectorRef, NgZone } from '@angular/core';
import { GrantMaterialNewFormViewModel } from './GrantMaterialNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { BaseGrantMaterialForm } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Bagis_Yardim_Modulu/BaseGrantMaterialForm';
import { GrantMaterial, DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MainStoreDefinition, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EAlimYontemiEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_EMalzemeGrupEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ETedarikTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { BudgetTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { GrantMaterialDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { StockActionService } from 'NebulaClient/Services/ObjectService/StockActionService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam, BooleanParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';

@Component({
    selector: 'GrantMaterialNewForm',
    templateUrl: './GrantMaterialNewForm.html',
    providers: [MessageService]
})
export class GrantMaterialNewForm extends BaseGrantMaterialForm implements OnInit {
    public StockActionSignDetailsColumns = [];
    public grantMaterialNewFormViewModel: GrantMaterialNewFormViewModel = new GrantMaterialNewFormViewModel();
    public get _GrantMaterial(): GrantMaterial {
        return this._TTObject as GrantMaterial;
    }
    private GrantMaterialNewForm_DocumentUrl: string = '/api/GrantMaterialService/GrantMaterialNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private app: ApplicationRef,
        private reportService: AtlasReportService,
        private objectContextService: ObjectContextService,
        private changeDetectorRef: ChangeDetectorRef,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.GrantMaterialNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    protected async ClientSidePreScript(): Promise<void> {
        super.ClientSidePreScript();
        if (this._GrantMaterial.MKYS_EMalzemeGrup == null) {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            mSelectForm.AddMSItem(i18n("M23417", "Tıbbi Sarf"), i18n("M23417", "Tıbbi Sarf"), MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem(i18n("M16287", "İlaç"), i18n("M16287", "İlaç"), MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem(i18n("M23359", "Tıbbi Cihaz"), i18n("M23359", "Tıbbi Cihaz"), MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem(i18n("M12780", "Diğer"), i18n("M12780", "Diğer"), MKYS_EMalzemeGrupEnum.diger);
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M14806", "Giriş Yapılacak Malzeme Grubunu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey)) {
                this.messageService.showError(i18n("M18579", "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
            }
            this._GrantMaterial.MKYS_EMalzemeGrup = <MKYS_EMalzemeGrupEnum>mSelectForm.MSSelectedItemObject;
        }
        if (this._GrantMaterial.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiSarf) {
            this.MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID ='58d34696-808e-47de-87e0-1f001d0928a7'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
        if (this._GrantMaterial.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.ilac) {
            this.MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID ='65a2337c-bc3c-4c6b-9575-ad47fa7a9a89'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
        if (this._GrantMaterial.MKYS_EMalzemeGrup === MKYS_EMalzemeGrupEnum.tibbiCihaz) {
            this.MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID ='f38f2111-0ee4-4b9f-9707-a63ac02d29f4'  AND  MKYSMALZEMEKODU IS NOT NULL";
        }
        this._GrantMaterial.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
        this.grantMaterialNewFormViewModel._GrantMaterial.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.bagisVeYardim;
        if (this._GrantMaterial.Store instanceof MainStoreDefinition) {
            this._GrantMaterial.MKYS_TeslimAlan = (<MainStoreDefinition>this._GrantMaterial.Store).GoodsAccountant.Name;
            this._GrantMaterial.MKYS_TeslimAlanObjID = (<MainStoreDefinition>this._GrantMaterial.Store).GoodsAccountant.ObjectID;
        }
        this.app.tick();
    }

    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() == MainStoreDefinition.ObjectDefID.id || value.ObjectDefID.toString() == PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    protected async PreScript() {
        await super.PreScript();

        let isApproved: string = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        if (isApproved === 'TRUE') {
            this.DropStateButton(GrantMaterial.GrantMaterialStates.Approved);
        } else {
            this.DropStateButton(GrantMaterial.GrantMaterialStates.Completed);
        }

        if (this._GrantMaterial.Store == null) {
            this._GrantMaterial.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
        }

        if ((<MainStoreDefinition>this._GrantMaterial.Store).MKYS_ButceTuru != undefined) {
            if ((<MainStoreDefinition>this._GrantMaterial.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.donerSermaye) {
                let budgetObj: Guid = new Guid("3511171d-06ae-4434-ad44-3579ee616ecb");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._GrantMaterial.BudgetTypeDefinition = budgetTypeDef;
            }
            if ((<MainStoreDefinition>this._GrantMaterial.Store).MKYS_ButceTuru === MKYS_EButceTurEnum.genelButce) {
                let budgetObj: Guid = new Guid("57c410cc-afea-487a-8327-76e91a696a02");
                let budgetTypeDef: any = await this.objectContextService.getObject(budgetObj, BudgetTypeDefinition.ObjectDefID);
                this._GrantMaterial.BudgetTypeDefinition = budgetTypeDef;
            }
            this.BudgetTypeDefinition.ReadOnly = true;
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            if (transDef.ToStateDefID != null) {
                if (transDef.ToStateDefID.valueOf() === GrantMaterial.GrantMaterialStates.Completed.id) {
                    let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._GrantMaterial.ObjectID.toString());
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
        }
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new GrantMaterial();
        this.grantMaterialNewFormViewModel = new GrantMaterialNewFormViewModel();
        this._ViewModel = this.grantMaterialNewFormViewModel;
        this.grantMaterialNewFormViewModel._GrantMaterial = this._TTObject as GrantMaterial;
        this.grantMaterialNewFormViewModel._GrantMaterial.BudgetTypeDefinition = new BudgetTypeDefinition();
        this.grantMaterialNewFormViewModel._GrantMaterial.Store = new Store();
        this.grantMaterialNewFormViewModel._GrantMaterial.GrantMaterialDetails = new Array<GrantMaterialDetail>();
        this.grantMaterialNewFormViewModel._GrantMaterial.StockActionSignDetails = new Array<StockActionSignDetail>();
    }

    protected loadViewModel() {
        let that = this;

        that.grantMaterialNewFormViewModel = this._ViewModel as GrantMaterialNewFormViewModel;
        that._TTObject = this.grantMaterialNewFormViewModel._GrantMaterial;
        if (this.grantMaterialNewFormViewModel == null) {
            this.grantMaterialNewFormViewModel = new GrantMaterialNewFormViewModel();
        }
        if (this.grantMaterialNewFormViewModel._GrantMaterial == null) {
            this.grantMaterialNewFormViewModel._GrantMaterial = new GrantMaterial();
        }
        let budgetTypeDefinitionObjectID = that.grantMaterialNewFormViewModel._GrantMaterial['BudgetTypeDefinition'];
        if (budgetTypeDefinitionObjectID != null && (typeof budgetTypeDefinitionObjectID === 'string')) {
            let budgetTypeDefinition = that.grantMaterialNewFormViewModel.BudgetTypeDefinitions.find(o => o.ObjectID.toString() === budgetTypeDefinitionObjectID.toString());
            if (budgetTypeDefinition) {
                that.grantMaterialNewFormViewModel._GrantMaterial.BudgetTypeDefinition = budgetTypeDefinition;
            }
        }
        let storeObjectID = that.grantMaterialNewFormViewModel._GrantMaterial['Store'];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.grantMaterialNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.grantMaterialNewFormViewModel._GrantMaterial.Store = store;
            }
        }
        that.grantMaterialNewFormViewModel._GrantMaterial.GrantMaterialDetails = that.grantMaterialNewFormViewModel.GrantMaterialDetailsGridList;
        for (let detailItem of that.grantMaterialNewFormViewModel.GrantMaterialDetailsGridList) {
            let materialObjectID = detailItem['Material'];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.grantMaterialNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material['StockCard'];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.grantMaterialNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard['DistributionType'];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.grantMaterialNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let stockLevelType = that.grantMaterialNewFormViewModel.StockLevelTypes.find(o => o.ObjectID.toString() === stockLevelTypeObjectID.toString());
                if (stockLevelType) {
                    detailItem.StockLevelType = stockLevelType;
                }
            }
        }
        that.grantMaterialNewFormViewModel._GrantMaterial.StockActionSignDetails = that.grantMaterialNewFormViewModel.StockActionSignDetailsGridList;
        for (let detailItem of that.grantMaterialNewFormViewModel.StockActionSignDetailsGridList) {
            let signUserObjectID = detailItem['SignUser'];
            if (signUserObjectID != null && (typeof signUserObjectID === 'string')) {
                let signUser = that.grantMaterialNewFormViewModel.ResUsers.find(o => o.ObjectID.toString() === signUserObjectID.toString());
                if (signUser) {
                    detailItem.SignUser = signUser;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(GrantMaterialNewFormViewModel);
        if (this._GrantMaterial.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = '#F0F0F0';
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._GrantMaterial.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = '#F0F0F0';
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._GrantMaterial.MaterialGranttedBy != null) {
            this.MaterialGranttedBy.BackColor = '#F0F0F0';
            this.MaterialGranttedBy.ReadOnly = true;
        }
        if (this._GrantMaterial.GranttedByUniqNo != null) {
            this.GranttedByUniqNo.BackColor = '#F0F0F0';
            this.GranttedByUniqNo.ReadOnly = true;
        }
        this.FormCaption = i18n("M11410", "Bağış / Yardım ( Yeni )");
        this.changeDetectorRef.detectChanges();

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

    GrantMaterialDetails_CellValueChangedEmitted(data: any) {
        if (data && this.GrantMaterialDetails_CellValueChangedEmitted && data.Row && data.Column) {
            this.GrantMaterialDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }

    onSelectionChange(data: any) {

    }
    public async GrantMaterialDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.GrantMaterialDetails_CellValueChanged(data, rowIndex, columnIndex);
    }

    onRowInserting(data: GrantMaterialDetail) {
    }

    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }




    public redirectProperties(): void {
        redirectProperty(this.StockActionID, 'Text', this.__ttObject, 'StockActionID');
        redirectProperty(this.TransactionDate, 'Value', this.__ttObject, 'TransactionDate');
        //redirectProperty(this.AdditionalDocumentCount, "Text", this.__ttObject, "AdditionalDocumentCount");
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
        this.TTTeslimEdenButon.Height = '20px';

        this.MaterialGranttedBy = new TTButtonTextBox();
        this.MaterialGranttedBy.Required = true;
        this.MaterialGranttedBy.BackColor = '#FFE3C6';
        this.MaterialGranttedBy.Name = 'MaterialGranttedBy';
        this.MaterialGranttedBy.TabIndex = 200;


        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = 'TA';
        this.TTTeslimAlanButon.Name = 'TTTeslimAlanButon';
        this.TTTeslimAlanButon.TabIndex = 120;
        this.TTTeslimAlanButon.Height = '20px';

        this.TTFirma = new TTVisual.TTButton();
        this.TTFirma.Text = i18n("M14301", "Firma");
        this.TTFirma.Name = 'TTFirma';
        this.TTFirma.TabIndex = 133;
        this.TTFirma.Height = '20px';

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
        this.MKYS_TeslimEden.Name = 'MKYS_TeslimEden';
        this.MKYS_TeslimEden.TabIndex = 118;

        this.BudgetTypeDefinition = new TTVisual.TTObjectListBox();
        this.BudgetTypeDefinition.ReadOnly = false;
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
        this.GrantMaterialDetails.Height = 350;
        this.GrantMaterialDetails.AllowUserToDeleteRows = true;
        this.GrantMaterialDetails.DeleteButtonWidth = 80;


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

        this.MaterialGrantMaterialDetail = new TTVisual.TTListBoxColumn();
        this.MaterialGrantMaterialDetail.ListDefName = 'MaterialListDefinition';
        this.MaterialGrantMaterialDetail.DataMember = 'Material';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogHeight = '60%';
        this.MaterialGrantMaterialDetail.AutoCompleteDialogWidth = '90%';
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
        this.Barcode.DataMember = 'Material.Barcode';
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = 'Barkod';
        this.Barcode.Name = 'Barcode';
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.IsDeputy = new TTVisual.TTCheckBoxColumn();
        this.IsDeputy.DataMember = 'IsDeputy';
        this.IsDeputy.DisplayIndex = 2;
        this.IsDeputy.HeaderText = i18n("M24061", "Vekil");
        this.IsDeputy.Name = 'IsDeputy';
        this.IsDeputy.Width = 50;

        this.DistiributionType = new TTVisual.TTTextBoxColumn();
        this.DistiributionType.DataMember = 'Material.DistributionTypeName';
        this.DistiributionType.DisplayIndex = 3;
        this.DistiributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistiributionType.Name = 'DistiributionType';
        this.DistiributionType.ReadOnly = true;
        this.DistiributionType.Width = 140;

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
        this.AmountGrantMaterialDetail.Width = 120;
        this.AmountGrantMaterialDetail.IsNumeric = true;

        this.NotDiscountedUnitPrice = new TTVisual.TTTextBoxColumn();
        this.NotDiscountedUnitPrice.DataMember = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.DisplayIndex = 5;
        this.NotDiscountedUnitPrice.HeaderText = i18n("M16508", "İndirimsiz Birim Fiyat");
        this.NotDiscountedUnitPrice.Name = 'NotDiscountedUnitPrice';
        this.NotDiscountedUnitPrice.Width = 140;
        this.NotDiscountedUnitPrice.IsNumeric = true;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = 'UnitPrice';
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = 'UnitPrice';
        this.UnitPrice.Width = 120;
        this.UnitPrice.IsNumeric = true;

        this.LotNoGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.LotNoGrantMaterialDetail.DataMember = 'LotNo';
        this.LotNoGrantMaterialDetail.DisplayIndex = 7;
        this.LotNoGrantMaterialDetail.HeaderText = i18n("M18356", "Lot Nu.");
        this.LotNoGrantMaterialDetail.Name = 'LotNoGrantMaterialDetail';
        this.LotNoGrantMaterialDetail.Width = 120;

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
        this.StockLevelType.Width = 140;

        this.RetrievalYearGrantMaterialDetail = new TTVisual.TTTextBoxColumn();
        this.RetrievalYearGrantMaterialDetail.DataMember = 'RetrievalYear';
        this.RetrievalYearGrantMaterialDetail.DisplayIndex = 10;
        this.RetrievalYearGrantMaterialDetail.HeaderText = 'EdinimYili';
        this.RetrievalYearGrantMaterialDetail.Name = 'RetrievalYearGrantMaterialDetail';
        this.RetrievalYearGrantMaterialDetail.Width = 120;

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
        this.Controls = [this.GranttedByUniqNo, this.TTTeslimEdenButon, this.MaterialGranttedBy, this.TTTeslimAlanButon, this.TTFirma, this.labelMKYS_TeslimEden,
        this.labelBudgetTypeDefinition, this.MKYS_TeslimEden, this.BudgetTypeDefinition, this.MKYS_TeslimAlan, this.labelGranttedByUniqNo, this.Description,
        this.labelMKYS_EMalzemeGrup, this.StockActionID, this.MKYS_EMalzemeGrup, this.labelMKYS_TeslimAlan, this.Store, this.labelTransactionDate,
        this.labelDestinationStore, this.TransactionDate, this.labelMaterialGranttedBy, this.labelStockActionID, this.ChattelDocumentTabcontrol,
        this.DescriptionAndSignTabControl, this.ChattelDocumentDetailTabpage, this.SignTabpage, this.GrantMaterialDetails, this.StockActionSignDetails,
        this.SignUserType, this.MaterialGrantMaterialDetail, this.SignUser, this.Barcode, this.IsDeputy, this.DistiributionType, this.ttlabel1,
        this.AmountGrantMaterialDetail, this.NotDiscountedUnitPrice, this.UnitPrice, this.LotNoGrantMaterialDetail, this.ExpirationDateGrantMaterialDetail,
        this.StockLevelType, this.RetrievalYearGrantMaterialDetail, this.ProductionDateGrantMaterialDetail, this.MKYS_ETedarikTuru, this.labelMKYS_ETedarikTuru];

    }


}
