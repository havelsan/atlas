//$2262FDD8
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class LaboratoryRequestResultFormViewModel extends BaseViewModel {
    public _LaboratoryRequest: LaboratoryRequest = new LaboratoryRequest();
    public GridLabProceduresGridList: Array<LaboratoryProcedure> = new Array<LaboratoryProcedure>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
