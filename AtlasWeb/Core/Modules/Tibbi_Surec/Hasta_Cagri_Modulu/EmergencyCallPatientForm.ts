//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef, Input } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { window } from 'rxjs/operators';
@Component({
    selector: 'EmergencyCallPatientForm',
    templateUrl: './EmergencyCallPatientForm.html',
    providers: [MessageService]
})
export class EmergenyCallPatientForm {
    public IDS;
    public DrName;
    public DrObjectID;
    constructor(protected httpService: Http) {
        this.IDS = this.getUrlParameter("IDS");
        this.DrName = this.getUrlParameter("DrName");
        this.DrObjectID = this.getUrlParameter("DrObjectID");
    }
    currentItem: QueueItems = new QueueItems();
    public _Model: QueueItems;

    dataInterval = 2000;


    ngOnInit() {
        this.start();
    }

    async start() {


        await this.LoadData();
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
            this.updateScreen();
        }, this.dataInterval);

    }


    updateScreen() {
        this.currentItem.doctorName = this._Model.doctorName;
        this.currentItem.polName = this._Model.polName;
        this.currentItem.GeneralLcdNotification = this._Model.GeneralLcdNotification;
        this.currentItem.hospitalName = this._Model.hospitalName;
        if (this._Model.patient.length > 0) {
            this.currentItem.patient = new Array<QueuePatient>();
            this.currentItem.patient.push(this._Model.patient[0]);
        }
    }


    getUrlParameter(name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    }

    public async LoadData() {
        return this.httpService.get("/api/PoliclinicLcdForm/GetEmergencyLcd?outPatientResID=" + this.IDS + "&DrName=" + this.DrName + "&DrObjectID=" + this.DrObjectID).toPromise().then(response => {

            this._Model = response.json() as QueueItems;

        });
    }
}


export class QueuePatient {
    public patientName: string;
    public OrderNO: string;
    public PriorityReason: string;
    public Priority: string;
    public QueueDate: string;
    public CallTime: Date;
    public DivertedTime: string;
    public Doctor: string;
    public Index: number;
    public ObjectID: Guid;
    public IsEmergency: Boolean;
    public SubActionProcedureObjectID: Guid;
}
export class QueueItems {
    public doctorName: string;
    public polName: string;
    public hospitalName: string;
    public GeneralLcdUpdateTime: number;
    public GeneralLcdNotification: string;
    public LcdNotification: string;
    public Count: number;
    public patient: Array<QueuePatient> = new Array<QueuePatient>();
}

export class Policinics {
    public Policlinics: Array<Policlinic> = new Array<Policlinic>();
}


export class Policlinic {
    public Name: string;
    public Count: number;
}
