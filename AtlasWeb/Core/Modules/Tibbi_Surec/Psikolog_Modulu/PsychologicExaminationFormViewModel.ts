//$B5A01C7B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PsychologicExamination } from 'NebulaClient/Model/AtlasClientModel';
import { PsychologyBasedObjectFormViewModel } from "./PsychologyBasedObjectFormViewModel";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { PsychologyTest } from 'NebulaClient/Model/AtlasClientModel';
import { ProcedureDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from "app/NebulaClient/ClassTransformer";


export class PsychologicExaminationFormViewModel extends BaseViewModel {
    @Type(() => PsychologicExamination)
    public _PsychologicExamination: PsychologicExamination = new PsychologicExamination();
    @Type(() => PsychologyBasedObjectFormViewModel)
    public psychologyBasedObjectFormViewModel: PsychologyBasedObjectFormViewModel;
    @Type(() => Guid)
    public PsychologyBasedObjectId: Guid;
    @Type(() => PsychologyTest)
    public PsychologyTestsGridList: Array<PsychologyTest> = new Array<PsychologyTest>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public DoctorStatement: string;
    public AppliedTest: string;
    public RequestByDoctorName: string ;
    public RequestDate: string ;
    @Type(() => Boolean)
    public isAuthorized: boolean;

}
