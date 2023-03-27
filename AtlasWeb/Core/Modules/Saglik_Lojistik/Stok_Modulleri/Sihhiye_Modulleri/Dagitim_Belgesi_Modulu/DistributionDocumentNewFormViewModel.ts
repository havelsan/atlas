//$5A1380B7
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { DistributionDocument } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionDocumentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class DistributionDocumentNewFormViewModel extends BaseViewModel  {
    @Type(() => DistributionDocument)
    public _DistributionDocument: DistributionDocument = new DistributionDocument();
    @Type(() => DistributionDocumentMaterial)
    public DistributionDocumentMaterialsGridList: Array<DistributionDocumentMaterial> = new Array<DistributionDocumentMaterial>();
    @Type(() => StockActionSignDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => StockLevelType)
    public StockLevelTypes: Array<StockLevelType> = new Array<StockLevelType>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public UTSEntegration: boolean;
}


export class GetUnsuccessfulDistributionDocumentsInputModel {
    @Type(() => Guid)
    public StoreId: Guid ;
}


export class GetUnsuccessfulDistributionDocument_Class {
    public StockActionID: number;
}

