//$DA7F477F
import { Component, OnInit, ApplicationRef, ViewChild } from '@angular/core';
import { Http, Headers, Response, RequestOptions, ResponseContentType } from '@angular/http';
import {
    pricePatienList, pricePatientOutputDTO, RepaitUnUpdate_Intput,
    ConsumableMaterialDefinitionFormViewModel, UploadFile_Input, MaterialProcedures_Output, Material_Output, ProcedureDefinition_Output, MaterialPriceDetail, LoadModelComponentConsumableMaterial_Input, LoadModelComponentConsumableMaterial, FirstInStockUnitePriceConsumableMaterial, UpdateMaterialPriceOutput, MaterialPriceByMedulaSUT_Input
} from './ConsumableMaterialDefinitionFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { CommonService } from "ObjectClassService/CommonService";
import { ConsumableMaterialDefinition, SexEnum, UploadedDocument, MaterialDocumentation, MaterialProcedures, ProcedureDefinition, Material, SUTMalzemeEKEnum, EquivalentConsMaterial, MaterialPatientTypeEnum, MaterialDocumentType, MaterialDescriptionShowTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MaterialPrice } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { Sites } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTUser } from 'NebulaClient/StorageManager/Security/TTUser';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { GMDNDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialPlaceOfUseDef } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialProductLevel } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialPurposeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialSpecialty } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialSpecialtyDef } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MaterialVatRate } from 'NebulaClient/Model/AtlasClientModel';
import { Producer } from 'NebulaClient/Model/AtlasClientModel';
import { ProductDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MalzemeTuru } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';

