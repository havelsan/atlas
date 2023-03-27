//$5C414B4A
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml.Serialization;
using Core.Security;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Reflection;
using System.Collections;
using System.Xml;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class ENabizPackageManagementServiceController
    {


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public ENabizPackagesFormViewModel LoadENabizPackagesFormViewModel()
        {
            var viewModel = new ENabizPackagesFormViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                viewModel._NabizResult = new List<NabizResult>();

                viewModel._NabizSearchCritaria = new NabizSearchCritaria();
                viewModel._NabizSearchCritaria.packageAddingDateStart = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._NabizSearchCritaria.packageAddingDateEnd = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._NabizSearchCritaria.SubepisodeOpeningDateStart = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._NabizSearchCritaria.SubepisodeOpeningDateEnd = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._NabizSearchCritaria.SearchType = 0;//ekran a��l�rken kabul tarihine g�re sorgula se�ili geliyor.
                viewModel._NabizSearchCritaria.packageStatus = 5;
                viewModel.NabizPackageList = new List<PackageInfo>();//dx-tag-box a paket t�rlerini dolurmak i�in
                BindingList<ENabizPackageDefinition.GetENabizPackageDefinitions_Class> packageDefList = TTObjectClasses.ENabizPackageDefinition.GetENabizPackageDefinitions("ORDER BY PACKAGEID ASC");
                foreach(ENabizPackageDefinition.GetENabizPackageDefinitions_Class item in packageDefList)
                {
                    PackageInfo n = new PackageInfo();
                    n.Code = Convert.ToInt32(item.PackageID);
                    n.PackageName = item.PackageID.ToString() + " - " + item.PackageName;
                    viewModel.NabizPackageList.Add(n);
                }

                //G�n Sonu

                viewModel._DailyBasedNabizSearchCritaria = new DailyBasedNabizSearchCritaria();
                viewModel._DailyBasedNabizSearchCritaria.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._DailyBasedNabizSearchCritaria.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._DailyBasedNabizResult = new List<DailyBasedNabizResult>();

                //Kabul-Hasta Bazl�
                viewModel._SubepisodeBasedNabizSearchCritaria = new SubepisodeBasedNabizSearchCritaria();
                viewModel._SubepisodeBasedNabizSearchCritaria.StartDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "00:00:00");
                viewModel._SubepisodeBasedNabizSearchCritaria.EndDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " " + "23:59:59");
                viewModel._SubepisodeBasedNabizSearchCritaria.HasSYSNo = false;
                objectContext.FullPartialllyLoadedObjects();
            }
           
            return viewModel;
        }

        
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public List<NabizResult> GetENabizPackages(NabizSearchCritaria searchModel)
        {
            List<NabizResult> eNabizPackagesFormResultList = new List<NabizResult>();
            using (var objectContext = new TTObjectContext(true))
            {
               
                List<string> packageCodeList = new List<string>();
                foreach (PackageInfo package in searchModel.NabizPackages)
                {
                    packageCodeList.Add(package.Code.ToString());
                }

                List<SendToENabizEnum> statusList = new List<SendToENabizEnum>();
                if (searchModel.packageStatus == 5)
                {
                    statusList.Add(SendToENabizEnum.Successful);
                    statusList.Add(SendToENabizEnum.UnableToSent);
                    statusList.Add(SendToENabizEnum.ToBeSent);
                    statusList.Add(SendToENabizEnum.NotToBeSent);
                    statusList.Add(SendToENabizEnum.UnSuccessful);
                }
                else if (searchModel.packageStatus == 0)
                    statusList.Add(SendToENabizEnum.ToBeSent);
                else if (searchModel.packageStatus == 1)
                    statusList.Add(SendToENabizEnum.Successful);
                else if (searchModel.packageStatus == 2)
                    statusList.Add(SendToENabizEnum.UnSuccessful);
                else if (searchModel.packageStatus == 3)
                    statusList.Add(SendToENabizEnum.UnableToSent);
                else if (searchModel.packageStatus == 4)
                    statusList.Add(SendToENabizEnum.NotToBeSent);

                string filter = "";
                if (searchModel.SearchType == 1)
                {

                    filter = " AND THIS.RECORDDATE BETWEEN " + GetDateAsString(searchModel.packageAddingDateStart) + " AND " + GetDateAsString(searchModel.packageAddingDateEnd);

                }else
                {
                    filter = " AND THIS.SUBEPISODE.OPENINGDATE BETWEEN " + GetDateAsString(searchModel.SubepisodeOpeningDateStart) + " AND " + GetDateAsString(searchModel.SubepisodeOpeningDateEnd);
                }


                List<SendToENabiz.SendToENabizLog_Class> packagesList = new List<SendToENabiz.SendToENabizLog_Class>();

                packagesList = SendToENabiz.SendToENabizLog( packageCodeList, statusList, filter).ToList();

                if (packagesList.Count > 0)
                {
                    List<ENabizPackageDefinition.GetENabizPackageDefinitions_Class> definitionList = new List<ENabizPackageDefinition.GetENabizPackageDefinitions_Class>();

                    definitionList = ENabizPackageDefinition.GetENabizPackageDefinitions(objectContext, "").ToList();


                    foreach (SendToENabiz.SendToENabizLog_Class package in packagesList)
                    {

                        NabizResult eNabizPackagesFormResultModel = new NabizResult();
                        ENabizPackageDefinition.GetENabizPackageDefinitions_Class definition = definitionList.FirstOrDefault(t => t.PackageID.ToString() == package.PackageCode);

                        eNabizPackagesFormResultModel.PackageCode = Convert.ToInt32(package.PackageCode);
                        eNabizPackagesFormResultModel.PackageName = definition.PackageName;

                        if (package.Status == SendToENabizEnum.Successful)
                        {
                            eNabizPackagesFormResultModel.PackageStatus = "G�nderim Ba�ar�l�";
                        }
                        else if (package.Status == SendToENabizEnum.UnableToSent)
                        {
                            eNabizPackagesFormResultModel.PackageStatus = "Paket G�nderilemedi";
                        }
                        else if (package.Status == SendToENabizEnum.ToBeSent)
                        {
                            eNabizPackagesFormResultModel.PackageStatus = "G�nderim S�ras�nda";
                        }
                        else if (package.Status == SendToENabizEnum.NotToBeSent)
                        {
                            eNabizPackagesFormResultModel.PackageStatus = "G�nderilmeyecek";
                        }
                        else if (package.Status == SendToENabizEnum.UnSuccessful)
                        {
                            eNabizPackagesFormResultModel.PackageStatus = "G�nderim Ba�ar�s�z";
                        }
                        eNabizPackagesFormResultModel.SendToENabizInternalObjectID = (Guid)package.InternalObjectID;
                        eNabizPackagesFormResultModel.SendToENabizInternalObjectDef = package.InternalObjectDefName;
                        eNabizPackagesFormResultModel.SendToENabizObjectID = (Guid)package.ObjectID;
                        eNabizPackagesFormResultModel.PatientName = package.Patientname + " " + package.Patientsurname;
                        eNabizPackagesFormResultModel.PatientAdmissionNo = package.ProtocolNo;
                        if (package.Responsemessage != null)
                            eNabizPackagesFormResultModel.ResponseFromENabiz = package.Responsemessage.ToString();
                        if (package.Senddate != null)
                            eNabizPackagesFormResultModel.PackageSendDate = ((DateTime)package.Senddate).ToString("dd.MM.yyyy hh:mm");

                        if (package.Responsecode != null)
                            eNabizPackagesFormResultModel.ResultCode = package.Responsecode.ToString();
                        else
                            eNabizPackagesFormResultModel.ResultCode = "";

                        if (package.SYSTakipNo != null)
                            eNabizPackagesFormResultModel.SYSTakipNo = package.SYSTakipNo.ToString();
                        else
                            eNabizPackagesFormResultModel.SYSTakipNo = "";

                        eNabizPackagesFormResultList.Add(eNabizPackagesFormResultModel);
                    }

                }

               
                

                
                return eNabizPackagesFormResultList;
            }


        }

        [HttpPost]
        public void sendGunSonuLoop(Date_Input input)
        {
            SendToENabiz s = new SendToENabiz();
            for (int i = 0; i < 7; i++)
            {
                s.ENABIZSend407(input.endDateStart.AddDays(i * -10),null);
            }
        }


        [HttpPost]
        public void sendGunSonu(Date_Input input)
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend407(input.endDateStart,null);
        }



        [HttpPost]
        public void sendGunSonuOneDate(Date_Input input)
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend407(input.endDateStart.AddDays(1), 1);
        }

        [HttpPost]
        public void sendGunSonuPursaklar()
        {
            SendToENabiz s = new SendToENabiz();
            //s.ENABIZSend407_PURSAKLAR();
            //s.ENABIZSend407(input.endDateStart.AddDays(1), 1);
        }

        [HttpPost]
        public void sendOlayAfet()
        {
            SKRSOlayAfetBilgisiGetir s = new SKRSOlayAfetBilgisiGetir();
            s.GetSKRSOlayAfetBilgisi(1);
            //s.ENABIZSend407_PURSAKLAR();
            //s.ENABIZSend407(input.endDateStart.AddDays(1), 1);
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public void SendENabizPackages(List<NabizResult> packageList)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();

            //foreach (NabizResult package in packageList)
            //{
            //    try
            //    {
            //        var packageID = package.ENabizPackageDefinition.PackageID;
            //        if (packageID == 101)
            //        {
            //            sendToENabiz.ENABIZSend101(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 102)
            //        {
            //            sendToENabiz.ENABIZSend102(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 103)
            //        {
            //            sendToENabiz.ENABIZSend103(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 104)
            //        {
            //            sendToENabiz.ENABIZSend104(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 105)
            //        {
            //            sendToENabiz.ENABIZSend105(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 106)
            //        {
            //            sendToENabiz.ENABIZSend106(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 108)
            //        {
            //            sendToENabiz.ENABIZSend108(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 200)
            //        {
            //            sendToENabiz.ENABIZSend200(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 201)
            //        {
            //            sendToENabiz.ENABIZSend201(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 203)
            //        {
            //            sendToENabiz.ENABIZSend203(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 207)
            //        {
            //            sendToENabiz.ENABIZSend207(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 209)
            //        {
            //            sendToENabiz.ENABIZSend209(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 210)
            //        {
            //            sendToENabiz.ENABIZSend210(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 211)
            //        {
            //            sendToENabiz.ENABIZSend211(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 212)
            //        {
            //            sendToENabiz.ENABIZSend212(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 214)
            //        {
            //            sendToENabiz.ENABIZSend214(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 215)
            //        {
            //            sendToENabiz.ENABIZSend215(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 216)
            //        {
            //            sendToENabiz.ENABIZSend216(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 217)
            //        {
            //            sendToENabiz.ENABIZSend217(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 218)
            //        {
            //            sendToENabiz.ENABIZSend218(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 219)
            //        {
            //            sendToENabiz.ENABIZSend219(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 226)
            //        {
            //            sendToENabiz.ENABIZSend226(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 229)
            //        {
            //            sendToENabiz.ENABIZSend229(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 230)
            //        {
            //            sendToENabiz.ENABIZSend230(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 231)
            //        {
            //            sendToENabiz.ENABIZSend231(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 235)
            //        {
            //            sendToENabiz.ENABIZSend235(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 236)
            //        {
            //            sendToENabiz.ENABIZSend236(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 237)
            //        {
            //            sendToENabiz.ENABIZSend237(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 238)
            //        {
            //            sendToENabiz.ENABIZSend238(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 239)
            //        {
            //            sendToENabiz.ENABIZSend239(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 240)
            //        {
            //            sendToENabiz.ENABIZSend240(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 247)
            //        {
            //            sendToENabiz.ENABIZSend247(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 248)
            //        {
            //            sendToENabiz.ENABIZSend248(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 250)
            //        {
            //            sendToENabiz.ENABIZSend250(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 252)
            //        {
            //            sendToENabiz.ENABIZSend252(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 261)
            //        {
            //            sendToENabiz.ENABIZSend261(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 262)
            //        {
            //            sendToENabiz.ENABIZSend262(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 268)
            //        {
            //            sendToENabiz.ENABIZSend268(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 301)
            //        {
            //            sendToENabiz.ENABIZSend301(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 302)
            //        {
            //            sendToENabiz.ENABIZSend302(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 409)
            //        {
            //            sendToENabiz.ENABIZSend409(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 411)
            //        {
            //            sendToENabiz.ENABIZSend411(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 501)
            //        {
            //            sendToENabiz.ENABIZSend501(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 905)
            //        {
            //            sendToENabiz.ENABIZSend905(package.SendToENabizInternalObjectID.ToString());
            //        }
            //        else if (packageID == 101)
            //        {
            //            sendToENabiz.ENABIZSend101(package.SendToENabizInternalObjectID.ToString());
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }
            //}
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public void AddQueue(List<NabizResult> packageList)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();

            foreach (NabizResult package in packageList)
            {

                TTObjectContext objectContext = new TTObjectContext(false);
                SendToENabiz sendToBeIn = objectContext.GetObject(package.SendToENabizObjectID, typeof(SendToENabiz)) as SendToENabiz;
                sendToBeIn.Status = SendToENabizEnum.ToBeSent;
                objectContext.Save();
                objectContext.Dispose();
            }
  
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public List<NabizResponse> SendPackageToENabiz(NabizResult package)
        {
            List<NabizResponse> result = new List<NabizResponse>();

            SendToENabiz sendToENabiz = new SendToENabiz();
            try
            {
                PackageDetail data = new PackageDetail();
                data.InternalObjectID = package.SendToENabizInternalObjectID;
                data.SendToEnabizObjectID = package.SendToENabizObjectID;
                data.PackageCode = package.PackageCode;
                List<NabizResponse> r = new List<NabizResponse>();
                r = SendNabizPackage(data);
                if (r.Count > 0)
                    result.Add(r[0]);



            }
            catch (Exception ex)
            {
               
            }

            return result;
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public void SendDailyBasedPackageToENabiz(DailyBasedNabizResult package)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();
            try
            {
                sendToENabiz.ENABIZSend407(Convert.ToDateTime(package.SendDate),10);
            }
            catch (Exception ex)
            {

            }
        }
        public class Date_Input
        {
            public DateTime endDateStart
            {
                get;
                set;
            }
        }

        [HttpPost]
        public void send202Dummy()
        {
            ENabiz202_15_49YasKadinIzlemVeriSeti.SYSMessage sYSMessage = ENabiz202_15_49YasKadinIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send204Dummy()
        {
            ENabiz204_AnneOlumVeriSeti.SYSMessage sYSMessage = ENabiz204_AnneOlumVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send205Dummy()
        {
            ENabiz205_AsiErtelemeIptalVeriSeti.SYSMessage sYSMessage = ENabiz205_AsiErtelemeIptalVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send206Dummy()
        {
            ENabiz206_AsiSonrasiIstenmeyenEtkiVeriSeti.SYSMessage sYSMessage = ENabiz206_AsiSonrasiIstenmeyenEtkiVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send207Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend207("b8dc2b84-3e9c-4ccf-9fa7-bdbde593220e");
        }

        [HttpPost]
        public void send208Dummy()
        {
            ENabiz208_XXXXXXlikOlurRaporuVeriSeti.SYSMessage sYSMessage = ENabiz208_XXXXXXlikOlurRaporuVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send209Dummy()
        {
            ENabiz209_BebekCocukIzlemVeriSeti.SYSMessage sYSMessage = ENabiz209_BebekCocukIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send210Dummy()
        {
            ENabiz210_BebekCocukBeslenmeVeriSeti.SYSMessage sYSMessage = ENabiz210_BebekCocukBeslenmeVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send211Dummy()
        {
            ENabiz211_BebekOlumuVeriSeti.SYSMessage sYSMessage = ENabiz211_BebekOlumuVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send212Dummy()
        {
            ENabiz212_BebekCocukPsikososyalIzlemVeriSeti.SYSMessage sYSMessage = ENabiz212_BebekCocukPsikososyalIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send216Dummy()
        {
            ENabiz216_DiyalizHastasiBildirimVeriSeti.SYSMessage sYSMessage = ENabiz216_DiyalizHastasiBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send217Dummy()
        {
            ENabiz217_DiyalizHastasiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz217_DiyalizHastasiIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send218Dummy()
        {
            ENabiz218_DogumBildirimVeriSeti.SYSMessage sYSMessage = ENabiz218_DogumBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send219Dummy()
        {
            ENabiz219_EvdeSaglikHizmetiIlkIzlem.SYSMessage sYSMessage = ENabiz219_EvdeSaglikHizmetiIlkIzlem.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send220Dummy()
        {
            ENabiz220_EvdeSaglikHizmetiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz220_EvdeSaglikHizmetiIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send221Dummy()
        {
            ENabiz221_GebeIzlemVeriSeti.SYSMessage sYSMessage = ENabiz221_GebeIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }
        [HttpPost]
        public void send222Dummy()
        {
            ENabiz222_GebePsikososyalIzlemVeriSeti.SYSMessage sYSMessage = ENabiz222_GebePsikososyalIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send223Dummy()
        {
            ENabiz223_GebelikBildirimVeriSeti.SYSMessage sYSMessage = ENabiz223_GebelikBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send224Dummy()
        {
            ENabiz224_GebelikSonucuVeriSeti.SYSMessage sYSMessage = ENabiz224_GebelikSonucuVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send225Dummy()
        {
            ENabiz225_GenclikSagligiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz225_GenclikSagligiIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send229Dummy()
        {
            ENabiz229_IntiharGirisimiVeKrizIzlemVeriSeti.SYSMessage sYSMessage = ENabiz229_IntiharGirisimiVeKrizIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send230Dummy()
        {
            ENabiz230_IntiharGirisimiveKrizTespitVeriSeti.SYSMessage sYSMessage = ENabiz230_IntiharGirisimiveKrizTespitVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send231Dummy()
        {
            ENabiz231_KadinaYonelikSiddetVeriSeti.SYSMessage sYSMessage = ENabiz231_KadinaYonelikSiddetVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send236Dummy()
        {
            ENabiz236_KuduzProfilaksiIzlemVeriSeti.SYSMessage sYSMessage = ENabiz236_KuduzProfilaksiIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send237Dummy()
        {
            ENabiz237_KuduzRiskliTemasBildirimVeriSeti.SYSMessage sYSMessage = ENabiz237_KuduzRiskliTemasBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send238Dummy()
        {
            ENabiz238_LohusaIzlemVeriSeti.SYSMessage sYSMessage = ENabiz238_LohusaIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send239Dummy()
        {
            ENabiz239_MaddeBagimliligiBildirimVeriSeti.SYSMessage sYSMessage = ENabiz239_MaddeBagimliligiBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send240Dummy()
        {
            ENabiz240_ObeziteIzlemVeriSeti.SYSMessage sYSMessage = ENabiz240_ObeziteIzlemVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send241Dummy()
        {
            ENabiz241_OlumBildirimVeriSeti.SYSMessage sYSMessage = ENabiz241_OlumBildirimVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send247Dummy()
        {
            ENabiz247_ToplumTabanliKanserTaramaVeriSeti.SYSMessage sYSMessage = ENabiz247_ToplumTabanliKanserTaramaVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }
        [HttpPost]
        public void send248Dummy()
        {
            ENabiz248_TutunKullanimiVeriSeti.SYSMessage sYSMessage = ENabiz248_TutunKullanimiVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send249Dummy()
        {
            ENabiz249_VeremTaramaVeriSeti.SYSMessage sYSMessage = ENabiz249_VeremTaramaVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send250Dummy()
        {
            ENabiz250_VeremVeriSeti.SYSMessage sYSMessage = ENabiz250_VeremVeriSeti.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send257Dummy()
        {
            ENabiz257_CocukDiyabetBildirim.SYSMessage sYSMessage = ENabiz257_CocukDiyabetBildirim.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send258Dummy()
        {
            ENabiz258_CocukDiyabetIzlem.SYSMessage sYSMessage = ENabiz258_CocukDiyabetIzlem.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send260Dummy()
        {
            ENabiz260_NobetciPersonelBilgisiKayit.SYSMessage sYSMessage = ENabiz260_NobetciPersonelBilgisiKayit.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send261Dummy()
        {
            ENabiz261_OlayAfetBilgisi.SYSMessage sYSMessage = ENabiz261_OlayAfetBilgisi.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send262Dummy()
        {
            ENabiz262_HastaNakilBilgileri.SYSMessage sYSMessage = ENabiz262_HastaNakilBilgileri.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send501Dummy()
        {
            ENabiz501_EriskinYogunBakimSkoru.SYSMessage sYSMessage = ENabiz501_EriskinYogunBakimSkoru.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send512Dummy()
        {
            ENabiz512_ASALYoklamaDurumuSorgula.SYSMessage sYSMessage = ENabiz512_ASALYoklamaDurumuSorgula.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send905Dummy()
        {
            ENabiz905_EkOdemeKayit.SYSMessage sYSMessage = ENabiz905_EkOdemeKayit.GetDummy();

            string Input = TTUtils.SaglikNetHelper.XMLSerialize(sYSMessage);
            string responce = "";
            responce = SYSServis.WebMethods.SYSSendMessageSync(TTObjectClasses.Sites.SiteLocalHost, Input);
        }

        [HttpPost]
        public void send268Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend268("cdd8b76e-2dae-468c-ac1c-9bc582ca9a27");
        }

        [HttpPost]
        public void send101Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend101("2626d405-17cd-4c13-bd62-689a5ac68338");
        }

        [HttpPost]
        public void send102Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            //s.ENABIZSend409("f4eb70b1-3ded-4777-a593-6cce9e2a2e5b");
            //s.ENABIZSend102("8663d3cf-df4e-4130-83cc-17085e70713c");
            s.ENABIZSend102_V2();
        }
        [HttpPost]
        public void send502Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend502("aaaaa5ce-554d-4cd5-a238-a961adb44fe9");
        }

        [HttpPost]
        public void send106Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend106("721128f6-6cc0-4cb5-a354-1a92cfd02826");
        }

        [HttpPost]
        public void send302Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend302("0e3fc010-705b-41ea-8cbf-e31a01e2030a");
        }

        [HttpPost]
        public void send105Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend105("809bd4c2-49fc-4869-b784-abace73d5297");
        }

        [HttpPost]
        public void send262()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend262("475d95b7-7d99-5eb7-e053-799cc70a2f0f");
        }

        [HttpPost]
        public void send301()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend301_V2("473b1c75-9c3f-4a28-94eb-83c7b0f6f4ee");
        }


        [HttpPost]
        public void send103Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend103("99dfe306-c4b3-4c57-b607-be8afe7ecfbf");
        }

        [HttpPost]
        public void send108Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend108("59cc87a2-60cf-424d-b8c1-a783eadbe19b");
        }

        [HttpPost]
        public void send201Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend201(null);
            //s.SendPathologyReportsToENabiz();


        }

        [HttpPost]
        public void send200Dummy()
        {
            SendToENabiz s = new SendToENabiz();
            s.ENABIZSend200("0d8a4a6b-ff5d-4b5b-b861-963d604570c5", "BULASICI_HASTALIK_BILDIRIM");

        }

        [HttpPost]
        public void SendNabizPackagesWithErrorCode()
        {
            SendToENabiz s = new SendToENabiz();
            s.SendENabizPackagesWithResponseCode();

        }

        [HttpPost]
        public void SendSmsDoctor()
        {
            SendSMSDoctorPATDelay s = new SendSMSDoctorPATDelay();
            s.TaskScript();

        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public List<DailyBasedNabizResult> GetDailyBasedENabizPackages(DailyBasedNabizSearchCritaria searchModel)
        {
            List<DailyBasedNabizResult> dailyBasedResultList = new List<DailyBasedNabizResult>();
            using (var objectContext = new TTObjectContext(true))
            {
                List<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class> resultList = new List<ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class>();
                resultList = ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz((DateTime)searchModel.StartDate, (DateTime)searchModel.EndDate, 407, null).ToList();

                foreach (ResponseOfENabizWOSYS.GetDailyBasedResponseOfNabiz_Class result in resultList)
                {
                    DailyBasedNabizResult resultModel = new DailyBasedNabizResult();
                    resultModel.ObjectID = new Guid(result.ObjectID.ToString());
                    resultModel.SendDate = ((DateTime)result.SendDate).ToString("dd.MM.yyyy hh:mm");

                    if (result.Status == SendToENabizEnum.Successful)
                        resultModel.Status = "G�nderim Ba�ar�l�";
                    else if (result.Status == SendToENabizEnum.UnSuccessful)
                        resultModel.Status = "G�nderim Ba�ar�s�z";

                    resultModel.ResponseCode = result.ResponseCode;
                    resultModel.ResponseMessage = result.ResponseMessage;
                    dailyBasedResultList.Add(resultModel);
                }

            }

            return dailyBasedResultList;

        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public List<SubepisodeBasedNabizResult> GetSubepisodes(SubepisodeBasedNabizSearchCritaria searchModel)
        {
            List<SubepisodeBasedNabizResult> resultList = new List<SubepisodeBasedNabizResult>();
            string _filter = "";
            if (!String.IsNullOrEmpty(searchModel.ProtocolNo))
            {
                if (searchModel.ProtocolNo.Contains("-"))
                {
                    _filter = " AND THIS.PROTOCOLNO = '" + searchModel.ProtocolNo.Trim() + "'";
                }
                else
                    _filter = " AND THIS.PROTOCOLNO LIKE '" + searchModel.ProtocolNo.Trim() + "%'";

            }
            else if (!String.IsNullOrEmpty(searchModel.PatientObjectID))
            {
                _filter = " AND THIS.EPISODE.PATIENT = '" + searchModel.PatientObjectID + "'";
            }
            else if (!String.IsNullOrEmpty(searchModel.SYSTakipNo))
            {
                _filter = " AND THIS.SYSTakipNo = '" + searchModel.SYSTakipNo + "'";
            }
            else
            {
                _filter = " AND THIS.OPENINGDATE BETWEEN " + GetDateAsString(searchModel.StartDate) + " AND " + GetDateAsString(searchModel.EndDate);

                if (searchModel.HasSYSNo)
                    _filter += " AND THIS.SYSTakipNo IS NULL";
            }
            using (var objectContext = new TTObjectContext(true))
            {
                List<SubEpisode.GetSubepisodesForENabiz_Class> subepisodes = new List<SubEpisode.GetSubepisodesForENabiz_Class>();
                subepisodes = SubEpisode.GetSubepisodesForENabiz(_filter).ToList();
 
                foreach (SubEpisode.GetSubepisodesForENabiz_Class subepisode in subepisodes)
                {
                    SubepisodeBasedNabizResult resultModel = new SubepisodeBasedNabizResult();
                    resultModel.ObjectID = new Guid(subepisode.ObjectID.ToString());
                    resultModel.OpeningDate = Convert.ToDateTime(subepisode.OpeningDate).ToString("dd.MM.yyyy hh:mm");
                    resultModel.ProtocolNo = subepisode.ProtocolNo;
                    resultModel.Ressection = subepisode.Ressectionname;
                    resultModel.PatientNameSurname = subepisode.Name + " " + subepisode.Surname;
                    resultModel.SYSTakipNo = subepisode.SYSTakipNo == null ? "" : subepisode.SYSTakipNo;
                    resultList.Add(resultModel);
                }

            }

            return resultList;

        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public List<PackageDetail> GetSubepisodePackageDetails(string subepisodeObjectID)
        {
            List<PackageDetail> resultList = new List<PackageDetail>();

            using (var objectContext = new TTObjectContext(false))
            {

                List<ENabizPackageDefinition.GetENabizPackageDefinitions_Class> definitionList = new List<ENabizPackageDefinition.GetENabizPackageDefinitions_Class>();

                definitionList = ENabizPackageDefinition.GetENabizPackageDefinitions(objectContext, "").ToList();

              
                BindingList<SendToENabiz.GetPackageDetailsBySubepisode_Class> packages = SendToENabiz.GetPackageDetailsBySubepisode(new Guid(subepisodeObjectID));
                      
                foreach (SendToENabiz.GetPackageDetailsBySubepisode_Class package in packages)
                {
                    PackageDetail p = new PackageDetail();
                    p.SendToEnabizObjectID = new Guid(package.ObjectID.ToString());
                    p.InternalObjectID = new Guid(package.InternalObjectID.ToString());
                    p.InternalObjectDefName = package.InternalObjectDefName;
                    p.SubepisodeObjectID = subepisodeObjectID;

                    ENabizPackageDefinition.GetENabizPackageDefinitions_Class definition = definitionList.FirstOrDefault(t => t.PackageID.ToString() == package.PackageCode);
                    p.PackageCode = Convert.ToInt32(package.PackageCode);
                    p.PackageName = definition == null ?"":definition.PackageName;
                   
                    if (package.Status == SendToENabizEnum.Successful)
                    {
                        p.StatusName = "Ba�ar�l�";
                        p.Status = 1;
                    }
                    else if (package.Status == SendToENabizEnum.UnableToSent)
                    {
                        p.StatusName = "G�nderilemedi";
                        p.Status = 3;
                    }
                    else if (package.Status == SendToENabizEnum.ToBeSent)
                    {
                        p.StatusName = "S�rada";
                        p.Status = 0;
                    }
                    else if (package.Status == SendToENabizEnum.NotToBeSent)
                    {
                        p.StatusName = "G�nderilmeyecek";
                        p.Status = 4;
                    }
                    else if (package.Status == SendToENabizEnum.UnSuccessful)
                    {
                        p.StatusName = "Ba�ar�s�z";
                        p.Status = 2;
                    }
                    p.RecordDate = Convert.ToDateTime(package.RecordDate).ToString("dd.MM.yy HH:mm");
                    //E�er hata alm��sa son al�nan hata g�steriliyor
                    if( p.Status==3 || p.Status == 2)
                    {
                        BindingList<ResponseOfENabiz.GetLastResponseOfNabiz_Class> response = ResponseOfENabiz.GetLastResponseOfNabiz(p.SendToEnabizObjectID);
                        if (response.Count > 0)
                        {
                            p.ResponseObjectID = response[0].ObjectID == null ? "" : response[0].ObjectID.ToString();
                            p.ResponseCode = response[0].ResponseCode == null ? "" : response[0].ResponseCode.ToString();
                            p.ResponseMessage = response[0].ResponseMessage == null ? "" : response[0].ResponseMessage.ToString();
                            p.SendDate = response[0].SendDate == null ? "" : Convert.ToDateTime(response[0].SendDate).ToString("dd.MM.yy HH:mm");
                        }
                    }

                    if (p.PackageCode == 102)//102 pakedi ise i�lemin/malzemenin ad�n�n yaz�lmas� i�in
                    {

                        //SubActionProcedure sp = objectContext.GetObject<SubActionProcedure>(p.InternalObjectID);

                        SubActionProcedure sp = objectContext.GetObject(p.InternalObjectID, p.InternalObjectDefName) as SubActionProcedure;
                        if (sp != null)
                        {
                            p.ProcedureDetail = sp.ProcedureObject.Code + "-" + sp.ProcedureObject.Name;
                        }
                        else
                        {
                           // ENabizMaterial eNabizMaterial = objectContext.GetObject(p.InternalObjectID, typeof(ENabizMaterial)) as ENabizMaterial;
                            ENabizMaterial eNabizMaterial = objectContext.GetObject(p.InternalObjectID, p.InternalObjectDefName) as ENabizMaterial;
                            if (eNabizMaterial != null)
                            {
                                p.ProcedureDetail = (eNabizMaterial.SubActionMaterial.Material.Name != null ? eNabizMaterial.SubActionMaterial.Material.Name : string.Empty);
                            }
                        }

                    }
                    resultList.Add(p);
                }

            }

            return resultList;

        }
        [HttpPost]
        public List<SGKHizmetSorgulamaResultDTOModel> SGKHizmetSorgulama(SGKHizmetSorgulamaKriter queryCriteria)
        {
            List<SGKHizmetSorgulamaResultDTOModel> result = new List<SGKHizmetSorgulamaResultDTOModel>();
            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);


                //foreach (var item in shsm.TransactionList)
                //{
                    //AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(item.ObjectID, typeof(AccountTransaction));
                    //string sysTakipNo = acctrx.SubEpisodeProtocol.SubEpisode.SYSTakipNo;
                    //string islemReferansNumarasi = acctrx.SubActionProcedure != null ? acctrx.SubActionProcedure.ObjectID.ToString() : acctrx.SubActionMaterial.ObjectID.ToString();
                    HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/genel/SGKHizmetSorgulama?sysTakipNo=" + queryCriteria.SYSTakipNo).Result; //+ "&islemReferansNumarasi=" + islemReferansNumarasi

                if (message.IsSuccessStatusCode)
                    {
                        string rresult = message.Content.ReadAsStringAsync().Result;
                        SGKHizmetSorgulamaResponse response = JsonConvert.DeserializeObject<SGKHizmetSorgulamaResponse>(rresult);
                        if (response.sonuc.Count > 0)
                        {
                            SGKHizmetSorgulamaResultDTOModel tempItem = new SGKHizmetSorgulamaResultDTOModel();

                            foreach (PropertyInfo responseItem in response.sonuc[0].GetType().GetProperties())
                            {
                                foreach (PropertyInfo resultItem in tempItem.GetType().GetProperties())
                                {
                                    if (responseItem.Name == resultItem.Name)
                                    {
                                        resultItem.SetValue(tempItem, responseItem.GetValue(response.sonuc[0]));
                                        break;
                                    }
                                }
                            }
                            tempItem.durum = response.durum;
                            tempItem.mesaj = response.mesaj;
                            result.Add(tempItem);
                        }
                    }
                //}
            }
            return result;
        }

        [HttpPost]
        public List<SGKHizmetSorgulamaResultDTOModel> SGKHizmetSorgulamaBySGKTakipNo(SGKHizmetSorgulamaBySGKTakipNoKriter queryCriteria)
        {
            List<SGKHizmetSorgulamaResultDTOModel> result = new List<SGKHizmetSorgulamaResultDTOModel>();
            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);


                //foreach (var item in shsm.TransactionList)
                //{
                //AccountTransaction acctrx = (AccountTransaction)objectContext.GetObject(item.ObjectID, typeof(AccountTransaction));
                //string sysTakipNo = acctrx.SubEpisodeProtocol.SubEpisode.SYSTakipNo;
                //string islemReferansNumarasi = acctrx.SubActionProcedure != null ? acctrx.SubActionProcedure.ObjectID.ToString() : acctrx.SubActionMaterial.ObjectID.ToString();
                HttpResponseMessage message = client.GetAsync("http://xxxxxx.com/api/genel/SGKHizmetSorgulamaBySGKTakipNo?SGKTakipNo=" + queryCriteria.SGKTakipNo).Result; //+ "&islemReferansNumarasi=" + islemReferansNumarasi

                if (message.IsSuccessStatusCode)
                {
                    string rresult = message.Content.ReadAsStringAsync().Result;
                    SGKHizmetSorgulamaResponse response = JsonConvert.DeserializeObject<SGKHizmetSorgulamaResponse>(rresult);
                    if (response.sonuc.Count > 0)
                    {
                        SGKHizmetSorgulamaResultDTOModel tempItem = new SGKHizmetSorgulamaResultDTOModel();

                        foreach (PropertyInfo responseItem in response.sonuc[0].GetType().GetProperties())
                        {
                            foreach (PropertyInfo resultItem in tempItem.GetType().GetProperties())
                            {
                                if (responseItem.Name == resultItem.Name)
                                {
                                    resultItem.SetValue(tempItem, responseItem.GetValue(response.sonuc[0]));
                                    break;
                                }
                            }
                        }
                        tempItem.durum = response.durum;
                        tempItem.mesaj = response.mesaj;
                        result.Add(tempItem);
                    }
                }
                //}
            }
            return result;
        }

        [HttpPost]
        public List<NabizResponse> SendNabizPackage(PackageDetail data)
        {
            List<NabizResponse> result = new List<NabizResponse>();
           
            using (var objectContext = new TTObjectContext(true))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();
                try
                {
                    var packageID = data.PackageCode;
                    if (packageID == 101)
                    {
                        result = sendToENabiz.ENABIZSend101(data.InternalObjectID.ToString()); //Hasta Kay�t
                    }
                    else if (packageID == 102)
                    {
                        result = sendToENabiz.ENABIZSend102(data.InternalObjectID.ToString()); //Hizmet/�la�/Malzeme Bilgisi Kay�t
                    }
                    else if (packageID == 105)
                        result = sendToENabiz.ENABIZSend105(data.InternalObjectID.ToString()); //Lab Sonu�
                    else if (packageID == 409)
                        result = sendToENabiz.ENABIZSend409(data.InternalObjectID.ToString()); //Radyoloji Sonu�
                    else if (packageID == 502)
                        result = sendToENabiz.ENABIZSend502(data.InternalObjectID.ToString()); //Yo�un bak�m izlem
                    else if (packageID == 106)
                        result = sendToENabiz.ENABIZSend106(data.InternalObjectID.ToString()); //Hasta ��k��
                    else if (packageID == 201)
                        result = sendToENabiz.ENABIZSend201(data.InternalObjectID.ToString()); //Patoloji
                    else if (packageID == 103)
                        result = sendToENabiz.ENABIZSend103(data.InternalObjectID.ToString()); //Muayene
                    else if (packageID == 108)
                        result = sendToENabiz.ENABIZSend108(data.InternalObjectID.ToString()); //Telet�p
                    else if (packageID == 214)
                        result = sendToENabiz.ENABIZSend214(data.InternalObjectID.ToString()); //Bula��c� hastal�klar
                    else if (packageID == 207)
                        result = sendToENabiz.ENABIZSend207(data.InternalObjectID.ToString()); //A�� veri seti
                    else if (packageID == 104)
                        result = sendToENabiz.ENABIZSend104(data.InternalObjectID.ToString()); //Fatura 
                    else if (packageID == 215)
                        result = sendToENabiz.ENABIZSend215(data.InternalObjectID.ToString()); //Diyabet
                    else if (packageID == 240)
                        result = sendToENabiz.ENABIZSend240(data.InternalObjectID.ToString()); //Obezite
                    else if (packageID == 231)
                        result = sendToENabiz.ENABIZSend231(data.InternalObjectID.ToString()); //Kad�na y�nelik �iddet
                    else if (packageID == 235)
                        result = sendToENabiz.ENABIZSend235(data.InternalObjectID.ToString()); //Kronik hastal�klar
                    else if (packageID == 248)
                        result = sendToENabiz.ENABIZSend248(data.InternalObjectID.ToString()); //T�t�n kullan�m�
                    else if (packageID == 219)
                        result = sendToENabiz.ENABIZSend219(data.InternalObjectID.ToString()); //Evde Sa�l�k �lk �zlem
                    else if (packageID == 237)
                        result = sendToENabiz.ENABIZSend237(data.InternalObjectID.ToString()); //Kuduz Riskli Temas Bildirim
                    else if (packageID == 239)
                        result = sendToENabiz.ENABIZSend239(data.InternalObjectID.ToString()); //Madde ba��ml�l���
                    else if (packageID == 250)
                        result = sendToENabiz.ENABIZSend250(data.InternalObjectID.ToString()); //Verem
                    else if (packageID == 230)
                        result = sendToENabiz.ENABIZSend230(data.InternalObjectID.ToString()); //�ntihar Tespit
                    else if (packageID == 236)
                        result = sendToENabiz.ENABIZSend236(data.InternalObjectID.ToString()); //Kuduz Proflaksi
                    else if (packageID == 229)
                        result = sendToENabiz.ENABIZSend229(data.InternalObjectID.ToString()); //�ntihar �zlem
                    else if (packageID == 252)
                        result = sendToENabiz.ENABIZSend252(data.InternalObjectID.ToString()); //Kons�ltasyon
                    else if (packageID == 261)
                        result = sendToENabiz.ENABIZSend261(data.InternalObjectID.ToString()); //Olay Afet
                    else if (packageID == 203)
                        result = sendToENabiz.ENABIZSend203(data.InternalObjectID.ToString()); //A��z ve Di� Sa�l���
                    else if (packageID == 244)
                        result = sendToENabiz.ENABIZSend244(data.InternalObjectID.ToString()); //�zellikli Hasta �zlem
                    else if (packageID == 262)
                        result = sendToENabiz.ENABIZSend262(data.InternalObjectID.ToString()); //Hasta Nakil Veri Seti
                }
                catch (Exception ex)
                {
                    
                }
            }
            return result;
        }
        [HttpPost]
        public List<NabizResponse> SendPackagesWithErrors(PackageDetail[] dataList)
        {
            List<NabizResponse> result = new List<NabizResponse>();

            using (var objectContext = new TTObjectContext(true))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();

              
                foreach (PackageDetail data in dataList)
                {
                    try
                    {
                        List<NabizResponse> r = new List<NabizResponse>();
                        r = SendNabizPackage(data);
                        if (r.Count > 0)
                              result.Add(r[0]);
                        
                    }
                    catch (Exception ex)
                    {

                    }
                }
               
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Nabiz_Goruntuleme)]
        public void SendSelectedPackages(List<NabizResult> packageList)
        {
            SendToENabiz sendToENabiz = new SendToENabiz();

            foreach (NabizResult package in packageList)
            {
                try
                {
                    PackageDetail data = new PackageDetail();
                    data.InternalObjectID = package.SendToENabizInternalObjectID;
                    data.SendToEnabizObjectID = package.SendToENabizObjectID;
                    data.PackageCode = package.PackageCode;
                    SendNabizPackage(data);
                }
                catch (Exception ex)
                {

                }

            }

        }


        [HttpPost]
        public List<NabizResponse> Send101FromSubepisode(SubepisodeBasedNabizResult data)
        {
            List<NabizResponse> result = new List<NabizResponse>();

            using (var objectContext = new TTObjectContext(true))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();
                try
                {
                    
                        result = sendToENabiz.ENABIZSend101(data.ObjectID.ToString());
                    
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

        [HttpPost]
        public string Send402(SubepisodeBasedNabizResult data)
        {
            string result = String.Empty;
           

            using (var objectContext = new TTObjectContext(true))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();
                try
                {

                    result = sendToENabiz.ENABIZSend402(data.SYSTakipNo.ToString());

                }
                catch (Exception ex)
                {

                }
            }
           
            return result;
        }

        [HttpPost]
        public string DeleteSysAndSend101(SubepisodeBasedNabizResult data)
        {
            List<NabizResponse> result = new List<NabizResponse>();
            string res = ""; 
        
            using (var objectContext = new TTObjectContext(false))
            {
                SendToENabiz sendToENabiz = new SendToENabiz();
                try
                {
                    SubEpisode subepisode = objectContext.GetObject(data.ObjectID, typeof(SubEpisode)) as SubEpisode;

                    bool isSuccesfull = sendToENabiz.ENABIZSend301_V2(subepisode.ObjectID.ToString());

                    if (isSuccesfull)
                    {

                        subepisode.SYSTakipNo = null;
                        objectContext.Save();

                        result = sendToENabiz.ENABIZSend101(data.ObjectID.ToString());
                        res = result.ToArray()[0].SonucKodu + "-" + result.ToArray()[0].SonucMesaji;
                    }
                    else
                        res = "��lem Ba�ar�s�z. Daha sonra tekrar deneyiniz.";

                }
                catch (Exception ex)
                {

                }
                objectContext.Dispose();
            }
          
            return res;
        }

        [HttpPost]
        public IslemBanaAitDegilResponse IslemBanaAitDegilListele(IslemBanaAitDegilInput input)
        {
            IslemBanaAitDegilResponse response = new IslemBanaAitDegilResponse();
          
            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

                string url = "http://xxxxxx.com/api/kurum/IslemBanaAitDegilListele?baslangicAraligi=" + input.SelectedDate.ToString("yyyyMMdd") + "&bitisAraligi=" + input.SelectedDate.AddDays(1).ToString("yyyyMMdd");

                HttpResponseMessage message = client.GetAsync(url).Result; 

                if (message.IsSuccessStatusCode)
                {
                    string rresult = message.Content.ReadAsStringAsync().Result;
                     response = JsonConvert.DeserializeObject<IslemBanaAitDegilResponse>(rresult);
                    if (response.sonuc.Count > 0)
                    {
                       
                    }
                }
                
            }
            return response;
        }


        public string GetDateAsString(DateTime? dateTime)
        {
            if (dateTime != null)
                return GetDateAsString(Convert.ToDateTime(dateTime));
            return "";
        }
        public string GetDateAsString(DateTime dateTime)
        {
            return "TODATE('" + Convert.ToDateTime(dateTime).ToString("yyyy-MM-dd HH:mm:ss") + "')";
        }

        [HttpGet]
        public void GetPrescriptionInfo(string SYSTakipNo)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);

                string url = "http://xxxxxx.com/api/RenkliRecete/GetReceteBilgileri?sysTakipNo=" + SYSTakipNo + "&hizmetSunucu=" + applicationcode;


                HttpResponseMessage message = client.GetAsync(url).Result; //+ "&islemReferansNumarasi=" + islemReferansNumarasi

                if (message.IsSuccessStatusCode)
                {
                    string rresult = message.Content.ReadAsStringAsync().Result;
                    GetReceteBilgileriResponse response = JsonConvert.DeserializeObject<GetReceteBilgileriResponse>(rresult);
                    if (response.sonuc.Count > 0)
                    {
                        //SGKHizmetSorgulamaResultDTOModel tempItem = new SGKHizmetSorgulamaResultDTOModel();

                        //foreach (PropertyInfo responseItem in response.sonuc[0].GetType().GetProperties())
                        //{
                        //    foreach (PropertyInfo resultItem in tempItem.GetType().GetProperties())
                        //    {
                        //        if (responseItem.Name == resultItem.Name)
                        //        {
                        //            resultItem.SetValue(tempItem, responseItem.GetValue(response.sonuc[0]));
                        //            break;
                        //        }
                        //    }
                        //}
                        //tempItem.durum = response.durum;
                        //tempItem.mesaj = response.mesaj;
                        //result.Add(tempItem);
                    }
                }
                //}
            }
        }

        [HttpPost]
        public void GetReceteBilgileriTarih(GetReceteBilgileriTarihInput input)
        {
            IslemBanaAitDegilResponse response = new IslemBanaAitDegilResponse();

            using (var objectContext = new TTObjectContext(false))
            {

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string username = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", "");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
                string applicationcode = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX");

                client.DefaultRequestHeaders.Add("KullaniciAdi", username);
                client.DefaultRequestHeaders.Add("Sifre", password);
                client.DefaultRequestHeaders.Add("UygulamaKodu", applicationcode);


                string url = "http://xxxxxx.com/api/RenkliRecete/GetReceteBilgileriTarih?tarih="+input.StartDate.ToString("yyyyMMdd")+"&hizmetSunucu="+username+"&sayfa="+input.PageNumber;
                HttpResponseMessage message = client.GetAsync(url).Result;

                if (message.IsSuccessStatusCode)
                {
                    string rresult = message.Content.ReadAsStringAsync().Result;
                    //response = JsonConvert.DeserializeObject<IslemBanaAitDegilResponse>(rresult);
                    //if (response.sonuc.Count > 0)
                    //{

                    //}
                }

            }
            //return response;
        }


    }

}





namespace Core.Models
{
     public class GetReceteBilgileriResponse
    {
        public int durum { get; set; }

        public List<GetReceteBilgileriResultModel> sonuc { get; set; }

        public string mesaj { get; set; }
    }

    public class GetReceteBilgileriResultModel
    {
     // public List<RECETEBILGISI> RECETEBILGISI { get; set; }
    }

    //public class RECETEBILGISI
    //{
    //    public RECETETARIHI RECETE_TARIHI { get; set; }
    //    public RECETENUMARASI RECETE_NUMARASI { get; set; }
    //    public RECETETURU RECETE_TURU { get; set; }
    //    public HEKIMKIMLIKNUMARASI HEKIM_KIMLIK_NUMARASI { get; set; }
    //    public List<ILACBILGISI> ILAC_BILGISI { get; set; }

    //}




    public partial class ENabizPackagesFormViewModel
    {
        public NabizSearchCritaria _NabizSearchCritaria { get; set; }
        public List<NabizResult> _NabizResult { get; set; }
        public List<PackageInfo> NabizPackageList { get; set; }

        public DailyBasedNabizSearchCritaria _DailyBasedNabizSearchCritaria { get; set; }
        public List<DailyBasedNabizResult> _DailyBasedNabizResult { get; set; }

        public SubepisodeBasedNabizSearchCritaria _SubepisodeBasedNabizSearchCritaria { get; set; }
        public List<SubepisodeBasedNabizResult> _SubepisodeBasedNabizResult { get; set; }


        public ENabizPackagesFormViewModel()
        {
            _NabizSearchCritaria = new NabizSearchCritaria();
            _NabizResult = new List<NabizResult>();
            NabizPackageList = new List<PackageInfo>();
            _DailyBasedNabizSearchCritaria = new DailyBasedNabizSearchCritaria();
            _DailyBasedNabizResult = new List<DailyBasedNabizResult>();
            _SubepisodeBasedNabizSearchCritaria = new SubepisodeBasedNabizSearchCritaria();
            _SubepisodeBasedNabizResult = new List<SubepisodeBasedNabizResult>();
        }
    }

    public class PackageInfo
    {
        public int Code
        {
            get;
            set;
        }
        public string PackageName
        {
            get;
            set;
        }

    }

    public class DailyBasedNabizSearchCritaria
    {
        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }
    }

    public class SGKHizmetSorgulamaKriter
    {
        public string SYSTakipNo;
        //public List<Guid> InternalObjectIDList { get; set; }
        //rowlar gelecek.
        public SGKHizmetSorgulamaKriter()
        {
            //this.InternalObjectIDList = new List<Guid>();
            this.SYSTakipNo = "";
        }
    }

    public class SGKHizmetSorgulamaBySGKTakipNoKriter
    {
        public string SGKTakipNo;
        //public List<Guid> InternalObjectIDList { get; set; }
        //rowlar gelecek.
        public SGKHizmetSorgulamaBySGKTakipNoKriter()
        {
            //this.InternalObjectIDList = new List<Guid>();
            this.SGKTakipNo = "";
        }
    }



    public class SubepisodeBasedNabizSearchCritaria
    {
        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }
        public string PatientObjectID
        {
            get; set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }
        public string SYSTakipNo
        {
            get;
            set;
        }

        public bool HasSYSNo { get; set; }
    }

    public class DailyBasedNabizResult
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ResponseCode
        {
            get;
            set;
        }
        public string ResponseMessage
        {
            get;
            set;
        }

        public string SendDate
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
    }

    public class SubepisodeBasedNabizResult
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string Ressection
        {
            get;
            set;
        }
        public string OpeningDate
        {
            get;
            set;
        }

        public string ProtocolNo
        {
            get;
            set;
        }

        public string PatientNameSurname
        {
            get;
            set;
        }
        public string SYSTakipNo
        {
            get;
            set;
        }
    }

    public class NabizSearchCritaria
    {
        public List<PackageInfo> NabizPackages
        {
            get;
            set;
        }
        public DateTime? packageAddingDateStart
        {
            get;
            set;
        }

        public DateTime? packageAddingDateEnd
        {
            get;
            set;
        }

        public int? packageStatus
        {
            get;
            set;
        }

        public DateTime? SubepisodeOpeningDateStart
        {
            get;
            set;
        }

        public DateTime? SubepisodeOpeningDateEnd
        {
            get;
            set;
        }

        public string ProtocolNo
        {
            get;
            set;
        }

        public int SearchType
        {
            get;
            set;
        }

        public Guid PatientObjectID
        {
            get; set;
        }

        public string ResponseCode
        {
            get;
            set;
        }


        //public DateTime? packageSendDateStart
        //{
        //    get;
        //    set;
        //}

        //public DateTime? packageSendDateEnd
        //{
        //    get;
        //    set;
        //}


    }

    public class NabizResult
    {
        public int PackageCode
        {
            get;
            set;
        }
        public string PackageName
        {
            get;
            set;
        }
        public Guid SendToENabizObjectID
        {
            get;
            set;
        }
        public Guid SendToENabizInternalObjectID
        {
            get;
            set;
        }

        public string ResponseFromENabiz
        {
            get;
            set;
        }

        public string SendToENabizInternalObjectDef
        {
            get;
            set;
        }

        public string PackageStatus
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public string PatientAdmissionNo
        {
            get;
            set;
        }

        public string PackageSendDate
        {
            get;
            set;
        }

        public string SYSTakipNo
        {
            get;
            set;
        }

        public string ResultCode
        {
            get;
            set;
        }

    }

    public class PackageDetail
    {
        public Guid SendToEnabizObjectID { get; set; }
        public Guid InternalObjectID { get; set; }
        public string SubepisodeObjectID { get; set; }
        public string InternalObjectDefName { get; set; }
        public int PackageCode { get; set; }
        public string PackageName { get; set; }
        public string StatusName { get; set; }
        public int Status { get; set; }
        public string RecordDate { get; set; }
        public string ResponseObjectID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string SendDate { get; set; }
        public string ProcedureDetail { get; set; }
    }

    public class IslemBanaAitDegilInput
    {
        public DateTime SelectedDate { get; set; }
    }
    public class IslemBanaAitDegilResponse
    {
        public int durum { get; set; }

        public List<IslemBanaAitDegilResultModel> sonuc = new List<IslemBanaAitDegilResultModel>(); 

        public string mesaj { get; set; }
    }
    public class IslemBanaAitDegilResultModel
    {
        public string sysTakipNo { get; set; }
        public string islemAdi { get; set; }
        public string islemKodu { get; set; }
        public string XXXXXX { get; set; }
    }

    public class GetReceteBilgileriTarihInput
    {
        public DateTime StartDate { get; set; }
        public int PageNumber { get; set; }
    }
}

