import { Component, ViewContainerRef, AfterViewInit, ComponentFactoryResolver } from '@angular/core';
import { ITabPanel } from './HvlTabPanel';
import { TypeCacheService } from '../Services/TypeCacheService';

@Component({
    selector: 'hvl-tab',
    inputs: ['TabData', 'TabIndex'],
    template: '<div></div>'
})
export class HvlTab implements AfterViewInit {
    TabData: ITabPanel;
    TabIndex: Number;
    constructor(private viewContainer: ViewContainerRef,
        private loader: ComponentFactoryResolver,
        private typeService: TypeCacheService) {
    }

    ngAfterViewInit() {
        this.typeService.LoadType(this.TabData.ModulePath, this.TabData.ComponentPath, this.viewContainer, this.TabData.RouteData, this.TabData.RouteData2);
    }
}