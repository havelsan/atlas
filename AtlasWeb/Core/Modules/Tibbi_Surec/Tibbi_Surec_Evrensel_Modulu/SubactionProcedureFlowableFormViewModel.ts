//$235E9323
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class SubactionProcedureFlowableFormViewModel extends BaseViewModel {
    @Type(() => SubactionProcedureFlowable)
    public _SubactionProcedureFlowable: SubactionProcedureFlowable = new SubactionProcedureFlowable();
}
