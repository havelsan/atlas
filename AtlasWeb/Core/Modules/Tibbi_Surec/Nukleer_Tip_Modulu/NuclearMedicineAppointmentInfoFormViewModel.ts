//$BBE48776
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { NucMedRadPharmMatGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineAppointmentInfoFormViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridRadPharmMaterialsGridList: Array<NucMedRadPharmMatGrid> = new Array<NucMedRadPharmMatGrid>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public Materials: Array<Material> = new Array<Material>();
    public AppointmentDescription: string;
}
