//$7EF666E1
import { BaseViewModel } from "NebulaClient/Model/BaseViewModel";
import { BondPayment } from 'NebulaClient/Model/AtlasClientModel';
import { BondPaymentDetail } from 'NebulaClient/Model/AtlasClientModel';
import { BondPaymentDocument } from 'NebulaClient/Model/AtlasClientModel';
import { CashOfficeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { BankDecount } from 'NebulaClient/Model/AtlasClientModel';
import { BankAccountDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { Type } from 'NebulaClient/ClassTransformer';

export class BondPaymentFormViewModel extends BaseViewModel {
    @Type(() => BondPayment)
    public _BondPayment: BondPayment = new BondPayment();
    @Type(() => BondPaymentDetail)
    public ttgrid1GridList: Array<BondPaymentDetail> = new Array<BondPaymentDetail>();
    @Type(() => BondPaymentDocument)
    public BondPaymentDocuments: Array<BondPaymentDocument> = new Array<BondPaymentDocument>();
    @Type(() => CashOfficeDefinition)
    public CashOfficeDefinitions: Array<CashOfficeDefinition> = new Array<CashOfficeDefinition>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => BankDecount)
    public BankDecounts: Array<BankDecount> = new Array<BankDecount>();
    @Type(() => BankAccountDefinition)
    public BankAccountDefinitions: Array<BankAccountDefinition> = new Array<BankAccountDefinition>();
}
