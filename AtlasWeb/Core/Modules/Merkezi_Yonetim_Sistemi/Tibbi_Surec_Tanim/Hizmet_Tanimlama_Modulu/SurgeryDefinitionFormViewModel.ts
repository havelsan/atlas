//$661E5E81
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SurgeryDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DefinitionConcept } from "NebulaClient/Model/AtlasClientModel";
import { SurgeryCodelessMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Resource } from "NebulaClient/Model/AtlasClientModel";
import { DPA22FCodelessMaterialDef } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";
import { SurgeryBranchDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";

export class SurgeryDefinitionFormViewModel extends ProcedureFormViewModel {
    public _SurgeryDefinition: SurgeryDefinition = new SurgeryDefinition();
    public DefinitionConceptsGridList: Array<DefinitionConcept> = new Array<DefinitionConcept>();
    public CodelessMaterialsGridGridList: Array<SurgeryCodelessMaterial> = new Array<SurgeryCodelessMaterial>();
    public Resources: Array<Resource> = new Array<Resource>();
    public DPA22FCodelessMaterialDefs: Array<DPA22FCodelessMaterialDef> = new Array<DPA22FCodelessMaterialDef>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public BranchesGridList: Array<SurgeryBranchDefinition> = new Array<SurgeryBranchDefinition>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();

    public SurgeryDuration:number;
    public PreInformation: string;
}
