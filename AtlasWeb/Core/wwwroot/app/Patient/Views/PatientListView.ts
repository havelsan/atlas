//$E6D0F48B
import { Component, OnInit } from '@angular/core';
import { PatientService } from '../Services/PatientService';
import { PatientListViewModel } from '../Models/PatientListViewModel';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';

@Component({
    selector: 'patient-list',
    template: `<h1>PatientListView</h1>`
})
export class PatientListView extends BaseComponent<PatientListViewModel> implements OnInit {

    public ObjectIdPlaceholder: string = i18n("M18387", "Lütfen ObjectId giriniz");
    public NamePlaceholder: string = i18n("M18361", "Lütfen adını giriniz");

    constructor(container: ServiceContainer, private patservice: PatientService) {
        super(container);
    }

    clientPreScript() { }
    clientPostScript(state: String) { }

    ngOnInit(): void {

    }

    gonder(): void {
        this.Model.Name = i18n("M12276", "Clientda değişti");

    }

    onSubmit(): void {
        console.log('ok');
    }
}