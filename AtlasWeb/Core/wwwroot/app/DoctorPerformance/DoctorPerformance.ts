//$B031EBC6
import { Component, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { HasDPRolesModel } from './DoctorPerformanceViewModel';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';

@Component({
    selector: "doctor-performance",
    templateUrl: './DoctorPerformance.html'
})
export class DoctorPerformance implements OnInit {

    public hasDPRole: HasDPRolesModel = new HasDPRolesModel();

    constructor(protected http: NeHttpService) {
        this.http.get<HasDPRolesModel>("api/DoctorPerformanceApi/HasDPRoles").then(result => {
            this.hasDPRole = result;
        }).catch(error => {
            ServiceLocator.MessageService.showError(error);
            console.log(error);
        });
    }

    ngOnInit() {

    }
}