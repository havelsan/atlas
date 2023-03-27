
import { ChangeDetectionStrategy, Component, ElementRef, HostBinding, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DomSanitizer, SafeStyle } from '@angular/platform-browser';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { IAuthenticationService } from 'app/Fw/Services/IAuthenticationService';
import { IActiveComponentRegistryService } from 'app/Fw/Services/IActiveComponentRegistryService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';

@Component({
    selector: 'm-user-profile',
    templateUrl: './user-profile.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserProfileComponent implements OnInit {
    @HostBinding('class')
    // tslint:disable-next-line:max-line-length
    classes = 'm-nav__item m-topbar__user-profile m-topbar__user-profile--img m-dropdown m-dropdown--medium m-dropdown--arrow m-dropdown--header-bg-fill m-dropdown--align-right m-dropdown--mobile-full-width m-dropdown--skin-light';

    @HostBinding('attr.m-dropdown-toggle') attrDropdownToggle = 'click';

    @Input() avatar: string = '/Content/icons/user.jpg';
    @Input() avatarBg: SafeStyle = '';

    constructor(
        private router: Router,

        private sanitizer: DomSanitizer
        , protected modalService: IModalService
        , private authenticationService: IAuthenticationService
        , private componentRegistry: IActiveComponentRegistryService, protected httpService: NeHttpService, 
    ) { }

    public UserName: string = '';

    public FeedBack: any = {};
    public showDetails: boolean = false;

    showHideDetails(event) {
        this.showDetails = !this.showDetails;
        event.preventDefault();
        event.stopPropagation()
    }

    loadUser() {
        this.UserName = sessionStorage.getItem('UserName');

        try {
            this.FeedBack = JSON.parse(sessionStorage["feedback"]);
        } catch (e) {

        }

    }
    ngOnInit(): void {
        if (!this.avatarBg) {
            this.avatarBg = this.sanitizer.bypassSecurityTrustStyle('url(./assets/metronic/app/media/img/misc/user_profile_bg.jpg)');
        }

    }

    isChangePassword: boolean = false;
    public changePassword() {
        this.isChangePassword = true;


        return new Promise((resolve, reject) => {
            let _inputParam: object = null;
            _inputParam = new Object();

            _inputParam["hideLoginTab"] = "false";

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'ChangePasswordView';
            componentInfo.ModuleName = 'LoginModule';
            componentInfo.ModulePath = '/app/System/LoginModule';
            componentInfo.InputParam = _inputParam;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Şifre Değiştirme Ekranı';
            modalInfo.Width = 500;
            modalInfo.Height = 800;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                this.ChangePasswordClosing();
            }).catch(err => {
                reject(err);
            });

        });





    }
    public ChangePasswordClosing() {
        this.isChangePassword = false;
    }

    public openSettings() {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'SettingsView';
            componentInfo.ModuleName = 'SystemModule';
            componentInfo.ModulePath = '/app/System/SystemModule';
            componentInfo.InputParam = null;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Ayarlar Ekranı';
            modalInfo.Width = 500;
            modalInfo.Height = 500;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });

        });
    }

    logOut() {
        const that = this;

        if (this.modifiedComponentExists() === true) {
            const result = confirm('Değişiklikleri kaydetmeden devam etmek istiyor musunuz?');
            if (result === false) {
                return;
            }
        }
        try {
            let isLCDOpened = sessionStorage.getItem('isLCDOpened');
            if (isLCDOpened == 'true') {
                let url = 'about:blank'; //currentLocation + "/lcd/emergenyCallPatientForm?showAsAnonymous&IDS=" + outPatientResID + "&DrName=" + doktorName + "&DrObjectID=" + this.activeUserService.ActiveUser.UserObject.ObjectID;
                let input: any = { Url: encodeURI(url) };
                console.log(input);
                let httpServiceUrl = 'http://localhost:5000/api/AtlasPatientScreen/OpenMonitor';
                this.httpService.post(httpServiceUrl, input);
                sessionStorage.setItem('isLCDOpened','false');
            }
        }
        catch (e) {
            let a = 1;
        }
        this.authenticationService.logout();
    }

    private modifiedComponentExists(): boolean {

        const activeComponents = this.componentRegistry.activeComponents();
        let isModifiedComponentExists = false;
        for (const componentRef of activeComponents) {
            let boundBaseForm = componentRef.instance as TTVisual.TTBoundFormBase;
            if (boundBaseForm && boundBaseForm.isModified) {
                if (boundBaseForm.isModified() === true) {
                    isModifiedComponentExists = true;
                    break;
                }
            }
        }

        return isModifiedComponentExists;
    }

    openBarcodeSettings() {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'BarcodeSettingsView';
            componentInfo.ModuleName = 'BarcodeModule';
            componentInfo.ModulePath = '/app/System/BarcodeModule';
            componentInfo.InputParam = null;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = 'Barkod Ayarları';
            modalInfo.Width = 500;
            modalInfo.Height = 530;


            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });

        });
    }
}
