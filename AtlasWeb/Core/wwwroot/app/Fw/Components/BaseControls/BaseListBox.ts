import { EventEmitter, KeyValueDiffers, ElementRef, SimpleChanges, ViewChild, Directive } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { BaseControl } from './BaseControl';

import { TTAutoCompleteGrid, LoadDataSourceEventArgs, SearchMode, AutoCompleteMode, PagedResult, ListBoxSearchCriteria } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';
import { AsyncSubject } from 'rxjs';
import { HvlAutoCompleteGrid } from 'Fw/Components/HvlAutoCompleteGrid';
import { ConfigurationCacheService } from 'Fw/Services/ConfigurationCacheService';
@Directive()
export class BaseListBox extends BaseControl {
    @ViewChild(HvlAutoCompleteGrid) autoCmp: HvlAutoCompleteGrid;
    PreviousSelectedValue: String;
    _SelectedObject: any;
    get SelectedObject(): any {
        return this._SelectedObject;
    }
    set SelectedObject(f: any) {
        this._SelectedObject = f;
    }
    DefinitionName: String;
    _Filter: String;
    get Filter(): String {
        return this._Filter;
    }
    set Filter(f) {
        this._Filter = f;
    }
    ListFilterExpression: String;
    SelectedValue: any;
    DialogWidth: String;
    Columns: Array<any>;
    AutoCompleteMode: AutoCompleteMode;
    SearchMode: SearchMode;
    AutoCompleteDialogWidth: any;
    AutoCompleteDialogHeight: any;
    MinSearchLength: Number;
    SearchTimeout: Number;
    LoadedDefinitions: any;

    PopupDialogFieldConfig: Array<ListBoxSearchCriteria>;
    PopupDialogGridColumns: Array<any>;
    PopupDialogWidth: any;
    PopupDialogHeight: any;
    PopupDialogTitle: String;

    SelectedObjectChange: EventEmitter<any> = new EventEmitter<any>();
    SelectedValueChange: EventEmitter<any> = new EventEmitter<any>();

    Toggle() {
        if (!this.autoCmp.autoCompleteDialogOpened) {
            this.autoCmp.Focus();
            this.autoCmp.toggleDialog();
        }
        else {
            this.autoCmp.autoCompleteDialogOpened = false;
            this.autoCmp.Blur();
        }
    }

    listDefSearch: TTAutoCompleteGrid = <TTAutoCompleteGrid>{
        MinSearchLength: 0,
        EnablePaging: true,
        GridPageSize: 10,
        AutoCompleteMode: AutoCompleteMode.List,
        AutoCompleteDisplayExpression: "GeneratedDisplayExpression",
        SearchMode: SearchMode.OnEnterPressed,
        IdExpression: "ObjectID",
        SearchTimeout: 500
    };

    constructor(differs: KeyValueDiffers,
        element: ElementRef,
        protected http: NeHttpService,
        private configCache: ConfigurationCacheService) {
        super(differs, element);
    }

    LoadAllDefinitions() {
        if (!this.DefinitionName) {
            return;
        }

        let listFilterQuery = this.ListFilterExpression ? "&listFilterExpression=" + this.ListFilterExpression : "";
        let url = "api/DefinitionQuery/GetDefinitionsAll?listDefName=" + this.DefinitionName + listFilterQuery;
        let that = this;
        this.http.get(url).then((t) => {
            that.LoadedDefinitions = t;
        });
    }

    beforeOpen(promise: AsyncSubject<any>) {
        if (!this.Columns || !(this.Columns.length == 0)) {
            this.loadConfig().then(t => {
                promise.next(null);
                promise.complete();
            });
        }
        else {
            promise.next(null);
            promise.complete();
        }
    }

    protected GetDefinitionLoadRequest(enablePaging: Boolean, skip: Number, take: Number, requireTotalCount: Boolean): Promise<PagedResult> {
        let result: PagedResult = new PagedResult();
        let takeQuery, skipQuery: String = '';
        if (!this.DefinitionName) {
            return Promise.resolve(result);
        }

        let filterQuery = this.Filter ? "&filter=" + this.Filter : "";
        let listFilterQuery = this.ListFilterExpression ? "&listFilterExpression=" + this.ListFilterExpression : "";
        let requireCountQuery = requireTotalCount ? "&requireTotalCount=true" : "&requireTotalCount=false";
        let pageQuery = enablePaging ? "&enablePaging=true" : "enablePaging=false";
        if (enablePaging) {
            takeQuery = "&take=" + take.toString();
            skipQuery = "&skip=" + (!skip ? "0" : skip).toString();
        }
        let url = "api/DefinitionQuery/Query?definitionName=" + this.DefinitionName + filterQuery + listFilterQuery + requireCountQuery + pageQuery + takeQuery + skipQuery;
        let that = this;
        return this.http.get(url).then((t) => {
            return t as PagedResult;
        });
    }

