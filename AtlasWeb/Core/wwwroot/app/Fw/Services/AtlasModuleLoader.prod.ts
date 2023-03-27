import { Compiler, Injectable, ModuleWithComponentFactories, NgModuleFactoryLoader, NgModuleFactory } from '@angular/core';

@Injectable()
export class AtlasModuleLoader {

    constructor(private _compiler: Compiler, private moduleLoader: NgModuleFactoryLoader) {
    }

    loadModule(modulePath: string, moduleName: string): Promise<NgModuleFactory<any>> {

        const normalizedModulePath = modulePath.replace(/^[/]+/g, '');
        let targetModulePath = normalizedModulePath;
        if ( modulePath.startsWith('/app/')) {
            targetModulePath = `wwwroot/${normalizedModulePath}`;
        }

        const modulePathForLoader = `${targetModulePath}#${moduleName}`;
        return this.moduleLoader.load(modulePathForLoader);
    }

    load(modulePath: string, moduleName: string): Promise<ModuleWithComponentFactories<any>> {
        
        return this.loadAndCompile(modulePath, moduleName);
    }

    private loadAndCompile(modulePath: string, moduleName: string): Promise<ModuleWithComponentFactories<any>> {
        return import(modulePath)
            .then((module: any) => module[moduleName])
            .then((type: any) => checkNotEmpty(type, modulePath, moduleName))
            .then((type: any) => this._compiler.compileModuleAndAllComponentsAsync(type));
    }
}

function checkNotEmpty(value: any, modulePath: string, exportName: string): any {
    if (!value) {
        throw new Error(`Cannot find '${exportName}' in '${modulePath}'`);
    }
    return value;
}
