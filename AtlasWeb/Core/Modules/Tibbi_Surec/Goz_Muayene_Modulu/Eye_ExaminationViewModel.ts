//$79AAA3C5
import { EyeExamination } from 'NebulaClient/Model/AtlasClientModel';
import { VisualSharpnessDefinitionNew } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';


export class Eye_ExaminationViewModel  extends BaseViewModel {
    //@Exclude()
    protected __type__: string = 'Core.Models.Eye_ExaminationViewModel, Core';
    @Type(() => EyeExamination)
    public _EyeExamination: EyeExamination = new EyeExamination();
    @Type(() => VisualSharpnessDefinitionNew)
    public VisualSharpnessDefinitionNews: Array<VisualSharpnessDefinitionNew> = new Array<VisualSharpnessDefinitionNew>();
    public PhysicianApplicationEpisodeID: Guid;
    public hasDiagnosis: boolean = false;
}

