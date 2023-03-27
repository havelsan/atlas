
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
    /// OutPatientPrescriptionBaseForm
    /// </summary>
    public partial class OutPatientPrescriptionBaseForm : PrescriptionBaseForm
    {
        override protected void BindControlEvents()
        {
            DigitalSignatureButton.Click += new TTControlEventDelegate(DigitalSignatureButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DigitalSignatureButton.Click -= new TTControlEventDelegate(DigitalSignatureButton_Click);
            base.UnBindControlEvents();
        }

        private void DigitalSignatureButton_Click()
        {
#region OutPatientPrescriptionBaseForm_DigitalSignatureButton_Click
   if (TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration)
            {
                if (this._OutPatientPrescription.SignedData != null)
                {
                    DigitalPrescriptionForm digitalPrescriptionForm = new DigitalPrescriptionForm();
                    InfoBox.Show("digitalPrescriptionForm.ShowDialog(this);");
                }
            }
#endregion OutPatientPrescriptionBaseForm_DigitalSignatureButton_Click
        }

        protected override void PreScript()
        {
#region OutPatientPrescriptionBaseForm_PreScript
    base.PreScript();

            if (TTObjectClasses.SystemParameter.IsDigitalSignatureIntegration)
            {
                if (this._OutPatientPrescription.SignedData != null)
                {
                    this.DigitalSignatureButton.Visible = true;

                    ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                    if (resUser == null)
                        throw new TTException(SystemMessage.GetMessage(1208));

                    Prescription.DigitalSignedPrescription digitalSignedPrescription = TTUtils.SerializationHelper.DeserializeObject((byte[])this._OutPatientPrescription.SignedData) as Prescription.DigitalSignedPrescription;
                    if (digitalSignedPrescription != null && resUser.VerifySignedData(new Prescription.DigitalPrescription(this._OutPatientPrescription), digitalSignedPrescription.SignedData))
                    {
                        this.Icon = TTVisual.Properties.Resources.validsignature;
                        this.DigitalSignatureButton.Text = "e-imza doğrulandı";
                        this.DigitalSignatureButton.BackColor = Color.Green;
                    }
                    else
                    {
                        this.Icon = TTVisual.Properties.Resources.invalidsignature;
                        this.DigitalSignatureButton.Text = "e-imza doğrulanamadı";
                        this.DigitalSignatureButton.BackColor = Color.Red;
                    }
                }
            }

            //             if(!string.IsNullOrEmpty(this._OutPatientPrescription.EReceteNo))
            //                EReceteNo.Text=this._OutPatientPrescription.EReceteNo;
#endregion OutPatientPrescriptionBaseForm_PreScript

            }
                }
}