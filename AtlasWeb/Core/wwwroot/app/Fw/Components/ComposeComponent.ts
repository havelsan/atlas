import {
    Component, OnInit, OnDestroy, Input, Output, EventEmitter, ViewContainerRef, ComponentRef
    , ViewChild,  Compiler, ComponentFactory, ComponentFactoryResolver, ReflectiveInjector, Type
} from '@angular/core';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IModal } from 'Fw/Models/ModalInfo';
import { IInputParam } from 'Fw/Models/IInputParam';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { AtlasModuleLoader } from 'Fw/Services/AtlasModuleLoader';
import { IActiveComponentRegistryService } from 'Fw/Services/IActiveComponentRegistryService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';

type ModuleWithDynamicComponents = Type<any> & {
    dynamicComponentsMap: {};
};


@Component({
    selector: 'comp-compose',
    template: `<div #placeholder></div>`,
})
export class ComposeComponent implements OnInit, OnDestroy {
    @Input() ReadOnlyByCode: boolean = false;
    @Input() DestroyComponentOnSave: boolean = false;
    @Input() SaveAndCloseCommandVisible: boolean = false;
    @Input() CloseWithStateTransition: boolean = false;
    @Input() Info: DynamicComponentInfo;
    @Input() ModalInfo: ModalInfo;
    
    @Output() ComponentCreated: EventEmitter<ComponentRef<any>> = new EventEmitter<ComponentRef<any>>();
    @Output() StateChanged: EventEmitter<boolean> = new EventEmitter<boolean>();
    @ViewChild('placeholder', { read: ViewContainerRef }) placeholderRef: ViewContainerRef;
    @Output() DynamicComponentActionExecuted: EventEmitter<any> = new EventEmitter<any>();
    @Output() DynamicComponentActionFailed: EventEmitter<any> = new EventEmitter<any>();
    @Output() DynamicComponentLoadErrorOccurred: EventEmitter<any> = new EventEmitter<any>();
    @Output() DynamicComponentClosed: EventEmitter<void> = new EventEmitter<void>();
    @Output() DynamicComponentViewModelLoaded: EventEmitter<any> = new EventEmitter<any>();

    @Input() RefreshComponent: string = '';

    public objectID: string;
    private componentRef: ComponentRef<any>;
    private isViewInitialized: boolean = false;
    private actionExecutedSubscription: any;
    private actionFailedSubscription: any;
    private loadErrorOccurredSubscription: any;
    private loadViewModelCompletedSubscription: any;

    constructor(private compiler: Compiler
        , private componentFactoryResolver: ComponentFactoryResolver
        , private loader: AtlasModuleLoader
        , private http: NeHttpService
        , private messageService: MessageService
        , private componentRegistry: IActiveComponentRegistryService) {
    }

    private renderPreCheck(): Promise<boolean> {
        if (this.Info.RenderPreCheckUri == null || this.Info.RenderPreCheckUri === '') {
            return Promise.resolve(true);
        }

        let that = this;
        return new Promise<boolean>((resolve, reject) => {
            that.http.getForNeResult<boolean>(that.Info.RenderPreCheckUri).then(res => {
                if (res.IsSuccess === true) {
                    let booleanValue = res.Result as boolean;
                    resolve(booleanValue);
                } else {
                    reject(res.Message);
                }
            }).catch(error => {
                reject(error);
            });

        });
    }

    private renderSubComponent() {
        if (!this.isViewInitialized) {
            return;
        }
        this.destroyComponent();
        if (this.Info == null) {
            return;
        }
        let that = this;
        this.renderPreCheck().then(res => {
            if (res === true) {
                that.loadSubComponent();
            }
        }).catch(error => {
            that.messageService.showError(error);
        });
    }

    public destroyComponent() {
        if (this.actionExecutedSubscription != null) {
            this.actionExecutedSubscription.unsubscribe();
        }
        if (this.actionFailedSubscription != null) {
            this.actionFailedSubscription.unsubscribe();
        }
        if (this.loadErrorOccurredSubscription != null) {
            this.loadErrorOccurredSubscription.unsubscribe();
        }
        if (this.loadViewModelCompletedSubscription != null) {
            this.loadViewModelCompletedSubscription.unsubscribe();
        }

        if (this.componentRef != null) {
            this.componentRef.destroy();
            this.componentRef = null;
            this.componentRegistry.unregisterComponent(this.componentRef);
            this.DynamicComponentClosed.emit();
        }
    }

