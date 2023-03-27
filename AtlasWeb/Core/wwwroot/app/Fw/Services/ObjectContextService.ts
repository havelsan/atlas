import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Injectable } from '@angular/core';
import { NeHttpService, ClassType } from 'Fw/Services/NeHttpService';

@Injectable()
export class ObjectContextService {

    constructor(private http: NeHttpService) {
    }

    public getNewObject<T>(objectDefID: Guid, targetType?: ClassType<T>): Promise<T> {
        return new Promise<T>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetNewObject/${objectDefID}`;
            let result = this.http.get<T>(apiUrl, targetType).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getNewObjectWithDefName<T>(objectDefName: string, targetType?: ClassType<T>): Promise<T> {
        return new Promise<T>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetNewObjectWithDefName/${objectDefName}`;
            let result = this.http.get<T>(apiUrl, targetType).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getObject<T>(objectID: Guid, objectDefID: Guid, targetType?: ClassType<T>): Promise<T> {
        return new Promise<T>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObject/${objectID}/${objectDefID}`;
            let result = this.http.get<T>(apiUrl, targetType).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getObjectWithDefName<T>(objectID: Guid, objectDefName: string, targetType?: ClassType<T>): Promise<T> {
        return new Promise<T>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObjectWithDefName/${objectID}/${objectDefName}`;
            let result = this.http.get<T>(apiUrl, targetType).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

}