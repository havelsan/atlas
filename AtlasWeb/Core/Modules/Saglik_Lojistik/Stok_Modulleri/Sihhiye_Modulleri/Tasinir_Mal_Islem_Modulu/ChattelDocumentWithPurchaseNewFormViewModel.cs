//$B9327ED3
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TTDataDictionary;

namespace Core.Controllers
{
    public partial class ChattelDocumentWithPurchaseServiceController
    {
        partial void PreScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTObjectContext objectContext)
        {
            string utsEnt = TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "");
            if (utsEnt != null && utsEnt != string.Empty)
                viewModel.UTSEntegration = bool.Parse(utsEnt);
            else
                viewModel.UTSEntegration = false;
        }
        partial void PostScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") != "FALSE")
            {
                if (chattelDocumentWithPurchase?.ChattelDocumentDetailsWithPurchase != null)
                {
                    foreach (var item in chattelDocumentWithPurchase?.ChattelDocumentDetailsWithPurchase)
                    {
                        // Seri No'su ya da Lot No'sundan en az biri girilmediyse ilerlemeye izin vermemeli.
                        if (string.IsNullOrEmpty(item.LotNo) && string.IsNullOrEmpty(item.SerialNo))
                        {
                            TTException exception = new TTException("Lot Numarası ya da Seri Numarasından en az biri girilmeden " + item.Material.Name + " malzemesi için giriş işlemi yapamazsınız!");
                        }
                    }
                }
            }
            if (transDef != null && transDef.ToStateDefID == ChattelDocumentWithPurchase.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "") != "FALSE")
                {
                    if (chattelDocumentWithPurchase?.ChattelDocumentDetailsWithPurchase != null)
                    {
                        foreach (var item in chattelDocumentWithPurchase?.ChattelDocumentDetailsWithPurchase)
                        {
                            if (item.Material.IsIndividualTrackingRequired == true)
                            {
                                string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                                if (string.IsNullOrEmpty(item.IncomingDeliveryNotifID))
                                {
                                    List<UTSServis.KabulEdilecekTekilUrunSorgulaSonuc> vermeBildirimleri = new List<UTSServis.KabulEdilecekTekilUrunSorgulaSonuc>();
                                    UTSServis.SayiIleKabulEdilecekTekilUrunSorgulaIstek istek = new UTSServis.SayiIleKabulEdilecekTekilUrunSorgulaIstek
                                    {
                                        GKK = long.Parse(chattelDocumentWithPurchase.Supplier.SupplierNumber),
                                        ADT = 100,
                                        OFF = string.Empty
                                    };
                                    try
                                    {
                                        UTSServis.SayiIleKabulEdilecekTekilUrunSorgulaCevap cevap =
                                            UTSServis.WebMethods.SayiIleKabulEdilecekTekilUrunSorgulaSync(new Guid(siteID), istek);
                                        if (cevap != null)
                                            vermeBildirimleri = cevap.SNC.LST;
                                    }
                                    catch (Exception e)
                                    {

                                    }

                                    foreach (var bildirim in vermeBildirimleri)
                                    {
                                        if (!string.IsNullOrEmpty(item.LotNo) && !string.IsNullOrEmpty(bildirim.LNO))
                                        {
                                            if (bildirim.LNO.Equals(item.LotNo))
                                                item.IncomingDeliveryNotifID = bildirim.BID;
                                        }
                                        else if (!string.IsNullOrEmpty(item.SerialNo) && !string.IsNullOrEmpty(bildirim.SNO))
                                        {
                                            if (bildirim.SNO.Equals(item.SerialNo))
                                                item.IncomingDeliveryNotifID = bildirim.BID;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseNewForm(ChattelDocumentWithPurchaseNewFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel._ChattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Completed)
            {

                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                    var sonucMesaji = chattelDocumentWithPurchase.SendMKYSForInputDocument(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                    foreach (DocumentRecordLog log in chattelDocumentWithPurchase.DocumentRecordLogs)
                    {
                        if (log.ReceiptNumber != null && chattelDocumentWithPurchase.FreeEntry != null)
                        {
                            if (chattelDocumentWithPurchase.FreeEntry == true)
                                chattelDocumentWithPurchase.SendMuayeneKabulCevapToXXXXXX();
                        }
                    }

                    if (chattelDocumentWithPurchase.PatientFullName != null && chattelDocumentWithPurchase.PatientUniqueNo != null)
                    {
                        BindingList<DirectMaterialSupplyAction> directMaterialSupplyAction = DirectMaterialSupplyAction.GetDirectMatSupplyByXXXXXXId(objectContext, Convert.ToInt32(chattelDocumentWithPurchase.XXXXXXTalepNo));
                        if (directMaterialSupplyAction.Count > 0)
                        {
                            DistributionDocument distributionDocument = new DistributionDocument(objectContext);
                            distributionDocument.CurrentStateDefID = DistributionDocument.States.New;
                            distributionDocument.DestinationStore = directMaterialSupplyAction[0].Store;
                            distributionDocument.Store = directMaterialSupplyAction[0].DestinationStore;
                            distributionDocument.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckSatinalmasiBaglananXXXXXXCikisi;
                            distributionDocument.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;
                            distributionDocument.MKYS_TeslimAlan = ((MainStoreDefinition)directMaterialSupplyAction[0].Store).GoodsResponsible.Name;
                            distributionDocument.MKYS_TeslimAlanObjID = ((MainStoreDefinition)directMaterialSupplyAction[0].Store).GoodsResponsible.ObjectID;
                            distributionDocument.MKYS_TeslimEden = ((SubStoreDefinition)directMaterialSupplyAction[0].DestinationStore).StoreResponsible.Name;
                            distributionDocument.MKYS_TeslimEdenObjID = ((SubStoreDefinition)directMaterialSupplyAction[0].DestinationStore).StoreResponsible.ObjectID;
                            distributionDocument.Description = "OTOMATİK DAĞITIM BELGESİ." + chattelDocumentWithPurchase.PatientUniqueNo + " " + chattelDocumentWithPurchase.PatientFullName + " HASTAYA GELEN SATINALMA İŞLEMİ.";
                            foreach (ChattelDocumentDetailWithPurchase detailPurchase in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
                            {
                                DistributionDocumentMaterial distributionDocumentMaterial = new DistributionDocumentMaterial(objectContext);
                                distributionDocumentMaterial.Material = detailPurchase.Material;
                                distributionDocumentMaterial.AcceptedAmount = detailPurchase.Amount;
                                distributionDocumentMaterial.Amount = detailPurchase.Amount;
                                StockTransaction trx = detailPurchase.StockTransactions.Select(string.Empty).FirstOrDefault();
                                OuttableLot outtableLot = new OuttableLot(objectContext);
                                outtableLot.LotNo = trx.LotNo;
                                if (trx.ExpirationDate == null)
                                    outtableLot.ExpirationDate = DateTime.MinValue;
                                else
                                    outtableLot.ExpirationDate = trx.ExpirationDate;
                                outtableLot.RestAmount = CurrencyType.ConvertFrom(trx.RestAmount);
                                outtableLot.Amount = CurrencyType.ConvertFrom(trx.Amount);
                                outtableLot.isUse = true;
                                outtableLot.StockActionDetailOut = distributionDocumentMaterial;
                                distributionDocument.DistributionDocumentMaterials.Add(distributionDocumentMaterial);
                            }

                            objectContext.Update();
                            distributionDocument.CurrentStateDefID = DistributionDocument.States.Approval;
                            objectContext.Update();
                            distributionDocument.CurrentStateDefID = DistributionDocument.States.Completed;
                            objectContext.Save();
                            if (directMaterialSupplyAction[0].CurrentStateDefID == DirectMaterialSupplyAction.States.Request)
                            {
                                directMaterialSupplyAction[0].CurrentStateDefID = DirectMaterialSupplyAction.States.Completed;
                                objectContext.Save();
                            }
                        }
                    }
                }

                foreach (var item in chattelDocumentWithPurchase?.ChattelDocumentDetailsWithPurchase)
                {
                    if (item.Material.IsIndividualTrackingRequired != null && item.Material.IsIndividualTrackingRequired.Value)
                    {
                        item.ReceiveNotificationID = MakeUTSReceiveNotification(item);
                        item.StockTransactions[0].ReceiveNotificationID = item.ReceiveNotificationID;
                        objectContext.Save();
                    }
                }

                if (chattelDocumentWithPurchase.InPatientPhysicianApplication != null)
                {
                    foreach (ChattelDocumentDetailWithPurchase detail in chattelDocumentWithPurchase.ChattelDocumentDetailsWithPurchase)
                    {
                        BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                        baseTreatmentMaterial.Material = detail.Material;
                        baseTreatmentMaterial.Amount = detail.Amount;
                        baseTreatmentMaterial.Patient = detail.Patient;
                        baseTreatmentMaterial.Store = chattelDocumentWithPurchase.Store;
                        DateTime now = Common.RecTime();
                        DateTime actionDate = chattelDocumentWithPurchase.WaybillDate.Value.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                        baseTreatmentMaterial.ActionDate = actionDate;
                        if (chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate < now)
                            baseTreatmentMaterial.PricingDate = chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                        chattelDocumentWithPurchase.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                    }
                }

                if (TTObjectClasses.SystemParameter.GetParameterValue("USEEXAMINATIONREPORTNOSEQ", "FALSE") == "TRUE")
                {
                    Guid examinationReportNoSeq = new Guid("ef2d5481-bbb7-4878-85b4-20f2d22cf06b");
                    chattelDocumentWithPurchase.ExaminationReportNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[examinationReportNoSeq], chattelDocumentWithPurchase.Store.ObjectID.ToString(), Common.RecTime().Year).ToString();
                }
                objectContext.Save();

                if (chattelDocumentWithPurchase.IsPTSAction == true)
                    chattelDocumentWithPurchase.SendITSReceiptNotification();
            }
        }

        [HttpGet]
        public bool UTSNotificationVerification(string VID, string BarcodeNo, string DocumentNo, long SendingOrganizationNo)
        {
            List<UTSNotification> utsNotifications;

            if (VID != null || VID != String.Empty)
                utsNotifications = UTSNotification.GetUTSNotificationByIncomingDeliveryNotifID(new TTObjectContext(true), VID).ToList();
            else
                utsNotifications = UTSNotification.GetUTSNotificationByBarkodeNo(new TTObjectContext(true), BarcodeNo, SendingOrganizationNo, DocumentNo).ToList();

            if (utsNotifications.Count > 0)
                return false;

            return true;
        }
    }
}

namespace Core.Models
{
    public partial class ChattelDocumentWithPurchaseNewFormViewModel
    {
        public class AddedUTSNotification
        {
            public string DeliveryNotifID { get; set; }
            public string LotNo { get; set; }
            public string SerialNo { get; set; }
        }
        public List<string> IncomingDeliveryNotificationID { get; set; }
        public bool UTSEntegration { get; set; }
        public List<AddedUTSNotification> AddedUTSNotifications { get; set; }

    }

}