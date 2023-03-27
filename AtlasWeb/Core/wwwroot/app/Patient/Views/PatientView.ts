import { Component } from '@angular/core';
import {BaseComponent} from 'Fw/Components/BaseComponent';
import {Patient} from '../Models/Patient';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';

@Component({
    selector: 'hvl-com-hasta-kayit',
    inputs: ['Model'],
    template: `<h1>PatientView</h1>`,
})
export class PatientView extends BaseComponent<Patient> {

    //navigator: NavigationService,, notifier: NotificationService
    constructor( container: ServiceContainer) {
        super(container);
    }

    clientPreScript() {
    }

    ulkeChanged(ulkeId: any) {
    }

    IlChange(Id: any) {
    }

    IlceChange(Id: any) {
    }

    MernisClick() {

    }

    clientPostScript(state: String) {

    }
}