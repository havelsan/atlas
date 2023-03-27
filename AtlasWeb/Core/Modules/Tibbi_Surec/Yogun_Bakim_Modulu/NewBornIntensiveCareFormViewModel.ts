//$37C3DF77
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NewBornIntensiveCare, IntensiveCareSpecialityObj } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";
import { DynamicComponentInfo } from "../../../wwwroot/app/Fw/Models/DynamicComponentInfo";
import { QueryParams } from "../../../wwwroot/app/QueryList/Models/QueryParams";

export class NewBornIntensiveCareFormViewModel extends BaseViewModel {
    @Type(() => NewBornIntensiveCare)
    public _NewBornIntensiveCare: NewBornIntensiveCare = new NewBornIntensiveCare();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();


    public intensiveCareSpecialityObjId: string;
}

export class Age {
    Years: number;
    Months: number;
    Weeks: number;
    Days: number;
}


export class NewBornIntensiveCareComponentInfoViewModel {

    @Type(() => DynamicComponentInfo)
    public NewBornIntensiveCareComponentInfo: DynamicComponentInfo;

    @Type(() => QueryParams)
    public NewBornIntensiveCareQueryParameters: QueryParams;
}