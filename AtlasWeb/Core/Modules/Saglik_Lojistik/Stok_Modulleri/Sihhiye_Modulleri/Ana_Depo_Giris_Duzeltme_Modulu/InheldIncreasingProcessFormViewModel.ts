//$18954073
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { InheldIncreasingProcess } from "NebulaClient/Model/AtlasClientModel";
import { InheldIncreasingProcessDet } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";

export class InheldIncreasingProcessFormViewModel extends BaseViewModel {
    public _InheldIncreasingProcess: InheldIncreasingProcess = new InheldIncreasingProcess();
    public InheldIncreasingProcessDetsGridList: Array<InheldIncreasingProcessDet> = new Array<InheldIncreasingProcessDet>();
    public Materials: Array<Material> = new Array<Material>();
}
