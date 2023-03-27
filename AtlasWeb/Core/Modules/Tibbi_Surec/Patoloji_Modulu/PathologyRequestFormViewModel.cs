//$B3E60DEE
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Infrastructure.Helpers;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Net;
using System.IO;

namespace Core.Controllers
{
    public partial class PathologyRequestServiceController
    {
        partial void PreScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTObjectContext objectContext)
        {
            //if (pathologyRequest.Episode.Diagnosis.Count == 0)
            //    throw new TTUtils.TTException( "Bu işlem herhangi bir tanısı olmayan kabullerde başlatılamaz.");

            viewModel._PathologyRequest.RequestDate = DateTime.Now;
            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                viewModel._PathologyRequest.FromResource = episodeAction.MasterResource;
                viewModel._PathologyRequest.MasterAction = episodeAction;
                viewModel._PathologyRequest.Episode = episodeAction.Episode;
                //Geçici olarak eklendi
                string pathologyResourceID = TTObjectClasses.SystemParameter.GetParameterValue("PATOLOJI", "1dd51b8e-ed9c-4fa0-a6b9-18b3969ae881");

                ResSection masterResource = (ResSection)objectContext.GetObject(new Guid(pathologyResourceID), TTObjectDefManager.Instance.GetObjectDef(typeof (ResSection))); //Patoloji
       
                viewModel._PathologyRequest.MasterResource = masterResource;
                if (Common.CurrentResource.TakesPerformanceScore == true)
                {
                    viewModel._PathologyRequest.RequestDoctor = Common.CurrentResource;
                    viewModel._PathologyRequest.RequestDoctor.PhoneNumber = Common.CurrentResource.PhoneNumber;
                }
                else
                {
                    if (episodeAction.ProcedureDoctor != null)
                    {
                        viewModel._PathologyRequest.RequestDoctor = episodeAction.ProcedureDoctor;
                        viewModel._PathologyRequest.RequestDoctor.PhoneNumber = episodeAction.ProcedureDoctor.PhoneNumber;
                    }
                }
            }

