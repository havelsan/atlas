import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { MainPageModel } from 'System/Models/MainPageModel';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { CommonService } from 'NebulaClient/Services/ObjectService/CommonService';
import { Subscription } from "rxjs";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ShowBoxTypeEnum } from 'app/NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { environment } from 'app/environments/environment';

@Component({
    templateUrl: './MainPageView.html',
    providers: [SystemApiService]
})
export class MainPageView extends BaseComponent<MainPageModel> implements OnInit, OnDestroy {
    private authenticationCompletedSubscription: Subscription;

    constructor(public systemApiService: SystemApiService, container: ServiceContainer, private authenticationService: IAuthenticationService, public router: Router, protected httpService: NeHttpService, ) {
        super(container);
        this.Model.DefaultButtonsVisible = false;
    }

    async ngAfterViewInit() {
        if (this.authenticationService.loggedIn() === false) {
            this.router.navigate(['giris']);
        } else {
            let doNotOpenUserResourceSelectionView: boolean = await CommonService.setIfSingleUserResources();
            if (doNotOpenUserResourceSelectionView === false) {
                this.getsysMessages();
                CommonService.openUserResourceSelectionView().then(async res => {
                    if(environment.target != 'dev') 
                    {
                        let openReportApproveForm = <boolean>await this.httpService.get('/api/ReportApproveFormService/getMyDisapprovedReportExistance');
                        if (openReportApproveForm != true)
                            return;
                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), "", i18n("M21560", "Onay bekleyen raporlarınız bulunmaktadır. Rapor onay ekranını açmak istiyor musunuz? "), 1);
                        if (result === "H") {
                            return;
                        }
                        CommonService.openRaporOnayEkrani();
                    }

                    //Parametre ve listede hasta varsa kontrol et
                    let checkPanicNotification = <boolean>await this.httpService.get('/api/LaboratoryProcedureService/CheckPanicNotification');
                    if (checkPanicNotification != true)
                        return;
                    else {
                        setInterval(() => {
                            CommonService.checkPanicAlert();
                        }, 1800000);//20000
                      
                    }

                   

                });

            }
        }
    }

    inbox = new Array<any>();
    async getsysMessages() {

        let apiUrl: string = '/api/UserMessageService/GetUnreadSysMessages';
        this.httpService.post<any>(apiUrl, null).then(
            x => {
                this.inbox = x;
            }

        );
    }

    selectedChange(data: any) {
        if (data.itemData.Messageid != undefined) {
            if (data.itemData.Durumu != 0) {
                let param: InputParam = new InputParam();
                param.ObjectID = new Guid(data.itemData.Messageid);
                let apiUrl: string = '/api/UserMessageService/IsMessageRead';
                this.httpService.post<any>(apiUrl, param).then(
                    x => {
                        this.updateCurrentBox();
                    }
                );
            }
            this.systemApiService.open(data.itemData.Messageid, 'USERMESSAGE', 'b40ac20a-68fd-485e-9915-ce7c66d5801a');
        }

    }

    async updateCurrentBox() {
        await this.getsysMessages();
    }

    clientPreScript() { }
    clientPostScript(state: String) { }

    ngOnDestroy() {
        if (this.authenticationCompletedSubscription) {
            this.authenticationCompletedSubscription.unsubscribe();
            this.authenticationCompletedSubscription = null;
        }
    }

    ngOnInit() {
        /*this.authenticationCompletedSubscription = this.authenticationService.AuthenticationCompletedSource.subscribe(r => {
            CommonService.openUserResourceSelectionView();
        }); */
    }
}
export class InputParam {
    public ObjectID: Guid;
    public CurrentBox: string;
}