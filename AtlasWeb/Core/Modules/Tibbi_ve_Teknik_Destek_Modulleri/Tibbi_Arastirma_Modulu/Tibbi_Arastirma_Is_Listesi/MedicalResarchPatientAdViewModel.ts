import { Patient } from "app/NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class MedicalResarchPatientAdViewModel {

}

export class PatientAdInput_DTO {
    public medicalResarchPatient: Patient;
    public medicalResarchObjectID: string;
}

export class MRProcedureGridsDTO{
    public mRProcedurGridDTOs:Array<MRProcedurGridDTO> = new Array<MRProcedurGridDTO>();
    public mRCreateProcedurGridGridListDTOs:Array<MRCreateProcedurGridGridListDTO> = new Array<MRCreateProcedurGridGridListDTO>();
}

export class MRProcedurGridDTO {
    public procedureObjectID: Guid;
    public procedureName: string;

    public Code:string;
    public Price:string;
    public MedicalResarchPatientExObjectID:string;
}

export class MRCreateProcedurGridGridListDTO {
    public RequestDate: Date;
    public Code: string;
    public Name: string;
    public Amount: string;
    public Status: string;
    public ResaultValue: string;
    public Resault: string;
    public Price: string;
    public ObjectID:Guid;
    public ProcedureObjectID:string;
    public MedicalResarchPatientExObjectID:string;
    public MedicalResarchEpisodeObjectID:string;
}

export class MedicalResarchProcedurInputDTO
{
    public  objectID:string;
    public  procedureDefinitionObjectID:string;
    public  Amount:number;
    public  episodeActionObjectID:string;
    public  medicalResarchPatientExObjectID:string;
    public MedicalResarchEpisodeObjectID:string;
}