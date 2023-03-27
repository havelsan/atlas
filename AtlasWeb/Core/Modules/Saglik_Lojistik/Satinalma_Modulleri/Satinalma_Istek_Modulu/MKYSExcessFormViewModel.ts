//$EF3444CE
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { SupplyRequestPoolDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class MKYSExcessFormViewModel extends BaseViewModel {
     @Type(() => SupplyRequestPoolDetail)
    public _SupplyRequestPoolDetail: SupplyRequestPoolDetail = new SupplyRequestPoolDetail();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
     @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
}
