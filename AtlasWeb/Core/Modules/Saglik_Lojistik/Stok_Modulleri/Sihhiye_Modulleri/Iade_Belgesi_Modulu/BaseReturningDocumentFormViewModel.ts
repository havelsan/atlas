//$17A9A55C
import { ReturningDocument } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReturningDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';

export class BaseReturningDocumentFormViewModel extends BaseViewModel {
    @Type(() => ReturningDocument)
    public _ReturningDocument: ReturningDocument = new ReturningDocument();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => ReturningDocumentMaterial)
    public StockActionOutDetailsGridList: Array<ReturningDocumentMaterial> = new Array<ReturningDocumentMaterial>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
}
