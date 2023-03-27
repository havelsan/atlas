//$8C6D60DA
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientOnVacation } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { DynamicComponentInfo } from "app/Fw/Models/DynamicComponentInfo";
import { QueryParams } from "app/QueryList/Models/QueryParams";
import { Type } from 'NebulaClient/ClassTransformer';

export class PatientOnVacationFormViewModel extends BaseViewModel {
    public _PatientOnVacation: PatientOnVacation = new PatientOnVacation();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}

export class PatientVacationComponentInfoViewModel  {
    @Type(() => DynamicComponentInfo)
    public vacationComponentInfo: DynamicComponentInfo;
    @Type(() => QueryParams)
    public vacationQueryParameters: QueryParams;    
}
export class OrderStatus_Input
{
    public returnMessage:string;
}
