//$9B6FCA57
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { EarlyChildGrowthEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class EarlyChildGrowthEvalFormViewModel extends BaseViewModel {
    @Type(() => EarlyChildGrowthEvaluation)
    public _EarlyChildGrowthEvaluation: EarlyChildGrowthEvaluation = new EarlyChildGrowthEvaluation();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Boolean)
    public isUserAuthorized: Boolean;

}
