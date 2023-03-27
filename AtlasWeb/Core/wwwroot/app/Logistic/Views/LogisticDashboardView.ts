//$CC3E8483
import { Component, ViewChild, Input } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import {
    LogisticDashboardViewModel, QueryInputDVO, QueryVademecumInteractionDVO,
    Product, MaterialDetail, VademecumProductDVO,
    StockActionWorkListDashboardItemModel, MinMaxCalculetedItem, CalcMinMaxValueDVO, UpdateMinMaxValueDVO, InStockTransactionInput, InStockTransactionDVO, BudgetTypeSource,
    OutStockTransactionDVO, OutStockTransactionInput, SubStoreExpDateUpdate_Output, SubStoreExpDateUpdate_Input, SubStoreWorksInputDVO, TransactionChartInputDTO, SubStoreWorksOutputDVO
} from '../Models/LogisticDashboardViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DxAccordionComponent, DxDataGridComponent } from 'devextreme-angular';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { UserHelper } from 'app/Helper/UserHelper';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { MinMaxCalcTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MessageIconEnum } from 'NebulaClient/Utils/Enums/MessageIconEnum';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { DrugStickerInfo } from 'app/Barcode/Models/DrugBarcodeInfo';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { barcodeProviderFactory } from 'app/Barcode/Services/BarcodeProviderFactory';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { DatePipe } from '@angular/common';
import { DynamicComponentInfoDVO } from '../Models/LogisticMainViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { StockActionService } from 'app/Fw/Services/StockActionService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { IntegerParam } from 'app/NebulaClient/Mscorlib/QueryParam';
import { CriticalStockLevelTypeEnum } from '../Models/MainViewModel';
import { ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';

@Component({
    selector: 'hvl-logistic-dashboard-view',
    inputs: ['Model'],
    templateUrl: './LogisticDashboardView.html',
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]

})
export class LogisticDashboardView extends BaseComponent<LogisticDashboardViewModel> {

    constructor(container: ServiceContainer, private http: NeHttpService,
        private modalService: IModalService, private objectContextService: ObjectContextService, protected activeUserService: IActiveUserService,
        private reportService: AtlasReportService,
        private barcodePrintService: IBarcodePrintService) {
        super(container);
        this.cikisInfos = new Array<any>();
        this.girisInfos = new Array<any>();
        this.cikisInfosDetail = new Array<any>();
        this.girisInfosDetail = new Array<any>();
        this.architectureInfoList = new Array<any>();
        this.architectureInfoListShow = new Array<any>();
        this.workListItems = new Array<any>();
        this.selectMonth = false;
        this.costActionGridMateril = new Array<any>();
        this.costActionAccountingTerm = new Array<any>();
        this.StockdataInformation = new Array<any>();
        this.StockdataLevelType = new Array<any>();
        this.StockBudgetType = new Array<any>();
        this.IsMainStoreFlag = false;
        this.MaterialInheldMaxMin = new Array<any>();
        this.DrugObjId = '';

    }

    public get logisticDashboardViewModel(): LogisticDashboardViewModel {
        return this.Model;
    }
    public DrugObjId: string;
    public SelectBoxValue: any;
    public ValueSelectBox: any;
    public costActionGridMateril: any;
    public SelectBoxDataSource: any;
    public architectureInfoList: any;
    public architectureInfoListShow: any;
    public costActionAccountingTerm: any;
    public architectureInfoSeries: any;
    public materialDetail: any;
    public StockdataInformation: any;
    public StockdataLevelType: any;
    public StockBudgetType: any;
    public IsMainStoreFlag: boolean;
    public MaterialInheldMaxMin: any;
    public cikisInfos: any;
    public girisInfos: any;
    public cikisInfosDetail: any;
    public girisInfosDetail: any;
    public componentInfo: DynamicComponentInfo;
    public workListItems: Array<StockActionWorkListDashboardItemModel>;
    public selectMonth: boolean = false;
    public selecttableStores: Array<Store>;
    public prdList: Array<Product>;
    public productDVO: VademecumProductDVO;
    public MinMaxCalcTypes: Array<MinMaxCalcTypeEnum> = new Array<MinMaxCalcTypeEnum>();
    public selectedMinMaxCalc: MinMaxCalcTypeEnum;
    public startDate: Date;
    public endDate: Date;
    public ObjectID: string;
    public SelectedMaterialName: string;
    public CalculetedItems: Array<MinMaxCalculetedItem>;
    //public UpdateCalculetedItems: Array<MinMaxCalculetedItem>;
    public selectedGridItems: Array<MinMaxCalculetedItem>;

    public hasRoleDashboardMaterialStatus: boolean;
    public hasRoleDashboardCostAction: boolean;
    public hasRoleDashboardMinMax: boolean;
    public hasRoleSubStoreExpDateUpdate: boolean;
    public hasRoleSubStoreWaitingWorks: boolean;

    btnOpenNewAccountingTermDisable: boolean = true; //yetki bazlı açılacak....:
    btnMaterialBarcodeDisable: boolean = true;
    defaultVisible: boolean = false;
    withTemplateVisible: boolean = false;
    withAnimationVisible: boolean = false;
    MinMaxCalcType: TTVisual.ITTEnumComboBox = { DataTypeName: 'MinMaxCalcTypeEnum' };
    btnVademecum: TTVisual.ITTButton = { Text: i18n("M16306", "İlaç Bilgileri") };
    valueCountOfBarcode: string;

    public isZeroAmount: boolean = false;
    public inStockTransactions: Array<InStockTransactionDVO>;
    public selectedInStockTransaction: Array<InStockTransactionDVO> = new Array<InStockTransactionDVO>();
    public budgetTypeSources: Array<BudgetTypeSource> = new Array<BudgetTypeSource>();
    public outStockTransactions: Array<OutStockTransactionDVO>;
    public loadingVisible: boolean = false;
    public selectedMaterial: Array<any> = new Array<any>();
    public MaterialMultiSelectLabel: string = "Seçilen: 0";
    public MaterialMultiSelectButtonText: string = "Malzeme seçiniz";
    public selectedSubStores: Array<Store> = new Array<Store>();
    public selectedSubStore: Store;
    public searchExpDate: Array<SubStoreExpDateUpdate_Output> = new Array<SubStoreExpDateUpdate_Output>();
    public ExpDayLimit: number = 0;
    public accountingTermObjId: any;
    public defualtbudgetType: any;
    public activeAccountingTerm: any;

