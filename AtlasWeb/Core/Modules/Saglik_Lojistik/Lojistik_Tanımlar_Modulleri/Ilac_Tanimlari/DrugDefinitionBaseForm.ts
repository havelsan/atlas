//$6A4829A2
import { Component, OnInit, OnDestroy, ComponentRef, Input, ViewChild } from '@angular/core';
import { DrugDefinitionQueryFilter, DrugDefinitionBaseFormViewModel } from './DrugDefinitionBaseViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DrugSpecificationEnum, DrugShapeTypeEnum, DrugDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { TTBoundFormBase, TTObjectListBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { TTFormBase } from 'NebulaClient/Visual/TTFormBase';
import { DrugDefinitionFormViewModel } from 'Modules/Merkezi_Yonetim_Sistemi/Eczane_Modulleri/Ilac_Vademecum_Tanimlari_Modulu/DrugDefinitionFormViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
const objectIDPropertyName = 'ObjectID';

import { DynamicComponentInfoDVO } from 'Fw/Models/DynamicComponentInfoDVO';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DxDataGridComponent } from 'devextreme-angular';
import { ControlOfDefinitionRole } from 'app/Logistic/Models/MainViewModel';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';



@Component({
    selector: 'DrugDefinitionBaseForm',
    templateUrl: './DrugDefinitionBaseForm.html',
    providers: [MessageService, SystemApiService]
})
export class DrugDefinitionBaseForm implements OnInit, OnDestroy {
    @ViewChild(DxDataGridComponent, {}) dataGrid: DxDataGridComponent;
    StoreID: any;
    private editorFormInstance: any;
    private selectedRowData: any;
    public componentInfo: DynamicComponentInfo;
    public ViewModel: DrugDefinitionBaseFormViewModel;
    public QueryModel: DrugDefinitionQueryFilter;
    public FormDefId: string;
    public ObjectDefName: string;
    LoadPanelMessage: string = "Lütfen Bekleyiniz.."
    // public DrugSpecificationEnumDef;
    public selecedDrugSpecification: Array<string> = [];

    // public List=DrugSpecificationEnum.Items;

    constructor(private systemApi: SystemApiService, protected activeUserService: IActiveUserService,
        private sideBarMenuService: ISidebarMenuService, protected httpService: NeHttpService, private http: NeHttpService,
        protected messageService: MessageService, protected modalService: IModalService) {
        this.ViewModel = new DrugDefinitionBaseFormViewModel();
        this.QueryModel = new DrugDefinitionQueryFilter();
        this.QueryModel.ActionStatus = -1;
        this.QueryModel.IsActive = -1;
        this.QueryModel.IsInheld = -1;
        this.QueryModel.ShowZeroOnDrugOrder = -1;
        this.QueryModel.ShowZeroDistributionInfo = -1;
        this.FormDefId = '8c7cc7e1-765b-4db2-ac74-b2a01d273780';
        this.ObjectDefName = 'DrugDefinition';
        this.QueryModel.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.QueryModel.DrugSpecs = [];
        this.QueryModel.AllDrugSpecifications = false;
        this.QueryModel.DrugShapeTypeList = DrugShapeTypeEnum.Items;
        this.QueryModel.AllDrugShapeType = false;
        this.QueryModel.DrugShape = [];

        this.activeUserService.onStoreChangeEvent.subscribe(() => {
            this.query();
        });

        // this.QueryModel.AllShowZeroOnDrugOrder=false;
        //this.QueryModel.AllIsInheld=false;
        // this.QueryModel.AllShowZeroDistributionInfo=false;
        //this.QueryModel.AllActionStatus=false;
        //this.QueryModel.AllIsActive=false;
    }



