//$23327FB0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NuclearMedicine } from "NebulaClient/Model/AtlasClientModel";
import { NucMedTreatmentMat } from "NebulaClient/Model/AtlasClientModel";
import { NucMedRadPharmMatGrid } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { RadioPharmaceuticalUnitDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { ImportantMedicalInformation } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";

export class NuclearMedicineRadioPharmacyFormViewModel extends BaseViewModel {
    public _NuclearMedicine: NuclearMedicine = new NuclearMedicine();
    public GridNuclearMedicineMaterialGridList: Array<NucMedTreatmentMat> = new Array<NucMedTreatmentMat>();
    public GridRadPharmMaterialsGridList: Array<NucMedRadPharmMatGrid> = new Array<NucMedRadPharmMatGrid>();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public Materials: Array<Material> = new Array<Material>();
    public RadioPharmaceuticalUnitDefinitions: Array<RadioPharmaceuticalUnitDefinition> = new Array<RadioPharmaceuticalUnitDefinition>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public ImportantMedicalInformations: Array<ImportantMedicalInformation> = new Array<ImportantMedicalInformation>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
