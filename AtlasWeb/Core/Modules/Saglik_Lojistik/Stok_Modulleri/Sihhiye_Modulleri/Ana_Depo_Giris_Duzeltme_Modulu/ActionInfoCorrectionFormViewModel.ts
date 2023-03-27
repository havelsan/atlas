//$A66271D6
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { ActionInfoCorrection } from "NebulaClient/Model/AtlasClientModel";
import { ActionInfoCorrectionDet } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class ActionInfoCorrectionFormViewModel extends BaseViewModel {
    public _ActionInfoCorrection: ActionInfoCorrection = new ActionInfoCorrection();
    public ActionInfoCorrectionDetsGridList: Array<ActionInfoCorrectionDet> = new Array<ActionInfoCorrectionDet>();
    public Materials: Array<Material> = new Array<Material>();
}
