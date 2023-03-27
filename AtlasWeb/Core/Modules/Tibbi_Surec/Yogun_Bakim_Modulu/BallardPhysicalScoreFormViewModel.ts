//$FB278BF0
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BallardPhysical } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class BallardPhysicalScoreFormViewModel extends BaseViewModel {
    @Type(() => BallardPhysical)
    public _BallardPhysical: BallardPhysical = new BallardPhysical();
}
