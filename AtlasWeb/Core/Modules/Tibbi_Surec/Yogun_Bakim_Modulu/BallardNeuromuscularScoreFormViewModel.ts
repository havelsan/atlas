//$29C8492B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BallardNeuromuscular } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class BallardNeuromuscularScoreFormViewModel extends BaseViewModel {
    @Type(() => BallardNeuromuscular)
    public _BallardNeuromuscular: BallardNeuromuscular = new BallardNeuromuscular();
}
