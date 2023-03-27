import {ComponentFactory, Injector} from '@angular/core';

export class ModuleComponentData {
    constructor(public ModulePath: string,
        public injector: Injector,
        public Components: ComponentFactory<any>[]) {
    }
}