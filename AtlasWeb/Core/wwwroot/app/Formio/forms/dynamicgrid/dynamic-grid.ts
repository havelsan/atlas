import { Component, EventEmitter, Input, Output, OnInit, OnDestroy } from '@angular/core';
import { FormioCustomComponent, FormioCustomComponentInfo } from 'angular-formio';
import 'devextreme/data/odata/store';
import ODataStore from 'devextreme/data/odata/store';
import DevExpress from 'devextreme/bundles/dx.all';
import { environment } from 'app/environments/environment';
import { ODataGridConfig } from 'app/ODataEditor/Models/ODataColumnDto';
import { ODataBuilder } from 'app/ODataEditor/Models/ODataObject';
@Component({
    selector: 'dynamic-grid',
    templateUrl: './dynamic-grid.html',
    styleUrls: []
})
export class DynamicGrid implements FormioCustomComponent<number>, OnInit, OnDestroy {

    dataSource: any = [];
    columns: Array<DevExpress.ui.dxDataGridColumn> = [];

    @Input()
    value: number;

    @Output()
    valueChange: EventEmitter<number> = new EventEmitter<number>();

    @Input()
    disabled: boolean;



    private _gridColumns: any;
    @Input()
    set gridColumns(value: string) {
        if (value == null || value.length == 0) {
            return;
        }
        this._gridColumns = JSON.parse(value);
        this.loadDataSource();
        console.log(value);
    }
    get gridColumns(): string {
        return this._gridColumns;
    }


    public dynamicGridConfig: ODataDynamicGridConfig;
    private _gridConfig: any;
    @Input()
    set gridConfig(value: string) {
        if (value == null || value.length == 0) {
            return;
        }
        this._gridConfig = JSON.parse(value);
        this.parseDevextremeObject(this._gridConfig);
        this.loadDataSource();
    }
    get gridConfig(): string {
        return this._gridConfig;
    }


    constructor() {

    }

    ngOnInit(): void {
        addEventListener('CustomComponentEvent', (e) => {
            let event = e as CustomEvent;
            let data = event.detail;
            let changed = false;
            if (this.dynamicGridConfig) {
                this.dynamicGridConfig.filter.forEach(p => {
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
                url: this.dynamicGridConfig.url,
                version: 4,
                onLoaded: (result) => {
                    if (result == null || result.length == 0) {
                        return;
                    }
                }
            }),
            select: this.dynamicGridConfig.select,
            filter: this.dynamicGridConfig.filter.length == 0 ? null : this.dynamicGridConfig.filter.map(p => p.slice(0, 3)),
            paginate: true,
            pageSize: 10
        }
    }

    paths(root) {
        let paths = [];
        let nodes = [{
            obj: root,
            path: []
        }];
        while (nodes.length > 0) {
            let n = nodes.pop();
            if (n.obj == null) {
                continue;
            }
            Object.keys(n.obj).forEach(k => {
                if (typeof n.obj[k] === 'object') {
                    let path = n.path.concat(k);
                    paths.push(path);
                    nodes.unshift({
                        obj: n.obj[k],
                        path: path
                    });
                }
            });
        }
        return paths;
    }

    exploreColumns(node) {
        let result = this.paths(node);
        for (let index = 0; index < result.length; index++) {
            let item: Array<string> = result[index];
            let path = item.join('.');
            let prop = eval("node." + path);
            if (prop && !this.isObject(prop)) {
                this.columns.push({
                    caption: item[item.length - 1],
                    dataField: path,
                });
            }
        }
    }

    isObject(val) {
        if (val === null) { return false; }
        return ((typeof val === 'function') || (typeof val === 'object'));
    }

    parseDevextremeObject(odataGridConfig: ODataGridConfig) {
        this.dynamicGridConfig = {
            url: odataGridConfig.url,
            filter: [],
            select: [],
        };
        let odataBuilder = new ODataBuilder();
        this.dynamicGridConfig.select = odataGridConfig.items.filter(x => x.Listed == true).map(x => x.Path.split('/').filter(y => y != "").join('.'));
        this.dynamicGridConfig.filter = odataGridConfig.items.filter(x => x.WhereCondition != null).map(x =>
            [
                x.Path.split('/').filter(x => x != "").join("."),
                odataBuilder.convertConditions(x.WhereCondition.Operation),
                odataBuilder.convertTypes(x.WhereCondition.Value, x.Type),
                x.WhereCondition.Value
            ]);
    }

    updateValue(payload: number) {
        this.value = payload; // Should be updated first
        this.valueChange.emit(payload); // Should be called after this.value update
    }

    ngOnDestroy(): void {
    }
}


export class ODataDynamicGridConfig {
    url: string;
    select: Array<string>;
    filter: Array<Array<any>>;
}