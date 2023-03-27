import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, HostBinding, OnInit, ChangeDetectorRef } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import * as objectPath from 'object-path';
import { MenuHorizontalOffcanvasDirective } from '../../../../core/directives/menu-horizontal-offcanvas.directive';
import { MenuHorizontalDirective } from '../../../../core/directives/menu-horizontal.directive';
import { MenuHorizontalService } from '../../../../core/services/layout/menu-horizontal.service';
import { MenuConfigService } from '../../../../core/services/menu-config.service';
import { ClassInitService } from '../../../../core/services/class-init.service';
import { HvlMenu } from 'app/Fw/Components/HvlMenu';
import { NavigationService } from 'app/Fw/Services/NavigationService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { IAuthenticationService } from 'app/Fw/Services/IAuthenticationService';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { MenuConfig } from 'app/template/config/menu';

@Component({
	selector: 'm-menu-horizontal',
  templateUrl: './menu-horizontal.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class MenuHorizontalComponent extends HvlMenu  implements OnInit, AfterViewInit {

    constructor(public navigationService: NavigationService,
        activeUserService: IActiveUserService,
        messageService: MessageService,
        modalService: IModalService,
        objectContextService: ObjectContextService,
        authenticationService: IAuthenticationService,
        httpService: NeHttpService,
        private el: ElementRef,
        public classInitService: ClassInitService,
        public menuHorService: MenuHorizontalService,
        private menuConfigService: MenuConfigService,
		public router: Router,
		private changeDetector : ChangeDetectorRef
    ) {
        super(navigationService, router
            , activeUserService, messageService, modalService
            , objectContextService, authenticationService, httpService);

        this.classes = this.menuHorService.menuClasses;



    }

    public onMenuClickForRoute(routeLink: string) {
        this.navigationService.navigate(routeLink);
    }

    protected isHorizontalMenu(): boolean {
        return true;
    }
    protected OnMenuServiceDefinitionModelLoaded() {
		let empty = new MenuConfig();
        
        let input = empty.config.header.items;
		//var input = this.menuConfigService.configModel.config.header.items;
		var that = this;
		var res = input.filter(function f(o) {

			var condition = o.condition;
			if (condition == null) {
				if (o.submenu != null) {
					return (o.submenu.items = o.submenu.items.filter(f)).length;
				} else {
					return true;
				}
			}
			var result = eval("that." + condition);
			if (result == true) {
				if (o.submenu != null) {
					return (o.submenu.items = o.submenu.items.filter(f)).length;
				} else {
					return true;
				}
			}
			return false;
		})
		let newModel = new MenuConfig();
		newModel.config.header.items = res;
		this.menuConfigService.setModel(newModel);
		this.changeDetector.detectChanges();
    }

	@HostBinding('class') classes = '';
	@HostBinding('id') id = 'm_header_menu';

	@HostBinding('attr.mMenuHorizontalOffcanvas')
	mMenuHorOffcanvas: MenuHorizontalOffcanvasDirective;
	@HostBinding('attr.mMenuHorizontal')
	mMenuHorizontal: MenuHorizontalDirective;

	currentRouteUrl: any = '';
	activeItem: any;
	itemsWithAsides = [];




    ngAfterViewInit(): void {

        super.ngAfterViewInit();

		Promise.resolve(null).then(() => {
			this.mMenuHorOffcanvas = new MenuHorizontalOffcanvasDirective(this.el);
			this.mMenuHorOffcanvas.ngAfterViewInit();

			this.mMenuHorizontal = new MenuHorizontalDirective(this.el);
			this.mMenuHorizontal.ngAfterViewInit();
		});
	}

    ngOnInit(): void {
        super.ngOnInit();

		this.currentRouteUrl = this.router.url;
		this.menuHorService.menuList$.subscribe(menuItems => this.fillAsides(menuItems));

		this.shouldOverrideAsides();

		this.router.events
			.pipe(filter(event => event instanceof NavigationEnd))
			.subscribe(event => {
				this.currentRouteUrl = this.router.url;
				this.shouldOverrideAsides();
			});
	}

	shouldOverrideAsides() {
		const aside = this.getActiveItemAside();
		if (aside) {
			// override aside menu as secondary menu of current header menu
			this.menuConfigService.configModel.config.aside = aside;
            this.menuConfigService.setModel(this.menuConfigService.configModel);
		}
	}

	fillAsides(menuItems) {
		for (const menuItem of menuItems) {
			if (menuItem.aside) {
				this.itemsWithAsides.push(menuItem);
			}

			if (menuItem.submenu && menuItem.submenu.items) {
				this.fillAsides(menuItem.submenu.items);
			}
		}
	}

	getActiveItemAside() {
		if (this.currentRouteUrl === '') {
			return null;
		}

		for (const item of this.itemsWithAsides) {
			if (item.page && item.page === this.currentRouteUrl) {
				return item.aside;
			}
		}
	}

	getItemCssClasses(item) {
		let cssClasses = 'm-menu__item';

		if (objectPath.get(item, 'submenu')) {
			cssClasses += ' m-menu__item--submenu';
		}

		if (objectPath.get(item, 'resizer')) {
			cssClasses += ' m-menu__item--resize';
		}

		if (
			(objectPath.get(item, 'root') &&
				objectPath.get(item, 'submenu.type') === 'classic') ||
			parseInt(objectPath.get(item, 'submenu.width'), 2) > 0
		) {
			cssClasses += ' m-menu__item--rel';
		}

		const customClass = objectPath.get(item, 'custom-class');
		if (customClass) {
			cssClasses += ' ' + customClass;
		}

		if (objectPath.get(item, 'icon-only')) {
			cssClasses += ' m-menu__item--icon-only';
		}

		if (item.submenu && this.isMenuItemIsActive(item)) {
			cssClasses += ' m-menu__item--active';
		}

		return cssClasses;
	}

	getItemAttrLinkRedirect(menuItem): any {
		if (objectPath.get(menuItem, 'redirect')) {
			return '1';
		}

		return null;
	}

	getItemAttrResizeDesktopBreakpoint(menuItem) {
		if (objectPath.get(menuItem, 'resizer')) {
			return objectPath.get(menuItem, 'resize-breakpoint');
		}

		return null;
	}

	getItemAttrSubmenuToggle(menuItem) {
		let attrSubmenuToggle = 'hover';
		if (objectPath.get(menuItem, 'toggle') === 'click') {
			attrSubmenuToggle = 'click';
		} else if (objectPath.get(menuItem, 'submenu.type') === 'tabs') {
			attrSubmenuToggle = 'tabs';
		} else {
			// submenu toggle default to 'hover'
		}

		return attrSubmenuToggle;
	}

	getItemAttrSubmenuMode(menuItem) {
		return null;
	}

	getItemMenuSubmenuClass(menuItem) {
		let subClass = '';

		const subAlignment = objectPath.get(menuItem, 'submenu.alignment');
		if (subAlignment) {
			subClass += ' m-menu__submenu--' + subAlignment;
		}

		if (objectPath.get(menuItem, 'submenu.type') === 'classic') {
			subClass += ' m-menu__submenu--classic';
		}

		if (objectPath.get(menuItem, 'submenu.type') === 'tabs') {
			subClass += ' m-menu__submenu--tabs';
		}

		if (objectPath.get(menuItem, 'submenu.type') === 'mega') {
			if (objectPath.get(menuItem, 'submenu.width')) {
				subClass += ' m-menu__submenu--fixed';
			}
		}

		if (objectPath.get(menuItem, 'submenu.pull')) {
			subClass += ' m-menu__submenu--pull';
		}

		return subClass;
	}

	isMenuItemIsActive(item): boolean {
		if (item.submenu) {
			return this.isMenuRootItemIsActive(item);
		}

		if (!item.page) {
			return false;
		}

		return item.page === this.currentRouteUrl;
	}

	isMenuRootItemIsActive(item): boolean {
		if (item.submenu.items) {
			for (const subItem of item.submenu.items) {
				if (this.isMenuItemIsActive(subItem)) {
					return true;
				}
			}
		}

		return false;
    }

    public goto(item) {

        if (item.customClick != null) {
            eval("this." + item.customClick);
        }


    }
}
