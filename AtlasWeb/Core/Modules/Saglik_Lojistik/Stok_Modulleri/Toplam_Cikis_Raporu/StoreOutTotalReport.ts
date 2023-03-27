import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { StockActionService, InOutRemainingDTO, BudgetTypeDefDVO, StockTransactionDefDTO } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

import { UserHelper } from 'app/Helper/UserHelper';
import { Store, DrugSpecificationEnum, StockTransactionDefinition } from 'app/NebulaClient/Model/AtlasClientModel';
import { StoreOutTotalInputDTO, StoreOutTotalOutputDTO } from './StoreOutTotalReportViewModel';
import { DxDropDownBoxComponent } from 'devextreme-angular';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';

@Component({
    selector: "StoreOutTotalReport",
    templateUrl: './StoreOutTotalReport.html',
    providers: [SystemApiService, MessageService]
})

export class StoreOutTotalReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows: number;
    selectedMaterialItem: any = {};
    public budgetTypeSources: Array<BudgetTypeDefDVO> = new Array<BudgetTypeDefDVO>();
    public inOutRemainingDTO: InOutRemainingDTO;
    public budgetTypeObjectID: Guid;
    public stockOutDataSource: Array<StoreOutTotalOutputDTO> = new Array<StoreOutTotalOutputDTO>();
    public StoreList: Array<Store>;
    public selectedStores: Array<Store> = new Array<Store>();
    public StartDate: Date;
    public EndDate: Date;
    public DrugSpecificationEnumDef: Array<EnumItem> = new Array<EnumItem>();
    public StockTransactionDefList: Array<StockTransactionDefDTO> = new Array<StockTransactionDefDTO>();
    public selectedSpecificationList: Array<number> = new Array<number>();
    public selectedStockTransactionDefValue: Array<Guid> = new Array<Guid>();
    @ViewChild('materialDrop') materialDrop: DxDropDownBoxComponent;
    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this._StoreObjectId = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this._StoreObjectId;
    }

    constructor(protected httpService: NeHttpService, private reportService: AtlasReportService, protected messageService: MessageService, public systemApiService: SystemApiService, private modalService: IModalService) {
        this.initViewModel();
    }

    async initViewModel() {
        this.inOutRemainingDTO = await StockActionService.GetInoutRemainingInitDVO();
        this.budgetTypeSources = this.inOutRemainingDTO.budgetTypeDefinitions;
        this.StockTransactionDefList = this.inOutRemainingDTO.stockTransactionDefList;
        this.StoreList = await UserHelper.UseFirstUserResourcesStores;
        this.selectedStores.push(this.StoreList.find(x => x.ObjectID.toString() == this._StoreObjectId));
        this.setDefaultDates();
        this.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
    }
    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }


    async ngOnInit() {

    }



    selectBudgetType(data: any) {
        this.budgetTypeObjectID = data.selectedItem.objectID;
    }

    openMaterialDropDown() {
        this.getMaterialDataSource();
    }

    public onClearMaterial(event: any) {
        if (event != null && event.value != null) {

        }
        else {
            this.selectedMaterialItem = {};
        }
    }

    storeOutColumn = [
        {
            caption: 'Taşınır Kodu',
            dataField: 'StockCardNo',
            allowEditing: false,
        },
        {
            caption: 'Barkodu',
            dataField: 'Barcode',
            allowEditing: false,
        },
        {
            caption: 'Malzeme Adı',
            dataField: 'MaterialName',
            allowEditing: false,
            sortOrder: "asc"
        },
        {
            caption: 'Dağıtım Şekli',
            dataField: 'DistributionType',
            allowEditing: false,
        },

        {
            caption: 'Miktar',
            dataField: 'Amount',
            allowEditing: false,
        },
        {
            caption: 'Birim Fiyatı',
            dataField: 'UnitePrice',
            allowEditing: false,
        },
        {
            caption: 'Toplam Fiyatı',
            dataField: 'TotalPrice',
            allowEditing: false,
        },
        {
            caption: 'Bütçe Türü',
            dataField: 'BudgetTypeName',
            allowEditing: false,
        },
        {
            caption: 'İşlem Türü',
            dataField: 'StocktransactionDefName',
            allowEditing: false,
        },
        {
            caption: 'Depo',
            dataField: 'StoreName',
            allowEditing: false,
            groupIndex: '0'

        },
    ];

    materialDataSource: DataSource;
    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'MaterialList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/StoreOutTotalReportService/GetMaterialList', loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectMaterial(e) {
        var component = e.component;
        component.lastClickTime = new Date();
        this.selectedMaterialItem = e.data;
        this.materialDrop.instance.close();
    }

    async GetStoreOutTotalList() {
        try {

            if (this.selectedStores == null || this.selectedStores.length == 0) {
                ServiceLocator.MessageService.showError("En Az Bir Depo Seçimeniz Gerekiyor..");
                return;
            }

            this.showLoadPanel = true;
            let input: StoreOutTotalInputDTO = new StoreOutTotalInputDTO();
            input.drugSpecificationList = new Array<number>();
            input.drugSpecificationList = this.selectedSpecificationList;
            input.stockTransactionDefList = this.selectedStockTransactionDefValue;
            input.storeIDList = new Array<string>();
            input.materialID = new Guid;
            for (let storeID of this.selectedStores) {
                input.storeIDList.push(storeID.ObjectID.toString());
            }


            if (this.selectedMaterialItem.ObjectID != null) {
                input.materialID = this.selectedMaterialItem.ObjectID;
            }

            input.budgettypeID = this.budgetTypeObjectID;
            input.startDate = this.StartDate;
            input.endDate = this.EndDate;

            let apiUrl: string = 'api/StoreOutTotalReportService/GetStockOutList';
            this.httpService.post<Array<StoreOutTotalOutputDTO>>(apiUrl, input).then(
                result => {
                    this.stockOutDataSource = result;
                    this.TotalNumberOfRows = result.length;
                    this.showLoadPanel = false;

                }).catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    this.showLoadPanel = false;
                });
        }
        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
            this.showLoadPanel = false;
        }
    }
}