import { ModalStateService, ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { LogDataSource } from 'Modules/Core_Destek_Modulleri/Log_Modulu/AuditQueryFormViewModel';
import { QueryInputDVO, GetReport, DefinitionOutTrxDVO, HospitalInventoryDVO, DefinitionInTrxDVO, EquivalentMaterial, SaveShelfAndRowOnStock_Input, GetStockLocation_Input, StoreLocationInformation_Input, OpenLogisticDocumentInputParams } from 'Modules/Merkezi_Yonetim_Sistemi/Eczane_Modulleri/Ilac_Vademecum_Tanimlari_Modulu/DrugDefinitionFormViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { CommonHelper } from 'app/Helper/CommonHelper';
import { EntityStateEnum } from 'app/NebulaClient/Utils/Enums/EntityStateEnum';
import { DxDataGridComponent } from 'devextreme-angular';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import { ClassType } from 'app/NebulaClient/ClassTransformer/decorators';
import { IEnumList } from 'app/NebulaClient/Mscorlib/IEnumList';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { IAuditObjectService, AuditObject } from 'app/Fw/Services/IAuditObjectService';
import { TransactionChartInputDTO, StockGiris, StockCikis, StockGirisDetay, StockCikisDetay } from 'app/Logistic/Models/LogisticDashboardViewModel';
import { DocumentGridModel } from 'app/Logistic/Views/LogiscticDocumentComponents/LogisticDocumentUploadForm';
import { TTObject } from 'app/NebulaClient/StorageManager/InstanceManagement/TTObject';

@Component({
    selector: 'ConsumableMaterialDefinitionForm',
    templateUrl: 'ConsumableMaterialDefinitionForm.html',
    providers: [MessageService]
})
export class ConsumableMaterialDefinitionForm extends TTVisual.TTForm {
    AllowToGivePatient: TTVisual.ITTCheckBox;
    AuctionDate: TTVisual.ITTDateTimePicker;
    Barcode: TTVisual.ITTTextBox;
    BarcodeName: TTVisual.ITTTextBox;
    Brans: TTVisual.ITTObjectListBox;
    Chargable: TTVisual.ITTCheckBox;
    cmdChangeTypeToFixedAsset: TTVisual.ITTButton;
    cmdSendChanging: TTVisual.ITTButton;
    Code: TTVisual.ITTTextBox;
    CreateInMedulaDontSendState: TTVisual.ITTCheckBox;
    CreationDate: TTVisual.ITTDateTimePicker;
    CurrencyType: TTVisual.ITTListBoxColumn;
    CurrentPrice: TTVisual.ITTTextBox;
    Description: TTVisual.ITTTextBox;
    DistributionTypeStockCard: TTVisual.ITTObjectListBox;
    EndDate: TTVisual.ITTDateTimePickerColumn;
    EnglishName: TTVisual.ITTTextBox;
    EstimatedTimeOfCheck: TTVisual.ITTTextBox;
    ETKMDescription: TTVisual.ITTTextBox;
    ETKMDescriptionTabPage: TTVisual.ITTTabPage;
    GMDNCodeStockCard: TTVisual.ITTObjectListBox;
    HasEstimatedTimeConsumableMaterialDefinition: TTVisual.ITTCheckBox;
    IsActive: TTVisual.ITTCheckBox;
    IsAllogreft: TTVisual.ITTCheckBox;
    IsArmyDrug: TTVisual.ITTCheckBox;
    IsExpendableMaterial: TTVisual.ITTCheckBox;
    IsIndividualTrackingRequired: TTVisual.ITTCheckBox;
    IsOldMaterial: TTVisual.ITTCheckBox;
    malzemeTuru: TTVisual.ITTListBoxColumn;
    IsPackageExclusive: TTVisual.ITTCheckBox;
    IsRestrictedMaterial: TTVisual.ITTCheckBox;
    IsTagNoRequired: TTVisual.ITTCheckBox;
    labelAuctionDate: TTVisual.ITTLabel;
    labelBarcode: TTVisual.ITTLabel;
    labelBarcodeName: TTVisual.ITTLabel;
    labelBrans: TTVisual.ITTLabel;
    labelCode: TTVisual.ITTLabel;
    labelCreationDate: TTVisual.ITTLabel;
    labelCurrentPrice: TTVisual.ITTLabel;
    labelDistributionTypeStockCard: TTVisual.ITTLabel;
    EquivalentMaterialEquivalentConsMaterial: TTVisual.ITTListBoxColumn;
    labelEstimatedTimeOfCheck: TTVisual.ITTLabel;
    labelGMDNCodeStockCard: TTVisual.ITTLabel;
    labelLicenceDate: TTVisual.ITTLabel;
    labelLicenceNO: TTVisual.ITTLabel;
    labelLicencingOrganization: TTVisual.ITTLabel;
    labelMaterialPlaceOfUseDef: TTVisual.ITTLabel;
    labelMaterialPricingType: TTVisual.ITTLabel;
    labelMaterialPurposeDefinition: TTVisual.ITTLabel;
    labelMaterialTree: TTVisual.ITTLabel;
    labelMkysMalzemeKodu: TTVisual.ITTLabel;
    labelName: TTVisual.ITTLabel;
    labelPackageAmount: TTVisual.ITTLabel;
    labelProducer: TTVisual.ITTLabel;
    labelProductNumber: TTVisual.ITTLabel;
    labelPurchaseDate: TTVisual.ITTLabel;
    labelRegistrationAuctionNo: TTVisual.ITTLabel;
    labelStockCard: TTVisual.ITTLabel;
    labelStorageConditions: TTVisual.ITTLabel;
    lblMedulaMultiplier: TTVisual.ITTLabel;
    lblSUTAppendix: TTVisual.ITTLabel;
    LicenceDate: TTVisual.ITTDateTimePicker;
    LicenceNO: TTVisual.ITTTextBox;

    LicencingOrganization: TTVisual.ITTEnumComboBox;
    MaterialPicture: TTVisual.ITTPictureBoxControl;
    MaterialPlaceOfUseDef: TTVisual.ITTObjectListBox;
    MaterialPriceGrid: TTVisual.ITTGrid;
    MaterialPricingType: TTVisual.ITTEnumComboBox;
    MaterialProductLevels: TTVisual.ITTGrid;
    MaterialPurposeDefinition: TTVisual.ITTObjectListBox;
    MaterialSpecialtyDefinitionMaterialSpecialty: TTVisual.ITTListBoxColumn;
    MaterialSpecialtys: TTVisual.ITTGrid;
    MaterialTree: TTVisual.ITTObjectListBox;
    RevenueSubAccountCode: TTVisual.ITTObjectListBox;
    MaterialVatRates: TTVisual.ITTGrid;
    MaterialVatRateTabPage: TTVisual.ITTTabPage;
    MedulaMultiplier: TTVisual.ITTTextBox;
    MkysMalzemeKodu: TTVisual.ITTTextBox;
    Name: TTVisual.ITTTextBox;
    PackageAmount: TTVisual.ITTTextBox;
    PictureTabPage: TTVisual.ITTTabPage;
    Price: TTVisual.ITTTextBoxColumn;
    PriceCode: TTVisual.ITTTextBoxColumn;
    PricingList: TTVisual.ITTListBoxColumn;
    Producer: TTVisual.ITTObjectListBox;
    ProductionInfoTabPage: TTVisual.ITTTabPage;
    ProductLevelTabPage: TTVisual.ITTTabPage;
    ProductMaterialProductLevel: TTVisual.ITTListBoxColumn;
    ProductNumber: TTVisual.ITTTextBox;
    PurchaseDate: TTVisual.ITTDateTimePicker;
    RegistrationAuctionNo: TTVisual.ITTTextBox;
    SendSMS: TTVisual.ITTCheckBox;
    StartDate: TTVisual.ITTDateTimePickerColumn;
    StockCard: TTVisual.ITTObjectListBox;
    StorageConditions: TTVisual.ITTTextBox;
    SUTAppendix: TTVisual.ITTEnumComboBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    VatRate: TTVisual.ITTTextBoxColumn;

    MaxPatientAge: TTVisual.ITTTextBox;
    MinPatientAge: TTVisual.ITTTextBox;
    OrderRPTDay: TTVisual.ITTTextBox;
    PatientMaxDayOut: TTVisual.ITTTextBox;
    SEX: TTVisual.ITTComboBox;
    grdMaterialProcedures: TTVisual.ITTObjectListBox;
    public MaterialPatientTypeItems;
    public GenderList;
    public MaterialTypeList;
    public StoreID: Guid;
    public MaterialPriceGridColumns = [];
    public MaterialProductLevelsColumns = [];
    public MaterialSpecialtysColumns = [];
    public MaterialVatRatesColumns = [];
    public MaterialVatRate;
    public consumableMaterialDefinitionFormViewModel: ConsumableMaterialDefinitionFormViewModel = new ConsumableMaterialDefinitionFormViewModel();
    public activeAccountingTerm: any;
    public costActionAccountingTerm: any;
    public accountingTermObjId: any;
    public outStockTransactions: Array<DefinitionOutTrxDVO>;
    public shelfNo: number;
    public rowNo: number;
    public GridDataSource: Array<any> = new Array<any>();
    public SUTAppendixSource: Array<EnumItem>;
    public GMDNCodesSource: DataSource;
    public PackageExclusiveList;
    IsPackageExclusiveValue: PackageExclusiveEnum;
    loadingVisible: boolean = false;
    MaterialPatientTypeSeleceted: any;
    panelTag: string;

    public materialDescriptionShowTypeItems: Array<EnumItem> = MaterialDescriptionShowTypeEnum.Items;
    public get _ConsumableMaterialDefinition(): ConsumableMaterialDefinition {
        return this._TTObject as ConsumableMaterialDefinition;
    }

    _TTObject: TTObject;
    _ViewModel: ConsumableMaterialDefinitionFormViewModel;
    ConsumableMaterialDefinitionForm_DocumentUrl: string = '/api/ConsumableMaterialDefinitionService/ConsumableMaterialDefinitionForm';
    private _modalInfo: ModalInfo;
    constructor(
        protected httpService: NeHttpService,
        protected modalService: IModalService,
        protected sideBarMenuService: ISidebarMenuService,
        protected activeUserService: IActiveUserService, private modalStateService: ModalStateService, protected messageService: MessageService
        , private http: HttpClient, private http2: AtlasHttpService) {
        super('CONSUMABLEMATERIALDEF', 'ConsumableMaterialDefinitionForm');
        this._DocumentServiceUrl = this.ConsumableMaterialDefinitionForm_DocumentUrl;
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
    // ***** Method declarations start *****
    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        this.SaveShelfAndRowOnStock();
        this.SaveStoreLocation();


    }
    protected async PreScript(): Promise<void> {

        this.loadObjectModel();

        this.WarningDate = "180";
        if (this._ConsumableMaterialDefinition.StockCard == null) {
            
            this.StockCard.ReadOnly = false;
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialTree = new MaterialTreeDefinition();
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsActive = true;
        }
    }

    showDetailAudit: boolean = false;
    //getDetailAuditDataSource:Array<AuditDataSource> = new Array<AuditDataSource>();
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
            auditObject.AuditObjectID = that._ConsumableMaterialDefinition.ObjectID;
            auditObject.AuditObjectDefID = that._ConsumableMaterialDefinition.ObjectDefID;
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




    SaveShelfAndRowOnStock() {
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/SaveShelfAndRowOnStock';
        let params: SaveShelfAndRowOnStock_Input = new SaveShelfAndRowOnStock_Input();
        params.MaterialID = this._ConsumableMaterialDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        params.Shelf = this.shelfNo;
        params.Row = this.rowNo;
        this.httpService.post<any>(apiUrl, params).then();

    }

    SaveStoreLocation() {
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/SaveStoreLocation';
        let params: StoreLocationInformation_Input = new StoreLocationInformation_Input();
        params.StockLocationID = this.StockLocationShelf;
        params.MaterialID = this._ConsumableMaterialDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        this.httpService.post<any>(apiUrl, params).then();
    }



    public ProducerColumns = [
        {
            caption: 'Firma Adı',
            dataField: 'Name',
        },
        {
            caption: 'Firma Tanımlayıcı No',
            dataField: 'FirmIdentifierNo',
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

    public EquivalentMaterialColumns = [
        {
            caption: 'Malzeme/İlaç Adı',
            dataField: 'Equivalent'
        },
        {
            caption: 'SUT KODU',
            dataField: 'Code'
        },
        {
            caption: i18n("M27286", "Sil"),
            name: 'RowDelete',
            width: '50',
            cellTemplate: 'deleteCellTemplate'
        }

    ];

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new ConsumableMaterialDefinition();
        this.consumableMaterialDefinitionFormViewModel = new ConsumableMaterialDefinitionFormViewModel();
        this._ViewModel = this.consumableMaterialDefinitionFormViewModel;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition = this._TTObject as ConsumableMaterialDefinition;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialSpecialtys = new Array<MaterialSpecialty>();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPurposeDefinition = new MaterialPurposeDefinition();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPlaceOfUseDef = new MaterialPlaceOfUseDef();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ParentConsumableMaterial = new ConsumableMaterialDefinition();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Brans = new SpecialityDefinition();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Producer = new Producer();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode = new GMDNDefinition();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialVatRates = new Array<MaterialVatRate>();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialProductLevels = new Array<MaterialProductLevel>();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.StockCard = new StockCard();
        this.malzemeTuru = new MalzemeTuru();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.StockCard.DistributionType = new DistributionTypeDefinition();
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialTree = new MaterialTreeDefinition();
        this.GenderList = SexEnum.Items;
        this.PackageExclusiveList = PackageExclusiveEnum.Items;
        this.MaterialPatientTypeItems = MaterialPatientTypeEnum.Items;
    }

    protected loadViewModel() {
        this.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        let that = this;
        that.consumableMaterialDefinitionFormViewModel = this._ViewModel as ConsumableMaterialDefinitionFormViewModel;
        that._TTObject = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition;
        if (this.consumableMaterialDefinitionFormViewModel == null)
            this.consumableMaterialDefinitionFormViewModel = new ConsumableMaterialDefinitionFormViewModel();
        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition == null)
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition = new ConsumableMaterialDefinition();
        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialSpecialtys = that.consumableMaterialDefinitionFormViewModel.MaterialSpecialtysGridList;
        for (let detailItem of that.consumableMaterialDefinitionFormViewModel.MaterialSpecialtysGridList) {
            let materialSpecialtyDefinitionObjectID = detailItem["MaterialSpecialtyDefinition"];
            if (materialSpecialtyDefinitionObjectID != null && (typeof materialSpecialtyDefinitionObjectID === "string")) {
                let materialSpecialtyDefinition = that.consumableMaterialDefinitionFormViewModel.MaterialSpecialtyDefs.find(o => o.ObjectID.toString() === materialSpecialtyDefinitionObjectID.toString());
                if (materialSpecialtyDefinition) {
                    detailItem.MaterialSpecialtyDefinition = materialSpecialtyDefinition;
                }
            }

        }
        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialProcedures = that.consumableMaterialDefinitionFormViewModel.grdConsumableMaterialProceduresGridList;
        for (let detailItem of that.consumableMaterialDefinitionFormViewModel.grdConsumableMaterialProceduresGridList) {
            let procedureDefinitionObjectID = detailItem["ProcedureDefinition"];
            if (procedureDefinitionObjectID != null && (typeof procedureDefinitionObjectID === "string")) {
                let procedureDefinition = that.consumableMaterialDefinitionFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureDefinitionObjectID.toString());
                if (procedureDefinition) {
                    detailItem.ProcedureDefinition = procedureDefinition;
                }
            }
        }
        let materialPurposeDefinitionObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["MaterialPurposeDefinition"];
        if (materialPurposeDefinitionObjectID != null && (typeof materialPurposeDefinitionObjectID === "string")) {
            let materialPurposeDefinition = that.consumableMaterialDefinitionFormViewModel.MaterialPurposeDefinitions.find(o => o.ObjectID.toString() === materialPurposeDefinitionObjectID.toString());
            if (materialPurposeDefinition) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPurposeDefinition = materialPurposeDefinition;
            }
        }
        let materialPlaceOfUseDefObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["MaterialPlaceOfUseDef"];
        if (materialPlaceOfUseDefObjectID != null && (typeof materialPlaceOfUseDefObjectID === "string")) {
            let materialPlaceOfUseDef = that.consumableMaterialDefinitionFormViewModel.MaterialPlaceOfUseDefs.find(o => o.ObjectID.toString() === materialPlaceOfUseDefObjectID.toString());
            if (materialPlaceOfUseDef) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPlaceOfUseDef = materialPlaceOfUseDef;
            }
        }
        let parentConsumableMaterialObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["ParentConsumableMaterial"];
        if (parentConsumableMaterialObjectID != null && (typeof parentConsumableMaterialObjectID === "string")) {
            let parentConsumableMaterial = that.consumableMaterialDefinitionFormViewModel.ConsumableMaterialDefinitions.find(o => o.ObjectID.toString() === parentConsumableMaterialObjectID.toString());
            if (parentConsumableMaterial) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ParentConsumableMaterial = parentConsumableMaterial;
            }
        }
        let bransObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["Brans"];
        if (bransObjectID != null && (typeof bransObjectID === "string")) {
            let brans = that.consumableMaterialDefinitionFormViewModel.SpecialityDefinitions.find(o => o.ObjectID.toString() === bransObjectID.toString());
            if (brans) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Brans = brans;
            }
        }
        let producerObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["Producer"];
        if (producerObjectID != null && (typeof producerObjectID === "string")) {
            let producer = that.consumableMaterialDefinitionFormViewModel.Producers.find(o => o.ObjectID.toString() === producerObjectID.toString());
            if (producer) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Producer = producer;
            }
        }
        let gMDNCodeObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["GMDNCode"];
        if (gMDNCodeObjectID != null && (typeof gMDNCodeObjectID === "string")) {
            let gMDNCode = that.consumableMaterialDefinitionFormViewModel.GMDNDefinitions.find(o => o.ObjectID.toString() === gMDNCodeObjectID.toString());
            if (gMDNCode) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode = gMDNCode;
            }
        }
        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialVatRates = that.consumableMaterialDefinitionFormViewModel.MaterialVatRatesGridList;
        for (let detailItem of that.consumableMaterialDefinitionFormViewModel.MaterialVatRatesGridList) {
        }
        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialVatRates = that.consumableMaterialDefinitionFormViewModel.MaterialVatRatesGridList;
        if (that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialVatRates.length != 0) {
            that.MaterialVatRate = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialVatRates[0].VatRate;
        }


        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialProductLevels = that.consumableMaterialDefinitionFormViewModel.MaterialProductLevelsGridList;
        for (let detailItem of that.consumableMaterialDefinitionFormViewModel.MaterialProductLevelsGridList) {
            let productObjectID = detailItem["Product"];
            if (productObjectID != null && (typeof productObjectID === "string")) {
                let product = that.consumableMaterialDefinitionFormViewModel.ProductDefinitions.find(o => o.ObjectID.toString() === productObjectID.toString());
                if (product) {
                    detailItem.Product = product;
                }
            }

        }
        let stockCardObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["StockCard"];
        if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
            let stockCard = that.consumableMaterialDefinitionFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
            if (stockCard) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.StockCard = stockCard;
            }
        }

        let malzemeTuruObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["MalzemeTuru"];
        if (malzemeTuruObjectID != null && (typeof malzemeTuruObjectID === "string")) {
            let malzemeTuru = that.consumableMaterialDefinitionFormViewModel.MalzemeTurus.find(o => o.ObjectID.toString() === malzemeTuruObjectID.toString());
            if (malzemeTuru) {
                that.malzemeTuru = malzemeTuru;
            }
        }
        let materialTreeObjectID = that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition["MaterialTree"];
        if (materialTreeObjectID != null && (typeof materialTreeObjectID === "string")) {
            let materialTree = that.consumableMaterialDefinitionFormViewModel.MaterialTreeDefinitions.find(o => o.ObjectID.toString() === materialTreeObjectID.toString());
            if (materialTree) {
                that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialTree = materialTree;
            }
        }
        that.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialDocumentations = that.consumableMaterialDefinitionFormViewModel.MaterialDocumentations;
        //this.materialTreeDefinitionSource = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialTree;
        this.SUTAppendixSource = SUTMalzemeEKEnum.Items;
        this.panelTag = Guid.newGuid().toString().replace(/-/g, "");
        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.AllowToGivePatient == null) {
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.AllowToGivePatient = true;
        }
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Chargable = true;

        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode) {
            this.GMDNCode = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode.ConceptCode + ", " + this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode.Name_Tr;
        } else {
            this.GMDNCode = undefined;
        }
        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive) {
            this.IsPackageExclusiveValue = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive ? PackageExclusiveEnum.Excluded : PackageExclusiveEnum.Included;
        } else {
            this.IsPackageExclusiveValue = undefined;
        }

        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Producer) {
            if (this.ProducerdataSource.find(x => x.FirmIdentifierNo == this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Producer.FirmIdentifierNo) == null) {
                this.ProducerdataSource.push(this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Producer);
            }
        }

        this.MaterialPatientTypeSeleceted = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPatientType;

        this.selectedRevenueSubAccountCodeItem = this.consumableMaterialDefinitionFormViewModel.RevenueSubAccountCodeDef;

        this.materialTreeDefinitionSource = this.consumableMaterialDefinitionFormViewModel.MaterialTreeDefList;


        if (this.selectedRevenueSubAccountCodeItem != null) {
            this.selectedRevenueSubAccountCodeItemDescription = this.selectedRevenueSubAccountCodeItem.Description;
        }
        //this.getRevenueSubAccountDataSource();




    }
    selectedRevenueSubAccountCodeItemDescription: string;
    public async loadObjectModel() {
        await this.LoadModelComponent();
        await this.filegrid();
        await this.getGMDNCodes();
        await this.controlOfValueNull();
    }


    async ngOnInit() {
        await this.load();
    }


    public cancel() {
        super.cancel();
    }

    LoadPanelMessage = "İşlem Gerçekleştiriliyor.";
    protected async save() {
        this.loadingVisible = true;
        this.consumableMaterialDefinitionFormViewModel.MaterialSpecialtysList = new Array<Guid>();
        for (let item of this.MaterialSpecialtysGridDataSource) {
            this.consumableMaterialDefinitionFormViewModel.MaterialSpecialtysList.push(item.ObjectID);
        }
        this.consumableMaterialDefinitionFormViewModel.ConsMaterialEquvalentList = new Array<Guid>();
        for (let item of this.EquivalentMaterialList) {
            this.consumableMaterialDefinitionFormViewModel.ConsMaterialEquvalentList.push(item.ObjectID);
        }

        this.consumableMaterialDefinitionFormViewModel.ProdureDefs = new Array<Guid>();
        if (this.GridDataSource != null) {
            for (let item of this.GridDataSource)
                this.consumableMaterialDefinitionFormViewModel.ProdureDefs.push(item.ObjectID);
        }

        if (this._ConsumableMaterialDefinition.Name == null) {
            ServiceLocator.MessageService.showError("Malzeme Adı Zorunlu Alan!");
            this.loadingVisible = false;
            return;
        }
        if (this._ConsumableMaterialDefinition.StockCard == null) {
            ServiceLocator.MessageService.showError("Taşınır Kodu Tanımı Zorunludur!");
            this.loadingVisible = false;
            return;
        }

        if (this._ConsumableMaterialDefinition.AllowToGivePatient == true) {
            if (this._ConsumableMaterialDefinition.Barcode == null) {
                ServiceLocator.MessageService.showError("Barkod Alanı Zorunludur!");
                this.loadingVisible = false;
                return;
            }
        }
        if (this._ConsumableMaterialDefinition.MaterialTree == null) {
            ServiceLocator.MessageService.showError("Malzeme Grubu Zorunludur!");
            this.loadingVisible = false;
            return;
        }
        if (this.MaterialVatRate == null) {
            ServiceLocator.MessageService.showError("KDV Oranı Zorunludur!");
            this.loadingVisible = false;
            this.consumableMaterialDefinitionFormViewModel.MaterialVatRateIn = this.MaterialVatRate;
            return;
        }
        if (this._ConsumableMaterialDefinition.IsPackageExclusive == null) {
            ServiceLocator.MessageService.showError("Paket Bilgisi Zorunludur!");
            this.loadingVisible = false;
            this.loadingVisible = false;
            return;
        }

        if (this._ConsumableMaterialDefinition.AllowToGivePatient == true) {
            if (this._ConsumableMaterialDefinition.SUTAppendix == null) {
                ServiceLocator.MessageService.showError("SUT Eki Zorunludur!");
                this.loadingVisible = false;
                return;
            }
        }

        if (this._ConsumableMaterialDefinition.ShcekShare == null) {
            ServiceLocator.MessageService.showError("S.H.Ç.E.K. Payı Zorunludur!");
            this.loadingVisible = false;
            return;
        }


        if (this.stockInheld == null) {
            this._ViewModel.StockCards.push(this._ConsumableMaterialDefinition.StockCard);
        }
        else {
            if (this._ConsumableMaterialDefinition.AllowToGivePatient == true) {
                if (this._ConsumableMaterialDefinition.PackageAmount == null) {
                    ServiceLocator.MessageService.showError("Kutudaki Adeti Zorunlu Alan!");
                    this.loadingVisible = false;
                    return;
                }
            }

            if (this.MaterialVatRate == null) {
                ServiceLocator.MessageService.showError("KDV Oranı Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
            if (this._ConsumableMaterialDefinition.SendSMS == null) {
                ServiceLocator.MessageService.showError("SMS Gerektirir Zorunlu Alan!");
                this.loadingVisible = false;
                return;
            }
        }

        if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SUTAppendix != null) {
            if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SUTAppendix != SUTMalzemeEKEnum.EK3B1) {
                if (this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Code == null) {
                    ServiceLocator.MessageService.showError("Sut eki EK3B1 dışında seçilen sut ekleri için sut kodu seçimi zorunludur!");
                    this.loadingVisible = false;
                    return;
                }
                if (this.ProducerdataSource != null) {
                    if (this.ProducerdataSource.length == 0) {
                        ServiceLocator.MessageService.showError("Sut eki EK3B1 dışında seçilen sut ekleri firma seçilmesi zorunludur!");
                        this.loadingVisible = false;
                        return;
                    }
                } else {
                    ServiceLocator.MessageService.showError("Sut eki EK3B1 dışında seçilen sut ekleri firma seçilmesi zorunludur!");
                    this.loadingVisible = false;
                    return;
                }
                if (this.ProducerdataSource != null) {
                    if (this.ProducerdataSource.length == 0) {
                        ServiceLocator.MessageService.showError("Sut eki EK3B1 dışında seçilen sut ekleri firma seçilmesi zorunludur!");
                        this.loadingVisible = false;
                        return;
                    }
                } else {
                    ServiceLocator.MessageService.showError("Sut eki EK3B1 dışında seçilen sut ekleri firma seçilmesi zorunludur!");
                    this.loadingVisible = false;
                    return;
                }
            }
        }

        this.consumableMaterialDefinitionFormViewModel.MaterialVatRatesGridList = new Array<MaterialVatRate>();
        let matVatRate: MaterialVatRate = new MaterialVatRate();
        matVatRate.VatRate = this.MaterialVatRate;
        this.consumableMaterialDefinitionFormViewModel.MaterialVatRatesGridList.push(matVatRate);


        this.consumableMaterialDefinitionFormViewModel.Producers = new Array<Producer>();
        this.consumableMaterialDefinitionFormViewModel.Producers = this.ProducerdataSource;

        this.MaterialPatientTypeSeleceted = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.MaterialPatientType;

        this.consumableMaterialDefinitionFormViewModel.MaterialNewPrice = 0;
        if (this.lastCost != null) {
            this.consumableMaterialDefinitionFormViewModel.MaterialNewPrice = this.lastCost;
        }



        super.save().then(x => {
            this.loadingVisible = false;
        }).catch(error => {
            this.loadingVisible = false;
        });
    }


    onSutAppendixChange(event) {
        if (event.selectedItem != null) {
            if (event.selectedItem.name == "EK3B1") {
                this._ConsumableMaterialDefinition.IsExpendableMaterial = true;
            } else {
                this._ConsumableMaterialDefinition.IsExpendableMaterial = false;
            }
        }

    }



    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;


    MinimumLevel: number;
    MaximumLevel: number;
    CriticalLevel: number;
    stockInheld: number;

    getGMDNCodes() {
        this.GMDNCodesSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",

                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'GMDNList'
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }

                    return this.httpService.post<any>('/api/ConsumableMaterialDefinitionService/GetGMDNCodes', loadOptions);

                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    showGMDNSelectGrid: boolean = false;
    selectGMDNCode() {
        this.showGMDNSelectGrid = true;
    }

    selectedRow: GMDNDefinition;
    GMDNCode: string;
    selectGMDN(event) {
        this.selectedRow = event.data as GMDNDefinition;
    }

    setGMDN() {
        this.GMDNCode = this.selectedRow.ConceptCode + ", " + this.selectedRow.Name_Tr;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.GMDNCode = this.selectedRow;
        this.showGMDNSelectGrid = false;
    }

    selectPackageType(event) {
        if (this.packageTypeInUse) {
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive = this.IsPackageExclusiveValue == PackageExclusiveEnum.Excluded;
        }
    }

    packageTypeInUse: boolean = false;
    packageTypeOpened() {
        this.packageTypeInUse = true;
    }

    packageTypeClosed() {
        this.packageTypeInUse = false;
    }



    public async getBuilding() {
        //   let that = this;
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/GetShelfAndRowOnStock';
        let params: SaveShelfAndRowOnStock_Input = new SaveShelfAndRowOnStock_Input();
        params.MaterialID = this._ConsumableMaterialDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        await this.httpService.post<any>(apiUrl, params)
            .then(response => {

                this.StockLocationShelf = response.StockLocation.ObjectID;
                this.building = response.StockLocation.ParentStockLocation;

            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }



    ProducerdataSource: Array<any> = new Array<any>();
    selectedproducer: any;

    btnAddClick4() {
        if (this.ProducerdataSource.filter(x => x.Name == this.selectedproducer.Name).length == 0) {
            this.ProducerdataSource.push(this.selectedproducer);
            this._ConsumableMaterialDefinition.Producer = this.selectedproducer;
        }
        else {
            ServiceLocator.MessageService.showError("Aynı Firmayı Birden Fazla Giremezsiniz !");
        }

    }

    selectedMaterialProcedure: any;
    public onMaterialProceduresChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialProcedures != event) {
            this.selectedMaterialProcedure = event;
            this.btnMaterialProcedureAddClick();
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


    public materialTreeDefinitionSource: any = {};
    public RevenueSubAccountCodeSource;
    selectedRevenueSubAccountCodeItem: any = {};
    public seletedRevenueSubAccObjectID;
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
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.RevenueSubAccountCode = e.data;
        this.selectedRevenueSubAccountCodeItem = e.data;
        this.selectedRevenueSubAccountCodeItemDescription = this.selectedRevenueSubAccountCodeItem.Description;
    }

    public getMaterialPriceDetails() {
        let that = this;
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/GetMaterialPriceDetails?StoreID=' + this.StoreID + "&MaterialObjectID=" + this._ConsumableMaterialDefinition.ObjectID;
        that.httpService.get<any>(apiUrl)
            .then(response => {
                this.MinimumLevel = response.MinimumLevel;
                this.MaximumLevel = response.MaximumLevel;
                this.CriticalLevel = response.CriticalLevel;
                this.stockInheld = response.Inheld;
            })
            .catch(error => {
                this.messageService.showError(error);
            });
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
    public InputsResult;
    async GetForInputs() {
        try {
            let inputDvo = new GetReport();
            //  inputDvo.selectedType = this.selectedMinMaxCalc;
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._ConsumableMaterialDefinition.ObjectID.toString();
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


    public OutputsResult;
    async GetForOutputs() {
        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._ConsumableMaterialDefinition.ObjectID.toString();
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
    public HospitalInventoryResult;
    async GetForHospitalInventories() {

        try {
            let inputDvo = new GetReport();
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._ConsumableMaterialDefinition.ObjectID.toString();
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


    public MontlyReportsResult;
    async GetForMontlyReports() {
        try {
            let inputDvo = new GetReport();
            //  inputDvo.selectedType = this.selectedMinMaxCalc;
            inputDvo.StoreID = this.StoreID.toString();
            inputDvo.MaterialID = this._ConsumableMaterialDefinition.ObjectID.toString();
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
            })
        }
        catch (ex) {
        }
    }

    selectAccountingTerm(data: any) {
        this.accountingTermObjId = data.selectedItem.ObjId;

    }

    selectedServiceProcedure: any;
    onServiceProcedureChange(event) {
        this.selectedServiceProcedure = event;
    }

    selectedEquivalentMaterial: any;
    onEquivalentMaterialSelectionChange(event) {
        this.selectedEquivalentMaterial = event;
        this.AddEquivalentMaterial();
    }
    public EquivalentDrugList: Array<any> = new Array<any>();

    equivalentMaterial: EquivalentConsMaterial;
    tempdrug: EquivalentMaterial = new EquivalentMaterial();
    AddEquivalentMaterial() {
        if (this.EquivalentDrugList == null) {
            this.EquivalentDrugList = new Array<any>();
        }

        if (this.EquivalentDrugList.filter(x => x.ObjectID == this.selectedEquivalentMaterial.ObjectID).length != 0) {
            ServiceLocator.MessageService.showError("Aynı Malzemeyi Birden Fazla Giremezsiniz !");
            throw new TTException(i18n("M11354", "Aynı Malzemeyi Birden Fazla Giremezsiniz ! "));
        }

        else {
            this.equivalentMaterial.ObjectID = this.selectedEquivalentMaterial.ObjectID;
            this.tempdrug.Equivalent = this.selectedEquivalentMaterial.Name;
            this.tempdrug.Drug = this.selectedEquivalentMaterial.ObjectID;
            this.EquivalentDrugList.push(this.tempdrug);
            this.tempdrug = new EquivalentMaterial();
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ManuelEquivalentConsMat.push(this.equivalentMaterial);
            this.equivalentMaterial = new EquivalentConsMaterial();
        }
    }

    @ViewChild('manuelEquivalentMatsGrid') manuelEquivalentMatsGrid: DxDataGridComponent;
    async EquivalentMaterialGrid_CellContentClicked(data: any) {
        let that = this;
        if (this.ReadOnly != true) {
            if (data.column.name = "RowDelete") {
                if (data.row != null) {
                    if (data.row.key != null) {
                        if (data.row.key) {
                            this.manuelEquivalentMatsGrid.instance.deleteRow(data.rowIndex);
                        }
                        else {
                            data.key.EntityState = EntityStateEnum.Deleted;
                            this.manuelEquivalentMatsGrid.instance.filter(['EntityState', '<>', 1]);
                            this.manuelEquivalentMatsGrid.instance.refresh();
                        }
                    }
                }
            }
        }
    }

    btnServiceProcedureAddClick() {
        // MaterialProcedures = new MaterialProcedures();
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
                ServiceLocator.MessageService.showError("Aynı Malzemeyi Birden Fazla Giremezsiniz !");
                throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
            }
        });

        /*   this.httpService.post<MaterialProcedures_Output>(apiUrl, param).then(response => {
              if (response) {
                  //Datasource reload
                  that.GetMaterialProcedures(that.ObjectID);
              }
          }); */
    }

    /* onConsumableMaterialProcedureServiceRowRemoving(e: any) {
        if (e.data.ObjectID != null) {
            let apiUrl = '/api/ConsumableMaterialDefinitionService/DeleteMaterialProcedures';
            this.httpService.post(apiUrl, { ObjectID: e.data.ObjectID }).then(response => {
                if (response) {
                    //Datasource reload
                    this.GetMaterialProcedures(this.ObjectID);
                }
            });
        }
    }
 */
    building: any;
    public ParentStockLocationList: Array<any> = [];


    onBuildingSelectionChanged(event) {
        this.GetStockShelfLocation();
    }


    StockLocationShelf: any;
    public StockLocationList: Array<any> = [];




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

    showPriceMedulaForm: boolean = false;
    public updateMaterialPriceOutput: Array<UpdateMaterialPriceOutput> = new Array<UpdateMaterialPriceOutput>();
    public tempMaterialPriceOutput: Array<UpdateMaterialPriceOutput> = new Array<UpdateMaterialPriceOutput>();

    async SUT_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.updateMedulaByMaterial();
        }
    }

    async updateMedulaByMaterial() {
        if (this.tempMaterialPriceOutput.length > 0) {
            if (String.isNullOrEmpty(this._ConsumableMaterialDefinition.Code) != true) {
                this.updateMaterialPriceOutput = this.tempMaterialPriceOutput.filter(x => x.Code == this._ConsumableMaterialDefinition.Code);
                if (this.updateMaterialPriceOutput.length > 1) {
                    this.lastCost = this.updateMaterialPriceOutput[0].Price;
                    let sutApp = this.SUTAppendixSource.find(x => x.name == this.updateMaterialPriceOutput[0].SutAppandix.trim());
                    this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SUTAppendix = sutApp.ordinal;
                }
                else {
                    ServiceLocator.MessageService.showInfo("SUT KODU SİSTEMDE YOKTUR.");
                    this.updateMaterialPriceOutput = this.tempMaterialPriceOutput;
                    this.showPriceMedulaForm = true;
                }
            }
            else {
                this.updateMaterialPriceOutput = this.tempMaterialPriceOutput;
                this.showPriceMedulaForm = true;
            }
        }
        else {
            this.loadingVisible = true;
            this.LoadPanelMessage = "Meduladan Fiyatlar Getiriliyor..";
            let apiUrl: string = '/api/ConsumableMaterialDefinitionService/updateMaterialPriceBySutKodu';
            await this.httpService.get<Array<UpdateMaterialPriceOutput>>(apiUrl)
                .then(response => {
                    let result = response;
                    if (result) {
                        this.updateMaterialPriceOutput = result as Array<UpdateMaterialPriceOutput>;
                        this.tempMaterialPriceOutput = this.updateMaterialPriceOutput;
                        if (this._ConsumableMaterialDefinition.Code) {
                            this.updateMaterialPriceOutput = this.updateMaterialPriceOutput.filter(x => x.Code == this._ConsumableMaterialDefinition.Code);
                            if (this.updateMaterialPriceOutput.length == 1) {
                                this.lastCost = this.updateMaterialPriceOutput[0].Price;
                                let sutApp = this.SUTAppendixSource.find(x => x.name == this.updateMaterialPriceOutput[0].SutAppandix.trim());
                                this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SUTAppendix = sutApp.ordinal;
                            }
                            else {
                                ServiceLocator.MessageService.showInfo("SUT KODU SİSTEMDE YOKTUR.");
                                this.updateMaterialPriceOutput = this.tempMaterialPriceOutput;
                                this.showPriceMedulaForm = true;
                            }
                        }
                        else {
                            this.updateMaterialPriceOutput = this.tempMaterialPriceOutput;
                            this.showPriceMedulaForm = true;
                        }
                        this.loadingVisible = false;
                    }
                })
                .catch(error => {
                    this.messageService.showError(error);
                    this.loadingVisible = false;
                    this.LoadPanelMessage = "İşlemler Yapılıyor..";
                });
            this.LoadPanelMessage = "İşlemler Yapılıyor..";
        }
    }


    selectedSUTPriceItem: any;
    updateMaterialPrice(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedSUTPriceItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code 
            this.lastCost = e.data.Price;
            let sutApp = this.SUTAppendixSource.find(x => x.name == e.data.SutAppandix.trim());
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SUTAppendix = sutApp.ordinal;
            this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Code = e.data.Code;
            this.showPriceMedulaForm = false;
        }
    }


    async updateMedulaByMaterialBtn() {
        if (String.isNullOrEmpty(this._ConsumableMaterialDefinition.Code) != true) {
            if (this.updateMaterialPriceOutput.length > 0) {
                let inputDTO: MaterialPriceByMedulaSUT_Input = new MaterialPriceByMedulaSUT_Input();
                inputDTO.updateMaterialPriceOutput = this.updateMaterialPriceOutput[0];
                let apiUrl: string = '/api/ConsumableMaterialDefinitionService/updateMaterialPriceByMedulaSUT';
                await this.httpService.post(apiUrl, inputDTO)
                    .then(response => {
                        let result = response;
                        if (result) {
                            this.messageService.showSuccess("Başarılı bir şekilde fiyatlar güncellendi.");
                            this.loadingVisible = false;
                        }
                    })
                    .catch(error => {
                        this.messageService.showError(error);
                        this.loadingVisible = false;
                    });
            }
        }
        else {
            ServiceLocator.MessageService.showError("SUT KODU ALANI DOLU OLMASI GEREKLİDİR.");
        }
    }

    totalUpdatePatientPriceCount: string;
    priceEndDate: Date;
    priceStartDate: Date;
    unUpdatedPatienList: Array<pricePatienList> = new Array<pricePatienList>();
    UpdatedPatienList: Array<pricePatienList> = new Array<pricePatienList>();
    showPatientPriceForm: boolean = false;
    updatePatientPriceBTN: boolean = true;
    async onPatientExitByOldPrice() {
        this.showPatientPriceForm = true;
        this.loadingVisible = true;
        if (this._ConsumableMaterialDefinition.ObjectID != null) {
            let apiUrl: string = '/api/ConsumableMaterialDefinitionService/updatePatientMaterialPrice?materialObjId=' + this._ConsumableMaterialDefinition.ObjectID;
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
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/UpdateRepaitPatientPrice';
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


    document: UploadFile_Input = new UploadFile_Input();
    docsUpload: Array<UploadFile_Input> = new Array<UploadFile_Input>();
    totalSize: number = 0;


    onChange($event) {
        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        const fileType = $event.target.parentElement.id;
        if (file.size > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Ekledi�iniz dosyalar�n boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
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
            doc.FileUpdateDate = Date.Now;
            doc.IsNew = true;
            doc.FileName = this.document.FileName;
            doc.Material = this._ConsumableMaterialDefinition.ObjectID;
            this.docsUpload.push(doc);
        }

        else {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13272", "Dosya seçiniz!"), MessageIconEnum.WarningMessage);
        }
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
                formData.append('Material', doc.Material);

                this.http.post('/api/ConsumableMaterialDefinitionService/Upload', formData, { headers: headers }).toPromise().then(result => {
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
        inputParams.MaterialID = this._ConsumableMaterialDefinition.ObjectID;
        inputParams.DocumentType = MaterialDocumentType.Sartname;
        inputParams.OldDocuments = new Array<DocumentGridModel>();
        if (this.consumableMaterialDefinitionFormViewModel.MaterialDocumentations != null && this.consumableMaterialDefinitionFormViewModel.MaterialDocumentations.length > 0) {
            for (let doc of this.consumableMaterialDefinitionFormViewModel.MaterialDocumentations.filter(x => x.MaterialDocumentType == MaterialDocumentType.Sartname)) {
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

    public currentItem: MaterialDocumentation;
    public currentItemName: string;
    selectItem(e) {
        this.currentItem = e.selectedRowKeys[0].ObjectID;
        this.currentItemName = e.selectedRowKeys[0].FileName;
    }

    selectedDocs: Array<any> = new Array<MaterialDocumentation>();
    downloadSelectedFiles() {

        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/DownloadFile';
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
        if (this.consumableMaterialDefinitionFormViewModel.MaterialDocumentations) {
            this._ConsumableMaterialDefinition.MaterialDocumentations = this.consumableMaterialDefinitionFormViewModel.MaterialDocumentations;
            if (this.docsUpload.length == 0) {
                for (let matDoc of this._ConsumableMaterialDefinition.MaterialDocumentations) {
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

    showPriceForm: boolean = false;
    public async getMaterialInStock() {
        this.showPriceForm = true;
    }

    public WarningDate: string;
    lastPrice: string;
    public MaterialPriceInfos: Array<any> = new Array<any>();
    public MaterialPriceList: Array<any> = new Array<any>();
    FirtInStockUnitePriceList: Array<FirstInStockUnitePriceConsumableMaterial> = new Array<FirstInStockUnitePriceConsumableMaterial>();

    EquivalentMaterialList: any[];

    public lastCost: any;
    public async LoadModelComponent() {
        this.loadingVisible = true;
        let apiUrl: string = '/api/ConsumableMaterialDefinitionService/loadModelComponent';
        let params: LoadModelComponentConsumableMaterial_Input = new LoadModelComponentConsumableMaterial_Input();
        params.MaterialID = this._ConsumableMaterialDefinition.ObjectID;
        params.StoreID = this.activeUserService.SelectedUserStore.ObjectID;


        await this.httpService.post<LoadModelComponentConsumableMaterial>(apiUrl, params)
            .then(response => {
                this.materialTreeDefinitionSource = response.MaterialTreeDefinitions
                this.ParentStockLocationList = response.getStockLocationClasses;
                if (response.shelfAndRowOnStock.StockLocation != null) {
                    this.StockLocationShelf = response.shelfAndRowOnStock.StockLocation.ObjectID;
                    this.building = response.shelfAndRowOnStock.StockLocation.ParentStockLocation;
                }
                this.MaterialPriceInfos = response.materialPrices;
                for (let x of response.materialPrices) {
                    this.MaterialPriceList.push(x);
                }
                if (response.materialPrices.length > 0)
                    this.lastCost = response.materialPrices[0].Price;

                if (response.getCritical != null) {
                    this.MinimumLevel = response.getCritical.MinimumLevel;
                    this.MaximumLevel = response.getCritical.MaximumLevel;
                    this.CriticalLevel = response.getCritical.CriticalLevel;
                    this.stockInheld = response.getCritical.Inheld;
                }
                this.GridDataSource = response.materialProcedures;
                this.selectedMaterialSpecialty = response.MaterialSpecialtyList;
                this.FirtInStockUnitePriceList = response.firstInStockUnitePrices;
                if (this.FirtInStockUnitePriceList && this.FirtInStockUnitePriceList.length > 0) {
                    this.lastPrice = this.FirtInStockUnitePriceList[0].UnitePrice.toString();
                }

                if (response.logDataSources != null) {
                    if (response.logDataSources.length > 0) {
                        this.lastUpdateDate = response.logDataSources[response.logDataSources.length - 1].Date;
                        this.lastUpdateUser = response.logDataSources[response.logDataSources.length - 1].AccountName;
                        this.creationDate = response.logDataSources[0].Date;
                        this.creationUser = response.logDataSources[0].AccountName;
                    }
                }
                this.EquivalentMaterialList = response.equivalentMaterialList;
                this.MaterialTypeList = response.MaterialTypeListIsGroupList;
                this.costActionAccountingTerm = response.doSearchaccountingTerm.costActionAccountingTerm;
                this.activeAccountingTerm = response.doSearchaccountingTerm.activeCostActionAccountingTerm;
                this.accountingTermObjId = response.doSearchaccountingTerm.activeCostActionAccountingTerm != null ? response.doSearchaccountingTerm.activeCostActionAccountingTerm.ObjId.toString() : "";
            })
            .catch(error => {
                this.messageService.showError(error);
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
                                this.GridDataSource = this.GridDataSource.filter(x => x.ObjectID === data.row.data.ObjectID);
                            }
                        }
                    }
                }
            }
        }
    }


    selectedMaterialSpecialty: any;
    public MaterialSpecialtysGridDataSource: MaterialSpecialty[] = new Array<MaterialSpecialty>();
    public onMaterialSpecialtyDefinitionMaterialSpecialtyChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialSpecialtys != event) {
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

    @ViewChild('MaterialSpecialtysGrid') MaterialSpecialtysGrid: DxDataGridComponent;
    async consumableMaterialSpecialtyGrid_CellContentClicked(data: any) {
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


    deleteDocumentUnSaved(data) {
        //this.docs.splice(this.docs.indexOf(data), 1);
    }

    controlOfValueNull() {
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsIndividualTrackingRequired = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsIndividualTrackingRequired == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsIndividualTrackingRequired;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.NotAppearInEpicrisis = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SendSMS == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SendSMS;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.HasEstimatedTime = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.HasEstimatedTime == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.HasEstimatedTime;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SendSMS = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SendSMS == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.SendSMS;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsExpendableMaterial = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsExpendableMaterial == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsExpendableMaterial;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ShowZeroOnDistributionInfo = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ShowZeroOnDistributionInfo == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.ShowZeroOnDistributionInfo;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.IsPackageExclusive;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.AllowToGivePatient = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.AllowToGivePatient == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.AllowToGivePatient;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Chargable = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Chargable == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.Chargable;
        this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay = this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay == undefined ? false : this.consumableMaterialDefinitionFormViewModel._ConsumableMaterialDefinition.DailyStay;
    }

    public ontttextbox2Changed(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaxPatientAge != event) {
            this._ConsumableMaterialDefinition.MaxPatientAge = event;
        }
    }

    public ontttextbox3Changed(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MinPatientAge != event) {
            this._ConsumableMaterialDefinition.MinPatientAge = event;
        }
    }
    public ontttextbox4Changed(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.OrderRPTDay != event) {
            this._ConsumableMaterialDefinition.OrderRPTDay = event;
        }
    }
    public ontttextbox5Changed(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.PatientMaxDayOut != event) {
            this._ConsumableMaterialDefinition.PatientMaxDayOut = event;
        }
    }

    public onAllowToGivePatientChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.AllowToGivePatient != event) {
            this._ConsumableMaterialDefinition.AllowToGivePatient = event;
        }
    }

    public onAuctionDateChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.AuctionDate != event) {
            this._ConsumableMaterialDefinition.AuctionDate = event;
        }
    }

    public onBarcodeChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Barcode != event) {
            this._ConsumableMaterialDefinition.Barcode = event;
        }
    }

    public onBarcodeNameChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.BarcodeName != event) {
            this._ConsumableMaterialDefinition.BarcodeName = event;
        }
    }

    public onBransChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Brans != event) {
            this._ConsumableMaterialDefinition.Brans = event;
        }
    }

    public onChargableChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Chargable != event) {
            this._ConsumableMaterialDefinition.Chargable = event;
        }
    }

    public onCodeChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Code != event) {
            this._ConsumableMaterialDefinition.Code = event;
        }
    }

    public onCreateInMedulaDontSendStateChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.CreateInMedulaDontSendState != event) {
            this._ConsumableMaterialDefinition.CreateInMedulaDontSendState = event;
        }
    }

    public onCreationDateChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.CreationDate != event) {
            this._ConsumableMaterialDefinition.CreationDate = event;
        }
    }

    public onCurrentPriceChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.CurrentPrice != event) {
            this._ConsumableMaterialDefinition.CurrentPrice = event;
        }
    }

    public onDistributionTypeStockCardChanged(event): void {
        if (this._ConsumableMaterialDefinition != null &&
            this._ConsumableMaterialDefinition.StockCard != null && this._ConsumableMaterialDefinition.StockCard.DistributionType != event) {
            this._ConsumableMaterialDefinition.StockCard.DistributionType = event;
        }
    }

    public onEnglishNameChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.OriginalName != event) {
            this._ConsumableMaterialDefinition.OriginalName = event;
        }
    }

    public onEstimatedTimeOfCheckChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.EstimatedTimeOfCheck != event) {
            this._ConsumableMaterialDefinition.EstimatedTimeOfCheck = event;
        }
    }

    public onETKMDescriptionChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.ETKMDescription != event) {
            this._ConsumableMaterialDefinition.ETKMDescription = event;
        }
    }

    public onGMDNCodeStockCardChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.GMDNCode != event) {
            this._ConsumableMaterialDefinition.GMDNCode = event;
        }
    }

    public onHasEstimatedTimeConsumableMaterialDefinitionChanged(event): void {
        if (this._ConsumableMaterialDefinition != null &&
            this._ConsumableMaterialDefinition.ParentConsumableMaterial != null && this._ConsumableMaterialDefinition.ParentConsumableMaterial.HasEstimatedTime != event) {
            this._ConsumableMaterialDefinition.ParentConsumableMaterial.HasEstimatedTime = event;
        }
    }

    public onIsActiveChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsActive != event) {
            this._ConsumableMaterialDefinition.IsActive = event;
        }
    }

    public onIsAllogreftChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsAllogreft != event) {
            this._ConsumableMaterialDefinition.IsAllogreft = event;
        }
    }

    public onIsArmyDrugChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsArmyDrug != event) {
            this._ConsumableMaterialDefinition.IsArmyDrug = event;
        }
    }

    public onIsExpendableMaterialChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsExpendableMaterial != event) {
            this._ConsumableMaterialDefinition.IsExpendableMaterial = event;
        }
    }

    public onIsIndividualTrackingRequiredChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsIndividualTrackingRequired != event) {
            this._ConsumableMaterialDefinition.IsIndividualTrackingRequired = event;
        }
    }

    public onIsOldMaterialChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsOldMaterial != event) {
            this._ConsumableMaterialDefinition.IsOldMaterial = event;
        }
    }

    public onIsPackageExclusiveChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsPackageExclusive != event) {
            this._ConsumableMaterialDefinition.IsPackageExclusive = event;
        }
    }

    public onIsRestrictedMaterialChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsRestrictedMaterial != event) {
            this._ConsumableMaterialDefinition.IsRestrictedMaterial = event;
        }
    }

    public onIsTagNoRequiredChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.IsTagNoRequired != event) {
            this._ConsumableMaterialDefinition.IsTagNoRequired = event;
        }
    }

    public onLicenceDateChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.LicenceDate != event) {
            this._ConsumableMaterialDefinition.LicenceDate = event;
        }
    }

    public onLicenceNOChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.LicenceNO != event) {
            this._ConsumableMaterialDefinition.LicenceNO = event;
        }
    }

    public onLicencingOrganizationChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.LicencingOrganization != event) {
            this._ConsumableMaterialDefinition.LicencingOrganization = event;
        }
    }

    public onMaterialPlaceOfUseDefChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialPlaceOfUseDef != event) {
            this._ConsumableMaterialDefinition.MaterialPlaceOfUseDef = event;
        }
    }

    public onMaterialPricingTypeChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialPricingType != event) {
            this._ConsumableMaterialDefinition.MaterialPricingType = event;
        }
    }

    public onMaterialPurposeDefinitionChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialPurposeDefinition != event) {
            this._ConsumableMaterialDefinition.MaterialPurposeDefinition = event;
        }
    }

    public onProducerChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Producer != event) {
            this.selectedproducer = event;
            this.btnAddClick4();
        }
    }


    public onProducerChanged2(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Producer != event) {
            this.selectedproducer = event;
        }
    }

    public onMaterialTreeChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MaterialTree != event) {
            this._ConsumableMaterialDefinition.MaterialTree = event;
        }
    }

    public onMedulaMultiplierChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MedulaMultiplier != event) {
            this._ConsumableMaterialDefinition.MedulaMultiplier = event;
        }
    }

    public onMkysMalzemeKoduChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.MkysMalzemeKodu != event) {
            this._ConsumableMaterialDefinition.MkysMalzemeKodu = event;
        }
    }

    public onNameChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Name != event) {
            this._ConsumableMaterialDefinition.Name = event;
        }
    }

    public onPackageAmountChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.PackageAmount != event) {
            this._ConsumableMaterialDefinition.PackageAmount = event;
        }
    }

    public onProductNumberChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.ProductNumber != event) {
            this._ConsumableMaterialDefinition.ProductNumber = event;
        }
    }

    public onPurchaseDateChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.PurchaseDate != event) {
            this._ConsumableMaterialDefinition.PurchaseDate = event;
        }
    }

    public onRegistrationAuctionNoChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.RegistrationAuctionNo != event) {
            this._ConsumableMaterialDefinition.RegistrationAuctionNo = event;
        }
    }

    public onSendSMSChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.SendSMS != event) {
            this._ConsumableMaterialDefinition.SendSMS = event;
        }
    }

    public onStockCardChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.StockCard != event) {
            this._ConsumableMaterialDefinition.StockCard = event;
            if (this._ConsumableMaterialDefinition.StockCard != null) {
                this.selectionStockCardMkysKayitID();
            }
        }
    }

    public async selectionStockCardMkysKayitID() {
        try {
            let GetSavedTaskModel = '/api/ConsumableMaterialDefinitionService/StockCardMkysKayitID?ObjectID=' + this._ConsumableMaterialDefinition.StockCard.ObjectID;
            this.httpService.get(GetSavedTaskModel, null).then(response => {
                if (response != 0) {
                    this._ConsumableMaterialDefinition.MkysMalzemeKodu = response as number;
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
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.StorageConditions != event) {
            this._ConsumableMaterialDefinition.StorageConditions = event;
        }
    }

    public onSUTAppendixChanged(event): void {
        if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.SUTAppendix != event) {
            this._ConsumableMaterialDefinition.SUTAppendix = event;
        }
    }
    public onDescriptionChanged(event): void {
        if (event != null) {
            if (this._ConsumableMaterialDefinition != null && this._ConsumableMaterialDefinition.Description != event) {
                this._ConsumableMaterialDefinition.Description = event;
            }
        }
    }

    protected redirectProperties(): void {
        redirectProperty(this.Barcode, "Text", this.__ttObject, "Barcode");
        redirectProperty(this.Name, "Text", this.__ttObject, "Name");
        redirectProperty(this.SendSMS, "Value", this.__ttObject, "SendSMS");
        redirectProperty(this.Chargable, "Value", this.__ttObject, "Chargable");
        redirectProperty(this.AllowToGivePatient, "Value", this.__ttObject, "AllowToGivePatient");
        redirectProperty(this.IsActive, "Value", this.__ttObject, "ISACTIVE");
        redirectProperty(this.IsRestrictedMaterial, "Value", this.__ttObject, "IsRestrictedMaterial");
        redirectProperty(this.IsExpendableMaterial, "Value", this.__ttObject, "IsExpendableMaterial");
        redirectProperty(this.IsOldMaterial, "Value", this.__ttObject, "IsOldMaterial");
        redirectProperty(this.IsArmyDrug, "Value", this.__ttObject, "IsArmyDrug");
        redirectProperty(this.IsPackageExclusive, "Value", this.__ttObject, "IsPackageExclusive");
        redirectProperty(this.IsIndividualTrackingRequired, "Value", this.__ttObject, "IsIndividualTrackingRequired");
        redirectProperty(this.IsTagNoRequired, "Value", this.__ttObject, "IsTagNoRequired");
        redirectProperty(this.Code, "Text", this.__ttObject, "Code");
        redirectProperty(this.EnglishName, "Text", this.__ttObject, "OriginalName");
        redirectProperty(this.CreationDate, "Value", this.__ttObject, "CreationDate");
        redirectProperty(this.MkysMalzemeKodu, "Text", this.__ttObject, "MkysMalzemeKodu");
        redirectProperty(this.SUTAppendix, "Value", this.__ttObject, "SUTAppendix");
        redirectProperty(this.StorageConditions, "Text", this.__ttObject, "StorageConditions");
        redirectProperty(this.EstimatedTimeOfCheck, "Text", this.__ttObject, "EstimatedTimeOfCheck");
        redirectProperty(this.ProductNumber, "Text", this.__ttObject, "ProductNumber");
        redirectProperty(this.BarcodeName, "Text", this.__ttObject, "BarcodeName");
        redirectProperty(this.PackageAmount, "Text", this.__ttObject, "PackageAmount");
        redirectProperty(this.CurrentPrice, "Text", this.__ttObject, "CurrentPrice");
        redirectProperty(this.LicenceDate, "Value", this.__ttObject, "LicenceDate");
        redirectProperty(this.LicenceNO, "Text", this.__ttObject, "LicenceNO");
        redirectProperty(this.LicencingOrganization, "Value", this.__ttObject, "LicencingOrganization");
        redirectProperty(this.MaterialPricingType, "Value", this.__ttObject, "MaterialPricingType");
        redirectProperty(this.IsAllogreft, "Value", this.__ttObject, "IsAllogreft");
        redirectProperty(this.CreateInMedulaDontSendState, "Value", this.__ttObject, "CreateInMedulaDontSendState");
        redirectProperty(this.HasEstimatedTimeConsumableMaterialDefinition, "Value", this.__ttObject, "ParentConsumableMaterial.HasEstimatedTime");
        redirectProperty(this.RegistrationAuctionNo, "Text", this.__ttObject, "RegistrationAuctionNo");
        redirectProperty(this.AuctionDate, "Value", this.__ttObject, "AuctionDate");
        redirectProperty(this.PurchaseDate, "Value", this.__ttObject, "PurchaseDate");
        redirectProperty(this.MedulaMultiplier, "Text", this.__ttObject, "MedulaMultiplier");
        redirectProperty(this.ETKMDescription, "Text", this.__ttObject, "ETKMDescription");
        redirectProperty(this.Description, "Rtf", this.__ttObject, "Description");
        redirectProperty(this.MaxPatientAge, "Text", this.__ttObject, "MaxPatientAge");
        redirectProperty(this.MinPatientAge, "Text", this.__ttObject, "MinPatientAge");
        redirectProperty(this.OrderRPTDay, "Text", this.__ttObject, "OrderRPTDay");
        redirectProperty(this.PatientMaxDayOut, "Text", this.__ttObject, "PatientMaxDayOut");
        redirectProperty(this.SEX, "Value", this.__ttObject, "SEX");


    }

    public initFormControls(): void {

        this.grdMaterialProcedures = new TTVisual.TTObjectListBox();
        this.grdMaterialProcedures.Name = "grdMaterialProcedures";
        this.grdMaterialProcedures.ListDefName = 'ProcedureListDefinition';
        this.grdMaterialProcedures.TabIndex = 64;

        this.IsTagNoRequired = new TTVisual.TTCheckBox();
        this.IsTagNoRequired.Value = false;
        this.IsTagNoRequired.Text = "K�nye No Zorunlu";
        this.IsTagNoRequired.Name = "IsTagNoRequired";
        this.IsTagNoRequired.TabIndex = 64;

        this.IsIndividualTrackingRequired = new TTVisual.TTCheckBox();
        this.IsIndividualTrackingRequired.Value = false;
        this.IsIndividualTrackingRequired.Text = "Tekil Takip Gerektirir";
        this.IsIndividualTrackingRequired.Name = "IsIndividualTrackingRequired";
        this.IsIndividualTrackingRequired.TabIndex = 63;

        this.SendSMS = new TTVisual.TTCheckBox();
        this.SendSMS.Value = false;
        this.SendSMS.Text = "SMS G�nder";
        this.SendSMS.Name = "SendSMS";
        this.SendSMS.TabIndex = 62;

        this.SUTAppendix = new TTVisual.TTEnumComboBox();
        this.SUTAppendix.DataTypeName = "SUTMalzemeEKEnum";
        this.SUTAppendix.Name = "SUTAppendix";
        this.SUTAppendix.TabIndex = 61;

        this.lblSUTAppendix = new TTVisual.TTLabel();
        this.lblSUTAppendix.Text = "SUT Eki";
        this.lblSUTAppendix.Name = "lblSUTAppendix";
        this.lblSUTAppendix.TabIndex = 60;

        this.labelMkysMalzemeKodu = new TTVisual.TTLabel();
        this.labelMkysMalzemeKodu.Text = "Mkys Malzeme Kodu";
        this.labelMkysMalzemeKodu.Name = "labelMkysMalzemeKodu";
        this.labelMkysMalzemeKodu.TabIndex = 59;

        this.MkysMalzemeKodu = new TTVisual.TTTextBox();
        this.MkysMalzemeKodu.Name = "MkysMalzemeKodu";
        this.MkysMalzemeKodu.TabIndex = 58;

        this.EstimatedTimeOfCheck = new TTVisual.TTTextBox();
        this.EstimatedTimeOfCheck.Name = "EstimatedTimeOfCheck";
        this.EstimatedTimeOfCheck.TabIndex = 55;

        this.StorageConditions = new TTVisual.TTTextBox();
        this.StorageConditions.Name = "StorageConditions";
        this.StorageConditions.TabIndex = 53;

        this.MaxPatientAge = new TTVisual.TTTextBox();
        this.MaxPatientAge.Name = "MaxPatientAge";

        this.MinPatientAge = new TTVisual.TTTextBox();
        this.MinPatientAge.Name = "MinPatientAge";

        this.OrderRPTDay = new TTVisual.TTTextBox();
        this.OrderRPTDay.Name = "OrderRPTDay";

        this.SEX = new TTVisual.TTComboBox();

        this.PatientMaxDayOut = new TTVisual.TTTextBox();
        this.PatientMaxDayOut.Name = "PatientMaxDayOut";

        this.Barcode = new TTVisual.TTTextBox();
        this.Barcode.Name = "Barcode";
        this.Barcode.TabIndex = 38;

        this.IsPackageExclusive = new TTVisual.TTCheckBox();
        this.IsPackageExclusive.Value = false;
        this.IsPackageExclusive.Text = "Paket Harici Faturalan�r";
        this.IsPackageExclusive.Name = "IsPackageExclusive";
        this.IsPackageExclusive.TabIndex = 57;

        this.labelEstimatedTimeOfCheck = new TTVisual.TTLabel();
        this.labelEstimatedTimeOfCheck.Text = "Tahmini Teymin S�resi";
        this.labelEstimatedTimeOfCheck.Name = "labelEstimatedTimeOfCheck";
        this.labelEstimatedTimeOfCheck.TabIndex = 56;

        this.labelStorageConditions = new TTVisual.TTLabel();
        this.labelStorageConditions.Text = "Depolama Ko�ullar�";
        this.labelStorageConditions.Name = "labelStorageConditions";
        this.labelStorageConditions.TabIndex = 54;

        this.labelCreationDate = new TTVisual.TTLabel();
        this.labelCreationDate.Text = "A��l�� Tarihi";
        this.labelCreationDate.Name = "labelCreationDate";
        this.labelCreationDate.TabIndex = 50;

        this.CreationDate = new TTVisual.TTDateTimePicker();
        this.CreationDate.BackColor = "#F0F0F0";
        this.CreationDate.Format = DateTimePickerFormat.Long;
        this.CreationDate.Enabled = false;
        this.CreationDate.Name = "CreationDate";
        this.CreationDate.TabIndex = 49;

        this.IsRestrictedMaterial = new TTVisual.TTCheckBox();
        this.IsRestrictedMaterial.Value = false;
        this.IsRestrictedMaterial.Text = "Kontroll� Sarf Malzeme";
        this.IsRestrictedMaterial.Name = "IsRestrictedMaterial";
        this.IsRestrictedMaterial.TabIndex = 48;

        this.IsOldMaterial = new TTVisual.TTCheckBox();
        this.IsOldMaterial.Value = false;
        this.IsOldMaterial.Text = "Eski Malzeme";
        this.IsOldMaterial.Name = "IsOldMaterial";
        this.IsOldMaterial.TabIndex = 47;

        this.MaterialSpecialtys = new TTVisual.TTGrid();
        this.MaterialSpecialtys.Name = "MaterialSpecialtys";
        this.MaterialSpecialtys.TabIndex = 46;

        this.MaterialSpecialtyDefinitionMaterialSpecialty = new TTVisual.TTListBoxColumn();
        this.MaterialSpecialtyDefinitionMaterialSpecialty.ListDefName = "MaterialSpecialtyList";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.DataMember = "MaterialSpecialtyDefinition";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.DisplayIndex = 0;
        this.MaterialSpecialtyDefinitionMaterialSpecialty.HeaderText = "Branş";
        this.MaterialSpecialtyDefinitionMaterialSpecialty.Name = "MaterialSpecialtyDefinitionMaterialSpecialty";


        this.labelMaterialPurposeDefinition = new TTVisual.TTLabel();
        this.labelMaterialPurposeDefinition.Text = "Malzeme Kullan�m Amac�";
        this.labelMaterialPurposeDefinition.Name = "labelMaterialPurposeDefinition";
        this.labelMaterialPurposeDefinition.TabIndex = 45;

        this.MaterialPurposeDefinition = new TTVisual.TTObjectListBox();
        this.MaterialPurposeDefinition.ListDefName = "MaterialPurposeList";
        this.MaterialPurposeDefinition.Name = "MaterialPurposeDefinition";
        this.MaterialPurposeDefinition.TabIndex = 44;

        this.labelMaterialPlaceOfUseDef = new TTVisual.TTLabel();
        this.labelMaterialPlaceOfUseDef.Text = "Malzeme Kullan�m Yeri";
        this.labelMaterialPlaceOfUseDef.Name = "labelMaterialPlaceOfUseDef";
        this.labelMaterialPlaceOfUseDef.TabIndex = 43;

        this.MaterialPlaceOfUseDef = new TTVisual.TTObjectListBox();
        this.MaterialPlaceOfUseDef.ListDefName = "MaterialPlaceOfUseList";
        this.MaterialPlaceOfUseDef.Name = "MaterialPlaceOfUseDef";
        this.MaterialPlaceOfUseDef.TabIndex = 42;

        this.IsExpendableMaterial = new TTVisual.TTCheckBox();
        this.IsExpendableMaterial.Value = false;
        this.IsExpendableMaterial.Text = "At�k Depolara At�labilir";
        this.IsExpendableMaterial.Name = "IsExpendableMaterial";
        this.IsExpendableMaterial.TabIndex = 40;

        this.labelBarcode = new TTVisual.TTLabel();
        this.labelBarcode.Text = "Orjinal �r�n Numaras�";
        this.labelBarcode.Name = "labelBarcode";
        this.labelBarcode.TabIndex = 39;

        this.cmdSendChanging = new TTVisual.TTButton();
        this.cmdSendChanging.Text = "Sahalara Yolla";
        this.cmdSendChanging.Name = "cmdSendChanging";
        this.cmdSendChanging.TabIndex = 37;
        this.cmdSendChanging.Visible = false;

        this.malzemeTuru = new TTVisual.TTListBoxColumn();
        this.malzemeTuru.ListDefName = "MalzemeTuruListDefinition";
        this.malzemeTuru.DataMember = "MalzemeTuru";
        this.malzemeTuru.HeaderText = "Malzeme Türü";
        this.malzemeTuru.Name = "malzemeTuru";

        this.cmdChangeTypeToFixedAsset = new TTVisual.TTButton();
        this.cmdChangeTypeToFixedAsset.Text = "Demirba�a �evir";
        this.cmdChangeTypeToFixedAsset.Name = "cmdChangeTypeToFixedAsset";
        this.cmdChangeTypeToFixedAsset.TabIndex = 36;
        this.cmdChangeTypeToFixedAsset.Visible = false;

        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Text = "�retim Detay Bilgileri";
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 35;

        this.ProductionInfoTabPage = new TTVisual.TTTabPage();
        this.ProductionInfoTabPage.DisplayIndex = 0;
        this.ProductionInfoTabPage.BackColor = "#FFFFFF";
        this.ProductionInfoTabPage.TabIndex = 0;
        this.ProductionInfoTabPage.Text = "�retim Detay Bilgileri";
        this.ProductionInfoTabPage.Name = "ProductionInfoTabPage";

        this.HasEstimatedTimeConsumableMaterialDefinition = new TTVisual.TTCheckBox();
        this.HasEstimatedTimeConsumableMaterialDefinition.Value = false;
        this.HasEstimatedTimeConsumableMaterialDefinition.Text = "S.K.T Zorunlu Olsun";
        this.HasEstimatedTimeConsumableMaterialDefinition.Name = "HasEstimatedTimeConsumableMaterialDefinition";
        this.HasEstimatedTimeConsumableMaterialDefinition.TabIndex = 52;

        this.CreateInMedulaDontSendState = new TTVisual.TTCheckBox();
        this.CreateInMedulaDontSendState.Value = false;
        this.CreateInMedulaDontSendState.Text = "Medulaya G�nderilmeyecek Durumunda Olu�tur";
        this.CreateInMedulaDontSendState.Name = "CreateInMedulaDontSendState";
        this.CreateInMedulaDontSendState.TabIndex = 51;

        this.lblMedulaMultiplier = new TTVisual.TTLabel();
        this.lblMedulaMultiplier.Text = "Medula �arpan�";
        this.lblMedulaMultiplier.Name = "lblMedulaMultiplier";
        this.lblMedulaMultiplier.TabIndex = 49;
        this.lblMedulaMultiplier.Visible = false;

        this.labelAuctionDate = new TTVisual.TTLabel();
        this.labelAuctionDate.Text = "�hale Kesinle�me Tarihi";
        this.labelAuctionDate.Name = "labelAuctionDate";
        this.labelAuctionDate.TabIndex = 48;

        this.MedulaMultiplier = new TTVisual.TTTextBox();
        this.MedulaMultiplier.Name = "MedulaMultiplier";
        this.MedulaMultiplier.TabIndex = 48;
        this.MedulaMultiplier.Visible = false;

        this.labelRegistrationAuctionNo = new TTVisual.TTLabel();
        this.labelRegistrationAuctionNo.Text = "�hale Kay�t No /Al�m No";
        this.labelRegistrationAuctionNo.Name = "labelRegistrationAuctionNo";
        this.labelRegistrationAuctionNo.TabIndex = 50;

        this.AuctionDate = new TTVisual.TTDateTimePicker();
        this.AuctionDate.Format = DateTimePickerFormat.Long;
        this.AuctionDate.Name = "AuctionDate";
        this.AuctionDate.TabIndex = 47;

        this.IsAllogreft = new TTVisual.TTCheckBox();
        this.IsAllogreft.Value = false;
        this.IsAllogreft.Text = "Allogreft Malzeme";
        this.IsAllogreft.Name = "IsAllogreft";
        this.IsAllogreft.TabIndex = 40;

        this.RegistrationAuctionNo = new TTVisual.TTTextBox();
        this.RegistrationAuctionNo.Name = "RegistrationAuctionNo";
        this.RegistrationAuctionNo.TabIndex = 49;

        this.labelPurchaseDate = new TTVisual.TTLabel();
        this.labelPurchaseDate.Text = "Sat�nalma Tarihi";
        this.labelPurchaseDate.Name = "labelPurchaseDate";
        this.labelPurchaseDate.TabIndex = 25;

        this.PurchaseDate = new TTVisual.TTDateTimePicker();
        this.PurchaseDate.Format = DateTimePickerFormat.Long;
        this.PurchaseDate.Name = "PurchaseDate";
        this.PurchaseDate.TabIndex = 24;

        this.labelMaterialPricingType = new TTVisual.TTLabel();
        this.labelMaterialPricingType.Text = "Malzeme Fiyatland�rma T�r�";
        this.labelMaterialPricingType.Name = "labelMaterialPricingType";
        this.labelMaterialPricingType.TabIndex = 23;

        this.MaterialPricingType = new TTVisual.TTEnumComboBox();
        this.MaterialPricingType.DataTypeName = "MaterialPricingTypeEnum";
        this.MaterialPricingType.Name = "MaterialPricingType";
        this.MaterialPricingType.TabIndex = 22;

        this.labelBrans = new TTVisual.TTLabel();
        this.labelBrans.Text = "Malzeme Bran��";
        this.labelBrans.Name = "labelBrans";
        this.labelBrans.TabIndex = 21;

        this.Brans = new TTVisual.TTObjectListBox();
        this.Brans.ListDefName = "SpecialityListDefinition";
        this.Brans.Name = "Brans";
        this.Brans.TabIndex = 20;

        this.labelProducer = new TTVisual.TTLabel();
        this.labelProducer.Text = "�retici";
        this.labelProducer.Name = "labelProducer";
        this.labelProducer.TabIndex = 19;

        this.Producer = new TTVisual.TTObjectListBox();
        this.Producer.ListDefName = "ProducerListDefinition";
        this.Producer.Name = "Producer";
        this.Producer.TabIndex = 18;

        this.labelGMDNCodeStockCard = new TTVisual.TTLabel();
        this.labelGMDNCodeStockCard.Text = "GMDN Kodu";
        this.labelGMDNCodeStockCard.Name = "labelGMDNCodeStockCard";
        this.labelGMDNCodeStockCard.TabIndex = 17;

        this.GMDNCodeStockCard = new TTVisual.TTObjectListBox();
        this.GMDNCodeStockCard.ListDefName = "GMDNCodeListDefinition";
        this.GMDNCodeStockCard.Name = "GMDNCodeStockCard";
        this.GMDNCodeStockCard.TabIndex = 16;

        this.labelPackageAmount = new TTVisual.TTLabel();
        this.labelPackageAmount.Text = "Ambalaj Miktar�";
        this.labelPackageAmount.Name = "labelPackageAmount";
        this.labelPackageAmount.TabIndex = 15;

        this.PackageAmount = new TTVisual.TTTextBox();
        this.PackageAmount.Name = "PackageAmount";
        this.PackageAmount.TabIndex = 14;

        this.labelLicencingOrganization = new TTVisual.TTLabel();
        this.labelLicencingOrganization.Text = "Lisans Organizasyonu";
        this.labelLicencingOrganization.Name = "labelLicencingOrganization";
        this.labelLicencingOrganization.TabIndex = 13;

        this.LicencingOrganization = new TTVisual.TTEnumComboBox();
        this.LicencingOrganization.DataTypeName = "LicencingOrganizationEnum";
        this.LicencingOrganization.Name = "LicencingOrganization";
        this.LicencingOrganization.TabIndex = 12;

        this.labelLicenceNO = new TTVisual.TTLabel();
        this.labelLicenceNO.Text = "Lisans Nu.";
        this.labelLicenceNO.Name = "labelLicenceNO";
        this.labelLicenceNO.TabIndex = 11;

        this.LicenceNO = new TTVisual.TTTextBox();
        this.LicenceNO.Name = "LicenceNO";
        this.LicenceNO.TabIndex = 10;

        this.labelLicenceDate = new TTVisual.TTLabel();
        this.labelLicenceDate.Text = "Lisans Tarihi";
        this.labelLicenceDate.Name = "labelLicenceDate";
        this.labelLicenceDate.TabIndex = 9;

        this.LicenceDate = new TTVisual.TTDateTimePicker();
        this.LicenceDate.Format = DateTimePickerFormat.Long;
        this.LicenceDate.Name = "LicenceDate";
        this.LicenceDate.TabIndex = 8;

        this.labelCurrentPrice = new TTVisual.TTLabel();
        this.labelCurrentPrice.Text = "Ambalaj Fiyat�";
        this.labelCurrentPrice.Name = "labelCurrentPrice";
        this.labelCurrentPrice.TabIndex = 7;

        this.CurrentPrice = new TTVisual.TTTextBox();
        this.CurrentPrice.Name = "CurrentPrice";
        this.CurrentPrice.TabIndex = 6;

        this.labelBarcodeName = new TTVisual.TTLabel();
        this.labelBarcodeName.Text = "Etiket Ad�";
        this.labelBarcodeName.Name = "labelBarcodeName";
        this.labelBarcodeName.TabIndex = 5;

        this.BarcodeName = new TTVisual.TTTextBox();
        this.BarcodeName.Name = "BarcodeName";
        this.BarcodeName.TabIndex = 4;

        this.labelProductNumber = new TTVisual.TTLabel();
        this.labelProductNumber.Text = "�r�n Numaras�";
        this.labelProductNumber.Name = "labelProductNumber";
        this.labelProductNumber.TabIndex = 1;

        this.ProductNumber = new TTVisual.TTTextBox();
        this.ProductNumber.Name = "ProductNumber";
        this.ProductNumber.TabIndex = 0;

        this.MaterialVatRateTabPage = new TTVisual.TTTabPage();
        this.MaterialVatRateTabPage.DisplayIndex = 1;
        this.MaterialVatRateTabPage.TabIndex = 1;
        this.MaterialVatRateTabPage.Text = "Fiyat ve KDV Oran� Bilgileri";
        this.MaterialVatRateTabPage.Name = "MaterialVatRateTabPage";

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "KDV Oranlar�";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 40;

        this.MaterialPriceGrid = new TTVisual.TTGrid();
        this.MaterialPriceGrid.ReadOnly = true;
        this.MaterialPriceGrid.Name = "MaterialPriceGrid";
        this.MaterialPriceGrid.TabIndex = 41;

        this.PriceCode = new TTVisual.TTTextBoxColumn();
        this.PriceCode.Required = true;
        this.PriceCode.DisplayIndex = 0;
        this.PriceCode.HeaderText = "Kodu";
        this.PriceCode.Name = "PriceCode";
        this.PriceCode.Width = 100;

        this.Description = new TTVisual.TTTextBox();
        this.Description.Required = true;
        // this.Description.Text = "Fiyat Açıklaması";
        this.Description.Name = "Description";
        this.Description.Multiline = true;
        this.Description.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";

        this.PricingList = new TTVisual.TTListBoxColumn();
        this.PricingList.ListDefName = "PricingListListDefinition";
        this.PricingList.Required = true;
        this.PricingList.DisplayIndex = 2;
        this.PricingList.HeaderText = "Fiyat Listesi";
        this.PricingList.Name = "PricingList";
        this.PricingList.Width = 150;

        this.Price = new TTVisual.TTTextBoxColumn();
        this.Price.Required = true;
        this.Price.DisplayIndex = 3;
        this.Price.HeaderText = "Fiyat";
        this.Price.Name = "Price";
        this.Price.Width = 80;

        this.CurrencyType = new TTVisual.TTListBoxColumn();
        this.CurrencyType.ListDefName = "CurrencyTypeListDefinition";
        this.CurrencyType.Required = true;
        this.CurrencyType.DisplayIndex = 4;
        this.CurrencyType.HeaderText = "Para Birimi";
        this.CurrencyType.Name = "CurrencyType";
        this.CurrencyType.Width = 100;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Ge�erli Malzeme Fiyatlar�";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 40;

        this.MaterialVatRates = new TTVisual.TTGrid();
        this.MaterialVatRates.Name = "MaterialVatRates";
        this.MaterialVatRates.TabIndex = 24;

        this.VatRate = new TTVisual.TTTextBoxColumn();
        this.VatRate.DataMember = "VatRate";
        this.VatRate.DisplayIndex = 0;
        this.VatRate.HeaderText = "KDV Oran�";
        this.VatRate.Name = "VatRate";
        this.VatRate.Width = 80;

        this.StartDate = new TTVisual.TTDateTimePickerColumn();
        this.StartDate.DataMember = "StartDate";
        this.StartDate.DisplayIndex = 1;
        this.StartDate.HeaderText = "Ba�lang�� Tarihi";
        this.StartDate.Name = "StartDate";
        this.StartDate.Width = 100;

        this.EndDate = new TTVisual.TTDateTimePickerColumn();
        this.EndDate.DataMember = "EndDate";
        this.EndDate.DisplayIndex = 2;
        this.EndDate.HeaderText = "Biti� Tarihi";
        this.EndDate.Name = "EndDate";
        this.EndDate.Width = 100;

        this.PictureTabPage = new TTVisual.TTTabPage();
        this.PictureTabPage.DisplayIndex = 2;
        this.PictureTabPage.TabIndex = 2;
        this.PictureTabPage.Text = "Foto�raf�";
        this.PictureTabPage.Name = "PictureTabPage";

        this.MaterialPicture = new TTVisual.TTPictureBoxControl();
        this.MaterialPicture.Name = "MaterialPicture";
        this.MaterialPicture.TabIndex = 0;

        this.ProductLevelTabPage = new TTVisual.TTTabPage();
        this.ProductLevelTabPage.DisplayIndex = 3;
        this.ProductLevelTabPage.TabIndex = 3;
        this.ProductLevelTabPage.Text = "TITUBB �r�n E�le�tirmeleri";
        this.ProductLevelTabPage.Name = "ProductLevelTabPage";

        this.MaterialProductLevels = new TTVisual.TTGrid();
        this.MaterialProductLevels.Name = "MaterialProductLevels";
        this.MaterialProductLevels.TabIndex = 40;

        this.ProductMaterialProductLevel = new TTVisual.TTListBoxColumn();
        this.ProductMaterialProductLevel.ListDefName = "ProductList";
        this.ProductMaterialProductLevel.DataMember = "Product";
        this.ProductMaterialProductLevel.DisplayIndex = 0;
        this.ProductMaterialProductLevel.HeaderText = "TITUBB �r�n�";
        this.ProductMaterialProductLevel.Name = "ProductMaterialProductLevel";
        this.ProductMaterialProductLevel.ReadOnly = true;
        this.ProductMaterialProductLevel.Width = 800;

        this.ETKMDescriptionTabPage = new TTVisual.TTTabPage();
        this.ETKMDescriptionTabPage.DisplayIndex = 4;
        this.ETKMDescriptionTabPage.TabIndex = 4;
        this.ETKMDescriptionTabPage.Text = "ETKM A��klama";
        this.ETKMDescriptionTabPage.Name = "ETKMDescriptionTabPage";

        this.ETKMDescription = new TTVisual.TTTextBox();
        this.ETKMDescription.Multiline = true;
        this.ETKMDescription.Name = "ETKMDescription";
        this.ETKMDescription.TabIndex = 49;

        this.Code = new TTVisual.TTTextBox();
        this.Code.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Code.Name = "Code";
        this.Code.TabIndex = 13;

        this.Name = new TTVisual.TTTextBox();
        this.Name.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Name.Name = "Name";
        this.Name.TabIndex = 9;

        this.EnglishName = new TTVisual.TTTextBox();
        this.EnglishName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.EnglishName.Name = "EnglishName";
        this.EnglishName.TabIndex = 26;

        this.StockCard = new TTVisual.TTObjectListBox();
        this.StockCard.ListDefName = "StockCardList";
        this.StockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.StockCard.Name = "StockCard";
        this.StockCard.TabIndex = 19;
        this.StockCard.ReadOnly = true;
        //this.StockCard.ListFilterExpression ="MALZEMEGETDATA IS NOT NULL";

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "Orjinal Ad�";
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 27;

        this.labelStockCard = new TTVisual.TTLabel();
        this.labelStockCard.Text = "Stok Kart�";
        this.labelStockCard.BackColor = "#DCDCDC";
        this.labelStockCard.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelStockCard.ForeColor = "#000000";
        this.labelStockCard.Name = "labelStockCard";
        this.labelStockCard.TabIndex = 20;

        this.labelCode = new TTVisual.TTLabel();
        this.labelCode.Text = "Malzeme Kodu";
        this.labelCode.BackColor = "#DCDCDC";
        this.labelCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelCode.ForeColor = "#000000";
        this.labelCode.Name = "labelCode";
        this.labelCode.TabIndex = 14;

        this.IsActive = new TTVisual.TTCheckBox();
        this.IsActive.Value = false;
        this.IsActive.Text = "Aktif";
        this.IsActive.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IsActive.Name = "IsActive";
        this.IsActive.TabIndex = 6;

        this.MaterialTree = new TTVisual.TTObjectListBox();
        this.MaterialTree.ListDefName = "MaterialTreeList";
        this.MaterialTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MaterialTree.Name = "MaterialTree";
        this.MaterialTree.TabIndex = 33;


        this.RevenueSubAccountCode = new TTVisual.TTObjectListBox();
        this.RevenueSubAccountCode.ListDefName = "RevenueSubAccountCodeDefList";
        this.RevenueSubAccountCode.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RevenueSubAccountCode.Name = "RevenueSubAccountCode";
        this.RevenueSubAccountCode.TabIndex = 33;

        this.labelMaterialTree = new TTVisual.TTLabel();
        this.labelMaterialTree.Text = "Malzeme Grubu";
        this.labelMaterialTree.BackColor = "#DCDCDC";
        this.labelMaterialTree.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelMaterialTree.ForeColor = "#000000";
        this.labelMaterialTree.Name = "labelMaterialTree";
        this.labelMaterialTree.TabIndex = 34;

        this.labelName = new TTVisual.TTLabel();
        this.labelName.Text = "T�rk�e Ad�";
        this.labelName.BackColor = "#DCDCDC";
        this.labelName.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelName.ForeColor = "#000000";
        this.labelName.Name = "labelName";
        this.labelName.TabIndex = 10;

        this.Chargable = new TTVisual.TTCheckBox();
        this.Chargable.Value = false;
        this.Chargable.Text = "�cretlendirilir";
        this.Chargable.Name = "Chargable";
        this.Chargable.TabIndex = 0;

        this.AllowToGivePatient = new TTVisual.TTCheckBox();
        this.AllowToGivePatient.Value = true;
        this.AllowToGivePatient.Text = "Hastaya Verilir";
        this.AllowToGivePatient.Name = "AllowToGivePatient";
        this.AllowToGivePatient.TabIndex = 0;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "Malzeme Bran�lar�";
        this.ttlabel3.BackColor = "#DCDCDC";
        this.ttlabel3.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.ForeColor = "#000000";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 34;

        this.IsArmyDrug = new TTVisual.TTCheckBox();
        this.IsArmyDrug.Value = false;
        this.IsArmyDrug.Text = "XXXXXX �lac Fabrikas� �retimi";
        this.IsArmyDrug.Name = "IsArmyDrug";
        this.IsArmyDrug.TabIndex = 0;

        this.DistributionTypeStockCard = new TTVisual.TTObjectListBox();
        this.DistributionTypeStockCard.ListDefName = "DistributionTypeList";
        this.DistributionTypeStockCard.Name = "DistributionTypeStockCard";
        this.DistributionTypeStockCard.TabIndex = 38;

        this.labelDistributionTypeStockCard = new TTVisual.TTLabel();
        this.labelDistributionTypeStockCard.Text = "Stok Kart� Da��t�m �ekli";
        this.labelDistributionTypeStockCard.Name = "labelDistributionTypeStockCard";
        this.labelDistributionTypeStockCard.TabIndex = 39;



        this.EquivalentMaterialEquivalentConsMaterial = new TTVisual.TTListBoxColumn();
        this.EquivalentMaterialEquivalentConsMaterial.ListDefName = "ConsumableMaterialList";
        this.EquivalentMaterialEquivalentConsMaterial.DataMember = "EquivalentMaterial";
        this.EquivalentMaterialEquivalentConsMaterial.DisplayIndex = 0;
        this.EquivalentMaterialEquivalentConsMaterial.HeaderText = "Eş Değer İlaç";
        this.EquivalentMaterialEquivalentConsMaterial.Name = "EquivalentMaterialEquivalentConsMaterial";
        this.EquivalentMaterialEquivalentConsMaterial.Width = 600;

        this.MaterialSpecialtysColumns = [this.MaterialSpecialtyDefinitionMaterialSpecialty];
        this.MaterialPriceGridColumns = [this.PriceCode, this.Description, this.PricingList, this.Price, this.CurrencyType];
        this.MaterialVatRatesColumns = [this.VatRate, this.StartDate, this.EndDate];
        this.MaterialProductLevelsColumns = [this.ProductMaterialProductLevel];
        this.tttabcontrol1.Controls = [this.ProductionInfoTabPage, this.MaterialVatRateTabPage, this.PictureTabPage, this.ProductLevelTabPage, this.ETKMDescriptionTabPage];
        this.ProductionInfoTabPage.Controls = [this.HasEstimatedTimeConsumableMaterialDefinition, this.CreateInMedulaDontSendState, this.lblMedulaMultiplier, this.labelAuctionDate, this.MedulaMultiplier, this.labelRegistrationAuctionNo, this.AuctionDate, this.IsAllogreft, this.RegistrationAuctionNo, this.labelPurchaseDate, this.PurchaseDate, this.labelMaterialPricingType, this.MaterialPricingType, this.labelBrans, this.Brans, this.labelProducer, this.Producer, this.labelGMDNCodeStockCard, this.GMDNCodeStockCard, this.labelPackageAmount, this.PackageAmount, this.labelLicencingOrganization, this.LicencingOrganization, this.labelLicenceNO, this.LicenceNO, this.labelLicenceDate, this.LicenceDate, this.labelCurrentPrice, this.CurrentPrice, this.labelBarcodeName, this.BarcodeName, this.labelProductNumber, this.ProductNumber];
        this.MaterialVatRateTabPage.Controls = [this.ttlabel2, this.MaterialPriceGrid, this.ttlabel1, this.MaterialVatRates];
        this.PictureTabPage.Controls = [this.MaterialPicture];
        this.ProductLevelTabPage.Controls = [this.MaterialProductLevels];
        this.ETKMDescriptionTabPage.Controls = [this.ETKMDescription];
        this.Controls = [this.grdMaterialProcedures, this.IsTagNoRequired, this.IsIndividualTrackingRequired, this.SendSMS, this.SUTAppendix, this.lblSUTAppendix, this.labelMkysMalzemeKodu, this.MkysMalzemeKodu, this.EstimatedTimeOfCheck, this.StorageConditions, this.Barcode, this.IsPackageExclusive, this.labelEstimatedTimeOfCheck, this.labelStorageConditions, this.labelCreationDate, this.CreationDate, this.IsRestrictedMaterial, this.IsOldMaterial, this.MaterialSpecialtys, this.MaterialSpecialtyDefinitionMaterialSpecialty, this.labelMaterialPurposeDefinition, this.MaterialPurposeDefinition, this.labelMaterialPlaceOfUseDef, this.MaterialPlaceOfUseDef, this.IsExpendableMaterial, this.labelBarcode, this.cmdSendChanging, this.cmdChangeTypeToFixedAsset, this.tttabcontrol1, this.ProductionInfoTabPage, this.HasEstimatedTimeConsumableMaterialDefinition, this.CreateInMedulaDontSendState, this.lblMedulaMultiplier, this.labelAuctionDate, this.MedulaMultiplier, this.labelRegistrationAuctionNo, this.AuctionDate, this.IsAllogreft, this.RegistrationAuctionNo, this.labelPurchaseDate, this.PurchaseDate, this.labelMaterialPricingType, this.MaterialPricingType, this.labelBrans, this.Brans, this.labelProducer, this.Producer, this.labelGMDNCodeStockCard, this.GMDNCodeStockCard, this.labelPackageAmount, this.PackageAmount, this.labelLicencingOrganization, this.LicencingOrganization, this.labelLicenceNO, this.LicenceNO, this.labelLicenceDate, this.LicenceDate, this.labelCurrentPrice, this.CurrentPrice, this.labelBarcodeName, this.BarcodeName, this.labelProductNumber, this.ProductNumber, this.MaterialVatRateTabPage, this.ttlabel2, this.MaterialPriceGrid, this.PriceCode, this.Description, this.PricingList, this.Price, this.CurrencyType, this.ttlabel1, this.MaterialVatRates, this.VatRate, this.StartDate, this.EndDate, this.PictureTabPage, this.MaterialPicture, this.ProductLevelTabPage, this.MaterialProductLevels, this.ProductMaterialProductLevel, this.ETKMDescriptionTabPage, this.ETKMDescription, this.Code, this.Name, this.EnglishName, this.StockCard, this.ttlabel4, this.labelStockCard, this.labelCode, this.IsActive, this.MaterialTree, this.labelMaterialTree, this.labelName, this.Chargable, this.AllowToGivePatient, this.ttlabel3, this.IsArmyDrug, this.DistributionTypeStockCard, this.labelDistributionTypeStockCard];

    }

}
export enum PackageExclusiveEnum {
    Excluded = 1,
    Included = 0
}

export namespace PackageExclusiveEnum {
    export const _Excluded = new EnumItem(PackageExclusiveEnum.Excluded, 'Excluded', i18n('M13837', 'Paket Hariç'), 0);
    export const _Included = new EnumItem(PackageExclusiveEnum.Included, 'Included', i18n('M17061', 'Paket Dahil'), 1);
    export const Items: Array<EnumItem> = [_Excluded, _Included];

    @ClassType()
    export class PackageExclusiveEnumList implements IEnumList {
        get Items(): Array<EnumItem> {
            return PackageExclusiveEnum.Items;
        }
    }
}