    public GridColumns = [
        {
            'caption': "Kodu",
            dataField: 'MaterialCodeSequence',
            allowSorting: true,
            sortOrder: 'asc',
            width: 50
        },
        {
            'caption': "Malzeme Adı",
            dataField: 'Name',
            allowSorting: true,
            width: 250
        },
        {
            "caption": "Barkod No",
            dataField: 'Barcode',
            allowSorting: true,
            width: 100
        },
        {
            "caption": "Durumu",
            dataField: 'IsActive',
            cellTemplate: "LabelCellTemplate",
            falseText: "Pasif",
            trueText: "Aktif",
            width: 50
        },
    ];
    public Items = [
        {
            Name: "Tümü",
            Value: -1
        },
        {
            Name: "Aktif",
            Value: 1
        },
        {
            Name: "Pasif",
            Value: 0
        },

    ];
    public StockItems = [
        {
            Name: "Tümü",
            Value: -1
        },
        {
            Name: "Stokta Olanlar",
            Value: 1
        },
        {
            Name: "Stokta Olmayanlar",
            Value: 0
        },

    ];
    public OrderItems = [
        {
            Name: "Tümü",
            Value: -1
        },
        {
            Name: "Evet",
            Value: 1
        },
        {
            Name: "Hayır",
            Value: 0
        },

    ];

    @Input() set StoreObjectId(object: string) {
        if (object != null && this.StoreID != object) {
            this.StoreID = object;
        }
    }
    get StoreObjectId(): string {
        return this.StoreID;
    }
    async ngOnInit() {
        this.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        this.query();
    }


    btnCollapse() {

        if (this.collapseAttr == 1) {
            this.collapseAttr = 0;
        } else
            this.collapseAttr = 1;

    }
    public collapseIconProperties(): string {

        if (this.collapseAttr == 1) {
            return "fa fa-2x fa-angle-up";
        }
        return "fa fa-2x fa-angle-left";

    }
    public collapseBtnProperties(): string {

        if (this.collapseAttr == 1) {
            return "float-left";
        }
        return "float-right";

    }
    private collapseAttr = 0;
    public collapseSelectedDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-3";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 episodeColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-12";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    public compComposeVisible: boolean = false;

    private isEditorModified(): boolean {

        if (this.editorFormInstance instanceof TTBoundFormBase && !this.isNewItem) {
            let boundFormBase = this.editorFormInstance as TTBoundFormBase;
            return boundFormBase.isModified();
        }
        return false;
    }

    public showLoadPanel = false;
    public componentIsActive = false;
    async openacomponent() {
        if (this.componentIsActive == false) {
            this.showLoadPanel = true;
            const that = this;
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            await this.systemApi.new(this.ObjectDefName, null, this.FormDefId, null).then(res => {
                compInfo.ComponentName = res.ComponentName;
                compInfo.ModuleName = res.ModuleName;
                compInfo.ModulePath = res.ModulePath;
                compInfo.objectID = res.objectID;
                compInfo.InputParam = new ActiveIDsModel(null, this.StoreID, null);
                that.componentInfo = compInfo;
            });
            this.showLoadPanel = false;
            //this.componentIsActive = true;
        }
    }



    public selectedMaterialObjectID: any;
    async selectionMaterial(e) {

        this.sideBarMenuService.onRequestEvent.emit({ loading: true });
        if (!e && !e.selectedRowsData) {
            return;
        }
        else {
            await this.openacomponent();
        }

        if (e.selectedRowsData instanceof Array) {
            let rowDataArray = e.selectedRowsData as Array<any>;
            if (rowDataArray.length > 0) {
                const selectedRowData = rowDataArray[0];
                this.selectedMaterialObjectID = selectedRowData;
                if (this.editorFormInstance instanceof TTBoundFormBase) {
                    this.setEditorFormItem(selectedRowData);
                }
                this.isNewItem = false;
            }

        }
    }




    public onComponentCreated(compRef: ComponentRef<any>) {
        this.editorFormInstance = compRef.instance;
        if(this.selectedMaterialObjectID != null){
            this.setEditorFormItem(this.selectedMaterialObjectID);
        }
    }

    public dynamicComponentActionExecuted(eventParam: any): void {
        const that = this;
        if (eventParam.hasOwnProperty('IsSave') == false)
            return;

        let dynamicComponentSaved = eventParam['IsSave'] as boolean;
        if (dynamicComponentSaved === true) {
            if (this.editorFormInstance instanceof TTBoundFormBase) {
                let boundFormBase = this.editorFormInstance as TTBoundFormBase;
                const ttObject = boundFormBase['__ttObject'];
                if (!this.selectedRowData) {
                    this.selectedRowData = new DrugDefinition();
                }
                Object.assign(this.selectedRowData, ttObject);
                this.selectedMaterialObjectID = this.selectedRowData;
                if (this.editorFormInstance instanceof TTBoundFormBase) {
                    this.setEditorFormItem(this.selectedRowData);
                }
            }
        }
    }

