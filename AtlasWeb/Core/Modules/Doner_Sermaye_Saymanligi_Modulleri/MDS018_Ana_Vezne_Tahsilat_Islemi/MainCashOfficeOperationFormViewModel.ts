//$4BACBE45
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { MainCashOfficeOperation } from 'NebulaClient/Model/AtlasClientModel';
import { SubmittedCashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { MainCashOfficePaymentTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Supplier } from 'NebulaClient/Model/AtlasClientModel';

export class MainCashOfficeOperationFormViewModel extends BaseViewModel {
    @Type(() => BankDecount)
    public _MainCashOfficeOperation: MainCashOfficeOperation = new MainCashOfficeOperation();
    @Type(() => SubmittedCashierLog)
    public CashierLogsGridGridList: Array<SubmittedCashierLog> = new Array<SubmittedCashierLog>();
    @Type(() => CashOfficeReceiptDocument)
    public CashOfficeReceiptDocuments: Array<CashOfficeReceiptDocument> = new Array<CashOfficeReceiptDocument>();
    @Type(() => CashOfficeDefinition)
    public CashOfficeDefinitions: Array<CashOfficeDefinition> = new Array<CashOfficeDefinition>();
    @Type(() => BankDecount)
    public BankDecounts: Array<BankDecount> = new Array<BankDecount>();
    @Type(() => BankAccountDefinition)
    public BankAccountDefinitions: Array<BankAccountDefinition> = new Array<BankAccountDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => CashierLog)
    public CashierLogs: Array<CashierLog> = new Array<CashierLog>();
    @Type(() => MainCashOfficePaymentTypeDefinition)
    public MainCashOfficePaymentTypeDefinitions: Array<MainCashOfficePaymentTypeDefinition> = new Array<MainCashOfficePaymentTypeDefinition>();
    @Type(() => Supplier)
    public Suppliers: Array<Supplier> = new Array<Supplier>();
}
