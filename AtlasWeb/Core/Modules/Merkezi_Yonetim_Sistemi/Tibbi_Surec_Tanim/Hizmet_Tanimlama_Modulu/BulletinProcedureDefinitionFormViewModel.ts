//$E18A2CC3
import { BulletinProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class BulletinProcedureDefinitionFormViewModel extends ProcedureFormViewModel {
    public _BulletinProcedureDefinition: BulletinProcedureDefinition = new BulletinProcedureDefinition();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
}
