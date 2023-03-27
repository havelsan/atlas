
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


namespace TTObjectClasses
{
    public  partial class MedulaHelper : TTObject
    {
#region Methods
        #region XXXXXX İçsel (Internal) işler
        public static void HizmetiGonderilecekYap(string accountTransactionID)
        {
            // GetDVO Deneme
            TTObjectContext objectcontext = new TTObjectContext(false);
            AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionID), typeof(AccountTransaction));
            acctrx.CurrentStateDefID = AccountTransaction.States.New;
            SaveAndDisposeContext(objectcontext);
        }

        public static void HizmetiGonderilecekYapV2(List<string> accountTransactionIDs)
        {
            // GetDVO Deneme
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    acctrx.CurrentStateDefID = AccountTransaction.States.New;
                }
                SaveAndDisposeContext(objectcontext);
            }
        }

        public static void HizmetiGonderilemeyecekYap(List<string> accountTransactionIDs)
        {
            // GetDVO Deneme
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof(AccountTransaction));
                    acctrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                }
                SaveAndDisposeContext(objectcontext);
            }
        }

        public static void TaniGonderilecekYap(List<string> SEPDiagnosisIDs)
        {
            if (SEPDiagnosisIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < SEPDiagnosisIDs.Count; i++)
                {
                    SEPDiagnosis sd = (SEPDiagnosis)objectcontext.GetObject(new Guid(SEPDiagnosisIDs[i]), typeof(SEPDiagnosis));
                    sd.CurrentStateDefID = SEPDiagnosis.States.New;
                }
                SaveAndDisposeContext(objectcontext);
            }
        }

        public static void TaniGonderilmeyecekYap(List<string> SEPDiagnosisIDs)
        {
            if (SEPDiagnosisIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                for (int i = 0; i < SEPDiagnosisIDs.Count; i++)
                {
                    SEPDiagnosis sd = (SEPDiagnosis)objectcontext.GetObject(new Guid(SEPDiagnosisIDs[i]), typeof(SEPDiagnosis));
                    sd.CurrentStateDefID = SEPDiagnosis.States.MedulaDontSend;
                }
                SaveAndDisposeContext(objectcontext);
            }
        }

        #endregion

        #region Hizmet İşlemleri

        public static void LoadHizmetBilgileri(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO hizmetKayitGirisDVO, AccountTransaction actx, ref int hizmetSayisi)
        {

            int lastIndex = 0;
            object obj = actx.SubActionProcedure.GetDVO(actx);
            if (obj is TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO)
            {
                hizmetKayitGirisDVO.muayeneBilgisi = (TTObjectClasses.HizmetKayitIslemleri.muayeneBilgisiDVO)obj;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.ameliyatveGirisimBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.ameliyatveGirisimBilgileri.Length;

                HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO[] ameliyatveGirisimBilgileri = hizmetKayitGirisDVO.ameliyatveGirisimBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO>(ref ameliyatveGirisimBilgileri, lastIndex + 1);
                ameliyatveGirisimBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.ameliyatveGirisimBilgisiDVO)obj;
                hizmetKayitGirisDVO.ameliyatveGirisimBilgileri = ameliyatveGirisimBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.digerIslemBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.digerIslemBilgileri.Length;
                HizmetKayitIslemleri.digerIslemBilgisiDVO[] digerIslemBilgileri = hizmetKayitGirisDVO.digerIslemBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO>(ref digerIslemBilgileri, lastIndex + 1);
                digerIslemBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.digerIslemBilgisiDVO)obj;
                hizmetKayitGirisDVO.digerIslemBilgileri = digerIslemBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.disBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.disBilgileri.Length;
                HizmetKayitIslemleri.disBilgisiDVO[] disBilgileri = hizmetKayitGirisDVO.disBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO>(ref disBilgileri, lastIndex + 1);
                disBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.disBilgisiDVO)obj;
                hizmetKayitGirisDVO.disBilgileri = disBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.hastaYatisBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.hastaYatisBilgileri.Length;
                HizmetKayitIslemleri.hastaYatisBilgisiDVO[] hastaYatisBilgileri = hizmetKayitGirisDVO.hastaYatisBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO>(ref hastaYatisBilgileri, lastIndex + 1);
                hastaYatisBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.hastaYatisBilgisiDVO)obj;
                hizmetKayitGirisDVO.hastaYatisBilgileri = hastaYatisBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.ilacBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.ilacBilgileri.Length;
                HizmetKayitIslemleri.ilacBilgisiDVO[] ilacBilgileri = hizmetKayitGirisDVO.ilacBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO>(ref ilacBilgileri, lastIndex + 1);
                ilacBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.ilacBilgisiDVO)obj;
                hizmetKayitGirisDVO.ilacBilgileri = ilacBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.kanBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.kanBilgileri.Length;
                HizmetKayitIslemleri.kanBilgisiDVO[] kanBilgileri = hizmetKayitGirisDVO.kanBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO>(ref kanBilgileri, lastIndex + 1);
                kanBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.kanBilgisiDVO)obj;
                hizmetKayitGirisDVO.kanBilgileri = kanBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.konsultasyonBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.konsultasyonBilgileri.Length;
                HizmetKayitIslemleri.konsultasyonBilgisiDVO[] konsultasyonBilgileri = hizmetKayitGirisDVO.konsultasyonBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO>(ref konsultasyonBilgileri, lastIndex + 1);
                konsultasyonBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.konsultasyonBilgisiDVO)obj;
                hizmetKayitGirisDVO.konsultasyonBilgileri = konsultasyonBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.malzemeBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.malzemeBilgileri.Length;
                HizmetKayitIslemleri.malzemeBilgisiDVO[] malzemeBilgileri = hizmetKayitGirisDVO.malzemeBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO>(ref malzemeBilgileri, lastIndex + 1);
                malzemeBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.malzemeBilgisiDVO)obj;
                hizmetKayitGirisDVO.malzemeBilgileri = malzemeBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.tahlilBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.tahlilBilgileri.Length;
                HizmetKayitIslemleri.tahlilBilgisiDVO[] tahlilBilgileri = hizmetKayitGirisDVO.tahlilBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO>(ref tahlilBilgileri, lastIndex + 1);
                tahlilBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.tahlilBilgisiDVO)obj;
                hizmetKayitGirisDVO.tahlilBilgileri = tahlilBilgileri;
                hizmetSayisi++;
            }
            else if (obj is TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)
            {
                if (hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri != null)
                    lastIndex = hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri.Length;
                HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO[] tetkikveRadyolojiBilgileri = hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri;
                System.Array.Resize<TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO>(ref tetkikveRadyolojiBilgileri, lastIndex + 1);
                tetkikveRadyolojiBilgileri[lastIndex] = (TTObjectClasses.HizmetKayitIslemleri.tetkikveRadyolojiBilgisiDVO)obj;
                hizmetKayitGirisDVO.tetkikveRadyolojiBilgileri = tetkikveRadyolojiBilgileri;
                hizmetSayisi++;
            }
        }
        
        public static void SetMedulaProvisionStatusAfterProcedureEntryByProvisionNo(string takipNO, TTObjectContext _context)
        {
            IList<SubEpisodeProtocol> sepList = (IList<SubEpisodeProtocol>)_context.QueryObjects("SUBEPISODEPROTOCOL", " MEDULATAKIPNO = '" + takipNO + "'");
            if (sepList != null && sepList.Count > 0)
                sepList[0].SetInvoiceStatusAfterProcedureEntry();
        }
        
        public static void SetMedulaProvisionStatusAfterProcedureEntryByObjectID(string ObjectID, TTObjectContext _context)
        {
            IList<SubEpisodeProtocol> sepList = (IList<SubEpisodeProtocol>)_context.QueryObjects("SUBEPISODEPROTOCOL", " OBJECTID = '" + ObjectID + "'");
            if (sepList != null && sepList.Count > 0)
                sepList[0].SetInvoiceStatusAfterProcedureEntry();
            _context.Save();
        }

        #endregion

        #region Genel Medula

        private static List<string> GetMedulaServiceProviderRefNo(object objMedula)
        {
            List<string> result = new List<string>();
            if (objMedula != null)
            {
                foreach (System.Reflection.PropertyInfo item in objMedula.GetType().GetProperties())
                {
                    if (item.PropertyType.IsArray)
                    {
                        object[] array = (object[])item.GetValue(objMedula, null);
                        if (array != null)
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                List<string> rr = MedulaHelper.GetMedulaServiceProviderRefNo(array[i]);
                                if (rr.Count > 0)
                                    result.Add(rr[0]);
                            }
                        }
                    }
                    else
                    {
                        // Saçmalık Ama başka yapacak birşey bulamadım
                        if (item.PropertyType.Name.EndsWith("DVO"))
                        {
                            object itemValue = (object)item.GetValue(objMedula, null);
                            List<string> rr = GetMedulaServiceProviderRefNo(itemValue);
                            if (rr.Count > 0)
                                result.Add(rr[0]);
                        }
                        else
                            if (item.Name == "hizmetSunucuRefNo")
                        {
                            result.Add((string)item.GetValue(objMedula, null));
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        public static void setBasariliIslem(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO result, TTObjectContext _context)
        {
            if (result.islemBilgileri != null)
            {
                for (int i = 0; i < result.islemBilgileri.Length; i++)
                {
                    TTObjectClasses.HizmetKayitIslemleri.kayitliIslemBilgisiDVO kayitliIslemBilgisiDVO = result.islemBilgileri[i];
                    if (kayitliIslemBilgisiDVO != null && kayitliIslemBilgisiDVO.hizmetSunucuRefNo != null && kayitliIslemBilgisiDVO.hizmetSunucuRefNo != "")
                    {
                        if (kayitliIslemBilgisiDVO.hizmetSunucuRefNo.StartsWith("H"))
                        {
                            AccountTransaction act = GetAccountTransactionById(kayitliIslemBilgisiDVO.hizmetSunucuRefNo.Substring(1), _context);
                            if (act != null)
                            {
                                act.CurrentStateDefID = AccountTransaction.States.MedulaEntrySuccessful;
                                act.MedulaProcessNo = kayitliIslemBilgisiDVO.islemSiraNo;
                                act.MedulaResultCode = null;
                                act.MedulaResultMessage = null;
                            }
                        }
                        else
                        {
                            SEPDiagnosis sd = GetSEPDiagnosisById(kayitliIslemBilgisiDVO.hizmetSunucuRefNo.Substring(1), _context);
                            if (sd != null)
                            {
                                sd.CurrentStateDefID = SEPDiagnosis.States.MedulaEntrySuccessful;
                                sd.MedulaProcessNo = kayitliIslemBilgisiDVO.islemSiraNo;
                                sd.MedulaResultCode = null;
                                sd.MedulaResultMessage = null;
                            }
                        }
                    }
                }
            }
        }

        public static void setHataliIslem(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitCevapDVO result, TTObjectContext _context)
        {
            // Normal şartlarda bir tane hatalı kayıt gelmelı
            for (int i = 0; i < result.hataliKayitlar.Length; i++)
            {
                TTObjectClasses.HizmetKayitIslemleri.hataliIslemBilgisiDVO hataliIslem = result.hataliKayitlar[i];
                if (hataliIslem != null)
                {
                    if (hataliIslem.hizmetSunucuRefNo != null && hataliIslem.hizmetSunucuRefNo != "")
                    {
                        if (hataliIslem.hizmetSunucuRefNo.StartsWith("H"))
                        {
                            AccountTransaction act = GetAccountTransactionById(hataliIslem.hizmetSunucuRefNo.Substring(1), _context);
                            act = setErrorDetailToAccountTransaction(act, hataliIslem.hataKodu, hataliIslem.hataMesaji);
                        }
                        else
                        {
                            SEPDiagnosis sd = GetSEPDiagnosisById(hataliIslem.hizmetSunucuRefNo.Substring(1), _context);
                            sd = setErrorDetailToSEPDiagnosis(sd, hataliIslem.hataKodu, hataliIslem.hataMesaji);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(hataliIslem.hataKodu))
                            result.sonucKodu += "," + hataliIslem.hataKodu;
                        if (!string.IsNullOrEmpty(hataliIslem.hataMesaji))
                            result.sonucMesaji += "," + hataliIslem.hataMesaji;
                    }
                }
            }
        }
        //public static void setHataliIslemFromHizmetKayitGirisDVO(TTObjectClasses.HizmetKayitIslemleri.hizmetKayitGirisDVO girisDVO, TTObjectContext _context,string hataKodu,string hataMesaji)
        //{
        //    //if (girisDVO.ameliyatveGirisimBilgileri != null)
                
        //}

        private static AccountTransaction setErrorDetailToAccountTransaction (AccountTransaction act, string hataKodu, string hataMesaji)
        {
            if (act != null)
            {
                act.MedulaResultCode = hataKodu;
                act.MedulaResultMessage = hataMesaji;
                act.CurrentStateDefID = AccountTransaction.States.MedulaEntryUnsuccessful;
            }
            return act;
        }
        private static SEPDiagnosis setErrorDetailToSEPDiagnosis(SEPDiagnosis sd,string hataKodu,string hataMesaji)
        {
            if (sd != null)
            {
                sd.MedulaResultCode = hataKodu;
                sd.MedulaResultMessage = hataMesaji;
                sd.CurrentStateDefID = SEPDiagnosis.States.MedulaEntryUnsuccessful;
            }
            return sd;
        }
        public static MedulaProvision GetMedulaProvisionByObjectID(string objectID, TTObjectContext _context)
        {
            MedulaProvision result = null;
            IList mpList = null;
            
            mpList = _context.LocalQuery ("MEDULAPROVISION", " OBJECTID = '" + objectID + "'");
            if (mpList.Count > 0)
                result = (MedulaProvision)mpList[0];
            else
            {
                mpList = _context.QueryObjects("MEDULAPROVISION", " OBJECTID = '" + objectID + "'");
                if (mpList.Count > 0)
                    result = (MedulaProvision)mpList[0];
            }
            return result;
        }

        public static SubEpisodeProtocol GetSubEpisodeProtocolByObjectID(string objectID, TTObjectContext _context)
        {
            SubEpisodeProtocol result = null;
            IList mpList = null;

            mpList = _context.LocalQuery("SUBEPISODEPROTOCOL", " OBJECTID = '" + objectID + "'");
            if (mpList.Count > 0)
                result = (SubEpisodeProtocol)mpList[0];
            else
            {
                mpList = _context.QueryObjects("SUBEPISODEPROTOCOL", " OBJECTID = '" + objectID + "'");
                if (mpList.Count > 0)
                    result = (SubEpisodeProtocol)mpList[0];
            }
            return result;
        }

        public static SubEpisodeProtocol GetSubEpisodeProtocolByProvisionNo(string provisionNo, TTObjectContext _context)
        {
            SubEpisodeProtocol result = null;
            IList<SubEpisodeProtocol> sepList = (IList<SubEpisodeProtocol>)_context.QueryObjects("SUBEPISODEPROTOCOL", " MEDULATAKIPNO = '" + provisionNo + "'");
            if (sepList.Count > 0)
                result = sepList[0];
            return result;
        }

        public static MedulaInvoice GetMedulaInvoiceByInvoiceDeliveryNo(string invoiceDeliveryNo, TTObjectContext _context)
        {
            MedulaInvoice result = null;
            IList<MedulaInvoice> miList = (IList<MedulaInvoice>)_context.QueryObjects("MEDULAINVOICE", " INVOICEDELIVERYNO = '" + invoiceDeliveryNo + "'");
            if (miList.Count > 0)
                result = miList[0];
            return result;
        }

        public static MedulaProvision GetMedulaProvisionByProvisionNo(string provisionNo, TTObjectContext _context)
        {
            MedulaProvision result = null;
            IList<MedulaProvision> mpList = (IList<MedulaProvision>)_context.QueryObjects("MEDULAPROVISION", " PROVISIONNO = '" + provisionNo + "'");
            if (mpList.Count > 0)
                result = mpList[0];
            return result;
        }

        public static AccountTransaction GetAccountTransactionByObjectID(string objectID, TTObjectContext _context)
        {
            AccountTransaction result = null;
            IList<AccountTransaction> actList = (IList<AccountTransaction>)_context.QueryObjects("ACCOUNTTRANSACTION", " OBJECTID = '" + objectID + "'");
            if (actList.Count > 0)
                result = actList[0];
            return result;
        }

        public static AccountTransaction GetAccountTransactionById(string id, TTObjectContext _context)
        {
            AccountTransaction result = null;
            IList<AccountTransaction> actList = (IList<AccountTransaction>)_context.QueryObjects("ACCOUNTTRANSACTION", " ID = '" + id + "'");
            if (actList.Count > 0)
                result = actList[0];
            return result;
        }

        public static SEPDiagnosis GetSEPDiagnosisById(string Id, TTObjectContext _context)
        {
            SEPDiagnosis result = null;
            IList<SEPDiagnosis> diagnosisList = (IList<SEPDiagnosis>)_context.QueryObjects("SEPDIAGNOSIS", " ID = '" + Id + "'");
            if (diagnosisList.Count > 0)
                result = diagnosisList[0];
            return result;
        }

        public static AccountTransaction GetAccountTransactionByMedulaProcessNo(string medulaProcessNo, TTObjectContext _context)
        {
            AccountTransaction result = null;
            IList actList = null;
            
            actList = _context.LocalQuery("ACCOUNTTRANSACTION", " MEDULAPROCESSNO = '" + medulaProcessNo + "'");
            if (actList.Count > 0)
                result = (AccountTransaction)actList[0];
            else
            {
                actList = _context.QueryObjects("ACCOUNTTRANSACTION", " MEDULAPROCESSNO = '" + medulaProcessNo + "'");
                if (actList.Count > 0)
                    result = (AccountTransaction)actList[0];
            }
            return result;
        }

        public static SEPDiagnosis GetSEPDiagnosisByMedulaProcessNo(string medulaProcessNo, TTObjectContext _context)
        {
            SEPDiagnosis result = null;
            IList<SEPDiagnosis> diagnosisList = (IList<SEPDiagnosis>)_context.QueryObjects("SEPDIAGNOSIS", " MEDULAPROCESSNO = '" + medulaProcessNo + "'");
            if (diagnosisList.Count > 0)
                result = diagnosisList[0];
            return result;
        }

        public static MedulaInvoiceTermDefinition MedulaDonemBul(DateTime invoiceDate, TTObjectContext _context)
        {
            MedulaInvoiceTermDefinition mit = null;
            BindingList<MedulaInvoiceTermDefinition> mitList = MedulaInvoiceTermDefinition.GetTermByDate(_context, invoiceDate);
            if (mitList.Count == 1)
            {
                mit = mitList[0];
            }
            else if (mitList.Count == 0)
            {
                throw new Exception(string.Format("Medula Dönemi bulunamamıştır. Fatura Tarihi : {0}", invoiceDate.ToString("dd.MM.yyyy")));
            }
            else if (mitList.Count > 1)
            {
                throw new Exception(string.Format("Birden fazla Medula Dönemi bulunmuştur. Fatura Tarihi : {0} ", invoiceDate.ToString("dd.MM.yyyy")));
            }
            return mit;
        }

        // Aynı metot FaturaKayıtHelper.cs dosyasında var
        /*
        public static  MedulaInvoice FindFirstMedulaInvoice(List<string> medulaProvisionObjectIDs, TTObjectContext tempContext)
        {
            for (int i = 0; i < medulaProvisionObjectIDs.Count; i++)
            {
                MedulaProvision tempMedulaProvision = (MedulaProvision)tempContext.GetObject(new Guid(medulaProvisionObjectIDs[i]), typeof(MedulaProvision));

                if (tempMedulaProvision != null && tempMedulaProvision.MedulaInvoice != null)
                    return tempMedulaProvision.MedulaInvoice;

            }
            return null;
        }
        */

        public static string GetDVOItemValue(object objMedula, string itemName)
        {
            string result = string.Empty;
            if (objMedula != null)
            {
                foreach (System.Reflection.PropertyInfo item in objMedula.GetType().GetProperties())
                {
                    if (item.Name == itemName)
                        return (string)item.GetValue(objMedula, null);
                }
            }
            return result;
        }

        #endregion

        #region Small Staff

        public static void DisposeContext(TTObjectContext context)
        {
            if (context != null)
                context.Dispose();
        }
        public static void SaveAndDisposeContext(TTObjectContext context)
        {

            if (context != null)
            {
                context.Save();
                context.Dispose();
            }
        }

        #endregion


        #region MedulaLog


 



        #endregion
        
#endregion Methods

    }
}