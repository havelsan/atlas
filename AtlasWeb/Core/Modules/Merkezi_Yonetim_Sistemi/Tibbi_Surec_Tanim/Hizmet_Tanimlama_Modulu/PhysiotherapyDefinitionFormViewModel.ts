//$69EE8790
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyTreatmentUnitGrid } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyTreatmentRoomGrid } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisUnit } from "NebulaClient/Model/AtlasClientModel";
import { ResTreatmentDiagnosisRoom } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureFormViewModel } from "./ProcedureFormViewModel";

export class PhysiotherapyDefinitionFormViewModel extends ProcedureFormViewModel {
    public _PhysiotherapyDefinition: PhysiotherapyDefinition = new PhysiotherapyDefinition();
    public TreatmentUnitsGridList: Array<PhysiotherapyTreatmentUnitGrid> = new Array<PhysiotherapyTreatmentUnitGrid>();
    public TreatmentRoomsGridList: Array<PhysiotherapyTreatmentRoomGrid> = new Array<PhysiotherapyTreatmentRoomGrid>();
    public ProcedureTreeDefinitions: Array<ProcedureTreeDefinition> = new Array<ProcedureTreeDefinition>();
    public ResTreatmentDiagnosisUnits: Array<ResTreatmentDiagnosisUnit> = new Array<ResTreatmentDiagnosisUnit>();
    public ResTreatmentDiagnosisRooms: Array<ResTreatmentDiagnosisRoom> = new Array<ResTreatmentDiagnosisRoom>();
}
