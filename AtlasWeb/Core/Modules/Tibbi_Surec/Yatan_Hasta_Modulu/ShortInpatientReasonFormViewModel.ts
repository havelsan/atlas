//$B8EEFEE0
import { BaseViewModel } from "../../../wwwroot/app/NebulaClient/Model/BaseViewModel";
import { InPatientTreatmentClinicApplication } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class ShortInpatientReasonFormViewModel extends BaseViewModel {
    @Type(() => InPatientTreatmentClinicApplication)
    public _InPatientTreatmentClinicApplication: InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication();
}
