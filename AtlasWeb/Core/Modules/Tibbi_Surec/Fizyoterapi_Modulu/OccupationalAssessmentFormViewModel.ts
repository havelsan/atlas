//$65742886
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OccupationalAssessmentForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class OccupationalAssessmentFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OccupationalAssessmentFormViewModel, Core';
    @Type(() => OccupationalAssessmentForm)

    public _OccupationalAssessmentForm: OccupationalAssessmentForm = new OccupationalAssessmentForm();
}
