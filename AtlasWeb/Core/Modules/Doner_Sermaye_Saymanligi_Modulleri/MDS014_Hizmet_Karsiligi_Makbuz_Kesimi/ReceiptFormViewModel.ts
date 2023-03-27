//$5F560BD5
import { Receipt, DailyRateDefinition, CurrencyTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { DiscountTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Advance } from 'NebulaClient/Model/AtlasClientModel';
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import Dictionary from 'app/NebulaClient/System/Collections/Dictionaries/Dictionary';

export class ReceiptFormViewModel extends BaseViewModel {
    @Type(() => Receipt)
    public _Receipt: Receipt = new Receipt();
    @Type(() => ReceiptProcedure)
    public GRIDReceiptProceduresGridList: Array<ReceiptProcedure> = new Array<ReceiptProcedure>();
    @Type(() => ReceiptMaterial)
    public GRIDReceiptMaterialsGridList: Array<ReceiptMaterial> = new Array<ReceiptMaterial>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => ReceiptDocument)
    public ReceiptDocuments: Array<ReceiptDocument> = new Array<ReceiptDocument>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => CashierLog)
    public CashierLogs: Array<CashierLog> = new Array<CashierLog>();
    @Type(() => DiscountTypeDefinition)
    public DiscountTypeDefinitions: Array<DiscountTypeDefinition> = new Array<DiscountTypeDefinition>();
    @Type(() => Advance)
    public Advances: Array<Advance> = new Array<Advance>();
    // @Type(() => AccountTransaction)
    // public AccountTransactions: Array<AccountTransaction> = new Array<AccountTransaction>();
    public HasRoleToChangePaymentTpye = false;
    //Hastadan Alınan Nakit Para
    @Type(() => Number)
    public MoneyPaid?: number = 0;
    @Type(() => Number)
    public RemainderOfMoney?: number = 0;
    @Type(() => Number)
    public ConvertedTotalPayment: number = 0;    
    public DailyRateDefinition: Guid;
    public SelectedCurrencyTypeDefinition: Guid;
    public SelectedCurrencyRate: DailyRateDefinitionsDTO;
    public ReceiptProcedureAccTrxMatch:Dictionary<Guid,Guid>;
}

export class DailyRateDefinitionsDTO {
    DailyRate: number;
    RateDate: Date;
    Currencytypename: string;
    Qref: string;
    Currencyratetypename: string;
    ObjectID: Guid;
}
