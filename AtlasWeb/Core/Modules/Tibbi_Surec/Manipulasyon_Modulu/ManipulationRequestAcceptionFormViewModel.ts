//$D44A5009
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Manipulation } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { MedulaReportResult } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationReturnReasonsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class ManipulationRequestAcceptionFormViewModel extends BaseViewModel {
    @Type(() => Manipulation)
    public _Manipulation: Manipulation = new Manipulation();
    @Type(() => ManipulationProcedure)
    public GridManipulationsGridList: Array<ManipulationProcedure> = new Array<ManipulationProcedure>();
    @Type(() => MedulaReportResult)
    public MedulaReportResultsGridList: Array<MedulaReportResult> = new Array<MedulaReportResult>();
    @Type(() => ManipulationReturnReasonsGrid)
    public GridReturnReasonsGridList: Array<ManipulationReturnReasonsGrid> = new Array<ManipulationReturnReasonsGrid>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ManipulationRequest)
    public ManipulationRequests: Array<ManipulationRequest> = new Array<ManipulationRequest>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Object)
    public _selectedManipulationProcedureObject: Object;
    @Type(() => Boolean)
    public _isDoctor: boolean;
    @Type(() => Boolean)
    public _isSecretary: boolean;
    @Type(() => Boolean)
    public _isTechnician: boolean;
    @Type(() => Boolean)
    public _isSuperUser: boolean;
}
