import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class MedicalResarchTermDefViewModel {
  
    
}

export class MedicalResarchTermDataGridList{
    public termObjectID:Guid;
    public termCode:string;
    public termName:string;
}

export class MedicalResarchTermDefDTO
{
    public  ObjectId :Guid;
    public  TermName:string;
    public  StartDate:Date;
    public  EndDate:Date;
    public  TermCode:string;
    public  TermBudgetPrice:number;
    public  Desciption:string;
    public Status:boolean;
}
