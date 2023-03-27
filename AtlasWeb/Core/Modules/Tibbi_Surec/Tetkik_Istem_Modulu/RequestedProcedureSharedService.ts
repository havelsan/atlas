import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Http } from "@angular/http";
import { DailyProvisionSubscribeModel } from './ProcedureRequestViewModel';

@Injectable()
export class RequestedProcedureSharedService {

   private operationControlForProcedure = new Subject<boolean>();
   public operationControlForProcedureObservable = this.operationControlForProcedure.asObservable();

   private dailyInputModelForProcedure = new Subject <DailyProvisionSubscribeModel>();
   public dailyInputModelForProcedureObservable = this.dailyInputModelForProcedure.asObservable();

   private triggerValue =  new Subject<boolean>();
   public triggerValueObservable = this.triggerValue.asObservable();

   private operationControlBoolObject = new Subject <boolean>();
   public operationControlBoolObjectObservable = this.operationControlBoolObject.asObservable();

   private dailyProvisionInputModel = new Subject <DailyProvisionSubscribeModel>();
   public dailyProvisionInputModelObservable = this.dailyProvisionInputModel.asObservable();

    constructor(protected http: Http) {

    }

    sendDailyOperationControlBooleanObject(operationControl: boolean) {
        this.operationControlBoolObject.next(operationControl);
    }

    sendDailyOperationInputModelForProcedures(inputModel: DailyProvisionSubscribeModel)
    {
        this.dailyInputModelForProcedure.next(inputModel);
    }

    sendTriggerValues(triggerValue: boolean)
    {
        this.triggerValue.next(triggerValue);
    }

    sendDailyOperationControlForProcedures(operationControl: boolean)
    {
        this.operationControlForProcedure.next(operationControl);
    }

    sendDailyOperationInputModel(inputModel: DailyProvisionSubscribeModel)
    {
        this.dailyProvisionInputModel.next(inputModel);
    }


}