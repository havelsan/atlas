using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTInstanceManagement;


namespace TTObjectClasses
{
    public class ENabiz700_SGKISLEMBILDIR
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
                messageType.code = "700";
                messageType.value = "SGK ISLEM BILDIR";
            }

        }
        public class recordData
        {
            public SGK_ISLEM_BILDIR SGK_ISLEM_BILDIR;
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public class SGK_ISLEM_BILDIR
        {

            [System.Xml.Serialization.XmlElement("BILDIRILECEK_ISLEM", Type = typeof(BILDIRILECEK_ISLEM))]
            public List<BILDIRILECEK_ISLEM> BILDIRILECEK_ISLEM = new List<BILDIRILECEK_ISLEM>();

        }
        public class BILDIRILECEK_ISLEM
        {
            public ISLEM_REFERANS_NUMARASI ISLEM_REFERANS_NUMARASI = new ISLEM_REFERANS_NUMARASI();
            public SGK_TAKIP_NUMARASI SGK_TAKIP_NUMARASI = new SGK_TAKIP_NUMARASI();
            public SGK_HIZMET_REFERANS_NUMARASI SGK_HIZMET_REFERANS_NUMARASI = new SGK_HIZMET_REFERANS_NUMARASI();
            public SGK_BILDIRIM SGK_BILDIRIM = new SGK_BILDIRIM();
        }
        public static SYSMessage Get(TTObjectContext objectContext,Guid InternalObjectGuid, string InternalObjectDefName,bool sgkBildirimKontrol, ref List<AccountTransaction> accTrxList, List<AccountTransaction> excludedAccTrxList = null, bool? FromInvoice = null)
        {
            SYSMessage _SYSMessage = new SYSMessage();
            recordData _recordData = new recordData();


            _recordData.SGK_ISLEM_BILDIR = new SGK_ISLEM_BILDIR();
            _recordData.HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();
            SubEpisodeProtocol sep = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubEpisodeProtocol;
            if (sep != null && !sep.IsCancelled)
            {
                if (sep.SubEpisode.SYSTakipNo == null)
                    throw new Exception("SubEpisode a ait SYSTakipNo bulunamadı.");
                else
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sep.SubEpisode.SYSTakipNo;

                List<AccountTransaction> sendList = null;

                if (accTrxList != null && accTrxList.Count > 0)
                    sendList = accTrxList;
                else
                {
                    List<Guid> stateList = new List<Guid>() { AccountTransaction.States.New , AccountTransaction.States.MedulaEntryUnsuccessful,AccountTransaction.States.MedulaEntrySuccessful };
                    
                    if (FromInvoice == true)
                        sendList = AccountTransaction.GetTransactionsToSendMedulaBySEP(objectContext, sep.ObjectID, stateList).ToList();
                    else
                        sendList = AccountTransaction.GetTransactionsToSendMedulaBySEP(objectContext, sep.ObjectID, stateList).Where(x => x.Nabiz700Status != SendToENabizEnum.Successful).ToList();
                }

                accTrxList = sendList;

                foreach (var item in sendList)
                {
                    if (excludedAccTrxList == null || (excludedAccTrxList != null && excludedAccTrxList.Count(x => x.ObjectID == item.ObjectID) == 0))
                    {
                        BILDIRILECEK_ISLEM BILDIRILECEK_ISLEM = new BILDIRILECEK_ISLEM();

                        if (item.SubActionProcedure != null)
                            BILDIRILECEK_ISLEM.ISLEM_REFERANS_NUMARASI.value = item.SubActionProcedure.ObjectID.ToString();
                        else
                            BILDIRILECEK_ISLEM.ISLEM_REFERANS_NUMARASI.value = item.ENabizMaterial != null && item.ENabizMaterial.Count > 0 ? item.ENabizMaterial[0].ObjectID.ToString() : "";

                        if (FromInvoice == true && sgkBildirimKontrol == true)
                            BILDIRILECEK_ISLEM.SGK_BILDIRIM.value = "2";
                        else
                            BILDIRILECEK_ISLEM.SGK_BILDIRIM.value = "1";

                        BILDIRILECEK_ISLEM.SGK_TAKIP_NUMARASI.value = item.SubEpisodeProtocol.MedulaTakipNo;
                        BILDIRILECEK_ISLEM.SGK_HIZMET_REFERANS_NUMARASI.value = item.MedulaReferenceNumber;

                        _recordData.SGK_ISLEM_BILDIR.BILDIRILECEK_ISLEM.Add(BILDIRILECEK_ISLEM);
                    }
                }

            }
            _SYSMessage.recordData = _recordData;

            return _SYSMessage;

        }
    }
}
