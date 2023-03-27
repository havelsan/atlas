//$28E4B765
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PsychologyTest } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "NebulaClient/ClassTransformer";
import { EpisodeAction } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";

export class PsychologyTestRequestInfoFormViewModel extends BaseViewModel {
    @Type(() => PsychologyTest)
    public _PsychologyTest: PsychologyTest = new PsychologyTest();
    public ProcedureName: string;
    public textDescription: string;
    @Type(() => EpisodeAction)
    public EpisodeActions: Array<EpisodeAction> = new Array<EpisodeAction>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();

}
