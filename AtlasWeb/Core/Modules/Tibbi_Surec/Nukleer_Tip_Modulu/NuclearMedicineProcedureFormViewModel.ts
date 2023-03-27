//$02158574
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { NucMedTreatmentMat } from "NebulaClient/Model/AtlasClientModel";
import { NucMedRadPharmMatGrid } from "NebulaClient/Model/AtlasClientModel";
import { DirectPurchaseGrid } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { RadioPharmaceuticalUnitDefinition } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineProcedureFormViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridNuclearMedicineMaterialGridList: Array<NucMedTreatmentMat> = new Array<NucMedTreatmentMat>();
    public ttgrid2GridList: Array<NucMedRadPharmMatGrid> = new Array<NucMedRadPharmMatGrid>();
    public DirectPurchaseGridsGridList: Array<DirectPurchaseGrid> = new Array<DirectPurchaseGrid>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public Materials: Array<Material> = new Array<Material>();
    public RadioPharmaceuticalUnitDefinitions: Array<RadioPharmaceuticalUnitDefinition> = new Array<RadioPharmaceuticalUnitDefinition>();
}
