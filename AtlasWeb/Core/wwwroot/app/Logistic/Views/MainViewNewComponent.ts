//$F07DF1EF
import { Component, OnInit, HostListener, EventEmitter, OnDestroy, Input } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { MainViewModel, CriticalStockLevelTypeEnum, TabTreeModel } from '../Models/MainViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Stock, MaterialTreeDefinition, UserOptionType } from 'NebulaClient/Model/AtlasClientModel';
import { UserHelper } from "app/Helper/UserHelper";
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { TTException } from "NebulaClient/Utils/Exceptions/TTException";
import { SystemMessageService } from "ObjectClassService/SystemMessageService";
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { Headers, RequestOptions } from '@angular/http';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import ArrayStore from 'devextreme/data/array_store';
import { QueryInputDVO, LogisticDashboardViewModel } from '../Models/LogisticDashboardViewModel';
import { ModalActionResult, ModalInfo } from 'app/Fw/Models/ModalInfo';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { IModalService } from 'app/Fw/Services/IModalService';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';



@Component({
    selector: "hvl-new-main-view",
    inputs: ['Model'],
    templateUrl: './MainViewNewComponent.html',
    styles: [`
        .activeTab {
            background-color:#0088CC !important;
            color: white !important;
            font-weight:600 !important;
        }
    `]
})

export class MainViewNewComponent extends BaseComponent<MainViewModel> implements OnInit, OnDestroy, IDestroyEvent {
    dataSource: string[];
    constructor(private sideBarMenuService: ISidebarMenuService, container: ServiceContainer, private modalService: IModalService,
        private http: NeHttpService, protected activeUserService: IActiveUserService, protected helpMenuService: HelpMenuService, ) {
        super(container);
    }

    @HostListener('window:keydown.f1', ['$event'])
    onKeyDown(event: KeyboardEvent) {
        const formName = this.constructor.name;
        if (formName && helpFormModuleMap.has(formName) === true) {
            const helpFileName = helpFormModuleMap.get(formName);
            const helpService: IHelpService = ServiceLocator.Injector.get(IHelpService);
            helpService.showHelp(helpFileName);
            return false;
        }
    }

    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    public hasRoleForPrescriptionApproval: boolean = false;

    public store: Store;
    public storeName: string;
    public hasRoleDashboard: boolean;
    public hasRoleMkysIntegration: boolean;
    public hasRoleSupplyRequestManager: boolean;
    public hasRoleLogisticAddAndUpdate: boolean;
    public hasRoleStockWorkList: boolean;
    public hasRoleDefinitions: boolean;
    public boolStore: boolean = false;
    public selecttableStores: Array<Store>;
    public criticalStockLevelOfItems: Array<Stock.GetCriticalStockLevelsNQL_Class>;
    public filteredCriticalStockLevelOfItems: Array<Stock.GetCriticalStockLevelsNQL_Class>;
    public InheldStockLevelOfItems: Array<Stock.GetCriticalStockLevelsNQL_Class>;
    public SelectedMaterialTree: Array<Guid>;
    public checkBoxValue: boolean = true;
    public years: number[] = [];
    public tabList: Array<any> = [
        {
            id: 0,
            text: 'Uyarılar',
            closable: false,
            selected: true,
            isVisibleKey: 'warnings'
        }
    ]
    public tabVisibility: any = {};
    public tabHidden: any = {};
    public tabItems: Array<any> = [];

    async clientPreScript() {
        this.store = this.activeUserService.SelectedUserStore;
        this.getUserConfigs();
        this.getMenu();
    }

    clientPostScript(state: String) {

    }


    public StoreID;
    @Input() set SelectedMainStore(value: any) {
        if (value != null && value != undefined)
            this.StoreID = value.ObjectID;
    }
    get SelectedMainStore(): any {
        return this.StoreID;
    }



