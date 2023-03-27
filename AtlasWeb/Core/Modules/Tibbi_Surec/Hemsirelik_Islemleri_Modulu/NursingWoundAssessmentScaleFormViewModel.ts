//$A6E54141
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingWoundAssessmentScale } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";

export class NursingWoundAssessmentScaleFormViewModel extends BaseViewModel {
    @Type(() => Number)
    public PatientAge: number;
    @Type(() => String)
    public PatientSex: string;

    public _NursingWoundAssessmentScale: NursingWoundAssessmentScale = new NursingWoundAssessmentScale();
}
