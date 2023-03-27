import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class DrugGenericReportViewModel extends BaseViewModel {

}
export class DrugGenericListInputDTO{
    public storeID:string;
    public genericID:Guid;
}

export class DrugListGeneric{
    public  DrugObjectID:Guid;
    public  GenericObjectID:Guid;
    public  GenericName:string;
    public  DrugName:string;
    public  Inheld:number;
    public Barcode:string;
}
