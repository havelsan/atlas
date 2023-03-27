//$238A1468
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratorySubProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class LaboratoryProcedureDetailFormViewModel extends BaseViewModel {
    public _LaboratoryProcedure: LaboratoryProcedure = new LaboratoryProcedure();
    public GridSubProceduresGridList: Array<LaboratorySubProcedure> = new Array<LaboratorySubProcedure>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
}
