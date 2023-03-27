import {
    Component,
    OnInit,
    HostBinding,
    Input,
    ChangeDetectorRef,
    ViewChild,
    AfterContentInit,
    EventEmitter
} from '@angular/core';

import { INotificationDevelopmentService } from 'app/Notification/Services/INotificationDevelopmentService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { SystemApiService } from 'app/Fw/Services/SystemApiService';
import { Router, Event, NavigationStart } from '@angular/router';

import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { CommonService } from 'NebulaClient/Services/ObjectService/CommonService';

@Component({
    selector: 'm-notification',
    templateUrl: './notification.component.html',
    providers: [SystemApiService],
})
export class NotificationComponent implements AfterContentInit, IDestroyEvent {
    
    OnDestroy: EventEmitter<any> = new EventEmitter<any>();

    @HostBinding('class')
    // tslint:disable-next-line:max-line-length
    classes = 'm-nav__item m-topbar__notifications m-topbar__notifications--img m-dropdown m-dropdown--large m-dropdown--header-bg-fill m-dropdown--arrow m-dropdown--align-center 	m-dropdown--mobile-full-width';

    @HostBinding('attr.m-dropdown-toggle') attrDropdownToggle = 'click';
    @HostBinding('attr.m-dropdown-persistent') attrDropdownPersisten = 'true';

    @Input() animateShake: any;
    @Input() animateBlink: any;
    @ViewChild('dxscroll') dxscroll: any;
    public showNotification: boolean = false;
    public showReadAll: boolean = false;

    constructor(public notificationService: INotificationDevelopmentService, private changeRef: ChangeDetectorRef,         private router:Router,
        private systemApiService: SystemApiService) {

    }

    iconClick() {
        this.stopAnimate();
    }

    stopAnimate() {
        this.showNotification = false;
        this.animateShake = '';
        this.animateBlink = '';

        this.changeRef.detectChanges();
    }

    animateNotification() {
        this.showNotification = true;
        this.animateShake = 'm-animate-shake';
        this.animateBlink = 'm-animate-blink';
        this.changeRef.detectChanges();
        setTimeout(() => {
            this.animateShake = '';
            //this.animateBlink = '';
            this.changeRef.detectChanges();
        }, 3000);
    }

    readAllVisible(){
        this.showReadAll  = this.notificationService.Notifications.filter(x=> x.isRead == false).length > 0;
    }

    ngAfterContentInit(): void {
        this.notificationService.ClearAllNotifications();
        this.notificationService.GetNotifications(5, null);

        this.notificationService.BeforeUpdate.subscribe( () => {

            if(this.dxscroll != null && this.dxscroll.instance != null){
                this.dxscroll.instance.beginUpdate();
            }else{
                //console.log("scroll not initialized yet");
            }
        });

        this.notificationService.OnUpdate.subscribe(x=> {

            this.readAllVisible();
            if(this.showReadAll == true){
                this.animateNotification();
            }
            if(this.dxscroll != null){

                this.dxscroll.instance.release(true);
                setTimeout(() => {
                    this.dxscroll.instance.endUpdate();
                    this.dxscroll.instance.release(false);
                    this.changeRef.detectChanges();
                }, 10);
            }
        });
        
        this.router.events.subscribe((event: Event) => {
            if (event instanceof NavigationStart) {
                 this.OnDestroy.emit();
            }
        });
    }

    onReachBottom(){

        if(this.notificationService.ReachedBottom == false){
            this.notificationService.GetNotifications(5, this.notificationService.LastTime);
        }else{
            this.dxscroll.instance.release(true);
        }
    }

    public dotClick(notification){
        if(notification.isRead == true){
            //Set Unread
            this.readAllVisible();
            this.animateNotification();
            notification.isRead = false;
            this.notificationService.SetRead(notification.notificationID, false);
        }
    }

    public onNotificationClicked(notification){

        if(notification.isRead != true){
            notification.isRead = true;
            this.readAllVisible();
            this.notificationService.SetRead(notification.notificationID, notification.isRead);
        }
        if (notification.contentType == 3) {//Action ise
            let actionData: any = JSON.parse(notification.actionData);
            this.openPopUpDynamicComponent(actionData.objectDefName, actionData.objectID, actionData.episodeObjectID, actionData.patientObjectID, actionData.formDefId, actionData.inputparam);
        } else if (notification.contentType == 5) {//LaboratoryPanicNotification
            CommonService.checkPanicAlert();
        }
        //this.fun(notification.actionData);
    }

    public openPageDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        //TODO : Bunu nasıl simüle edeceğiz?
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).catch();
            //TODO
            //this.setActiveInfo(objectID.toString(), objectDefName);
        }
        else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(c => {
            });
        }
    }

    public openPopUpDynamicComponent(objectDefName: any, objectID: any, episodeObjectID: any, patientObjectID: any, formDefId?: any, inputparam?: any) {

        if (objectID != null) {
            this.systemApiService.openPopUp(objectID, objectDefName, formDefId, inputparam, this).then(result => {

                let modalActionResult = result as ModalActionResult;
                this.popUpDynamicComponentClosed(modalActionResult.Result);

            }).catch();
        }
    }

    public popUpDynamicComponentClosed(dialogResult: DialogResult) {
        //TODO: çarpıya basıp form kapatılınca buraya girmiyor.
        this.systemApiService.componentInfo = null;
    }


    readAll() {
        this.notificationService.ReadAll();
        this.notificationService.Notifications.forEach(x => x.isRead = true);
        this.showReadAll = false;
        this.stopAnimate();
    }

    public fun(a: any) {

        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = 'ParticipationFreeDrugReportNewForm';
        componentInfo.ModuleName = 'HastaRaporlariModule';
        componentInfo.ModulePath = 'Modules/Tibbi_Surec/Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewForm/HastaRaporlariModule';
        componentInfo.InputParam = a;

        let modalInfo: ModalInfo = new ModalInfo();
        modalInfo.Title = "";
        modalInfo.Width = 950;
        modalInfo.Height = 950;

        let promise = new Promise<string>(function (resolve, reject) {
            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(res => {
                if (res.Param.toString() != "[object Object]")
                    a.Text = res.Param;
            }).catch(err => {
                reject(err);
            });
        });
        return promise;
    }

}
