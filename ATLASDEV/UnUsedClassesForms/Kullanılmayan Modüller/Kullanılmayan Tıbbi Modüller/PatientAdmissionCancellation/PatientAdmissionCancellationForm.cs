
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
    public partial class PatientAdmissionCancellationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region PatientAdmissionCancellationForm_PreScript
    base.PreScript();
            
            
            Control buttonOK = this.Controls.Find("cmdOK",true)[0];
            if (buttonOK != null)
                buttonOK.Visible = false;
            

            
            if(this._PatientAdmissionCancellation.Episode != null && this._PatientAdmissionCancellation.Episode.PatientStatus != null && this._PatientAdmissionCancellation.Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
                throw new TTUtils.TTException("Yatan hastalarda hasta kabul iptal işlemi yapılamaz!");
            if(this._PatientAdmissionCancellation.Episode != null && this._PatientAdmissionCancellation.Episode.PatientStatus != null && this._PatientAdmissionCancellation.Episode.PatientStatus.Value == PatientStatusEnum.Discharge)
                throw new TTUtils.TTException("Taburcu olan hastalarda hasta kabul iptal işlemi yapılamaz!");
            if(this._PatientAdmissionCancellation.Episode != null && this._PatientAdmissionCancellation.Episode.Diagnosis != null && this._PatientAdmissionCancellation.Episode.Diagnosis.Count > 0)
                throw new TTUtils.TTException("Hastaya tanı konulduğundan hasta kabul iptal işlemi yapılamaz!");
#endregion PatientAdmissionCancellationForm_PreScript

            }
                }
}