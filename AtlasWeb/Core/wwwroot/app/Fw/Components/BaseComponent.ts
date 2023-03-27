import { AfterViewInit, ViewChildren, QueryList, OnDestroy, HostListener, Directive } from '@angular/core';
import { BaseModel } from '../Models/BaseModel';
import { RouteData } from '../Models/RouteData';
import { GlobalsService } from '../Services/GlobalsService';
import { NavigationService } from '../Services/NavigationService';
import { NotificationService } from '../Services/NotificationService';
import { ServiceContainer } from '../Services/ServiceContainer';
import { BaseControl } from './BaseControls/BaseControl';
import notifyDX from 'devextreme/ui/notify';
import { Subscription } from 'rxjs';
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

export interface BaseForm {
    clientPreScript(): void;
    clientPostScript(state: String): void;
    setRouteData(routeData: RouteData): void;
}
@Directive()
export abstract class BaseComponent<T extends BaseModel> implements AfterViewInit, BaseForm, OnDestroy {
    Model: T;
    RouteData: any;
    protected navigator: NavigationService;
    protected notifier: NotificationService;
    public Globals: GlobalsService;
    @ViewChildren('Validation') validationControls: QueryList<BaseControl>;
    private notificationSourceSubscription: Subscription;

    abstract clientPreScript(): void;
    abstract clientPostScript(state: String): void;

    constructor(protected container: ServiceContainer) {
        this.navigator = container.Navigator;
        this.notifier = container.Notifier;
        this.Globals = container.Globals;

        this.RouteData = null;
        this.Model = new BaseModel() as T;
        this.notificationSourceSubscription = this.notifier.notificationSource.subscribe((t) => {
            this.notify(t.message, t.type);
        });
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

    protected Validate(): Boolean {
        return true;
        //let validationControls: Array<BaseControl>;
        //let result = true;
        //let totalResult = true;
        //validationControls = this.validationControls.toArray();
        //for (let i = 0; i < validationControls.length; i++) {
        //    let validation = validationControls[i];
        //    result = validation.checkValidation();
        //    if (!result) {
        //        totalResult = false;
        //    }
        //}
        //return totalResult;
    }

    saveClicked() {
        if (this.Validate()) {
            this.clientPostScript('save');
        }
    }

    cancelClicked() {
        this.clientPostScript('cancel');
    }

    public setModel(model: T): void {
        this.Model = model;
    }

    public setRouteData(routeData: RouteData) {
        this.RouteData = routeData;
    }

    navigate(modulePath: string, path: string, params: any) {
        let currentComponent: any;
        currentComponent = this['constructor'].name;
        //this.navigator.navigate(modulePath, path, params, currentComponent);
    }

    notify(message: string, type: string, duration: number = 2000) {
        notifyDX(message, type, duration);
    }

    notifyInfo(message: string, duration: number) {
        this.notify(message, 'info');
    }

    notifyAlert(message: string, duration: number) {
        this.notify(message, 'error');
    }

    notifyWarning(message: string, duration: number) {
        this.notify(message, 'warning');
    }

    onClose() {
        this.destruct();
    }

    destruct() {
        delete this.Model;
        delete this.RouteData;
    }

    ngAfterViewInit() {
        this.clientPreScript();
    }

    lock(busy: Boolean) {
        this.container.Globals.Busy.next(busy);
    }

    ngOnDestroy() {
        if (this.notificationSourceSubscription != null) {
            this.notificationSourceSubscription.unsubscribe();
            this.notificationSourceSubscription = null;
        }
    }
}