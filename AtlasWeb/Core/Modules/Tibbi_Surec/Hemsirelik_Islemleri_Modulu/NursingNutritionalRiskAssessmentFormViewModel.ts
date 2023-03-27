//$7335E347
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingNutritionalRiskAssessment } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";
import List from "NebulaClient/System/Collections/List";
import { NursingDynamicComponent_SummaryInfo } from "./NursingApplicationMainFormViewModel";
import { NursingApplication } from "NebulaClient/Model/AtlasClientModel";

export class NursingNutritionalRiskAssessmentFormViewModel extends BaseViewModel {
    @Type(() => Number)
    public PatientAge: number;
    public _NursingNutritionalRiskAssessment: NursingNutritionalRiskAssessment = new NursingNutritionalRiskAssessment();
    public NursingAppProgressSummaryInfoList: List<NursingDynamicComponent_SummaryInfo> = new List<NursingDynamicComponent_SummaryInfo>();
    public _NursingApplication: NursingApplication = new NursingApplication();
    public writeAllreportControl: boolean = false;
    
}
