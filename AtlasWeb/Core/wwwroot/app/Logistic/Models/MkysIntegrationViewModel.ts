import { BaseModel } from 'Fw/Models/BaseModel';
import { DocumentTransactionTypeEnum, MKYSControlEnum, MKYS_EButceTurEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { MkysServis } from 'NebulaClient/Services/External/MkysServis';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';

export class MkysIntegrationViewModel extends BaseModel {
    DocumentRecordLogGridListItem: Array<DocumentRecordLogGridItem> = new Array<DocumentRecordLogGridItem>();
    ActiveAccountingTerm: ActiveAccountingTerm;
    StockActionDetailViews: Array<StockActionDetailView>;
    StockActionMkysCompareItems: Array<StockActionMkysCompareItem>;
    receivedDataSource: Array<ReceivedDataFromMkys> = new Array<ReceivedDataFromMkys>();

    hasRoleSendToMkys: boolean;
    hasRoleCompareToMkys: boolean;
    hasRoleMkysDocumentsFromInstitutions: boolean;
    hasRoleMkysEndOfYearCensus: boolean;
}


export class OutputMyStock {
    public stockcardObj: string;
    public tasinirKod: string;
    public malzemeAdi: string;
    public mevcut: string;
    public depoObjID: string;
    public calcInheld: number;
    public calcTotalIn: number;
    public calcTotalInPrice: number;
    public calcTotalOut: number;
    public calcTotalOutPrice: number;
}

export class QueryInputDVO {
    public accountingTermObjID: string;
    public isWithOutCancelled: boolean;
    public StoreID:string;
}
export class QueryMkysDVO {
    public mkysObject: Array<DocumentRecordLogGridItem>;
    public MKYSUserName: string;
    public MKYSUserPassword: string;
}
export class QueryMkysCompareItem {
    public stockActionID: string;
}

export class QueryMkysActionAllCompare {
    @Type(() => Date)
    public startDate: Date;
    @Type(() => Date)
    public endDate: Date;
    public stockActionID: string;
    public MKYSUserName: string;
    public MKYSUserPassword: string;
}

export class EndOfYearItem {
    @Type(() => Store)
    public store: Store;
    public year: string;
    public MKYSUserName: string;
    public MKYSUserPassword: string;
}

export class ActiveAccountingTerm {
    public AccountingTerm: string;
    public Desciption: string;
}

export class DocumentRecordLogGridItem {
    public ObjectID:Guid;
    public Subject: string;
    public DocumentRecordLogNumber: number;
    public DocumentTransactionType: DocumentTransactionTypeEnum;
    @Type(() => Date)
    public DocumentDateTime: Date;
    public ReceiptNumber: number;
    public StockAction: string;
    public StockActionID: string;
    public MKYSResultMsg: string;
    public MKYSControlType: MKYSControlEnum;
    public BudgetTypeName: MKYS_EButceTurEnum;
}
export class StockActionMkysCompareItem {
    public StockActionDetailViews: StockActionDetailView[];
    public StockActionID: string;
    public StockActionName: string;
    @Type(() => Date)
    public StockActionTransactionDate: Date;
    public colorEnum: MkysCompareResultColorEnum;
    public IsFaild: boolean;
}
export class StockActionDetailView {
    public CompareTaskItems: Array<CompareTaskItem>;
    public StokHareketID: number;
    public AyniyatMakbuzID: number;
    public MalzemeKayitID: number;
    public Material: string;
}
export class CompareTaskItem {
    public Subject: string;
    public MkysValue: string;
    public MyValue: string;
    public Result: boolean;
}
export enum MkysCompareResultColorEnum {
    red = 0,
    blue = 1
}


export class ReceivedDataFromMkys {
    public kurumlardanGelenDevirItem: MkysServis.kurumlardanGelenDevirItem;
    public turu: string;
    public cikisBelgeNo: number;
    public cikisBelgeTarihi: Date;
    public gonderenBirimAdi: string;
    public gonderenButceTuruAdi: string;
    public gonderenDepoAdi: string;
    public hareketTuru: string;
    public gonderenBirimID: number;
    public birimDepoID: number;
    public islemKayitNo: number;
    public devirGerceklestiMi: number;
    public details: Array<MkysServis.devirFisiItem>;
}
export class InputFor_ChattelDocumentCreate {
    public SelectedReceivedDataItems: Array<ReceivedDataFromMkys>;
    public Store: Store;
}
export class GetActiveAccountingTerm_Input {
    public storeObjectId: Guid;
}

export class GetYilSonuDevir_Output {
    public malzemeKayitID: number;
    public malzemeAdi: string;
    public malzemeKodu: string;
    public miktar: number;
    public atlasMiktar: number;
    public hata: string;
    public stokHaraketYilSonuItems: Array<MkysServis.stokHareketYilSonuItem>;
}

export class StockCensusForAtlas_Input {
    public stokHaraketYilSonuItems: Array<GetYilSonuDevir_Output>;
    public store: Store;
}