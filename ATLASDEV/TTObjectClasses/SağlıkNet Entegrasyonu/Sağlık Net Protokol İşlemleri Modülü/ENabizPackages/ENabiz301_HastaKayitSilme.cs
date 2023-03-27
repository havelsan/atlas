using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TTInstanceManagement;

namespace TTObjectClasses
{
    public class ENabiz301_HastaKayitSilme
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
                messageType.code = "301";
                messageType.value = TTUtils.CultureService.GetText("M25793", "Hasta Kayıt Silme");
            }
        }
        public class recordData
        {
            public HASTA_TAKIP_BILGISI HASTA_TAKIP_BILGISI = new HASTA_TAKIP_BILGISI();

        }
        public class HASTA_TAKIP_BILGISI
        {
            public SYSTakipNo SYSTakipNo = new SYSTakipNo();
        }
        public static SYSMessage Get(Guid InternalObjectGuid, string InternalObjectDefName) // InternalObjectGuid cancel olmuş subepisodeIDsi , sysTakipNo parametresi karşıya kayıt paketi gitmiş ancak cevap alınamamış sonra da subepisode'u iptal olmuş paketlerin iptal paketinin gönderilmesi için eklendi
        {
            recordData _recordData = new recordData();

            TTObjectContext objectContext = new TTObjectContext(false);

            SubEpisode sp = objectContext.GetObject(InternalObjectGuid, InternalObjectDefName) as SubEpisode;
            if (sp != null)
            {
                if (sp.SYSTakipNo == null)
                {
                    string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                    ENabiz101_HastaKayit.SYSMessage sYSMessage = ENabiz101_HastaKayit.Get(InternalObjectGuid, InternalObjectDefName);
                    Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                    responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                    var xdoc = new XmlDocument();
                    xdoc.LoadXml(responce);
                    sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                    sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                    sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");



                    if (sonucKodu.Equals("S0000") || sonucKodu.Equals("E2033"))
                    {
                        if (sonucKodu.Equals("E2033"))
                        {
                            string[] temp = System.Text.RegularExpressions.Regex.Split(sonucMesaji, "SYSTakipNo=");
                            string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp[1].ToString(), "\"");
                            sysTakipNo = temp2[0];
                            _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sysTakipNo;
                        }
                    }
                }
                else
                {
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SYSTakipNo;
                }
            }



            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }

        public static SYSMessage Get_V2(Guid InternalObjectGuid) 
        { 
            recordData _recordData = new recordData();

            TTObjectContext objectContext = new TTObjectContext(false);

            SubEpisode sp = objectContext.GetObject(InternalObjectGuid, typeof(SubEpisode)) as SubEpisode;
            if (sp != null)
            {
               
                    _recordData.HASTA_TAKIP_BILGISI.SYSTakipNo.value = sp.SYSTakipNo;
                
            }



            SYSMessage _sYSMessage = new SYSMessage();
            _sYSMessage.recordData = _recordData;
            return _sYSMessage;
        }
    }
}
