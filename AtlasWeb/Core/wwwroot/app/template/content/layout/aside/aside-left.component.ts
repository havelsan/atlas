import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, HostBinding, Inject, OnInit, Output, EventEmitter } from '@angular/core';
import { filter } from 'rxjs/operators';
import { NavigationEnd, Router } from '@angular/router';
import { MenuAsideOffcanvasDirective } from '../../../core/directives/menu-aside-offcanvas.directive';
import { ClassInitService } from '../../../core/services/class-init.service';
import { LayoutConfigService } from '../../../core/services/layout-config.service';
import { LayoutRefService } from '../../../core/services/layout/layout-ref.service';
import { MenuAsideService } from '../../../core/services/layout/menu-aside.service';
import { DOCUMENT } from '@angular/common';
import { Subscription } from 'rxjs';
import { SidebarMenuItem, SidebarMenuItemClickable } from 'app/SidebarMenu/Models/SidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IAuditObjectService } from 'app/Fw/Services/IAuditObjectService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MenuConfigService } from 'app/template/core/services/menu-config.service';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { ExaminationQueueDefinition } from 'app/NebulaClient/Model/AtlasClientModel';
import { GetSortedQueueItemsByArray_Input } from 'app/Fw/Components/HvlMenu';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';
import { ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';



@Component({
    selector: 'm-aside-left',
    templateUrl: './aside-left.component.html',
    changeDetection: ChangeDetectionStrategy.Default
})
export class AsideLeftComponent implements OnInit, AfterViewInit {

    @HostBinding('class') classes = 'm-grid__item';
    @HostBinding('id') id = 'm_aside_left';

    @HostBinding('attr.mMenuAsideOffcanvas') mMenuAsideOffcanvas: MenuAsideOffcanvasDirective;

    currentRouteUrl: string = '';
    insideTm: any;
    outsideTm: any;

    constructor(
        private el: ElementRef,
        public classInitService: ClassInitService,
        public menuAsideService: MenuAsideService,
        public layoutConfigService: LayoutConfigService,
        private router: Router,
        private layoutRefService: LayoutRefService,
        private sidebarMenuService: ISidebarMenuService,
        private menuConfigService: MenuConfigService,

        protected modalService: IModalService,
        private activeUserService: IActiveUserService,
        protected httpService: NeHttpService,

        @Inject(DOCUMENT) private document: Document,

        private favoriteService: IFavoriteService

    ) {
        // subscribe to menu classes update
        this.classInitService.onClassesUpdated$.subscribe(classes => {
            // join the classes array and pass to variable
            this.classes = 'm-grid__item ' + classes.aside_left.join(' ');
        });


    }

    ngAfterViewInit(): void {

        setTimeout(() => {

            this.mMenuAsideOffcanvas = new MenuAsideOffcanvasDirective(this.el);
            // manually call the directives' lifecycle hook method
            this.mMenuAsideOffcanvas.ngAfterViewInit();

            // keep aside left element reference
            this.layoutRefService.addElement('asideLeft', this.el.nativeElement);

        }, 1000);
    }

    ngOnInit() {

        this.currentRouteUrl = this.router.url.split(/[?#]/)[0];

        this.router.events
            .pipe(filter(event => event instanceof NavigationEnd))
            .subscribe(event => this.currentRouteUrl = this.router.url.split(/[?#]/)[0]);


        let that = this;
        this.subscriptionAddOrRemoveMenu = this.sidebarMenuService.addOrRemoveMenu
            .subscribe(item => {
                that.addOrRemoveMenu(item);
            });
    }

    isMenuItemIsActive(item): boolean {
        if (item.submenu) {
            return this.isMenuRootItemIsActive(item);
        }

        if (!item.page) {
            return false;
        }

        // dashboard
        if (item.page !== '/' && this.currentRouteUrl.startsWith(item.page)) {
            return true;
        }
        return this.currentRouteUrl === item.page;
    }

    isMenuRootItemIsActive(item): boolean {
        let result: boolean = false;

        for (const subItem of item.submenu) {
            result = this.isMenuItemIsActive(subItem);
            if (result) {
                return true;
            }
        }

        return false;
    }

	/**
	 * Use for fixed left aside menu, to show menu on mouseenter event.
	 * @param e Event
	 */
    mouseEnter(e: Event) {
        // check if the left aside menu is fixed
        if (this.document.body.classList.contains('m-aside-left--fixed')) {
            if (this.outsideTm) {
                clearTimeout(this.outsideTm);
                this.outsideTm = null;
            }

            this.insideTm = setTimeout(() => {
                // if the left aside menu is minimized
                if (this.document.body.classList.contains('m-aside-left--minimize') && mUtil.isInResponsiveRange('desktop')) {
                    // show the left aside menu
                    this.document.body.classList.remove('m-aside-left--minimize');
                    this.document.body.classList.add('m-aside-left--minimize-hover');
                }
            }, 300);
        }
    }

	/**
	 * Use for fixed left aside menu, to show menu on mouseenter event.
	 * @param e Event
	 */
    mouseLeave(e: Event) {
        if (this.document.body.classList.contains('m-aside-left--fixed')) {
            if (this.insideTm) {
                clearTimeout(this.insideTm);
                this.insideTm = null;
            }

            this.outsideTm = setTimeout(() => {
                // if the left aside menu is expand
                if (this.document.body.classList.contains('m-aside-left--minimize-hover') && mUtil.isInResponsiveRange('desktop')) {
                    // hide back the left aside menu
                    this.document.body.classList.remove('m-aside-left--minimize-hover');
                    this.document.body.classList.add('m-aside-left--minimize');
                }
            }, 500);
        }
    }


    private subscriptionAddOrRemoveMenu: Subscription;

    @Output() onMenuItemClicked: EventEmitter<SidebarMenuItem> = new EventEmitter<SidebarMenuItem>();

    private findMenuItemWithKey(menuKey: string, itemsList: any) {

        if (itemsList == null) {
            return;
        }
        for (let sideBarMenuItem of itemsList) {
            if (sideBarMenuItem.key === menuKey) {
                return sideBarMenuItem;
            }
            let targetMenu = this.findMenuItemWithKey(menuKey, sideBarMenuItem.submenu);
            if (targetMenu != null) {
                return targetMenu;
            }
        }
        return null;
    }

    private removeMenuItemWithKey(menuKey: string, itemsList): void {

        if (itemsList == null) {
            return;
        }

        for (let sideBarMenuItem of itemsList) {
            if (sideBarMenuItem.key === menuKey) {
                let itemIndex = itemsList.indexOf(sideBarMenuItem);
                if (itemIndex > -1) {
                    itemsList.splice(itemIndex, 1);
                    return;
                }
            }
            this.removeMenuItemWithKey(menuKey, sideBarMenuItem.submenu);
        }
        return null;
    }

    private addMenu(parentMenuKey: string, menuItem: SidebarMenuItem) {
        if (!parentMenuKey) {
            if (this.constructor.name === 'AsideLeftComponent') {

                if (this.itemsList.findIndex(x => x.key == menuItem.key) > -1) {
                    return;
                }

                this.itemsList.push({ root: true, bullet: 'dot', key: menuItem.key, icon: menuItem.icon, title: menuItem.label, sidebarMenuItem: menuItem, submenu: menuItem.items, index: menuItem.index });
                this.itemsList.sort((a, b) => {
                    if (a.index < b.index) return -1;
                    else if (a.index > b.index) return 1;
                    else return 0;
                });

                if (menuItem.isFavorited) {
                    this.addFavoritesFromDynamicComponent(menuItem);
                }
            }
        } else {
            let targetMenu = this.findMenuItemWithKey(parentMenuKey, this.itemsList);
            if (targetMenu != null) {

                if (targetMenu.submenu.findIndex(x => x.key == menuItem.key) > -1) {
                    return;
                }

                targetMenu.submenu.push({ key: menuItem.key, icon: menuItem.icon, title: menuItem.label, sidebarMenuItem: menuItem });
                targetMenu.submenu.sort((a, b) => {
                    if (a.title < b.title) return -1;
                    else if (a.title > b.title) return 1;
                    else return 0;
                });

                if (menuItem.isFavorited) {
                    this.addFavoritesFromDynamicComponent(menuItem);
                }
            }
        }
    }

    public removeMenu(menuKey: string) {
        if (menuKey) {
            this.favoriteService.removeItem(menuKey);
            this.removeMenuItemWithKey(menuKey, this.itemsList);
        }
    }

    private addOrRemoveMenu(item: any) {

        if (item.hasOwnProperty('action')) {
            let action: string = item.action as string;
            if (action === 'add') {
                let parentMenuKey: string = item.parentMenuKey as string;
                let menuItem: SidebarMenuItem = item.menuItem as SidebarMenuItem;

                let isFavorited = this.favoriteService.userFavorites.findIndex(x => x == item.menuItem.key) > -1
                if (isFavorited) {
                    menuItem.isFavorited = true;
                } else {
                    menuItem.isFavorited = false;
                }

                this.addMenu(parentMenuKey, menuItem);
            } else if (action === 'remove') {
                let menuKey: string = item.menuKey as string;
                this.removeMenu(menuKey);
            }
        }
    }


    public ngOnDestroy(): void {
        if (this.subscriptionAddOrRemoveMenu != null) {
            this.subscriptionAddOrRemoveMenu.unsubscribe();
            this.subscriptionAddOrRemoveMenu = null;
        }
    }

    public customButtonHandlers(item) {
        if (item.key === 'Audit') {
            this.AuditClick();
        }
        else if (item.key === 'KullaniciBirimDegistirme') {
            this.kullaniciBirimDegistirme();
        }
        else if (item.key === 'RaporOnayEkrani') {
            this.openRaporOnayEkrani();
        }
        //else if (item.key === 'Raporlar') {
        //    this.printReport();
        //}
        else {

        }
    }

    public menuItemClicked(listItem): void {

        let item = listItem.sidebarMenuItem;

        if (item == null) {
            this.customButtonHandlers(listItem);
            return;
        }
        this.onMenuItemClicked.emit(item);
        if (item.ItemType === 'MenuItem' || item.ItemType === 'HeaderItem') {

            if (item instanceof DynamicSidebarMenuItem) {
                if (item.clickFunction && item.componentInstance) {
                    if (item.getParamsFunction && item.parameterFunctionInstance) {
                        let boundedParamFunction = item.getParamsFunction.bind(item.parameterFunctionInstance);
                        let params: ClickFunctionParams = { Params: boundedParamFunction(item.getParamsFunction).Params, ParentInstance: item.ParentInstance };

                        let boundedFunction = item.clickFunction.bind(item.componentInstance);
                        boundedFunction(params);
                    } else {
                        let boundedFunction = item.clickFunction.bind(item.componentInstance);
                        boundedFunction();
                    }
                }
            } else {

                let menuItem = item as SidebarMenuItemClickable;
                if (menuItem) {
                    menuItem.click.emit(item);
                }
            }
        }
    }

    public kullaniciBirimDegistirme(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'UserResourceSelectionView';
            componentInfo.ModuleName = 'UserResourceSelectionModule';
            componentInfo.ModulePath = '/app/System/UserResourceSelectionModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17898", "Kullanıcı Birim Değiştirme");
            modalInfo.Width = 400;
            modalInfo.Height = 220;
            modalInfo.IsShowCloseButton = false;
            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.getQuueuList();
            }).catch(err => {
                reject(err);
            });
        });


    }

    public openRaporOnayEkrani(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ReportApproveForm';
            componentInfo.ModuleName = 'HastaRaporlariModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/HastaRaporlariModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Rapor Onay Ekranı";
            modalInfo.Width = 1000;
            modalInfo.Height = 600;
            modalInfo.IsShowCloseButton = true;
            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.getQuueuList();
            }).catch(err => {
                reject(err);
            });
        });


    }

    public printReport(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'PrintReportForm';
            componentInfo.ModuleName = 'PrintReportFormModule';
            componentInfo.ModulePath = '/Modules/Sorgulama_ve_Cikartma_Formlari/Rapor_Yazdirma_Formu/PrintReportFormModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17898", "Raporlar");
            modalInfo.Width = 1280;
            modalInfo.Height = 720;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.getQuueuList();
            }).catch(err => {
                reject(err);
            });
        });


    }

    queueList: Array<ExaminationQueueDefinition> = new Array<ExaminationQueueDefinition>();
    public getQuueuList(): any {
        let that = this;
        let attt: GetSortedQueueItemsByArray_Input = new GetSortedQueueItemsByArray_Input();
        if (this.activeUserService.SelectedOutPatientResource != null) {
            attt.currentResUserID = this.activeUserService.ActiveUser.UserObject.ObjectID;
            attt.outPatientResID = this.activeUserService.SelectedOutPatientResource.ObjectID;
            attt.includeCalleds = false;
            let apiUrl: string = '/api/CommonService/GetQueueDefinition';
            this.httpService.post<any>(apiUrl, attt).then(
                x => {
                    this.activeUserService.SelectedQueue = x[0];
                    that.queueList = x;
                    return that.queueList;
                }
            );
        }

    }

    public AuditClick() {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ShowAuditForm';
            componentInfo.ModuleName = 'LogModule';
            componentInfo.ModulePath = '/Modules/Core_Destek_Modulleri/Log_Modulu/LogModule';
            const auditService = ServiceLocator.Injector.get(IAuditObjectService);
            componentInfo.InputParam = auditService.ObjectIDList;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'İşlem Tarihçesi';
            modalInfo.Width = 1300;
            modalInfo.Height = 750;

            const modalService = ServiceLocator.Injector.get(IModalService);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public itemsList: any = [
        {
            title: 'Yardımcı Menüler',
            root: true,
            key: 'YardimciMenu',
            bullet: 'dot',
            icon: 'fa fa-magic',
            submenu: [],
            index: 100,
        }, {
            title: 'Tahlil/Tetkik Sonuçları',
            root: true,
            key: 'TahlilTetkikSonuc',
            bullet: 'dot',
            icon: 'far fa-file-alt',
            submenu: [],
            index: 200,
        }, {
            title: 'Barkod',
            root: true,
            key: 'Barkod',
            bullet: 'dot',
            icon: 'fas fa-barcode',
            submenu: [],
            index: 300,
        },
        {
            title: 'Sağlık Bakanlığı Raporları',
            root: true,
            key: 'SaglikBakanligiRaporlari',
            bullet: 'dot',
            icon: 'fa fa-book',
            submenu: [],
            index: 400,
        },
        {
            title: 'Kullanıcı Birim Değiştirme',
            root: true,
            key: 'KullaniciBirimDegistirme',
            bullet: 'dot',
            icon: 'fa fa-newspaper-o',
            index: 500,
        },
        {
            title: 'Rapor Onay Ekranı',
            root: true,
            key: 'RaporOnayEkrani',
            bullet: 'dot',
            icon: 'fa fa-check',
            index: 600,
        },
        {
            title: 'İşlem Tarihçesi',
            root: true,
            key: 'Audit',
            bullet: 'dot',
            icon: 'fa fa-search',
            index: 700,
        },
        {
            title: 'Hasta Raporları',
            root: true,
            key: 'ReportMainItem',
            bullet: 'dot',
            icon: 'fa fa-print',
            submenu: [],
            index: 800,
        }
        ,
        {
            title: 'İstatistik Raporları',
            root: true,
            key: 'StatisticReportMainItem',
            bullet: 'dot',
            icon: 'fa fa-print',
            submenu: [],
            index: 900,
        }
    ];

    addFavoritesFromDynamicComponent(menuItem) {
        let dynamicSidebarMenuItem = menuItem as DynamicSidebarMenuItem;
        if (dynamicSidebarMenuItem != null) {
            this.favoriteService.addItem(
                {
                    key: menuItem.key,
                    icon: menuItem.icon != null ? menuItem.icon : 'fa fa-star',
                    name: menuItem.label,
                    sidebarMenuItem: dynamicSidebarMenuItem
                });
        }
    }

    addToFavorites(item, e) {
        item.sidebarMenuItem.isFavorited = true;
        this.favoriteService.addToFavorites(item.key).then(x => {
            this.addFavoritesFromDynamicComponent(item.sidebarMenuItem);
        });
        e.preventDefault();
        return false;
    }

    removeFromFavorites(item, e) {
        item.sidebarMenuItem.isFavorited = false;
        this.favoriteService.removeFromFavorites(item.key).then(x => {

            this.favoriteService.removeItem(item.key);
        });
        e.preventDefault();
        return false;
    }




}
