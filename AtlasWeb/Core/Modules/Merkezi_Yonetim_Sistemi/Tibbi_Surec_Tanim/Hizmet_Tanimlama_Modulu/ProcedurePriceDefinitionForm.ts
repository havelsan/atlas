import { Component, OnInit, Input, AfterViewInit, ViewChild, Output, EventEmitter } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { PricingListDefinition, PricingListGroupDefinition, CurrencyTypeDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import DataSource from "devextreme/data/data_source";
import CustomStore from 'devextreme/data/custom_store';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DxDataGridComponent } from "devextreme-angular";
import { ShowBox } from "NebulaClient/Visual/TTVisualControlInterfaces";
import { ShowBoxTypeEnum } from "app/NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { Type } from "app/NebulaClient/ClassTransformer";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";

@Component({
    selector: 'procedure-price-definition-form',
    templateUrl: './ProcedurePriceDefinitionForm.html',
    providers: [MessageService, SystemApiService]
})
export class ProcedurePriceDefinitionForm implements OnInit, AfterViewInit {

    @ViewChild('priceDetailGrid') priceDetailGrid: DxDataGridComponent;

    @Input() set ProcedureDefInfo(propVal: any) {
        this._procedureDefInfo = propVal;
        if (this._procedureDefInfo != null)
            this.GetPricingDetailDefForProcedure();
        else {
            this.PricingDetailGridDataSource = new Array<PricingDetailDefinitionGridModel>();
            this._procedureDefInfo = null;
        }
    }
    @Output() ViewModelLoaded: EventEmitter<any> = new EventEmitter<any>();


    get ProcedureDefInfo(): any {
        return this._procedureDefInfo;
    }

    public _procedureDefInfo: any;
    public listBoxStyle = {};

    public pricingListListDefinitionDataSource: any;
    public pricingListGroupListDefinitionDataSource: any;
    public PricingDetailGridDataSource: Array<PricingDetailDefinitionGridModel>;
    public PriceDetailGridColumns = [];
    public gridDataSourceLoaded = false;
    public PricingObjectIDForFilter: Guid;

    constructor(private http: NeHttpService) {
        this.PricingDetailGridDataSource = new Array<PricingDetailDefinitionGridModel>();
    }

