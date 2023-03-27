//$6A4829A2
import { Component, OnInit, OnDestroy, ComponentRef, Input } from '@angular/core';
import { QueryFilter, MaterialDefinitionViewModel } from './MaterialDefinitionViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { DrugSpecificationEnum, DrugShapeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { TTBoundFormBase } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { TTFormBase } from 'NebulaClient/Visual/TTFormBase';
import { DrugDefinitionFormViewModel } from 'Modules/Merkezi_Yonetim_Sistemi/Eczane_Modulleri/Ilac_Vademecum_Tanimlari_Modulu/DrugDefinitionFormViewModel';

const objectIDPropertyName = 'ObjectID';

@Component({
    selector: 'MaterialDefinitionSearchForm',
    templateUrl: './MaterialDefinitionSearchForm.html',
    providers: [MessageService, SystemApiService]
})
export class MaterialDefinitionSearchForm implements OnInit, OnDestroy {
    StoreID: string;
    private editorFormInstance: any;
    private selectedRowData: any;
    public componentInfo: DynamicComponentInfo;
    public ViewModel: MaterialDefinitionViewModel;
    public QueryModel: QueryFilter;
    public FormDefId: string;
    public ObjectDefName: string;
    // public DrugSpecificationEnumDef;
    public selecedDrugSpecification: Array<string> = [];
    // public List=DrugSpecificationEnum.Items;

    constructor(private systemApi: SystemApiService, private sideBarMenuService: ISidebarMenuService, protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        this.ViewModel = new MaterialDefinitionViewModel();
        this.QueryModel = new QueryFilter();
        this.QueryModel.ActionStatus=1;
        this.QueryModel.IsActive=1;
        this.QueryModel.IsInheld=1;
        this.QueryModel.ShowZeroOnDrugOrder=-1;
        this.QueryModel.ShowZeroDistributionInfo=-1;
        this.FormDefId = '8c7cc7e1-765b-4db2-ac74-b2a01d273780';
        this.ObjectDefName = 'DrugDefinition';
        this.QueryModel.DrugSpecificationEnumDef = DrugSpecificationEnum.Items;
        this.QueryModel.DrugSpecs=[];
        this.QueryModel.AllDrugSpecifications=false;
        this.QueryModel.DrugShapeTypeList=DrugShapeTypeEnum.Items;
        this.QueryModel.AllDrugShapeType=false;
        this.QueryModel.DrugShape=[];
       // this.QueryModel.AllShowZeroOnDrugOrder=false;
        //this.QueryModel.AllIsInheld=false;
       // this.QueryModel.AllShowZeroDistributionInfo=false;
        //this.QueryModel.AllActionStatus=false;
        //this.QueryModel.AllIsActive=false;
    }

    

    public GridColumns = [
        {
            'caption': "Kodu",
            dataField: 'Code',
            allowSorting: true,
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
            Name: "Var",
            Value: 1
        },
        {
            Name: "Yok",
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
        const that = this;
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        this.systemApi.new(this.ObjectDefName, null, this.FormDefId, null).then(res => {
            compInfo.ComponentName = res.ComponentName;
            compInfo.ModuleName = res.ModuleName;
            compInfo.ModulePath = res.ModulePath;
            compInfo.objectID = res.objectID;
            that.componentInfo = compInfo;
           // that.componentInfo = res;
        });

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
        return "col-md-9";

    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }

    public compComposeVisible:boolean=false;

    private isEditorModified(): boolean {

        if (this.editorFormInstance instanceof TTBoundFormBase) {
            let boundFormBase = this.editorFormInstance as TTBoundFormBase;
            return boundFormBase.isModified();
        }
        return false;
    }

    selectionMaterial(e) {
        if (!e && !e.selectedRowsData) {
            return;
        }
        if (e.selectedRowsData instanceof Array) {
            let rowDataArray = e.selectedRowsData as Array<any>;
            if (rowDataArray.length > 0) {
                const selectedRowData = rowDataArray[0];

                if (this.selectedRowData) {
                    const selectedObjectID = this.selectedRowData[objectIDPropertyName];
                    const objectID = selectedRowData[objectIDPropertyName];
                    if (selectedObjectID.toString() === objectID.toString()) {
                        return;
                    }
                }

                if (this.isEditorModified() === true) {
                    const result = confirm('Değişiklikler kaydedilmemiş. Yine de devem etmek istiyor musunuz?');
                    if (result === false) {
                        if (e.currentSelectedRowKeys.length) {
                            e.component.deselectRows(e.currentSelectedRowKeys);
                            e.currentSelectedRowKeys.splice(0, e.currentSelectedRowKeys.length);
                            if (this.selectedRowData) {
                                e.component.selectRows([this.selectedRowData]);
                            }
                        }
                        return;
                    }
                }


                this.selectedRowData = selectedRowData;
                this.setEditorFormItem(selectedRowData);
            }
        }
    }

    public onComponentCreated(compRef: ComponentRef<any>) {
        this.editorFormInstance = compRef.instance;
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

                // transfer fields to grid row from editor viewmodel
                Object.assign(this.selectedRowData, ttObject);

            }
        }
    }

    private setEditorFormItem(selectedItem: any): void {
        if (!selectedItem) {
            this.loadEditRecord(Guid.empty());
            return;
        }

        if (!this.editorFormInstance)
            return;

        if (this.editorFormInstance instanceof TTFormBase) {
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
    }

    // public onMaterialSelectionChanged(data) {
    //     if (data.addedItems.length > 0) {
    //         for(let i=0;i<data.addedItems.length;i++)
    //         {
    //             this.QueryModel.DrugSpecifications.push(data.addedItems[i].code);
    //         }
           
    //     }
    //     else if (data.removedItems.length > 0) {
    //         for(let i=0; i<data.removedItems.length;i++)
    //         {
    //             this.QueryModel.DrugSpecifications.splice(this.QueryModel.DrugSpecifications.findIndex(x => x.Equals(data.removedItems[i].code)), 1);
    //         }
           
    //     }
    // }


    query() {
        let apiUrl: string = '/api/MaterialDefinitionViewModelService/WorkListQuery';
        let params: QueryFilter = new QueryFilter();
        params = this.QueryModel;
        this.QueryModel.StoreID=this.StoreID;
        // Malzeme Seçili değilse aşağıdaki gibi if yazılacak
        // if (this.DrugOutForInputReciepeTypeFormViewModel.MaterialList == null || this.DrugOutForInputReciepeTypeFormViewModel.MaterialList.length == 0) {
        //         this.DrugOutForInputReciepeTypeFormViewModel.allMaterials = true;
        //     }
        this.httpService.post<any>(apiUrl, params).then(
            x => {
                this.ViewModel.GridDataSource = x.GridDataSource;
            }

        );
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