    private getComponentFactory(): Promise<ComponentFactory<any>> {
        if (this.compiler && this.compiler.constructor.name == "CompilerImpl") {
            return this.getComponentFactoryForJit();
        }
        return this.getComponentFactoryForAot();
    }

    private getComponentFactoryForAot(): Promise<ComponentFactory<any>> {
        if (this.Info.ComponentType != null) {
            let componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.Info.ComponentType);
            return Promise.resolve(componentFactory);
        }

        let injector = ReflectiveInjector.fromResolvedProviders([], this.placeholderRef.parentInjector);

        let that = this;
        return new Promise<ComponentFactory<any>>((resolve, reject) => {
            that.loader.loadModule(this.Info.ModulePath, this.Info.ModuleName).then(moduleFactory => {

                const moduleReference = moduleFactory.create(injector);
                const componentResolver = moduleReference.componentFactoryResolver;
                const componentType = (moduleFactory.moduleType as ModuleWithDynamicComponents).dynamicComponentsMap[that.Info.ComponentName];

                const componentFactory = componentResolver.resolveComponentFactory(componentType);
                if (!componentFactory) {
                    throw new Error(`'${that.Info.ComponentName}' bileşeni '${that.Info.ModuleName}' içerisinde bulunamadı`);
                }

                resolve(componentFactory);
            }).catch(err => reject(err));
        });
    }

    private getComponentFactoryForJit(): Promise<ComponentFactory<any>> {
        if (this.Info.ComponentType != null) {
            let componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.Info.ComponentType);
            return Promise.resolve(componentFactory);
        }

        let that = this;
        return new Promise<ComponentFactory<any>>((resolve, reject) => {
            that.loader.load(this.Info.ModulePath, this.Info.ModuleName).then(moduleWithFactories => {
                const cmpFactory = moduleWithFactories.componentFactories.find(x => x.componentType.name === that.Info.ComponentName);
                if (!cmpFactory) {
                    throw new Error(`'${that.Info.ComponentName}' bileşeni '${that.Info.ModuleName}' içerisinde bulunamadı`);
                }

                resolve(cmpFactory);
            }).catch(err => reject(err));
        });
    }

    private loadSubComponent() {
        if (!this.isViewInitialized) {
            return;
        }
        this.destroyComponent();
        if (this.Info == null) {
            return;
        }

        const moduleInfoSupplied = (this.Info.ModuleName && this.Info.ModulePath && this.Info.ComponentName) ? true : false;
        const moduleTypeSupplied = (this.Info.ComponentType) ? true : false;

        if (moduleInfoSupplied === false && moduleTypeSupplied === false) {
            return;
        }

        let that = this;
        try {
            this.placeholderRef.clear();
        } catch (e) {
            console.log('dispose error: ' + e);
        }

        let injector = ReflectiveInjector.fromResolvedProviders([], this.placeholderRef.parentInjector);

        this.getComponentFactory()
            .then((cmpFactory: ComponentFactory<any>) => {
                let componentRef = this.placeholderRef.createComponent(cmpFactory, 0, injector, []);
                componentRef.instance.ObjectID = that.Info.objectID;
                componentRef.instance.ActiveIDsModel = that.Info.InputParam instanceof DynamicComponentInputParam ? that.Info.InputParam.activeIDsModel : null;
                that.ComponentCreated.emit(componentRef);

                that.componentRef = componentRef;
                let modal = componentRef.instance as IModal;
                let inputParam = that.Info.InputParam;
                if (that.Info.InputParam instanceof DynamicComponentInputParam) {
                    inputParam = that.Info.InputParam.data;
                }

                if (modal != null && (typeof modal.setInputParam === 'function') && (typeof modal.setModalInfo === 'function')) {
                    modal.setInputParam(inputParam);
                    modal.setModalInfo(that.ModalInfo);
                }
                let inputParamIf = componentRef.instance as IInputParam;
                if (inputParamIf != null && (typeof inputParamIf.setInputParam === 'function') && (typeof modal.setModalInfo === 'undefined')) {
                    inputParamIf.setInputParam(inputParam);
                }

                that.componentRegistry.registerComponent(that.componentRef);
                if (that.Info.CloseWithStateTransition != null) {
                    that.CloseWithStateTransition = that.Info.CloseWithStateTransition;
                }
                if (that.Info.DestroyComponentOnSave != null) {
                    that.DestroyComponentOnSave = that.Info.DestroyComponentOnSave;
                }

                let boundBaseForm = componentRef.instance as TTVisual.TTBoundFormBase;
                if (boundBaseForm != null) {
                    boundBaseForm.saveAndCloseCommandVisible = this.SaveAndCloseCommandVisible;
                    boundBaseForm.closeWithStateTransition = this.CloseWithStateTransition;
                    boundBaseForm.dynamicComponentRef = componentRef;
                    that.actionExecutedSubscription =
                        that.subscribeDynamicComponentEvent(componentRef, boundBaseForm.ActionExecuted, 'ActionExecuted', that.boundFormActionExecuted);
                    that.actionFailedSubscription =
                        that.subscribeDynamicComponentEvent(componentRef, boundBaseForm.ActionFailed, 'ActionFailed', that.boundFormActionFailed);
                    that.loadErrorOccurredSubscription =
                        that.subscribeDynamicComponentEvent(componentRef, boundBaseForm.LoadErrorOccurred, 'LoadErrorOccurred', that.boundFormLoadErrorOccurred);
                    that.loadViewModelCompletedSubscription =
                        that.subscribeDynamicComponentEvent(componentRef, boundBaseForm.LoadViewModelCompleted, 'LoadViewModelCompleted', that.boundFormLoadViewModelCompleted);
                }

                componentRef.changeDetectorRef.detectChanges();
                componentRef.onDestroy(() => {
                    componentRef.changeDetectorRef.detach();
                });

            })
            .catch(error => {
                that.messageService.showError(error);
            });
    }

    private subscribeDynamicComponentEvent(componentRef: ComponentRef<any>, targetEvent: EventEmitter<any>, eventName: string, eventFunc: any): any {
        let funcCheck = <any>componentRef.instance[eventName];
        if (funcCheck != null) {
            if (funcCheck instanceof EventEmitter) {
                let boundedFunc = eventFunc.bind(this);
                return targetEvent.subscribe(boundedFunc);
            }
        }
        return null;
    }

    ngOnInit() {
    }

    ngOnChanges() {
        this.renderSubComponent();
    }

    ngAfterViewInit() {
        this.isViewInitialized = true;
        this.renderSubComponent();
    }

    ngOnDestroy() {
        this.destroyComponent();
    }

    boundFormActionExecuted(e: any) {
        const that = this;
        let destroyComponent = true;
        if (e != null && e.IsSave === true && this.DestroyComponentOnSave === false) {
            destroyComponent = false;
        }
        if (e && e.ToStateFormDefID) {
            if (e.ToStateComponentName && e.ToStateModuleName && e.ToStateModulePath) {
                const toStateComponentInfo = { ...this.Info };
                toStateComponentInfo.ModuleName = e.ToStateModuleName;
                toStateComponentInfo.ModulePath = e.ToStateModulePath;
                toStateComponentInfo.ComponentName = e.ToStateComponentName;
                this.Info = toStateComponentInfo;
            }
        }
        if (e && e.hasOwnProperty('Cancelled')) {
            if (e.Cancelled) {
                destroyComponent = true;
            }
        }

        if (e && e.hasOwnProperty('SaveAndClose')) {
            if (e.SaveAndClose) {
                destroyComponent = true;
            }
        }

        this.DynamicComponentActionExecuted.emit(e);
        if (destroyComponent === true) {
            this.destroyComponent();
            if (this.Info.RefreshComponent) {
                setTimeout(() => {
                    that.loadSubComponent();
                }, 800);
            }
        }
    }

    boundFormActionFailed(e: any) {
        this.DynamicComponentActionFailed.emit(e);
    }

    boundFormLoadErrorOccurred(e: any) {
        this.destroyComponent();
        this.DynamicComponentLoadErrorOccurred.emit(e);
    }

    boundFormLoadViewModelCompleted(e: any) {
        if (this.ReadOnlyByCode) {
            let boundBaseForm = this.componentRef.instance as TTVisual.TTBoundFormBase;
            if (boundBaseForm) {
                boundBaseForm.ReadOnly = this.ReadOnlyByCode;
                boundBaseForm.makeStatePanelReadOnly();
            }
        }
        this.DynamicComponentViewModelLoaded.emit(e);
    }

    public isBoundFormModified() {
        if (!this.componentRef) {
            return false;
        }
        if (!this.componentRef.instance) {
            return false;
        }
        const boundBaseForm = this.componentRef.instance as TTVisual.TTBoundFormBase;
        if (boundBaseForm) {
            return boundBaseForm.isModified();
        }
        return false;
    }

}
