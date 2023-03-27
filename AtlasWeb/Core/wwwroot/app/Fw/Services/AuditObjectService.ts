import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { IAuditObjectService, AuditObject } from './IAuditObjectService';
import { bufferCount } from 'rxjs/operators';

@Injectable()
export class AuditObjectService implements IAuditObjectService {

    private _objectIDList: Array<AuditObject>;

    // En son toplam 25 hasta tutulacak
    private readonly MaxBufferedItemCount = 25;

    private _auditObjectSource = new ReplaySubject<AuditObject>(this.MaxBufferedItemCount);
    private _auditObjectChanged = new ReplaySubject<AuditObject>(1);

    public ActivePatientSource = this._auditObjectSource.asObservable();
    public ActivePatientChanged = this._auditObjectChanged.asObservable();

    constructor() {
        this._objectIDList = new Array<AuditObject>();
        this.subscribe();
    }

    public get ObjectIDList(): Array<AuditObject> {
        return this._objectIDList;
    }

    private subscribe() {
        let that = this;
        this._auditObjectSource.subscribe(AuditObject => {
            that._objectIDList = new Array<AuditObject>();
            const bufferedObservable = this.ActivePatientSource.pipe(bufferCount(1));
            bufferedObservable.subscribe(z => {
                z.forEach(item => that._objectIDList.push(item));
            }).unsubscribe();
        });
    }
}
