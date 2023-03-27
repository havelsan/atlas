import { Component, Input } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { IModalService } from "app/Fw/Services/IModalService";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { StockActionService, InOutRemainingDTO, BudgetTypeDefDVO, MainStoreDVO } from 'app/NebulaClient/Services/ObjectService/StockActionService';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { UserHelper } from 'app/Helper/UserHelper';
import { Store } from 'app/NebulaClient/Model/AtlasClientModel';
import { ConsumedMaterialReportInputDTO, ConsumedMaterialReportOutputDTO } from './ConsumedMaterialReportViewModel';


@Component({
    selector: "ConsumedMaterialReport",
    templateUrl: './ConsumedMaterialReport.html',
    providers: [SystemApiService, MessageService]
})

export class ConsumedMaterialReport {
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz...';
    private _StoreObjectId: string;
    public showLoadPanel: boolean;
    public TotalNumberOfRows: number;
    public budgetTypeSources: Array<BudgetTypeDefDVO> = new Array<BudgetTypeDefDVO>();
    public inOutRemainingDTO: InOutRemainingDTO;
    public budgetTypeObjectID: Guid;
    public consumedMaterialDataSource: Array<ConsumedMaterialReportOutputDTO> = new Array<ConsumedMaterialReportOutputDTO>();
    public StoreList: Array<MainStoreDVO> = new Array<MainStoreDVO>();
    public selectedStores: Array<Store> = new Array<Store>();
    public StartDate: Date;
    public EndDate: Date;

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
        this.StoreList = this.inOutRemainingDTO.mainStores;
        this.setDefaultDates();
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

    consumedMaterialColumn = [
        {
            caption: 'Taşınır Kodu',
            dataField: 'StockCardClassCode',
            allowEditing: false,
        },
        {
            caption: 'Taşınır 2. Düzey Adı',
            dataField: 'StockCardClassName',
            allowEditing: false,
            sortOrder: "asc"
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


    async GetConsumedMaterial() {
        try {

            if (this.selectedStores == null || this.selectedStores.length == 0) {
                ServiceLocator.MessageService.showError("En Az Bir Depo Seçimeniz Gerekiyor..");
                return;
            }

            this.showLoadPanel = true;
            let input: ConsumedMaterialReportInputDTO = new ConsumedMaterialReportInputDTO();
            input.storeIDList = new Array<string>();

            for (let storeID of this.selectedStores) {
                input.storeIDList.push(storeID.ObjectID.toString());
            }


            input.budgettypeID = this.budgetTypeObjectID;
            input.startDate = this.StartDate;
            input.endDate = this.EndDate;

            let apiUrl: string = 'api/ConsumedMaterialReportService/GetConsumedMaterial';
            this.httpService.post<Array<ConsumedMaterialReportOutputDTO>>(apiUrl, input).then(
                result => {
                    this.consumedMaterialDataSource = result;
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