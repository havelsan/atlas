import { Component, OnInit, ViewChild, Output, EventEmitter, Input } from '@angular/core';
import { ModelDto } from '../Models/ModelDto';
import { ODataColumnDto } from '../Models/ODataColumnDto';
import { ODataObject } from '../Models/ODataObject';
import { DxSelectBoxComponent, DxTreeListComponent, DxTextBoxComponent } from 'devextreme-angular';
import buildQuery from 'odata-query';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import f from 'odata-filter-builder';
import { ODataWhereDto } from '../Models/ODataWehereDto';
import { environment } from 'app/environments/environment';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { first } from 'rxjs/operators';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';

@Component({
    selector: 'odata-editor',
    templateUrl: './odata-editor.component.html',
    styleUrls: []
})
export class ODataEditorComponent implements OnInit {

    @Output() onClose = new EventEmitter<any>();
    @Input() dynamicParameters: Array<string>;

    public models: Array<ModelDto> = [];
    public selectedModel: ModelDto = null;
    public createChildren: any;
    public oDataQuery: string;
    public showFilterPopup: boolean = false;
    public selectedColumn: any = { data: { text: "" } };
    public filterOperation: string;
    public filterValue: any = {};
    public showoDataEditor: boolean = false;
    public searchEnabled: boolean = true;
    dataSourceId: string = "";
    showQueryPreview: boolean = false;
    odataDataSources: any[] = [];
    dataSource: any;
    editData: any = [];
    selectedRows: string[] = [];
    expandedRowKeys: string[] = [];
    conditions: ODataColumnDto[] = [];
    modelSelectedItems: ODataColumnDto[] = [];
    orderTypes: string[] = ["None", "asc", "desc"];
    orderType: string = this.orderTypes[0];
    queryJson: ODataObject = new ODataObject();
    topCountItems: string[] = ["Count", "1", "10", "20", "50", "100", "1000", "10000"];
    whereOperations: any[] = [
        { Text: 'Seçiniz' },
        { Text: 'Eşittir', Operation: 'eq' },
        { Text: 'Eşit Değildir', Operation: 'ne' },
        { Text: 'İçerir (; ile ayırabilirsiniz.)', Operation: 'in-eq' },
        // { Text: 'case-insensitive equals', Operation: 'tolower' },
        // { Text: 'case-insensitive not equals', Operation: 'not-tolower' },
        { Text: 'İle başlayan', Operation: 'startswith' },
        // { Text: 'does not start with', Operation: 'not-startswith' },
        // { Text: 'ends with', Operation: 'endswith' },
        // { Text: 'does not end with', Operation: 'not-endswith' },
        { Text: 'İçerir', Operation: 'contains' },
        // { Text: 'has length', Operation: 'length' }
    ];

    @ViewChild('countSelect') countSelect: DxSelectBoxComponent;
    @ViewChild('treeList') treeList: DxTreeListComponent;
    @ViewChild('txtDataSource') txtDataSource: DxTextBoxComponent;
    @ViewChild('dataSourceList') dataSourceList: DxSelectBoxComponent;

    constructor(private httpService: NeHttpService
    ) {
        this.dataSource = {
            key: 'id',
            load: async (loadOptions) => {
                let queryString = "?parentId=" + (loadOptions.parentIds == null ? "" : loadOptions.parentIds[0])
                    + "&filterValue=" + (loadOptions.filter.filterValue == null ? "" : loadOptions.filter.filterValue);
                if (loadOptions.parentIds && loadOptions.parentIds[0]) {
                    let parentNode = this.treeList.instance.getNodeByKey(loadOptions.parentIds[0]);
                    if (parentNode) {
                        queryString += "&parentPath=" + parentNode.data.path;
                    }
                }
                return await httpService.get<any>('/api/OData/GetModelList' + queryString);
            }
        }
    }

    loadDataSources() {
        this.httpService.get<any>('/api/DynamicForm/GetDataSources?type=1').then(p => {
            if (p) {
                this.odataDataSources = p;
            }
        });
    }

    onDataSourceChanged(e) {
        this.clearComponent();
        if (e.selectedItem) {
            this.dataSourceId = e.selectedItem.ObjectID;
            this.txtDataSource.value = e.selectedItem.Name;
            this.modelSelectedItems = JSON.parse(e.selectedItem.ApiConfig);
            this.load();
        }
    }

