//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
@Component({
    selector: 'SurgeryLcdForm',
    templateUrl: './SurgeryLcdForm.html',
    providers: [MessageService]
})
export class SurgeryLcdForm {
    constructor(protected httpService: Http) {

    }
    currentItems: Array<PatientSurgeryInfo> = new Array<PatientSurgeryInfo>();
    public _SugeryModel: SugeryModel;

    public _SurgeryPageInfo: SurgeryPageInfo;

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

        await this.GetSurgeryLcdPageInfo();

        let bodyHeight = window.innerHeight - 204;
        this.pageSize = Math.floor(bodyHeight / 73);

        await this.LoadData()
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
        }, this.dataInterval);

        setInterval(() => {
            this.updateScreen();
        }, this._SurgeryPageInfo.SurgeryLcdUpdateTime);
    }

    updateScreen() {

        if (this._SugeryModel == null || this._SugeryModel.PatientSurgeryInfo == null || this._SugeryModel.PatientSurgeryInfo.length == 0) {
            return;
        }
        let skip = this.currentPage * this.pageSize;

        this.currentItems = this._SugeryModel.PatientSurgeryInfo.slice(skip, skip + this.pageSize);

        this.currentPage++;

        if (this.currentPage >= this.pageCount) {
            this.currentPage = 0;
        }
    }

    public async LoadData() {
        return this.httpService.get("/api/SurgeryLcd/GetSurgeryLcd").toPromise().then(response => {

            this._SugeryModel = response.json() as SugeryModel;

            this.calculateVariables();
        });
    }

    calculateVariables() {
        let totalItems = this._SugeryModel.PatientSurgeryInfo.length;
        this.pageCount = totalItems / this.pageSize; 
    }

    public async GetSurgeryLcdPageInfo() {
        return this.httpService.get("/api/SurgeryLcd/GetSurgeryLcdPageInfo").toPromise().then(response => {
            this._SurgeryPageInfo = response.json() as SurgeryPageInfo;
        });
    }

}
export class SugeryModel {
    public CurrentDate: string;
    public PatientSurgeryInfo: Array<PatientSurgeryInfo> = new Array<PatientSurgeryInfo>();
}
export class SurgeryPageInfo {
    public HospitalName: string;
    public SurgeryLcdUpdateTime: number;
    public SurgeryLcdNotification: string;
}

export class PatientSurgeryInfo {
    public PatientNameSurname: string;
    public Clinic: string;
    public DoctorName: string;
    public SurgeryStatus: string;
    public UpdateTime: string;
}