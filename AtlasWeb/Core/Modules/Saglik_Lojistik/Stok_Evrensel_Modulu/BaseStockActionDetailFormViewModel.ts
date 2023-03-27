//$6ACC1BD6
import { StockActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class BaseStockActionDetailFormViewModel extends BaseViewModel {
     @Type(() => StockActionDetail)
    public _StockActionDetail: StockActionDetail = new StockActionDetail();
     @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
     @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
}
