//$524BF188
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PatientOwnDrugReturn, Episode, Patient } from "NebulaClient/Model/AtlasClientModel";
import { PatientOwnDrugReturnDetail } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class PatientOwnDrugReturnFormViewModel extends BaseViewModel {
    @Type(() => PatientOwnDrugReturn)
    public _PatientOwnDrugReturn: PatientOwnDrugReturn = new PatientOwnDrugReturn();
    @Type(() => PatientOwnDrugReturnDetail)
    public PatientOwnDrugReturnDetailsGridList: Array<PatientOwnDrugReturnDetail> = new Array<PatientOwnDrugReturnDetail>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
        @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
}
