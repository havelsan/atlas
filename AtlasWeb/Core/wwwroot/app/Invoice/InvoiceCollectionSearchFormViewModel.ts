
import { listboxObject } from './InvoiceHelperModel';
import { Guid } from 'NebulaClient/Mscorlib/Guid';


export class InvoiceCollectionSearchFormModel {

    public InvoiceCollectionSearchModel: InvoiceCollectionSearchModel;
    public InvoiceCollectionList: InvoiceCollectionSearchResultModel[];
    public InvoiceCollectionDetailModelDto: InvoiceCollectionDetailModelDto;

    constructor() {
        this.InvoiceCollectionSearchModel = new InvoiceCollectionSearchModel();
        this.InvoiceCollectionList = new Array<InvoiceCollectionSearchResultModel>();
        this.InvoiceCollectionDetailModelDto = new InvoiceCollectionDetailModelDto();

    }
}

export class InvoiceCollectionSearchModel {
    public TedaviTuru: string;
    public Term: Guid;
    public State: string;
    public Payer: Guid;
    public ICFirstDate: Date = null;
    public ICLastDate: Date = null;
    public ICPostFirstDate: Date = null;
    public ICPostLastDate: Date = null;
    public ICFirstPrice: string;
    public ICLastPrice: string;
    public ICNo: string;
    public ICPostNo: string;

    constructor() {
        //this.Payer = new listboxObject();
    }
}

export class InvoiceCollectionSearchResultModel {
    public ObjectID: Guid;
    public No: number;
    public Name: string;
    public Payer: listboxObject;
    public StateDisplayText: string;
    public Date: string;
    public InvoiceCount: number;
    public InvoicePrice: string;
    public PaymentPrice: string;
    public Deduction: string;
    public ProcedureTotal: Currency;
    public MaterialTotal: Currency;
    public DrugTotal: Currency;
    public TermName: string;

    constructor() {
        this.Payer = new listboxObject();
    }
}

export class InvoiceCollectionDetailModelDto {

    public HizmetToplami: string;
    public IlacToplami: string;
    public SarfToplami: string;
    public InvoiceCollectionDetail: InvoiceCollectionDetailListDto[];

    constructor() {
        this.InvoiceCollectionDetail = new Array<InvoiceCollectionDetailListDto>();
    }

}
export class InvoiceCollectionDetailListDto {
    public CrateDate: string;
    public PatientName: string;
}

export class InvoiceCollectionMergeModel {
    public ParentInvoiceCollectionID: Object;
    public ChildInvoiceCollectionsIDs: Array<Guid> = new Array<Guid>();
}

export class PriceDetailParameterModel {
    SelectedObjectIDs: Array<Guid> = new Array<Guid>();
}

export class PriceDetailResultModel {
    public ObjectID: Guid;
    public ProcedureTotal: Currency;
    public MaterialTotal: Currency;
    public DrugTotal: Currency;
}
