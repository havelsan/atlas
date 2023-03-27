import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { DxAutocompleteComponent } from "devextreme-angular";
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { UsernamePwdInput } from 'app/NebulaClient/Visual/UsernamePwdBox';

@Component({
    selector: "username-pwd-form",
    template: `
    <div class="row">
        <label class="control-label col-sm-12">Kullanıcı Adı:</label>
        <div class="col-sm-12">
            <dx-text-box [(value)]="usernamePwdFormViewModel.userName" ></dx-text-box>
        </div>
    </div>
    <div class="row">
        <label class="control-label col-sm-12">Şifre:</label>
        <div class="col-sm-12">
            <dx-text-box mode="Password" [(value)]="usernamePwdFormViewModel.password" [showClearButton]="true"></dx-text-box>
        </div>
    </div>
    <div>
        <div class="col-sm-6">
            <dx-button type="success" text="Tamam" (onClick)="OkButtonClick()">

            </dx-button>
        </div>
        <div class="col-sm-6">
            <dx-button type="default" text="İptal" (onClick)="CancelButtonClick()">

            </dx-button>
        </div>
    </div>
    <dx-check-box [(value)]="savePasswordForSession" (onValueChanged)="savePwdCheckBoxOnChanged($event)" text="Şifreyi Hatırla (Sadece Bu Giriş)">

    </dx-check-box>
    `,
})
export class UsernamePwdFormComponent implements IModal, OnInit {
    //public Name: string = "";

    @Output() OkButtonClicked: EventEmitter<any> = new EventEmitter<any>();

    public _sessionStoragePwdName: string;
    //Kullanıcı adının session storage içerisine kayıt olacağı değişken ismi.
    public _sessionStorageUsername: string;

    @ViewChild(DxAutocompleteComponent) autoComplete: DxAutocompleteComponent;
    public usernamePwdFormViewModel: UsernamePwdFormViewModel = new UsernamePwdFormViewModel();
    public _modalInfo: ModalInfo;
    public savePasswordForSession = false;
    private getMkysUsernameOnInit = false;
    private getUserUniqueRefNoOnInit = false;
    private doNotOpenSavedScreen = false;
    setInputParam(value: Object) {
        let input = <UsernamePwdInput>value;
        this.getMkysUsernameOnInit = input.GetMkysUsernameOnInit;
        this._sessionStoragePwdName = input.SessionStoragePwdName;
        this._sessionStorageUsername = input.SessionStorageUsername;
        this.getUserUniqueRefNoOnInit = input.GetUserUniqueRefNoOnInit;
        this.doNotOpenSavedScreen = input.doNotOpenSavedScreen;
        if (this.getMkysUsernameOnInit) {
            this.getUserUniqueRefNoOnInit = false;
            let username = window.sessionStorage.getItem(this._sessionStorageUsername);
            if (String.isNullOrEmpty(username))
                this.getMkysUserName();
            else
                this.usernamePwdFormViewModel.userName = username;
        }

        if (this.getUserUniqueRefNoOnInit) {
            let username = window.sessionStorage.getItem(this._sessionStorageUsername);
            if (String.isNullOrEmpty(username))
                this.getUserUniqueRefNo();
            else
                this.usernamePwdFormViewModel.userName = username;
        }

        let savePwd = window.sessionStorage.getItem('savePasswordForSession');
        if (!String.isNullOrEmpty(savePwd))
            this.savePasswordForSession = savePwd == 'true';

        let mkysUsername = window.sessionStorage.getItem(this._sessionStorageUsername);
        if (!String.isNullOrEmpty(mkysUsername))
            this.usernamePwdFormViewModel.userName = mkysUsername;

        let mkysPwd = window.sessionStorage.getItem(this._sessionStoragePwdName);
        if (!String.isNullOrEmpty(mkysPwd))
            this.usernamePwdFormViewModel.password = mkysPwd;

        

    }
    setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    constructor(private modalStateService: ModalStateService, protected http: NeHttpService) {

    }
    ngOnInit(): void {

    }

    ngAfterViewInit(){
        if(this.doNotOpenSavedScreen){
            if(!String.isNullOrEmpty(this.usernamePwdFormViewModel.userName) && !String.isNullOrEmpty(this.usernamePwdFormViewModel.password) )
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.usernamePwdFormViewModel);
        }
    }

    public savePwdCheckBoxOnChanged(event: any) {
        if (!event.value) {
            window.sessionStorage.setItem(this._sessionStorageUsername, '');
            window.sessionStorage.setItem(this._sessionStoragePwdName, '');
            window.sessionStorage.setItem('savePasswordForSession', 'false');
            this.usernamePwdFormViewModel.password = '';
        }
    }

    public CancelButtonClick(): void {
        if (!this.savePasswordForSession) {
            window.sessionStorage.setItem(this._sessionStorageUsername, '');
            window.sessionStorage.setItem(this._sessionStoragePwdName, '');
            window.sessionStorage.setItem('savePasswordForSession', 'false');
        }
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this.usernamePwdFormViewModel);
    }

    public OkButtonClick() {
        if (this.savePasswordForSession && !String.isNullOrEmpty(this.usernamePwdFormViewModel.password)) {
            window.sessionStorage.setItem(this._sessionStorageUsername, this.usernamePwdFormViewModel.userName);
            window.sessionStorage.setItem(this._sessionStoragePwdName, this.usernamePwdFormViewModel.password);
            window.sessionStorage.setItem('savePasswordForSession', 'true');
        }
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this.usernamePwdFormViewModel);
    }

    private getMkysUserName() {
        let url = 'api/StockActionService/GetMkysUserName';
        this.http.get<string>(url).then(res => {
            if (!String.isNullOrEmpty(res))
                window.sessionStorage.setItem(this._sessionStorageUsername, res);
            this.usernamePwdFormViewModel.userName = res;
        });
    }

    private getUserUniqueRefNo() {
        let url = 'api/EpisodeActionService/GetActiveUserUniqueRefNo';
        this.http.get<string>(url).then(res => {
            if (!String.isNullOrEmpty(res))
                window.sessionStorage.setItem(this._sessionStorageUsername, res);
            this.usernamePwdFormViewModel.userName = res;
        });
    }
}

export class UsernamePwdFormViewModel {
    public userName: string;
    public password: string;
}