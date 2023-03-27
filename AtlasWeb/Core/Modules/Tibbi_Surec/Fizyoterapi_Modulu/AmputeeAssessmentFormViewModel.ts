//$0D050CFF
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AmputeeAssessmentForm } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class AmputeeAssessmentFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.AmputeeAssessmentFormViewModel, Core';
    @Type(() => AmputeeAssessmentForm)
    public _AmputeeAssessmentForm: AmputeeAssessmentForm = new AmputeeAssessmentForm();
}
