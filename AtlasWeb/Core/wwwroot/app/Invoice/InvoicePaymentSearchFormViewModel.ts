
import { listboxObject } from './InvoiceHelperModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { TTReportDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTReportDef';

export class InvoicePaymentSearchFormModel implements BaseViewModel {
    public ReadOnly: boolean;
    public ReadOnlyFields: string[];
    public OutgoingTransitions: TTObjectStateTransitionDef[];
    public CurrentStateReports: TTReportDef[];
    public ListDefDisplayExpressions: any;
    public UpdatedObjects: Object[];
    public InvoicePaymentSearchModel: InvoicePaymentSearchModel;
    public InvoicePaymentSearchResultModel: InvoicePaymentSearchResultModel[];
    public newPaymentPayer: listboxObject;
    public newPaymentUniqueID: string;
    public newPaymentInvoiceNo: string;
    public newPaymentControlTotalPayment: number;
    public newPaymentPayerType: any;
    public newPaymentTerm: any;
    public newPaymentRemainingPaymentTime?: number;
    public lastPaymentDate?: Date;

    constructor() {
        this.InvoicePaymentSearchModel = new InvoicePaymentSearchModel();
        this.InvoicePaymentSearchResultModel = new Array<InvoicePaymentSearchResultModel>();
        this.newPaymentPayer = new listboxObject();
    }
}

export class InvoicePaymentSearchModel {
    public Term: Guid;
    public State: string;
    public Payer: Guid;
    public BankAccount: Guid;
    public User: Guid;
    public FirstDecountDate: Date = null;
    public LastDecountDate: Date = null;
    public FirstPrice: string;
    public LastPrice: string;
    public DecountNo: string;
    public PatientUniqueRefNo: string;
    public InvoiceNo: string;

    constructor() {
        //this.Payer = new listboxObject();
    }
}

export class InvoicePaymentSearchResultModel {
    public ObjectID: Guid;
    public Payer: string;
    public StateDisplayText: string;
    public DecountNo: string;
    public DecountDate: Date = null;
    public TotalPrice: string;
    public Deduction: string;
}

export class InvoiceCollectionSelectNewPayment {
    public ObjectID: string;
    public No: number;
    public Name: string;
    public Date: string;
    public StateDisplayText: string;
    public InvoicePrice: string;
    public Payer: listboxObject;
    public InvoiceCount: number;
    public LastPaymentDate: Date;
    public TermName: string;

    constructor() {
        this.Payer = new listboxObject();
    }
}

export class IsReadOnly {
    public value: boolean;
    constructor(val?: boolean) {
        if (val != undefined)
            this.value = val;
        else
            this.value = false;
    }
}
