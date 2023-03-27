//$2E87B09A
import { Injectable, EventEmitter } from '@angular/core';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'Fw/Services/MessageService';
import { ReplaySubject } from 'rxjs';
import { SKRSTekrarTetkikIstemGerekcesi } from '../../../wwwroot/app/NebulaClient/Model/AtlasClientModel';
import { SurgeryAppointmentListSearchCriteria, SurgeryAppointmentListItem } from './SurgeryAppointmentComponentFormViewModel';


@Injectable()
export class SurgeryAppointmentSharedService {
    public AppointmentListSearchCriteriaParam: SurgeryAppointmentListSearchCriteria = new SurgeryAppointmentListSearchCriteria();
    public SearchedAppointmentsResponseParam: Array<SurgeryAppointmentListItem> = new Array<SurgeryAppointmentListItem>();
    
    

    // ReplaySubject Tipindekilere , herhangi bir  Service subscribe olmadan önce deger set edildi ise subscripe olduğu anda eski değerlerini de alır . Her zaman son set edileni alması için 1 parametresi verildi
    //Subject Tipindekilere , herhangi bir  Service subscribe olmadan önce deger set edildi , Sunscribe olan servis o eski değerleri alamaz
    private _appointmentListSearchCriteria = new Subject<SurgeryAppointmentListSearchCriteria>();
    private _searchedAppointmentsResponse = new Subject<Array<SurgeryAppointmentListItem>>();
    


    public AppointmentListSearchCriteria: Observable<SurgeryAppointmentListSearchCriteria> = this._appointmentListSearchCriteria.asObservable();
    public SearchedAppointmentsResponse: Observable<Array<SurgeryAppointmentListItem>> = this._searchedAppointmentsResponse.asObservable();
    

    constructor(private httpService: NeHttpService, protected messageService: MessageService ) {

    }


  
    sendSearchCriteria(data){
        if(data != null){
            this.AppointmentListSearchCriteriaParam = data;
            this._appointmentListSearchCriteria.next(data);
        }
    }

    sendResponseList(data){
        if(data != null){
            this.SearchedAppointmentsResponseParam = data;
            this._searchedAppointmentsResponse.next(data);
        }
    }
}


export class PlannedRequestCarrierClass{
    public procedureList: Array<Guid>;
    public requestDate: Date;
}