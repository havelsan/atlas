import { ObjectDefLookupItem } from 'Fw/Models/ObjectDefLookupItem';
import { FormDefLookupItem } from '../Models/formdeflookupitem';
import { TTObjectStateDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateDef';
import { Injectable } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';

@Injectable()
export class DefinitionService {

    private readonly objectDefListUrl: string = '/api/ObjectDef/GetObjectDefList';
    private readonly formDefListUrl: string = '/api/ObjectDef/GetFormDefList';
    private readonly stateDefListUrl: string = '/api/ObjectDef/GetObjectStateDefs';

    constructor(private http: NeHttpService) { }

    public getObjectDefList(): Promise<Array<ObjectDefLookupItem>> {
        return new Promise<Array<ObjectDefLookupItem>>((resolve, reject) => {
            this.http.get<Array<ObjectDefLookupItem>>(this.objectDefListUrl).then(res => {
                let result =  res as Array<ObjectDefLookupItem>;
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getFormDefList(objectDefName: string): Promise<Array<FormDefLookupItem>> {
        return new Promise<Array<FormDefLookupItem>>((resolve, reject) => {
            let apiUrl = this.formDefListUrl + '/' + objectDefName;
            this.http.get<Array<FormDefLookupItem>>(apiUrl).then(res => {
                let result = res as Array<FormDefLookupItem>;
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getObjectStateDefList(objectDefID: string): Promise<Array<TTObjectStateDef>> {
        return new Promise<Array<TTObjectStateDef>>((resolve, reject) => {
            let apiUrl = this.stateDefListUrl + '/' + objectDefID;
            this.http.get<Array<TTObjectStateDef>>(apiUrl).then(res => {
                let result =  res as Array<TTObjectStateDef>;
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }
}