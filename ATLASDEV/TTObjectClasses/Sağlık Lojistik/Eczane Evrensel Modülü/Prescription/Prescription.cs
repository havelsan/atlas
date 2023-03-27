
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
    /// <summary>
    /// Reçete Ana Sınıfı
    /// </summary>
    public abstract partial class Prescription : EpisodeAction
    {
        public partial class OLAP_GetPrescription_Class : TTReportNqlObject
        {
        }

        public partial class GetFamilyForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetCivilianForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetOfficerForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPrescriptionSearchWithProtocolNOReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetNCOfficerForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPrescriptionStatisticWithGroupReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetOfficialForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetExpertNonComForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPrivateForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetCadetForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetRetiredForPrescriptionStatisticReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledPrescription_Class : TTReportNqlObject
        {
        }

        public partial class VEM_RECETE_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert





            base.PreInsert();
            ProcedureDoctor = ((ResUser)Common.CurrentUser.UserObject);

            Dictionary<Guid, FavoriteDrug> favoriteDrugs = new Dictionary<Guid, FavoriteDrug>();
            BindingList<FavoriteDrug.GetFavoriteDrugsWithObjectID_Class> drugs = FavoriteDrug.GetFavoriteDrugsWithObjectID(((ResUser)Common.CurrentUser.UserObject).ObjectID);

            foreach (FavoriteDrug.GetFavoriteDrugsWithObjectID_Class favoriteDrug in drugs)
            {
                if (favoriteDrugs.ContainsKey((Guid)favoriteDrug.DrugDefinition) == false)
                {
                    FavoriteDrug fDrug = (FavoriteDrug)ObjectContext.GetObject((Guid)favoriteDrug.ObjectID, "FAVORITEDRUG");
                    favoriteDrugs.Add((Guid)favoriteDrug.DrugDefinition, fDrug);
                }
            }


            if (this is OutPatientPrescription)
            {
                foreach (OutPatientDrugOrder outPatientDrugOrder in ((OutPatientPrescription)this).OutPatientDrugOrders)
                {
                    if (favoriteDrugs.ContainsKey(outPatientDrugOrder.Material.ObjectID))
                    {
                        favoriteDrugs[outPatientDrugOrder.Material.ObjectID].Count = favoriteDrugs[outPatientDrugOrder.Material.ObjectID].Count + 1;
                    }
                    else
                    {
                        FavoriteDrug newFavoriteDrug = new FavoriteDrug(ObjectContext);
                        newFavoriteDrug.Count = 1;
                        newFavoriteDrug.DrugDefinition = ((DrugDefinition)outPatientDrugOrder.Material);
                        newFavoriteDrug.ResUser = ((ResUser)Common.CurrentUser.UserObject);
                    }
                }
            }
            else if (this is InpatientPrescription)
            {
                foreach (InpatientDrugOrder inpatientDrugOrder in ((InpatientPrescription)this).InpatientDrugOrders)
                {
                    if (favoriteDrugs.ContainsKey(inpatientDrugOrder.Material.ObjectID))
                    {
                        favoriteDrugs[inpatientDrugOrder.Material.ObjectID].Count = favoriteDrugs[inpatientDrugOrder.Material.ObjectID].Count + 1;
                    }
                    else
                    {
                        FavoriteDrug newFavoriteDrug = new FavoriteDrug(ObjectContext);
                        newFavoriteDrug.Count = 1;
                        newFavoriteDrug.DrugDefinition = ((DrugDefinition)inpatientDrugOrder.Material);
                        newFavoriteDrug.ResUser = ((ResUser)Common.CurrentUser.UserObject);
                    }
                }
            }



            #endregion PreInsert
        }

        #region Methods

        public  void SendENabizPresciptionForCancelled()
        {
            if (SubEpisode != null && SendToENabiz())
                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
        }

        public static string GetEReceteSignedInputRequest(Prescription pres)
        {
            TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO istekGiris = Prescription.GetEReceteInputRequest(pres);
            string imzalanacakXml = Common.SerializeObjectToXml(istekGiris.ereceteDVO);
            imzalanacakXml = imzalanacakXml.Replace("ereceteDVO", "ereceteBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("kisiDVO", "kisiBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaListesi", "ereceteAciklamaBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacListesi", "ereceteIlacBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteTaniListesi", "ereceteTaniBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaListesi", "ereceteIlacAciklamaBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static string GetEreceteSignedApprovalRequest(Prescription pres)
        {
            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = Prescription.GetEreceteApprovalRequest(pres);
            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalRequest);
            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static string GetEReceteSignedDeleteRequest(Prescription pres)
        {
            EReceteIslemleri.ereceteSilIstekDVO eReceteDelete = Prescription.GetEReceteDelete(pres);
            string imzalanacakXml = Common.SerializeObjectToXml(eReceteDelete);
            imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }

        public static string GetEReceteSignedDeleteRequestEreceteNo(string eReceteNo)
        {
            EReceteIslemleri.ereceteSilIstekDVO eReceteDelete = new EReceteIslemleri.ereceteSilIstekDVO();
            eReceteDelete.doktorTcKimlikNo = Common.CurrentUser.UniqueRefNo;
            eReceteDelete.ereceteNo = eReceteNo;
            eReceteDelete.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            string imzalanacakXml = Common.SerializeObjectToXml(eReceteDelete);
            imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }


        public static string GetEReceteSignedDiagnosisRequestEreceteNo(string eReceteNo, Guid diagnosisObjID)
        {
            TTObjectContext context = new TTObjectContext(false);
            DiagnosisDefinition diagnosis = (DiagnosisDefinition)context.GetObject(diagnosisObjID, typeof(DiagnosisDefinition));

            EReceteIslemleri.ereceteTaniDVO ereceteTaniDVO = new EReceteIslemleri.ereceteTaniDVO();
            ereceteTaniDVO.taniAdi = diagnosis.Name;
            if (diagnosis.Code.Length > 5)
                ereceteTaniDVO.taniKodu = diagnosis.Code.Substring(0, 5);
            else
                ereceteTaniDVO.taniKodu = diagnosis.Code;

            EReceteIslemleri.ereceteTaniEkleIstekDVO ereceteTaniEkleIstekDVO = new EReceteIslemleri.ereceteTaniEkleIstekDVO();
            ereceteTaniEkleIstekDVO.doktorTcKimlikNo = Common.CurrentUser.UniqueRefNo;
            ereceteTaniEkleIstekDVO.ereceteNo = eReceteNo;
            ereceteTaniEkleIstekDVO.ereceteTaniDVO = ereceteTaniDVO;
            ereceteTaniEkleIstekDVO.tesisKodu = SystemParameter.GetSaglikTesisKodu();

            string imzalanacakXml = Common.SerializeObjectToXml(ereceteTaniEkleIstekDVO);
            imzalanacakXml = imzalanacakXml.Replace("ereceteTaniEkleIstekDVO", "imzaliEreceteTaniBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteTaniDVO", "ereceteTaniBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }


        public static string GetEReceteSignedRecipeDescriptionRequestEreceteNo(string eReceteNo, int drugDescriptionType, string desciption)
        {
            EReceteIslemleri.ereceteAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteAciklamaDVO();
            ereceteAciklamaDVO.aciklama = desciption;
            ereceteAciklamaDVO.aciklamaTuru = drugDescriptionType;
            EReceteIslemleri.ereceteAciklamaEkleIstekDVO ereceteAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteAciklamaEkleIstekDVO();
            ereceteAciklamaEkleIstekDVO.doktorTcKimlikNo = Common.CurrentUser.UniqueRefNo;
            ereceteAciklamaEkleIstekDVO.ereceteNo = eReceteNo;
            ereceteAciklamaEkleIstekDVO.ereceteAciklamaDVO = ereceteAciklamaDVO;
            ereceteAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            string imzalanacakXml = Common.SerializeObjectToXml(ereceteAciklamaEkleIstekDVO);
            imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaEkleIstekDVO", "imzaliEreceteAciklamaBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaDVO", "ereceteAciklamaBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }


        public static string GetEReceteSignedDrugDescriptionRequestEreceteNo(string eReceteNo, int drugDescriptionType, string desciption, string barcode)
        {
            EReceteIslemleri.ereceteIlacAciklamaDVO ereceteAciklamaDVO = new EReceteIslemleri.ereceteIlacAciklamaDVO();
            ereceteAciklamaDVO.aciklama = desciption;
            ereceteAciklamaDVO.aciklamaTuru = drugDescriptionType;

            EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO ereceteIlacAciklamaEkleIstekDVO = new EReceteIslemleri.ereceteIlacAciklamaEkleIstekDVO();
            ereceteIlacAciklamaEkleIstekDVO.barkod = Convert.ToInt64(barcode);
            ereceteIlacAciklamaEkleIstekDVO.doktorTcKimlikNo = Common.CurrentUser.UniqueRefNo;
            ereceteIlacAciklamaEkleIstekDVO.ereceteNo = eReceteNo;
            ereceteIlacAciklamaEkleIstekDVO.ereceteIlacAciklamaDVO = ereceteAciklamaDVO;
            ereceteIlacAciklamaEkleIstekDVO.tesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            string imzalanacakXml = Common.SerializeObjectToXml(ereceteIlacAciklamaEkleIstekDVO);
            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaEkleIstekDVO", "imzaliEreceteIlacAciklamaBilgisi");
            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaDVO", "ereceteIlacAciklamaBilgisi");
            return Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(imzalanacakXml));
        }


        [Serializable]
        public class EreceteListelePrescriptionWebCaller : IWebMethodCallback
        {
            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (messageException == null && returnValue != null)
                {
                }
                return false;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }

        [Serializable]
        public class InpatientPrescriptionWebCaller : IWebMethodCallback
        {
            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (messageException == null && returnValue != null)
                {
                    //if (returnValue is EReceteIslemleri.ereceteGirisCevapDVO)
                    //{
                    //    if (((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucKodu == "0000")
                    //    {
                    //        TTObjectContext context = new TTObjectContext(false);
                    //        InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(this.ObjectID, typeof(InpatientPrescription));
                    //        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.EreceteCompleted;
                    //        inpatientPrescription.EReceteNo = ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).ereceteDVO.ereceteNo;
                    //        inpatientPrescription.EReceteDescription = "Sonuç Kodu :" + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucKodu + "\r\nSonuç Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucMesaji + "\r\nUyarı Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).uyariMesaji;
                    //        if (inpatientPrescription.IsRepeated.HasValue)
                    //        {
                    //            if ((bool)inpatientPrescription.IsRepeated)
                    //            {
                    //                ResUser user = (ResUser)context.GetObject(inpatientPrescription.ProcedureDoctor.ObjectID, typeof(ResUser));
                    //                user.ErecetePassword = inpatientPrescription.ERecetePassword;
                    //            }
                    //        }
                    //        context.Save();
                    //    }
                    //    else
                    //    {
                    //        TTObjectContext context = new TTObjectContext(false);
                    //        InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(this.ObjectID, typeof(InpatientPrescription));
                    //        inpatientPrescription.CurrentStateDefID = InpatientPrescription.States.EreceteCancelled;
                    //        inpatientPrescription.EReceteNo = string.Empty;
                    //        inpatientPrescription.EReceteDescription = "Sonuç Kodu :" + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucKodu + "\r\nSonuç Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucMesaji + "\r\nUyarı Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).uyariMesaji;
                    //        context.Save();
                    //    }
                    //}
                    if (returnValue is EReceteIslemleri.ereceteSilCevapDVO)
                    {
                        if (((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu == "0000")
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(ObjectID, typeof(InpatientPrescription));

                            inpatientPrescription.EReceteNo = string.Empty;
                            inpatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(ObjectID, typeof(InpatientPrescription));

                            inpatientPrescription.EReceteNo = string.Empty;
                            inpatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }
                    else if (returnValue is EReceteIslemleri.ereceteSorguCevapDVO)
                    {
                        if (((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu == "0000")
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(ObjectID, typeof(InpatientPrescription));

                            inpatientPrescription.EReceteNo = ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).ereceteDVO.ereceteNo;
                            inpatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(ObjectID, typeof(InpatientPrescription));

                            inpatientPrescription.EReceteNo = string.Empty;
                            inpatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }
                }
                else
                {
                    TTObjectContext context = new TTObjectContext(false);
                    InpatientPrescription inpatientPrescription = (InpatientPrescription)context.GetObject(ObjectID, typeof(InpatientPrescription));
                    inpatientPrescription.EReceteNo = ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).ereceteDVO.ereceteNo;
                    inpatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucKodu + "\r\nSonuç Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).sonucMesaji + "\r\nUyarı Mesajı : " + ((EReceteIslemleri.ereceteGirisCevapDVO)returnValue).uyariMesaji;
                }
                return true;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }

        public bool IsSignedPrescription()
        {
            return (IsSigned ?? false);
        }

        [Serializable]
        public class OutPatientPrescriptionWebCaller : IWebMethodCallback
        {
            private Guid _objectID;
            public Guid ObjectID
            {
                get { return _objectID; }
                set { _objectID = value; }
            }

            public bool WebMethodCallback(object returnValue, object[] calledParameters, Exception messageException)
            {

                if (messageException == null && returnValue != null)
                {
                    if (returnValue is EReceteIslemleri.ereceteGirisCevapDVO)
                    {
                        //                        if (((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).sonucKodu == "0000")
                        //                        {
                        //                            TTObjectContext context = new TTObjectContext(false);
                        //                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(this.ObjectID, typeof(OutPatientPrescription));
                        //                            //outPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Completed;
                        //                            outPatientPrescription.EReceteNo = ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).ereceteDVO.ereceteNo;
                        //                            outPatientPrescription.EReceteDescription = "Sonuç Kodu :" + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).uyariMesaji;
                        //                            context.Save();
                        //
                        //                        }
                        //                        else
                        //                        {
                        //                            TTObjectContext context = new TTObjectContext(false);
                        //                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(this.ObjectID, typeof(OutPatientPrescription));
                        //                            //outPatientPrescription.CurrentStateDefID = OutPatientPrescription.States.Cancelled;
                        //                            outPatientPrescription.EReceteNo = string.Empty;
                        //                            outPatientPrescription.EReceteDescription = "Sonuç Kodu :" + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.EreceteGirisCevapDVO)returnValue).uyariMesaji;
                        //                            context.Save();
                        //                        }
                    }
                    else if (returnValue is EReceteIslemleri.ereceteSilCevapDVO)
                    {
                        if (((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu == "0000")
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(ObjectID, typeof(OutPatientPrescription));
                            outPatientPrescription.EReceteNo = string.Empty;
                            outPatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(ObjectID, typeof(OutPatientPrescription));
                            outPatientPrescription.EReceteNo = string.Empty;
                            outPatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSilCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }
                    else if (returnValue is EReceteIslemleri.ereceteSorguCevapDVO)
                    {
                        if (((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu == "0000")
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(ObjectID, typeof(OutPatientPrescription));
                            outPatientPrescription.EReceteNo = ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).ereceteDVO.ereceteNo;
                            outPatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();

                        }
                        else
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            OutPatientPrescription outPatientPrescription = (OutPatientPrescription)context.GetObject(ObjectID, typeof(OutPatientPrescription));
                            outPatientPrescription.EReceteNo = string.Empty;
                            outPatientPrescription.EReceteDescription = TTUtils.CultureService.GetText("M26921", "Sonuç Kodu :") + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucKodu + "Sonuç Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).sonucMesaji + " Uyarı Mesajı : " + ((EReceteIslemleri.ereceteSorguCevapDVO)returnValue).uyariMesaji;
                            context.Save();
                        }
                    }
                }

                return false;
            }

            public TTObjectContext ObjectContext { get { return new TTObjectContext(false); } }
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.Prescription;
            }
        }

        override protected void OnConstruct()
        {
            //base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
            {
                base.OnConstruct();
                if (FillingDate == null)
                    FillingDate = DateTime.Now.Date;
            }
        }

        private bool IsGreenAreaExamination(Prescription pres)
        {
            bool IsGreenAreaExamination = false;
            foreach (EpisodeAction app in pres.Episode.EpisodeActions)
            {
                if (app is InPatientPhysicianApplication)
                {
                    InPatientPhysicianApplication pApp = (InPatientPhysicianApplication)app;
                    if (pApp.IsGreenAreaExamination == true)
                        IsGreenAreaExamination = true;
                    break;
                }
                if (app is PatientExamination)
                {
                    PatientExamination pe = (PatientExamination)app;
                    if (pe.IsGreenAreaExamination == true)
                        IsGreenAreaExamination = true;
                    break;
                }
            }
            return IsGreenAreaExamination;
        }


        public static EReceteIslemleri.ereceteSilIstekDVO GetEReceteDelete(Prescription pres)
        {
            EReceteIslemleri.ereceteSilIstekDVO eReceteDelete = new EReceteIslemleri.ereceteSilIstekDVO();
            eReceteDelete.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            eReceteDelete.ereceteNo = pres.EReceteNo;
            eReceteDelete.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return eReceteDelete;
        }


        public static TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO GetEReceteInputRequest(Prescription pres)
        {

            TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO eReceteInfo = new TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO();
            eReceteInfo.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo.Value;
            eReceteInfo.tesisKodu = SystemParameter.GetSaglikTesisKodu();

            TTObjectClasses.EReceteIslemleri.ereceteDVO eReceteDVO = new TTObjectClasses.EReceteIslemleri.ereceteDVO();
            eReceteDVO.doktorAdi = pres.ProcedureDoctor.Person.Name;
            eReceteDVO.doktorSoyadi = pres.ProcedureDoctor.Person.Surname;
            eReceteDVO.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;

            //if (pres is OutPatientPrescription)
            //    eReceteDVO.doktorBransKodu = Convert.ToInt32(((OutPatientPrescription)pres).SpecialityDefinition.Code);
            //else
            eReceteDVO.doktorBransKodu = pres.ProcedureDoctor.GetSpeciality() != null ? Convert.ToInt32(pres.ProcedureDoctor.GetSpeciality().Code) : 0;

            //Doktor Sertifika Kodu
            //Yok 0
            //Hemodiyaliz 56
            //Aile Hekimliği 109

            eReceteDVO.doktorSertifikaKodu = 0;
            eReceteDVO.ereceteNo = string.Empty;
            eReceteDVO.receteTarihi = DateTime.Now.ToString("dd.MM.yyyy");
            eReceteDVO.seriNo = string.Empty;
            eReceteDVO.takipNo = pres.SubEpisode.SGKSEP != null ? pres.SubEpisode.SGKSEP.MedulaTakipNo : "";

            if (pres.SubEpisode.SGKSEP != null)
            {
                if (pres.Episode.IsNewBorn.HasValue && pres.Episode.IsNewBorn == true)
                {
                    if (pres.Episode.Patient.Mother != null)
                        eReceteDVO.tcKimlikNo = (long)pres.Episode.Patient.Mother.UniqueRefNo;
                    else
                        eReceteDVO.tcKimlikNo = 00000000000;
                }
                else
                {
                    if (pres.Episode.Patient.YUPASSNO != null && pres.Episode.Patient.YUPASSNO > 0)
                        eReceteDVO.tcKimlikNo = (long)pres.Episode.Patient.YUPASSNO;
                    else
                        eReceteDVO.tcKimlikNo = pres.Episode.Patient.UniqueRefNo != null ? pres.Episode.Patient.UniqueRefNo.Value : 00000000000;
                }
            }
            else
                eReceteDVO.tcKimlikNo = pres.Episode.Patient.UniqueRefNo != null ? pres.Episode.Patient.UniqueRefNo.Value : 00000000000;

            eReceteDVO.tesisKodu = eReceteInfo.tesisKodu;
            if (pres.SubEpisode.SGKSEP != null)
            {
                if (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi != null)
                {
                    switch (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiAdi)
                    {
                        case "N":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.NormalProvision;
                            break;
                        case "I":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.IndustrialAccidentProvision;
                            break;
                        case "A":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.NormalProvision;
                            break;
                        case "T":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.TrafficProvision;
                            break;
                        case "V":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.CriminalCaseProvision;
                            break;
                        case "M":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.OccupationalDiseaseProvision;
                            break;
                        case "D":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.NaturalDisasterProvision;
                            break;
                        case "L":
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.MaternityStatusProvision;
                            break;
                        default:
                            eReceteDVO.provizyonTipi = (int)ProvisionTypeEnum.NormalProvision;
                            break;
                    }
                }
            }

            if (pres is OutPatientPrescription)
            {
                List<EReceteIslemleri.ereceteIlacDVO> receteIlacLst = new List<EReceteIslemleri.ereceteIlacDVO>();
                foreach (OutPatientDrugOrder drugOrder in ((OutPatientPrescription)pres).OutPatientDrugOrders)
                {

                    TTObjectClasses.EReceteIslemleri.ereceteIlacDVO receteIlac = new TTObjectClasses.EReceteIslemleri.ereceteIlacDVO();
                    receteIlac.barkod = Convert.ToInt64(drugOrder.Material.Barcode);
                    receteIlac.ilacAdi = drugOrder.Material.Name.ToString();
                    receteIlac.adet = (int)drugOrder.PackageAmount;
                    receteIlac.kullanimDoz1 = (int)DrugOrder.GetDetailCount(drugOrder.Frequency);
                    receteIlac.kullanimDoz2 = (double)drugOrder.DoseAmount;
                    if (((DrugDefinition)drugOrder.Material).ReimbursementUnder.HasValue)
                        receteIlac.geriOdemeKapsaminda = ((DrugDefinition)drugOrder.Material).ReimbursementUnder == true ? "E" : "H";
                    receteIlac.kullanimPeriyot = (int)drugOrder.Day;
                    receteIlac.kullanimPeriyotBirimi = (int)drugOrder.PeriodUnitType.Value;
                    receteIlac.kullanimSekli = (int)drugOrder.DrugUsageType;

                    List<TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO> receteIlacAciklamaLst = new List<TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO>();
                    if (!string.IsNullOrEmpty(drugOrder.Description))
                    {
                        TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO receteIlacAciklama = new TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO();
                        receteIlacAciklama.aciklama = drugOrder.Description;
                        receteIlacAciklama.aciklamaTuru = (int)drugOrder.DescriptionType;
                        receteIlacAciklamaLst.Add(receteIlacAciklama);
                    }
                    if (receteIlacAciklamaLst != null && receteIlacAciklamaLst.Count > 0)
                        receteIlac.ereceteIlacAciklamaListesi = receteIlacAciklamaLst.ToArray();

                    receteIlacLst.Add(receteIlac);

                }
                if (receteIlacLst != null && receteIlacLst.Count > 0)
                    eReceteDVO.ereceteIlacListesi = receteIlacLst.ToArray();

                eReceteDVO.protokolNo = pres.Episode.HospitalProtocolNo.ToString();

                if (((OutPatientPrescription)pres).IsDischargePrescripiton.HasValue)
                {
                    if (((OutPatientPrescription)pres).IsDischargePrescripiton == true)
                    {
                        eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.DischargedPrescriptionSubType;
                        pres.PrescriptionSubType = PrescriptionSubTypeEnum.DischargedPrescriptionSubType;
                    }
                    else
                    {
                        if (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiAdi == TTUtils.CultureService.GetText("M25093", "Acil"))
                        {
                            if (pres.IsGreenAreaExamination(pres))
                            {
                                eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.GreenChannelPrescriptionSubType;
                                pres.PrescriptionSubType = PrescriptionSubTypeEnum.GreenChannelPrescriptionSubType;
                            }
                            else
                            {
                                eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                                pres.PrescriptionSubType = PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                            }
                        }
                        else if (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "E")
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                        }
                        else
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.OutPatientPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.OutPatientPrescriptionSubType;
                        }
                    }
                }
                else
                {
                    if (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiAdi == TTUtils.CultureService.GetText("M25093", "Acil"))
                    {
                        if (pres.IsGreenAreaExamination(pres))
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.GreenChannelPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.GreenChannelPrescriptionSubType;
                        }
                        else
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                        }
                    }
                    else if (pres.SubEpisode.SGKSEP.MedulaProvizyonTipi.provizyonTipiKodu == "E")
                    {
                        eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                        pres.PrescriptionSubType = PrescriptionSubTypeEnum.EmergencyPrescriptionSubType;
                    }
                    else
                    {
                        if (pres.SubEpisode.SGKSEP.MedulaTedaviTuru.tedaviTuruKodu == "G")
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.DailyPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.DailyPrescriptionSubType;
                        }
                        else
                        {
                            eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.OutPatientPrescriptionSubType;
                            pres.PrescriptionSubType = PrescriptionSubTypeEnum.OutPatientPrescriptionSubType;
                        }
                    }

                }


                switch (pres.PrescriptionType)
                {
                    case (PrescriptionTypeEnum.NormalPrescription):
                        eReceteDVO.receteTuru = 1;
                        break;
                    case (PrescriptionTypeEnum.RedPrescription):
                        eReceteDVO.receteTuru = 2;
                        break;
                    case (PrescriptionTypeEnum.OrangePrescription):
                        eReceteDVO.receteTuru = 3;
                        break;
                    case (PrescriptionTypeEnum.PurplePrescription):
                        eReceteDVO.receteTuru = 4;
                        break;
                    case (PrescriptionTypeEnum.GreenPrescription):
                        eReceteDVO.receteTuru = 5;
                        break;
                    case (PrescriptionTypeEnum.ControlledPrescription):
                        eReceteDVO.receteTuru = 1;
                        break;
                    default:
                        throw new TTException(TTUtils.CultureService.GetText("M25905", "Hatalı reçete tipi"));
                        //break;
                }
            }
            else
            {
                List<TTObjectClasses.EReceteIslemleri.ereceteIlacDVO> receteIlacLst = new List<TTObjectClasses.EReceteIslemleri.ereceteIlacDVO>();
                foreach (InpatientDrugOrder drugOrder in ((InpatientPrescription)pres).InpatientDrugOrders)
                {
                    if (drugOrder.CurrentStateDefID != InpatientDrugOrder.States.Cancelled)
                    {
                        TTObjectClasses.EReceteIslemleri.ereceteIlacDVO receteIlac = new TTObjectClasses.EReceteIslemleri.ereceteIlacDVO();
                        receteIlac.barkod = Convert.ToInt64(drugOrder.Material.Barcode);
                        receteIlac.ilacAdi = drugOrder.Material.Name.ToString();
                        receteIlac.adet = (int)drugOrder.PackageAmount;
                        receteIlac.kullanimDoz1 = (int)DrugOrder.GetDetailCount(drugOrder.Frequency);
                        receteIlac.kullanimDoz2 = (double)drugOrder.DoseAmount;
                        if (((DrugDefinition)drugOrder.Material).ReimbursementUnder.HasValue)
                            receteIlac.geriOdemeKapsaminda = ((DrugDefinition)drugOrder.Material).ReimbursementUnder == true ? "E" : "H";
                        receteIlac.kullanimPeriyot = 1;
                        receteIlac.kullanimPeriyotBirimi = 3;

                        if (drugOrder.Material is MedicinalProductDefinition)
                            receteIlac.kullanimSekli = 99;
                        else
                            receteIlac.kullanimSekli = (int)((DrugDefinition)drugOrder.Material).RouteOfAdmin.Code;

                        List<TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO> receteIlacAciklamaLst = new List<TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO>();
                        if (!string.IsNullOrEmpty(drugOrder.Description))
                        {
                            TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO receteIlacAciklama = new TTObjectClasses.EReceteIslemleri.ereceteIlacAciklamaDVO();
                            receteIlacAciklama.aciklama = drugOrder.Description;
                            receteIlacAciklama.aciklamaTuru = (int)drugOrder.DescriptionType;
                            receteIlacAciklamaLst.Add(receteIlacAciklama);
                        }
                        if (receteIlacAciklamaLst != null && receteIlacAciklamaLst.Count > 0)
                            receteIlac.ereceteIlacAciklamaListesi = receteIlacAciklamaLst.ToArray();

                        receteIlacLst.Add(receteIlac);
                    }
                }
                if (receteIlacLst != null && receteIlacLst.Count > 0)
                    eReceteDVO.ereceteIlacListesi = receteIlacLst.ToArray();

                eReceteDVO.protokolNo = pres.Episode.HospitalProtocolNo.ToString();
                eReceteDVO.receteAltTuru = (int)PrescriptionSubTypeEnum.InPatientPrescriptionSubType;
                switch (pres.PrescriptionType)
                {
                    case (PrescriptionTypeEnum.NormalPrescription):
                        eReceteDVO.receteTuru = 1;
                        break;
                    case (PrescriptionTypeEnum.RedPrescription):
                        eReceteDVO.receteTuru = 2;
                        break;
                    case (PrescriptionTypeEnum.OrangePrescription):
                        eReceteDVO.receteTuru = 3;
                        break;
                    case (PrescriptionTypeEnum.PurplePrescription):
                        eReceteDVO.receteTuru = 4;
                        break;
                    case (PrescriptionTypeEnum.GreenPrescription):
                        eReceteDVO.receteTuru = 5;
                        break;
                    case (PrescriptionTypeEnum.ControlledPrescription):
                        eReceteDVO.receteTuru = 1;
                        break;
                    default:
                        throw new TTException(TTUtils.CultureService.GetText("M25905", "Hatalı reçete tipi"));
                        //break;
                }
            }

            eReceteInfo.ereceteDVO = eReceteDVO;

            //Dictionary<Guid, DiagnosisForPresc> taniDictionary = new Dictionary<Guid, DiagnosisForPresc>();

            //if (pres is OutPatientPrescription)
            //{
            //    foreach (DiagnosisForPresc diagnosis in pres.SPTSDiagnosises)
            //    {
            //        if (diagnosis.Check.HasValue && (bool)diagnosis.Check)
            //        {
            //            if (taniDictionary.ContainsKey(diagnosis.ObjectID) == false)
            //                taniDictionary.Add(diagnosis.ObjectID, diagnosis);
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (DiagnosisForPresc diagnosis in pres.SPTSDiagnosises)
            //    {
            //        if (taniDictionary.ContainsKey(diagnosis.ObjectID) == false)
            //            taniDictionary.Add(diagnosis.ObjectID, diagnosis);
            //    }
            //}

            Dictionary<Guid, DiagnosisGrid> taniDictionary = new Dictionary<Guid, DiagnosisGrid>();

            foreach (DiagnosisGrid diagnosis in pres.Episode.Diagnosis)
            {
                if (taniDictionary.ContainsKey(diagnosis.ObjectID) == false)
                    taniDictionary.Add(diagnosis.ObjectID, diagnosis);
            }

            Dictionary<string, string> presDias = new Dictionary<string, string>();
            foreach (KeyValuePair<Guid, DiagnosisGrid> presDia in taniDictionary)
            {
                if (presDia.Value.Diagnose.Code.Length > 5)
                {
                    if (presDias.ContainsKey(presDia.Value.Diagnose.Code.Substring(0, 5)) == false)
                        presDias.Add(presDia.Value.Diagnose.Code.Substring(0, 5), presDia.Value.Diagnose.Name);
                }
                else
                {
                    if (presDias.ContainsKey(presDia.Value.Diagnose.Code) == false)
                        presDias.Add(presDia.Value.Diagnose.Code, presDia.Value.Diagnose.Name);
                }
            }

            List<TTObjectClasses.EReceteIslemleri.ereceteTaniDVO> taniLst = new List<TTObjectClasses.EReceteIslemleri.ereceteTaniDVO>();

            foreach (KeyValuePair<string, string> diagnosis in presDias)
            {
                TTObjectClasses.EReceteIslemleri.ereceteTaniDVO tani = new TTObjectClasses.EReceteIslemleri.ereceteTaniDVO();
                tani.taniKodu = diagnosis.Key;
                tani.taniAdi = diagnosis.Value;
                taniLst.Add(tani);
            }


            if (taniLst != null && taniLst.Count > 0)
                eReceteDVO.ereceteTaniListesi = taniLst.ToArray();

            TTObjectClasses.EReceteIslemleri.kisiDVO kisiDVO = new TTObjectClasses.EReceteIslemleri.kisiDVO();
            kisiDVO.adi = pres.Episode.Patient.Name;
            kisiDVO.soyadi = pres.Episode.Patient.Surname;
            kisiDVO.tcKimlikNo = pres.Episode.Patient.UniqueRefNo != null ? pres.Episode.Patient.UniqueRefNo.Value : 00000000000;
            kisiDVO.cinsiyeti = pres.Episode.Patient.Sex != null ? pres.Episode.Patient.Sex.ADI.ToString() : "";
            kisiDVO.dogumTarihi = pres.Episode.Patient.BirthDate != null ? pres.Episode.Patient.BirthDate.Value.ToString("dd.MM.yyyy") : DateTime.Now.ToString("dd.MM.yyyy");
            eReceteDVO.kisiDVO = kisiDVO;
            eReceteInfo.ereceteDVO = eReceteDVO;
            return eReceteInfo;

        }

        public static EReceteIslemleri.ereceteSorguIstekDVO GetEreceteInQuiry(Prescription pres)
        {
            EReceteIslemleri.ereceteSorguIstekDVO ereceteInQuiry = new EReceteIslemleri.ereceteSorguIstekDVO();
            ereceteInQuiry.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            ereceteInQuiry.ereceteNo = pres.EReceteNo;
            ereceteInQuiry.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return ereceteInQuiry;
        }

        public static EReceteIslemleri.ereceteListeSorguIstekDVO GetEreceteListInQuiry(Prescription pres)
        {
            EReceteIslemleri.ereceteListeSorguIstekDVO eReceteListInQuiry = new EReceteIslemleri.ereceteListeSorguIstekDVO();
            eReceteListInQuiry.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            eReceteListInQuiry.hastaTcKimlikNo = pres.Episode.Patient.UniqueRefNo != null ? pres.Episode.Patient.UniqueRefNo.Value : 00000000000;
            eReceteListInQuiry.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return eReceteListInQuiry;
        }


        public static EReceteIslemleri.ereceteOnayIstekDVO GetEreceteApprovalRequest(Prescription pres)
        {
            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = new EReceteIslemleri.ereceteOnayIstekDVO();
            eReceteApprovalRequest.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            eReceteApprovalRequest.receteOnayTuru = "1";//1 = Yatan Hasta, 2 = EHU, 3 = Diğer Hekim
            eReceteApprovalRequest.ereceteNo = pres.EReceteNo;
            eReceteApprovalRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return eReceteApprovalRequest;
        }

        public static EReceteIslemleri.ereceteYatanHastaOnayiIstekDVO GetEreceteInpatientApprovalRequest(Prescription pres)
        {
            EReceteIslemleri.ereceteYatanHastaOnayiIstekDVO eReceteApprovalRequest = new EReceteIslemleri.ereceteYatanHastaOnayiIstekDVO();
            eReceteApprovalRequest.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            //eReceteApprovalRequest.receteOnayTuru = " 1";//1 = Yatan Hasta, 2 = EHU, 3 = Diğer Hekim
            eReceteApprovalRequest.ereceteNo = pres.EReceteNo;
            eReceteApprovalRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return eReceteApprovalRequest;
        }



        public static EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteApprovalCancelRequest(Prescription pres)
        {
            EReceteIslemleri.ereceteOnayIptalIstekDVO eReceteApprovalCancelRequest = new EReceteIslemleri.ereceteOnayIptalIstekDVO();
            eReceteApprovalCancelRequest.doktorTcKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            eReceteApprovalCancelRequest.receteOnayTuru = "1";//1 = Yatan Hasta, 2 = EHU, 3 = Diğer Hekim
            eReceteApprovalCancelRequest.ereceteNo = pres.EReceteNo;
            eReceteApprovalCancelRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return eReceteApprovalCancelRequest;
        }



        public static EReceteIslemleri.ereceteOnayIstekDVO GetEreceteEHUApprovalRequest(Prescription pres, long UniqueRefNo)
        {
            EReceteIslemleri.ereceteOnayIstekDVO ereceteEHUApprovalRequest = new EReceteIslemleri.ereceteOnayIstekDVO();
            ereceteEHUApprovalRequest.doktorTcKimlikNo = UniqueRefNo;
            ereceteEHUApprovalRequest.receteOnayTuru = "2";
            ereceteEHUApprovalRequest.ereceteNo = pres.EReceteNo;
            ereceteEHUApprovalRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return ereceteEHUApprovalRequest;
        }



        public static EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteEHUCancelRequest(Prescription pres, long UniqueRefNo)
        {
            EReceteIslemleri.ereceteOnayIptalIstekDVO ereceteEHUCancelRequest = new EReceteIslemleri.ereceteOnayIptalIstekDVO();
            ereceteEHUCancelRequest.doktorTcKimlikNo = UniqueRefNo;
            ereceteEHUCancelRequest.receteOnayTuru = "2";
            ereceteEHUCancelRequest.ereceteNo = pres.EReceteNo;
            ereceteEHUCancelRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return ereceteEHUCancelRequest;
        }



        public static EReceteIslemleri.ereceteOnayIstekDVO GetEreceteDailyPresApprovalRequest(Prescription pres, long UniqueRefNo)
        {
            EReceteIslemleri.ereceteOnayIstekDVO ereceteDailyPresApprovalRequest = new EReceteIslemleri.ereceteOnayIstekDVO();
            ereceteDailyPresApprovalRequest.doktorTcKimlikNo = UniqueRefNo;
            ereceteDailyPresApprovalRequest.receteOnayTuru = "4";
            ereceteDailyPresApprovalRequest.ereceteNo = pres.EReceteNo;
            ereceteDailyPresApprovalRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return ereceteDailyPresApprovalRequest;
        }

        public static EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteDailyPresCancelRequest(Prescription pres, long UniqueRefNo)
        {
            EReceteIslemleri.ereceteOnayIptalIstekDVO ereceteDailyPresCancelRequest = new EReceteIslemleri.ereceteOnayIptalIstekDVO();
            ereceteDailyPresCancelRequest.doktorTcKimlikNo = UniqueRefNo;
            ereceteDailyPresCancelRequest.receteOnayTuru = "4";
            ereceteDailyPresCancelRequest.ereceteNo = pres.EReceteNo;
            ereceteDailyPresCancelRequest.tesisKodu = SystemParameter.GetSaglikTesisKodu();
            return ereceteDailyPresCancelRequest;
        }

        public StockPrescriptionOut FindStockPrescriptionOut(Prescription pres)
        {
            StockPrescriptionOut stockPrescriptionOut = null;
            IList stockPrescriptionOuts = pres.ObjectContext.QueryObjects("STOCKPRESCRIPTIONOUT", "PRESCRIPTION =" + ConnectionManager.GuidToString(pres.ObjectID));
            foreach (StockPrescriptionOut prescriptionOut in stockPrescriptionOuts)
            {
                if (prescriptionOut.CurrentStateDefID == StockPrescriptionOut.States.Completed)
                {
                    stockPrescriptionOut = prescriptionOut;
                    break;
                }
            }
            return stockPrescriptionOut;
        }


        public void CancelStockPrescriptionOut(Prescription pres)
        {
            StockPrescriptionOut stockPrescriptionOut = pres.FindStockPrescriptionOut(pres);
            if (stockPrescriptionOut != null)
            {
                string result = "E"; //ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Reçete Kağıdı İptali", "Bu reçete ile bir adet reçete kağıdı daha önce sarf edilmiştir. \r\n" + "Bu reçete kağıdını da iptal etmek istiyormusunuz ?");
                if (result == "E")
                {
                    StockPrescriptionOut cancelAction = (StockPrescriptionOut)pres.ObjectContext.GetObject(stockPrescriptionOut.ObjectID, typeof(StockPrescriptionOut));
                    cancelAction.CurrentStateDefID = StockPrescriptionOut.States.Cancelled;
                }
            }
        }

        public void NoStepBackPrescription(Prescription pres)
        {
            StockPrescriptionOut stockPrescriptionOut = pres.FindStockPrescriptionOut(pres);
            if (stockPrescriptionOut != null)
            {
                throw new Exception(TTUtils.CultureService.GetText("M25337", "Bu reçete için reçete kağıdı sarf edildiği için işlemi geri alamazsınız. İşlemi ancak iptal edebilirsiniz."));
            }
        }

        public static XXXXXXSptsClasses.ReceteInfo GetDısReceteInfo(Prescription pres)
        {
            XXXXXXSptsClasses.ReceteInfo receteInfo = new XXXXXXSptsClasses.ReceteInfo();
            receteInfo.HastaId = pres.Episode.Patient.ObjectID.ToString();
            receteInfo.ReceteObjectId = pres.ObjectID.ToString();
            receteInfo.sicilno = pres.ProcedureDoctor.EmploymentRecordID.ToString();
            receteInfo.diplomano = Convert.ToInt32(pres.ProcedureDoctor.DiplomaNo.ToString());
            receteInfo.ilacverilistarihi = DateTime.Now.ToString();
            receteInfo.recetetarihi = DateTime.Now.ToString();
            foreach (ResourceSpecialityGrid speciality in pres.ProcedureDoctor.ResourceSpecialities)
            {
                if (speciality.MainSpeciality == true)
                {
                    receteInfo.uzmanlikdali = Convert.ToInt16(speciality.Speciality.Code);
                }
            }

            receteInfo.patientgroup = pres.Episode.Patient.Beneficiary.Value.ToString();
            //receteInfo.receteturu = "1";
            if (((OutPatientPrescription)pres).FreeDiagnosis != null)
            {
                receteInfo.serbesttani = ((OutPatientPrescription)pres).FreeDiagnosis.ToString();
            }
            else
            {
                receteInfo.serbesttani = "";
            }
            receteInfo.kurumId = 1011;
            receteInfo.protokolno = ((OutPatientPrescription)pres).PrescriptionNO.ToString();
            receteInfo.acildurum = pres.Emergency.Value.ToString();
            receteInfo.XXXXXX = SystemParameter.GetParameterValue("SPTSHOSPITALID", null).ToString();
            receteInfo.ilaclar = new List<XXXXXXSptsClasses.receteilac>();
            if (pres is OutPatientPrescription)
            {
                receteInfo.ayaktanyatan = 0;
                foreach (OutPatientDrugOrder drugOrder in ((OutPatientPrescription)pres).OutPatientDrugOrders)
                {
                    if (drugOrder.Material is DrugDefinition)
                    {
                        if (drugOrder.StoreInheld < drugOrder.Amount)
                        {
                            if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Supply)
                            {
                                XXXXXXSptsClasses.receteilac receteIlac = new XXXXXXSptsClasses.receteilac();
                                long sptsID = drugOrder.MaterialBarcodeLevel.SPTSDrugID.Value;
                                receteIlac.Id = Convert.ToInt32(sptsID);
                                receteIlac.name = drugOrder.Material.Name.ToString();
                                receteIlac.PacketAmount = (int)drugOrder.PackageAmount;
                                receteIlac.Dosage = (int)((DrugDefinition)drugOrder.Material).Dose;
                                receteIlac.DosageAmount = (int)drugOrder.DoseAmount;
                                receteIlac.weeklyMonthly = 1;
                                receteIlac.AlternativeId = 0;
                                receteIlac.hasReport = (Boolean)drugOrder.Report;
                                receteIlac.hasTenDays = (Boolean)drugOrder.TenDaily;
                                receteInfo.ilaclar.Add(receteIlac);
                            }
                        }
                    }
                }
            }
            else
            {
                receteInfo.ayaktanyatan = 1;
                foreach (InpatientDrugOrder drugOrder in ((InpatientPrescription)pres).InpatientDrugOrders)
                {
                    if (drugOrder.Material is DrugDefinition)
                    {
                        XXXXXXSptsClasses.receteilac receteIlac = new XXXXXXSptsClasses.receteilac();
                        receteIlac.Id = Convert.ToInt16(drugOrder.Material.Code.ToString());
                        receteIlac.name = drugOrder.Material.Name.ToString();
                        receteIlac.PacketAmount = (int)drugOrder.PackageAmount;
                        receteIlac.Dosage = (int)((DrugDefinition)drugOrder.Material).Dose;
                        receteIlac.DosageAmount = (int)drugOrder.DoseAmount;
                        receteIlac.weeklyMonthly = 1;
                        receteIlac.AlternativeId = 0;
                        receteIlac.hasReport = false;
                        receteIlac.hasTenDays = false;
                        receteInfo.ilaclar.Add(receteIlac);
                    }
                }
            }
            receteInfo.tanilar = new List<XXXXXXSptsClasses.recetetani>();
            foreach (DiagnosisForSPTS diagnosis in pres.DiagnosisForSPTSs)
            {
                XXXXXXSptsClasses.recetetani dia = new XXXXXXSptsClasses.recetetani();
                dia.adi = diagnosis.SPTSDiagnosisInfo.Name.ToString();
                dia.kodu = diagnosis.SPTSDiagnosisInfo.ID.ToString();
                receteInfo.tanilar.Add(dia);
            }
            return receteInfo;
        }

        public static XXXXXXSptsClasses.ReceteInfo GetReceteInfo(Prescription pres)
        {
            XXXXXXSptsClasses.ReceteInfo receteInfo = new XXXXXXSptsClasses.ReceteInfo();
            receteInfo.HastaId = pres.Episode.Patient.ObjectID.ToString();
            receteInfo.ReceteObjectId = pres.ObjectID.ToString();
            receteInfo.sicilno = pres.ProcedureDoctor.EmploymentRecordID.ToString();
            receteInfo.diplomano = Convert.ToInt32(pres.ProcedureDoctor.DiplomaNo.ToString());
            receteInfo.ilacverilistarihi = DateTime.Now.ToString();
            receteInfo.recetetarihi = DateTime.Now.ToString();
            foreach (ResourceSpecialityGrid speciality in pres.ProcedureDoctor.ResourceSpecialities)
            {
                if (speciality.MainSpeciality == true)
                {
                    receteInfo.uzmanlikdali = Convert.ToInt16(speciality.Speciality.Code);
                }
            }

            //receteInfo.patientgroup = "2";
            receteInfo.patientgroup = pres.Episode.Patient.Beneficiary.Value.ToString();
            //receteInfo.receteturu = "1";
            if (((OutPatientPrescription)pres).FreeDiagnosis != null)
            {
                receteInfo.serbesttani = ((OutPatientPrescription)pres).FreeDiagnosis.ToString();
            }
            else
            {
                receteInfo.serbesttani = "";
            }
            receteInfo.kurumId = 1011;
            receteInfo.protokolno = ((OutPatientPrescription)pres).PrescriptionNO.ToString();
            receteInfo.acildurum = pres.Emergency.Value.ToString();
            receteInfo.XXXXXX = SystemParameter.GetParameterValue("SPTSHOSPITALID", null).ToString();
            receteInfo.ilaclar = new List<XXXXXXSptsClasses.receteilac>();
            if (pres is OutPatientPrescription)
            {
                receteInfo.ayaktanyatan = 0;
                foreach (OutPatientDrugOrder drugOrder in ((OutPatientPrescription)pres).OutPatientDrugOrders)
                {
                    if (drugOrder.Material is DrugDefinition)
                    {
                        if (drugOrder.StoreInheld >= drugOrder.Amount)
                        {
                            if (drugOrder.DrugSupply == OutPatientDrugSupplyEnum.Supply)
                            {
                                XXXXXXSptsClasses.receteilac receteIlac = new XXXXXXSptsClasses.receteilac();
                                long sptsID = drugOrder.MaterialBarcodeLevel.SPTSDrugID.Value;
                                receteIlac.Id = Convert.ToInt32(sptsID);
                                receteIlac.name = drugOrder.Material.Name.ToString();
                                receteIlac.PacketAmount = (int)drugOrder.PackageAmount;
                                receteIlac.Dosage = (int)((DrugDefinition)drugOrder.Material).Dose;
                                receteIlac.DosageAmount = (int)drugOrder.DoseAmount;
                                receteIlac.weeklyMonthly = 1;
                                receteIlac.AlternativeId = 0;
                                receteIlac.hasReport = (Boolean)drugOrder.Report;
                                receteIlac.hasTenDays = (Boolean)drugOrder.TenDaily;
                                receteInfo.ilaclar.Add(receteIlac);
                            }
                        }
                    }
                }
            }
            else
            {
                receteInfo.ayaktanyatan = 1;
                foreach (InpatientDrugOrder drugOrder in ((InpatientPrescription)pres).InpatientDrugOrders)
                {
                    if (drugOrder.Material is DrugDefinition)
                    {
                        XXXXXXSptsClasses.receteilac receteIlac = new XXXXXXSptsClasses.receteilac();
                        receteIlac.Id = Convert.ToInt16(drugOrder.Material.Code.ToString());
                        receteIlac.name = drugOrder.Material.Name.ToString();
                        receteIlac.PacketAmount = (int)drugOrder.PackageAmount;
                        receteIlac.Dosage = (int)((DrugDefinition)drugOrder.Material).Dose;
                        receteIlac.DosageAmount = (int)drugOrder.DoseAmount;
                        receteIlac.weeklyMonthly = 1;
                        receteIlac.AlternativeId = 0;
                        receteIlac.hasReport = false;
                        receteIlac.hasTenDays = false;
                        receteInfo.ilaclar.Add(receteIlac);
                    }
                }
            }
            receteInfo.tanilar = new List<XXXXXXSptsClasses.recetetani>();
            foreach (DiagnosisForSPTS diagnosis in pres.DiagnosisForSPTSs)
            {
                XXXXXXSptsClasses.recetetani dia = new XXXXXXSptsClasses.recetetani();
                dia.adi = diagnosis.SPTSDiagnosisInfo.Name.ToString();
                dia.kodu = diagnosis.SPTSDiagnosisInfo.ID.ToString();
                receteInfo.tanilar.Add(dia);
            }
            return receteInfo;
        }


        [Serializable]
        public class DigitalSignedPrescription
        {
            public DigitalSignedPrescription(ResUser resUser, OutPatientPrescription outPatientPrescription)
            {
                _userID = resUser.ObjectID;
                _userName = resUser.Name;
                _signedDate = TTObjectDefManager.ServerTime;
                _digitalPrescription = new Prescription.DigitalPrescription(outPatientPrescription);
                _signedData = resUser.SignData(_digitalPrescription);
            }

            private Guid _userID;
            public Guid UserID
            {
                get { return _userID; }
                set { _userID = value; }
            }

            private string _userName;
            public string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            private byte[] _signedData;
            public byte[] SignedData
            {
                get { return _signedData; }
                set { _signedData = value; }
            }

            private DateTime _signedDate;
            public DateTime SignedDate
            {
                get { return _signedDate; }
                set { _signedDate = value; }
            }

            private Prescription.DigitalPrescription _digitalPrescription;
            public Prescription.DigitalPrescription DigitalPrescription
            {
                get { return _digitalPrescription; }
                set { _digitalPrescription = value; }
            }

        }



        [Serializable]
        public class DigitalPrescription
        {
            public DigitalPrescription()
            {

            }

            public DigitalPrescription(OutPatientPrescription outPatientPrescription)
            {
                _procedureDoctorID = outPatientPrescription.ProcedureDoctor.ObjectID;
                if (outPatientPrescription.FillingDate.HasValue)
                    _fillingDate = outPatientPrescription.FillingDate.Value;
                _prescriptionNO = outPatientPrescription.PrescriptionNO;
                if (outPatientPrescription.PrescriptionType.HasValue)
                    _prescriptionType = (int)outPatientPrescription.PrescriptionType.Value;

                if (outPatientPrescription.OutPatientDrugOrders.Count > 0)
                {
                    _digitalPrescriptionDetails = new List<Prescription.DigitalPrescriptionDetail>();
                    foreach (OutPatientDrugOrder outPatientDrugOrder in outPatientPrescription.OutPatientDrugOrders)
                    {
                        Prescription.DigitalPrescriptionDetail digitalPrescriptionDetail = new Prescription.DigitalPrescriptionDetail();
                        digitalPrescriptionDetail.DrugID = outPatientDrugOrder.Material.ObjectID;
                        if (outPatientDrugOrder.Day.HasValue)
                            digitalPrescriptionDetail.Day = outPatientDrugOrder.Day.Value;
                        if (outPatientDrugOrder.DoseAmount.HasValue)
                            digitalPrescriptionDetail.DoseAmount = outPatientDrugOrder.DoseAmount.Value;
                        if (outPatientDrugOrder.Frequency.HasValue)
                            digitalPrescriptionDetail.Frequency = (int)outPatientDrugOrder.Frequency.Value;
                        _digitalPrescriptionDetails.Add(digitalPrescriptionDetail);
                    }
                }
            }

            private DateTime _fillingDate;
            public DateTime FillingDate
            {
                get { return _fillingDate; }
                set { _fillingDate = value; }
            }

            private string _prescriptionNO;
            public string PrescriptionNO
            {
                get { return _prescriptionNO; }
                set { _prescriptionNO = value; }
            }

            private int _prescriptionType;
            public int PrescriptionType
            {
                get { return _prescriptionType; }
                set { _prescriptionType = value; }
            }

            private Guid _procedureDoctorID;
            public Guid ProcedureDoctorID
            {
                get { return _procedureDoctorID; }
                set { _procedureDoctorID = value; }
            }

            private List<Prescription.DigitalPrescriptionDetail> _digitalPrescriptionDetails;
            public List<Prescription.DigitalPrescriptionDetail> DigitalPrescriptionDetails
            {
                get { return _digitalPrescriptionDetails; }
                set { _digitalPrescriptionDetails = value; }
            }

        }

        [Serializable]
        public class DigitalPrescriptionDetail
        {
            public DigitalPrescriptionDetail()
            {
            }

            private Guid _drugID;
            public Guid DrugID
            {
                get { return _drugID; }
                set { _drugID = value; }
            }

            private int _day;
            public int Day
            {
                get { return _day; }
                set { _day = value; }
            }

            private int _frequency;
            public int Frequency
            {
                get { return _frequency; }
                set { _frequency = value; }
            }

            private double _doseAmount;
            public double DoseAmount
            {
                get { return _doseAmount; }
                set { _doseAmount = value; }
            }
        }

        #endregion Methods

    }
}