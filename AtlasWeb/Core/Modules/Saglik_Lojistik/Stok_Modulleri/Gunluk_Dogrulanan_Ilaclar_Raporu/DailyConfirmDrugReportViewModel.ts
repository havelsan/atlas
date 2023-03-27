import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";


export class DailyConfirmDrugReportViewModel extends BaseViewModel {

}

export class DrugOrderDailyConf {
    public DrugOrderObjectID: Guid;
    public DrugName: string;
    public Barcode: string;
    public ProtocolNo: string;
    public PatientNameSurname: string;
    public Frequency: string;
    public DoseAmount: string;
    public Clinic: string;
    public DoctorName: string;
    public PlannedStartTime: string;
    public State: string;
    public drugOrderDailyConfDetails: Array<DrugOrderDailyConfDetail> = new Array<DrugOrderDailyConfDetail>();
}

export class DrugOrderDailyConfDetail {
    public DetailNo: string;
    public DoseAmount: string;
    public State: string;
    public OrderPlannedDate: string;
}

