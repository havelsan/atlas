//$2AF9EEDE
import { Component, ViewChild } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import {
    LogisticMainViewModel, QueryInputDVO, WorkListItem, MenuOutputDVO,
    StockActionWorkListItemModel, DynamicComponentInfoDVO, WorkListResultColorEnum
} from '../Models/LogisticMainViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { MenuDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TTListDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTListDef';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DxAccordionComponent } from 'devextreme-angular';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { Store, PharmacyStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { DxDataGridComponent } from 'devextreme-angular';


import { MainViewModel } from '../Models/MainViewModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
@Component({
    selector: 'hvl-logistic-main-view',
    inputs: ['Model'],
    templateUrl: './WorkListView.html',
    /*styles: [` :host /deep/ .dx-datagrid-header-panel .dx-toolbar {
        margin: 0;
        padding-right: 20px;
        background-color: #5186C3;
    }
    :host /deep/ .dx-datagrid-header-panel .dx-toolbar-items-container  {
        height: 70px;
    }
    :host /deep/ .dx-datagrid-header-panel .dx-toolbar-before {
        background-color: #337AB7;
    }
    :host /deep/ .dx-datagrid-header-panel .dx-selectbox {
         margin: 17px 10px;
    }
    :host /deep/ .dx-datagrid-header-panel .dx-button {
         margin: 17px 0;
    }
    /deep/ .informer {
        height: 70px;
        width: 130px;
        text-align: center;
        background: #2A507C url("content/icons/arrow.png") no-repeat 100% 50%;
    }
    /deep/ .count {
        color: #fff;
        padding-top: 15px;
        line-height: 27px;
    }
    /deep/ .name {
        color: #619dd1;
    }
        `]*/
})
export class LogisticWorkList extends BaseComponent<LogisticMainViewModel> {
    StockWorkList: Array<StockActionWorkListItemModel>;
    public menuList: Array<MenuDefinition>;
    public searchMenuTxt: string;
    public componentInfo: DynamicComponentInfo;
    public selectedAccordionItem: any;
    public workListItems: Array<WorkListItem> = new Array<WorkListItem>();
    public selectedWorkListItems: Array<WorkListItem> = new Array<WorkListItem>();
    public definitionMenuItems: Array<TTListDef>;
    public selecttableStores: Array<Store>;
    public expanded = true;
    public totalCount: number;
    public worklistGroupProp: string;
    public showLoadPanel = false;
    public LoadPanelMessage: string = 'İşlemler listeleniyor, lütfen bekleyiniz.';
    @ViewChild(DxDataGridComponent) dataGrid: DxDataGridComponent;
    public WorkListColumns = [
        {
            caption: ' ',
            dataField: 'ObjectID',
            cellTemplate: 'buttonCellTemplate',
            visible: false,
            width: 48
        },
        {
            'caption': i18n("M16866", "İşlem No"),
            dataField: 'StockActionID',
            width: 60,
            allowSorting: true
        },
        {
            'caption': i18n("M15131", "Hasta Adı"),
            dataField: 'PatientName',
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            'caption': i18n("M21662", "Servis"),
            dataField: 'DestinationStore',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16818", "İşlem"),
            dataField: 'StockactionName',
            dataType: 'string',
            width: 60,
            allowSorting: true
        },
        {
            'caption': i18n("M12616", "Depo Adı"),
            dataField: 'Store',
            dataType: 'string',
            width: 250,
            allowSorting: true
        },
        {
            'caption': i18n("M16838", "İşlem Durumu"),
            dataField: 'StateName',
            dataType: 'string',
            width: 150,
            allowSorting: true
        },
        {
            'caption': i18n("M16886", "İşlem Tarihi"),
            dataField: 'TransactionDate',
            dataType: 'string',
            width: 100,
            allowSorting: true

        }
    ];

    public worklistVisibile: boolean = true;
    public worklistBarVisibile: boolean = false;
    public actionTab: string;



    private patientInfoCollapseAttr = 0;
    btnCollapse() {

        if (this.patientInfoCollapseAttr === 1) {
            this.patientInfoCollapseAttr = 0;
            this.actionTab = '71%';
        } else {
            this.patientInfoCollapseAttr = 1;
            this.actionTab = '98%';
        }

        //this.getMenuList();
        //this.accordion.dataSource = this.menuList;
    }

    public collapseIconProperties(): string {

        if (this.patientInfoCollapseAttr === 1) {
            return 'fa fa-2x fa-angle-up';
        }
        return 'fa fa-2x fa-angle-left';
    }

    public collapseSelectedDivProperties(): string {

        if (this.patientInfoCollapseAttr === 1) {
            return "hidden";
        }
        return "col-md-3";
    }

    public collapseSelectedHiddenDivProperties(): string {

        if (this.patientInfoCollapseAttr == 1) {
            return "col-md-1 episodeColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }
    /*onToolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'before',
            template: 'totalGroupCount'
        }, {
                location: 'before',
                widget: 'dxSelectBox',
                options: {
                    width: 200,
                    items: [{
                        value: 'StockactionName',
                        text: 'İşleme Göre Grupla '
                    }, {
                        value: 'PatientName',
                        text: 'Hastaya Göre Grupla '
                    }, {
                        value: 'DestinationStore',
                        text: 'Karşı Depoya Göre Grupla'
                    }, {
                        value: 'Store',
                        text: 'Depoya Göre Grupla'
                    }],
                    displayExpr: 'text',
                    valueExpr: 'value',
                    value: this.worklistGroupProp,
                    onValueChanged: this.groupChanged.bind(this)
                }
            }, {
                location: 'before',
                widget: 'dxButton',
                options: {
                    hint: 'Hepsini Kapat',
                    icon: 'chevrondown',
                    onClick: this.collapseAllClick.bind(this)
                }
            });
    }

    groupChanged(e) {
        this.dataGrid.instance.clearGrouping();
        this.dataGrid.instance.columnOption(e.value, 'groupIndex', 0);
        this.totalCount = this.getGroupCount(e.value);
        this.worklistGroupProp = e.value;
    }

    collapseAllClick(e) {
        this.expanded = !this.expanded;
        e.component.option({
            icon: this.expanded ? 'chevrondown' : 'chevronnext',
            hint: this.expanded ? 'Hepsini Kapat' : 'Hepsini Aç'
        });
    }

    getGroupCount(groupField) {
        return query(this.Model.stockactionlist)
            .groupBy(groupField)
            .toArray().length;
    }*/

    @ViewChild('menuAccordion') accordion: DxAccordionComponent;

    constructor(container: ServiceContainer, private http: NeHttpService, protected activeUserService: IActiveUserService) {
        super(container);

    }

    store: Store;
    mainViewModel: MainViewModel;

    async clientPreScript() {
        this.store = this.activeUserService.SelectedUserStore;
        if (this.store.ObjectDefID.valueOf() !== PharmacyStoreDefinition.ObjectDefID.id) {
            this.WorkListColumns = [
                {
                    caption: ' ',
                    dataField: 'ObjectID',
                    cellTemplate: 'buttonCellTemplate',
                    visible: false,
                    width: 50
                },
                {
                    'caption': i18n("M16866", "İşlem No"),
                    dataField: 'StockActionID',
                    width: 80,
                    allowSorting: true
                },
                {
                    'caption': i18n("M12616", "Depo Adı"),
                    dataField: 'Store',
                    width: 250,
                    allowSorting: true
                },
                {
                    'caption': i18n("M16818", "İşlem"),
                    dataField: 'StockactionName',
                    width: 250,
                    allowSorting: true
                },
                {
                    'caption': i18n("M17307", "Karşı Depo Adı"),
                    dataField: 'DestinationStore',
                    width: 250,
                    allowSorting: true
                },
                {
                    'caption': i18n("M15131", "Hasta Adı"),
                    dataField: 'PatientName',
                    width: 150,
                    allowSorting: true
                },
                {
                    'caption': i18n("M16838", "İşlem Durumu"),
                    dataField: 'StateName',
                    width: 150,
                    allowSorting: true
                },
                {
                    'caption': i18n("M16886", "İşlem Tarihi"),
                    dataField: 'TransactionDate',
                    width: 150,
                    allowSorting: true

                }
            ];
        }
        this.Model = new LogisticMainViewModel();
        this.Model.workListItems = new Array<WorkListItem>();
        this.Model.StateType = 'UNCOMPLETED';
        this.Model.WorkListCount = 25;
        this.Model.PartialCancel = false;
        this.Model.EHUWait = false;
        this.Model.IsEmergencyMaterial = false;
        this.worklistGroupProp = 'StockactionName';
        this.doSearch();
        this.getMenuList();

    }
    clientPostScript(state: String) {

    }

    txtChange() {
        if (this.searchMenuTxt !== '') {
            let excludeList: Array<MenuDefinition> = Array<MenuDefinition>();
            for (let mc of this.Model.menulist) {
                if (mc.Caption.toUpperCase().includes(this.searchMenuTxt.toUpperCase())) {
                    excludeList.push(mc);
                }
            }
            this.menuList = excludeList;
        } else {
            this.menuList = this.Model.menulist;
        }
    }

    search() {
        this.doSearch();
    }


    public MKYSState: string = 'ALL';
    async doSearch() {
        this.showLoadPanel = true;
        this.LoadPanelMessage = "İşlemler Listeleniyor..";
        let inputDvo = new QueryInputDVO();
        inputDvo.StartDate = this.Model.StartDate;
        inputDvo.EndDate = this.Model.EndDate;
        inputDvo.StockActionId = this.Model.StockActionId;
        inputDvo.TIFId = this.Model.TIFId;
        inputDvo.WorkListCount = this.Model.WorkListCount;
        inputDvo.StateType = this.Model.StateType;
        inputDvo.SelectedWorkListItems = this.selectedWorkListItems;
        inputDvo.StoreID = this.activeUserService.SelectedUserStore.ObjectID;
        inputDvo.MKYSState = this.MKYSState;
        inputDvo.PartialCancel = this.Model.PartialCancel;
        inputDvo.EHUWait = this.Model.EHUWait;
        inputDvo.IsEmergencyMaterial = this.Model.IsEmergencyMaterial;
        let fullApiUrl = 'api/LogisticWorkList/Query';
        await this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                this.showLoadPanel = false;
                let result = <LogisticMainViewModel>res;
                this.Model = result;
                /*this.dataGrid.instance.clearGrouping();
                this.dataGrid.instance.columnOption(this.worklistGroupProp, 'groupIndex', 0);
                this.totalCount = this.getGroupCount(this.worklistGroupProp);*/
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showLoadPanel = false;
            });
    }

    getMenuList() {
        let that = this;
        this.http.get<MenuOutputDVO>('api/LogisticWorkList/GetStockMenuDefinition').then((output: MenuOutputDVO) => {
            that.menuList = output.StockActionMenuItems;
            that.Model.menulist = output.StockActionMenuItems;
            if (output.WorkListSearchItem) {
                that.workListItems = output.WorkListSearchItem;
            }
            that.Model.selectedWorkListItems = output.WorkListSearchItem;
            that.definitionMenuItems = output.StockDefinitionMenuItems;
        });
    }

    async StockActionIDInfo_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.search();
        }
    }
    async TIFIDInfo_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.search();
        }
    }


    selectStockAction(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.select(e);
        }
    }


    async select(value: any): Promise<void> {

        this.showLoadPanel = true;
        this.LoadPanelMessage = "İşlem Yükleniyor..";
        await this.http.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + value.data.ObjectID).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;
            this.accordion.instance.collapseItem(0);
            /*this.patientInfoCollapseAttr = 0;
            this.btnCollapse();*/
        }).then(() => {
            this.patientInfoCollapseAttr = 0;
            this.btnCollapse();
            this.showLoadPanel = false;
        }).catch(error => {
            this.showLoadPanel = false;
        });
    }

    changed(e: any): void {
        alert(e);
    }

    async onItemClicked(e: any): Promise<void> {
        let menu: MenuDefinition = <MenuDefinition>e;
        this.http.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetNewObjectDynamicComponentInfo?ObjectDefName=' + menu.ObjectDefinitionName,
            DynamicComponentInfoDVO).then((result: DynamicComponentInfoDVO) => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModuleName = result.ModuleName;
                compInfo.ModulePath = result.ModulePath;
                compInfo.InputParam = this.store;
                this.componentInfo = compInfo;

                this.accordion.instance.collapseItem(0);
            }).then(() => {
                this.patientInfoCollapseAttr = 0;
                this.btnCollapse();
            }).catch(error => {
            });
    }

    dynamicComponentActionExecuted(event: any) {
        if (event.Name === "ToFix") {
            this.openFixSteateObject(this.componentInfo.objectID);
        } else {
            this.accordion.instance.expandItem(0);
            this.patientInfoCollapseAttr = 1;
            this.btnCollapse();
            this.doSearch();
        }
    }


    async openFixSteateObject(objectID: any): Promise<void> {

        this.showLoadPanel = true;
        this.LoadPanelMessage = "İşlem Yükleniyor..";
        await this.http.get<DynamicComponentInfoDVO>('api/LogisticWorkList/GetDynamicComponentInfo?ObjectId=' + objectID).then((result: DynamicComponentInfoDVO) => {
            let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
            compInfo.ComponentName = result.ComponentName;
            compInfo.ModuleName = result.ModuleName;
            compInfo.ModulePath = result.ModulePath;
            compInfo.objectID = result.objectID;
            this.componentInfo = compInfo;
            //this.accordion.instance.collapseItem(0);
            /*this.patientInfoCollapseAttr = 0;
            this.btnCollapse();*/
        }).then(() => {
            //this.patientInfoCollapseAttr = 0;
            //this.btnCollapse();
            this.showLoadPanel = false;
        }).catch(error => {
            this.showLoadPanel = false;
        });
    }



    onRowPrepared(e: any): void {
        if (e.rowType == 'data' && e.data != null) {

            if (e.data.colorEnum != null && e.rowElement.firstItem() != null) {

                let colorEnum: WorkListResultColorEnum = e.data.colorEnum;

                if (colorEnum.Value === WorkListResultColorEnum.red) {
                    e.rowElement.firstItem().style.backgroundColor = '#DC143C';
                    e.rowElement.firstItem().style.color = '#F8F8FF';
                }
                if (colorEnum.Value === WorkListResultColorEnum.white) {
                    e.rowElement.firstItem().style.backgroundColor = '#ffffff';
                    e.rowElement.firstItem().style.color = '#000000';
                }
            }
        }
    }

}
