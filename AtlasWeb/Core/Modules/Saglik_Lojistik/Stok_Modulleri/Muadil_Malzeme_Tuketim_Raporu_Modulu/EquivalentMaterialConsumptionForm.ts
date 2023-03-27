import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { EquivalentMaterialConsumptionViewModel } from './EquivalentMaterialConsumptionViewModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { ResUser, ResClinic, ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";

@Component({
    selector: "EquivalentMaterialConsumptionForm",
    templateUrl: './EquivalentMaterialConsumptionForm.html',
    providers: [SystemApiService, MessageService]
})

export class EquivalentMaterialConsumptionForm extends TTUnboundForm implements OnInit {
    public EquivalentMaterialConsumptionViewModel: EquivalentMaterialConsumptionViewModel;
    public DayQueryNumber: number;
    private _StoreObjectId: string;
    public MaterialList: Array<MaterialItem> = new Array<MaterialItem>();
    public SelectedMaterials: Array<Guid> = new Array<Guid>();
    public StartDate: Date;
    public EndDate: Date;
    public visibility: boolean = false;
    public DrugActiveIngredientList: TTVisual.ITTObjectListBox;
    drugReturnActionState: number = 0;
    doctorIDList: Array<Guid> = new Array<Guid>();
    DrugIDList: Array<Guid> = new Array<Guid>();
    EquivalentMaterialConsumptionFormGridList: Array<EquivalentMaterialConsumptionFormGridViewModel>;
    public TotalNumberOfRows: number;
    public materialSource: Array<ListMaterialsObject>;
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    public selectedItems: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public SelectedMaterialList: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public componentInfo: DynamicComponentInfo;
    public isInheldDrugList = false;
    public SelectedDrugActiveIngredients: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public storeListFiltred: String="";
    @ViewChild('materialActionDetayAccordion') materialActionDetayAccordion: DxAccordionComponent;

    public EquivalentMaterialConsumptionListColumns = [
        {
            'caption': "Malzeme / İlaç Adı",
            dataField: 'Name',
            allowSorting: true
        },
        {
            'caption': "Barkod No",
            dataField: 'BarcodeNo',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Taşınır Kodu",
            dataField: 'NatoStockNo',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "Etken Madde Adı",
            dataField: 'ActiveIngredientName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Tüketim Miktarı",
            dataField: 'TotalConsumption',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Depo Mevcudu",
            dataField: 'Inheld',
            dataType: 'string',
            allowSorting: true
        },

    ];
    @Input() set StoreObjectId(object: string) {
        if (object != null && this._StoreObjectId != object) {
            this._StoreObjectId = object;
        }
    }
    get StoreObjectId(): string {
        return this._StoreObjectId;
    }

    constructor(protected httpService: NeHttpService, private modalService: IModalService, protected messageService: MessageService, public systemApiService: SystemApiService, private renderer: Renderer2) {
        super('EquivalentMaterialConsumption', 'EquivalentMaterialConsumptionForm');
        this.materialSource = new Array<ListMaterialsObject>();
        this.initViewModel();
    }

    public initViewModel(): void {
        this.EquivalentMaterialConsumptionViewModel = new EquivalentMaterialConsumptionViewModel();
    }

    async ngOnInit() {
        this.setDefaultDates();
        //this.FillDataSources();
    }
    materialSourceFull: Array<ListMaterialsObject> = new Array<ListMaterialsObject>();
    DoctorList: Array<ResUser.ClinicDoctorListNQL_Class>;
    MasterResourceList: Array<ResClinic>;
    ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EquivalentMaterialConsumptionService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.ActiveIngredientList = result.ActiveIngredientList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });

            let url = 'api/EquivalentMaterialConsumptionService/GetMaterialsForFilter';
            let input = { 'StoreObjectID': this._StoreObjectId, 'IsInheld': this.isInheldDrugList };
            this.httpService.post<Array<ListMaterialsObject>>(url, input).then(result => {
                this.materialSource = result;
                this.materialSourceFull = result;
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
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


    private showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.storeListFiltred = this._StoreObjectId.toString();
        this.showMaterialMultiSelectForm = true;


    }
    public selectedMaterialsText: string = "";
    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    OpenActiveIngredientsMaterialMultiSelectComponent() {
        this.showActiveIngredientsMaterialMultiSelectForm = true;

    }
    public async onActiveSubstanceChanged(data) {
        if (data.addedItems.length > 0) {
            this.ActiveSubstanceIDList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.ActiveSubstanceIDList.splice(this.ActiveSubstanceIDList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }
    public selectedChangeOnActiveIngredient() {
        this.showActiveIngredientsMaterialMultiSelectForm = false;
    }

    public selectedChange(event: any) {
        // if (this.SelectedMaterialList.find(x => x.ObjectID == event.itemData.ObjectID) == null)
        //     this.SelectedMaterialList.push(event.itemData);
        this.showMaterialMultiSelectForm = false;
    }

    public async searchMaterial(event: any) {
        if (event.value.length === 0) {
            this.materialSource = new Array<ListMaterialsObject>();
        }
        if (this._StoreObjectId != null) {
            if (event.value.length > 2) {
                let url = 'api/EquivalentMaterialReportService/GetMaterialsForFilter';
                let input = { 'StoreObjectID': this._StoreObjectId, 'SearchText': event.value.toString(), 'IsInheld': this.isInheldDrugList };
                this.httpService.post<Array<ListMaterialsObject>>(url, input).then(result => {
                    this.materialSource = result;
                });
            }
        }
        else
            TTVisual.InfoBox.Show('Depo Seçimi yapmadan işlem yapamazsınız!');
    }

    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    public async GetEquivalentMaterialConsumptionList() {
        this.showLoadPanel = true;
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/EquivalentMaterialConsumptionService/GetEquivalentMaterialConsumption';
            let body = { 'StoreObjectID': this._StoreObjectId, 'StartDate': this.StartDate, 'EndDate': this.EndDate, 'SelectedMaterialList': this.SelectedMaterialList, 'ActiveIngredientList': this.ActiveSubstanceIDList, 'SelectedDrugActiveIngredients': this.SelectedDrugActiveIngredients };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.EquivalentMaterialConsumptionFormGridList = result;
                }
                this.TotalNumberOfRows = this.EquivalentMaterialConsumptionFormGridList.length;
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
        catch (ex) {

        }
        finally {
            this.showLoadPanel = false;
        }
    }

}


export class MaterialItem {
    MaterialObjectID: string;
    Name: string;
    NATOStockNO: string;
    Restamount: string;
    ExpirationDate: Date;
    DayLife: number;
    MKYSStockTransactionID: string;
}

export class EquivalentMaterialConsumptionFormGridViewModel {
    public Name: string;
    public BarcodeNo: string;
    public NatoStockNo: string;
    public ActiveIngredientName: string;
    public TotalConsumption: string;
    public MaterialObjectID: Guid;
    public EquivalentMaterials: Array<EquivalentMaterialConsumptionFormGridViewModel> = new Array<EquivalentMaterialConsumptionFormGridViewModel>();
    public Inheld:string;
}

//Filtreleme için dx-list (Malzeme listesi) doldurmak için oluşturulan obje
export class ListMaterialsObject {
    public ObjectID: Guid;
    public Name: string;
    public Inheldamount: number;
}