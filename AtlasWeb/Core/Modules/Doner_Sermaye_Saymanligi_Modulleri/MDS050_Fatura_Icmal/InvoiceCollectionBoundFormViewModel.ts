//$DC0DDCEC
import { Type } from 'NebulaClient/ClassTransformer';
import { InvoiceCollection } from 'NebulaClient/Model/AtlasClientModel';
import { InvoiceCollectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { PayerInvoiceDocument } from 'NebulaClient/Model/AtlasClientModel';
import { InvoiceTerm } from 'NebulaClient/Model/AtlasClientModel';
import { ProvizyonTipi } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviTuru } from 'NebulaClient/Model/AtlasClientModel';
import { TedaviTipi } from 'NebulaClient/Model/AtlasClientModel';
import { PayerDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { TakipTipi } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { PayerTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { OperationStatus } from 'app/CashOfficeForms/OperationStatus';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class InvoiceCollectionBoundFormViewModel extends BaseViewModel {
    @Type(() => InvoiceCollection)
    public _InvoiceCollection: InvoiceCollection = new InvoiceCollection();
    @Type(() => InvoiceCollectionDetail)
    public ttgrid1GridList: Array<InvoiceCollectionDetail> = new Array<InvoiceCollectionDetail>();
    @Type(() => Episode)
    public Episodes: Array<Episode> = new Array<Episode>();
    @Type(() => Patient)
    public Patients: Array<Patient> = new Array<Patient>();
    @Type(() => PayerInvoiceDocument)
    public PayerInvoiceDocuments: Array<PayerInvoiceDocument> = new Array<PayerInvoiceDocument>();
    @Type(() => InvoiceTerm)
    public InvoiceTerms: Array<InvoiceTerm> = new Array<InvoiceTerm>();
    @Type(() => ProvizyonTipi)
    public ProvizyonTipis: Array<ProvizyonTipi> = new Array<ProvizyonTipi>();
    @Type(() => TedaviTuru)
    public TedaviTurus: Array<TedaviTuru> = new Array<TedaviTuru>();
    @Type(() => TedaviTipi)
    public TedaviTipis: Array<TedaviTipi> = new Array<TedaviTipi>();
    @Type(() => PayerDefinition)
    public PayerDefinitions: Array<PayerDefinition> = new Array<PayerDefinition>();
    @Type(() => TakipTipi)
    public TakipTipis: Array<TakipTipi> = new Array<TakipTipi>();
    @Type(() => ResUser)
    public ResUsers: Array<ResUser> = new Array<ResUser>();
    @Type(() => ResUser)
    public LastStateUsers: Array<ResUser> = new Array<ResUser>();
    //public GridModel: Array<InvoiceCollectionDetailGridViewModel> = new Array<InvoiceCollectionDetailGridViewModel>();
    public CancelledInvoices: Array<InvoiceCollectionCancelGridViewModel> = new Array<InvoiceCollectionCancelGridViewModel>();
    @Type(() => Number)
    public InvoiceCollectionDetailCount: number;
    public PayerType: PayerTypeEnum;
    @Type(() => Guid)
    public SEPObjectIDs: Array<Guid> = new Array<Guid>();
    @Type(() => Date)
    public LastPaymentDate?: Date;
    @Type(() => Number)
    public TermDay?: number;
}

export class InvoiceCollectionDetailGridViewModel {
    public UniqueRefNo: string;
    public OpeningDate?: Date;
    public Patientfullname: string;
    public Episodeid: number;
    public Invoiceprice: number;
    public PaymentPrice: number;
    public Deduction: number;
    public Invoicedate?: Date;
    public Invoiceno: string;
    public ObjectID?: Guid;
    public Status: string;
    public MedulaTakipNo: string;
    public Maxsepobjectid: Guid;
    public DrugTotal: Currency;
    public MaterialTotal: Currency;
    public ProcedureTotal: Currency;
}

export class InvoiceCollectionCancelGridViewModel extends InvoiceCollectionDetailGridViewModel {
    public Date: Date;
    public User: string;
    public Description: string;
}

export class InvoiceCollectionDetailBatchProcessModel {
    public ObjectIDs: Array<Guid> = new Array<Guid>();
    public InvoiceCollectionId?: Guid;
    public OperationID: number;
    public NewInvoiceCollection?: any;
}

export class InvoiceCollectionDetailBatchProcessResultModel {
    public _OperationStatus: OperationStatus;
    public GridModel: Array<InvoiceCollectionDetailGridViewModel>;
    public CancelledInvoices: Array<InvoiceCollectionCancelGridViewModel>;
}