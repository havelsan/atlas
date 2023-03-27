//$63443740
import { StockAction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class StockActionBaseFormViewModel extends BaseViewModel {
      @Type(() => StockAction)
    public _StockAction: StockAction = new StockAction();
}
