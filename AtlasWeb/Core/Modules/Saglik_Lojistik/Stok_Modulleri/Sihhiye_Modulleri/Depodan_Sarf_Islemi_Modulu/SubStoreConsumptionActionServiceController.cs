//$A98B9C94
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class SubStoreConsumptionActionServiceController : Controller
    {
        public class UTSOutputDTO
        {
            public List<StockActionDetail> stockActionDetails { get; set; }
            public string returnMessage { get; set; }
        }
        public class GetMaterialDetail_Input
        {
            public Guid StockActionDetailObjectID { get; set; }
        }
        public class UTSInputDTO
        {
            public Guid stockactionID { get; set; }
        }

        [HttpPost]
        public UTSOutputDTO MakeUTSNotificationForSubStoreConsumption(UTSInputDTO input)
        {
            UTSOutputDTO uTSOutputDTO = new UTSOutputDTO();
            uTSOutputDTO.stockActionDetails = new List<StockActionDetail>();

            using (TTObjectContext context = new TTObjectContext(false))
            {
                uTSOutputDTO.returnMessage = string.Empty;
                if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") == "TRUE")
                {
                    StockAction stockAction = context.GetObject<StockAction>(input.stockactionID);

                    foreach (StockActionDetail stockActionDetail in stockAction.StockActionDetails)
                    {
                        if (stockActionDetail.UTSNotification != null && stockActionDetail.UTSNotification.CurrentStateDefID != UTSNotification.States.Cancelled)
                            continue;
                        if (stockActionDetail.Material.IsIndividualTrackingRequired == false)
                            continue;

                        StockTransaction stockTransaction = stockActionDetail.StockTransactions.Select(string.Empty).FirstOrDefault();
                        try
                        {
                            UTSServis.BildirimCevap utsBildirimCevap = null;
                            UTSNotification utsNotification = null;

                            UTSServis.KullanimBildirimiIstek kullanimBildirimiIstek = new UTSServis.KullanimBildirimiIstek()
                            {
                                TKN = null,
                                UNO = stockActionDetail.Material.Barcode,
                                LNO = stockTransaction.LotNo,
                                SNO = stockTransaction.SerialNo,
                                ADT = stockTransaction.Amount,
                                HAA = string.Empty,
                                HAS = string.Empty,
                                YKN = null,
                                PAN = string.Empty,
                                GIT = DateTime.Now.ToString("yyyy-MM-dd")
                            };

                            kullanimBildirimiIstek.TUR = UTSServis.KullanimBildirimiTur.DIGER;
                            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                            try
                            {
                                utsBildirimCevap = UTSServis.WebMethods.KullanimBildirimiSync(new Guid(siteID), kullanimBildirimiIstek);
                            }
                            catch (Exception e)
                            {
                                uTSOutputDTO.returnMessage += "-" + e.Message;
                            }
                            // Kullaným bildirimi baþarý ile tamamlanýrsa NotifID UTSNotifDetail objesinde set edilir ve state baþarýlý olarak belirlenir. 
                            // Baþarýlý tamamlanamazsa state baþarýsýz olarak belirlenir. 
                            if (utsBildirimCevap != null)
                            {
                                if (utsBildirimCevap.SNC == String.Empty || utsBildirimCevap.SNC == null)
                                {
                                    uTSOutputDTO.returnMessage += "-" + utsBildirimCevap.MSJ[0].MET;
                                }
                                else
                                {
                                    utsNotification = new UTSNotification(context)
                                    {
                                        DocumentNo = stockAction.StockActionID.ToString(),
                                        Material = stockActionDetail.Material,
                                        IncomingDeliveryNotifID = utsBildirimCevap.SNC,
                                        CurrentStateDefID = UTSNotification.States.Active,
                                    };
                                    stockActionDetail.UTSNotification = utsNotification;
                                    context.Save();
                                }

                                uTSOutputDTO.stockActionDetails.Add(stockActionDetail);
                            }
                        }
                        catch (Exception e)
                        {
                            uTSOutputDTO.returnMessage += "-" + e.Message;
                        }
                    }
                }

                return uTSOutputDTO;
            }
        }


        [HttpPost]
        public string DeleteUTSNotificationForSubStoreConsumption(GetMaterialDetail_Input input)
        {
            string sonuc = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                StockActionDetail stockActionDetail = (StockActionDetail)objectContext.GetObject(input.StockActionDetailObjectID, typeof(StockActionDetail).Name, false);
                string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

                UTSServis.KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek = new UTSServis.KullanimIptalBildirimiIstek();
                kullanimIptalBildirimiIstek.BID = stockActionDetail.UTSNotification.IncomingDeliveryNotifID;

                UTSServis.BildirimCevap KullanimIptalcevap = UTSServis.WebMethods.KullanimIptalBildirimiSync(new Guid(siteID), kullanimIptalBildirimiIstek);
                if (KullanimIptalcevap.MSJ[0].TIP != "HATA")
                {
                    sonuc = "ÜTS iptal Yapýldý.";
                    stockActionDetail.UTSNotification.CurrentStateDefID = UTSNotification.States.Cancelled;
                    stockActionDetail.UTSNotification = null;
                }
                else
                {
                    sonuc = KullanimIptalcevap.MSJ[0].KOD + KullanimIptalcevap.MSJ[0].MET + KullanimIptalcevap.MSJ[0].MPA + KullanimIptalcevap.MSJ[0].TIP;
                }
                objectContext.Save();
                if (String.IsNullOrEmpty(sonuc) == true)
                {
                    sonuc = "Ýþlem Yapýlamadý.";
                }
                return sonuc;
            }
        }
    }
}