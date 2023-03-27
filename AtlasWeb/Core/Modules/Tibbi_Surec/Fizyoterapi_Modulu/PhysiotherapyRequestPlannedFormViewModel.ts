//$70E7AD1C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysiotherapyRequest } from "NebulaClient/Model/AtlasClientModel";
import { BaseTreatmentMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { OzelDurum } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';
import { PhysiotherapyOrderPlannedFormViewModel } from './PhysiotherapyOrderPlannedFormViewModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { TreatmentQueryReportTypeEnum, ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TreatmentDiagnosisInfo } from "./PhysiotherapyOrderRequestFormViewModel";

export class PhysiotherapyRequestPlannedFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PhysiotherapyRequestPlannedFormViewModel, Core';

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

    public expandedRowKeys: number;

    public IsSessionRecalculate: boolean;
    public sessionRecalculateByDate: boolean;
    @Type(() => Date)
    public SessionChangedDate: Date;

    @Type(() => PlannedPhyOrderDetailInfo)
    public ChangedOrderDetail: PlannedPhyOrderDetailInfo;

    @Type(() => PlannedOrderDetailSessionInfo)
    public OrderDetailInfoList: Array<PlannedOrderDetailSessionInfo>;

    public PhysiotherapySessionRate: string;

    @Type(() => OrderInfo)
    public PhysiotherapyOrderList: Array<OrderInfo>;

    @Type(() => PhysiotherapyOrderPlannedFormViewModel)
    public selectedPhysiotherapyOrderPlannedFormViewModel: PhysiotherapyOrderPlannedFormViewModel;

    public CanComplatePhysiotherapyRequest: boolean;

    @Type(() => PackageProcedureDefinition)
    public PackageProcedure: PackageProcedureDefinition;

    @Type(() => PhysiotherapyReports)
    public Report: PhysiotherapyReports;

    public TreatmentType: TreatmentQueryReportTypeEnum;

    @Type(() => ReportItem)
    public ReportItemList: Array<ReportItem>;

    public Message: string;

    @Type(() => PlannedPhyOrderDetailInfo)
    public selectedRowKeysResultList: Array<PlannedPhyOrderDetailInfo>;

    @Type(() => Date)
    public LastOrderDetailStartDate: Date;
    @Type(() => Date)
    public LastOrderDetailFinishDate: Date;
    @Type(() => ResUser)
    public LastOrderDetailResponsiblePhysiotherapist: ResUser;

    @Type(() => ProcedureDefinition)
    public ProcedureObjectDataSource: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();

    @Type(() => TreatmentDiagnosisUnitInfo)
    public TreatmentDiagnosisUnitInfos: Array<TreatmentDiagnosisUnitInfo> = new Array<TreatmentDiagnosisUnitInfo>();

    public HasRole_Fizyoterapi_Ek_Islem: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Uygulama: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Hasta_Gelmedi: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Durdurma: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Iptal_Et: boolean;
    public HasRole_Fizyoterapi_Tarih_Guncelleme: boolean;
    public HasRole_Fizyoterapi_Uygulamasi_Geri_Alma: boolean;
    //public IsPhysiotherapyRequestFormUsing: boolean;
    public MedicalInfo: string;
    public AnamnesisComplaintInfo: string;
    public AnamnesisPatientHistoryInfo: string;
    public AnamnesisPhysicalExaminationInfo: string;
    public AnamnesisMTSConclusionInfo: string;
    public HideAnamnesisInfoButton: boolean = true;

}

export class PlannedOrderDetailSessionInfo {
    @Type(() => PlannedPhyOrderDetailInfo)
    public OrderDetailList: Array<PlannedPhyOrderDetailInfo>;
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

    @Type(() => Boolean)
    public PhyOrderIsPackageExists: Boolean;

    public TreatmentProperties: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public FinishDate: Date;
    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;
    //@Type(() => PhysiotherapyOrderDetail)
    //public OrderDetailItem: PhysiotherapyOrderDetail;

    @Type(() => Date)
    public OrderDetailPlannedDate: Date;
    @Type(() => Guid)
    public OrderDetailCurrentStateDefID: Guid;
    @Type(() => Guid)
    public OrderDetailObjectID: Guid;
    public OrderDetailObjectDef: string;
    @Type(() => Guid)
    public OrderObjectID: Guid;


    public PhysiotherapySessionId: string;
    public PhysiotherapySessionDef: string;
}
export class PlannedPhyOrderDetailInfo {
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

    @Type(() => Boolean)
    public PhyOrderIsPackageExists: Boolean;

    public TreatmentProperties: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public FinishDate: Date;
    @Type(() => ResUser)
    public ResponsiblePhysiotherapist: ResUser;
    //@Type(() => PhysiotherapyOrderDetail)
    //public OrderDetailItem: PhysiotherapyOrderDetail;

    @Type(() => Date)
    public OrderDetailPlannedDate: Date;
    @Type(() => Guid)
    public OrderDetailCurrentStateDefID: Guid;
    @Type(() => Guid)
    public OrderDetailObjectID: Guid;
    public OrderDetailObjectDef: string;
    @Type(() => Guid)
    public OrderObjectID: Guid;


    public PhysiotherapySessionId: string;
    public PhysiotherapySessionDef: string;
}

export class TreatmentDiagnosisUnitInfo {
    public TreatmentDiagnosisUnitID: Guid;
    public State: string;
    public TreatmentDiagnosisUnitName: string;
    public TreatmentNote: string;
    public TreatmentNoteId: string;
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

export class ReportItem {
    @Type(() => PhysiotherapyReports)
    public ReportObj: PhysiotherapyReports;

    public ReportNo: string;
    public ReportDate: string;
    public ReportStartDate: string;
    public ReportEndDate: string;
    public ApplicationArea: string;
    public ReportType: string;
    public ReportInfo: string;
    public ReportTime: string;
    public TreatmentType: string;
    public DiagnosisGroup: string;

    @Type(() => PackageProcedureDefinition)
    public PackageProcedureDefinition: PackageProcedureDefinition;
}

export class TreatmentUnitAndRequest {
    @Type(() => Guid)
    public PhysiotherapyRequestId: Guid;
    @Type(() => Guid)
    public PhysiotherapyRequestDefId: Guid;
    @Type(() => TreatmentDiagnosisInfo)
    public TreatmentDiagnosisInfoList: Array<TreatmentDiagnosisInfo> = new Array<TreatmentDiagnosisInfo>();
}