//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
@Component({
    selector: 'NewBornLcdForm',
    templateUrl: './NewBornLcdForm.html',
    providers: [MessageService]
})
export class NewBornLcdForm {
    constructor(protected httpService: Http) {

    }
    currentItems: Array<PatientNewBornInfo> = new Array<PatientNewBornInfo>();
    public _NewBornModel: NewBornModel;

    public _NewBornPageInfo: NewBornPageInfo;

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

        await this.GetNewBornLcdPageInfo();

        let bodyHeight = window.innerHeight - 204;
        this.pageSize = Math.floor(bodyHeight / 73);

        await this.LoadData()
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
        }, this.dataInterval);

        setInterval(() => {
            this.updateScreen();
        }, this._NewBornPageInfo.NewBornLcdUpdateTime);
    }

    updateScreen() {

        if (this._NewBornModel == null || this._NewBornModel.PatientNewBornInfo == null || this._NewBornModel.PatientNewBornInfo.length == 0) {
            return;
        }
        let skip = this.currentPage * this.pageSize;

        this.currentItems = this._NewBornModel.PatientNewBornInfo.slice(skip, skip + this.pageSize);

        this.currentPage++;

        if (this.currentPage >= this.pageCount) {
            this.currentPage = 0;
        }
    }

    public async LoadData() {
        return this.httpService.get("/api/NewBornLcd/GetNewBornLcd").toPromise().then(response => {

            this._NewBornModel = response.json() as NewBornModel;

            this.calculateVariables();
        });
    }

    calculateVariables() {
        let totalItems = this._NewBornModel.PatientNewBornInfo.length;
        this.pageCount = totalItems / this.pageSize; 
    }

    public async GetNewBornLcdPageInfo() {
        return this.httpService.get("/api/NewBornLcd/GetNewBornLcdPageInfo").toPromise().then(response => {
            this._NewBornPageInfo = response.json() as NewBornPageInfo;
        });
    }

}
export class NewBornModel {
    public CurrentDate: string;
    public PatientNewBornInfo: Array<PatientNewBornInfo> = new Array<PatientNewBornInfo>();
}
export class NewBornPageInfo {
    public HospitalName: string;
    public NewBornLcdUpdateTime: number;
    public NewBornLcdNotification: string;
}
export class PatientNewBornInfo {
    public PatientNameSurname: string;
    public Clinic: string;
    public Gender: string;
    public GenderKodu: string;
    public BirthTime: string;
    public BirthWeight: string;
}