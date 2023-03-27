using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TTInstanceManagement;
using TTObjectClasses;
using TTUtils;

namespace Core.Controllers.Invoice
{
    public class Utils
    {
        public static void UpdateTransactionState(List<string> accountTransactionIDs, bool state,List<AccountTransaction> actList = null)
        {
            if (accountTransactionIDs.Count > 0 || (actList != null && actList.Count > 0))
            {
                TTObjectContext objectcontext = null;
                SubEpisodeProtocol sep = null;
                if (actList != null && actList.Count > 0)
                {
                    objectcontext = actList[0].ObjectContext;
                    for (int i = 0; i < actList.Count; i++)
                    {
                        AccountTransaction acctrx = actList[i];
                        if (state)
                            acctrx.CurrentStateDefID = AccountTransaction.States.New;
                        else
                            acctrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                        InvoiceLog.AddInfo("Hizmetin durumu güncellendi Yeni Durum: " + (state ? TTUtils.CultureService.GetText("M24515", "Yeni") : TTUtils.CultureService.GetText("M25734", "Gönderilmeyecek")), acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxState, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                        if (i == 0)
                            sep = acctrx.SubEpisodeProtocol;
                    }
                }
                else if (accountTransactionIDs.Count > 0)
                {
                    objectcontext = new TTObjectContext(false);
                    for (int i = 0; i < accountTransactionIDs.Count; i++)
                    {
                        AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                        if (state)
                            acctrx.CurrentStateDefID = AccountTransaction.States.New;
                        else
                            acctrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                        InvoiceLog.AddInfo("Hizmetin durumu güncellendi Yeni Durum: " + (state ? TTUtils.CultureService.GetText("M24515", "Yeni") : TTUtils.CultureService.GetText("M25734", "Gönderilmeyecek")), acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxState, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                        if (i == 0)
                            sep = acctrx.SubEpisodeProtocol;
                    }
                }

                objectcontext.Save();
                if (sep != null)
                    sep.SetInvoiceStatusAfterProcedureEntry();
                objectcontext.Save();
            }
        }

        public static void UpdateDiagnosisState(List<string> SEPDiagnosisIDs, bool state)
        {
            if (SEPDiagnosisIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                SubEpisodeProtocol sep = null;
                for (int i = 0; i < SEPDiagnosisIDs.Count; i++)
                {
                    SEPDiagnosis sepD = (SEPDiagnosis)objectcontext.GetObject(new Guid(SEPDiagnosisIDs[i]), typeof (SEPDiagnosis));
                    if (state)
                        sepD.CurrentStateDefID = SEPDiagnosis.States.New;
                    else
                        sepD.CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                    
                    InvoiceLog.AddInfo("Tanı durumu güncellendi. Yeni Durum: " + (state ? CultureService.GetText("M24515", "Yeni") : CultureService.GetText("M25734", "Gönderilmeyecek")), sepD.ObjectID, InvoiceOperationTypeEnum.UpdateDiagnosisState, InvoiceLogObjectTypeEnum.SEPDiagnosis, objectcontext);

                    if (i == 0)
                        sep = sepD.SubEpisodeProtocol;
                }

                objectcontext.Save();
                if (sep != null)
                    sep.SetInvoiceStatusAfterProcedureEntry();
                objectcontext.Save();
            }
        }

        public static void UpdateTransactionInvoiceInclusion(List<string> accountTransactionIDs, bool state)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    acctrx.InvoiceInclusion = state;
                    InvoiceLog.AddInfo("Hizmet dahillik durumu güncellendi Yeni Durum: " + (state ? TTUtils.CultureService.GetText("M25388", "Dahil."): TTUtils.CultureService.GetText("M25387", "Dahil değil.")), acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxInclusion, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                }

                objectcontext.Save();
            }
        }

        public static void UpdateTransactionDate(List<string> accountTransactionIDs, DateTime newDate)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Hizmet tarihi güncellendi ED: " + acctrx.TransactionDate.Value.ToString("dd/MM/yyyy") + " YD: " + newDate.ToString("dd/MM/yyyy"), acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxDate, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.TransactionDate = newDate;
                }

