//$60425E6D
import { Router } from '@angular/router';
import { IAuthenticationService } from 'Fw/Services/IAuthenticationService';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { UserResourceSelectionModel } from 'System/Models/UserResourceSelectionModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { IModal, ModalInfo } from 'Fw/Models/ModalInfo';
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { ExaminationQueueDefinition } from 'NebulaClient/Model/AtlasClientModel';




@Component({
    selector: 'UserResourceSelectionView',
    templateUrl: './UserResourceSelectionView.html',
    inputs: ['Model'],
    providers: [SystemApiService],
})

export class UserResourceSelectionView extends BaseComponent<UserResourceSelectionModel> implements OnInit, IModal {

    public userResourceSelectionModel: UserResourceSelectionModel = new UserResourceSelectionModel();
    public IsOutPatientSelectedByUser : boolean = false;
    public IsInPatientSelectedByUser : boolean = false;
    private UserResourceSelectionView_DocumentUrl: string = '/api/UserResourceSelection/UserResourceSelectionView';
    constructor(container: ServiceContainer, private authService: IAuthenticationService, public router: Router, protected httpService: NeHttpService, private activeUserService: IActiveUserService) {
        super(container);
        this.Model.DefaultButtonsVisible = false;
        this.initViewModel();
    }

    ngAfterViewInit() {
        if (this.authService.loggedIn() === false) {
            this.router.navigate(['giris']);
        }
    }