    load() {
        let children = this.treeList.instance.getRootNode().children;
        let modelName = this.modelSelectedItems[0].ModelName;
        this.editData = this.modelSelectedItems.map(item => {
            return {
                Path: item.Path,
                Columns: item.Path.split('/').filter(p => p != ''),
                Depth: item.Path.split('/').filter(p => p != '').length,
                Index: 0,
                Listed: item.Listed
            }
        });
        for (let i = 0; i < children.length; i++) {
            let item = children[i];
            if (item.key.split("_")[1] == modelName) {
                let subscription = this.treeList.onRowExpanded.pipe(first()).toPromise().then(x => {
                    this.expandAllRows();
                });
                this.treeList.instance.expandRow(item.key);
                break;
            }
        }
    }

    waitNodeLoad(key: string) {
        return new Promise((resolve, reject) => {
            let interval = setInterval(() => {
                let data = this.treeList.instance.getNodeByKey(key);
                if (data) {
                    clearInterval(interval);
                    resolve(data);
                }
                else {
                    console.log("KEY NOT LOADED YET!!! => " + key)
                }
                
            }, 100);
        });
    }

    async expandAllRows() {
        console.log("EXPANDING START");
        let that = this;
        let modelName = this.modelSelectedItems[0].ModelName;
        for (let index = 0; index < this.editData.length; index++) {
            let item = this.editData[index];
            for (let i = 0; i < item.Columns.length; i++) {
                let column = item.Columns[i];
                let key = modelName + "/" + item.Columns.slice(0, i + 1).join("/") + "_" + column;
                let parentItem = that.treeList.instance.getNodeByKey(key);
                if (parentItem == null) {
                    parentItem = await this.waitNodeLoad(key);
                }
                if (parentItem && parentItem.hasChildren) {
                    console.log("EXPANDING=> " + parentItem.key);
                    this.treeList.instance.expandRow(parentItem.key);
                }

                if (item.Listed && i == item.Columns.length - 1) {
                    this.selectedRows.push(key);
                }
            }
        }
        this.treeList.instance.deselectAll();
        console.log("SELECTING ROWS!!!");
        this.treeList.instance.selectRows(this.selectedRows, false);
        let count = 0;
        //TODO:CORE interval limit or focus
        let interval = setInterval(() => {
            if (this.treeList.instance.getSelectedRowKeys().length > 0) {
                console.log("SELECTION DONE!");
                clearInterval(interval);
            }
            else {
                console.log("SELECTING ROWS AGAIN!!!");
                this.treeList.instance.deselectAll();
                this.treeList.instance.selectRows(this.selectedRows, false);
            }
            if(++count == 100) {
                clearInterval(interval);
                console.log("SELECTION NOT COMPLETED!");
            }
        }, 100);
    }

    deleteDataSource() {
        if (!this.dataSourceList.selectedItem) {
            ServiceLocator.MessageService.showError('Datasource seçmediniz.');
            return;
        }
        let data: DataSourceDto = { ObjectID: this.dataSourceList.value };
        this.httpService.post<any>('/api/DynamicForm/DeleteDataSource', data).then(p => {
            this.loadDataSources();
        });
    }

    async saveDataSource(): Promise<string> {
        return new Promise((resolve, reject) => {
            if (!this.dataSourceList.selectedItem) {
                if (this.txtDataSource.value == '') {
                    ServiceLocator.MessageService.showError('Kaynak ismi girmelisiniz.');
                    reject('Kaynak ismi girmelisiniz.');
                    return;
                }
                if (this.modelSelectedItems.length == 0 || this.modelSelectedItems.filter(p => p.Listed).length == 0) {
                    ServiceLocator.MessageService.showError('Model listesinden seçim yapmalınız.');
                    reject('Model listesinden seçim yapmalınız.');
                    return;
                }
                let data = {
                    ApiConfig: JSON.stringify(this.modelSelectedItems),
                    Name: this.txtDataSource.value,
                    Type: 1,
                    Description: ''
                };
                this.httpService.post<any>('/api/DynamicForm/AddDataSource', data).then(p => {
                    this.loadDataSources();
                    this.txtDataSource.value = '';
                    resolve(p);
                });
            } else {
                let data = {
                    ApiConfig: JSON.stringify(this.modelSelectedItems),
                    Name: this.txtDataSource.value,
                    Type: 1,
                    Description: '',
                    ObjectID: this.dataSourceList.selectedItem.ObjectID
                };
                this.httpService.post<any>('/api/DynamicForm/UpdateDataSource', data).then(p => {
                    this.loadDataSources();
                    this.txtDataSource.value = '';
                    resolve(p);
                });
            }
        });
    }

