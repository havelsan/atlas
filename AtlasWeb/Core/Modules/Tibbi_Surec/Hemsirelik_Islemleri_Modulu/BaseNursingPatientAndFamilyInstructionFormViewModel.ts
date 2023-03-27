//$BD3A1C02
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BaseNursingPatientAndFamilyInstruction } from 'NebulaClient/Model/AtlasClientModel';
import { NursingPatientAndFamilyInstruction } from 'NebulaClient/Model/AtlasClientModel';
import { PatientAndFamilyInstructionDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseNursingPatientAndFamilyInstructionFormViewModel extends BaseViewModel {
    @Type(() => BaseNursingPatientAndFamilyInstruction)
    public _BaseNursingPatientAndFamilyInstruction: BaseNursingPatientAndFamilyInstruction = new BaseNursingPatientAndFamilyInstruction();
    @Type(() => NursingPatientAndFamilyInstruction)
    public NursingPatientAndFamilyInstructionsGridList: Array<NursingPatientAndFamilyInstruction> = new Array<NursingPatientAndFamilyInstruction>();
    @Type(() => PatientAndFamilyInstructionDefinition)
    public PatientAndFamilyInstructionDefinitions: Array<PatientAndFamilyInstructionDefinition> = new Array<PatientAndFamilyInstructionDefinition>();
}
