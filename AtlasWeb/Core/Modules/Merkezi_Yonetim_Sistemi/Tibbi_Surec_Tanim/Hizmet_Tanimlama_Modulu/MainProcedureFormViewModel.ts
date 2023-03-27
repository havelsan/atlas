//$7F229294
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SubProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RequiredDiagnoseProcedure } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";

export class MainProcedureFormViewModel extends BaseViewModel {
    public _ProcedureDefinition: ProcedureDefinition = new ProcedureDefinition();
    public ProcedureDefinitionList: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public GridSubProceduresGridList: Array<SubProcedureDefinition> = new Array<SubProcedureDefinition>();
    @Type(() => RequiredDiagnoseProcedure)
    public GridRequiredDiagnosisGridList: Array<RequiredDiagnoseProcedure> = new Array<RequiredDiagnoseProcedure>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
}
