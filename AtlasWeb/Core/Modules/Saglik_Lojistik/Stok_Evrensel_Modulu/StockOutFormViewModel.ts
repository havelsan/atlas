//$0DCC6253
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { StockOut } from "NebulaClient/Model/AtlasClientModel";
import { StockOutMaterial } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockLevelType } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";

export class StockOutFormViewModel extends BaseViewModel {
    public _StockOut: StockOut = new StockOut();
    public StockActionOutDetailsGridList: Array<StockOutMaterial> = new Array<StockOutMaterial>();
    public Materials: Array<Material> = new Array<Material>();
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    public Stores: Array<Store> = new Array<Store>();
}
