//$2E87B09A
import { Injectable } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import { ReplaySubject } from 'rxjs';

@Injectable()
export class DiagnosisGridSharedService {
    public AddedDiagnosisListVal: Array<Guid> = new Array<Guid>();
    
    private _addedDiagnosisList = new Subject<Array<Guid>>();
    
    public AddedDiagnosisList: Observable<Array<Guid>> = this._addedDiagnosisList.asObservable();
    

    constructor(private httpService: NeHttpService, protected messageService: MessageService ) {

    }

    AddDiagnosisList(data){
        if(data != null){
            this.AddedDiagnosisListVal = data;
            this._addedDiagnosisList.next(data);            
        }
    }


}
