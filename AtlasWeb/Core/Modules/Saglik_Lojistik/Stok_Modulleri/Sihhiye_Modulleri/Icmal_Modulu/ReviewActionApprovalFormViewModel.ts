//$55BD35B5
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ReviewAction } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReviewActionPatientDet } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class ReviewActionApprovalFormViewModel extends BaseViewModel  {
    @Type(() => ReviewAction)
    public _ReviewAction: ReviewAction = new ReviewAction();
    @Type(() => ReviewActionDetail)
    public ReviewActionDetailsGridList: Array<ReviewActionDetail> = new Array<ReviewActionDetail>();
    @Type(() => ReviewActionPatientDet)
    public ReviewActionPatientDetsGridList: Array<ReviewActionPatientDet> = new Array<ReviewActionPatientDet>();
    @Type(() => Material)
    public Materials: Array<Material> = new Array<Material>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
}
