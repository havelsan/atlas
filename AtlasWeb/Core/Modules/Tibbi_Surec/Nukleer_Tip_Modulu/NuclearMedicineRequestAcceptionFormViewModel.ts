//$3D86ADED
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { NuclearMedicineTest } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { ResNuclearMedicineEquipment } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { EpisodeAction } from "NebulaClient/Model/AtlasClientModel";
import { PackageDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SubActionProcedure } from "NebulaClient/Model/AtlasClientModel";
import { PatientMedulaHastaKabul } from "NebulaClient/Model/AtlasClientModel";
import { SubEpisode } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineRequestAcceptionFormViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public NuclearMedicineTestsGridList: Array<NuclearMedicineTest> = new Array<NuclearMedicineTest>();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public ResNuclearMedicineEquipments: Array<ResNuclearMedicineEquipment> = new Array<ResNuclearMedicineEquipment>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    public EpisodeActions: Array<EpisodeAction> = new Array<EpisodeAction>();
    public PackageDefinitions: Array<PackageDefinition> = new Array<PackageDefinition>();
    public SubActionProcedures: Array<SubActionProcedure> = new Array<SubActionProcedure>();
    public PatientMedulaHastaKabuls: Array<PatientMedulaHastaKabul> = new Array<PatientMedulaHastaKabul>();
    public SubEpisodes: Array<SubEpisode> = new Array<SubEpisode>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
}
