//$4850B003
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ChangePasswordModel } from '../Models/ChangePasswordModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { DockPanelModel } from 'Fw/Models/DockPanel/DockPanelModel';
import { ModalStateService, ModalInfo , IModal} from 'Fw/Models/ModalInfo';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { IActiveTabService } from 'Fw/Services/IActiveTabService';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';


@Component({
    selector: 'hvl-changepassword-view',
    templateUrl: './ChangePasswordView.html',
})
export class ChangePasswordView extends BaseComponent<ChangePasswordModel> implements IModal, OnInit {
    DockModel: DockPanelModel;
    public _hideLoginTab: string = "false";
    constructor(container: ServiceContainer, private authService: IAuthenticationService, private modalStateService: ModalStateService,
        private activeUserService: IActiveUserService, protected httpService: NeHttpService,
        private messageService: MessageService, protected tabService: IActiveTabService, ) {
        super(container);

    }
    @Output() PasswordChanged: EventEmitter<any> = new EventEmitter<any>();
    @Output() PA_passwordChanged: EventEmitter<any> = new EventEmitter<any>();

    // @Input() hideLoginTab: string;

    public _modalInfo: ModalInfo;

    @Input() set hideLoginTab(value: string) {
       this._hideLoginTab = value;

        if (this._hideLoginTab == "true")
            this.tabService.setActiveTab("kps", 'pedfn');
        else
            this.tabService.setActiveTab("login", 'pedfn');
    }
    get hideLoginTab(): string {

        return this._hideLoginTab;
    }

    setInputParam(value: Object) {
        this._hideLoginTab = value["hideLoginTab"];

    }

    ngOnInit() {

    }

    clientPreScript() { }
    clientPostScript(state: String) { }

    ChangePassword() {
        let apiUrl: string = '/api/CommonService/ChangePassword';
        let params: ChangePasswordParam = new ChangePasswordParam();
        params.newPassword = this.Model.NewPassword;
        params.oldPassword = this.Model.OldPassword;
        params.applyNewPassword = this.Model.ApplyNewPassword;
        params.userId = new Guid(this.activeUserService.ActiveUser.UserID);
        if (this.Model.ApplyNewPassword != this.Model.NewPassword) {
            this.messageService.showError(i18n("M22482", "Şifreler Uyuşmamaktadır."));
            return;
        }

        //this.httpService.post<any>(apiUrl, params).then(
        //    x => {
        //        let a = x;
        //        if (a)
        //            this.messageService.showSuccess(i18n("M16824", "İşlem Başarı İle Gerçekleştirilmiştir."));
        //    }

        //);

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                let a = x;
                if (a) {
                    this.PasswordChanged.emit();
                    this.messageService.showSuccess("İşlem Başarı İle Gerçekleştirilmiştir.");
                }
            }
        ).catch(error => {
            this.messageService.showError(error);
        });


    }

    controlLoginType()
    {
        if (this.hideLoginTab == "true")
            return true;

        return false;

    }

    getActivePassive(pageName: string): string {

            if ( this.tabService.getActiveTab('pedfn') === pageName)
                return 'active';
            else
                return '';

    }

    getActivePassivePane(pageName: string): string {

        if ( this.tabService.getActiveTab('pedfn') === pageName)
                return 'tab-pane fade in active';
            else
                return 'tab-pane fade';

    }

    TabPanelClick(source) {
        this.tabService.setActiveTab(source, 'pedfn');
    }

    setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    ChangeKPSPassword() {
        let apiUrl: string = '/api/CommonService/ChangeKPSPassword';
        let params: ChangePasswordParam = new ChangePasswordParam();
        let that = this;
        params.newPassword = this.Model.KPSPassWord;
        params.oldPassword = this.Model.KPSUserName;
        params.applyNewPassword = "";
        params.userId = new Guid(this.activeUserService.ActiveUser.UserID);

        this.httpService.post<any>(apiUrl, params).then(
            x => {
                let a = x;
                if (a) {
                    that.Model.KPSPassWord = null;
                    that.Model.KPSUserName = null;
                    that.PasswordChanged.emit();
                        if (this._hideLoginTab == "false")
                        this.modalStateService.callActionExecuted(DialogResult.Cancel, that._modalInfo.ContainerItemID, "");
                    that.messageService.showSuccess("İşlem Başarı İle Gerçekleştirilmiştir.");
                }
            }
        ).catch(error => {
            that.messageService.showError(error);
        });


    }

    //LOKMAN KOD
    //ChangePassword() {
    //    let apiUrl: string = '/api/CommonService/ChangePassword';
    //    let params: ChangePasswordParam = new ChangePasswordParam();
    //    params.newPassword = this.Model.NewPassword;
    //    params.oldPassword = this.Model.OldPassword;
    //    params.userId = new Guid(this.activeUserService.ActiveUser.UserID);

    //    this.httpService.post<any>(apiUrl, params).then(
    //        x => {
    //            let a = x;
    //            if (a) {
    //                this.PasswordChanged.emit();
    //                this.messageService.showSuccess("İşlem Başarı İle Gerçekleştirilmiştir.");
    //            }
    //        }
    //    ).catch(error => {
    //        this.messageService.showError(error);
    //    });

    //}


}
export class ChangePasswordParam
{
    public userId: Guid ;
    public oldPassword: string ;
    public newPassword: string;
    public applyNewPassword: string;
}