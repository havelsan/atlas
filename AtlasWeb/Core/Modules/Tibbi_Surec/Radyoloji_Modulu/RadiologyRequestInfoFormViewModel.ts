//$13C3C6B8
import { Radiology } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { vmRequiredInfoFormProcedure } from "../Tetkik_Istem_Modulu/ProcedureRequestViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class RadiologyRequestInfoFormViewModel extends BaseViewModel {
    @Type(() => Radiology)
    public _Radiology: Radiology = new Radiology();
    @Type(() => Guid)
    public subActionObjectId: Guid;
    @Type(() => vmRequiredInfoFormProcedure)
    public requestedProcedure: vmRequiredInfoFormProcedure = new vmRequiredInfoFormProcedure();
}
