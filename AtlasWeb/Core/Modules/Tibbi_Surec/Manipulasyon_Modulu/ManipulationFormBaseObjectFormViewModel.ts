//$A7E32CBF
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ManipulationFormBaseObject } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ManipulationFormBaseObjectFormViewModel extends BaseViewModel {
    @Type(() => ManipulationFormBaseObject)
    public _ManipulationFormBaseObject: ManipulationFormBaseObject = new ManipulationFormBaseObject();
}
