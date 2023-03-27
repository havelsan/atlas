import { Type } from 'NebulaClient/ClassTransformer';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { SKRSKlinikler, SKRSKurumlar, SKRSNAKILYOLU, SKRSSEVKNEDENI, SKRSILKodlari, SKRSDurum, SKRSKanGrubu, SKRSSOLUNUM, SKRSTRANSPORTMALZEMESI, EpisodeAction, DiagnosisGrid, SKRSHastaNakilTipi, SKRSTRIAJKODU, SKRSBilinc, SKRSPersonelBransKodu } from '../../../wwwroot/app/NebulaClient/Model/AtlasClientModel';
import { DiagnosisAndProcedureBaseModel } from '../Tibbi_Surec_Is_Listeleri/Yatan_Hasta_Is_Listesi/InPatientWorkListViewModel';

export class HastaNakilFormuViewModel {
    public IsNew: boolean;
    public SubepisodeID: string;
    public ObjectID: string;
    @Type(() => Date)
    public TalepEdildigiZaman: Date;
    @Type(() => Guid)
    public NakilTalepEdenKlinik: Guid;
    @Type(() => Guid)
    public NakilEdilmekIstenilenKlinik: Guid;
    @Type(() => Guid)
    public HastaninBulunduguKlinik: Guid;
    @Type(() => Guid)
    public KomutaKontrolMerkezi: Guid;
    @Type(() => Guid)
    public NakilGerceklestirmeYolu: Guid;
    @Type(() => Guid)
    public SevkNedeni: Guid;
    public SevkNedeniAciklama: string;
    @Type(() => Guid)
    public KabulEdenKurumIli: Guid;
    @Type(() => Guid)
    public KabulEdenKurum: Guid;
    @Type(() => Guid)
    public NakilKabulEdenKlinik: Guid;
    @Type(() => Guid)
    public HastaHukumluMu: Guid;
    @Type(() => Guid)
    public AdliVakaMi: Guid;
    @Type(() => Guid)
    public KanGrubu: Guid;
    @Type(() => Guid)
    public NakilTipi: Guid;
    @Type(() => Guid)
    public DoktorIhtiyaci: Guid;
    @Type(() => Guid)
    public BransIhtiyaci: Guid;
    @Type(() => Guid)
    public TeyitliVakaMi: Guid;
    public SistolikKanBasinci: number;
    public DiastolikKanBasinci: number;
    @Type(() => Guid)
    public Solunum: Guid;
    public SolunumSayisi: number;
    public SolunumIslemi: string;
    public GlaskowKomaSkalasi: number;
    public Gozler: number;
    @Type(() => Guid)
    public Triaj: Guid;
    public Ates: string;
    public NabizSayisi: number;
    @Type(() => Guid)
    public Bilinc: Guid;
    public KanSekeri: number;
    public Sozel: number;
    public Motor: number;
    @Type(() => Object)
    public VitalBulgular: Object;
    @Type(() => Object)
    public PatolojikMuayeneBilgileri: Object;
    @Type(() => Object)
    public NakilSirasindaIstenilenMedikalIslemler: Object;
    @Type(() => Object)
    public TetkikBilgileri: Object;
    @Type(() => Object)
    public YapilanMedikalIslemler: Object;
    @Type(() => Object)
    public YapilmasiIstenilenMedikalIslemler: Object;
    @Type(() => Object)
    public NakilSirasindakiGereksinimler: Object;
    @Type(() => Guid)
    public TransportMalzemesi: Guid;
    public MalzemeSayisi: number;
    public HastaYakiniAdi: string;
    public HastaYakiniSoyadi: string;
    public HastaYakiniTel: string;
    public HastaYakiniAdres: string;
    @Type(() => Object)
    public EpikrizeEkAciklama: Object;
    public HekimAdi: string;
    public HekimSoyadi: string;
    public HekimTel: string;
    public HekimTC: string;
    public PersonelAdi: string;
    public PersonelSoyadi: string;
    public PersonelTel: string;
    public _NabizDurumu: string;
    @Type(() => DiagnosisAndProcedureBaseModel)
    public SevkTaniList: Array<DiagnosisAndProcedureBaseModel> = new Array<DiagnosisAndProcedureBaseModel>();

}

export class HastaNakilSKRSModel {

    @Type(() => SKRSKlinikler)
    public SKRSKlinikList: Array<SKRSKlinikler> = new Array<SKRSKlinikler>();
    @Type(() => SKRSKurumlar)
    public SKRSKurumList: Array<SKRSKurumlar> = new Array<SKRSKurumlar>();
    @Type(() => SKRSNAKILYOLU)
    public SKRSNakilYoluList: Array<SKRSNAKILYOLU> = new Array<SKRSNAKILYOLU>();
    @Type(() => SKRSSEVKNEDENI)
    public SKRSSevkNedeniList: Array<SKRSSEVKNEDENI> = new Array<SKRSSEVKNEDENI>();
    @Type(() => SKRSILKodlari)
    public SKRSILKodlariList: Array<SKRSILKodlari> = new Array<SKRSILKodlari>();
    @Type(() => SKRSDurum)
    public SKRSDurumList: Array<SKRSDurum> = new Array<SKRSDurum>();
    @Type(() => SKRSKanGrubu)
    public SKRSKanGrubuList: Array<SKRSKanGrubu> = new Array<SKRSKanGrubu>();
    @Type(() => SKRSHastaNakilTipi)
    public SKRSHastaNakilTipiList: Array<SKRSHastaNakilTipi> = new Array<SKRSHastaNakilTipi>();
    @Type(() => SKRSSOLUNUM)
    public SKRSSolunumList: Array<SKRSSOLUNUM> = new Array<SKRSSOLUNUM>();
    @Type(() => SKRSTRANSPORTMALZEMESI)
    public SKRSTransportMalzemesiList: Array<SKRSTRANSPORTMALZEMESI> = new Array<SKRSTRANSPORTMALZEMESI>();
    @Type(() => SKRSTRIAJKODU)
    public SKRSTriajKoduList: Array<SKRSTRIAJKODU> = new Array<SKRSTRIAJKODU>();
    @Type(() => SKRSBilinc)
    public SKRSBilincList: Array<SKRSBilinc> = new Array<SKRSBilinc>();
    @Type(() => SKRSPersonelBransKodu)
    public SKRSPersonelBransList: Array<SKRSPersonelBransKodu> = new Array<SKRSPersonelBransKodu>();

    @Type(() => DoctorInfo)
    public DoctorList: Array<DoctorInfo> = new Array<DoctorInfo>();

}
export class DoctorInfo {
    @Type(() => Guid)
    public ObjectID: Guid;
    public NameSurname: string;
    public Name: string;
    public Surname: string;
    public Phone: string;
    public UniqueRefNo: string;
}