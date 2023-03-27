
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
    public partial class ContentSignForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            //btnSignContent.Click += new TTControlEventDelegate(btnSignContent_Click);
            //btnShowSignCertificate.Click += new TTControlEventDelegate(btnShowSignCertificate_Click);
            //btnCancel.Click += new TTControlEventDelegate(btnCancel_Click);
            //btnSelectSignCertificate.Click += new TTControlEventDelegate(btnSelectSignCertificate_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //btnSignContent.Click -= new TTControlEventDelegate(btnSignContent_Click);
            //btnShowSignCertificate.Click -= new TTControlEventDelegate(btnShowSignCertificate_Click);
            //btnCancel.Click -= new TTControlEventDelegate(btnCancel_Click);
            //btnSelectSignCertificate.Click -= new TTControlEventDelegate(btnSelectSignCertificate_Click);
            base.UnBindControlEvents();
        }

        private void btnSignContent_Click()
        {
#region ContentSignForm_btnSignContent_Click
   //try
   //         {
   //             this.btnSignContent.Enabled = false;
   //             Application.DoEvents();
   //             ISmartCardManager smartCardManager = TTUtils.SmartCardManagerFactory.Instance;
   //             bool loginRequired = true;
   //             if ( smartCardManager.IsCardSelected && smartCardManager.LastLoginTime.HasValue )
   //             {
   //                 TimeSpan loginDiff = DateTime.Now - smartCardManager.LastLoginTime.Value;
   //                 string smartCardSessionTimeout = TTObjectClasses.SystemParameter.GetParameterValue("SmartCardSessionTimeout", "180");
   //                 int sessionTimeout = 180;
   //                 int.TryParse(smartCardSessionTimeout, out sessionTimeout);
   //                 if ( loginDiff.TotalMinutes < sessionTimeout )
   //                 {
   //                     loginRequired = false;
   //                 }
   //             }
                
   //             if ( loginRequired )
   //             {
   //                 TTFormClasses.SmartCardLoginForm smartCardLoginForm = new TTFormClasses.SmartCardLoginForm();
   //                 smartCardLoginForm.ShowDialog(this.FindForm());
   //                 if ( smartCardLoginForm.DialogResult == DialogResult.Cancel )
   //                 {
   //                     this.btnSignContent.Enabled = true;
   //                     return;
   //                 }
   //             }
                
   //             byte[] signCertificate = smartCardManager.GetSignCertificate();
   //             if ( signCertificate == null )
   //             {
   //                 InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
   //                 return;
   //             }
                
   //             TTUtils.IESignatureManager signatureManager = TTUtils.ESignatureManagerFactory.Instance;
                
   //             TTUtils.ICertValidationResult validationResult = signatureManager.IsValidCertificate(signCertificate);
   //             if ( !validationResult.IsValidationSuccess )
   //             {
   //                 InfoBox.Show("E-İmza sertifikası doğrulanamadı: " + validationResult.ValidationResult, MessageIconEnum.WarningMessage);
   //                 this.btnSignContent.Enabled = true;
   //                 return;
   //             }
                
   //             byte[] buffer = signatureManager.SignXmlToByte(smartCardManager, txtContentForSign.Text);
   //             this.SignedContent = buffer;
   //             this.DialogResult = DialogResult.OK;
   //             this.Close();
   //         }
   //         catch(Exception ex)
   //         {
   //             InfoBox.Show(ex);
   //             this.btnSignContent.Enabled = true;
   //             Application.DoEvents();
   //         }
#endregion ContentSignForm_btnSignContent_Click
        }

        private void btnShowSignCertificate_Click()
        {
#region ContentSignForm_btnShowSignCertificate_Click
   //try
   //         {
   //             ISmartCardManager smartCardManager = TTUtils.SmartCardManagerFactory.Instance;
   //             bool loginRequired = true;
   //             if ( smartCardManager.IsCardSelected && smartCardManager.LastLoginTime.HasValue )
   //             {
   //                 TimeSpan loginDiff = DateTime.Now - smartCardManager.LastLoginTime.Value;
   //                 string smartCardSessionTimeout = TTObjectClasses.SystemParameter.GetParameterValue("SmartCardSessionTimeout", "180");
   //                 int sessionTimeout = 180;
   //                 int.TryParse(smartCardSessionTimeout, out sessionTimeout);
   //                 if ( loginDiff.TotalMinutes < sessionTimeout )
   //                 {
   //                     loginRequired = false;
   //                 }
   //             }
                
   //             if ( loginRequired )
   //             {
   //                 TTFormClasses.SmartCardLoginForm smartCardLoginForm = new TTFormClasses.SmartCardLoginForm();
   //                 smartCardLoginForm.ShowDialog(this.FindForm());
   //                 if ( smartCardLoginForm.DialogResult == DialogResult.Cancel )
   //                     return;
   //             }
                
   //             byte[] signCertificate = smartCardManager.GetSignCertificate();
   //             if ( signCertificate == null )
   //             {
   //                 InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
   //                 return;
   //             }
   //             smartCardManager.DisplayCertificate(signCertificate);
   //         }
   //         catch(Exception ex)
   //         {
   //             InfoBox.Show(ex);
   //         }
#endregion ContentSignForm_btnShowSignCertificate_Click
        }

        private void btnCancel_Click()
        {
#region ContentSignForm_btnCancel_Click
   //this.DialogResult = DialogResult.Cancel;
   //         this.Close();
#endregion ContentSignForm_btnCancel_Click
        }

        private void btnSelectSignCertificate_Click()
        {
#region ContentSignForm_btnSelectSignCertificate_Click
   //try
   //         {
   //             ISmartCardManager smartCardManager = TTUtils.SmartCardManagerFactory.Instance;
   //             bool loginRequired = true;
   //             if ( smartCardManager.IsCardSelected && smartCardManager.LastLoginTime.HasValue )
   //             {
   //                 TimeSpan loginDiff = DateTime.Now - smartCardManager.LastLoginTime.Value;
   //                 string smartCardSessionTimeout = TTObjectClasses.SystemParameter.GetParameterValue("SmartCardSessionTimeout", "180");
   //                 int sessionTimeout = 180;
   //                 int.TryParse(smartCardSessionTimeout, out sessionTimeout);
   //                 if ( loginDiff.TotalMinutes < sessionTimeout )
   //                 {
   //                     loginRequired = false;
   //                 }
   //             }
                
   //             if ( loginRequired )
   //             {
   //                 TTFormClasses.SmartCardLoginForm smartCardLoginForm = new TTFormClasses.SmartCardLoginForm();
   //                 smartCardLoginForm.ShowDialog(this.FindForm());
   //                 if ( smartCardLoginForm.DialogResult == DialogResult.Cancel )
   //                     return;
   //             }
                
   //             smartCardManager.ClearSignCertificate();
   //             byte[] signCertificate = smartCardManager.GetSignCertificate();
   //             if ( signCertificate == null )
   //             {
   //                 InfoBox.Show("E-İmza sertifikası akıllı karttan alınamadı", MessageIconEnum.WarningMessage);
   //                 return;
   //             }
   //         }
   //         catch(Exception ex)
   //         {
   //             InfoBox.Show(ex);
   //         }
#endregion ContentSignForm_btnSelectSignCertificate_Click
        }

#region ContentSignForm_Methods
        //
        private string InputContent;
        public byte[] SignedContent;
        
        public void SetContent(string content)
        {
            InputContent = content;
            txtContentForSign.Text = content;
        }
        
        public void SetHeader(string header)
        {
            this.Text = header;
        }
        
#endregion ContentSignForm_Methods
    }
}