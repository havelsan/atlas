//$4F82880F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class InpatientPrescriptionBaseFormViewModel extends BaseViewModel {
     @Type(() => InpatientPrescription)
    public _InpatientPrescription: InpatientPrescription = new InpatientPrescription();
}
