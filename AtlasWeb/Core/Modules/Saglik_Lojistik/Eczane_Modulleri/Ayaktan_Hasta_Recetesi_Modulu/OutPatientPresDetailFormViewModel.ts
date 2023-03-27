//$521E8502
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class OutPatientPresDetailFormViewModel extends BaseViewModel {
     @Type(() => OutPatientPrescription)
    public _OutPatientPrescription: OutPatientPrescription = new OutPatientPrescription();
}
