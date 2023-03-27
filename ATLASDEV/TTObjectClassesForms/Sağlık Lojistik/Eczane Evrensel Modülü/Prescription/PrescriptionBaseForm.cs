
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// PrescriptionBaseForm
    /// </summary>
    public partial class PrescriptionBaseForm : ActionForm
    {
#region PrescriptionBaseForm_ClientSideMethods
        public static object  GetEReceteSignedDelete(Prescription pres)
        {
        //            EReceteIslemleri.ereceteSilIstekDVO eReceteDelete = Prescription.GetEReceteDelete(pres);
        //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteDelete);
        //            imzalanacakXml = imzalanacakXml.Replace("ereceteSilIstekDVO", "imzaliEreceteSilBilgisi");
        //
        //            byte[] signedContent = CommonForm.SignContent("E-Reçete Sil İçerik İmzalama", imzalanacakXml);
        //            if ( signedContent == null )
        //                throw new TTException("E-Reçete silme içeriği imzalanamadı");
        //
        //            EReceteIslemleri.imzaliEreceteSilIstekDVO eReceteSignedDelete = new EReceteIslemleri.imzaliEreceteSilIstekDVO();
        //            eReceteSignedDelete.doktorTcKimlikNo = eReceteDelete.doktorTcKimlikNo.ToString();
        //            eReceteSignedDelete.imzaliEreceteSil = signedContent;
        //            eReceteSignedDelete.surumNumarasi = "1";
        //            eReceteSignedDelete.tesisKodu = eReceteDelete.tesisKodu.ToString();
        //            return eReceteSignedDelete;

         throw  new NotImplementedException();
        }
        
        
        public static object GetEReceteSignedInputRequest(Prescription pres)
        {
            // Medula imzalı ereçete giriş bilgisi olarak
            // normal e-reçete giriş istek DVO'sunu kabul etmiyor
            // Gerekli değişiklikler aşağıdaki gibi olmalı
            //            TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO istekGiris = Prescription.GetEReceteInputRequest(pres);
            //            string imzalanacakXml = Common.SerializeObjectToXml(istekGiris.ereceteDVO);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteDVO", "ereceteBilgisi");
            //            imzalanacakXml = imzalanacakXml.Replace("kisiDVO", "kisiBilgisi");
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteAciklamaListesi", "ereceteAciklamaBilgisi");
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacListesi", "ereceteIlacBilgisi");
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteTaniListesi", "ereceteTaniBilgisi");
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteIlacAciklamaListesi", "ereceteIlacAciklamaBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-reçete İçerik İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-Reçete giriş içeriği imzalanamadı");
//
            //            pres.IsSigned = true;
            //            pres.SignedData = signedContent;
//
            //            TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO istekImzali = new TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO();
            //            istekImzali.doktorTcKimlikNo = istekGiris.doktorTcKimlikNo;
            //            istekImzali.tesisKodu = istekGiris.tesisKodu;
            //            istekImzali.imzaliErecete = signedContent;
            //            istekImzali.surumNumarasi = 1;
            //            return istekImzali;
            throw new  NotImplementedException();
        }
        
        public static object GetEreceteSignedApprovalRequest(Prescription pres)
        {
            //            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = Prescription.GetEreceteApprovalRequest(pres);
            //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalRequest);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-reçete Onay İstek İçeriği İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-reçete onay istek içeriği imzalanamadı");
//
            //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
            //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
            //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
            //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
            //            eReceteSignedApprovalRequest.surumNumarasi = "1";
            //            return eReceteSignedApprovalRequest;
//
            throw new NotImplementedException();
        }
        public static object GetEreceteSignedApprovalCancelRequest(Prescription pres)
        {
            //            EReceteIslemleri.ereceteOnayIptalIstekDVO eReceteApprovalCancelRequest = Prescription.GetEreceteApprovalCancelRequest(pres);
            //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalCancelRequest);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIptalIstekDVO", "imzaliEreceteOnayIptalBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-Reçete Onay İstek İptal İçeriği İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
//
            //            EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO eReceteSignedApprovalCancelRequest = new EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO();
            //            eReceteSignedApprovalCancelRequest.doktorTcKimlikNo = eReceteApprovalCancelRequest.doktorTcKimlikNo.ToString();
            //            eReceteSignedApprovalCancelRequest.imzaliEreceteOnayIptal = signedContent;
            //            eReceteSignedApprovalCancelRequest.surumNumarasi = "1";
            //            eReceteSignedApprovalCancelRequest.tesisKodu = eReceteApprovalCancelRequest.tesisKodu.ToString();
            //            return eReceteSignedApprovalCancelRequest;

             throw  new NotImplementedException();
        }
        public static object GetEreceteSignedEHUApprovalRequest(Prescription pres, long UniqueRefNo)
        {
            //            EReceteIslemleri.ereceteOnayIstekDVO eReceteApprovalRequest = Prescription.GetEreceteEHUApprovalRequest(pres, UniqueRefNo);
            //            string imzalanacakXml = Common.SerializeObjectToXml(eReceteApprovalRequest);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-Reçete EHU Onay İstek İçeriği İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
//
            //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
            //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
            //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
            //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
            //            eReceteSignedApprovalRequest.surumNumarasi = "1";
            //            return eReceteSignedApprovalRequest;
             throw new NotImplementedException();
        }
        
        public static object GetEreceteSignedEHUCancelRequest(Prescription pres, long UniqueRefNo)
        {
            //            EReceteIslemleri.ereceteOnayIptalIstekDVO ereceteEHUCancelRequest = Prescription.GetEreceteEHUCancelRequest(pres, UniqueRefNo);
            //            string imzalanacakXml = Common.SerializeObjectToXml(ereceteEHUCancelRequest);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIptalIstekDVO", "imzaliEreceteOnayIptalBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-Reçete EHU Onay İstek İçeriği İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
//
            //            EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO ereceteSignedEHUCancelRequest = new EReceteIslemleri.imzaliEreceteOnayIptalIstekDVO();
            //            ereceteSignedEHUCancelRequest.doktorTcKimlikNo = ereceteEHUCancelRequest.doktorTcKimlikNo.ToString();
            //            ereceteSignedEHUCancelRequest.imzaliEreceteOnayIptal = signedContent;
            //            ereceteSignedEHUCancelRequest.surumNumarasi = "1";
            //            ereceteSignedEHUCancelRequest.tesisKodu = ereceteEHUCancelRequest.tesisKodu.ToString();
            //            return ereceteSignedEHUCancelRequest;
             throw  new NotImplementedException();
        }
        
        public static object GetEreceteSignedDailyPresApprovalRequest(Prescription pres, long UniqueRefNo)
        {
            //            EReceteIslemleri.ereceteOnayIstekDVO ereceteDailyPresApprovalRequest = Prescription.GetEreceteDailyPresApprovalRequest(pres, UniqueRefNo);
            //            string imzalanacakXml = Common.SerializeObjectToXml(ereceteDailyPresApprovalRequest);
            //            imzalanacakXml = imzalanacakXml.Replace("ereceteOnayIstekDVO", "imzaliEreceteOnayBilgisi");
//
            //            byte[] signedContent = CommonForm.SignContent("E-Reçete Onay İstek İçeriği İmzalama", imzalanacakXml);
            //            if ( signedContent == null )
            //                throw new TTException("E-reçete EHU onay istek içeriği imzalanamadı");
//
            //            EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
            //            long drKimlikNo = pres.ProcedureDoctor.Person.UniqueRefNo != null ? pres.ProcedureDoctor.Person.UniqueRefNo.Value : 00000000000;
            //            long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            //            eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
            //            eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
            //            eReceteSignedApprovalRequest.imzaliEreceteOnay = signedContent;
            //            eReceteSignedApprovalRequest.surumNumarasi = "1";
            //            return eReceteSignedApprovalRequest;
             throw new NotImplementedException();
        }
        
#endregion PrescriptionBaseForm_ClientSideMethods
    }
}