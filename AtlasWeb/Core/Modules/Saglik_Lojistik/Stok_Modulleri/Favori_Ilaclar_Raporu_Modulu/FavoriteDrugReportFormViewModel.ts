import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class FavoriteDrugReportFormViewModel extends BaseViewModel {
    public SelectedDoctorList: Array <Guid> = new Array <Guid>();
    public SelectedDrug: Guid;
}

export class FavoriteDrug_Output{
    public DoctorName:string;
    public DrugName:string;
    public Amount: number;
}
