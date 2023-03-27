
import { listboxObject } from './InvoiceHelperModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { Type } from 'NebulaClient/ClassTransformer';
import { DiagnosisDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { BaseViewModel } from 'NebulaClient/Model/BaseViewModel';

export class InvoiceSEPFormViewModel extends BaseViewModel {
    public InvoiceTypes: PayerType[];
    @Type(() => Guid)
    public MainSEP: Guid;
    public InvoiceSEPMaster: InvoiceSEPMasterModel;
    //@Type(() => InvoiceSEPDetailModel)
    public InvoiceSEPDetail: InvoiceSEPDetailModel;
    public InvoiceSEPList: InvoiceSEPListModel[];
    public PatientSEPList: PatientSEPListModel[];
    public InvoiceSEPTransactionList: InvoiceSEPTransactionListModel[];
    public InvoiceSEPDiagnoseList: InvoiceSEPDiagnoseListModel[];
    public InvoiceSEPEpicrisis: InvoiceSEPEpicrisisModel;
    public AddNewProcedure: AddNewProcedureViewModel;

    constructor() {
        super();
        this.InvoiceTypes = new Array<PayerType>();
        this.InvoiceSEPMaster = new InvoiceSEPMasterModel();
        this.InvoiceSEPDetail = new InvoiceSEPDetailModel();
        this.InvoiceSEPList = new Array<InvoiceSEPListModel>();
        this.PatientSEPList = new Array<PatientSEPListModel>();
        this.InvoiceSEPTransactionList = new Array<InvoiceSEPTransactionListModel>();
        this.InvoiceSEPDiagnoseList = new Array<InvoiceSEPDiagnoseListModel>();
        this.InvoiceSEPEpicrisis = new InvoiceSEPEpicrisisModel();
        this.AddNewProcedure = new AddNewProcedureViewModel();
    }
}

export class NewProcedureModel {
    public ProcedureObjectID: listboxObject;
    public Code: string;
    public Name: string;
    public Amount: number;
    public TransactionDate: Date;
    public Doctor: Guid;

    constructor() {
        this.Amount = 1;
        this.ProcedureObjectID = new listboxObject();
        this.Code = "";
        this.Name = "";
        this.TransactionDate = new Date();
        this.Doctor = new Guid();
    }
}
export class AddNewProcedureViewModel extends NewProcedureModel {
    public TransactionLastDate: Date;
    public SEPObjectID: Guid;
    public WeekendsIncluded: boolean;
    constructor() {
        super();
        this.TransactionLastDate = new Date();
        this.SEPObjectID = new Guid();
        this.WeekendsIncluded = false;
    }
}

export class InvoiceSEPEpicrisisModel {
    public ObjectID: Guid;
    public Episode: Guid;
    public SubEpisode: Guid;
    public SubEpisodeProtocol: Guid;
    public Description: string;
    public CreateDate: Date;
    public UserName: string;
    public EpicrisisDetail: InvoiceSEPEpicrisisDetailModel[];

    constructor() {
        this.EpicrisisDetail = new Array<InvoiceSEPEpicrisisDetailModel>();
    }
}
export class InvoiceSEPEpicrisisDetailModel {
    public Included: boolean;
    public Type: string;
    public Text: string;
    public Order: number;
}
export class SearchProtocolNoModel {
    public SEPObjectID: Guid;
    public Name: string;
    public Surname: string;
    public ProtocolNo: string;
}
export class PatientSEPListModel {
    public ObjectID: Guid;
    public Episode: Guid;
    public SubEpisode: Guid;
    public HospitalProtocolNo: number;
    public MedulaBasvuruNo: string;
    public MedulaFaturaTutari: Currency;
    public MedulaTakipNo: string;
    public Medulatakipno1: string;
    public Date: Date;
    public Specialityname: string;
    public SubEpisodeResSection: string;
    public Status: Object;
    public Tedavituru: string;
    public Id: number;
    public Payername: string;
    public PayetTypeEnum: number;
    public InvoiceNo: string;
    public InvoiceDate: Date;

}
export class PayerType {
    public id: number;
    public text: string;
}
export class InvoiceSEPMasterModel {
    public UniqueRefNo: number;
    public NameAndSurname: string;
    public YupassNo: string;
    public BirthDate: string;
    public Payer: listboxObject;
    public PayerType: listboxObject;
    public PatientObjectID: Guid;
    constructor() {
        this.Payer = new listboxObject();
        this.PayerType = new listboxObject();
    }

}
export class InvoiceSEPDetailModel {
    public ObjectID: Guid;
    public SubEpisodeObjectID: Guid;
    public EpisodeObjectID: Guid;
    public HospitalProtocolNo: string;
    public EpisodeOpeningDate: string;
    @Type(() => Date)
    public InPatientDate: Date;
    @Type(() => Date)
    public DischargeDate: Date;
    public TotalInPatientDate: number;
    public EpisodeStatus: number;
    public MedulaBasvuruNo: string;
    public Brans: Guid;
    public MedulaDevredilenKurum: Guid;
    public MedulaIstisnaiHal: Guid;
    public MedulaSigortaliTuru: Guid;
    public Triage: Guid;
    public MedulaSonucKodu: string;
    public MedulaSonucMesaji: string;
    public SEPDescription: string;
    public InvoiceNo: string;
    @Type(() => Date)
    public InvoiceDate: Date;
    public PayerInvoiceDocumentObjectID: Guid;
    public InvoiceDescription: string;
    public InvoiceCancelCount: number;
    public InvoiceTerm: string;
    public InvoiceCollection: listboxObject;
    public InvoiceTotalPrice: string;
    public HBYSTotalPrice: string;
    public DoctorName: string;
    public InpatientStatus: string;
    public DischargeType: string;

    constructor() {
        this.InvoiceCollection = new listboxObject();
    }
}
export class InvoiceSEPListModel {
    public ObjectID: Guid;
    public SubEpisodeObjectID: Guid;
    public EpisodeObjectID: Guid;
    public MedulaProvizyonTarihi: Date;
    public InvoiceStatus: string;
    public MedulaTakipNo: string;
    public KabulNo: string;
    public MedulaBagliTakipNo: string;
    public SubEpisodeResSection: string;
    public MedulaTedaviTuru: Guid;
    public MedulaProvizyonTipi: Guid;
    public MedulaTedaviTipi: Guid;
    public MedulaTakipTipi: Guid;
    public Id: number;
    public SelectedTransactionList: InvoiceSEPTransactionListModel[];
    public UserChangedSelection: boolean;
    public Description: string;
    public Investigation: boolean;
    public Checked: boolean;
    public BlockState: boolean;

    constructor() {
        this.SelectedTransactionList = new Array<InvoiceSEPTransactionListModel>();
        this.UserChangedSelection = false;
    }
}
export class InvoiceSEPTransactionListModel {
    public ObjectID: Guid;
    public Basetype: string;
    public Medulatype: string;
    public Id: string;
    public Statetext: string;
    public ExternalCode: string;
    public Description: string;
    @Type(() => Date)
    public TransactionDate: Date;
    public Unitprice: Currency;
    public Amount: number;
    public TotalPrice: Currency;
    public Diffprice: number;
    public MedulaProcessNo: string;
    public MedulaPrice: Currency;
    public InvoiceInclusion: boolean;
    public Blocking: boolean;
    public MedulaResultCode: string;
    public MedulaResultMessage: string;
    public OzelDurum: Guid;
    public AyniFarkliKesi: Guid;
    public MedulaReportNo: string;
    public MedulaBedNo: string;
    public Suttype: string;
    public ProcedureState: string;
    public CurrentStateDefID: Guid;
    public Doctor: Guid;
    public Totalpayment: Currency;
    public UTSUsageCommitment: boolean;
    public NabizResultCode: string;
    public NabizResultMessage: string;
    public SurgerySutGroup: string;
    public Nabiz700Status: number;
    public Position: number;
    public AppDate: string;
}
export class InvoiceSEPDiagnoseListModel {
    public ObjectID: Guid;
    public Id: string;
    public Diagnose: DiagnosisDefinition;
    public IsMainDiagnose: boolean;
    public DiagnosisType: string;
    public MedulaProcessNo: string;
    public CurrentState: string;
    public MedulaResultCode: string;
    public MedulaResultMessage: string;
    public OzelDurum: string;
    public CurrentStateDefID: Guid;
}
export class TakipDVO {
    public faturaTeslimNo: string;
    public ilkTakipNo: string;
    public bransKodu: string;
    public donorTCKimlikNo: string;
    public hastaBasvuruNo: string;
    public hastaBilgileri: hastaBilgileriDVO;
    public kayitTarihi: string;
    public provizyonTipi: string;
    public takipDurumu: string;
    public takipNo: string;
    public takipTarihi: string;
    public takipTipi: string;
    public tedaviTipi: string;
    public tedaviTuru: string;
    public tesisKodu: number;
    public sevkDurumu: string;
    public yeniDoganCocukSiraNo: string;
    public yeniDoganDogumTarihi: string;
    public arvFlag: string;
    public evrakID: number;
    public istisnaiHal: string;
    public fatutaIptalHakki: number;
    public faturaTarihi: string;
    public sonucKodu: string;
    public sonucMesaji: string;
}
export class hastaBilgileriDVO {
    public tcKimlikNo: string;
    public ad: string;
    public soyad: string;
    public cinsiyet: string;
    public dogumTarihi: string;
    public sigortaliTuru: string;
    public devredilenKurum: string;
    public katilimPayindanMuaf: string;
    public kapsamAdi: string;
}
export class HizmetOkuCevapModel {
    public tumHizmetler: Array<HizmetOkuCevapHizmetlerModel>;
    public takipNo: string;
    public odemeSorguDurum: string;
    public triajBeyani: string;
    public sonucKodu: string;
    public sonucMesaji: string;
    constructor() {
        this.tumHizmetler = new Array<HizmetOkuCevapHizmetlerModel>();
    }
}
export class HizmetOkuCevapHizmetlerModel {
    public type: string;
    public islemSiraNo: string;
    public hizmetSunucuRefNo: string;
    public islemTarihi: string;
    public sutKodu: string;
    public adet: string;
    public ozelDurum: string;
    public bransKodu: string;
    public drTescilNo: string;
    public aciklama: string;
    public ayniFarkliKesi: string;
    public raporTakipNo: string;
    public sagSol: string;
    public refakatciGunSayisi: string;
    public yatakKodu: string;
    public yatisBaslangicTarihi: string;
    public yatisBitisTarihi: string;
    public birim: string;
    public sonuc: string;
    public ilacTuru: string;
    public paketHaric: string;
    public tutar: string;
    public donorId: string;
    public firmaTanimlayiciNo: string;
    public ihaleKesinlesmeTarihi: string;
    public ikNoAlimNo: string;
    public katkiPayi: string;
    public kdv: string;
    public kodsuzMalzemeAdi: string;
    public kodsuzMalzemeFiyati: string;
    public malzemeKodu: string;
    public malzemeSatinAlisTarihi: string;
    public malzemeTuru: string;
    public Euroscore: string;
    public isbtBilesenNo: string;
    public isbtUniteNo: string;
    public anomali: string;
    public disTaahhutNo: string;
    public sagAltCene: string;
    public sagAltCeneAnomaliDis: string;
    public sagSutAltCene: string;
    public sagSutUstCene: string;
    public sagUstCene: string;
    public sagUstCeneAnomaliDis: string;
    public solAltCene: string;
    public solAltCeneAnomaliDis: string;
    public solSutAltCene: string;
    public solSutUstCene: string;
    public solUstCene: string;
    public solUstCeneAnomaliDis: string;
    public cokluOzelDurum: Array<string>;
    public tahlilSonuc: Array<TahlilSonucHizmetOkuCevapModel>;
    constructor() {
        this.tahlilSonuc = new Array<TahlilSonucHizmetOkuCevapModel>();
        this.cokluOzelDurum = new Array<string>();
    }
}
export class TahlilSonucHizmetOkuCevapModel {
    public islemSiraNo: string;
    public sonuc: string;
    public tahlilTipi: string;
    public birim: string;
}
export class BasvuruTakipOkuCevapDVO {
    public basvuruTakip: Array<BasvuruTakipDVO>;
    public hastaBasvuruNo: string;
    public sonucKodu: string;
    public sonucMesaji: string;
    constructor() {
        this.basvuruTakip = new Array<BasvuruTakipDVO>();
    }
}
export class BasvuruTakipDVO {
    public takipNo: string;
    public takipFaturaDurumu: string;
}
export class faturaOkuCevapDTO {
    public faturaDetaylariField: Array<faturaCevapDetayDTO>;
    public faturaRefNoField: string;
    public faturaTarihiField: string;
    public faturaTeslimNoField: string;
    public faturaTutariField: number;
    public sonucKoduField: string;
    public sonucMesajiField: string;
    public succes: boolean;
}
export class faturaCevapDetayDTO {
    public aciklamaField: string;
    public islemDetaylariField: Array<islemDetayDTO>;
    public protokolNoField: string;
    public taburcuKoduField: string;
    public takipNoField: string;
    public takipToplamTutarField: number;
}
export class islemDetayDTO {
    public islemSiraNoField: string;
    public islemTutariField: number;
    public islemTarihiField: string;
    public islemAdiField: string;
    public islemKoduField: string;
}

export class InvoiceLogModel {
    public Message: string;
    public Operation: string;
    public UserName: string;
    public Date: string;
    public LogType: string;
}

export class InvoiceBlockingModel {
    public ObjectID: Guid;
    public BlockUserName: string;
    public BlockUserObjectID: Guid;
    public BlockDate: Date;
    public BlockDescription: string;
    public UnblockUserName: string;
    public UnblockUserObjectID: Guid;
    public UnblockDate: Date;
    public ModuleName: string;
    public UnblockDescription: string;
    public Active: boolean;
}

export class HastaYatisOkuCevapDVO {
    public saglikTesisiKodu: string;
    public hastaBasvuruNo: string;
    public basvuruYatisBilgileri: Array<BasvuruYatisBilgileriDVO>;
    public yeniDoganDogumTarihi: string;
    public yeniDoganCocukSiraNo: string;
    public donorTck: string;
    public sonucKodu: string;
    public sonucMesaji: string;
    public ClinicDischargeDate: Date;
    constructor() {
        this.basvuruYatisBilgileri = new Array<BasvuruYatisBilgileriDVO>();
    }
}

export class BasvuruYatisBilgileriDVO {
    public baslangicTarihi: Date;
    public bitisTarihi: Date;
    public durum: string;
}

export class FazlaTakipDTO {
    public ID: string;
    public hastaBasvuruNo: string;
    public takipNo: string;
    public takipTarihi: string;
    public bransKodu: string;
    public tedaviTuru: string;
    public durum: string;
}

export class FazlaTakipBilgileriDTO {
    public tc: string;
    public ilkTarih: Date;
    public sonTarih: Date;
    public takipListesi: Array<FazlaTakipDTO>;

    constructor() {
        this.takipListesi = new Array<FazlaTakipDTO>();
    }
}

export class VefatKayitBilgileriDTO {
    public tc: string;
    public vefatTarihi: Date;
    public cevapVefatTarihi: Date;
    public cevapTc: string;
    public adi: string;
    public sonucKoduMesaji: string;
    public soyadi: string;
    public tesis: string;
}

export class BaseCevapDVO {
    public sonucKodu: string;
    public sonucMesaji: string;
}

export class doktorListDVO {
    public drAdi: string;
    public drSoyadi: string;
    public drDiplomaNo: string;
    public drTescilNo: string;

    constructor() {

    }
}

export class DoktorAraGirisDVO extends doktorListDVO {
    public drBransKodu: string;

    constructor() {
        super();
    }
}


export class doktorAraCevapDVO extends BaseCevapDVO {
    public doktorlar: Array<doktorListDVO>;

    constructor() {
        super();
        this.doktorlar = new Array<doktorListDVO>();
    }
}

export class IlacAraGirisDVO {
    public barkod: string;
    public ilacAdi: string;
    constructor() {

    }
}

export class FiyatListDVO {
    fiyat: number;
    gecerlilikTarihi: Date;
}

export class IlacIndirimDVO {
    //Kamu indirim alt oranı
    kamuIndOranAlt: number;
    //Kamu indirim üst oranı
    kamuIndOranUst: number;
    gecerlilikTarihi: string;
    ilac_id: number;
    indirimOrani1: number;
    indirimOrani2: number;
    indirimOrani3: number;
    indirimOrani4: number;
}

export class ilacListDVO {
    ilacFiyatlari: Array<FiyatListDVO>;
    kullanimBirimi: number;
    barkod: string;
    ilacAdi: string;
    //Eczane aktiflik bilgisi
    eczAktifPasif: string;
    //XXXXXX aktiflik bilgisi
    hasAktifPasif: string;
    ayaktanOdenme: string;
    yatanOdenme: string;
    ilacIndirimleri: Array<IlacIndirimDVO>;

    constructor() {

    }
}

export class ilacAraCevapDVO extends BaseCevapDVO {

    ilaclar: Array<ilacListDVO>;

    constructor() {
        super();
        this.ilaclar = new Array<ilacListDVO>();
    }
}

export class TesisYatakSorguGirisDVO {
    tarih: Date = null;
}

export class tesisYatakBilgiDVO {
    yatakKodu: string;
    turu: string;
    tescilTuru: number;
    Seviye: number;
    gecerlilikBaslangicTarihi: string;
    gecerlilikBitisTarihi: string;
}

export class tesisYatakSorguCevapDVO extends BaseCevapDVO {
    yataklar: Array<tesisYatakBilgiDVO>;
}

export class FTRTedaviRaporuOkuDTO {
    vucutBolgesi: string;
    seansGun: number;
    seansSayi: number;
    butKodu: string;
    tedaviTuru: string;
    raporBaslangicTarihi: string;
    raporBitisTarihi: string;
    raporTakipNo: string;
    resultMessage: string;

    aciklama: string;
    doktorlar: Array<string>;
    tanilar: Array<string>;
    protocolNo: string;
    protocolTarihi: string;
    tesisKodu: number;
    raporTarihi: string;
    constructor() {
        this.doktorlar = new Array<string>();
        this.tanilar = new Array<string>();
    }
}

export class FTRTedaviRaporuOkuDTOList {
    raporList: Array<FTRTedaviRaporuOkuDTO>;
    totalMessage: string;
    nameSurname: string;
}


export class IlacRaporuOkuDTO {
    raporTakipNo: number;
    ilacEtkinMadde: string;
    basTarihi: string;
    bitTarihi: string;
    saglikTesisKodu: number;
}

export class IlacRaporuOkuDTOList {
    raporList: Array<IlacRaporuOkuDTO>;
    totalMessage: string;
    nameSurname: string;
}

export class SuitableFTRTransaction {
    sepObjectID: Guid;
    accTrxObjectID: Guid;
    Id: string;
    CurrentState: string;
    CurrentStateDefID: Guid;
    ExternalCode: string;
    Description: string;
    TransactionDate: Date;
    MedulaProvisionNo: string;
    MedulaProvisionDate: Date;
    MedulaReportNo: string;
}

export enum LoadInvoiceFormPartitions {
    MainSEP = 1,
    InvoiceSEPMaster = 2,
    InvoiceSEPDetail = 3,
    InvoiceSEPList = 4,
    InvoiceSEPTransactionList = 5,
    InvoiceSEPDiagnoseList = 6,
    PatientSEPList = 7,
    InvoiceSEPEpicrisis = 8
}

export class UTSMaterialDTO {
    objectID: Guid;
    id: string;
    transactionDate: string;
    description: string;
    utsUsageCommitment: boolean;
    resultCode: string;
    resultMessage: string;
}

export class UXXXXXXesinlestirmeSorguDTO {

    kullanimBildirimID: string;
    saglikTesisKodu: string;
    tcKimlikNo: string;
    seriNo: string;
    lotNo: string;
    hizmetSunucuReferansNo: string;
    takipNo: string;
    durum: string;
}

export class UXXXXXXesinlestirmeSorguSonucDTO {
    detailList: Array<UXXXXXXesinlestirmeSorguDTO>;
    message: string;
}

export class DocumentOperationsModel {
    public evrakId?: number; // Medula Dönem Evrak Id
    public takipNo: string;
    public medulaTakipDokumanListesiSorguResultMessage: string;

    public uploadedDocumentArray: UploadedDocumentModel[];
    public selectedUploadedDocumentArray: UploadedDocumentModel[];
    public medulaTakipDokumanArray: MedulaTakipDokumanModel[];

    constructor() {
        this.uploadedDocumentArray = new Array<UploadedDocumentModel>();
        this.selectedUploadedDocumentArray = new Array<UploadedDocumentModel>();
        this.medulaTakipDokumanArray = new Array<MedulaTakipDokumanModel>();
    }
}

export class UploadedDocumentModel {
    objectID: Guid;
    kayitReferansNo?: number; // Medula Kayıt Referans Numarası
    evrakId?: number
    takipNo: string;
    //uploadDate: string;
    //uploadUser: string;
    protocolNo: string;
    dosyaTuru: string;
    dosyaAdi: string;
    explanation: string;
}

export class MedulaTakipDokumanModel {
    evrakId: number;
    takipNo: string;
    kayitReferansNo: number; // Medula Kayıt Referans Numarası
    islemSiraNo: string;
    dosyaTuru: string;
    dosyaAdi: string;
}

export class DokumanHeaderModel {
    evrakId?: number;
    sepObjectID: Guid;
    takipNo: string;
}

export class MedulaTakipDokumanSorguModel {
    header: DokumanHeaderModel;

    constructor() {
        this.header = new DokumanHeaderModel();
    }
}

export class MedulaTakipDokumanSorguSonucModel {
    medulaDocumentArray: Array<MedulaTakipDokumanModel>;
    message: string;
}

export class MedulaDokumanIslemModel {
    header: DokumanHeaderModel;
    documentArray: UploadedDocumentModel[];

    constructor() {
        this.header = new DokumanHeaderModel();
        this.documentArray = new Array<UploadedDocumentModel>();
    }
}

export class BarcodeSUTMatchModel {
    queryInput: BarcodeSUTMatchDetailModel;
    public resultMessage: string;
    public medulaBarcodeSUTMatchArray: BarcodeSUTMatchDetailModel[];

    constructor() {
        this.queryInput = new BarcodeSUTMatchDetailModel();
        this.medulaBarcodeSUTMatchArray = new Array<BarcodeSUTMatchDetailModel>();
    }
}

export class BarcodeSUTMatchDetailModel {
    tarih?: Date;
    barkod: string;
    firmaTanimlayiciNo: string;
    sutKodu: string;
    baslangicTarihi: string;
    bitisTarihi: string;
}

export class ENabizBildirimHizmetModel {
    hizmetSunucuRefNo: string;
    islemKodu: string;
    islemTarihi: string;
}


export class getSutRuleEngineResultCodes_Model {
    @Type(() => Guid)
    ObjectID: Guid;
    @Type(() => Guid)
    RuleGroupID: Guid;
    RuleName: string;
    ExternalCode: string;
    RelatedCode: string;
    Description: string;
    Message: string;
    Price: number;
    Choice: number;
}

export class InfoModel {
    public Header: string;
    public Value: string;
}