import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { MedulaResult } from './InvoiceHelperModel';
import { MIFTypeEnum } from 'app/NebulaClient/Model/AtlasClientModel';

export class InvoiceAccountancyFormViewModel {
    public TermInformation: TermInformationModel;
    public SEPInformationList: SEPInformationModel[];

    constructor() {
        this.TermInformation = new TermInformationModel();
        this.SEPInformationList = new Array<SEPInformationModel>();
    }
}

export class TermInformationModel {

    public Term?: Guid;
    public GSSDocumentNo?: number;
    public TempProtDocumentNo?: number;
    public Approved: boolean;
    public ApproveDate?: Date;
    public ApproveUser: string;
    public MedulaTotal: number;
    public MedulaBKKTotal: number;
    public MedulaNetTotal: number;
    public MedulaGocIdaresiTotal: number;
    public HBYSSEPTotal: number;
    public HBYSAccTrxTotal: number;
}

export class SEPInformationModel {

    public MedulaTakipBilgisiObjectId?: Guid;
    public SEPObjectId?: Guid;
    public Durum: string;
    public KabulNo: string;
    public BasvuruNo: string;
    public TakipNo: string;
    public GrupTuru: string;
    public GrupAdi: string;
    public MedulaTutar: number;
    public HBYSSEPTutar: number;
    public HBYSAccTrxTutar: number;
    public UyumsuzlukTipi: number;
}

export class MIFModel {
    public MIFInfo: MIFInfo;
    public MIFPayers: MIFPayer[];

    constructor() {
        this.MIFInfo = new MIFInfo();
        this.MIFPayers = new Array<MIFPayer>();
    }
}

export class MIFInfo {
    public TermObjectID?: Guid;
    public MIFType?: number;
    public MIFObjectID?: Guid;
    public MIFName: string;
    //public CreateDate?: Date;
    //public CreateUser: string;
}

export class MIFPayer {
    public Payer: Guid;
    public Code: string;
    public Name: string;
    public Details: MIFPayerDetail[];

    constructor() {
        this.Details = new Array<MIFPayerDetail>();
    }
}

export class MIFPayerDetail {
    public AccountCode: string;
    public AccountName: string;
    public Debt?: number;
    public Credit?: number;
}