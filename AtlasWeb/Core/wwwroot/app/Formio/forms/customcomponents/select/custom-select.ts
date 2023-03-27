import { Component, OnInit, EventEmitter, Input, OnDestroy } from '@angular/core';
import { FormioCustomComponent } from 'angular-formio';
import ODataStore from 'devextreme/data/odata/store';
import { ODataGridConfig } from 'app/ODataEditor/Models/ODataColumnDto';
import { ODataDynamicGridConfig } from '../../dynamicgrid/dynamic-grid';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { ODataBuilder } from 'app/ODataEditor/Models/ODataObject';

@Component({
    selector: 'custom-select',
    templateUrl: './custom-select.html',
    styleUrls: []
})
export class CustomSelectComponent implements FormioCustomComponent<any>, OnInit, OnDestroy {

    value: any;
    valueChange: EventEmitter<any>;
    disabled: boolean;
    formioEvent?: EventEmitter<any>;
    public config: ODataDynamicGridConfig;

    private _selectConfig: any;
    @Input()
    set selectConfig(value: string) {
        if (value == null || value.length == 0) {
            return;
        }
        this._selectConfig = JSON.parse(value);
        this.parseDevextremeObject(this._selectConfig);
        this.loadDataSource();
    };
    get selectConfig(): string {
        return this._selectConfig;
    };

    private _displayExpr: string;
    @Input()
    set displayExpr(value: string) {
        if (value == null || value.length == 0) {
            this._displayExpr = "Name";
            return;
        }
        this._displayExpr = value;
        //this.loadDataSource();
    }
    get displayExpr(): string {
        return this._displayExpr || "Name";
    }

    private _valueExpr: string;
    @Input()
    set valueExpr(value: string) {
        if (value == null || value.length == 0) {
            this._valueExpr = "ObjectId";
            return;
        }
        this._valueExpr = value;
        //this.loadDataSource();
    }
    get valueExpr(): string {
        return this._valueExpr || "ObjectId";
    }

    dataSource: any = [];
    showClearButton: boolean = false;
    selectedValue: string = "";

    constructor(private httpService: NeHttpService) { }

    ngOnInit(): void {
        addEventListener('CustomComponentEvent', (e) => {
            let event = e as CustomEvent;
            let data = event.detail;
            let changed = false;
            if (this.config) {
                this.config.filter.forEach(p => {
                    if (p) {
                        let paramKey = (p[3] as string).substring(2, p[3].length - 2);
                        if (data[paramKey] && data[paramKey] != p[2]) {
                            p[2] = data[paramKey];
                            changed = true;
                        }
                    }
                });
                if (changed) {
                    this.loadDataSource();
                }
            }
        });
    }

    loadDataSource() {
        this.dataSource = {
            store: new ODataStore({
                key: this.valueExpr,

                url: this.config.url,
                version: 4,
                onLoaded: (result) => {
                    if (result == null || result.length == 0) {
                        return;
                    }
                    console.log(result);
                }
            }),
            select: this.config.select,
            filter: this.config.filter.length == 0 ? null : this.config.filter.map(p => p.slice(0, 3)),
            paginate: true,
            pageSize: 10
        }
    }

    parseDevextremeObject(odataGridConfig: ODataGridConfig) {
        this.config = {
            url: odataGridConfig.url,
            filter: [],
            select: [],
        };
        let odataBuilder = new ODataBuilder();
        this.config.select = odataGridConfig.items.filter(x => x.Listed == true).map(x => x.Path.split('/').filter(y => y != "").join('.'));
        this.config.filter = odataGridConfig.items.filter(x => x.WhereCondition != null).map(x =>
            [
                x.Path.split('/').filter(x => x != "").join("."),
                odataBuilder.convertConditions(x.WhereCondition.Operation),
                odataBuilder.convertTypes(x.WhereCondition.Value, x.Type),
                x.WhereCondition.Value
            ]);
    }

    ngOnDestroy(): void {
        //removeEventListener(this._eventName, this.eventFunction);
    }
}
