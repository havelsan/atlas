//$60481105
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Snappe } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class SnappeIIScoreFormViewModel extends BaseViewModel {
    @Type(() => Snappe)
    public _Snappe: Snappe = new Snappe();
}
