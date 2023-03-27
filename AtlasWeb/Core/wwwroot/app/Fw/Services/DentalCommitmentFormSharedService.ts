import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Http } from "@angular/http";
import { DentalCommitment } from 'app/NebulaClient/Model/AtlasClientModel';

@Injectable()
export class DentalCommitmentFormSharedService {

   private dentalCommitmentObject = new Subject<DentalCommitment>();
   public dentalCommitmentObjectObservable = this.dentalCommitmentObject.asObservable();

    constructor(protected http: Http) {

    }

    sendDentalCommitmentObject(dentalCommitment: DentalCommitment) {
        this.dentalCommitmentObject.next(dentalCommitment);
    }
}