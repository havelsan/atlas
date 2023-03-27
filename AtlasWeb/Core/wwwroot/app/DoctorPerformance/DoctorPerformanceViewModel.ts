
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';


export class DoctorPerformanceCommissionDecisionViewModel {
    public DecisionList: Array<DoctorPerformanceDecisionModel>;
    public Terms: Array<DoctorPerformanceTermModel>;
    public Users: Array<RelatedUserModel>;
    public SelectedDecision: DoctorPerformanceDecisionModel;
    constructor() {
        this.DecisionList = new Array<DoctorPerformanceDecisionModel>();
        this.Terms = new Array<DoctorPerformanceTermModel>();
        this.Users = new Array<RelatedUserModel>();
        this.SelectedDecision = new DoctorPerformanceDecisionModel();
    }
}

export class DoctorPerformanceDecisionModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    @Type(() => Date)
    public Date: Date; 
    public CreateDate: Date; 
    public Text: string;
    public CurrentState: string;
    @Type(() => Guid)
    public TermID: Guid;
    public MemberList: Array<DPCommissionMember>;
    constructor() {
        this.MemberList = new Array<DPCommissionMember>();
        this.Text = "";
        this.CurrentState = "";
        this.Name = "";
    }
}

export class DoctorPerformanceTermModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public CurrentState: string;
    public TotalPoint: number;
}

export class DoctorPerformanceTermOperationViewModel {
    public TermList: Array<DoctorPerformanceTermModel>;
    constructor()
    {
        this.TermList = new Array<DoctorPerformanceTermModel>();
    }
}
export class LookupColumn{
    public ObjectID: string;
    public Name: string;
    public State: string;

    constructor(_objectID: string, _name: string, _state: string) {
        this.ObjectID = _objectID;
        this.Name = _name;
        this.State = _state;
    }
}

export class BarChartModel {
    public ColumnName: string;
    public Description: string;
    public Value: number;
}

export class DoctorPerformanceTermStatesString {
    public static Open: string = "Açık";
    public static Cancelled: string = "İptal";
    public static Close: string = "Kapalı";
    public static Approved: string = "Onaylı";
}

export class DoctorPerformancePermissionOperationViewModel {
    public UnitManagerList: Array<UnitManagerModel>;
    public RelatedUserList: Array<RelatedUserModel>;
    @Type(() => Guid)
    public SelectedUnitManager: Guid;

    constructor()
    {
        this.RelatedUserList = new Array<RelatedUserModel>();
        this.UnitManagerList = new Array<UnitManagerModel>();
    }
}

export class saveUnitManagerAndRelatedDoctors {
    @Type(() => Guid)
    public UnitManagerObjectID: Guid;
    public ResUserObjectIDList: Array<Guid>;
    constructor() {
        this.UnitManagerObjectID = new Guid();
        this.ResUserObjectIDList = new Array<Guid>();
    }
}


export class UnitManagerModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
}


export class RelatedUserModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public SpecialtyName: string;
   
}

export class DPCommissionMember extends RelatedUserModel {
    public Duty: number;
}

export class BransGridModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
}
export class DoctorGridModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public UniqueRefNo: string;
    public Title: string;
    public B1Point: number;
    public B2Point: number;
    public B3Point: number;
    public LastExecDate: Date;
}
export class LogGridModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Date)
    public ExecDate: Date;
    public TotalCalcPoint: number;
}
export class DoctorPerformanceTermBasedOperationViewModel {
    public BransList: Array<BransGridModel>;
    public DoctorList: Array<DoctorGridModel>;
    public DetailList: Array<DetailModel>;
    public LogList: Array<LogGridModel>;
    public LogDiffList: Array<DiffDetailModel>;
    public LogDetailList: Array<DetailModel>;
    public SummaryList: Array<SummaryGridModel>;
    public RuleList: Array<RuleGridModel>;
    @Type(() => Guid)
    public SelectedBrans: Guid;
    @Type(() => Guid)
    public SelectedDoctor: Guid;
    constructor() {
        this.BransList = new Array<BransGridModel>();
        this.DoctorList = new Array<DoctorGridModel>();
        this.DetailList = new Array<DetailModel>();
        this.LogList = new Array<LogGridModel>();
        this.LogDiffList = new Array<DiffDetailModel>();
        this.LogDetailList = new Array<DetailModel>();
        this.RuleList = new Array<RuleGridModel>();
        this.SummaryList = new Array<SummaryGridModel>();
    }
}

