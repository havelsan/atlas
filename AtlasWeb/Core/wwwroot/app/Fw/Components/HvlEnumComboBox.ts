import {
    Component, SimpleChanges, OnChanges, KeyValueDiffers,
    ElementRef, Optional, AfterViewInit, OnDestroy, Input, Output, EventEmitter
} from '@angular/core';
import { BaseSelectBox } from './BaseControls/BaseSelectBox';
import { DataGridMessageService } from '../Services/DataGridMessageService';
import { ConfigurationCacheService } from '../Services/ConfigurationCacheService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Subscription } from 'rxjs';
import { getClassType } from 'NebulaClient/ClassTransformer';
import { SortByEnum } from 'NebulaClient/Utils/Enums/SortByEnum';

const NamePropertyName = 'Name';
const ValuePropertyName = 'Value';
const KeyPropertyName = 'Key';

@Component({
    selector: 'hvl-enum-combobox',
    inputs: ['Required', 'ReadOnly', 'Name', 'Enabled',
        'Visible', 'TabIndex',
        'BackColor', 'ForeColor','ngClass',
        'Font', 'DataTypeName', 'ShowClearButton'],
    template: `<dx-select-box [visible]="Visible" [disabled]="!Enabled" [readOnly]="ReadOnly" [ngClass]="ngClass" [value]="Value"
    searchEnabled="true"  placeholder="" [searchMode]="SearchMode"
    [showClearButton]="ShowClearButton" [displayExpr]="DisplayPath" [valueExpr]="SelectedValuePath" [dataSource]="Items"
     (onValueChanged)="valueChanged($event.value)"
     height="height" ></dx-select-box>`
})
export class HvlEnumComboBox extends BaseSelectBox implements OnChanges, AfterViewInit, OnDestroy {

    @Input() Value: any;
    @Input() IncludeOnly: Array<number>;
    @Input() SortBy: SortByEnum;
    @Output() ValueChange: EventEmitter<any> = new EventEmitter<any>();
    ngClass = [];

    SearchMode: String = 'startswith';
    DataTypeName: string;

    private gridMessageServiceSubscription: Subscription;

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        protected http: NeHttpService,
        @Optional() private gridMessageService: DataGridMessageService,
        private configCache: ConfigurationCacheService) {
        super(differs, element);
        this.DisplayPath = NamePropertyName;
        this.SelectedValuePath = ValuePropertyName;
        if (this.gridMessageService) {
            let that = this;
            this.gridMessageServiceSubscription = this.gridMessageService.OnMessage.subscribe(t => {
                if (t.name === that.Name) {
                    if (t.messageName.startsWith('Font.')) {
                        let fontProperty = t.messageName.substr(t.messageName.indexOf('.') + 1);
                        this.Font[fontProperty] = t.content;
                        this.setAppearence();
                    } else {
                        that[t.messageName] = t.content;
                        if (t.messageName === 'DataTypeName') {
                            this.changeEnumName();
                        } else {
                            this.setAppearence();
                        }
                    }
                }
            });
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['IncludeOnly']) {
            this.Items = this.includeEnums(this.Items);
        }
        if (changes['DataTypeName'] && this.DataTypeName) {
            this.changeEnumName();
        }
        if (changes['showClearButton'] && this.ShowClearButton === undefined) {
            this.ShowClearButton = false;
        }
        let changesEnabled = changes['Enabled'];
        if (changesEnabled != null) {
            if (changesEnabled.currentValue === false && changesEnabled.previousValue === true) {
                this.Value = null;
            }
        }
        super.ngOnChanges(changes);
    }

    ngAfterViewInit() {
        if (this.gridMessageService) {
            this.height = "22px";
        }
        this.element.nativeElement.parentElement.parentElement.style.padding = "0px";
    }

    loadEnumList() {
        const itemsArray = new Array<any>();
        const enumListTypeClassName = `${this.DataTypeName}List`;
        const classType = getClassType(enumListTypeClassName);
        if (classType) {
            const enumListManager: any = Object.create(classType.prototype);
            if (enumListManager) {
                const enumItems = enumListManager.Items;
                for (const enumItem of enumItems) {
                    const newEnumItem = { Name: enumItem.description, Key: enumItem.name, Value: enumItem.code };
                    itemsArray.push(newEnumItem);
                }

                const propComparator = (propName) => (a, b) =>  a[propName].localeCompare(b[propName]);
                const filteredItems = this.includeEnums(itemsArray);
                let sortedFilteredItems = filteredItems;
                if (this.SortBy === SortByEnum.DisplayText) {
                    sortedFilteredItems = filteredItems.sort(propComparator(NamePropertyName));
                } else if (this.SortBy === SortByEnum.Name) {
                    sortedFilteredItems = filteredItems.sort(propComparator(KeyPropertyName));
                } else if (this.SortBy === SortByEnum.Value) {
                    sortedFilteredItems = filteredItems.sort((a, b) => a.Value - b.Value);
                }
                this.Items = sortedFilteredItems;
            }
        }
    }

    changeEnumName() {
        let that = this;
        if (that.DataTypeName) {
            this.loadEnumList();
        }
    }

    includeEnums(data: Array<any>) {
        if (this.IncludeOnly && this.IncludeOnly.length > 0 && data) {
            return data.filter((value) => {
                return !this.IncludeOnly.Contains(value.Value);
            });
        }
        return data;
    }

    valueChanged(e: any) {
        this.Value = e;
        this.ValueChange.emit(this.Value);
    }

    ngOnDestroy() {
        if (this.gridMessageServiceSubscription != null) {
            this.gridMessageServiceSubscription.unsubscribe();
            this.gridMessageServiceSubscription = null;
        }
    }

}