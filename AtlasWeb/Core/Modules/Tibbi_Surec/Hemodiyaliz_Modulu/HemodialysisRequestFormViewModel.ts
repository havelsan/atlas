//$E801CDDD
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { HemodialysisRequest } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class HemodialysisRequestFormViewModel extends BaseViewModel {
    @Type(() => HemodialysisRequest)
    public _HemodialysisRequest: HemodialysisRequest = new HemodialysisRequest();
}
