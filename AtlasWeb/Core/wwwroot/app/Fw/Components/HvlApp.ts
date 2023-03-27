import { Component, ViewChild, AfterViewInit, OnInit, OnDestroy, HostListener, ElementRef, HostBinding, Input } from '@angular/core';
import { Router, NavigationStart, NavigationEnd, ActivatedRouteSnapshot } from '@angular/router';
import { RouteData } from 'Fw/Models/RouteData';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { Subscription, interval } from 'rxjs';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import dxDataGrid from 'devextreme/ui/data_grid';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { MessageService } from 'Fw/Services/MessageService';
import { IActiveComponentRegistryService } from 'Fw/Services/IActiveComponentRegistryService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { LayoutConfigService } from 'app/template/core/services/layout-config.service';
import { ClassInitService } from 'app/template/core/services/class-init.service';
import { DomSanitizer } from '@angular/platform-browser';
import * as objectPath from 'object-path';
import { BehaviorSubject } from 'rxjs';
import { LayoutRefService } from 'app/template/core/services/layout/layout-ref.service';
import { AnimationBuilder, AnimationPlayer, style, animate } from '@angular/animations';
import { ThemeService } from 'app/Fw/Services/ThemeService';
import { QuickActionsMenuService } from 'app/template/content/layout/header/topbar/quick-action/QuickActionsMenuService';
import { QuickActionsMenuItem } from 'app/template/content/layout/header/topbar/quick-action/QuickActionsMenuItem';
import { EReportIndexAuthorizations } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionFormViewModel';
import { AtlasSignalRService } from 'Fw/Services/AtlasSignalRService';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';
import { ChangeDetectorRef } from '@angular/core';

@Component({
    selector: 'hvl-app',
    templateUrl: './HvlApp.html',
    providers: []
})
export class HvlApp implements AfterViewInit, OnInit, OnDestroy {
    CurrentPageTitle: String;

    DisplayItems: DisplayItems = new DisplayItems();

    UserName: String = '';
    IsBusy: Boolean = false;
    MessageCount: number = 0;
    style: any = { 'background-color': '#4276A4' };

    nabizButtonVisible: boolean = false;

    public toggleSidebar: boolean = true;

    isAuthorizedForEDogum: boolean = false;
    isAuthorizedForEAthlete: boolean = false;
    private helpServicedisplayHelpSubscription: Subscription;
    private eNabizButtonSubscription: Subscription;

    private routeChangedSubscription: Subscription;
    private busySubscription: Subscription;
    public UpToDateSearchStr: string;

    //begin metronic
    @HostBinding('class') classes = 'm-grid m-grid--hor m-grid--root m-page';
    @Input() selfLayout: any = 'blank';

    public player: AnimationPlayer;
    // class for the header container
    pageBodyClass$: BehaviorSubject<string> = new BehaviorSubject<string>('');
    @ViewChild('mContentWrapper') contenWrapper: ElementRef;
    @ViewChild('mContent') mContent: ElementRef;
    //end metronic


    constructor(private signalRService: AtlasSignalRService,
        private container: ServiceContainer
        , private authenticationService: IAuthenticationService
        , public router: Router
        , protected httpService: NeHttpService
        , protected modalService: IModalService
        , private componentRegistry: IActiveComponentRegistryService,
        private sideBarMenuService: ISidebarMenuService,
        protected messageService2: MessageService,
        private layoutConfigService: LayoutConfigService,
        private classInitService: ClassInitService,
        private sanitizer: DomSanitizer,
        private configService: LayoutConfigService,
        private layoutRefService: LayoutRefService,
        private animationBuilder: AnimationBuilder,
        private themeService: ThemeService,
        private quickActionsMenuService: QuickActionsMenuService,
        private favoriteService: IFavoriteService,
        private changeRef: ChangeDetectorRef

    ) {
        let that = this;
        this.DisplayItems.IsLoggedIn = false;
        this.UserName = '';
        this.IsBusy = false;


        let test1: QuickActionsMenuItem = {
            Icon: 'fa fa-cog',
            Key: 'Ayarlar',
            Text: 'Ayarlar',
            click: () => { this.openSettings(); }
        };

        this.quickActionsMenuService.addItem(test1);


        this.eNabizButtonSubscription = this.httpService.eNabizButtonSharedService.buttonVisibleObservable.subscribe(
            buttonVisibleObservable => {
                this.nabizButtonVisible = buttonVisibleObservable;
            }
        );

        // set default datagrid options
        // calculateFilterExpression türü string olan tüm sütunlar için türkçe arama işlemini düzeltir
        dxDataGrid.defaultOptions({
            options: {
                allowColumnResizing: true,
                allowColumnReordering: false,
                customizeColumns: function (columns) {
                    columns.forEach((column, index) => {
                        if (column.dataType === 'string') {
                            column.calculateFilterExpression = that.calculateFilterExpression;
                        }
                    });
                }
            }
        });
    }


