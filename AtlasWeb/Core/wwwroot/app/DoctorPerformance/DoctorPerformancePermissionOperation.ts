//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DoctorPerformancePermissionOperationViewModel, UnitManagerModel, RelatedUserModel, saveUnitManagerAndRelatedDoctors } from './DoctorPerformanceViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Component({
    selector: "dp-permission-operation",
    templateUrl: './DoctorPerformancePermissionOperation.html'
})
export class DoctorPerformancePermissionOperation implements OnInit {
    public doctorPerformancePermissionOperationViewModel: DoctorPerformancePermissionOperationViewModel;

    DPUnitManagerListColumns = [];
    DPRelatedUserColumns = [];

    constructor(protected http: NeHttpService) {
        this.doctorPerformancePermissionOperationViewModel = new DoctorPerformancePermissionOperationViewModel();
    }

    ngOnInit() {
        this.generateColumns();
        this.loadDataSources();
    }

    loadDataSources(): void {
        this.http.get<Array<UnitManagerModel>>("api/DoctorPerformanceApi/GetAllUnitManagerList").then(result => {
            this.doctorPerformancePermissionOperationViewModel.UnitManagerList = result;
        }).catch(error => {
            this.errorHandlerForDPPermissionOperation(error);
            });

        this.http.get<Array<RelatedUserModel>>("api/DoctorPerformanceApi/GetAllUserList").then(result => {
            this.doctorPerformancePermissionOperationViewModel.RelatedUserList = result;
        }).catch(error => {
            this.errorHandlerForDPPermissionOperation(error);
            });

    }

    selectedUnitManager: Array<UnitManagerModel> = new Array<UnitManagerModel>();
    selectedRelatedUser: Array<RelatedUserModel> = new Array<RelatedUserModel>();

    btnSavePermissionClick(): void {
        let savePermission: saveUnitManagerAndRelatedDoctors = new saveUnitManagerAndRelatedDoctors ();

        for (let index = 0; index < this.selectedUnitManager.length; index++) {
            savePermission.UnitManagerObjectID = this.selectedUnitManager[index].ObjectID;
        }
        for (let index = 0; index < this.selectedRelatedUser.length; index++) {
            savePermission.ResUserObjectIDList.push(this.selectedRelatedUser[index].ObjectID);
        }

        this.loadPanelOperation(true, "Kayıt yapılıyor. Lütfen bekleyiniz");
        let apiUrlForTransactionHizmetKayit: string = '/api/DoctorPerformanceApi/saveUnitManagerAndRelatedDoctors';

        this.http.post(apiUrlForTransactionHizmetKayit, savePermission).then(response => {
            this.loadPanelOperation(false, "");
        }).catch(error => {
            this.errorHandlerForDPPermissionOperation(error);
            });

    }

    onRowClickUnitManagerList(event: any): void {
        this.http.get<Array<RelatedUserModel>>("api/DoctorPerformanceApi/GetRelatedUserList?UnitManagerID="+event.data.ObjectID).then(result => {
            this.selectedRelatedUser = result;
        }).catch(error => {
            this.errorHandlerForDPPermissionOperation(error);
        });
    }

    generateColumns(): void {
        let that = this;
        this.DPUnitManagerListColumns = [
            {
                caption: 'Birim Yöneticisi',
                dataField: 'Name',
                dataType: 'string'
            }];
        this.DPRelatedUserColumns = [
            {
                caption: 'Kullanıcı',
                dataField: 'Name',
                dataType: 'string'
            }, {
                caption: 'Branş',
                dataField: 'SpecialtyName',
                dataType: 'string'
            }];
    }


    errorHandlerForDPPermissionOperation(message: string): void {
        this.loadPanelOperation(false, '');
        ServiceLocator.MessageService.showError(message);
        console.log(message);
    }

    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';

        //this.loadPanelOperation(false, "");
        //this.loadPanelOperation(true,  "Mesaj");
    }
}