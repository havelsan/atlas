//$E4BD1750
import { GlassesReport } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "NebulaClient/ClassTransformer";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class GlassesReportFormViewModel extends BaseViewModel {
    @Type(() => GlassesReport)
    public _GlassesReport: GlassesReport = new GlassesReport();
    @Type(() => DiagnosisGrid)
    public SecDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisGrid)
    public DiagnosisDiagnosisGridGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Boolean)
    public cbxVitrumFarVal: boolean;
    @Type(() => Boolean)
    public cbxVitrumCloseReadingVal: boolean;
    @Type(() => Boolean)
    public cbxVitrumNearVal: boolean;
    @Type(() => Boolean)
    public stateToComplete: boolean = false;
    @Type(() => Boolean)
    public stateToNew: boolean = false;
    public medulaUsername: string = "";
    public medulaPassword: string = "";
}
export class OldGlassesReport {

    @Type(() => Guid)
    public ObjectId: Guid;
    @Type(() => Date)
    public ActionDate: Date;
    public GlassesReportNo: string;
    public currentState: string;

}
