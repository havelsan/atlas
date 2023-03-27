import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { MedicalResarchProcedur, MedicalResarchDoctor, MedicalResarchTermDef, ResUser } from "app/NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
export class MedicalResarchViewModel {

    public MedicalResarchDTO: MedicalResarchDTO;
    @Type(() => MedicalResarchTermDef)
    public MedicalResarchTermDef: MedicalResarchTermDef;
    @Type(() => MedicalResarchProcedur)
    public MedicalResarchProcedurList: Array<MedicalResarchProcedur>;
    @Type(() => MedicalResarchDoctor)
    public MedicalResarchDoctorList: Array<MedicalResarchDoctor>;
    @Type(() => ProcedureDefinitionDTO)
    public ProcedureDefList: Array<ProcedureDefinitionDTO>;
    @Type(() => ResUser)
    public DoctorResUserList: Array<ResUser>;
    public formIsReadOnly:boolean;
    public formName:string;

}

export class ProcedureDefinitionDTO{
    public Name:string;
    public ObjectID:Guid;
    public Code:string;
}

export class MedicalResarchDTO {
    public ObjectId: Guid;
    public Code: number;
    public PatientCount: number;
    public StartDate: Date;
    public EndDate: Date;
    public Desciption: string;
    public BudgetTotalPrice: number;
}

export class InputDTO {
    public MedicalResarchObjectID: string;
}

