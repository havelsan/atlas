//$79C65E04
import { Component, ViewChild, OnInit, AfterViewInit, OnDestroy, Input } from '@angular/core';
import { NavigationService } from '../Services/NavigationService';
import { Router } from '@angular/router';
import { MessageService } from 'Fw/Services/MessageService';
import { ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { SidebarMenuItem } from '../../SidebarMenu/Models/SidebarMenuItem';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { MultiSelectForm } from 'NebulaClient/Visual/MultiSelectForm';
import { InfoBox } from 'NebulaClient/Visual/InfoBox';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ExaminationQueueItem } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ShowBoxTypeEnum } from "NebulaClient/Utils/Enums/ShowBoxTypeEnum";
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { Subscription } from 'rxjs';

@Component({
    selector: 'hvl-menu',
    templateUrl: './HvlMenu.html',
    providers: [MessageService]
})
export class HvlMenu implements OnInit, AfterViewInit, OnDestroy {

    @Input() ToggleSidebar: Boolean = true;

    public menuServiceDefinitionModel: MenuServiceDefinitionModel;
    private authenticationCompletedSubscription: Subscription;

    constructor(protected navigationService: NavigationService, public router: Router,
        private activeUserService: IActiveUserService,
        protected messageService: MessageService,
        protected modalService: IModalService,
        private objectContextService: ObjectContextService,
        private authenticationService: IAuthenticationService,
        protected httpService: NeHttpService) {
        if (this.menuServiceDefinitionModel == null && this.isHorizontalMenu())
            this.menuServiceDefinitionModel = new MenuServiceDefinitionModel();
    }

    protected isHorizontalMenu(): boolean {
        return false;
    }

    ngOnDestroy() {
        if (this.authenticationCompletedSubscription) {
            this.authenticationCompletedSubscription.unsubscribe();
            this.authenticationCompletedSubscription = null;
        }
    }

    private loadHorizontalMenuRoles() {
        let that = this;
        if (this.isHorizontalMenu()) {
            this.httpService.get<MenuServiceDefinitionModel>('api/MenuDefinitionService/GetHorizontalMenuRoles').then(result => {
                that.menuServiceDefinitionModel = result;
                this.OnMenuServiceDefinitionModelLoaded();
            });
        }
    }
    protected OnMenuServiceDefinitionModelLoaded() {

    }

    ngOnInit() {
        if (this.authenticationService.loggedIn()) {
            this.loadHorizontalMenuRoles();
        }
        this.authenticationCompletedSubscription = this.authenticationService.AuthenticationCompletedSource.subscribe(r => {
            this.loadHorizontalMenuRoles();
        });
    }

    ngAfterViewInit() {
    }
    queueList: Array<ExaminationQueueDefinition> = new Array<ExaminationQueueDefinition>();
    public getQuueuList(): any {
        let that = this;
        let attt: GetSortedQueueItemsByArray_Input = new GetSortedQueueItemsByArray_Input();
        if (this.activeUserService.SelectedOutPatientResource != null) {
            attt.currentResUserID = this.activeUserService.ActiveUser.UserObject.ObjectID;
            attt.outPatientResID = this.activeUserService.SelectedOutPatientResource.ObjectID;
            attt.includeCalleds = false;
            let apiUrl: string = '/api/CommonService/GetQueueDefinition';
            this.httpService.post<any>(apiUrl, attt).then(
                x => {
                    this.activeUserService.SelectedQueue = x[0];
                    that.queueList = x;
                    return that.queueList;
                }
            );
        }

    }

    public async setQueue(data: ExaminationQueueDefinition) {
        let attt: ExaminationQueueDefinitionParamClass = new ExaminationQueueDefinitionParamClass();
        attt.selectedQueue = data;
        attt.outResourceId = this.activeUserService.SelectedOutPatientResource.ObjectID;
        attt.currentResourceId = this.activeUserService.ActiveUser.UserObject.ObjectID;
        let apiUrl: string = '/api/CommonService/SetQueue';
        let x = await this.httpService.post<any>(apiUrl, attt);
        return x;

    }

    public async setPatientStatusParam(data: SetPatientStatusParam): Promise<any> {
        let attt: SetPatientStatusParam = new SetPatientStatusParam();
        attt = data;
        let apiUrl: string = '/api/CommonService/SetPatientStatus';
        this.httpService.post<any>(apiUrl, attt).then(
            x => {
            }
        );


    }
    public menuItemClicked(menuItem: SidebarMenuItem) {

    }

    public onMenuClickForRoute(routeLink: string) {
        this.navigationService.navigate(routeLink);
    }

