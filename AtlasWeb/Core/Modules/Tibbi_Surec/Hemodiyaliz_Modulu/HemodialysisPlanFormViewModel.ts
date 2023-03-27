//$AE147DB2
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisOrder } from "NebulaClient/Model/AtlasClientModel";
import { HemodialysisRequest } from "NebulaClient/Model/AtlasClientModel";
import { ResEquipment } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisUnit } from "NebulaClient/Model/AtlasClientModel";
import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizeGirmeSikligi, HemodialysisReports } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class HemodialysisPlanFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisOrder)
    public _HemodialysisOrder: HemodialysisOrder = new HemodialysisOrder();
    @Type(() => ResEquipment)
    public ResEquipments: Array<ResEquipment> = new Array<ResEquipment>();
    @Type(() => HemodialysisRequest)
    public HemodialysisRequests: Array<HemodialysisRequest> = new Array<HemodialysisRequest>();
    @Type(() => ResTreatmentDiagnosisUnit)
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();
    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinitions: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();
    @Type(() => SKRSDiyalizeGirmeSikligi)
    public SKRSDiyalizeGirmeSikligis: Array<SKRSDiyalizeGirmeSikligi> = new Array<SKRSDiyalizeGirmeSikligi>();

    public IsSGKPatient: boolean;
    @Type(() => HemodialysisReports)
    public ReportList: Array<HemodialysisReports> = new Array<HemodialysisReports>();
}
