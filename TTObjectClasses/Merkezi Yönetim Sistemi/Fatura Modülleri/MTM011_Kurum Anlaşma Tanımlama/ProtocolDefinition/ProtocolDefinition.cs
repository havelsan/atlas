
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
    /// Kurum Anlaşma Tanımlama
    /// </summary>
    public partial class ProtocolDefinition : TerminologyManagerDef
    {
        public partial class GetProtocolDefinitions_Class : TTReportNqlObject
        {
        }

        #region Methods
        public ArrayList CalculatePrice(TTObject pObject, PatientStatusEnum? ppPatientStatus, PackageDefinition pPackageDef, DateTime? pSubActDate, PricingListDefinition pPricingList, int? patientAge)
        {
            if (ppPatientStatus.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(587));

            PatientStatusEnum pPatientStatus = ppPatientStatus.Value;

            if (pPackageDef != null) //Paket icindeki hizmet/malzemenin hesaplanmasi
            {
                int patientPercent = 0;
                int payerPercent = 0;

                ProtocolExceptionProcedureDefinition prtException = GetProtocolExceptionProcedureDefinition(pPackageDef.PackageProcedureDefinition, patientAge);
                if (prtException != null)
                {
                    if (pPatientStatus == PatientStatusEnum.Outpatient)
                    {
                        patientPercent = (int)prtException.OutPatientPatientPercent;
                        payerPercent = (int)prtException.OutPatientPayerPercent;
                    }
                    else
                    {
                        patientPercent = (int)prtException.InPatientPatientPercent;
                        payerPercent = (int)prtException.InPatientPayerPercent;
                    }
                }
                else
                {
                    ProtocolDetailProcedureDefinition prtDetail = GetProtocolDetailProcedureDefinition(pPackageDef.PackageProcedureDefinition, patientAge);
                    if (prtDetail != null)
                    {
                        if (pPatientStatus == PatientStatusEnum.Outpatient)
                        {
                            patientPercent = (int)prtDetail.OutPatientPatientPercent;
                            payerPercent = (int)prtDetail.OutPatientPayerPercent;
                        }
                        else
                        {
                            patientPercent = (int)prtDetail.InPatientPatientPercent;
                            payerPercent = (int)prtDetail.InPatientPayerPercent;
                        }
                    }
                }

                ArrayList col = new ArrayList();
                if (pPackageDef.UsePackageRulesForPricing == true)  // Paketteki (PackageDefinition) fiyat listesi ve kurallar kullanılır
                {
                    if (pSubActDate == null)
                        col = pPackageDef.CalculatePackagePrice(pObject, pPricingList);
                    else
                        col = pPackageDef.CalculatePackagePrice(pObject, pSubActDate);
                }
                else  // Anlaşmadaki (ProtocolDefinition) fiyat listesi ve kurallar kullanılır
                {
                    if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
                    {
                        ProcedureDefinition pDef = (ProcedureDefinition)pObject;
                        if (pSubActDate == null)
                            col = CalculateProcedurePrice(pDef, pPatientStatus, pPricingList, patientAge);
                        else
                            col = CalculateProcedurePrice(pDef, pPatientStatus, pSubActDate, patientAge);
                    }
                    else if (pObject.ObjectDef.IsOfType("MATERIAL") == true)
                    {
                        Material mDef = (Material)pObject;
                        if (pSubActDate == null)
                            col = CalculateMaterialPrice(mDef, pPatientStatus, pPricingList);
                        else
                            col = CalculateMaterialPrice(mDef, pPatientStatus, pSubActDate);
                    }
                }

                foreach (ManipulatedPrice mpd in col)
                {
                    if (patientPercent == 100) // Paket %100 hasta payı olarak ücretlenecekse içindekiler de hasta payı olarak oluşsun
                    {
                        mpd.PayerPrice = 0;
                        mpd.PatientPrice = mpd.Price;
                    }
                    else if (payerPercent == 100) // Paket %100 kurum payı olarak ücretlenecekse içindekiler de kurum payı olarak oluşsun
                    {
                        mpd.PayerPrice = mpd.Price;
                        mpd.PatientPrice = 0;
                    }
                    else  // Paketin hasta ve kurum arasında paylaştırılacağı durumda da (böyle bir durum olmaz normalde ama) içindekiler kurum payı olarak oluşsun
                    {
                        mpd.PayerPrice = mpd.Price;
                        mpd.PatientPrice = 0;
                    }
                }
                return col;
            }
            else
            {
                if (pObject.ObjectDef.IsOfType("PROCEDUREDEFINITION") == true)
                {
                    ProcedureDefinition pDef = (ProcedureDefinition)pObject;
                    if (pSubActDate == null)
                        return CalculateProcedurePrice(pDef, pPatientStatus, pPricingList, patientAge);
                    else
                        return CalculateProcedurePrice(pDef, pPatientStatus, pSubActDate, patientAge);
                }
                else if (pObject.ObjectDef.IsOfType("MATERIAL") == true)
                {
                    Material mDef = (Material)pObject;
                    if (pSubActDate == null)
                        return CalculateMaterialPrice(mDef, pPatientStatus, pPricingList);
                    else
                        return CalculateMaterialPrice(mDef, pPatientStatus, pSubActDate);
                }
                else
                    return null;
            }
        }

        public ArrayList CalculatePrice(TTObject pObject, PatientStatusEnum? ppPatientStatus, PackageDefinition pPackageDef, PricingListDefinition pPricingList, int? patientAge)
        {
            return CalculatePrice(pObject, ppPatientStatus, pPackageDef, null, pPricingList, patientAge);
        }

        public ArrayList CalculatePrice(TTObject pObject, PatientStatusEnum? ppPatientStatus, PackageDefinition pPackageDef, DateTime? pSubActDate, int? patientAge)
        {
            return CalculatePrice(pObject, ppPatientStatus, pPackageDef, pSubActDate, null, patientAge);
        }

        private ArrayList CalculateProcedurePrice(ProcedureDefinition pProcedure, PatientStatusEnum? ppPatientStatus, DateTime? pSubActionDate, PricingListDefinition pPricingList, int? patientAge)
        {
            if (ppPatientStatus.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(587));
            PatientStatusEnum pPatientStatus = ppPatientStatus.Value;

            ProtocolDetailProcedureDefinition prtDetail;
            ArrayList pricingDetailList = new ArrayList();
            ArrayList manipulatedPDList = new ArrayList();
            double discountPercent = 0;
            int patientPercent = 0;
            int payerPercent = 0;
            double discountedPrice = 0;
            const double EK2A2IncreasePercent = 110;
            PackageProcedureDefinition packProcDef = pProcedure as PackageProcedureDefinition;
            TTObjectContext context = new TTObjectContext(false);

            ProtocolExceptionProcedureDefinition pexc = GetProtocolExceptionProcedureDefinition(pProcedure, patientAge);
            if (pexc != null)
            {
                // direkt fiyat verilmisse onlar isleme aliniyor.
                if ((pexc.PatientPrice != 0) || (pexc.PayerPrice != 0))
                {
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pexc.ProcedureObject.Code;
                    mypd.Description = pexc.ProcedureObject.Name;
                    mypd.Price = (double)pexc.PatientPrice + (double)pexc.PayerPrice;
                    mypd.PatientPrice = pexc.PatientPrice;
                    mypd.PayerPrice = pexc.PayerPrice;

                    manipulatedPDList.Add(mypd);
                    return manipulatedPDList;
                }
                else
                {
                    double multiplier = 0; // Fiyat Listesi çarpanı

                    if (pSubActionDate == null)
                        pricingDetailList = pProcedure.GetProcedurePricingDetail(pPricingList);
                    else
                    {
                        pricingDetailList = pProcedure.GetProcedurePricingDetail(pexc.PricingList, pSubActionDate);
                        if (pricingDetailList.Count > 0)
                        {
                            if (pexc.PricingListMultiplier != null)
                                multiplier = (double)pexc.PricingListMultiplier.Multiplier;
                        }
                        // Alternatif Fiyat Listesinden fiyat kontrolü
                        if (pricingDetailList.Count == 0 && pexc.SecondPricingList != null)
                        {
                            pricingDetailList = pProcedure.GetProcedurePricingDetail(pexc.SecondPricingList, pSubActionDate);
                            if (pricingDetailList.Count > 0)
                            {
                                if (pexc.SecondPricingListMultiplier != null)
                                    multiplier = (double)pexc.SecondPricingListMultiplier.Multiplier;
                            }
                        }
                    }

                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;

                        // XXXXXX üniversite XXXXXX ve Fiyat Tanım ekranında İndirim/Artırım Oranı dolu ise, Fiyat Tanım Ekranında
                        // tanımlı olan İndirim/Artırım oranına  göre fiyat hesaplanacak
                        // Kurum Anlaşma Tanımında Çarpan var is (1,12 örneğin), Ãœnv. XXXXXXlerine uygulanan %10 artırımın ekstradan
                        // uygulanmamasını istedi XXXXXX. Bu yüzden "multiplier == 0" koşulu eklendi.
                        // "multiplier == 0" koşulu kaldırıldı ATLAS'ta )
                        if (SystemParameter.GetParameterValue("APPLYPRICEDISCOUNTPERCENT", "TRUE").Equals("TRUE")) // && multiplier == 0)
                        {
                            double percent = 0;

                            if (pPatientStatus == PatientStatusEnum.Outpatient && pp.OutPatientDiscountPercent.HasValue && pp.OutPatientDiscountPercent > 0)
                                percent = pp.OutPatientDiscountPercent.Value;
                            else if (pPatientStatus != PatientStatusEnum.Outpatient && pp.InPatientDiscountPercent.HasValue && pp.InPatientDiscountPercent > 0)
                                percent = pp.InPatientDiscountPercent.Value;

                            // Fiyat için bir indirim/artırım oranı tanımlanmamışsa, EK-2A-2 hizmetleri için %10 artırım yapılır
                            // SGK ve Ücretsiz (SUT Fiyat Listesi kullanan) anlaşmalarda
                            if (percent == 0 && pProcedure.SUTAppendix == SUTHizmetEKEnum.EK2A2 && (Type == ProtocolTypeEnum.SGK || Type == ProtocolTypeEnum.UnPaid))
                                percent = EK2A2IncreasePercent;

                            if (percent >= 100)
                                mypd.Price = Math.Round((double)pp.Price * (percent / 100), 8);
                            else if (percent > 0 && percent < 100)
                                mypd.Price = Math.Round((double)pp.Price * (1 - (percent / 100)), 8);
                            else
                                mypd.Price = pp.Price;
                        }
                        else
                            mypd.Price = pp.Price;

                        if (multiplier > 0)  // Fiyat Listesi çarpanı varsa fiyat çarpılır
                            mypd.Price = Math.Round((double)(mypd.Price * multiplier), 8);

                        if (pPatientStatus == PatientStatusEnum.Outpatient)
                        {
                            discountPercent = (double)pexc.OutPatientDiscountPercent;
                            patientPercent = (int)pexc.OutPatientPatientPercent;
                            payerPercent = (int)pexc.OutPatientPayerPercent;
                        }
                        else
                        {
                            discountPercent = (double)pexc.InPatientDiscountPercent;
                            patientPercent = (int)pexc.InPatientPatientPercent;
                            payerPercent = (int)pexc.InPatientPayerPercent;
                        }

                        if (discountPercent > 100)
                            discountedPrice = Math.Round((double)mypd.Price * (discountPercent / 100), 8);
                        else
                            discountedPrice = Math.Round((double)mypd.Price * (1 - (discountPercent / 100)), 8);

                        mypd.Price = discountedPrice;
                        mypd.PatientPrice = (double)((patientPercent * discountedPrice) / 100);
                        mypd.PayerPrice = (double)((payerPercent * discountedPrice) / 100);
                        mypd.PricingDetailDefinition = pp;

                        manipulatedPDList.Add(mypd);
                    }
                    return manipulatedPDList;
                }
            }

            //Exceptionda yoksa anlasma detayindan hizmetin bagli oldugu hizmet grubu araniyor.
            prtDetail = (ProtocolDetailProcedureDefinition)GetProtocolDetailProcedureDefinition(pProcedure, patientAge);
            if (prtDetail != null)
            {
                double multiplier = 0; // Fiyat Listesi çarpanı

                if (pSubActionDate == null)
                    pricingDetailList = pProcedure.GetProcedurePricingDetail(pPricingList);
                else
                {
                    pricingDetailList = pProcedure.GetProcedurePricingDetail(prtDetail.PricingList, pSubActionDate);
                    if (pricingDetailList.Count > 0)
                    {
                        if (prtDetail.PricingListMultiplier != null)
                            multiplier = (double)prtDetail.PricingListMultiplier.Multiplier;
                    }
                    // Alternatif Fiyat Listesinden fiyat kontrolü
                    if (pricingDetailList.Count == 0 && prtDetail.SecondPricingList != null)
                    {
                        pricingDetailList = pProcedure.GetProcedurePricingDetail(prtDetail.SecondPricingList, pSubActionDate);
                        if (pricingDetailList.Count > 0)
                        {
                            if (prtDetail.SecondPricingListMultiplier != null)
                                multiplier = (double)prtDetail.SecondPricingListMultiplier.Multiplier;
                        }
                    }
                }

                foreach (PricingDetailDefinition pp in pricingDetailList)
                {
                    //ManipulatedPrice mypd = new ManipulatedPrice(ObjectContext);
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pp.ExternalCode;
                    mypd.Description = pp.Description;

                    // XXXXXX üniversite XXXXXX ve Fiyat Tanım ekranında İndirim/Artırım Oranı dolu ise, Fiyat Tanım Ekranında
                    // tanımlı olan İndirim/Artırım oranına  göre fiyat hesaplanacak.
                    // Kurum Anlaşma Tanımında Çarpan var is (1,12 örneğin), Ãœnv. XXXXXXlerine uygulanan %10 artırımın ekstradan
                    // uygulanmamasını istedi XXXXXX. Bu yüzden "multiplier == 0" koşulu eklendi.
                    // "multiplier == 0" koşulu kaldırıldı ATLAS'ta )
                    if (SystemParameter.GetParameterValue("APPLYPRICEDISCOUNTPERCENT", "TRUE").Equals("TRUE")) // && multiplier == 0)
                    {
                        double percent = 0;

                        if (pPatientStatus == PatientStatusEnum.Outpatient && pp.OutPatientDiscountPercent.HasValue && pp.OutPatientDiscountPercent > 0)
                            percent = pp.OutPatientDiscountPercent.Value;
                        else if (pPatientStatus != PatientStatusEnum.Outpatient && pp.InPatientDiscountPercent.HasValue && pp.InPatientDiscountPercent > 0)
                            percent = pp.InPatientDiscountPercent.Value;

                        // Fiyat için bir indirim/artırım oranı tanımlanmamışsa, EK-2A-2 hizmetleri için %10 artırım yapılır
                        // SGK ve Ücretsiz (SUT Fiyat Listesi kullanan) anlaşmalarda
                        if (percent == 0 && pProcedure.SUTAppendix == SUTHizmetEKEnum.EK2A2 && (Type == ProtocolTypeEnum.SGK || Type == ProtocolTypeEnum.UnPaid))
                            percent = EK2A2IncreasePercent;

                        if (percent >= 100)
                            mypd.Price = Math.Round((double)pp.Price * (percent / 100), 8);
                        else if (percent > 0 && percent < 100)
                            mypd.Price = Math.Round((double)pp.Price * (1 - (percent / 100)), 8);
                        else
                            mypd.Price = pp.Price;
                    }
                    else
                        mypd.Price = pp.Price;

                    if (multiplier > 0)  // Fiyat Listesi çarpanı varsa fiyat çarpılır
                        mypd.Price = Math.Round((double)(mypd.Price * multiplier), 8);

                    if (pPatientStatus == PatientStatusEnum.Outpatient)
                    {
                        //if(packProcDef == null)  Eskiden paketse indirimi yapmıyordu (discountPercent 0 kalıyordu), kaldırıldı.
                        discountPercent = (double)prtDetail.OutPatientDiscountPercent;
                        patientPercent = (int)prtDetail.OutPatientPatientPercent;
                        payerPercent = (int)prtDetail.OutPatientPayerPercent;
                    }
                    else
                    {
                        //if(packProcDef == null)  Eskiden paketse indirimi yapmıyordu (discountPercent 0 kalıyordu), kaldırıldı.
                        discountPercent = (double)prtDetail.InPatientDiscountPercent;
                        patientPercent = (int)prtDetail.InPatientPatientPercent;
                        payerPercent = (int)prtDetail.InPatientPayerPercent;
                    }

                    if (discountPercent > 100)
                        discountedPrice = Math.Round((double)mypd.Price * (discountPercent / 100), 8);
                    else
                        discountedPrice = Math.Round((double)mypd.Price * (1 - (discountPercent / 100)), 8);

                    mypd.Price = discountedPrice;
                    mypd.PatientPrice = (double)((patientPercent * discountedPrice) / 100);
                    mypd.PayerPrice = (double)((payerPercent * discountedPrice) / 100);
                    mypd.PricingDetailDefinition = pp;

                    manipulatedPDList.Add(mypd);
                }
                return manipulatedPDList;
            }
            else
                throw new TTException(SystemMessage.GetMessageV3(588, new string[] { Name, pProcedure.Code, pProcedure.Name }));
        }

        private ArrayList CalculateProcedurePrice(ProcedureDefinition pProcedure, PatientStatusEnum? ppPatientStatus, PricingListDefinition pPricingList, int? patientAge)
        {
            return CalculateProcedurePrice(pProcedure, ppPatientStatus, null, pPricingList, patientAge);
        }

        private ArrayList CalculateProcedurePrice(ProcedureDefinition pProcedure, PatientStatusEnum? ppPatientStatus, DateTime? pSubActionDate, int? patientAge)
        {
            return CalculateProcedurePrice(pProcedure, ppPatientStatus, pSubActionDate, null, patientAge);
        }

        private ArrayList CalculateMaterialPrice(Material pMaterial, PatientStatusEnum? ppPatientStatus, DateTime? pSubActionDate, PricingListDefinition pPricingList)
        {
            if (ppPatientStatus.HasValue == false)
                throw new TTException(SystemMessage.GetMessage(587));
            PatientStatusEnum pPatientStatus = ppPatientStatus.Value;

            ProtocolDetailMaterialDefinition prtDetail;
            ArrayList pricingDetailList = new ArrayList();
            ArrayList manipulatedPDList = new ArrayList();
            double discountPercent = 0;
            int patientPercent = 0;
            int payerPercent = 0;
            double discountedPrice = 0;
            TTObjectContext context = new TTObjectContext(false);

            ProtocolExceptionMaterialDefinition pexc = GetProtocolExceptionMaterialDefinition(pMaterial);
            if (pexc != null)
            {
                if ((pexc.PatientPrice != 0) || (pexc.PayerPrice != 0))
                {
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pexc.Material.Code;
                    mypd.Description = pexc.Material.Name;
                    mypd.Price = (double)pexc.PatientPrice + (double)pexc.PayerPrice;
                    mypd.PatientPrice = pexc.PatientPrice;
                    mypd.PayerPrice = pexc.PayerPrice;

                    manipulatedPDList.Add(mypd);
                    return manipulatedPDList;
                }
                else
                {
                    if (pSubActionDate == null)
                        pricingDetailList = pMaterial.GetMaterialPricingDetail(pPricingList);
                    else
                        pricingDetailList = pMaterial.GetMaterialPricingDetail(pexc.PricingList, pSubActionDate);

                    foreach (PricingDetailDefinition pp in pricingDetailList)
                    {
                        ManipulatedPrice mypd = new ManipulatedPrice(context);
                        mypd.ExternalCode = pp.ExternalCode;
                        mypd.Description = pp.Description;
                        mypd.Price = pp.Price;

                        if (pPatientStatus == PatientStatusEnum.Outpatient)
                        {
                            discountPercent = (double)pexc.OutPatientDiscountPercent;
                            patientPercent = (int)pexc.OutPatientPatientPercent;
                            payerPercent = (int)pexc.OutPatientPayerPercent;
                        }
                        else
                        {
                            discountPercent = (double)pexc.InPatientDiscountPercent;
                            patientPercent = (int)pexc.InPatientPatientPercent;
                            payerPercent = (int)pexc.InPatientPayerPercent;
                        }
                        if (discountPercent > 100)
                            discountedPrice = Math.Round((double)pp.Price * (discountPercent / 100), 8);
                        else
                            discountedPrice = Math.Round((double)pp.Price * (1 - (discountPercent / 100)), 8);

                        mypd.Price = discountedPrice;
                        mypd.PatientPrice = (double)((patientPercent * discountedPrice) / 100);
                        mypd.PayerPrice = (double)((payerPercent * discountedPrice) / 100);
                        mypd.PricingDetailDefinition = pp;

                        manipulatedPDList.Add(mypd);
                    }

                    // Hiç fiyat eşleşmesi olmayan malzemelere 0(sıfır) fiyat oluşturması için
                    if (manipulatedPDList.Count == 0)
                    {
                        ManipulatedPrice mp = new ManipulatedPrice(context);
                        mp.ExternalCode = pMaterial.Code;
                        mp.Description = pMaterial.Name;
                        mp.Price = 0;
                        mp.PatientPrice = 0;
                        mp.PayerPrice = 0;
                        manipulatedPDList.Add(mp);
                    }

                    return manipulatedPDList;
                }
            }

            prtDetail = (ProtocolDetailMaterialDefinition)GetProtocolDetailMaterialDefinition(pMaterial);
            if (prtDetail != null)
            {
                if (pSubActionDate == null)
                    pricingDetailList = pMaterial.GetMaterialPricingDetail(pPricingList);
                else
                    pricingDetailList = pMaterial.GetMaterialPricingDetail(prtDetail.PricingList, pSubActionDate);

                foreach (PricingDetailDefinition pp in pricingDetailList)
                {
                    ManipulatedPrice mypd = new ManipulatedPrice(context);
                    mypd.ExternalCode = pp.ExternalCode;
                    mypd.Description = pp.Description;
                    mypd.Price = pp.Price;

                    if (pPatientStatus == PatientStatusEnum.Outpatient)
                    {
                        discountPercent = (double)prtDetail.OutPatientDiscountPercent;
                        patientPercent = (int)prtDetail.OutPatientPatientPercent;
                        payerPercent = (int)prtDetail.OutPatientPayerPercent;
                    }
                    else
                    {
                        discountPercent = (double)prtDetail.InPatientDiscountPercent;
                        patientPercent = (int)prtDetail.InPatientPatientPercent;
                        payerPercent = (int)prtDetail.InPatientPayerPercent;
                    }

                    if (discountPercent > 100)
                        discountedPrice = Math.Round((double)pp.Price * (discountPercent / 100), 8);
                    else
                        discountedPrice = Math.Round((double)pp.Price * (1 - (discountPercent / 100)), 8);

                    mypd.Price = discountedPrice;
                    mypd.PatientPrice = (double)((patientPercent * discountedPrice) / 100);
                    mypd.PayerPrice = (double)((payerPercent * discountedPrice) / 100);
                    mypd.PricingDetailDefinition = pp;

                    manipulatedPDList.Add(mypd);
                }

                // Hiç fiyat eşleşmesi olmayan malzemelere 0(sıfır) fiyat oluşturması için
                if (manipulatedPDList.Count == 0)
                {
                    ManipulatedPrice mp = new ManipulatedPrice(context);
                    mp.ExternalCode = pMaterial.Code;
                    mp.Description = pMaterial.Name;
                    mp.Price = 0;
                    mp.PatientPrice = 0;
                    mp.PayerPrice = 0;
                    manipulatedPDList.Add(mp);
                }

                return manipulatedPDList;
            }
            else
                throw new TTException(SystemMessage.GetMessageV3(589, new string[] { Name, pMaterial.Code, pMaterial.Name }));
        }

        private ArrayList CalculateMaterialPrice(Material pMaterial, PatientStatusEnum? ppPatientStatus, PricingListDefinition pPricingList)
        {
            return CalculateMaterialPrice(pMaterial, ppPatientStatus, null, pPricingList);
        }

        private ArrayList CalculateMaterialPrice(Material pMaterial, PatientStatusEnum? ppPatientStatus, DateTime? pSubActionDate)
        {
            return CalculateMaterialPrice(pMaterial, ppPatientStatus, pSubActionDate, null);
        }

        public ProtocolDetailProcedureDefinition GetProtocolDetailProcedureDefinition(ProcedureDefinition pProcedure)
        {
            bool notFound = true;
            IList pDetailProcedures = null;
            ProcedureTreeDefinition parentProcedureTree;
            TTObjectContext context = new TTObjectContext(true);
            parentProcedureTree = (ProcedureTreeDefinition)pProcedure.ProcedureTree;

            while (notFound)
            {
                pDetailProcedures = ProtocolDetailProcedureDefinition.GetByProtocolAndProcedureTree(context, ObjectID.ToString(), parentProcedureTree.ObjectID.ToString());
                if (pDetailProcedures.Count == 0)
                {
                    parentProcedureTree = (ProcedureTreeDefinition)parentProcedureTree.ParentID;
                    if (parentProcedureTree == null)
                        break;
                }
                else
                    notFound = false;
            }

            if (notFound)
                return null;
            else
                return (ProtocolDetailProcedureDefinition)pDetailProcedures[0];
        }

        public ProtocolDetailProcedureDefinition GetProtocolDetailProcedureDefinition(ProcedureDefinition pProcedure, int? patientAge)
        {
            IList pDetailProcedures = null;
            ProcedureTreeDefinition parentProcedureTree;
            TTObjectContext context = new TTObjectContext(true);
            parentProcedureTree = (ProcedureTreeDefinition)pProcedure.ProcedureTree;

            while (true)
            {
                pDetailProcedures = ProtocolDetailProcedureDefinition.GetByProtocolAndProcedureTree(context, ObjectID.ToString(), parentProcedureTree.ObjectID.ToString());
                foreach (ProtocolDetailProcedureDefinition protDetailProcedure in pDetailProcedures)
                {
                    if (patientAge == null || (protDetailProcedure.StartAge == null && protDetailProcedure.EndAge == null))
                        return protDetailProcedure;
                    else if (protDetailProcedure.StartAge <= patientAge && protDetailProcedure.EndAge >= patientAge)
                        return protDetailProcedure;
                }

                parentProcedureTree = (ProcedureTreeDefinition)parentProcedureTree.ParentID;
                if (parentProcedureTree == null)
                    break;
            }
            return null;
        }

        private ProtocolDetailMaterialDefinition GetProtocolDetailMaterialDefinition(Material pMaterial)
        {
            bool notFound = true;
            IList pDetailMaterials = null;
            MaterialTreeDefinition parentMaterialTree;
            TTObjectContext context = new TTObjectContext(true);
            parentMaterialTree = (MaterialTreeDefinition)pMaterial.MaterialTree;

            while (notFound)
            {
                pDetailMaterials = ProtocolDetailMaterialDefinition.GetByProtocolAndMaterialTree(context, ObjectID.ToString(), parentMaterialTree.ObjectID.ToString());
                if (pDetailMaterials.Count == 0)
                {
                    parentMaterialTree = (MaterialTreeDefinition)parentMaterialTree.ParentMaterialTree;
                    if (parentMaterialTree == null)
                        break;
                }
                else
                    notFound = false;
            }

            if (notFound)
                return null;
            else
                return (ProtocolDetailMaterialDefinition)pDetailMaterials[0];
        }

        public ProtocolExceptionProcedureDefinition GetProtocolExceptionProcedureDefinition(ProcedureDefinition procedure)
        {
            IList exceptionProcedureList = ObjectContext.QueryObjects<ProtocolExceptionProcedureDefinition>("PROTOCOL = " + ConnectionManager.GuidToString(ObjectID) + " AND PROCEDUREOBJECT = " + ConnectionManager.GuidToString(procedure.ObjectID));
            foreach (ProtocolExceptionProcedureDefinition exceptionProcedure in exceptionProcedureList)
            {
                return exceptionProcedure;
            }
            return null;
        }

        public ProtocolExceptionProcedureDefinition GetProtocolExceptionProcedureDefinition(ProcedureDefinition procedure, int? patientAge)
        {
            IList exceptionProcedureList = ObjectContext.QueryObjects<ProtocolExceptionProcedureDefinition>("PROTOCOL = " + ConnectionManager.GuidToString(ObjectID) + " AND PROCEDUREOBJECT = " + ConnectionManager.GuidToString(procedure.ObjectID));
            foreach (ProtocolExceptionProcedureDefinition exceptionProcedure in exceptionProcedureList)
            {
                if (patientAge == null || (exceptionProcedure.StartAge == null && exceptionProcedure.EndAge == null))
                    return exceptionProcedure;
                else if (exceptionProcedure.StartAge <= patientAge && exceptionProcedure.EndAge >= patientAge)
                    return exceptionProcedure;
            }
            return null;
        }

        public ProtocolExceptionMaterialDefinition GetProtocolExceptionMaterialDefinition(Material material)
        {
            IList exceptionMaterialList = ProtocolExceptionMaterialDefinition.GetByProtocolAndMaterial(ObjectContext, ObjectID.ToString(), material.ObjectID.ToString());
            foreach (ProtocolExceptionMaterialDefinition exceptionMaterial in exceptionMaterialList)
            {
                return exceptionMaterial;
            }
            return null;
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ProtocolDefinitionInfo;
        }

        public double GetPrice(TTObject pObject, PatientStatusEnum? ppPatientStatus, PackageDefinition pPackageDef, DateTime? pSubActDate, PricingListDefinition pPricingList, int? patientAge, bool onlyPatientPrice)
        {
            double price = 0;
            try
            {
                ArrayList col = new ArrayList();
                col = CalculatePrice(pObject, ppPatientStatus, pPackageDef, pSubActDate, pPricingList, patientAge);

                if (col != null && col.Count > 0)
                {
                    foreach (ManipulatedPrice mpd in col)
                    {
                        if (onlyPatientPrice)
                            price += Convert.ToDouble(mpd.PatientPrice);
                        else
                            price += Convert.ToDouble(mpd.PatientPrice) + Convert.ToDouble(mpd.PayerPrice);
                    }
                }
            }
            catch (Exception ex)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(ex.Message);
            }

            return price;
        }



        #endregion Methods

    }
}