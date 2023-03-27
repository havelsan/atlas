import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Compiler, Injector, Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IModalService } from 'Fw/Services/IModalService';
import { MessageService } from 'Fw/Services/MessageService';
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ModalStateService } from 'Fw/Models/ModalInfo';
@Injectable()
export class ServiceLocator {
    public static get Compiler(): Compiler {
        return window['ApplicationGlobals'].getInstance().compiler as Compiler;
    }

    public static get Injector(): Injector {
        return window['ApplicationGlobals'].getInstance().injector as Injector;
    }

    public static get HttpService(): Http {
        let injector = ServiceLocator.Injector;
        let httpInstance: Http = injector.get(Http);
        return httpInstance;
    }

    public static ModalService(): IModalService {
        let injector = ServiceLocator.Injector;
        let compiler = ServiceLocator.Compiler;
        let serviceInstance: IModalService = injector.get(IModalService, [compiler]);
        return serviceInstance;
    }

    public static ModalStateService(): ModalStateService {
        let injector = ServiceLocator.Injector;
        let compiler = ServiceLocator.Compiler;
        let serviceInstance: ModalStateService = injector.get(ModalStateService, [compiler]);
        return serviceInstance;
    }

    public static get NeHttpService(): NeHttpService {
        let httpInstance: NeHttpService = ServiceLocator.Injector.get(NeHttpService, [Http]);
        return httpInstance;
    }

    /* public static get ActivePatientService(): IActivePatientService {
        let httpInstance: IActivePatientService = ServiceLocator.Injector.get(IActivePatientService);
        return httpInstance;
    } */

    public static get ActiveTabService(): IActiveTabService {
        let httpInstance: IActiveTabService = ServiceLocator.Injector.get(IActiveTabService);
        return httpInstance;
    }


/*     public static get ActiveEpisodeService(): IActiveEpisodeService {
        let httpInstance: IActiveEpisodeService = ServiceLocator.Injector.get(IActiveEpisodeService);
        return httpInstance;
    }

    public static get ActiveEpisodeActionService(): IActiveEpisodeActionService {
        let httpInstance: IActiveEpisodeActionService = ServiceLocator.Injector.get(IActiveEpisodeActionService);
        return httpInstance;
    } */

    public static get ActiveUserService(): IActiveUserService {
        let httpInstance: IActiveUserService = ServiceLocator.Injector.get(IActiveUserService);
        return httpInstance;
    }

    public static get MessageService(): MessageService {
        let serviceInstance: MessageService = ServiceLocator.Injector.get(MessageService);
        return serviceInstance;
    }

    public static post<TResult>(url: string, input: any): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.post<TResult>(url, input).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static async get<TResult>(url: string, input: any): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.get<TResult>(url).then(result => {
                resolve(result);
            }).catch(err => {
                reject(err);
            });
        });
    }


    public static getObject<TResult>(objectID: Guid, objectDefID: Guid): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObject/${objectID}/${objectDefID}`;
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.get(apiUrl).then(respose => {
                let ttobject = respose as TResult;
                resolve(ttobject);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static getObjectWithDefName<TResult>(objectID: Guid, objectDefName: string): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObjectWithDefName/${objectID}/${objectDefName}`;
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.get(apiUrl).then(respose => {
                let ttobject = respose as TResult;
                resolve(ttobject);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static getObjectChildren<TResult>(objectID: Guid, objectDefID: Guid, relDefID: Guid): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObjectChildren/${objectID}/${objectDefID}/${relDefID}`;
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.get(apiUrl).then(response => {
                let ttobjectList = response as TResult;
                resolve(ttobjectList);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public static getObjectChildrenWithDefName<TResult>(objectID: Guid, objectDefName: string, relDefID: Guid): Promise<TResult> {
        return new Promise<TResult>((resolve, reject) => {
            let apiUrl = `/api/ObjectContext/GetObjectChildrenWithDefName/${objectID}/${objectDefName}/${relDefID}`;
            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            httpService.get(apiUrl).then(response => {
                let ttobjectList = response as TResult;
                resolve(ttobjectList);
            }).catch(err => {
                reject(err);
            });
        });
    }
}
