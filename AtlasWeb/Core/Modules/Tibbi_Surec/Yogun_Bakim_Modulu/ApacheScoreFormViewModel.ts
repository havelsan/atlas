//$4B2A0E30
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ApacheScore } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class ApacheScoreFormViewModel extends BaseViewModel {
    @Type(() => ApacheScore)
    public _ApacheScore: ApacheScore = new ApacheScore();

    public glaskowScore: number;
    public O2GradientmmHg: number;
    public O2GradientKPa: number;
}