    private setEditorFormItem(selectedItem: any): void {
        if (!this.isNewItem) {
            const formBase = this.editorFormInstance as TTFormBase;
            let objectID = selectedItem[objectIDPropertyName];
            let objectIDGuid: Guid;
            if (objectID instanceof Guid) {
                objectIDGuid = objectID as Guid;
            } else if ((typeof objectID) === 'string') {
                objectIDGuid = new Guid(objectID as string);
            }
            this.loadEditRecord(objectIDGuid);
        }
    }

    private loadEditRecord(objectID: Guid): void {
        if (this.editorFormInstance instanceof TTFormBase) {
            const formBase = this.editorFormInstance as TTFormBase;
            formBase.ObjectID = objectID;
            if (this.editorFormInstance instanceof TTBoundFormBase) {
                let boundFormBase = this.editorFormInstance as TTBoundFormBase;
                (<any>boundFormBase).load(DrugDefinitionFormViewModel);
            }
        }
        //this.dataGrid.instance.deselectAll();
    }



    selectIsActive(data: any) {
        this.QueryModel.IsActive = data.selectedItem.Value;
    }
    selectOrderItems(data: any) {
        this.QueryModel.ShowZeroOnDrugOrder = data.selectedItem.Value;
    }

    selectDrugSpecification(data: any) {
        if (this.QueryModel.DrugSpecs.length > 0) {
            this.QueryModel.DrugSpecs = data.selectedItem.Value;
        }
    }

    selectStockInheld(data: any) {
        this.QueryModel.IsInheld = data.selectedItem.Value;
    }

    selectZeroDistribution(data: any) {
        this.QueryModel.ShowZeroDistributionInfo = data.selectedItem.Value;
    }
    selectDrugShapeType(data: any) {
        if (this.QueryModel.DrugShape.length > 0) {
            this.QueryModel.DrugShape = data.selectedItem.Value;
        }
    }
    selectActionStatus(data: any) {
        this.QueryModel.ActionStatus = data.selectedItem.Value;
    }

    query() {
        let apiUrl: string = '/api/DrugDefinitionBaseViewModelService/WorkListQuery';
        let params: DrugDefinitionQueryFilter = new DrugDefinitionQueryFilter();
        params = this.QueryModel;

        this.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        this.QueryModel.StoreID = this.StoreID;
        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.ViewModel.GridDataSource = x.GridDataSource;
            }

        );
    }

    public DrugDefinitionNewAdd: boolean = false;
    async getRoleControlMain() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MainView/GetRoleControlDefinitionSet';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <ControlOfDefinitionRole>res;
                that.DrugDefinitionNewAdd = result.DrugDefinitionNewAdd;
            })
            .catch(error => {

            });
    }

    private isNewItem: boolean = false;
    async newDrugDefinition() {
        await this.getRoleControlMain();
        if (this.DrugDefinitionNewAdd == true) {
            this.isNewItem = true;
            this.showLoadPanel = true;
            const that = this;
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            this.systemApi.new(this.ObjectDefName, null, this.FormDefId, null).then(res => {
                compInfo.ComponentName = res.ComponentName;
                compInfo.ModuleName = res.ModuleName;
                compInfo.ModulePath = res.ModulePath;
                compInfo.objectID = res.objectID;
                that.componentInfo = compInfo;
                that.selectedMaterialObjectID = undefined;
                this.showLoadPanel = false;
            });
            this.dataGrid.instance.deselectAll();
        }
        else {
            ServiceLocator.MessageService.showError("Yeni  İlaç Tanımı Yapmaya Yetkiniz Bulunmamaktadır.");
        }


    }

    public ngOnDestroy(): void {
    }

    public btnAktifIlacListesiSorgula() {

        let fullApiUrl: string = 'api/LogisticAddAndUpdate/aktifIlacListesiSorgula';
        this.httpService.post(fullApiUrl, null)
            .then((res) => {
                let result = res;

            });
    }
}


