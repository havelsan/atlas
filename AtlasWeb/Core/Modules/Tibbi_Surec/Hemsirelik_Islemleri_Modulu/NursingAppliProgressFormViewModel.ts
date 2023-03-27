//$E6CB5D3D
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingAppliProgress } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingAppliProgressFormViewModel extends BaseViewModel{
    @Type(() => NursingAppliProgress)
    public _NursingAppliProgress: NursingAppliProgress = new NursingAppliProgress();
}
