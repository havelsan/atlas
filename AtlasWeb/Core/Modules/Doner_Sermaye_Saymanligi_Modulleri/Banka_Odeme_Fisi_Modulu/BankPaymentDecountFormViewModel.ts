//$BB6AE03B
import { Type } from 'NebulaClient/ClassTransformer';
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BankPaymentDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BankPaymentDecountDocument } from 'NebulaClient/Model/AtlasClientModel';
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

export class BankPaymentDecountFormViewModel extends BaseViewModel {
    @Type(() => BankPaymentDecount)
    public _BankPaymentDecount: BankPaymentDecount = new BankPaymentDecount();
    @Type(() => BankPaymentDecountDocument)
    public BankPaymentDecountDocuments: Array<BankPaymentDecountDocument> = new Array<BankPaymentDecountDocument>();
    @Type(() => BankDecount)
    public BankDecounts: Array<BankDecount> = new Array<BankDecount>();
    @Type(() => BankAccountDefinition)
    public BankAccountDefinitions: Array<BankAccountDefinition> = new Array<BankAccountDefinition>();
    @Type(() => CashOfficeDefinition)
    public CashOfficeDefinitions: Array<CashOfficeDefinition> = new Array<CashOfficeDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
}
