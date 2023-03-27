//$32B0F384
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DentalTreatmentDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DentalTreatmentDepartmentGrid } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { DentalRequestTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class DentalTreatmentDefinitionFormViewModel extends ProcedureFormViewModel {
    public _DentalTreatmentDefinition: DentalTreatmentDefinition = new DentalTreatmentDefinition();
    public DepartmentsGridList: Array<DentalTreatmentDepartmentGrid> = new Array<DentalTreatmentDepartmentGrid>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public DentalRequestTypeDefinitions: Array<DentalRequestTypeDefinition> = new Array<DentalRequestTypeDefinition>();
}
