import { BaseModel } from 'Fw/Models/BaseModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Store } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';
export class OutTransactionViewModel extends BaseModel {

    public OutStockTransactions: Array<OutStockTransactionDVO>;
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