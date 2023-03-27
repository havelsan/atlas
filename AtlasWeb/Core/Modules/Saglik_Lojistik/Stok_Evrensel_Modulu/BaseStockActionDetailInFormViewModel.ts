//$BEAAAED9
import { StockActionDetailIn } from 'NebulaClient/Model/AtlasClientModel';
import { FixedAssetInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { QRCodeInDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Resource } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class BaseStockActionDetailInFormViewModel extends BaseViewModel {
      @Type(() => StockActionDetailIn)
    public _StockActionDetailIn: StockActionDetailIn = new StockActionDetailIn();
      @Type(() => FixedAssetInDetail)
    public FixedAssetDetailsGridList: Array<FixedAssetInDetail> = new Array<FixedAssetInDetail>();
      @Type(() => QRCodeInDetail)
    public QRCodeInDetailsGridList: Array<QRCodeInDetail> = new Array<QRCodeInDetail>();
      @Type(() => Resource)
    public Resources: Array<Resource> = new Array<Resource>();
      @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
      @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
}