    ngOnInit(): void {
        this.loadDataSources();
    }

    onItemSelectionChanged(e) {
        if (e.currentSelectedRowKeys.length > 1) {
            this.conditions = this.modelSelectedItems.filter(p => p.WhereCondition != null || p.Order != "None");
            return;
        }
        if (e.currentSelectedRowKeys.length == 1) {
            let selectedItem = e.component.getNodeByKey(e.currentSelectedRowKeys);
            let path: string = "";
            let tempItem = e.component.getNodeByKey(e.currentSelectedRowKeys);
            while (tempItem && tempItem.data.parentId != "") {
                path = "/" + tempItem.data.text + path;
                tempItem = tempItem.parent;
            }
            let differentModelExists = this.modelSelectedItems.filter(p => p.ModelName != tempItem.data.text && p.Listed).length > 0;
            if (differentModelExists) {
                ServiceLocator.MessageService.showError("Tek bir model seçebilirsiniz");
                e.component.deselectRows(selectedItem.key);
                return;
            }
            if (!this.modelSelectedItems.find(p => p.Path == path)) {
                this.modelSelectedItems.push({
                    Name: selectedItem.data.text,
                    Id: selectedItem.key,
                    ModelName: tempItem.data.text,
                    Path: path,
                    Listed: true,
                    Order: this.orderType,
                    Type: selectedItem.data.type
                });
            } else {
                let item = this.modelSelectedItems.find(p => p.Path == path);
                item.Listed = true;
            }
        } else {
            let unselectedNode = e.component.getNodeByKey(e.currentDeselectedRowKeys);
            if (unselectedNode) {
                this.filterModelList(unselectedNode);
            }
        }
        this.conditions = this.modelSelectedItems.filter(p => p.WhereCondition != null || p.Order != "None");
    }

    unListAll(node) {
        for (let data of node.items) {
            this.filterModelList(data);
        }
    }

    filterModelList(data) {
        let item = this.modelSelectedItems.find(p => p.Id == data.key);
        if (item) {
            item.Listed = false;
            if (!item.WhereCondition && item.Order == "None") {
                this.modelSelectedItems = this.modelSelectedItems.filter(p => p.Id != item.Id);
            }
        }
        if (data.items) {
            this.unListAll(data);
        }
    }

    onRowPrepared(e) {
        if (e.node && e.node.data.hasItems) {
            e.rowElement.classList.add('hiddenCheckBox');
        }
    }

    onItemDeleting(e) {
        e.cancel = e.itemData.Listed;
        let item = this.modelSelectedItems.filter(p => p.Id == e.itemData.Id)[0];
        if (item) {
            item.WhereCondition = undefined;
            item.Order = this.orderType;
        }
        this.conditions = this.modelSelectedItems.filter(p => p.WhereCondition != null || p.Order != "None");

    }

    onRowDblClick(e) {
        this.showFilterPopup = true;
        this.selectedColumn = e;
        let item = this.modelSelectedItems.filter(p => p.Id == e.node.key)[0];
        if (item) {
            if (item.WhereCondition) {
                this.filterValue = item.WhereCondition.Value;
                this.filterOperation = item.WhereCondition.Operation;
            }
            this.orderType = item.Order;
        }
    }

