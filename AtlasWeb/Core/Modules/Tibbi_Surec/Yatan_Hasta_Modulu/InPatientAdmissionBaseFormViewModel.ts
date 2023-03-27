//$E173CD6C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class InPatientAdmissionBaseFormViewModel extends BaseViewModel {
    @Type(() => InpatientAdmission)
    public _InpatientAdmission: InpatientAdmission = new InpatientAdmission();
}
