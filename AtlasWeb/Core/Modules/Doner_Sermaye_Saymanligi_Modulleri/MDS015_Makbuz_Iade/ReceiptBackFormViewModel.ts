//$CE4F87F1
import { ReceiptBack } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptBackDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptBackDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashierLog } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { Receipt } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ReceiptDocument } from 'NebulaClient/Model/AtlasClientModel';
import { AccountTransaction } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class ReceiptBackFormViewModel extends BaseViewModel {
    @Type(() => ReceiptBack)
    public _ReceiptBack: ReceiptBack = new ReceiptBack();
    @Type(() => ReceiptBackDetail)
    public GRIDReceiptBackDetailsGridList: Array<ReceiptBackDetail> = new Array<ReceiptBackDetail>();
    @Type(() => ReceiptBackDocument)
    public ReceiptBackDocuments: Array<ReceiptBackDocument> = new Array<ReceiptBackDocument>();
    @Type(() => CashierLog)
    public CashierLogs: Array<CashierLog> = new Array<CashierLog>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => Receipt)
    public Receipts: Array<Receipt> = new Array<Receipt>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => ReceiptDocument)
    public ReceiptDocuments: Array<ReceiptDocument> = new Array<ReceiptDocument>();
    @Type(() => AccountTransaction)
    public AccountTransactions: Array<AccountTransaction> = new Array<AccountTransaction>();
}

export class ReceiptBackDetailViewModel {
    @Type(() => Receipt)
    public receipt: Receipt;
    @Type(() => ReceiptBackDetail)
    public ReceiptBackDetails: Array<ReceiptBackDetail> = new Array<ReceiptBackDetail>();
    @Type(() => AccountTransaction)
    public AccountTransactions: Array<AccountTransaction> = new Array<AccountTransaction>();
}