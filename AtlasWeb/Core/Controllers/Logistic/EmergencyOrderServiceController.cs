using Core.Models;
using Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors.Controls;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTConnectionManager;
using TTDataDictionary;
using TTInstanceManagement;
using TTObjectClasses;
using TTReportClasses;
using TTStorageManager.Security;
using TTUtils;
using static Core.Controllers.DrugOrderIntroductionServiceController;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class EmergencyOrderServiceController : Controller
    {
        public class EmergecyOrderDTO
        {
            public Guid store { get; set; }
            public string episodeActionId { get; set; }
            public string desciption { get; set; }
            public string episodeId { get; set; }
            public string patientId { get; set; }
            public List<EmergecyOrderMaterial> emergecyOrderMaterials { get; set; }
        }
        public class EmergecyOrderMaterial
        {
            public Material material { get; set; }
            public int amount { get; set; }
        }

        public class EmergecyOrderDetailDTO
        {
            public DateTime orderDate { get; set; }
            public string materialName { get; set; }
            public double amount { get; set; }
            public StockActionDetailStatusEnum status { get; set; }
            public Guid detailObjectId { get; set; }
            public Guid materialObjectID { get; set; }
            public string desciption { get; set; }
        }
        public class EmergecyOrderDetailInput_DTO
        {
            public Guid episodeActionID { get; set; }
        }

        public class CancelEmergecyOrderDetailInput_DTO
        {
            public Guid detailObjectId { get; set; }
        }

        public class CancelEmergecyOrderDetailOutput_DTO
        {
            public StockActionDetailStatusEnum status { get; set; }
            public string message { get; set; }
        }

        public class UpdateEmergecyOrderDetailInput_DTO
        {
            public Guid detailObjectId { get; set; }
            public double amount { get; set; }
        }

        public class EmergecyOrderDTO_Input
        {
            public List<EmergecyOrderDetailDTO> emergecyOrderDetailDTO { get; set; }
            public Guid episodeActionID { get; set; }
            public string desciption { get; set; }
            public List<EmergecyOrderDetailDTO> selectedEmergecyOrderDetailDTO { get; set; }
            public Guid storeID { get; set; }
        }


        [HttpPost]
        public List<EmergecyOrderDetailDTO> getEmergencyOrderDetails(EmergecyOrderDetailInput_DTO input)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            var episodeActionQuery = EpisodeAction.GetEpisodeActionByID(objectContext, input.episodeActionID.ToString()).FirstOrDefault();
            List<EmergecyOrderDetailDTO> orderDetails =
            EmergencyOrderDetail.GetEmergencyOrderDetail(episodeActionQuery.SubEpisode.ObjectID).Select(p => new EmergecyOrderDetailDTO
            {
                amount = p.Amount.Value,
                materialName = p.Material,
                detailObjectId = p.Detailid.Value,
                status = p.Status.Value,
                materialObjectID = p.Materialobjectid.Value,
                desciption = p.Desciption,
                orderDate = p.TransactionDate.Value
            }).ToList();
            return orderDetails;
        }

        [HttpPost]
        public string applyEmergencyOrderDetails(EmergecyOrderDTO_Input input)
        {
            try
            {
                string returnMessage = string.Empty;
                TTObjectContext objectContext = new TTObjectContext(false);
                List<BaseTreatmentMaterial> baseTreatmentMaterials = new List<BaseTreatmentMaterial>();
                var episodeActionQuery = EpisodeAction.GetEpisodeActionByID(objectContext, input.episodeActionID.ToString()).FirstOrDefault();
                EmergencyOrder emergencyOrder = objectContext.QueryObjects<EmergencyOrder>("SUBEPISODEID=" + ConnectionManager.GuidToString(episodeActionQuery.SubEpisode.ObjectID) + " AND CURRENTSTATEDEFID =" + ConnectionManager.GuidToString(EmergencyOrder.States.Approve)).FirstOrDefault();
                if (emergencyOrder == null)
                {
                    throw new Exception("Uygulanacak ilaç bulunamamıştır");
                }
                else
                {
                    foreach (EmergecyOrderDetailDTO detailItem in input.emergecyOrderDetailDTO)
                    {
                        EmergencyOrderDetail emergencyOrderDetail = null;
                        if (detailItem.detailObjectId != Guid.Empty)
                        {
                            emergencyOrderDetail = objectContext.GetObject<EmergencyOrderDetail>(detailItem.detailObjectId);
                        }
                        else
                        {
                            emergencyOrderDetail = new EmergencyOrderDetail(objectContext);
                            emergencyOrderDetail.Amount = detailItem.amount;
                            emergencyOrderDetail.EmergencyOrder = emergencyOrder;
                            emergencyOrderDetail.Material = objectContext.GetObject<Material>(detailItem.materialObjectID);
                            emergencyOrderDetail.Status = StockActionDetailStatusEnum.New;
                            emergencyOrderDetail.Store = objectContext.GetObject<Store>(input.storeID);

                        }

                        if (input.selectedEmergecyOrderDetailDTO.Select(x => x.materialObjectID == detailItem.materialObjectID).FirstOrDefault() == true)
                        {
                            if (detailItem.status == StockActionDetailStatusEnum.New)
                            {
                                if (emergencyOrder.EmergencyOrderDetails.Where(x => x.ObjectID == detailItem.detailObjectId).Select(t => t.Material.ObjectID == detailItem.detailObjectId).Any() != true)
                                {
                                    Material material = objectContext.GetObject<Material>(detailItem.materialObjectID);
                                    emergencyOrderDetail.Material = material;
                                }
                                
                                emergencyOrderDetail.Amount = detailItem.amount;
                                BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(objectContext);
                                newMaterial.Store = emergencyOrderDetail.Store;
                                newMaterial.Eligible = true;
                                newMaterial.Material = emergencyOrderDetail.Material;
                                newMaterial.Amount = emergencyOrderDetail.Amount;
                                newMaterial.EpisodeAction = episodeActionQuery;
                                newMaterial.SubEpisode = episodeActionQuery.SubEpisode;
                                newMaterial.ActionDate = Common.RecTime();
                                emergencyOrderDetail.SubActionMaterial = newMaterial;
                                emergencyOrderDetail.Status = StockActionDetailStatusEnum.Completed;


                                if (emergencyOrderDetail.Material is ConsumableMaterialDefinition)
                                {
                                    if (((ConsumableMaterialDefinition)emergencyOrderDetail.Material).IsIndividualTrackingRequired == true)
                                    {
                                        baseTreatmentMaterials.Add(newMaterial);
                                    }
                                }
                            }
                            else
                            {
                                emergencyOrderDetail.Status = StockActionDetailStatusEnum.Cancelled;
                            }
                        }
                        else
                        {
                            if (detailItem.status == StockActionDetailStatusEnum.Cancelled)
                            {
                                emergencyOrderDetail.Status = StockActionDetailStatusEnum.Cancelled;
                            }
                        }
                    }
                    emergencyOrder.Desciption = input.desciption;
                    returnMessage = "İşlem Başarılı Kayıt Oldu.";
                    objectContext.Save();

                    if (baseTreatmentMaterials.Count > 0)
                    {
                        returnMessage += "UTS MESAJI :" + this.MakeUTSUsageNotificationEmergenyOrder(baseTreatmentMaterials);
                    }

                    objectContext.Dispose();
                }
                return returnMessage;
            }
            catch (Exception ex)
            {
                throw new Exception("İşlem Sırasında Hata Alınmıştır.. Hata: " + ex.Message);
            }
        }


        [HttpPost]
        public string saveEmergencyOrder(EmergecyOrderDTO input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                Store store = objectContext.GetObject<Store>(input.store);
                var episodeActionQuery = EpisodeAction.GetEpisodeActionByID(objectContext, input.episodeActionId).FirstOrDefault();
                EmergencyOrder emergencyOrder = objectContext.QueryObjects<EmergencyOrder>("SUBEPISODEID=" + ConnectionManager.GuidToString(episodeActionQuery.SubEpisode.ObjectID) + " AND CURRENTSTATEDEFID =" + ConnectionManager.GuidToString(EmergencyOrder.States.Approve)).FirstOrDefault();
                if (emergencyOrder == null)
                {
                    emergencyOrder = new EmergencyOrder(objectContext);
                    emergencyOrder.CurrentStateDefID = EmergencyOrder.States.New;
                    emergencyOrder.EpisodeAction = episodeActionQuery;
                    emergencyOrder.TransactionDate = Common.RecTime();
                    emergencyOrder.SubEpisodeID = episodeActionQuery.SubEpisode.ObjectID;
                    emergencyOrder.Desciption = input.desciption;
                }

                foreach (var detail in input.emergecyOrderMaterials)
                {
                    EmergencyOrderDetail orderDetail = new EmergencyOrderDetail(objectContext);
                    orderDetail.Amount = detail.amount;
                    orderDetail.EmergencyOrder = emergencyOrder;
                    orderDetail.Material = detail.material;
                    orderDetail.Status = StockActionDetailStatusEnum.New;
                    orderDetail.Store = store;
                }
                objectContext.Save();
                emergencyOrder.CurrentStateDefID = EmergencyOrder.States.Approve;
                objectContext.Save();
                objectContext.Dispose();
                return "Acil Direktifi İstemi Yapıldı.";
            }
            catch (Exception ex)
            {
                return " İşlem Sırasında Hata Alınmıştır.. Hata: " + ex.Message;
            }
        }

        [HttpPost]
        public CancelEmergecyOrderDetailOutput_DTO cancelEmergencyOrderDetail(CancelEmergecyOrderDetailInput_DTO input)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            CancelEmergecyOrderDetailOutput_DTO output = new CancelEmergecyOrderDetailOutput_DTO();
            EmergencyOrderDetail detailItem = objectContext.GetObject<EmergencyOrderDetail>(input.detailObjectId);

            try
            {
                if (detailItem.Status == StockActionDetailStatusEnum.New)
                {
                    detailItem.Status = StockActionDetailStatusEnum.Cancelled;
                }
                else
                {
                    detailItem.Status = StockActionDetailStatusEnum.Cancelled;
                    detailItem.SubActionMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                }
                output.status = detailItem.Status.Value;
                output.message = "İşlem Başarılı";

                if (detailItem.Material is ConsumableMaterialDefinition)
                {
                    if (((ConsumableMaterialDefinition)detailItem.Material).IsIndividualTrackingRequired == true)
                    {
                        output.message += "UTS MESAJI:" + DeleteUTSRowTreatmentMaterialDetail((BaseTreatmentMaterial)detailItem.SubActionMaterial, objectContext);
                    }
                }

                objectContext.Save();
                objectContext.Dispose();
                return output;
            }
            catch (Exception ex)
            {
                output.message = "Hata" + ex.Message;
                return output;
            }
        }

        [HttpPost]
        public double updateAmountEmergencyOrderDetail(UpdateEmergecyOrderDetailInput_DTO input)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            EmergencyOrderDetail detailItem = objectContext.GetObject<EmergencyOrderDetail>(input.detailObjectId);

            try
            {
                if (detailItem.Status == StockActionDetailStatusEnum.New)
                {
                    detailItem.Amount = input.amount;
                }

                objectContext.Save();
                objectContext.Dispose();
                return detailItem.Amount.Value;
            }
            catch
            {
                return detailItem.Amount.Value;
            }
        }


        public string MakeUTSUsageNotificationEmergenyOrder(List<BaseTreatmentMaterial> baseTreatmentMaterials)
        {
            using (TTObjectContext context = new TTObjectContext(false))
            {
                string errorMessage = string.Empty;
                if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") == "TRUE")
                {
                    StockActionDetail stockActionDetail;
                    foreach (BaseTreatmentMaterial baseTreatmentMaterial in baseTreatmentMaterials)
                    {
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
                                            errorMessage += e.Message;
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
                                    errorMessage += stockActionDetail.Material.Name + " malzemesi için UTS kullanım bildirimi tamamlanamamıştır! " + ex.ToString();
                                }
                            }
                        }
                    }
                }

                if (String.IsNullOrEmpty(errorMessage) == true)
                {
                    return "UTS Bildirimleri Tamamlandı.";
                }
                else
                {
                    return errorMessage;
                }
            }
        }


        public string DeleteUTSRowTreatmentMaterialDetail(BaseTreatmentMaterial baseTreatmentMaterial, TTObjectContext objectContext)
        {
            string sonuc = string.Empty;
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

            if (baseTreatmentMaterial == null)
            {
                throw new Exception("Harekti Olmayan Malzeme İçin İşlem İlerletilemez. ");
            }

            foreach (StockTransaction item in baseTreatmentMaterial.StockActionDetail.StockTransactions.Select(""))
            {
                foreach (UTSNotificationDetail utsNotDet in item.UTSNotificationDetails.Where(x => x.CurrentStateDefID != UTSNotificationDetail.States.Cancelled))
                {
                    UTSServis.KullanimIptalBildirimiIstek kullanimIptalBildirimiIstek = new UTSServis.KullanimIptalBildirimiIstek();
                    kullanimIptalBildirimiIstek.BID = utsNotDet.NotificationID;
                    try
                    {
                        UTSServis.BildirimCevap KullanımIptalcevap = UTSServis.WebMethods.KullanimIptalBildirimiSync(new Guid(siteID), kullanimIptalBildirimiIstek);
                        sonuc = KullanımIptalcevap.MSJ[0].MET;
                        if (String.IsNullOrEmpty(KullanımIptalcevap.MSJ[0].TIP) == false)
                        {
                            if (KullanımIptalcevap.MSJ[0].TIP != "HATA")
                            {
                                utsNotDet.CurrentStateDefID = UTSNotificationDetail.States.Cancelled;
                                IBindingList acctrx = objectContext.QueryObjects(typeof(AccountTransaction).Name, "UTSNOTIFICATIONDETAIL = '" + utsNotDet.ObjectID.ToString() + "'");
                                foreach (AccountTransaction acc in acctrx)
                                {
                                    acc.UTSNotificationDetail = null;
                                }
                            }
                            else
                            {
                                sonuc = KullanımIptalcevap.MSJ[0].KOD + KullanımIptalcevap.MSJ[0].MET + KullanımIptalcevap.MSJ[0].MPA + KullanımIptalcevap.MSJ[0].TIP;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        sonuc = e.Message.ToString();
                    }
                }
            }
            if (String.IsNullOrEmpty(sonuc) == true)
            {
                throw new Exception("İşlem Yapılamadı." + sonuc);
            }
            return sonuc;
        }
    }
}
