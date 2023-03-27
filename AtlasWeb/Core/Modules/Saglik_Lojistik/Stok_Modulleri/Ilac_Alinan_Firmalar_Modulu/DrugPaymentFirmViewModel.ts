import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { Material } from "app/NebulaClient/Model/AtlasClientModel";

export class DrugPaymentFirmViewModel extends BaseViewModel {

}

export class DrugPaymentFirmList {
    public Materialname: string;
    public Barcode: string;
    public Amount: string;
    public Transactiondate:Date;
    public Stockactionid: string;
    public Suppliername: string;
}

export class DrugPaymentInputDTO{
    public StartDate:Date;
    public EndDate:Date;
    public Materials: Array<Material>;
    public SupplierObjectID:Guid;
}
