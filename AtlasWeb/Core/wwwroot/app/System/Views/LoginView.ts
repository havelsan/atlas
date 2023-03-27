import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { LoginModel } from '../Models/LoginModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { DockPanelModel, LayoutType } from 'Fw/Models/DockPanel/DockPanelModel';
import { DockPanelPaneModel, PaneType } from 'Fw/Models/DockPanel/DockPanelPaneModel';
import { LayoutBuilder } from 'Fw/Models/DockPanel/Layout/LayoutBuilder';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { MessageService } from 'Fw/Services/MessageService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { AuthenticationResultEnum } from 'NebulaClient/Utils/Enums/AuthenticationResultEnum';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';

@Component({
    selector: 'hvl-login-view',
    templateUrl: './LoginView.html',
})
export class LoginView extends BaseComponent<LoginModel> implements OnInit {
    DockModel: DockPanelModel;
    CaptchaGuid: Guid;
    CaptchaImage: string;
    CaptchaCode: string;
    ShowCaptcha: boolean = false;
    userID: Guid;
    isChangePassword: boolean = false;


    constructor(container: ServiceContainer, private authService: IAuthenticationService,
        private activeUserService: IActiveUserService, public router: Router,
        private messageService: MessageService, 

        private favoriteService: IFavoriteService
    ) {
        super(container);
        let model = new DockPanelModel(LayoutType.Tile, '100%');
        model.LeftPaneModel = new DockPanelPaneModel(PaneType.Top);
        model.TopPaneModel = new DockPanelPaneModel(PaneType.Left);
        model.RightPaneModel = new DockPanelPaneModel(PaneType.Right);
        model.BottomPaneModel = new DockPanelPaneModel(PaneType.Bottom);
        model.LayoutType = LayoutType.Tile;
        model.TileLayout = LayoutBuilder.CreateTileLayout(3, 3).AddTile(0, 0, 1, 1, true).AddTile(1, 0, 1, 1, true);
        this.DockModel = model;
    }

    ngOnInit() {

    }

    clientPreScript() { }
    clientPostScript(state: String) { }

    public changePassword() {
        this.isChangePassword = true;
    }
    public ChangePasswordClosing() {
        this.isChangePassword = false;
    }

    passwordChanged() {
        this.isChangePassword = false;
    }


    UserNameChange(event) {
        let key: string = event.key;
        if (!this.alphaNumericOnly(key)) {
            event.preventDefault();
            return false;
        }
    }

    alphaNumericOnly(key: string): boolean {
        let re = RegExp('^([a-zA-Z0-9!.]|[^\x00-\x7F])+$').test(key);
        return re;
    }

    onLogin() {
        let that = this;
        if (this.Validate()) {
            this.lock(true);
            // otomatik giriş için yapıldı.
            this.authService.login(this.Model.UserName, this.Model.Password, this.CaptchaGuid, this.CaptchaCode).then(res => {
                if (res.Value.IsTokenAvailable == true) {

                    that.router.navigate(['acilis']);

                }
                if (res.Value.CaptchaGuid != null && res.Value.CaptchaGuid != Guid.Empty) {
                    that.ShowCaptcha = true;
                    that.CaptchaImage = 'data:image/jpeg;base64,' + res.Value.CaptchaImage;
                    that.CaptchaGuid = res.Value.CaptchaGuid;
                    this.CaptchaCode = '';
                }

                if (res.Value.AuthResultEnum == AuthenticationResultEnum.PasswordExpired) {
                    that.userID = new Guid(res.Value.user.UserID);
                    that.changePassword();
                }
            });
        }
    }

    refreshCaptcha() {
        let that = this;
        this.authService.refreshCaptcha(this.Model.UserName).then(res => {
            that.CaptchaGuid = res.Value.CaptchaGuid;
            that.CaptchaImage = 'data:image/jpeg;base64,' + res.Value.CaptchaImage;
            that.CaptchaCode = '';
        });
    }
}