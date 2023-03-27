import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Material, Store, MKYS_ECikisIslemTuruEnum, DrugSpecificationEnum,ActiveIngredientDefinition, PrescriptionTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { StockOutType } from "../Kullanilmayan_Malzeme_Raporu/UnusedMaterialForm";

export class DrugOutForRecipeTypeFormViewModel extends BaseViewModel {
    public StoreID: Guid;
    public StartDate: Date = new Date();
    public EndDate: Date = new Date();
    public BudgetTypeDefinitionObjectID: Guid;
    public MaterialList: Array<string> = new Array<string>();
    public SelectedMaterialList: Array<MaterialModel> = new Array<MaterialModel>();
    public SelectedFilterStores: Array <Guid> = new Array <Guid>();
    public StoreList: Array<Store> = new Array<Store>();
    public StoresName: Array <string> = new Array <string>();
    public MKYS_CikisIslemTuru: MKYS_ECikisIslemTuruEnum;
    public showUnused: boolean = false;
    public filterAmount: number;
    public DoctorIDList: Array <Guid> = new Array <Guid>();
    public OutStoreIDList: Array <Guid> = new Array <Guid>();
    public DayQueryNumber: number;
    public VademecumList: Array <number> = new Array <number>();
    //public getEHU: boolean = false;
    public SelectedStockOutTypeList: StockOutType;
 
    
    constructor() {

        super();

        this.EndDate = new Date();
        this.StartDate = this.EndDate.AddMonths(-1);
        this.EndDate.setHours(23, 59, 59, 0);
        this.StartDate.setHours(0, 0, 0, 0);
    }
 }
export class DrugOutForInputReciepeTypeFormViewModel 
{
  //  @Type(() => PrescriptionTypeEnum)
    public PrescriptionType:PrescriptionTypeEnum;
    @Type(() => Date)
    public StartDate: Date = new Date();
    @Type(() => Date)
    public EndDate: Date = new Date();
    @Type(() => Guid)
    public Store: Guid;
    @Type(() => Material)
    public MaterialList: Array<string> = new Array<string>();
    @Type(() => Boolean)
    public allMaterials:boolean=false;
   //@Type(() => DrugSpecificationEnum)
    // public DrugSpecifications:Array<Number> = new Array<Number>();
    // @Type(() => Boolean)
    // public allDrugSpecification:boolean=false;
    @Type(() => Guid)
    public DoctorID:Guid;
    public SelectedStockOutTypeList: string ;
    constructor() {
        
        this.EndDate = new Date();
        this.StartDate = this.EndDate.AddMonths(-1);
        this.EndDate.setHours(23, 59, 59, 0);
        this.StartDate.setHours(0, 0, 0, 0);
    }
    
}


 export class DrugOutForRecipeTypeResultModel {

    public Amount: number;
    public Patient: string;
    public MKYS_teslimAlanObjectId: string;
    public Material: string;
}


export class OutVoucherSecondLevelResultModel {
    public VoucherDate: Date;
    public TakeInType: string;
    public BudgetType: string;
    public CompanyName: string;
    public BidDate: Date;
    public BidNumber: string;
    public TotalAmount: number;
    public ObjectID: Guid;
}

export class InputModelForSecondLevel
{
    public StockTransactionObjectID: Guid ;
}

export class OutVoucherThirdLevelResultModel{
    public  TransactionCode: string;
    public  Barcode: string;
    public  Amount: number;
    public  StoreStock: string;
    public  MaterialName: string;
    public  MaterialObjectID: Guid;
    public  StockActionObjectID: Guid;
    public  StockActionDetailObjectID: Guid;
    public  VoucherAmount: number;
    public  UnitPrice: number;
    public  UnitType: string;
}
export class InputModelForThirdLevel
{
    public StockActionObjectID: Guid ;
}

export class MaterialModel
{
    public  Name: string;
    public  ID: Guid;
}