    onItemSelected(e) {
        var component = e.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            this.showFilterPopup = true;
            this.selectedColumn = e;
            let item = this.modelSelectedItems.filter(p => p.ModelName + p.Path == e.node.data.path)[0];
            if (item) {
                if (item.WhereCondition) {
                    this.filterValue = item.WhereCondition.Value;
                    this.filterOperation = item.WhereCondition.Operation;
                } else {
                    this.filterValue = '';
                    this.filterOperation = undefined;
                }
                this.orderType = item.Order;
            }
        }
    }

    copyQuery() {
        let selBox = document.createElement('textarea');
        selBox.style.position = 'fixed';
        selBox.style.left = '0';
        selBox.style.top = '0';
        selBox.style.opacity = '0';
        selBox.value = this.oDataQuery;
        document.body.appendChild(selBox);
        selBox.focus();
        selBox.select();
        document.execCommand('copy');
        document.body.removeChild(selBox);
    }

    triggerChangeEvent(str) {
        let urlField = jQuery(str);
        if (urlField.length > 0) {
            urlField[0].dispatchEvent(new Event('input', {
                bubbles: true,
                cancelable: true
            }));
        }
    }

    async closePopup() {
        this.dataSourceId = await this.saveDataSource();
        this.saveDataSourceParams();
        this.prepareQuery();
        this.showoDataEditor = false;
        this.jQueryFunctions();
        this.onClose.emit({});
    }

    async saveDataSourceParams() {
        let dataSourceId = this.dataSourceId;
        let params = this.modelSelectedItems.filter(x => x.WhereCondition != null && x.WhereCondition.Value.startsWith('{{') && x.WhereCondition.Value.endsWith('}}'))
            .map(x => ({
                ParamKey: x.WhereCondition.Value.substring(2,x.WhereCondition.Value.length - 2),
                DataSourceId: dataSourceId
            }));
        let result = await this.httpService.post<any>('/api/DynamicForm/AddDataSourceParams?dataSourceId=' + dataSourceId, params);
        return result;
    }

    jQueryFunctions() {
        //TODO:Core Refactor this method
        let modelItemStr: string = JSON.stringify({
            url: environment.apiRoot + "/odata/" + this.modelSelectedItems[0].ModelName,
            items: this.modelSelectedItems,
            entityName: this.modelSelectedItems[0].ModelName
        });
        jQuery("[name='data[data.url]']").val(environment.apiRoot + "/odata/" + this.oDataQuery);
        jQuery("[name='data[customOptions.selectConfig]']").val(modelItemStr);
        jQuery("[name='data[customOptions.dataSourceId]']").val(this.dataSourceId);

        this.triggerChangeEvent("[name='data[data.url]']");
        this.triggerChangeEvent("[name='data[customOptions.dataSourceId]']");
        this.triggerChangeEvent("[name='data[customOptions.selectConfig]']");

        jQuery("[name='data[customOptions.gridConfig]']").val(modelItemStr);
        this.triggerChangeEvent("[name='data[customOptions.gridConfig]']");
        let columns = this.modelSelectedItems.filter(x => x.Listed == true).map(x => ({
            caption: x.Path.split('/').filter(p => p != '').join(' '),
            dataField: x.Path.split('/').filter(p => p != '').join('.')
        }));
        jQuery("[name='data[customOptions.gridColumns]']").val(JSON.stringify(columns));
        this.triggerChangeEvent("[name='data[customOptions.gridColumns]']");
    }

    clearComponent() {
        console.log("CLEAR COMPONENT!");
        this.treeList.instance.deselectAll();
        this.expandedRowKeys.Clear();
        this.modelSelectedItems.Clear();
        this.conditions.Clear();
        this.oDataQuery = "";
        this.selectedRows.Clear();
        this.txtDataSource.value = "";
        this.dataSourceList.value = undefined;
    }

    prepareQuery() {
        let top = this.countSelect.value;
        this.generateJson();
        this.clearCustomFilters(this.queryJson);
        if (top == "Count") {
            this.queryJson.count = true;
        } else if (!top || top != "") {
            this.queryJson.top = top;
        }
        this.oDataQuery = this.modelSelectedItems[0].ModelName + buildQuery(this.queryJson);
        this.queryJson = new ODataObject();
    }

    clearCustomFilters(node) {

        for (let item in node) {
            if (item == 'customFilter') {
                delete node.customFilter;
            }
            else if (item == 'expand') {
                this.clearCustomFilters(node.expand);
            }
            else if (item == 'select') {
            }
            else if (item == 'filter') {
            }
            else if (item == 'top') {
            }
            else if (item == 'orderBy') {
            }
            else {
                this.clearCustomFilters(node[item])
            }
        }
    }

    generateJson() {
        for (let i = 0; i < this.modelSelectedItems.length; i++) {
            let item = this.modelSelectedItems[i];
            let subpaths = item.Path.split('/').filter(x => x != '');
            if (subpaths.length == 1) {

                if (item.Listed) {
                    if (!this.queryJson.select) {
                        this.queryJson.select = [];
                    }
                }
                this.queryJson.select.push(subpaths[0]);

                this.queryJson.customFilter = this.prepareFilterJson(this.queryJson.customFilter, item, null);
                if (this.queryJson.customFilter) {
                    this.queryJson.filter = this.queryJson.customFilter.toString();
                }
                if (item.Order != 'None') {

                    if (this.queryJson.orderBy == null) {
                        this.queryJson.orderBy = [];
                    }
                    this.queryJson.orderBy.push(subpaths[0] + ' ' + item.Order);
                }
                continue;
            }
            this.checkAndCreatePath(item);
        }
    }

    checkAndCreatePath(item: ODataColumnDto) {

        let findPaths = item.Path.split('/').filter(x => x != '');
        let currentPath = '';
        let targetRef = this.queryJson;
        for (let index = 0; index < findPaths.length; index++) {
            const path = findPaths[index];
            if (index == findPaths.length - 1) {
                if (item.Listed) {
                    if (targetRef.select == null) {
                        targetRef.select = [];
                    }
                    targetRef.select.push(path);
                }
                if (item.WhereCondition) {
                    this.queryJson.customFilter = this.prepareFilterJson(this.queryJson.customFilter, item, findPaths.join('/'));
                    if (this.queryJson.customFilter) {
                        this.queryJson.filter = this.queryJson.customFilter.toString();
                    }
                }
                if (item.Order != 'None') {
                    if (this.queryJson.orderBy == null) {
                        this.queryJson.orderBy = [];
                    }

                    this.queryJson.orderBy.push(path + ' ' + item.Order);
                }
                break;
            }
            currentPath += ('.expand.' + path);
            let result: any = null;
            try {
                result = eval('this.queryJson' + currentPath)
            }
            catch (e) {
            }
            if (result == null) {
                if (targetRef.expand == null) {
                    targetRef.expand = {};
                }
                if (targetRef.expand[path] == null) {
                    targetRef.expand[path] = new ODataObject();
                }
            }
            targetRef = targetRef.expand[path];
        }
    }

    addFilter() {
        let path: string = "";
        let temp = this.selectedColumn.node;

        while (temp && temp.data.parentId != "") {
            path = "/" + temp.data.text + path;
            temp = temp.parent;
        }
        if (this.modelSelectedItems.filter(p => p.Id == this.selectedColumn.data.id).length == 0) {
            this.modelSelectedItems.push({
                Name: this.selectedColumn.data.text,
                Id: this.selectedColumn.data.id,
                ModelName: temp.data.text,
                Path: path,
                Listed: false,
                Order: this.orderType,
                Type: this.selectedColumn.data.type
            });
        }
        let item = this.modelSelectedItems.filter(p => p.Id == this.selectedColumn.data.id)[0];
        if (this.filterOperation) {
            item.WhereCondition = new ODataWhereDto();
            item.WhereCondition.Value = this.filterValue;
            item.WhereCondition.PropertyName = this.selectedColumn.data.text;
            item.WhereCondition.Operation = this.filterOperation;
            item.WhereCondition.Text = this.whereOperations.filter(p => p.Operation == this.filterOperation)[0].Text;
        }
        item.Order = this.orderType;
        this.showFilterPopup = false;
        this.filterValue = undefined;
        this.filterOperation = undefined;
        this.orderType = this.orderTypes[0];
        this.conditions = this.modelSelectedItems.filter(p => p.WhereCondition != null || p.Order != "None");
    }



    prepareFilterJson(filter, item, propertyName) {
        let where = item.WhereCondition;
        if (!where) {
            return;
        }
        if (!filter || Object.keys(filter).length === 0) {
            filter = f('and');
        }
        propertyName = propertyName || where.PropertyName;
        if (where.Operation == 'eq') {
            filter = filter.eq(propertyName, where.Value);
        } else if (where.Operation == 'ne') {
            filter = filter.ne(propertyName, where.Value);
        }
        else if (where.Operation == 'in-eq') {
            filter = filter.in(propertyName, where.Value.split(';'));
        }
        else if (where.Operation == 'tolower') {
            filter = filter.eq(p => p.toLower(propertyName), where.Value);
        }
        else if (where.Operation == 'not-tolower') {
            filter = filter.ne(p => p.toLower(propertyName), where.Value);
        }
        else if (where.Operation == 'startswith') {
            filter = filter.startsWith(propertyName, where.Value);
        }
        else if (where.Operation == 'not-startswith') {
            //TODO:Core
        }
        else if (where.Operation == 'endswith') {
            filter = filter.endsWith(propertyName, where.Value);
        }
        else if (where.Operation == 'not-endswith') {
            //TODO:Core
        }
        else if (where.Operation == 'contains') {
            filter = filter.contains(propertyName, where.Value);
        }
        else if (where.Operation == 'length') {
            filter = filter.eq(p => p.length(propertyName), where.Value);
        }
        return filter;
    }
}

export class DataSourceDto {
    ObjectID: Guid;
}