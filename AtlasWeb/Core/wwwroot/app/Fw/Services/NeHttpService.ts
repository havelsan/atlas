import { Injectable } from '@angular/core';
import { Headers, RequestOptions } from '@angular/http';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeSerializer } from 'NebulaClient/ClassTransformer/NeSerializer';
import { plainToClass, classToPlain } from 'NebulaClient/ClassTransformer';
import { MessageService } from 'Fw/Services/MessageService';
import { AuthHttp } from '../../auth.module';
import { EpisodeActionWorkListSharedService } from './EpisodeActionWorkListSharedService';
import { EpisodeActionDisplayFormSharedService } from './EpisodeActionDisplayFormSharedService';
import { ENabizButtonSharedService } from './ENabizButtonSharedService';
import { DentalCommitmentFormSharedService } from './DentalCommitmentFormSharedService';
import { RequestedProcedureSharedService } from 'Modules/Tibbi_Surec/Tetkik_Istem_Modulu/RequestedProcedureSharedService';
import { MedicalStuffReportSharedService } from 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/MedicalStuffReportSharedService';
export type ClassType<T> = { new(...args: any[]): T; };

@Injectable()
export class NeHttpService {

    constructor(private http: AuthHttp,
        private messageService: MessageService,
        //private activePatientService: IActivePatientService,
        //private activeEpisodeService: IActiveEpisodeService,
        //private activeEpisodeActionService: IActiveEpisodeActionService,
        public episodeActionWorkListSharedService: EpisodeActionWorkListSharedService,
        public episodeActionDisplayFormSharedService: EpisodeActionDisplayFormSharedService,
        public eNabizButtonSharedService: ENabizButtonSharedService,
        public dentalCommitmentFormSharedService: DentalCommitmentFormSharedService,
        public requestedProcedureSharedService: RequestedProcedureSharedService,
        public medicalStuffReportSharedService: MedicalStuffReportSharedService) {
    }

    private createHeaders(): Headers {
        let headers = new Headers();
        headers.set('Content-Type', 'application/json');
        let token = sessionStorage.getItem('token');
        if (token) {
            headers.set('Authorization', `Bearer ${token}`);
        }
        /*let activePatientID = this.activePatientService.ActivePatientID;
        if (activePatientID != null) {
            headers.append('Access-Control-Allow-Headers', 'ActivePatientID');
            headers.append('ActivePatientID', activePatientID.valueOf());
        }
        let activeEpisodeID = this.activeEpisodeService.ActiveEpisodeID;
        if (activeEpisodeID != null) {
            headers.append('Access-Control-Allow-Headers', 'ActiveEpisodeID');
            headers.append('ActiveEpisodeID', activeEpisodeID.valueOf());
        }
        let activeEpisodeActionID = this.activeEpisodeActionService.ActiveEpisodeActionID;
        if (activeEpisodeActionID != null) {
            headers.append('Access-Control-Allow-Headers', 'ActiveEpisodeActionID');
            headers.append('ActiveEpisodeActionID', activeEpisodeActionID.valueOf());
        }*/
        const currentLocaleId = sessionStorage.getItem('localeId');
        if (currentLocaleId) {
            headers.append('Access-Control-Allow-Headers', 'CurrentCulture');
            headers.append('CurrentCulture', currentLocaleId);
        }
        return headers;
    }

    private createRequestOptions(): RequestOptions {
        let headers = this.createHeaders();
        let options = new RequestOptions();
        options.headers = headers;
        return options;
    }

    private translateResult<T>(res: NeResult<T>, targetType?: ClassType<T>) {
        if (targetType && res && res.Result) {
            const convertedValue = plainToClass(targetType, res.Result);
            let convertedResult = new NeResult<T>();
            convertedResult.InfoMessage = res.InfoMessage;
            convertedResult.IsSuccess = res.IsSuccess;
            convertedResult.Message = res.Message;
            convertedResult.Result = plainToClass(targetType, convertedValue);
            return convertedResult;
        }
        return res;
    }

