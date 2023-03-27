//$248A454E
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DentalProsthesisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DentalProsthesisDepartmentGrid } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class DentalProsthesisDefinitionFormViewModel extends ProcedureFormViewModel {
    public _DentalProsthesisDefinition: DentalProsthesisDefinition = new DentalProsthesisDefinition();
    public DepartmentsGridList: Array<DentalProsthesisDepartmentGrid> = new Array<DentalProsthesisDepartmentGrid>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
}
