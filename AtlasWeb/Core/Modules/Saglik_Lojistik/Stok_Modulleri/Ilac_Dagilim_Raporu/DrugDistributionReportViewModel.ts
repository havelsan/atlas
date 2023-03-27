import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { DrugUsageTypeEnum } from "app/NebulaClient/Model/AtlasClientModel";

export class DrugDistributionReportViewModel extends BaseViewModel {

}

export class DrugDistributionInputDTO{
    public selectedDrugObjectID:Guid;
    public startDate:Date;
    public endDate:Date;
}

export class patientHasDrugListDTO {
    public OutStatus: string;
    public PlannedStartTime: Date;
    public PlannedEndTime: Date;
    public DrugName: string;
    public EhuStatus: string;
    public Dose: string;
    public DoseAmount: string;
    public Day: string;
    public Amount: string;
    public Desciption: string;
    public IsImmediately: boolean;
    public PatientOwnDrug: boolean;
    public CaseOfNeed: boolean;
    public TreatmentType: DrugUsageTypeEnum;
    public DoctorName: string;
    public ClinikName: string;
    public MaterialType:string;
    public PatientNameSurname:string;

}