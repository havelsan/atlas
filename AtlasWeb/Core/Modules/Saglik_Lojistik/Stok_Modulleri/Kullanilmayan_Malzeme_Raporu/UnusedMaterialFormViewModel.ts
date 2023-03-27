import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Material, Store, MKYS_ECikisIslemTuruEnum } from 'NebulaClient/Model/AtlasClientModel';

export class UnusedMaterialFormViewModel extends BaseViewModel {
    public StoreID: Guid;
    public StartDate: Date = new Date();
    public EndDate: Date = new Date();
    public MaterialList: Array<Material> = new Array<Material>();
    public SelectedMaterialList: Array<MaterialModel> = new Array<MaterialModel>();
    public SelectedFilterStores: Array <Guid> = new Array <Guid>();
    public StoreList: Array<Store> = new Array<Store>();
    public StoresName: Array <string> = new Array <string>();
    public showUnused: boolean = false;
    public filterAmount: number;
    public DoctorID: Guid;
    public OutStoreID: Guid;
    public DayQueryNumber: number;
    public VademecumList: Array <number> = new Array <number>();
    public getEHU: boolean = false;
    public SelectedStockOutTypeList: Array<Guid> = new Array<Guid>();
    public MaterialObjectID: Guid;
 




    constructor() {

        super();

        this.EndDate = new Date();
        this.StartDate = this.EndDate.AddMonths(-1);
        this.EndDate.setHours(23, 59, 59, 0);
        this.StartDate.setHours(0, 0, 0, 0);
    }
 }



 export class UnusedResultModel {

    public OutVoucherDate: Date;
    public MKYSStockActionID: number;
    public BudgetType: string;
    public VoucherTotalAmount: number;
    public StockActionID: number;
    public MaterialObjectID: Guid;
    public TifNO: Guid;
    public OutPlace: string;
    public OutPlaceID: Guid;
    public UnitPrice: number;
    public DocumentRecordLogID: number;
    public StockTransactionObjectID: Guid;
    public FirstMaterialName: string;
    public Amount: number;
    public InStockActionDetail: Guid;
}

export class ModelForInfoInput
{
    public MaterialStockTransactionID: Guid;
}
export class InventoryInput
{
    public MaterialObjectID: Guid;
    public viewModel: UnusedMaterialFormViewModel;
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