//$0316A658
import { AnesthesiaDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class AnesthesiaDefinitionFormViewModel extends ProcedureFormViewModel {
    public _AnesthesiaDefinition: AnesthesiaDefinition = new AnesthesiaDefinition();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
}
