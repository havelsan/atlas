import { Component } from '@angular/core';
import { ModalStateService } from "Fw/Models/ModalInfo";
import { NeHttpService } from 'app/Fw/Services/NeHttpService';


@Component({
    selector: 'PatientHistorySearchForm',
    templateUrl: './PatientHistorySearchForm.html',
})
export class PatientHistorySearchForm {
    public selectedPatient: string;
    public selectedPatientInfo: string;
    public loadDemographicForm: boolean = false;
    public loadFormByPatient: boolean = true;
    public selectedProtocolNo: string;
    public clearSelectedPatient: boolean = false;

    constructor(private modalStateService: ModalStateService, protected httpService: NeHttpService) {
        this.selectedPatient = "";
        this.selectedPatientInfo = "";
        this.selectedProtocolNo = "";
    }

    async patientChanged(patient: any) {
        if (patient != null) {
            this.loadDemographicForm = false;
            this.selectedProtocolNo = "";
            this.selectedPatient = patient.ObjectID;
            this.selectedPatientInfo = patient.ObjectID;
            this.loadFormByPatient = true;
            this.loadDemographicForm = true;
            this.clearSelectedPatient = false;
        }
    }

    async onProtocolNoEnterKeyDown(protocolNo: string) {
        this.loadDemographicForm = false;
        this.selectedPatient = "";
        //this.selectedProtocolNo = protocolNo;
        this.selectedPatientInfo = await this.getPatientInfo(this.selectedProtocolNo);
        this.loadFormByPatient = false;
        this.loadDemographicForm = true;
        this.clearSelectedPatient = true;
    }

    public async getPatientInfo(protocolNo: string): Promise<string> {
        let that = this;
        let patientInfo = "";
        let fullApiUrl: string = "/api/PatientHistoryService/GetPatientInfo?protocolNo=" + protocolNo;
        await this.httpService.get<any>(fullApiUrl)
            .then(response => {
                patientInfo = response as string;
            })
            .catch(error => {
                console.log(error);
            });

        return patientInfo;
    }
}




