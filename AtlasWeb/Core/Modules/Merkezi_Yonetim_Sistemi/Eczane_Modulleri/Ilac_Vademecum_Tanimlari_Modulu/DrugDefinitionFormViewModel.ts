//$EDB62D88
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { DrugDefinition, StockAction, DrugSpecificationEnum, MaterialDocumentation, StockLocation, DrugDrugInteraction, DrugFoodInteraction, DietMaterialDefinition, MaterialDocumentType, RevenueSubAccountCodeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DrugATC } from "NebulaClient/Model/AtlasClientModel";
import { DrugActiveIngredient } from "NebulaClient/Model/AtlasClientModel";
import { MaterialVatRate } from "NebulaClient/Model/AtlasClientModel";
import { DrugRelation } from "NebulaClient/Model/AtlasClientModel";
import { ManuelEquivalentDrug } from "NebulaClient/Model/AtlasClientModel";
import { DrugLabProcInteraction } from "NebulaClient/Model/AtlasClientModel";
import { DrugSpecifications } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { EtkinMadde } from "NebulaClient/Model/AtlasClientModel";
import { MaterialPrice } from "NebulaClient/Model/AtlasClientModel";
import { ATC } from "NebulaClient/Model/AtlasClientModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { UnitDefinition } from "NebulaClient/Model/AtlasClientModel";
import { RouteOfAdmin } from "NebulaClient/Model/AtlasClientModel";
import { GenericDrug } from "NebulaClient/Model/AtlasClientModel";
import { NFC } from "NebulaClient/Model/AtlasClientModel";
import { ActiveIngredientDefinition } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Producer } from "NebulaClient/Model/AtlasClientModel";
import { GMDNDefinition } from "NebulaClient/Model/AtlasClientModel";
import { LaboratoryTestDefinition } from "NebulaClient/Model/AtlasClientModel";
import { MaterialTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Material } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MaterialProcedures } from "NebulaClient/Model/AtlasClientModel";
import { ProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { DocumentGridModel } from "app/Logistic/Views/LogiscticDocumentComponents/LogisticDocumentUploadForm";



export class DrugDefinitionFormViewModel extends BaseViewModel {
    @Type(() => Guid)
    public EtkinMaddeObjectID: Guid = Guid.empty();
    @Type(() => Guid)
    public ProdureDefs: Array<Guid> = new Array<Guid>();

    public EtkinMaddeName: string;
    @Type(() => Int32Array)
    public DrugSpecs: Array<number> = new Array<number>();
    @Type(() => DrugDefinition)
    public _DrugDefinition: DrugDefinition = new DrugDefinition();
    @Type(() => DrugATC)
    public DrugATCsGridList: Array<DrugATC> = new Array<DrugATC>();
    @Type(() => DrugActiveIngredient)
    public DrugActiveIngredientsGridList: Array<DrugActiveIngredient> = new Array<DrugActiveIngredient>();
    @Type(() => MaterialVatRate)
    public MaterialVatRatesGridList: Array<MaterialVatRate> = new Array<MaterialVatRate>();
    @Type(() => DrugRelation)
    public DrugRelationsGridList: Array<DrugRelation> = new Array<DrugRelation>();
    @Type(() => ManuelEquivalentDrug)
    public ManuelEquivalentDrugsGridList: Array<ManuelEquivalentDrug> = new Array<ManuelEquivalentDrug>();
    @Type(() => DrugLabProcInteraction)
    public DrugLabProcInteractionsGridList: Array<DrugLabProcInteraction> = new Array<DrugLabProcInteraction>();

    @Type(() => DrugDrugInteraction)
    public DrugDrugInteractionsGridList: Array<DrugDrugInteraction> = new Array<DrugDrugInteraction>();
    @Type(() => DrugFoodInteraction)
    public DrugFoodInteractionsGridList: Array<DrugFoodInteraction> = new Array<DrugFoodInteraction>();

    @Type(() => DrugSpecifications)
    public grdDrugSpecificationGridList: Array<DrugSpecifications> = new Array<DrugSpecifications>();
    @Type(() => MaterialProcedures)
    public grdMaterialProceduresGridList: Array<MaterialProcedures> = new Array<MaterialProcedures>();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => StockCard)
    public StockCards: Array<StockCard> = new Array<StockCard>();
    @Type(() => DrugSpecifications)
    public DrugSpecifications: Array<DrugSpecifications> = new Array<DrugSpecifications>();
    @Type(() => DistributionTypeDefinition)
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    @Type(() => EtkinMadde)
    public EtkinMaddes: Array<EtkinMadde> = new Array<EtkinMadde>();
    @Type(() => ATC)
    public ATCs: Array<ATC> = new Array<ATC>();
    // @Type(() => DrugSpecifications)
    // public drugSpecs: DrugSpecifications = new DrugSpecifications();
    @Type(() => UnitDefinition)
    public UnitDefinitions: Array<UnitDefinition> = new Array<UnitDefinition>();
    @Type(() => RouteOfAdmin)
    public RouteOfAdmins: Array<RouteOfAdmin> = new Array<RouteOfAdmin>();
    @Type(() => GenericDrug)
    public GenericDrugs: Array<GenericDrug> = new Array<GenericDrug>();
    @Type(() => NFC)
    public NFCs: Array<NFC> = new Array<NFC>();
    @Type(() => ActiveIngredientDefinition)
    public ActiveIngredientDefinitions: Array<ActiveIngredientDefinition> = new Array<ActiveIngredientDefinition>();
    @Type(() => SpecialityDefinition)
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    @Type(() => Producer)
    public Producers: Array<Producer> = new Array<Producer>();
    @Type(() => GMDNDefinition)
    public GMDNDefinitions: Array<GMDNDefinition> = new Array<GMDNDefinition>();
    @Type(() => DrugDefinition)
    public DrugDefinitions: Array<DrugDefinition> = new Array<DrugDefinition>();
    @Type(() => LaboratoryTestDefinition)
    public LaboratoryTestDefinitions: Array<LaboratoryTestDefinition> = new Array<LaboratoryTestDefinition>();

    @Type(() => DrugDrugInteraction)
    public DrugDrugInteractions: Array<DrugDrugInteraction> = new Array<DrugDrugInteraction>();

    @Type(() => DrugFoodInteraction)
    public DrugFoodInteractions: Array<DrugFoodInteraction> = new Array<DrugFoodInteraction>();


    @Type(() => MaterialTreeDefinition)
    public MaterialTreeDefinitions: Array<MaterialTreeDefinition> = new Array<MaterialTreeDefinition>();
    //
    @Type(() => Material)
    public SelectedFilterMaterials: Array<Material> = new Array<Material>();
    @Type(() => DrugSpecifications)
    public DrugSpecificationGrid: Array<DrugSpecifications> = new Array<DrugSpecifications>();
    @Type(() => Material)
    public Material: Material = new Material();
    // @Type(() => MaterialPrice.MaterialPriceByMaterialForDefinition_Class)
    // public DrugLastCost = new Array<MaterialPrice.MaterialPriceByMaterialForDefinition_Class>();
    //public selecedDrugSpecification:Array<DrugSpecifications> = new Array<DrugSpecifications>();
    // @Type(() => Guid)
    // public AcitiveStoreId:Guid;
    @Type(() => ActiveIngredientDefinition)
    public ActiveIngredientList: Array<ActiveIngredientDefinition> = new Array<ActiveIngredientDefinition>();
    public MaterialSpecialtysList: Array<Guid> = new Array<Guid>();
    // @Type(() => DrugDefinition)
    // public EquivalentDrugList: Array<DrugDefinition> = new Array<DrugDefinition>();

    public MaterialDocumentations: Array<MaterialDocumentation> = new Array<MaterialDocumentation>();
    public MaterialAlerjikDocumentations: Array<MaterialDocumentation> = new Array<MaterialDocumentation>();
    @Type(() => DrugDefinition)
    public interactionDrugs: Array<DrugDefinition> = new Array<DrugDefinition>();

    @Type(() => DietMaterialDefinition)
    public dietMaterialDefinitions: Array<DietMaterialDefinition> = new Array<DietMaterialDefinition>();

    @Type(() => RevenueSubAccountCodeDefinition)
    public RevenueSubAccountCodeDef: RevenueSubAccountCodeDefinition = new RevenueSubAccountCodeDefinition();

    @Type(()=> MaxDoseByDrugDef)
    public MaxDoseByDrugDef:MaxDoseByDrugDef =new MaxDoseByDrugDef();
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
export class EquivalentMaterial {
    public Equivalent: string;
    public Drug: Guid;
}
export class GetReport {
    public StoreID: string;
    public MaterialID: string;
    public activeAccountingTerm: string;
    public accountingTermObjId: string;
}
export class InStockTransactionInput {
    public store: string;
    public materials: Array<string> = new Array<string>();
    public accountingTermObjId: string;
    public budgetTypeObjId: string;
    public isZeroAmount: boolean;
}

export class DefinitionInTrxDVO {
    @Type(() => Date)
    public TransactionDate: Date;
    public TIFNo: number;
    public SourceDescription: string;
    public Amount: number;
    public UnitPrice: number;
    @Type(() => Date)
    public ExpirationDate: Date;
    public MKYSTrxID: number;
    @Type(() => Guid)
    public StockTransactionObjectID: Guid;
    public TrxDescription: string;
    public StockActionID: number;
    public ReceiptNumber: number;
    @Type(() => Guid)
    public StockActionObjectid: Guid;
}
export class OutStockTransactionInput {
    public store: string;
    public materials: Array<string> = new Array<string>();
    public accountingTermObjId: string;
    public budgetTypeObjId: string;
    public isZeroAmount: boolean;
}

export class DefinitionOutTrxDVO {
    @Type(() => Date)
    public TransactionDate: Date;
    public TIFNo: number;
    public SourceDescription: string;
    public StockActionID: number;
    public ReceiptNumber: number;
    public Amount: number;
    public UnitPrice: number;
    public TrxDescription: string;
    @Type(() => Guid)
    public StockActionObjectid: Guid;
}

export class HospitalInventoryDVO {
    public StoreType: string;
    public StoreName: string;
    public Amount: number;
}
export class DrugDefinitionSelectBoxItem {
    public DisplayText: string;
    public Objectid: Guid;
}
export class ATCDVO {
    public ATCName: string;
    public ATCCode: string;
}

export class SaveShelfAndRowOnStock_Input {
    public MaterialID: Guid;
    public StoreID: Guid;
    public Shelf: number;
    public Row: number;
}
export class GetStockLocation_Input {
    public StockLocationName: string;
}

export class DrugSpecification_Input {
    public drugSpecificationNewArray: Array<DrugSpecificationEnum>;
    public drugDefinitionObjectid: DrugDefinition;
}

export class StoreLocationInformation_Input {
    public StockLocationID: Guid;
    public MaterialID: Guid;
    public StoreID: Guid;
    public StockObjID: Guid;
}
export class GetCriticalStockLevels_Class {
    public Inheld: Currency;
    public MinimumLevel: Currency;
    public CriticalLevel: Currency;
    public MaximumLevel: Currency;


}
export class GetStockLocation_Class {
    public ParentstockLocation: string;
    public StockLocation: string;

}
export class MaterialModelForMovableTransactionInput {
    public StockTransactionID: Guid;
    public StockActionObjectID: Guid;
    public StockActionID: number;
    public VoucherList: Array<StockAction> = new Array<StockAction>();;
    public MaterialObjectID: Guid;


}

export class DrugsFormViewModel {
    public accountingTermObjId: string;
    public StoreID: Guid;
    public BudgetType: Guid;
    public MaterialID: Guid;
    public isZeroAmount: boolean;
}
export class DrugDefinitionByEquivalentFormViewModel {
    public MaterialID: Guid;
}

export class DrugDefinitionByEquivalentDVO {
    public barcode: string;
    public MaterialID: Guid;
    public restAmount: number;
}
export class DrugsInFormViewModel {
    public accountingTermObjId: string;
    public MaterialID: Guid;
}
export class EquivalentMaterialFormViewModel {
    public Equivalent: string;
    public Drug: Guid;
}
export class DrugsInDVO {
    public accountingTermObjId: string;
    public MaterialID: Guid;
    public InAmount: number;
}
export class AmaountTotal {
    public Month: string;
    public InAmount: number;
    public OutAmount: number;
}
export class DrugsOutFormViewModel {
    public accountingTermObjId: string;
    public MaterialID: Guid;
}
export class DrugsOutDVO {
    public accountingTermObjId: string;
    public MaterialID: Guid;
    public InAmount: number;
}
export class UploadFile_Input {
    public File: any;
    public FileName: string;
    public Material: any;
    public FileUpdateDate: Date;
    public IsNew: Boolean;
    public MaterialDocumentType: MaterialDocumentType;
    public ObjectID: Guid;
}

export class MaterialProcedures_Output {
    public ObjectID: Guid;
    public Material: Material_Output;
    ProcedureDefinition: ProcedureDefinition_Output;
}
export class Material_Output {
    public ObjectID: Guid;
    public Name: string;
}
export class ProcedureDefinition_Output {
    public Name: string;
    public ObjectID: Guid;
    public Code: string;
    public ID: string;
}

export class FirstIN_Input {
    @Type(() => Guid)
    public MaterialObjectID: Guid;
    @Type(() => Guid)
    public StoreObjcetID: Guid;
}
export class RepaitUnUpdate_Intput {
    public unUpdatedPatienList: Array<pricePatienList>;
}
export class FirstInStockUnitePrice {
    public stockActionObjectid: Guid;
    public ObjectDefID: Guid;
    public ExpirationDate: Date;
    public TransactionDate: Date;
    public Tif: string;
    public UnitePrice: string;
}

export class pricePatienList {
    public AccTrxObjID: string;
    public PatientNameAndSurname: string;
    public PatientProtocolNo: string;
    public TrasnactionDate: Date;
    public OldPrice: string;
    public NewPrice: string;
    public Desciption: string;
}

export class pricePatientOutputDTO {
    public unUpdatedPatienList: Array<pricePatienList>;
    public UpdatedPatienList: Array<pricePatienList>;
    public totalUpdatePatientPriceCount: string;
    public priceEndDate: Date;
    public priceStartDate: Date;
}


export class LoadModelComponent {
    public MaxDoseByDrugDef: MaxDoseByDrugDef;
    public shelfAndRowOnStock: ShelfAndRowOnStock;
    public getStockLocationClasses: any[];
    public materialPrices: any[];
    public getEquivalents: any[];
    public getCritical: any;
    public materialProcedures: any[];
    public firstInStockUnitePrices: any[];
    public logDataSources: any[];
    public doSearchaccountingTerm: any;
    public drugSpecifications: any[];

    public routeOfAdminDataSource: any[];
    public nfcDataSource: any[];
}

export class MaxDoseByDrugDef {
    public InpatientMaxDoseOne: number;
    public InpatientMaxDoseTwo: number;
    public OutpatientMaxDoseOne: number;
    public OutpatientMaxDoseTwo: number;
}

export class ShelfAndRowOnStock {
    public Shelf: number;
    public Row: number;
    public StockLocationID: Guid;
    public StockLocation: StockLocation;
}

export class LoadModelComponent_Input {
    public MaterialID: Guid;
    public StoreID: Guid;
    public Shelf: number;
    public Row: number;
    public Equivalent: string;
}

export class OpenLogisticDocumentInputParams {
    public MaterialID: Guid;
    public DocumentType: MaterialDocumentType;
    public OldDocuments: Array<DocumentGridModel> = new Array<DocumentGridModel>();
}
