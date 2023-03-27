//$A5D38332
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SubactionProcedureFlowable } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class SubactionProcedureAppointmentFormViewModel extends BaseViewModel {
    @Type(() => SubactionProcedureFlowable)
    public _SubactionProcedureFlowable: SubactionProcedureFlowable = new SubactionProcedureFlowable();
}
