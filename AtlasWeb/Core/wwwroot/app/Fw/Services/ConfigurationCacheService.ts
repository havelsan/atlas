import { Injectable } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ListBoxSearchCriteria } from 'NebulaClient/Visual/Controls/TTAutoCompleteGrid';

@Injectable()
export class ConfigurationCacheService {
    Enums: any = {};
    ListDefConfigs: any = {};

    constructor(private http: NeHttpService) {

    }

    public GetEnum(enumName: string): Promise<Array<any>> {
        if (this.Enums[enumName]) {
            return Promise.resolve(this.Enums[enumName]);
        }
        else {
            let that = this;
            return this.http.get('api/DefinitionQuery/GetEnum?enumName=' + enumName).then((res: Array<any>) => {
                let items = res;
                for (let index = 0; index < items.length; index++) {
                    items[index]['Name'] = items[index]['Name'].toUpperCase();
                }
                that.Enums[enumName] = items;
                return that.Enums[enumName];
            });
        }
    }

    public GetListBoxConfig(definitionName: string): Promise<Array<any>> {
        let that = this;
        if (this.ListDefConfigs[definitionName]) {
            return Promise.resolve(this.ListDefConfigs[definitionName]);
        }
        else {
            return this.http.get("api/DefinitionQuery/GetListDefProperties?definitionName=" + definitionName).then((res: Array<ListBoxSearchCriteria>) => {
                let columns: Array<any> = [];
                let column: any;
                for (let i = 0; i < res.length; i++) {
                    column = {
                        caption: res[i].Label,
                        dataField: res[i].Column,
                        width: res[i].Width
                    };
                    columns.push(column);
                }
                that.ListDefConfigs[definitionName] = columns;
                return columns;
            });
        }
    }
}