//$83852E9C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';


export class OrthesisProsthesisCancelledFormViewModel extends BaseViewModel {
    @Type(() => OrthesisProsthesisRequest)
    public _OrthesisProsthesisRequest: OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
    @Type(() => OrthesisProsthesisProcedure)
    public OrthesisProsthesisProceduresGridList: Array<OrthesisProsthesisProcedure> = new Array<OrthesisProsthesisProcedure>();
    @Type(() => DiagnosisGrid)
    public GridEpisodeDiagnosisGridList: Array<DiagnosisGrid> = new Array<DiagnosisGrid>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => DiagnosisDefinition)
    public DiagnosisDefinitions: Array<DiagnosisDefinition> = new Array<DiagnosisDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
}
