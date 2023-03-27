
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ManipulationRequest } from 'NebulaClient/Model/AtlasClientModel';
import { ManipulationProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';


export class ManipulationRequestFormViewModel extends BaseViewModel {
    @Type(() => ManipulationRequest)
    public _ManipulationRequest: ManipulationRequest = new ManipulationRequest();
    @Type(() => ManipulationProcedure)
    public GridManipulationProceduresGridList: Array<ManipulationProcedure> = new Array<ManipulationProcedure>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => Object)
    public _selectedManipulationProcedureObject: Object;
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    //@Type(() => ResSection)
    //public ProcedureDepartments: Array<ResSection> = new Array<ResSection>();

}
