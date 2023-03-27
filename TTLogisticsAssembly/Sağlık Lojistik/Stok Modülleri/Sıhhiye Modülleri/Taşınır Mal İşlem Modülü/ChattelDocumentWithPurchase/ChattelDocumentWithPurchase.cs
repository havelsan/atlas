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
using static TTObjectClasses.FsTasinirWebServis;
using TTObjectClasses.DTOs;

namespace TTObjectClasses
{
    /// <summary>
    /// Ta��n�r Mal ��lemi Sat�n Alma Yoluyla
    /// </summary>
    public partial class ChattelDocumentWithPurchase : BaseChattelDocument, IAutoDocumentNumber, IStockInTransaction, IAutoDocumentRecordLog, IChattelDocumentWithPurchase, ICheckStockActionInDetail
    {
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            MKYSControl = false;

            #endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_Approved2Completed()
        {
            #region PreTransition_Approved2Completed
            if (InPatientPhysicianApplication != null)
            {
                foreach (ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase in ChattelDocumentDetailsWithPurchase)
                    chattelDocumentDetailWithPurchase.Patient = InPatientPhysicianApplication.Episode.Patient;
            }
            #endregion PreTransition_Approved2Completed
        }
        protected void PreTransition_New2Completed()
        {
            #region PreTransition_New2Completed
            if (InPatientPhysicianApplication != null)
            {
                foreach (ChattelDocumentDetailWithPurchase chattelDocumentDetailWithPurchase in ChattelDocumentDetailsWithPurchase)
                    chattelDocumentDetailWithPurchase.Patient = InPatientPhysicianApplication.Episode.Patient;
            }
            #endregion PreTransition_New2Completed
        }

        protected void PreTransition_Completed2FixDocument()
        {
            #region PreTransition_Completed2FixDocument
            string errorMsg = string.Empty;
            foreach (ChattelDocumentDetailWithPurchase purchaseDetail in this.ChattelDocumentDetailsWithPurchase)
            {
                foreach (StockTransaction trx in purchaseDetail.StockTransactions.Select(string.Empty))
                {
                    foreach (StockTransactionDetail trxDetail in trx.StockTransactionDetails)
                    {
                        if (trxDetail.OutStockTransaction.CurrentStateDefID == StockTransaction.States.Completed)
                        {
                            if (string.IsNullOrEmpty(errorMsg))
                                errorMsg = trxDetail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.ToString();
                            else
                                errorMsg = errorMsg + ", " + trxDetail.OutStockTransaction.StockActionDetail.StockAction.StockActionID.ToString();
                        }

                    }

                }
            }

            if (string.IsNullOrEmpty(errorMsg) == false)
                throw new TTException(errorMsg + " numaral� i�lem(ler) ile ��k�� oldu�u i�in i�lemi d�zeltme ad�m�na alamazs�n�z.");

            #endregion PreTransition_Completed2FixDocument
        }

        protected void PostTransition_Completed2FixDocument()
        {
            #region PostTransition_Completed2FixDocument
            foreach (ChattelDocumentDetailWithPurchase purchaseDetail in this.ChattelDocumentDetailsWithPurchase)
            {
                foreach (StockTransaction trx in purchaseDetail.StockTransactions.Select(string.Empty))
                    trx.CurrentStateDefID = StockTransaction.States.Cancelled;
            }
            #endregion PostTransition_Completed2FixDocument
        }

        #region Methods
        #region IAutoDocumentRecordLog Member
        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> GetDocumentRecordLogContents()
        {
            return DocumentRecordLogContents;
        }
        #endregion
        #region IChattelDocumentWithPurchase Member
        public string GetWaybill()
        {
            return Waybill;
        }

        public int? GetXXXXXXSatMKabulId()
        {
            return XXXXXXSatMKabulId;
        }

        public DateTime? GetWaybillDate()
        {
            return WaybillDate;
        }

        public int? GetFastSoftFaturaId()
        {
            return FastSoftFaturaId;
        }

        public int? GetFastSoftUygulamaId()
        {
            return FastSoftUygulamaId;
        }

        public Boolean? GetIsFastSoft()
        {
            return IsFastSoft;
        }

        public DateTime? GetAuctionDate()
        {
            return AuctionDate;
        }

        public string GetRegistrationAuctionNo()
        {
            return RegistrationAuctionNo;
        }

        public DateTime? GetConclusionDateTime()
        {
            return ConclusionDateTime;
        }

        public string GetConclusionNumber()
        {
            return ConclusionNumber;
        }

        public DateTime? GetExaminationReportDate()
        {
            return ExaminationReportDate;
        }

