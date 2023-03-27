import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';

export class PatientHistoryFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.PatientHistoryFormViewModel, Core';

    @Type(() => ProcessTitle)
    public _PatientHistory: ProcessTitle;
    public PatientUniqueRefNo: string;
    public PatientId: Guid;
    public patientObjectId: string;
    public visibility: boolean;

    public SubEpisodeId: string;

    @Type(() => ProcessTitle)
    public PoliclinicProcessTitle: Array<ProcessTitle>;

    @Type(() => ProcessTitle)
    public ClinicProcessTitle: Array<ProcessTitle>;

    public DiagnosisCount: number;
    @Type(() => DiagnoseData)
    public DiagnoseDataList: Array<DiagnoseData>;

    public RadiologyCount: number;
    @Type(() => RadiologyData)
    public RadiologyDataList: Array<RadiologyData>;

    public LaboratoryCount: number;
    @Type(() => LaboratoryData)
    public LaboratoryDataList: Array<LaboratoryData>;

    public PathologyCount: number;
    @Type(() => PathologyData)
    public PathologyDataList: Array<PathologyData>;

    public DrugOrderCount: number;
    public DrugOrderDataList: any;

    @Type(() => ProcessTitleWithSubTitles)
    public SurgeryTitles: Array<ProcessTitleWithSubTitles>;

    @Type(() => ProcessTitle)
    public ImportantMedicalInformation: ProcessTitle;

    @Type(() => ProcessTitle)
    public PatientHistoryBySubEpisode: Array<ProcessTitle>;

    @Type(() => ProcessTitle)
    public PatientActionList: Array<ProcessTitle>;

    public VaccineCount: number;
    @Type(() => ProcessTitle)
    public VaccineProcessTitle: Array<ProcessTitle>;

    @Type(() => ProcessTitleWithSubTitles)
    public SpecialityTitles: Array<ProcessTitleWithSubTitles>;

    public RequestedProceduresCount: number;
    @Type(() => RequestedProcedureData)
    public RequestedProceduresList: Array<RequestedProcedureData>;

    public TreatmentMaterialsCount: number;
    @Type(() => TreatmentMaterialData)
    public TreatmentMaterialsList: Array<TreatmentMaterialData>;

    @Type(() => ProcessTitle)
    public EmergencyObjectTitle: Array<ProcessTitle>;

    public DietOrdersCount: number;
    @Type(() => DietOrderData)
    public DietOrdersList: Array<DietOrderData>;

    @Type(() => ProcessTitle)
    public ManipulationProcessTitle: Array<ProcessTitle>;

    public AllProceduresLink: string;
    public AllLabProceduresLink: string;
    public LinksVisibility: boolean;
    @Type(() => ProcessTitle)
    public PhysiotherapyRequestsTitles: Array<ProcessTitle>;
    public CloseAllPanel: boolean;
    public PopUpHistoryList: Array<PopupHistory>;
    _historyFilter: HistoryFilter = new HistoryFilter();
}


export class ProcessTitle {
    public ObjectID: string;
    public ObjectDefName: string;
    public FormDefId: string;
    public RequestDate: Date;
    public SpecialityName: string;
    public DoctorName: string;
}
export class ProcessTitleWithSubTitles {
    public ObjectID: string;
    public ObjectDefName: string;
    public FormDefId: string;
    public RequestDate: Date;
    public SpecialityName: string;
    public DoctorName: string;
    public SubTitles: Array<ProcessTitle>;
}
export class DiagnoseData {
    public ObjectId: Guid;
    public DiagnoseDate: string;
    public DiagnoseType: string;
    public DiagnoseCode: string;
    public DiagnoseName: string;
    public FreeDiagnosis: string;
    public IsMainDiagnose: boolean;
    public EntryType: string;
    public Speciality: string;
    public ResponsibleDoctor: string;
}
export class RadiologyData {
    public RequestNumber: string;
    public RequestDate: string;
    public TestCode: string;
    public TestName: string;
    public Doctor: string;
    public FromResource: string;
    public ReportTxt: string;
    public AccesionNumber: number;
}
export class PathologyData {
    public AdmissionNumber: string;
    public RequestDate: string;
    public TestCode: string;
    public TestName: string;
    public Doctor: string;
    public FromResource: string;
    public Macroscopy: string;
    public Microscopy: string;
    public PathologicDiagnosis: string;
    public Note: string;
    @Type(() => Boolean)
    public IsApproved: boolean;
    @Type(() => Boolean)
    public IsReported: boolean;
    public ObjectID: string;
    
}
export class RequestedProcedureData {
    public ProcedureCode: string;
    public ProcedureName: string;
    public Amount: number;
    public UnitPrice: string;
    public RequestBy: string;
    public RequestDate: string;
    public MasterResource: string;
    public ActionStatus: string;
    public ProcedureResultLink: string;
    public ProcedureReportLink: string;
}
export class TreatmentMaterialData {
    public ActionDate: string;
    public Name: string;
    public Code: string;
    public Amount: string;
}
export class DietOrderData {
    public DietName: string;
    public DietDate: string;
    public WhichMeal: string;
    public MasterResource: string;
    public PhysicalStateClinic: string;
    public RoomName: string;
    public RoomGroupName: string;
    public OrderDescription: string;
    public CurrentStateName: string;
    public PeriodStartTime: string;
    public PeriodEndTime: string;
    public DoctorName: string;
}

export class LaboratoryData {
    @Type(() => Guid)
    public ObjectID: Guid;
    public TestCode: string;
    public LaboratoryTestName: string;
    public RequestDate: Date;
    public FromResourceName: string;
    public RequestedByUser: string;
    public BarcodeID: string;
    public SpecimenID: string;
    public ResultDate: Date;
    public Result: string;
    public Unit: string;
    public Reference: string;
    public ApproveDate: Date;
    public BarcodePrintDate: Date;
    public SampleDate: Date;
    public TestLoincCode: string;
    @Type(() => LaboratorySubProcedureData)
    public LaboratorySubProcedureList: Array<LaboratorySubProcedureData>;
    @Type(() => Boolean)
    public isPanelTest: boolean;

}

export class LaboratorySubProcedureData {
    @Type(() => Guid)
    public ObjectID: Guid;
    @Type(() => Guid)
    public MasterSubactionProcedureID: Guid;
    public TestCode: string;
    public LaboratoryTestName: string;
    public ResultDate: Date;
    public Result: string;
    public Unit: string;
    public Reference: string;

}
export class PopupHistory
{
    public ObjectID: string;
    public RequesterID: string;
    public RequesterUsr: string;
    public RequesterUnit: string;
    public ObjectDefName: string;
    public CurrentState: string;
    @Type(() => Date)
    public RequestDate: Date;
}

export class HistoryFilter {
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    public actionType: string;
    @Type(() => Boolean)
    public selectAll: boolean;
    @Type(() => Boolean)
    public useFilter: boolean;
    @Type(() => Guid)
    public subEpisode: Guid;

}

export class TeletipInput_DVO
{
    public PatientCitizenId: string;
    public SUTCodeList:Array<string>;
}