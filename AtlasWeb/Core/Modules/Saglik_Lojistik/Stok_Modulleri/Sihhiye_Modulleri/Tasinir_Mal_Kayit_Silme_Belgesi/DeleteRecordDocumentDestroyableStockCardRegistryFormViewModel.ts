//$F8CF74AB
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DeleteRecordDocumentDestroyable } from 'NebulaClient/Model/AtlasClientModel';
import { DeleteRecordDocumentDestroyableMaterialOut } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionInspection } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class DeleteRecordDocumentDestroyableStockCardRegistryFormViewModel extends BaseViewModel {
    @Type(() => DeleteRecordDocumentDestroyable)
    public _DeleteRecordDocumentDestroyable: DeleteRecordDocumentDestroyable = new DeleteRecordDocumentDestroyable();
    @Type(() => DeleteRecordDocumentDestroyableMaterialOut)
    public StockActionOutDetailsGridList: Array<DeleteRecordDocumentDestroyableMaterialOut> = new Array<DeleteRecordDocumentDestroyableMaterialOut>();
    @Type(() => StockActionInspectionDetail)
    public StockActionSignDetailsGridList: Array<StockActionSignDetail> = new Array<StockActionSignDetail>();
    @Type(() => StockActionInspectionDetail)
    public StockActionInspectionDetailsStockActionInspectionDetailGridList: Array<StockActionInspectionDetail> = new Array<StockActionInspectionDetail>();
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
    @Type(() => Store)
    public Stores: Array<Store> = new Array<Store>();
    @Type(() => StockActionInspection)
    public StockActionInspections: Array<StockActionInspection> = new Array<StockActionInspection>();
    public mkysPwd: string;
}
