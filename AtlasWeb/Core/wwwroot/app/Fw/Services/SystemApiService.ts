import { Injectable } from '@angular/core';
import { DynamicComponentInfo } from '../Models/DynamicComponentInfo';
import { DynamicComponentInfoDVO } from '../Models/DynamicComponentInfoDVO';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ModalActionResult, ModalInfo } from '../Models/ModalInfo';
import { IModalService } from './IModalService';
import { ServiceLocator } from './ServiceLocator';

@Injectable()
export class SystemApiService {
    public componentInfo: DynamicComponentInfo;

    constructor(private http: NeHttpService) {
    }

    open(objectID: any, objectDefName: any, FormDefId?: any, InputParam?: any): Promise<DynamicComponentInfo> {
        return new Promise<DynamicComponentInfo>((resolve, reject) => {
            let that = this;
            this.http.get<DynamicComponentInfoDVO>('api/SystemApi/GetDynamicComponentInfo?ObjectId=' + objectID + '&ObjectDefName=' + objectDefName + '&FormDefId=' + FormDefId).then(result => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModuleName = result.ModuleName;
                compInfo.ModulePath = result.ModulePath;
                compInfo.objectID = result.objectID;
                compInfo.InputParam = InputParam;
                that.componentInfo = compInfo;
                resolve(compInfo);
            }).catch(error => {
                reject(error);
            });
        });
    }

    public openPopUp(objectID: any, objectDefID: any, formDefId?: any, inputparam?: any, instance?: any): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "";
            modalInfo.fullScreen = true;

            this.http.get<DynamicComponentInfoDVO>('api/SystemApi/GetDynamicComponentInfo?ObjectId=' + objectID + '&ObjectDefName=' + objectDefID + '&FormDefId=' + formDefId).then(dynamicComponentInfoDVO => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = dynamicComponentInfoDVO.ComponentName;
                compInfo.ModuleName = dynamicComponentInfoDVO.ModuleName;
                compInfo.ModulePath = dynamicComponentInfoDVO.ModulePath;
                compInfo.objectID = dynamicComponentInfoDVO.objectID;
                compInfo.InputParam = inputparam;
                compInfo.ParentInstance = instance;
                let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
                let result = modalService.create(compInfo, modalInfo);
                result.then(inner => {
                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            }).catch(err => {
                reject(err);
            });
        });
    }


    new(objectDefName: any, ParentObjectID?: Guid, FormDefId?: any, InputParam?: any): Promise<DynamicComponentInfo> {
        return new Promise<DynamicComponentInfo>((resolve, reject) => {
            let that = this;
            this.http.get<DynamicComponentInfoDVO>('api/SystemApi/GetNewObjectDynamicComponentInfo?ObjectDefName=' + objectDefName + '&FormDefId=' + FormDefId).then(result => {
                let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
                compInfo.ComponentName = result.ComponentName;
                compInfo.ModulePath = result.ModulePath;
                compInfo.ModuleName = result.ModuleName;
                compInfo.ParentObjectID = ParentObjectID;
                compInfo.InputParam = InputParam;
                that.componentInfo = compInfo;
                resolve(compInfo);
            }).catch(error => {
                reject(error);
            });
        });
    }
}