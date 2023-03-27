//$1E5828E9
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { GaitAnalysisForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class GaitAnalysisFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.GaitAnalysisFormViewModel, Core';
    @Type(() => GaitAnalysisForm)
    public _GaitAnalysisForm: GaitAnalysisForm = new GaitAnalysisForm();
}
