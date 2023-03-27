//$D8D66679
import { PatientExamination } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SKRSCikisSekli } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class PatientExaminationFormViewModel extends BaseViewModel {
    public _PatientExamination: PatientExamination = new PatientExamination();
    public Episodes: Array<Episode> = new Array<Episode>();
    public Patients: Array<Patient> = new Array<Patient>();
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public SKRSCikisSeklis: Array<SKRSCikisSekli> = new Array<SKRSCikisSekli>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    public ResSections: Array<ResSection> = new Array<ResSection>();
    public FormattedRequestDate: string;
    //public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    // public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    //public EpisodeActions: Array<EpisodeAction> = new Array<EpisodeAction>();
    //public DiagnosisHistoryGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    //public GridAdditionalApplicationsGridList: Array<PatientExaminationAdditionalApplication> = new Array<PatientExaminationAdditionalApplication>();
    //public GridTreatmentMaterialsGridList: Array<PatientExaminationTreatmentMaterial> = new Array<PatientExaminationTreatmentMaterial>();
    //public GrdConsultationGridList: Array<Consultation> = new Array<Consultation>();
    //public ttgridSevkEdenDoktorlarGridList: Array<DoctorGrid> = new Array<DoctorGrid>();
    //public GridNursingOrdersGridList: Array<SingleNursingOrder> = new Array<SingleNursingOrder>();
    //public ForensicProceduresGridGridList: Array<PatientExaminationForensicProcedure> = new Array<PatientExaminationForensicProcedure>();
    //public EmergencyInterventions: Array<EmergencyIntervention> = new Array<EmergencyIntervention>();
    //public ImportantMedicalInformations: Array<ImportantMedicalInformation> = new Array<ImportantMedicalInformation>();
    //public Materials: Array<Material> = new Array<Material>();
    //public StockCards: Array<StockCard> = new Array<StockCard>();
    //public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    //public SevkVasitasis: Array<SevkVasitasi> = new Array<SevkVasitasi>();
    //public VitalSignAndNursingDefinitions: Array<VitalSignAndNursingDefinition> = new Array<VitalSignAndNursingDefinition>();
    //public SingleNursingOrderDetails: Array<SingleNursingOrderDetail> = new Array<SingleNursingOrderDetail>();

    //public _PatientExaminationMasterResourceID: Guid;
    //public RequestedProcedures: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();
    //public _EpisodeActionObjectId: Guid;
    //public EpisodeActionRequestedProcedureInfo: EpisodeActionRequestedProcedureInfo;
}

//export class EpisodeActionRequestedProcedureInfo {
//    public EpisodeAction: PatientExamination;
//    public Emergency: boolean;
//    public ProcedureRequestFormDetailDefinitionIDs: Array<Guid> = new Array<Guid>();
//    public ProcedureRequestAdditionalApplicationIDs: Array<Guid> = new Array<Guid>();

//}
