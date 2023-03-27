import { BaseModel } from 'Fw/Models/BaseModel';
import { TransactionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { StockLevelTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { MinMaxCalcTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';



export class LogisticDashboardViewModel extends BaseModel {

    dashboardGridItemModel: Array<DashboardGridItemModel>;
    costActionSelectBox: Array<CostActionSelectBox>;
    architectureInfo: Array<ArchitectureInfo>;
    Store: string;
    Material: string;
    MinMaxMaterial: string;
    materialDetail: Array<MaterialDetail>;
    stockCikis: Array<StockCikis>;
    stockGiris: Array<StockGiris>;
    stockactionlist: Array<StockActionWorkListDashboardItemModel> = new Array<StockActionWorkListDashboardItemModel>();
    StockDataInformation: Array<StockDataInformation>;
    costActionAccountingTerm: Array<CostActionAccountingTerm>;
    IsMainStoreFlag: boolean;
    MaterialInheldMaxMin: Array<MaterialInheldMaxMin>;
    MinMaxCalcTypes: Array<MinMaxCalcTypeEnum> = new Array<MinMaxCalcTypeEnum>();
    selectedMinMaxCalc: MinMaxCalcTypeEnum;
    MinMaxCalculetedItems: Array<MinMaxCalculetedItem>;

    public hasRoleDashboardMaterialStatus: boolean;
    public hasRoleDashboardCostAction: boolean;
    public hasRoleDashboardMinMax: boolean;
    public hasRoleSubStoreExpDateUpdate: boolean;
    public hasRoleSubStoreWaitingWorks: boolean;
    public hasRoleOpenCloseTerm: boolean;
    public budgetTypeSources: Array<BudgetTypeSource>;
    public defaultBudgetType: BudgetTypeSource;
    public activeCostActionAccountingTerm: CostActionAccountingTerm;
}

export class DashboardGridItemModel {
    public ObjectID: string;
    public Material: string;
    public MaterialName: string;
    public AvarageUnitePrice: number;
    public DifAvarageUnitePrice: number;
    public MaterialPrice: number;
    public PreviousMonthPrice: number;
    public PreviousMothInheld: number;
    public ProfitAndLoss: number;
    public TotalAmount: number;
    public TotalOutAmunt: number;
    public TotalPrice: number;
    public TransferredAmount: number;

}

export class CostActionAccountingTerm {
    public ObjId: string;
    public Desciption: string;
    @Type(() => Date)
    public StartDate: Date;
}

export class CostActionSelectBox {
    public Objetid: string;
    public costActionDesciption: any;
}

export class BudgetTypeSource {
    public objectID: string;
    public name: string;
}

export class ArchitectureInfo {
    public yearKey: string;
    public year: string;
    public cluster: number;
    public ObjId: string;
    public MaterialName: string;
}

export class DashboardListItem {
    public ObjectDefName: string;
    public ObjectDefId: string;
}

export class QueryInputDVO {
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public ObjId: string;
    public Store: string;
    @Type(() => Date)
    public Months: Date;
    public selectMonth: boolean;
    public Material: string;
    public accountingTermObjId: string;
}

export class SubStoreWorksInputDVO {
    @Type(() => Date)
    public StartDate: Date;
    @Type(() => Date)
    public EndDate: Date;
    public ObjectID: string;
    public Store: string;
    public AllReport: Number;
}

export class SubStoreWorksOutputDVO {
    public StoreName: string;
    public StockActionID: number;
    public DestinationStore: string;
    @Type(() => Date)
    public WorklistDate: Date;
    public StateName: string;
    public ObjectName: string;
    @Type(() => Guid)
    public ObjectID: Guid;
}
export class MaterialDetail {
    public ObjectID: string;
    public Inheld: number;
    public totalIn: number;
    public totalOut: number;
    public totalInPrice: string;
    public totalOutPrice: string;
    public materialName: string;
    public barcode: string;
    public distibutiontype: string;
    public materialClasses: string;
    public materialMKYSCod: string;
    public storageConditions: string;
    public estimatedTimeOfCheck: string;
    public materialPicture: number[];
    public StockInheldMaxLevel: number;
    public StockInheldMinLevel: number;
    public StockDataInformation: Array<StockDataInformation>;
    public StockBudgetType: Array<StockBudgetType>;
    public StockDataLevelType: Array<StockDataLevelType>;

    public MaterialInheldMaxMin: Array<MaterialInheldMaxMin>;
}
export class StockBudgetType {
    public BudgetType: string;
    public Amount: number;
}
export class MaterialInheldMaxMin {
    public maxInheld: number;
    public minInheld: number;
    public inheld: number;
}
export class StockDataInformation {
    public LotNo: string;
    @Type(() => Date)
    public ExpirationDate: Date;
    public ResAmount: number;
}
export class StockDataLevelType {
    public StockLevelType: StockLevelTypeEnum;
    public Amount: number;
}


export class StockGiris {
    public Description: string;
    public Amount: number;
    public stockGirisDetayList: Array<StockGirisDetay>;
}

export class StockCikis {
    public Description: string;
    public Amount: number;
    public stockCikisDetayList: Array<StockCikisDetay>;
}

export class StockCikisDetay {
    public description: string;
    public amount: number;
}

export class StockGirisDetay {
    public description: string;
    public amount: number;
}


export class StockActionWorkListDashboardItemModel {

    public ObjectID: string;
    public StockActionID: number;
    public StockActionType: TransactionTypeEnum;
    public DestinationStore: string;
    public StockactionName: string;
    public PatientName: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public StateName: string;
    public StateFormName: string;
    public Amount: number;
}

export class DynamicComponentInfoDVO {
    public ComponentName: string;
    public ModuleName: string;
    public ModulePath: string;
    public objectID: string;
}

//VADEMECUM INSTANCES START POINT
export class QueryVademecumInteractionDVO {
    public episodeID: string;
    public prdList: Array<Product>;
    public diseaseList: Array<Disease>;
    public icdCodeList: Array<ICDCode>;
    public symptomList: Array<Symptom>;
    public nutritionList: Array<Nutrition>;
    public patientCharacteristics: PatientCharacteristics;
}

export class QueryVademecumInteractionDVONew {
    public episodeID: string;
    public prdList: Array<Guid>;
    public diseaseList: Array<Disease>;
    public icdCodeList: Array<ICDCode>;
    public symptomList: Array<Symptom>;
    public nutritionList: Array<Nutrition>;
    public patientCharacteristics: PatientCharacteristics;
}
export class VademecumProductDVO {
    public id: string;
}
export class Disease {
    public id: number;
}
export class ICDCode {
    public name: string;
}
export class Nutrition {
    public id: number;
}
export class PatientCharacteristics {
    public weight: number;
    public height: number;
    @Type(() => Date)
    public birthdate: Date;
    @Type(() => Date)
    public pregnancyDate: Date;
    public gender: string;
    public smokingHabit: boolean;
    public drugHabit: boolean;
    public pregnancyProbability: boolean;
    public breastFeeding: boolean;
    public contactLensUsage: boolean;
    public saltFreeDiet: boolean;
    public electroshockTherapy: boolean;
    public postpartumPeriod: boolean;
    public bloodDonation: boolean;
    public pregnant: boolean;
}
export class Product {
    public id: number;
}
export class Symptom {
    public id: number;
}
//VADEMECUM INSTANCES END POINT

export class MinMaxCalculetedItem {
    public StockObjectID: string;
    public MaterialName: string;
    public DistributionTypeName: string;
    public Inheld: number;
    public OutAmount: number;
    public MinLevel: number;
    public CriticalLevel: number;
    public MaxLevel: number;
    public CalcMinLevel: number;
    public CalcMaxLevel: number;
    public CalcCriticalLevel: number;
}
export class CalcMinMaxValueDVO {
    public id: string;
    public selectedType: MinMaxCalcTypeEnum;
    public StartDate: Date;
    public EndDate: Date;
    public materialObjectID: Array<string> = new Array<string>();
    public AllProducts: boolean;
    public StockHasInheld: boolean;
}
export class UpdateMinMaxValueDVO {
    public MinMaxCalculetedItems: Array<MinMaxCalculetedItem>;
}

export class InStockTransactionInput {
    public store: string;
    public materials: Array<string> = new Array<string>();
    public accountingTermObjId: string;
    public budgetTypeObjId: string;
    public isZeroAmount: boolean;
}

export class InStockTransactionDVO {
    public materialName: string;
    public restAmount: number;
    public unitPrice: number;
    public stockNo: string;
    @Type(() => Date)
    public transactionDate: Date;
    public inAmount: number;
    public outAmount: number;
    @Type(() => Date)
    public expirationDate: Date;
    public minLevel: number;
    public maxLevel: number;
    public barcode: string;
    public MKYSTrxID: number;
    public stockTransactionObjectID: Guid;
    public trxDescription: string;
    public destinationDescription: string;
    public auctionNo: string;
    public stockActionId: number;
    public tifNo: string;
    public stockTransactionListObjectID: Array<Guid>;

}

export class OutStockTransactionInput {
    public inStockTransactionID: string;
    public accountingTermObjId: string;
    public inStockTransactionListID: Array<string>;
}

export class OutStockTransactionDVO {
    @Type(() => Date)
    public transactionDate: Date;
    public trxType: string;
    public trxDescription: string;
    public storeName: string;
    public documentLogID: number;
    public stockActionID: number;
    public amount: number;
    @Type(() => Date)
    public expirationDate: Date;
    public stockTransactionObjectID: Guid;
}

export class SubStoreExpDateUpdate_Input {
    public materials: Array<string> = new Array<string>();
    public store: string;
    public beforeDay: number;
}

export class SubStoreExpDateUpdate_Output {
    public transactionObjectID: Guid;
    public materialName: string;
    public inheld: number;
    @Type(() => Date)
    public expDate: Date;
    public dayDiff: number;
    @Type(() => Date)
    public newExpDate: Date;
}
export class TransactionChartInputDTO {
    public StockInList = new Array<StockGiris>();
    public StockOutList = new Array<StockCikis>();
} 