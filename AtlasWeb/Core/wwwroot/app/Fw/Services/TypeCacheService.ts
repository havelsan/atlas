import {
    Injectable, Compiler, ComponentFactory, ReflectiveInjector, Injector,
    ViewContainerRef, ModuleWithComponentFactories, ApplicationRef, NgModuleFactory, Type
} from '@angular/core';
import { ModuleComponentData } from '../Models/ModuleComponentData';
import { AtlasModuleLoader } from 'Fw/Services/AtlasModuleLoader';
import { MessageService } from 'Fw/Services/MessageService';

type ModuleWithDynamicComponents = Type<any> & {
    dynamicComponentsMap: {};
};

@Injectable()
export class TypeCacheService {
    Modules: Array<ModuleComponentData>;

    constructor(private compiler: Compiler
        , private injector: Injector
        , private app: ApplicationRef
        , private loader: AtlasModuleLoader
        , private messageService: MessageService) {
        this.Modules = new Array<ModuleComponentData>();
    }

    private getModuleRelativePath(modulePath: string) {
        let pathParts = modulePath.split('/');
        let relativePath = '';
        let appendPart = false;
        let lastIndex = pathParts.length - 1;
        let pathIndex = 0;
        for (let pathPart of pathParts) {
            if (pathPart === 'app' || pathPart === 'Modules') {
                appendPart = true;
            }

            if (appendPart) {
                relativePath += pathPart;
                if (pathIndex < lastIndex)
                    relativePath += '/';
            }
            ++pathIndex;
        }
        return relativePath;
    }

    public LoadTypeForJit(ModulePath: string, TypePath: string, viewContainer: ViewContainerRef, routeData: any = null, routeData2: any = null): void {
        let that = this;
        let component: ComponentFactory<any>;
        let moduleRelativePath = this.getModuleRelativePath(ModulePath);
        let moduleName = ModulePath.substring(ModulePath.lastIndexOf("/") + 1);
        let componentName = TypePath.substring(TypePath.lastIndexOf("/") + 1);

        let injector = ReflectiveInjector.fromResolvedProviders([], viewContainer.parentInjector);
        
        this.loader.load(moduleRelativePath, moduleName)
            .then((moduleWithFactories: ModuleWithComponentFactories<any>) => {
                const cmpFactory = moduleWithFactories.componentFactories.find(x => x.componentType.name === componentName);
                if (!cmpFactory) {
                    throw new Error(`'${componentName}' bileşeni '${moduleRelativePath}' içerisinde bulunamadı`);
                }
                let componentRef = viewContainer.createComponent(cmpFactory, 0, this.injector, []);
                componentRef.instance.RouteData = routeData;
                componentRef.instance.RouteData2 = routeData2;

                componentRef.changeDetectorRef.detectChanges();
                componentRef.onDestroy(() => {
                    componentRef.changeDetectorRef.detach();
                });

            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    public LoadTypeForAot(ModulePath: string, TypePath: string, viewContainer: ViewContainerRef, routeData: any = null, routeData2: any = null): void {
        let that = this;
        let moduleName = ModulePath.substring(ModulePath.lastIndexOf("/") + 1);
        let componentName = TypePath.substring(TypePath.lastIndexOf("/") + 1);

        let injector = ReflectiveInjector.fromResolvedProviders([], viewContainer.parentInjector);
        
        this.loader.loadModule(ModulePath, moduleName)
            .then((moduleFactory: NgModuleFactory<any>) => {
               
                const moduleReference = moduleFactory.create(injector);
                const componentResolver = moduleReference.componentFactoryResolver;
                const componentType = (moduleFactory.moduleType as ModuleWithDynamicComponents).dynamicComponentsMap[componentName];

                const componentFactory = componentResolver.resolveComponentFactory(componentType);
                if (!componentFactory) {
                    throw new Error(`'${componentName}' bileşeni '${moduleName}' içerisinde bulunamadı`);
                }
                
                const componentRef = viewContainer.createComponent<any>(componentFactory, 0, this.injector, []);
                componentRef.instance.RouteData = routeData;
                componentRef.instance.RouteData2 = routeData2;

                componentRef.changeDetectorRef.detectChanges();
                componentRef.onDestroy(() => {
                    componentRef.changeDetectorRef.detach();
                });

            })
            .catch(error => {
                that.messageService.showError(error);
            });

    }

    public LoadType(ModulePath: string, TypePath: string, viewContainer: ViewContainerRef, routeData: any = null, routeData2: any = null): void {
        if (this.compiler && this.compiler.constructor.name == "CompilerImpl") {
            return this.LoadTypeForJit(ModulePath, TypePath, viewContainer, routeData, routeData2);
        }
        return this.LoadTypeForAot(ModulePath, TypePath, viewContainer, routeData, routeData2);
    }

}