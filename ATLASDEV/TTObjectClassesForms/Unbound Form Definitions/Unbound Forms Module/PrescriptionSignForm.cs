
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
    /// E-Reçete Elektronik İmza
    /// </summary>
    public partial class PrescriptionSignForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnSignPrescription.Click += new TTControlEventDelegate(btnSignPrescription_Click);
            btnShowSignCertificate.Click += new TTControlEventDelegate(btnShowSignCertificate_Click);
            btnCancel.Click += new TTControlEventDelegate(btnCancel_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnSignPrescription.Click -= new TTControlEventDelegate(btnSignPrescription_Click);
            btnShowSignCertificate.Click -= new TTControlEventDelegate(btnShowSignCertificate_Click);
            btnCancel.Click -= new TTControlEventDelegate(btnCancel_Click);
            base.UnBindControlEvents();
        }

        private void btnSignPrescription_Click()
        {
#region PrescriptionSignForm_btnSignPrescription_Click
   try
            {
                ISmartCardManager smartCardManager = TTUtils.SmartCardManagerFactory.Instance;
                bool loginRequired = true;
                if ( smartCardManager.IsCardSelected && smartCardManager.LastLoginTime.HasValue )
                {
                    TimeSpan loginDiff = DateTime.Now - smartCardManager.LastLoginTime.Value;
                    string smartCardSessionTimeout = TTObjectClasses.SystemParameter.GetParameterValue("SmartCardSessionTimeout", "180");
                    int sessionTimeout = 180;
                    int.TryParse(smartCardSessionTimeout, out sessionTimeout);
                    if ( loginDiff.TotalMinutes < sessionTimeout )
                    {
                        loginRequired = false;
                    }
                }
                
                if ( loginRequired )
                {
                    TTFormClasses.SmartCardLoginForm smartCardLoginForm = new TTFormClasses.SmartCardLoginForm();
                    smartCardLoginForm.ShowDialog(this.FindForm());
                    if ( smartCardLoginForm.DialogResult == DialogResult.Cancel )
                        return;
                }
                
                byte[] signCertificate = smartCardManager.GetSignCertificate();
                if ( signCertificate == null )
                {
                    InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
                    return;
                }
                
                TTUtils.IESignatureManager signatureManager = TTUtils.ESignatureManagerFactory.Instance;
                
                TTUtils.ICertValidationResult validationResult = signatureManager.IsValidCertificate(signCertificate);
                if ( !validationResult.IsValidationSuccess )
                {
                    InfoBox.Show("E-İmza sertifikası doğrulanamadı: " + validationResult.ValidationResult, MessageIconEnum.WarningMessage);
                    return;
                }
                
                byte[] buffer = signatureManager.SignXmlToByte(smartCardManager, txtContentForSign.Text);
                TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO istekImzali = new TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO();
                istekImzali.doktorTcKimlikNo = _istekGiris.doktorTcKimlikNo;
                istekImzali.tesisKodu = _istekGiris.tesisKodu;
                istekImzali.imzaliErecete = buffer;
                _cevap = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), _Prescription.ERecetePassword, istekImzali);
                if ( _cevap.sonucKodu == "0000" )
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    StringBuilder mesaj = new StringBuilder();
                    mesaj.AppendLine("İmzalı E-reçete girişi yapılamadı");
                    mesaj.AppendFormat("{0}-{1}", _cevap.sonucKodu, _cevap.sonucMesaji);
                    if ( !string.IsNullOrEmpty(_cevap.uyariMesaji) )
                    {
                        mesaj.AppendLine();
                        mesaj.AppendFormat("Uyarı Mesajı: {0}", _cevap.uyariMesaji);
                    }
                    InfoBox.Show(mesaj.ToString());
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion PrescriptionSignForm_btnSignPrescription_Click
        }

        private void btnShowSignCertificate_Click()
        {
#region PrescriptionSignForm_btnShowSignCertificate_Click
   try
            {
                ISmartCardManager smartCardManager = TTUtils.SmartCardManagerFactory.Instance;
                bool loginRequired = true;
                if ( smartCardManager.IsCardSelected && smartCardManager.LastLoginTime.HasValue )
                {
                    TimeSpan loginDiff = DateTime.Now - smartCardManager.LastLoginTime.Value;
                    string smartCardSessionTimeout = TTObjectClasses.SystemParameter.GetParameterValue("SmartCardSessionTimeout", "180");
                    int sessionTimeout = 180;
                    int.TryParse(smartCardSessionTimeout, out sessionTimeout);
                    if ( loginDiff.TotalMinutes < sessionTimeout )
                    {
                        loginRequired = false;
                    }
                }
                
                if ( loginRequired )
                {
                    TTFormClasses.SmartCardLoginForm smartCardLoginForm = new TTFormClasses.SmartCardLoginForm();
                    smartCardLoginForm.ShowDialog(this.FindForm());
                    if ( smartCardLoginForm.DialogResult == DialogResult.Cancel )
                        return;
                }
                
                byte[] signCertificate = smartCardManager.GetSignCertificate();
                if ( signCertificate == null )
                {
                    InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
                    return;
                }
                smartCardManager.DisplayCertificate(signCertificate);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion PrescriptionSignForm_btnShowSignCertificate_Click
        }

        private void btnCancel_Click()
        {
#region PrescriptionSignForm_btnCancel_Click
   this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion PrescriptionSignForm_btnCancel_Click
        }

#region PrescriptionSignForm_Methods
        // Reçete Elektronik imza ekranı
        private Prescription _Prescription;
        public TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO _istekGiris;
        public TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisCevapDVO _cevap;
        public void SetPrescriptionContent(Prescription prescription)
        {
            _Prescription = prescription;
            _istekGiris = Prescription.GetEReceteInputRequest(prescription);
            string imzalanacakReceteXml = Common.SerializeObjectToXml(_istekGiris.ereceteDVO);
            imzalanacakReceteXml = imzalanacakReceteXml.Replace("ereceteDVO", "ereceteBilgisi");
            imzalanacakReceteXml = imzalanacakReceteXml.Replace("kisiDVO", "kisiBilgisi");
            imzalanacakReceteXml = imzalanacakReceteXml.Replace("ereceteIlacListesi", "ereceteIlacBilgisi");
            imzalanacakReceteXml = imzalanacakReceteXml.Replace("ereceteTaniListesi", "ereceteTaniBilgisi");
            txtContentForSign.Text = imzalanacakReceteXml;
        }
        
#endregion PrescriptionSignForm_Methods
    }
}