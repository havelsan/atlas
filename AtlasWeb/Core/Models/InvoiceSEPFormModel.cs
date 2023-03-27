using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Models
{
    public class InvoiceSEPFormModel
    {
        public Guid MainSEP
        {
            get;
            set;
        }

        public List<PayerType> InvoiceTypes
        {
            get;
            set;
        }

        public InvoiceSEPMasterModel InvoiceSEPMaster
        {
            get;
            set;
        }

        public InvoiceSEPDetailModel InvoiceSEPDetail
        {
            get;
            set;
        }

        public List<InvoiceSEPListModel> InvoiceSEPList
        {
            get;
            set;
        }

        public List<PatientSEPListModel> PatientSEPList
        {
            get;
            set;
        }

        public List<InvoiceSEPTransactionListModel> InvoiceSEPTransactionList
        {
            get;
            set;
        }

        public List<InvoiceSEPDiagnoseListModel> InvoiceSEPDiagnoseList
        {
            get;
            set;
        }

        public InvoiceSEPEpicrisisModel InvoiceSEPEpicrisis
        {
            get;
            set;
        }

        public AddNewProcedureViewModel AddNewProcedure
        {
            get;
            set;
        }

        public InvoiceSEPFormModel()
        {
            this.InvoiceSEPMaster = new InvoiceSEPMasterModel();
            this.InvoiceSEPDetail = new InvoiceSEPDetailModel();
            this.InvoiceSEPEpicrisis = new InvoiceSEPEpicrisisModel();
            this.InvoiceSEPList = new List<InvoiceSEPListModel>();
            this.PatientSEPList = new List<PatientSEPListModel>();
            this.InvoiceSEPTransactionList = new List<InvoiceSEPTransactionListModel>();
            this.InvoiceSEPDiagnoseList = new List<InvoiceSEPDiagnoseListModel>();
            this.AddNewProcedure = new AddNewProcedureViewModel();
        }
    }

    public class AddNewProcedureViewModel : NewProcedureModel
    {
        public DateTime? TransactionLastDate
        {
            get;
            set;
        }

        public Guid SEPObjectID
        {
            get;
            set;
        }
    }

    public class NewProcedureModel
    {
        public listboxObject ProcedureObjectID
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public DateTime? TransactionDate
        {
            get;
            set;
        }

        public Guid Doctor
        {
            get;
            set;
        }
    }

    public class AddNewProcedureToSEPModel
    {
        public Guid SEPObjectID
        {
            get;
            set;
        }

        public List<NewProcedureModel> NewProcedures
        {
            get;
            set;
        }

        public AddNewProcedureToSEPModel()
        {
            this.SEPObjectID = new Guid();
            this.NewProcedures = new List<NewProcedureModel>();
        }
    }

    public class InvoiceSEPEpicrisisModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid Episode
        {
            get;
            set;
        }

        public Guid SubEpisode
        {
            get;
            set;
        }

        public Guid SubEpisodeProtocol
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime? CreateDate
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public List<InvoiceSEPEpicrisisDetailModel> EpicrisisDetail
        {
            get;
            set;
        }

        public InvoiceSEPEpicrisisModel()
        {
            this.EpicrisisDetail = new List<InvoiceSEPEpicrisisDetailModel>();
        }
    }

    public class InvoiceSEPEpicrisisDetailModel
    {
        public bool Included
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }
    }

    public class PayerType
    {
        public int id
        {
            get;
            set;
        }

        public string text
        {
            get;
            set;
        }
    }

    public class PatientSEPListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Guid? Episode
        {
            get;
            set;
        }

        public Guid? SubEpisode
        {
            get;
            set;
        }

        public string HospitalProtocolNo
        {
            get;
            set;
        }

        public string MedulaBasvuruNo
        {
            get;
            set;
        }

        public Currency? Medulafaturatutari
        {
            get;
            set;
        }

        public string MedulaTakipNo
        {
            get;
            set;
        }

        public string Medulatakipno1
        {
            get;
            set;
        } //TODO:AAE Bağlı Takip ismi değişecek.

        public DateTime? Date
        {
            get;
            set;
        }

        public string Specialityname
        {
            get;
            set;
        }

        public object Status
        {
            get;
            set;
        } //TODO: AAE Kontrol edilecek.

        public string SubEpisodeResSection
        {
            get;
            set;
        } //TODO: AAE Kontrol edilecek.

        public string Tedavituru
        {
            get;
            set;
        }

        public long? Id
        {
            get;
            set;
        }

        public string Payername
        {
            get;
            set;
        }

        public int? PayetTypeEnum
        {
            get;
            set;
        }

        public string InvoiceNo
        {
            get;
            set;
        }

        public DateTime? InvoiceDate
        {
            get;
            set;
        }
    }

    public class SearchProtocolNoModel
    {
        public Guid SEPObjectID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProtocolNo { get; set; }
    }

    public class InvoiceSEPMasterModel
    {
        public Guid PatientObjectID
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

        public string NameAndSurname
        {
            get;
            set;
        }

        public string YupassNo
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public listboxObject Payer
        {
            get;
            set;
        }

        public listboxObject PayerType
        {
            get;
            set;
        }

        public InvoiceSEPMasterModel()
        {
            this.Payer = new listboxObject();
            this.PayerType = new listboxObject();
        }
    }

    public class InvoiceSEPDetailModel
    {
        public Guid ObjectID { get; set; }
        public Guid SubEpisodeObjectID { get; set; }
        public Guid EpisodeObjectID { get; set; }
        public string HospitalProtocolNo { get; set; }
        public string EpisodeOpeningDate { get; set; }
        public DateTime? InPatientDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public int? TotalInPatientDate { get; set; }
        public int EpisodeStatus { get; set; }
        public string MedulaBasvuruNo { get; set; }
        public Guid? Brans { get; set; }
        public Guid? MedulaDevredilenKurum { get; set; }
        public Guid? MedulaIstisnaiHal { get; set; }
        public Guid? MedulaSigortaliTuru { get; set; }
        public Guid? Triage { get; set; }
        public string MedulaSonucKodu { get; set; }
        public string MedulaSonucMesaji { get; set; }
        public string SEPDescription { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string InvoiceDescription { get; set; }
        public int InvoiceCancelCount { get; set; }
        public string InvoiceTerm { get; set; }
        public listboxObject InvoiceCollection { get; set; }
        public string InvoiceTotalPrice { get; set; }
        public string HBYSTotalPrice { get; set; }
        public Guid? PayerInvoiceDocumentObjectID { get; set; }
        public string DoctorName { get; set; }
        public string InpatientStatus { get; set; }
        public string DischargeType { get; set; }

        public InvoiceSEPDetailModel()
        {
            this.InvoiceCollection = new listboxObject();
        }
    }

    public class InvoiceSEPListModel
    {
        public Guid ObjectID { get; set; }
        public Guid SubEpisodeObjectID { get; set; }
        public Guid EpisodeObjectID { get; set; }
        public DateTime MedulaProvizyonTarihi { get; set; }
        public string InvoiceStatus { get; set; }
        public string KabulNo { get; set; }
        public string MedulaTakipNo { get; set; }
        public string MedulaBagliTakipNo { get; set; }
        public string SubEpisodeResSection { get; set; }
        public Guid? MedulaTedaviTuru { get; set; }
        public Guid? MedulaProvizyonTipi { get; set; }
        public Guid? MedulaTedaviTipi { get; set; }
        public Guid? MedulaTakipTipi { get; set; }
        public Currency? HBYSPrice { get; set; }
        public Currency? InvoicePrice { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public List<InvoiceSEPTransactionListModel> SelectedTransactionList { get; set; }
        public bool UserChangedSelection { get; set; }
        public bool? Investigation { get; set; }
        public bool? Checked { get; set; }
        public bool? BlockState { get; set; }


        public InvoiceSEPListModel()
        {
            this.SelectedTransactionList = new List<InvoiceSEPTransactionListModel>();
            this.UserChangedSelection = false;
        }
    }

    public class InvoiceSEPHizmetKayitIptalModel
    {
        public Guid SEPObjectID
        {
            get;
            set;
        }

        public List<InvoiceSEPTransactionListModel> TransactionList
        {
            get;
            set;
        }

        InvoiceSEPHizmetKayitIptalModel()
        {
            this.SEPObjectID = Guid.Empty;
            this.TransactionList = new List<InvoiceSEPTransactionListModel>();
        }
    }

    public class InvoiceSEPTurnTypeModel
    {
        public bool TurnType
        {
            get;
            set;
        }

        public List<InvoiceSEPTransactionListModel> TransactionList
        {
            get;
            set;
        }

        public InvoiceSEPTurnTypeModel()
        {
            this.TransactionList = new List<InvoiceSEPTransactionListModel>();
        }
    }

    public class SGKHizmetSorgulamaModel
    {
        public List<InvoiceSEPTransactionListModel> TransactionList { get; set; }

        public SGKHizmetSorgulamaModel()
        {
            this.TransactionList = new List<InvoiceSEPTransactionListModel>();
        }
    }

    public class SGKHizmetSorgulamaResultDTOModel : SGKHizmetSorgulamaResultModel
    {
        public int durum { get; set; }
        public string mesaj { get; set; }
    }

    public class SGKHizmetSorgulamaResultModel
    {
        public string sysTakipNo { get; set; }
        public string islemReferansNo { get; set; }
        public string islemTuru { get; set; }
        public string islemKodu { get; set; }
        public string islemTarihi { get; set; }
        public string sgkTakipNo { get; set; }
        public string sgkHizmetReferansNo { get; set; }
        public DateTime? olusturulmaZamani { get; set; }
        public DateTime? guncellenmeZamani { get; set; }
        public DateTime? sgkGonderimZamani { get; set; }
        public string sgkSonucMesaji { get; set; }
        public bool? silindi { get; set; }
        public string hashID { get; set; }
        public string sgkSonucKodu { get; set; }
    }
    public class SGKHizmetSorgulamaResponse
    {
        public int durum { get; set; }

        public List<SGKHizmetSorgulamaResultModel> sonuc { get; set; }

        public string mesaj { get; set; }
    }

    public class InvoiceSEPHizmetKayitIptalModelDiagnosis
    {
        public Guid SEPObjectID
        {
            get;
            set;
        }

        public List<InvoiceSEPDiagnoseListModel> DiagnoseList
        {
            get;
            set;
        }

        public InvoiceSEPHizmetKayitIptalModelDiagnosis()
        {
            this.SEPObjectID = Guid.Empty;
            this.DiagnoseList = new List<InvoiceSEPDiagnoseListModel>();
        }
    }

    public class InvoiceSEPTransactionListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string Basetype
        {
            get;
            set;
        }

        public string Medulatype
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string Statetext
        {
            get;
            set;
        }

        public string ExternalCode
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public DateTime TransactionDate
        {
            get;
            set;
        }

        public Currency Unitprice
        {
            get;
            set;
        }
        public Currency? Diffprice
        {
            get;
            set;
        }
        public Double Amount
        {
            get;
            set;
        }

        public Currency Totalprice
        {
            get;
            set;
        }

        public string MedulaProcessNo
        {
            get;
            set;
        }

        public Currency? MedulaPrice
        {
            get;
            set;
        }

        public bool InvoiceInclusion
        {
            get;
            set;
        }

        public bool Blocking
        {
            get;
            set;
        }

        public string MedulaResultCode
        {
            get;
            set;
        }

        public string MedulaResultMessage
        {
            get;
            set;
        }

        public Guid? OzelDurum
        {
            get;
            set;
        }
        public Guid? AyniFarkliKesi
        {
            get;
            set;
        }

        public string MedulaReportNo
        {
            get;
            set;
        }
        public string MedulaBedNo
        {
            get;
            set;
        }
        public string ProcedureState
        {
            get;
            set;
        }
        public string Suttype
        {
            get;
            set;
        }

        public Guid CurrentStateDefID
        {
            get;
            set;
        }

        public Guid? Doctor
        {
            get;
            set;
        }

        public Currency? Totalpayment
        {
            get;
            set;
        }

        public bool UTSUsageCommitment
        {
            get;
            set;
        }

        public string NabizResultCode
        {
            get;
            set;
        }

        public string NabizResultMessage
        {
            get;
            set;
        }

        public int Nabiz700Status
        {
            get;
            set;
        }
        public string SurgerySutGroup
        {
            get;
            set;
        }
        public int? Position
        {
            get;
            set;
        }
        public string AppDate
        {
            get;
            set;
        }
    }

    public class InvoiceSEPDiagnoseListModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public DiagnosisDefinition Diagnose
        {
            get;
            set;
        }

        public bool? IsMainDiagnose
        {
            get;
            set;
        }

        public string DiagnosisType
        {
            get;
            set;
        }

        public string MedulaProcessNo
        {
            get;
            set;
        }

        public string CurrentState
        {
            get;
            set;
        }

        public string MedulaResultCode
        {
            get;
            set;
        }

        public string MedulaResultMessage
        {
            get;
            set;
        }

        public OzelDurum OzelDurum
        {
            get;
            set;
        }

        public Guid CurrentStateDefID
        {
            get;
            set;
        }

        public InvoiceSEPDiagnoseListModel()
        {
            this.Diagnose = new DiagnosisDefinition();
        }
    }

    public class FaturaKayitModel
    {
        public List<Guid> sepObjectIDs
        {
            get;
            set;
        }

        public DateTime invoiceDate
        {
            get;
            set;
        }

        public string invoiceDescription
        {
            get;
            set;
        }

        public Guid invoiceCollection
        {
            get;
            set;
        }

        public List<Guid> transactionlist
        {
            get;
            set;
        }

        public int invoiceType
        {
            get;
            set;
        }
        public int type
        {
            get;
            set;
        }
        public FaturaKayitModel()
        {
            this.transactionlist = new List<Guid>();
        }
    }

    public class LoadInvoiceFormModel
    {
        public Guid id
        {
            get;
            set;
        }

        public int type
        {
            get;
            set;
        }

        public List<int> loadPartitions
        {
            get;
            set;
        }
        public string Statetext { get; set; }
        public DateTime? InPatientDate { get; set; }

        public DateTime? DischargeDate { get; set; }
        public int? Nabiz700Status { get; set; }
        public bool? BlockingStatus { get; set; }

        public LoadInvoiceFormModel()
        {
            this.loadPartitions = new List<int>();
        }
    }

    enum LoadInvoiceFormPartitions
    {
        MainSEP = 1,
        InvoiceSEPMaster = 2,
        InvoiceSEPDetail = 3,
        InvoiceSEPList = 4,
        InvoiceSEPTransactionList = 5,
        InvoiceSEPDiagnoseList = 6,
        PatientSEPList = 7,
        InvoiceSEPEpicrisis = 8
    }

    public class TopluSEPGirisModel
    {
        public List<Guid> sepObjectIDs
        {
            get;
            set;
        }
    }

    public class HizmetOkuCevapModel
    {
        public List<HizmetOkuCevapHizmetlerModel> tumHizmetler
        {
            get;
            set;
        }

        public string takipNo
        {
            get;
            set;
        }

        public string odemeSorguDurum
        {
            get;
            set;
        }

        public string triajBeyani
        {
            get;
            set;
        }

        public string sonucKodu
        {
            get;
            set;
        }

        public string sonucMesaji
        {
            get;
            set;
        }

        public HizmetOkuCevapModel()
        {
            this.tumHizmetler = new List<HizmetOkuCevapHizmetlerModel>();
        }
    }

    public class HizmetOkuCevapHizmetlerModel
    {
        public string type
        {
            get;
            set;
        }

        public string islemSiraNo
        {
            get;
            set;
        }

        public string hizmetSunucuRefNo
        {
            get;
            set;
        }

        public string islemTarihi
        {
            get;
            set;
        }

        public string sutKodu
        {
            get;
            set;
        }

        public double adet
        {
            get;
            set;
        }

        public string ozelDurum
        {
            get;
            set;
        }

        public string bransKodu
        {
            get;
            set;
        }

        public string drTescilNo
        {
            get;
            set;
        }

        public string aciklama
        {
            get;
            set;
        }

        public string ayniFarkliKesi
        {
            get;
            set;
        }

        public string raporTakipNo
        {
            get;
            set;
        }

        public string sagSol
        {
            get;
            set;
        }

        public string refakatciGunSayisi
        {
            get;
            set;
        }

        public string yatakKodu
        {
            get;
            set;
        }

        public string yatisBaslangicTarihi
        {
            get;
            set;
        }

        public string yatisBitisTarihi
        {
            get;
            set;
        }

        public string birim
        {
            get;
            set;
        }

        public string sonuc
        {
            get;
            set;
        }

        public string ilacTuru
        {
            get;
            set;
        }

        public string paketHaric
        {
            get;
            set;
        }

        public double tutar
        {
            get;
            set;
        }

        public string donorId
        {
            get;
            set;
        }

        public string firmaTanimlayiciNo
        {
            get;
            set;
        }

        public string ihaleKesinlesmeTarihi
        {
            get;
            set;
        }

        public string ikNoAlimNo
        {
            get;
            set;
        }

        public string katkiPayi
        {
            get;
            set;
        }

        public int? kdv
        {
            get;
            set;
        }

        public string kodsuzMalzemeAdi
        {
            get;
            set;
        }

        public double? kodsuzMalzemeFiyati
        {
            get;
            set;
        }

        public string malzemeKodu
        {
            get;
            set;
        }

        public string malzemeSatinAlisTarihi
        {
            get;
            set;
        }

        public string malzemeTuru
        {
            get;
            set;
        }

        public string Euroscore
        {
            get;
            set;
        }

        public string isbtBilesenNo
        {
            get;
            set;
        }

        public string isbtUniteNo
        {
            get;
            set;
        }

        public string anomali
        {
            get;
            set;
        }

        public string disTaahhutNo
        {
            get;
            set;
        }

        public string sagAltCene
        {
            get;
            set;
        }

        public string sagAltCeneAnomaliDis
        {
            get;
            set;
        }

        public string sagSutAltCene
        {
            get;
            set;
        }

        public string sagSutUstCene
        {
            get;
            set;
        }

        public string sagUstCene
        {
            get;
            set;
        }

        public string sagUstCeneAnomaliDis
        {
            get;
            set;
        }

        public string solAltCene
        {
            get;
            set;
        }

        public string solAltCeneAnomaliDis
        {
            get;
            set;
        }

        public string solSutAltCene
        {
            get;
            set;
        }

        public string solSutUstCene
        {
            get;
            set;
        }

        public string solUstCene
        {
            get;
            set;
        }

        public string solUstCeneAnomaliDis
        {
            get;
            set;
        }

        public List<string> cokluOzelDurum
        {
            get;
            set;
        }

        public List<TahlilSonucHizmetOkuCevapModel> tahlilSonuc
        {
            get;
            set;
        }

        public HizmetOkuCevapHizmetlerModel()
        {
            this.tahlilSonuc = new List<TahlilSonucHizmetOkuCevapModel>();
            this.cokluOzelDurum = new List<string>();
        }
    }

    public class TahlilSonucHizmetOkuCevapModel
    {
        public string islemSiraNo
        {
            get;
            set;
        }

        public string sonuc
        {
            get;
            set;
        }

        public string tahlilTipi
        {
            get;
            set;
        }

        public string birim
        {
            get;
            set;
        }
    }

    public class faturaOkuCevapDTO
    {
        public List<faturaCevapDetayDTO> faturaDetaylariField;
        public string faturaRefNoField;
        public string faturaTarihiField;
        public string faturaTeslimNoField;
        public double faturaTutariField;
        public string sonucKoduField;
        public string sonucMesajiField;
        public bool succes;
    }

    public class faturaCevapDetayDTO
    {
        public string aciklamaField;
        public List<islemDetayDTO> islemDetaylariField;
        public string protokolNoField;
        public string taburcuKoduField;
        public string takipNoField;
        public double takipToplamTutarField;
    }

    public class islemDetayDTO
    {
        public string islemSiraNoField;
        public double islemTutariField;
        public string islemTarihiField;
        public string islemAdiField;
        public string islemKoduField;
    }

    public class InvoiceLogModel
    {
        public string Message
        {
            get;
            set;
        }

        public string Operation
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string LogType
        {
            get;
            set;
        }
    }

    public class InvoiceBlockingModel
    {
        public Guid ObjectID { get; set; }
        public string BlockUserName { get; set; }
        public Guid? BlockUserObjectID { get; set; }
        public string BlockDate { get; set; }
        public string BlockDescription { get; set; }
        public string UnblockUserName { get; set; }
        public Guid? UnblockUserObjectID { get; set; }
        public string UnblockDate { get; set; }
        public string ModuleName { get; set; }
        public string UnblockDescription { get; set; }
        public bool Active { get; set; }
    }

    public class HastaYatisOkuCevapDTO
    {
        public string saglikTesisiKodu { get; set; }
        public string hastaBasvuruNo { get; set; }
        public List<BasvuruYatisBilgileriDTO> basvuruYatisBilgileri { get; set; }
        public string yeniDoganDogumTarihi { get; set; }
        public string yeniDoganCocukSiraNo { get; set; }
        public string donorTck { get; set; }
        public string sonucKodu { get; set; }
        public string sonucMesaji { get; set; }
        public DateTime? ClinicDischargeDate { get; set; }

        public HastaYatisOkuCevapDTO()
        {
            this.basvuruYatisBilgileri = new List<BasvuruYatisBilgileriDTO>();
        }
    }

    public class BasvuruYatisBilgileriDTO
    {
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
        public string durum { get; set; }
    }

    public class FTRTedaviRaporuOkuDTO
    {
        public string vucutBolgesi { get; set; }
        public int seansGun { get; set; }
        public int seansSayi { get; set; }
        public string butKodu { get; set; }
        public string tedaviTuru { get; set; }
        public string raporBaslangicTarihi { get; set; }
        public string raporBitisTarihi { get; set; }
        public long raporTakipNo { get; set; }
        public string resultMessage { get; set; }
        public string aciklama { get; set; }
        public List<string> doktorlar { get; set; }
        public List<string> tanilar { get; set; }
        public string protocolNo { get; set; }
        public string protocolTarihi { get; set; }
        public int tesisKodu { get; set; }
        public string raporTarihi { get; set; }

        public FTRTedaviRaporuOkuDTO()
        {
            this.doktorlar = new List<string>();
            this.tanilar = new List<string>();
        }
    }

    public class IlacRaporuOkuDTO
    {
        public long raporTakipNo { get; set; }
        public string ilacEtkinMadde { get; set; }
        public string basTarihi { get; set; }
        public string bitTarihi { get; set; }
        public int saglikTesisKodu { get; set; }
    }
    public class IlacRaporuOkuDTOList
    {
        public List<IlacRaporuOkuDTO> raporList { get; set; }
        public string totalMessage { get; set; }
        public string nameSurname { get; set; }
        public IlacRaporuOkuDTOList()
        {
            this.raporList = new List<IlacRaporuOkuDTO>();
        }
    }

    public class FTRTedaviRaporuOkuDTOList
    {
        public List<FTRTedaviRaporuOkuDTO> raporList { get; set; }
        public string totalMessage { get; set; }
        public string nameSurname { get; set; }

        public FTRTedaviRaporuOkuDTOList()
        {
            this.raporList = new List<FTRTedaviRaporuOkuDTO>();
        }
    }

    public class SuitableFTRTransaction
    {
        public Guid sepObjectID { get; set; }
        public Guid accTrxObjectID { get; set; }
        public string Id { get; set; }
        public string CurrentState { get; set; }
        public string ExternalCode { get; set; }
        public string Description { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string MedulaProvisionNo { get; set; }
        public string MedulaReportNo { get; set; }
        public DateTime? MedulaProvisionDate { get; set; }
        public Guid? CurrentStateDefID { get; set; }
    }

    public class VefatKayitBilgileriDTO
    {
        public string tc { get; set; }
        public DateTime? vefatTarihi { get; set; }
        public string cevapVefatTarihi { get; set; }
        public string cevapTc { get; set; }
        public string adi { get; set; }
        public string sonucKoduMesaji { get; set; }
        public string soyadi { get; set; }
        public string tesis { get; set; }
    }

    public class FazlaTakipDTO
    {
        public string ID { get; set; }
        public string hastaBasvuruNo { get; set; }
        public string takipNo { get; set; }
        public string takipTarihi { get; set; }
        public string bransKodu { get; set; }
        public string tedaviTuru { get; set; }
        public string durum { get; set; }

    }

    public class UTSMaterialDTO
    {
        public Guid objectID { get; set; }
        public string id { get; set; }
        public string transactionDate { get; set; }
        public string description { get; set; }
        public bool utsUsageCommitment { get; set; }
        public string resultCode { get; set; }
        public string resultMessage { get; set; }
    }

    public class UXXXXXXesinlestirmeSorguDTO
    {
        public string kullanimBildirimID { get; set; }
        public string saglikTesisKodu { get; set; }
        public string tcKimlikNo { get; set; }
        public string seriNo { get; set; }
        public string lotNo { get; set; }
        public string hizmetSunucuReferansNo { get; set; }
        public string takipNo { get; set; }
        public string durum { get; set; }
    }

    public class UXXXXXXesinlestirmeSorguSonucDTO
    {
        public List<UXXXXXXesinlestirmeSorguDTO> detailList { get; set; }
        public string message { get; set; }

        public UXXXXXXesinlestirmeSorguSonucDTO()
        {
            this.detailList = new List<UXXXXXXesinlestirmeSorguDTO>();
        }
    }

    public class RelatedEpisodeActionResultModel
    {
        public Guid EAObjectID { get; set; }
        public string ObjectDefName { get; set; }
    }

    public class UploadedDocumentModel
    {
        public Guid objectID { get; set; }
        public long? kayitReferansNo { get; set; }
        public int? evrakId { get; set; }
        public string takipNo { get; set; }
        //public string uploadDate { get; set; }
        //public string uploadUser { get; set; }
        public string protocolNo { get; set; }
        public string dosyaTuru { get; set; }
        public string dosyaAdi { get; set; }
        public string explanation { get; set; }
    }

    public class MedulaTakipDokumanModel
    {
        public int evrakId { get; set; }
        public string takipNo { get; set; }
        public long kayitReferansNo { get; set; }
        public string islemSiraNo { get; set; }
        public string dosyaTuru { get; set; }
        public string dosyaAdi { get; set; }
    }

    public class DokumanHeaderModel
    {
        public int? evrakId { get; set; }
        public Guid sepObjectID { get; set; }
        public string takipNo { get; set; }
    }

    public class MedulaTakipDokumanSorguModel
    {
        public DokumanHeaderModel header { get; set; }

        public MedulaTakipDokumanSorguModel()
        {
            header = new DokumanHeaderModel();
        }
    }

    public class MedulaTakipDokumanSorguSonucModel
    {
        public List<MedulaTakipDokumanModel> medulaDocumentArray { get; set; }
        public string message { get; set; }

        public MedulaTakipDokumanSorguSonucModel()
        {
            medulaDocumentArray = new List<MedulaTakipDokumanModel>();
        }
    }

    public class MedulaDokumanIslemModel
    {
        public DokumanHeaderModel header { get; set; }
        public List<UploadedDocumentModel> documentArray { get; set; }

        public MedulaDokumanIslemModel()
        {
            header = new DokumanHeaderModel();
            documentArray = new List<UploadedDocumentModel>();
        }
    }

    public class BarcodeSUTMatchModel
    {
        public BarcodeSUTMatchDetailModel queryInput { get; set; }
        public List<BarcodeSUTMatchDetailModel> medulaBarcodeSUTMatchArray { get; set; }
        public string resultMessage { get; set; }

        public BarcodeSUTMatchModel()
        {
            queryInput = new BarcodeSUTMatchDetailModel();
            medulaBarcodeSUTMatchArray = new List<BarcodeSUTMatchDetailModel>();
        }
    }

    public class BarcodeSUTMatchDetailModel
    {
        public DateTime? tarih { get; set; }
        public string barkod { get; set; }
        public string firmaTanimlayiciNo { get; set; }
        public string sutKodu { get; set; }
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
    }

    public class ENabizBildirimHizmetModel
    {
        public string hizmetSunucuRefNo { get; set; }
        public string islemKodu { get; set; }
        public string islemTarihi { get; set; }
    }

    public class InfoModel
    {
        public string Header { get; set; }
        public string Value { get; set; }

        public InfoModel(string header, string value)
        {
            Header = header;
            Value = value;
        }
    }
}