    public openColorPrescriptionForApproval_Bash() {
        let that = this;

        let fullApiUrl: string = 'api/DrugOrderIntroductionService/OpenColorPrescriptionWithJSONForApproval';
        let input = { 'kullaniciTipi': '1' };
        this.httpService.post(fullApiUrl, input).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
        });
    }

    public openVademecum() {
        let win = window.open('http://xxxxxx.com', '_blank');
        win.focus();
    }

    public async openStatistics() {

        let apiUrl: string = '/api/CommonService/GetSystemParameterStatistics';
        this.httpService.get<string>(apiUrl).then(
            x => {
                let win = window.open(x, '_blank');
                win.focus();
            }
        );

    }

    public async openDoctorPerformance() {

        let apiUrl: string = '/api/CommonService/GetSystemParameterDoctorPerformance';
        this.httpService.get<string>(apiUrl).then(
            x => {
                let win = window.open(x, '_blank');
                win.focus();
            }
        );

    }


    examinationRetunClass: ExaminationRetunClass = new ExaminationRetunClass();
    private async Callpatient(): Promise<void> {
        if (this.activeUserService.SelectedQueue == undefined && this.queueList.length == 0) {
            InfoBox.Alert('Lütfen Önce Çalışacağınız Birimi Seçiniz.');
            return;
        }

        if (this.activeUserService.SelectedQueue == null) {
            if (this.queueList.length === 1)
                this.activeUserService.SelectedQueue = this.queueList[0];
            else {
                let pMSForm: MultiSelectForm = new MultiSelectForm();
                for (let queue of this.queueList) {
                    pMSForm.AddMSItem(queue.Name, queue.ObjectID.toString(), queue);
                }
                let sKey: string;
                sKey = await pMSForm.GetMSItem(this, i18n("M12304", "Çalışacağınız kuyruğu seçiniz."), false, true, false, false, true, true);
                if (sKey != "") {
                    this.activeUserService.SelectedQueue = <ExaminationQueueDefinition>pMSForm.MSSelectedItemObject;
                }
            }
        }
        if (this.activeUserService.SelectedQueue != null) {
            let that = this;
            that.examinationRetunClass = await that.setQueue(that.activeUserService.SelectedQueue);
            let nextItemsCount: number;
            let result: string = "";
            if (that.examinationRetunClass.examinationQueueItem.NextItemsCount > 0) {
                nextItemsCount = that.examinationRetunClass.examinationQueueItem.NextItemsCount.Value;
                result = await ShowBox.Show(ShowBoxTypeEnum.Message, i18n("M15213", "Hasta Geldi,Ertele"), "G,E", i18n("M21820", "Sıradaki Hasta"), i18n("M21820", "Sıradaki Hasta"), that.examinationRetunClass.RefNo + " " + that.examinationRetunClass.FullName + i18n("M10038", "\r\n\r\nKalan Hasta Sayısı : ") + nextItemsCount.toString(), 1);
            }
            else {
                result = await ShowBox.Show(ShowBoxTypeEnum.Message, i18n("M15213", "Hasta Geldi,Ertele"), "G,E", i18n("M21820", "Sıradaki Hasta"), i18n("M21820", "Sıradaki Hasta"), that.examinationRetunClass.RefNo + " " + that.examinationRetunClass.FullName, 1);
            }
            let param: SetPatientStatusParam = new SetPatientStatusParam();
            param.result = result;
            param.examinationQueueItem = that.examinationRetunClass.examinationQueueItem;
            that.setPatientStatusParam(param);
        }

    }

    public kullaniciBirimDegistirme(): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'UserResourceSelectionView';
            componentInfo.ModuleName = 'UserResourceSelectionModule';
            componentInfo.ModulePath = '/app/System/UserResourceSelectionModule';

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M17898", "Kullanıcı Birim Değiştirme");
            modalInfo.Width = 400;
            modalInfo.Height = 220;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                //that.getQuueuList();
            }).catch(err => {
                reject(err);
            });
        });

    }


    
    /* private showSurgery(data: Surgery): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SurgeryRequestForm';
            componentInfo.ModuleName = 'AmeliyatModule';
            componentInfo.ModulePath = '/Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
            componentInfo.InputParam = data;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M10815", "Ameliyat İstek");
            modalInfo.Width = 1300;
            modalInfo.Height = 770;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    } */
    //Ameliyat İstek>



    
}

export class GetSortedQueueItemsByArray_Input {
    public outPatientResID: Guid;
    public currentResUserID: Guid;
    public includeCalleds: boolean;
}
export class SetPatientStatusParam {
    public result: string;
    public examinationQueueItem: ExaminationQueueItem;
}
export class ExaminationRetunClass {
    public examinationQueueItem: ExaminationQueueItem;
    public RefNo: string;
    public FullName: string;
}
export class ExaminationQueueDefinitionParamClass {
    public selectedQueue: ExaminationQueueDefinition;
    public outResourceId: Guid;
    public currentResourceId: Guid;
}

export class MenuServiceDefinitionModel {
    public donemIslemleri: boolean;
    public icmalIslemleri: boolean;
    public tahsilatIslemleri: boolean;
    public venzeIslemleri: boolean;
    public faturaIslemleri: boolean;
    public faturaAnaMenu: boolean;
    public showPatientFolderShow: boolean;

    public malzemeYonetimi: boolean;

    public nursing: boolean;
    public drugCorrection: boolean;
    public diyetListe: boolean;
    public ortezIstek: boolean;
    public dokumanYonetimi: boolean;
    public ortezListele: boolean;
    public ayaktanHastaIsListesi: boolean;
    public saglikKuruluIsListesi: boolean;
    public teletipListe:boolean;

    public laboratuvarNumuneAlmaIsListesi: boolean;
    public laboratuvarProsedurIsListesi: boolean;
    public laboratuvarIsListesi: boolean;
    public hospitalTimeSchedule: boolean;

    public coloredPrescriptionApprove: boolean;
    public yeniDoktorPerformans: boolean;
    public nabizGoruntule: boolean;
    public receteIstatistikGoruntule: boolean;
    public chemoRadioIsListesi: boolean;
    public laundryModule: boolean;
    public tescilliYatakEslestirme: boolean;
    public medicalResach: boolean;

    public kiosk:boolean;
    public surgeryAppointment:boolean;
}