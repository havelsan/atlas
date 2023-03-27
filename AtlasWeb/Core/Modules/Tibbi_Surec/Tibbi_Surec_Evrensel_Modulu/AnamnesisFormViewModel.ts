//$48984D93
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { PhysicianApplication } from 'NebulaClient/Model/AtlasClientModel';
import { VitalSingsFormViewModel } from 'Modules/Tibbi_Surec/Vital_Bulgular/VitalSingsFormViewModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Type } from 'NebulaClient/ClassTransformer';

export class AnamnesisFormViewModel extends BaseViewModel {
    @Type(() => PhysicianApplication)
    public _PhysicianApplication: PhysicianApplication = new PhysicianApplication();
    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;
    @Type(() => Guid)
    public PatientID: Guid;

}

export class AnamnesisListInfo {
    @Type(() => Guid)
    public ObjectID: Guid ;
    public ProcessDate: string;
    public UnitName: string;
    public DoctorName: string;
}

export class AnamnesisPopUp {
    @Type(() => Object)
    public Complaint: Object;
    @Type(() => Object)
    public PatientHistory: Object;
    @Type(() => Object)
    public PhysicalExamination: Object;
    @Type(() => Object)
    public MTSConclusion: Object;
    @Type(() => VitalSingsFormViewModel)
    public vitalSingsViewModel: VitalSingsFormViewModel;
}