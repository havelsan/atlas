//$23447197
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { GlaskowScore } from "NebulaClient/Model/AtlasClientModel";
import { GlaskowComaScaleDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";

export class GlaskowScoreFormViewModel extends BaseViewModel {
    @Type(() => GlaskowScore)
    public _GlaskowScore: GlaskowScore = new GlaskowScore();

    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowComaScaleDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();

    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowEyeDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowOralAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowMotorAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
}
