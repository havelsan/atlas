//$5E8BB1A2
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EstheticAlternativeProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class EstheticAlternativeProcedureDefinitionFormViewModel extends ProcedureFormViewModel {
    public _EstheticAlternativeProcedureDefinition: EstheticAlternativeProcedureDefinition = new EstheticAlternativeProcedureDefinition();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
}
