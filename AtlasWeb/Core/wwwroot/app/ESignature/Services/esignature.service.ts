//$7A290403
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { IESignatureService } from './IESignatureService';
import { MessageService } from 'Fw/Services/MessageService';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";

interface IAtlasResult {
    Result: any;
    IsSuccess: boolean;
    Message: string;
    InfoMessage: string;
    StackTrace: string;
}

@Injectable()
export class ESignatureService implements IESignatureService {
    private rootUrl = 'http://localhost:5000';
    private unknownResultReceivedMessage: string = i18n("M21667", "Servis yanıtı çözümlenemedi");

    constructor(private http: Http, private modalService: IModalService, private messageService: MessageService) { }

    public getTerminals(): Promise<Array<string>> {
        let that = this;
        let url = `${this.rootUrl}/api/scard/terminals`;
        return new Promise<Array<string>>((resolve, reject) => {
            this.http.get(url).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve(response.Result.Terminals as Array<string>);
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    resolve(new Array<string>());
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    public getCertificates(): Promise<Array<any>> {
        let that = this;
        let url = `${this.rootUrl}/api/scard/certificates`;
        return new Promise<Array<string>>((resolve, reject) => {
            this.http.get(url).toPromise().then(r => {
                if (r && r.json()) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve(response.Result.Certificates as Array<any>);
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    reject(this.unknownResultReceivedMessage);
                }

            }).catch(err => {
                reject(err);
            });
        });
    }

    public selectCertificateWithSerialNumber(serialNumber: number): Promise<void> {
        let that = this;
        let url = `${this.rootUrl}/api/scard/selectSignCertificateWithSerialNumber`;
        let input: any = { SerialNumber: serialNumber };
        return new Promise<void>((resolve, reject) => {
            this.http.post(url, input).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve();
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    reject(this.unknownResultReceivedMessage);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    public loginRequired(): Promise<boolean> {
        let that = this;
        let url = `${this.rootUrl}/api/scard/loginRequired`;
        return new Promise<boolean>((resolve, reject) => {
            this.http.get(url).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve(response.Result.isLoginRequired);
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    resolve(true);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    public login(terminalName: string, pin: string): Promise<void> {
        let that = this;
        let url = `${this.rootUrl}/api/scard/login`;
        let input: any = { TerminalName: terminalName, Pin: pin };
        return new Promise<void>((resolve, reject) => {
            this.http.post(url, input).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve();
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    reject(this.unknownResultReceivedMessage);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }


    public convertToBase64(content: string): Promise<string> {
        let that = this;
        let url = `${this.rootUrl}/api/signserver/base64`;
        let input: any = { text: content };
        return new Promise<string>((resolve, reject) => {
            this.http.post(url, input).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve(response.Result);
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    reject(this.unknownResultReceivedMessage);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    public signContent(content: string): Promise<string> {
        let that = this;
        let url = `${this.rootUrl}/api/signserver/signContent`;
        return new Promise<string>((resolve, reject) => {
            let input: any = { Content: content };
            this.http.post(url, input).toPromise().then(r => {
                if (r && r.json) {
                    const response = r.json() as IAtlasResult;
                    if (response.IsSuccess == true) {
                        resolve(response.Result.SignedContent);
                    } else {
                        that.messageService.showError(response.Message);
                        reject(response.Message);
                    }
                } else {
                    reject(this.unknownResultReceivedMessage);
                }
            }).catch(err => {
                reject(err);
            });
        });
    }

    async showLoginModal(): Promise<void> {
        let himssIntegrated: string = (await SystemParameterService.GetParameterValue('HIMSSINTEGRATED', 'TRUE'));

        return new Promise<void>((resolve, reject) => {
            this.loginRequired().then(req => {
                if (req === true) {
                    let componentInfo = new DynamicComponentInfo();
                    componentInfo.ComponentName = 'SmartCardLoginComponent';
                    componentInfo.ModuleName = 'ESignatureModule';
                    componentInfo.ModulePath = '/app/ESignature/esignature.module';

                    let modalInfo = new ModalInfo();
                    modalInfo.Width = 700;
                    modalInfo.Height = 400;
                    modalInfo.Title = i18n("M10626", "Akıllı Kart Giriş");
                    modalInfo.IsShowCloseButton = true;

                   /* if (himssIntegrated === 'TRUE'){
                        modalInfo.IsShowCloseButton = false;
                    }*/

                    this.modalService.create(componentInfo, modalInfo).then(r => {
                        resolve();
                    }).catch(err => {
                        reject(err);
                    });
                } else {
                    resolve();
                }
            });
        });
    }
}