//$AD04A09E
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class MergePatientFormViewModel extends BaseViewModel {
   // public _MergePatient: MergePatient = new MergePatient();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();

}
