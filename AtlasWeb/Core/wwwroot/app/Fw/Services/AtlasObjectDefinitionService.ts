import { Injectable } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { AtlasListDefinition } from 'Fw/Models/AtlasListDefinition';
import { ListDefinitionWithResultInput } from "Fw/Models/ListDefinitionWithResultInput";

@Injectable()
export class AtlasObjectDefinitionService {

    constructor(private http: NeHttpService) {
    }

    public getListDefinitionWithResult(input: ListDefinitionWithResultInput): Promise<AtlasListDefinition> {
        let url = '/api/ObjectDef/GetListDefinition';
        let inputPost =  { ListDefID: input.listDefID, ListDefName: input.listDefName, UserFilterExpression: input.userFilterExpression };
        return this.http.post<AtlasListDefinition>(url, inputPost);
    }
}