    async ngOnInit() {
        this.closeAllTabs();
        if (this.activeUserService.SelectedUserStore === undefined) {
            this.activeUserService.SelectedUserStore = await this.selecetStore();
        }
        this.store = this.activeUserService.SelectedUserStore;
        this.storeName = this.store.Name;
        this.updateAccountTermSelectBox();
        this.getMaterialExpirationShownOnTab();
        this.getRoleControlMain();
        this.getCriticalStockLevels();
        this.FillMaterialTreeForStock();
        this.AddHelpMenu();

        for (var i = 0; i < 10; i++) {
            this.years.push(DateTime.now.year - i);
        }
        this.getPinnedTabs();
    }

    getMenu() {
        this.http.get('/api/LogisticWorkList/GetNewStockMenuDefinition').then(p => {
            if (p) {
                this.tabItems = p as Array<any>;
            }
        }).catch(e => {
            ServiceLocator.MessageService.showError('Menü getirilemedi');
        })
    }

    getUserConfigs() {
        this.http.get('/api/EntryOperation/GetUserConfig?optionType=' + UserOptionType.StockMenuPin.Value).then(p => {
            var response: any = p as any;
            if (response && response.Value) {
                var pinnedTabKeys = response.Value.split(',');
                for (var key of pinnedTabKeys) {
                    this.pinItemKey(key);
                }
            }
        }).catch(e => {
            ServiceLocator.MessageService.showError("Kullanıcı ayarları getirilemedi.");
        });
    }

    public showMaterialMultiSelectForm: boolean = false;
    openMaterialExpirationDateInfoForm() {
        this.showMaterialMultiSelectForm = true;
    }

    async setStoreClick() {
        this.activeUserService.SelectedUserStore = await this.selecetStore();
        this.store = this.activeUserService.SelectedUserStore;
        this.storeName = this.store.Name;
        this.updateAccountTermSelectBox();
        this.activeUserService.onStoreChangeEvent.emit();

        this.getMaterialExpirationShownOnTab();
        this.getRoleControlMain();
        this.getCriticalStockLevels();
        this.FillMaterialTreeForStock();
        this.AddHelpMenu();



    }
    costActionAccountingTerm: any;
    accountingTermObjId: any;
    activeAccountingTerm: any;
    async updateAccountTermSelectBox() {
        let inputDvo = new QueryInputDVO();
        inputDvo.Store = this.store.ObjectID.toString();
        let that = this;
        let fullApiUrl: string = 'api/LogisticDashboard/Query3';
        this.http.post(fullApiUrl, inputDvo).then((res) => {
            let result = <LogisticDashboardViewModel>res;
            if (result && result.costActionAccountingTerm) {
                that.costActionAccountingTerm = result.costActionAccountingTerm;
                that.accountingTermObjId = result.activeCostActionAccountingTerm != null ? result.activeCostActionAccountingTerm.ObjId.toString() : "";
                that.activeAccountingTerm = result.activeCostActionAccountingTerm;
            } else {
                that.costActionAccountingTerm = new Array<any>();
            }
        });
    }

    onYearChanged(e) {

    }

    pinItemKey(key) {
        for (var item of this.tabItems) {
            if (item.isVisibleKey == key) {
                item.pinned = !item.pinned;
            }
            if (item.items) {
                for (var innerItem of item.items) {
                    if (innerItem.isVisibleKey == key) {
                        innerItem.pinned = !innerItem.pinned;
                    }
                }
            }
        }
    }

    pinItem(id) {
        for (var item of this.tabItems) {
            if (item.id == id) {
                item.pinned = !item.pinned;
            }
            if (item.items) {
                for (var innerItem of item.items) {
                    if (innerItem.id == id) {
                        innerItem.pinned = !innerItem.pinned;
                    }
                }
            }
        }
    }



    async selecetStore(): Promise<Store> {
        let getStore: Store;
        this.selecttableStores = await UserHelper.UseFirstUserResourcesStores;

        if (this.selecttableStores.length === 1) {
            getStore = this.selecttableStores[0];
            this.boolStore = true;
        }
        else {
            let mSelectForm: TTVisual.MultiSelectForm = new TTVisual.MultiSelectForm();
            for (let selecetedStore of this.selecttableStores) { mSelectForm.AddMSItem(selecetedStore.Name, selecetedStore.ObjectID.toString(), selecetedStore); }
            let mkey: string = await mSelectForm.GetMSItem(this, i18n("M16899", "İşlem Yapılacak Depoyu Seçiniz"), true);
            if (String.isNullOrEmpty(mkey))
                throw new TTException(await SystemMessageService.GetMessageV2(249, i18n("M16944", "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz.")));
            getStore = mSelectForm.MSSelectedItemObject as Store;
        }

        return getStore;
    }

