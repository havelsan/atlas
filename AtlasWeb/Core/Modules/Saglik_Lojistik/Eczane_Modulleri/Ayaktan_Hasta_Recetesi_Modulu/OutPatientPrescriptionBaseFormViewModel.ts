//$B9200448
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OutPatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class OutPatientPrescriptionBaseFormViewModel extends BaseViewModel {
      @Type(() => OutPatientPrescription)
    public _OutPatientPrescription: OutPatientPrescription = new OutPatientPrescription();
}
