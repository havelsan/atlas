//$DA96F75E
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component } from '@angular/core';
import { SmartCardLoginModel } from '../../ESignature/Models/login.model';
import { ESignatureService } from '../../ESignature/Services/esignature.service';
import { IModalService } from 'Fw/Services/IModalService';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { PrescriptionService } from 'ObjectClassService/PrescriptionService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: 'esignature-test-component',
    template: `

    <h1>E-Signature Test Component</h1>
    <div>
        <dx-button text="Show Login Modal" style="margin: 5px 0px" (click)="showLoginModal()"></dx-button>
        <dx-button text="Show Certificate List Modal" style="margin: 5px 0px" (click)="showCertificateListModal()"></dx-button>
    </div>
    <br />
    <div>{{loginMessage}}</div>
    <div style="width: 700px; height: 300px">
        <smart-card-login-component (LoginCompleted)="loginCompleted($event)" (LoginFailed)="loginFailed($event)"></smart-card-login-component>
    </div>
    <br />
    <div>{{certificateSelectedMessage}}</div>
    <div style="width: 350px; height: 200px; overflow: hidden">
        <certificate-list-component (CertificateSelected)="certificateSelected($event)"></certificate-list-component>
    </div>
    <br />
    <dx-text-area [height]="90" [(value)]="content" style="margin: 5px 0px">    </dx-text-area>
    <dx-button text="Sign" style="margin: 5px 0px" (click)="sign()"></dx-button>
    <dx-text-area [height]="90" [readOnly]="true"  [(value)]="signedContent" style="margin: 5px 0px">    </dx-text-area>

    <dx-button text="Ereçete imzalanacak içerik" (click)="ereceteImzalanacak()"></dx-button>

   `,
    providers: [ESignatureService]
})
export class ESignatureTestComponent {

    public loginMessage: string;
    public certificateSelectedMessage: string;
    public content: string;
    public signedContent: string;

    constructor(private signService: ESignatureService, private modalService: IModalService) {
    }

    public loginCompleted(eparam: SmartCardLoginModel) {
        this.loginMessage = `Smart Card Login Completed Successfully: ${eparam.TerminalName} - ${eparam.PIN}`;
    }

    public loginFailed(eparam: any) {
        this.loginMessage = `Smart Card Login Failed: ${eparam}`;
    }

    public certificateSelected(eparam: any) {
        this.certificateSelectedMessage = `Certificate Selected: ${eparam.SerialNumber}`;
    }

    public sign() {
        let that = this;
        this.signService.signContent(this.content).then(r => {
            that.signedContent = r;
        }).catch(err => {
            console.log(err);
        });
    }

    public showLoginModal() {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'SmartCardLoginComponent';
        componentInfo.ModuleName = 'ESignatureModule';
        componentInfo.ModulePath = '/app/ESignature/esignature.module';

        let modalInfo = new ModalInfo();
        modalInfo.Width = 700;
        modalInfo.Height = 400;
        modalInfo.Title = i18n("M10626", "Akıllı Kart Giriş");

        this.modalService.create(componentInfo, modalInfo).then(r => {
            console.log(r);
        }).catch(err => {
            console.log(err);
        });

    }

    public showCertificateListModal() {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'CertificateListComponent';
        componentInfo.ModuleName = 'ESignatureModule';
        componentInfo.ModulePath = '/app/ESignature/esignature.module';

        let modalInfo = new ModalInfo();
        modalInfo.Width = 400;
        modalInfo.Height = 300;
        modalInfo.Title = i18n("M21646", "Sertifika Listesi");

        this.modalService.create(componentInfo, modalInfo).then(r => {
            console.log(r);
        }).catch(err => {
            console.log(err);
        });

    }


    public ereceteImzalanacak(): void {

        let ereceteobjectID = new Guid('90efbf82-ccb7-4114-ba92-e7238e757254');
        ServiceLocator.getObject<InpatientPrescription>(ereceteobjectID, InpatientPrescription.ObjectDefID).then(pres => {
            console.log(pres);
            PrescriptionService.GetEReceteSignedInputRequest(pres).then(res => {

                this.signService.signContent(res).then(sres => {
                    console.log(sres);
                }).catch(err2 => {
                    console.log(err2);
                });

            }).catch(err1 => {
                console.log(err1);
            });
        }).catch(err => {
            console.log(err);
        });

        // PrescriptionService.GetEReceteSignedInputRequest()

    }

}