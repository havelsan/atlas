import { Component, Output, EventEmitter } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { MessageService } from 'Fw/Services/MessageService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { Patient } from 'app/NebulaClient/Model/AtlasClientModel';
import { PatientAdInput_DTO } from './MedicalResarchPatientAdViewModel';

@Component({
    selector: 'MedicalResarchPatientAd',
    templateUrl: './MedicalResarchPatientAd.html',
    providers: [MessageService, SystemApiService]
})
export class MedicalResarchPatientAd implements IModal {


    constructor(private http: NeHttpService, protected systemApiService: SystemApiService) {

    }

    public MedicalResarchObjectID: any;
    public setInputParam(value: Object) {
        this.MedicalResarchObjectID = value;
    }

    public setModalInfo(value: ModalInfo) {
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }

    selectedPatient: Patient = new Patient();
    async patientChanged(patient: any) {
        let that = this;
        if (!that.selectedPatient) {
            that.selectedPatient = new Patient();
        }
        that.selectedPatient = patient;
    }

    @Output() public ActionExecuted: EventEmitter<any> = new EventEmitter<any>();
    public loadingVisible: boolean = false;
    public LoadPanelMessage: string;
    async savePatientClick() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "Araştırma için Hasta Kayıt Yapılıyor Lütfen Bekleyiniz.";
        let fullApiUrl: string = 'api/MedicalResarchPatientAdService/saveMedicalResarchPatientAd';
        let inputDTO: PatientAdInput_DTO = new PatientAdInput_DTO();
        inputDTO.medicalResarchPatient = this.selectedPatient;
        inputDTO.medicalResarchObjectID = this.MedicalResarchObjectID;
        await this.http.post(fullApiUrl, inputDTO)
            .then((res) => {
                let resulst: string = res as string;
                ServiceLocator.MessageService.showInfo(resulst);
                this.loadingVisible = false;
                this.ActionExecuted.emit({ Cancelled: true });
            })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
                this.loadingVisible = false;
            });
    }
}