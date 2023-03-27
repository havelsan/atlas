import { BaseModel } from 'Fw/Models/BaseModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { Accountancy, Supplier } from 'app/NebulaClient/Model/AtlasClientModel';


export class LogisticAddAndUpdateViewModel extends BaseModel {
    returnAccountancy: ReturnAccountancy;
    returnSupplier: ReturnSupplier;
    returnStockCard: ReturnStockCard;
    StockFirstInGridItemList: Array<StockFirstInGridItem>;
    StockFirstInDetailGridItemList: Array<StockFirstInDetailGridItem>;
}

export class StockCardType {
    public StockCardTypeString: string;
    @Type(() => Date)
    public StockCardDateTime: Date;
    public MKYSPassword: string;
}

export class ReturnAccountancy {
    public NewAccountancyList: Array<ReturnAccountancyItem>;
    public UpdateAccountancyList: Array<ReturnAccountancyItem>;
}
export class ReturnAccountancyItem {
    public AccountancyCode: string;
    public AccountancyNO: string;
    public AccountancyName: string;
}
export class CreateMkysKurumlari_InputDVO {
    public CreateAccountancyList: Array<ReturnAccountancyItem>;
}
export class CreateMkysKurumlari_OutputDVO {
    public returnMessage: string;
}
export class UpdateMkysKurumlari_InputDVO {
    public UpdateAccountancyList: Array<ReturnAccountancyItem>;
}
export class UpdateMkysKurumlari_OutputDVO {
    public returnMessage: string;
}


export class ReturnSupplier {
    public NewSupplierList: Array<ReturnSupplierItem>;
    public UpdateSupplierList: Array<ReturnSupplierItem>;
}
export class ReturnSupplierItem {
    public GLNNo: string;
    public Name: string;
    public TaxNo: string;
    public TaxOfficeName: string;
}
export class CreateMkysFirma_InputDVO {
    public CreateSupplerList: Array<ReturnSupplierItem>;
}
export class CreateMkysFirma_OutputDVO {
    public returnMessage: string;
}
export class UpdateMkysFirma_InputDVO {
    public UpdateSupplierList: Array<ReturnSupplierItem>;
}
export class UpdateMkysFirma_OutputDVO {
    public returnMessage: string;
}



export class ReturnStockCard {
    public NewStockCardList: Array<StockCardItem>;
    public UpdateStockCardList: Array<StockCardItem>;
}
export class StockCardItem {
    public StockCardName: string;
    public StockCardCode: string;
    public StockCardDistribution: string;
    public MKYSKayitID: number;
    public isActive: boolean;
    public Ilac: boolean;
    public Desciption: string;
    public UpdateStockCardObjectID: Guid;
}
export class CreateMkysStockCard_InputDVO {
    public CreateStockCardList: Array<StockCardItem>;
}
export class CreateMkysStockCard_OutputDVO {
    public returnMessage: string;
}
export class UpdateMkysStockCard_InputDVO {
    public UpdateStockCardList: Array<StockCardItem>;
}
export class UpdateMkysStockCard_OutputDVO {
    public returnMessage: string;
}

export class UTS_SynchronizeMaterials_Input {
    public StartDate: string;
    public EndnDate: string;
    public UTSSinif1: boolean;
    public UTSSinif2: boolean;
    public UTSSinif3: boolean;
}

export class StockFirstInGridItem {
    public stockActionObjID: string;
    public stockActionNo: string;
}

export class StockFirstInDetailGridItem {
    public StockActionDetailObjID: string;
    @Type(() => Date)
    public ExpirationDate: Date;
    public MaterialName: string;
    public OldPrice: string;
    public Amount: string;
    public NewPrice: string;
    public MKYS_StokHareketID: string;
    public NatoStockNo: string;
    public Barcode: string;
}

export class ReturnFirstStockIn_Input {
    public mainStoreDefinition: string;
}
export class GetDetailsOfFirstStockIn_Input {
    public stockActionObjID: string;
}

export class UpdateUnitPriceForSelectedItems_Input {
    public StockFirstInDetailGridItems: Array<StockFirstInDetailGridItem>;
}

