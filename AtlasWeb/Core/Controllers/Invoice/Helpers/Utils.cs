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

namespace Core.Controllers.Invoice.Helpers
{
    public class Utils
    {
        /// <summary>
        /// TTObjectContext nesnesinin kaydedilmesi ve dispose edilmesi işleminin bir metot ile yapılması için kullanılır ayrıca , context nesnesinin null olma olasılığı dikkate alınır
        /// </summary>
        /// <param name = "context"></param>
        public static void SaveAndDisposeContext(TTObjectContext context)
        {
            if (context != null)
            {
                context.Save();
                context.Dispose();
            }
        }

        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult GetMedulaResult(string sonucKodu, string sonucAciklama)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            result.SonucKodu = sonucKodu;
            result.SonucMesaji = sonucAciklama;
            return result;
        }

        /// <summary>
        /// Herhangi bir nesnedeki(daha çok medula DVO nesneleri) sonucKodu ve sonucMesaji özelliklerinin değerlerini kullanarak MedulaResult tipinde bir değer üretmek için kullanılır, Değerleri elde etme işlemi sırasında reflection kullanılır
        /// </summary>
        /// <param name = "objMedula"></param>
        /// <returns></returns>
        public static TTObjectClasses.SubEpisodeProtocol.MedulaResult GetMedulaResult(object objMedula)
        {
            TTObjectClasses.SubEpisodeProtocol.MedulaResult result = new TTObjectClasses.SubEpisodeProtocol.MedulaResult();
            if (objMedula != null)
            {
                PropertyInfo item = objMedula.GetType().GetProperty("sonucKodu");
                object val = (object)item.GetValue(objMedula, null);
                if (val != null)
                    result.SonucKodu = val.ToString();
                item = objMedula.GetType().GetProperty("sonucMesaji");
                val = (object)item.GetValue(objMedula, null);
                if (val != null)
                    result.SonucMesaji = val.ToString();
                if (result.SonucKodu.Equals("0000"))
                    result.Succes = true;
                else
                    result.Succes = false;
            }

            return result;
        }

