//$3B5590D0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OrtesisProsthesisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { OrtesisProsthesisMaterialGrid } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class OrtesisProsthesisDefinitionFormViewModel extends ProcedureFormViewModel {
    public _OrtesisProsthesisDefinition: OrtesisProsthesisDefinition = new OrtesisProsthesisDefinition();
    public MaterialsGridGridList: Array<OrtesisProsthesisMaterialGrid> = new Array<OrtesisProsthesisMaterialGrid>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public Materials: Array<Material> = new Array<Material>();
}
