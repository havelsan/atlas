//$E267C06F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { CognitiveEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class CognitiveEvaluationFormViewModel extends BaseViewModel {
    @Type(() => CognitiveEvaluation)
    public _CognitiveEvaluation: CognitiveEvaluation = new CognitiveEvaluation();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => Boolean)
    public isUserAuthorized: Boolean;

}