        //TODO(Şadi) Metot gerçek ortama geçildiğinde silinecek.
        /// <summary>
        /// Şuan için Medula (DVO) nesnelerindeki zorunlu alanları otomatik olarak doldurmak için kullanılır , gerçek ortama geçildiğinde metot kullanım dışı olacaktır
        /// </summary>
        /// <param name = "objMedula"></param>
        public static void DVODegerEzici(object objMedula, AccountTransaction AccTrx)
        {
            if (objMedula != null)
            {
                foreach (PropertyInfo item in objMedula.GetType().GetProperties())
                {
                    if (item.PropertyType.IsArray)
                    {
                        object[] array = (object[])item.GetValue(objMedula, null);
                        if (array != null)
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                DVODegerEzici(array[i], AccTrx);
                            }
                        }
                    }
                    else
                    {
                        // Saçmalık ama başka yapacak birşey bulamadım
                        if (item.PropertyType.Name.EndsWith("DVO"))
                        {
                            object itemValue = (object)item.GetValue(objMedula, null);
                            DVODegerEzici(itemValue, AccTrx);
                        }
                        else
                        {
                            if (item.Name == "ozelDurum")
                            {
                                if (AccTrx.OzelDurum != null && !string.IsNullOrEmpty(AccTrx.OzelDurum.ozelDurumKodu))
                                    item.SetValue(objMedula, AccTrx.OzelDurum.ozelDurumKodu, null); // AccTrx in Özel Durum Kodu set ediliyor
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// XXXXXX tarafından alınan DVO nesnesinin 
        /// </summary>
        /// <param name = "objMedula">Medulaya gönderilecek olan nesne</param>
        /// <param name = "objXXXXXX">XXXXXX tarafından gelen nesne</param>
        public static void SetMedulaObjectValues(object objMedula, object objXXXXXX)
        {
            foreach (PropertyInfo item in objMedula.GetType().GetProperties())
            {
                if (objXXXXXX.GetType().GetProperty(item.Name) != null)
                {
                    objMedula.GetType().GetProperty(item.Name).SetValue(objMedula, objXXXXXX.GetType().GetProperty(item.Name).GetValue(objXXXXXX, null), null);
                }
            }
        }

        public static class XmlSerializerUtils
        {
            public static string Serialize<T>(T item)
            {
                MemoryStream memStream = new MemoryStream();
                using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                {
                    textWriter.Formatting = Formatting.Indented;
                    XmlSerializer serializer = new XmlSerializer(typeof (T));
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
                        XmlSerializer serializer = new XmlSerializer(typeof (T));
                        return (T)serializer.Deserialize(memStream);
                    }
                }
            }
        }

        public static int GetMedulaTransactionCountBySEPAndState(TTObjectContext objectcontext, string SEPObjectID, List<Guid> stateList)
        {
            int result = 0;
            //TODO:SEP  Sorguya parametre olarak SEP ID geçmek lazım, şu ende SE ID geçiliyor
            BindingList<AccountTransaction.GetMedulaTransactionCountBySEPAndState_Class> list = AccountTransaction.GetMedulaTransactionCountBySEPAndState(objectcontext, new Guid(SEPObjectID), stateList);
            if (list.Count > 0)
                result = Convert.ToInt32(list[0].Acctrxcount);
            return result;
        }

        public static int GetMedulaDiagnosisCountBySEPAndState(TTObjectContext objectcontext, string SEPObjectID, List<Guid> stateList)
        {
            IList<SEPDiagnosis.GetBySubEpisodeProtocolAndState_Class> diagList = SEPDiagnosis.GetBySubEpisodeProtocolAndState(objectcontext, new Guid(SEPObjectID), stateList);
            return diagList.Count;
        }

        public static string GetAccountTransactionType(TTObjectClasses.AccountTransaction act)
        {
            string result = string.Empty;
            if (act != null)
            {
                if (act.SubActionProcedure != null)
                    result = "HİZMET";
                else
                {
                    if (act.SubActionMaterial != null && act.SubActionMaterial.Material != null)
                    {
                        if (act.SubActionMaterial.Material is TTObjectClasses.DrugDefinition || act.SubActionMaterial.Material is TTObjectClasses.MagistralPreparationDefinition)
                            result = "İLAÇ";
                        else
                            result = "MALZEME";
                    }
                //else
                //    Medula.MedulaLog.AddErr(string.Format("NebulaXXXXXXHelper.NebulaXXXXXXHelper Metodu SubActionProcedure ve SubActionMaterial Acctrx :{0} ", act.ObjectID.ToString()), null, TTObjectClasses.MedulaOperationTypeEnum.Genel);
                }
            }

            return result;
        }

        public static void UpdateTransactionState(List<string> accountTransactionIDs, bool state)
        {
            if (accountTransactionIDs.Count > 0)
            {
                TTObjectContext objectcontext = new TTObjectContext(false);
                SubEpisodeProtocol sep = null;
                for (int i = 0; i < accountTransactionIDs.Count; i++)
                {
                    AccountTransaction acctrx = (AccountTransaction)objectcontext.GetObject(new Guid(accountTransactionIDs[i]), typeof (AccountTransaction));
                    if (state)
                        acctrx.CurrentStateDefID = AccountTransaction.States.New;
                    else
                        acctrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    if (i == 0)
                        sep = acctrx.SubEpisodeProtocol;
                }

                objectcontext.Save();
                if (sep != null)
                    sep.SetInvoiceStatusAfterProcedureEntry();
                Utils.SaveAndDisposeContext(objectcontext);
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
                    if (i == 0)
                        sep = sepD.SubEpisodeProtocol;
                }

                objectcontext.Save();
                if (sep != null)
                    sep.SetInvoiceStatusAfterProcedureEntry();
                Utils.SaveAndDisposeContext(objectcontext);
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
                }

                Utils.SaveAndDisposeContext(objectcontext);
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
                    acctrx.TransactionDate = newDate;
                }

                Utils.SaveAndDisposeContext(objectcontext);
            }
        }
    }
}