//$F738331A
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AccountTotalDebt } from "NebulaClient/Model/AtlasClientModel";
import { AccountPeriodDefinition } from "NebulaClient/Model/AtlasClientModel";

export class AccountTotalDebtFormViewModel extends BaseViewModel {
    public _AccountTotalDebt: AccountTotalDebt = new AccountTotalDebt();
    public AccountPeriodDefinitions: Array<AccountPeriodDefinition> = new Array<AccountPeriodDefinition>();
}
