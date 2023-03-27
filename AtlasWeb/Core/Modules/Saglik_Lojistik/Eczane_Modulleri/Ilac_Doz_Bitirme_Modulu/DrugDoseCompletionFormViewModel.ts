//$9D7F6EF0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DrugDoseCompletion } from "NebulaClient/Model/AtlasClientModel";
import { DrugDoseCompletionDetail } from "NebulaClient/Model/AtlasClientModel";
import { Episode } from "NebulaClient/Model/AtlasClientModel";
import { Patient } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class DrugDoseCompletionFormViewModel extends BaseViewModel {
    public _DrugDoseCompletion: DrugDoseCompletion = new DrugDoseCompletion();
    public DrugDoseCompletionDetailsGridList: Array<DrugDoseCompletionDetail> = new Array<DrugDoseCompletionDetail>();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public Materials: Array<Material> = new Array<Material>();
}
