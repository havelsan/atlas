//$3DD3D024
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DietOrder } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DietOrderFormViewModel extends BaseViewModel {
    @Type(() => DietOrder)
    public _DietOrder: DietOrder = new DietOrder();
}
