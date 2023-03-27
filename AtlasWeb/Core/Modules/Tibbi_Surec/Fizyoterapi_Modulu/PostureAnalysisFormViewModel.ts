//$0D062540
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PostureAnalysisForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class PostureAnalysisFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PostureAnalysisFormViewModel, Core';
    @Type(() => PostureAnalysisForm)

    public _PostureAnalysisForm: PostureAnalysisForm = new PostureAnalysisForm();
}
