//$55A2CEEB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientOwnDrugReturn } from "NebulaClient/Model/AtlasClientModel";
import { PatientOwnDrugReturnDetail } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class PatientOwnDrugReturnCompFormViewModel extends BaseViewModel {
    public _PatientOwnDrugReturn: PatientOwnDrugReturn = new PatientOwnDrugReturn();
    public PatientOwnDrugReturnDetailsGridList: Array<PatientOwnDrugReturnDetail> = new Array<PatientOwnDrugReturnDetail>();
    public Materials: Array<Material> = new Array<Material>();
}
