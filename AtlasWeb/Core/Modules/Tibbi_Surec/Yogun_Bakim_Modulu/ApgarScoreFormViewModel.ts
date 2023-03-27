//$667A2C28
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Apgar } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "../../../wwwroot/app/NebulaClient/ClassTransformer";

export class ApgarScoreFormViewModel extends BaseViewModel {
    @Type(() => Apgar)
    public _Apgar: Apgar = new Apgar();
}
