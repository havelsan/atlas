import { RadiologyTest, LaboratoryProcedure, ProcedureDefinition, PsychologyTest, PathologyTestProcedure, NuclearMedicineTest, ManipulationProcedure, RadiologyTestTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class ProceduresRequiredInfoViewModel {
    @Type(() => RadiologyTest)
    RadiologyTestList: Array<RadiologyTest> = new Array<RadiologyTest>();
    @Type(() => LaboratoryProcedure)
    LaboratoryTestList: Array<LaboratoryProcedure> = new Array<LaboratoryProcedure>();
    @Type(() => ProcedureDefinition)
    ProcedureObjectList: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => PsychologyTest)
    PsychologyProcedureList: Array<PsychologyTest> = new Array<PsychologyTest>();
    @Type(() => PathologyTestProcedure)
    PathologyProcedureList: Array<PathologyTestProcedure> = new Array<PathologyTestProcedure>();
    @Type(() => NuclearMedicineTest)
    NuclearMedicineTestList: Array<NuclearMedicineTest> = new Array<NuclearMedicineTest>();
    @Type(() => ManipulationProcedure)
    ManipulationProcedureList: Array<ManipulationProcedure> = new Array<ManipulationProcedure>();
    @Type(() => RadiologyTestTypeDefinition)
    RadiologyTestTypeDefinitions: Array<RadiologyTestTypeDefinition> = new Array<RadiologyTestTypeDefinition>();
    
    ClinicAnemnesis: string;
    @Type(() => Boolean)
    copyDescription: boolean;
    textDescription: string;
}