import { Component, SimpleChanges, EventEmitter,
     OnChanges, OnDestroy, KeyValueDiffers, ElementRef, Optional, ViewChild, AfterViewInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { BaseListBox } from './BaseControls/BaseListBox';
import { DxSelectBoxComponent } from 'devextreme-angular';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
import { Subscription } from 'rxjs';

@Component({
    selector: 'hvl-listdef-combobox',
    inputs: ['Required', 'ReadOnly', 'Name', 'SearchingMode',
        'Visible', 'TabIndex', 'BackColor', 'ForeColor', 'Enabled',
        'Font', 'DefinitionName', 'SelectedObject', 'SelectedValue'],
    outputs: ['SelectedObjectChange', 'SelectedValueChange'],
    template: '<dx-select-box [visible]="Visible"  [disabled]="!Enabled" [readOnly]="ReadOnly" searchEnabled="true" displayExpr="GeneratedDisplayExpression" placeholder="" height="height" [searchMode]="SearchingMode" showClearButton="true" \
            [dataSource]="LoadedDefinitions" valueExpr="ObjectID" [(value)]="SelectedValue" valueExpr="ObjectID" (selectedItemChange)="changed($event)">\
    </dx-select-box>'
})
export class HvlListDefComboBox extends BaseListBox implements OnChanges, OnDestroy, AfterViewInit {
    SelectedValueChange: EventEmitter<any> = new EventEmitter<any>();
    SearchingMode: string = "startswith";
    private gridMessageServiceSubscription: Subscription;

    @ViewChild(DxSelectBoxComponent) SelectBox: DxSelectBoxComponent;

    constructor(differs: KeyValueDiffers, element: ElementRef, http: NeHttpService, @Optional() private gridMessageService: DataGridMessageService, cacheService: ConfigurationCacheService) {
        super(differs, element, http, cacheService);
        if (this.gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name == that.Name) {
                    if (t.messageName.startsWith("Font.")) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        this.Font[fontProperty] = t.content;
                        this.setAppearence();
                    }
                    else {
                        that[t.messageName] = t.content;
                        if (t.messageName == "ListDefName") {
                            //this.LoadDefinitions();
                        }
                        else
                            this.setAppearence();
                    }
                }
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['SearchingMode'] && !this.SearchingMode) {
            this.SearchingMode = "startswith";
        }
        if (changes['DefinitionName'] && this.DefinitionName) {
            this.LoadAllDefinitions();
            delete changes['DefinitionName'];
        }
        if (changes['SelectedObject'] && this.SelectedObject) {
            this.SelectedValue = this.SelectedObject.ObjectID;
            this.SelectedValueChange.emit(this.SelectedValue);
            //this.findByValue().then(t => {
            //    this.SelectedObject = t;
            //});
        }
        super.ngOnChanges(changes);
    }

    changed(data: any) {
        this.SelectedObject = data;
        this.SelectedObjectChange.emit(this.SelectedObject);
        if (this.SelectedObject) {
            this.SelectedValue = this.SelectedObject.ObjectID;
        }
        else {
            this.SelectedValue = null;
        }
        this.SelectedValueChange.emit(this.SelectedValue);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px";
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    ngOnDestroy() {
        if ( this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }
}