
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
    public partial class PrescriptionESignForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnSaveSignedContent.Click += new TTControlEventDelegate(btnSaveSignedContent_Click);
            btnCancel.Click += new TTControlEventDelegate(btnCancel_Click);
            btnSignPrescription.Click += new TTControlEventDelegate(btnSignPrescription_Click);
            btnShowSignCertificate.Click += new TTControlEventDelegate(btnShowSignCertificate_Click);
            btnSelectSignCertificate.Click += new TTControlEventDelegate(btnSelectSignCertificate_Click);
            btnSendMedula.Click += new TTControlEventDelegate(btnSendMedula_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnSaveSignedContent.Click -= new TTControlEventDelegate(btnSaveSignedContent_Click);
            btnCancel.Click -= new TTControlEventDelegate(btnCancel_Click);
            btnSignPrescription.Click -= new TTControlEventDelegate(btnSignPrescription_Click);
            btnShowSignCertificate.Click -= new TTControlEventDelegate(btnShowSignCertificate_Click);
            btnSelectSignCertificate.Click -= new TTControlEventDelegate(btnSelectSignCertificate_Click);
            btnSendMedula.Click -= new TTControlEventDelegate(btnSendMedula_Click);
            base.UnBindControlEvents();
        }

        private void btnSaveSignedContent_Click()
        {
            #region PrescriptionESignForm_btnSaveSignedContent_Click
            //
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.DefaultExt = "xml";
            //saveFileDialog.Filter = "Xml dosyaları (*.xml)|*.xml";
            //DialogResult dialogResult = saveFileDialog.ShowDialog();
            //if (dialogResult == DialogResult.OK)
            //{
            //    if ( _signedContent != null )
            //       System.IO.File.WriteAllBytes(saveFileDialog.FileName, _signedContent);
            //}
            var a = 1;
            #endregion PrescriptionESignForm_btnSaveSignedContent_Click
        }

        private void btnCancel_Click()
        {
#region PrescriptionESignForm_btnCancel_Click
   this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion PrescriptionESignForm_btnCancel_Click
        }

        private void btnSignPrescription_Click()
        {
#region PrescriptionESignForm_btnSignPrescription_Click
   try
            {
                _signedContent = null;
                txtSignedContent.Text = string.Empty;
                
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
                _signedContent = buffer;
                txtSignedContent.Text = System.Text.Encoding.Default.GetString(buffer);
                
                DialogResult result = MessageBox.Show("İmzalanmış içeriği dosyaya kaydetmek ister misiniz", "İmzalı İçerik Kaydı...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    //SaveFileDialog saveFileDialog = new SaveFileDialog();
                    //saveFileDialog.DefaultExt = "xml";
                    //saveFileDialog.Filter = "Xml dosyaları (*.xml)|*.xml";
                    //DialogResult dialogResult = saveFileDialog.ShowDialog();
                    //if (dialogResult == DialogResult.OK)
                    //{
                    //    System.IO.File.WriteAllBytes(saveFileDialog.FileName, buffer);
                    //}
                }
                
                InfoBox.Show("Elektronik İmza işlemi başarılı olarak tamamlandı", MessageIconEnum.InformationMessage);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion PrescriptionESignForm_btnSignPrescription_Click
        }

        private void btnShowSignCertificate_Click()
        {
#region PrescriptionESignForm_btnShowSignCertificate_Click
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
#endregion PrescriptionESignForm_btnShowSignCertificate_Click
        }

        private void btnSelectSignCertificate_Click()
        {
#region PrescriptionESignForm_btnSelectSignCertificate_Click
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
                
                smartCardManager.ClearSignCertificate();
                byte[] signCertificate = smartCardManager.GetSignCertificate();
                if ( signCertificate == null )
                {
                    InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
                    return;
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion PrescriptionESignForm_btnSelectSignCertificate_Click
        }

        private void btnSendMedula_Click()
        {
#region PrescriptionESignForm_btnSendMedula_Click
   try
            {
                txtSignedContent.Text = string.Empty;
                _signedContent = null;
                
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
                _signedContent = buffer;
                txtSignedContent.Text = System.Text.Encoding.Default.GetString(buffer);
                
                TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO istekImzali = new TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisIstekDVO();
                istekImzali.doktorTcKimlikNo = _istekGiris.doktorTcKimlikNo;
                istekImzali.tesisKodu = _istekGiris.tesisKodu;
                istekImzali.imzaliErecete = buffer;
                TTObjectClasses.EReceteIslemleri.imzaliEreceteGirisCevapDVO cevap = EReceteIslemleri.WebMethods.imzaliEreceteGirisSync(Sites.SiteLocalHost, Common.CurrentResource.UniqueNo.ToString(), _Prescription.ERecetePassword, istekImzali);
                string mesaj = string.Format("{0}-{1}", cevap.sonucKodu, cevap.sonucMesaji);
                InfoBox.Show(mesaj, MessageIconEnum.InformationMessage);
                if ( cevap.sonucKodu == "0000" )
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion PrescriptionESignForm_btnSendMedula_Click
        }

#region PrescriptionESignForm_Methods
        //
        private Prescription _Prescription;
        private TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO _istekGiris;
        private byte[] _signedContent;
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
        
#endregion PrescriptionESignForm_Methods
    }
}