export class SummaryGridModel{
    public Code: string;
    public Name: string;
    public TotalCount: number;
    public TotalPoint: number;
}
export class RuleGridModel {

    public Rule: string;
    public TotalCount: number;
    public TotalPoint: number;
}
export class DoctorPerformanceRuleOperationViewModel{
    public GILDefinitionList: Array<GILDefinitionDTO>;
    public SelectedRule: DoctorPerformanceRuleOperationDetailViewModel;
    public SelectedItem: GILDefinitionDTO;
    constructor() {
        this.SelectedItem = new GILDefinitionDTO();
        this.GILDefinitionList = new Array<GILDefinitionDTO>();
        this.SelectedRule = new DoctorPerformanceRuleOperationDetailViewModel();
    }
}
export class GILDefinitionDTO{
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public Point: number;
    public Description: string;
    public SurgeryGroup: string;
    public HasRule: boolean;
}
export class DoctorPerformanceRuleOperationDetailViewModel {
    public ProcedureList: Array<ProcedureModelForRule>;
    public SpecialityList: Array<SpecialityModelForRule>;
    public DiagnosisList: Array<DiagnosisModelForRule>;
    public QueryList: Array<QueryScriptModelForRule>;
    public AgeType: number;
    public Age: number;
    public PeriodScope: number;
    public Period: number;
    public PeriodTimeType: number;
    public PeriodAmount: number;
    public Sex: number;
    public Kesi: number;
    public Hospital: number;
    public TedaviTuru: string;
    constructor() {

        this.ProcedureList = new Array<ProcedureModelForRule>();
        this.SpecialityList = new Array<SpecialityModelForRule>();
        this.DiagnosisList = new Array<DiagnosisModelForRule>();
        this.QueryList = new Array<QueryScriptModelForRule>();
    }
}

export class ProcedureModelForRule {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public BannOrMustType: number;
    public TimeType: number;
}
export class SpecialityModelForRule {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public BannOrMustType: number;
}
export class DiagnosisModelForRule {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
}
export class QueryScriptModelForRule {
    public Script: string;
    public RuleName: string;
    public PointPercentage: number;
    public ResultMessage: string;
}


export class DetailModel {
    @Type(() => Guid)
    public ObjectID: Guid;
    public Name: string;
    public Code: string;
    public DoctorName: string;
    public PatientName: string;
    public ProtocolNo: string;
    public Point: number;
    public CalcPoint: number;
    public LastPoint: number;
    public RuleName: string;
    public RuleDescription: string;
    @Type(() => Date)
    public PerformedDate: Date;
    public IsModified: boolean;
    public RessectionName: string;
    public PatientStatus: string;
}

export class ServiceResultModel {
    public DetailList: Array<DetailModel>;
    public B1Point: number;
    public B2Point: number;
    public B3Point: number;
    public LastExecDate: Date;

    constructor()
    {
        this.DetailList = new Array<DetailModel>();
    }
}

export class DiffDetailModel extends DetailModel {
    public DiffType: number;
    public DiffDescription: string;
    public OldPoint: number;
    public NewPoint: number;
}

export class HasDPRolesModel
{
    public hasDPGrafikGenelRole: boolean;
    public hasDPGrafikOzelRole: boolean;
    public hasDPYonetimPaneliRole: boolean;
    public hasDPPerfomansRole: boolean;
    constructor() {
        this.hasDPGrafikGenelRole = false;
        this.hasDPGrafikOzelRole = false;
        this.hasDPYonetimPaneliRole = false;
        this.hasDPPerfomansRole = false;
    }
}

export class DpKatsayiRaporModel {
    @Type(() => Guid)
    public Performer: Guid;
    public PersonelName: string;
    public BranchName: string;
    public BranchCode: string;
    public GroupName: string;
    public RatioPoint: number;
    public TotalPoint: number;
    public LastPoint: number;
    public Ratio: number;

}
