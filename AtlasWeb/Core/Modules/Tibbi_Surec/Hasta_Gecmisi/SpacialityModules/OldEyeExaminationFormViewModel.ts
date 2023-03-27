//$D8529456
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EyeExamination } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';

export class OldEyeExaminationFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.OldEyeExaminationFormViewModel, Core';

    @Type(() => EyeExamination)
    public _EyeExamination: EyeExamination = new EyeExamination();

    public NoGlassVisSharpLeftVal: string;
    public NoGlassVisSharpRightVal: string;
    public GlassVisSharpLeftVal: string;
    public GlassVisSharpRightVal: string;
}
