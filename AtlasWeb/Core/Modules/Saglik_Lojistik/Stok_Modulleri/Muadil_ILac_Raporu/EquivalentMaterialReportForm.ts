import { Component, OnInit, Input } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ListMaterialsObject, EquivalentMaterialReportFormViewModel, EquivalentMaterialReportFormGridViewModel } from './EquivalentMaterialReportFormViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";


@Component({
    selector: "equivalent-material-report-form",
    templateUrl: './EquivalentMaterialReportForm.html',
    providers: []
})

export class EquivalentMaterialReportForm implements OnInit {

    private _selectedStoreObjectID: Guid;
    @Input() set SelectedStoreObjectID(value: Guid) {
        if (value != null && this._selectedStoreObjectID != value) {
            this._selectedStoreObjectID = value;
            let url = 'api/EquivalentMaterialReportService/InitEquivalentMaterialReportForm?storeObjectID=' + this._selectedStoreObjectID;
            this.http.get<EquivalentMaterialReportFormViewModel>(url).then(result => {
                this.equivalentMaterialReportFormViewModel = result;
                this.equivalentMaterialReportFormViewModel.SearchModel.StoreObjectID = value;
            });
        }
    }
    public searchText: string;
    public materialSource: Array<ListMaterialsObject>;
    public selectedItems: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public visibility: boolean = false;
    public isInheldDrugList = false;
    DrugIDList: Array<Guid> = new Array<Guid>();
    public SelectedMaterialList: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public equivalentMaterialReportFormViewModel: EquivalentMaterialReportFormViewModel;
    public showLoadPanel = false;
    EquivalentMaterialFormGridList: Array<EquivalentMaterialReportFormViewModel>;
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public storeListFiltred: string ="";
    public EquivalentDrugColumns = [
        {
            caption: 'Malzeme/İlaç Adı',
            dataField: 'Name'
        },
        {
            caption: 'Barkod No',
            dataField: 'BarcodeNo'
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'NatoStockNo'
        },
        {
            caption: 'Etken Madde',
            dataField: 'ActiveIngredientName',
            width: '20%'
        },
        {
            caption: 'Stok Miktarı',
            dataField: 'StockInheld',
            width: '20%'
        }
    ];

    constructor(protected http: NeHttpService, protected activeUserService: IActiveUserService) {
        this.equivalentMaterialReportFormViewModel = new EquivalentMaterialReportFormViewModel();
        this.materialSource = new Array<ListMaterialsObject>();
    }
    ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    materialSourceFull;
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EquivalentMaterialConsumptionService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.http.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.ActiveIngredientList = result.ActiveIngredientList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
            let url = 'api/EquivalentMaterialConsumptionService/GetMaterialsForFilter';
            let input = { 'StoreObjectID': this._selectedStoreObjectID, 'IsInheld': this.isInheldDrugList };
            this.http.post<Array<ListMaterialsObject>>(url, input).then(result => {
                this.materialSource = result;
                this.materialSourceFull = result;
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }
    public SelectedDrugActiveIngredients = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    ngOnInit(): void {
        //this.FillDataSources();

    }
    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.storeListFiltred = this.equivalentMaterialReportFormViewModel.SearchModel.StoreObjectID.toString();
        this.showMaterialMultiSelectForm = true;


    }
    onInheldClicked(event) {
        if (event.value == true) {
            let excludeList: Array<any> = Array<any>();
            for (let mc of this.materialSource) {
                if (mc.Inheldamount !== null && mc.Inheldamount > 0) {
                    excludeList.push(mc);
                }
            }
            this.materialSource = excludeList;
        }
        else {
            this.materialSource = this.materialSourceFull;
        }

    }
    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;
        this.visibility = true;
        selectedMaterials.forEach(element => {
            this.equivalentMaterialReportFormViewModel.SearchModel.SelectedMaterialList.push(element);
        });


    }

    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    OpenActiveIngredientsMaterialMultiSelectComponent() {
        this.showActiveIngredientsMaterialMultiSelectForm = true;

    }
    public selectedChangeOnActiveIngredient() {
        // this.SelectedMaterialList = new Array<ListMaterialsObject>();

        // for (let selectedItem of this.selectedItems) {
        //     this.SelectedMaterialList.push(selectedItem);

        // }
        // this.visibility = true;
        // this.showMaterialMultiSelectForm = false;
        this.showActiveIngredientsMaterialMultiSelectForm = false;

    }


    public clearSelectedMaterials() {
        this.SelectedMaterialList = new Array<ListMaterialsObject>();
    }

    public selectedChange(event: any) {
         //if (this.SelectedMaterialList.find(x => x.ObjectID == event.itemData.ObjectID) == null)
        //     this.SelectedMaterialList.push(event.itemData);
        // this.equivalentMaterialReportFormViewModel.SearchModel.SelectedMaterialList = new Array<ListMaterialsObject>();
        // this.SelectedMaterialList.forEach(element => {
        //     this.equivalentMaterialReportFormViewModel.SearchModel.SelectedMaterialList.push(element);
        // });
            this.showMaterialMultiSelectForm = false;
    }


    public async searchMaterial(event: any) {
        if (event.value.length === 0) {
            this.materialSource = new Array<ListMaterialsObject>();
        }
        if (this._selectedStoreObjectID != null) {
            if (event.value.length > 2) {
                let url = 'api/EquivalentMaterialReportService/GetMaterialsForFilter';
                let input = { 'StoreObjectID': this._selectedStoreObjectID, 'SearchText': event.value.toString(), 'IsInheld': this.isInheldDrugList };
                this.http.post<Array<ListMaterialsObject>>(url, input).then(result => {
                    this.materialSource = result;
                });
            }
        }
        else
            TTVisual.InfoBox.Show('Depo Seçimi yapmadan işlem yapamazsınız!');
    }


    public btnSearchClick() {
        this.showLoadPanel = true;
        let url = 'api/EquivalentMaterialReportService/GetEquivalentMaterials';
        this.http.post<Array<EquivalentMaterialReportFormGridViewModel>>(url, this.equivalentMaterialReportFormViewModel.SearchModel).then(result => {
            this.equivalentMaterialReportFormViewModel.GridViewModel = result;
            this.showLoadPanel = false;
        });
    }
}