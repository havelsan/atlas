//$675B7CD7
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { AccountVoucher, Supplier } from "NebulaClient/Model/AtlasClientModel";
import { AccountVoucherCodeDefinition } from "NebulaClient/Model/AtlasClientModel";
import { AccountPeriodDefinition } from "NebulaClient/Model/AtlasClientModel";

export class AccountVoucherEntryFormViewModel extends BaseViewModel {
    public _AccountVoucher: AccountVoucher = new AccountVoucher();
    public AccountVoucherCodeDefinitions: Array<AccountVoucherCodeDefinition> = new Array<AccountVoucherCodeDefinition>();
    public SupplierDefinitions: Array<Supplier> = new Array<Supplier>();
    public AccountPeriodDefinitions: Array<AccountPeriodDefinition> = new Array<AccountPeriodDefinition>();
}
