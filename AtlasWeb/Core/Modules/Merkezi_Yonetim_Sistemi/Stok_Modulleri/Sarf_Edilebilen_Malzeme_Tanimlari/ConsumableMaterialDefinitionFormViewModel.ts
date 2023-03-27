//$FA4C1124
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { ConsumableMaterialDefinition, Material, MaterialDocumentation, ProcedureDefinition, MaterialProcedures, StockLocation, RevenueSubAccountCodeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { MaterialSpecialty } from "NebulaClient/Model/AtlasClientModel";
import { MaterialVatRate } from "NebulaClient/Model/AtlasClientModel";
import { MaterialProductLevel } from "NebulaClient/Model/AtlasClientModel";
import { MaterialSpecialtyDef } from "NebulaClient/Model/AtlasClientModel";
import { MaterialPurposeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { MaterialPlaceOfUseDef } from "NebulaClient/Model/AtlasClientModel";
import { SpecialityDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Producer } from "NebulaClient/Model/AtlasClientModel";
import { GMDNDefinition } from "NebulaClient/Model/AtlasClientModel";
import { ProductDefinition } from "NebulaClient/Model/AtlasClientModel";
import { StockCard } from "NebulaClient/Model/AtlasClientModel";
import { DistributionTypeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { MaterialTreeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { MalzemeTuru } from "NebulaClient/Model/AtlasClientModel";
import { Type } from "app/NebulaClient/ClassTransformer";
export class ConsumableMaterialDefinitionFormViewModel extends BaseViewModel {
    public _ConsumableMaterialDefinition: ConsumableMaterialDefinition = new ConsumableMaterialDefinition();
    public MaterialSpecialtysGridList: Array<MaterialSpecialty> = new Array<MaterialSpecialty>();
    public MaterialVatRatesGridList: Array<MaterialVatRate> = new Array<MaterialVatRate>();
    public MaterialProductLevelsGridList: Array<MaterialProductLevel> = new Array<MaterialProductLevel>();
    public MaterialSpecialtyDefs: Array<MaterialSpecialtyDef> = new Array<MaterialSpecialtyDef>();
    public MaterialPurposeDefinitions: Array<MaterialPurposeDefinition> = new Array<MaterialPurposeDefinition>();
    public MaterialPlaceOfUseDefs: Array<MaterialPlaceOfUseDef> = new Array<MaterialPlaceOfUseDef>();
    public ConsumableMaterialDefinitions: Array<ConsumableMaterialDefinition> = new Array<ConsumableMaterialDefinition>();
    public SpecialityDefinitions: Array<SpecialityDefinition> = new Array<SpecialityDefinition>();
    public Producers: Array<Producer> = new Array<Producer>();
    public GMDNDefinitions: Array<GMDNDefinition> = new Array<GMDNDefinition>();
    public ProductDefinitions: Array<ProductDefinition> = new Array<ProductDefinition>();
    public StockCards: Array<StockCard> = new Array<StockCard>();
    public DistributionTypeDefinitions: Array<DistributionTypeDefinition> = new Array<DistributionTypeDefinition>();
    public MaterialTreeDefinitions: Array<MaterialTreeDefinition> = new Array<MaterialTreeDefinition>();
    public MalzemeTurus: Array<MalzemeTuru> = new Array<MalzemeTuru>();
    public MaterialPriceDetail: MaterialPriceDetail = new MaterialPriceDetail();
    @Type(() => ProcedureDefinition)
    public ProcedureDefinitions: Array<ProcedureDefinition> = new Array<ProcedureDefinition>();
    @Type(() => MaterialProcedures)
    public grdConsumableMaterialProceduresGridList: Array<MaterialProcedures> = new Array<MaterialProcedures>();

    public MaterialDocumentations: Array<MaterialDocumentation> = new Array<MaterialDocumentation>();
    public MaterialSpecialtysList: Array<Guid> = new Array<Guid>();

    public ConsMaterialEquvalentList: Array<Guid> = new Array<Guid>();
    public MaterialVatRateIn: number;

    @Type(() => Guid)
    public ProdureDefs: Array<Guid> = new Array<Guid>();

    @Type(() => RevenueSubAccountCodeDefinition)
    public RevenueSubAccountCodeDef: RevenueSubAccountCodeDefinition = new RevenueSubAccountCodeDefinition();


    public MaterialTreeDefList: Array<MaterialTreeDefinition> = new Array<MaterialTreeDefinition>();
    public MaterialNewPrice: number;
}

export class ConsumableMaterialDefinitionQueryFilter {
    public IsActive: number = -1;
    public ShowZeroOnDrugOrder: number = -1;
    public IsInheld: number = -1;
    public ShowZeroDistributionInfo: number = -1;
    public ActionStatus: number = -1;
    public StoreID: string;
}

export class MaterialPriceDetail {
    public MaterialPrice: number;
}
export class UploadFile_Input {
    public File: any;
    public FileName: string;
    public Material: any;
    public FileUpdateDate: Date;
    public IsNew: Boolean;
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

export class FirstInStockUnitePriceConsumableMaterial {
    public stockActionObjectid: Guid;
    public ObjectDefID: Guid;
    public ExpirationDate: Date;
    public TransactionDate: Date;
    public Tif: string;
    public UnitePrice: string;
}

export class LoadModelComponentConsumableMaterial {
    public shelfAndRowOnStock: ShelfAndRowOnStock;
    public getStockLocationClasses: any[];
    public materialPrices: any[];
    public equivalentMaterialList: any[];
    public getCritical: any;
    public materialProcedures: any[];
    public firstInStockUnitePrices: any[];
    public logDataSources: any[];
    public doSearchaccountingTerm: any;
    public drugSpecifications: any[];
    public MaterialTypeListIsGroupList: any[];
    public MaterialTreeDefinitions: any[];
    public MaterialSpecialtyList: any[];


}

export class ShelfAndRowOnStock {
    public Shelf: number;
    public Row: number;
    public StockLocationID: Guid;
    public StockLocation: StockLocation;
}

export class LoadModelComponentConsumableMaterial_Input {
    public MaterialID: Guid;
    public StoreID: Guid;
    public Shelf: number;
    public Row: number;
}

export class UpdateMaterialPriceOutput {
    public Price: number;
    public Desciption: string;
    public Code: string;
    public SutAppandix: string;
    public ActivationData: string;
}

export class MaterialPriceByMedulaSUT_Input {
    public updateMaterialPriceOutput: UpdateMaterialPriceOutput;
}


export class RepaitUnUpdate_Intput {
    public unUpdatedPatienList: Array<pricePatienList>;
}

/* export class AuditDataSource {
    public lastUpdateDate: Date;
    public lastUpdateUser: string;
    public creationDate: Date;
    public creationUser: string;
} */

