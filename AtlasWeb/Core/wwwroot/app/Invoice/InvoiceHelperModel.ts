//$6C3FEC77
import { Guid } from "NebulaClient/Mscorlib/Guid";

export class CollectiveOperationResultCount {
    public succesCount: number;
    public errorCount: number;
    public newCount: number;
    public errorList: CollectiveOperationErrors[];
    constructor() {
        this.errorList = new Array<CollectiveOperationErrors>();
    }
}

export class CollectiveOperationErrors {
    public ObjectID: Guid;
    public Takip: string;
    public Code: string;
    public Message: string;
}

export class listboxObject
{
    public ObjectID: string;
    public Name: string;
    public Code: string;

    constructor() {

    }

}

export class MedulaResult {

    public Succes: boolean;
    public BasvuruNo: string;
    public TakipNo: string;
    public SonucMesaji: string;
    public SonucKodu: string;
    public BagliTakipNo: string;
    public SEPObjectID: string;

    constructor() {
        this.SonucKodu = "";
        this.SonucMesaji = "";
        this.Succes = false;
        this.TakipNo = "";
        this.BasvuruNo = "";
        this.SEPObjectID = "";
    }
}

export class AccountTransactionStatesString {
    public static New: string = i18n("M24515", "Yeni");
    public static Cancelled: string = i18n("M16535", "İptal Edildi");
    public static Send: string = i18n("M14871", "Gönderildi");
    public static Invoiced: string = i18n("M14243", "Faturalandı");
    public static Ready: string = i18n("M15575", "Hazır") ;
    public static ToBeNew: string = i18n("M22584", "Tahakkuk");
    public static Paid: string = i18n("M19880", "Ödendi");
    public static MedulaDontSend: string = i18n("M18852", "Medulaya Gönderilmeyecek");
    public static MedulaSentServer: string = i18n("M22385", "Sunucuya Gönderildi") ;
    public static MedulaEntryUnsuccessful: string = i18n("M15876", "Hizmet Kaydı Başarısız");
    public static MedulaEntrySuccessful: string = i18n("M15875", "Hizmet Kaydı Başarılı");
}

export class SEPInvoiceStatusDictionary{
    public static ProvisionNoNotExists: string = i18n("M22660", "Takip No Alınmamış");
    public static ProvisionNoWaiting: string = i18n("M22661", "Takip No Bekleniyor");
    public static ProcedureEntryNotCompleted: string = i18n("M15879", "Hizmet Kaydı Tamamlanmamış");
    public static ProcedureEntryWithError: string = i18n("M15880", "Hizmet Kaydı Tamamlanmamış Hatalı");
    public static ProcedureEntryCompleted: string = i18n("M15881", "Hizmet Kaydı Tamamlanmış");
    public static InvoiceEntryWaiting: string = i18n("M14173", "Fatura Kaydı Bekleniyor");
    public static InvoiceEntryWithError: string = i18n("M14174", "Fatura Kaydı Hatalı");
    public static Invoiced: string = i18n("M14172", "Fatura Kaydedildi");
    public static InvoiceReadWaiting: string = i18n("M14216", "Fatura Tutar Okuma Bekleniyor");
    public static InvoiceRead: string = i18n("M14219", "Fatura Tutar Okundu");
    public static InvoiceReadWithError: string = i18n("M14217", "Fatura Tutar Okuma Hatalı");
    public static InsideInvoiceCollection: string = i18n("M16131", "İcmal İçerisinde");
    public static InvoiceInconsistent: string = "Fatura Tutarı Uyuşmayan";
}

export class InvoicePaymentModel {
    public PIPObjectId: Guid;
    public Payer: listboxObject;
    public CreateDate: Date;
    public Username: string;
    public BankAccount: Guid;
    public DecountDate: Date;
    public DecountNo: string;
    public TotalPrice?: number;
    public PaymentPrice?: number;
    public Deduction?: number;
    public InvoicePrice?: number;
    public Description: string;
    public CurrentStateDefID: Guid;
    public CancelDescription: string;
    constructor()
    {
        this.Payer = new listboxObject();
        //this.BankAccount = new listboxObject();
    }
}
export class ForbiddenSUTOperation {
    public sepObjectID: Guid;
    public protocolNo: string;
    public provisionNo: string;
    public sutCode: string;
    public sutName: string;
    public totalAmount: number;
    public totalPrice: number;
}

export class InvoicePaymentDetailModel {
    public InvoiceCollectionDetailID: Guid;
    public ICDCurrentStateDefID: Guid;
    public PatientName: string;
    public UniqueRefNo: string;
    public EpisodeID: string;
    public InvoiceDate: string;
    public InvoiceNo: string;
    public InvoicePrice: number;
    public InvoiceRestPrice: number;
    public Payment: number;
    public Deduction: number;
    public PayerObjectID: Guid;
    public PayerName: string;
    public TermName: string;
    public IsTermOpen: boolean;
    public StatusDisplayText: string;
}

export class PayerInvoicePaymentStates {
    public static Cancelled: Guid = new Guid("f151bb8b-cc39-4c24-be77-dc51ebaae92c");
    public static Paid: Guid = new Guid("39ffbf5b-29b4-4d1b-bdf6-a6a149698f73");

}