    public async CreateListDataSources() {
        this.pricingListListDefinitionDataSource = {
            store: new CustomStore({
                byKey: (key: string) => {
                    this.PricingObjectIDForFilter = new Guid(key);
                    return this.http.post<any>("/api/ProcedureDefinitionService/GetPricingListListDefinition?key=" + key, null);
                },
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'PricingListListDefinition',
                        injectionFilter: "CODE NOT IN ('2','3')"
                    }

                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }

                    return this.http.post<any>("/api/ProcedureDefinitionService/GetPricingListListDefinition", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 20
        };

        this.pricingListGroupListDefinitionDataSource = {
            store: new CustomStore({
                byKey: async (key: string) => {
                    return await this.http.post<any>("/api/ProcedureDefinitionService/GetPricingListGroupListDefinition?key=" + key, null);
                },
                load: async (loadOptions: any) => {
                    let PricingListGroup = null;
                    if (this.gridDataSourceLoaded)
                        PricingListGroup = this.PricingDetailGridDataSource.map(x => x.PricingListGroup);
                    loadOptions.Params = {
                        searchText: loadOptions.searchValue,
                        definitionName: 'PricingListGroupListDefinition',
                        pricingListGroup: PricingListGroup,
                        injectionFilter: "PRICINGLIST = '" + this.PricingObjectIDForFilter + "'"
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 50;
                    }
                    this.gridDataSourceLoaded = false;

                    return await this.http.post<any>("/api/ProcedureDefinitionService/GetPricingListGroupListDefinition", loadOptions);

                },
            }),
            paginate: true,
            pageSize: 20
        };
    }

    public GenerateColumns() {
        this.PriceDetailGridColumns = [
            {
                caption: 'Fiyat Asıl Kodu',
                dataField: 'ExternalCode',
                width: 'auto',
                fixed: true,
            },
            {
                caption: 'Fiyat Asıl Adı',
                dataField: 'Description',
                width: 'auto',
                fixed: true,
            },
            // {
            //     caption: 'Fiyat Listesi',
            //     dataField: 'PricingList',
            //     cellTemplate: 'lstboxPricingListDefinition',
            //     allowEditing: false,
            //     cssClass: 'remove-padding',
            //     width: 220
            // },
            {
                caption: "Fiyat Listesi",
                dataField: 'PricingList',
                setCellValue: this.pricingListSelectionChanged,
                lookup: {
                    dataSource: this.pricingListListDefinitionDataSource,
                    valueExpr: 'ObjectID', displayExpr: 'Name',
                },
                width: 220,
            },
            {
                caption: "Fiyat Grubu",
                dataField: 'PricingListGroup',
                setCellValue: this.pricingListGroupSelectionChanged,
                lookup: { dataSource: this.pricingListGroupListDefinitionDataSource, valueExpr: 'ObjectID', displayExpr: this.getDisplayExp },
                width: 220,
            },
            {
                caption: 'F. Başl. Tar.',
                dataField: 'StartDate',
                dataType: 'date',
                width: 'auto',
            },
            {
                caption: 'F. Bitiş. Tar.',
                dataField: 'EndDate',
                dataType: 'date',
                width: 'auto',
            },
            {
                caption: 'Hiz. Fiyatı',
                dataField: 'Price',
                dataType: 'number',
                width: 'auto',
            },
            {
                caption: 'Hiz. Puanı',
                dataField: 'Point',
                dataType: 'number',
                width: 'auto',
            },
            {
                caption: 'Ayaktan İnd. Oranı',
                dataField: 'OutPatientDiscountPercent',
                dataType: 'number',
                width: 'auto',
            },
            {
                caption: 'Yatan İnd. Oranı',
                dataField: 'InPatientDiscountPercent',
                dataType: 'number',
                width: 'auto',
            },
            // {
            //     caption: 'Aktif',
            //     dataField: 'IsActivte',
            //     dataType: 'boolean'
            // },
            // {
            //     caption: 'Para Birimi',
            //     dataField: '',
            //     cellTemplate: '',
            //     width: 90
            // },
        ];
    }

    public selectedRowPricingList: PricingListDefinition;

    public pricingListSelectionChanged(rowData: any, value: any) {
        rowData.PricingListGroup = null;
        (<any>this).defaultSetCellValue(rowData, value);
    }

    public pricingListGroupSelectionChanged(rowData: any, value: any) {
        (<any>this).defaultSetCellValue(rowData, value);
    }

    public getDisplayExp(item) {
        if (!item) {
            return "";
        }

        return item.ExternalCode + " " + item.Description;
    }

    async ngOnInit() {
        await this.CreateListDataSources();
        this.GenerateColumns();
    }


    ngAfterViewInit(): void {
        this.listBoxStyle = {
            'margin-left': '15px',
            'margin-right': '15px',
        };
    }

    // public onPriceDetailGridUpdated(event: any) {
    //     console.log(event);
    // }

    // public onEditingStart(event: any) {
    //     console.log(event);
    //     this.PricingListsReadOnly = false;
    // }

    // public onRowInserting(event: any) {
    //     console.log(event);
    //     this.PricingListsReadOnly = true;
    // }

    public async onRowInserted(event) {
        this.SavePricingDetail(event.key);
    }

    public onEditingStart(event: any) {
        this.PricingObjectIDForFilter = event.data.PricingList;
    }

    public onInitNewRow(event: any) {
        //this.PricingListsReadOnly = false;
        if (this._procedureDefInfo != null) {
            event.data.IsNew = true;
            event.data.Description = this._procedureDefInfo.SUTName;
            event.data.ExternalCode = this._procedureDefInfo.SUTCode;
        }
        else {
            event.cancel = true;
            ServiceLocator.MessageService.showError('Hizmet seçilmedi.');
        }
    }

    public onRowPrepared(event: any) {
        if (event.data != null && new Date(event.data.StartDate) <= new Date() && new Date(event.data.EndDate) >= new Date())
            event.rowElement.firstItem().style.backgroundColor = 'lightgreen';
    }

    public onRowUpdated(event: any) {
        event.key.IsUpdated = true;
        this.SavePricingDetail(event.key);
    }

    public onRowRemoving(event: any) {
        if (event != null && event.data != null && event.data.IsNew == true) {
            event.cancel = false;
        }
        else {
            TTVisual.InfoBox.Alert('Sadece Yeni eklenen fiyat silinebilir!');
            event.cancel = true;
        }
    }

    public onPricingListDefinitionChanged(event, data): void {
        data.IsUpdated = true;
    }

    public onPricingListGroupChanged(event, data): void {
        data.IsUpdated = true;
    }

    public async SavePricingDetail(data) {
        let sameCode = false;
        let askForSameCode: string;

        if (this.PricingDetailGridDataSource.filter(x => x.IsNew == true).length > 0)
            askForSameCode = await ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'YES,NO', i18n("M23735", "Uyarı"), '', 'Yeni fiyat aynı kodlu işlemler ile eşleşsin mi?');

        if (!String.isNullOrEmpty(askForSameCode) && askForSameCode === "YES")
            sameCode = true;

        let inputParams = {
            PriceDetails: [data],
            ProcedureDefObjectID: this.ProcedureDefInfo.ObjectID,
            CreateProcedurePriceWithSameCode: sameCode
        };
        this.http.post<Array<PricingDetailDefinitionGridModel>>('api/ProcedureDefinitionService/SaveAndUpdatePricingDetail', inputParams).then(res => {
            this.gridDataSourceLoaded = true;
            this.PricingDetailGridDataSource = res;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            this.PricingDetailGridDataSource = new Array<PricingDetailDefinitionGridModel>();
            this.gridDataSourceLoaded = true;
        });
    }

