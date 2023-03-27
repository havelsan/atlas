import { Component } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { PatientRecordModel } from '../Models/PatientRecordModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';

@Component({
    selector: 'hvl-patient-record-form',
    inputs: ['Model'],
    templateUrl: './PatientRecordView.html',
})
export class PatientRecordView extends BaseComponent<PatientRecordModel> {

    SearchResults: Array<any>;
    constructor(container: ServiceContainer) {
        super(container);
        this.SearchResults = new Array<any>();
    }


    clientPreScript() {
          }

    clientPostScript(state: String) {

    }

    patientRecord() {
    }

    event() {
    }


}