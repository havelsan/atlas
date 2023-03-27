import { Component, OnInit, ViewChild, Input, Renderer2 } from '@angular/core';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import {
    DynamicComponentInfoDVO
} from 'app/Logistic/Models/LogisticMainViewModel';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DrugReturnReportFormViewModel } from './DrugReturnReportFormViewModel';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from "app/NebulaClient/Visual/TTUnboundForm";
import { MessageService } from "app/Fw/Services/MessageService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { Headers, RequestOptions } from '@angular/http';
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";
import { TransactionTypeEnum, ResUser, ResClinic, ActiveIngredientDefinition } from "app/NebulaClient/Model/AtlasClientModel";
import { DxAccordionComponent } from "devextreme-angular";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { IModalService } from "app/Fw/Services/IModalService";

@Component({
    selector: "DrugReturnReportForm",
    templateUrl: './DrugReturnReportForm.html',
    providers: [SystemApiService, MessageService]
})

export class DrugReturnReportForm extends TTUnboundForm implements OnInit {
    public DrugReturnReportFormViewModel: DrugReturnReportFormViewModel;
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
    DrugReturnActionList: Array<DrugReturnActionGrid>;
    DrugIDList: Array<Guid> = new Array<Guid>();
    public SelectedMaterialList: Array<Guid> = new Array<Guid>();
    public SelectedDrugActiveIngredients: Array<Guid> = new Array<Guid>();
    public SelectedActiveIngredients: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class> = new Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>();
    masterResourceIDList: Array<Guid> = new Array<Guid>();
    ActiveSubstanceIDList: Array<Guid> = new Array<Guid>();
    public TotalNumberOfRows: number;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'Lütfen Bekleyiniz';
    public componentInfo: DynamicComponentInfo;
    public storeListFiltred: String="";
    @ViewChild('materialActionDetayAccordion') materialActionDetayAccordion: DxAccordionComponent;

    public DrugActionListColumns = [
        {
            caption: '',
            dataField: 'ObjectID',
            width: 50,
            cellTemplate: 'buttonCellTemplate',
        },
        {
            'caption': "Hasta Adı Soyadı",
            dataField: 'PatientName',
            allowSorting: true
        },
        {
            'caption': "Doktor Adı Soyadı",
            dataField: 'DoctorName',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "İade Tarihi",
            dataField: 'ReturnDate',
            allowSorting: true,
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            'caption': "Servis",
            dataField: 'MasterResource',
            dataType: 'string',
            allowSorting: true,
        },
        {
            'caption': "İade Sebebi",
            dataField: 'ReturnReason',
            dataType: 'string',
            allowSorting: true
        },
        {
            'caption': "Oda",
            dataField: 'Room',
            allowSorting: true
        },
        {
            'caption': "Yatak",
            dataField: 'Bed',
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
        super('MaterialExpirationDateInfo', 'MaterialExpirationDateInfoForm');
        this.DrugActiveIngredientList = new TTVisual.TTObjectListBox();
        this.DrugActiveIngredientList.ListFilterExpression = "";
        this.DrugActiveIngredientList.ListDefName = "ActiveIngredientList";
        this.DrugActiveIngredientList.Name = "DrugActiveIngredientList";
        this.DrugActiveIngredientList.TabIndex = 4;
        this.initViewModel();
    }

    public initViewModel(): void {
        this.DrugReturnReportFormViewModel = new DrugReturnReportFormViewModel();
    }

    async ngOnInit() {
        this.setDefaultDates();
        this.initDrugReturnActionStates();
        this.FillDataSources();
    }

    DoctorList: Array<ResUser.ClinicDoctorListNQL_Class>;
    MasterResourceList: Array<ResClinic>;
    ActiveIngredientList: Array<ActiveIngredientDefinition.GetActiveIngredientDefinitions_Class>;
    async FillDataSources() {
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugReturnReportService/FillDataSources';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DoctorList = result.DoctorList;
                    this.MasterResourceList = result.MasterResourceList;
                    this.ActiveIngredientList = result.ActiveIngredientList;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }
    }

    DrugReturnActionStateList: Array<DrugReturnActionState>;
    selectedDrugActionState: DrugReturnActionState = new DrugReturnActionState("Tümü", 0);
    initDrugReturnActionStates() {
        this.DrugReturnActionStateList = new Array<DrugReturnActionState>();
        this.DrugReturnActionStateList.push(new DrugReturnActionState("Tümü", 0));
        this.DrugReturnActionStateList.push(new DrugReturnActionState("Kabul Edilenler", 1));
        this.DrugReturnActionStateList.push(new DrugReturnActionState("Kabul Edilmeyenler", 2));
    }

