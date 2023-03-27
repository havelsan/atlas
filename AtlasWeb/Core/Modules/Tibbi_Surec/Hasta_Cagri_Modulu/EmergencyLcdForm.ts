//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
@Component({
    selector: 'EmergencyLcdForm',
    templateUrl: './EmergencyLcdForm.html',
    providers: [MessageService]
})
export class EmergencyLcdForm {
    constructor(protected httpService: Http) {

    }
    currentItems: Array<PatientEmergencyInfo> = new Array<PatientEmergencyInfo>();
    public _EmergencyModel: EmergencyModel;

    public _EmergencyPageInfo: EmergencyPageInfo;

    currentPage: number = 0;
    pageSize: number = 0;
    pageCount: number = 0;
    trHeight: number = 73;
    pageInterval = 10000;
    dataInterval = 5000;

    ngOnInit() {    
        this.start();
    }

    async start() {

        await this.GetEmergencyLcdPageInfo();

        let bodyHeight = window.innerHeight - 204;
        this.pageSize = Math.floor(bodyHeight / 73);

        await this.LoadData();
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
        }, this.dataInterval);

        setInterval(() => {
            this.updateScreen();
        }, this._EmergencyPageInfo.EmergencyLcdUpdateTime);
    }

    updateScreen() {

        if (this._EmergencyModel == null || this._EmergencyModel.PatientEmergencyInfo == null || this._EmergencyModel.PatientEmergencyInfo.length == 0) {
            return;
        }
        let skip = this.currentPage * this.pageSize;

        this.currentItems = this._EmergencyModel.PatientEmergencyInfo.slice(skip, skip + this.pageSize);

        this.currentPage++;

        if (this.currentPage >= this.pageCount) {
            this.currentPage = 0;
        }
    }

    public async LoadData() {
        return this.httpService.get("/api/EmergencyLcd/GetEmergencyLcd").toPromise().then(response => {

            this._EmergencyModel = response.json() as EmergencyModel;

            this.calculateVariables();
        });
    }

    calculateVariables() {
        let totalItems = this._EmergencyModel.PatientEmergencyInfo.length;
        this.pageCount = totalItems / this.pageSize; 
    }

    public async GetEmergencyLcdPageInfo() {
        return this.httpService.get("/api/EmergencyLcd/GetEmergencyLcdPageInfo").toPromise().then(response => {
            this._EmergencyPageInfo = response.json() as EmergencyPageInfo;
        });
    }

}
export class EmergencyModel {
    public CurrentDate: string;
    public PatientEmergencyInfo: Array<PatientEmergencyInfo> = new Array<PatientEmergencyInfo>();
}
export class EmergencyPageInfo {
    public HospitalName: string;
    public EmergencyLcdUpdateTime: number;
    public EmergencyLcdNotification: string;
}

export class PatientEmergencyInfo {
    public PatientNameSurname: string;
    public Clinic: string;
    public Triage: string;
    public AdmissionTime: string;
    public IsPatientCalled: boolean;
}