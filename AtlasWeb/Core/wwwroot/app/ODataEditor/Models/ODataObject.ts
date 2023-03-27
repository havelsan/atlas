import buildQuery from 'odata-query';
import { ODataColumnDto } from './ODataColumnDto';
import f from 'odata-filter-builder';
import { environment } from 'app/environments/environment';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';


export class ODataObject {

    public customFilter?: any;
    public filter?: string;
    public select?: string[];
    public expand?: any;
    public top?: string;
    public orderBy?: string[];
    public count: boolean;

}

export class ODataBuilder {
    prepareQuery(top, modelSelectedItems): string {
        let queryJson: ODataObject = new ODataObject();
        this.generateJson(modelSelectedItems, queryJson);
        this.clearCustomFilters(queryJson);
        if (top == "Count") {
            queryJson.count = true;
        } else if (!top || top != "") {
            queryJson.top = top;
        }
        let oDataQuery = environment.apiRoot + "/odata/" + modelSelectedItems[0].ModelName + buildQuery(queryJson);
        return oDataQuery;
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

    generateJson(modelSelectedItems, queryJson) {
        for (let i = 0; i < modelSelectedItems.length; i++) {
            let item = modelSelectedItems[i];
            let subpaths = item.Path.split('/').filter(x => x != '');
            if (subpaths.length == 1) {

                if (item.Listed) {
                    if (!queryJson.select) {
                        queryJson.select = [];
                    }
                }
                queryJson.select.push(subpaths[0]);

                queryJson.customFilter = this.prepareFilterJson(queryJson.customFilter, item, null);
                if (queryJson.customFilter) {
                    queryJson.filter = queryJson.customFilter.toString();
                }
                if (item.Order != 'None') {

                    if (queryJson.orderBy == null) {
                        queryJson.orderBy = [];
                    }
                    queryJson.orderBy.push(subpaths[0] + ' ' + item.Order);
                }
                continue;
            }
            this.checkAndCreatePath(item, queryJson);
        }
    }

    checkAndCreatePath(item: ODataColumnDto, queryJson) {

        let findPaths = item.Path.split('/').filter(x => x != '');
        let currentPath = '';
        let targetRef = queryJson;
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
                    queryJson.customFilter = this.prepareFilterJson(queryJson.customFilter, item, findPaths.join('/'));
                    if (queryJson.customFilter) {
                        queryJson.filter = queryJson.customFilter.toString();
                    }
                }
                if (item.Order != 'None') {
                    if (queryJson.orderBy == null) {
                        queryJson.orderBy = [];
                    }

                    queryJson.orderBy.push(path + ' ' + item.Order);
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

    convertTypes(value, type) {
        if(type) {
            if(type == "Boolean") {
                return JSON.parse(value) as boolean;
            }else if (type == "String") {
                return value;
            }else if (type == "Guid") {
                return new Guid(value);
            }else if (type.startswith("Int")) {
                return parseInt(value);
            }else if(type == "Double" || type == "Decimal") {
                return parseFloat(value);
            }else if(type == "Datetime") {
                return new Date(value);;
            }
        }
        return value;
    }

    convertConditions(odataCondition) {

        if (odataCondition == 'eq') {
            return "=";
        }
        else if (odataCondition == 'ne') {
            return "<>";
        }
        else if (odataCondition == 'in-eq') {
            return "contains";
        }
        else if (odataCondition == 'startswith') {
            return "startswith";
        }
        else if (odataCondition == 'contains') {
            return "contains";
        }
        else {
            alert("ODATA to Devextreme condition implement this => " + odataCondition);
        }
    }    
}