    OnSelectedDrugACtionStateChanged(data) {
        this.selectedDrugActionState = data.selectedItem;
        this.drugReturnActionState = this.selectedDrugActionState.value;
    }
    public showMaterialMultiSelectForm: boolean = false;
    OpenMaterialMultiSelectComponent() {
        this.storeListFiltred = this._StoreObjectId.toString();
        this.showMaterialMultiSelectForm = true;
    }

    async MaterialsSelected(event) {
        this.showMaterialMultiSelectForm = false;
        let selectedMaterials = event;
        this.visibility = true;
        selectedMaterials.forEach(element => {
            this.DrugIDList.push(element.ObjectID);
            //this.selectedMaterialsText += element.Name + " - ";
        });


    }



    private showActiveIngredientsMaterialMultiSelectForm: boolean = false;
    OpenActiveIngredientsMaterialMultiSelectComponent() {
        this.showActiveIngredientsMaterialMultiSelectForm = true;

    }
    // public clearSelectedMaterials() {
    //     this.SelectedMaterialList = new Array<ListMaterialsObject>();
    // }
    public selectedChangeOnActiveIngredient() {

        this.ActiveSubstanceIDList = new Array<Guid>();
        for (let selectedItem of this.SelectedActiveIngredients) {
            this.ActiveSubstanceIDList.push(selectedItem.ObjectID);
        }
       // this.visibility = true;
        this.showActiveIngredientsMaterialMultiSelectForm = false;

    }
    public selectedChange(event: any) {
        // if (this.SelectedMaterialList.find(x => x.ObjectID == event.itemData.ObjectID) == null)
        //     this.SelectedMaterialList.push(event.itemData);
        this.DrugIDList = new Array<Guid>();
        this.showMaterialMultiSelectForm = false;
    }



    public onDoctorSelectionChanged(data) {
        if (data.addedItems.length > 0) {
            this.doctorIDList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.doctorIDList.splice(this.doctorIDList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }
    public onMasterResourceSelectionChanged(data) {
        if (data.addedItems.length > 0) {
            this.masterResourceIDList.push(data.addedItems[0].ObjectID);
        }
        else if (data.removedItems.length > 0) {
            this.masterResourceIDList.splice(this.masterResourceIDList.findIndex(x => x.Equals(data.removedItems[0].ObjectID)), 1);
        }
    }


    public setDefaultDates() {
        this.StartDate = new Date();
        this.StartDate.setHours(0, 0, 0, 0);
        this.EndDate = new Date();
        this.EndDate.setHours(23, 59, 59, 0);
    }

    public async GetDrugReturnActionList() {
        this.showLoadPanel = true;
        try {
            let that = this;
            let apiUrlForPASearchUrl: string = '/api/DrugReturnReportService/GetDrugReturnActionList';
            let body = { 'StartDate': this.StartDate, 'EndDate': this.EndDate, 'DrugReturnActionState': this.drugReturnActionState, 'DoctorIDList': this.doctorIDList, 'DrugIDList': this.DrugIDList, 'ActiveIngredientIDList': this.ActiveSubstanceIDList, 'ServiceIDList': this.masterResourceIDList };
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.httpService.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.DrugReturnActionList = result;
                }
                this.TotalNumberOfRows = this.DrugReturnActionList.length;
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

    public selectedMaterialsText: string = "";

    public clearSelectedMaterials() {
        this.DrugIDList = new Array<Guid>();
        this.selectedMaterialsText = "";
    }

    showDrugReturnActionDetail: boolean = false;
    public openDrugReturnActionForm(data) {
        this.httpService.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + data.key.ObjectID).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;
        }).then(() => {
            this.showDrugReturnActionDetail = true;
            });
    }

}

enum State {
    All = "Tümü",
    Completed = "Kabul Edilenler",
    Approve = "Kabul Edilmeyenler"
}

export class DrugReturnActionState {
    that = this;
    constructor(text: string, value: number) {
        this.text = text;
        this.value = value;
    }
    text: string;
    value: number;
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

export class StockActionWorkListDashboardItemModel {

    public ObjectID: string;
    public StockActionID: number;
    public StockActionType: TransactionTypeEnum;
    public DestinationStore: string;
    public StockactionName: string;
    public PatientName: string;
    public TransactionDate: Date;
    public StateName: string;
    public StateFormName: string;
    public Amount: number;
}

export class DrugReturnActionGrid {
    public ObjectID: Guid;
    public PatientName: string;
    public DoctorName: string;
    public ReturnDate: Date;
    public MasterResource: string;
    public Room: string;
    public Bed: string;
    public ReturnReason: string;
}
export class ListMaterialsObject {
    public ObjectID: Guid;
    public Name: string;
    public InHeldAmount: string;
}