    protected valueChanged(data: any) {
        // if (data == undefined) {
        //     data = null;
        // }
        if (!data) {
            this.SelectedObject = data;
            this.SelectedValue = data;
            this.SelectedObjectChange.emit(data);
            this.SelectedValueChange.emit(data);
            this.PreviousSelectedValue = null;
            return;
        }
        else if (data == null && !this.PreviousSelectedValue) {
            return;
        }
        else {
            this.SelectedObject = data;
            this.SelectedObjectChange.emit(data);
            let value: any = !data ? null : data.ObjectID;
            this.SelectedValue = value;
            this.SelectedValueChange.emit(this.SelectedValue);
            this.PreviousSelectedValue = data.ObjectID;
        }
    }

    onDataSourceRefresh(ev: LoadDataSourceEventArgs) {
        let that = this;
        let data: Array<any>;
        let result: PagedResult = new PagedResult();
        this.Filter = ev.Filter;
        if (!ev.IsPopupDataSource)
            ev.AsyncLoader = this.GetDefinitionLoadRequest(true, ev.Skip, ev.Take, ev.RequireCount);
        else {
            let listFilterQuery = this.ListFilterExpression ? "&listFilterExpression=" + this.ListFilterExpression : "";
            let requireCountQuery = ev.RequireCount ? "&requireTotalCount=true" : "&requireTotalCount=false";

            let takeQuery: String = "&take=" + (!ev.Take ? "0" : ev.Take).toString();
            let skipQuery: String = "&skip=" + (!ev.Skip ? "0" : ev.Skip).toString();
            let url = "api/DefinitionQuery/DetailedQuery?definitionName=" + this.DefinitionName + listFilterQuery + requireCountQuery + takeQuery + skipQuery;
            ev.PopupAsyncLoader = this.http.post(url, this.PopupDialogFieldConfig);
        }
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['BackColor'] && this.BackColor) {
            this.listDefSearch.BackColor = this.BackColor;
        }
        if (changes['ForeColor'] && this.ForeColor) {
            this.listDefSearch.ForeColor = this.ForeColor;
        }
        if (changes['MinSearchLength']) {
            this.listDefSearch.MinSearchLength = this.MinSearchLength;
        }
        if (changes['AutoCompleteMode'] && !this.AutoCompleteMode) {
            this.AutoCompleteMode = AutoCompleteMode.Grid;
        }
        if (changes['SearchMode']) {
            if (this.SearchMode == undefined) {
                this.SearchMode = SearchMode.OnKeyPressed;
            }
        }
        //if (changes['DefinitionName'] && this.DefinitionName) {
        //    this.loadConfig();
        //}
        super.ngOnChanges(changes);
    }

    findByValue(displayExpressionCache: any): Promise<any> {
        let that = this;
        if (this.DefinitionName && this.SelectedValue) {

            if (displayExpressionCache) {
                const mapKey = `${this.SelectedValue}~${this.DefinitionName}`;
                const foundItem = displayExpressionCache[mapKey];
                if (foundItem) {
                    return Promise.resolve(foundItem);
                }
            }

            return this.http.get("api/DefinitionQuery/GetDefinitionById?definitionId=" + this.SelectedValue + "&listDefName=" + this.DefinitionName).then((res) => {
                if (displayExpressionCache && res) {
                    const mapKey = `${that.SelectedValue}~${that.DefinitionName}`;
                    displayExpressionCache[mapKey] = res;
                }
                return res;
            });
        }
        else {
            return Promise.resolve(null);
        }
    }

    loadConfig(): Promise<any> {
        let that = this;
        if (this.DefinitionName) {
            return that.configCache.GetListBoxConfig(this.DefinitionName.toString()).then(columns => {
                that.PopupDialogGridColumns = columns;
                that.Columns = columns;
            });
        }
        else
            return Promise.resolve(null);
    }

    openPopup() {
        this.autoCmp.openPopupDialog();
    }
}