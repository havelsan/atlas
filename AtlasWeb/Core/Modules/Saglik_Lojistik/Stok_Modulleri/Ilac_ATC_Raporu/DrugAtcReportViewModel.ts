import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class DrugAtcReportViewModel extends BaseViewModel {

}
export class DrugListInputDTO{
    public storeID:string;
    public atcID:Guid;
}

export class DrugList{
    public  DrugObjectID:Guid;
    public  AtcObjectID:Guid;
    public  ATCName:string;
    public  DrugName:string;
    public  Inheld:number;
    public Barcode:string;
}
