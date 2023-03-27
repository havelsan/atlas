import { Component, OnInit, Input, EventEmitter, ViewChild } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import CustomStore from 'devextreme/data/custom_store';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { MKYS_EMalzemeGrupEnum, DrugDefinition, TransactionTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { NewMaterialSelectDTO } from '../Models/NewMaterialSelectComponentViewModel';
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
    selector: 'material-selector',
    templateUrl: './NewMaterialSelectComponent.html'
})

export class MaterialSelectorComponent implements OnInit {


    materialDataSource: DataSource;
    @Input("input") InputModel: MaterialSelectorInput;
    showMaterialSelectGrid: boolean = false;
    selectedMaterials: any[] = [];
    selectedItem: any = {};
    searchText: string;
    search: boolean = false;
    @ViewChild('materialGrid') materialGrid: DxDataGridComponent;
    materialGridColumns = [
        {
            'caption': "Barkod",
            dataField: 'Barcode',
            width: 100,
            allowSorting: true
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'Stockcardname',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Barkod Adı",
            dataField: 'Name',
            width: 250,
            allowSorting: true
        },
        {
            'caption': "Dağıtım Şekli",
            dataField: 'Distributiontypename',
            width: 100,
            allowSorting: true
        },
    ];

    constructor(protected httpService: NeHttpService) { }

    ngOnInit() {
        if (this.InputModel.TransactionType == TransactionTypeEnum.Out) {
            this.materialGridColumns = [
                {
                    'caption': "Barkod",
                    dataField: 'Barcode',
                    width: 100,
                    allowSorting: true
                },
                {
                    'caption': "Malzeme Adı",
                    dataField: 'Stockcardname',
                    width: 250,
                    allowSorting: true
                },
                {
                    'caption': "Barkod Adı",
                    dataField: 'Name',
                    width: 250,
                    allowSorting: true
                },
                {
                    'caption': "Mevcut",
                    dataField: 'Inheld',
                    width: 80,
                    allowSorting: true
                },
                {
                    'caption': "Dağıtım Şekli",
                    dataField: 'Distributiontypename',
                    width: 100,
                    allowSorting: true
                }
            ];
        }
    }

    openMaterialDropDown() {
        this.getMaterialDataSource();
        this.search = true;
    }

    onEnterKey(e) {
        this.search = true;
        this.searchText = this.searchText.toUpperCase();
        this.materialGrid.searchPanel = { text: this.searchText };
        this.getMaterialDataSource();
    }

    getMaterialDataSource() {
        this.materialDataSource = new DataSource({
            store: new CustomStore({
                key: "ObjectID",
                load: (loadOptions: any) => {
                    loadOptions.Params = {
                        searchText: this.searchText,
                        definitionName: 'MaterialList'
                    }
                    if (loadOptions.take == null || loadOptions.take == 0) {
                        loadOptions.take = 10;
                    }
                    return this.httpService.post<any>('/api/NewMaterialSelectComponent/GetMaterialList?materialGroup=' + this.InputModel.MaterialGroup + '&transactionType=' +
                        this.InputModel.TransactionType + '&storeID=' + this.InputModel.StoreID, loadOptions);
                },
            }),
            paginate: true,
            pageSize: 10
        });
    }

    selectedChanged(e) {
        for (let item of e.selectedRowsData) {
            this.checkMaterialAvailable(item);
        }
    }

    checkMaterialAvailable(material) {
        if (this.InputModel.MaterialGroup != MKYS_EMalzemeGrupEnum.ilac && material.IsIndividualTrackingRequired === true) {
            this.selectedMaterials = this.selectedMaterials.filter(p => p != material.ObjectID);
            ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ÜTS Tekil Takip Gerektiren Malzemelerdendir. Lütfen Alma Bildirimi sorgulama işlemi yapınız!');
            return false;
        }


        if (this.InputModel.MaterialGroup == MKYS_EMalzemeGrupEnum.ilac && (<DrugDefinition>material).IsITSDrug === true) {
            this.selectedMaterials = this.selectedMaterials.filter(p => p != material.ObjectID);
            ServiceLocator.MessageService.showError('Giriş yapmak istediğiniz malzeme ITS Malzemelerdendir. Lütfen PTS Getir işlemi yapınız!');
            return false;
        }
        return true;
    }

    selectMaterial(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        this.selectedItem = e.data;
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code  
            this.addMaterial();

        }

    }


    addMaterial() {
        let materialsID: Array<Guid> = new Array<Guid>();
        materialsID.push(this.selectedItem.ObjectID);
        this.httpService.post('/api/NewMaterialSelectComponent/GetMaterials', { materialIds: materialsID, date: this.InputModel.TicketDate, store:this.InputModel.StoreID , destinationstore:this.InputModel.DestinationStoreID }).then(p => {
            if (p) {
                let items = p as NewMaterialSelectDTO[];
                NewMaterialService.onMaterialAdd.emit(items);
                this.selectedMaterials.Clear();
                this.selectedItem = {};
                this.search = false;
                this.searchText = "";
            }
        });
    }
}

export class MaterialSelectorInput {
    MaterialGroup: MKYS_EMalzemeGrupEnum;
    TicketDate: Date;
    TransactionType: TransactionTypeEnum;
    StoreID: Guid;
    DestinationStoreID: Guid;
}

export class MaterialDTO {
    Name: string;
    Barcode: string;
    NATOStockNO: string;
    ObjectID: Guid;
    DistributionTypeName: string;
    VatRate: number;
    MaterialID: Guid;
    UnitPrice: number;
    NotDiscountedUnitPrice: number;
    DiscountAmount: number;
    DiscountRate: number;
    Amount: number;
    Price: number;
}

export class NewMaterialService {
    public static onMaterialAdd: EventEmitter<NewMaterialSelectDTO[]> = new EventEmitter<NewMaterialSelectDTO[]>();
}