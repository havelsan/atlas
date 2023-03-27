//$D3A4FA7F
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PsychologicEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";

export class PsychologicEvaluationFormViewModel extends BaseViewModel {
    @Type(() => PsychologicEvaluation)
    public _PsychologicEvaluation: PsychologicEvaluation = new PsychologicEvaluation();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => Boolean)
    public isUserAuthorized: Boolean;

}
