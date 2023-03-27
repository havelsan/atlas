import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { UserPackageViewModel, PackageBasicObject, DiagnosisModel, PackageInfoViewModel } from './UserPackageViewModel';

import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemApiService } from 'Fw/Services/SystemApiService';

@Component({
    selector: "UserPackageForm",
    templateUrl: './UserPackageForm.html',

    providers: [SystemApiService],

})
export class UserPackageForm extends BaseComponent<any> implements OnInit, IModal, OnDestroy {
    userPackageViewModel: UserPackageViewModel = new UserPackageViewModel();
    packageInfoViewModel: PackageInfoViewModel = new PackageInfoViewModel();
    DiagnosisColumns = [

        { caption: 'Tanı Kodu', dataField: 'Code', fixed: true, width: '100' },
        { caption: 'Tanı Adı', dataField: 'Name', fixed: true, width: '200' }

    ]


    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super(services);
    }

    async ngOnInit() {
        await this.loadUserPackageViewModel();

    }

    private _inputParam: Object;
    public setInputParam(value: Object) {
        this._inputParam = value;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }
    loadUserPackageViewModel() {
        let that = this;
        let fullApiUrl: string = "/api/UserPackageService/LoadUserPackageViewModel";
        this.httpService.get<UserPackageViewModel>(fullApiUrl)
            .then(response => {
                that.userPackageViewModel = response as UserPackageViewModel;
            })
            .catch(error => {
                console.log(error);
            });

    }

    public ngOnDestroy(): void {
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    PackageChanged(data) {
        let that = this;
        let packageInfo: PackageBasicObject = data.value;

        //DiagnosisList doldur

        let fullApiUrl: string = "/api/UserPackageService/LoadPackageInfoViewModelByPackageID?PackageID='" + packageInfo.ObjectID.toString() + "'";

        this.httpService.get<PackageInfoViewModel>(fullApiUrl)
            .then(response => {
                that.packageInfoViewModel = response as PackageInfoViewModel;


            })
            .catch(error => {
                console.log(error);
            });

    }




    //public ClosePanicNotification(): void {
    //    ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    //}


}
