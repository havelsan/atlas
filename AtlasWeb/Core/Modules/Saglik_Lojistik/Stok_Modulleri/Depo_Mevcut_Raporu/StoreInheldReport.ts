import { Component, Input, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { StockActionService, InOutRemainingDTO, BudgetTypeDefDVO } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { StockInheldInputDTO, StockInheld } from './StoreInheldReportViewModel';
import { UserHelper } from 'app/Helper/UserHelper';
import { Store } from 'app/NebulaClient/Model/AtlasClientModel';
import { DxDropDownBoxComponent } from 'devextreme-angular';

@Component({
    selector: "StoreInheldReport",
    templateUrl: './StoreInheldReport.html',
    providers: [SystemApiService, MessageService]
})

export class StoreInheldReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows: number;
    selectedMaterialItem: any = {};
    public budgetTypeSources: Array<BudgetTypeDefDVO> = new Array<BudgetTypeDefDVO>();
    public inOutRemainingDTO: InOutRemainingDTO;
    public budgetTypeObjectID: Guid;
    public stockInheld: Array<StockInheld> = new Array<StockInheld>();
    public StoreList: Array<Store>;
    public selectedStores: Array<Store> = new Array<Store>();
    @ViewChild('materialDrop') materialDrop:DxDropDownBoxComponent;
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

        this.StoreList = await UserHelper.UseFirstUserResourcesStores;

        this.selectedStores.push(this.StoreList.find(x => x.ObjectID.toString() == this._StoreObjectId));

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

    storeInheldColumn = [
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
            caption: 'Malzeme Aı',
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
            caption: 'Mevcut',
            dataField: 'Inheld',
            allowEditing: false,
        },
        {
            caption: 'Bütçe Türü',
            dataField: 'BudgetTypeName',
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
                    return this.httpService.post<any>('/api/StoreInheldReportService/GetMaterialList', loadOptions);
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

    async GetStockInheldList() {
        try {

            if (this.selectedStores == null || this.selectedStores.length == 0) {
                ServiceLocator.MessageService.showError("En Az Bir Depo Seçimeniz Gerekiyor..");
                return;
            }
           
            this.showLoadPanel = true;
            let input: StockInheldInputDTO = new StockInheldInputDTO();
            input.storeIDList = new Array<string>();
            input.materialID = new Guid;
            for (let storeID of this.selectedStores) {
                input.storeIDList.push(storeID.ObjectID.toString());
            }
            if(this.selectedMaterialItem.ObjectID != null){
                input.materialID = this.selectedMaterialItem.ObjectID;
            }

            input.budgettypeID = this.budgetTypeObjectID;

            let apiUrl: string = 'api/StoreInheldReportService/GetStockInheldList';
            this.httpService.post<Array<StockInheld>>(apiUrl, input).then(
                result => {
                    this.stockInheld = result;
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