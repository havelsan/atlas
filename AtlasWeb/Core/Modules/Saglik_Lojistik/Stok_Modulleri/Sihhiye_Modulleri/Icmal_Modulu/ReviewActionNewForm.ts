//$993A997C
import { Component, OnInit, ChangeDetectorRef, NgZone } from '@angular/core';
import { ReviewActionNewFormViewModel } from './ReviewActionNewFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseReviewActionForm } from "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Icmal_Modulu/BaseReviewActionForm";
import { ReviewAction, BudgetTypeDefinition, ReviewActionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionPatientDet } from 'NebulaClient/Model/AtlasClientModel';
import { StockCollectedTrx } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { SelectStoreUsageEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { TTButtonTextBox } from 'NebulaClient/Visual/Controls/TTButtonTextBox';
import { MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MKYS_ECikisStokHareketTurEnum } from 'NebulaClient/Model/AtlasClientModel';

import { PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionService, ReviewActionService_Output, GetFiliterList_Output } from "ObjectClassService/ReviewActionService";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { IntegerParam } from 'NebulaClient/Mscorlib/IntegerParam';
import { StockActionService } from 'ObjectClassService/StockActionService';
import { DocumentTransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";

@Component({
    selector: 'ReviewActionNewForm',
    templateUrl: './ReviewActionNewForm.html',
    providers: [MessageService]
})
export class ReviewActionNewForm extends BaseReviewActionForm implements OnInit {
    public ReviewActionDetailsColumns = [];
    public reviewActionNewFormViewModel: ReviewActionNewFormViewModel = new ReviewActionNewFormViewModel();
    public get _ReviewAction(): ReviewAction {
        return this._TTObject as ReviewAction;
    }
    private ReviewActionNewForm_DocumentUrl: string = '/api/ReviewActionService/ReviewActionNewForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected objectContextService: ObjectContextService,
        private changeDetectorRef: ChangeDetectorRef,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super(httpService, messageService, objectContextService, ngZone);
        this._DocumentServiceUrl = this.ReviewActionNewForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }
    buttonDisabled: boolean = false;
    loadingVisible = false;
    stockactionstatenewtocompleted: string = "";

    // ***** Method declarations start *****
    store: Array<Store> = new Array<Store>();
    filterStore: Array<Guid> = new Array<Guid>();
    budget: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    filterBudget: Array<Guid> = new Array<Guid>();
    tagBoxDisabled: boolean = false;
    inputStore: Store;
    public setInputParam(value: Store) {
        if (value != null) {
            if (value.ObjectDefID.toString() === PharmacyStoreDefinition.ObjectDefID.id)
                this.inputStore = value;
        }
    }

    showLoadPanel: boolean = false;
    LoadPanelMessage: string = "Listeleniyor...";
    public async TTGetDrugButton_Click(): Promise<void> {
        this.showLoadPanel = true;
        this.loadingVisible = true;
        this.buttonDisabled = true;
        this._ReviewAction.ReviewActionDetails = new Array<ReviewActionDetail>();
        let reviewActionDetailOutput: ReviewActionService_Output = await ReviewActionService.GetDrugOrder(<Date>this._ReviewAction.StartDate, <Date>this._ReviewAction.EndDate, this._ReviewAction, this.filterStore, this.filterBudget);
        if (reviewActionDetailOutput != null) {
            for (let dvo of reviewActionDetailOutput.ReviewActionDetails) {
                let guidMaterial: Guid = new Guid(dvo["Material"].toString());
                dvo.Material = await this.objectContextService.getObject<Material>(guidMaterial, Material.ObjectDefID);
                this.reviewActionNewFormViewModel.ReviewActionDetailsGridList.push(dvo);
                this._ReviewAction.ReviewActionDetails.push(dvo);
            }

            this.reviewActionNewFormViewModel._ReviewAction.ReviewActionPatientDets = new Array<ReviewActionPatientDet>();
            for (let patientDet of reviewActionDetailOutput.ReviewActionPatientDets) {
                this.reviewActionNewFormViewModel._ReviewAction.ReviewActionPatientDets.push(patientDet);
                this.reviewActionNewFormViewModel.ReviewActionPatientDetsGridList.push(patientDet);
            }
            this.reviewActionNewFormViewModel.StockCollectedTrxs = new Array<StockCollectedTrx>();
            for (let coltrx of reviewActionDetailOutput.StockCollectedTrxs) {
                this.reviewActionNewFormViewModel.StockCollectedTrxs.push(coltrx);
            }
            this.StartDate.ReadOnly = true;
            this.EndDate.ReadOnly = true;
            this.TTGetDrugButton.ReadOnly = true;
            this.StartDate.BackColor = "#F0F0F0";
            this.EndDate.BackColor = "#F0F0F0";
            this.TTGetDrugButton.BackColor = "#F0F0F0";
            this.tagBoxDisabled = true;
            this._ReviewAction.Description = reviewActionDetailOutput.filterDescription;
            this.ReviewActionType.ReadOnly = true;
        }
        this.loadingVisible = false;
        this.showLoadPanel = false;
    }

    public Clear() {
        this.buttonDisabled = false;
        this.reviewActionNewFormViewModel.ReviewActionDetailsGridList = new Array<ReviewActionDetail>();
        this._ReviewAction.ReviewActionDetails = new Array<ReviewActionDetail>();
        this.reviewActionNewFormViewModel._ReviewAction.ReviewActionPatientDets = new Array<ReviewActionPatientDet>();
        this.reviewActionNewFormViewModel.ReviewActionPatientDetsGridList = new Array<ReviewActionPatientDet>();
        this.reviewActionNewFormViewModel.StockCollectedTrxs = new Array<StockCollectedTrx>();
        this.StartDate.ReadOnly = false;
        this.EndDate.ReadOnly = false;
        this.TTGetDrugButton.ReadOnly = false;
        this.StartDate.BackColor = "#FFE3C6";
        this.EndDate.BackColor = "#FFE3C6";
        //this.TTGetDrugButton.BackColor = "#FFE3C6";
        this.tagBoxDisabled = false;
        this._ReviewAction.Description = '';
        this.ReviewActionType.ReadOnly = false;
    }


    protected async PreScript() {
        await super.PreScript();

        //this.stockactionstatenewtocompleted = (await SystemParameterService.GetParameterValue('STOCKACTIONSTATENEWTOCOMPLETED', 'TRUE'));
        //if (this.stockactionstatenewtocompleted === 'TRUE') {
        this.DropStateButton(ReviewAction.ReviewActionStates.Approval);
        //}

        let dateStart: Date = new Date();
        dateStart.setHours(0, 0, 0);
        let dateEnd: Date = new Date();
        dateEnd.setHours(23, 59, 59);
        this.reviewActionNewFormViewModel._ReviewAction.StartDate = dateStart;
        this.reviewActionNewFormViewModel._ReviewAction.EndDate = dateEnd;
        this._ReviewAction.StartDate = dateStart;
        this._ReviewAction.EndDate = dateEnd;
        this._ReviewAction.ReviewActionType = ReviewActionTypeEnum.Kschedule;
        if (this._ReviewAction.Store == null) {
            this._ReviewAction.Store = this.inputStore;
            await this.SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.Nothing);
        }

        let that = this;
        that._ReviewAction.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
        that._ReviewAction.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckTuketimYatanHastaTedavisi;


    }


    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        if (transDef != null) {
            super.AfterContextSavedScript(transDef);
            if (this._ReviewAction.CurrentStateDefID.toString() === ReviewAction.StockActionStates.Completed.id) {
                let documentRecordLogs: any = await StockActionService.GetDocumentRecordLogs(this._ReviewAction.ObjectID.toString());
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

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ReviewAction();
        this.reviewActionNewFormViewModel = new ReviewActionNewFormViewModel();
        this._ViewModel = this.reviewActionNewFormViewModel;
        this.reviewActionNewFormViewModel._ReviewAction = this._TTObject as ReviewAction;
        this.reviewActionNewFormViewModel._ReviewAction.ReviewActionDetails = new Array<ReviewActionDetail>();
        this.reviewActionNewFormViewModel._ReviewAction.Store = new Store();
        this.reviewActionNewFormViewModel._ReviewAction.ReviewActionPatientDets = new Array<ReviewActionPatientDet>();
    }

    protected loadViewModel() {
        let that = this;

        that.reviewActionNewFormViewModel = this._ViewModel as ReviewActionNewFormViewModel;
        that._TTObject = this.reviewActionNewFormViewModel._ReviewAction;
        if (this.reviewActionNewFormViewModel == null)
            this.reviewActionNewFormViewModel = new ReviewActionNewFormViewModel();
        if (this.reviewActionNewFormViewModel._ReviewAction == null)
            this.reviewActionNewFormViewModel._ReviewAction = new ReviewAction();
        that.reviewActionNewFormViewModel._ReviewAction.ReviewActionDetails = that.reviewActionNewFormViewModel.ReviewActionDetailsGridList;
        that.reviewActionNewFormViewModel._ReviewAction.ReviewActionPatientDets = that.reviewActionNewFormViewModel.ReviewActionPatientDetsGridList;
        for (let detailItem of that.reviewActionNewFormViewModel.ReviewActionDetailsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === 'string')) {
                let material = that.reviewActionNewFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === 'string')) {
                        let stockCard = that.reviewActionNewFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === 'string')) {
                                let distributionType = that.reviewActionNewFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
        }
        let storeObjectID = that.reviewActionNewFormViewModel._ReviewAction["Store"];
        if (storeObjectID != null && (typeof storeObjectID === 'string')) {
            let store = that.reviewActionNewFormViewModel.Stores.find(o => o.ObjectID.toString() === storeObjectID.toString());
            if (store) {
                that.reviewActionNewFormViewModel._ReviewAction.Store = store;
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(ReviewActionNewFormViewModel);
        if (this._ReviewAction.MKYS_TeslimAlanObjID != null) {
            this.MKYS_TeslimAlan.BackColor = "#F0F0F0";
            this.MKYS_TeslimAlan.ReadOnly = true;
        }
        if (this._ReviewAction.MKYS_TeslimEdenObjID != null) {
            this.MKYS_TeslimEden.BackColor = "#F0F0F0";
            this.MKYS_TeslimEden.ReadOnly = true;
        }
        if (this._ReviewAction.ReviewActionDetails.length > 0) {
            this.TTGetDrugButton.ReadOnly = true;
            this.TTGetDrugButton.BackColor = "#F0F0F0";
            this.StartDate.ReadOnly = true;
            this.StartDate.BackColor = "#F0F0F0";
            this.EndDate.ReadOnly = true;
            this.EndDate.BackColor = "#F0F0F0";
        }
        this.FormCaption = "İlaç İcmal ( Yeni )";
        this.changeDetectorRef.detectChanges();

        let filterList: GetFiliterList_Output = await ReviewActionService.GetFiliterList();
        this.store = filterList.stores;
        this.budget = filterList.budgets;
    }


    public onActionDateChanged(event): void {
        if (event != null) {
            let dateNow: Date = new Date();
            if (this._ReviewAction != null && this._ReviewAction.ActionDate !== event) {
                if (event.getTime() <= dateNow.getTime()) {
                    this._ReviewAction.ActionDate = event;
                    this._ReviewAction.TransactionDate = event;
                    this.reviewActionNewFormViewModel._ReviewAction.TransactionDate = event;
                } else {
                    ServiceLocator.MessageService.showError(i18n("M16402", "İleri Tarihe giriş yapılamaz."));
                    this._ReviewAction.ActionDate = dateNow;
                    this._ReviewAction.TransactionDate = dateNow;
                    this.reviewActionNewFormViewModel._ReviewAction.TransactionDate = dateNow;
                }
            }
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Description !== event) {
                this._ReviewAction.Description = event;
            }
        }
    }

    public onEndDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.EndDate !== event) {
                this._ReviewAction.EndDate = event;
            }
        }
    }

    public onMKYS_CikisIslemTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisIslemTuru !== event) {
                this._ReviewAction.MKYS_CikisIslemTuru = event;
            }
        }
    }

    public onMKYS_CikisStokHareketTuruChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_CikisStokHareketTuru !== event) {
                this._ReviewAction.MKYS_CikisStokHareketTuru = event;
            }
        }
    }

    public onReviewActionTypeChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.ReviewActionType !== event) {
                this._ReviewAction.ReviewActionType = event;
            }
        }
    }

    public onMKYS_TeslimAlanChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimAlan !== event) {
                this._ReviewAction.MKYS_TeslimAlan = event;
            }
        }
    }

    public onMKYS_TeslimEdenChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.MKYS_TeslimEden !== event) {
                this._ReviewAction.MKYS_TeslimEden = event;
            }
        }
    }

    public onStartDateChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StartDate !== event) {
                this._ReviewAction.StartDate = event;
            }
        }
    }

    public onStockActionIDChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.StockActionID !== event) {
                this._ReviewAction.StockActionID = event;
            }
        }
    }

    public onStoreChanged(event): void {
        if (event != null) {
            if (this._ReviewAction != null && this._ReviewAction.Store !== event) {
                this._ReviewAction.Store = event;
            }
        }
    }


    ReviewActionDetails_CellValueChangedEmitted(data: any) {
        if (data && this.ReviewActionDetails_CellValueChanged && data.Row && data.Column) {
            this.ReviewActionDetails_CellValueChanged(data, data.RowIndex, data.ColIndex);
        }
    }
    onSelectionChange(data: any) {
    }
    public async ReviewActionDetails_CellValueChanged(data: any, rowIndex: number, columnIndex: number): Promise<void> {
        await super.ReviewActionDetails_CellValueChanged(data, rowIndex, columnIndex);
    }
    onRowInserting(data: any) {
    }
    onCellContentClicked(data: any) {
    }
    async initNewRow(data: any) {
    }





    public redirectProperties(): void {
        redirectProperty(this.StockActionID, "Text", this.__ttObject, "StockActionID");
        redirectProperty(this.ActionDate, "Value", this.__ttObject, "ActionDate");
        redirectProperty(this.StartDate, "Value", this.__ttObject, "StartDate");
        redirectProperty(this.EndDate, "Value", this.__ttObject, "EndDate");
        redirectProperty(this.MKYS_CikisIslemTuru, "Value", this.__ttObject, "MKYS_CikisIslemTuru");
        redirectProperty(this.MKYS_CikisStokHareketTuru, "Value", this.__ttObject, "MKYS_CikisStokHareketTuru");
        redirectProperty(this.ReviewActionType, "Value", this.__ttObject, "ReviewActionType");
        redirectProperty(this.MKYS_TeslimAlan, "Text", this.__ttObject, "MKYS_TeslimAlan");
        redirectProperty(this.MKYS_TeslimEden, "Text", this.__ttObject, "MKYS_TeslimEden");
        redirectProperty(this.Description, "Text", this.__ttObject, "Description");
    }

    public initFormControls(): void {
        this.TTGetDrugButton = new TTVisual.TTButton();
        this.TTGetDrugButton.Text = "Listele";
        this.TTGetDrugButton.Name = "TTGetDrugButton";
        this.TTGetDrugButton.TabIndex = 128;

        this.ClearButton = new TTVisual.TTButton();
        this.ClearButton.Text = "Temizle";
        this.ClearButton.Name = "ClearButton";
        this.ClearButton.TabIndex = 128;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 127;

        this.ReviewActionTabPanel = new TTVisual.TTTabPage();
        this.ReviewActionTabPanel.DisplayIndex = 0;
        this.ReviewActionTabPanel.TabIndex = 0;
        this.ReviewActionTabPanel.Text = "Taşınır Malın";
        this.ReviewActionTabPanel.Name = "ReviewActionTabPanel";

        this.ReviewActionDetails = new TTVisual.TTGrid();
        this.ReviewActionDetails.Name = "ReviewActionDetails";
        this.ReviewActionDetails.TabIndex = 126;
        this.ReviewActionDetails.Height = 350;
        this.ReviewActionDetails.AllowUserToDeleteRows = false;
        this.ReviewActionDetails.AllowUserToAddRows = false;

        this.MaterialRewiewActionDetail = new TTVisual.TTListBoxColumn();
        this.MaterialRewiewActionDetail.ListDefName = "DrugList";
        this.MaterialRewiewActionDetail.DataMember = "Material";
        this.MaterialRewiewActionDetail.DisplayIndex = 0;
        this.MaterialRewiewActionDetail.HeaderText = i18n("M16287", "İlaç");
        this.MaterialRewiewActionDetail.Name = "MaterialRewiewActionDetail";
        this.MaterialRewiewActionDetail.ReadOnly = true;
        this.MaterialRewiewActionDetail.Width = 400;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Material.Barcode";
        this.Barcode.DisplayIndex = 1;
        this.Barcode.HeaderText = "Barkod";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 120;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "Material.DistributionTypeName";
        this.DistributionType.DisplayIndex = 2;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 120;

        this.AmountRewiewActionDetail = new TTVisual.TTTextBoxColumn();
        this.AmountRewiewActionDetail.DataMember = "Amount";
        this.AmountRewiewActionDetail.DisplayIndex = 3;
        this.AmountRewiewActionDetail.HeaderText = i18n("M19030", "Miktar");
        this.AmountRewiewActionDetail.Name = "AmountRewiewActionDetail";
        this.AmountRewiewActionDetail.ReadOnly = true;
        this.AmountRewiewActionDetail.Width = 120;
        this.AmountRewiewActionDetail.IsNumeric = true;

        this.PatinetName = new TTVisual.TTTextBoxColumn();
        this.PatinetName.DataMember = "Patient";
        this.PatinetName.DisplayIndex = 4;
        this.PatinetName.HeaderText = i18n("M15131", "Hasta Adı");
        this.PatinetName.Name = "PatinetName";
        this.PatinetName.ReadOnly = true;
        this.PatinetName.Width = 180;

        this.PatientUniqurefNo = new TTVisual.TTTextBoxColumn();
        this.PatientUniqurefNo.DataMember = "UniqueRefNo";
        this.PatientUniqurefNo.DisplayIndex = 5;
        this.PatientUniqurefNo.HeaderText = "Hasta TCK No";
        this.PatientUniqurefNo.Name = "PatientUniqurefNo";
        this.PatientUniqurefNo.ReadOnly = true;
        this.PatientUniqurefNo.Width = 120;

        this.ClinicName = new TTVisual.TTTextBoxColumn();
        this.ClinicName.DataMember = "Clinic";
        this.ClinicName.DisplayIndex = 6;
        this.ClinicName.HeaderText = i18n("M12031", "Bölüm");
        this.ClinicName.Name = "ClinicName";
        this.ClinicName.ReadOnly = true;
        this.ClinicName.Width = 180;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Name = "Description";
        this.Description.TabIndex = 122;
        this.Description.ReadOnly = true;

        this.MKYS_TeslimEden = new TTButtonTextBox();
        this.MKYS_TeslimEden.Required = true;
        this.MKYS_TeslimEden.BackColor = "#FFE3C6";
        this.MKYS_TeslimEden.Name = "MKYS_TeslimEden";
        this.MKYS_TeslimEden.TabIndex = 14;

        this.MKYS_TeslimAlan = new TTButtonTextBox();
        this.MKYS_TeslimAlan.Required = true;
        this.MKYS_TeslimAlan.BackColor = "#FFE3C6";
        this.MKYS_TeslimAlan.Name = "MKYS_TeslimAlan";
        this.MKYS_TeslimAlan.TabIndex = 12;

        this.StockActionID = new TTVisual.TTTextBox();
        this.StockActionID.BackColor = "#F0F0F0";
        this.StockActionID.ReadOnly = true;
        this.StockActionID.Name = "StockActionID";
        this.StockActionID.TabIndex = 4;

        this.labelStore = new TTVisual.TTLabel();
        this.labelStore.Text = i18n("M12615", "Depo");
        this.labelStore.Name = "labelStore";
        this.labelStore.TabIndex = 125;

        this.Store = new TTVisual.TTObjectListBox();
        this.Store.ReadOnly = true;
        this.Store.ListDefName = "MainStoreList";
        this.Store.Name = "Store";
        this.Store.TabIndex = 124;

        this.labelDescription = new TTVisual.TTLabel();
        this.labelDescription.Text = i18n("M10469", "Açıklama");
        this.labelDescription.Name = "labelDescription";
        this.labelDescription.TabIndex = 123;

        this.labelMKYS_TeslimEden = new TTVisual.TTLabel();
        this.labelMKYS_TeslimEden.Text = i18n("M23231", "Teslim Eden");
        this.labelMKYS_TeslimEden.Name = "labelMKYS_TeslimEden";
        this.labelMKYS_TeslimEden.TabIndex = 15;

        this.labelMKYS_TeslimAlan = new TTVisual.TTLabel();
        this.labelMKYS_TeslimAlan.Text = i18n("M23224", "Teslim Alan");
        this.labelMKYS_TeslimAlan.Name = "labelMKYS_TeslimAlan";
        this.labelMKYS_TeslimAlan.TabIndex = 13;

        this.labelMKYS_CikisStokHareketTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisStokHareketTuru.Text = i18n("M12372", "Çıkış Hareket Türü");
        this.labelMKYS_CikisStokHareketTuru.Name = "labelMKYS_CikisStokHareketTuru";
        this.labelMKYS_CikisStokHareketTuru.TabIndex = 11;

        this.MKYS_CikisStokHareketTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisStokHareketTuru.DataTypeName = "MKYS_ECikisStokHareketTurEnum";
        this.MKYS_CikisStokHareketTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisStokHareketTuru.Enabled = false;
        this.MKYS_CikisStokHareketTuru.Name = "MKYS_CikisStokHareketTuru";
        this.MKYS_CikisStokHareketTuru.TabIndex = 10;


        this.labelReviewActionType = new TTVisual.TTLabel();
        this.labelReviewActionType.Text = "İcmal Tipi";
        this.labelReviewActionType.Name = "labelReviewActionType";
        this.labelReviewActionType.TabIndex = 11;

        this.ReviewActionType = new TTVisual.TTEnumComboBox();
        this.ReviewActionType.DataTypeName = "ReviewActionTypeEnum";
        this.ReviewActionType.BackColor = "#F0F0F0";
        this.ReviewActionType.Enabled = true;
        this.ReviewActionType.Name = "ReviewActionType";
        this.ReviewActionType.TabIndex = 10;

        this.labelMKYS_CikisIslemTuru = new TTVisual.TTLabel();
        this.labelMKYS_CikisIslemTuru.Text = i18n("M12365", "Çıkış  Türü");
        this.labelMKYS_CikisIslemTuru.Name = "labelMKYS_CikisIslemTuru";
        this.labelMKYS_CikisIslemTuru.TabIndex = 9;

        this.MKYS_CikisIslemTuru = new TTVisual.TTEnumComboBox();
        this.MKYS_CikisIslemTuru.DataTypeName = "MKYS_ECikisIslemTuruEnum";
        this.MKYS_CikisIslemTuru.BackColor = "#F0F0F0";
        this.MKYS_CikisIslemTuru.Enabled = false;
        this.MKYS_CikisIslemTuru.Name = "MKYS_CikisIslemTuru";
        this.MKYS_CikisIslemTuru.TabIndex = 8;

        this.labelActionDate = new TTVisual.TTLabel();
        this.labelActionDate.Text = i18n("M16886", "İşlem Tarihi");
        this.labelActionDate.Name = "labelActionDate";
        this.labelActionDate.TabIndex = 7;

        this.ActionDate = new TTVisual.TTDateTimePicker();
        // this.ActionDate.BackColor = "#F0F0F0";
        this.ActionDate.Format = DateTimePickerFormat.Long;
        this.ActionDate.Name = "ActionDate";
        this.ActionDate.TabIndex = 6;
        this.ActionDate.ReadOnly = false;

        this.labelStockActionID = new TTVisual.TTLabel();
        this.labelStockActionID.Text = i18n("M16866", "İşlem No");
        this.labelStockActionID.Name = "labelStockActionID";
        this.labelStockActionID.TabIndex = 5;

        this.labelEndDate = new TTVisual.TTLabel();
        this.labelEndDate.Text = i18n("M11939", "Bitiş Tarihi");
        this.labelEndDate.Name = "labelEndDate";
        this.labelEndDate.TabIndex = 3;

        this.EndDate = new TTVisual.TTDateTimePicker();
        this.EndDate.Format = DateTimePickerFormat.Long;
        this.EndDate.Name = "EndDate";
        this.EndDate.TabIndex = 2;

        this.labelStartDate = new TTVisual.TTLabel();
        this.labelStartDate.Text = i18n("M11637", "Başlangıç Tarihi");
        this.labelStartDate.Name = "labelStartDate";
        this.labelStartDate.TabIndex = 1;

        this.StartDate = new TTVisual.TTDateTimePicker();
        this.StartDate.Format = DateTimePickerFormat.Long;
        this.StartDate.Name = "StartDate";
        this.StartDate.TabIndex = 0;

        this.TTTeslimEdenButon = new TTVisual.TTButton();
        this.TTTeslimEdenButon.Text = "TE";
        this.TTTeslimEdenButon.Name = "TTTeslimEdenButon";
        this.TTTeslimEdenButon.TabIndex = 121;

        this.TTTeslimAlanButon = new TTVisual.TTButton();
        this.TTTeslimAlanButon.Text = "TA";
        this.TTTeslimAlanButon.Name = "TTTeslimAlanButon";
        this.TTTeslimAlanButon.TabIndex = 120;

        this.StoreName = new TTVisual.TTTextBoxColumn();
        this.StoreName.DataMember = "StoreName";
        this.StoreName.DisplayIndex = 6;
        this.StoreName.HeaderText = i18n("M12031", "Bölüm");
        this.StoreName.Name = "StoreName";
        this.StoreName.ReadOnly = true;
        this.StoreName.Width = 300;

        this.UnitPrice = new TTVisual.TTTextBoxColumn();
        this.UnitPrice.DataMember = "UnitPrice";
        this.UnitPrice.DisplayIndex = 6;
        this.UnitPrice.HeaderText = i18n("M11855", "Birim Fiyat");
        this.UnitPrice.Name = "UnitPrice";
        this.UnitPrice.ReadOnly = true;
        this.UnitPrice.Width = 100;

        this.ReviewActionDetailsColumns = [this.MaterialRewiewActionDetail, this.Barcode, this.DistributionType, this.AmountRewiewActionDetail, this.StoreName, this.UnitPrice];
        this.tttabcontrol1.Controls = [this.ReviewActionTabPanel];
        this.ReviewActionTabPanel.Controls = [this.ReviewActionDetails];
        this.Controls = [this.TTGetDrugButton, this.ClearButton, this.tttabcontrol1, this.ReviewActionTabPanel, this.ReviewActionDetails, this.MaterialRewiewActionDetail,
        this.Barcode, this.DistributionType, this.AmountRewiewActionDetail, this.PatinetName, this.PatientUniqurefNo, this.ClinicName, this.Description,
        this.MKYS_TeslimEden, this.MKYS_TeslimAlan, this.StockActionID, this.labelStore, this.Store, this.labelDescription, this.labelMKYS_TeslimEden,
        this.labelMKYS_TeslimAlan, this.labelMKYS_CikisStokHareketTuru, this.MKYS_CikisStokHareketTuru, this.labelReviewActionType, this.ReviewActionType, this.labelMKYS_CikisIslemTuru, this.MKYS_CikisIslemTuru,
        this.labelActionDate, this.ActionDate, this.labelStockActionID, this.labelEndDate, this.EndDate, this.labelStartDate, this.StartDate,
        this.TTTeslimEdenButon, this.TTTeslimAlanButon];

    }


}
