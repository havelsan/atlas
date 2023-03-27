import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import {ENabizDataSets} from "./ENabizViewModel";

export class DataSetsFormViewModel extends BaseViewModel{
    @Type(() => ENabizDataSets)
    public _DatasetList: Array<ENabizDataSets> = new Array<ENabizDataSets>();
}