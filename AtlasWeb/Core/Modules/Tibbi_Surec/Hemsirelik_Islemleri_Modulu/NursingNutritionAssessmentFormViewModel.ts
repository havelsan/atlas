//$2CF6E489
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingNutritionAssessment } from 'NebulaClient/Model/AtlasClientModel';
import { NursingDietDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ToothDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { UrgeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { SwallowDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PanoramaDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingNutritionAssessmentFormViewModel extends BaseViewModel{
    @Type(() => NursingNutritionAssessment)
    public _NursingNutritionAssessment: NursingNutritionAssessment = new NursingNutritionAssessment();
    @Type(() => NursingDietDefinition)
    public NursingDietDefinitions: Array<NursingDietDefinition> = new Array<NursingDietDefinition>();
    @Type(() => ToothDefinition)
    public ToothDefinitions: Array<ToothDefinition> = new Array<ToothDefinition>();
    @Type(() => UrgeDefinition)
    public UrgeDefinitions: Array<UrgeDefinition> = new Array<UrgeDefinition>();
    @Type(() => SwallowDefinition)
    public SwallowDefinitions: Array<SwallowDefinition> = new Array<SwallowDefinition>();
    @Type(() => PanoramaDefinition)
    public PanoramaDefinitions: Array<PanoramaDefinition> = new Array<PanoramaDefinition>();
}
