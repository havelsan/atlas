//$F07DF1EF
import { Component, OnInit, HostListener, EventEmitter, Input } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { MainViewModel, CriticalStockLevelTypeEnum } from '../Models/MainViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Stock, MaterialTreeDefinition } from 'NebulaClient/Model/AtlasClientModel';
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
import { Color } from 'devexpress-dashboard/model';





@Component({
    selector: "hvl-old-main-view",
    inputs: ['Model'],
    templateUrl: './MainViewOldComponent.html',
    styles: [`.defColMd1 { width: 2%; }    
    .defColMd11 { width: 98%; } `]
})

export class MainViewOldComponent extends BaseComponent<MainViewModel> implements OnInit {
    dataSource: string[];
    constructor(private sideBarMenuService: ISidebarMenuService, container: ServiceContainer, private http: NeHttpService, protected activeUserService: IActiveUserService, protected helpMenuService: HelpMenuService,) {
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

    async clientPreScript() {
        this.store = this.activeUserService.SelectedUserStore;
    }

    clientPostScript(state: String) {

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




    async ngOnInit() {

        this.closeAllTabs();
        //let url: string = '/api/Account/HasRole';
        //let input = { 'roleID': new Guid('b9b1be5e-7b6b-42ef-b031-b7f8323f019d') };
        //let result = await this.http.post<boolean>(url, input);
        //this.hasRoleForPrescriptionApproval = result;

        if (this.activeUserService.SelectedUserStore === undefined) {
            this.activeUserService.SelectedUserStore = await this.selecetStore();
        }

        this.store = this.activeUserService.SelectedUserStore;
        this.storeName = this.store.Name;
        this.getMaterialExpirationShownOnTab();
        this.getRoleControlMain();
        this.getCriticalStockLevels();
        this.FillMaterialTreeForStock();

        this.AddHelpMenu();
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


    private collapseAttr = 0;
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
    public collapseSelectedDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "hidden";
        }
        return "col-md-2";
    }
    public collapseSelectedHiddenDivProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-1 defColMd1 col-sm-12 col-xs-12";
        }
        return "hidden";

    }
    public collapsedPanelProperties(): string {

        if (this.collapseAttr == 1) {
            return "col-md-11 defColMd11 col-sm-12 col-xs-12";
        }
        return "col-md-11";

    }

    public definitionPopupVisible: boolean = false;
    public tabHidden: any = {};
    public tabVisibility: any = {};
    public tabList: Array<any>;
    public treeList: Array<any> = [
        {
            id: "1",
            text: "İlaç Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasDrugDefinitionBaseForm"
        },
        {
            id: "2",
            text: "Sarf Edilebilir Malzeme Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasConsumableMaterialDefinitionBaseForm"
        },
        {
            id: "3",
            text: "Tüketim Malzeme Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasDepletionMaterialDefinitionBaseForm"
        },
        {
            id: "4",
            text: "Firma Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasSupplierandproducerdef"
        },
        {
            id: "5",
            text: "Malzeme Grubu Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasMaterialtreedefinition"
        },
        {
            id: "6",
            text: "Komisyon Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasCommisiondefinition"
        },
        {
            id: "7",
            text: "ATC Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasAtcdefinition"
        },
        {
            id: "8",
            text: "Direktif Zaman Çizelsi",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasHospitalTimeSchedule"
        },
        {
            id: "9",
            text: "İlaç Kullanım Şekli Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasRouteOfAdmineDef"
        },
        {
            id: "10",
            text: "Ölçü Birimi Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasDistributionDefinition"
        },
        {
            id: "11",
            text: "Order ŞablonTanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasOrderTemplateDefinition"
        },
        {
            id: "12",
            text: "Etken Madde Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasActiveIngredientDefinition"
        }, {
            id: "13",
            text: "Cep Depo Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasSubStoreDefinition"
        }, {
            id: "14",
            text: "Ana Depo Tanımları",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasMainStoreDefinition"
        }, {
            id: "15",
            text: "Order Tatil Günü Tanımı",
            closable: true,
            selected: false,
            clickable: true,
            isVisibleKey: "hasOrderRestDayDefinition"
        }
    ];

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
    private closeAllTabs() {
        this.tabHidden.warnings = true;
        this.treeList.forEach(p => {
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
                    if (t.items) {
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

    openPopup() {
        this.definitionPopupVisible = true;
    }

    tabListed(item) {
        return this.treeList.filter(p => p.id == item.id).length > 0;
    }
    private selectActiveTab(id) {
        this.treeList.forEach(p => {
            p.selected = id === p.id;
        });
    }
    tabClose(item) {
        this.tabList = this.treeList.filter(p => p.id != item.id);
        this.closeAllTabs();
        if (this.tabList.length > 0) {
            this.openTab(this.tabList[0]);
        }
    }
    public selectItem(e) {
        this.btnCollapse();
        if (!e.itemData.clickable) {
            return;
        }
        this.selectActiveTab(e.itemData.id);
        if (this.treeList.filter(p => p.id == e.itemData.id).length == 0) {
            this.tabList.push({
                id: e.itemData.id,
                text: e.itemData.text,
                closable: true,
                selected: true,
                isVisibleKey: e.itemData.isVisibleKey
            });
        }
        this.openTab(e.itemData);
        this.definitionPopupVisible = false;
    }

    public tabItems = this.tabList;
    selectDefClick() {
        this.definitionPopupVisible = true;
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



}