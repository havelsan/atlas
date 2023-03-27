import { Injectable, ComponentRef } from '@angular/core';
import { IActiveComponentRegistryService } from './IActiveComponentRegistryService';

@Injectable()
export class AtlasActiveComponentRegistryService implements IActiveComponentRegistryService {

    public _componentList: Map<ComponentRef<any>, ComponentRef<any>>;

    constructor() {
        this._componentList = new Map<ComponentRef<any>, ComponentRef<any>>();
    }

    public registerComponent(componentRef: ComponentRef<any>) {
        if (this._componentList.has(componentRef) === false) {
            this._componentList.set(componentRef, componentRef);
        }
    }

    public unregisterComponent(componentRef: ComponentRef<any>) {
        if (this._componentList.has(componentRef) === false) {
            this._componentList.delete(componentRef);
        }
    }

    public activeComponents(): Array<ComponentRef<any>> {
        const compList = new Array<ComponentRef<any>>();
        this._componentList.forEach((compRef, index, map) => {
            compList.push(compRef);
        });
        return compList;
    }

}