    private _inputParam: Object;
    public setInputParam(value: Object) {
        this._inputParam = value;
    }

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    async ngOnInit() {
        let fullApiUrl = `${this.UserResourceSelectionView_DocumentUrl}/${Guid.Empty}`;

        if (this.authService.loggedIn() == true) {
            this.httpService.get(fullApiUrl).then(response => {
                let result = response;
                this.userResourceSelectionModel = <UserResourceSelectionModel>result;
                this.loadViewModel();
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
        }
    }

    public initViewModel(): void {

        this.userResourceSelectionModel = new UserResourceSelectionModel();
        this.userResourceSelectionModel.SelectedOutPatientResource = new ResSection();
        this.userResourceSelectionModel.SelectedQueue = new ExaminationQueueDefinition();
        this.userResourceSelectionModel.SelectedInPatientResource = new ResSection();
        this.userResourceSelectionModel.SelectedSecMasterResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;
        if (that.userResourceSelectionModel == null)
            that.userResourceSelectionModel = new UserResourceSelectionModel();

        let selectedQueueObjectID;
        if (that.activeUserService.SelectedQueue)
            selectedQueueObjectID = that.activeUserService.SelectedQueue["ObjectID"];
        else if (that.userResourceSelectionModel.SelectedQueue)
            selectedQueueObjectID = that.userResourceSelectionModel.SelectedQueue["ObjectID"];
        if (selectedQueueObjectID && that.userResourceSelectionModel.QueueList) {
            let selectedQueue = that.userResourceSelectionModel.QueueList.find(o => o.ObjectID.toString() === selectedQueueObjectID.toString());
            if (selectedQueue) {
                that.userResourceSelectionModel.SelectedQueue = <ExaminationQueueDefinition>selectedQueue;
            }
        }


        let selectedSecMasterResourceObjectID;
        if (that.activeUserService.SelectedSecMasterResource)
            selectedSecMasterResourceObjectID = that.activeUserService.SelectedSecMasterResource["ObjectID"];
        else if (that.userResourceSelectionModel.SelectedSecMasterResource)
            selectedSecMasterResourceObjectID = that.userResourceSelectionModel.SelectedSecMasterResource["ObjectID"];
        if (selectedSecMasterResourceObjectID && that.userResourceSelectionModel.SecMasterResourceList) {
            let selectedSecMasterResource = that.userResourceSelectionModel.SecMasterResourceList.find(o => o.ObjectID.toString() === selectedSecMasterResourceObjectID.toString());
            if (selectedSecMasterResource) {
                that.userResourceSelectionModel.SelectedSecMasterResource = <ResSection>selectedSecMasterResource;
            }
        }

    }

    clientPreScript() {
        this.loadViewModel();
    }
    clientPostScript(state: String) { }

    public async onOkClick() {
        await this.UpdateSelectedUserResources();
    }

    outPatientResourceSelectedItemChanged(event) {
        if(event != null ){
            this.IsOutPatientSelectedByUser = true;
            this.userResourceSelectionModel.SelectedOutPatientResource = event.selectedItem;
            this.getQueueList();
        }
    }
    inPatientResourceSelectedItemChanged(event) {
        if(event != null){
            this.IsInPatientSelectedByUser = true;
            this.userResourceSelectionModel.SelectedInPatientResource = event.selectedItem;
        }
    }
   
    async UpdateSelectedUserResources(): Promise<void> {
        try {

            if (this.IsOutPatientSelectedByUser == false && this.IsInPatientSelectedByUser == false) { // Kullanıcıyı Ayaktan yada Yatan Hasta Birimi Seçemeye Zorluyoruz.
                ServiceLocator.MessageService.showError(i18n("M11298", "Ayaktan ya da yatan hasta birimini seçmelisiniz."));
                return;
            }
            
            if(this.IsOutPatientSelectedByUser == true){
                this.activeUserService.SelectedOutPatientResource = this.userResourceSelectionModel.SelectedOutPatientResource;
            }else{
                this.activeUserService.SelectedOutPatientResource = null;
            }
            
            if(this.IsInPatientSelectedByUser == true){
                this.activeUserService.SelectedInPatientResource = this.userResourceSelectionModel.SelectedInPatientResource;
            }else {
                this.activeUserService.SelectedInPatientResource = null;
            }

            this.activeUserService.SelectedSecMasterResource = this.userResourceSelectionModel.SelectedSecMasterResource;
            this.activeUserService.SelectedQueue = this.userResourceSelectionModel.SelectedQueue;

            //Kullanıcılar server tarafında cache lendiği için server tarafı da set edildi. Ancak bu geçici çözüm. Değiştirilecek. BB
            let url: string = "/api/UserResourceSelection/UpdateSelectedUserResources";
            let body = this.userResourceSelectionModel;
            this.httpService.post(url, body).then(response => {
                let result = response;
                ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
            }).catch(error => {
                ServiceLocator.MessageService.showError("Hata : " + error);
            });
           
            ServiceLocator.ModalStateService().callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
        } catch (e) {
            ServiceLocator.MessageService.showError("Hata : " + e);
        }
    }

    queueList: Array<ExaminationQueueDefinition> = new Array<ExaminationQueueDefinition>();
    showQueueList: boolean = false;
    public getQueueList(): any {
        let that = this;
        let attt: GetSortedQueueItemsByArray_Input2 = new GetSortedQueueItemsByArray_Input2();
        if (this.userResourceSelectionModel.SelectedOutPatientResource != null) {
            attt.currentResUserID = this.activeUserService.ActiveUser.UserObject.ObjectID;
            attt.outPatientResID = this.userResourceSelectionModel.SelectedOutPatientResource.ObjectID;
            attt.includeCalleds = false;
            let apiUrl: string = '/api/CommonService/GetQueueDefinition';
            this.httpService.post<any>(apiUrl, attt, ExaminationQueueDefinition).then(
                x => {
                    that.queueList = x as Array<ExaminationQueueDefinition>;
                    this.userResourceSelectionModel.QueueList = that.queueList;
                    if (that.queueList && that.queueList.length > 1) {
                        that.showQueueList = true;
                    }
                    else {
                        that.showQueueList = false;
                    }

                    this.activeUserService.isPoolQueue = that.showQueueList;
                    this.activeUserService.SelectedQueue = that.queueList[0];
                    this.userResourceSelectionModel.SelectedQueue = that.queueList[0];
                    return that.queueList;
                }
            );
        }
    }
}

export class GetSortedQueueItemsByArray_Input2 {
    public outPatientResID: Guid;
    public currentResUserID: Guid;
    public includeCalleds: boolean;
}