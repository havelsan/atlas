//$F07DF1EF
import { Component, OnInit, HostListener, EventEmitter } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { MainViewModel, CriticalStockLevelTypeEnum } from '../Models/MainViewModel';
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



@Component({
    selector: "hvl-main-view",
    inputs: ['Model'],
    templateUrl: './MainView.html'
})

export class MainView extends BaseComponent<MainViewModel> implements OnInit {
    dataSource: string[];
    constructor(private sideBarMenuService: ISidebarMenuService, container: ServiceContainer, private http: NeHttpService, protected activeUserService: IActiveUserService, protected helpMenuService: HelpMenuService, ) {
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
    newScreen: number;
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

    async clientPreScript() {
        this.store = this.activeUserService.SelectedUserStore;
        this.getUserConfigs();
    }

    clientPostScript(state: String) {

    }

    getUserConfigs() {
        this.http.get('/api/EntryOperation/GetUserConfig?optionType=' + UserOptionType.StockMenu.Value).then(p => {
            var response: any = p as any;
            if (response == null) {
                this.newScreen = 2;
            }
            else {
                if (response.Value == null) {
                    this.newScreen = 2;
                } else {
                    this.newScreen = parseInt(response.Value);
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



    async ngOnInit() {

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
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    public onStockLevelTypeChanged(event: any) {
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
    onSelectedMaterialTreeChanged(data) {
        if (data != null && data.value != null) {
            this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems.filter(x => x.MaterialTree == data.value);
            this.criticalStockLevelTypeItem = data;
        }
        else {
            this.filteredCriticalStockLevelOfItems = this.criticalStockLevelOfItems;
            this.criticalStockLevelTypeItem = data;
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
            allowEditing: false
        },
        {
            caption: i18n("M22502", "Belirlenen Kritik Seviye"),
            dataField: 'CriticalLevel',
            allowEditing: false
        },
        {
            caption: i18n("M22501", "Belirlenen Maximum Seviye"),
            dataField: 'MaximumLevel',
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





}