    public gridCalcValuesColumns = [
        {
            caption: i18n("M18545", "Malzeme"),
            dataField: 'MaterialName',
            allowEditing: false,
            width: 700
        },
        {
            caption: i18n("M12625", "Depo Mevcudu"),
            dataField: 'Inheld',
            allowEditing: false
        },
        {
            caption: i18n("M22502", "Belirlenen Minimum Seviye"),
            dataField: 'MinLevel',
            allowEditing: false
        },
        {
            caption: i18n("M22502", "Belirlenen Kritik Seviye"),
            dataField: 'CriticalLevel',
            allowEditing: false
        },
        {
            caption: i18n("M22501", "Belirlenen Maximum Seviye"),
            dataField: 'MaxLevel',
            allowEditing: false
        },
        {
            caption: i18n("M15757", "Hesaplanan Minimum Seviye"),
            dataField: 'CalcMinLevel'
        },
        {
            caption: i18n("M15757", "Hesaplanan Kritik Seviye"),
            dataField: 'CalcCriticalLevel',
        },
        {
            caption: i18n("M15756", "Hesaplanan Maximum Seviye"),
            dataField: 'CalcMaxLevel'
        },
        {
            caption: i18n("M23490", "Toplam Çıkış Miktarı"),
            dataField: 'OutAmount',
            allowEditing: false
        },
    ];

    public get MaterialPicture(): string {
        if (this.Model != null && this.Model.materialDetail != null && this.Model.materialDetail.length > 0
            && this.Model.materialDetail[0].materialPicture != null) {
            return 'data:image/jpeg;base64,' + this.Model.materialDetail[0].materialPicture;
        }
        // tslint:disable-next-line:max-line-length
        return 'data:image/jpeg;base64,iVBORw0KGgoAAAANSUhEUgAAAPoAAAC+CAIAAACTR4UQAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6NENFRkZCMDg5MTk0MTFFM0ExOEVBQzhBRENBQjg5NkIiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6NENFRkZCMDk5MTk0MTFFM0ExOEVBQzhBRENBQjg5NkIiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo0Q0VGRkIwNjkxOTQxMUUzQTE4RUFDOEFEQ0FCODk2QiIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDo0Q0VGRkIwNzkxOTQxMUUzQTE4RUFDOEFEQ0FCODk2QiIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PlZyjbMAACHoSURBVHja7J3ZcxvH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';
    }

    public get MaterialItem(): MaterialDetail {
        if (this.Model != null && this.Model.materialDetail != null && this.Model.materialDetail.length > 0) {
            return this.Model.materialDetail[0];
        }
        return null;
    }

    public labelSettings = {

        backgroundColor: undefined,
        border: { color: '#d3d3d3', dashStyle: 'solid', visible: false, width: 1 },
        connector: { color: undefined, visible: true },
        visible: true

    };

    // onInitialized(e: any) {
    //     let accordion: any = $(e.element).dxAccordion('instance');
    //     setTimeout(function () {
    //         accordion.collapseItem(0);
    //     }, 100);
    // }

    MaterialSelectBox: TTVisual.ITTValueListBox = {
        ListDefName: 'MaterialListDefinition_AutoFill',
        DataMember: 'Material'
    };

    MinMaxMaterialSelectBox: TTVisual.ITTValueListBox = {
        ListDefName: 'MaterialListDefinition_AutoFill',
        DataMember: 'MinMaxMaterial'
    };

    public StockTransactionGrid = [
        {
            caption: i18n("M10707", "Alınan Miktar"),
            dataField: 'Amount',
            width: 150,
            allowSorting: true
        },

        {
            caption: i18n("M11855", "Birim Fiyat"),
            dataField: 'UnitePrice',
            width: 150,
            allowSorting: true
        },
        {
            caption: i18n("M14801", "Giriş İşlemi Tarihi"),
            dataField: 'TransactionDate',
            width: 150,
            allowSorting: true
        }
    ];

    public StockDataInformationGrid = [
        {
            caption: 'Lot No:',
            dataField: 'LotNo',
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M22057", "Son Kullanma Tarihi"),
            dataField: 'ExpirationDate',
            width: 200,
            allowSorting: true
        },
        {
            caption: i18n("M19036", "Miktarı"),
            dataField: 'ResAmount',
            width: 150,
            allowSorting: true
        }
    ];


    public StockDataBudgetTypeGrid = [
        {

            caption: i18n("M12146", "Bütçe Türü"),
            dataField: 'BudgetType',
            width: 200


        },
        {
            caption: i18n("M19036", "Miktarı"),
            dataField: 'Amount',
            width: 150,
            allowSorting: true
        }];



    public StockDataLevelTypeGrid = [
        {

            caption: i18n("M18508", "Mal Durumu"),
            dataField: 'StockLevelType',
            width: 200,
            cellTemplate: 'enumCmbTemplate'

        },
        {
            caption: i18n("M19036", "Miktarı"),
            dataField: 'Amount',
            width: 150,
            allowSorting: true
        }];