export class UTSMaterialGridDataModel {
    public Barcode: string;
    public Materialname: string;
    public Producername: string;
}

export class UTSUnusedGridDataModel {
    public ProtocolNo: string;
    public MaterialName: string;
    public Barcode: string;
    public LotNo: string;
    public Amount: string;
    public UTSAlmaBildirimID: string;
    public StockActionID: string;
    public MKYSTifNo: string;
    public UTSAmount: string;
    public StockActionObjID: string;
    public StockTransactionID: string;
    @Type(() => Guid)
    public SubActionMaterailObjID: Guid;
    public UTSErrorMessege: string;
}
export class UTSUnlist_Input {
    @Type(() => Date)
    public UTSUsedStartDate: Date;
    @Type(() => Date)
    public UTSUsedEndDate: Date;
}

export class ENabizMaterialGrid {
    public ProtocolNO: string;
    public SendDate: string;
    public ResponseMessage: string;
    public MaterialBarcode: string;
    public MaterialName: string;
    public ApplicationDate: string;
    public RequestDate: string;
}

export class ENabizMaterialInput {
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
}

export class InputPriceDTO {
    @Type(() => Date)
    public startDateOfPrice: Date;
    public selectedMaterials: Array<UpdateMaterialPriceListDTO>;
}

export class UpdateMaterialPriceListDTO {
    public ObjectID: Guid;
    public Code: string;
    public MaterialName: string;
    public Price: number;
    public DiscountPercent: number;

}

export class StockActionInDetailDTO {
    @Type(() => Guid)
    public ObjectID: Guid;
    public MaterialName: string;
    public NATOStockNO: string;
    public Barcode: string;
    public DistributionTypeName: string;
    public OldAmount: number;
    public Amount: number;
    public OldUnitPriceWithOutVat: number;
    public UnitPriceWithOutVat: number;
    public OldVatRate: number;
    public VatRate: number;
    public UnitPriceWithInVat: number;
    public DiscountRate: number;
    public NotDiscountedUnitPrice: number;
    public UnitPrice: number;
    public DiscountAmount: number;
    public Price: number;
}

export class GetStockActionInDetails_Input{
    public stockActionID: string;
}

export class GetStockActionInDetails_Output{
    public error: boolean;
    public errorMessage: string;
    public stockActionDetails: Array<StockActionInDetailDTO> = new Array<StockActionInDetailDTO>();
}

export class UpdateStockActionInDetails_Input{
    public stockActionDetails: Array<StockActionInDetailDTO> = new Array<StockActionInDetailDTO>();
}


export class GetCovid19StockAction_Input{
    public covid19StockActionID: string;
    public covid19TifID:string;
    public covid19StoreID:Guid;

}

export class GetCovid19StockAction_Output {
    ActionType:number; //Satınalma:1,TaşınırGiriş:2
    DocumentDateTime: string;
    AuctionDate: Date;
    RegistrationAuctionNo: string;
    ExaminationReportDate: Date;
    ExaminationReportNo: string;
    WaybillDate: Date;
    Waybill: string;
    Description: string;
    MKYS_TeslimAlan: string;
    MKYS_TeslimEden: string;
    Accountancy: Accountancy;
    DetailsCovid19: StockActionDetailCovid19[];
    Supplier: Supplier;
    ReceiptNumber:string;
    StockActionObjectID:Guid;
    DocumentRecordLogID:Guid;
    DocumentRecordLogNumber:string;
    StockActionID:string;
}

export class StockActionDetailCovid19 {
    MaterialName: string;
    MaterialObjectID: string;
    StockActionDetailID: string;
    NotDiscountedUnitPrice: number;
    DiscountRate: number;
    VatRate: number;
    MKYS_StokHareketID: number;
    Amount:number;
    Barcode:string;
    NatoStockNo:string;
    TotalPrice:number;
    UnitePrice:number;
}

export class UpdateStockActionCovid19_Input {
    stockActionObjectID: Guid;
    DocumentRecordLogID:Guid;
    covid19ActionChange: GetCovid19StockAction_Output;
    mkyspass:string;
}