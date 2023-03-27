
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
    /// Kafa randevusu formu
    /// </summary>
    public partial class AdmissionAppointmentForm : ActionForm
    {
        override protected void BindControlEvents()
        {
            ClearSelectedPatient.Click += new TTControlEventDelegate(ClearSelectedPatient_Click);
            SelectedPatient.SelectedObjectChanged += new TTControlEventDelegate(SelectedPatient_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ClearSelectedPatient.Click -= new TTControlEventDelegate(ClearSelectedPatient_Click);
            SelectedPatient.SelectedObjectChanged -= new TTControlEventDelegate(SelectedPatient_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void ClearSelectedPatient_Click()
        {
#region AdmissionAppointmentForm_ClearSelectedPatient_Click
   if (this.SelectedPatient.SelectedValue != null)
            {
                this.SelectedPatient.SelectedValue = null;
                this.PatientName.Text = "";
                this.PatientSurname.Text = "";
                this.SelectedPatientFiltered.Text = "";
            }
#endregion AdmissionAppointmentForm_ClearSelectedPatient_Click
        }

        private void SelectedPatient_SelectedObjectChanged()
        {
#region AdmissionAppointmentForm_SelectedPatient_SelectedObjectChanged
   if (this.SelectedPatient.SelectedValue != null)
            {
                Patient selectedPatient = (Patient)(this.SelectedPatient).SelectedObject;
                this.PatientName.Text = selectedPatient.Name;
                this.PatientSurname.Text = selectedPatient.Surname;
                this.SelectedPatientFiltered.Text = selectedPatient.ID.Value.ToString() + " " + selectedPatient.Name +  " "  + selectedPatient.Surname;
                this.PatientName.ReadOnly = true;
                this.PatientSurname.ReadOnly = true;
            }
            else
            {
                this.PatientName.Text = "";
                this.PatientSurname.Text = "";
                this.PatientName.ReadOnly = false;
                this.PatientSurname.ReadOnly = false;
            }
#endregion AdmissionAppointmentForm_SelectedPatient_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region AdmissionAppointmentForm_PreScript
    base.PreScript();
            string filterExpression = " STATEONLY = 0";
            if(Common.CurrentUser.Status != UserStatusEnum.SuperUser)
            {
                filterExpression += " AND OBJECTID IN (";
                int count = 0;
                foreach (AppointmentDefinition appointmentDefinition in AppointmentDefinition.GetAllAppointmentDefinitions(this._AdmissionAppointment.ObjectContext))
                {
                    foreach(AppointmentDefinitionRole appointmentDefinitionRole in appointmentDefinition.AppointmentDefinitionRoles)
                    {   Guid roleID = new Guid(appointmentDefinitionRole.RoleID);
                        if (ResUser.HasRole(Common.CurrentResource, roleID) == true  && appointmentDefinitionRole.RightType == AppointmentRightTypeEnum.ReadAndCreate)
                        {
                            if (count > 0)
                                filterExpression += ",";
                            filterExpression += "'" + appointmentDefinition.ObjectID.ToString() + "'";
                            count++;
                        }
                    }
                }
                filterExpression += ")";
                
                if (count == 0)
                    filterExpression = " 1 = 0 ";
            }
            this.AppointmentDefinitionList.ListFilterExpression = filterExpression;
           //TODO pnlButton!
            // this.cmdOK.Visible = false;
#endregion AdmissionAppointmentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AdmissionAppointmentForm_PostScript
    base.PostScript(transDef);
//            if (this._AdmissionAppointment.AppointmentDefinition == null)
//            {
//                throw new Exception("'Randevu Türü' boş geçilemez.");
//            }
//            this._AdmissionAppointment.AppointmentCarrierList = new List<AppointmentCarrier>();
//            AppointmentDefinition appointmentDefinition = (AppointmentDefinition)this._AdmissionAppointment.AppointmentDefinition;
//            foreach (AppointmentCarrier appointmentCarrier in appointmentDefinition.AppointmentCarriers)
//            {
//                foreach (AppointmentCarrierUserTypes appointmentCarrierUserTypes in appointmentCarrier.AppointmentCarrierUserTypes)
//                {
//                    appointmentCarrier.UserTypes.Add((UserTypeEnum)appointmentCarrierUserTypes.UserType.Value);
//                }
//                if (appointmentCarrier.AppointmentType == AppointmentTypeEnum.None) { }
//                this._AdmissionAppointment.AppointmentCarrierList.Add(appointmentCarrier);
//            }
#endregion AdmissionAppointmentForm_PostScript

            }
                }
}