    public GetPricingDetailDefForProcedure() {
        this.http.post<ProcedureDefinitionFormViewModel>('api/ProcedureDefinitionService/GetPricingDetailDefsForProcedure?procedureDefObjectId=' + this.ProcedureDefInfo.ObjectID, null).then(res => {
            this.gridDataSourceLoaded = true;
            this._procedureDefInfo.SUTName = res.procedureDefInfo.SUTName;
            //this._procedureDefInfo.SUTCode = res.procedureDefInfo.SUTCode;
            this.ViewModelLoaded.emit(res.procedureDefInfo);
            this.PricingDetailGridDataSource = res.pricingDetailDefinitionGridModel;
        });
    }

    public SaveGridData() {
        this.priceDetailGrid.instance.saveEditData();
        this.priceDetailGrid.instance.closeEditCell();
    }

}

export class PricingDetailDefinitionGridModel {
    public ExternalCode: string;
    @Type(() => Guid)
    public ObjectID: Guid;
    //Name'i
    public Description: string;
    //PricingListListDefinition
    @Type(() => Guid)
    public PricingList?: Guid;
    //PricingListGroupListDefinition
    @Type(() => Guid)
    public PricingListGroup?: Guid;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    @Type(() => Number)
    public Price: number;
    @Type(() => Number)
    public Point: number;
    @Type(() => CurrencyTypeDefinition)
    public CurrencyType: CurrencyTypeDefinition;
    @Type(() => Number)
    public InPatientDiscountPercent: number;
    @Type(() => Number)
    public OutPatientDiscountPercent: number;
    public IsNew = false;
    public IsActive: boolean;
    public IsUpdated: boolean;
}

export class ProcedureDefinitionFormViewModel {
    @Type(() => PricingDetailDefinitionGridModel)
    public pricingDetailDefinitionGridModel: Array<PricingDetailDefinitionGridModel> = new Array<PricingDetailDefinitionGridModel>();
    @Type(() => ProcedureDefInfo)
    public procedureDefInfo: ProcedureDefInfo;
}

export class ProcedureDefInfo {
    //Asıl Fiyat Adı
    public SUTName: string;
    //Asıl Fiyat Kodu
    public SUTCode: string;
}