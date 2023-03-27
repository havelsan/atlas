//$19F8320B
import { Component, OnInit, NgZone, ViewChild, ElementRef } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { Common } from 'app/NebulaClient/Model/AtlasClientModel';
import { Http, Response } from '@angular/http';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { window } from 'rxjs/operators';
@Component({
    selector: 'PoliclinicLcdForm',
    templateUrl: './PoliclinicLcdForm.html',
    providers: [MessageService]
})
export class PoliclinicLcdForm {
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

        //let bodyHeight = window.innerHeight - 204;
        //this.pageSize = Math.floor(bodyHeight / 73);

        await this.LoadData();
        this.updateScreen();

        setInterval(() => {
            this.LoadData();
            this.updateScreen();
        }, this.dataInterval);

    }
    Count: number = 0;
    SendModel: QueueItems = new QueueItems();
    lastCalledPatient: QueuePatient;
    hasCalledByDoctor: boolean = false;
    updateScreen() {
        this.currentItem = this._Model;
        if (this.hasCalledByDoctor == true)
            this.hasCalledByDoctor = false;
        for (let pat of this.currentItem.patient) {
            if (pat.Priority == "-1" && this.lastCalledPatient != pat) {
                this.SendModel = new QueueItems();
                if (this.lastCalledPatient != null) {
                    if (this.lastCalledPatient.patientName == pat.patientName) {
                        this.hasCalledByDoctor = false;
                    }
                    else {
                        this.hasCalledByDoctor = true;
                        this.Count = 0;
                    }
                }
                if (this.lastCalledPatient == null)
                    this.hasCalledByDoctor = true;
                this.lastCalledPatient = pat;
                this.SendModel.patient.push(pat);
                this.SendModel.doctorName = this.currentItem.doctorName;
                this.SendModel.polName = this.currentItem.polName;
                this.SendModel.GeneralLcdNotification = this.currentItem.GeneralLcdNotification;
                break;
            }
        }
        if (this.lastCalledPatient != null) {
            if (this.hasCalledByDoctor == false && this.Count == 0) {
                this.hasCalledByDoctor = true;
                this.Count++;
            }
            if (this.hasCalledByDoctor == false && this.Count == this._Model.GeneralLcdUpdateTime) {
                this.hasCalledByDoctor = false;
            }
        }
    }


    getUrlParameter(name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    }

    public async LoadData() {
        return this.httpService.get("/api/PoliclinicLcdForm/GetPoliclinicLcd?outPatientResID=" + this.IDS + "&DrName=" + this.DrName + "&DrObjectID=" + this.DrObjectID).toPromise().then(response => {

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
