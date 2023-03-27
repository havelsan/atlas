import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Material, StockAction } from 'NebulaClient/Model/AtlasClientModel';



export class MovableTransactionInputVoucherFormViewModel extends BaseViewModel {

    public StartDate: Date;
    public EndDate: Date;
    public MKYSStockTransactionID: string;
    public StoreID: Guid;
    public StateType: string;
    public StockActionID: number;
    public SupplierObjectID: Guid;
    public AccountancyObjectID: Guid;
    public BudgetTypeDefinitionObjectID: Guid;
    public DocumentRecordLogID: string;
    public SelectedFilterMaterials: Array<Material> = new Array<Material>();
    public MaterialObjectID: Guid;
    public MovableBarcodeNumber: Guid;
    public MovableCode: Guid;
    public IncomingAmount: number;
    public OutgoingAmount: number;
    public RemainingAmount: number;
    public HospitalInventory: string;
    public SelectedMaterialInDetailedSearch: Material;
    public showZeroValues: boolean;
    public VademecumList: Array <number> = new Array <number>();
    constructor() {

        super();

        this.EndDate = new Date();
        this.StartDate = this.EndDate.AddMonths(-1);
        this.EndDate.setHours(23, 59, 59, 0);
        this.StartDate.setHours(0, 0, 0, 0);

    }

}

export class MovableTransactionInputVoucherResultModel {
    public VoucherDate: Date;
    public TakeinType: string;
    public BudgetType: string;
    public CompanyName: string;
    public ExaminationDate: Date;
    public ExamintaionNo: string;
    public VoucherAmount: number;
    public StockActionID: number;
    public StockActionObjectID: Guid;
    public VounherNo:string;


}

export class VoucherDetailsInputModel {
    public StockActionObjectID: Guid;
}

export class VoucherDetailsResultModel
{
    public  ExpirationDate: Date;
    public  TransactionCode: string;
    public  Barcode: string;
    public  Amount: string;
    public  StoreStock: string;
    public  MaterialName: string;
    public  MaterialObjectID: Guid;
    public  StockActionObjectID: Guid;
    public  StockActionDetailObjectID: Guid;

}

export class MaterialDetailsResultModel
{
    public OutDate: Date;
    public OutLocation: string;
    public Amount: number;
    public UnitPrice: number;
    public TotalPrice: number;
    public MKYS_StokHareketID: string;
    public MaterialObjectID: Guid;
    public StockActionObjectID: Guid;
    public StockActionDetailObjectID: Guid;

}
export class MaterialDetailsInputModel
{
    public  StockActionObjectID: Guid;
    public  StockActionDetailObjectID: Guid;
    public  MaterialObjectID: Guid;
}

export class MaterialModelForDetailedSearch
{
    public NatoStockNO: string;
    public Barcode: string;
    public MaterialName: string;
    public InAmount: number;
    public OutAmount: number;
    public RestAmount: number;
    public StockTransactionID: Guid;
    public StockActionObjectID: Guid;
    public StockActionID: number;
    public VoucherList: Array <StockAction>;
    public DocumentRecordLogID: number;
    public BidDate: Date;
    public BidNumber: string;
    public CompanyName: string;
    public TakeinType: string;
    public VatRate: number;
    public UnitPriceWithinVat: number;
    public UnitPriceWithoutVat: number;


}
export class ModelForInfoInput
{
    public MaterialStockTransactionID: Guid;
}

export class OutTransactionDetailModel
{
    public StockHareketID: string;
    public OutPlace: string;
    public OutDate: Date;
    public Amount: number;
    public UnitPrice: number;
    public TotalPrice: number;
}
export class InventoryInput
{
    public MaterialObjectID: Guid;
    public viewModel: MovableTransactionInputVoucherFormViewModel;
}