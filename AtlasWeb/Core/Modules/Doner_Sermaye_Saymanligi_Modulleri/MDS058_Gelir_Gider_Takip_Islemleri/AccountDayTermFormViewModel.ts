//$964EC689
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AccountDayTerm } from "NebulaClient/Model/AtlasClientModel";
import { AccountPeriodDefinition } from "NebulaClient/Model/AtlasClientModel";

export class AccountDayTermFormViewModel extends BaseViewModel {
    public _AccountDayTerm: AccountDayTerm = new AccountDayTerm();
    public AccountPeriodDefinitions: Array<AccountPeriodDefinition> = new Array<AccountPeriodDefinition>();
}
