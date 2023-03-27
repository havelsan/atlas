//$4A710438
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ExtendExpDateIn } from "NebulaClient/Model/AtlasClientModel";
import { ExtendExpDateInDetail } from "NebulaClient/Model/AtlasClientModel";
import { StockActionSignDetail } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { BudgetTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Supplier } from "NebulaClient/Model/AtlasClientModel";
import { ResUser } from "NebulaClient/Model/AtlasClientModel";

export class BaseExtendExpDateInFormViewModel extends BaseViewModel {
    public _ExtendExpDateIn: ExtendExpDateIn = new ExtendExpDateIn();
    public ExtendExpDateInDetailsGridList: Array<ExtendExpDateInDetail> = new Array<ExtendExpDateInDetail>();
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    public Materials: Array<Material> = new Array<Material>();
    public BudgetTypeDefinitions: Array<BudgetTypeDefinition> = new Array<BudgetTypeDefinition>();
    public Stores: Array<Store> = new Array<Store>();
    public Suppliers: Array<Supplier> = new Array<Supplier>();
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
