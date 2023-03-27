//$D4EB28FE
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.ComponentModel;
using TTDataDictionary;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Xml;
using System.IO.Compression;
using System.IO;
using System.Xml.Serialization;

namespace Core.Controllers
{
    public partial class ChattelDocumentWithPurchaseServiceController
    {
        partial void PreScript_ChattelDocumentWithPurchaseApproveForm(ChattelDocumentWithPurchaseApproveFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTObjectContext objectContext)
        {
            string utsEnt = TTObjectClasses.SystemParameter.GetParameterValue("UTSENTEGRATION", "");
            if (utsEnt != null || utsEnt != string.Empty)
                viewModel.UTSEntegration = bool.Parse(utsEnt);
            else
                viewModel.UTSEntegration = false;
        }
        partial void PostScript_ChattelDocumentWithPurchaseApproveForm(ChattelDocumentWithPurchaseApproveFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //Tamamlandı statetine geçiliyorsa lot no seri no ve verme bildirimi yapılıp yapılmadığını anlamak için kontroller
            if (transDef.ToStateDefID == ChattelDocumentWithPurchase.States.Completed)
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

        private string MakeUTSReceiveNotification(ChattelDocumentDetailWithPurchase item)
        {
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");

            int amount = this.UTSSendReceiveNot((ChattelDocumentWithPurchase)item.StockAction, item);

            UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
            {
                ADT = amount,
                VBI = item.IncomingDeliveryNotifID
            };

            UTSServis.BildirimCevap almaBildirimiCevap = null;
            try
            {
                almaBildirimiCevap = UTSServis.WebMethods.VIDAlmaBildirimiSync(new Guid(siteID), almaBildirimiIstek);
            }
            catch (Exception e)
            {
                // todo
            }

            if (almaBildirimiCevap != null && !string.IsNullOrEmpty(almaBildirimiCevap.SNC))
            {
                return almaBildirimiCevap.SNC;
            }
            return null;
        }

        partial void AfterContextSaveScript_ChattelDocumentWithPurchaseApproveForm(ChattelDocumentWithPurchaseApproveFormViewModel viewModel, ChattelDocumentWithPurchase chattelDocumentWithPurchase, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
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
                        baseTreatmentMaterial.ActionDate = chattelDocumentWithPurchase.WaybillDate.Value;
                        if (chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate < Common.RecTime())
                            baseTreatmentMaterial.PricingDate = chattelDocumentWithPurchase.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                        chattelDocumentWithPurchase.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                    }
                }
                objectContext.Save();
            }

        }

        public class UTSBatchGridDataType
        {
            public string IncomingDeliveryNotifID { get; set; }
            public string ProductName { get; set; }
            public string ProductNo { get; set; }
            public long SendingOrganizationNo { get; set; }
            public string UniqueDeviceIdentifier { get; set; }
            public string LotNumber { get; set; }
            public string SerialNumber { get; set; }
            public Material ReceivedMaterial { get; set; }
            public string DocumentNo { get; set; }
            public int Amount { get; set; }
        }

        [HttpGet]
        public List<UTSBatchGridDataType> GetUTSIncomingReceiveNotifications(string GKK, string BNO)
        {
            try
            {

                List<UTSBatchGridDataType> dataList = new List<UTSBatchGridDataType>();
                UTSServis.KabulEdilecekTekilUrunSorgulaIstek kabulEdilecekTekilUrunSorgulaIstek = new UTSServis.KabulEdilecekTekilUrunSorgulaIstek()
                {
                    GKK = long.Parse(GKK),
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
                            if (sonuc.BNO == BNO)
                            {
                                TTObjectContext context = new TTObjectContext(false);
                                Material material = Material.GetMaterialByBarcode(context, sonuc.UNO)?.ToList()?.FirstOrDefault();
                                if (material != null)
                                {
                                    int amount = 1;
                                    UTSServis.UrunSorgulaIstek urunSorgulaIstek = new UTSServis.UrunSorgulaIstek();
                                    urunSorgulaIstek.UNO = sonuc.UNO;
                                    UTSServis.UrunSorgulaCevap urunBilgisiCevap = UTSServis.WebMethods.UrunSorgulaSync_ServerSide1(urunSorgulaIstek);

                                    if (urunBilgisiCevap != null && urunBilgisiCevap.UrunDetayList.Count > 0)
                                        amount = urunBilgisiCevap.UrunDetayList[0].UrunSayisi;
                                    else
                                        amount = 1;


                                    UTSBatchGridDataType data = new UTSBatchGridDataType
                                    {
                                        ReceivedMaterial = material,
                                        IncomingDeliveryNotifID = sonuc.BID,
                                        ProductNo = sonuc.UNO,
                                        SendingOrganizationNo = sonuc.GKK,
                                        SerialNumber = sonuc.SNO,
                                        LotNumber = sonuc.LNO,
                                        DocumentNo = sonuc.BNO,
                                        Amount = amount * sonuc.ADT,
                                    };
                                    dataList.Add(data);
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(BNO) || BNO == sonuc.BNO)
                                        errorMessage = errorMessage + sonuc.UNO + " barkod numaralı " + sonuc.MME + " isimli malzeme ";
                                }
                            }
                            else
                            {
                                if (vermeBildirimleri.SNC.Count == 1)
                                    errorMessage = errorMessage + BNO + " Numaralı Fatura Numarası Sistemde Bulunamadı";
                            }
                        }
                    }
                    kabulEdilecekTekilUrunSorgulaIstek.SAN++;
                }
                while (vermeBildirimleri?.SNC?.Count == 10);

                if (string.IsNullOrEmpty(errorMessage) == false)
                {
                    errorMessage = errorMessage + "sistemde kayıtlı değildir !";
                    throw new TTException(errorMessage);
                }

                if (string.IsNullOrEmpty(BNO) == false)
                    dataList = dataList.Where(x => x.DocumentNo.Equals(BNO)).ToList();
                return dataList;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    throw new TTException(ex.InnerException.Message);
                else
                    throw new TTException(ex.Message);
            }

        }


        public class XMLReadDocumentFile
        {
            public string xmlFileName { get; set; }

            public string xmlFile { get; set; }

            public StockAction stockAction { get; set; }
        }

        [HttpPost]
        public PTSMaterialOutput GetItsReceiptNotificationFileRead(XMLReadDocumentFile documentFile)
        {
            PTSMaterialOutput output = new PTSMaterialOutput();
            try
            {
                XmlDocument document = new XmlDocument();
                documentFile.xmlFile = documentFile.xmlFile.Replace("-<", "<");
                document.LoadXml(documentFile.xmlFile);

                using (TextReader sr = new StringReader(document.InnerXml))
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(XMLtoObject));
                    var obj = serializer.Deserialize(sr) as XMLtoObject;
                    output = this.AddPTSActionDetails(obj, documentFile.stockAction);
                }

                //output = this.AddPTSActionDetails(document, documentFile.stockAction);
            }
            catch (TTException ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception(ex.InnerException.InnerException.Message.ToString());
                }
                else
                {
                    throw new Exception("Hata mesajı alınamadı. Sistem Yöneticisine başvurun.");
                }
            }
            return output;
        }

        public class PTSInputDVO
        {
            public string PTSID { get; set; }
            public StockAction stockAction { get; set; }
        }

        [HttpPost]
        public PTSMaterialOutput GetItsReceiptNotification(PTSInputDVO input)
        {
            TTObjectContext context = new TTObjectContext(false);
            PTSPackageReceiverServis.receiveFileParametersType request = new PTSPackageReceiverServis.receiveFileParametersType();
            request.sourceGLN = TTObjectClasses.SystemParameter.GetParameterValue("ITSGLN", "");
            request.transferId = Convert.ToInt32(input.PTSID);

            byte[] fileArray = null;
            byte[] decompresedBuffer = null;

            PTSMaterialOutput output = new PTSMaterialOutput();

            try
            {
                fileArray = PTSPackageReceiverServis.WebMethods.receiveFileStream(Sites.SiteLocalHost, request);
                decompresedBuffer = TTUtils.Helpers.SharpZipHelper.DecompressZipAndReturnFirstFileEntry(fileArray);
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(decompresedBuffer);
                XmlDocument document = new XmlDocument();
                document.Load(memoryStream);

                using (TextReader sr = new StringReader(document.InnerXml))
                {

                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(XMLtoObject));
                    var obj = serializer.Deserialize(sr) as XMLtoObject;
                    output = this.AddPTSActionDetails(obj, input.stockAction);

                }


            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw new Exception("HATA :" + ex.InnerException.Message);
                }
                else
                {
                    throw new Exception("HATA : " + ex.Message);
                }
            }

            return output;

        }


        [System.Xml.Serialization.XmlRoot("transfer")]
        public class XMLtoObject
        {
            public string sourceGLN { get; set; }
            public string destinationGLN { get; set; }
            public string actionType { get; set; }
            public string shipTo { get; set; }
            public string documentNumber { get; set; }
            public string documentDate { get; set; }
            [XmlElement(ElementName = "carrier")]
            public List<Carrier> carrier { get; set; }
        }
        [System.Xml.Serialization.XmlRoot("carrier")]
        public class Carrier
        {
            [XmlAttribute("carrierLabel")]
            public string carrierLabel { get; set; }
            [XmlAttribute("containerType")]
            public string containerType { get; set; }

            [XmlElement(ElementName = "productList")]
            public List<ProductList> productList { get; set; }
            [XmlElement(ElementName = "carrier")]
            public List<Carrier> carrier { get; set; }
        }
        [System.Xml.Serialization.XmlRoot("productList")]
        public class ProductList
        {
            [XmlAttribute("GTIN")]
            public string GTIN { get; set; }
            [XmlAttribute("lotNumber")]
            public string lotNumber { get; set; }
            [XmlAttribute("expirationDate")]
            public string expirationDate { get; set; }
            [XmlAttribute("PONumber")]
            public string PONumber { get; set; }
            [XmlAttribute("productionDate")]
            public string productionDate { get; set; }
            [XmlElement(ElementName = "serialNumber")]
            public List<string> serialNumber { get; set; }
        }

        public List<ProductList> ProductListMethod(List<Carrier> carrier, List<ProductList> productListReturn)
        {
            foreach (Carrier cr in carrier)
            {
                if (cr.carrier.Count > 0)
                {
                    ProductListMethod(cr.carrier, productListReturn);
                }
                else
                {
                    productListReturn.AddRange(cr.productList);
                }
            }
            return productListReturn;
        }

        public PTSMaterialOutput AddPTSActionDetails(XMLtoObject document, StockAction stockAction)
        {

            PTSMaterialOutput output = new PTSMaterialOutput();
            output.StockCards = new List<StockCard>();
            output.PTSMaterials = new List<PTSMaterial>();
            output.StockLevelType = StockLevelType.NewStockLevel;
            int ID = 1;

            List<ProductList> productList = new List<ProductList>();
            var productListReturn = new List<ProductList>();
            productListReturn = this.ProductListMethod(document.carrier, productList);


            foreach (ProductList xn in productListReturn)
            {
                TTObjectContext context = new TTObjectContext(false);
                PTSMaterial pTSMaterial = new PTSMaterial();
                pTSMaterial.barcode = xn.GTIN;
                IBindingList materialList = context.QueryObjects("MATERIAL", "BARCODE = '" + pTSMaterial.barcode.Substring(1, 13) + "'");
                if (materialList.Count > 0)
                {
                    ChattelDocumentDetailWithPurchase detailMat = new ChattelDocumentDetailWithPurchase(context);
                    detailMat.Material = (Material)materialList[0];
                    if (detailMat.Material.StockCard != null)
                    {
                        if (output.StockCards.Contains(detailMat.Material.StockCard) == false)
                            output.StockCards.Add(detailMat.Material.StockCard);
                    }
                    detailMat.ExpirationDate = null;
                    detailMat.LotNo = xn.lotNumber;
                    detailMat.UnitPriceWithOutVat = null;
                    detailMat.VatRate = Material.GetVatrateFromMaterialTS((Material)materialList[0], Common.RecTime()); ;
                    detailMat.UnitPriceWithInVat = null;
                    detailMat.DiscountRate = null;
                    detailMat.UnitPrice = null;
                    detailMat.DiscountAmount = null;
                    if (String.IsNullOrEmpty(xn.productionDate) != true)
                    {
                        detailMat.RetrievalYear = Convert.ToDateTime(xn.productionDate).Year;
                        detailMat.ProductionDate = Convert.ToDateTime(xn.productionDate);
                    }
                    pTSMaterial.ID = ID;
                    ID = ID + 1;
                    pTSMaterial.material = (Material)materialList[0];
                    pTSMaterial.materialObjectID = ((Material)materialList[0]).ObjectID;
                    pTSMaterial.lotNO = xn.lotNumber;
                    pTSMaterial.expirationDate = Convert.ToDateTime(xn.expirationDate);
                    pTSMaterial.materialName = ((Material)materialList[0]).Name;
                    pTSMaterial.NatoStockNo = ((Material)materialList[0]).StockCard.NATOStockNO;
                    pTSMaterial.DistributionTypeName = ((Material)materialList[0]).DistributionTypeName;
                    pTSMaterial.UnitPriceWithOutVat = null;
                    pTSMaterial.VatRate = Material.GetVatrateFromMaterialTS((Material)materialList[0], Common.RecTime());
                    pTSMaterial.UnitPriceWithInVat = null;
                    pTSMaterial.DiscountRate = null;
                    pTSMaterial.UnitPrice = null;
                    pTSMaterial.DiscountAmount = null;
                    if (String.IsNullOrEmpty(xn.productionDate) != true)
                    {
                        pTSMaterial.RetrievalYear = Convert.ToDateTime(xn.productionDate).Year;
                        pTSMaterial.ProductionDate = Convert.ToDateTime(xn.productionDate);
                    }

                    if (stockAction is ChattelDocumentWithPurchase)
                    {
                        IBindingList sups = context.QueryObjects("SUPPLIER", "GLNNO = '" + document.sourceGLN + "'");
                        if (sups.Count > 0)
                            pTSMaterial.supplier = (Supplier)sups[0];
                        else
                            throw new Exception("Tedarikçi/Firma Sistemde Bulunamamıştır.Firma GLNNO numarası :" + document.sourceGLN);

                        pTSMaterial.DocumentRecordNo = document.documentNumber;
                        pTSMaterial.DocumentRecordDate = Convert.ToDateTime(document.documentDate);

                        IBindingList checkOfSystemPTS = context.QueryObjects(typeof(ChattelDocumentWithPurchase).Name, " ISPTSACTION = 1 AND WAYBILL ='" + pTSMaterial.DocumentRecordNo
                           + "' AND CURRENTSTATE <> STATES.Cancelled AND SUPPLIER ='" + pTSMaterial.supplier.ObjectID + "'");

                        IBindingList checkWithAccOfSystemPTS = context.QueryObjects(typeof(ChattelDocumentInputWithAccountancy).Name, " ISPTSACTION = 1 AND WAYBILL ='" + pTSMaterial.DocumentRecordNo
                          + "' AND CURRENTSTATE <> STATES.Cancelled");


                        if (checkOfSystemPTS.Count > 0)
                            throw new Exception(document.documentNumber + " Döküman numarası işlem sistemde daha önceden girişi yapılmıştır.Giriş işlem numarası :" + ((StockAction)checkOfSystemPTS[0]).StockActionID);
                        if (checkWithAccOfSystemPTS.Count > 0)
                            throw new Exception(document.documentNumber + " Döküman numarası işlem sistemde daha önceden girişi yapılmıştır.Giriş işlem numarası :" + ((StockAction)checkWithAccOfSystemPTS[0]).StockActionID);
                    }
                    else
                    {
                        IBindingList acco = context.QueryObjects("ACCOUNTANCY", "GLNNO = '" + document.sourceGLN + "'");
                        if (acco.Count > 0)
                            pTSMaterial.accountancy = (Accountancy)acco[0];
                        else
                            throw new Exception("Kurum Sistemde Bulunamamıştır.Firma/Kurum GLNNO numarası :" + document.sourceGLN);

                        pTSMaterial.DocumentRecordNo = document.documentNumber;
                        pTSMaterial.DocumentRecordDate = Convert.ToDateTime(document.documentDate);

                        IBindingList checkOfSystemPTS = context.QueryObjects(typeof(ChattelDocumentInputWithAccountancy).Name, " ISPTSACTION = 1 AND WAYBILL ='" + pTSMaterial.DocumentRecordNo
                           + "' AND CURRENTSTATE <> STATES.Cancelled AND ACCOUNTANCY ='" + pTSMaterial.accountancy.ObjectID + "'");
                        if (checkOfSystemPTS.Count > 0)
                            throw new Exception(document.documentNumber + " Döküman numarası işlem sistemde daha önceden girişi yapılmıştır.Giriş işlem numarası :" + ((StockAction)checkOfSystemPTS[0]).StockActionID);
                    }
                    pTSMaterial.amount = 0;

                    PTSMaterial findPTS = output.PTSMaterials.Where(x => x.materialObjectID == ((Material)materialList[0]).ObjectID && x.lotNO == xn.lotNumber && x.expirationDate == Convert.ToDateTime(xn.expirationDate)).FirstOrDefault();
                    if (findPTS == null)
                    {
                        pTSMaterial.serialNOList = new List<PTSMaterialSerialNumber>();
                        for (int i = 0; i < xn.serialNumber.Count; i++)
                        {
                            PTSMaterialSerialNumber materialSerialNumber = new PTSMaterialSerialNumber();
                            materialSerialNumber.serialNo = xn.serialNumber[i];
                            if (pTSMaterial.material.PackageAmount != null)
                            {
                                if ((double)pTSMaterial.material.PackageAmount > 0)
                                    materialSerialNumber.amount = (double)pTSMaterial.material.PackageAmount;
                                else
                                    materialSerialNumber.amount = 1;
                            }
                            else
                            {
                                materialSerialNumber.amount = 1;
                            }

                            detailMat.Amount = materialSerialNumber.amount;
                            detailMat.SerialNo = materialSerialNumber.serialNo;
                            materialSerialNumber.chattelDocumentDetailWithPurchase = detailMat;
                            pTSMaterial.serialNOList.Add(materialSerialNumber);
                            pTSMaterial.amount += materialSerialNumber.amount;
                        }

                        output.PTSMaterials.Add(pTSMaterial);
                    }
                    else
                    {
                        for (int i = 0; i < xn.serialNumber.Count; i++)
                        {
                            PTSMaterialSerialNumber materialSerialNumber = new PTSMaterialSerialNumber();
                            materialSerialNumber.serialNo = xn.serialNumber[i];
                            if (pTSMaterial.material.PackageAmount != null)
                            {
                                if ((double)pTSMaterial.material.PackageAmount > 0)
                                    materialSerialNumber.amount = (double)pTSMaterial.material.PackageAmount;
                                else
                                    materialSerialNumber.amount = 1;
                            }
                            else
                            {
                                materialSerialNumber.amount = 1;
                            }

                            detailMat.Amount = materialSerialNumber.amount;
                            detailMat.SerialNo = materialSerialNumber.serialNo;
                            materialSerialNumber.chattelDocumentDetailWithPurchase = detailMat;

                            findPTS.serialNOList.Add(materialSerialNumber);
                            findPTS.amount += materialSerialNumber.amount;
                        }
                    }
                }
                else
                    throw new Exception(pTSMaterial.barcode.Substring(1, 13) + " Barkod nolu ilaç bulunamamıştır.Lütfen ilaç tanımını yapınız.");
            }
            return output;
        }
    }
}

