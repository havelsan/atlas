//$723BC53A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BloodBankTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { BloodBankGridProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { BloodBankGridMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class BloodBankTestDefinitionFormViewModel extends ProcedureFormViewModel {
    public _BloodBankTestDefinition: BloodBankTestDefinition = new BloodBankTestDefinition();
    public GridProceduresGridList: Array<BloodBankGridProcedureDefinition> = new Array<BloodBankGridProcedureDefinition>();
    public GridMaterialsGridList: Array<BloodBankGridMaterialDefinition> = new Array<BloodBankGridMaterialDefinition>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public Materials: Array<Material> = new Array<Material>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
}
