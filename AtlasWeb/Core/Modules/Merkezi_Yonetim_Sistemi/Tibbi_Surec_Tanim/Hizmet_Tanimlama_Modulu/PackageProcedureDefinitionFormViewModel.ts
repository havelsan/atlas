//$BDC77873
import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class PackageProcedureDefinitionFormViewModel extends ProcedureFormViewModel {
    public _PackageProcedureDefinition: PackageProcedureDefinition = new PackageProcedureDefinition();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
}
