//$F07DF1EF
import { Component, OnInit, HostListener, EventEmitter, OnDestroy, ViewChild } from '@angular/core';
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
import { DxTreeViewComponent } from 'devextreme-angular';



@Component({
    selector: "new-report-view",
    inputs: ['Model'],
    templateUrl: './LogisticNewReportComponent.html',
    styles: [`
        .activeTab {
            background-color:#0088CC !important;
            color: white !important;
            font-weight:600 !important;
        }
    `]
})

export class LogisticNewReportComponent extends BaseComponent<MainViewModel> implements OnInit, OnDestroy, IDestroyEvent {
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
    public SelectedMaterialTree: Array<Guid>;
    public years: number[] = [];
    public tabList: Array<any> = [];
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

    async ngOnInit() {

        if (this.activeUserService.SelectedUserStore === undefined) {
            this.activeUserService.SelectedUserStore = await this.selecetStore();
        }
        this.store = this.activeUserService.SelectedUserStore;
        this.storeName = this.store.Name;
        this.closeAllTabs();
        for (var i = 0; i < 10; i++) {
            this.years.push(DateTime.now.year - i);
        }
    }

    getMenu() {
        this.http.get('/api/LogisticWorkList/GetStockReportMenuDefinition').then(p => {
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
        this.activeUserService.onStoreChangeEvent.emit();
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
        this.selecttableStores = await UserHelper.UseUserResourcesStores;

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
        // var firstTab = this.tabList.filter(p => p.id == 0)[0];
        // if (item.selected) {
        //     this.openTab(firstTab);
        // }
        this.tabList = this.tabList.filter(p => p.id != item.id);
        this.closeAllTabs();
        if(this.tabList.length > 0) {
            this.openTab(this.tabList[0]);
        }
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
        if(!this.tabVisibility[item.isVisibleKey])
        {
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
                        t.items.forEach(z => {
                            let exists = this.tabListed(z);
                            if (exists) {
                                this.tabHidden[z.isVisibleKey] = true;
                            } else {
                                this.tabVisibility[z.isVisibleKey] = false;
                            }
                        });
                    }
                })
            }
        });
    }

    ngOnDestroy() {
        this.OnDestroy.emit();
    }
}