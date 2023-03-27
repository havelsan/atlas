//$139D31CE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicineTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NucMedTabNamesGrid } from "NebulaClient/Model/AtlasClientModel";
import { NuclearMedicineGridEquipmentDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NuclearMedicineGridPharmDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NuclearMedicineGridMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { NucMedTestGroupDef } from "NebulaClient/Model/AtlasClientModel";
import { ResNuclearMedicineEquipment } from "NebulaClient/Model/AtlasClientModel";
import { RadioPharmaceuticalDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";
import { SKRSLOINC } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineTestDefinitionFormViewModel extends ProcedureFormViewModel {
    public _NuclearMedicineTestDefinition: NuclearMedicineTestDefinition = new NuclearMedicineTestDefinition();
    public ttgrid1GridList: Array<NucMedTabNamesGrid> = new Array<NucMedTabNamesGrid>();
    public ttgrid4GridList: Array<NuclearMedicineGridEquipmentDefinition> = new Array<NuclearMedicineGridEquipmentDefinition>();
    public ttgrid3GridList: Array<NuclearMedicineGridPharmDefinition> = new Array<NuclearMedicineGridPharmDefinition>();
    public ttgrid2GridList: Array<NuclearMedicineGridMaterialDefinition> = new Array<NuclearMedicineGridMaterialDefinition>();
    public NucMedTestGroupDefs: Array<NucMedTestGroupDef> = new Array<NucMedTestGroupDef>();
    public ResNuclearMedicineEquipments: Array<ResNuclearMedicineEquipment> = new Array<ResNuclearMedicineEquipment>();
    public RadioPharmaceuticalDefinitions: Array<RadioPharmaceuticalDefinition> = new Array<RadioPharmaceuticalDefinition>();
    public Materials: Array<Material> = new Array<Material>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public SKRSLOINCs: Array<SKRSLOINC> = new Array<SKRSLOINC>();
}
