using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz104_FaturaBilgisiKayit
    {
        public class SYSSendMessage
        {
            public input input = new input();
        }
        public class input
        {
            public SYSMessage SYSMessage = new SYSMessage();
        }
        public class SYSMessage
        {
            public messageGuid messageGuid = new messageGuid();
            public messageType messageType = new messageType();

            public documentGenerationTime documentGenerationTime = new documentGenerationTime();
            public author author = new author();
            public firmaKodu firmaKodu = new firmaKodu();

            public recordData recordData = new recordData();

            public SYSMessage()
            {
                messageType.code = "104";
                messageType.value = TTUtils.CultureService.GetText("M25629", "Fatura Bilgisi Kayit");
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            public HASTA_FATURA_BILGILERI HASTA_FATURA_BILGILERI;
            public FATURA_BILGILERI FATURA_BILGILERI = new FATURA_BILGILERI();
        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class HASTA_FATURA_BILGILERI
        {
            public FATURA_TARIHI FATURA_TARIHI = new FATURA_TARIHI();
            public FATURA_TUTARI FATURA_TUTARI = new FATURA_TUTARI();
            public MEDULA_TESLIM_NUMARASI MEDULA_TESLIM_NUMARASI = new MEDULA_TESLIM_NUMARASI();
            public PAKETE_AIT_ISLEM_ZAMANI PAKETE_AIT_ISLEM_ZAMANI = new PAKETE_AIT_ISLEM_ZAMANI();
            [System.Xml.Serialization.XmlElement("ISLEM_FATURA_BILGISI", Type = typeof(ISLEM_FATURA_BILGISI))]
            public List<ISLEM_FATURA_BILGISI> ISLEM_FATURA_BILGISI = new List<ISLEM_FATURA_BILGISI>();
        }
        public class ISLEM_FATURA_BILGISI
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public ISLEM_FATURA_TUTARI ISLEM_FATURA_TUTARI = new ISLEM_FATURA_TUTARI();

        }
        public class FATURA_BILGILERI
        {
            [System.Xml.Serialization.XmlElement("FATURA_BILGISI", Type = typeof(FATURA_BILGISI))]
            public List<FATURA_BILGISI> FATURA_BILGISI = new List<FATURA_BILGISI>();
        }
        public class FATURA_BILGISI
        {
            public FATURA_TARIHI FATURA_TARIHI = new FATURA_TARIHI();
            public FATURA_TUTARI FATURA_TUTARI = new FATURA_TUTARI();
            public MEDULA_TESLIM_NUMARASI MEDULA_TESLIM_NUMARASI = new MEDULA_TESLIM_NUMARASI();
            public FATURA_NUMARASI FATURA_NUMARASI = new FATURA_NUMARASI();

            [System.Xml.Serialization.XmlElement("ISLEM_FATURA_BILGISI", Type = typeof(ISLEM_FATURA_BILGISI))]
            public List<ISLEM_FATURA_BILGISI> ISLEM_FATURA_BILGISI = new List<ISLEM_FATURA_BILGISI>();
        }
        public static SYSMessage Get(Guid InternalObjectID, string InternalObjectDefName)
        {
            SYSMessage _SYSMessage = new SYSMessage();

            if (InternalObjectDefName.Equals("SUBEPISODEPROTOCOL"))
            {
                TTObjectContext objectContext = new TTObjectContext(true);

                SubEpisodeProtocol subEpisodeProtocol = objectContext.GetObject(InternalObjectID, InternalObjectDefName) as SubEpisodeProtocol;
                if (subEpisodeProtocol == null)
                    throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli SubEpisodeProtocol objesi bulunamadı.");

                if (subEpisodeProtocol.SubEpisode == null)
                    throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli SubEpisode objesi bulunamadı.");

                if (subEpisodeProtocol.InvoiceCollectionDetail == null || subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument == null)
                    throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli PayerInvoiceDocument objesi bulunamadı.");

                if (string.IsNullOrEmpty(subEpisodeProtocol.SubEpisode.SYSTakipNo))
                    throw new Exception("'104 Fatura Bilgisi Kayıt' paketini göndermek için gerekli SYSTakipNo bulunamadı.");

                _SYSMessage.recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = subEpisodeProtocol.SubEpisode.SYSTakipNo;

                FATURA_BILGISI faturaBilgisi = new FATURA_BILGISI();

                if (subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.DocumentDate.HasValue)
                    faturaBilgisi.FATURA_TARIHI.value = subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.DocumentDate.Value.ToString("yyyyMMddHHmm");

                if (subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.TotalPrice.HasValue)
                    faturaBilgisi.FATURA_TUTARI.value = subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.TotalPrice.Value.ToString().Replace(',', '.');

                faturaBilgisi.MEDULA_TESLIM_NUMARASI.value = subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.DocumentNo;
                faturaBilgisi.FATURA_NUMARASI.value = subEpisodeProtocol.InvoiceCollectionDetail.PayerInvoiceDocument.DocumentID.ToString();

                // Takip içindeki medulaya kaydedilmiş Hizmet Malzeme ve İlaç Bilgileri ISLEM_FATURA_BILGISI ne eklenir
                //List<Guid> subEpisodeList = new List<Guid>();
                //subEpisodeList.Add(subEpisodeProtocol.SubEpisode.ObjectID);
                // TODO:SEP
                IList<AccountTransaction> accTrxList = subEpisodeProtocol.AccountTransactions.Select("").Where(x => x.CurrentStateDefID == AccountTransaction.States.MedulaEntrySuccessful && !string.IsNullOrEmpty(x.MedulaProcessNo)).ToList(); //null; // AccountTransaction.GetTransactionsWithMedulaProcessNoBySEP(objectContext, subEpisodeList);

                foreach (AccountTransaction accTrx in accTrxList)
                {
                    if (accTrx.SubActionProcedure != null || accTrx.SubActionMaterial != null)
                    {
                        ISLEM_FATURA_BILGISI islemFaturaBilgisi = new ISLEM_FATURA_BILGISI();

                        if (accTrx.SubActionProcedure != null)
                            islemFaturaBilgisi.ISLEM_REFERANS_NUMARASI.value = accTrx.SubActionProcedure.ObjectID.ToString();
                        else if (accTrx.SubActionMaterial != null)
                            islemFaturaBilgisi.ISLEM_REFERANS_NUMARASI.value = accTrx.SubActionMaterial.ObjectID.ToString();

                        if (accTrx.MedulaPrice.HasValue)
                            islemFaturaBilgisi.ISLEM_FATURA_TUTARI.value = accTrx.MedulaPrice.Value.ToString().Replace(',', '.');

                        faturaBilgisi.ISLEM_FATURA_BILGISI.Add(islemFaturaBilgisi);
                    }
                }

                _SYSMessage.recordData.FATURA_BILGILERI.FATURA_BILGISI.Add(faturaBilgisi);
            }

            return _SYSMessage;
        }
    }
}
