import { Injectable } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReplaySubject } from 'rxjs';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { IActivePatientService } from './IActivePatientService';
import { bufferCount } from 'rxjs/operators';

@Injectable()
export class ActivePatientService implements IActivePatientService {

    private _activePatientIDList: Array<Guid>;
    private _activePatientID: Guid;
    private _activePatient: Patient = new Patient();

    // En son toplam 25 hasta tutulacak
    private readonly MaxBufferedItemCount = 25;

    private _activePatientSource = new ReplaySubject<Guid>(this.MaxBufferedItemCount);
    private _activePatientChanged = new ReplaySubject<Patient>(1);

    public ActivePatientSource = this._activePatientSource.asObservable();
    public ActivePatientChanged = this._activePatientChanged.asObservable();

    constructor() {
        this._activePatientIDList = new Array<Guid>();
        this.subscribe();
    }

    public setActivePatient(objectID: Guid): void {
        if (objectID.valueOf == Guid.Empty.valueOf) {
            this._activePatientID = Guid.Empty;
            this._activePatient = null;
        }
        else
            this._activePatientSource.next(objectID);
    }

    public get ActivePatient(): Patient {
        return this._activePatient;
    }

    public get ActivePatientID(): Guid {
        return this._activePatientID;
    }

    public get ActivePatientIDList(): Array<Guid> {
        return this._activePatientIDList;
    }

    private loadActivePatient(objectID: Guid) {
        let that = this;
        ServiceLocator.getObjectWithDefName<Patient>(objectID, 'Patient')
            .then(p => {
                that._activePatient = p;
                that._activePatientChanged.next(p);
            });
    }

    private subscribe() {
        let that = this;
        this._activePatientSource.subscribe(objectID => {
            that._activePatientID = objectID;
            that.loadActivePatient(objectID);
            that._activePatientIDList = new Array<Guid>();
            const bufferedObservable = this.ActivePatientSource.pipe(bufferCount(1));
            bufferedObservable.subscribe(z => {
                z.forEach(item => that._activePatientIDList.push(item));
            }).unsubscribe();
        });
    }
}
