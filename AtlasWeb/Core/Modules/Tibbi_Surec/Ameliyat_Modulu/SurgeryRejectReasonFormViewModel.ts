//$B8BC1FFB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SurgeryRejectReason } from "NebulaClient/Model/AtlasClientModel";

export class SurgeryRejectReasonFormViewModel extends BaseViewModel {
    public _SurgeryRejectReason: SurgeryRejectReason = new SurgeryRejectReason();
}
