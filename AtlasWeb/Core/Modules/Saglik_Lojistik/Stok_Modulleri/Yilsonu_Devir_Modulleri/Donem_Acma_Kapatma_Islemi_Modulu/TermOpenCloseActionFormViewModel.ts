//$6340DA5B
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { Type } from 'NebulaClient/ClassTransformer';
import { TermOpenCloseAction } from "NebulaClient/Model/AtlasClientModel";
import { AccountingTerm } from "NebulaClient/Model/AtlasClientModel";
import { Accountancy } from "NebulaClient/Model/AtlasClientModel";

export class TermOpenCloseActionFormViewModel extends BaseViewModel {
    @Type(() => TermOpenCloseAction)
    public _TermOpenCloseAction: TermOpenCloseAction = new TermOpenCloseAction();
    @Type(() => AccountingTerm)
    public AccountingTerms: Array<AccountingTerm> = new Array<AccountingTerm>();
    @Type(() => Accountancy)
    public Accountancys: Array<Accountancy> = new Array<Accountancy>();
}

export class GetAccountingTerm_Output
{
    @Type(() => AccountingTerm)
    public  accountingTerm: AccountingTerm;
}
