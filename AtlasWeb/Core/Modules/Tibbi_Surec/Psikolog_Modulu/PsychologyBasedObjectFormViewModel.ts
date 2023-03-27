//$2820EA9B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PsychologyBasedObject } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyAuthorizedUser } from 'NebulaClient/Model/AtlasClientModel';
import { IQIntelligenceTestReport } from 'NebulaClient/Model/AtlasClientModel';
import { VerbalAndPerformanceTests } from 'NebulaClient/Model/AtlasClientModel';
import { CognitiveEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologicEvaluation } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSOgrenimDurumu } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSMeslekler } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from "NebulaClient/ClassTransformer";


export class PsychologyBasedObjectFormViewModel extends BaseViewModel {
    @Type(() => PsychologyBasedObject)
    public _PsychologyBasedObject: PsychologyBasedObject = new PsychologyBasedObject();
    @Type(() => PsychologyAuthorizedUser)
    public PsychologyAuthorizedUsersGridList: Array<PsychologyAuthorizedUser> = new Array<PsychologyAuthorizedUser>();
    @Type(() => IQIntelligenceTestReport)
    public IQIntelligenceTestReportGridList: Array<IQIntelligenceTestReport> = new Array<IQIntelligenceTestReport>();
    @Type(() => VerbalAndPerformanceTests)
    public VerbalAndPerformanceTestsGridList: Array<VerbalAndPerformanceTests> = new Array<VerbalAndPerformanceTests>();
    @Type(() => CognitiveEvaluation)
    public ttgrid1GridList: Array<CognitiveEvaluation> = new Array<CognitiveEvaluation>();
    @Type(() => PsychologicEvaluation)
    public PsychologicEvaluationGridList: Array<PsychologicEvaluation> = new Array<PsychologicEvaluation>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => PsychologyBasedObject)
    public PsychologyBasedObjects: Array<PsychologyBasedObject> = new Array<PsychologyBasedObject>();
    @Type(() => SKRSOgrenimDurumu)
    public SKRSOgrenimDurumus: Array<SKRSOgrenimDurumu> = new Array<SKRSOgrenimDurumu>();
    @Type(() => SKRSMeslekler)
    public SKRSMesleklers: Array<SKRSMeslekler> = new Array<SKRSMeslekler>();
    @Type(() => Guid)
    public EpisodeId: Guid;
    @Type(() => Boolean)
    public PsychologyFormActive: Boolean;
    @Type(() => Boolean)
    public isUserAuthorized: Boolean;

}
