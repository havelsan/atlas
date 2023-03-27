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
    selector: 'CallPatientForm',
    templateUrl: './CallPatientForm.html',
    providers: [MessageService]
})
export class CallPatientForm {
    constructor(protected httpService: Http) {

    }
    currentItem: QueueItems= new QueueItems();

    private _Model: QueueItems;
    @Input() set Model(value: QueueItems) {
        this._Model = value;
    }
    get Model(): QueueItems {
        return this._Model;
    }

    ngOnInit() {
        this.start();
    }

    async start() {
        this.currentItem = this._Model;
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
