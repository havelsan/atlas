//$410A9793
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingSpiritualEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class NursingSpiritualEvaluationFormViewModel extends BaseViewModel{
    @Type(() => NursingSpiritualEvaluation)
    public _NursingSpiritualEvaluation: NursingSpiritualEvaluation = new NursingSpiritualEvaluation();
}
