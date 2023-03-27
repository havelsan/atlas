//$DB89F690
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseEpisodeActionWorkListSearchCriteria, BaseEpisodeActionWorkListItem, BaseEpisodeActionWorkListFormViewModel } from "Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel";
import { ResSection, LCDNotificationDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class ExaminationWorkListViewModel extends BaseEpisodeActionWorkListFormViewModel {
    @Type(() => ExaminationWorkListItem)
    WorkList: Array<ExaminationWorkListItem> = new Array<ExaminationWorkListItem>();
    @Type(() => ExaminationWorkListItem)
    ReportApproveWorkList: Array<ExaminationWorkListItem> = new Array<ExaminationWorkListItem>();
    _SearchCriteria: ExaminationWorkListSearchCriteria = new ExaminationWorkListSearchCriteria();
    // _SearchCriteria  dx-tag-box 'ı doldurmak için
    @Type(() => ResSection)
    ResourceList: Array<ResSection> = new Array<ResSection>();
    @Type(() => LCDNotificationDefinition)
    LCDNotificationList: Array<LCDNotificationDefinition> = new Array<LCDNotificationDefinition>();
    @Type(() => LCDNotificationDefinition)
    LCDNotification : LCDNotificationDefinition;
    triageCode: string;
    hasHeadDoctorRole: boolean = false;
    isNewLcd: string;
}

export class ExaminationWorkListSearchCriteria extends BaseEpisodeActionWorkListSearchCriteria {
    @Type(() => ResSection)
    public Resources: Array<ResSection>;
    @Type(() => ListObject)
    public ActionNames: Array<ListObject>;
    @Type(() => ListObject)
    public ActionStatus: Array<ListObject>;
    @Type(() => ListObject)
    public ReportStatus: Array<ListObject>;
    @Type(() => Number)
    public PatientType: number;
    public ProtocolNo: string;
    public ReportChasingNo: string;
    public policlinic_EA: boolean;
    public participatnFreeDrugReport_EA: boolean;
    public doNotListCalleds: boolean;
}

export class ExaminationWorkListItem extends BaseEpisodeActionWorkListItem {

    public AdmissionQueueNo: string;
    @Type(() => Date)
    public Date: Date;
    public PatientNameSurname: string;
    public KabulNo: string;
    public UniqueRefno: string;
    public EpisodeActionName: string;
    public StateName: string;
    public ResourceName: string;
    public DoctorName: string;
    public ExaminationProtocolNo: string;

    public ComingReason: string;
    public PayerInfo: string;
    public PatientClassGroup: string;
    public ApplicationReason: string;
    @Type(() => Date)
    public BirthDate: Date;
    public FatherName: string;
    public PhoneNumber: string;
    public Diagnosis: string;
    public Triage: string;

}

export class ListObject {
    public TypeName: string;
    @Type(() => Number)
    public TypeID: number;
}

export class SendWorklistSignedReportApproveModel {
    @Type(() => Guid)
    public reportObjectId: Guid 
    public medulaUsername: string;
    public medulaPassword: string;
    public signContent: string;
}

