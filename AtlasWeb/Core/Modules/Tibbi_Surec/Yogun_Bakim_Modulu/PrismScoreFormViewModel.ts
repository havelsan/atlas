//$D9C6323B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Prism } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class PrismScoreFormViewModel extends BaseViewModel {

    @Type(() => Prism)
    public _Prism: Prism = new Prism();

    @Type(() => Number)
    public age: number;
}
