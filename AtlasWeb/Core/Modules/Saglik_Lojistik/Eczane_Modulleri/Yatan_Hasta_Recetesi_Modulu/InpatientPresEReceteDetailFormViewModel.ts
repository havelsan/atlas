//$E0D255E6
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientPrescription } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class InpatientPresEReceteDetailFormViewModel extends BaseViewModel {
        @Type(() => InpatientPrescription)
    public _InpatientPrescription: InpatientPrescription = new InpatientPrescription();
}
