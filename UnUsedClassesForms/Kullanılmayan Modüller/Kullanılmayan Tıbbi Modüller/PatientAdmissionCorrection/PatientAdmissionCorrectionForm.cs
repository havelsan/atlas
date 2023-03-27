
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
    /// Hasta Kabul Düzeltme
    /// </summary>
    public partial class PatientAdmissionCorrectionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            NewPatientAdmission.Click += new TTControlEventDelegate(NewPatientAdmission_Click);
            OldPatientAdmission.Click += new TTControlEventDelegate(OldPatientAdmission_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NewPatientAdmission.Click -= new TTControlEventDelegate(NewPatientAdmission_Click);
            OldPatientAdmission.Click -= new TTControlEventDelegate(OldPatientAdmission_Click);
            base.UnBindControlEvents();
        }

        private void NewPatientAdmission_Click()
        {
#region PatientAdmissionCorrectionForm_NewPatientAdmission_Click
   //            if(this._PatientAdmissionCorrection.NewPatientAdmission==null)
//            {
//                throw new Exception("Yeni Hasta Kabul Bulunamadı");
//            }
//            else
//            {
//                TTForm frm = TTForm.GetEditForm(this._PatientAdmissionCorrection.NewPatientAdmission);
//                if (frm == null)
//                {
//                    InfoBox.Show(this._PatientAdmissionCorrection.NewPatientAdmission.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından yeni hasta kabul işlemi açılamamaktadır");
//                }
//                else
//                {
//                    frm.ShowReadOnly(this,this._PatientAdmissionCorrection.NewPatientAdmission);
//                }
//            }
#endregion PatientAdmissionCorrectionForm_NewPatientAdmission_Click
        }

        private void OldPatientAdmission_Click()
        {
#region PatientAdmissionCorrectionForm_OldPatientAdmission_Click
   //            if(this._PatientAdmissionCorrection.OldPatientAdmission==null)
//            {
//                throw new Exception("Eski Hasta Kabul Bulunamadı");
//            }
//            else
//            {
//                TTForm frm = TTForm.GetEditForm(this._PatientAdmissionCorrection.OldPatientAdmission);
//                if (frm == null)
//                {
//                    InfoBox.Show(this._PatientAdmissionCorrection.OldPatientAdmission.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından yeni hasta kabul işlemi açılamamaktadır");
//                }
//                else
//                {
//                    frm.ShowReadOnly(this,this._PatientAdmissionCorrection.OldPatientAdmission);
//                }
//            }
#endregion PatientAdmissionCorrectionForm_OldPatientAdmission_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientAdmissionCorrectionForm_PostScript
    base.PostScript(transDef);
#endregion PatientAdmissionCorrectionForm_PostScript

            }
                }
}