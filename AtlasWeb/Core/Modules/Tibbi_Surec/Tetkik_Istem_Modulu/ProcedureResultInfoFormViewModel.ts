//$C2251E48
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ProcedureResultInfo } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class ProcedureResultInfoFormViewModel extends BaseViewModel {
    protected __type__: string = 'Core.Models.ProcedureResultInfoFormViewModel, Core';
    @Type(() => ProcedureResultInfo)
    public _ProcedureResultInfo: ProcedureResultInfo = new ProcedureResultInfo();
}
