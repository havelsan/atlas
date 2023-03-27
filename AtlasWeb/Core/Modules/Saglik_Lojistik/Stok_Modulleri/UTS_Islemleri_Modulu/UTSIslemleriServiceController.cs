//$91FFD0C5
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using TTUtils;
using TTDefinitionManagement;
using static TTObjectClasses.UTSServis;
using System.Xml;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class UTSIslemleriServiceController : Controller
    {
        public class UTSBatchGridDataType
        {
            public string IncomingDeliveryNotifID
            {
                get; set;
            }
            public string OutgoingDeliveryNotifID
            {
                get; set;
            }
            public string ReceiveNotifID
            {
                get; set;
            }
            public string UsageNotifID
            {
                get; set;
            }
            public string ProductName
            {
                get; set;
            }
            public string ProductNo
            {
                get; set;
            }
            public string SendingOrganizationNo
            {
                get; set;
            }
            public string UniqueDeviceIdentifier
            {
                get; set;
            }
            public string LotNumber
            {
                get; set;
            }
            public string SerialNumber
            {
                get; set;
            }
            public string PatientUniqueID
            {
                get; set;
            }
            public string PatientName
            {
                get; set;
            }
            public string NotificationStatus
            {
                get; set;
            }
            public int Amount
            {
                get; set;
            }
        }

        public class GetGridDataInput
        {
            public int SayfaNo
            {
                get; set;
            }
            public DateTime StartDate
            {
                get; set;
            }
            public DateTime EndDate
            {
                get; set;
            }
        }

        [HttpPost]
        public List<UTSBatchGridDataType> GetAlmaGridData(GetGridDataInput input)
        {
            List<UTSBatchGridDataType> dataList = new List<UTSBatchGridDataType>();
            UTSServis.KabulEdilecekTekilUrunSorgulaIstek kabulEdilecekTekilUrunSorgulaIstek = new UTSServis.KabulEdilecekTekilUrunSorgulaIstek
            {
                SAN = input.SayfaNo
            };
            UTSServis.KabulEdilecekTekilUrunSorgulaCevap vermeBildirimleri = new UTSServis.KabulEdilecekTekilUrunSorgulaCevap();
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            do
            {
                vermeBildirimleri = UTSServis.WebMethods.KabulEdilecekTekilUrunSorgulaSync(new Guid(siteID), kabulEdilecekTekilUrunSorgulaIstek);
                if (vermeBildirimleri?.SNC != null)
                {
                    foreach (var sonuc in vermeBildirimleri.SNC)
                    {
                        UTSBatchGridDataType data = new UTSBatchGridDataType
                        {
                            IncomingDeliveryNotifID = sonuc.BID,
                            ProductNo = sonuc.UNO,
                            SendingOrganizationNo = sonuc.GKK.ToString(),
                            SerialNumber = sonuc.SNO,
                            LotNumber = sonuc.LNO
                        };
                        dataList.Add(data);
                    }
                }
                kabulEdilecekTekilUrunSorgulaIstek.SAN += 1;
            }
            while (vermeBildirimleri?.SNC.Count == 10);



            return dataList;
        }

        [HttpPost]
        public List<UTSBatchGridDataType> GetVermeAndKullanimGridData(GetGridDataInput input)
        {
            List<UTSBatchGridDataType> dataList = new List<UTSBatchGridDataType>();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                List<UTSNotification> receiveNotifications = new List<UTSNotification>();

                foreach (var notif in receiveNotifications)
                {
                    UTSBatchGridDataType data = new UTSBatchGridDataType()
                    {
                        IncomingDeliveryNotifID = notif.IncomingDeliveryNotifID,
                        ProductNo = notif.Material.Barcode,
                        ProductName = notif.Material.Name,
                        SendingOrganizationNo = notif.SendingOrganizationNo.ToString(),
                        SerialNumber = notif.SerialNo,
                        LotNumber = notif.LotNo
                    };
                    //data.PatientUniqueID = notif.BaseTreatmentMaterial?.Episode?.Patient?.UniqueRefNo?.ToString(); //TODO
                    //data.PatientName = notif.BaseTreatmentMaterial?.Episode?.Patient?.Name;
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        [HttpPost]
        public List<UTSBatchGridDataType> GetKullanimIptalGridData(GetGridDataInput input)
        {
            List<UTSBatchGridDataType> dataList = new List<UTSBatchGridDataType>();
            using (TTObjectContext context = new TTObjectContext(true))
            {
                List<UTSNotification> useNotifications = new List<UTSNotification>();

                foreach (var notif in useNotifications)
                {
                    UTSBatchGridDataType data = new UTSBatchGridDataType
                    {
                        //TODO 
                        //UsageNotifID = notif.UsageNotificationID,
                        ProductNo = notif.Material.Barcode,
                        ProductName = notif.Material.Name,
                        SendingOrganizationNo = notif.SendingOrganizationNo.ToString(),
                        SerialNumber = notif.SerialNo,
                        LotNumber = notif.LotNo
                    };
                    //data.PatientUniqueID = notif.BaseTreatmentMaterial.Episode.Patient.UniqueRefNo.ToString(); //TODO
                    //data.PatientName = notif.BaseTreatmentMaterial?.Episode?.Patient?.Name;
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        public class MakeNotificationInput
        {
            public string IncomingDeliveryNotifID
            {
                get; set;
            }
            public int Amount
            {
                get; set;
            }
            public UTSBatchGridDataType NotificationInfo
            {
                get; set;
            }
        }
        public class MakeUsageNotificationInput
        {
            public int Amount
            {
                get; set;
            }
            public UTSBatchGridDataType NotificationInfo
            {
                get; set;
            }
            public Guid PatientID
            {
                get; set;
            }
        }
        [HttpPost]
        public void MakeReceiveNotification(MakeNotificationInput input)
        {
            UTSServis.VidAlmaBildirimiIstek almaIstek = new UTSServis.VidAlmaBildirimiIstek
            {
                ADT = input.Amount,
                VBI = input.IncomingDeliveryNotifID
            };
            UTSServis.BildirimCevap cevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "")), almaIstek);
            using (TTObjectContext context = new TTObjectContext(false))
            {
                //TODO 
                if (cevap.SNC != String.Empty)
                {
                    string barcode = input.NotificationInfo.ProductNo;
                    Material material = Material.GetMaterialByBarcode(context, barcode)[0];

                    UTSNotification receiveNotification = UTSNotification.GetNotification(context, "WHERE ReceiveNotificationID =" + input.NotificationInfo.ReceiveNotifID)[0];
                    receiveNotification.IncomingDeliveryNotifID = input.IncomingDeliveryNotifID;

                    receiveNotification.Material = material;
                    receiveNotification.SerialNo = input.NotificationInfo.SerialNumber;
                    receiveNotification.LotNo = input.NotificationInfo.LotNumber;
                    receiveNotification.ProductBarcodeNo = barcode;
                    receiveNotification.SendingOrganizationNo = long.Parse(input.NotificationInfo.SendingOrganizationNo);

                    //receiveNotification.CurrentStateDefID = UTSNotification.States.Received;
                    //TODO 
                    //receiveNotification.ReceiveNotificationID = cevap.SNC;                     
                }

                context.Save();
            }
        }

        [HttpPost]
        public void MakeDeliveryNotification(MakeNotificationInput input)
        {
            UTSServis.VermeBildirimiIstek vermeIstek = new UTSServis.VermeBildirimiIstek
            {
                // ADT = input.amount;
                UNO = input.NotificationInfo.ProductNo,
                SNO = input.NotificationInfo.SerialNumber,
                KUN = 5, //SORULACAK!!!
                BNO = "" //SORULACAK!!!
            };

            UTSServis.BildirimCevap cevap = UTSServis.WebMethods.VermeBildirimiSync(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "")), vermeIstek);
            using (TTObjectContext context = new TTObjectContext(false))
            {
                //TODO 
                if (cevap.SNC != String.Empty)
                {
                    string barcode = input.NotificationInfo.ProductNo;
                    Material material = Material.GetMaterialByBarcode(context, barcode)[0];

                    UTSNotification deliveryNotification = UTSNotification.GetNotification(context, "WHERE ReceiveNotificationID =" + input.NotificationInfo.ReceiveNotifID)[0];
                    deliveryNotification.Material = material;
                    deliveryNotification.SerialNo = input.NotificationInfo.SerialNumber;
                    deliveryNotification.LotNo = input.NotificationInfo.LotNumber;
                    deliveryNotification.ProductBarcodeNo = barcode;
                    deliveryNotification.SendingOrganizationNo = long.Parse(input.NotificationInfo.SendingOrganizationNo);

                    //deliveryNotification.CurrentStateDefID = UTSNotification.States.New;
                    //TODO 
                    //deliveryNotification.OutgoingDeliveryNotifID = cevap.SNC;
                }

                context.Save();
            }
        }

        [HttpPost]
        public void MakeUsageNotification(MakeUsageNotificationInput input)
        {
            UTSServis.KullanimBildirimiIstek kullanimBildirimiIstek = new UTSServis.KullanimBildirimiIstek
            {
                //ADT = input.amount;
                UNO = input.NotificationInfo.ProductNo,
                SNO = input.NotificationInfo.SerialNumber,
                HAA = "" //TODO
            };

            UTSServis.BildirimCevap cevap = UTSServis.WebMethods.KullanimBildirimiSync(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "")), kullanimBildirimiIstek);
            using (TTObjectContext context = new TTObjectContext(false))
            {
                //TODO 
                if (cevap.SNC != String.Empty)
                {
                    string barcode = input.NotificationInfo.ProductNo;
                    Material material = Material.GetMaterialByBarcode(context, barcode)[0];

                    UTSNotification usageNotification = UTSNotification.GetNotification(context, "WHERE ReceiveNotificationID =" + input.NotificationInfo.ReceiveNotifID)[0];
                    usageNotification.Material = material;
                    usageNotification.SerialNo = input.NotificationInfo.SerialNumber;
                    usageNotification.LotNo = input.NotificationInfo.LotNumber;
                    usageNotification.ProductBarcodeNo = barcode;
                    usageNotification.SendingOrganizationNo = long.Parse(input.NotificationInfo.SendingOrganizationNo);

                    BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial
                    {
                        Material = material
                    };
                    //baseTreatmentMaterial.LotNo = input.NotificationInfo.LotNumber;
                    //baseTreatmentMaterial.SerialNo = input.NotificationInfo.SerialNumber;
                    //baseTreatmentMaterial.UsageNotificationID = cevap.SNC;
                    //TODO 
                    //usageNotification.UsageNotificationID = cevap.SNC;
                    //usageNotification.BaseTreatmentMaterial = baseTreatmentMaterial;
                }

                context.Save();
            }
        }


        public class UTSReceiveNotificationSendModel
        {
            public string ObjectId
            {
                get; set;
            }
            public int Amount
            {
                get; set;
            }
            public string IncomingDeliveryNotifID
            {
                get; set;
            }
        }

        public class UTSReceiveNotificationResultModel
        {
            public string ObjectId
            {
                get; set;
            }
            public string ReceiveNotificationID
            {
                get; set;
            }
            public string Message
            {
                get; set;
            }
        }



        //private string MakeUTSReceiveNotification(ChattelDocumentDetailWithPurchase item)
        //{
        //    string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
        //    UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
        //    {
        //        ADT = item.Amount,
        //        VBI = item.IncomingDeliveryNotifID
        //    };
        //    UTSServis.BildirimCevap almaBildirimiCevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(siteID), almaBildirimiIstek);
        //    if (!string.IsNullOrEmpty(almaBildirimiCevap.SNC))
        //    {
        //        return almaBildirimiCevap.SNC;
        //    }
        //    else
        //    {
        //        string hataKodu = almaBildirimiCevap.MSJ[0].KOD;
        //        return null;
        //    }
        //}



        public int UTSSendReceiveNot(ChattelDocumentWithPurchase item, ChattelDocumentDetailWithPurchase detail)
        {

            int amount = 1;
            List<UTSBatchGridDataType> dataList = new List<UTSBatchGridDataType>();
            UTSServis.KabulEdilecekTekilUrunSorgulaIstek kabulEdilecekTekilUrunSorgulaIstek = new UTSServis.KabulEdilecekTekilUrunSorgulaIstek()
            {
                GKK = item.Supplier.FirmIdentifierNo.Value,
                SAN = 0
            };

            UTSServis.KabulEdilecekTekilUrunSorgulaCevap vermeBildirimleri = new UTSServis.KabulEdilecekTekilUrunSorgulaCevap();
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            string errorMessage = string.Empty;
            do
            {
                vermeBildirimleri = UTSServis.WebMethods.KabulEdilecekTekilUrunSorgulaSync(new Guid(siteID), kabulEdilecekTekilUrunSorgulaIstek);
                if (vermeBildirimleri?.SNC != null)
                {
                    foreach (var sonuc in vermeBildirimleri.SNC)
                    {
                        if (sonuc.BNO == item.Waybill)
                        {
                            if (sonuc.BID == detail.IncomingDeliveryNotifID)
                                amount = sonuc.ADT;
                        }

                    }
                }
                kabulEdilecekTekilUrunSorgulaIstek.SAN++;
            }
            while (vermeBildirimleri?.SNC?.Count == 10);
            return amount;
        }



        [HttpPost]
        public List<UTSReceiveNotificationResultModel> MakeUTSReceiveNotificationForAll(List<UTSReceiveNotificationSendModel> list)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase;
                UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek;
                UTSServis.BildirimCevap almaBildirimiCevap = null;
                UTSReceiveNotificationResultModel res;
                List<UTSReceiveNotificationResultModel> results = new List<UTSReceiveNotificationResultModel>();
                foreach (var item in list)
                {
                    chattelDocumentDetailWithPurchase = (ChattelDocumentDetailWithPurchase)context.GetObject(new Guid(item.ObjectId), typeof(ChattelDocumentDetailWithPurchase));

                    int amount = this.UTSSendReceiveNot((ChattelDocumentWithPurchase)chattelDocumentDetailWithPurchase.StockAction, chattelDocumentDetailWithPurchase);

                    almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
                    {
                        ADT = amount,
                        VBI = item.IncomingDeliveryNotifID
                    };

                    try
                    {
                        almaBildirimiCevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(siteID), almaBildirimiIstek);
                    }
                    catch
                    {
                        // todo
                    }

                    res = new UTSReceiveNotificationResultModel
                    {
                        ObjectId = item.ObjectId
                    };

                    if (almaBildirimiCevap != null && !string.IsNullOrEmpty(almaBildirimiCevap.SNC))
                    {
                        res.ReceiveNotificationID = almaBildirimiCevap.SNC;
                        chattelDocumentDetailWithPurchase.ReceiveNotificationID = almaBildirimiCevap.SNC;
                        context.Save();
                    }
                    else if (almaBildirimiCevap != null)
                    {
                        res.Message = almaBildirimiCevap.MSJ[0].KOD;
                    }

                    results.Add(res);
                }
                return results;
            }
        }


        public class BaseTreatmentMaterialUTSUsageNotificationResultViewModel
        {
            public Guid ObjectId
            {
                get; set;
            }
            public string UTSUseNotificationState
            {
                get; set;
            }
            public string Message
            {
                get; set;
            }
        }


        [HttpPost]
        public List<BaseTreatmentMaterialUTSUsageNotificationResultViewModel> MakeUTSUsageNotificationAll(List<string> baseTreatmentMaterialIDs)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                List<BaseTreatmentMaterialUTSUsageNotificationResultViewModel> results = new List<BaseTreatmentMaterialUTSUsageNotificationResultViewModel>();
                if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") == "TRUE")
                {
                    string errorMessage = string.Empty;
                    StockActionDetail stockActionDetail;
                    var objectDef = TTObjectDefManager.Instance.ObjectDefs.Values.Where(d => d.Name.ToUpperInvariant() == "BASETREATMENTMATERIAL").FirstOrDefault();
                    foreach (var baseTreatmentMaterialID in baseTreatmentMaterialIDs)
                    {
                        BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)context.GetObject(new Guid(baseTreatmentMaterialID), objectDef, false);

                        var baseTreatmentMaterialNotifcationState = true;
                        BaseTreatmentMaterialUTSUsageNotificationResultViewModel result = new BaseTreatmentMaterialUTSUsageNotificationResultViewModel
                        {
                            ObjectId = baseTreatmentMaterial.ObjectID
                        };

                        if (baseTreatmentMaterial != null)
                        {
                            stockActionDetail = baseTreatmentMaterial.StockActionDetail;
                            foreach (var stockTransaction in stockActionDetail.StockTransactions.Select(string.Empty))
                            {
                                try
                                {
                                    Patient p = stockActionDetail.SubActionMaterial[0].Episode.Patient;
                                    int succeedededUTSUsageNotificationCount = stockTransaction.UTSNotificationDetails.Where(x => x.CurrentStateDefID != UTSNotificationDetail.States.Cancelled 
                                    && x.NotificationID != null).Count();

                                    UTSServis.BildirimCevap utsBildirimCevap = null;
                                    UTSNotificationDetail utsNotificationDetail = null;
                                    for (int i = 0; i < stockTransaction.Amount - succeedededUTSUsageNotificationCount; i++)
                                    {
                                        UTSServis.KullanimBildirimiIstek kullanimBildirimiIstek = new UTSServis.KullanimBildirimiIstek()
                                        {
                                            TKN = p.UniqueRefNo,
                                            UNO = stockActionDetail.Material.Barcode,
                                            LNO = stockTransaction.LotNo,
                                            SNO = stockTransaction.SerialNo,
                                            ADT = 1,
                                            HAA = p.Name,
                                            HAS = p.Surname,
                                            YKN = p.ForeignUniqueRefNo,
                                            PAN = p.PassportNo,
                                            GIT = DateTime.Now.ToString("yyyy-MM-dd")
                                        };

                                        if (p.UniqueRefNo != null)
                                            kullanimBildirimiIstek.TUR = UTSServis.KullanimBildirimiTur.TC_KIMLIK_NUMARASI_VAR;
                                        else if (p.ForeignUniqueRefNo != null)
                                            kullanimBildirimiIstek.TUR = UTSServis.KullanimBildirimiTur.YABANCI_KIMLIK_NUMARASI_VAR;

                                        string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                                        try
                                        {
                                            utsBildirimCevap = UTSServis.WebMethods.KullanimBildirimiSync(new Guid(siteID), kullanimBildirimiIstek);
                                        }
                                        catch (Exception e)
                                        {
                                            //todo
                                            errorMessage += e.Message;
                                            baseTreatmentMaterialNotifcationState = false;
                                        }


                                        // Kullanım bildirimi başarı ile tamamlanırsa NotifID UTSNotifDetail objesinde set edilir ve state başarılı olarak belirlenir. 
                                        // Başarılı tamamlanamazsa state başarısız olarak belirlenir. 
                                        if (utsBildirimCevap != null)
                                        {
                                            if (utsBildirimCevap.SNC == String.Empty || utsBildirimCevap.SNC == null)
                                            {
                                                TTException e = new TTException(utsBildirimCevap.MSJ[0].MET);
                                            }
                                            else
                                            {

                                                utsNotificationDetail = new UTSNotificationDetail(context)
                                                {
                                                    StockTransaction = stockTransaction,
                                                    NotificationDate = DateTime.Now,
                                                    NotificationType = UTSNotificationTypeEnum.UsageNotification
                                                };
                                                utsNotificationDetail.NotificationID = utsBildirimCevap.SNC;
                                                utsNotificationDetail.CurrentStateDefID = UTSNotificationDetail.States.Unsuccessful;
                                                context.Save();
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(stockActionDetail.Material.Name + " malzemesi için UTS kullanım bildirimi tamamlanamamıştır! " + ex.ToString());
                                }
                            }

                            foreach (var stockTransaction in stockActionDetail.StockTransactions)
                            {
                                if (stockTransaction.UTSNotificationDetails.Where(x => x.NotificationID != null).Count() != stockTransaction.Amount)
                                {
                                    baseTreatmentMaterialNotifcationState = false;
                                    break;
                                }
                            }
                        }
                        else
                            baseTreatmentMaterialNotifcationState = false;

                        if (baseTreatmentMaterialNotifcationState)
                        {
                            result.Message = "Succeed";
                            result.UTSUseNotificationState = "Bildirildi";
                        }
                        else
                        {
                            result.Message = errorMessage;
                            result.UTSUseNotificationState = "Bildirilmedi";
                        }
                        results.Add(result);
                    }
                }
                return results;
            }
        }


        public class UTS_SynchronizeMaterials_Input
        {
            public string StartDate
            {
                get; set;
            }
            public string EndnDate
            {
                get; set;
            }
            public Boolean UTSSinif1
            {
                get; set;
            }
            public Boolean UTSSinif2
            {
                get; set;
            }
            public Boolean UTSSinif3
            {
                get; set;
            }
        }


        [HttpPost]
        public string SynchronizeAllUTSMaterial(UTS_SynchronizeMaterials_Input searchCriteria)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                int updateUTSMaterialSinif1 = 0;
                int updateUTSMaterialSinif2 = 0;
                int updateUTSMaterialSinif3 = 0;
                int updateUTSMaterialCancel = 0;

                string sql = "";
                if (searchCriteria.UTSSinif1 == true)
                    sql += "'SINIF_I_DIGER','SINIF_I_M','SINIF_I_S',";
                if (searchCriteria.UTSSinif2 == true)
                    sql += "'SINIF_II_B','SINIF_II_A',";
                if (searchCriteria.UTSSinif3 == true)
                    sql += "'SINIF_III',";

                sql = sql.Replace(sql.Substring(sql.Length - 1), "");


                //IBindingList utsAllMaterials = objectContext.QueryObjects(typeof(UTSAllMaterial).Name, " SINIF IN("+ sql + ")AND LASTUPDATE >= '" + searchCriteria.StartDate + "' AND LASTUPDATE <= '" + searchCriteria.EndnDate + "'");

               BindingList<UTSAllMaterial.GetUTSMaterialByFilter_Class> utsAllMaterials = UTSAllMaterial.GetUTSMaterialByFilter(Convert.ToDateTime(searchCriteria.StartDate), Convert.ToDateTime(searchCriteria.EndnDate), " AND SINIF IN("+sql+")");

                foreach (UTSAllMaterial.GetUTSMaterialByFilter_Class utsAllMaterial in utsAllMaterials)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    if (utsAllMaterial.takipDurumu.ToString() == "Takip Ediliyor")
                    {
                        BindingList<Material> materials = Material.GetMaterialByBarcode(context, utsAllMaterial.birincilUrunNumarasi.ToString());
                        foreach (Material material in materials)
                        {
                            if (searchCriteria.UTSSinif1 == true && (utsAllMaterial.sinif.ToString() == "SINIF_I_S" || utsAllMaterial.sinif.ToString() == "SINIF_I_M" || utsAllMaterial.sinif.ToString() == "SINIF_I_DIGER"))
                            {
                                material.IsIndividualTrackingRequired = true;
                                updateUTSMaterialSinif1++;
                            }
                            if (searchCriteria.UTSSinif2 == true && (utsAllMaterial.sinif.ToString() == "SINIF_II_A" || utsAllMaterial.sinif.ToString() == "SINIF_II_B"))
                            {
                                material.IsIndividualTrackingRequired = true;
                                updateUTSMaterialSinif2++;
                            }
                            if (searchCriteria.UTSSinif3 == true && utsAllMaterial.sinif.ToString() == "SINIF_III")
                            {
                                material.IsIndividualTrackingRequired = true;
                                updateUTSMaterialSinif3++;
                            }
                        }
                    }
                    else
                    {
                        BindingList<Material> unMaterials = Material.GetMaterialByBarcode(context, utsAllMaterial.birincilUrunNumarasi.ToString());
                        foreach (Material material in unMaterials)
                        {
                            material.IsIndividualTrackingRequired = false;
                            updateUTSMaterialCancel++;
                        }
                    }
                    context.Save();
                    context.Dispose();
                }
                string returnMessage = "";
                if (searchCriteria.UTSSinif1 == true)
                    returnMessage += updateUTSMaterialSinif1 + " Tane 1.sınıf UTS malzemesi takibe alındı.";
                if (searchCriteria.UTSSinif2 == true)
                    returnMessage += updateUTSMaterialSinif2 + " Tane 2.sınıf UTS malzemesi takibe alındı.";
                if (searchCriteria.UTSSinif3 == true)
                    returnMessage += updateUTSMaterialSinif3 + " Tane 3.sınıf UTS malzemesi takibe alındı.";

                return returnMessage + "-- " + updateUTSMaterialCancel + " Tane UTS Takip malzemesi takipten çıkartıldı.";

            }
        }
    }
}

