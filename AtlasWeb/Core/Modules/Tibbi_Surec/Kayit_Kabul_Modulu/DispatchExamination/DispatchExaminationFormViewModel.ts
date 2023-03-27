import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { vmRequestedProcedure, vmProcedureRequestFormDefinition } from "Modules/Tibbi_Surec/Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { DispatchExamination } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisGrid } from "NebulaClient/Model/AtlasClientModel";
import { DispatchExaminationAdditionalApplication } from "NebulaClient/Model/AtlasClientModel";
import { DiagnosisDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { EpisodeAction } from "NebulaClient/Model/AtlasClientModel";
import { ResSection } from "NebulaClient/Model/AtlasClientModel";

export class DispatchExaminationFormViewModel {

    public _DispatchExamination: DispatchExamination = new DispatchExamination();
    public GridDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    public GridAdditionalApplicationsGridList: Array<DispatchExaminationAdditionalApplication> = new Array<DispatchExaminationAdditionalApplication>();
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public EpisodeActions: Array<EpisodeAction> = new Array<EpisodeAction>();
    public ResSections: Array<ResSection> = new Array<ResSection>();

    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();

    @Type(() => Guid)
    public ProcedureRequestFormResourceIDs: Array<Guid> = new Array<Guid>();

    public UserMostUsedFormDefinitions: Array<vmProcedureRequestFormDefinition> = new Array<vmProcedureRequestFormDefinition>();

    public GridTreatmentMaterialsGridList: Array<any> = new Array<any>();

    @Type(() => vmRequestedProcedure)
    public GridRequestedProcedureGridList: Array<vmRequestedProcedure> = new Array<vmRequestedProcedure>();

    public EpisodeActionObject: EpisodeAction = null;
    public EpisodeActionObjectID: string = null;
    public PatientObjecID: string = null;
    public PatientAdmissionObjecID: string = null;

    @Type(() => Date)
    public requestDate: Date = new Date();

    @Type(() => Boolean)
    public createNewProcedure: boolean;
}
