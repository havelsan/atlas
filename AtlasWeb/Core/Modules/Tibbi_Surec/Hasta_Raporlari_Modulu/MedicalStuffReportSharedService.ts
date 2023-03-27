import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Http } from "@angular/http";

@Injectable()
export class MedicalStuffReportSharedService {

   private medicalStuffReportUpdate = new Subject<boolean>();
   public medicalStuffReportUpdateObservable = this.medicalStuffReportUpdate.asObservable();

  
    constructor(protected http: Http) {

    }    

    updateReportGridObservable(updateVal: boolean)
    {
        this.medicalStuffReportUpdate.next(updateVal);
    }    

}