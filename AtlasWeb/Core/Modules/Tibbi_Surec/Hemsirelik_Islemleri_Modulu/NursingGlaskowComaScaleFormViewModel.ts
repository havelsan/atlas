//$C421A093
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { NursingGlaskowComaScale } from 'NebulaClient/Model/AtlasClientModel';
import { GlaskowComaScaleDefinition } from 'NebulaClient/Model/AtlasClientModel';

export class NursingGlaskowComaScaleFormViewModel extends BaseViewModel{
    @Type(() => NursingGlaskowComaScale)
    public _NursingGlaskowComaScale: NursingGlaskowComaScale = new NursingGlaskowComaScale();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowComaScaleDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowEyeDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowOralAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
    @Type(() => GlaskowComaScaleDefinition)
    public GlaskowMotorAnswerDefinitions: Array<GlaskowComaScaleDefinition> = new Array<GlaskowComaScaleDefinition>();
}
