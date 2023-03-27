//$C7340BCC
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { VerbalAndPerformanceTests } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";

export class VerbalAndPerformanceTestsFormViewModel extends BaseViewModel {
    @Type(() => VerbalAndPerformanceTests)
    public _VerbalAndPerformanceTests: VerbalAndPerformanceTests = new VerbalAndPerformanceTests();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Boolean)
    public  isUserAuthorized: Boolean ;
}
