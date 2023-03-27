//$FA130A98
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Prescription } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class PrescriptionBaseFormViewModel extends BaseViewModel  {
    @Type(() => Prescription)
    public _Prescription: Prescription = new Prescription();
}
