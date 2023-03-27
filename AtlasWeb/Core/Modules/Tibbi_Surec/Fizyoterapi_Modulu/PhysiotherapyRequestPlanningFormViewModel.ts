//$70E7AD1C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyRequest, DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { BaseTreatmentMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { OzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { PhysiotherapyOrderPlanningFormViewModel } from './PhysiotherapyOrderPlanningFormViewModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { PatientReportInfo } from "../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel";
import { UserTemplateModel } from "../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel";


export class PhysiotherapyRequestPlanningFormViewModel extends BaseViewModel {

    @Type(() => PhysiotherapyRequest)
    public _PhysiotherapyRequest: PhysiotherapyRequest = new PhysiotherapyRequest();


    @Type(() => BaseTreatmentMaterial)
    public GridTreatmentMaterialsGridList: Array<BaseTreatmentMaterial> = new Array<BaseTreatmentMaterial>();

    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();

    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();

    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();

    @Type(() => OzelDurum)
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();

    //@Type(() => OrderDetailInfo)
    //public AdditionalOrderDetailInfoList: Array<OrderDetailInfo> = new Array<OrderDetailInfo>();

    //@Type(() => OrderDetailInfo)
    //public ChangedOrderDetail: OrderDetailInfo;

    @Type(() => OrderDetailSessionInfo)
    public OrderDetailInfoList: Array<OrderDetailSessionInfo>;

    //public PhysiotherapySessionRate: string;

    @Type(() => OrderInfo)
    public PhysiotherapyOrderList: Array<OrderInfo>;

    @Type(() => PhysiotherapyOrderPlanningFormViewModel)
    public selectedPhysiotherapyPlannedOrdersFormViewModel: PhysiotherapyOrderPlanningFormViewModel;

    //@Type(() => PackageProcedureDefinition)
    //public PackageProcedure: PackageProcedureDefinition;

    //@Type(() => PhysiotherapyReports)
    //public Report: PhysiotherapyReports;

    //public TreatmentType: TreatmentQueryReportTypeEnum;

    //@Type(() => ReportItem)
    //public ReportItemList: Array<ReportItem>;

    //public Message: string;
    public selectedRowKeysResultList: Array<PhyOrderDetailInfo>;

    public IsAppointmentActive: boolean;

    //@Type(() => Date)
    //public LastOrderDetailStartDate: Date;
    //@Type(() => Date)
    //public LastOrderDetailFinishDate: Date;
    //@Type(() => ResUser)
    //public LastOrderDetailResponsiblePhysiotherapist: ResUser;

    @Type(() => ProcedureDefinition)
    public ProcedureObjectDataSource: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

    public HasRole_Fizyoterapi_Ek_Islem: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Iptal_Et: boolean;

    public IsPhysiotherapyRequestFormUsing: boolean;
    public MedicalInfo: string;
    public AnamnesisComplaintInfo: string;
    public AnamnesisPatientHistoryInfo: string;
    public AnamnesisPhysicalExaminationInfo: string;
    public AnamnesisMTSConclusionInfo: string;
    public HideAnamnesisInfoButton: boolean = true;
    @Type(() => PatientReportInfo)
    public PatientReportInfoList: Array<PatientReportInfo> = new Array<PatientReportInfo>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => UserTemplateModel)
    public userTemplateList : Array<UserTemplateModel> = new Array<UserTemplateModel>();

    @Type(() => UserTemplateModel)
    public selectedUserTemplate : UserTemplateModel;

}


export class OrderDetailInfo {
    public SessionNumber: string;
    @Type(() => Date)
    public PlannedDate: Date;
    public PhysiotherapyState: string;
    public ApplicationArea: string;
    public ApplicationAreaInfo: string;
    public TreatmentDiagnosisUnit: string;
    public Duration: string;
    public Dose: string;
    public NoteToPhysiotherapist: string;
    public Physiotherapist: string;
    public IsAdditionalProcess: Boolean;
    public IsAdditionalTreatment: Boolean;
    public CurrentUserObjectId: Guid;
    public ProcedureObject: string;
    public Package: string;
    public TreatmentProperties: string;

    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public FinishDate: Date;

    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;

    @Type(() => PhysiotherapyOrderDetail)
    public OrderDetailItem: PhysiotherapyOrderDetail;
}
export class OrderInfo {
    public TreatmentDiagnosisUnit: string;
    public ApplicationArea: string;
    public ApplicationAreaInfo: string;
    public ProcedureObject: string;
    public SessionCount: number;
    public Duration: string;
    public Dose: string;
    public TreatmentProperties: string;

    public IsPlannedBefore: boolean;

    @Type(() => Guid)
    public CurrentStateDefID: Guid;

    @Type(() => Guid)
    public OrderObjectId: Guid;

    @Type(() => Guid)
    public OrderObjectDefId: Guid;
}

export class OrderDetailSessionInfo {
    @Type(() => PhyOrderDetailInfo)
    public OrderDetailList: Array<PhyOrderDetailInfo>;
    public KeyNumber: string;
    public SessionNumber: string;
    public PlannedDate: string;
    public PhysiotherapyState: string;
    public ApplicationAreaDef: string;
    public ApplicationAreaInfo: string;
    public TreatmentDiagnosisUnit: string;
    public Duration: string;
    public Dose: string;
    public DoseDurationInfo: string;
    public Physiotherapist: string;
    @Type(() => Boolean)
    public IsAdditionalProcess: Boolean;
    @Type(() => Boolean)
    public IsAdditionalTreatment: Boolean;
    public CurrentUserObjectId: Guid;
    public ProcedureObject: string;
    public Package: string;
    public TreatmentProperties: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public FinishDate: Date;
    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;
    @Type(() => PhysiotherapyOrderDetail)
    public OrderDetailItem: PhysiotherapyOrderDetail;
}
export class PhyOrderDetailInfo {
    public KeyNumber: string;
    public SessionNumber: string;
    public PlannedDate: string;
    public PhysiotherapyState: string;
    public ApplicationAreaDef: string;
    public ApplicationAreaInfo: string;
    public TreatmentDiagnosisUnit: string;
    public Duration: string;
    public Dose: string;
    public DoseDurationInfo: string;
    public Physiotherapist: string;
    @Type(() => Boolean)
    public IsAdditionalProcess: Boolean;
    @Type(() => Boolean)
    public IsAdditionalTreatment: Boolean;
    public CurrentUserObjectId: Guid;
    public ProcedureObject: string;
    public Package: string;
    public TreatmentProperties: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public FinishDate: Date;
    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;
    @Type(() => PhysiotherapyOrderDetail)
    public OrderDetailItem: PhysiotherapyOrderDetail;
}