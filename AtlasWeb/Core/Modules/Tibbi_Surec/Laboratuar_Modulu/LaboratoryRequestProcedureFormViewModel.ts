//$E61A8D98
import { LaboratoryRequest } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { LaboratoryRejectReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { OzelDurum } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class LaboratoryRequestProcedureFormViewModel extends BaseViewModel {
    public _LaboratoryRequest: LaboratoryRequest = new LaboratoryRequest();
    public GridLabProceduresGridList: Array<LaboratoryProcedure> = new Array<LaboratoryProcedure>();
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    public LaboratoryRejectReasonDefinitions: Array<LaboratoryRejectReasonDefinition> = new Array<LaboratoryRejectReasonDefinition>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public OzelDurums: Array<OzelDurum> = new Array<OzelDurum>();
}
