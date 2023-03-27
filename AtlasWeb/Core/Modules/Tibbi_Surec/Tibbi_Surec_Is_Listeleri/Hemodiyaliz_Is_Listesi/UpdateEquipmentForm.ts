//$8F2DAF9F

import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { UpdateEquipmentViewModel } from './HemodialysisWorkListViewModel';
import { ResEquipment, ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';

@Component({
    selector: "UpdateEquipmentForm",
    templateUrl: './UpdateEquipmentForm.html',
    providers: [MessageService]

})
export class UpdateEquipmentForm extends BaseComponent<any> implements OnInit, OnDestroy {


    _sessionUnitDataSource: Array<any> = [];
    _equipmentDataSource: Array<any> = [];
    _equipmentStatusDataSource: Array<any> = [{
        Name: 'Aktif',
        ObjectID: 1
    },
        {
        Name: 'Pasif',
            ObjectID: 0
    }];
    _equipmentToTransferDataSource: Array<any> = [];
    _countTypeDataSource: Array<any> = [{
        Name: 'Gün',
        ObjectID: 0
    },
        {
            Name: 'Ay',
            ObjectID: 1
        }, {
            Name: 'Yıl',
            ObjectID: 2
        }];


    updateEquipmentViewModel: UpdateEquipmentViewModel = new UpdateEquipmentViewModel();


    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }



    constructor(protected httpService: NeHttpService, private http: AtlasHttpService, services: ServiceContainer, protected messageService: MessageService) {
        super(services);
    }

    async ngOnInit() {
         await this.loadEquipmentModel();
      
    }


    private async loadEquipmentModel(): Promise<any> {

        let that = this;
        let fullApiUrl: string = "/api/HemodialysisWorkListService/LoadUpdateEquipmentViewModel";
        this.httpService.get<UpdateEquipmentViewModel>(fullApiUrl)
            .then(response => {
                that.updateEquipmentViewModel = response as UpdateEquipmentViewModel;
            })
            .catch(error => {
                console.log(error);
            });


        
    }

 

    SessionUnitChanged(data) {
        let that = this;
        let unit: ResTreatmentDiagnosisUnit = data.value;
        that.updateEquipmentViewModel.TreatmentUnit = unit;
        let fullApiUrl: string = "/api/HemodialysisWorkListService/GetEquipmentList?ObservationUnitID='" + unit.ObjectID.toString() + "'";
        this.httpService.get<Array<ResEquipment>>(fullApiUrl)
            .then(response => {
                that.updateEquipmentViewModel.TreatmentEquipmentList = response as Array<ResEquipment>;


            })
            .catch(error => {
                console.log(error);
            });


    }

    EquipmentChanged(data) {
        let that = this;
        let equipment: ResEquipment = data.value;
        this.updateEquipmentViewModel.SelectedEquipment = equipment;
        if (equipment.IsActive == true) {
            this.updateEquipmentViewModel.SelectedEquipmentStatus = 1;
        } else if (equipment.IsActive == false) {
            this.updateEquipmentViewModel.SelectedEquipmentStatus = 0;
        }
    }

  
    EquipmentToTransferChanged(data) {
        let that = this;
        that.updateEquipmentViewModel.TransferedEquipment = data.value;

    }

    TransferAppointments(event): void {
        if (event.value === true) {
            this.updateEquipmentViewModel.TransferAllCheck = false;

            

        }
        
    }

    GetNotAppointedEquipmentList(fromAll: boolean) {
        let that = this;

        let fullApiUrl: string = "/api/HemodialysisWorkListService/GetNotAppointedEquipmentList?ObservationUnitID='" + that.updateEquipmentViewModel.TreatmentUnit.ObjectID.toString() + "'&FromTransFerAll=" + fromAll + "&Count=" + that.updateEquipmentViewModel.Count + "&CountType=" + that.updateEquipmentViewModel.CountType;
        this.httpService.get<Array<ResEquipment>>(fullApiUrl)
            .then(response => {
                that.updateEquipmentViewModel.NotAppointedEquipmentList = response as Array<ResEquipment>;


            })
            .catch(error => {
                console.log(error);
            });

    }

    TransferAll(event): void {
        if (event.value === true) {
            this.updateEquipmentViewModel.TransferAppointmentsCheck = false;
            this.GetNotAppointedEquipmentList(true);
        }
       
    }

    updateEquipmentSettings() {
        //let that = this;
        //this.barcodeModel = new BarcodeSettingsViewModel();
        //this.barcodeModel._Settings = new Array<BarcodeSettings>();
        //this.barcodeModel._Settings = that._barcodeSettingsArray;

        //let apiUrl: string = '/api/CommonService/SaveUserBarcodeSettings';

        //this.httpService.post(apiUrl, this.barcodeModel).then(result => {
        //    this.messageService.showInfo("İşlem başarıyla kaydedildi.");

        //})
        //    .catch(error => {
        //        this.messageService.showError(error);
        //    });
    }

   
}

