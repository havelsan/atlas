//$5176D4E5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisOrder } from "NebulaClient/Model/AtlasClientModel";
import { HemodialysisRequest } from "NebulaClient/Model/AtlasClientModel";
import { ResEquipment } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisUnit } from "NebulaClient/Model/AtlasClientModel";
import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSDiyalizeGirmeSikligi } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class HemodialysisOrderFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisOrder)
    public _HemodialysisOrder: HemodialysisOrder = new HemodialysisOrder();
    @Type(() => HemodialysisRequest)
    public HemodialysisRequests: Array<HemodialysisRequest> = new Array<HemodialysisRequest>();
    @Type(() => ResEquipment)
    public ResEquipments: Array<ResEquipment> = new Array<ResEquipment>();
    @Type(() => ResTreatmentDiagnosisUnit)
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();
    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinitions: Array<PackageProcedureDefinition> = new Array<PackageProcedureDefinition>();
    @Type(() => SKRSDiyalizeGirmeSikligi)
    public SKRSDiyalizeGirmeSikligis: Array<SKRSDiyalizeGirmeSikligi> = new Array<SKRSDiyalizeGirmeSikligi>();
}