    getPinnedTabs() {
        for (var tab of this.tabItems) {
            if (tab.pinned) {
                this.tabList.push({
                    id: tab.id,
                    text: tab.text,
                    closable: true,
                    selected: false,
                    isVisibleKey: tab.isVisibleKey
                });
            }
            if (tab.items) {
                for (var childTab of tab.items) {
                    if (childTab.pinned) {
                        this.tabList.push({
                            id: childTab.id,
                            text: childTab.text,
                            closable: true,
                            selected: false,
                            isVisibleKey: childTab.isVisibleKey
                        });
                    }
                }
            }
        }
    }

    private AddHelpMenu() {

        //if (this.hasRoleForPrescriptionApproval === true) {
        let colorPrescriptionForApproval = new DynamicSidebarMenuItem();
        colorPrescriptionForApproval.key = 'colorPrescriptionForApproval';
        colorPrescriptionForApproval.icon = 'ai ai-recete-onay';
        colorPrescriptionForApproval.label = 'Reçete Onay';
        colorPrescriptionForApproval.componentInstance = this.helpMenuService;
        colorPrescriptionForApproval.clickFunction = this.helpMenuService.openColorPrescriptionForApproval_Ecz;
        this.sideBarMenuService.addMenu('YardimciMenu', colorPrescriptionForApproval);
        //}
    }

    public RemoveMenuFromHelpMenu(): void {


        this.sideBarMenuService.removeMenu('colorPrescriptionForApproval');
    }

    SelectBoxChange(data: any) {
        this.store = data.itemData;
        this.activeUserService.SelectedUserStore = this.store;
    }

    async getRoleControlMain() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MainView/GetRoleControlMain';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <MainViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.hasRoleStockWorkList = that.Model.hasRoleStockWorkList;
                    that.hasRoleDefinitions = that.Model.hasRoleDefinitions;
                    that.hasRoleDashboard = that.Model.hasRoleDashboard;
                    that.hasRoleMkysIntegration = that.Model.hasRoleMkysIntegration;
                    that.hasRoleSupplyRequestManager = that.Model.hasRoleSupplyRequestManager;
                    that.hasRoleLogisticAddAndUpdate = that.Model.hasRoleLogisticAddAndUpdate;

                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    public showMaterialExpirationShownOnTab: boolean = false;

