//$86088497
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingApplication } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";
import { NursingDynamicComponent_SummaryInfo } from "../Hemsirelik_Islemleri_Modulu/NursingApplicationMainFormViewModel";

export class NursingAplicationDoctorFormViewModel extends BaseViewModel {
    public _NursingApplication: NursingApplication = new NursingApplication();

    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingAppProgressSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingGlaskowComaScaleSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPupilSymptomsSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPainScaleSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingSpiritualSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingNutritionAssessmentSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingFunctionalLifeActivitySummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingPatientAndFamilyInstructionSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingCareSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingSystemInterrogationSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingDischargingInstructionPlanSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingFallingDownRiskSummaryInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingWoundAssessmentScaleInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingLegMeasurementInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingNutritionalRiskAssessmentInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
    @Type(() => NursingDynamicComponent_SummaryInfo)
    public NursingWoundedAssessmentInfoList: Array<NursingDynamicComponent_SummaryInfo> = new Array<NursingDynamicComponent_SummaryInfo>();
}


