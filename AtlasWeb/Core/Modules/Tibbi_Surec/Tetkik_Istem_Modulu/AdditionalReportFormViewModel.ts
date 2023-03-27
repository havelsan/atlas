//$CC532205
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AdditionalReport } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class AdditionalReportFormViewModel extends BaseViewModel {
     protected __type__: string = 'Core.Models.AdditionalReportFormViewModel, Core';
    @Type(() => AdditionalReport)
    public _AdditionalReport: AdditionalReport = new AdditionalReport();
}



