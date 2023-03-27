//$B468C0A2
import { EpisodeAction, HCReportTypeDefinition, HCRequestReason, HealthCommittee, EDisabledReport, EStatusNotRepCommitteeObj } from 'NebulaClient/Model/AtlasClientModel';
import { SubActionProcedure, ReasonForExaminationDefinition, PatientAdmissionResourcesToBeReferred, WhoPaysEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { HCRequestReasonDetail, HCHospitalUnit } from '../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel';

export class EpisodeActionFormViewModel extends BaseViewModel {
    @Type(() => EpisodeAction)
    public _EpisodeAction: EpisodeAction = new EpisodeAction();
}

export class SUTRuleResultViewModel {
    @Type(() => Boolean)
    public validateResult: Boolean;
    public messageList: Array<string> = new Array<string>();
}

export class SUTRuleEngineInputViewModel {
    @Type(() => EpisodeAction)
    public episodeAction: EpisodeAction;
    @Type(() => SubActionProcedure)
    public subActionProcedures: Array<SubActionProcedure> = new Array<SubActionProcedure>();
}

export class InpatientHC_Class {
    @Type(() => ReasonForExaminationDefinition)
    public reasonForExaminationDefinition: ReasonForExaminationDefinition;

    @Type(() => PatientAdmissionResourcesToBeReferred)
    public resourcesToBeReferredList: Array<PatientAdmissionResourcesToBeReferred>;

    public _hcReasonID: string;

    public HCModeOfPayment: WhoPaysEnum = 0;

    @Type(() => Guid)
    public episodeActionObjectID: Guid;

    @Type(() => EDisabledReport)
    public eDisabledReport: EDisabledReport = null;

    @Type(() => EStatusNotRepCommitteeObj)
    public eStatusNotfReportObj: EStatusNotRepCommitteeObj = null;
}

export class EReportIndexAuthorizations {
    public isAuthorizedForEDogum: boolean;
    public isAuthorizedForEAthlete: boolean;
    public isAuthorizedForEDriver: boolean;
    public isAuthorizedForEPsychotecnics: boolean;
    public isAuthorizedForEDisabled: boolean;
}

export class DailyInpatientInfoModel {
    public HasDailyInpatient: boolean;
    public DailyInpatientProtocolNo: string;
    public HasNormalInpatient: boolean;
}

export class HealthCommitteandReqReason {
    @Type(() => HCRequestReason)
    public hCRequestReasons: Array<HCRequestReason>;
    @Type(() => HealthCommittee)
    public shortHealthCommittees: Array<ShortHcInfo>;
}

export class ShortHcInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    public HCReportName: string;
}

export class OldHealthCommitte {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public HCStateID: Guid;
    public HCReasonID: string;
    public ReasonForExamination: ReasonForExaminationDefinition;
    public HCModeOfPayment: WhoPaysEnum;
    public HospitalsUnits: Array<HCHospitalUnit>;
    public EDisabledReport: EDisabledReport;
    public eStatusNotfReportObj: EStatusNotRepCommitteeObj;
}

export class BirthTypeModel
{
    @Type(() => Guid)
    public ObjectID: Guid;    
    public Name: string; 
}

export class SurgeryChecklistModel
{
    public ChecklistID: Guid;    
    public Procedures: string;
    public RequestDate: Date;
}



