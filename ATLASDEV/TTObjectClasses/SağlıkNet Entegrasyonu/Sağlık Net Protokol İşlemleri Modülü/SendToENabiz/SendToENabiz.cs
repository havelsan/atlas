
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;


using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace TTObjectClasses
{
    public partial class SendToENabiz : TTObject
    {

        public partial class GetCountOfSuccesPackage_Class : TTReportNqlObject
        {
        }

        public partial class GetCountOfToBeSentPackage_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();

            #endregion PreInsert
        }

        #region Methods
        public void ControlAndCreatePackageToSendToENabiz(TTObjectContext context, SubEpisode subEpisode, Guid objectID, string name, string packageCode)
        {
            IList sendToBeList;
            sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(context, objectID, packageCode);
            if (sendToBeList.Count == 0)
            {
                new SendToENabiz(context, subEpisode, objectID, name, packageCode, Common.RecTime());
            }
            context.Save();
        }
        public SendToENabiz(TTObjectContext objectContext, SubEpisode subEpisode, Guid internalObjectID, String internalObjectDefName, string packageCode, DateTime recordDate) : this(objectContext)
        {
            SubEpisode = subEpisode;
            InternalObjectID = internalObjectID;
            InternalObjectDefName = internalObjectDefName;
            PackageCode = packageCode;
            RecordDate = recordDate;
            Status = SendToENabizEnum.ToBeSent;
        }
        public SendToENabiz(TTObjectContext objectContext, SubEpisode subEpisode, Guid internalObjectID, String internalObjectDefName, string packageCode, DateTime recordDate, SendToENabizEnum status) : this(objectContext)
        {
            SubEpisode = subEpisode;
            InternalObjectID = internalObjectID;
            InternalObjectDefName = internalObjectDefName;
            PackageCode = packageCode;
            RecordDate = recordDate;
            Status = status;
        }
        public NabizResponse SendAndLogNABIZ(string Input, SendToENabiz sendToBe, TTObjectContext objectcontext, Guid? subepisode = null)
        {
            ResponseOfENabiz roen;
            NabizResponse res = new NabizResponse();
            try
            {
                string sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                var xdoc = new XmlDocument();
                xdoc.LoadXml(responce);
                sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");


                res.SYSTakipNo = sysTakipNo;
                res.SonucKodu = sonucKodu;
                res.SonucMesaji = sonucMesaji;

                if (subepisode != null)
                    sonucMesaji += " subepisode: " + subepisode;


                if (sonucKodu.Equals("S0000"))
                {
                    sendToBe.Status = SendToENabizEnum.Successful;
                    roen = new ResponseOfENabiz(objectcontext, sendToBe, "", "");
                }
                else
                {
                    sendToBe.Status = SendToENabizEnum.UnSuccessful;
                    roen = new ResponseOfENabiz(objectcontext, sendToBe, sonucKodu, sonucMesaji);
                }
            }
            catch (Exception ex)
            {
                sendToBe.Status = SendToENabizEnum.UnableToSent;
                roen = new ResponseOfENabiz(objectcontext, sendToBe, "SENDEX", ex.ToString());
            }

            return res;
        }

        public NabizResponse700 SendAndLogNABIZ700(string Input, SendToENabiz sendToBe, TTObjectContext objectcontext, Guid? subepisode = null)
        {
            ResponseOfENabiz roen;
            NabizResponse700 res = new NabizResponse700();
            try
            {
                string sonucKodu = "", sonucMesaji = "", sysTakipNo = "", response = "";
                response = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                var xdoc = new XmlDocument();
                xdoc.LoadXml(response);

                sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

                res.SYSTakipNo = sysTakipNo;
                res.SonucKodu = sonucKodu;
                res.SonucMesaji = sonucMesaji;

                // IslemKontrol bloğu için
                string xmlStringIslemKontrol = ENabizHelper.GetNodeListOuterXML(xdoc, "IslemKontrol");
                string xmlStringDokumanKontrol = ENabizHelper.GetNodeListOuterXML(xdoc, "DokumanKontrol");
                if (!string.IsNullOrWhiteSpace(xmlStringIslemKontrol))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<SendToENabiz.SGKBildirimKontrolIslem>), new XmlRootAttribute("IslemKontrol"));
                    StringReader stringReader = new StringReader(xmlStringIslemKontrol);
                    res.IslemKontrol.SGKBildirimKontrolIslem = (List<SendToENabiz.SGKBildirimKontrolIslem>)serializer.Deserialize(stringReader);
                }
                if (!string.IsNullOrWhiteSpace(xmlStringDokumanKontrol))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SendToENabiz.DokumanKontrol), new XmlRootAttribute("DokumanKontrol"));
                    StringReader stringReader = new StringReader(xmlStringDokumanKontrol);
                    res.DokumanKontrol = (SendToENabiz.DokumanKontrol)serializer.Deserialize(stringReader);
                }

                if (subepisode != null)
                    sonucMesaji += " subepisode: " + subepisode;

                if(res.IslemKontrol != null)
                    sonucMesaji += " IslemKontrolListesi: " + TTUtils.SaglikNetHelper.XMLSerialize(res.IslemKontrol);

                if (sonucKodu.Equals("S0000"))
                {
                    sendToBe.Status = SendToENabizEnum.Successful;
                    roen = new ResponseOfENabiz(objectcontext, sendToBe, "", "");
                }
                else
                {
                    sendToBe.Status = SendToENabizEnum.UnSuccessful;
                    roen = new ResponseOfENabiz(objectcontext, sendToBe, sonucKodu, sonucMesaji);
                }
            }
            catch (Exception ex)
            {
                sendToBe.Status = SendToENabizEnum.UnableToSent;
                roen = new ResponseOfENabiz(objectcontext, sendToBe, "SENDEX", ex.ToString());
            }

            return res;
        }

        public List<NabizResponse> ENABIZSend101(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeNQLList;
            List<NabizResponse> res = new List<NabizResponse>();
            if (InternalObjectID == null)
                sendToBeNQLList = SendToENabiz.GetToBeSent(objectcontext, "101");
            else
                sendToBeNQLList = SendToENabiz.GetByObjectID(objectcontext, new Guid(InternalObjectID), "101");


            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
            List<SendToENabiz> sendToBeList = ((BindingList<SendToENabiz>)sendToBeNQLList).Where(t => t.SubEpisode.OpeningDate <= Common.RecTime()).ToList();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                ResponseOfENabiz roen;
                if (sendToBeIn.SubEpisode.PatientAdmission.IsNewBorn == true||   (sendToBeIn.SubEpisode.Episode.Patient.IsTrusted.HasValue && sendToBeIn.SubEpisode.Episode.Patient.IsTrusted.Value))
                {
                    try
                    {
                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz101_HastaKayit.SYSMessage sYSMessage = ENabiz101_HastaKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                            var xdoc = new XmlDocument();
                            xdoc.LoadXml(responce);
                            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");
                            NabizResponse r = new NabizResponse();
                            r.SYSTakipNo = sysTakipNo;
                            r.SonucKodu = sonucKodu;
                            r.SonucMesaji = sonucMesaji;
                            res.Add(r);
                            if (sonucKodu.Equals("S0000") || sonucKodu.Equals("E2033"))
                            {
                                if (sonucKodu.Equals("E2033"))
                                {
                                    string[] temp = System.Text.RegularExpressions.Regex.Split(sonucMesaji, "SYSTakipNo=");
                                    string[] temp2 = System.Text.RegularExpressions.Regex.Split(temp[1].ToString(), "\"");
                                    sysTakipNo = temp2[0];

                                }
                                sendToBeIn.SubEpisode.SYSTakipNo = sysTakipNo;


                                sendToBeIn.Status = SendToENabizEnum.Successful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");

                            }
                            else
                            {
                                sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                                roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                            }
                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }

                    }
                    catch (Exception ex)
                    {
                        sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                        roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL101", ex.ToString());
                    }
                }
                else
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL101", "TC kimlik numarası KPS sisteminden doğrulanmadığı için gönderilmedi.(Patient.IsTrusted)");
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }


        public string ENABIZSend402(string SYSTakipNo)
        {
            ENabiz402_SYSTakipNoSorgulama.SYSMessage sYSMessage = ENabiz402_SYSTakipNoSorgulama.Get(SYSTakipNo);
            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string response = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
           
            return response;
        }

        public List<NabizResponse> ENABIZSend102(string InternalObjectID, bool? FromInvoice = null,string outherSysTakipNo = null)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            BindingList<SendToENabiz> sendToBeList;
            List<NabizResponse> res = new List<NabizResponse>();

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "102");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "102");

            ResponseOfENabiz roen;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            //Globals.ParallelForEachAll(sendToBeList, new ParallelOptions { MaxDegreeOfParallelism = 8 }, sendToBe =>
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                //Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz102_HizmetIlacMalzemeBilgisiKayit.SYSMessage sYSMessage = ENabiz102_HizmetIlacMalzemeBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, FromInvoice, outherSysTakipNo);
                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL102", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            //);
            objectcontext.Dispose();
            return res;
        }



        public List<NabizResponse> ENABIZSend102_V2()
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            BindingList<SendToENabiz> sendToBeList;
            List<NabizResponse> res = new List<NabizResponse>();


           

            //if (InternalObjectID == null)
            //    sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "102");
            //else
            //    sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "102");

            ResponseOfENabiz roen;
            //Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            //foreach (SendToENabiz sendToBe in sendToBeList)
            ////Globals.ParallelForEachAll(sendToBeList, new ParallelOptions { MaxDegreeOfParallelism = 8 }, sendToBe =>
            //{
            //    TTObjectContext objectcontextIn = new TTObjectContext(false);
            //    SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
            //    //Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
            //    try
            //    {
            //        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
            //        {
                        ENabiz102_HizmetIlacMalzemeBilgisiKayit.SYSMessage sYSMessage = ENabiz102_HizmetIlacMalzemeBilgisiKayit.Get_V2();
                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        //NabizResponse r = new NabizResponse();
                        //r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        //res.Add(r);

                        //string sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                        responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                        var xdoc = new XmlDocument();
                        xdoc.LoadXml(responce);
                        sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                        sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                        sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");


            //            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
            //        }
            //        else
            //        {
            //            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        sendToBeIn.Status = SendToENabizEnum.UnableToSent;
            //        roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL102", ex.ToString());
            //    }

            //    objectcontextIn.Save();
            //    objectcontextIn.Dispose();
            //}
            ////);
            //objectcontext.Dispose();
            return res;
        }


        public List<NabizResponse> ENABIZSend103(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "103");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "103");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz103_MuayeneBilgisiKayit.SYSMessage sYSMessage = ENabiz103_MuayeneBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL103", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend104(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "104");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "104");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = "";
                ResponseOfENabiz roen;
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz104_FaturaBilgisiKayit.SYSMessage sYSMessage = ENabiz104_FaturaBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL104", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;

        }
        public List<NabizResponse> ENABIZSend105(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            BindingList<SendToENabiz> sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "105");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "105");



            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            //Globals.ParallelForEachAll(sendToBeList, new ParallelOptions { MaxDegreeOfParallelism = 8 }, sendToBe =>
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                string Input = "";
                ResponseOfENabiz roen;
                try
                {

                    IList countOfSuccesPackage = SendToENabiz.GetCountOfSuccesPackage(objectcontextIn, sendToBeIn.InternalObjectID.Value, "102");

                    if (countOfSuccesPackage.Count > 0)
                    {
                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz105_LaboratuvarSonucKayit.SYSMessage sYSMessage = ENabiz105_LaboratuvarSonucKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                            NabizResponse r = new NabizResponse();
                            r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                            res.Add(r);
                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                        roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL1051", TTUtils.CultureService.GetText("M26934", "Sonuçların gönderilebilmesi için ilk önce hizmet kaydı yapılmalıdır."));
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL105", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            //);
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend106(string InternalObjectID, DateTime? dischargeDate = null)
        {
            TTObjectContext objectcontext = new TTObjectContext(false);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "106");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "106");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = "";
                ResponseOfENabiz roen;
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz106_CikisBilgisiKayit.SYSMessage sYSMessage = ENabiz106_CikisBilgisiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, dischargeDate);
                        if (sYSMessage != null)
                        {

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                            NabizResponse r = new NabizResponse();
                            r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                            res.Add(r);
                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                            roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL106", TTUtils.CultureService.GetText("M26983", "Taburculuk İşlemi İptal Edilmiş."));
                        }
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL106", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENabizSend_GunlukIslemler(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                using (var objectContext = new TTObjectContext(true))
                {
                    if (startDate.HasValue && endDate.HasValue)
                    {
                        var procedureList = SubActionProcedure.GetProceduresByDate((DateTime)startDate, (DateTime)endDate);
                        foreach (SubActionProcedure.GetProceduresByDate_Class item in procedureList)
                        {
                            ENABIZSend102(item.ObjectID.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<NabizResponse> ENABIZSend108(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "108");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "108");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    IList countOfSuccesPackage = SendToENabiz.GetCountOfSuccesPackage(objectcontextIn, sendToBeIn.InternalObjectID.Value, "102");

                    if (countOfSuccesPackage.Count > 0)
                    {
                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz108_TeleTipSonucKayit.SYSMessage sYSMessage = ENabiz108_TeleTipSonucKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                            Console.WriteLine(Input);
                            NabizResponse r = new NabizResponse();
                            r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                            res.Add(r);
                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL108", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend201(string InternalObjectID)
        {

            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "201");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "201");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz201_PatolojiKayit.SYSMessage sYSMessage = ENabiz201_PatolojiKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.WriteLine(Input);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL201", ex.Message);
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;

        }

        public List<NabizResponse> ENABIZSend244(string InternalObjectID)
        {

            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "244");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "244");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz244_OzellikliIzlemVeriSeti.SYSMessage sYSMessage = ENabiz244_OzellikliIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.WriteLine(Input);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL244", ex.Message);
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;

        }
        public List<NabizResponse> ENABIZSend203(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "203");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "203");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz203_AgizVeDisSagligiVeriSeti.SYSMessage sYSMessage = ENabiz203_AgizVeDisSagligiVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.WriteLine(Input);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL203", ex.Message);
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;

        }
        public List<NabizResponse> ENABIZSend252(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "252");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "252");


            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz252_KonsultasyonKayit.SYSMessage sYSMessage = ENabiz252_KonsultasyonKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL252", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENABIZSend901()
        {

            TTObjectContext objectcontextIn = new TTObjectContext(false);
            string Input;
            try
            {

                ENabiz901_YatakBilgisiKayit.SYSMessage sYSMessage = ENabiz901_YatakBilgisiKayit.Get();
                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                SendAndLogNABIZWOSYS(Input, "901", objectcontextIn);

            }
            catch (Exception ex)
            {
                ResponseOfENabizWOSYS roenwosys = new ResponseOfENabizWOSYS(objectcontextIn, "901", SendToENabizEnum.UnableToSent, "HVL901", ex.ToString());
            }

            objectcontextIn.Save();
            objectcontextIn.Dispose();



        }
        public void ENABIZSend501(string InternalObjectID)
        {

            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "501");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "501");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz501_EriskinYogunBakimSkoru.SYSMessage sYSMessage = ENabiz501_EriskinYogunBakimSkoru.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.WriteLine(Input);
                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL501", ex.Message);
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();

        }
        public void ENABIZSend905(string InternalObjectID)
        {

            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "905");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "905");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz905_EkOdemeKayit.SYSMessage sYSMessage = ENabiz905_EkOdemeKayit.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.WriteLine(Input);
                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL905", ex.Message);
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();

        }
        public List<NabizResponse> ENABIZSend214(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "214");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "214");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try 
                {
                    IList countOfSuccesPackage = SendToENabiz.GetCountOfSuccesPackageBySubepisode(objectcontextIn, sendToBeIn.SubEpisode.ObjectID, "103"); //Tanı muayenenin içinde gittiği için muayene paketi gitmiş mi kontrolü
                    if (countOfSuccesPackage.Count > 0)
                    {

                        if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                        {
                            ENabiz214_BulasiciHastalikBildirimVeriSeti.SYSMessage sYSMessage = ENabiz214_BulasiciHastalikBildirimVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                            Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                            NabizResponse r = new NabizResponse();
                            r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                            res.Add(r);
                            sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                        }
                        else
                        {
                            sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                        }
                    }
                    else
                    {
                        sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                        roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL214_1", "Bulaşıcı Hastalık Veri Setinin Gönderilebilmesi İçin Önce Muayene Kaydı Yapılmalıdır.");
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL214", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend219(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "219");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "219");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz219_EvdeSaglikHizmetiIlkIzlem.SYSMessage sYSMessage = ENabiz219_EvdeSaglikHizmetiIlkIzlem.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL219", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend215(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "215");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "215");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz215_DiyabetVeriSeti.SYSMessage sYSMessage = ENabiz215_DiyabetVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL215", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENABIZSend216(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "216");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "216");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz216_DiyalizHastasiBildirimVeriSeti.SYSMessage sYSMessage = ENabiz216_DiyalizHastasiBildirimVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL216", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend217(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "217");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "217");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz217_DiyalizHastasiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz217_DiyalizHastasiIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL217", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public List<NabizResponse> ENABIZSend235(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "235");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "235");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz235_KronikHastaliklarVeriSeti.SYSMessage sYSMessage = ENabiz235_KronikHastaliklarVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL235", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend236(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "236");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "236");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz236_KuduzProfilaksiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz236_KuduzProfilaksiIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL236", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend237(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "237");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "237");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz237_KuduzRiskliTemasBildirimVeriSeti.SYSMessage sYSMessage = ENabiz237_KuduzRiskliTemasBildirimVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL237", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend240(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "240");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "240");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz240_ObeziteIzlemVeriSeti.SYSMessage sYSMessage = ENabiz240_ObeziteIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL240", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend248(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "248");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "248");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz248_TutunKullanimiVeriSeti.SYSMessage sYSMessage = ENabiz248_TutunKullanimiVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL248", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend250(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "250");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "250");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz250_VeremVeriSeti.SYSMessage sYSMessage = ENabiz250_VeremVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL250", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend262(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            List<NabizResponse> res = new List<NabizResponse>();
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "262");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "262");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz262_HastaNakilBilgileri.SYSMessage sYSMessage = ENabiz262_HastaNakilBilgileri.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r =SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL262", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENABIZSend411(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "411");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "411");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz411_DoktorMesajiPaketi.SYSMessage sYSMessage = ENabiz411_DoktorMesajiPaketi.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL411", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public List<NabizResponse> ENABIZSend409(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;
            List<NabizResponse> res = new List<NabizResponse>();

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "409");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "409");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz409_RadyolojiSonucKayitPaketi.SYSMessage sYSMessage = ENabiz409_RadyolojiSonucKayitPaketi.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);


                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL409", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENABIZSend407(DateTime? endDateTime, int? dayLoopCount)
        {
            TTObjectContext objectcontextIn = new TTObjectContext(false);
            string Input;
            try
            {

                ENabiz407_GunSonuVeriSeti.SYSMessage sYSMessage = ENabiz407_GunSonuVeriSeti.Get(endDateTime, dayLoopCount);
                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                SendAndLogNABIZWOSYS(Input, "407", objectcontextIn);

            }
            catch (Exception ex)
            {
                ResponseOfENabizWOSYS roenwosys = new ResponseOfENabizWOSYS(objectcontextIn, "407", SendToENabizEnum.UnableToSent, "HVL407", ex.ToString());
            }

            objectcontextIn.Save();
            objectcontextIn.Dispose();


        }

        public void ENABIZSend407_PURSAKLAR()
        {
            TTObjectContext objectcontextIn = new TTObjectContext(false);
            string Input;
            try
            {

                ENabiz407_GunSonuVeriSeti.SYSMessage sYSMessage = ENabiz407_GunSonuVeriSeti.GetPursaklarGunSonu(null,31);
                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                SendAndLogNABIZWOSYS(Input, "407", objectcontextIn);

            }
            catch (Exception ex)
            {
                ResponseOfENabizWOSYS roenwosys = new ResponseOfENabizWOSYS(objectcontextIn, "407", SendToENabizEnum.UnableToSent, "HVL407", ex.ToString());
            }

            objectcontextIn.Save();
            objectcontextIn.Dispose();


        }

        public void ENABIZSend514()
        {

            TTObjectContext objectcontextIn = new TTObjectContext(false);
            string Input;
            try
            {

                ENabiz514_SaglikTesisiBilgileri.SYSMessage sYSMessage = ENabiz514_SaglikTesisiBilgileri.Get();
                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                SendAndLogNABIZWOSYS(Input, "514", objectcontextIn);

            }
            catch (Exception ex)
            {
                ResponseOfENabizWOSYS roenwosys = new ResponseOfENabizWOSYS(objectcontextIn, "514", SendToENabizEnum.UnableToSent, "HVL514", ex.ToString());
            }

            objectcontextIn.Save();
            objectcontextIn.Dispose();



        }
        public void ENABIZSend268(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "268");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "268");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.SubEpisode.ObjectID))
                    {

                        ENabiz268_HekimPuanBilgisi.SYSMessage sYSMessage = ENabiz268_HekimPuanBilgisi.Get(sendToBeIn.SubEpisode.ObjectID, sendToBeIn.InternalObjectID.Value);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.SubEpisode.ObjectID, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.SubEpisode.ObjectID];
                    }


                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL268", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend226(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "226");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "226");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz226_GozlukReceteBilgileri.SYSMessage sYSMessage = ENabiz226_GozlukReceteBilgileri.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL226", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend227(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "227");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "227");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz227_GETATVeriSeti.SYSMessage sYSMessage = ENabiz227_GETATVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL227", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public List<NabizResponse> ENABIZSend230(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "230");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "230");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz230_IntiharGirisimiveKrizTespitVeriSeti.SYSMessage sYSMessage = ENabiz230_IntiharGirisimiveKrizTespitVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL230", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend231(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "231");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "231");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz231_KadinaYonelikSiddetVeriSeti.SYSMessage sYSMessage = ENabiz231_KadinaYonelikSiddetVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL231", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }

        public List<NabizResponse> ENABIZSend502(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;
            List<NabizResponse> res = new List<NabizResponse>();

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "502");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "502");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz502_YogunBakimIzlemVeriSeti.SYSMessage sYSMessage = ENabiz502_YogunBakimIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                      res.Add(r);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL502", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend239(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "239");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "239");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz239_MaddeBagimliligiBildirimVeriSeti.SYSMessage sYSMessage = ENabiz239_MaddeBagimliligiBildirimVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL239", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend261(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "261");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "261");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz261_OlayAfetBilgisi.SYSMessage sYSMessage = ENabiz261_OlayAfetBilgisi.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL261", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public List<NabizResponse> ENABIZSend207(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "207");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "207");

            string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
            ResponseOfENabiz roen;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz207_AsiVeriSeti.SYSMessage sYSMessage = ENabiz207_AsiVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL207", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }
        public void ENABIZSend247(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "247");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "247");

            string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
            ResponseOfENabiz roen;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                Input = ""; sonucKodu = ""; sonucMesaji = ""; sysTakipNo = ""; responce = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz247_ToplumTabanliKanserTaramaVeriSeti.SYSMessage sYSMessage = ENabiz247_ToplumTabanliKanserTaramaVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);
                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        Console.Write(Input);
                        // MessageBox.Show(Input);
                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }

                }
                catch (Exception ex)
                {/*
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL207", ex.ToString());*/
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void SendAndLogNABIZWOSYS(string Input, string packageCode, TTObjectContext objectcontext)
        {
            ResponseOfENabizWOSYS roenwosys;
            try
            {
                string sonucKodu = "", sonucMesaji = "", response = "";
                response = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                var xdoc = new XmlDocument();
                xdoc.LoadXml(response);
                sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");

                if (sonucKodu.Equals("S0000"))
                {

                    roenwosys = new ResponseOfENabizWOSYS(objectcontext, packageCode, SendToENabizEnum.Successful, sonucKodu, sonucMesaji);
                }
                else
                {
                    roenwosys = new ResponseOfENabizWOSYS(objectcontext, packageCode, SendToENabizEnum.UnSuccessful, sonucKodu, sonucMesaji);
                }
            }
            catch (Exception ex)
            {
                roenwosys = new ResponseOfENabizWOSYS(objectcontext, packageCode, SendToENabizEnum.UnableToSent, "SENDEX", "");
            }

        }
        public void ENABIZSend302(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "302");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "302");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz302_HizmetSilme.SYSMessage sYSMessage = ENabiz302_HizmetSilme.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL302", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend301(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "301");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "301");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                string sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                try
                {

                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz301_HastaKayitSilme.SYSMessage sYSMessage = ENabiz301_HastaKayitSilme.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

                        var xdoc = new XmlDocument();
                        xdoc.LoadXml(responce);
                        sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
                        sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
                        sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");



                        if (sonucKodu.Equals("S0000"))
                        {

                            sendToBeIn.SubEpisode.SYSTakipNo = null;

                            sendToBeIn.Status = SendToENabizEnum.Successful;
                            roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "", "");

                        }
                        else
                        {
                            sendToBeIn.Status = SendToENabizEnum.UnSuccessful;
                            roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, sonucKodu, sonucMesaji);
                        }
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }


                    //SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);


                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL301", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }

        public bool ENABIZSend301_V2(string InternalObjectID)
        {
            bool isSucccesful = false;
            ENabiz301_HastaKayitSilme.SYSMessage sYSMessage = ENabiz301_HastaKayitSilme.Get_V2(new Guid(InternalObjectID));

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";

            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

            var xdoc = new XmlDocument();
            xdoc.LoadXml(responce);
            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");

            if (sonucKodu.Equals("S0000"))
            {
                isSucccesful = true;
            }

            return isSucccesful;


        }

            public void ENABIZSend210(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "210");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "210");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz210_BebekCocukBeslenmeVeriSeti.SYSMessage sYSMessage = ENabiz210_BebekCocukBeslenmeVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.SubEpisode.ObjectID);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL210", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend211(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "211");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "211");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz211_BebekOlumuVeriSeti.SYSMessage sYSMessage = ENabiz211_BebekOlumuVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL211", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend212(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "212");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "212");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz212_BebekCocukPsikososyalIzlemVeriSeti.SYSMessage sYSMessage = ENabiz212_BebekCocukPsikososyalIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.SubEpisode.ObjectID);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL212", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend218(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "218");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "218");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz218_DogumBildirimVeriSeti.SYSMessage sYSMessage = ENabiz218_DogumBildirimVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL218", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public void ENABIZSend238(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "238");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "238");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz238_LohusaIzlemVeriSeti.SYSMessage sYSMessage = ENabiz238_LohusaIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL238", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public string ENABIZSend200(string InternalObjectID, string PackageName)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            IList sendToBeList;


            ENabiz200_VeriPaketiSilme.SYSMessage sYSMessage = ENabiz200_VeriPaketiSilme.Get(new Guid(InternalObjectID), PackageName);
            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

            string responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);

            string sonucKodu = "", sonucMesaji = "", sysTakipNo = "";

            var xdoc = new XmlDocument();
            xdoc.LoadXml(responce);
            sonucKodu = ENabizHelper.GetNodeValue(xdoc, "sonucKodu");
            sonucMesaji = ENabizHelper.GetNodeValue(xdoc, "sonucMesaji");
            sysTakipNo = ENabizHelper.GetNodeValue(xdoc, "SYSTakipNo");


            objectcontext.Dispose();

            return sonucKodu + " - " + sonucMesaji + " SYSTakipNo=" + sysTakipNo;

        }
        public void ENABIZSend209(string InternalObjectID)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "209");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "209");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz209_BebekCocukIzlemVeriSeti.SYSMessage sYSMessage = ENabiz209_BebekCocukIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, sendToBeIn.SubEpisode.ObjectID);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);

                        SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);

                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL209", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
        }
        public List<NabizResponse> ENABIZSend229(string InternalObjectID)
        {
            List<NabizResponse> res = new List<NabizResponse>();
            TTObjectContext objectcontext = new TTObjectContext(true);

            IList sendToBeList;

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "229");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "229");

            string Input;

            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                ResponseOfENabiz roen;
                Input = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        ENabiz229_IntiharGirisimiVeKrizIzlemVeriSeti.SYSMessage sYSMessage = ENabiz229_IntiharGirisimiVeKrizIzlemVeriSeti.Get(sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName);

                        Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                        NabizResponse r = new NabizResponse();
                        r = SendAndLogNABIZ(Input, sendToBeIn, objectcontextIn);
                        res.Add(r);
                        sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL229", ex.ToString());
                }

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }



        #region SGK İşlem Bildir (700) Paketi
        public class ResponseOfSend700
        {
            public string sonucKodu { get; set; }
            public string sonucMesaji { get; set; }
            public List<SendToENabiz.sbHizmetKayitSonucDVO> sbHizmetKayitSonucDVO { get; set; }
        }

        public class sbHizmetKayitSonucDVO
        {
            public string sonucKodu { get; set; }
            public string sonucMesaji { get; set; }
            public string hizmetSunucuRefNo { get; set; }
        }

        public class SGKBildirimKontrolSonuc
        {
            public string SonucKodu { get; set; }
            public string SonucMesaji { get; set; }
        }

        public class IslemSonuc
        {
            public SendToENabiz.SGKBildirimKontrolSonuc SGKBildirimKontrolSonuc { get; set; }
        }

        public class SGKBildirimKontrolIslem
        {
            public string IslemReferansNumarasi { get; set; }

            public SendToENabiz.IslemSonuc IslemSonuc { get; set; }
        }

        public class IslemKontrol
        {
            public List<SendToENabiz.SGKBildirimKontrolIslem> SGKBildirimKontrolIslem { get; set; }
        }
        public class DokumanKontrol
        {
            public SendToENabiz.SGKBildirimKontrolSonuc SGKBildirimKontrolSonuc { get; set; }//TODO: AAE Bu satır uygun örnek geldiğinde List e çevrilecek. 
        }

        public static bool SGKBildirimOnline = true;
        public static DateTime SGKBildirimOnlineChangeDate = DateTime.Now;
        public List<NabizResponse700> ENABIZSend700(string InternalObjectID, bool? FromInvoice = null, List<AccountTransaction> accTrxList = null)
        {
            TTObjectContext objectcontext = new TTObjectContext(true);
            BindingList<SendToENabiz> sendToBeList;
            List<NabizResponse700> res = new List<NabizResponse700>();

            if (InternalObjectID == null)
                sendToBeList = SendToENabiz.GetToBeSentWithPackageCode(objectcontext, "700");
            else
                sendToBeList = SendToENabiz.GetByObjectIDWhichHasSYSTakipNo(objectcontext, new Guid(InternalObjectID), "700");

            ResponseOfENabiz roen;
            Dictionary<Guid, SendToENabizEnum> sentItems = new Dictionary<Guid, SendToENabizEnum>();
            List<AccountTransaction> excludedAccTrxList = null;
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                if (InternalObjectID == null) // Autoscript ten çağırıldığı zaman accTrxList her takip için boşaltılmalı, aşağıda ref olarak çağırıldığı için önceki takibin AccTrx leri kalıyor içinde.
                    accTrxList = null;
                excludedAccTrxList = new List<AccountTransaction>();

                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(sendToBe.ObjectID, typeof(SendToENabiz)) as SendToENabiz;
                string Input = "", sonucKodu = "", sonucMesaji = "", sysTakipNo = "", responce = "";
                try
                {
                    if (!sentItems.ContainsKey(sendToBeIn.InternalObjectID.Value))
                    {
                        for (int i = 0; i == 0 || (  i == 1 && excludedAccTrxList.Count() > 0 ); i++)
                        {
                            if (SGKBildirimOnlineChangeDate.ToShortDateString() != DateTime.Now.ToShortDateString() && !SGKBildirimOnline)
                            {
                                SGKBildirimOnline = true;
                                SGKBildirimOnlineChangeDate = DateTime.Now;
                            }
                             
                            ENabiz700_SGKISLEMBILDIR.SYSMessage sYSMessage = ENabiz700_SGKISLEMBILDIR.Get(objectcontextIn, sendToBeIn.InternalObjectID.Value, sendToBeIn.InternalObjectDefName, SGKBildirimOnline, ref accTrxList, excludedAccTrxList, FromInvoice);
                            if (sYSMessage.recordData.SGK_ISLEM_BILDIR.BILDIRILECEK_ISLEM.Count() > 0)
                            {
                                Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
                                NabizResponse700 r = new NabizResponse700();
                                r = SendAndLogNABIZ700(Input, sendToBeIn, objectcontextIn);
                                res.Add(r);

                                if (r.SonucKodu.Equals("S0000"))
                                {
                                    foreach (AccountTransaction item in accTrxList)
                                    {
                                        if (excludedAccTrxList.Count(x => x.ObjectID == item.ObjectID) == 0)
                                        {
                                            item.Nabiz700Status = SendToENabizEnum.Successful;
                                            item.NabizResultCode = null;
                                            item.NabizResultMessage = null;
                                        }
                                    }

                                }
                                else if (r.SonucKodu.Equals("E0020") && SGKBildirimOnline)
                                {
                                    SGKBildirimOnline = false;
                                    SGKBildirimOnlineChangeDate = DateTime.Now;
                                }
                                else if (r.SonucKodu.Equals("E2031") && r.IslemKontrol?.SGKBildirimKontrolIslem == null)
                                {
                                    foreach (AccountTransaction item in accTrxList)
                                    {
                                        item.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                        item.NabizResultCode = r.SonucKodu;
                                        item.NabizResultMessage = r.SonucMesaji;   
                                    }
                                }
                                else if (r.SonucKodu.Equals("E8000"))
                                {
                                    if (r.IslemKontrol.SGKBildirimKontrolIslem.Count() > 0)
                                    {
                                        foreach (SendToENabiz.SGKBildirimKontrolIslem item in r.IslemKontrol.SGKBildirimKontrolIslem)
                                        {
                                            string medulaRefNo = sYSMessage.recordData.SGK_ISLEM_BILDIR.BILDIRILECEK_ISLEM.FirstOrDefault(x => x.ISLEM_REFERANS_NUMARASI.value == item.IslemReferansNumarasi.Trim()).SGK_HIZMET_REFERANS_NUMARASI.value;

                                            AccountTransaction accTrx = accTrxList.FirstOrDefault(x => x.MedulaReferenceNumber == medulaRefNo);
                                            if (accTrx != null)
                                            {
                                                if (item?.IslemSonuc?.SGKBildirimKontrolSonuc?.SonucKodu == "0000")
                                                {
                                                    accTrx.Nabiz700Status = SendToENabizEnum.Successful;
                                                    accTrx.NabizResultMessage = null;
                                                    accTrx.NabizResultCode = null;
                                                }
                                                else
                                                {
                                                    excludedAccTrxList.Add(accTrx);
                                                    accTrx.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                                    accTrx.NabizResultCode = item?.IslemSonuc?.SGKBildirimKontrolSonuc?.SonucKodu;
                                                    accTrx.NabizResultMessage = item?.IslemSonuc?.SGKBildirimKontrolSonuc?.SonucMesaji;
                                                }
                                            }
                                        }
                                    }
                                    if(r.DokumanKontrol?.SGKBildirimKontrolSonuc != null)
                                    {
                                        foreach (AccountTransaction item in accTrxList)
                                        {
                                            item.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                            item.NabizResultCode = r.DokumanKontrol.SGKBildirimKontrolSonuc.SonucKodu;
                                            item.NabizResultMessage = r.DokumanKontrol.SGKBildirimKontrolSonuc.SonucMesaji;   
                                        }
                                    }
                                }
                                else
                                {
                                    int iofResult = r.SonucMesaji.IndexOf("Medula yanıt mesaji:");
                                    int iofrefNoResult = r.SonucMesaji.IndexOf("Düzeltilmesi gereken işlem referans numarası:");
                                    if (iofResult > 0)
                                    {
                                        string modelString = r.SonucMesaji.Substring(iofResult + 20, r.SonucMesaji.Length - iofResult - 20);
                                        SendToENabiz.ResponseOfSend700 response = JsonConvert.DeserializeObject<SendToENabiz.ResponseOfSend700>(modelString);

                                        foreach (SendToENabiz.sbHizmetKayitSonucDVO item in response.sbHizmetKayitSonucDVO)
                                        {
                                            AccountTransaction accTrx = accTrxList.FirstOrDefault(x => x.MedulaReferenceNumber == item.hizmetSunucuRefNo);
                                            if (accTrx != null)
                                            {
                                                if (item.sonucKodu == "0000")
                                                {
                                                    accTrx.Nabiz700Status = SendToENabizEnum.Successful;
                                                    accTrx.NabizResultMessage = null;
                                                    accTrx.NabizResultCode = null;
                                                }
                                                else
                                                {
                                                    excludedAccTrxList.Add(accTrx);
                                                    accTrx.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                                    accTrx.NabizResultCode = item.sonucKodu;
                                                    accTrx.NabizResultMessage = item.sonucMesaji;
                                                }
                                            }
                                        }
                                    }
                                    else if (iofrefNoResult > 0)
                                    {
                                        string refString = r.SonucMesaji.Substring(iofrefNoResult + 45, r.SonucMesaji.Length - iofrefNoResult - 45);
                                        string[] splittedString = refString.Split(',');
                                        foreach (string item in splittedString)
                                        {
                                            //TODO: AAE item bizdeki referans numarası hiç gitmemişse buraya düşüyor ve diğerlerini kayıt etmiyor.
                                            string medulaRefNo = sYSMessage.recordData.SGK_ISLEM_BILDIR.BILDIRILECEK_ISLEM.FirstOrDefault(x => x.ISLEM_REFERANS_NUMARASI.value == item.Trim()).SGK_HIZMET_REFERANS_NUMARASI.value;

                                            AccountTransaction accTrx = accTrxList.FirstOrDefault(x => x.MedulaReferenceNumber == medulaRefNo);
                                            if (accTrx != null)
                                            {
                                                excludedAccTrxList.Add(accTrx);
                                                accTrx.Nabiz700Status = SendToENabizEnum.UnSuccessful;
                                                accTrx.NabizResultCode = r.SonucKodu;
                                                accTrx.NabizResultMessage = r.SonucMesaji;
                                            }
                                        }
                                    }
                                }
                                if(i == 0)//ilk turda ekleyelim sadece
                                sentItems.Add(sendToBeIn.InternalObjectID.Value, sendToBeIn.Status.Value);
                            }
                            else
                                throw new Exception("Gönderilecek hizmet bulunamadı.");
                        }
                    }
                    else
                    {
                        sendToBeIn.Status = sentItems[sendToBeIn.InternalObjectID.Value];
                    }
                }
                catch (Exception ex)
                {
                    sendToBeIn.Status = SendToENabizEnum.UnableToSent;
                    roen = new ResponseOfENabiz(objectcontextIn, sendToBeIn, "HVL700", ex.ToString());
                }
                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
            objectcontext.Dispose();
            return res;
        }

        #endregion

        #region Hata Almış Paketleri Tekrar Kuyruğa Ekleme

        public void SendENabizPackagesWithResponseCode()
        {

            List<string> responsecodeList = new List<string>();
            responsecodeList.Add("SENDEX");
            responsecodeList.Add("E0001");//İşlem sırasında hata alındı. Lütfen tekrar deneyin!
            responsecodeList.Add("E2007");//Merge and persist
            responsecodeList.Add("E2006");//Merge and persist
            responsecodeList.Add("E2998");//Doküman başka bir istek tarafından kullanılmaktadır. Lütfen daha sonra tekrar deneyiniz...	
            responsecodeList.Add("E0020");//SysTakipNo başına hatalı istek limit aşımı. Limit: dakikada 3 istek.
            responsecodeList.Add("HVL1051");//105 paket önce 102 gönderilmelidir hatası
            responsecodeList.Add("HVL214_1");//214 bulaşıcı hastalık önce muayene gönderilmelidir hatası.
            DateTime endDate = DateTime.Now.Date;
            DateTime startDate = endDate.AddDays(-7);

            BindingList<SendToENabiz.GetPackagesByErrorCode_Class> sendToBeList = SendToENabiz.GetPackagesByErrorCode(responsecodeList, startDate, endDate);

            foreach (SendToENabiz.GetPackagesByErrorCode_Class sendToBe in sendToBeList)
            {
                TTObjectContext objectcontextIn = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectcontextIn.GetObject(new Guid(sendToBe.ObjectID.ToString()), typeof(SendToENabiz)) as SendToENabiz;
                sendToBeIn.Status = SendToENabizEnum.ToBeSent;

                objectcontextIn.Save();
                objectcontextIn.Dispose();
            }
    
        }
        #endregion
        public void SendPathologyReportsToENabiz()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
          
            BindingList<SendToENabiz> sendToBeList  = SendToENabiz.GetToBeSentWithPackageCode(objectContext, "201"); // Sırada bekleyen Patolojiler
            foreach (SendToENabiz sendToBe in sendToBeList)
            {
                //Patoloji raporuna ait işlemlerin 102lerini gönder 
                try
                {
                    Pathology pathology = (Pathology)objectContext.GetObject(sendToBe.InternalObjectID.Value, sendToBe.InternalObjectDefName);
                    foreach (PathologyTestProcedure test in pathology.PathologyTestProcedures)
                    {
                        if(test.CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                            ENABIZSend102(test.ObjectID.ToString());
                    }
                    //Patoloji Raporunu Gönder
                    ENABIZSend201(pathology.ObjectID.ToString());
                }catch(Exception ex)
                {

                }
            }
        }

     


            #endregion Methods

        }

        public class NabizResponse //Nabız gönderim sonuçlarını kullanıcıya uyarı vermek için kullanılan nesne
    {
        public string SYSTakipNo;
        public string SonucKodu;
        public string SonucMesaji;
        public NabizResponse()
        {
            SYSTakipNo = "";
            SonucKodu = "";
            SonucMesaji = "";
        }
    }

    public class NabizResponse700 : NabizResponse //Nabız gönderim sonuçlarını kullanıcıya uyarı vermek için kullanılan nesne
    {
        public SendToENabiz.IslemKontrol IslemKontrol;
        public SendToENabiz.DokumanKontrol DokumanKontrol;
        public NabizResponse700()
        {
            SYSTakipNo = "";
            SonucKodu = "";
            SonucMesaji = "";
            IslemKontrol = new SendToENabiz.IslemKontrol();
            DokumanKontrol = new SendToENabiz.DokumanKontrol();
        }
    }
}