            viewModel.PathologyMaterialsGridList = new PathologyMaterial[0];
            viewModel._ForceSelectPathologyProcedure = TTObjectClasses.SystemParameter.GetParameterValue("PATOLOJITETKIKSECIM", "FALSE").ToUpper() == "TRUE" ? true : false;
            ContextToViewModel(viewModel, objectContext);
        //viewModel._PathologyRequest.RequestDoctor
        //viewModel._PathologyRequest.RequestDoctor.PhoneNumber  
        }

        partial void PostScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            foreach (PathologyMaterial material in pathologyRequest.PathologyMaterials)
            {
                foreach (RequestedPathologyProcedures procedure in viewModel._ProcedureArray)
                {
                    if (procedure.MaterialNo == material.No)
                    {
                        var pathologyTest = new PathologyTestProcedure(objectContext);
                        var pathologyDef = (PathologyTestDefinition)objectContext.GetObject(procedure.ProcedureDefObjectID, "PathologyTestDefinition");
                        pathologyTest.ProcedureObject = pathologyDef;
                        pathologyTest.Amount = procedure.Amount;
                        pathologyTest.PathologyMaterial = material;
                        pathologyTest.PathologyRequest = pathologyRequest;
                        pathologyTest.ActionDate = DateTime.Now;
                        pathologyTest.EpisodeAction = pathologyRequest; //İstek kabul edilirken materyallerin patolojileri set edilecek.
                        pathologyTest.CurrentStateDefID = PathologyTestProcedure.States.New;
                        pathologyTest.FromClinic = true;
                    }
                }
            }

            Guid? selectedEpisodeActionID = viewModel.GetSelectedEpisodeActionID();
            if (selectedEpisodeActionID.HasValue)
            {
                EpisodeAction episodeAction = objectContext.GetObject<EpisodeAction>(selectedEpisodeActionID.Value);
                pathologyRequest.MasterAction = episodeAction;
            }

            pathologyRequest.CurrentStateDefID = PathologyRequest.States.Request;
        }

        [HttpGet]
        public RequestedPathologyProcedures AddNewPathologyProcedure([FromQuery] string ProcedureDefObjectId, [FromQuery] string EpisodeActionObjectId)
        {
            TTObjectContext objContext = new TTObjectContext(true);
            ProcedureDefinition ttProcedureDefinition = (ProcedureDefinition)objContext.GetObject(new Guid(ProcedureDefObjectId), "ProcedureDefinition");
            RequestedPathologyProcedures vmRequestedProcedure = new RequestedPathologyProcedures();
            var objectContext = new TTObjectContext(false);
            vmRequestedProcedure.ProcedureCode = ttProcedureDefinition.Code;
            vmRequestedProcedure.ProcedureName = ttProcedureDefinition.Name;
            vmRequestedProcedure.RequestDate = Common.RecTime();
            vmRequestedProcedure.RequestBy = Common.CurrentUser.Name;
            vmRequestedProcedure.Amount = 1;
            vmRequestedProcedure.ProcedureUser = ""; // patolojinin işlemi yapan doktoru gelecek
            vmRequestedProcedure.ProcedureDefObjectID = new Guid(ProcedureDefObjectId);
            //Geçici olarak eklendi
            string pathologyResourceID = TTObjectClasses.SystemParameter.GetParameterValue("PATOLOJI", "1dd51b8e-ed9c-4fa0-a6b9-18b3969ae881");

            ResSection masterResource = (ResSection)objectContext.GetObject(new Guid(pathologyResourceID), TTObjectDefManager.Instance.GetObjectDef(typeof (ResSection))); //Patoloji
            vmRequestedProcedure.MasterResource = masterResource.Name;
            return vmRequestedProcedure;
        }

        partial void AfterContextSaveScript_PathologyRequestForm(PathologyRequestFormViewModel viewModel, PathologyRequest pathologyRequest, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            pathologyRequest.RequestMaterialNumber.GetNextValue();
            objectContext.Save();
            int count = 1;
            bool hasFrozen = false;
            for (int i = 0; i < pathologyRequest.PathologyMaterials.Count; i++)
            {
                pathologyRequest.PathologyMaterials[i].MaterialNumber = pathologyRequest.RequestMaterialNumber.Value.ToString() + "-" + count.ToString();
                if (pathologyRequest.PathologyMaterials[i].NumuneAlinmaSekli.KODU == "4") //Skrsde frozenın kodu değişirse buranın güncellenmesi gerekir
                    hasFrozen = true;
                count++;
            }

            objectContext.Save();
            pathologyRequest.HasFrozen = hasFrozen;
            pathologyRequest.CurrentStateDefID = PathologyRequest.States.Accept;

            objectContext.Save();


            //Gaziler için entegrasyon
            //CallFonetLabWebServiceForPathology(pathologyRequest);



        }

        private void CallFonetLabWebServiceForPathology(PathologyRequest pathologyRequest)
        {
            var _url = "http://31.223.33.135:5555/FonetLabWebService/Services/TetkikService";
            var _action = ""; //Neden boş

            XmlDocument soapEnvelopeXml = CreatePatHizmetEkleInput(pathologyRequest);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(soapResult);
                string jsonText = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);

                // To convert JSON text contained in string json into an XML node

                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonText);
            }
        }

        private static XmlDocument CreatePatHizmetEkleInput(PathologyRequest pathologyRequest)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            string kullaniciAdi = "10000000000";
            string sifre = "FONET1";
            Patient patient = pathologyRequest.SubEpisode.Episode.Patient;
            string gender = patient.Sex.KODU == "1" ? "Erkek" : "Kadin";
            string sb = "<soapenv:Envelope xmlns:soapenv = \"http://schemas.xmlsoap.org/soap/envelope/\" xmlns: tem = \"http://tempuri.org/\" >" +
                            "<soapenv:Header/>" +
                            "<soapenv:Body>" +
                                "<PatHizmetEkle>" +
                                 "< !--Optional:-->" +
                                 "<tetkikIstem>" +
                                    "<KullaniciBilgi>" +
                                        "<KullaniciAdi>" + kullaniciAdi + "</KullaniciAdi>" +
                                        "<Password>" + sifre + "</Password>" +
                                     "</KullaniciBilgi>" +
                                     "<Hasta>" +
                                        "<TCKimlikNo>" + patient.UniqueRefNo.ToString() + "</TCKimlikNo>" +
                                        "<HT_ID>" + patient.ObjectID.ToString() + "</HT_ID>" + //Arşiv numarasının veritabanındaki objecti
                                        "<HT_KODU>" + patient.ID.ToString() + "</HT_KODU>" + //Hasta Arşiv numarası
                                        "<Adi>" + patient.Name + "</Adi >" +
                                        "<SoyAdi>" + patient.Surname + "</SoyAdi>" +
                                        "<DogumTarihi>" + patient.BirthDate + "</DogumTarihi>" +
                                        "<Cinsiyet>" + gender + "</Cinsiyet>" +
                                        "<Telefon>?</Telefon>" + //Optional
                                    "</Hasta>" +
                                    "<IsteyenServis>" + pathologyRequest.FromResource.Name + "</IsteyenServis>" +
                                    "<IsteyenServisId>" + pathologyRequest.FromResource.ObjectID.ToString() + "</IsteyenServisId>" +
                                    "<IsteyenDoktor>" + pathologyRequest.RequestDoctor.Name + "</IsteyenDoktor>" +
                                    "  < IsteyenDoktorAd >?</ IsteyenDoktorAd >" +//Optional
                                    "    < IsteyenDoktorSoyad >?</ IsteyenDoktorSoyad >" +//Optional
                                    "<IsteyenDoktorId>" + pathologyRequest.RequestDoctor.ObjectID.ToString() + "</IsteyenDoktorId>" +
                                    "<IsteyenDoktorTC>" + pathologyRequest.RequestDoctor.UniqueNo.ToString() + "</IsteyenDoktorTC>" +
                                    "<OnTaniKodu>?</OnTaniKodu>" +//Optional
                                    "<NumuneAlimTarih>" + pathologyRequest.PathologyMaterials[0].DateOfSampleTaken + "</NumuneAlimTarih>" +
                                    "<NumuneAlimKullanici >?</ NumuneAlimKullanici >" +//Optional
                                    "<AHDurum>false</AHDurum>" +
                                    "<PatIstem>" +
                                        "<PatIstemID>?</PatIstemID >" +//??
                                        "<IstemAciklamasi>" + pathologyRequest.PathologyMaterials[0].Description + "</IstemAciklamasi>" +//
                                        "< KlinikOyku >?</ KlinikOyku >" +//Optional
                                        "< KlinikTani >?</ KlinikTani >" +//Optional
                                        "< PatServisAd >?</ PatServisAd >" +//Optional
                                        "< PatServisID >?</ PatServisID >" +//Optional
                                        "< AlimSaat >?</ AlimSaat >" +//Optional
                                        "< AlimTarih >" + pathologyRequest.PathologyMaterials[0].DateOfSampleTaken + "</ AlimTarih >" +
                                        "<AlimSekli>" + pathologyRequest.PathologyMaterials[0].NumuneAlinmaSekli.ADI + "</AlimSekli>" +
                                        "<AlimYer>" + pathologyRequest.PathologyMaterials[0].YerlesimYeri.KODTANIMI + "</AlimYer>" +
                                        "< AlimYon >?</ AlimYon >" +//Optional
                                        "< AlimTaraf >?</ AlimTaraf >" +//Optional
                                        "< DefterNo >?</ DefterNo >" +//Optional
                                        "< Sitoloji >?</ Sitoloji >" +//Optional
                                        "< OrganDokuLokalizasyon >?</ OrganDokuLokalizasyon >" +//Optional
                                        "< LaboratuvarSonuc >?</ LaboratuvarSonuc >" +//Optional
                                        "< TahminiAgirlik >?</ TahminiAgirlik >" +//Optional
                                        "< KavanozTip >?</ KavanozTip >" +//Optional
                                        "< SolüsyonTip >?</ SolüsyonTip >" +//Optional
                                        "<DokuTemelOzellik>" + pathologyRequest.PathologyMaterials[0].AlindigiDokununTemelOzelligi.ADI + "</DokuTemelOzellik>" +
                                        "<AlinmaYontemi>" + pathologyRequest.PathologyMaterials[0].NumuneAlinmaSekli.ADI + "</AlinmaYontemi>" +
                                    "</PatIstem>" +
                                    "<TetkikListesi>" +//Netleşmesi gerekiyor
                                        " <long>5751</long>" +
                                    "</TetkikListesi>" +
                                 "</tetkikIstem>" +
                             "</PatHizmetEkle>" +
                         "</soapenv : Body>" +
                    "</soapenv : Envelope >";
            soapEnvelopeDocument.LoadXml(sb);

            return soapEnvelopeDocument;
        }
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
        [HttpGet]
        public SKRSICDOYERLESIMYERI[] GetSKRSYerlesimYeri()
        {
            SKRSICDOYERLESIMYERI[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSICDOYERLESIMYERI>().ToArray();
                //var query = from i in ttList
                //            orderby i.TOPOGRAFIKODU
                //            select new SKRSListObject
                //            {
                //                ObjectID = i.ObjectID,
                //                Name = i.TOPOGRAFIKODU + " - " + i.KODTANIMI,
                //                Code = i.SKRSKODU.ToString(),
                //            };
                //    result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public SKRSNumuneAlindigiDokununTemelOzelligi[] GetSKRSAlindigiDokununTemelOzelligi()
        {
            SKRSNumuneAlindigiDokununTemelOzelligi[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSNumuneAlindigiDokununTemelOzelligi>().ToArray();
                //var query = from i in ttList
                //            orderby i.KODU
                //            select new SKRSNumuneAlindigiDokununTemelOzelligi
                //            {
                //                ObjectDe
                //                ObjectID = i.ObjectID,
                //                Name = i.ADI,
                //                Code = i.KODU,
                //            };
                //result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public SKRSNumuneAlinmaSekli[] GetSKRSNumuneAlinmaSekli()
        {
            SKRSNumuneAlinmaSekli[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<SKRSNumuneAlinmaSekli>().ToArray();
                //var query = from i in ttList
                //            orderby i.KODU
                //            select new SKRSListObject
                //            {
                //                ObjectID = i.ObjectID,
                //                Name = i.ADI,
                //                Code = i.KODU,
                //            };
                //result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }

        [HttpGet]
        public PathologyJarTypeDef[] GetKavanozTipi()
        {
            PathologyJarTypeDef[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                result = objectContext.QueryObjects<PathologyJarTypeDef>().ToArray();
                //var query = from i in ttList
                //            orderby i.KODU
                //            select new SKRSListObject
                //            {
                //                ObjectID = i.ObjectID,
                //                Name = i.ADI,
                //                Code = i.KODU,
                //            };
                //result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }

            return result;
        }
    }
}

namespace Core.Models
{
    public partial class PathologyRequestFormViewModel
    {
        public object _selectedProcedureObject
        {
            get;
            set;
        }

        public RequestedPathologyProcedures[] _ProcedureArray
        {
            get;
            set;
        }

        public bool _ForceSelectPathologyProcedure { get; set; }
    }

    public class SKRSListObject
    {
        public SKRSListObject(Guid? _objectID, string _name, string _code)
        {
            this.ObjectID = _objectID;
            this.Name = _name;
            this.Code = _code;
        }

        public SKRSListObject()
        {
            this.ObjectID = new Guid();
            this.Name = "";
            this.Code = "";
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
    }

    public class RequestedPathologyProcedures
    {
        public int MaterialNo;
        public Guid SubActionProcedureObjectId;
        public string ProcedureCode;
        public string ProcedureName;
        public int Amount;
        public double UnitPrice;
        public DateTime RequestDate;
        public string RequestBy;
        public string ProcedureUser;
        public string MasterResource;
        public Guid CurrentStateDefID;
        public Guid ProcedureDefObjectID;
    }
}