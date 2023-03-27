//$1190FE80
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { KvcRiskScore, Surgery } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class KvcRiskScoreFormViewModel extends BaseViewModel {
    @Type(() => KvcRiskScore)
    public _KvcRiskScore: KvcRiskScore = new KvcRiskScore();

    @Type(() => Surgery)
    public _Surgery: Surgery;
}