namespace Core.Models
{
    public class RespectiveIncomingUTSNotification
    {
        public string IncomingReceiveNotificationID { get; set; }
        public ChattelDocumentDetailWithPurchase chattelDocumentDetailsWithPurchase { get; set; }
    }
    public partial class ChattelDocumentWithPurchaseApproveFormViewModel
    {
        public List<RespectiveIncomingUTSNotification> RespectiveIncomingUTSNotificationList { get; set; }
        public bool UTSEntegration { get; set; }
    }


    public class PTSMaterialSerialNumber
    {
        public string serialNo { get; set; }
        public double amount { get; set; }
        public ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase { get; set; }
    }

    public class PTSMaterialOutput
    {
        public List<PTSMaterial> PTSMaterials { get; set; }
        public List<StockCard> StockCards { get; set; }
        public StockLevelType StockLevelType { get; set; }
    }

    public class PTSMaterial
    {
        public int ID { get; set; }
        public Material material { get; set; }
        public Guid materialObjectID { get; set; }
        public string barcode { get; set; }
        public string materialName { get; set; }
        public DateTime expirationDate { get; set; }
        public string lotNO { get; set; }
        public List<PTSMaterialSerialNumber> serialNOList { get; set; }

        public double amount { get; set; }
        public string NatoStockNo { get; set; }
        public string DistributionTypeName { get; set; }
        public double? price { get; set; }
        public double? UnitPriceWithOutVat { get; set; }
        public double? VatRate { get; set; }
        public double? UnitPriceWithInVat { get; set; }

        public double? DiscountRate { get; set; }
        public double? UnitPrice { get; set; }
        public double? DiscountAmount { get; set; }
        public int? RetrievalYear { get; set; }
        public DateTime? ProductionDate { get; set; }

        public Supplier supplier { get; set; }

        public Accountancy accountancy { get; set; }

        public string DocumentRecordNo { get; set; }
        public DateTime? DocumentRecordDate { get; set; }

        public PTSStockActionDetail PTSStockActionDetail { get; set; }
    }
}