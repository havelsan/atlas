//$D80796D7

import { RadiologyAdditionalReport } from "NebulaClient/Model/AtlasClientModel";
import { BaseViewModel } from "app/NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
export class RadiologyTestAdditionalReportFormViewModel extends BaseViewModel {
    @Type(() => RadiologyAdditionalReport)
    public _RadiologyAdditionalReport: RadiologyAdditionalReport = new RadiologyAdditionalReport();
}
