import { Component, ElementRef, KeyValueDiffers, ContentChildren, QueryList, IterableDiffers, DoCheck, SimpleChanges } from '@angular/core';
import { HvlTabPage } from './HvlTabPage';
import { BaseControl } from '..//BaseControls/BaseControl';
import { ITTTabPage } from 'NebulaClient/Visual/ControlInterfaces/TTTabControl/ITTTabPage';

@Component({
    template: '<div *ngIf="Visible">\
                    <ul class="nav nav-tabs">\
                        <li *ngFor="let page of TabPages" class="nav"><a href="#{{page.Name}}" data-toggle="tab">{{page.Text}}</a></li>\
                    </ul><div class="tab-content">\
                    <ng-content></ng-content></div>\
                </div>',
    inputs: ['TabPages'],
    selector: 'hvl-tab-control'
})
export class HvlTabControl extends BaseControl implements DoCheck /*OnChanges,AfterContentInit, AfterViewInit*/ {

    @ContentChildren(HvlTabPage) Pages: QueryList<HvlTabPage>;
    TabPages: Array<ITTTabPage> = new Array<ITTTabPage>();
    PageArrayDiffers: any;
    PageDiffers: any = {};

    constructor(element: ElementRef,
        differs: KeyValueDiffers,
        private iterableDiffers: IterableDiffers) {
        super(differs, element);
        this.PageArrayDiffers = this.iterableDiffers.find([]).create(null);
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['TabPages'] && this.TabPages) {
            for (let i = 0; i < this.TabPages.length; i++) {
                this.PageDiffers[this.TabPages[i].Name] = this.differs.find(this.TabPages[i]);
            }
        }
    }

    ngDoCheck() {
        let pageChanges: any = this.PageArrayDiffers.diff(this.TabPages);
    }

    //ngAfterViewInit() {
    //    super.ngAfterViewInit();
    //    this.TitleContainer = <HTMLUListElement>this.element.nativeElement.firstChild.getElementsByTagName('ul')[0];
    //}

    //ngAfterContentInit() {
    //    if (this.TabPages && this.TabPages.length > 0) {
    //        let that = this;
    //        this.TabPages.forEach((item) => {

    //        });
    //    }
    //}

}