    public WorkListColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            width: 50
        },
        {
            'caption': i18n("M16866", "İşlem No"),
            dataField: 'StockActionID',
            width: 100,
            allowSorting: true
        },
        {
            'caption': i18n("M17307", "Karşı Depo Adı"),
            dataField: 'DestinationStore',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16886", "İşlem Tarihi"),
            dataField: 'TransactionDate',
            width: 160,
            allowSorting: true
        },
        {
            'caption': i18n("M15101", "Haraket Tipi"),
            dataField: 'StockActionType',
            dataType: 'string',
            width: 300,
            allowSorting: true,
            cellTemplate: 'enumCmbTemplate'
        },
        {
            'caption': i18n("M15133", "Hasta Adı Soyadı"),
            dataField: 'PatientName',
            dataType: 'string',
            width: 300,
            allowSorting: true
        },
        {
            'caption': i18n("M19030", "Miktar"),
            dataField: 'Amount',
            width: 100,
            allowSorting: true
        },
        {
            'caption': i18n("M16818", "İşlem"),
            dataField: 'StockactionName',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16838", "İşlem Durumu"),
            dataField: 'StateName',
            dataType: 'string',
            width: 150,
            allowSorting: true
        }

    ];

    public SubStoreWaitingWorksColumns =
        [
            {
                caption: 'Rapor Görüntüle',
                dataField: 'ObjectID',
                cellTemplate: 'ReportButtonCellTemplate',
                width: 80
            },
            {
                'caption': "İşlem No",
                dataField: 'StockActionID',
                width: 100,
                allowSorting: true
            },
            {
                'caption': "Tarih",
                dataField: 'WorklistDate',
                dataType: "date",
                format: "shortDate",
                width: 100,
                allowSorting: true
            },
            {
                'caption': "Depo Adı",
                dataField: 'StoreName',
                dataType: 'string',
                //width: 'auto',
                allowSorting: true
            },
            {
                'caption':  "Karşı Depo Adı",
                dataField: 'DestinationStore',
                dataType: 'string',
                //width: 'auto',
                allowSorting: true
            },
            {
                'caption': "İşlem",
                dataField: 'ObjectName',
                dataType: 'string',
                //width:'auto',
                allowSorting: true
            },
            {
                'caption': "Durum",
                dataField: 'StateName',
                dataType: 'string',
                //width: 'auto',
                allowSorting: true
            }
        ];

    @ViewChild('menuAccordion') accordion: DxAccordionComponent;
    @ViewChild('materialDetayAccordion') materialAccordion: DxAccordionComponent;
    @ViewChild('materialLotDetayAccordion') materialLotAccordion: DxAccordionComponent;
    @ViewChild('materialActionDetayAccordion') materialActionDetayAccordion: DxAccordionComponent;
    @ViewChild('calculatedItemsGrid') calculatedItemsGrid: DxDataGridComponent;



    customizeTooltip(arg) {
        return { text: arg.argumentText + '<br> ' + arg.seriesName + ': ' + arg.valueText }; //+ "₺"
    }

    customizeLabel(arg) {
        return arg.valueText + ' (' + arg.percentText + ')';
    }

    toggleDefault() {
        this.defaultVisible = !this.defaultVisible;
    }

    toggleWithTemplate() {
        this.withTemplateVisible = !this.withTemplateVisible;
    }

    toggleWithAnimation() {
        this.withAnimationVisible = !this.withAnimationVisible;
    }

    async clientPreScript() {
        this.getRoleControlDashboard();
        this.selecttableStores = await UserHelper.UseUserResourcesStores;
        this.fillData();

        if (this.IsMainStoreFlag === true) {
            this.MaterialSelectBox.ReadOnly = false;
        } else {
            this.MaterialSelectBox.ReadOnly = true;
        }

        let selectedStore: any = this.selecttableStores.filter(x => x.ObjectID.toString() == this.Store);
        if (selectedStore.length > 0 && selectedStore[0].SubStoreMKYS != null) {
            this.startDate = new Date().AddDays(-5);
        }
        else {
            this.startDate = new Date().AddDays(-60);
            this.StokLevelAllProduct = false;
        }



        this.endDate = new Date();
    }

    async getRoleControlDashboard() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/GetRoleControlDashboard';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <LogisticDashboardViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.hasRoleDashboardCostAction = that.Model.hasRoleDashboardCostAction;
                    that.hasRoleDashboardMaterialStatus = that.Model.hasRoleDashboardMaterialStatus;
                    that.hasRoleDashboardMinMax = that.Model.hasRoleDashboardMinMax;
                    that.hasRoleSubStoreExpDateUpdate = that.Model.hasRoleSubStoreExpDateUpdate;
                    that.hasRoleSubStoreWaitingWorks = that.Model.hasRoleSubStoreWaitingWorks;
                    that.budgetTypeSources = that.Model.budgetTypeSources;
                    that.defualtbudgetType = that.Model.defaultBudgetType;
                    that.btnOpenNewAccountingTermDisable = that.Model.hasRoleOpenCloseTerm;
                    that.budgetTypeObjID = that.Model.defaultBudgetType.objectID;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


    clientPostScript(state: String) {

    }
    SelectMinMaxMaterialBoxChange($event) { }


    private async fillData() {
        if (this.selecttableStores.length === 1) {
            this.Store = this.selecttableStores[0].ObjectID.toString();
            this.doSearch();
        }
    }

    MaterialListDefinition_MinMax: any;
    private fillMaterialList() {
        /*this.http.get<any>('api/LogisticDashboard/GetMaterialListDefinition').then((result: any) => {
            this.MaterialListDefinition_MinMax = result;
        });*/
    }

    Store: string;
    SelectBoxChange(data: any) {

        if (data != null && data.itemData != null) {
            this.SelectedMainStore = data.itemData;
        }

    }

    private _SelectedMainStore: any;
    @Input() set SelectedMainStore(value: any) {

        this._SelectedMainStore = value;

        this.refreshOnSelectedMainStoreValueChanged();
        if (this._SelectedMainStore) {
            this.updateWithSelectedMainStore(this._SelectedMainStore.ObjectID.toString());
        }

    }
    get SelectedMainStore(): any {
        return this._SelectedMainStore;
    }

    private refreshOnSelectedMainStoreValueChanged() {
        this.girisInfos = Array<any>();
        this.cikisInfos = Array<any>();
        this.cikisInfosDetail = Array<any>();
        this.girisInfosDetail = Array<any>();
        this.accountingTermObjId = Array<any>();
        this.costActionAccountingTerm = Array<any>();
        this.StockdataInformation = Array<any>();
        this.StockdataLevelType = Array<any>();
        this.StockBudgetType = Array<any>();
        this.MaterialInheldMaxMin = Array<any>();

    }

    private updateWithSelectedMainStore(selectedMainStoreObjectID: string) {

        this.Store = selectedMainStoreObjectID;
        this.doSearchaccountingTerm(selectedMainStoreObjectID);
        this.SelectBoxDataSource = this.Model.costActionSelectBox;
        this.Model.Material = null;
        this.MaterialSelectBox.ListFilterExpression = ' STOCKS.STORE = \'' + selectedMainStoreObjectID + '\'';
        this.MinMaxMaterialSelectBox.ListFilterExpression = ' STOCKS.STORE = \'' + selectedMainStoreObjectID + '\'';
    }
    selectedMaterialForStore: Array<any> = new Array<any>();
    SelectMaterialBoxChange(data: any) {

        this.girisInfosDetail = Array<any>();
        this.cikisInfosDetail = Array<any>();
        this.Model.Material = data;
        if (this.Model.Material != null) {
            this.doSearch();
            this.btnMaterialBarcodeDisable = false;
        }
        if (data != null) {
            this.DrugObjId = data;
        }
        this.showMaterialMultiSelectFormForStore = false;
    }


    selectMonthsObj: any;
    selectMonths(data: any) {
        if (data.selectedItem != null) {
            this.selectMonthsObj = data.selectedItem.Objetid;

            this.selectMonth = true;

            if (this.selectMonthsObj !== '') {
                this.doSearch();
            }

        }
    }

    selectedMinMaxCalType(data: any) {
        if (data != null) {
            this.selectedMinMaxCalc = data;
        }
    }
    private showMaterialMultiSelectForm: boolean = false;
    store: any;
    OpenMaterialMultiSelectComponent() {
        this.store = this.activeUserService.SelectedUserStore.ObjectID;
        this.showMaterialMultiSelectForm = true;

    }
    private showMaterialMultiSelectFormForStore: boolean = false;
    OpenMaterialMultiSelectComponentForStore() {
        this.store = this.activeUserService.SelectedUserStore.ObjectID;
        this.showMaterialMultiSelectFormForStore = true;

    }

    //public selectedChangeOnActiveIngredient() {
    //    this.SelectedMaterialName = "";
    //    for (let sm of this.selectedMaterial) {

    //        this.SelectedMaterialName += sm.Name + "    ";
    //    }        
    //    this.showMaterialMultiSelectForm = false;
    //}


    public StokLevelAllProduct: boolean = true;
    public StockHasInheld: boolean = true;

    CalculateClick() {

        let inputDvo = new CalcMinMaxValueDVO();
        //  inputDvo.selectedType = this.selectedMinMaxCalc;
        inputDvo.id = this.Store;
        inputDvo.StartDate = this.startDate;
        inputDvo.EndDate = this.endDate;
        if (this.selectedMaterial != null) {
            if (this.selectedMaterial.length > 0) {
                for (let sm of this.selectedMaterial) {
                    //inputDvo.materialObjectID.push(sm.ObjectID);
                    inputDvo.materialObjectID.push(sm.ObjectID);
                }
                this.StokLevelAllProduct = false;
                this.StockHasInheld = false;
                inputDvo.AllProducts = this.StokLevelAllProduct;
            }
            else {
                inputDvo.materialObjectID.push(this.Model.MinMaxMaterial);
            }
        }
        inputDvo.AllProducts = this.StokLevelAllProduct;
        inputDvo.StockHasInheld = this.StockHasInheld;
        // inputDvo.materialObjectID = this.Model.MinMaxMaterial;
        let that = this;
        let fullApiUrl = 'api/LogisticDashboard/CalcMinMaxValue';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <Array<MinMaxCalculetedItem>>res;
                this.CalculetedItems = result;
                this.filteredCriticalStockLevelOfItems = this.CalculetedItems;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });


    }


    calcValueChangedItems: Array<MinMaxCalculetedItem> = new Array<MinMaxCalculetedItem>();

    onCellPrepared(e: any) {
        // if (e.key != null && !e.cellElement.hasClass("dx-cell-modified") && this.calcValueChangedItems.find(x => x.StockObjectID == e.key.StockObjectID) != null && (e.column.dataField == 'CalcCriticalLevel' || e.column.dataField == 'CalcMinLevel' || e.column.dataField == 'CalcMaxLevel')) {
        //     e.cellElement.css("background-color", "lightgreen");
        // }
    }

    onGrdCalculateStocktRowUpdating(event: any) {
        if (this.calcValueChangedItems != null && this.calcValueChangedItems.find(x => x.StockObjectID == event.key.StockObjectID) == null) {
            if (event.newData.CalcCriticalLevel != null)
                event.key.CalcCriticalLevel = event.newData.CalcCriticalLevel;
            else if (event.newData.CalcMinLevel != null)
                event.key.CalcMinLevel = event.newData.CalcMinLevel;
            else if (event.newData.CalcMaxLevel != null)
                event.key.CalcMaxLevel = event.newData.CalcMaxLevel;

            this.calcValueChangedItems.push(event.key);
        }
        else {
            if (event.newData.CalcCriticalLevel != null)
                this.calcValueChangedItems.find(x => x.StockObjectID == event.key.StockObjectID).CalcCriticalLevel = event.newData.CalcCriticalLevel;
            else if (event.newData.CalcMinLevel != null)
                this.calcValueChangedItems.find(x => x.StockObjectID == event.key.StockObjectID).CalcMinLevel = event.newData.CalcMinLevel;
            else if (event.newData.CalcMaxLevel != null)
                this.calcValueChangedItems.find(x => x.StockObjectID == event.key.StockObjectID).CalcMaxLevel = event.newData.CalcMaxLevel;

        }
        for (var dataField in event.newData) {
            var $cell = event.component.getCellElement(event.component.getRowIndexByKey(event.key), dataField);
            $cell && $cell.css("background-color", "lightgreen");
        }
    }

    async UpdateClick() {
        if (this.calcValueChangedItems != undefined) {
            let result: string = await ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V", i18n("M23735", "Uyarı"),
                "Stok Seviye Belirleme", this.calcValueChangedItems.length + " Kalem Malzemenin Seviyeleri Güncellenecektir." + "\r\n" + i18n("M12687", "Devam Etmek İstiyor Musunuz?"));
            if (result == "T") {
                this.loadingVisible = true;

                this.calculatedItemsGrid.instance.closeEditCell();
                this.calculatedItemsGrid.instance.saveEditData();
                let inputDvo = new UpdateMinMaxValueDVO();
                // if (this.calcValueChangedItems != null && this.calcValueChangedItems.length > 0)
                inputDvo.MinMaxCalculetedItems = this.calcValueChangedItems;
                // else
                //inputDvo.MinMaxCalculetedItems = this.CalculetedItems;

                let that = this;
                let fullApiUrl = 'api/LogisticDashboard/UpdateMinMaxValue';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res) => {
                        let result = <string>res;
                        this.CalculateClick();
                        this.loadingVisible = false;
                        TTVisual.InfoBox.Alert(result, MessageIconEnum.ErrorMessage);
                    })
                    .catch(error => {
                        this.loadingVisible = false;
                        TTVisual.InfoBox.Alert(error);
                    });
            }
        }
        else {
            TTVisual.InfoBox.Alert("Güncellemek için listeden malzeme seçiniz.");
        }
    }

    customizeFormat(data) {
        return data + '₺';
    }

    public selectedMaterialsText: string = "";
    async MaterialsSelected(event) {
        this.selectedMaterial = event;
        //this.MaterialMultiSelectLabel = "Seçilen: " + (this.selectedMaterial != null ? this.selectedMaterial.length : 0).toString();
        if (this.selectedMaterial != null) {
            if (this.selectedMaterial.length === 0) {
                this.MaterialMultiSelectButtonText = "Malzeme seçiniz";
            }
            if (this.selectedMaterial.length > 0) {
                this.MaterialMultiSelectButtonText = "Seçilen Malzeme: " + this.selectedMaterial.length.toString();
            }
        }
        this.showMaterialMultiSelectForm = false;
        this.showSubStoreMaterialMultiSelectForm = false;
    }

    async MaterialsCleared() {
        this.selectedMaterial = [];
        this.MaterialMultiSelectButtonText = "Malzeme seçiniz";
        //this.MaterialMultiSelectLabel = "Seçilen: 0";
        //this.showMaterialMultiSelectForm = false;
        //this.showSubStoreMaterialMultiSelectForm = false;
    }

    selectMaterial(data: any) {
        this.architectureInfoList = this.architectureInfoListShow;
        if (data.selectedRowKeys.length >= 1) {
            let excludeList: Array<any> = new Array<any>();
            let itemsMap: any = {};
            let seriesCheck: any = {};
            this.architectureInfoSeries = [];

            if (data.selectedRowKeys != null) {
                for (let i = 0; (i < data.selectedRowKeys.length); i++) {
                    let material = data.selectedRowKeys[i].Material;
                    for (let mc of this.architectureInfoList) {
                        if (mc.ObjId.toUpperCase().includes(material.toUpperCase())) {
                            let uniqueKey = material + '_' + mc.yearKey;
                            itemsMap[uniqueKey] = mc.cluster;
                            if (seriesCheck.hasOwnProperty(material) === false) {
                                let serieItem: any = {};
                                serieItem.valueField = material;
                                serieItem.name = mc.MaterialName;
                                seriesCheck[material] = material;
                                this.architectureInfoSeries.push(serieItem);
                            }
                        }
                    }
                }

                let itemlist: any = {};
                let checkList = new Set<string>();
                for (let itemKey of Object.keys(itemsMap)) {
                    let cluster = itemsMap[itemKey];
                    let keys = itemKey.split('_');
                    let mat = keys[0];
                    let monthKey = keys[1];
                    let targetItem = checkList.has(monthKey) ? itemlist[monthKey] : {};
                    targetItem[mat] = cluster;
                    if (checkList.has(monthKey) === false) {
                        targetItem.month = monthKey;
                        checkList.add(monthKey);
                        itemlist[monthKey] = targetItem;
                    }
                }

                for (let itemKey of Object.keys(itemlist)) {
                    let obj = itemlist[itemKey];
                    excludeList.push(obj);
                }
            }

            this.architectureInfoList = excludeList;
        }
    }

    // selectedCalculetedItem(data: any) {
    //     this.UpdateCalculetedItems = data.selectedRowsData;
    // }

    get ArchitectureInfoList(): Array<string> {
        let keys: Array<string> = new Array<string>();
        for (let key of this.architectureInfoList) {
            keys.push(key);
        }
        return keys;
    }

    selectPieChartInStock(data: any) {
        for (let i = 0; (i < this.Model.stockGiris.length); i++) {
            if (data.target.argument === this.Model.stockGiris[i].Description) {
                let selectList = this.Model.stockGiris[i].stockGirisDetayList;
                this.girisInfosDetail = selectList;
                let html: HTMLElement = document.getElementById('girisDetayLabel');
                html.textContent = data.target.argument;
            }
        }
    }
    selectPieChartOutStock(data: any) {
        for (let i = 0; (i < this.Model.stockCikis.length); i++) {
            if (data.target.argument === this.Model.stockCikis[i].Description) {
                let selectList = this.Model.stockCikis[i].stockCikisDetayList;
                this.cikisInfosDetail = selectList;
                let html: HTMLElement = document.getElementById('cikisDetayLabel');
                html.textContent = data.target.argument;
            }
        }
    }

    selectAccountingTerm(data: any) {

        this.architectureInfoList = new Array<any>();
        this.costActionGridMateril = new Array<any>();
        //this.Model.Material = null;

        this.accountingTermObjId = data.selectedItem.ObjId;
        if (this.IsMainStoreFlag === true) {
            this.MaterialSelectBox.ReadOnly = false;
        } else {
            this.MaterialSelectBox.ReadOnly = true;
        }
        this.doSearch();
        this.doSearchMoth();
    }

    budgetTypeObjID: any;
    selectBudgetType(data: any) {
        this.budgetTypeObjID = data.selectedItem.objectID;
    }

    private showStockAction(data: string): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DashboardActionComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = data;

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
        this.showStockAction(value.data.ObjectID);
    }


    async btnOpenNewAccountingTerm() {
        this.OpenNewAccountingTerm(null);
    }

    public OpenNewAccountingTerm(e: any) {
        this.http.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetNewObjectDynamicComponentInfo?ObjectDefName=TERMOPENCLOSEACTION',
            DynamicComponentInfoDVO).then((result: DynamicComponentInfoDVO) => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModuleName = result.ModuleName;
                compInfo.ModulePath = result.ModulePath;
                this.componentInfo = compInfo;
                compInfo.InputParam = this.activeUserService.SelectedUserStore;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = 'Yeni Dönem Açma';
                modalInfo.Width = 1200;
                modalInfo.Height = 800;
                return new Promise((resolve, reject) => {
                    let resultModel = this.modalService.create(compInfo, modalInfo);
                    resultModel.then(inner => {
                        resolve(inner);
                    }).catch(err => {
                        reject(err);
                    });
                });
            });
    }



    async btnVademecumClick(): Promise<void> {
        if (this.DrugObjId != null) {
            let drug: any = await this.objectContextService.getObject(new Guid(this.DrugObjId), DrugDefinition.ObjectDefID);
            if (drug != null) {
                if ((<DrugDefinition>drug).VademecumProductID != null) {
                    let drugId: string = (<DrugDefinition>drug).VademecumProductID.toString();
                    this.showDrugInfo(drugId);
                } else {
                    ServiceLocator.MessageService.showError(i18n("M21533", "Seçilen malzemenin Vademecum sistem ID\'si bulunamamıştır!"));
                }
            } else {
                TTVisual.InfoBox.Alert(i18n("M21521", "Seçilen İlaç ile ilgili sistemde veri bulunamadı!"), MessageIconEnum.ErrorMessage);
            }

        } else {
            TTVisual.InfoBox.Alert(i18n("M19995", "Önce ilaç seçmelisiniz."), MessageIconEnum.ErrorMessage);
        }
    }

    barcodeAmountKeyPress(event: KeyboardEvent) {
        if (event.charCode === 44)
            event.preventDefault();
        if (event.charCode === 46)
            event.preventDefault();
        if (isNaN(parseInt(event.key)))
            event.preventDefault();
    }

    expirationDates: Array<Date>;
    async btnMaterialBarcode(): Promise<void> {
        if (this.valueCountOfBarcode !== null) {
            if (this.Model.Material != null) {
                let multiSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
                for (let det of this.Model.materialDetail) {
                    for (let info of (<MaterialDetail>det).StockDataInformation) {
                        let datePipe = new DatePipe("en-US");
                        multiSelectForm.AddMSItem("SKT : " + datePipe.transform(info.ExpirationDate, "dd/MM/yyyy").toString(), info.ExpirationDate.toString());
                    }
                }
                let mlotKey: string = await multiSelectForm.GetMSItem(null, i18n("M22057", "Son Kullanma Tarihi"), true);
                if (multiSelectForm.MSSelectedItem !== null) {
                    let selectDate = multiSelectForm.MSSelectedItem;
                    let numberOfBarcode: number = parseInt(this.valueCountOfBarcode);
                    let datePipe = new DatePipe("en-US"); //TODO TSLINT datePipe object not found at line 858?
                    for (let i = 0; i < numberOfBarcode; i++) {
                        for (let det of this.Model.materialDetail) {
                            let infoBarcode: DrugStickerInfo = new DrugStickerInfo;
                            infoBarcode.DrugName = (<MaterialDetail>det).materialName;
                            infoBarcode.ExpireDate = datePipe.transform(selectDate, "dd.MM.yyyy").toString();
                            infoBarcode.BarcodeCode = (<MaterialDetail>det).barcode;
                            infoBarcode.HospitalName = (await SystemParameterService.GetParameterValue("HOSPITALSHORTNAME", "GAZİLER FTR EĞİTİM ARŞ.HST"));
                            console.log(infoBarcode);
                            this.barcodePrintService.printAllBarcode(infoBarcode, "generateDrugSticker", "printDrugSticker");
                        }
                    }
                }
            } else {
                TTVisual.InfoBox.Alert(i18n("M19997", "Önce Malzeme seçmelisiniz."), MessageIconEnum.ErrorMessage);
            }
        } else {
            TTVisual.InfoBox.Alert(i18n("M11528", "Barkod Adetini seçiniz."), MessageIconEnum.ErrorMessage);
        }
    }

    private showDrugInfo(productID: string): Promise<DialogResult> {
        return new Promise<DialogResult>((resolve, reject) => {
            let inputDvo = new VademecumProductDVO();
            inputDvo.id = productID;
            let that = this;
            let fullApiUrl: string = 'api/LogisticDashboard/GetVademecumProductByID';
            let result: any;
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    result = <any>res;
                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'DrugInfoComponent';
                    componentInfo.ModuleName = 'LogisticFormsModule';
                    componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                    componentInfo.InputParam = result;

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = 'UYARI';
                    modalInfo.Width = 1200;
                    modalInfo.Height = 800;

                    let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                    let result2 = modalService.create(componentInfo, modalInfo);
                    result2.then(res2 => {
                        resolve(res2.Result);
                    });
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        });
    }

    doSearch() {
        let inputDvo = new QueryInputDVO();
        inputDvo.Store = this.Store;
        inputDvo.Material = this.Model.Material;
        inputDvo.selectMonth = this.selectMonth;
        inputDvo.ObjId = this.selectMonthsObj;
        if (this.costActionAccountingTerm.length > 0) {
            inputDvo.accountingTermObjId = this.accountingTermObjId;
        }

        let that = this;
        let fullApiUrl = 'api/LogisticDashboard/Query';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <LogisticDashboardViewModel>res;
                that.Model = result;
                if (that.Model && that.Model.stockGiris) {
                    that.girisInfos = that.Model.stockGiris;
                } else {
                    that.girisInfos = new Array<any>();
                }
                if (that.Model && that.Model.stockCikis) {
                    that.cikisInfos = that.Model.stockCikis;
                } else {
                    that.cikisInfos = new Array<any>();
                }
                if (that.Model && that.Model.stockactionlist) {
                    that.workListItems = that.Model.stockactionlist;
                } else {
                    that.workListItems = new Array<any>();
                }
                if (that.Model && that.Model.materialDetail) {
                    that.StockdataInformation = that.Model.materialDetail[0].StockDataInformation;
                    that.StockdataLevelType = that.Model.materialDetail[0].StockDataLevelType;
                } else {
                    that.StockdataInformation = new Array<any>();
                    that.StockdataLevelType = new Array<any>();
                }
                if (that.Model && that.Model.materialDetail) {
                    that.MaterialInheldMaxMin = that.Model.materialDetail[0].MaterialInheldMaxMin[0];
                } else {
                    that.MaterialInheldMaxMin = new Array<any>();
                }
                if (that.Model && that.Model.materialDetail) {
                    that.StockBudgetType = that.Model.materialDetail[0].StockBudgetType;
                } else {
                    that.StockBudgetType = new Array<any>();
                }
                if (that.Model.stockGiris != null && that.Model.stockGiris.length > 0 && that.Model.stockCikis != null && that.Model.stockCikis.length > 0) {
                    that.girisInfosDetail = that.Model.stockGiris[0].stockGirisDetayList;
                    that.cikisInfosDetail = that.Model.stockCikis[0].stockCikisDetayList;
                }
                if (that.Model && that.Model.dashboardGridItemModel) {
                    that.costActionGridMateril = that.Model.dashboardGridItemModel;
                } else {
                    that.costActionGridMateril = new Array<any>();
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    openChart() {

        let inputParam: TransactionChartInputDTO = new TransactionChartInputDTO();
        inputParam.StockInList = this.Model.stockGiris;
        inputParam.StockOutList = this.Model.stockCikis;
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

    doSearchMoth() {
        let inputDvo = new QueryInputDVO();
        inputDvo.accountingTermObjId = this.accountingTermObjId;
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/Query2';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <LogisticDashboardViewModel>res;
                this.Model.architectureInfo = result.architectureInfo;
                this.Model.costActionSelectBox = result.costActionSelectBox;
                if (that.Model && that.Model.architectureInfo) {
                    this.architectureInfoListShow = that.Model.architectureInfo;
                } else {
                    this.architectureInfoListShow = new Array<any>();
                }
                if (that.Model && that.Model.costActionSelectBox) {
                    that.SelectBoxDataSource = that.Model.costActionSelectBox;
                } else {
                    that.SelectBoxDataSource = new Array<any>();
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


    doSearchaccountingTerm(Store: string) {

        let inputDvo = new QueryInputDVO();
        inputDvo.Store = Store;
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/Query3';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <LogisticDashboardViewModel>res;
                that.Model = result;
                if (that.Model && that.Model.costActionAccountingTerm) {
                    that.costActionAccountingTerm = that.Model.costActionAccountingTerm;
                    that.accountingTermObjId = that.Model.activeCostActionAccountingTerm != null ? that.Model.activeCostActionAccountingTerm.ObjId.toString() : "";
                    that.activeAccountingTerm = that.Model.activeCostActionAccountingTerm;
                } else {
                    that.costActionAccountingTerm = new Array<any>();
                }
                that.IsMainStoreFlag = that.Model.IsMainStoreFlag;
                this.architectureInfoList = new Array<any>();
                this.costActionGridMateril = new Array<any>();
                if (that.IsMainStoreFlag === true) {
                    that.MaterialSelectBox.ReadOnly = false;
                } else {
                    that.MaterialSelectBox.ReadOnly = true;
                }
                this.doSearch();
                this.doSearchMoth();

            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });

    }

    GetVProductByID() {
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/GetVademecumProductByID';
        let result: any;
        this.http.post(fullApiUrl, null)
            .then((res) => {
                result = <LogisticDashboardViewModel>res;
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'DrugInfoComponent';
                componentInfo.ModuleName = 'LogisticFormsModule';
                componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                componentInfo.InputParam = result;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = 'UYARI';
                modalInfo.Width = 1200;
                modalInfo.Height = 800;

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
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    doVademecumGetData() {
        let inputDvo = new QueryVademecumInteractionDVO();
        inputDvo.prdList = this.prdList;
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/QueryVademecum';
        let result: any;
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                result = <LogisticDashboardViewModel>res;
                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'DrugInteractionComponent';
                componentInfo.ModuleName = 'LogisticFormsModule';
                componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                componentInfo.InputParam = result;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = 'UYARI';
                modalInfo.Width = 1200;
                modalInfo.Height = 800;

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
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    getInStockTransactions() {
        let inputDvo = new InStockTransactionInput();
        inputDvo.store = this.Store;
        if (this.selectedMaterial != null)
            if (this.selectedMaterial.length > 0) {
                for (let sm of this.selectedMaterial) {
                    inputDvo.materials.push(sm.ObjectID.toString());
                }
            }

        inputDvo.isZeroAmount = this.isZeroAmount;
        inputDvo.budgetTypeObjId = this.budgetTypeObjID;

        if (this.budgetTypeObjID == null) {
            TTVisual.InfoBox.Alert('Bütçe Tipi seçmediniz.');
            return;
        }

        if (this.accountingTermObjId.length > 0) {
            inputDvo.accountingTermObjId = this.accountingTermObjId;
        }

        if (this.accountingTermObjId.length === 0) {
            TTVisual.InfoBox.Alert('Hesap Dönemi seçmediniz.');
            return;
        }


        this.inStockTransactions = new Array<InStockTransactionDVO>();
        this.outStockTransactions = new Array<OutStockTransactionDVO>();
        let that = this;
        let fullApiUrl = 'api/LogisticDashboard/GetInStockTransactions';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = res as Array<InStockTransactionDVO>;
                that.inStockTransactions = result;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    openDocumentRecordLogs() {


        setTimeout(() => {
            this.showDocumentRecordLog();
        }, 1000);
    }

    

    private showDocumentRecordLog(): Promise<ModalActionResult> {

        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'DocumentRecordLogComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = that.Store;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'TİF Hareket Dökümü';
            modalInfo.Width = 1200;
            modalInfo.Height = 800;


            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    openCalculatePrice() {
        setTimeout(() => {
            this.showCalculatePrice();
        }, 1000);
    }



    private showCalculatePrice(): Promise<ModalActionResult> {

        let that = this;
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'InOutRemainingComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = that.Store;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Giriş-Çıkış-Kalan Toplam Tutar ve Miktarı Dökümü';
            modalInfo.Width = 1200;
            modalInfo.Height = 300;


            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    selectInStockTransaction(value: any) {
        this.loadingVisible = true;
        if (value.data.stockTransactionObjectID != null) {
            let inputDvo = new OutStockTransactionInput();
            inputDvo.inStockTransactionListID = value.data.stockTransactionListObjectID;
            if (this.costActionAccountingTerm.length > 0) {
                inputDvo.accountingTermObjId = this.accountingTermObjId;
            }
            this.outStockTransactions = new Array<OutStockTransactionDVO>();
            let that = this;
            let fullApiUrl = 'api/LogisticDashboard/GetOutStockTransactions';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = res as Array<OutStockTransactionDVO>;
                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'OutTransactionModalComponent';
                    componentInfo.ModuleName = 'LogisticFormsModule';
                    componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
                    componentInfo.InputParam = result;

                    let modalInfo: ModalInfo = new ModalInfo();
                    modalInfo.Title = 'ÇIKIŞLAR';
                    modalInfo.Width = 1200;
                    modalInfo.Height = 800;

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
                    that.loadingVisible = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    that.loadingVisible = false;
                });
        }
    }
    public async onSelectionChanged(event: any) {
        if (event.removedItems.length > 0) {
            if (event.removedItems[0].title === "Depo Mevcudu") {
                if (this.loadingVisible == true)
                    this.loadingVisible = false;
            }
        }
        if (event.addedItems.length > 0) {
            if (event.addedItems[0].title === "Cep Depo Son Kullanma Tarihi Güncelleme") {
                if (this.selectedSubStores.length === 0)
                    this.selectedSubStores = await UserHelper.UserUsableSubStores;
            }
        }
    }

    private showSubStoreMaterialMultiSelectForm: boolean = false;
    OpenSubStoreMaterialMultiSelectComponent() {
        if (this.selectedSubStore != null) {
            this.store = this.selectedSubStore;
            this.showSubStoreMaterialMultiSelectForm = true;
        } else {
            TTVisual.InfoBox.Alert("Depo seçmelisiniz.");
        }
    }

    CloseMaterialSelect() {
        this.showSubStoreMaterialMultiSelectForm = false;
    }

    public SearchExpDateClick() {

        if (this.ExpDayLimit != null) {

            if (this.selectedSubStore != null) {
                let inputDvo: SubStoreExpDateUpdate_Input = new SubStoreExpDateUpdate_Input();
                inputDvo.store = this.selectedSubStore.toString();
                inputDvo.beforeDay = this.ExpDayLimit;
                inputDvo.materials = new Array<string>();
                if (this.selectedMaterial != null)
                    if (this.selectedMaterial.length > 0) {
                        for (let sm of this.selectedMaterial) {
                            inputDvo.materials.push(sm.ObjectID.toString());
                        }
                    }
                let that = this;
                let fullApiUrl = 'api/LogisticDashboard/SearchExpDate';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res) => {
                        let result = <Array<SubStoreExpDateUpdate_Output>>res;
                        that.searchExpDate = result;
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                    });
            } else {
                TTVisual.InfoBox.Alert("Depo seçmelisiniz.");
            }
        } else {
            TTVisual.InfoBox.Alert("Gün kriteri boş geçilemez.");
        }
    }

    public UpdateExpDateClick() {
        let updateExpList: Array<SubStoreExpDateUpdate_Output> = this.searchExpDate.filter(x => x.newExpDate != null);
        if (updateExpList.length > 0) {
            let fullApiUrl = 'api/LogisticDashboard/UpdateExpDate';
            this.http.post(fullApiUrl, updateExpList)
                .then((res) => {
                    let result = <string>res;
                    TTVisual.InfoBox.Alert(result);
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        } else {
            TTVisual.InfoBox.Alert("Hiç Güncelleme yapmadınız.");
        }
    }

    public AllReport: boolean = false;
    public getAllReport(event): void {
        if (event.value === true) {
            this.AllReport = true;
        }
        else {
            this.AllReport = false;
        }
    }

    SubStoreWorklist: Array<SubStoreWorksOutputDVO> = new Array<SubStoreWorksOutputDVO>();
    public SubStoreWorklistSearch() {
        let inputDvo = new SubStoreWorksInputDVO();
        inputDvo.StartDate = this.startDate;
        inputDvo.EndDate = this.endDate;
        inputDvo.Store = this.Store;
        if (this.AllReport == true) {
            inputDvo.AllReport = 1;
        }
        else {
            inputDvo.AllReport = 0;
        }
        let fullApiUrl = 'api/LogisticDashboard/getSubStoreWaitingWorks';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                this.SubStoreWorklist = res as Array<SubStoreWorksOutputDVO>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    public prepareDocument_Click(event: any) {
        const objectIdParam = new GuidParam(event.key.ObjectID.toString());
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('DistributionReturningDocumentReport', reportParameters);
    }

    public CriticalStockLevelTypeItems = CriticalStockLevelTypeEnum.Items;
    public filteredCriticalStockLevelOfItems: Array<MinMaxCalculetedItem>;


    public onStockLevelTypeChanged(event: any) {
        if (event != null && event.value != null) {
            switch (event.value) {
                case CriticalStockLevelTypeEnum.GetStockLevelUnderMin:
                    this.filteredCriticalStockLevelOfItems = this.CalculetedItems.filter(x => x.Inheld < x.MinLevel);
                    break;
                case CriticalStockLevelTypeEnum.GetStockLevelOverCritical:
                    this.filteredCriticalStockLevelOfItems = this.CalculetedItems.filter(x => x.Inheld > x.CriticalLevel);
                    break;
                case CriticalStockLevelTypeEnum.GetStockLevelUnderCritical:
                    this.filteredCriticalStockLevelOfItems = this.CalculetedItems.filter(x => x.Inheld < x.CriticalLevel);
                    break;
                case CriticalStockLevelTypeEnum.GetStockLevelOverMax:
                    this.filteredCriticalStockLevelOfItems = this.CalculetedItems.filter(x => x.Inheld > x.MaxLevel);
                    break;
            }
        }
        else {
            this.filteredCriticalStockLevelOfItems = this.CalculetedItems;
        }
    }
}