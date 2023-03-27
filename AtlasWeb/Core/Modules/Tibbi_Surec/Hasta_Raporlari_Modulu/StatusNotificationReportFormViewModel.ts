//$07330916
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { StatusNotificationReport } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { HCRequestReason } from 'NebulaClient/Model/AtlasClientModel';
import { ReasonForExaminationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PeriodUnitTypeWithUndefiniteEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ReportDiagnosisFormViewModel } from '../Tani_Modulu/ReportDiagnosisFormViewModel';

export class StatusNotificationReportFormViewModel extends BaseViewModel {
    @Type(() => StatusNotificationReport)
    public _StatusNotificationReport: StatusNotificationReport = new StatusNotificationReport();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => HCRequestReason)
    public HCRequestReasons: Array<HCRequestReason> = new Array<HCRequestReason>();
    @Type(() => ReasonForExaminationDefinition)
    public ReasonForExaminationDefinitions: Array<ReasonForExaminationDefinition> = new Array<ReasonForExaminationDefinition>();
    @Type(() => Number)
    public txtRaporSuresi: number;
    public cmbRaporSureTuru: PeriodUnitTypeWithUndefiniteEnum;
    @Type(() => Boolean)
    public IsSuperUser: boolean;
    @Type(() => Guid)
    public ToState: Guid;
    @Type(() => ReportDiagnosisFormViewModel)
    public reportDiagnosisFormViewModel: ReportDiagnosisFormViewModel = new ReportDiagnosisFormViewModel();
    public Complaint: string;
    public PatientHistory: string;
    public PhysicalExamination: string;
    public MTSConclusion: string;
    public diagnosisCodeList: Array<string> = new Array<string>();

    public minReportDate : string = "";
    public maxReportDate : string = "";
}
