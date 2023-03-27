//$8B328143
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PathologyAdditionalReport } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class PathologyAdditionalReportFormViewModel extends BaseViewModel {
    @Type(() => PathologyAdditionalReport)
    public _PathologyAdditionalReport: PathologyAdditionalReport = new PathologyAdditionalReport();
}
