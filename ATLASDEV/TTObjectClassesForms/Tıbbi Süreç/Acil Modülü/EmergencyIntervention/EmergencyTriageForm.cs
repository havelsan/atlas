
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
    /// Acil Hasta Triaj
    /// </summary>
    public partial class EmergencyTriageForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
           // cmbTriajCode.SelectedIndexChanged += new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            //cmbTriajCode.SelectedIndexChanged -= new TTControlEventDelegate(cmbTriajCode_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void ResponsibleDoctor_SelectedObjectChanged()
        {
#region EmergencyTriageForm_ResponsibleDoctor_SelectedObjectChanged
   // _EmergencyIntervention.SetProcedureDoctorAsResponsibleDoctor();
#endregion EmergencyTriageForm_ResponsibleDoctor_SelectedObjectChanged
        }

        private void cmbTriajCode_SelectedIndexChanged()
        {
#region EmergencyTriageForm_cmbTriajCode_SelectedIndexChanged
   //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Red).Value)
            {
            //    //((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Red;
            //}
            //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Yellow).Value)
            //{
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Yellow;

            //}
            //if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Green).Value )
            //{
            //    ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Green;

            }
#endregion EmergencyTriageForm_cmbTriajCode_SelectedIndexChanged
        }

        protected override void PreScript()
        {
            #region EmergencyTriageForm_PreScript
            this.SetProcedureDoctorAsCurrentResource();

            //  DropStateButton(EmergencyIntervention.States.Cancelled);
            foreach (NursingApplication nursingApplication in this._EmergencyIntervention.NursingApplications)
            {
                if (nursingApplication.CurrentStateDef.Status == StateStatusEnum.Uncompleted && !nursingApplication.IsCancelled)
                {
                    this.DropStateButton(EmergencyIntervention.States.Completed);
                }
            }
            // this.ResponsibleDoctor.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._EmergencyIntervention.MasterResource.ObjectID.ToString() + "'";
            this.Complaint.ListFilterExpression = "SPECIALITYDEFINITION ='" + this._EmergencyIntervention.GetSubEpisodeSpeciality().ObjectID.ToString() + "' OR SPECIALITYDEFINITION is NULL";

            string ipAddr = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112IP", null);
            TTUtils.TTWebServiceUri uri = new TTUtils.TTWebServiceUri(ipAddr);
            string userName112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112USERNAME", null);
            string password112 = TTObjectClasses.SystemParameter.GetParameterValue("ACIL112PASSWORD", null);
            //if (this._EmergencyIntervention.Sevkli112 == true)
            //{
            //    IList<EmergencyIntervention.GetByEpisodeInfo_Class> MyEmergencyInterventionList = EmergencyIntervention.GetByEpisodeInfo(this._EmergencyIntervention.ObjectContext, this._EmergencyIntervention.Episode.ObjectID.ToString());

            //    try
            //    {
            //        int sonuc = TTObjectClasses.Acil112Servis.WebMethods.VakaGuncellemeMetoduSync(Sites.SiteLocalHost, uri, userName112, password112,"", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(MyEmergencyInterventionList[0].EnteranceTime).ToString("yyyy-MM-dd HH:mm:ss"), "", ipAddr);
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;//new Exception(ex.Message.ToString());
            //    }
            //}

            //foreach(TTComboBoxItem  item in this.TriajCode.Items)
            //{
            // private System.ComponentModel.Container components = null;
            // }

            //((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.White;
            //if (cmbTriajCode.SelectedItem != null && cmbTriajCode.SelectedItem.Value != null)
            //{
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Red).Value )
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Red;
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Yellow).Value)
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Yellow;
            //    if (Convert.ToInt32(cmbTriajCode.SelectedItem.Value) == Common.GetEnumValueDefOfEnumValue(TriajCode.Green).Value )
            //        ((ITTControl)this.TriajColor).BackColor = System.Drawing.Color.Green;
            //}
            if (this._EmergencyIntervention.CurrentStateDefID == EmergencyIntervention.States.Completed)
                this.DropStateButton(EmergencyIntervention.States.Observation);

            base.PreScript();
#endregion EmergencyTriageForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region EmergencyTriageForm_PostScript
    base.PostScript(transDef);
                    
            if (transDef != null)
            {
                if (this._EmergencyIntervention.ResponsibleDoctor == null)
                    throw new Exception("'Sorumlu Doktor' seçilmesi zorunludur.");
                
                /*if (transDef.ToStateDefID == EmergencyIntervention.States.Observation)
                {
                    if (_EmergencyIntervention.Episode.Patient.SecurePerson != null && _EmergencyIntervention.Episode.Patient.SecurePerson.Value == true)
                    {
                        if (this._EmergencyIntervention.ResponsibleDoctor == null)
                            throw new Exception("Güvenlikli Hastalar için 'Sorumlu Doktor' seçilmesi zorunludur.");
                    }

                    if (this._EmergencyIntervention.Episode.IsMedulaEpisode())
                    {
                        if (this._EmergencyIntervention.ResponsibleDoctor == null)
                            throw new Exception("SGK hastaları için 'Sorumlu Doktor' seçilmesi zorunludur.");

                        if (this._EmergencyIntervention.TriajCode == null)
                            throw new Exception("SGK hastaları için 'Triaj Kodu' seçilmesi zorunludur.");
                    }
                }*/
            }
#endregion EmergencyTriageForm_PostScript

            }
            
#region EmergencyTriageForm_Methods
        protected override void PrepareFormTitle()
        {
            if (this._EmergencyIntervention.MasterResource != null)
                this.Text += " - " + this._EmergencyIntervention.MasterResource.Name.ToUpper();
            if (this._EpisodeAction.Episode.Patient != null)
                this.Text += " - " + this._EpisodeAction.Episode.Patient.FullName.ToUpper();

        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null && transDef.ToStateDefID == EmergencyIntervention.States.Observation)
            {
                foreach (PatientExamination patientExamination in this._EmergencyIntervention.PatientExaminations)
                {
                    patientExamination.CurrentStateDefID = PatientExamination.States.Examination;
                }
                this._EmergencyIntervention.ObjectContext.Save();
            }
        }


        //TODO  in ts
        // Forma BloodPlesure,Tempreture, Pluse ,Respiration, SPO2 Form Componentlerini  buraya ekleyip  giriş yapılırsa Emergensy Intervationla bağlamak ExecutionDate set etmek  gerekiyor
        #endregion EmergencyTriageForm_Methods
    }
}