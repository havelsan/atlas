//$85B4F511
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseNursingDischargingInstructionPlan } from 'NebulaClient/Model/AtlasClientModel';
import { NursingDischargingInstructionPlan } from 'NebulaClient/Model/AtlasClientModel';
import { DischargingInstructionPlanDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseNursingDischargingInstructionPlanFormViewModel extends BaseViewModel {
    @Type(() => BaseNursingDischargingInstructionPlan)
    public _BaseNursingDischargingInstructionPlan: BaseNursingDischargingInstructionPlan = new BaseNursingDischargingInstructionPlan();
    @Type(() => NursingDischargingInstructionPlan)
    public NursingDischargingInstructionPlansGridList: Array<NursingDischargingInstructionPlan> = new Array<NursingDischargingInstructionPlan>();
    @Type(() => DischargingInstructionPlanDefinition)
    public DischargingInstructionPlanDefinitions: Array<DischargingInstructionPlanDefinition> = new Array<DischargingInstructionPlanDefinition>();
    public ReportCountControl: boolean = false;
}
