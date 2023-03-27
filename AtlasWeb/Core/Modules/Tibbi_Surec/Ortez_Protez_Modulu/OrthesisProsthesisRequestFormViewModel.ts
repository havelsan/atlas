//$8AA95C87
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { OrthesisProsthesisRequest } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesisProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { OrthesisProsthesis_ReturnDescriptionsGrid } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { SpecialityDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class OrthesisProsthesisRequestFormViewModel extends BaseViewModel {
    @Type(() => OrthesisProsthesisRequest)
    public _OrthesisProsthesisRequest: OrthesisProsthesisRequest = new OrthesisProsthesisRequest();
    @Type(() => OrthesisProsthesisProcedure)
    public OrthesisProsthesisProceduresGridList: Array<OrthesisProsthesisProcedure> = new Array<OrthesisProsthesisProcedure>();
    @Type(() => OrthesisProsthesis_ReturnDescriptionsGrid)
    public ReturnDescriptionGridGridList: Array<OrthesisProsthesis_ReturnDescriptionsGrid> = new Array<OrthesisProsthesis_ReturnDescriptionsGrid>();
    @Type(() => ResSection)
    public ResSections: Array<ResSection> = new Array<ResSection>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => Boolean)
    public HasDebt: boolean;
    public prevStateID: string;
    public RequesterUnit: string;
    public RequesterUserName: string;
}
