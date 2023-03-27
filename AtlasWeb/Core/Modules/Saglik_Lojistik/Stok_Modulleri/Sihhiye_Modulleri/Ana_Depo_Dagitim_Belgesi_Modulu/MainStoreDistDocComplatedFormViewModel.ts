//$ABEB8EA3
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { MainStoreDistributionDoc } from "NebulaClient/Model/AtlasClientModel";
import { DocumentRecordLog } from "NebulaClient/Model/AtlasClientModel";
import { MainStoreDistDocDetail } from "NebulaClient/Model/AtlasClientModel";
import { Store } from "NebulaClient/Model/AtlasClientModel";
import { Material } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { StockLevelType } from "NebulaClient/Model/AtlasClientModel";

export class MainStoreDistDocComplatedFormViewModel extends BaseViewModel {
    public _MainStoreDistributionDoc: MainStoreDistributionDoc = new MainStoreDistributionDoc();
    public ttgrid3GridList: Array<DocumentRecordLog> = new Array<DocumentRecordLog>();
    public MainStoreDistDocDetailsGridList: Array<MainStoreDistDocDetail> = new Array<MainStoreDistDocDetail>();
    public Stores: Array<Store> = new Array<Store>();
    public Materials: Array<Material> = new Array<Material>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
}
