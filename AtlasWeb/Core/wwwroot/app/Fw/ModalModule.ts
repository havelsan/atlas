import {
    Component, NgModule, ViewChild, ViewContainerRef, AfterViewInit,
    Compiler, ReflectiveInjector, Injectable, Injector, ComponentFactoryResolver, ViewRef, OnDestroy, ChangeDetectorRef, EventEmitter
} from '@angular/core';
import { ModalContainerComponent } from 'Fw/Components/ModalContainerComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { DevExtremeModule } from 'devextreme-angular';
import { FwModule } from 'Fw/FwModule';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { ModalActionResult } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { CommonModule } from '@angular/common';


@Injectable()
export class ModalService implements IModalService {
    private vcRef: ViewContainerRef;
    private injector: Injector;
    public activeInstances: number = 0;
    private activeDynamicComponents: Array<string> = new Array<string>();
    public OnCloseAllPopups: EventEmitter<any> = new EventEmitter<any>();

    constructor(private compiler: Compiler, private componentFactoryResolver: ComponentFactoryResolver) {
    }

    registerViewContainerRef(vcRef: ViewContainerRef): void {
        this.vcRef = vcRef;
    }

    registerInjector(injector: Injector): void {
        this.injector = injector;
    }

    closeAllPopups() {
        this.activeDynamicComponents.Clear();
        this.OnCloseAllPopups.emit();
    }

    create<T>(dynCompInfo: DynamicComponentInfo, modalInfo: ModalInfo): Promise<ModalActionResult> {
        let that = this;


        let promise = new Promise<ModalActionResult>(function (resolve, reject) {

            let index = that.activeDynamicComponents.indexOf(dynCompInfo.ComponentName);
            if (index < 0) {
                that.activeDynamicComponents.push(dynCompInfo.ComponentName);
            } else {
                if (!modalInfo.AllowMultiple) {
                    reject({ reason: modalInfo.Title + " Ekranı Açılmış Durumda" });
                    return;
                }
            }

            let modalComponentFactory = that.componentFactoryResolver.resolveComponentFactory(ModalContainerComponent);
            const childInjector = ReflectiveInjector.resolveAndCreate([], that.injector);
            let modalComponentRef = that.vcRef.createComponent(modalComponentFactory, 0, childInjector);
            let modalContainerComponent: ModalContainerComponent = modalComponentRef.instance as ModalContainerComponent;
            modalContainerComponent.Initialize(dynCompInfo, modalInfo);
            let compRef = dynCompInfo.ParentInstance as IDestroyEvent;

            let closeAllSubscribtion = that.OnCloseAllPopups.subscribe(x => {

                reject({ reason: "Close All" });

                that.disposeEvents(null, null, modalComponentRef, dynCompInfo, closeAllSubscribtion);
            });

            let subscription = modalContainerComponent.OnActionExecute.subscribe(next => {
                resolve(next);
            }, error => {
                reject(error);
            }, () => {
                that.disposeEvents(subscription, null, modalComponentRef, dynCompInfo, closeAllSubscribtion);
            });

            if (dynCompInfo.ParentInstance != null) {
                if (compRef != null && compRef.OnDestroy != null) {
                    const subscriptionOnDestroy = compRef.OnDestroy.subscribe(x => {
                        that.disposeEvents(subscription, subscriptionOnDestroy, modalComponentRef, dynCompInfo, closeAllSubscribtion);
                    })
                }
            }
        });
        return promise;
    }


    disposeEvents(subscription: any, subscriptionOnDestroy: any, modalComponentRef: any, dynCompInfo: DynamicComponentInfo, closeAllSubs : any) {

        if (modalComponentRef) {
            modalComponentRef.destroy();
        }
        if (subscription) {
            subscription.unsubscribe();
            subscription = null;
        }
        if (closeAllSubs) {
            closeAllSubs.unsubscribe();
            closeAllSubs = null;
        }
        if (subscriptionOnDestroy) {
            subscriptionOnDestroy.unsubscribe();
            subscriptionOnDestroy = null;
        }
        let index = this.activeDynamicComponents.indexOf(dynCompInfo.ComponentName);
        if (index > -1)
            this.activeDynamicComponents.splice(index, 1);
    }
}
@Component({
    selector: 'modal-placeholder',
    template: `<ng-container *ngIf="showPlaceHolder"><div #modalplaceholder></div></ng-container>`
})
export class ModalPlaceholderComponent implements AfterViewInit {
    @ViewChild('modalplaceholder', { read: ViewContainerRef }) viewContainerRef;

    public showPlaceHolder: boolean = true;
    constructor(private modalService: IModalService,
        private injector: Injector,
        private cdRef: ChangeDetectorRef
    ) {

    }

    closeAllPopups() {
        this.showPlaceHolder = false;
        this.cdRef.detectChanges();
        this.showPlaceHolder = true;
        this.cdRef.detectChanges();
        this.registerServiceInjectors();
    }

    registerServiceInjectors() {
        this.modalService.registerViewContainerRef(this.viewContainerRef);
        this.modalService.registerInjector(this.injector);
    }

    ngAfterViewInit(): void {
        this.registerServiceInjectors();
        this.modalService.OnCloseAllPopups.subscribe(x => {
            this.closeAllPopups();
        });
    }
}

@NgModule({
    declarations: [ModalPlaceholderComponent, ModalContainerComponent],
    exports: [ModalPlaceholderComponent, ModalContainerComponent],
    imports: [CommonModule, DevExtremeModule, FwModule],
    entryComponents: [ModalContainerComponent]
})
export class ModalModule {

    static dynamicComponentsMap = {
        ModalPlaceholderComponent,
        ModalContainerComponent
    };
}
