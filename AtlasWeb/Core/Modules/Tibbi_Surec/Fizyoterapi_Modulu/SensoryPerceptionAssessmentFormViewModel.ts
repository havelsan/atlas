//$1A41A56B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SensoryPerceptionAssessmentForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class SensoryPerceptionAssessmentFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.SensoryPerceptionAssessmentFormViewModel, Core';
    @Type(() => SensoryPerceptionAssessmentForm)
    public _SensoryPerceptionAssessmentForm: SensoryPerceptionAssessmentForm = new SensoryPerceptionAssessmentForm();
}
