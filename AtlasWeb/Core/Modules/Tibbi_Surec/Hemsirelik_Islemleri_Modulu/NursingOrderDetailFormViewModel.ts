//$CF51C78F
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { NursingOrderDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from "NebulaClient/Model/AtlasClientModel";
import { VitalSignAndNursingValueDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import {VitalSignsValues} from '../Vital_Bulgular/VitalSingsFormViewModel';

export class NursingOrderDetailFormViewModel extends BaseViewModel {
    @Type(() => NursingOrderDetail)
    public _NursingOrderDetail: NursingOrderDetail = new NursingOrderDetail();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => VitalSignAndNursingValueDefinition)
    public VitalSignAndNursingValueDefinitions: Array<VitalSignAndNursingValueDefinition> = new Array<VitalSignAndNursingValueDefinition>();
    @Type(() => Number)
    public VitalSignAndNursingValueDefinitionListCount: number; //procedureonject ile ili�kili tan�ml� sonu� var m�
    public PatientFullName: string;
    @Type(() => Guid)
    public NursingApplicationCurrentState: Guid;
    @Type(() => VitalSignsValues)
    public VitalSignsValues: VitalSignsValues;

}
