//$EE21AC3B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NeurophysiologicalAssessmentForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class NeurophysiologicalAssessmentFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.NeurophysiologicalAssessmentFormViewModel, Core';
    @Type(() => NeurophysiologicalAssessmentForm)

    public _NeurophysiologicalAssessmentForm: NeurophysiologicalAssessmentForm = new NeurophysiologicalAssessmentForm();
}
