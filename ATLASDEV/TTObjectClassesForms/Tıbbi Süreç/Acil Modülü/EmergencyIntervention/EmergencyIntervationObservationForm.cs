
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
    /// Acil Müdahale
    /// </summary>
    public partial class EmergencyIntervationObservationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            //cmbTriajCode.SelectedIndexChanged += new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            ResponsibleDoctor.SelectedObjectChanged += new TTControlEventDelegate(ResponsibleDoctor_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //cmbTriajCode.SelectedIndexChanged -= new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            ResponsibleDoctor.SelectedObjectChanged -= new TTControlEventDelegate(ResponsibleDoctor_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void cmbTriajCode_SelectedIndexChanged()
        {
#region EmergencyIntervationObservationForm_cmbTriajCode_SelectedIndexChanged
   //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Red).Value)
            //{
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Red;
            //}
            //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Yellow).Value)
            //{
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Yellow;

            //}
            //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Green).Value )
            //{
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Green;

            //}
#endregion EmergencyIntervationObservationForm_cmbTriajCode_SelectedIndexChanged
        }

        private void ResponsibleDoctor_SelectedObjectChanged()
        {
#region EmergencyIntervationObservationForm_ResponsibleDoctor_SelectedObjectChanged
   _EmergencyIntervention.SetProcedureDoctorAsResponsibleDoctor();
#endregion EmergencyIntervationObservationForm_ResponsibleDoctor_SelectedObjectChanged
        }

        protected override void PreScript()
        {
            #region EmergencyIntervationObservationForm_PreScript
            //DropStateButton(EmergencyIntervention.States.Cancelled);

            this.SetProcedureDoctorAsCurrentResource();

            this.DropStateButton(EmergencyIntervention.States.InpatientObservation);
            foreach (NursingApplication nursingApplication in this._EmergencyIntervention.NursingApplications)
            {
                if (nursingApplication.CurrentStateDef.Status == StateStatusEnum.Uncompleted && !nursingApplication.IsCancelled)
                {
                    this.DropStateButton(EmergencyIntervention.States.Completed);
                }
            }
            this.ResponsibleDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._EmergencyIntervention.MasterResource.ObjectID.ToString() + "'";

            //if (cmbTriajCode.SelectedItem != null)
            //{
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Red).Value )
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Red;
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Yellow).Value)
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Yellow;
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Green).Value)
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Green;
            //}
            base.PreScript();
#endregion EmergencyIntervationObservationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region EmergencyIntervationObservationForm_PostScript
    base.PostScript(transDef);
            if (this._EmergencyIntervention.ResponsibleDoctor == null)
                throw new Exception("'Sorumlu Doktor' seçilmesi zorunludur.");

            //            if(transDef != null)
            //            {
            //                if(transDef.ToStateDefID == EmergencyIntervention.States.InpatientObservation)
            //                {
            //                    this.FireNursingAndPhysicianApplication();
            //                    SetAuthorizedUserOfInPatientPhysicianApplication();
            //                }
            //            }
#endregion EmergencyIntervationObservationForm_PostScript

            }
            
#region EmergencyIntervationObservationForm_Methods
        protected override void PrepareFormTitle()
        {
            if (this._EmergencyIntervention.MasterResource != null)
                this.Text += " - " + this._EmergencyIntervention.MasterResource.Name.ToUpper();
            if (this._EpisodeAction.Episode.Patient != null)
                this.Text += " - " + this._EpisodeAction.Episode.Patient.FullName.ToUpper();

        }
        
#endregion EmergencyIntervationObservationForm_Methods
    }
}