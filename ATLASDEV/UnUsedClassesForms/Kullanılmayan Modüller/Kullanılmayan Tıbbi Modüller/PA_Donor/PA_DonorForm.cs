
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
    /// Donör Kabulü
    /// </summary>
    public partial class PA_DonorForm : PA_CivilianConsignmentForm
    {
        override protected void BindControlEvents()
        {
            IsNotSGK.CheckedChanged += new TTControlEventDelegate(IsNotSGK_CheckedChanged);
            cmdSearchPatient.Click += new TTControlEventDelegate(cmdSearchPatient_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            IsNotSGK.CheckedChanged -= new TTControlEventDelegate(IsNotSGK_CheckedChanged);
            cmdSearchPatient.Click -= new TTControlEventDelegate(cmdSearchPatient_Click);
            base.UnBindControlEvents();
        }

        private void IsNotSGK_CheckedChanged()
        {
#region PA_DonorForm_IsNotSGK_CheckedChanged
            ShowOrHideMedulaTabByPatientPayerAndReasonForAdmission();
#endregion PA_DonorForm_IsNotSGK_CheckedChanged
        }

        private void cmdSearchPatient_Click()
        {
#region PA_DonorForm_cmdSearchPatient_Click
   using (PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                if (patient != null)
                {
                  
                    txtName.Text = patient.Name;
                    txtSurname.Text = patient.Surname;
                    txtNakilYapılacakHastaTC.Text = patient.UniqueRefNo != null ? patient.UniqueRefNo.Value.ToString() : "";
//                    txtBirthDate.Text = patient.BirthDate != null ? patient.BirthDate.Value.ToString("dd.MM.yyyy") : "";
//                    if (patient.Sex != null)
//                    {
//                        if (patient.Sex == SexEnum.Male)
//                            txtSex.Text = "Erkek";
//                        else if (patient.Sex == SexEnum.Female)
//                            txtSex.Text = "Bayan";
//                        else
//                            txtSex.Text = "";
//                    } 
                }
                else
                {
                    InfoBox.Show("Hasta bilgilerine ulaşılamıyor.");
//                    txtSex.Text = "";
//                    txtBirthDate.Text = "";
                    txtNakilYapılacakHastaTC.Text = "";
                    txtSurname.Text = "";
                    txtName.Text = "";
                }
            }
#endregion PA_DonorForm_cmdSearchPatient_Click
        }

        protected override void PreScript()
        {
#region PA_DonorForm_PreScript
    base.PreScript();
         
#endregion PA_DonorForm_PreScript

            }
                }
}