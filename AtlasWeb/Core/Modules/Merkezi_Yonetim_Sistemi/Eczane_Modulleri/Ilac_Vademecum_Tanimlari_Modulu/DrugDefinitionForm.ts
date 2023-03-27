//$E31F4EE6
import { Component, ViewChild } from '@angular/core';
import { Http, Headers, Response, RequestOptions, ResponseContentType } from '@angular/http';
import { DrugDefinitionFormViewModel, DefinitionOutTrxDVO, ATCDVO, HospitalInventoryDVO, DefinitionInTrxDVO, QueryInputDVO, GetReport, EquivalentMaterial, DrugSpecification_Input, GetStockLocation_Input, SaveShelfAndRowOnStock_Input, StoreLocationInformation_Input, UploadFile_Input, MaterialProcedures_Output, ProcedureDefinition_Output, Material_Output, FirstInStockUnitePrice, FirstIN_Input, pricePatienList, pricePatientOutputDTO, RepaitUnUpdate_Intput, LoadModelComponent_Input, LoadModelComponent, OpenLogisticDocumentInputParams, MaxDoseByDrugDef } from './DrugDefinitionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { DrugDefinition, ProductDefinition, DrugReportType, PrescriptionTypeEnum, SexEnum, AntibioticTypeEnum, ATC, Stock, MaterialDocumentation, ProcedureDefinition, ActiveIngredientDefinition, MaterialSpecialty, InteractionLevelTypeEnum, DrugDrugInteraction, DrugFoodInteraction, MaterialPatientTypeEnum, MaterialDocumentType, MaterialDescriptionShowTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ManuelEquivalentDrug } from 'NebulaClient/Model/AtlasClientModel';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { PricingDetailDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTObject } from 'NebulaClient/StorageManager/InstanceManagement/TTObject';
import { TTObjectContext } from 'NebulaClient/StorageManager/InstanceManagement/TTObjectContext';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DrugActiveIngredient } from 'NebulaClient/Model/AtlasClientModel';
import { DrugATC } from 'NebulaClient/Model/AtlasClientModel';
import { DrugLabProcInteraction } from 'NebulaClient/Model/AtlasClientModel';
import { DrugRelation } from 'NebulaClient/Model/AtlasClientModel';
import { DrugSpecifications } from 'NebulaClient/Model/AtlasClientModel';
import { EtkinMadde } from 'NebulaClient/Model/AtlasClientModel';
import { GenericDrug } from 'NebulaClient/Model/AtlasClientModel';
import { GMDNDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialVatRate } from 'NebulaClient/Model/AtlasClientModel';
import { NFC } from 'NebulaClient/Model/AtlasClientModel';
import { Producer } from 'NebulaClient/Model/AtlasClientModel';
import { RouteOfAdmin } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { UnitDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { ITTControlBase } from 'app/NebulaClient/Visual/ControlInterfaces/ITTControlBase';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { DrugSpecificationEnum } from 'NebulaClient/Model/AtlasClientModel';
import { UploadedDocument } from 'NebulaClient/Model/AtlasClientModel';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { IModal, ModalActionResult, ModalInfo, ModalStateService } from "Fw/Models/ModalInfo";
import { CommonHelper } from 'app/Helper/CommonHelper';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { IModalService } from "Fw/Services/IModalService";
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { StockService } from 'app/NebulaClient/Services/ObjectService/StockService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { MaterialProcedures } from 'NebulaClient/Model/AtlasClientModel';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { TransactionChartInputDTO, StockGiris, StockCikis, StockGirisDetay, StockCikisDetay } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { NeResult } from 'app/NebulaClient/Utils/NeResult';
import { DocumentGridModel } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticDocumentUploadForm';
import { TTObjectStateTransitionDef } from 'app/NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTException } from 'app/NebulaClient/Utils/Exceptions/TTException';

@Component({
    selector: 'DrugDefinitionForm',
    templateUrl: './DrugDefinitionForm.html',

    providers: [MessageService]
})

export class DrugDefinitionForm extends TTVisual.TTForm {
    Controls: Array<ITTControlBase>;
    ActiveIngredient: TTVisual.ITTListBoxColumn;
    AllowToGivePatient: TTVisual.ITTCheckBox;
    ATC: TTVisual.ITTListBoxColumn;
    Barcode: TTVisual.ITTTextBox;
    BarcodeName: TTVisual.ITTTextBox;
    Brans: TTVisual.ITTObjectListBox;
    btnCalculate: TTVisual.ITTButton;
    Chargable: TTVisual.ITTCheckBox;
    cmdAddEquiv: TTVisual.ITTButton;
    cmdChangeTypeToConsumableButton: TTVisual.ITTButton;
    Code: TTVisual.ITTTextBox;
    Color: TTVisual.ITTEnumComboBox;
    DrugSpecification: TTVisual.ITTEnumComboBoxColumn;
    CreateInMedulaDontSendState: TTVisual.ITTCheckBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    CurrencyType: TTVisual.ITTListBoxColumn;
    CurrentPrice: TTVisual.ITTTextBox;
    InstitutionDiscountRate: TTVisual.ITTTextBox;
    PharmacistDiscountRate: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    DescriptionTabPage: TTVisual.ITTTabPage;
    DistributionTypeStockCard: TTVisual.ITTObjectListBox;
    DividePriceToVolume: TTVisual.ITTCheckBox;
    Dose: TTVisual.ITTTextBox;
    DrugActiveIngredients: TTVisual.ITTGrid;
    DrugATCs: TTVisual.ITTGrid;
    DrugSpecificationGrid: TTVisual.ITTGrid;
    DrugLabIntTabPage: TTVisual.ITTTabPage;
    DrugLabProcInteractions: TTVisual.ITTGrid;
    DrugDrugInteractions: TTVisual.ITTGrid;
    DrugFoodInteractions: TTVisual.ITTGrid;
    DrugNutrientInteraction: TTVisual.ITTTextBox;
    DrugRelations: TTVisual.ITTGrid;
    DrugSpecifications: TTVisual.ITTTabPage;
    Ek2EquivalentTabPage: TTVisual.ITTTabPage;
    EndDate: TTVisual.ITTDateTimePickerColumn;
    EquivalentDrugManuelEquivDrug: TTVisual.ITTListBoxColumn;
    EquivalentDrugName: TTVisual.ITTTextBoxColumn;
    EquivalentsGrid: TTVisual.ITTGrid;
    EquivalentTabPage: TTVisual.ITTTabPage;
    EstimatedTimeOfCheck: TTVisual.ITTTextBox;
    EtkinMadde: TTVisual.ITTObjectListBox;
    ETKMDescription: TTVisual.ITTTextBox;
    ETKMDescriptionTabPage: TTVisual.ITTTabPage;
    FormulaMaxDose: TTVisual.ITTTextBoxColumn;
    FormuleTabPage: TTVisual.ITTTabPage;
    Frequency: TTVisual.ITTEnumComboBox;
    gbxAmountPrice: TTVisual.ITTGroupBox;
    GenericDrug: TTVisual.ITTObjectListBox;
    GMDNCodeStockCard: TTVisual.ITTObjectListBox;
    grdDrugSpecification: TTVisual.ITTGrid;
    IsActive: TTVisual.ITTCheckBox;
    IsArmyDrug: TTVisual.ITTCheckBox;
    IsExpendableMaterial: TTVisual.ITTCheckBox;
    IsNarcotic: TTVisual.ITTCheckBox;
    IsOldMaterial: TTVisual.ITTCheckBox;
    IsPackageExclusive: TTVisual.ITTCheckBox;
    IsParentIngredient: TTVisual.ITTCheckBoxColumn;
    IsPsychotropic: TTVisual.ITTCheckBox;
    KDVTabPage: TTVisual.ITTTabPage;
    labelBarcode: TTVisual.ITTLabel;
    labelBarcodeName: TTVisual.ITTLabel;
    labelBrans: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelColor: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelCurrentPrice: TTVisual.ITTLabel;
    labelDistributionTypeStockCard: TTVisual.ITTLabel;
    labelDose: TTVisual.ITTLabel;
    labelDrugNutrientInteraction: TTVisual.ITTLabel;
    labelEnglishName: TTVisual.ITTLabel;
    labelEstimatedTimeOfCheck: TTVisual.ITTLabel;
    labelEtkinMadde: TTVisual.ITTLabel;
    labelFrequency: TTVisual.ITTLabel;
    labelGenericDrug: TTVisual.ITTLabel;
    labelGMDNCodeStockCard: TTVisual.ITTLabel;
    labelLicenceDate: TTVisual.ITTLabel;
    labelLicenceNO: TTVisual.ITTLabel;
    labelLicencingOrganization: TTVisual.ITTLabel;
    labelMaterialPricingType: TTVisual.ITTLabel;
    labelMaterialTree: TTVisual.ITTLabel;
    labelMaxDose: TTVisual.ITTLabel;
    labelMaxDoseDay: TTVisual.ITTLabel;
    labelMkysMalzemeKodu: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelNFC: TTVisual.ITTLabel;
    labelOrderRPTDay: TTVisual.ITTLabel;
    labelPackageAmount: TTVisual.ITTLabel;
    labelPrescriptionType: TTVisual.ITTLabel;
    labelProducer: TTVisual.ITTLabel;
    labelProductNumber: TTVisual.ITTLabel;
    labelPurchaseDate: TTVisual.ITTLabel;
    labelRouteOfAdmin: TTVisual.ITTLabel;
    labelRoutineDay: TTVisual.ITTLabel;
    labelRoutineDose: TTVisual.ITTLabel;
    labelStockCard: TTVisual.ITTLabel;
    labelStorageConditions: TTVisual.ITTLabel;
    labelVolume: TTVisual.ITTLabel;
    labelVolumeUnit: TTVisual.ITTLabel;
    LaboratoryTestDefinitionDrugLabProcInteraction: TTVisual.ITTListBoxColumn;
    DrugDefinitionDrugDrugInteraction: TTVisual.ITTListBoxColumn;
    DrugDefinitionDrugFoodInteraction: TTVisual.ITTListBoxColumn;
    lblAmountMultiplier: TTVisual.ITTLabel;
    lblMedulaMultiplier: TTVisual.ITTLabel;
    lblTestAmount: TTVisual.ITTLabel;
    lblUnitPriceDivider: TTVisual.ITTLabel;
    LicenceDate: TTVisual.ITTDateTimePicker;
    LicenceNO: TTVisual.ITTTextBox;
    LicencingOrganization: TTVisual.ITTEnumComboBox;
    ManuelEquivalentDrugs: TTVisual.ITTGrid;
    ManuelEquivalentTabPage: TTVisual.ITTTabPage;
    MaterialPriceGrid: TTVisual.ITTGrid;
    MaterialPricingType: TTVisual.ITTEnumComboBox;
    MaterialTree: TTVisual.ITTObjectListBox;
    MaterialVatRates: TTVisual.ITTGrid;
    MaxDose: TTVisual.ITTTextBox;
    MaxDoseDay: TTVisual.ITTTextBox;
    MaxDoseUnit: TTVisual.ITTListBoxColumn;
    MaxValueDrugLabProcInteraction: TTVisual.ITTTextBoxColumn;
    MedulaMultiplier: TTVisual.ITTTextBox;
    MessageDrugLabProcInteraction: TTVisual.ITTTextBoxColumn;
    MinValueDrugLabProcInteraction: TTVisual.ITTTextBoxColumn;
    MkysMalzemeKodu: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    NFC: TTVisual.ITTObjectListBox;
    OrderRPTDay: TTVisual.ITTTextBox;
    OriginalName: TTVisual.ITTTextBox;
    PackageAmount: TTVisual.ITTTextBox;
    PatientSafetyFrom: TTVisual.ITTCheckBox;
    PrescriptionType: TTVisual.ITTEnumComboBox;
    OutpatientReportTypeItem: TTVisual.ITTEnumComboBox;
    Price: TTVisual.ITTTextBoxColumn;
    PriceCode: TTVisual.ITTTextBoxColumn;
    PriceDesc: TTVisual.ITTTextBoxColumn;
    PricingList: TTVisual.ITTListBoxColumn;
    Producer: TTVisual.ITTObjectListBox;
    ProductionTabPage: TTVisual.ITTTabPage;
    ProductNumber: TTVisual.ITTTextBox;
    PropertyTabPage: TTVisual.ITTTabPage;
    PurchaseDate: TTVisual.ITTDateTimePicker;
    ReimbursementUnder: TTVisual.ITTCheckBox;
    RelationDrugDrugRelation: TTVisual.ITTListBoxColumn;
    RouteOfAdmin: TTVisual.ITTObjectListBox;
    RoutineDay: TTVisual.ITTTextBox;
    RoutineDose: TTVisual.ITTTextBox;
    searchMedicineFromMedula: TTVisual.ITTButton;
    SendSMS: TTVisual.ITTCheckBox;
    PaidPayment: TTVisual.ITTCheckBox;
    NotAppearInEpicrisis: TTVisual.ITTCheckBox;
    DivisibleDrug: TTVisual.ITTCheckBox;
    DoNotLeaveTheBarcode: TTVisual.ITTCheckBox;
    SetMedulaInfoByMultiplier: TTVisual.ITTCheckBox;
    SgkReturnPay: TTVisual.ITTCheckBox;
    SosFarmaCheckBox: TTVisual.ITTCheckBox;
    SpecialistApproval: TTVisual.ITTCheckBox;
    SpecialistDoctorApproval: TTVisual.ITTCheckBox;
    StartDate: TTVisual.ITTDateTimePickerColumn;
    StockCard: TTVisual.ITTObjectListBox;
    StorageConditions: TTVisual.ITTTextBox;
    ttcheckbox1: TTVisual.ITTCheckBox;
    ttcheckbox2: TTVisual.ITTCheckBox;
    ttenumcombobox1: TTVisual.ITTEnumComboBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttextbox1: TTVisual.ITTTextBox;
    tttextbox2: TTVisual.ITTTextBox;
    txtAmountMultiplier: TTVisual.ITTTextBox;
    txtTestAmount: TTVisual.ITTTextBox;
    txtUnitPriceDivider: TTVisual.ITTTextBox;
    Unit: TTVisual.ITTListBoxColumn;
    Value: TTVisual.ITTTextBoxColumn;
    VatRate: TTVisual.ITTTextBoxColumn;
    Volume: TTVisual.ITTTextBox;
    VolumeUnit: TTVisual.ITTObjectListBox;
    WithOutStockInheld: TTVisual.ITTCheckBox;
    docs: Array<UploadedDocument> = new Array<UploadedDocument>();
    grdMaterialProcedures: TTVisual.ITTObjectListBox;
    PatientMaxDayOut: TTVisual.ITTTextBox;
    public documentid: Guid;
    public DrugSpecificationEnumDef;

    public RouteOfAdminDataSoruce: Array<RouteOfAdmin>;
    public NFCDataSoruce: Array<NFC>;
    public SeletedRouteOfAdmin: any;
    public SeletedNFC: any;
    public MaxDoseByDrugDef: MaxDoseByDrugDef = new MaxDoseByDrugDef();
    public DrugActiveIngredientsColumns = [];
    public DrugATCsColumns = [];
    public DrugLabProcInteractionsColumns = [];
    public DrugRelationsColumns = [];
    public EquivalentsGridColumns = [];
    public grdDrugSpecificationColumns = [];
    public ManuelEquivalentDrugsColumns = [];
    public MaterialPriceGridColumns = [];
    public MaterialVatRate;
    public MaterialMedulaMultiplier;
    public costActionAccountingTerm: any;
    public MaterialVatRatesColumns = [];
    public visibility: boolean = false;
    public accountingTermObjId: any;
    public StoreID: Guid;
    public inStockTransactions: Array<DefinitionInTrxDVO>;
    public activeAccountingTerm: any;
    public objectid: Guid;
    public outStockTransactions: Array<DefinitionOutTrxDVO>;
    public drugDefinitionFormViewModel: DrugDefinitionFormViewModel = new DrugDefinitionFormViewModel();
    public ReportsItems;
    public MaterialPatientTypeItems;
    public PrescriptionTypeList;
    public GenderList;
    public loadingVisible: boolean = false;
    SEX: TTVisual.ITTComboBox;
    public AntibioticTypeList;
    public materialTreeDefinitionSource = [];
    public etkinMaddeSource = [];
    public ATCListSource: Array<ATCDVO>;
    public MaterialATC = [];
    public shelfNo: number;
    public rowNo: number;
    public discountPaymentPrice: number;
    public GTINNo: string;
    public WarningDate: string;
    OutpatientReportType: TTVisual.ITTEnumComboBox;
    InpatientReportType: TTVisual.ITTEnumComboBox;
    public selecedDrugSpecification;
    public drugSpecs: DrugSpecifications;
    public etkinvalue: EtkinMadde;
    public selectedInStockTransaction: Array<DefinitionInTrxDVO> = new Array<DefinitionInTrxDVO>();
    public GridDataSource: Array<any> = new Array<any>();
    public drugSpecificationNewArray: Array<DrugSpecifications> = new Array<DrugSpecifications>();
    public drugspecificationNew: DrugSpecifications;
    public loadingVisibleWait: boolean = false;
    ProcedureList: Array<any> = new Array<any>();
    SelectedProcedureList: Array<any> = new Array<any>();
    disabledMaterialPriceByIlacAra: boolean = true;
    disabledPatientExitByOldPrice: boolean = false;
    public DrugPriceList: Array<any> = new Array<any>();
    public DrugInfos: Array<any> = new Array<any>();
    public lastCost: any;
    ConsumptionList: Array<any> = new Array<any>();
    ProducerdataSource: Array<any> = new Array<any>();
    selectedproducer: any;
    MaterialSpecialtyDefinitionMaterialSpecialty: TTVisual.ITTListBoxColumn;
    showPatientPriceForm: boolean = false;
    unUpdatedPatienList: Array<pricePatienList> = new Array<pricePatienList>();
    UpdatedPatienList: Array<pricePatienList> = new Array<pricePatienList>();
    totalUpdatePatientPriceCount: string;
    priceEndDate: Date;
    priceStartDate: Date;
    updatePatientPriceBTN: boolean = true;
    selectedMaterial: any;
    selectedActiveIngredient: any;
    selectedLabMaterial: any;
    selectedDrugMaterial: any;
    selectedFood: any;
    selectedEquivalentMaterial: any;
    equivalentMaterial: ManuelEquivalentDrug = new ManuelEquivalentDrug();
    tempdrug: EquivalentMaterial = new EquivalentMaterial();
    selectedServiceProcedure: any;
    public InputsResult;
    public OutputsResult;
    public HospitalInventoryResult;
    public MontlyReportsResult;
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
    public stockInheld: number;
    showPriceForm: boolean = false;
    FirtInStockUnitePriceList: Array<FirstInStockUnitePrice> = new Array<FirstInStockUnitePrice>();
    lastPrice: string;
    MinimumLevel: number;
    MaximumLevel: number;
    CriticalLevel: number;
    building: any;
    StockLocationShelf: any;
    public StockLocationList: Array<any> = [];
    selectedProducer: any;
    SelectedAtc: any;
    document: UploadFile_Input = new UploadFile_Input();
    docsUpload: Array<UploadFile_Input> = new Array<UploadFile_Input>();
    docsAlerjikUpload: Array<UploadFile_Input> = new Array<UploadFile_Input>();
    totalSize: number = 0;
    public currentItem: MaterialDocumentation;
    public currentItemAlerjik: MaterialDocumentation;
    public currentItemName: string;
    public currentItemNameAlerjik: string;
    selectedDocs: Array<any> = new Array<MaterialDocumentation>();
    private showServiceMultiSelectForm: boolean = false;
    public Services: Array<any> = new Array<any>();
    SelectedConsumptionList: Array<any> = new Array<any>();
    private showMaterialMultiSelectForm: boolean = false;
    private showFeaturedDrugMultiSelectForm: boolean = false;
    public selectedMaterialsText: string = "";
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    public SelectedActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    public ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    public Consumptions: Array<any> = new Array<any>();
    private showConsumptionsMultiSelectForm: boolean = false;
    private showATCMultiSelectForm: boolean = false;
    public ParentStockLocationList: Array<any> = [];
    MaterialPatientTypeSeleceted: any;
    private _unitDefinitionDataSource: Array<UnitDefinition>;
    public get unitDefinitionDataSource(): Array<UnitDefinition> {
        return this._unitDefinitionDataSource;
    }
    public set unitDefinitionDataSource(value: Array<UnitDefinition>) {
        this._unitDefinitionDataSource = value;
    }
    public materialDescriptionShowTypeItems: Array<EnumItem> = MaterialDescriptionShowTypeEnum.Items;
    public isDivideAmountToPatient: boolean = false;
    LoadPanelMessage: string = "İşlemleriniz Yapılıyor Lütfen Bekleyiniz..";
    public get _DrugDefinition(): DrugDefinition {
        return this._TTObject as DrugDefinition;
    }

    public dummyDrugLabProcInteraction = new Array<DrugLabProcInteraction>();



    DrugDefinitionForm_DocumentUrl: string = '/api/DrugDefinitionService/DrugDefinitionForm';
    private _modalInfo: ModalInfo;
    constructor(
        protected httpService: NeHttpService,
        protected modalService: IModalService,
        protected sideBarMenuService: ISidebarMenuService,
        protected activeUserService: IActiveUserService, private modalStateService: ModalStateService, protected messageService: MessageService
        , private http: HttpClient, private http2: AtlasHttpService) {
        super('DRUGDEFINITION', 'DrugDefinitionForm');
        this._DocumentServiceUrl = this.DrugDefinitionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.costActionAccountingTerm = new Array<any>();
        this.sideBarMenuService.onRequestEvent.subscribe((e) => {
            this.loadingVisible = e.loading;
        });
        this.LoadViewModelCompleted.subscribe(() => {
            this.sideBarMenuService.onRequestEvent.emit({ loading: false });
        });
    }

    getProcedureList() {
        let apiUrlForInvoiceTerms: string = '/api/DrugDefinitionService/GetProcedureDefinitionListDefinition';
        this.httpService.post<any>(apiUrlForInvoiceTerms, null).then(
            x => {
                this.ProcedureList = x;
            }).catch(() => {
            });
    }

    public cancel() {
        super.cancel();
    }

    protected async save() {
        this.loadingVisible = true;
        if (this._DrugDefinition.Name == null) {
            ServiceLocator.MessageService.showError("İlaç Adı Zorunlu Alan!");
            this.loadingVisible = false;
            return;
        }
        if (this._DrugDefinition.StockCard == null) {
            ServiceLocator.MessageService.showError("Taşınır Kodu Tanımı Zorunludur!");
            this.loadingVisible = false;
            return;
        }
        if (this._DrugDefinition.Barcode == null) {
            ServiceLocator.MessageService.showError("Barkod Alanı Zorunludur!");
            this.loadingVisible = false;
            return;
        }
        if (this._DrugDefinition.MaterialTree == null) {
            ServiceLocator.MessageService.showError("Malzeme Grubu Zorunludur!");
            this.loadingVisible = false;
            return;
        }
        if (this.MaterialVatRate == null) {
            ServiceLocator.MessageService.showError("KDV Oranı Zorunludur!");
            this.loadingVisible = false;
            return;
        }

        if (this.drugDefinitionFormViewModel._DrugDefinition.PackageAmount == null || this.drugDefinitionFormViewModel._DrugDefinition.PackageAmount == 0) {
            ServiceLocator.MessageService.showError("Kutu Paket Miktarı Zorunludur!");
            this.loadingVisible = false;
            return;
        }

        if (this.drugDefinitionFormViewModel._DrugDefinition.DivideAmountToPatient == true) {

            if (this.drugDefinitionFormViewModel._DrugDefinition.DivideTotalAmount == null ||
                this.drugDefinitionFormViewModel._DrugDefinition.DivideUnitAmount == null) {
                ServiceLocator.MessageService.showError("Hastaya çıkış Birim ve veya Toplam Doz boş olamaz. ");
                this.loadingVisible = false;
                return;
            } else {
                if (this.drugDefinitionFormViewModel._DrugDefinition.DivideTotalAmount % this.drugDefinitionFormViewModel._DrugDefinition.DivideUnitAmount > 0) {
                    ServiceLocator.MessageService.showError("Hastaya çıkış Birim Doz Toplam Doz a tam bölünmesi gerekmektedir.");
                    this.loadingVisible = false;
                    return;
                }
            }
        }

        if (this.stockInheld == null) {
            this._ViewModel.StockCards.push(this._DrugDefinition.StockCard);
        }
        else {
            if (this._DrugDefinition.PackageAmount == null) {
                ServiceLocator.MessageService.showError("Kutudaki Adeti Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this.discountPaymentPrice == null) {
                ServiceLocator.MessageService.showError("İndirimli Satış Fiyatı Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this.MaterialVatRate == null) {
                ServiceLocator.MessageService.showError("KDV Oranı Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this._DrugDefinition.CurrentPrice == null) {
                ServiceLocator.MessageService.showError("Kutudaki Satış Fiyatı Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this._DrugDefinition.IsPackageExclusive == null) {
                ServiceLocator.MessageService.showError("Paket Harici Faturalanır Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this._DrugDefinition.SendSMS == null) {
                ServiceLocator.MessageService.showError("SMS Gerektirir Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
        }

        if (this._DrugDefinition.DrugLabProcInteractions.length > 0) {
            this._ViewModel.DrugLabProcInteractionsGridList = this._DrugDefinition.DrugLabProcInteractions;
        }

        if (this._DrugDefinition.DrugDrugInteractions.length > 0) {
            this._ViewModel.DrugDrugInteractionsGridList = this._DrugDefinition.DrugDrugInteractions;
        }
        if (this._DrugDefinition.DrugFoodInteractions.length > 0) {
            this._ViewModel.DrugFoodInteractionsGridList = this._DrugDefinition.DrugFoodInteractions;
        }


        if (this.etkinvalue != null) {
            this.drugDefinitionFormViewModel.EtkinMaddes.push(this.etkinvalue);
        }

        this.drugDefinitionFormViewModel.ProdureDefs = new Array<Guid>();
        if (this.GridDataSource != null) {
            for (let item of this.GridDataSource)
                this.drugDefinitionFormViewModel.ProdureDefs.push(item.ObjectID);
        }

        this.drugDefinitionFormViewModel.MaterialSpecialtysList = new Array<Guid>();
        for (let item of this.MaterialSpecialtysGridDataSource) {
            this.drugDefinitionFormViewModel.MaterialSpecialtysList.push(item.ObjectID);
        }

        this.drugDefinitionFormViewModel.MaterialVatRatesGridList = new Array<MaterialVatRate>();
        let matVatRate: MaterialVatRate = new MaterialVatRate();
        matVatRate.VatRate = this.MaterialVatRate;
        this.drugDefinitionFormViewModel.MaterialVatRatesGridList.push(matVatRate);


        this.drugDefinitionFormViewModel.Producers = new Array<Producer>();
        this.drugDefinitionFormViewModel.Producers = this.ProducerdataSource;

        this.drugDefinitionFormViewModel._DrugDefinition.MaterialPatientType = this.MaterialPatientTypeSeleceted;

        if (this.deletedActiveIngredients != null && this.deletedActiveIngredients.length > 0) {
            for (let deletedIngredient of this.deletedActiveIngredients) {
                this.drugDefinitionFormViewModel.DrugActiveIngredientsGridList.push(deletedIngredient);
            }
        }

        if (this.MaxDoseByDrugDef != null) {
            this.drugDefinitionFormViewModel.MaxDoseByDrugDef = this.MaxDoseByDrugDef;
        }

        super.save().then(x => {
            this.loadingVisible = false;
            this.deletedActiveIngredients = new Array<DrugActiveIngredient>();
        }).catch(error => {
            this.loadingVisible = false;
        });

    }



    getMaterialList() {
        let apiUrlForInvoiceTerms: string = '/api/DrugDefinitionService/GetMaterialList';
        this.httpService.post<any>(apiUrlForInvoiceTerms, null).then(
            x => {
                this.ConsumptionList = x;
            });
    }

    public ProducerColumns = [
        {
            caption: 'Firma Adı',
            dataField: 'Name',
        },
        {
            caption: 'Firma Tanımlayıcı No',
            dataField: 'GLNNo',
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        },
    ];

    public MaterialProceduresGridColumns = [
        {
            caption: 'Hizmet No',
            dataField: 'ID'
        },
        {
            caption: 'Hizmet Kodu',
            dataField: 'Code',
        },
        {
            caption: 'Hizmet',
            dataField: 'Name',
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        },
    ];

    public GridColumns = [

        {
            'caption': i18n("M10469", "Eklenme Tarihi"),
            dataField: 'SpecificationUploadedDate',
            allowSorting: true
        },

        {
            'caption': i18n("M13245", "Dosya Adı"),
            dataField: 'SpecificationFileName',
            allowSorting: true,
        },



    ];

    public EquivalentDrugColumns = [
        {
            caption: 'Malzeme/İlaç Adı',
            dataField: 'Equivalent'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        }

    ];

    public ActiveIngredientsColumns = [
        {
            caption: 'Kodu ',
            dataField: 'ActiveIngredient.Code',
            allowEditing: false,
        },
        {
            caption: 'Etken Madde Adı ',
            dataField: 'ActiveIngredient.Name',
            allowEditing: false,
        },
        {
            caption: 'Değer ',
            dataField: 'Value',
            allowEditing: true,
        },
        {
            caption: 'Birim ',
            dataField: 'Unit.ObjectID',
            lookup: { dataSource: this.unitDefinitionDataSource, valueExpr: 'ObjectID', displayExpr: 'Name' },
            cellTemplate: 'ddBoxTemplate',
            allowEditing: true,
        },
        {
            caption: 'Maksimum Doz ',
            dataField: 'MaxDose',
            allowEditing: true,
        },
        {
            caption: 'Etkin',
            dataField: 'IsParentIngredient',
            dataType: 'boolean',
            allowEditing: true,
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        },
    ];

    public DrugLabColumns = [
        {
            caption: 'Tetkik Adı ',
            dataField: 'LaboratoryTestDefinition.Name',
            allowEditing: false,
        },
        {
            caption: 'Değerin Altı',
            dataField: 'MinValue',
            allowEditing: true,
        },
        {
            caption: 'Değerin Üstü',
            dataField: 'MaxValue',
            allowEditing: true,
        },
        {
            caption: 'Uyarı Mesajı',
            dataField: 'Message',
            allowEditing: true,
        },
        {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "center",
            width: '3%',
            cellTemplate: "deleteCellTemplate",
            visibleIndex: 14
        }
    ];

    public DrugDrugInteractionColumns = [
        {
            caption: 'İlaç',
            dataField: 'InteractionDrug.Name',
            allowEditing: false,
        },
        {
            caption: 'Etkileşim Seviyesi',
            dataField: 'InteractionLevelType',
            lookup: { dataSource: InteractionLevelTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: true,
        },
        {
            caption: 'Uyarı Mesajı',
            dataField: 'Message',
            allowEditing: true,
        },
        /* {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "center",
            width: '3%',
            cellTemplate: "deleteCellTemplate",
            visibleIndex: 14
        } */
    ];



    public DrugFoodInteractionColumns = [
        {
            caption: 'Besin',
            dataField: 'DietMaterialDefinition.MaterialName',
            allowEditing: false,
        },
        {
            caption: 'Etkileşim Seviyesi',
            dataField: 'InteractionLevelType',
            lookup: { dataSource: InteractionLevelTypeEnum.Items, valueExpr: 'ordinal', displayExpr: 'description' },
            allowEditing: true,
        },
        {
            caption: 'Uyarı Mesajı',
            dataField: 'Message',
            allowEditing: true,
        },
        /* {
            caption: i18n("M27286", "Sil"),
            name: "RowDelete",
            alignment: "center",
            width: '3%',
            cellTemplate: "deleteCellTemplate",
            visibleIndex: 14
        } */
    ];


    public MaterialSpecialtysGridColumns = [
        {
            caption: 'Branş Adı',
            dataField: 'Name',
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        }
    ];


    @ViewChild('dataDrugDrugInteraction') dataDrugDrugInteraction: DxDataGridComponent;
    gridDrugDrugInteraction_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.dataGridDrugLabProc.instance.deleteRow(data.rowIndex);
                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Deleted;
                        this.dataGridDrugLabProc.instance.filter(['EntityState', '<>', 1]);
                        this.dataGridDrugLabProc.instance.refresh();
                    }
                }
            }
        }
    }


    @ViewChild('dataGridDrugLabProc') dataGridDrugLabProc: DxDataGridComponent;
    gridDrugLabProcInteraction_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.dataGridDrugLabProc.instance.deleteRow(data.rowIndex);
                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Deleted;
                        this.dataGridDrugLabProc.instance.filter(['EntityState', '<>', 1]);
                        this.dataGridDrugLabProc.instance.refresh();
                    }
                }
            }
        }
    }

    @ViewChild('MaterialSpecialtysGrid') MaterialSpecialtysGrid: DxDataGridComponent;
    async drugDefinitionSpecialtyGrid_CellContentClicked(data: any) {
        let that = this;
        let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'Silmek istediğinize emin misiniz?');
        if (result === "OK") {
            if (this.ReadOnly != true) {
                if (data.column.name = "RowDelete") {
                    if (data.row != null) {
                        if (data.row.key != null) {
                            if (data.row.key.IsNew) {
                                this.MaterialSpecialtysGrid.instance.deleteRow(data.rowIndex);
                            }
                            else {
                                this.MaterialSpecialtysGridDataSource = this.MaterialSpecialtysGridDataSource.filter(x => x.ObjectID === data.row.data.ObjectID);
                            }
                        }
                    }
                }
            }
        }
    }

    OpenATCMultiSelectComponent() {
        this.getATCList();
    }
    public selectedChangeOnATC() {
        this.drugDefinitionFormViewModel._DrugDefinition.DrugATCs = this.MaterialATC;
        this.showATCMultiSelectForm = false;
    }

    onUnitValueChanged(args, setValueMethod) {
        setValueMethod(args.value);
    }

    onUnitSelectionChanged(e, dropDownBoxInstance) {
        var keys = e.selectedRowKeys;

        dropDownBoxInstance.option("value", keys.length > 0 ? keys[0] : null);

        if (keys.length > 0) {
            this.activeIngredientMaterialGrid.instance.saveEditData();
            this.activeIngredientMaterialGrid.instance.closeEditCell();
        }
    }


    async updateMaterialPriceByIlacAra() {
        this.loadingVisible = true;
        if (this._DrugDefinition.ObjectID != null) {
            let apiUrl: string = '/api/DrugDefinitionService/updateMaterialPriceByIlacAra?drugDefinitionObjId=' + this._DrugDefinition.ObjectID;
            await this.httpService.get<any>(apiUrl)
                .then(response => {
                    let result = response;
                    if (result) {
                        this.messageService.showInfo(result);
                        this.loadingVisible = false;
                    }
                })
                .catch(error => {
                    this.messageService.showError(error);
                    this.loadingVisible = false;
                });
        }
    }


    async onPatientExitByOldPrice() {
        this.showPatientPriceForm = true;
        this.loadingVisible = true;
        if (this._DrugDefinition.ObjectID != null) {
            let apiUrl: string = '/api/DrugDefinitionService/updatePatientMaterialPrice?drugDefinitionObjId=' + this._DrugDefinition.ObjectID;
            await this.httpService.get<pricePatientOutputDTO>(apiUrl)
                .then(response => {
                    let result = response;
                    if (result) {
                        this.unUpdatedPatienList = result.unUpdatedPatienList;
                        this.UpdatedPatienList = result.UpdatedPatienList;
                        this.totalUpdatePatientPriceCount = result.totalUpdatePatientPriceCount;
                        this.priceEndDate = result.priceEndDate;
                        this.priceStartDate = result.priceStartDate;
                        this.loadingVisible = false;
                        if (this.unUpdatedPatienList && this.unUpdatedPatienList.length > 0)
                            this.updatePatientPriceBTN = false;
                    }
                })
                .catch(error => {
                    this.messageService.showError(error);
                    this.loadingVisible = false;
                });
        }
    }


    private async updatePatientPrice_Click() {
        let inputDVO = new RepaitUnUpdate_Intput();
        inputDVO.unUpdatedPatienList = this.unUpdatedPatienList;
        let apiUrl: string = '/api/DrugDefinitionService/UpdateRepaitPatientPrice';
        await this.httpService.post(apiUrl, inputDVO)
            .then(response => {
                let result = response;
                if (result) {
                    this.messageService.showSuccess("Başarılı bir şekilde fiyatlar güncellendi.");
                    this.loadingVisible = false;
                    this.onPatientExitByOldPrice();
                }
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadingVisible = false;
            });
    }

    btnAddClick() {
        let param: DrugActiveIngredient = new DrugActiveIngredient();
        if (this.selectedMaterial) {
            param.ActiveIngredient = this.selectedMaterial;
            param.ActiveIngredient.Name = this.selectedMaterial.Name;
            param.ActiveIngredient.Code = this.selectedMaterial.Code;
            param.ActiveIngredient.MaxDose = this.selectedMaterial.MaxDose;
            param.Unit = this.selectedMaterial.MaxDoseUnit;
            param.MaxDoseUnit = this.selectedMaterial.MaxDoseUnit;
            this.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients.push(param);
        }
    }


    btnAddClick2() {
        let param: DrugActiveIngredient = new DrugActiveIngredient();
        param.ActiveIngredient = this.selectedActiveIngredient;
        this.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients.push(param);
    }

    btnAddClick3() {
        let param: DrugLabProcInteraction = new DrugLabProcInteraction();
        param.LaboratoryTestDefinition = this.selectedLabMaterial;

        if (this.drugDefinitionFormViewModel._DrugDefinition.DrugLabProcInteractions.filter(x => x.LaboratoryTestDefinition.ObjectID == param.LaboratoryTestDefinition.ObjectID).length != 0) {
            ServiceLocator.MessageService.showError("Aynı Lab Hizmeti Birden Fazla Giremezsiniz !");
            throw new TTException(i18n("M11354", "Aynı Lab Hizmeti Birden Fazla Giremezsiniz ! "));
        }
        else {
            this.drugDefinitionFormViewModel._DrugDefinition.DrugLabProcInteractions.push(param);
        }
    }

    AddEquivalentMaterial() {
        if (this.EquivalentDrugList == null) {
            this.EquivalentDrugList = new Array<any>();
        }

        if (this.EquivalentDrugList.filter(x => x.DrugObjectid == this.selectedEquivalentMaterial.ObjectID).length != 0) {
            ServiceLocator.MessageService.showError("Aynı Malzemeyi Birden Fazla Giremezsiniz !");
            throw new TTException(i18n("M11354", "Aynı Malzemeyi Birden Fazla Giremezsiniz ! "));
        }

        else {
            this.equivalentMaterial = new ManuelEquivalentDrug();
            this.equivalentMaterial.EquivalentDrug = this.selectedEquivalentMaterial.ObjectID;
            this.equivalentMaterial.EQUIVALENTCRC = this.selectedEquivalentMaterial.EquivalentCRC;
            this.equivalentMaterial.IsActive = true;
            this.equivalentMaterial.IsNew = true;
            this.tempdrug = new EquivalentMaterial();
            this.tempdrug.Equivalent = this.selectedEquivalentMaterial.Name;
            this.tempdrug.Drug = this.selectedEquivalentMaterial.ObjectID;
            this.EquivalentDrugList.push(this.tempdrug);
            this.drugDefinitionFormViewModel._DrugDefinition.ManuelEquivalentDrugs.push(this.equivalentMaterial);
        }
    }

    onMaterialRowRemoving(e: any) {
        if (e.data.ManuelDrugObjectid != null) {
            this.drugDefinitionFormViewModel._DrugDefinition.ManuelEquivalentDrugs.find(x => x.ObjectID === e.data.ManuelDrugObjectid).EntityState = EntityStateEnum.Deleted;
            this.manuelEquivalentDrugsGrid.instance.filter(['EntityState', '<>', 1]);
            e.cancel = true;
        }
    }

    @ViewChild('materialServiceProcedureGrid') materialServiceProcedureGrid: DxDataGridComponent;
    async materialServiceProcedureGrid_CellContentClicked(data: any) {
        let that = this;
        let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', 'Silmek istediğinize emin misiniz?');
        if (result === "OK") {
            if (this.ReadOnly != true) {
                if (data.column.name = "RowDelete") {
                    if (data.row != null) {
                        if (data.row.key != null) {
                            if (data.row.key.IsNew) {
                                this.materialServiceProcedureGrid.instance.deleteRow(data.rowIndex);
                            }
                            else {
                                //this.drugDefinitionFormViewModel._DrugDefinition.MaterialProcedures.find(x => x.ProcedureDefinition.ObjectID === data.row.data.ObjectID).EntityState = EntityStateEnum.Deleted;
                                this.GridDataSource = this.GridDataSource.filter(x => x.ObjectID === data.row.data.ObjectID);
                            }
                        }
                    }
                }
            }
        }
    }


    @ViewChild('manuelEquivalentDrugsGrid') manuelEquivalentDrugsGrid: DxDataGridComponent;
    async EquivalentMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key) {
                            this.manuelEquivalentDrugsGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.manuelEquivalentDrugsGrid.instance.filter(['EntityState', '<>', 1]);
                            this.manuelEquivalentDrugsGrid.instance.refresh();
                        }
                    }
                }
            }
        }
    }

    btnAddClick4() {
        if (this.GridDataSource != null) {
            if (this.ProducerdataSource.filter(x => x.Name == this.selectedProducer.Name).length == 0) {
                this.ProducerdataSource.push(this.selectedProducer);
            }
            else {
                ServiceLocator.MessageService.showError("Aynı Firmayı Birden Fazla Giremezsiniz !");
            }
        }
    }

    btnMaterialProcedureAddClick() {
        if (this.GridDataSource != null) {
            if (this.GridDataSource.filter(x => x.Code == this.selectedMaterialProcedure.Code).length == 0) {
                this.GridDataSource.push(this.selectedMaterialProcedure);
            }
            else {
                ServiceLocator.MessageService.showError("Aynı Hizmeti Birden Fazla Giremezsiniz !");
            }
        }
    }

    onMaterialSelectionChange(event) {
        this.selectedMaterial = event;
        this.btnAddClick();
    }
    onActiveIngredientSelectionChange(event) {
        this.selectedActiveIngredient = event;
        this.btnAddClick2();
    }
    onEquivalentMaterialSelectionChange(event) {
        this.selectedEquivalentMaterial = event;
        this.AddEquivalentMaterial();
    }

    onServiceProcedureChange(event) {
        this.selectedServiceProcedure = event;

    }

    onLabSelectionChange(event) {
        this.selectedLabMaterial = event;
        this.btnAddClick3();
    }

    onDrugSelectionChange(event) {
        this.selectedDrugMaterial = event;

        if (this.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions == null) {
            this.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions = new Array<DrugDrugInteraction>();
        }

        if (this.selectedDrugMaterial != null) {
            let drugIn: DrugDrugInteraction = new DrugDrugInteraction();
            drugIn.InteractionDrug = this.selectedDrugMaterial;

            if (this.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions.filter(x => x.InteractionDrug.ObjectID == drugIn.InteractionDrug.ObjectID).length != 0) {
                ServiceLocator.MessageService.showError("Aynı İlaç Hizmeti Birden Fazla Giremezsiniz !");
                throw new TTException(i18n("M11354", "Aynı İlaç Hizmeti Birden Fazla Giremezsiniz ! "));
            }
            else {
                this.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions.push(drugIn);
            }
        }
    }

    onFoodSelectionChange(event) {
        this.selectedFood = event;

        if (this.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions == null) {
            this.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions = new Array<DrugFoodInteraction>();
        }

        if (this.selectedFood != null) {
            let foodIn: DrugFoodInteraction = new DrugFoodInteraction();
            foodIn.DietMaterialDefinition = this.selectedFood;

            if (this.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions.filter(x => x.DietMaterialDefinition.ObjectID == foodIn.DietMaterialDefinition.ObjectID).length != 0) {
                ServiceLocator.MessageService.showError("Aynı Besin Hizmeti Birden Fazla Giremezsiniz !");
                throw new TTException(i18n("M11354", "Aynı Besin Hizmeti Birden Fazla Giremezsiniz ! "));
            }
            else {
                this.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions.push(foodIn);
            }
        }
    }


    selectAccountingTerm(data: any) {
        this.accountingTermObjId = data.selectedItem.ObjId;

    }
    getATCList() {
        let that = this;
        let apiUrl: string = '/api/DrugDefinitionService/GetATCList';
        that.httpService.get<any>(apiUrl)
            .then(atc => {
                that.ATCListSource = atc;
                this.showATCMultiSelectForm = true;
            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    itemClick(e, row) {
        this.selectAction(row);
    }
    private showStockAction(data: any): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(data, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "İşlem Detayı");
            modalInfo.Width = 1200;
            modalInfo.Height = 800;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
    async selectAction(value: any): Promise<void> {
        this.showStockAction(value.data.StockActionObjectid);
    }


    // Girişler için eklendi


    async GetForInputs() {
        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._DrugDefinition.ObjectID.toString();
            inputDvo.activeAccountingTerm = this.activeAccountingTerm;
            inputDvo.accountingTermObjId = this.accountingTermObjId;


            let that = this;
            let apiUrlForPASearchUrl: string;
            apiUrlForPASearchUrl = '/api/DrugDefinitionService/GetInputMaterials';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            this.httpService.post(apiUrlForPASearchUrl, inputDvo).then(response => {
                let result = response;
                if (result) {
                    that.InputsResult = result;
                }
            });
        }
        catch (ex) {

        }
    }

    openInTrxChart() {
        if (this.InputsResult != null && this.InputsResult.length > 0) {
            let inputParam: TransactionChartInputDTO = new TransactionChartInputDTO();
            inputParam.StockInList = new Array<StockGiris>();
            inputParam.StockOutList = new Array<StockCikis>();
            for (let intrx of this.InputsResult) {
                let findTrx: StockGiris = inputParam.StockInList.find(x => x.Description == intrx.TrxDescription);
                if (findTrx != null) {
                    findTrx.Amount = findTrx.Amount + intrx.Amount;
                    let findTrxDetay: StockGirisDetay = findTrx.stockGirisDetayList.find(x => x.description == intrx.SourceDescription);
                    if (findTrxDetay != null) {
                        findTrxDetay.amount = findTrxDetay.amount + intrx.Amount;
                    } else {
                        let newDetay: StockGirisDetay = new StockGirisDetay();
                        newDetay.description = intrx.SourceDescription;
                        newDetay.amount = intrx.Amount;
                        findTrx.stockGirisDetayList.push(newDetay);
                    }
                } else {
                    let newTRX: StockGiris = new StockGiris();
                    newTRX.Description = intrx.TrxDescription;
                    newTRX.Amount = intrx.Amount;
                    newTRX.stockGirisDetayList = new Array<StockGirisDetay>();
                    let newDetay: StockGirisDetay = new StockGirisDetay();
                    newDetay.description = intrx.SourceDescription;
                    newDetay.amount = intrx.Amount;
                    newTRX.stockGirisDetayList.push(newDetay);
                    inputParam.StockInList.push(newTRX);
                }
            }
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'TransactionChartComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = inputParam;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'GRAFİK';
            modalInfo.Width = 1200;
            modalInfo.Height = 550;

            let promise = new Promise<string>(function (resolve, reject) {
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result2 = modalService.create(componentInfo, modalInfo);
                result2.then(res2 => {
                    let modalActionResult: any = res2.Param;
                    if (modalActionResult !== undefined) {
                        resolve(modalActionResult);
                    }
                })
                    .catch(err => {
                        TTVisual.InfoBox.Alert(err);
                    });
            });
        }
    }
    //Çıkışlar

    async GetForOutputs() {
        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._DrugDefinition.ObjectID.toString();
            inputDvo.activeAccountingTerm = this.activeAccountingTerm;
            inputDvo.accountingTermObjId = this.accountingTermObjId;

            let that = this;
            let apiUrlForPASearchUrl: string;
            apiUrlForPASearchUrl = '/api/DrugDefinitionService/GetOutputMaterials';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            await this.httpService.post(apiUrlForPASearchUrl, inputDvo).then(response => {
                let result = response;
                if (result) {
                    that.OutputsResult = result;

                }
            });
        }
        catch (ex) {

        }
    }

    openOutTrxChart() {
        if (this.OutputsResult != null && this.OutputsResult.length > 0) {
            let inputParam: TransactionChartInputDTO = new TransactionChartInputDTO();
            inputParam.StockInList = new Array<StockGiris>();
            inputParam.StockOutList = new Array<StockCikis>();
            for (let intrx of this.OutputsResult) {
                let findTrx: StockCikis = inputParam.StockOutList.find(x => x.Description == intrx.TrxDescription);
                if (findTrx != null) {
                    findTrx.Amount = findTrx.Amount + intrx.Amount;
                    let findTrxDetay: StockCikisDetay = findTrx.stockCikisDetayList.find(x => x.description == intrx.SourceDescription);
                    if (findTrxDetay != null) {
                        findTrxDetay.amount = findTrxDetay.amount + intrx.Amount;
                    } else {
                        let newDetay: StockCikisDetay = new StockCikisDetay();
                        newDetay.description = intrx.SourceDescription;
                        newDetay.amount = intrx.Amount;
                        findTrx.stockCikisDetayList.push(newDetay);
                    }
                } else {
                    let newTRX: StockCikis = new StockCikis();
                    newTRX.Description = intrx.TrxDescription;
                    newTRX.Amount = intrx.Amount;
                    newTRX.stockCikisDetayList = new Array<StockCikisDetay>();
                    let newDetay: StockCikisDetay = new StockCikisDetay();
                    newDetay.description = intrx.SourceDescription;
                    newDetay.amount = intrx.Amount;
                    newTRX.stockCikisDetayList.push(newDetay);
                    inputParam.StockOutList.push(newTRX);
                }
            }
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'TransactionChartComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = inputParam;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'GRAFİK';
            modalInfo.Width = 1200;
            modalInfo.Height = 550;

            let promise = new Promise<string>(function (resolve, reject) {
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result2 = modalService.create(componentInfo, modalInfo);
                result2.then(res2 => {
                    let modalActionResult: any = res2.Param;
                    if (modalActionResult !== undefined) {
                        resolve(modalActionResult);
                    }
                })
                    .catch(err => {
                        TTVisual.InfoBox.Alert(err);
                    });
            });
        }
    }
    //XXXXXX Envanteri

    async GetForHospitalInventories() {

        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._DrugDefinition.ObjectID.toString();
            inputDvo.activeAccountingTerm = this.activeAccountingTerm;
            inputDvo.accountingTermObjId = this.accountingTermObjId;

            let that = this;
            let apiUrlForPASearchUrl: string;
            apiUrlForPASearchUrl = '/api/DrugDefinitionService/GetHospitalInventory';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            await this.httpService.post(apiUrlForPASearchUrl, inputDvo).then(response => {
                let result = response;
                if (result) {
                    this.HospitalInventoryResult = result;

                }
            });
        }
        catch (ex) {

        }
    }
    //Aylık Rapor

    async GetForMontlyReports() {
        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._DrugDefinition.ObjectID.toString();
            inputDvo.activeAccountingTerm = this.activeAccountingTerm;
            inputDvo.accountingTermObjId = this.accountingTermObjId;

            let that = this;
            let apiUrlForPASearchUrl: string;
            apiUrlForPASearchUrl = '/api/DrugDefinitionService/GetAmount';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            await this.httpService.post(apiUrlForPASearchUrl, inputDvo).then(response => {
                let result = response;
                if (result) {
                    this.MontlyReportsResult = result;
                }
            });
        }
        catch (ex) {
        }
    }
    SaveDrugSpecification() {
        let apiUrl: string = '/api/DrugDefinitionService/SaveDrugSpecification';
        let param: DrugSpecification_Input = new DrugSpecification_Input();
        param.drugSpecificationNewArray = new Array<any>();
        for (let i of this.drugSpecificationNewArray) {
            param.drugSpecificationNewArray.push(i.DrugSpecification)
        }
        param.drugDefinitionObjectid = this._DrugDefinition;
        this.httpService.post<any>(apiUrl, param).then();
    }

    SaveShelfAndRowOnStock() {
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/SaveShelfAndRowOnStock';
        let params: SaveShelfAndRowOnStock_Input = new SaveShelfAndRowOnStock_Input();
        params.MaterialID = this._DrugDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        params.Shelf = this.shelfNo;
        params.Row = this.rowNo;
        this.httpService.post<any>(apiUrl, params).then();
    }

    SaveStoreLocation() {
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/SaveStoreLocation';
        let params: StoreLocationInformation_Input = new StoreLocationInformation_Input();
        params.StockLocationID = this.StockLocationShelf;
        params.MaterialID = this._DrugDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        this.httpService.post<any>(apiUrl, params).then();
    }
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        this.SaveShelfAndRowOnStock();
        this.SaveStoreLocation();
    }
    protected async PreScript(): Promise<void> {
        /*   this.getRowAndShelf(); */
        this.GTINNo = "0" + this.drugDefinitionFormViewModel._DrugDefinition.Barcode;
        this.WarningDate = "180";
        if (this._DrugDefinition.StockCard == null) {
            this.StockCard.ReadOnly = false;
            this.drugDefinitionFormViewModel._DrugDefinition.MaterialTree = new MaterialTreeDefinition();
            this.drugDefinitionFormViewModel._DrugDefinition.IsActive = true;
        }
        if (this.drugDefinitionFormViewModel._DrugDefinition.DivideAmountToPatient != null) {
            this.isDivideAmountToPatient = this.drugDefinitionFormViewModel._DrugDefinition.DivideAmountToPatient;
        }
    }

    //audit


    public async getDetailAuditBy() {
        let apiUrl: string = '/api/DrugDefinitionService/GetObjectAuditRecords?auditObjectID=' + this._DrugDefinition.ObjectID;
        await this.httpService.post<any>(apiUrl, null)
            .then(response => {
                if (response.length > 0) {
                    this.lastUpdateDate = response[response.length - 1].Date;
                    this.lastUpdateUser = response[response.length - 1].AccountName;
                    this.creationDate = response[0].Date;
                    this.creationUser = response[0].AccountName;
                }
            });
    }


    public async getDetailAudit() {
        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ShowAuditForm';
            componentInfo.ModuleName = 'LogModule';
            componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Log_Modulu/LogModule';
            const auditService = ServiceLocator.Injector.get(IAuditObjectService);
            auditService.ObjectIDList.Clear();
            let auditObject: AuditObject = new AuditObject;
            auditObject.AuditObjectID = that._DrugDefinition.ObjectID;
            auditObject.AuditObjectDefID = that._DrugDefinition.ObjectDefID;
            auditService.ObjectIDList.push(auditObject);
            componentInfo.InputParam = auditService.ObjectIDList;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İşlem Tarihçesi';
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            const modalService = ServiceLocator.Injector.get(IModalService);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }



    selectedMaterialSpecialty: any;
    public MaterialSpecialtysGridDataSource: MaterialSpecialty[] = new Array<MaterialSpecialty>();
    public onMaterialSpecialtyDefinitionMaterialSpecialtyChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaterialSpecialtys != event) {
            this.selectedMaterialSpecialty = event;
            this.btnselectedMaterialSpecialtyAddClick();
        }
    }

    btnselectedMaterialSpecialtyAddClick() {
        if (this.MaterialSpecialtysGridDataSource != null) {
            if (this.MaterialSpecialtysGridDataSource.filter(x => x.ObjectID == this.selectedMaterialSpecialty.ObjectID).length == 0) {
                this.MaterialSpecialtysGridDataSource.push(this.selectedMaterialSpecialty);

            }
            else {
                ServiceLocator.MessageService.showError("Aynı Branş Birden Fazla Giremezsiniz !");
            }
        }
        else {
            this.MaterialSpecialtysGridDataSource.push(this.selectedMaterialSpecialty);
        }
    }

    controlOfValueNull() {
        this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDrugOrder = this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDrugOrder == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDrugOrder;
        this.drugDefinitionFormViewModel._DrugDefinition.DoNotLeaveTheBarcode = this.drugDefinitionFormViewModel._DrugDefinition.DoNotLeaveTheBarcode == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.DoNotLeaveTheBarcode;
        this.drugDefinitionFormViewModel._DrugDefinition.NotAppearInEpicrisis = this.drugDefinitionFormViewModel._DrugDefinition.NotAppearInEpicrisis == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.NotAppearInEpicrisis;
        this.drugDefinitionFormViewModel._DrugDefinition.SendSMS = this.drugDefinitionFormViewModel._DrugDefinition.SendSMS == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.SendSMS;
        this.drugDefinitionFormViewModel._DrugDefinition.IsITSDrug = this.drugDefinitionFormViewModel._DrugDefinition.IsITSDrug == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.IsITSDrug;
        this.drugDefinitionFormViewModel._DrugDefinition.IsExpendableMaterial = this.drugDefinitionFormViewModel._DrugDefinition.IsExpendableMaterial == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.IsExpendableMaterial;
        this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDistributionInfo = this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDistributionInfo == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.ShowZeroOnDistributionInfo;
        this.drugDefinitionFormViewModel._DrugDefinition.DivisibleDrug = this.drugDefinitionFormViewModel._DrugDefinition.DivisibleDrug == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.DivisibleDrug;
        this.drugDefinitionFormViewModel._DrugDefinition.DailyStay = this.drugDefinitionFormViewModel._DrugDefinition.DailyStay == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.DailyStay;
        this.drugDefinitionFormViewModel._DrugDefinition.IsPackageExclusive = this.drugDefinitionFormViewModel._DrugDefinition.IsPackageExclusive == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.IsPackageExclusive;
        this.drugDefinitionFormViewModel._DrugDefinition.PaidPayment = this.drugDefinitionFormViewModel._DrugDefinition.PaidPayment == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.PaidPayment;
        this.drugDefinitionFormViewModel._DrugDefinition.AllowToGivePatient = this.drugDefinitionFormViewModel._DrugDefinition.AllowToGivePatient == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.AllowToGivePatient;
        this.drugDefinitionFormViewModel._DrugDefinition.Chargable = this.drugDefinitionFormViewModel._DrugDefinition.Chargable == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.Chargable;
        this.drugDefinitionFormViewModel._DrugDefinition.DailyStay = this.drugDefinitionFormViewModel._DrugDefinition.DailyStay == undefined ? false : this.drugDefinitionFormViewModel._DrugDefinition.DailyStay;
    }

    calculateDiscountPaymentPrice() {
        let calculatePrice: number = 0;
        if (this.drugDefinitionFormViewModel._DrugDefinition.CurrentPrice != null)
            if (this.drugDefinitionFormViewModel._DrugDefinition.PharmacistDiscountRate != null)
                if (this.drugDefinitionFormViewModel._DrugDefinition.InstitutionDiscountRate != null)
                    if (this.drugDefinitionFormViewModel._DrugDefinition.PackageAmount != null) {
                        calculatePrice = ((this.drugDefinitionFormViewModel._DrugDefinition.CurrentPrice - (this.drugDefinitionFormViewModel._DrugDefinition.CurrentPrice * this.drugDefinitionFormViewModel._DrugDefinition.PharmacistDiscountRate / 100) -
                            (this.drugDefinitionFormViewModel._DrugDefinition.CurrentPrice * this.drugDefinitionFormViewModel._DrugDefinition.InstitutionDiscountRate / 100)) / this.drugDefinitionFormViewModel._DrugDefinition.PackageAmount)
                    }
        this.discountPaymentPrice = Math.Round(calculatePrice, 4);
    }

    changeTxtControl() {
        this.calculateDiscountPaymentPrice();
    }




    public initViewModel(): void {
        this._TTObject = new DrugDefinition();
        this.drugDefinitionFormViewModel = new DrugDefinitionFormViewModel();
        this._ViewModel = this.drugDefinitionFormViewModel;
        this.drugDefinitionFormViewModel._DrugDefinition = this._TTObject as DrugDefinition;
        this.drugDefinitionFormViewModel._DrugDefinition.StockCard = new StockCard();
        this.drugDefinitionFormViewModel._DrugDefinition.StockCard.DistributionType = new DistributionTypeDefinition();
        this.drugDefinitionFormViewModel._DrugDefinition.EtkinMadde = new EtkinMadde();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugATCs = new Array<DrugATC>();
        this.drugDefinitionFormViewModel.DrugSpecificationGrid = new Array<DrugSpecifications>();
        this.drugDefinitionFormViewModel._DrugDefinition.Unit = new UnitDefinition();
        this.drugDefinitionFormViewModel._DrugDefinition.RouteOfAdmin = new RouteOfAdmin();
        this.drugDefinitionFormViewModel._DrugDefinition.GenericDrug = new GenericDrug();
        this.drugDefinitionFormViewModel._DrugDefinition.NFC = new NFC();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients = new Array<DrugActiveIngredient>();
        this.drugDefinitionFormViewModel._DrugDefinition.Brans = new SpecialityDefinition();
        this.drugDefinitionFormViewModel._DrugDefinition.Producer = new Producer();
        this.drugDefinitionFormViewModel._DrugDefinition.GMDNCode = new GMDNDefinition();
        this.drugDefinitionFormViewModel._DrugDefinition.MaterialVatRates = new Array<MaterialVatRate>();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugRelations = new Array<DrugRelation>();
        this.drugDefinitionFormViewModel._DrugDefinition.ManuelEquivalentDrugs = new Array<ManuelEquivalentDrug>();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugLabProcInteractions = new Array<DrugLabProcInteraction>();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions = new Array<DrugDrugInteraction>();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions = new Array<DrugFoodInteraction>();
        this.drugDefinitionFormViewModel._DrugDefinition.DrugSpecifications = new Array<DrugSpecifications>();
        this.drugDefinitionFormViewModel._DrugDefinition.MaterialTree = new MaterialTreeDefinition();
        this.selecedDrugSpecification = new Array<any>();
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.ReportsItems = DrugReportType.Items;
        this.MaterialPatientTypeItems = MaterialPatientTypeEnum.Items;
        this.PrescriptionTypeList = PrescriptionTypeEnum.Items;
        this.GenderList = SexEnum.Items;
        this.AntibioticTypeList = AntibioticTypeEnum.Items;
        this._DrugDefinition.ShowZeroOnDrugOrder = false;
        this._DrugDefinition.ShowZeroOnDistributionInfo = false;
        this._DrugDefinition.DoNotLeaveTheBarcode = false;
        this._DrugDefinition.IsExpendableMaterial = false;
        this._DrugDefinition.NotAppearInEpicrisis = false;
        this._DrugDefinition.DivisibleDrug = false;
        this._DrugDefinition.SendSMS = true;
        this._DrugDefinition.IsActive = true;
        this._DrugDefinition.PaidPayment = false;
        this._DrugDefinition.IsITSDrug = false;
        this._DrugDefinition.Chargable = true;
        this._DrugDefinition.IsPackageExclusive = false;
        this._DrugDefinition.DailyStay = false;
        this._DrugDefinition.AllowToGivePatient = false;
        this.drugDefinitionFormViewModel._DrugDefinition.MaterialProcedures = new Array<MaterialProcedures>();

        if (this.stockInheld == null) {
            this.disabledMaterialPriceByIlacAra = true;
        }
    }

    public IsActiveItems = [
        {
            Name: "Aktif",
            Value: true
        },
        {
            Name: "Pasif",
            Value: false
        }

    ];

    protected async loadViewModel() {


        let that = this;
        this.StoreID = this.activeUserService.SelectedUserStore.ObjectID;

        that.drugDefinitionFormViewModel = this._ViewModel as DrugDefinitionFormViewModel;
        if (that.drugDefinitionFormViewModel.UnitDefinitions != null) {
            if (that.unitDefinitionDataSource == null && that.drugDefinitionFormViewModel.UnitDefinitions.length > 0) {
                that.unitDefinitionDataSource = new Array<UnitDefinition>();
                for (let unit of that.drugDefinitionFormViewModel.UnitDefinitions) {
                    that.unitDefinitionDataSource.push(unit);
                }
            }
        }
        //that.unitDataSource = that.drugDefinitionFormViewModel.UnitDefinitions;
        that._TTObject = this.drugDefinitionFormViewModel._DrugDefinition;
        if (this.drugDefinitionFormViewModel == null)
            this.drugDefinitionFormViewModel = new DrugDefinitionFormViewModel();
        if (this.drugDefinitionFormViewModel._DrugDefinition == null)
            this.drugDefinitionFormViewModel._DrugDefinition = new DrugDefinition();
        let stockCardObjectID = that.drugDefinitionFormViewModel._DrugDefinition["StockCard"];
        let stockCard;
        if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
            stockCard = that.drugDefinitionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
            if (stockCard) {
                that.drugDefinitionFormViewModel._DrugDefinition.StockCard = stockCard;
            }
        }

        if (stockCard != null) {
            let distributionTypeObjectID = stockCard["DistributionType"];
            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                let distributionType = that.drugDefinitionFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                if (distributionType) {
                    stockCard.DistributionType = distributionType;
                }
            }

        }
        let MaterialTreeid = that.drugDefinitionFormViewModel._DrugDefinition["MaterialTree"];
        if (MaterialTreeid != null && (typeof MaterialTreeid === "string")) {
            let tree = that.drugDefinitionFormViewModel.MaterialTreeDefinitions.find(o => o.ObjectID.toString() === MaterialTreeid.toString());
            if (tree) {
                that.drugDefinitionFormViewModel._DrugDefinition.MaterialTree = tree;
            }
        }

        this.materialTreeDefinitionSource.push(this._DrugDefinition.MaterialTree);

        let EtkinMaddeid = that.drugDefinitionFormViewModel._DrugDefinition["EtkinMadde"];
        if (EtkinMaddeid != null && (typeof EtkinMaddeid === "string")) {
            let etkin = that.drugDefinitionFormViewModel.EtkinMaddes.find(o => o.ObjectID.toString() === EtkinMaddeid.toString());
            if (etkin) {
                that.drugDefinitionFormViewModel._DrugDefinition.EtkinMadde = etkin;
            }
        }

        if (this.drugDefinitionFormViewModel._DrugDefinition.EtkinMadde != null) {
            this.etkinvalue = this.drugDefinitionFormViewModel._DrugDefinition.EtkinMadde;
        }

        this.etkinMaddeSource.push(this._DrugDefinition.EtkinMadde);

        that.drugDefinitionFormViewModel._DrugDefinition.DrugATCs = that.drugDefinitionFormViewModel.DrugATCsGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.DrugATCsGridList) {
            let aTCObjectID = detailItem["ATC"];
            if (aTCObjectID != null && (typeof aTCObjectID === "string")) {
                let aTC = that.drugDefinitionFormViewModel.ATCs.find(o => o.ObjectID.toString() === aTCObjectID.toString());
                if (aTC) {
                    detailItem.ATC = aTC;
                }
            }
        }

        if (that.drugDefinitionFormViewModel.UnitDefinitions != null) {
            let unitObjectID1 = that.drugDefinitionFormViewModel._DrugDefinition.ObjectID;
            if (unitObjectID1 != null && (typeof unitObjectID1 === "string") && unitObjectID1 != undefined) {
                let unit = that.drugDefinitionFormViewModel.UnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID1.toString());
                if (unit) {
                    that.drugDefinitionFormViewModel._DrugDefinition.Unit = unit;
                }
            }
        }



        let routeOfAdminObjectID = that.drugDefinitionFormViewModel._DrugDefinition["RouteOfAdmin"];
        if (routeOfAdminObjectID != null && (typeof routeOfAdminObjectID === "string")) {
            let routeOfAdmin = that.drugDefinitionFormViewModel.RouteOfAdmins.find(o => o.ObjectID.toString() === routeOfAdminObjectID.toString());
            if (routeOfAdmin) {
                that.drugDefinitionFormViewModel._DrugDefinition.RouteOfAdmin = routeOfAdmin;
            }
        }


        let genericDrugObjectID = that.drugDefinitionFormViewModel._DrugDefinition["GenericDrug"];
        if (genericDrugObjectID != null && (typeof genericDrugObjectID === "string")) {
            let genericDrug = that.drugDefinitionFormViewModel.GenericDrugs.find(o => o.ObjectID.toString() === genericDrugObjectID.toString());
            if (genericDrug) {
                that.drugDefinitionFormViewModel._DrugDefinition.GenericDrug = genericDrug;
            }
        }


        let nFCObjectID = that.drugDefinitionFormViewModel._DrugDefinition["NFC"];
        if (nFCObjectID != null && (typeof nFCObjectID === "string")) {
            let nFC = that.drugDefinitionFormViewModel.NFCs.find(o => o.ObjectID.toString() === nFCObjectID.toString());
            if (nFC) {
                that.drugDefinitionFormViewModel._DrugDefinition.NFC = nFC;
            }
        }



        that.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients = that.drugDefinitionFormViewModel.DrugActiveIngredientsGridList;
        let detailItem;
        for (detailItem of that.drugDefinitionFormViewModel.DrugActiveIngredientsGridList) {
            let activeIngredientObjectID = detailItem["ActiveIngredient"];
            if (activeIngredientObjectID != null && (typeof activeIngredientObjectID === "string")) {
                let activeIngredient = that.drugDefinitionFormViewModel.ActiveIngredientDefinitions.find(o => o.ObjectID.toString() === activeIngredientObjectID.toString());
                if (activeIngredient) {
                    detailItem.ActiveIngredient = activeIngredient;
                }
            }
            let unitObjectID = detailItem["Unit"];
            if (unitObjectID != null && (typeof unitObjectID === "string")) {
                let unit = that.drugDefinitionFormViewModel.UnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
                if (unit) {
                    if (detailItem) {
                        detailItem.Unit = unit;
                    }
                }
            }

        }
        /*let unitObjectID = that.drugDefinitionFormViewModel._DrugDefinition["Unit"];
        if (unitObjectID != null && (typeof unitObjectID === "string")) {
            let unit = that.drugDefinitionFormViewModel.UnitDefinitions.find(o => o.ObjectID.toString() === unitObjectID.toString());
            if (unit) {
                if (detailItem) {
                    detailItem.Unit = unit;
                }
            }
        }


        let maxDoseUnitObjectID = that.drugDefinitionFormViewModel._DrugDefinition["MaxDoseUnit"];
        if (maxDoseUnitObjectID != null && (typeof maxDoseUnitObjectID === "string")) {
            let maxDoseUnit = that.drugDefinitionFormViewModel.UnitDefinitions.find(o => o.ObjectID.toString() === maxDoseUnitObjectID.toString());
            if (maxDoseUnit) {
                detailItem.MaxDoseUnit = maxDoseUnit;
            }
        }*/




        let bransObjectID = that.drugDefinitionFormViewModel._DrugDefinition["Brans"];
        if (bransObjectID != null && (typeof bransObjectID === "string")) {
            let brans = that.drugDefinitionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === bransObjectID.toString());
            if (brans) {
                that.drugDefinitionFormViewModel._DrugDefinition.Brans = brans;
            }
        }


        let producerObjectID = that.drugDefinitionFormViewModel._DrugDefinition["Producer"];
        if (producerObjectID != null && (typeof producerObjectID === "string")) {
            let producer = that.drugDefinitionFormViewModel.Producers.find(o => o.ObjectID.toString() === producerObjectID.toString());
            if (producer) {
                that.drugDefinitionFormViewModel._DrugDefinition.Producer = producer;
            }
        }


        let gMDNCodeObjectID = that.drugDefinitionFormViewModel._DrugDefinition["GMDNCode"];
        if (gMDNCodeObjectID != null && (typeof gMDNCodeObjectID === "string")) {
            let gMDNCode = that.drugDefinitionFormViewModel.GMDNDefinitions.find(o => o.ObjectID.toString() === gMDNCodeObjectID.toString());
            if (gMDNCode) {
                that.drugDefinitionFormViewModel._DrugDefinition.GMDNCode = gMDNCode;
            }
        }



        that.drugDefinitionFormViewModel._DrugDefinition.MaterialVatRates = that.drugDefinitionFormViewModel.MaterialVatRatesGridList;
        if (that.drugDefinitionFormViewModel._DrugDefinition.MaterialVatRates.length != 0) {
            that.MaterialVatRate = that.drugDefinitionFormViewModel._DrugDefinition.MaterialVatRates[0].VatRate;
        }

        that.drugDefinitionFormViewModel._DrugDefinition.DrugRelations = that.drugDefinitionFormViewModel.DrugRelationsGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.DrugRelationsGridList) {
            let relationDrugObjectID = detailItem["RelationDrug"];
            if (relationDrugObjectID != null && (typeof relationDrugObjectID === "string")) {
                let relationDrug = that.drugDefinitionFormViewModel.DrugDefinitions.find(o => o.ObjectID.toString() === relationDrugObjectID.toString());
                if (relationDrug) {
                    detailItem.RelationDrug = relationDrug;
                }
            }

        }

        that.drugDefinitionFormViewModel._DrugDefinition.ManuelEquivalentDrugs = that.drugDefinitionFormViewModel.ManuelEquivalentDrugsGridList;

        for (let detailItem of that.drugDefinitionFormViewModel.ManuelEquivalentDrugsGridList) {
            let equivalentDrugObjectID = detailItem["EquivalentDrug"];
            if (equivalentDrugObjectID != null && (typeof equivalentDrugObjectID === "string")) {
                let equivalentDrug = that.drugDefinitionFormViewModel.DrugDefinitions.find(o => o.ObjectID.toString() === equivalentDrugObjectID.toString());
                if (equivalentDrug) {
                    detailItem.EquivalentDrug = equivalentDrug;
                }
            }

        }


        that.drugDefinitionFormViewModel._DrugDefinition.DrugLabProcInteractions = that.drugDefinitionFormViewModel.DrugLabProcInteractionsGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.DrugLabProcInteractionsGridList) {
            let laboratoryTestDefinitionObjectID = detailItem["LaboratoryTestDefinition"];
            if (laboratoryTestDefinitionObjectID != null && (typeof laboratoryTestDefinitionObjectID === "string")) {
                let laboratoryTestDefinition = that.drugDefinitionFormViewModel.LaboratoryTestDefinitions.find(o => o.ObjectID.toString() === laboratoryTestDefinitionObjectID.toString());
                if (laboratoryTestDefinition) {
                    detailItem.LaboratoryTestDefinition = laboratoryTestDefinition;
                }
            }

        }

        that.drugDefinitionFormViewModel._DrugDefinition.DrugDrugInteractions = that.drugDefinitionFormViewModel.DrugDrugInteractionsGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.DrugDrugInteractionsGridList) {
            let interactionDrugObjectID = detailItem["InteractionDrug"];
            if (interactionDrugObjectID != null && (typeof interactionDrugObjectID === "string")) {
                let drugDrugInteraction = that.drugDefinitionFormViewModel.interactionDrugs.find(o => o.ObjectID.toString() === interactionDrugObjectID.toString());
                if (drugDrugInteraction) {
                    detailItem.InteractionDrug = drugDrugInteraction;
                }
            }
        }

        that.drugDefinitionFormViewModel._DrugDefinition.DrugFoodInteractions = that.drugDefinitionFormViewModel.DrugFoodInteractionsGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.DrugFoodInteractionsGridList) {
            let dietMaterialDefinitionObjectID = detailItem["DietMaterialDefinition"];
            if (dietMaterialDefinitionObjectID != null && (typeof dietMaterialDefinitionObjectID === "string")) {
                let dietInteraction = that.drugDefinitionFormViewModel.dietMaterialDefinitions.find(o => o.ObjectID.toString() === dietMaterialDefinitionObjectID.toString());
                if (dietInteraction) {
                    detailItem.DietMaterialDefinition = dietInteraction;
                }
            }
        }




        that.drugDefinitionFormViewModel._DrugDefinition.MaterialProcedures = that.drugDefinitionFormViewModel.grdMaterialProceduresGridList;
        for (let detailItem of that.drugDefinitionFormViewModel.grdMaterialProceduresGridList) {
            let procedureDefinitionObjectID = detailItem["ProcedureDefinition"];
            if (procedureDefinitionObjectID != null && (typeof procedureDefinitionObjectID === "string")) {
                let procedureDefinition = that.drugDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinitionObjectID.toString());
                if (procedureDefinition) {
                    detailItem.ProcedureDefinition = procedureDefinition;
                }
            }
        }

        if (this.drugDefinitionFormViewModel._DrugDefinition.Producer) {
            if (this.ProducerdataSource.find(x => x.FirmIdentifierNo == this.drugDefinitionFormViewModel._DrugDefinition.Producer.FirmIdentifierNo) == null) {
                this.ProducerdataSource.push(this.drugDefinitionFormViewModel._DrugDefinition.Producer);
            }
        }

        this.MaterialPatientTypeSeleceted = this.drugDefinitionFormViewModel._DrugDefinition.MaterialPatientType;

        //this.drugSpecificationNewArray = this.drugDefinitionFormViewModel.grdDrugSpecificationGridList;

        this.selectedRevenueSubAccountCodeItem = this.drugDefinitionFormViewModel.RevenueSubAccountCodeDef;
        if (this.selectedRevenueSubAccountCodeItem != null) {
            this.selectedRevenueSubAccountCodeItemDescription = this.selectedRevenueSubAccountCodeItem.Description;
        }



        await this.loadObjectModel();

    }
    ATCDefDrug: any[] = new Array<any>();
    selectedRevenueSubAccountCodeItemDescription: string;


    public async getMaterialInStock() {
        this.showPriceForm = true;
    }

    public async loadObjectModel() {
        await this.LoadModelComponent();
        await this.filegrid();
        await this.fileAlerjikgrid();
        await this.controlOfValueNull();
        this.calculateDiscountPaymentPrice();
        //this.getDetailAuditBy();
    }


    public async LoadModelComponent() {
        this.loadingVisible = true;
        let apiUrl: string = '/api/DrugDefinitionService/loadModelComponent';
        let params: LoadModelComponent_Input = new LoadModelComponent_Input();
        params.MaterialID = this._DrugDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        params.Equivalent = this._DrugDefinition.EquivalentCRC;

        await this.httpService.post<LoadModelComponent>(apiUrl, params)
            .then(response => {
                this.ParentStockLocationList = response.getStockLocationClasses;
                if (response.shelfAndRowOnStock.StockLocation != null) {
                    this.StockLocationShelf = response.shelfAndRowOnStock.StockLocation.ObjectID;
                    this.building = response.shelfAndRowOnStock.StockLocation.ParentStockLocation;
                }
                this.DrugInfos = response.materialPrices;
                for (let x of response.materialPrices) {
                    this.DrugPriceList.push(x);
                }
                if (this.DrugPriceList.length > 0)
                    this.lastCost = this.DrugPriceList[this.DrugPriceList.length - 1].Price;

                //this.EquivalentDrugList = response.equivalentDrug;
                this.EquivalentDrugList = new Array<any>();
                for (let eq of response.getEquivalents) {
                    let e: EquivalentMaterial = new EquivalentMaterial();
                    e.Drug = eq.DrugObjectid;
                    e.Equivalent = eq.Equivalent;
                    this.EquivalentDrugList.push(e);
                }

                if (response.getCritical != null) {
                    this.MinimumLevel = response.getCritical.MinimumLevel;
                    this.MaximumLevel = response.getCritical.MaximumLevel;
                    this.CriticalLevel = response.getCritical.CriticalLevel;
                    this.stockInheld = response.getCritical.Inheld;
                }
                this.GridDataSource = response.materialProcedures;
                this.FirtInStockUnitePriceList = response.firstInStockUnitePrices;
                if (this.FirtInStockUnitePriceList && this.FirtInStockUnitePriceList.length > 0) {
                    this.lastPrice = this.FirtInStockUnitePriceList[0].UnitePrice.toString();
                }

                if (response.logDataSources.length > 0) {
                    this.lastUpdateDate = response.logDataSources[response.logDataSources.length - 1].Date;
                    this.lastUpdateUser = response.logDataSources[response.logDataSources.length - 1].AccountName;
                    this.creationDate = response.logDataSources[0].Date;
                    this.creationUser = response.logDataSources[0].AccountName;
                }



                this.costActionAccountingTerm = response.doSearchaccountingTerm.costActionAccountingTerm;
                this.activeAccountingTerm = response.doSearchaccountingTerm.activeCostActionAccountingTerm;
                this.accountingTermObjId = response.doSearchaccountingTerm.activeCostActionAccountingTerm != null ? response.doSearchaccountingTerm.activeCostActionAccountingTerm.ObjId.toString() : "";
                this.drugDefinitionFormViewModel.DrugSpecs = response.drugSpecifications;
                this.RouteOfAdminDataSoruce = response.routeOfAdminDataSource;
                this.NFCDataSoruce = response.nfcDataSource;
                if (response.MaxDoseByDrugDef != null)
                    this.MaxDoseByDrugDef = response.MaxDoseByDrugDef;


                this.loadingVisible = false;
            })
            .catch(error => {
                this.messageService.showError(error);
                this.loadingVisible = false;
            });

        if (this.lastCost == null)
            this.lastCost = Math.Round(this._DrugDefinition.CurrentPrice / this._DrugDefinition.PackageAmount, 4);


        for (let atc of this._DrugDefinition.DrugATCs) {
            this.ATCDefDrug.push(atc.ATC);
        }

        if (this._DrugDefinition.RouteOfAdmin != null)
            if (this.SeletedRouteOfAdmin == null)
                this.SeletedRouteOfAdmin = this.RouteOfAdminDataSoruce.find(x => x.ObjectID == this._DrugDefinition.RouteOfAdmin.ObjectID).ObjectID;

        if (this._DrugDefinition.NFC != null)
            if (this.SeletedNFC == null)
                this.SeletedNFC = this.NFCDataSoruce.find(x => x.ObjectID == this._DrugDefinition.NFC.ObjectID).ObjectID;
    }



    onBuildingSelectionChanged(event) {
        this.GetStockShelfLocation();
    }

    public GetStockLocation() {

    }

    public GetStockShelfLocation() {
        let inputparam: GetStockLocation_Input = new GetStockLocation_Input();
        inputparam.StockLocationName = this.building;
        let that = this;
        let apiUrl: string = '/api/DrugDefinitionService/GetStockShelfLocation?';
        that.httpService.post<any>(apiUrl, inputparam)
            .then(stockLocationIsNotGroupList => {
                that.StockLocationList = stockLocationIsNotGroupList;
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }


    onRouteOfAdminSelectionChanged(data: any) {
        if (this.SeletedRouteOfAdmin != null) {
            this.drugDefinitionFormViewModel.RouteOfAdmins = new Array<RouteOfAdmin>();
            this.drugDefinitionFormViewModel.RouteOfAdmins.push(this.RouteOfAdminDataSoruce.find(x => x.ObjectID == this.SeletedRouteOfAdmin));
        }
    }
    onNFCSelectionChanged(data: any) {
        if (this.SeletedNFC != null)
            this.drugDefinitionFormViewModel.NFCs = new Array<NFC>();
        this.drugDefinitionFormViewModel.NFCs.push(this.NFCDataSoruce.find(x => x.ObjectID == this.SeletedNFC));
    }



    public EquivalentDrugList: Array<any> = new Array<any>();

    public OzellikChanged(data) {
        this.drugspecificationNew = new DrugSpecifications();
    }

    public async GetSpecificationsOfDrugDefinition() {
        let apiUrl: string = 'api/DrugDefinitionService/GetSpecificationsOfDrugDefinition?drugDefinitionObjectID=' + this._DrugDefinition.ObjectID;
        await this.httpService.get<any>(apiUrl).then((specificationList: Array<any>) => {
            this.DrugSpecificationEnumDef = specificationList;
        })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

    public async selectMaterialTree() {
        let apiUrl: string = '/api/DrugDefinitionService/GetMaterialTree';
        await this.httpService.get<any>(apiUrl)
            .then(matTree => {
                this.materialTreeDefinitionSource = matTree;
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    /*     public selectSGKMaterial() {
            if (this.drugDefinitionFormViewModel._DrugDefinition != null) {
                let that = this;
                let apiUrl: string = '/api/DrugDefinitionService/GetSGKActiveMaterial';
                that.httpService.get<any>(apiUrl)
                    .then(SGK => {
                        that.etkinMaddeSource = SGK;
                    })
                    .catch(error => {
                        that.messageService.showError(error);
    
                    });
            }
        } */

    public RevenueSubAccountCodeSource;
    selectedRevenueSubAccountCodeItem: any = {};
    openRevenueSubAccountDropDown() {
        this.getRevenueSubAccountDataSource();
    }
    public onClearRevenueSubAccount(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedRevenueSubAccountCodeItem = {};
        }
    }

    async getRevenueSubAccountDataSource() {
        this.RevenueSubAccountCodeSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: async (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'RevenueSubAccountCodeDefList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return await this.httpService.post<any>('/api/ConsumableMaterialDefinitionService/RevenueSubAccountCodeList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }
    selectRevenueSubAccount(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.drugDefinitionFormViewModel._DrugDefinition.RevenueSubAccountCode = e.data;
        this.selectedRevenueSubAccountCodeItem = e.data;
        this.selectedRevenueSubAccountCodeItemDescription = this.selectedRevenueSubAccountCodeItem.Description;
    }


    etkinMaddeList: DataSource;
    selectSGKMaterial() {
        this.etkinMaddeList = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'SGKActiveMaterial'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/DrugDefinitionService/GetSGKActiveMaterial', loadOptions);

                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    showEtkinMaddeNameGrid: boolean = false;
    selectEtkinMadde(e) {
        this.drugDefinitionFormViewModel.EtkinMaddeName = e.data.etkinMaddeAdi;
        this.drugDefinitionFormViewModel.EtkinMaddeObjectID = e.data.ObjectID;
        this.showEtkinMaddeNameGrid = false;
    }



    public onAllowToGivePatientChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.AllowToGivePatient != event) {
            this._DrugDefinition.AllowToGivePatient = event;
        }
    }

    public onBarcodeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Barcode != event) {
            this._DrugDefinition.Barcode = event;
        }
    }

    public onBarcodeNameChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.BarcodeName != event) {
            this._DrugDefinition.BarcodeName = event;
        }
    }

    public onBransChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Brans != event) {
            this._DrugDefinition.Brans = event;
        }
    }

    public onChargableChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Chargable != event) {
            this._DrugDefinition.Chargable = event;
        }
    }

    public onCodeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Code != event) {
            this._DrugDefinition.Code = event;
        }
    }

    public onColorChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Color != event) {
            this._DrugDefinition.Color = event;
        }
    }

    public onDrugSpecificationChanged(event): void {
        if (this.DrugSpecification != null && this.DrugSpecification != event) {
            this.DrugSpecification = event;
        }
    }

    public onCreateInMedulaDontSendStateChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.CreateInMedulaDontSendState != event) {
            this._DrugDefinition.CreateInMedulaDontSendState = event;
        }
    }

    public onCreationDateChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.CreationDate != event) {
            this._DrugDefinition.CreationDate = event;
        }
    }

    public onCurrentPriceChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.CurrentPrice != event) {
            this._DrugDefinition.CurrentPrice = event;
        }
    }

    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._DrugDefinition != null && this._DrugDefinition.Description != event) {
                this._DrugDefinition.Description = event;
            }
        }
    }

    public onDistributionTypeStockCardChanged(event): void {
        if (this._DrugDefinition != null &&
            this._DrugDefinition.StockCard != null && this._DrugDefinition.StockCard.DistributionType != event) {
            this._DrugDefinition.StockCard.DistributionType = event;
        }
    }

    public onDividePriceToVolumeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.DividePriceToVolume != event) {
            this._DrugDefinition.DividePriceToVolume = event;
        }
    }

    public onDoseChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Dose != event) {
            this._DrugDefinition.Dose = event;
        }
    }

    public onDrugNutrientInteractionChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.DrugNutrientInteraction != event) {
            this._DrugDefinition.DrugNutrientInteraction = event;
        }
    }

    public onEstimatedTimeOfCheckChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.EstimatedTimeOfCheck != event) {
            this._DrugDefinition.EstimatedTimeOfCheck = event;
        }
    }

    public onEtkinMaddeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.EtkinMadde != event) {
            this._DrugDefinition.EtkinMadde = event;
        }
    }

    public onETKMDescriptionChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.ETKMDescription != event) {
            this._DrugDefinition.ETKMDescription = event;
        }
    }

    public onFrequencyChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Frequency != event) {
            this._DrugDefinition.Frequency = event;
        }
    }

    public onGenericDrugChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.GenericDrug != event) {
            this._DrugDefinition.GenericDrug = event;
        }
    }

    public onGMDNCodeStockCardChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.GMDNCode != event) {
            this._DrugDefinition.GMDNCode = event;
        }
    }

    public onIsActiveChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsActive != event) {
            this._DrugDefinition.IsActive = event;
        }
    }

    public onIsArmyDrugChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsArmyDrug != event) {
            this._DrugDefinition.IsArmyDrug = event;
        }
    }

    public onIsExpendableMaterialChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsExpendableMaterial != event) {
            this._DrugDefinition.IsExpendableMaterial = event;
        }
    }

    public onIsNarcoticChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsNarcotic != event) {
            this._DrugDefinition.IsNarcotic = event;
        }
    }

    public onIsOldMaterialChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsOldMaterial != event) {
            this._DrugDefinition.IsOldMaterial = event;
        }
    }

    public onIsPackageExclusiveChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsPackageExclusive != event) {
            this._DrugDefinition.IsPackageExclusive = event;
        }
    }

    public onIsPsychotropicChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.IsPsychotropic != event) {
            this._DrugDefinition.IsPsychotropic = event;
        }
    }

    public onLicenceDateChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.LicenceDate != event) {
            this._DrugDefinition.LicenceDate = event;
        }
    }

    public onLicenceNOChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.LicenceNO != event) {
            this._DrugDefinition.LicenceNO = event;
        }
    }

    public onLicencingOrganizationChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.LicencingOrganization != event) {
            this._DrugDefinition.LicencingOrganization = event;
        }
    }

    public onMaterialPricingTypeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaterialPricingType != event) {
            this._DrugDefinition.MaterialPricingType = event;
        }
    }

    public onMaterialTreeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaterialTree != event) {
            this._DrugDefinition.MaterialTree = event;
        }
    }

    public onMaxDoseChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaxDose != event) {
            this._DrugDefinition.MaxDose = event;
        }
    }

    public onMaxDoseDayChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaxDoseDay != event) {
            this._DrugDefinition.MaxDoseDay = event;
        }
    }

    public onMedulaMultiplierChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MedulaMultiplier != event) {
            this._DrugDefinition.MedulaMultiplier = event;
        }
    }

    public onMkysMalzemeKoduChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MkysMalzemeKodu != event) {
            this._DrugDefinition.MkysMalzemeKodu = event;
        }
    }

    public onNameChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Name != event) {
            this._DrugDefinition.Name = event;
        }
    }

    public onNFCChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.NFC != event) {
            this._DrugDefinition.NFC = event;
        }
    }

    public onOrderRPTDayChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.OrderRPTDay != event) {
            this._DrugDefinition.OrderRPTDay = event;
        }
    }

    public onOriginalNameChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.OriginalName != event) {
            this._DrugDefinition.OriginalName = event;
        }
    }

    public onPackageAmountChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PackageAmount != event) {
            this._DrugDefinition.PackageAmount = event;
        }
    }

    public onPatientSafetyFromChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PatientSafetyFrom != event) {
            this._DrugDefinition.PatientSafetyFrom = event;
        }
    }

    public onPrescriptionTypeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PrescriptionType != event) {
            this._DrugDefinition.PrescriptionType = event;
        }
    }



    public onProducerChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Producer != event) {
            this.selectedProducer = event;
            this.btnAddClick4();
        }
    }

    selectedMaterialProcedure: any;
    public onMaterialProceduresChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaterialProcedures != event) {
            this.selectedMaterialProcedure = event;
            this.btnMaterialProcedureAddClick();
        }
    }

    public onProductNumberChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.ProductNumber != event) {
            this._DrugDefinition.ProductNumber = event;
        }
    }

    public onPurchaseDateChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PurchaseDate != event) {
            this._DrugDefinition.PurchaseDate = event;
        }
    }

    public onReimbursementUnderChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.ReimbursementUnder != event) {
            this._DrugDefinition.ReimbursementUnder = event;
        }
    }

    public onRouteOfAdminChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.RouteOfAdmin != event) {
            this._DrugDefinition.RouteOfAdmin = event;
        }
        else
            this._DrugDefinition.RouteOfAdmin = event;
    }

    public onRoutineDayChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.RoutineDay != event) {
            this._DrugDefinition.RoutineDay = event;
        }
    }

    public onRoutineDoseChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.RoutineDose != event) {
            this._DrugDefinition.RoutineDose = event;
        }
    }

    public onSendSMSChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.SendSMS != event) {
            this._DrugDefinition.SendSMS = event;
        }
    }
    public onShowZeroOnDrugOrderChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.ShowZeroOnDrugOrder != event) {
            this._DrugDefinition.ShowZeroOnDrugOrder = event;
        }
    }

    public onPaidPaymentChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PaidPayment != event) {
            this._DrugDefinition.PaidPayment = event;
        }
    }

    public onSetMedulaInfoByMultiplierChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.SetMedulaInfoByMultiplier != event) {
            this._DrugDefinition.SetMedulaInfoByMultiplier = event;
        }
    }

    public onSgkReturnPayChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.SgkReturnPay != event) {
            this._DrugDefinition.SgkReturnPay = event;
        }
    }

    public onSpecialistApprovalChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.InfectionApproval != event) {
            this._DrugDefinition.InfectionApproval = event;
        }
    }

    public onStockCardChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.StockCard != event) {
            this._DrugDefinition.StockCard = event;
            if (this._DrugDefinition.StockCard != null) {
                this.selectionStockCardMkysKayitID();
            }
        }
    }


    public async selectionStockCardMkysKayitID() {
        try {
            let GetSavedTaskModel = '/api/ConsumableMaterialDefinitionService/StockCardMkysKayitID?ObjectID=' + this._DrugDefinition.StockCard.ObjectID;
            this.httpService.get(GetSavedTaskModel, null).then(response => {
                if (response != 0) {
                    this._DrugDefinition.MkysMalzemeKodu = response as number;
                } else {
                    ServiceLocator.MessageService.showError("Malzeme Kayıt ID'si sistemde bulunmamıitır.Önce Malzeme Kayıt ID'sinin Güncellenmesi Gerekmektedir.");
                }

            }).catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    public onStorageConditionsChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.StorageConditions != event) {
            this._DrugDefinition.StorageConditions = event;
        }
    }

    public onttcheckbox2Changed(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.ShowZeroOnDistributionInfo != event) {
            this._DrugDefinition.ShowZeroOnDistributionInfo = event;
        }
    }
    public ontttextbox5Changed(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.PatientMaxDayOut != event) {
            this._DrugDefinition.PatientMaxDayOut = event;
        }
    }

    public onttenumcombobox1Changed(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.DrugShapeType != event) {
            this._DrugDefinition.DrugShapeType = event;
        }
    }

    public ontttextbox1Changed(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MinPatientAge != event) {
            this._DrugDefinition.MinPatientAge = event;
        }
    }

    public ontttextbox2Changed(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.MaxPatientAge != event) {
            this._DrugDefinition.MaxPatientAge = event;
        }
    }

    public ontxtAmountMultiplierChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.AccTrxAmountMultiplier != event) {
            this._DrugDefinition.AccTrxAmountMultiplier = event;
        }
    }

    public ontxtUnitPriceDividerChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.AccTrxUnitPriceDivider != event) {
            this._DrugDefinition.AccTrxUnitPriceDivider = event;
        }
    }

    public onVolumeChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Volume != event) {
            this._DrugDefinition.Volume = event;
        }
    }

    public onVolumeUnitChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.Unit != event) {
            this._DrugDefinition.Unit = event;
        }
    }

    public onWithOutStockInheldChanged(event): void {
        if (this._DrugDefinition != null && this._DrugDefinition.WithOutStockInheld != event) {
            this._DrugDefinition.WithOutStockInheld = event;
        }
    }

    // public onRouteOfAdminCleared(event): void {
    //     if (this._DrugDefinition != null && this._DrugDefinition.RouteOfAdmin != event) {
    //         this._DrugDefinition.RouteOfAdmin = event;
    //     }
    // }


    onChange($event) {
        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        const fileType = $event.target.parentElement.id;
        if (file.size > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
            return;
        }
        fileReader.onloadend = (e) => {
            that.document.FileName = file.name,
                that.document.File = fileReader.result;
        };

        fileReader.readAsArrayBuffer(file);
    }

    addDocument() {
        if (this.document.FileName !== undefined) {
            const doc: UploadFile_Input = new UploadFile_Input();
            doc.File = this.document.File;
            doc.FileUpdateDate = new Date(Date.now());
            doc.IsNew = true;
            doc.FileName = this.document.FileName;
            doc.Material = this._DrugDefinition.ObjectID;
            doc.MaterialDocumentType = MaterialDocumentType.Sartname;
            this.docsUpload.push(doc);
        }

        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13272", "Dosya seçiniz!"), MessageIconEnum.WarningMessage);
        }
    }

    addAlerjikDocument() {
        if (this.document.FileName !== undefined) {
            const doc: UploadFile_Input = new UploadFile_Input();
            doc.File = this.document.File;
            doc.FileUpdateDate = new Date(Date.now());
            doc.IsNew = true;
            doc.FileName = this.document.FileName;
            doc.Material = this._DrugDefinition.ObjectID;
            doc.MaterialDocumentType = MaterialDocumentType.AlerjikReaksiyon;
            this.docsAlerjikUpload.push(doc);
        }

        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13272", "Dosya seçiniz!"), MessageIconEnum.WarningMessage);
        }
    }

    UploadAlerjik() {
        for (let doc of this.docsAlerjikUpload) {
            if (doc.IsNew) {
                let token = sessionStorage.getItem('token');
                const headers = new HttpHeaders()
                    .append('Authorization', `Bearer ${token}`);

                let blb: any = doc.File;
                const blob = new Blob([new Uint8Array(blb)], { type: 'application/octet-binary' });
                const formData = new FormData();


                formData.append('File', blob);
                formData.append('FileName', doc.FileName);
                //formData.append('Material', doc.Material);
                this.http.post('/api/DrugDefinitionService/UploadAlerjik', formData, { headers: headers }).toPromise().then(result => {
                    const neResult = result as NeResult<Object>;
                    if (neResult.IsSuccess == true) {
                        this.messageService.showSuccess(i18n("M21515", "Seçilen dosyalar başarıyla eklenmiştir."));
                    }
                }).catch(error => {
                    console.log(error);
                });
            }

        }
        // this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, null);
    }

    Upload() {
        for (let doc of this.docsUpload) {
            if (doc.IsNew) {
                let token = sessionStorage.getItem('token');
                const headers = new HttpHeaders()
                    .append('Authorization', `Bearer ${token}`);

                let blb: any = doc.File;
                const blob = new Blob([new Uint8Array(blb)], { type: 'application/octet-binary' });
                const formData = new FormData();


                formData.append('File', blob);
                formData.append('FileName', doc.FileName);
                //formData.append('Material', doc.Material);
                this.http.post('/api/DrugDefinitionService/Upload', formData, { headers: headers }).toPromise().then(result => {
                    const neResult = result as NeResult<Object>;
                    if (neResult.IsSuccess == true) {
                        this.messageService.showSuccess(i18n("M21515", "Seçilen dosyalar başarıyla eklenmiştir."));
                    }
                }).catch(error => {
                    console.log(error);
                });
            }

        }
    }

    openLogisticDocument() {
        let inputParams: OpenLogisticDocumentInputParams = new OpenLogisticDocumentInputParams();
        inputParams.MaterialID = this._DrugDefinition.ObjectID;
        inputParams.DocumentType = MaterialDocumentType.Sartname;
        inputParams.OldDocuments = new Array<DocumentGridModel>();
        if (this.drugDefinitionFormViewModel.MaterialDocumentations != null && this.drugDefinitionFormViewModel.MaterialDocumentations.length > 0) {
            for (let doc of this.drugDefinitionFormViewModel.MaterialDocumentations.filter(x => x.MaterialDocumentType == MaterialDocumentType.Sartname)) {
                let document: DocumentGridModel = new DocumentGridModel();
                document.File = doc.File;
                document.FileName = doc.FileName;
                document.FileUpdateDate = doc.FileUpdateDate;
                document.IsNew = false;
                document.Material = doc.Material;
                document.MaterialDocumentType = doc.MaterialDocumentType;
                document.ObjectID = doc.ObjectID;
                inputParams.OldDocuments.push(document);
            }
        }

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'LogisticDocumentUploadForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(inputParams, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "Dosya Yükleme / İndirme");
            modalInfo.Width = 1200;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });

    }

    openLogisticDocumentAllaergy() {
        let inputParams: OpenLogisticDocumentInputParams = new OpenLogisticDocumentInputParams();
        inputParams.MaterialID = this._DrugDefinition.ObjectID;
        inputParams.DocumentType = MaterialDocumentType.AlerjikReaksiyon;
        inputParams.OldDocuments = new Array<DocumentGridModel>();
        if (this.drugDefinitionFormViewModel.MaterialDocumentations != null && this.drugDefinitionFormViewModel.MaterialDocumentations.length > 0) {
            for (let doc of this.drugDefinitionFormViewModel.MaterialDocumentations.filter(x => x.MaterialDocumentType == MaterialDocumentType.AlerjikReaksiyon)) {
                let document: DocumentGridModel = new DocumentGridModel();
                document.File = doc.File;
                document.FileName = doc.FileName;
                document.FileUpdateDate = doc.FileUpdateDate;
                document.IsNew = false;
                document.Material = doc.Material;
                document.MaterialDocumentType = doc.MaterialDocumentType;
                document.ObjectID = doc.ObjectID;
                inputParams.OldDocuments.push(document);
            }
        }

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'LogisticDocumentUploadForm';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = new DynamicComponentInputParam(inputParams, null);

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M16835", "Dosya Yükleme / İndirme");
            modalInfo.Width = 1200;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    selectItem(e) {
        this.currentItem = e.selectedRowKeys[0].ObjectID;
        this.currentItemName = e.selectedRowKeys[0].FileName;
    }

    selectItemAlerjik(e) {
        this.currentItemAlerjik = e.selectedRowKeys[0].ObjectID;
        this.currentItemNameAlerjik = e.selectedRowKeys[0].FileName;
    }


    downloadSelectedFiles() {

        let apiUrl: string = '/api/DrugDefinitionService/DownloadFile';
        let input = { id: this.currentItem };
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;

        this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
            (res) => {
                CommonHelper.saveFile(res.blob(), this.currentItemName);
            });

    }

    downloadAlerjikSelectedFiles() {

        let apiUrl: string = '/api/DrugDefinitionService/DownloadFile';
        let input = { id: this.currentItem };
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let options = new RequestOptions();
        options.headers = headers;
        options.responseType = ResponseContentType.Blob;

        this.http2.post(apiUrl, JSON.stringify(input), options).toPromise().then(
            (res) => {
                CommonHelper.saveFile(res.blob(), this.currentItemName);
            });

    }

    filegrid() {
        if (this.drugDefinitionFormViewModel.MaterialDocumentations) {
            this._DrugDefinition.MaterialDocumentations = this.drugDefinitionFormViewModel.MaterialDocumentations.filter(x => x.MaterialDocumentType == MaterialDocumentType.Sartname);
            if (this.docsUpload.length == 0) {
                for (let matDoc of this._DrugDefinition.MaterialDocumentations) {
                    const doc: UploadFile_Input = new UploadFile_Input();
                    doc.File = matDoc.File;
                    doc.FileUpdateDate = matDoc.FileUpdateDate;
                    doc.IsNew = true;
                    doc.FileName = matDoc.FileName;
                    doc.Material = matDoc.Material;
                    doc.ObjectID = matDoc.ObjectID;
                    this.docsUpload.push(doc);
                }
            }
        }
    }
    fileAlerjikgrid() {
        if (this.drugDefinitionFormViewModel.MaterialDocumentations) {
            this._DrugDefinition.MaterialDocumentations = this.drugDefinitionFormViewModel.MaterialDocumentations.filter(x => x.MaterialDocumentType == MaterialDocumentType.AlerjikReaksiyon);
            if (this.docsAlerjikUpload.length == 0) {
                for (let matDoc of this._DrugDefinition.MaterialDocumentations) {
                    const doc: UploadFile_Input = new UploadFile_Input();
                    doc.File = matDoc.File;
                    doc.FileUpdateDate = matDoc.FileUpdateDate;
                    doc.IsNew = true;
                    doc.FileName = matDoc.FileName;
                    doc.Material = matDoc.Material;
                    doc.ObjectID = matDoc.ObjectID;
                    this.docsAlerjikUpload.push(doc);
                }
            }
        }
    }

    deleteDocumentUnSaved(data) {
        //this.docs.splice(this.docs.indexOf(data), 1);
    }
    deleteAlerjikDocumentUnSaved(data) {

    }


    protected redirectProperties(): void {
        /*redirectProperty ile Converter'dan oluşturduğumuz propertyler 
        burada property olarak tanımlanıyor,kullanılıyor */
        redirectProperty(this.Barcode, "Text", this.__ttObject, "Barcode");
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.Chargable, "Value", this.__ttObject, "Chargable");
        redirectProperty(this.IsExpendableMaterial, "Value", this.__ttObject, "IsExpendableMaterial");
        redirectProperty(this.AllowToGivePatient, "Value", this.__ttObject, "AllowToGivePatient");
        redirectProperty(this.PatientSafetyFrom, "Value", this.__ttObject, "PatientSafetyFrom");
        redirectProperty(this.IsPsychotropic, "Value", this.__ttObject, "IsPsychotropic");
        redirectProperty(this.IsNarcotic, "Value", this.__ttObject, "IsNarcotic");
        redirectProperty(this.IsPackageExclusive, "Value", this.__ttObject, "IsPackageExclusive");
        redirectProperty(this.SgkReturnPay, "Value", this.__ttObject, "SgkReturnPay");
        redirectProperty(this.IsOldMaterial, "Value", this.__ttObject, "IsOldMaterial");
        redirectProperty(this.IsArmyDrug, "Value", this.__ttObject, "IsArmyDrug");
        redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.OriginalName, "Text", this.__ttObject, "OriginalName");
        redirectProperty(this.WithOutStockInheld, "Value", this.__ttObject, "WithOutStockInheld");
        redirectProperty(this.ttcheckbox1, "Value", this.__ttObject, "ShowZeroOnDrugOrder");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.ttcheckbox2, "Value", this.__ttObject, "ShowZeroOnDistributionInfo");
        redirectProperty(this.DrugNutrientInteraction, "Text", this.__ttObject, "DrugNutrientInteraction");
        redirectProperty(this.Color, "Value", this.__ttObject, "Color");
        redirectProperty(this.DrugSpecification, "Value", this.__ttObject, "DrugSpecification");
        redirectProperty(this.SendSMS, "Value", this.__ttObject, "SendSMS");
        redirectProperty(this.PaidPayment, "Value", this.__ttObject, "PaidPayment");
        redirectProperty(this.NotAppearInEpicrisis, "Value", this.__ttObject, "NotAppearInEpicrisis");
        redirectProperty(this.DivisibleDrug, "Value", this.__ttObject, "DivisibleDrug");
        redirectProperty(this.DoNotLeaveTheBarcode, "Value", this.__ttObject, "DoNotLeaveTheBarcode");
        redirectProperty(this.MkysMalzemeKodu, "Text", this.__ttObject, "MkysMalzemeKodu");
        redirectProperty(this.StorageConditions, "Text", this.__ttObject, "StorageConditions");
        redirectProperty(this.EstimatedTimeOfCheck, "Text", this.__ttObject, "EstimatedTimeOfCheck");
        redirectProperty(this.Frequency, "Value", this.__ttObject, "Frequency");
        redirectProperty(this.RoutineDose, "Text", this.__ttObject, "RoutineDose");
        redirectProperty(this.RoutineDay, "Text", this.__ttObject, "RoutineDay");
        redirectProperty(this.MaxDose, "Text", this.__ttObject, "MaxDose");
        redirectProperty(this.Dose, "Text", this.__ttObject, "Dose");
        redirectProperty(this.Volume, "Text", this.__ttObject, "Volume");
        redirectProperty(this.MaxDoseDay, "Text", this.__ttObject, "MaxDoseDay");
        redirectProperty(this.OrderRPTDay, "Text", this.__ttObject, "OrderRPTDay");
        redirectProperty(this.PrescriptionType, "Value", this.__ttObject, "PrescriptionType");
        redirectProperty(this.SpecialistApproval, "Value", this.__ttObject, "InfectionApproval");
        redirectProperty(this.tttextbox1, "Text", this.__ttObject, "MinPatientAge");
        redirectProperty(this.tttextbox2, "Text", this.__ttObject, "MaxPatientAge");
        redirectProperty(this.ttenumcombobox1, "Value", this.__ttObject, "DrugShapeType");
        redirectProperty(this.ProductNumber, "Text", this.__ttObject, "ProductNumber");
        redirectProperty(this.BarcodeName, "Text", this.__ttObject, "BarcodeName");
        redirectProperty(this.PackageAmount, "Text", this.__ttObject, "PackageAmount");
        redirectProperty(this.CurrentPrice, "Text", this.__ttObject, "CurrentPrice");
        redirectProperty(this.InstitutionDiscountRate, "Text", this.__ttObject, "InstitutionDiscountRate");
        redirectProperty(this.PharmacistDiscountRate, "Text", this.__ttObject, "PharmacistDiscountRate");
        redirectProperty(this.LicenceDate, "Value", this.__ttObject, "LicenceDate");
        redirectProperty(this.LicenceNO, "Text", this.__ttObject, "LicenceNO");
        redirectProperty(this.LicencingOrganization, "Value", this.__ttObject, "LicencingOrganization");
        redirectProperty(this.MaterialPricingType, "Value", this.__ttObject, "MaterialPricingType");
        redirectProperty(this.txtUnitPriceDivider, "Text", this.__ttObject, "AccTrxUnitPriceDivider");
        redirectProperty(this.txtAmountMultiplier, "Text", this.__ttObject, "AccTrxAmountMultiplier");
        redirectProperty(this.PurchaseDate, "Value", this.__ttObject, "PurchaseDate");
        redirectProperty(this.ReimbursementUnder, "Value", this.__ttObject, "ReimbursementUnder");
        redirectProperty(this.CreateInMedulaDontSendState, "Value", this.__ttObject, "CreateInMedulaDontSendState");
        redirectProperty(this.DividePriceToVolume, "Value", this.__ttObject, "DividePriceToVolume");
        redirectProperty(this.SetMedulaInfoByMultiplier, "Value", this.__ttObject, "SetMedulaInfoByMultiplier");
        redirectProperty(this.MedulaMultiplier, "Text", this.__ttObject, "MedulaMultiplier");
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");
        redirectProperty(this.ETKMDescription, "Text", this.__ttObject, "ETKMDescription");
        redirectProperty(this.OrderRPTDay, "Text", this.__ttObject, "OrderRPTDay");
        redirectProperty(this.PatientMaxDayOut, "Text", this.__ttObject, "PatientMaxDayOut");
        redirectProperty(this.SEX, "Value", this.__ttObject, "SEX");
        redirectProperty(this.OutpatientReportType, "Value", this.__ttObject, "OutpatientReportType");
        redirectProperty(this.InpatientReportType, "Value", this.__ttObject, "InpatientReportType");
    }

    public initFormControls(): void {

        this.grdMaterialProcedures = new TTVisual.TTObjectListBox();
        this.grdMaterialProcedures.Name = "grdMaterialProcedures";
        this.grdMaterialProcedures.ListDefName = 'ProcedureListDefinition';
        this.grdMaterialProcedures.TabIndex = 64;


        this.DoNotLeaveTheBarcode = new TTVisual.TTCheckBox();
        this.DoNotLeaveTheBarcode.Value = false;
        this.DoNotLeaveTheBarcode.Text = "Barkoda Çıkmasın";
        this.DoNotLeaveTheBarcode.Name = "DoNotLeaveTheBarcode";
        this.DoNotLeaveTheBarcode.TabIndex = 67;


        this.DivisibleDrug = new TTVisual.TTCheckBox();
        this.DivisibleDrug.Value = false;
        this.DivisibleDrug.Text = "Bölünebilir İlaç";
        this.DivisibleDrug.Name = "DivisibleDrug";
        this.DivisibleDrug.TabIndex = 66;

        this.NotAppearInEpicrisis = new TTVisual.TTCheckBox();
        this.NotAppearInEpicrisis.Value = false;
        this.NotAppearInEpicrisis.Text = "Epikriz Formunda Görünmesin";
        this.NotAppearInEpicrisis.Name = "NotAppearInEpicrisis";
        this.NotAppearInEpicrisis.TabIndex = 65;

        this.PaidPayment = new TTVisual.TTCheckBox();
        this.PaidPayment.Value = false;
        this.PaidPayment.Text = "Ödeme Türü Ücretli Olsun";
        this.PaidPayment.Name = "PaidPayment";
        this.PaidPayment.TabIndex = 64;

        this.SendSMS = new TTVisual.TTCheckBox();
        this.SendSMS.Value = false;
        this.SendSMS.Text = "SMS Gönder";
        this.SendSMS.Name = "SendSMS";
        this.SendSMS.TabIndex = 63;

        this.labelColor = new TTVisual.TTLabel();
        this.labelColor.Text = "Renk";
        this.labelColor.Name = "labelColor";
        this.labelColor.TabIndex = 62;

        this.Color = new TTVisual.TTEnumComboBox();
        this.Color.DataTypeName = "ColorEnum";
        this.Color.Name = "Color";
        this.Color.TabIndex = 61;

        this.labelDrugNutrientInteraction = new TTVisual.TTLabel();
        this.labelDrugNutrientInteraction.Text = "İlaç Besin Etkileşimi";
        this.labelDrugNutrientInteraction.Name = "labelDrugNutrientInteraction";
        this.labelDrugNutrientInteraction.TabIndex = 60;

        this.DrugNutrientInteraction = new TTVisual.TTTextBox();
        this.DrugNutrientInteraction.Multiline = true;
        this.DrugNutrientInteraction.Name = "DrugNutrientInteraction";
        this.DrugNutrientInteraction.TabIndex = 59;

        this.MkysMalzemeKodu = new TTVisual.TTTextBox();
        this.MkysMalzemeKodu.Name = "MkysMalzemeKodu";
        this.MkysMalzemeKodu.TabIndex = 47;

        this.EstimatedTimeOfCheck = new TTVisual.TTTextBox();
        this.EstimatedTimeOfCheck.Name = "EstimatedTimeOfCheck";
        this.EstimatedTimeOfCheck.TabIndex = 45;

        this.StorageConditions = new TTVisual.TTTextBox();
        this.StorageConditions.Name = "StorageConditions";
        this.StorageConditions.TabIndex = 43;

        this.Barcode = new TTVisual.TTTextBox();
        this.Barcode.Name = "Barcode";
        this.Barcode.TabIndex = 28;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 1;

        this.OriginalName = new TTVisual.TTTextBox();
        this.OriginalName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OriginalName.Name = "OriginalName";
        this.OriginalName.TabIndex = 3;

        this.SgkReturnPay = new TTVisual.TTCheckBox();
        this.SgkReturnPay.Value = false;
        this.SgkReturnPay.Text = "SGK Geri Ödeme";
        this.SgkReturnPay.Name = "SgkReturnPay";
        this.SgkReturnPay.TabIndex = 58;

        this.IsNarcotic = new TTVisual.TTCheckBox();
        this.IsNarcotic.Value = false;
        this.IsNarcotic.Text = "Narkotik Madde İçerir";
        this.IsNarcotic.Name = "IsNarcotic";
        this.IsNarcotic.TabIndex = 50;

        this.IsPsychotropic = new TTVisual.TTCheckBox();
        this.IsPsychotropic.Value = false;
        this.IsPsychotropic.Text = "Psikotrop Madde İçerir";
        this.IsPsychotropic.Name = "IsPsychotropic";
        this.IsPsychotropic.TabIndex = 49;

        this.labelMkysMalzemeKodu = new TTVisual.TTLabel();
        this.labelMkysMalzemeKodu.Text = "Mkys Malzeme Kodu";
        this.labelMkysMalzemeKodu.Name = "labelMkysMalzemeKodu";
        this.labelMkysMalzemeKodu.TabIndex = 48;

        this.labelEstimatedTimeOfCheck = new TTVisual.TTLabel();
        this.labelEstimatedTimeOfCheck.Text = "Tahmini Teymin Süresi";
        this.labelEstimatedTimeOfCheck.Name = "labelEstimatedTimeOfCheck";
        this.labelEstimatedTimeOfCheck.TabIndex = 46;

        this.labelStorageConditions = new TTVisual.TTLabel();
        this.labelStorageConditions.Text = "Depolama Koşulları";
        this.labelStorageConditions.Name = "labelStorageConditions";
        this.labelStorageConditions.TabIndex = 44;

        this.SosFarmaCheckBox = new TTVisual.TTCheckBox();
        this.SosFarmaCheckBox.Value = false;
        this.SosFarmaCheckBox.Text = "İlaç Bilgi Bankası";
        this.SosFarmaCheckBox.Enabled = false;
        this.SosFarmaCheckBox.Name = "SosFarmaCheckBox";
        this.SosFarmaCheckBox.TabIndex = 40;

        this.labelDistributionTypeStockCard = new TTVisual.TTLabel();
        this.labelDistributionTypeStockCard.Text = "Stok Kartı Dağıtım Şekli";
        this.labelDistributionTypeStockCard.Name = "labelDistributionTypeStockCard";
        this.labelDistributionTypeStockCard.TabIndex = 39;

        this.DistributionTypeStockCard = new TTVisual.TTObjectListBox();
        this.DistributionTypeStockCard.ListDefName = "DistributionTypeList";
        this.DistributionTypeStockCard.Name = "DistributionTypeStockCard";
        this.DistributionTypeStockCard.TabIndex = 38;

        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = "Açılış Tarihi";
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 37;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.BackColor = "#F0F0F0";
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Enabled = false;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 36;

        this.PatientSafetyFrom = new TTVisual.TTCheckBox();
        this.PatientSafetyFrom.Value = false;
        this.PatientSafetyFrom.Text = "Hasta Güvenlik ve İzleme Formu";
        this.PatientSafetyFrom.Name = "PatientSafetyFrom";
        this.PatientSafetyFrom.TabIndex = 35;

        this.cmdChangeTypeToConsumableButton = new TTVisual.TTButton();
        this.cmdChangeTypeToConsumableButton.Text = "Sarfa Çevir";
        this.cmdChangeTypeToConsumableButton.Name = "cmdChangeTypeToConsumableButton";
        this.cmdChangeTypeToConsumableButton.TabIndex = 34;

        this.IsOldMaterial = new TTVisual.TTCheckBox();
        this.IsOldMaterial.Value = false;
        this.IsOldMaterial.Text = "Eski Malzeme";
        this.IsOldMaterial.Name = "IsOldMaterial";
        this.IsOldMaterial.TabIndex = 33;

        this.labelEtkinMadde = new TTVisual.TTLabel();
        this.labelEtkinMadde.Text = "SGK Etkin Madde";
        this.labelEtkinMadde.Name = "labelEtkinMadde";
        this.labelEtkinMadde.TabIndex = 32;

        this.EtkinMadde = new TTVisual.TTObjectListBox();
        this.EtkinMadde.ListDefName = "EtkinMaddeListDefinition";
        this.EtkinMadde.Name = "EtkinMadde";
        this.EtkinMadde.TabIndex = 31;

        this.IsExpendableMaterial = new TTVisual.TTCheckBox();
        this.IsExpendableMaterial.Value = false;
        this.IsExpendableMaterial.Text = "Atık Depolara Atılabilir";
        this.IsExpendableMaterial.Name = "IsExpendableMaterial";
        this.IsExpendableMaterial.TabIndex = 30;

        this.labelBarcode = new TTVisual.TTLabel();
        this.labelBarcode.Text = "Orjinal Ürün Numarası";
        this.labelBarcode.Name = "labelBarcode";
        this.labelBarcode.TabIndex = 29;

        this.WithOutStockInheld = new TTVisual.TTCheckBox();
        this.WithOutStockInheld.Value = false;
        this.WithOutStockInheld.Text = "Var/Yok";
        this.WithOutStockInheld.Name = "WithOutStockInheld";
        this.WithOutStockInheld.TabIndex = 24;
        this.WithOutStockInheld.Visible = false;

        this.labelMaterialTree = new TTVisual.TTLabel();
        this.labelMaterialTree.Text = "Malzeme Grubu";
        this.labelMaterialTree.BackColor = "#DCDCDC";
        this.labelMaterialTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaterialTree.ForeColor = "#000000";
        this.labelMaterialTree.Name = "labelMaterialTree";
        this.labelMaterialTree.TabIndex = 11;

        this.labelStockCard = new TTVisual.TTLabel();
        this.labelStockCard.Text = "Stok Kartı";
        this.labelStockCard.BackColor = "#DCDCDC";
        this.labelStockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockCard.ForeColor = "#000000";
        this.labelStockCard.Name = "labelStockCard";
        this.labelStockCard.TabIndex = 10;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "İlaç Kodu";
        this.labelCode.BackColor = "#DCDCDC";
        this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCode.ForeColor = "#000000";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 7;

        this.IsActive = new TTVisual.TTCheckBox();
        this.IsActive.Value = false;
        this.IsActive.Text = "Aktif/Pasif";
        this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IsActive.Name = "IsActive";
        this.IsActive.TabIndex = 2;

        this.labelEnglishName = new TTVisual.TTLabel();
        this.labelEnglishName.Text = "Orjinal Adı";
        this.labelEnglishName.BackColor = "#DCDCDC";
        this.labelEnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelEnglishName.ForeColor = "#000000";
        this.labelEnglishName.Name = "labelEnglishName";
        this.labelEnglishName.TabIndex = 9;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "Türkçe  Adı";
        this.labelName.BackColor = "#DCDCDC";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 8;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 23;

        this.PropertyTabPage = new TTVisual.TTTabPage();
        this.PropertyTabPage.DisplayIndex = 0;
        this.PropertyTabPage.BackColor = "#FFFFFF";
        this.PropertyTabPage.TabIndex = 0;
        this.PropertyTabPage.Text = "Özellikler";
        this.PropertyTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PropertyTabPage.Name = "PropertyTabPage";

        this.labelOrderRPTDay = new TTVisual.TTLabel();
        this.labelOrderRPTDay.Text = "Tekrar Gün";
        this.labelOrderRPTDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelOrderRPTDay.Name = "labelOrderRPTDay";
        this.labelOrderRPTDay.TabIndex = 64;

        this.ttenumcombobox1 = new TTVisual.TTEnumComboBox();
        this.ttenumcombobox1.DataTypeName = "DrugShapeTypeEnum";
        this.ttenumcombobox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttenumcombobox1.Name = "ttenumcombobox1";
        this.ttenumcombobox1.TabIndex = 27;

        this.OrderRPTDay = new TTVisual.TTTextBox();
        this.OrderRPTDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OrderRPTDay.Name = "OrderRPTDay";
        this.OrderRPTDay.TabIndex = 63;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Onaylar";
        this.ttgroupbox1.BackColor = "#FFFFFF";
        this.ttgroupbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 26;

        this.SpecialistApproval = new TTVisual.TTCheckBox();
        this.SpecialistApproval.Value = false;
        this.SpecialistApproval.Text = "Enfeksiyon Kom. Onay";
        this.SpecialistApproval.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SpecialistApproval.Name = "SpecialistApproval";
        this.SpecialistApproval.TabIndex = 24;

        this.SpecialistDoctorApproval = new TTVisual.TTCheckBox();
        this.SpecialistDoctorApproval.Value = false;
        this.SpecialistDoctorApproval.Text = "Uzman Tabip Onayı";
        this.SpecialistDoctorApproval.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SpecialistDoctorApproval.Name = "SpecialistDoctorApproval";
        this.SpecialistDoctorApproval.TabIndex = 25;

        this.labelGenericDrug = new TTVisual.TTLabel();
        this.labelGenericDrug.Text = "İlaç Jeneriği";
        this.labelGenericDrug.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelGenericDrug.ForeColor = "#000000";
        this.labelGenericDrug.Name = "labelGenericDrug";
        this.labelGenericDrug.TabIndex = 22;

        this.PrescriptionType = new TTVisual.TTEnumComboBox();
        this.PrescriptionType.DataTypeName = "PrescriptionTypeEnum";
        this.PrescriptionType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PrescriptionType.Name = "PrescriptionType";
        this.PrescriptionType.TabIndex = 9;

        this.labelPrescriptionType = new TTVisual.TTLabel();
        this.labelPrescriptionType.Text = "Reçete Türü";
        this.labelPrescriptionType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPrescriptionType.ForeColor = "#000000";
        this.labelPrescriptionType.Name = "labelPrescriptionType";
        this.labelPrescriptionType.TabIndex = 21;

        this.labelVolumeUnit = new TTVisual.TTLabel();
        this.labelVolumeUnit.Text = "Birim";
        this.labelVolumeUnit.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelVolumeUnit.ForeColor = "#000000";
        this.labelVolumeUnit.Name = "labelVolumeUnit";
        this.labelVolumeUnit.TabIndex = 14;

        this.Volume = new TTVisual.TTTextBox();
        this.Volume.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Volume.Name = "Volume";
        this.Volume.TabIndex = 1;

        this.labelNFC = new TTVisual.TTLabel();
        this.labelNFC.Text = "NFC";
        this.labelNFC.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNFC.ForeColor = "#000000";
        this.labelNFC.Name = "labelNFC";
        this.labelNFC.TabIndex = 19;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Rutin Değerler";
        this.ttgroupbox2.BackColor = "#FFFFFF";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 23;

        this.labelRoutineDay = new TTVisual.TTLabel();
        this.labelRoutineDay.Text = "Gün";
        this.labelRoutineDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoutineDay.ForeColor = "#000000";
        this.labelRoutineDay.Name = "labelRoutineDay";
        this.labelRoutineDay.TabIndex = 19;

        this.labelFrequency = new TTVisual.TTLabel();
        this.labelFrequency.Text = "Doz Aralığı";
        this.labelFrequency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelFrequency.ForeColor = "#000000";
        this.labelFrequency.Name = "labelFrequency";
        this.labelFrequency.TabIndex = 28;

        this.RoutineDay = new TTVisual.TTTextBox();
        this.RoutineDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoutineDay.Name = "RoutineDay";
        this.RoutineDay.TabIndex = 17;

        this.RoutineDose = new TTVisual.TTTextBox();
        this.RoutineDose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoutineDose.Name = "RoutineDose";
        this.RoutineDose.TabIndex = 18;

        this.labelRoutineDose = new TTVisual.TTLabel();
        this.labelRoutineDose.Text = "Doz Miktarı";
        this.labelRoutineDose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoutineDose.ForeColor = "#000000";
        this.labelRoutineDose.Name = "labelRoutineDose";
        this.labelRoutineDose.TabIndex = 20;

        this.Frequency = new TTVisual.TTEnumComboBox();
        this.Frequency.DataTypeName = "FrequencyEnum";
        this.Frequency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Frequency.Name = "Frequency";
        this.Frequency.TabIndex = 25;

        this.DrugATCs = new TTVisual.TTGrid();
        this.DrugATCs.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DrugATCs.Name = "DrugATCs";
        this.DrugATCs.TabIndex = 11;

        this.ATC = new TTVisual.TTListBoxColumn();
        this.ATC.ListDefName = "ATCList";
        this.ATC.DataMember = "ATC";
        this.ATC.DisplayIndex = 0;
        this.ATC.HeaderText = "ATC Adı";
        this.ATC.Name = "ATC";
        this.ATC.Width = 400;

        this.MaxDoseDay = new TTVisual.TTTextBox();
        this.MaxDoseDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaxDoseDay.Name = "MaxDoseDay";
        this.MaxDoseDay.TabIndex = 5;

        this.labelMaxDoseDay = new TTVisual.TTLabel();
        this.labelMaxDoseDay.Text = "Max. Gün";
        this.labelMaxDoseDay.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaxDoseDay.ForeColor = "#000000";
        this.labelMaxDoseDay.Name = "labelMaxDoseDay";
        this.labelMaxDoseDay.TabIndex = 17;

        this.labelVolume = new TTVisual.TTLabel();
        this.labelVolume.Text = "Hacim";
        this.labelVolume.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelVolume.ForeColor = "#000000";
        this.labelVolume.Name = "labelVolume";
        this.labelVolume.TabIndex = 13;

        this.MaxDose = new TTVisual.TTTextBox();
        this.MaxDose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaxDose.Name = "MaxDose";
        this.MaxDose.TabIndex = 6;

        this.Dose = new TTVisual.TTTextBox();
        this.Dose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Dose.Name = "Dose";
        this.Dose.TabIndex = 0;

        this.VolumeUnit = new TTVisual.TTObjectListBox();
        this.VolumeUnit.ListDefName = "UnitListDefinition";
        this.VolumeUnit.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.VolumeUnit.Name = "VolumeUnit";
        this.VolumeUnit.TabIndex = 2;

        this.RouteOfAdmin = new TTVisual.TTObjectListBox();
        this.RouteOfAdmin.ListDefName = "RouteOfAdminListDefinition";
        this.RouteOfAdmin.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RouteOfAdmin.Name = "RouteOfAdmin";
        this.RouteOfAdmin.TabIndex = 8;
        this.RouteOfAdmin.PopupDialogHeight = "200";

        this.labelRouteOfAdmin = new TTVisual.TTLabel();
        this.labelRouteOfAdmin.Text = "Uygulama Şekli";
        this.labelRouteOfAdmin.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRouteOfAdmin.ForeColor = "#000000";
        this.labelRouteOfAdmin.Name = "labelRouteOfAdmin";
        this.labelRouteOfAdmin.TabIndex = 20;

        this.labelDose = new TTVisual.TTLabel();
        this.labelDose.Text = "Doz";
        this.labelDose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelDose.ForeColor = "#000000";
        this.labelDose.Name = "labelDose";
        this.labelDose.TabIndex = 12;

        this.GenericDrug = new TTVisual.TTObjectListBox();
        this.GenericDrug.ListDefName = "DrugGenericList";
        this.GenericDrug.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GenericDrug.Name = "GenericDrug";
        this.GenericDrug.TabIndex = 10;

        this.NFC = new TTVisual.TTObjectListBox();
        this.NFC.ListDefName = "NFCList";
        this.NFC.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.NFC.Name = "NFC";
        this.NFC.TabIndex = 7;

        this.labelMaxDose = new TTVisual.TTLabel();
        this.labelMaxDose.Text = "Maksimum Doz";
        this.labelMaxDose.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaxDose.ForeColor = "#000000";
        this.labelMaxDose.Name = "labelMaxDose";
        this.labelMaxDose.TabIndex = 18;

        this.tttextbox1 = new TTVisual.TTTextBox();
        this.tttextbox1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox1.Name = "tttextbox1";
        this.tttextbox1.TabIndex = 17;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Uygulanabilir En Küçük Yaş";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 19;

        this.tttextbox2 = new TTVisual.TTTextBox();
        this.tttextbox2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.tttextbox2.Name = "tttextbox2";
        this.tttextbox2.TabIndex = 17;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Uygulanabilir En Büyük Yaş";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 19;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "İlacın Şekli/Türü";
        this.ttlabel5.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.ForeColor = "#000000";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 19;

        this.FormuleTabPage = new TTVisual.TTTabPage();
        this.FormuleTabPage.DisplayIndex = 1;
        this.FormuleTabPage.BackColor = "#FFFFFF";
        this.FormuleTabPage.TabIndex = 0;
        this.FormuleTabPage.Text = "Formülü";
        this.FormuleTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.FormuleTabPage.Name = "FormuleTabPage";

        this.DrugActiveIngredients = new TTVisual.TTGrid();
        this.DrugActiveIngredients.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DrugActiveIngredients.Name = "DrugActiveIngredients";
        this.DrugActiveIngredients.TabIndex = 0;

        this.ActiveIngredient = new TTVisual.TTListBoxColumn();
        this.ActiveIngredient.ListDefName = "ActiveIngredientList";
        this.ActiveIngredient.DataMember = "ActiveIngredient";
        this.ActiveIngredient.DisplayIndex = 0;
        this.ActiveIngredient.HeaderText = "Etken Madde Adı";
        this.ActiveIngredient.Name = "ActiveIngredient";
        this.ActiveIngredient.Width = 300;

        this.Unit = new TTVisual.TTListBoxColumn();
        this.Unit.ListDefName = "UnitListDefinition";
        this.Unit.DataMember = "Unit";
        this.Unit.DisplayIndex = 1;
        this.Unit.HeaderText = "Birim";
        this.Unit.Name = "Unit";
        this.Unit.Width = 80;

        this.Value = new TTVisual.TTTextBoxColumn();
        this.Value.DataMember = "Value";
        this.Value.DisplayIndex = 2;
        this.Value.HeaderText = "Değer";
        this.Value.Name = "Value";
        this.Value.Width = 80;

        this.FormulaMaxDose = new TTVisual.TTTextBoxColumn();
        this.FormulaMaxDose.DataMember = "MaxDose";
        this.FormulaMaxDose.DisplayIndex = 3;
        this.FormulaMaxDose.HeaderText = "Maximum Doz";
        this.FormulaMaxDose.Name = "FormulaMaxDose";
        this.FormulaMaxDose.Width = 80;

        this.MaxDoseUnit = new TTVisual.TTListBoxColumn();
        this.MaxDoseUnit.ListDefName = "UnitListDefinition";
        this.MaxDoseUnit.DataMember = "MaxDoseUnit";
        this.MaxDoseUnit.DisplayIndex = 4;
        this.MaxDoseUnit.HeaderText = "Maximum Doz Birim";
        this.MaxDoseUnit.Name = "MaxDoseUnit";
        this.MaxDoseUnit.Width = 115;

        this.IsParentIngredient = new TTVisual.TTCheckBoxColumn();
        this.IsParentIngredient.DataMember = "IsParentIngredient";
        this.IsParentIngredient.DisplayIndex = 5;
        this.IsParentIngredient.HeaderText = "Etkin";
        this.IsParentIngredient.Name = "IsParentIngredient";
        this.IsParentIngredient.Width = 80;

        this.ProductionTabPage = new TTVisual.TTTabPage();
        this.ProductionTabPage.DisplayIndex = 2;
        this.ProductionTabPage.BackColor = "#FFFFFF";
        this.ProductionTabPage.TabIndex = 0;
        this.ProductionTabPage.Text = "Üretim Detay Bilgileri";
        this.ProductionTabPage.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProductionTabPage.Name = "ProductionTabPage";

        this.gbxAmountPrice = new TTVisual.TTGroupBox();
        this.gbxAmountPrice.Text = "Ücretlendirme";
        this.gbxAmountPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.gbxAmountPrice.Name = "gbxAmountPrice";
        this.gbxAmountPrice.TabIndex = 39;

        this.txtTestAmount = new TTVisual.TTTextBox();
        this.txtTestAmount.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtTestAmount.Name = "txtTestAmount";
        this.txtTestAmount.TabIndex = 8;

        this.btnCalculate = new TTVisual.TTButton();
        this.btnCalculate.Text = "Hesapla";
        this.btnCalculate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.btnCalculate.Name = "btnCalculate";
        this.btnCalculate.TabIndex = 6;

        this.txtAmountMultiplier = new TTVisual.TTTextBox();
        this.txtAmountMultiplier.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtAmountMultiplier.Name = "txtAmountMultiplier";
        this.txtAmountMultiplier.TabIndex = 4;

        this.txtUnitPriceDivider = new TTVisual.TTTextBox();
        this.txtUnitPriceDivider.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.txtUnitPriceDivider.Name = "txtUnitPriceDivider";
        this.txtUnitPriceDivider.TabIndex = 3;

        this.lblTestAmount = new TTVisual.TTLabel();
        this.lblTestAmount.Text = "Test Miktarı";
        this.lblTestAmount.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblTestAmount.Name = "lblTestAmount";
        this.lblTestAmount.TabIndex = 2;

        this.lblAmountMultiplier = new TTVisual.TTLabel();
        this.lblAmountMultiplier.Text = "Miktar Çarpanı";
        this.lblAmountMultiplier.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblAmountMultiplier.Name = "lblAmountMultiplier";
        this.lblAmountMultiplier.TabIndex = 1;

        this.lblUnitPriceDivider = new TTVisual.TTLabel();
        this.lblUnitPriceDivider.Text = "Birim Fiyat Böleni";
        this.lblUnitPriceDivider.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblUnitPriceDivider.Name = "lblUnitPriceDivider";
        this.lblUnitPriceDivider.TabIndex = 0;

        this.SetMedulaInfoByMultiplier = new TTVisual.TTCheckBox();
        this.SetMedulaInfoByMultiplier.Value = false;
        this.SetMedulaInfoByMultiplier.Text = "Medulaya Malzeme Kaydında Adet ve Fiyat Bilgisi Çarpana Göre Ayarlanır";
        this.SetMedulaInfoByMultiplier.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SetMedulaInfoByMultiplier.Name = "SetMedulaInfoByMultiplier";
        this.SetMedulaInfoByMultiplier.TabIndex = 38;
        this.SetMedulaInfoByMultiplier.Visible = false;

        this.CreateInMedulaDontSendState = new TTVisual.TTCheckBox();
        this.CreateInMedulaDontSendState.Value = false;
        this.CreateInMedulaDontSendState.Text = "Medulaya Gönderilmeyecek Durumunda Oluştur";
        this.CreateInMedulaDontSendState.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CreateInMedulaDontSendState.Name = "CreateInMedulaDontSendState";
        this.CreateInMedulaDontSendState.TabIndex = 37;

        this.DividePriceToVolume = new TTVisual.TTCheckBox();
        this.DividePriceToVolume.Value = false;
        this.DividePriceToVolume.Text = "Birim Fiyatı Hacime Bölünerek Hesaplanır";
        this.DividePriceToVolume.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DividePriceToVolume.Name = "DividePriceToVolume";
        this.DividePriceToVolume.TabIndex = 36;
        this.DividePriceToVolume.Visible = false;

        this.lblMedulaMultiplier = new TTVisual.TTLabel();
        this.lblMedulaMultiplier.Text = "Medula Çarpanı";
        this.lblMedulaMultiplier.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblMedulaMultiplier.Name = "lblMedulaMultiplier";
        this.lblMedulaMultiplier.TabIndex = 35;
        this.lblMedulaMultiplier.Visible = false;

        this.searchMedicineFromMedula = new TTVisual.TTButton();
        this.searchMedicineFromMedula.Text = "İlaç Ara";
        this.searchMedicineFromMedula.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.searchMedicineFromMedula.Name = "searchMedicineFromMedula";
        this.searchMedicineFromMedula.TabIndex = 26;

        this.MedulaMultiplier = new TTVisual.TTTextBox();
        this.MedulaMultiplier.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MedulaMultiplier.Name = "MedulaMultiplier";
        this.MedulaMultiplier.TabIndex = 34;
        this.MedulaMultiplier.Visible = false;

        this.labelPurchaseDate = new TTVisual.TTLabel();
        this.labelPurchaseDate.Text = "Satınalma Tarihi";
        this.labelPurchaseDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPurchaseDate.Name = "labelPurchaseDate";
        this.labelPurchaseDate.TabIndex = 25;

        this.PurchaseDate = new TTVisual.TTDateTimePicker();
        this.PurchaseDate.Format = DateTimePickerFormat.Long;
        this.PurchaseDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PurchaseDate.Name = "PurchaseDate";
        this.PurchaseDate.TabIndex = 24;

        this.labelBrans = new TTVisual.TTLabel();
        this.labelBrans.Text = "Malzeme Branşı";
        this.labelBrans.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBrans.Name = "labelBrans";
        this.labelBrans.TabIndex = 23;

        this.ReimbursementUnder = new TTVisual.TTCheckBox();
        this.ReimbursementUnder.Value = false;
        this.ReimbursementUnder.Text = "Geri Ödeme Kapsamında";
        this.ReimbursementUnder.Name = "ReimbursementUnder";
        this.ReimbursementUnder.TabIndex = 27;

        this.Brans = new TTVisual.TTObjectListBox();
        this.Brans.ListDefName = "SpecialityListDefinition";
        this.Brans.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Brans.Name = "Brans";
        this.Brans.TabIndex = 22;

        this.labelMaterialPricingType = new TTVisual.TTLabel();
        this.labelMaterialPricingType.Text = "Malzeme Fiyatlandırma Türü";
        this.labelMaterialPricingType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaterialPricingType.Name = "labelMaterialPricingType";
        this.labelMaterialPricingType.TabIndex = 21;

        this.MaterialPricingType = new TTVisual.TTEnumComboBox();
        this.MaterialPricingType.DataTypeName = "MaterialPricingTypeEnum";
        this.MaterialPricingType.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaterialPricingType.Name = "MaterialPricingType";
        this.MaterialPricingType.TabIndex = 20;

        this.labelProducer = new TTVisual.TTLabel();
        this.labelProducer.Text = "Üretici";
        this.labelProducer.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProducer.Name = "labelProducer";
        this.labelProducer.TabIndex = 19;

        this.Producer = new TTVisual.TTObjectListBox();
        this.Producer.ListDefName = "ProducerListDefinition";
        this.Producer.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Producer.Name = "Producer";
        this.Producer.TabIndex = 18;

        this.labelProductNumber = new TTVisual.TTLabel();
        this.labelProductNumber.Text = "Ürün Numarası";
        this.labelProductNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProductNumber.Name = "labelProductNumber";
        this.labelProductNumber.TabIndex = 17;

        this.ProductNumber = new TTVisual.TTTextBox();
        this.ProductNumber.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProductNumber.Name = "ProductNumber";
        this.ProductNumber.TabIndex = 16;

        this.labelGMDNCodeStockCard = new TTVisual.TTLabel();
        this.labelGMDNCodeStockCard.Text = "GMDN Kodu";
        this.labelGMDNCodeStockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelGMDNCodeStockCard.Name = "labelGMDNCodeStockCard";
        this.labelGMDNCodeStockCard.TabIndex = 15;

        this.GMDNCodeStockCard = new TTVisual.TTObjectListBox();
        this.GMDNCodeStockCard.ListDefName = "GMDNCodeListDefinition";
        this.GMDNCodeStockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GMDNCodeStockCard.Name = "GMDNCodeStockCard";
        this.GMDNCodeStockCard.TabIndex = 14;

        this.labelPackageAmount = new TTVisual.TTLabel();
        this.labelPackageAmount.Text = "Ambalaj Miktarı";
        this.labelPackageAmount.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelPackageAmount.Name = "labelPackageAmount";
        this.labelPackageAmount.TabIndex = 13;

        this.PackageAmount = new TTVisual.TTTextBox();
        this.PackageAmount.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.TabIndex = 12;

        this.labelLicencingOrganization = new TTVisual.TTLabel();
        this.labelLicencingOrganization.Text = "Lisans Organizasyonu";
        this.labelLicencingOrganization.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelLicencingOrganization.Name = "labelLicencingOrganization";
        this.labelLicencingOrganization.TabIndex = 11;

        this.LicencingOrganization = new TTVisual.TTEnumComboBox();
        this.LicencingOrganization.DataTypeName = "LicencingOrganizationEnum";
        this.LicencingOrganization.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LicencingOrganization.Name = "LicencingOrganization";
        this.LicencingOrganization.TabIndex = 10;

        this.labelLicenceNO = new TTVisual.TTLabel();
        this.labelLicenceNO.Text = "Lisans Nu.";
        this.labelLicenceNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelLicenceNO.Name = "labelLicenceNO";
        this.labelLicenceNO.TabIndex = 9;

        this.LicenceNO = new TTVisual.TTTextBox();
        this.LicenceNO.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LicenceNO.Name = "LicenceNO";
        this.LicenceNO.TabIndex = 8;

        this.labelLicenceDate = new TTVisual.TTLabel();
        this.labelLicenceDate.Text = "Lisans Tarihi";
        this.labelLicenceDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelLicenceDate.Name = "labelLicenceDate";
        this.labelLicenceDate.TabIndex = 7;

        this.LicenceDate = new TTVisual.TTDateTimePicker();
        this.LicenceDate.Format = DateTimePickerFormat.Long;
        this.LicenceDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LicenceDate.Name = "LicenceDate";
        this.LicenceDate.TabIndex = 6;

        this.labelCurrentPrice = new TTVisual.TTLabel();
        this.labelCurrentPrice.Text = "Ambalaj Fiyatı";
        this.labelCurrentPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCurrentPrice.Name = "labelCurrentPrice";
        this.labelCurrentPrice.TabIndex = 5;

        this.CurrentPrice = new TTVisual.TTTextBox();
        this.CurrentPrice.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.CurrentPrice.Name = "CurrentPrice";
        this.CurrentPrice.TabIndex = 4;

        this.InstitutionDiscountRate = new TTVisual.TTTextBox();
        this.InstitutionDiscountRate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InstitutionDiscountRate.Name = "InstitutionDiscountRate";
        this.InstitutionDiscountRate.TabIndex = 4;

        this.PharmacistDiscountRate = new TTVisual.TTTextBox();
        this.PharmacistDiscountRate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PharmacistDiscountRate.Name = "PharmacistDiscountRate";
        this.PharmacistDiscountRate.TabIndex = 4;


        this.labelBarcodeName = new TTVisual.TTLabel();
        this.labelBarcodeName.Text = "Etiket Adı";
        this.labelBarcodeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBarcodeName.Name = "labelBarcodeName";
        this.labelBarcodeName.TabIndex = 3;

        this.BarcodeName = new TTVisual.TTTextBox();
        this.BarcodeName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BarcodeName.Name = "BarcodeName";
        this.BarcodeName.TabIndex = 2;

        this.KDVTabPage = new TTVisual.TTTabPage();
        this.KDVTabPage.DisplayIndex = 3;
        this.KDVTabPage.TabIndex = 1;
        this.KDVTabPage.Text = "Fiyat ve KDV Oranı Bilgileri";
        this.KDVTabPage.Name = "KDVTabPage";

        this.MaterialVatRates = new TTVisual.TTGrid();
        this.MaterialVatRates.Name = "MaterialVatRates";
        this.MaterialVatRates.TabIndex = 57;

        this.VatRate = new TTVisual.TTTextBoxColumn();
        this.VatRate.DataMember = "VatRate";
        this.VatRate.DisplayIndex = 0;
        this.VatRate.HeaderText = "KDV Oranı";
        this.VatRate.Name = "VatRate";
        this.VatRate.Width = 80;

        this.StartDate = new TTVisual.TTDateTimePickerColumn();
        this.StartDate.DataMember = "StartDate";
        this.StartDate.DisplayIndex = 1;
        this.StartDate.HeaderText = "Başlangıç Tarihi";
        this.StartDate.Name = "StartDate";
        this.StartDate.Width = 180;

        this.EndDate = new TTVisual.TTDateTimePickerColumn();
        this.EndDate.DataMember = "EndDate";
        this.EndDate.DisplayIndex = 2;
        this.EndDate.HeaderText = "Bitiş Tarihi";
        this.EndDate.Name = "EndDate";
        this.EndDate.Width = 180;

        this.MaterialPriceGrid = new TTVisual.TTGrid();
        this.MaterialPriceGrid.ReadOnly = true;
        this.MaterialPriceGrid.Name = "MaterialPriceGrid";
        this.MaterialPriceGrid.TabIndex = 41;

        this.PriceCode = new TTVisual.TTTextBoxColumn();
        this.PriceCode.DisplayIndex = 0;
        this.PriceCode.HeaderText = "Kodu";
        this.PriceCode.Name = "PriceCode";
        this.PriceCode.ReadOnly = true;
        this.PriceCode.Width = 100;

        this.PriceDesc = new TTVisual.TTTextBoxColumn();
        this.PriceDesc.DisplayIndex = 1;
        this.PriceDesc.HeaderText = "Fiyat Açıklaması";
        this.PriceDesc.Name = "PriceDesc";
        this.PriceDesc.ReadOnly = true;
        this.PriceDesc.Width = 300;

        this.PricingList = new TTVisual.TTListBoxColumn();
        this.PricingList.ListDefName = "PricingListListDefinition";
        this.PricingList.DisplayIndex = 2;
        this.PricingList.HeaderText = "Fiyat Listesi";
        this.PricingList.Name = "PricingList";
        this.PricingList.ReadOnly = true;
        this.PricingList.Width = 150;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.DisplayIndex = 3;
        this.Price.HeaderText = "Fiyat";
        this.Price.Name = "Price";
        this.Price.ReadOnly = true;
        this.Price.Width = 80;

        this.CurrencyType = new TTVisual.TTListBoxColumn();
        this.CurrencyType.ListDefName = "CurrencyTypeListDefinition";
        this.CurrencyType.DisplayIndex = 4;
        this.CurrencyType.HeaderText = "Para Birimi";
        this.CurrencyType.Name = "CurrencyType";
        this.CurrencyType.ReadOnly = true;
        this.CurrencyType.Width = 100;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Geçerli Malzeme Fiyatları";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 40;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "KDV Oranları";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 40;

        this.DescriptionTabPage = new TTVisual.TTTabPage();
        this.DescriptionTabPage.DisplayIndex = 4;
        this.DescriptionTabPage.TabIndex = 2;
        this.DescriptionTabPage.Text = "Açıklama";
        this.DescriptionTabPage.Name = "DescriptionTabPage";

        this.Description = new TTVisual.TTTextBox();
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Description.Name = "Description";
        this.Description.TabIndex = 6;

        this.EquivalentTabPage = new TTVisual.TTTabPage();
        this.EquivalentTabPage.DisplayIndex = 5;
        this.EquivalentTabPage.TabIndex = 3;
        this.EquivalentTabPage.Text = "Eş Değerleri";
        this.EquivalentTabPage.Name = "EquivalentTabPage";

        this.EquivalentsGrid = new TTVisual.TTGrid();
        this.EquivalentsGrid.OnRowMarkerDoubleClickShowTTObjectForm = false;
        this.EquivalentsGrid.AllowUserToDeleteRows = false;
        this.EquivalentsGrid.AllowUserToResizeColumns = false;
        this.EquivalentsGrid.AllowUserToResizeRows = false;
        this.EquivalentsGrid.Name = "EquivalentsGrid";
        this.EquivalentsGrid.TabIndex = 0;

        this.EquivalentDrugName = new TTVisual.TTTextBoxColumn();
        this.EquivalentDrugName.DisplayIndex = 0;
        this.EquivalentDrugName.HeaderText = "Eşdeğer İlaç";
        this.EquivalentDrugName.Name = "EquivalentDrugName";
        this.EquivalentDrugName.Width = 600;

        this.Ek2EquivalentTabPage = new TTVisual.TTTabPage();
        this.Ek2EquivalentTabPage.DisplayIndex = 6;
        this.Ek2EquivalentTabPage.TabIndex = 4;
        this.Ek2EquivalentTabPage.Text = "Ek-2 Eş Degerler";
        this.Ek2EquivalentTabPage.Name = "Ek2EquivalentTabPage";

        this.DrugRelations = new TTVisual.TTGrid();
        this.DrugRelations.ReadOnly = true;
        this.DrugRelations.Name = "DrugRelations";
        this.DrugRelations.TabIndex = 0;

        this.RelationDrugDrugRelation = new TTVisual.TTListBoxColumn();
        this.RelationDrugDrugRelation.ListDefName = "DrugList";
        this.RelationDrugDrugRelation.DataMember = "RelationDrug";
        this.RelationDrugDrugRelation.DisplayIndex = 0;
        this.RelationDrugDrugRelation.HeaderText = "Eşdeğer İlaç";
        this.RelationDrugDrugRelation.Name = "RelationDrugDrugRelation";
        this.RelationDrugDrugRelation.Width = 600;

        this.ManuelEquivalentTabPage = new TTVisual.TTTabPage();
        this.ManuelEquivalentTabPage.DisplayIndex = 7;
        this.ManuelEquivalentTabPage.TabIndex = 5;
        this.ManuelEquivalentTabPage.Text = "Manuel Eklenen Eş Değerler";
        this.ManuelEquivalentTabPage.Name = "ManuelEquivalentTabPage";

        this.cmdAddEquiv = new TTVisual.TTButton();
        this.cmdAddEquiv.Text = "Eş Değer Ekle";
        this.cmdAddEquiv.Name = "cmdAddEquiv";
        this.cmdAddEquiv.TabIndex = 36;

        this.ManuelEquivalentDrugs = new TTVisual.TTGrid();
        this.ManuelEquivalentDrugs.Name = "ManuelEquivalentDrugs";
        this.ManuelEquivalentDrugs.TabIndex = 35;

        this.EquivalentDrugManuelEquivDrug = new TTVisual.TTListBoxColumn();
        this.EquivalentDrugManuelEquivDrug.ListDefName = "DrugList";
        this.EquivalentDrugManuelEquivDrug.DataMember = "EquivalentDrug";
        this.EquivalentDrugManuelEquivDrug.DisplayIndex = 0;
        this.EquivalentDrugManuelEquivDrug.HeaderText = "Eş Değer İlaç";
        this.EquivalentDrugManuelEquivDrug.Name = "EquivalentDrugManuelEquivDrug";
        this.EquivalentDrugManuelEquivDrug.Width = 600;

        this.ETKMDescriptionTabPage = new TTVisual.TTTabPage();
        this.ETKMDescriptionTabPage.DisplayIndex = 8;
        this.ETKMDescriptionTabPage.TabIndex = 6;
        this.ETKMDescriptionTabPage.Text = "ETKM Açıklama";
        this.ETKMDescriptionTabPage.Name = "ETKMDescriptionTabPage";

        this.ETKMDescription = new TTVisual.TTTextBox();
        this.ETKMDescription.Multiline = true;
        this.ETKMDescription.Name = "ETKMDescription";
        this.ETKMDescription.TabIndex = 36;

        this.DrugLabIntTabPage = new TTVisual.TTTabPage();
        this.DrugLabIntTabPage.DisplayIndex = 9;
        this.DrugLabIntTabPage.TabIndex = 7;
        this.DrugLabIntTabPage.Text = "İlaç - Tetkik Sonuç Ektileşim";
        this.DrugLabIntTabPage.Name = "DrugLabIntTabPage";

        this.DrugLabProcInteractions = new TTVisual.TTGrid();
        this.DrugLabProcInteractions.Name = "DrugLabProcInteractions";
        this.DrugLabProcInteractions.TabIndex = 58;



        this.DrugDrugInteractions = new TTVisual.TTGrid();
        this.DrugDrugInteractions.Name = "DrugDrugInteractions";
        this.DrugDrugInteractions.TabIndex = 58;

        this.DrugFoodInteractions = new TTVisual.TTGrid();
        this.DrugFoodInteractions.Name = "DrugFoodInteractions";
        this.DrugFoodInteractions.TabIndex = 58;

        this.LaboratoryTestDefinitionDrugLabProcInteraction = new TTVisual.TTListBoxColumn();
        this.LaboratoryTestDefinitionDrugLabProcInteraction.ListDefName = "LaboratoryTestListDefinition";
        this.LaboratoryTestDefinitionDrugLabProcInteraction.DataMember = "LaboratoryTestDefinition";
        this.LaboratoryTestDefinitionDrugLabProcInteraction.DisplayIndex = 0;
        this.LaboratoryTestDefinitionDrugLabProcInteraction.HeaderText = "Tetkik";
        this.LaboratoryTestDefinitionDrugLabProcInteraction.Name = "LaboratoryTestDefinitionDrugLabProcInteraction";
        this.LaboratoryTestDefinitionDrugLabProcInteraction.Width = 300;




        this.DrugDefinitionDrugDrugInteraction = new TTVisual.TTListBoxColumn();
        this.DrugDefinitionDrugDrugInteraction.ListDefName = "DrugList";
        this.DrugDefinitionDrugDrugInteraction.DataMember = "DrugDefitinition";
        this.DrugDefinitionDrugDrugInteraction.DisplayIndex = 0;
        this.DrugDefinitionDrugDrugInteraction.HeaderText = "İlaç";
        this.DrugDefinitionDrugDrugInteraction.Name = "DrugDefinitionDrugDrugInteraction";
        this.DrugDefinitionDrugDrugInteraction.Width = 300;

        this.DrugDefinitionDrugFoodInteraction = new TTVisual.TTListBoxColumn();
        this.DrugDefinitionDrugFoodInteraction.ListDefName = "DietMaterialListDefinition";
        this.DrugDefinitionDrugFoodInteraction.DataMember = "DietMaterialDefinition";
        this.DrugDefinitionDrugFoodInteraction.DisplayIndex = 0;
        this.DrugDefinitionDrugFoodInteraction.HeaderText = "İlaç";
        this.DrugDefinitionDrugFoodInteraction.Name = "DrugDefinitionDrugFoodInteraction";
        this.DrugDefinitionDrugFoodInteraction.Width = 300;


        this.MinValueDrugLabProcInteraction = new TTVisual.TTTextBoxColumn();
        this.MinValueDrugLabProcInteraction.DataMember = "MinValue";
        this.MinValueDrugLabProcInteraction.DisplayIndex = 1;
        this.MinValueDrugLabProcInteraction.HeaderText = "Değerin Altı";
        this.MinValueDrugLabProcInteraction.Name = "MinValueDrugLabProcInteraction";
        this.MinValueDrugLabProcInteraction.Width = 80;

        this.MaxValueDrugLabProcInteraction = new TTVisual.TTTextBoxColumn();
        this.MaxValueDrugLabProcInteraction.DataMember = "MaxValue";
        this.MaxValueDrugLabProcInteraction.DisplayIndex = 2;
        this.MaxValueDrugLabProcInteraction.HeaderText = "Değerin Üstü";
        this.MaxValueDrugLabProcInteraction.Name = "MaxValueDrugLabProcInteraction";
        this.MaxValueDrugLabProcInteraction.Width = 80;

        this.MessageDrugLabProcInteraction = new TTVisual.TTTextBoxColumn();
        this.MessageDrugLabProcInteraction.DataMember = "Message";
        this.MessageDrugLabProcInteraction.DisplayIndex = 3;
        this.MessageDrugLabProcInteraction.HeaderText = "Uyarı Mesajı";
        this.MessageDrugLabProcInteraction.Name = "MessageDrugLabProcInteraction";
        this.MessageDrugLabProcInteraction.Width = 500;

        this.DrugSpecifications = new TTVisual.TTTabPage();
        this.DrugSpecifications.DisplayIndex = 10;
        this.DrugSpecifications.TabIndex = 8;
        this.DrugSpecifications.Text = "İlaç Özellikleri";
        this.DrugSpecifications.Name = "DrugSpecifications";

        this.grdDrugSpecification = new TTVisual.TTGrid();
        this.grdDrugSpecification.Name = "grdDrugSpecification";
        this.grdDrugSpecification.TabIndex = 0;

        this.DrugSpecification = new TTVisual.TTEnumComboBoxColumn();
        this.DrugSpecification.DataTypeName = "DrugSpecificationEnum";
        this.DrugSpecification.DataMember = "DrugSpecification";
        this.DrugSpecification.DisplayIndex = 0;
        this.DrugSpecification.HeaderText = "İlaç Özelliği";
        this.DrugSpecification.Name = "DrugSpecification";
        this.DrugSpecification.Width = 200;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Code.Name = "Code";
        this.Code.TabIndex = 0;

        this.PatientMaxDayOut = new TTVisual.TTTextBox();
        this.PatientMaxDayOut.Name = "PatientMaxDayOut";

        this.StockCard = new TTVisual.TTObjectListBox();
        this.StockCard.ListDefName = "StockCardList";
        this.StockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockCard.Name = "StockCard";
        this.StockCard.TabIndex = 4;
        this.StockCard.ReadOnly = true;
        this.StockCard.ListFilterExpression = "MALZEMEGETDATA IS NOT NULL";

        this.MaterialTree = new TTVisual.TTObjectListBox();
        this.MaterialTree.ListDefName = "MaterialTreeList";
        this.MaterialTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaterialTree.Name = "MaterialTree";
        this.MaterialTree.TabIndex = 5;

        this.Chargable = new TTVisual.TTCheckBox();
        this.Chargable.Value = false;
        this.Chargable.Text = "Ücretlendirilir";
        this.Chargable.Name = "Chargable";
        this.Chargable.TabIndex = 0;

        this.AllowToGivePatient = new TTVisual.TTCheckBox();
        this.AllowToGivePatient.Value = false;
        this.AllowToGivePatient.Text = "Hastaya Verilir/Verilmez";
        this.AllowToGivePatient.Name = "AllowToGivePatient";
        this.AllowToGivePatient.TabIndex = 0;

        this.IsArmyDrug = new TTVisual.TTCheckBox();
        this.IsArmyDrug.Value = false;
        this.IsArmyDrug.Text = "XXXXXX İlacıdır";
        this.IsArmyDrug.Name = "IsArmyDrug";
        this.IsArmyDrug.TabIndex = 0;

        this.IsPackageExclusive = new TTVisual.TTCheckBox();
        this.IsPackageExclusive.Value = false;
        this.IsPackageExclusive.Text = "Paket Harici Faturalanır";
        this.IsPackageExclusive.Name = "IsPackageExclusive";
        this.IsPackageExclusive.TabIndex = 57;

        this.ttcheckbox1 = new TTVisual.TTCheckBox();
        this.ttcheckbox1.Value = false;
        this.ttcheckbox1.Text = "Orderda 0 Göster";
        this.ttcheckbox1.Name = "ttcheckbox1";
        this.ttcheckbox1.TabIndex = 50;

        this.MaterialSpecialtyDefinitionMaterialSpecialty = new TTVisual.TTListBoxColumn();
        this.MaterialSpecialtyDefinitionMaterialSpecialty.ListDefName = "MaterialSpecialtyList";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.DataMember = "MaterialSpecialtyDefinition";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.DisplayIndex = 0;
        this.MaterialSpecialtyDefinitionMaterialSpecialty.HeaderText = "Branş";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.Name = "MaterialSpecialtyDefinitionMaterialSpecialty";

        this.ttcheckbox2 = new TTVisual.TTCheckBox();
        this.ttcheckbox2.Value = false;
        this.ttcheckbox2.Text = "Dağıtım Belg. 0 Göster";
        this.ttcheckbox2.Name = "ttcheckbox2";
        this.ttcheckbox2.TabIndex = 50;
        this.SEX = new TTVisual.TTComboBox();
        this.OutpatientReportType = new TTVisual.TTComboBox();
        this.InpatientReportType = new TTVisual.TTComboBox();
        this.drugSpecs = new DrugSpecifications;
        this.DrugATCsColumns = [this.ATC];
        this.DrugActiveIngredientsColumns = [this.ActiveIngredient, this.Unit, this.Value, this.FormulaMaxDose, this.MaxDoseUnit, this.IsParentIngredient];
        this.MaterialVatRatesColumns = [this.VatRate, this.StartDate, this.EndDate];
        this.MaterialPriceGridColumns = [this.PriceCode, this.PriceDesc, this.PricingList, this.Price, this.CurrencyType];
        this.EquivalentsGridColumns = [this.EquivalentDrugName];
        this.DrugRelationsColumns = [this.RelationDrugDrugRelation];
        this.ManuelEquivalentDrugsColumns = [this.EquivalentDrugManuelEquivDrug];
        this.DrugLabProcInteractionsColumns = [this.LaboratoryTestDefinitionDrugLabProcInteraction, this.MinValueDrugLabProcInteraction, this.MaxValueDrugLabProcInteraction, this.MessageDrugLabProcInteraction];
        this.grdDrugSpecificationColumns = [this.DrugSpecification];
        this.tttabcontrol1.Controls = [this.PropertyTabPage, this.FormuleTabPage, this.ProductionTabPage, this.KDVTabPage, this.DescriptionTabPage, this.EquivalentTabPage, this.Ek2EquivalentTabPage, this.ManuelEquivalentTabPage, this.ETKMDescriptionTabPage, this.DrugLabIntTabPage, this.DrugSpecifications];
        this.PropertyTabPage.Controls = [this.labelOrderRPTDay, this.ttenumcombobox1, this.OrderRPTDay, this.ttgroupbox1, this.labelGenericDrug, this.PrescriptionType, this.labelPrescriptionType, this.labelVolumeUnit, this.Volume, this.labelNFC, this.ttgroupbox2, this.DrugATCs, this.DrugSpecificationGrid, this.MaxDoseDay, this.labelMaxDoseDay, this.labelVolume, this.MaxDose, this.Dose, this.VolumeUnit, this.RouteOfAdmin, this.labelRouteOfAdmin, this.labelDose, this.GenericDrug, this.NFC, this.labelMaxDose, this.tttextbox1, this.ttlabel3, this.tttextbox2, this.ttlabel4, this.ttlabel5];
        this.ttgroupbox1.Controls = [this.SpecialistApproval, this.SpecialistDoctorApproval];
        this.ttgroupbox2.Controls = [this.labelRoutineDay, this.labelFrequency, this.RoutineDay, this.RoutineDose, this.labelRoutineDose, this.Frequency];
        this.FormuleTabPage.Controls = [this.DrugActiveIngredients];
        this.ProductionTabPage.Controls = [this.gbxAmountPrice, this.SetMedulaInfoByMultiplier, this.CreateInMedulaDontSendState, this.DividePriceToVolume, this.lblMedulaMultiplier, this.searchMedicineFromMedula, this.MedulaMultiplier, this.labelPurchaseDate, this.PurchaseDate, this.labelBrans, this.ReimbursementUnder, this.Brans, this.labelMaterialPricingType, this.MaterialPricingType, this.labelProducer, this.Producer, this.labelProductNumber, this.ProductNumber, this.labelGMDNCodeStockCard, this.GMDNCodeStockCard, this.labelPackageAmount, this.PackageAmount, this.labelLicencingOrganization, this.LicencingOrganization, this.labelLicenceNO, this.LicenceNO, this.labelLicenceDate, this.LicenceDate, this.labelCurrentPrice, this.CurrentPrice, this.labelBarcodeName, this.BarcodeName];
        this.gbxAmountPrice.Controls = [this.txtTestAmount, this.btnCalculate, this.txtAmountMultiplier, this.txtUnitPriceDivider, this.lblTestAmount, this.lblAmountMultiplier, this.lblUnitPriceDivider];
        this.KDVTabPage.Controls = [this.MaterialVatRates, this.MaterialPriceGrid, this.ttlabel1, this.ttlabel2];
        this.DescriptionTabPage.Controls = [this.Description];
        this.EquivalentTabPage.Controls = [this.EquivalentsGrid];
        this.Ek2EquivalentTabPage.Controls = [this.DrugRelations];
        this.ManuelEquivalentTabPage.Controls = [this.cmdAddEquiv, this.ManuelEquivalentDrugs];
        this.ETKMDescriptionTabPage.Controls = [this.ETKMDescription];
        this.DrugLabIntTabPage.Controls = [this.DrugLabProcInteractions];
        this.DrugSpecifications.Controls = [this.grdDrugSpecification];
        this.Controls = [this.grdMaterialProcedures, this.SendSMS, this.PaidPayment, this.NotAppearInEpicrisis, this.DivisibleDrug, this.labelColor, this.Color, this.DrugSpecification, this.labelDrugNutrientInteraction, this.DrugNutrientInteraction, this.MkysMalzemeKodu, this.EstimatedTimeOfCheck, this.StorageConditions, this.Barcode, this.MedulaMultiplier, this.Name, this.OriginalName, this.SgkReturnPay, this.IsNarcotic, this.IsPsychotropic, this.labelMkysMalzemeKodu, this.labelEstimatedTimeOfCheck, this.labelStorageConditions, this.SosFarmaCheckBox, this.labelDistributionTypeStockCard, this.DistributionTypeStockCard, this.labelCreationDate, this.CreationDate, this.PatientSafetyFrom, this.cmdChangeTypeToConsumableButton, this.IsOldMaterial, this.labelEtkinMadde, this.EtkinMadde, this.IsExpendableMaterial, this.labelBarcode, this.WithOutStockInheld, this.labelMaterialTree, this.labelStockCard, this.labelCode, this.IsActive, this.labelEnglishName, this.labelName, this.tttabcontrol1, this.PropertyTabPage, this.labelOrderRPTDay, this.ttenumcombobox1, this.OrderRPTDay, this.ttgroupbox1, this.SpecialistApproval, this.SpecialistDoctorApproval, this.labelGenericDrug, this.PrescriptionType, this.labelPrescriptionType, this.labelVolumeUnit, this.Volume, this.labelNFC, this.ttgroupbox2, this.labelRoutineDay, this.labelFrequency, this.RoutineDay, this.RoutineDose, this.labelRoutineDose, this.Frequency, this.DrugATCs, this.ATC, this.MaxDoseDay, this.labelMaxDoseDay, this.labelVolume, this.MaxDose, this.Dose, this.VolumeUnit, this.RouteOfAdmin, this.labelRouteOfAdmin, this.labelDose, this.GenericDrug, this.NFC, this.labelMaxDose, this.tttextbox1, this.ttlabel3, this.tttextbox2, this.ttlabel4, this.ttlabel5, this.FormuleTabPage, this.DrugActiveIngredients, this.ActiveIngredient, this.Unit, this.Value, this.FormulaMaxDose, this.MaxDoseUnit, this.IsParentIngredient, this.ProductionTabPage, this.gbxAmountPrice, this.txtTestAmount, this.btnCalculate, this.txtAmountMultiplier, this.txtUnitPriceDivider, this.lblTestAmount, this.lblAmountMultiplier, this.lblUnitPriceDivider, this.SetMedulaInfoByMultiplier, this.CreateInMedulaDontSendState, this.DividePriceToVolume, this.lblMedulaMultiplier, this.searchMedicineFromMedula, this.labelPurchaseDate, this.PurchaseDate, this.labelBrans, this.ReimbursementUnder, this.Brans, this.labelMaterialPricingType, this.MaterialPricingType, this.labelProducer, this.Producer, this.labelProductNumber, this.ProductNumber, this.labelGMDNCodeStockCard, this.GMDNCodeStockCard, this.labelPackageAmount, this.PackageAmount, this.labelLicencingOrganization, this.LicencingOrganization, this.labelLicenceNO, this.LicenceNO, this.labelLicenceDate, this.LicenceDate, this.labelCurrentPrice, this.CurrentPrice, this.labelBarcodeName, this.BarcodeName, this.KDVTabPage, this.MaterialVatRates, this.VatRate, this.StartDate, this.EndDate, this.MaterialPriceGrid, this.PriceCode, this.PriceDesc, this.PricingList, this.Price, this.CurrencyType, this.ttlabel1, this.ttlabel2, this.DescriptionTabPage, this.Description, this.EquivalentTabPage, this.EquivalentsGrid, this.EquivalentDrugName, this.Ek2EquivalentTabPage, this.DrugRelations, this.RelationDrugDrugRelation, this.ManuelEquivalentTabPage, this.cmdAddEquiv, this.ManuelEquivalentDrugs, this.EquivalentDrugManuelEquivDrug, this.ETKMDescriptionTabPage, this.ETKMDescription, this.DrugLabIntTabPage, this.DrugLabProcInteractions, this.LaboratoryTestDefinitionDrugLabProcInteraction, this.MinValueDrugLabProcInteraction, this.MaxValueDrugLabProcInteraction, this.MessageDrugLabProcInteraction, this.DrugSpecifications, this.grdDrugSpecification, this.DrugSpecification, this.Code, this.StockCard, this.MaterialTree, this.Chargable, this.AllowToGivePatient, this.IsArmyDrug, this.IsPackageExclusive, this.ttcheckbox1, this.ttcheckbox2];

    }


    OpenServiceMultiSelectComponent() {
        this.showServiceMultiSelectForm = true;
        this.getProcedureList();


    }

    // seçtiğimiz elemanlar SelectedProcedur içerisine dolduruluyor 
    public selectedChangeOnService() {
        this.Services = this.SelectedProcedureList;
        this.showServiceMultiSelectForm = false;

        this.SelectedProcedureList.forEach(element => {
            let param: any;
            param.Code = element.Code;
            param.Name = element.Name;

            this.Services.push(param);

        });

    }


    OpenConsumptionMultiSelectComponent() {
        this.showConsumptionsMultiSelectForm = true;
        this.getMaterialList();

    }


    public selectedChangeOnConsumption() {
        this.Consumptions = this.SelectedConsumptionList;
        this.showConsumptionsMultiSelectForm = false;
        //param değerlerine bak
        this.SelectedConsumptionList.forEach(element => {
            let param: any;
            param.Code = element.Code;
            param.Name = element.Name;

            this.Consumptions.push(param);

        });

    }


    OpenFeaturedDrugSelectComponent() {
        this.showFeaturedDrugMultiSelectForm = true;

    }

    public selectedChangeOnFeaturedDrug() {
        this.showFeaturedDrugMultiSelectForm = false;
    }

    OpenMaterialMultiSelectComponent() {
        this.showMaterialMultiSelectForm = true;
    }


    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterialItems = event;
        this.visibility = true;


        selectedMaterialItems.forEach(element => {
            let voucherMaterial: Material = new Material();
            voucherMaterial = element;
            this._ViewModel.SelectedFilterMaterials.push(voucherMaterial);
        });
    }

    @ViewChild('materialProducerdataSourceGrid') materialProducerdataSourceGrid: DxDataGridComponent;
    materialProducerdataSourceGrid_CellContentClicked(data: any) {
        if (data.column.name == "RowDelete") {
            if (data.row != null) {
                if (data.row.key != null) {
                    if (data.row.key.IsNew) {
                        this.materialProducerdataSourceGrid.instance.deleteRow(data.rowIndex);
                    }
                    else {
                        data.key.EntityState = EntityStateEnum.Deleted;
                        this.materialProducerdataSourceGrid.instance.filter(['EntityState', '<>', 1]);
                        this.materialProducerdataSourceGrid.instance.refresh();
                    }
                }
            }
        }
    }

    btnServiceProcedureAddClick() {
        let param: MaterialProcedures_Output = new MaterialProcedures_Output();
        let that = this;
        param.ProcedureDefinition = new ProcedureDefinition_Output();
        param.Material = new Material_Output();
        param.ProcedureDefinition.Name = this.selectedServiceProcedure.Name;
        param.Material.ObjectID = this.ObjectID;
        param.ProcedureDefinition.ObjectID = this.selectedServiceProcedure.ObjectID;
        let apiUrl = '/api/ConsumableMaterialDefinitionService/AddMaterialProcedure';
        this.GridDataSource.forEach(element => {
            if (element.ProcedureDefinition.ObjectID == param.ProcedureDefinition.ObjectID) {
                ServiceLocator.MessageService.showError("Aynı Hizmeti Birden Fazla Giremezsiniz !");
                throw new TTException("Aynı Hizmeti Birden Fazla Giremezsiniz ! ");
            }
        });
    }


    OpenActiveIngredientsMaterialMultiSelectComponent() {
        if (!this.ActiveIngredientList) {
            this.GetActiveIngredientMaterials();
        }
        this.showActiveIngredientsMaterialMultiSelectForm = true;
    }

    public selectedChangeOnActiveIngredient() {
        this.ActiveSubstanceIDList = new Array<Guid>();
        for (let selectedItem of this.SelectedActiveIngredients) {
            this.ActiveSubstanceIDList.push(selectedItem.ObjectID);
        }
        this.showActiveIngredientsMaterialMultiSelectForm = false;
    }

    async GetActiveIngredientMaterials() {
        let that = this;
        this.SelectedActiveIngredients.Clear();
        let apiUrlForPASearchUrl: string = '/api/DrugOutForRecipeTypeService/GetActiveIngredientDefinitions';
        await this.httpService.post<any>(apiUrlForPASearchUrl, null).then(response => {
            if (response) {
                this.ActiveIngredientList = response;
                var selectedIngredients: Array<Guid> = new Array<Guid>();
                for (let item of this.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients) {
                    selectedIngredients.push(item.ObjectID);
                }

                that.SelectedActiveIngredients = that.ActiveIngredientList.filter(p => {
                    return selectedIngredients.Contains(p.ObjectID);
                });
            }
        });
    }

    public deletedActiveIngredients: Array<DrugActiveIngredient> = new Array<DrugActiveIngredient>();
    @ViewChild('activeIngredientMaterialGrid') activeIngredientMaterialGrid: DxDataGridComponent;
    activeIngredientMaterialGrid_CellContentClicked(data) {
        if (data != null) {
            if (data.data != null) {
                if (data.data.IsNew) {
                    this.activeIngredientMaterialGrid.instance.deleteRow(data.rowIndex);
                }
                else {
                    let deleteIngredient: DrugActiveIngredient = this.drugDefinitionFormViewModel._DrugDefinition.DrugActiveIngredients.find(x => x.ObjectID == data.data.ObjectID);
                    deleteIngredient.EntityState = EntityStateEnum.Deleted;
                    this.deletedActiveIngredients.push(deleteIngredient);
                    //data.data.EntityState = EntityStateEnum.Deleted;
                    this.activeIngredientMaterialGrid.instance.filter(['EntityState', '<>', 1]);
                    this.activeIngredientMaterialGrid.instance.refresh();
                }
            }
        }
    }

    public divideAmountToPatientClicked(value) {
        this.isDivideAmountToPatient = value.value;
        if (value.value == false) {
            this.drugDefinitionFormViewModel._DrugDefinition.DivideUnitAmount = null;
            this.drugDefinitionFormViewModel._DrugDefinition.DivideTotalAmount = null;
            this.drugDefinitionFormViewModel._DrugDefinition.DivideUnitDefinition = null;
        }
    }
}