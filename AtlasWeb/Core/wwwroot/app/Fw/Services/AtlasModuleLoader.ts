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
        
        if (this._compiler && this._compiler.constructor.name == "CompilerImpl") {
            return this.loadAndCompileWithWebpack(modulePath, moduleName);
        }
        return this.loadAndCompile(modulePath, moduleName);
    }

    private loadAndCompileWithWebpack(modulePath: string, moduleName: string): Promise<ModuleWithComponentFactories<any>> {
        let relativeModulePath = modulePath.charAt(0) === '/' ? modulePath.substring(1) : modulePath;
        const reqModules = require.context('Modules', true, /^((?![\\/]node_modules|wwwroot[\\/]).)*Module\.ts$/);
        const appModules = require.context('app', true, /^((?![\\/]node_modules|wwwroot[\\/]|app-routing.module|app.module|auth.module).)*(module|Module)\.ts$/);
        let moduleKeyPath = '';
        let moduleTarget = '';
        if (relativeModulePath.startsWith("Modules")) {
            moduleKeyPath = './' + relativeModulePath.replace('Modules/', '') + '.ts';
            moduleTarget = reqModules.resolve(moduleKeyPath);
        } else if (relativeModulePath.startsWith("app")) {
            moduleKeyPath = './' + relativeModulePath.replace('app/', '') + '.ts';
            moduleTarget = appModules.resolve(moduleKeyPath);
        }
        const module = createModule(moduleTarget);
        const moduleType = module[moduleName];
        return this._compiler.compileModuleAndAllComponentsAsync(moduleType);
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

function createModule(id: string): any {
    return __webpack_require__(id);
}