    public openSettings() {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SettingsView';
            componentInfo.ModuleName = 'SystemModule';
            componentInfo.ModulePath = 'wwwroot/app/System/SystemModule';
            componentInfo.InputParam = null;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Ayarlar Ekranı';
            modalInfo.Width = 500;
            modalInfo.Height = 500;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });

        });
    }

    public ToggleSidebar() {
        this.toggleSidebar = !this.toggleSidebar;
    }

    private calculateFilterExpression(filterValue, selectedFilterOperation, target) {
        let column = this as any;
        let getter = function (data) {
            let dataInner = data[column.dataField];
            if (dataInner != null) {
                let tempData = data[column.dataField].normalize('NFD').replace(/[\u0300-\u036f]/g, '');
                return tempData.normalize('NFD').replace(/ı/g, 'i');
            }
        };
        if (filterValue != null) {
            filterValue = filterValue.normalize('NFD').replace(/[\u0300-\u036f]/g, '');
            filterValue = filterValue.normalize('NFD').replace(/ı/g, 'i');
            return [getter, selectedFilterOperation || 'contains', filterValue];
        }
    }


    public changePassword() {
        this.DisplayItems.isChangePassword = true;
    }
    public ChangePasswordClosing() {
        this.DisplayItems.isChangePassword = false;
    }

    isReportsLoaded: boolean = false;
    RouteChanged(event: any) {
        //let title: String;
        if (event instanceof NavigationStart) {
            this.CurrentPageTitle = undefined;
            let ev: NavigationStart = <NavigationStart>event;


            if (ev.url === '/giris') {
                this.style = { 'background-color': '#4276A4' };
            } else {


                if (this.DisplayItems.IsLoggedIn == false) {
                    if (this.authenticationService.loggedIn()) {
                        this.DisplayItems.IsLoggedIn = true;
                    }
                    if (this.DisplayItems.IsLoggedIn == false) {

                        if (ev.url.lastIndexOf("?showAsAnonymous") > -1) {
                            this.DisplayItems.ShowAsAnonymous = true;
                        }
                        else {
                            this.router.navigate(['giris']);
                        }
                        return;
                    }

                }

                this.UserName = sessionStorage.getItem('UserName');
                this.style = { 'background-color': '#4276A4' };
                this.getAuthorizationsForReports();
            }

            if (ev.url === '/acilis') {
                this.GetUnreadMessage();
                this.GetCanShowUpToDate();
            }



            this.CurrentPageTitle = undefined;
        } else if (event instanceof NavigationEnd) {
            let title: String;
            let urlSegments: Array<string> = event.url.split('/').filter(t => { return t && t !== ''; });
            this.CurrentPageTitle = this.getPageTitle(this.router.routerState.snapshot.root, urlSegments, 0);
        }
    }

    getPageTitle(root: ActivatedRouteSnapshot, urlSegments: Array<string>, depthIndex: number) {
        if (root.url && root.url.length > 0 && root.url[0].path === urlSegments[depthIndex]) {
            if (depthIndex === urlSegments.length - 1 && root.data) {
                return root.data['PageTitle'];
            } else {
                for (let i = 0; i < root.children.length; i++) {
                    return this.getPageTitle(root.children[i], urlSegments, depthIndex + 1);
                }
            }
        } else {
            for (let i = 0; i < root.children.length; i++) {
                return this.getPageTitle(root.children[i], urlSegments, depthIndex);
            }
        }
    }

    @HostListener('window:keydown.alt.g', ['$event'])
    onKeyDownForEnglish(event: any) {
        sessionStorage.setItem('localeId', 'en');
        location.reload(true);
    }

    @HostListener('window:keydown.alt.h', ['$event'])
    onKeyDownForNative(event: any) {
        sessionStorage.setItem('localeId', 'tr');
        location.reload(true);
    }

    @HostListener('window:beforeunload', ['$event'])
    beforeUnloadHander(event) {
        if (this.modifiedComponentExists() === true) {
            const returnMessage = 'Değişiklikleri kaydetmeden devam etmek istiyor musunuz?';
            event.returnValue = returnMessage;
            return returnMessage;
        }
    }

    private modifiedComponentExists(): boolean {

        const activeComponents = this.componentRegistry.activeComponents();
        let isModifiedComponentExists = false;
        for (const componentRef of activeComponents) {
            let boundBaseForm = componentRef.instance as TTVisual.TTBoundFormBase;
            if (boundBaseForm && boundBaseForm.isModified) {
                if (boundBaseForm.isModified() === true) {
                    isModifiedComponentExists = true;
                    break;
                }
            }
        }

        return isModifiedComponentExists;
    }

    public messageReceivedSubsription: Subscription;
    public signalRReceivedSubsription: Subscription;

    async ngOnInit() {
        let that = this;
        this.routeChangedSubscription = this.router.events.subscribe(this.RouteChanged.bind(this));
        this.busySubscription = this.container.Globals.Busy.subscribe((busy) => {
            that.IsBusy = busy;
        });
        this.OpenSignalRConnection();
    }

    public AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let eDogumReportIndexAuthorization = sessionStorage.getItem('eDogumReportIndexAuthorization');
        let eAthleteReportIndexAuthorization = sessionStorage.getItem('eAthleteReportIndexAuthorization');
        let eDriverReportIndexAuthorization = sessionStorage.getItem('eDriverReportIndexAuthorization');
        let ePsychotecnicsReportIndexAuthorization = sessionStorage.getItem('ePsychotecnicsReportIndexAuthorization');
        let eDisabledReportIndexAuthorization = sessionStorage.getItem('eDisabledReportIndexAuthorization');
        if (eDogumReportIndexAuthorization == 'true') {
            let eDogumReportList = new DynamicSidebarMenuItem();
            eDogumReportList.key = 'eDogumReportList';
            eDogumReportList.componentInstance = this;
            eDogumReportList.label = 'e-Doğum Raporları Listeleme';
            eDogumReportList.icon = ' fa fa-child';
            eDogumReportList.clickFunction = this.openEDogumReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDogumReportList);
        }
        if (eAthleteReportIndexAuthorization == 'true') {
            let AthleteReportIndex = new DynamicSidebarMenuItem();
            AthleteReportIndex.key = 'AthleteReportIndex';
            AthleteReportIndex.componentInstance = this;
            AthleteReportIndex.label = 'e-Sporcu Raporları Listeleme';
            AthleteReportIndex.icon = 'fa fa-futbol-o';
            AthleteReportIndex.clickFunction = this.openAthleteReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", AthleteReportIndex);
        }
        if (eDriverReportIndexAuthorization == 'true') {
            let eDriverReportList = new DynamicSidebarMenuItem();
            eDriverReportList.key = 'eDriverReportList';
            eDriverReportList.componentInstance = this;
            eDriverReportList.label = 'e-Sürücü Raporları Listeleme';
            eDriverReportList.icon = 'fa fa-car';
            eDriverReportList.clickFunction = this.openEDriverReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDriverReportList);
        }
        if (ePsychotecnicsReportIndexAuthorization == 'true') {
            let ePsychotecnicReportList = new DynamicSidebarMenuItem();
            ePsychotecnicReportList.key = 'ePsychotecnicReportList';
            ePsychotecnicReportList.componentInstance = this;
            ePsychotecnicReportList.label = 'e-Psikoteknik Raporları Listeleme';
            ePsychotecnicReportList.icon = 'fa fa-address-card';
            ePsychotecnicReportList.clickFunction = this.openEPsychotecnicReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", ePsychotecnicReportList);
        }
        if (eDisabledReportIndexAuthorization == 'true') {
            let eDisabledReportList = new DynamicSidebarMenuItem();
            eDisabledReportList.key = 'eDisabledReportList';
            eDisabledReportList.componentInstance = this;
            eDisabledReportList.label = 'e-Engelli Kurul Hekim İşlemleri';
            eDisabledReportList.icon = 'fa fa-address-card';
            eDisabledReportList.clickFunction = this.openEDisabledReport;
            this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDisabledReportList);
        }
 
        
        let eDriverReportCreate = new DynamicSidebarMenuItem();
        eDriverReportCreate.key = 'eDriverRaportCreate';
        eDriverReportCreate.componentInstance = this;
        eDriverReportCreate.label = 'e-Sürücü Kurul Başvuru Oluşturma';
        eDriverReportCreate.icon = 'fa fa-car';
        eDriverReportCreate.clickFunction = this.openEDriverReportCreate;
        this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDriverReportCreate);

        let eDriverCouncilSecIndex = new DynamicSidebarMenuItem();
        eDriverCouncilSecIndex.key = 'eDriverCouncilSecIndex';
        eDriverCouncilSecIndex.componentInstance = this;
        eDriverCouncilSecIndex.label = 'e-Sürücü Kurul Sekreter Index';
        eDriverCouncilSecIndex.icon = 'fa fa-car';
        eDriverCouncilSecIndex.clickFunction = this.openEDriverReportSecCouncilIndex;
        this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDriverCouncilSecIndex);

        let eDriverCouncilDocIndex = new DynamicSidebarMenuItem();
        eDriverCouncilDocIndex.key = 'eDriverCouncilDocIndex';
        eDriverCouncilDocIndex.componentInstance = this;
        eDriverCouncilDocIndex.label = 'e-Sürücü Kurul Doktor Index';
        eDriverCouncilDocIndex.icon = 'fa fa-car';
        eDriverCouncilDocIndex.clickFunction = this.openEDriverReportDocIndex;
        this.sideBarMenuService.addMenu("SaglikBakanligiRaporlari", eDriverCouncilSecIndex);
    }

    /*public AddAthleteIndexToHelpMenu() {
        this.removeAthleteIndexFromHelpMenu();

    }
    public removeAthleteIndexFromHelpMenu() {
        this.sideBarMenuService.removeMenu('AthleteReportIndex');

    }*/

    public async getAuthorizationsForReports(): Promise<void> {
        let sessionItem = sessionStorage.getItem('eDogumReportIndexAuthorization');
        let sessionControl;

        if (sessionItem == null) {
            sessionControl = false;
        } else {
            sessionControl = true;
        }
        if (sessionControl == false) {
            let fullApiUrl: string = 'api/EpisodeActionService/GetEReportIndexAuthorizations';
            await this.httpService.get(fullApiUrl).then((res: EReportIndexAuthorizations) => {
                if (res.isAuthorizedForEDogum == true) {
                    sessionStorage.setItem('eDogumReportIndexAuthorization', 'true');
                } else {
                    sessionStorage.setItem('eDogumReportIndexAuthorization', 'false');
                }

                if (res.isAuthorizedForEAthlete == true) {
                    sessionStorage.setItem('eAthleteReportIndexAuthorization', 'true');
                } else {
                    sessionStorage.setItem('eAthleteReportIndexAuthorization', 'false');
                }
                if (res.isAuthorizedForEDriver == true) {
                    sessionStorage.setItem('eDriverReportIndexAuthorization', 'true');
                } else {
                    sessionStorage.setItem('eDriverReportIndexAuthorization', 'false');
                }
                if (res.isAuthorizedForEPsychotecnics == true) {
                    sessionStorage.setItem('ePsychotecnicsReportIndexAuthorization', 'true');
                } else {
                    sessionStorage.setItem('ePsychotecnicsReportIndexAuthorization', 'false');
                }
                if (res.isAuthorizedForEDisabled == true) {
                    sessionStorage.setItem('eDisabledReportIndexAuthorization', 'true');
                } else {
                    sessionStorage.setItem('eDisabledReportIndexAuthorization', 'false');
                }
                this.AddHelpMenu();
            }).catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
        }
        else {
            this.AddHelpMenu();

        }

    }

    /*public async getAuthorizationForEDogumReport(): Promise<void> {
        let fullApiUrl: string = 'api/PhysicianApplicationService/GetEDogumReportIndexAuthorization';
        await this.httpService.get(fullApiUrl).then((res: boolean) => {
            if (res == true)
                this.isAuthorizedForEDogum = true;
            else
                this.isAuthorizedForEDogum = false;

            this.AddHelpMenu();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
        this.isAuthorizedForEDogum = false;
    }

    public async getAuthorizationForEAthleteReport(): Promise<void> {
        let fullApiUrl: string = 'api/EpisodeActionService/GetEAthleteReportIndexAuthorization';
        await this.httpService.get(fullApiUrl).then((res: boolean) => {
            if (res == true)
                this.isAuthorizedForEAthlete = true;
            else
                this.isAuthorizedForEAthlete = false;

            this.AddAthleteIndexToHelpMenu();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
        this.isAuthorizedForEAthlete = false;
    }*/

    public RemoveMenuFromHelpMenu() {
        this.sideBarMenuService.removeMenu('eDogumReportList');
        this.sideBarMenuService.removeMenu('AthleteReportIndex');
        this.sideBarMenuService.removeMenu('eDriverReportList');
        this.sideBarMenuService.removeMenu('ePsychotecnicReportList');
        this.sideBarMenuService.removeMenu('eDriverRaportCreate');
        this.sideBarMenuService.removeMenu('eDriverCouncilDocIndex');
        this.sideBarMenuService.removeMenu('eDriverCouncilSecIndex');
    }

    OpenSignalRConnection() {
        if (!this.signalRService.connectionExists) {
            this.signalRService.startConnection();
            this.signalRReceivedSubsription = this.signalRService.newMessageHandle.subscribe(m => {
                this.DisplayItems.SystemMessage = m;
                this.DisplayItems.IsSystemMessage = true;
                this.GetUnreadMessage();
            });
        }
    }


    SystemMessageClosing() {
        this.DisplayItems.IsSystemMessage = false;
    }
    CloseSystemMessage() {
        this.DisplayItems.IsSystemMessage = false;
    }

    ngOnDestroy() {

        this.signalRService.stopConnection();
        if (this.signalRReceivedSubsription) {
            this.signalRReceivedSubsription.unsubscribe();
            this.signalRReceivedSubsription = null;
        }

        let httpPrintServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/CloseMonitor';
        this.httpService.post(httpPrintServiceUrl, null);
        if (this.routeChangedSubscription != null) {
            this.routeChangedSubscription.unsubscribe();
            this.routeChangedSubscription = null;
        }
        if (this.busySubscription != null) {
            this.busySubscription.unsubscribe();
            this.busySubscription = null;
        }
        if (this.helpServicedisplayHelpSubscription) {
            this.helpServicedisplayHelpSubscription.unsubscribe();
            this.helpServicedisplayHelpSubscription = null;
        }
        this.authenticationService.logout();
    }


    getChromeVersion() {
        var raw = navigator.userAgent.match(/Chrom(e|ium)\/([0-9]+)\./);
        return raw ? parseInt(raw[2], 10) : navigator.userAgent;
    }

    feedBackTry: number = 0;
    async loginFeedback() {
        this.feedBackTry++;
        let pingStartTime = new Date().getTime();
        let serverInfo = await this.httpService.get<ServerInfo>('/api/Account/ServerInfo');
        let pingEndTime = new Date().getTime();
        let ping = Math.abs(pingEndTime - pingStartTime);

        if (ping > 1000 && this.feedBackTry < 2) {
            setTimeout(() => {
                this.loginFeedback();
            }, 10000);
            return;
        }

        this.feedBackTry = 0;

        let feedBack: any = {};
        feedBack.ChromeVersion = this.getChromeVersion();
        feedBack.CPU = navigator["hardwareConcurrency"];
        feedBack.Height = window.screen.height

        let date = new Date();
        feedBack.JSTime = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate() + " " + date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
        feedBack.Ping = ping;
        feedBack.RAM = navigator["deviceMemory"];
        feedBack.ServerTime = serverInfo.ServerTime;
        feedBack.SoftwareVersion = document.title;
        feedBack.Width = window.screen.width
        feedBack.IP = serverInfo.IPAddress;
        feedBack.UserName = sessionStorage.UserName;
        sessionStorage.setItem('feedback', JSON.stringify(feedBack));

        this.httpService.post<any>('/api/Account/SendFB', feedBack).then(
            x => {

            }
        );



    }

    fbSubscription: Subscription;
    //PageRefresh && After Login
    loginJobs() {
        this.templateInit();
        this.AddHelpMenu();
        this.templateAfterInit();
        this.favoriteService.loadUserFavorites();

        const delay = 60000 * 10; // every 10 min
        //const delay = 5000; // every 5 sec
        let inter = interval(delay);
        this.fbSubscription = inter.pipe().subscribe(response => {
            this.loginFeedback();
        });

        this.loginFeedback();
        this.changeRef.detectChanges();
    }
    logoutJobs() {
        this.DisplayItems.IsLoggedIn = false;
        this.signalRService.stopConnection();
        this.modalService.closeAllPopups();
        if (this.fbSubscription != null) {
            this.fbSubscription.unsubscribe();
        }
        this.changeRef.detectChanges();
    }

    ngAfterViewInit() {
        //App.init();
        //App.initAjax();
        //Layout.init();
        //QuickSidebar.init();

        if (this.authenticationService.loggedIn()) {
            this.loginJobs();
        }
        this.authenticationService.AuthenticationCompletedSource.subscribe(r => {
            this.loginJobs();
        });
        this.authenticationService.OnLogout.subscribe(r => {
            this.logoutJobs();
        });

    }

    GetUnreadMessage() {
        let apiUrl: string = '/api/UserMessageService/GetUnredMessage';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.MessageCount = x;
            }
        );
    }

    public openAthleteReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenAthleteReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDogumReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenEDogumReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDriverReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenEDriverReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEPsychotecnicReport() {
        let fullApiUrl: string = 'api/EpisodeActionService/OpenEPsychotechnicsReportIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDisabledReport() {
        let fullApiUrl: string = 'api/EDisabledReportService/OpenEDisabledCouncilProcess';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDriverReportCreate() {
        let fullApiUrl: string = 'api/EReportService/openESurucuKurulRaporBasvuruOlusturma';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openEDriverReportSecCouncilIndex() {
        let fullApiUrl: string = 'api/EReportService/openESurucuKurulRaporSekreterIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    
    public openEDriverReportDocIndex() {
        let fullApiUrl: string = 'api/EReportService/openESurucuKurulRaporSekreterIndex';
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }
    public CanShowUpToDate: boolean = false;
    GetCanShowUpToDate() {
        let apiUrl: string = '/api/UpToDateService/UpToDateAccess';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.CanShowUpToDate = x;
            }
        );
    }

    navigationChanged(routeData: RouteData) {
    }

    logOut() {
        const that = this;

        if (this.modifiedComponentExists() === true) {
            const result = confirm('Değişiklikleri kaydetmeden devam etmek istiyor musunuz?');
            if (result === false) {
                return;
            }
        }
        this.authenticationService.logout();
    }
    public openUpToDateLink(Url: string) {

        if (Url != null) {
            window.open(Url, '_blank');
            window.focus();
        } else {

        }
    }

    public keyDownControl(event) {

        if (event != null && event.key != null && event.key === 'Enter') {
            this.UpToDate_click();
        }

    }
    public UpToDate_click() {

        let apiUrl: string = '/api/UpToDateService/GetUpToDateServiceUrl';
        try {

            if (this.UpToDateSearchStr != null && this.UpToDateSearchStr !== '') {
                this.httpService.post<any>(apiUrl, null).then(
                    x => {
                        this.openUpToDateLink(x + '( ' + this.UpToDateSearchStr + ')');
                        //http://xxxxxx.com/contents/search?unid=(unique_user_id)&srcsys=(assigned_system_id)&search=(SearchTerm)
                    }
                );
            }

        } catch (e) {
            alert('HATA KODU : ' + e);
        }

    }
    splashScreen: ElementRef;
    splashScreenImage: string;
    templateInit() {

        // subscribe to class update event
        this.classInitService.onClassesUpdated$.subscribe(classes => {
            // get body class array, join as string classes and pass to host binding class
            setTimeout(() => this.classes = classes.body.join(' '));
        });


        let selectedTheme = localStorage.getItem('selectedTheme');

        if (selectedTheme == null || selectedTheme == 'Default') {

        } else {
            this.themeService.setTheme(selectedTheme);
        }

        this.layoutConfigService.onLayoutConfigUpdated$.subscribe(model => {
            this.classInitService.setConfig(model);

            this.style = '';
            if (objectPath.get(model.config, 'self.layout') === 'boxed') {
                const backgroundImage = objectPath.get(model.config, 'self.background');
                if (backgroundImage) {
                    this.style = this.sanitizer.bypassSecurityTrustStyle('background-image: url(' + objectPath.get(model.config, 'self.background') + ')');
                }
            }

            // splash screen image
            this.splashScreenImage = objectPath.get(model.config, 'loader.image');
        });

        this.configService.onLayoutConfigUpdated$.subscribe(model => {
            const config = model.config;

            let pageBodyClass = '';
            this.selfLayout = objectPath.get(config, 'self.layout');
            if (this.selfLayout === 'boxed' || this.selfLayout === 'wide') {
                pageBodyClass += ' m-container m-container--responsive m-container--xxl m-page__container';
            }
            this.pageBodyClass$.next(pageBodyClass);

            this.DisplayItems.asideLeftDisplay = objectPath.get(config, 'aside.left.display');

            this.DisplayItems.asideRightDisplay = objectPath.get(config, 'aside.right.display');
        });

        this.classInitService.onClassesUpdated$.subscribe((classes) => {
            this.DisplayItems.asideLeftCloseClass = objectPath.get(classes, 'aside_left_close');
        });

        // animate page load
        this.router.events.subscribe(event => {
            if (event instanceof NavigationStart) {
                if (this.contenWrapper) {
                    // hide content
                    this.contenWrapper.nativeElement.style.display = 'none';
                }
            }
            if (event instanceof NavigationEnd) {
                if (this.contenWrapper) {
                    // show content back
                    this.contenWrapper.nativeElement.style.display = '';
                    // animate the content
                    this.animate(this.contenWrapper.nativeElement);
                }
            }
        });

    }

    templateAfterInit(): any {
        setTimeout(() => {
            if (this.mContent) {
                // keep content element in the service
                this.layoutRefService.addElement('content', this.mContent.nativeElement);
            }
        });
    }

    /**
 * Animate page load
 */
    animate(element) {
        this.player = this.animationBuilder
            .build([
                style({ opacity: 0, transform: 'translateY(15px)' }),
                animate('500ms ease', style({ opacity: 1, transform: 'translateY(0)' })),
                style({ transform: 'none' }),
            ])
            .create(element);
        this.player.play();
    }
}

export class ENabizButtonResponseModel {
    public isResponseSuccess: boolean;
    public responseMessage: string;
    public responseLink: string;
}

export class DisplayItems {
    IsLoggedIn: boolean = false;
    ShowAsAnonymous: boolean = false;
    asideLeftDisplay: string;
    asideRightDisplay: string;
    asideLeftCloseClass: string;
    isBrandDialogVisible: boolean = false;
    isChangePassword: boolean = false;
    IsSystemMessage: boolean = false;
    SystemMessage: string = '';
}

export class ServerInfo {
    IPAddress: string;
    ServerTime: string;
    SoftwareVersion: string;
}