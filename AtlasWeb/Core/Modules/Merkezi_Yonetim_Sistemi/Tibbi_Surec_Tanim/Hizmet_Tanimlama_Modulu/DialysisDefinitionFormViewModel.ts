//$8F762DBC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DialysisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DialysisTreatmentUnitGrid } from "NebulaClient/Model/AtlasClientModel";
import { DialysisTreatmentEquipmentGrid } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisUnit } from "NebulaClient/Model/AtlasClientModel";
import { ResEquipment } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class DialysisDefinitionFormViewModel extends ProcedureFormViewModel {
    public _DialysisDefinition: DialysisDefinition = new DialysisDefinition();
    public TreatmentUnitsGridList: Array<DialysisTreatmentUnitGrid> = new Array<DialysisTreatmentUnitGrid>();
    public DialysisTreatmentEquipmentsGridList: Array<DialysisTreatmentEquipmentGrid> = new Array<DialysisTreatmentEquipmentGrid>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();
    public ResEquipments: Array<ResEquipment> = new Array<ResEquipment>();
}
