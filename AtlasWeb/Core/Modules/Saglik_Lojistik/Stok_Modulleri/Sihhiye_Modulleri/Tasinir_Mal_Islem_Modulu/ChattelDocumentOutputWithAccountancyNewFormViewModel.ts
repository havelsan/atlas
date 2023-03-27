//$4FC6001C
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ChattelDocumentOutputWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ChattelDocumentOutputDetailWithAccountancy } from 'NebulaClient/Model/AtlasClientModel';
import { StockActionSignDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { StockCard } from 'NebulaClient/Model/AtlasClientModel';
import { DistributionTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelType } from 'NebulaClient/Model/AtlasClientModel';
import { Accountancy } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from "app/NebulaClient/Mscorlib/Guid";

export class ChattelDocumentOutputWithAccountancyNewFormViewModel extends BaseViewModel {
    @Type(() => ChattelDocumentOutputWithAccountancy)
    public _ChattelDocumentOutputWithAccountancy: ChattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy();
    @Type(() => ChattelDocumentOutputDetailWithAccountancy)
    public ChattelDocumentDetailsWithAccountancyGridList: Array<ChattelDocumentOutputDetailWithAccountancy> = new Array<ChattelDocumentOutputDetailWithAccountancy>();
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
    @Type(() => Accountancy)
    public Accountancys: Array<Accountancy> = new Array<Accountancy>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    public OuttableLotList: Array<OuttableLotDTO> = new Array<OuttableLotDTO>();
    public QRCodeReadList: Array<QRCodeReadDTO> = new Array<QRCodeReadDTO>();
}

export class OuttableLotDTO {
    public Amount: number;
    public RestAmount: number;
    public BudgetTypeName: string;
    public ExpirationDate: Date;
    public LotNo: string;
    public SerialNo: string;
    @Type(() => Guid)
    public TrxObjectID: Guid;
    public StockActionDetailOrderNo: number;
}

export class QRCodeReadDTO {
    public Barcode: string;
    public LotNo:string;
    public ExpirationDate: Date;
    public SerialNo: string;
    public Amount: number;
    @Type(() => Guid)
    public MaterialObjectID: Guid;
}
