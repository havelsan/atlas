//$71777221
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { RadiologyTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyTabNamesGrid } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyGridRestrictedTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyGridDepartmentDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyGridEquipmentDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyGridMaterialDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyGridTestDescriptionDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyTestTMDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyTabDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyTestTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResRadiologyDepartment } from "NebulaClient/Model/AtlasClientModel";
import { ResRadiologyEquipment } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { RadiologyTestDescriptionDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SKRSLOINC } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class RadiologyTestDefinitionFormViewModel extends ProcedureFormViewModel {
    protected __type__: string = 'Core.Models.RadiologyTestDefinitionFormViewModel, Core';

    public _RadiologyTestDefinition: RadiologyTestDefinition = new RadiologyTestDefinition();
    public TabNameGridGridList: Array<RadiologyTabNamesGrid> = new Array<RadiologyTabNamesGrid>();
    public ttgrid2GridList: Array<RadiologyGridRestrictedTestDefinition> = new Array<RadiologyGridRestrictedTestDefinition>();
    public ttgrid3GridList: Array<RadiologyGridDepartmentDefinition> = new Array<RadiologyGridDepartmentDefinition>();
    public ttgrid4GridList: Array<RadiologyGridEquipmentDefinition> = new Array<RadiologyGridEquipmentDefinition>();
    public ttgrid1GridList: Array<RadiologyGridMaterialDefinition> = new Array<RadiologyGridMaterialDefinition>();
    public ttgrid5GridList: Array<RadiologyGridTestDescriptionDefinition> = new Array<RadiologyGridTestDescriptionDefinition>();
    public RadiologyTestTMDefinitions: Array<RadiologyTestTMDefinition> = new Array<RadiologyTestTMDefinition>();
    public RadiologyTabDefinitions: Array<RadiologyTabDefinition> = new Array<RadiologyTabDefinition>();
    public RadiologyTestTypeDefinitions: Array<RadiologyTestTypeDefinition> = new Array<RadiologyTestTypeDefinition>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public RadiologyTestDefinitions: Array<RadiologyTestDefinition> = new Array<RadiologyTestDefinition>();
    public ResRadiologyDepartments: Array<ResRadiologyDepartment> = new Array<ResRadiologyDepartment>();
    public ResRadiologyEquipments: Array<ResRadiologyEquipment> = new Array<ResRadiologyEquipment>();
    public Materials: Array<Material> = new Array<Material>();
    public RadiologyTestDescriptionDefinitions: Array<RadiologyTestDescriptionDefinition> = new Array<RadiologyTestDescriptionDefinition>();
    public SKRSLOINCs: Array<SKRSLOINC> = new Array<SKRSLOINC>();
}