    async getMaterialExpirationShownOnTab() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MaterialExpirationDateInfoService/getMaterialExpirationShownOnTab';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <boolean>res;
                that.showMaterialExpirationShownOnTab = result;
                that.showMaterialExpirationShownOnTab = true;
                that.tabVisibility.warnings = true;
                that.tabHidden.warnings = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    public getCriticalStockLevels() {
        let that = this;
        let fullApiUrl = 'api/LogisticDashboard/GetCriticalStockLevels?storeObjectID=' + this.store.ObjectID;
        this.http.get<Array<Stock.GetCriticalStockLevelsNQL_Class>>(fullApiUrl)
            .then((res) => {
                this.criticalStockLevelOfItems = res;
                this.InheldStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.Inheld > 0);
                this.onStockLevelTypeChanged(this.criticalStockLevelTypeItem);
                this.onSelectedMaterialTreeChanged(this.criticalStockLevelTypeItem);
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    public refreshStockLevelButtonClick() {
        this.getCriticalStockLevels();
    }
    onValueChanged(data: any) {
        this.onStockLevelTypeChanged(this.criticalStockLevelTypeItem);
        this.onSelectedMaterialTreeChanged(this.criticalStockLevelTypeItem);
    }

    public onStockLevelTypeChanged(event: any) {
        if (this.checkBoxValue == true) {
            if (event != null && event.value != null) {
                switch (event.value) {
                    case CriticalStockLevelTypeEnum.GetStockLevelUnderMin:
                        this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems.filter(x => x.Inheld < x.MinimumLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelOverCritical:
                        this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems.filter(x => x.Inheld > x.CriticalLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelUnderCritical:
                        this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems.filter(x => x.Inheld < x.CriticalLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelOverMax:
                        this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems.filter(x => x.Inheld > x.MaximumLevel);
                        break;
                }
                this.criticalStockLevelTypeItem = event;
            }
            else {
                this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems;
                this.criticalStockLevelTypeItem = event;
            }
        } else {
            if (event != null && event.value != null) {
                switch (event.value) {
                    case CriticalStockLevelTypeEnum.GetStockLevelUnderMin:
                        this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.Inheld < x.MinimumLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelOverCritical:
                        this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.Inheld > x.CriticalLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelUnderCritical:
                        this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.Inheld < x.CriticalLevel);
                        break;
                    case CriticalStockLevelTypeEnum.GetStockLevelOverMax:
                        this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.Inheld > x.MaximumLevel);
                        break;
                }
                this.criticalStockLevelTypeItem = event;
            }
            else {
                this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems;
                this.criticalStockLevelTypeItem = event;
            }
        }
    }
    onSelectedMaterialTreeChanged(data) {
        if (this.checkBoxValue == true) {
            if (data != null && data.value != null) {
                this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems.filter(x => x.MaterialTree == data.value);
                this.criticalStockLevelTypeItem = data;
            }
            else {
                this.filteredCriticalStockLevelOfItems = this.InheldStockLevelOfItems;
                this.criticalStockLevelTypeItem = data;
            }
        } else {
            if (data != null && data.value != null) {
                this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.MaterialTree == data.value);
                this.criticalStockLevelTypeItem = data;
            }
            else {
                this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems;
                this.criticalStockLevelTypeItem = data;
            }
        }

    }
    public criticalStockLevelTypeItem: any;

    public CriticalStockLevelTypeItems = CriticalStockLevelTypeEnum.Items;
    public criticalStockLevelGridColumns = [
        {
            caption: i18n("M18545", "Malzeme"),
            dataField: 'Name',
            allowEditing: false,
            width: 600
        },
        {
            caption: i18n("M12625", "Depo Mevcudu"),
            dataField: 'Inheld',
            allowEditing: false
        },
        {
            caption: i18n("M22502", "Belirlenen Minimum Seviye"),
            dataField: 'MinimumLevel',
            headerCellTemplate: 'titleHeaderTemplateMini',
            allowEditing: false

        },
        {
            caption: i18n("M22502", "Belirlenen Kritik Seviye"),
            dataField: 'CriticalLevel',
            headerCellTemplate: 'titleHeaderTemplateKrit',
            allowEditing: false
        },
        {
            caption: i18n("M22501", "Belirlenen Maximum Seviye"),
            dataField: 'MaximumLevel',
            headerCellTemplate: 'titleHeaderTemplateMax',
            allowEditing: false
        }
    ];


    public MaterialTreeForStock;
    async FillMaterialTreeForStock() {
        try {

            let that = this;
            let apiUrlForPASearchUrl: string = '/api/LogisticDashboard/FillMaterialTreeForStock';
            let body = "";
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });

            await this.http.post<any>(apiUrlForPASearchUrl, body).then(response => {
                let result = response;
                if (result) {
                    this.MaterialTreeForStock = result;
                }
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }

        catch (ex) {
            ServiceLocator.MessageService.showError(ex);
        }

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

    public selectItem(e) {
        if (!e.itemData.clickable) {
            return;
        }
        this.selectActiveTab(e.itemData.id);
        if (this.tabList.filter(p => p.id == e.itemData.id).length == 0) {
            this.tabList.push({
                id: e.itemData.id,
                text: e.itemData.text,
                closable: true,
                selected: true,
                isVisibleKey: e.itemData.isVisibleKey
            });
        }
        this.openTab(e.itemData);
        this.btnCollapse();
    }

    tabClose(item) {
        var firstTab = this.tabList.filter(p => p.id == 0)[0];
        if (item.selected) {
            this.openTab(firstTab);
        }
        this.tabList = this.tabList.filter(p => p.id != item.id);
    }

    tabListed(item) {
        return this.tabList.filter(p => p.id == item.id).length > 0;
    }

    openTab(item) {
        this.closeAllTabs();
        let exists = this.tabListed(item);
        if (exists) {
            this.tabHidden[item.isVisibleKey] = false;
        }
        if (!this.tabVisibility[item.isVisibleKey]) {
            this.tabVisibility[item.isVisibleKey] = true;
        }
        this.selectActiveTab(item.id);
    }

    private selectActiveTab(id) {
        this.tabList.forEach(p => {
            p.selected = id === p.id;
        });
    }

    private closeAllTabs() {
        this.tabHidden.warnings = true;
        this.tabItems.forEach(p => {
            let exists = this.tabListed(p);
            if (exists) {
                this.tabHidden[p.isVisibleKey] = true;
            } else {
                this.tabVisibility[p.isVisibleKey] = false;
            }
            if (p.items) {
                p.items.forEach(t => {
                    let exists = this.tabListed(t);
                    if (exists) {
                        this.tabHidden[t.isVisibleKey] = true;
                    } else {
                        this.tabVisibility[t.isVisibleKey] = false;
                    }
                    if(t.items) {
                        t.items.forEach(k => {
                            let exists = this.tabListed(k);
                            if (exists) {
                                this.tabHidden[k.isVisibleKey] = true;
                            } else {
                                this.tabVisibility[k.isVisibleKey] = false;
                            }
                        })
                    }
                })
            }
        });
    }


    onToolbarPreparing(e) {
        e.toolbarOptions.items.unshift({
            location: 'after',
            widget: 'dxButton',
            options: {
                icon: 'fa fa-file-text-o',
                onClick: this.printMaterialStockLevelReport.bind(this)
            }
        });
    }

    public async printMaterialStockLevelReport(): Promise<ModalActionResult> {
        var data = {
            StoreObjectId: this.store,
        }
        let reportData: DynamicReportParameters = {

            Code: 'MATERIALSTOCKLEVELREPORT',
            ReportParams: { StoreObjectId: data.StoreObjectId.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, null);
            componentInfo.ParentInstance = this;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Stok Seviyeleri RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onRowPreparedTransactionList(e: any) {
        if (e.rowElement.firstItem() != undefined) {
            if (e.rowElement.firstItem().cells[0].innerText !== "Malzeme" && e.rowElement.firstItem().cells[1].innerText !== "Depo Mevcudu"
                && e.rowElement.firstItem().cells[2].innerText !== "Belirlenen Minimum Seviye" && e.rowElement.firstItem().cells[3].innerText !== "Belirlenen Kritik Seviye"
                && e.rowElement.firstItem().cells[4].innerText !== "Belirlenen Maximum Seviye") {
                let DM: number = Number(e.rowElement.firstItem().cells[1].innerText);
                let MinS: number = Number(e.rowElement.firstItem().cells[2].innerText);
                let MaxS: number = Number(e.rowElement.firstItem().cells[4].innerText);
                let KritS: number = Number(e.rowElement.firstItem().cells[3].innerText);
                if (DM >= MaxS) {
                    e.rowElement.firstItem().cells[1].bgColor = '#7eb0ed';
                    e.rowElement.firstItem().cells[1].style.color = 'white';
                }
                if (DM < MaxS && DM > KritS) {
                    e.rowElement.firstItem().cells[1].bgColor = '#00b383';
                    e.rowElement.firstItem().cells[1].style.color = 'white';
                }
                if (DM <= KritS && DM > MinS) {
                    e.rowElement.firstItem().cells[1].bgColor = '#800000';
                    e.rowElement.firstItem().cells[1].style.color = 'white';
                }
                if (DM <= MinS) {
                    e.rowElement.firstItem().cells[1].bgColor = '#f15d5d';
                    e.rowElement.firstItem().cells[1].style.color = 'white';
                }
            }
        }
    }

    ngOnDestroy() {
        this.OnDestroy.emit();
    }
}