    public postForNeResult<T>(url: string, value: any, targetType?: ClassType<T>): Promise<NeResult<T>> {
        let that = this;
        let payload = classToPlain(value);
        let body = NeSerializer.stringify(payload);
        let requestOptions = this.createRequestOptions();
        let promise = new Promise<NeResult<T>>((resolve, reject) => {
            this.http.post(encodeURI(url), body, requestOptions).toPromise().then(result => {
                let neResult = result.json() as NeResult<T>;
                if (neResult.IsSuccess === false) {
                    reject(neResult.Message);
                } else {
                    if (targetType) {
                        const result = that.translateResult<T>(neResult, targetType);
                        resolve(result);
                    } else {
                        const convertedValue = plainToClass(Object, neResult.Result);
                        neResult.Result = convertedValue as T;
                        resolve(neResult);
                    }
                }
            }).catch(err => {
                reject(err);
            });
        });

        return promise;
    }

    public post<T>(url: string, value: any, targetType?: ClassType<T>): Promise<T>;
    public post<T>(url: string, value: any, targetType?: ClassType<T>): Promise<Array<T>>;
    public post<T>(url: string, value: any, targetType?: ClassType<T>): Promise<T> | Promise<Array<T>> {
        let that = this;
        let payload = classToPlain(value);
        let body = NeSerializer.stringify(payload);
        let requestOptions = this.createRequestOptions();
        let promise = new Promise<T>((resolve, reject) => {
            this.http.post(encodeURI(url), body, requestOptions).toPromise().then(result => {
                const neResult = result.json() as NeResult<T>;
                if (neResult != null) {
                    if (neResult.InfoMessage != null) {
                        that.messageService.showInfo(neResult.InfoMessage);
                    }
                }
                if (neResult.IsSuccess === false) {
                    reject(neResult.Message);
                } else {
                    if (targetType && neResult && neResult.Result) {
                        const convertedValue = plainToClass(targetType, neResult.Result);
                        resolve(convertedValue);
                    } else {
                        const convertedValue = plainToClass(Object, neResult.Result);
                        resolve(convertedValue as T);
                    }
                }
            }).catch(err => {
                reject(err);
            });
        });

        return promise;
    }

    public getForNeResult<T>(url: string, targetType?: ClassType<T>): Promise<NeResult<T>> {
        let that = this;
        let requestOptions = this.createRequestOptions();
        let promise = new Promise<NeResult<T>>((resolve, reject) => {
            this.http.get(encodeURI(url), requestOptions).toPromise().then(result => {
                let neResult = result.json() as NeResult<T>;
                if (neResult.IsSuccess === false) {
                    reject(neResult.Message);
                } else {
                    if (targetType != null) {
                        const result = that.translateResult<T>(neResult, targetType);
                        resolve(result);
                    } else {
                        const convertedValue = plainToClass(Object, neResult.Result);
                        neResult.Result = convertedValue as T;
                        resolve(neResult);
                    }
                }
            }).catch(err => {
                reject(err);
            });
        });

        return promise;
    }

    public get<T>(url: string, targetType?: ClassType<T>): Promise<T>;
    public get<T>(url: string, targetType?: ClassType<T>): Promise<T[]>;
    public get<T>(url: string, targetType?: ClassType<T>): Promise<T> | Promise<T[]> {
        let that = this;
        let requestOptions = this.createRequestOptions();
        let promise = new Promise<T>((resolve, reject) => {
            this.http.get(encodeURI(url), requestOptions).toPromise().then(result => {
                let neResult = result.json() as NeResult<T>;
                if (neResult != null) {
                    if (neResult.InfoMessage != null) {
                        that.messageService.showInfo(neResult.InfoMessage);
                    }
                }
                if (neResult.IsSuccess === false) {
                    reject(neResult.Message);
                } else {
                    if (targetType && neResult && neResult.Result) {
                        const convertedValue = plainToClass(targetType, neResult.Result);
                        resolve(convertedValue);
                    } else {
                        const convertedValue = plainToClass(Object, neResult.Result);
                        resolve(convertedValue as T);
                    }
                }
            }).catch(err => {
                reject(err);
            });
        });

        return promise;
    }
}
