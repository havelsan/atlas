import { VoucherDistributingDocument } from 'NebulaClient/Model/AtlasClientModel';
import { Stock } from 'NebulaClient/Model/AtlasClientModel';
import { VoucherDistributingDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { UnitStoreGetData } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class VoucherDistributingDocumentNewFormViewModel extends BaseViewModel {
    public _VoucherDistributingDocument: VoucherDistributingDocument = new VoucherDistributingDocument();
    public StocksStockGridList: Stock[] = new Array<Stock>();
    public StocksStockGridGridList: Stock[] = new Array<Stock>();
    public StockActionOutDetailsGridList: VoucherDistributingDocumentMaterial[] = new Array<VoucherDistributingDocumentMaterial>();
    public StockActionSignDetailsGridList: StockActionSignDetail[] = new Array<StockActionSignDetail>();
    public Stores: Store[] = new Array<Store>();
    public UnitStoreGetDatas: UnitStoreGetData[] = new Array<UnitStoreGetData>();
    public Materials: Material[] = new Array<Material>();
    public StockCards: StockCard[] = new Array<StockCard>();
    public DistributionTypeDefinitions: DistributionTypeDefinition[] = new Array<DistributionTypeDefinition>();
    public StockLevelTypes: StockLevelType[] = new Array<StockLevelType>();
    public ResUsers: ResUser[] = new Array<ResUser>();
}
