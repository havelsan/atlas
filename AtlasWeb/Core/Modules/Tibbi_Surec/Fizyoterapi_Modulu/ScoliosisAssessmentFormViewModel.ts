//$05DF2D9F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ScoliosisAssessmentForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ScoliosisAssessmentFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ScoliosisAssessmentFormViewModel, Core';
    @Type(() => ScoliosisAssessmentForm)
    public _ScoliosisAssessmentForm: ScoliosisAssessmentForm = new ScoliosisAssessmentForm();
}
