import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Material, StockCard, StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class NewMaterialSelectComponentViewModel extends BaseModel {

}

export class NewMaterialSelectDTO {
    public Material: Material;
    public StockCard: StockCard;
    public StockLevelType: StockLevelType;
    public StoreStock :number;
    public DestinationStoreStock:number;
    public DestinationStoreMaxLevel: number;
    public VatRate:number;
}

