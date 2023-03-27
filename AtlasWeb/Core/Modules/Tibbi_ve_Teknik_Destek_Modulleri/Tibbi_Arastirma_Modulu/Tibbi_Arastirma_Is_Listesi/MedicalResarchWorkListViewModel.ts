//$DB89F690
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { MedicalResarchTermDef, Patient } from 'app/NebulaClient/Model/AtlasClientModel';

export class MedicalResarchWorkListViewModel  {
    public PatientObjectID: string;
    public ProtocolNo:string;
} 

export class ResarchWorkList_Input{
    public MedicalResarchCode:string;
    public MedicalResarchTermDef:MedicalResarchTermDef;
    
}

export class MedicalResarchActionListDTO{
    public Code:string;
    public BudgetTotalPrice:number;
    public Name:string;
    public PatientCount:number;
    public TermName:string;
    public Status:string;
    public ObjectID:Guid;
}


export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
}

export class ResarchPatientWorkList_Input{
    public MedicalResarchCode:string;
    public MedicalResarchTermDef:MedicalResarchTermDef;
    public SelectedPatient:Patient;
}

export class MedicalResarchActionPatientWorkListDTO
{
    public ObjectID:Guid;
    public  MedicalResarchCode:string;
    public  MedicalResarchName:string;
    public  PatientNameSurname:string;
    public  PatientProtocolNo:string;
    public  PatientBudgetPrice:string;
    public  PatientStatus:string;
}