                objectcontext.Save();
            }
        }

        public static void UpdateTransactionPrice(List<Guid> accTrxObjectIDList, double? newPrice)
        {
            if (accTrxObjectIDList.Count > 0)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                foreach (Guid accTrxObjectID in accTrxObjectIDList)
                {
                    AccountTransaction acctrx = objectContext.GetObject<AccountTransaction>(accTrxObjectID);
                    InvoiceLog.AddInfo("Hizmet birim fiyatı güncellendi ED: " + acctrx.UnitPrice.Value + " YD: " + newPrice, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxUnitPrice, InvoiceLogObjectTypeEnum.AccountTransaction, objectContext, acctrx.UnitPrice.Value.ToString(), newPrice.Value.ToString());
                    acctrx.UnitPrice = newPrice;
                }

                objectContext.Save();
                objectContext.Dispose();
            }
        }

        public static void UpdateAltVaka(List<string> accountTransactionIDs, string altVakaObjectID)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                List<SubEpisodeProtocol> updateSEPList = new List<SubEpisodeProtocol>();
                SubEpisodeProtocol sep = null;
                if (!Guid.Empty.ToString().Equals(altVakaObjectID))
                    sep = objectcontext.GetObject(new Guid(altVakaObjectID), typeof (SubEpisodeProtocol)) as SubEpisodeProtocol;

                if(sep != null && sep.IsInvoiced)
                    throw new TTException(TTUtils.CultureService.GetText("M25669", "Faturalanmış durumdaki takip satırlarına taşıma işlemi yapılamaz."));

                updateSEPList.Add(sep);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));

                    SubEpisodeProtocol oldSEP = acctrx.SubEpisodeProtocol;
                    if (oldSEP.Payer.ObjectID == sep.Payer.ObjectID && oldSEP.Protocol.ObjectID == sep.Protocol.ObjectID)
                    {
                        acctrx.SubEpisodeProtocol = sep;
                    }
                    else
                    {
                        if (acctrx.SubActionProcedure != null)
                        {
                            acctrx.SubActionProcedure.ChangeMyProtocol(sep);
                        }
                        else if (acctrx.SubActionMaterial != null)
                        {
                            acctrx.SubActionMaterial.ChangeMyProtocol(sep);
                        }
                    }
                    InvoiceLog.AddInfo("Hizmetin altvakası değiştirildi ED: " + oldSEP.Id + " YD: " + sep.Id, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxSEP, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    if (!updateSEPList.Contains(acctrx.SubEpisodeProtocol))
                        updateSEPList.Add(acctrx.SubEpisodeProtocol);

                    if (acctrx.SubActionProcedure != null)
                    {
                        if (acctrx.SubActionProcedure.CreationDate < sep.SubEpisode.OpeningDate)
                            acctrx.SubActionProcedure.CreationDate = sep.SubEpisode.OpeningDate;
                        if (acctrx.SubActionProcedure.PerformedDate < sep.SubEpisode.OpeningDate)
                            acctrx.SubActionProcedure.PerformedDate = sep.SubEpisode.OpeningDate;
                    }
                    else if (acctrx.SubActionMaterial != null)
                    {
                        ENabizMaterial tempEnabizMaterial = acctrx.ENabizMaterial.FirstOrDefault();
                        if (tempEnabizMaterial != null)
                        {
                            if (tempEnabizMaterial.RequestDate < sep.SubEpisode.OpeningDate)
                                tempEnabizMaterial.RequestDate = sep.SubEpisode.OpeningDate;
                            if (tempEnabizMaterial.ApplicationDate < sep.SubEpisode.OpeningDate)
                                tempEnabizMaterial.ApplicationDate = sep.SubEpisode.OpeningDate;
                        }
                    }
                }

                objectcontext.Save();
                foreach (SubEpisodeProtocol sepInner in updateSEPList)
                    sepInner.SetInvoiceStatusAfterProcedureEntry();
                objectcontext.Save();
            }
        }

        public static void UpdateOzelDurum(List<string> accountTransactionIDs, string ozelDurumObjectID)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                OzelDurum ozelDurum = null;
                if (!Guid.Empty.ToString().Equals(ozelDurumObjectID))
                    ozelDurum = objectcontext.GetObject(new Guid(ozelDurumObjectID), typeof (OzelDurum)) as OzelDurum;
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    string YD = "";
                    if (ozelDurum != null)
                        YD = ozelDurum.ozelDurumKodu;
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin özel durumu değiştirildi " + (acctrx.OzelDurum != null ? "ED: " + acctrx.OzelDurum.ozelDurumKodu : "") + " YD: " + YD, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxOzelDurum, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.OzelDurum = ozelDurum;
                }

                objectcontext.Save();
            }
        }
        public static void UpdateKesi(List<string> accountTransactionIDs, string kesiObjectID)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                AyniFarkliKesi kesi = null;
                if (!Guid.Empty.ToString().Equals(kesiObjectID))
                    kesi = objectcontext.GetObject(new Guid(kesiObjectID), typeof(AyniFarkliKesi)) as AyniFarkliKesi;
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    string YD = "";
                    if (kesi != null)
                        YD = kesi.ayniFarkliKesiKodu;
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin kesi bilgisi değiştirildi " + (acctrx.AyniFarkliKesi != null ? "ED: " + acctrx.AyniFarkliKesi.ayniFarkliKesiKodu : "") + " YD: " + YD, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxKesi, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.AyniFarkliKesi= kesi;
                }

                objectcontext.Save();
            }
        }
        public static void UpdateSagSol(List<string> accountTransactionIDs, int? lr)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    string YD = "";
                    if (lr != null)
                        YD = Common.GetDisplayTextOfDataTypeEnum((SurgeryLeftRight)lr);
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin sağ sol bilgisi değiştirildi " + (acctrx.Position != null ? "ED: " + Common.GetDisplayTextOfDataTypeEnum(acctrx.Position): "") + " YD: " + YD, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxPosition, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    if (lr == null || lr == (int)SurgeryLeftRight.AllTheSame)
                        acctrx.Position = null;
                    else
                        acctrx.Position = (SurgeryLeftRight)lr;
                }

                objectcontext.Save();
            }
        }
        
        public static class XmlSerializer
        {
            public static string Serialize<T>(T item)
            {
                MemoryStream memStream = new MemoryStream();
                using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                {
                    textWriter.Formatting = Formatting.Indented;
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof (T));
                    serializer.Serialize(textWriter, item);
                    memStream = textWriter.BaseStream as MemoryStream;
                }

                if (memStream != null)
                    return Encoding.Unicode.GetString(memStream.ToArray());
                else
                    return null;
            }

            public static T Deserialize<T>(string xmlString)
            {
                if (string.IsNullOrEmpty(xmlString))
                    return default (T);
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                    {
                        memStream.Position = 0;
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof (T));
                        return (T)serializer.Deserialize(memStream);
                    }
                }
            }
        }

        internal static void UpdateMedulaReportNo(List<string> accountTransactionIDs, string reportNo)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    //TODO: Adet değiştirme ile kontroller çalıştırılması gereken kodlar buraya yazılacak.
                    if (acctrx.SubActionProcedure != null)
                    {
                        InvoiceLog.AddInfo("Hizmetin rapor numarası bilgisi değiştirildi ED: " + acctrx.SubActionProcedure.MedulaReportNo + " YD: " + reportNo, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateMedulaReportNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                        acctrx.SubActionProcedure.MedulaReportNo = reportNo;
                    }
                    else if (acctrx.SubActionMaterial != null)
                    {
                        InvoiceLog.AddInfo("İlacın rapor numarası bilgisi değiştirildi ED: " + acctrx.SubActionMaterial.MedulaReportNo + " YD: " + reportNo, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateMedulaReportNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                        acctrx.SubActionMaterial.MedulaReportNo = reportNo;
                    }
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateMedulaAccessionNo(List<string> accountTransactionIDs, string accessionNo)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin Accession No bilgisi değiştirildi " + (!string.IsNullOrEmpty(acctrx.MedulaAccessionNo) ? "ED: " + acctrx.MedulaAccessionNo : " ") + " YD: " + accessionNo, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxAccessionNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.MedulaAccessionNo = accessionNo;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateMedulaBayiNo(List<string> accountTransactionIDs, string bayiNo)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin Bayi No bilgisi değiştirildi " + (!string.IsNullOrEmpty(acctrx.MedulaDealerNo) ? "ED: " + acctrx.MedulaDealerNo : " ") + " YD: " + bayiNo, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxDealerNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.MedulaDealerNo = bayiNo;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateMedulaYatakNo(List<string> accountTransactionIDs, string yatak)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    //TODO: Adet değiştirme ile kontroller çalıştırılması gereken kodlar buraya yazılacak.
                    InvoiceLog.AddInfo("Hizmetin yatak numarası bilgisi değiştirildi ED: " + acctrx.SubActionProcedure.MedulaReportNo + " YD: " + yatak, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateMedulaReportNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.MedulaBedNo = yatak;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateTransactionAmount(List<string> accountTransactionIDs, string amount)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    //TODO: Adet değiştirme ile kontroller çalıştırılması gereken kodlar buraya yazılacak.
                    InvoiceLog.AddInfo("Hizmetin adet bilgisi değiştirildi ED: " + acctrx.Amount + " YD: " + amount, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxAmount, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.Amount = Convert.ToDouble(amount);
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateTransactionDoctor(List<string> accountTransactionIDs, Guid doctorObjectID)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                ResUser resUserDoctor = null;
                if (!Guid.Empty.ToString().Equals(doctorObjectID))
                    resUserDoctor = objectcontext.GetObject(doctorObjectID, typeof (ResUser)) as ResUser;
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Hizmetin doktor bilgisi değiştirildi " + (acctrx.Doctor != null ? "ED: " + acctrx.Doctor.Name : " ") + " YD: " + resUserDoctor.Name, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxDoctor, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.Doctor = resUserDoctor;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateSatinAlmaTarihi(List<string> accountTransactionIDs, DateTime newDate)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Malzeme satin alma tarihi bilgisi değiştirildi " + (acctrx.PurchaseDate != null ? "ED: " + acctrx.PurchaseDate.Value.ToString("dd/MM/yyyy") : " ") + " YD: " + newDate.ToString("dd/MM/yyyy"), acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxSatinAlmaTarihi, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.PurchaseDate = newDate;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateBarkod(List<string> ssList, string barkod)
        {
            if (ssList.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < ssList.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(ssList[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Malzemenin barkod bilgisi değiştirildi. " + (!string.IsNullOrEmpty(acctrx.Barcode) ? "ED: " + acctrx.Barcode : " ") + " YD: " + barkod, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxBorcode, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.Barcode = barkod;
                }

                objectcontext.Save();
            }
        }

        internal static void UpdateFirmaTanimlayiciNumarasi(List<string> ssList, string fTNo)
        {
            if (ssList.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < ssList.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(ssList[i]), typeof (AccountTransaction));
                    InvoiceLog.AddInfo("Malzemenin firma tanımlayıcı numarası bilgisi değiştirildi " + ((!string.IsNullOrEmpty(acctrx.ProducerCode) ? "ED: " + acctrx.ProducerCode : " ")) + " YD: " + fTNo, acctrx.ObjectID, InvoiceOperationTypeEnum.UpdateTrxFirmaNo, InvoiceLogObjectTypeEnum.AccountTransaction, objectcontext);
                    acctrx.ProducerCode = fTNo;
                }

                objectcontext.Save();
            }
        }
    }
}