        public string GetExaminationReportNo()
        {
            return ExaminationReportNo;
        }
        #endregion
        #region IChattelDocumentWithSupplier Members
        ISupplier IChattelDocumentWithSupplier.GetSupplier()
        {
            return (ISupplier)Supplier;
        }

        #endregion IChattelDocumentWithSupplier Members
        #region ICheckStockActionInDetail Members
        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }
        #endregion 
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        public static ChattelDocumentWithPurchase GetWaybillForInputDocumentTS(ChattelDocumentWithPurchase chattelDocumentWithPurchase)
        {
            return chattelDocumentWithPurchase.GetWaybillForInputDocument(chattelDocumentWithPurchase);
        }



        public ChattelDocumentWithPurchase GetWaybillForInputDocument(ChattelDocumentWithPurchase chattelDocumentWithPurchase)
        {
            ChattelDocumentWithPurchase chatteldoc = new ChattelDocumentWithPurchase(chattelDocumentWithPurchase.ObjectContext);
            string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
            string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
            string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
            XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
            XXXXXXTasinirMal.MuayeneAramaKriterInfoWS muayeneKR = new XXXXXXTasinirMal.MuayeneAramaKriterInfoWS();
            muayeneKR.MkysDepoKodu = ((MainStoreDefinition)Store).StoreRecordNo.Value.ToString();
            muayeneKR.IrsaliyeNo = Waybill; //"3333";
            XXXXXXTasinirMal.MuayeneKabulInfoWS[] kabulInfoList = XXXXXXTasinirMal.WebMethods.MuayeneKabulGetSync(Sites.SiteLocalHost, sonuc.Mesaj, muayeneKR).ToArray();
            string exp = string.Empty;
            try
            {
                if (kabulInfoList.Count() == 1)
                {
                    XXXXXXTasinirMal.MuayeneKabulInfoWS kabulDetay = kabulInfoList[0];
                    chatteldoc.MKYS_EAlimYontemi = (MKYS_EAlimYontemiEnum)Enum.Parse(typeof(MKYS_EAlimYontemiEnum), (Convert.ToInt32(kabulDetay.AlimYontemId) - 1).ToString());
                    switch (kabulDetay.ButceTurId)
                    {
                        case "B": //GENEL B�T�E
                            var budget1 = ObjectContext.QueryObjects("BUDGETTYPEDEFINITION", "OBJECTID='57c410cc-afea-487a-8327-76e91a696a02'");
                            chatteldoc.BudgetTypeDefinition = (BudgetTypeDefinition)budget1[0];
                            break;
                        case "D": //D�NER SERMAYE
                            var budget2 = ObjectContext.QueryObjects("BUDGETTYPEDEFINITION", "OBJECTID='3511171d-06ae-4434-ad44-3579ee616ecb'");
                            chatteldoc.BudgetTypeDefinition = (BudgetTypeDefinition)budget2[0];
                            break;
                        default:
                            exp += kabulDetay.ButceTurId + " - B�t�e T�r� Tan�ml� De�ildir \n";
                            break;
                    }

                    IBindingList supplier = ObjectContext.QueryObjects("SUPPLIER", "TAXNO= '" + kabulDetay.FirmaVergiNo + "' AND  NAME  LIKE '%" + kabulDetay.FirmaAdi + "%'");
                    if (supplier.Count == 1)
                    {
                        chatteldoc.Supplier = (Supplier)supplier[0];
                    }
                    else
                    {
                        exp += kabulDetay.FirmaVergiNo + " - " + kabulDetay.FirmaAdi + " Firma Sistemde Tan�ml� De�ildir. \n";
                    }

                    if (kabulDetay.IhaleTarihi == DateTime.MinValue) //TODO : kar�� tarafdan isa geliyor.
                        chatteldoc.AuctionDate = DateTime.Now;
                    else
                        chatteldoc.AuctionDate = kabulDetay.IhaleTarihi;
                    chatteldoc.ExaminationReportNo = kabulDetay.MuayeneNo.ToString();
                    chatteldoc.ExaminationReportDate = kabulDetay.MuayeneTarihi;
                    chatteldoc.MKYS_TeslimAlan = kabulDetay.TeslimAlan;
                    chatteldoc.MKYS_TeslimEden = kabulDetay.TeslimEden;
                    chatteldoc.WaybillDate = kabulDetay.IrsaliyeTarihi;
                    chatteldoc.XXXXXXInvoice = kabulDetay.FaturaTutar;
                    chatteldoc.XXXXXXGeneralTotal = kabulDetay.GenelToplam;
                    chatteldoc.XXXXXXSaleTotal = kabulDetay.IndirimTutar;
                    chatteldoc.XXXXXXVatTotal = kabulDetay.KdvTutar;
                    chatteldoc.RegistrationAuctionNo = kabulDetay.IKN;
                    chatteldoc.ConclusionDateTime = kabulDetay.MakamOnayTarihi;
                    chatteldoc.ConclusionNumber = kabulDetay.MakamOnayNo;
                    chatteldoc.PatientFullName = kabulDetay.HastaAdSoyad;
                    chatteldoc.PatientUniqueNo = kabulDetay.HastaTC;
                    chatteldoc.XXXXXXTalepNo = kabulDetay.TalepNo.ToString();
                    foreach (XXXXXXTasinirMal.MuayeneKabulKalemInfoWS kalemdetay in kabulDetay.MuayeneKalemleri)
                    {
                        ChattelDocumentDetailWithPurchase detayPurchase = new ChattelDocumentDetailWithPurchase(chatteldoc.ObjectContext);
                        if (kalemdetay.Barkod != null) //Buras� de�i�ecek
                        {
                            IBindingList mat = null;
                            if (!String.IsNullOrEmpty(kalemdetay.Barkod))
                                mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + kalemdetay.Barkod + "' AND MKYSMALZEMEKODU ='" + kalemdetay.MalzemeKayitId + "'"); //ISACTIVE �ZELL��� VER� BOZUK OLDUGUNDAN KOYULDU KALDIRILACAK.
                            else
                                mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND  MKYSMALZEMEKODU ='" + kalemdetay.MalzemeKayitId + "'");
                            if (mat.Count == 1)
                            {
                                Material material = (Material)mat[0];
                                detayPurchase.Material = material;
                                detayPurchase.Amount = kalemdetay.Miktar;
                                detayPurchase.UnitPriceWithOutVat = kalemdetay.AlisFiyati;
                                detayPurchase.VatRate = kalemdetay.KdvOran;
                                detayPurchase.UnitPriceWithInVat = kalemdetay.KdvTutar;
                                detayPurchase.DiscountRate = kalemdetay.IndirimOrani;
                                detayPurchase.DiscountAmount = kalemdetay.IndirimTutar;
                                detayPurchase.Price = kalemdetay.Tutar;
                                detayPurchase.ExpirationDate = kalemdetay.SonKullanmaTarihi;
                                detayPurchase.DiscountAmount = kalemdetay.IndirimTutar;
                                detayPurchase.LotNo = kalemdetay.LotNo;
                                detayPurchase.StockLevelType = StockLevelType.NewStockLevel;
                                detayPurchase.Status = StockActionDetailStatusEnum.New;
                                detayPurchase.RetrievalYear = Common.RecTime().Year;
                                //detayPurchase.ProductionDate 
                            }
                            else if (mat.Count > 1)
                            {
                                exp += kalemdetay.Barkod + "-" + kalemdetay.MalzemeAdi + TTUtils.CultureService.GetText("M25076", "1 den fazla malzeme bulunmu�tur");
                            }
                            else
                            {
                                exp += kalemdetay.Barkod + " - " + kalemdetay.MalzemeAdi + " Malzeme Bilgisi Sistemde Bulunmamaktad�r.";
                            }
                        }

                        chatteldoc.ChattelDocumentDetailsWithPurchase.Add(detayPurchase);
                    }
                }
                else if (kabulInfoList.Count() > 1)
                {
                    exp += TTUtils.CultureService.GetText("M25277", "Birden Fazla Kay�t Bulunmu�tur.");
                }
                else
                {
                    exp += TTUtils.CultureService.GetText("M26090", "�rsaliyeli Kay�t Bulunamam��t�r.");
                }

                if (!string.IsNullOrEmpty(exp))
                {
                    throw new Exception(exp);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

            return chatteldoc;
        }


        public static ChattelDocumentWithPurchase GetWaybillForInputDocumentTSFastsoft(ChattelDocumentWithPurchase chattelDocumentWithPurchase)
        {
            return chattelDocumentWithPurchase.GetWaybillForInputDocumentFastsoft(chattelDocumentWithPurchase);
        }

        public ChattelDocumentWithPurchase GetWaybillForInputDocumentFastsoft(ChattelDocumentWithPurchase chattelDocumentWithPurchase)
        {
            ChattelDocumentWithPurchase chatteldoc = new ChattelDocumentWithPurchase(chattelDocumentWithPurchase.ObjectContext);
            string birim_ID = TTObjectClasses.SystemParameter.GetParameterValue("FASTSOFTBIRIMID", "");
            FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS AramaKriter = new FsTasinirWebServis.MuayeneFaturaAramaKriterInfoWS
            {
                FaturaNo = Waybill
            };
            Guid siteID = Sites.SiteLocalHost;
            string exp = string.Empty;
            try
            {
                MuayeneFaturaInfoWS[] MuayeneFaturaInfo = FsTasinirWebServis.WebMethods.MuayeneFaturaGetSync(siteID, "", "", birim_ID, AramaKriter);

                if (MuayeneFaturaInfo.Count() == 1)
                {
                    MuayeneFaturaInfoWS kabulDetay = MuayeneFaturaInfo[0];

                    chatteldoc.MKYS_EAlimYontemi = (MKYS_EAlimYontemiEnum)Enum.Parse(typeof(MKYS_EAlimYontemiEnum), (Convert.ToInt32(kabulDetay.AlimYontemId) - 1).ToString());
                    switch (kabulDetay.ButceTurId)
                    {
                        case "B": //GENEL B�T�E
                            var budget1 = ObjectContext.QueryObjects("BUDGETTYPEDEFINITION", "OBJECTID='57c410cc-afea-487a-8327-76e91a696a02'");
                            chatteldoc.BudgetTypeDefinition = (BudgetTypeDefinition)budget1[0];
                            break;
                        case "D": //D�NER SERMAYE
                            var budget2 = ObjectContext.QueryObjects("BUDGETTYPEDEFINITION", "OBJECTID='3511171d-06ae-4434-ad44-3579ee616ecb'");
                            chatteldoc.BudgetTypeDefinition = (BudgetTypeDefinition)budget2[0];
                            break;
                        default:
                            exp += kabulDetay.ButceTurId + " - B�t�e T�r� Tan�ml� De�ildir \n";
                            break;
                    }

                    IBindingList supplier = ObjectContext.QueryObjects("SUPPLIER", "TAXNO= '" + kabulDetay.FirmaVergiNo + "'");
                    if (supplier.Count >= 1)
                    {
                        chatteldoc.Supplier = (Supplier)supplier[0];
                    }
                    else
                    {
                        exp += kabulDetay.FirmaVergiNo + " - " + kabulDetay.FirmaAdi + " Firma Sistemde Tan�ml� De�ildir. \n";
                    }

                    if (kabulDetay.IhaleTarihi == DateTime.MinValue)
                        chatteldoc.AuctionDate = DateTime.Now;
                    else
                        chatteldoc.AuctionDate = kabulDetay.IhaleTarihi;
                    chatteldoc.ExaminationReportNo = kabulDetay.MuayeneNo.ToString();
                    chatteldoc.ExaminationReportDate = kabulDetay.MuayeneTarihi;
                    chatteldoc.MKYS_TeslimAlan = kabulDetay.TeslimAlan;
                    chatteldoc.MKYS_TeslimEden = kabulDetay.TeslimEden;
                    chatteldoc.WaybillDate = kabulDetay.IrsaliyeTarihi;
                    chatteldoc.RegistrationAuctionNo = kabulDetay.IhaleKayitNo;
                    chatteldoc.ConclusionDateTime = kabulDetay.MakamOnayTarihi;
                    chatteldoc.ConclusionNumber = kabulDetay.MakamOnayNo;
                    chatteldoc.FastSoftFaturaId = kabulDetay.FaturaId;
                    chatteldoc.FastSoftUygulamaId = kabulDetay.UygulamaId;

                    if (kabulDetay.MuayeneFaturaKalemList == null)
                    {
                        exp += "Fatura detaylar� bulunamad�.\n";
                    }
                    else
                    {
                        foreach (MuayeneFaturaKalemInfoWS kalemdetay in kabulDetay.MuayeneFaturaKalemList)
                        {
                            ChattelDocumentDetailWithPurchase detayPurchase = new ChattelDocumentDetailWithPurchase(chatteldoc.ObjectContext);
                            if (kalemdetay.Barkod != null)
                            {
                                IBindingList mat = null;
                                if (!String.IsNullOrEmpty(kalemdetay.Barkod))
                                    mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND BARCODE= '" + kalemdetay.Barkod + "' AND MKYSMALZEMEKODU ='" + kalemdetay.MalzemeKayitId + "'");
                                else
                                    mat = ObjectContext.QueryObjects("MATERIAL", "ISACTIVE = 1 AND  MKYSMALZEMEKODU ='" + kalemdetay.MalzemeKayitId + "'");
                                if (mat.Count == 1)
                                {
                                    Material material = (Material)mat[0];
                                    detayPurchase.Material = material;
                                    detayPurchase.Amount = kalemdetay.Miktar;
                                    detayPurchase.UnitPriceWithOutVat = kalemdetay.AlisFiyati;
                                    detayPurchase.VatRate = kalemdetay.KdvOrani;
                                    detayPurchase.UnitPriceWithInVat = kalemdetay.KdvTutar;
                                    detayPurchase.DiscountRate = kalemdetay.IndirimOrani;
                                    detayPurchase.DiscountAmount = kalemdetay.Tutar - kalemdetay.NetTutar;
                                    detayPurchase.Price = kalemdetay.Tutar;
                                    detayPurchase.ExpirationDate = kalemdetay.SonKullanmaTarihi;
                                    detayPurchase.StockLevelType = StockLevelType.NewStockLevel;
                                    detayPurchase.Status = StockActionDetailStatusEnum.New;
                                    detayPurchase.RetrievalYear = Common.RecTime().Year;
                                }
                                else if (mat.Count > 1)
                                {
                                    exp += kalemdetay.Barkod + " - Barkodlu  " + kalemdetay.MalzemeKayitId + " - Malzeme Kayit Idli " + kalemdetay.MalzemeAdi + TTUtils.CultureService.GetText("M25076", "1 den fazla malzeme bulunmu�tur");
                                }
                                else
                                {
                                    exp += kalemdetay.Barkod + " - Barkodlu  " + kalemdetay.MalzemeKayitId + " - Malzeme Kayit Idli " + kalemdetay.MalzemeAdi + " Malzeme Bilgisi Sistemde Bulunmamaktad�r.";
                                }
                            }

                            chatteldoc.ChattelDocumentDetailsWithPurchase.Add(detayPurchase);
                        }
                    }
                }
                else if (MuayeneFaturaInfo.Count() > 1)
                {
                    exp += TTUtils.CultureService.GetText("M25277", "Birden Fazla Kay�t Bulunmu�tur.");
                }
                else
                {
                    exp += TTUtils.CultureService.GetText("M26090", "�rsaliyeli Kay�t Bulunamam��t�r.");
                }

                if (!string.IsNullOrEmpty(exp))
                {
                    throw new TTException(exp);
                }
            }
            catch (Exception e)
            {
                throw new TTException(e.Message);
            }

            return chatteldoc;
        }


        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Tasinir_Mal_Islemi_Satin_Alma_Yoluyla_Tamam)]
        public static string SendMuayeneKabulCevapToXXXXXXTS(ChattelDocumentWithPurchase purchase)
        {
            return purchase.SendMuayeneKabulCevapToXXXXXX();
        }

        public string SendMuayeneKabulCevapToXXXXXX()
        {
            string BolumId = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPBOLUMID", "");
            string ehipWsUsername = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICIADI", "");
            string ehipWsPassword = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXEHIPKULLANICISIFRESI", "");
            XXXXXXTasinirMal.IslemSonuc sonuc = XXXXXXTasinirMal.WebMethods.GetEhipWsEntegreKeyByBolumIdSync(Sites.SiteLocalHost, BolumId, ehipWsUsername, ehipWsPassword);
            XXXXXXTasinirMal.MuayeneKabulCevapInfoWS kabulInfo = new XXXXXXTasinirMal.MuayeneKabulCevapInfoWS();
            kabulInfo.IrsaliyeNo = Waybill;
            kabulInfo.SatMuayeneKabulId = (int)XXXXXXSatMKabulId;
            DocumentRecordLog currentLog = null;
            foreach (DocumentRecordLog log in DocumentRecordLogs)
            {
                if (log.DocumentTransactionType == DocumentTransactionTypeEnum.In)
                {
                    kabulInfo.TifNo = log.DocumentRecordLogNumber.Value.ToString();
                    kabulInfo.TifTarihi = (DateTime)log.DocumentDateTime;
                }
            }

            XXXXXXTasinirMal.IslemSonuc islemSonuc = XXXXXXTasinirMal.WebMethods.MuayeneKabulTifKaydetSync(Sites.SiteLocalHost, sonuc.Mesaj, kabulInfo);
            XXXXXXEtkilenenAdet = islemSonuc.EtkilenenAdet;
            XXXXXXKayitId = islemSonuc.KayitID;
            XXXXXXMesaj = islemSonuc.Mesaj;
            XXXXXXIslemBasarili = islemSonuc.IslemBasarili;
            return XXXXXXMesaj;
        }


        private List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> _documentRecordLogContents = null;
        public List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent> DocumentRecordLogContents
        {
            get
            {
                Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>> inRecordLogs = new Dictionary<MKYS_EButceTurEnum, List<StockActionDetail>>();
                foreach (ChattelDocumentDetailWithPurchase detail in ChattelDocumentDetailsWithPurchase)
                {
                    foreach (StockTransaction inTrx in detail.StockTransactions.Where(d => d.CurrentStateDefID == StockTransaction.States.Completed).ToList())
                    {
                        if (inTrx.InOut == TransactionTypeEnum.In)
                        {
                            if (inTrx.BudgetTypeDefinition.MKYS_Butce == null)
                                throw new TTException(inTrx.BudgetTypeDefinition.Name + " b�tcesi MKYS ile e�le�tirilmemi�tir. L�tfen e�le�tirip i�leme �yle devam ediniz.");
                            MKYS_EButceTurEnum butce = (MKYS_EButceTurEnum)inTrx.BudgetTypeDefinition.MKYS_Butce;
                            if (inRecordLogs.ContainsKey(butce))
                            {
                                if (inRecordLogs[butce].Contains(detail) == false)
                                    inRecordLogs[butce].Add(detail);
                            }
                            else
                            {
                                List<StockActionDetail> dets = new List<StockActionDetail>();
                                dets.Add(detail);
                                inRecordLogs.Add(butce, dets);
                            }
                        }
                    }
                }

                if (inRecordLogs.Count > 0)
                {
                    _documentRecordLogContents = new List<AutoDocumentRecordLogAttribute.DocumentRecordLogContent>();
                    foreach (KeyValuePair<MKYS_EButceTurEnum, List<StockActionDetail>> inLog in inRecordLogs)
                    {
                        string place = this.Supplier.Name;
                        int countOfRow = inLog.Value.Count;

                        if (this.IsPTSAction == true)
                        {

                            countOfRow = this.PTSStockActionDetails.Count;

                            //List<StockActionDetailIn> inDetailList = new List<StockActionDetailIn>();
                            //foreach (StockActionDetail stockActionDetail in inLog.Value)
                            //{
                            //    StockActionDetailIn det = (StockActionDetailIn)stockActionDetail;
                            //    int findDetail = inDetailList.Where(x => x.Material == det.Material && x.LotNo == det.LotNo && x.ExpirationDate == det.ExpirationDate && x.UnitPrice == det.UnitPrice).Count();
                            //    if (findDetail == 0)
                            //        inDetailList.Add(det);
                            //}
                            //countOfRow = inDetailList.Count();
                        }

                        AutoDocumentRecordLogAttribute.DocumentRecordLogContent logContent = new AutoDocumentRecordLogAttribute.DocumentRecordLogContent(DocumentTransactionTypeEnum.In, this, countOfRow, place, inLog.Key);
                        _documentRecordLogContents.Add(logContent);
                    }
                }

                return _documentRecordLogContents;
            }
        }

        public void CalculateDistributionAmounts()
        {
            double reqAmount = 0;
            foreach (ChattelDocumentDetailWithPurchase cdm in ChattelDocumentDetailsWithPurchase)
            {
                reqAmount = 0;
                foreach (ChattelDocumentDistribution cdd in cdm.ChattelDocumentDistributions)
                {
                    reqAmount += (double)cdd.DemandDetail.Amount;
                }

                if (cdm.Amount < reqAmount) //Eksik al�nm��
                {
                    foreach (ChattelDocumentDistribution cdd in cdm.ChattelDocumentDistributions)
                        cdd.DistributionAmount = (cdm.Amount * 100) / reqAmount;
                }
                else
                {
                    foreach (ChattelDocumentDistribution cdd in cdm.ChattelDocumentDistributions)
                        cdd.DistributionAmount = cdd.DemandDetail.Amount;
                }
            }
        }

        #region ihaleTarihiVeNumarasiUpdate

        public string SendIhaleTarihiVeNumarasiUpdateMessageToMKYS(string mkysPwd)
        {
            string SonucMesaj = string.Empty;

            using (var objectContext = new TTObjectContext(false))
            {
                //if (this.HasMemberChanged("AuctionDate") || this.HasMemberChanged("RegistrationAuctionNo"))
                //    return "";
                //�hale tarihi ve numaras� update
                SonucMesaj = ihaleTarihiVeNumarasiUpdate(mkysPwd, this);
                if (String.IsNullOrEmpty(SonucMesaj))
                    SonucMesaj = TTUtils.CultureService.GetText("M26531", "MKYS g�nderim i�lemi ba�ar�s�z!");

                return SonucMesaj;
            }
        }

        public string ihaleTarihiVeNumarasiUpdate(string mkysPwd, ChattelDocumentWithPurchase chattelDocumentWithPurchase)
        {
            string SonucMesaj = string.Empty;
            DocumentRecordLog currentLog = null;
            try
            {
                MkysServis.ihaleTarihiUpdateInsertItem updateInsertItem = new MkysServis.ihaleTarihiUpdateInsertItem();
                updateInsertItem.ihaleNo = chattelDocumentWithPurchase.RegistrationAuctionNo;
                updateInsertItem.ihaleTarihi = chattelDocumentWithPurchase.AuctionDate;
                currentLog = chattelDocumentWithPurchase.DocumentRecordLogs.Where(d => d.ReceiptNumber != null).FirstOrDefault();
                if (currentLog == null || currentLog.ReceiptNumber.HasValue == false)
                    throw new Exception("MKYS' ye g�nderimi tamamlanmam�� i�lemin ihale numaras� ve/veya ihale tarihi de�i�tirilemez.");
                updateInsertItem.ayniyatMakbuzID = currentLog.ReceiptNumber.Value;

                MkysServis.ihaleTarihiUpdateResult ihaleTarihiUpdateResult = MkysServis.WebMethods.ihaleTarihiVeNumarasiUpdateSync(Sites.SiteLocalHost, updateInsertItem);

                if (!ihaleTarihiUpdateResult.basaridurumu)
                {
                    throw new Exception("�hale Tarihi ve/veya numarasi g�ncelleme ba�ar�s�z!" + ihaleTarihiUpdateResult.mesaj);
                }
                else
                {
                    currentLog.ReceiptNumber = ihaleTarihiUpdateResult.ayniyatMakbuzID;
                    chattelDocumentWithPurchase.RegistrationAuctionNo = ihaleTarihiUpdateResult.ihaleNo;
                    chattelDocumentWithPurchase.AuctionDate = ihaleTarihiUpdateResult.ihaleTarihi;
                    SonucMesaj += updateInsertItem.ayniyatMakbuzID.ToString() + " ayniyat makbuz nolu i�lemin ihale numaras� ve/veya ihale tarihi g�ncelenmi�tir.";
                }

                return SonucMesaj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion ihaleTarihiVeNumarasiUpdate


        public static string CreateFromDTO(StockActionDTO model)
        {
            string result = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                ChattelDocumentWithPurchase stockAction;
                if (model.StockActionObjectId.HasValue)
                {
                    stockAction = objectContext.GetObject<ChattelDocumentWithPurchase>(model.StockActionObjectId.Value);
                }
                else
                {
                    stockAction = new ChattelDocumentWithPurchase(objectContext);
                }
                stockAction.MKYS_EAlimYontemi = (MKYS_EAlimYontemiEnum)model.BuyMethod;
                stockAction.BudgetTypeDefinition = objectContext.GetObject<BudgetTypeDefinition>(model.BudgetType.Value);
                stockAction.MKYS_TeslimAlanObjID = model.Deliverer;
                stockAction.MKYS_TeslimAlan = model.DelivererName;
                stockAction.MKYS_TeslimEdenObjID = model.TakenBy;
                stockAction.MKYS_TeslimEden = model.TakenByName;
                stockAction.Description = model.Description;
                stockAction.Store = objectContext.GetObject<Store>(model.MainStoreId);
                stockAction.TransactionDate = model.TicketDate;
                stockAction.MKYS_ETedarikTuru = (MKYS_ETedarikTurEnum)model.SupplyType;
                stockAction.Supplier = objectContext.GetObject<Supplier>(model.CompanyId);
                stockAction.AuctionDate = model.TenderDate;
                stockAction.RegistrationAuctionNo = model.TenderNumber;
                stockAction.ExaminationReportNo = model.ControlNumber;
                stockAction.ExaminationReportDate = model.ControlDate;
                stockAction.WaybillDate = model.BreederDocumentDate;
                stockAction.Waybill = model.BreederDocumentNumber;
                stockAction.MKYS_EMalzemeGrup = model.MaterialGroup;
                if (model.InPatientPhysicianApplication.HasValue)
                {
                    stockAction.InPatientPhysicianApplication = objectContext.GetObject<InPatientPhysicianApplication>(model.InPatientPhysicianApplication.Value);
                }
                foreach (var materialDTO in model.MaterialList)
                {
                    ChattelDocumentDetailWithPurchase detailPurchase;
                    if (materialDTO.ObjectID != null && materialDTO.ObjectID != Guid.Empty)
                    {
                        detailPurchase = objectContext.GetObject<ChattelDocumentDetailWithPurchase>(materialDTO.ObjectID);
                    }
                    else
                    {
                        detailPurchase = new ChattelDocumentDetailWithPurchase(objectContext);
                    }
                    detailPurchase.Material = objectContext.GetObject<Material>(materialDTO.MaterialID);
                    detailPurchase.Amount = materialDTO.Amount;
                    detailPurchase.UnitPriceWithOutVat = materialDTO.UnitPriceWithOutVat;
                    detailPurchase.VatRate = Convert.ToInt64(materialDTO.VatRate);
                    detailPurchase.UnitPriceWithInVat = materialDTO.UnitPriceWithInVat;
                    detailPurchase.DiscountRate = materialDTO.DiscountRate;
                    detailPurchase.DiscountAmount = materialDTO.DiscountAmount;
                    detailPurchase.NotDiscountedUnitPrice = materialDTO.NotDiscountedUnitPrice; //TODO
                    detailPurchase.Price = materialDTO.Price;
                    detailPurchase.UnitPrice = materialDTO.UnitPrice; //TODO
                    detailPurchase.ExpirationDate = materialDTO.ExpirationDate;
                    detailPurchase.LotNo = materialDTO.LotNo;
                    detailPurchase.StockLevelType = StockLevelType.NewStockLevel;
                    detailPurchase.Status = StockActionDetailStatusEnum.New;
                    detailPurchase.RetrievalYear = Common.RecTime().Year;
                    stockAction.ChattelDocumentDetailsWithPurchase.Add(detailPurchase);
                }
                stockAction.CurrentStateDefID = States.New;
                objectContext.Save();
                if (model.RecordType == 1)
                {
                    stockAction.CurrentStateDefID = States.Completed;
                    objectContext.Save();
                    if (model.SendToMKYS)
                    {
                        result = stockAction.SendMKYSForInputDocument(model.MKYSPassword);
                    }
                    AfterContextSaveScript(stockAction);
                }
                return result;
            }
        }

        public static void AfterContextSaveScript(ChattelDocumentWithPurchase stockAction)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                foreach (var item in stockAction?.ChattelDocumentDetailsWithPurchase)
                {
                    if (item.Material.IsIndividualTrackingRequired != null && item.Material.IsIndividualTrackingRequired.Value)
                    {
                        item.ReceiveNotificationID = MakeUTSReceiveNotification(item);
                        item.StockTransactions[0].ReceiveNotificationID = item.ReceiveNotificationID;
                        objectContext.Save();
                    }
                }

                if (stockAction.InPatientPhysicianApplication != null)
                {
                    foreach (ChattelDocumentDetailWithPurchase detail in stockAction.ChattelDocumentDetailsWithPurchase)
                    {
                        BaseTreatmentMaterial baseTreatmentMaterial = new BaseTreatmentMaterial(objectContext);
                        baseTreatmentMaterial.Material = detail.Material;
                        baseTreatmentMaterial.Amount = detail.Amount;
                        baseTreatmentMaterial.Patient = detail.Patient;
                        baseTreatmentMaterial.Store = stockAction.Store;
                        baseTreatmentMaterial.ActionDate = stockAction.WaybillDate.Value;
                        if (stockAction.InPatientPhysicianApplication.SubEpisode.ClosingDate < Common.RecTime())
                            baseTreatmentMaterial.PricingDate = stockAction.InPatientPhysicianApplication.SubEpisode.ClosingDate;
                        stockAction.InPatientPhysicianApplication.TreatmentMaterials.Add(baseTreatmentMaterial);
                    }
                }
            }
        }

        private static string MakeUTSReceiveNotification(ChattelDocumentDetailWithPurchase item)
        {
            string siteID = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
            UTSServis.VidAlmaBildirimiIstek almaBildirimiIstek = new UTSServis.VidAlmaBildirimiIstek
            {
                ADT = item.Amount,
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

        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChattelDocumentWithPurchase).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ChattelDocumentWithPurchase.States.Approved && toState == ChattelDocumentWithPurchase.States.Completed)
                PreTransition_Approved2Completed();
            if (fromState == ChattelDocumentWithPurchase.States.Completed && toState == ChattelDocumentWithPurchase.States.Cancelled)
                PreTransition_Completed2Cancelled();
            if (fromState == ChattelDocumentWithPurchase.States.New && toState == ChattelDocumentWithPurchase.States.Completed)
                PreTransition_New2Completed();
            if (fromState == ChattelDocumentWithPurchase.States.Completed && toState == ChattelDocumentWithPurchase.States.FixDocument)
                PreTransition_Completed2FixDocument();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ChattelDocumentWithPurchase).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ChattelDocumentWithPurchase.States.Completed && toState == ChattelDocumentWithPurchase.States.FixDocument)
                PostTransition_Completed2FixDocument();
        }

    }
}