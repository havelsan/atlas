
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
    /// Nükleer Tıp Yeni İstek Formu
    /// </summary>
    public partial class NuclearMedicineRequestAcceptionForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
            /*
#region NuclearMedicineRequestAcceptionForm_ttbutton1_Click
            NuclearMedicine.PrintNuclearBarcode(this._NuclearMedicine);
#endregion NuclearMedicineRequestAcceptionForm_ttbutton1_Click */
        }

        protected override void PreScript()
        {
#region NuclearMedicineRequestAcceptionForm_PreScript
    base.PreScript();

            this.SetProcedureDoctorAsCurrentResource();  
            bool hasInitialObjectIDForAdmissionAppointment = false;
            if(this._NuclearMedicine.SubEpisode.PatientAdmission != null)
            {
                if(this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment != null)
                {
                    if(this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments.Count > 0)
                    {
                        if(this._NuclearMedicine.SubEpisode.PatientAdmission.AdmissionAppointment.Appointments[0].InitialObjectID != null)
                            hasInitialObjectIDForAdmissionAppointment = true;
                    }
                }
            }
            
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }
            if ((bool)_NuclearMedicine.IsEmergency || hasInitialObjectIDForAdmissionAppointment)
            {
                this.DropStateButton(NuclearMedicine.States.AppointmentInfo);
            }
            else
            {
                this.DropStateButton(NuclearMedicine.States.Preparation);
            }
            
            if(this._EpisodeAction.MyNotApprovedAppointments().Count > 0)
                this.DropStateButton(NuclearMedicine.States.AppointmentInfo);
#endregion NuclearMedicineRequestAcceptionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineRequestAcceptionForm_PostScript
    base.PostScript(transDef);
            if (/*transDef.ToStateDefID == NuclearMedicine.States.Rejected ||*/ transDef.ToStateDefID == NuclearMedicine.States.Cancelled)
                return;

            if (String.IsNullOrEmpty(this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo))
            {
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }

            #endregion NuclearMedicineRequestAcceptionForm_PostScript

        }

        #region NuclearMedicineRequestAcceptionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == NuclearMedicine.States.AppointmentInfo)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    NuclearMedicine nucTest = (NuclearMedicine)objectContext.GetObject(this._NuclearMedicine.ObjectID, "NUCLEARMEDICINE");

                    if(nucTest != null)
                    {
                        string injectionStr = "WHERE INITIALOBJECTID = '" + nucTest.ObjectID + "'";
                        IList appList = Appointment.GetByInjection(objectContext, injectionStr);
                        if(appList.Count > 0)
                        {
                            nucTest.CurrentStateDefID = NuclearMedicine.States.AdmissionAppointment;
                            objectContext.Save();
                        }
                    }
                }
                
                base.AfterContextSavedScript(transDef);
                
            }
        }
        
#endregion NuclearMedicineRequestAcceptionForm_Methods
    }
}