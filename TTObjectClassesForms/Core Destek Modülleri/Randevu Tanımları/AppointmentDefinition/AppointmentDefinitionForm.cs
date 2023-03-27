
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
    /// Randevu Tanımlama
    /// </summary>
    public partial class AppointmentDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            cbFormDef.SelectedIndexChanged += new TTControlEventDelegate(cbFormDef_SelectedIndexChanged);
            AppointmentCarriers.CellDoubleClick += new TTGridCellEventDelegate(AppointmentCarriers_CellDoubleClick);
            AppointmentDefinitionRolesGrid.CellValueChanged += new TTGridCellEventDelegate(AppointmentDefinitionRolesGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cbFormDef.SelectedIndexChanged -= new TTControlEventDelegate(cbFormDef_SelectedIndexChanged);
            AppointmentCarriers.CellDoubleClick -= new TTGridCellEventDelegate(AppointmentCarriers_CellDoubleClick);
            AppointmentDefinitionRolesGrid.CellValueChanged -= new TTGridCellEventDelegate(AppointmentDefinitionRolesGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void cbFormDef_SelectedIndexChanged()
        {
#region AppointmentDefinitionForm_cbFormDef_SelectedIndexChanged
   if(cbFormDef.SelectedItem != null)
            {
                if(cbFormDef.SelectedItem.Value != null)
                {
                    TTFormDef form = (TTFormDef)cbFormDef.SelectedItem.Value;
                    this.txtFormDefID.Text = form.FormDefID.ToString();
                }
                else
                {
                    this.txtFormDefID.Text = null;
                }
            }
            else
            {
                this.txtFormDefID.Text = null;
            }
#endregion AppointmentDefinitionForm_cbFormDef_SelectedIndexChanged
        }

        private void AppointmentCarriers_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AppointmentDefinitionForm_AppointmentCarriers_CellDoubleClick
   /*TTFormClasses.AppointmentCarrierForm frm = new TTFormClasses.AppointmentCarrierForm();
            AppointmentCarrier appointmentCarrier = (AppointmentCarrier)this._AppointmentDefinition.AppointmentCarriers[rowIndex];
            frm.ShowEdit(this.FindForm(),appointmentCarrier);*/
#endregion AppointmentDefinitionForm_AppointmentCarriers_CellDoubleClick
        }

        private void AppointmentDefinitionRolesGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region AppointmentDefinitionForm_AppointmentDefinitionRolesGrid_CellValueChanged
   //            if(this.AppointmentDefinitionRolesGrid.CurrentCell.Value != null)
//            {
//                if (this.AppointmentDefinitionRolesGrid.Columns["Role"].Index == columnIndex)
//                {
//                    TTRole role = (TTRole)this.AppointmentDefinitionRolesGrid.CurrentCell.Value;
//                    
//                    this.AppointmentDefinitionRolesGrid.Rows[rowIndex].Cells["RoleID"].Value = role.RoleID.ToString();
//                }
//            }
#endregion AppointmentDefinitionForm_AppointmentDefinitionRolesGrid_CellValueChanged
        }

        protected override void PreScript()
        {
#region AppointmentDefinitionForm_PreScript
    base.PreScript();
            
            //Appointment.cs nin TTFormDef leri sıralı bir şekilde formDef combosuna dolduruluyor.
            Hashtable unSortedForms = new Hashtable();
            foreach(TTFormDef form in TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs)
            {
                Common.TTStringSortableList sortableForms = new Common.TTStringSortableList();
                sortableForms.ID = form.FormDefID;
                sortableForms.Value = form.Name;
                unSortedForms.Add(sortableForms.ID,sortableForms);
            }
            
            List<Common.TTStringSortableList> sortedForms = Common.SortedStringItems(unSortedForms);
            ITTComboBox cmb = (ITTComboBox)this.cbFormDef;
            cmb.Items.Clear();
            foreach(Common.TTStringSortableList listItem in sortedForms)
            {
                TTFormDef form = TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs[listItem.ID];
                TTComboBoxItem cbi = new TTComboBoxItem(form.Name, form);
                cmb.Items.Add(cbi);
            }
            
            if (!String.IsNullOrEmpty(this.txtFormDefID.Text.ToString()))
            {
                Guid formDefID = new Guid(this.txtFormDefID.Text.ToString());
                TTFormDef form = TTObjectDefManager.Instance.ObjectDefs["Appointment"].FormDefs[formDefID];
                cbFormDef.ControlValue = form;
            } 
            else
            {
                cbFormDef.ControlValue = null;
            }
            
            //TTRole ler sıralı bir şekilde gridin içindeki Rol isimli comboya dolduruluyor.
            Hashtable unSortedRoles = new Hashtable();
            foreach(TTRole role in TTObjectDefManager.Instance.Roles)
            {
                if (role.Subtype != RoleSubTypeEnum.User)
                {
                    Common.TTStringSortableList sortableRoles = new Common.TTStringSortableList();
                    sortableRoles.ID = role.RoleID;
                    sortableRoles.Value = role.Name;
                    unSortedRoles.Add(sortableRoles.ID,sortableRoles);
                }
            }
            
            List<Common.TTStringSortableList> sortedRoles = Common.SortedStringItems(unSortedRoles);
            ITTComboBoxColumn cb = (ITTComboBoxColumn)AppointmentDefinitionRolesGrid.Columns["Role"];
            cb.Items.Clear();
            foreach(Common.TTStringSortableList listItem in sortedRoles)
            {
                TTRole role = TTObjectDefManager.Instance.Roles[listItem.ID];
                TTComboBoxItem cbi = new TTComboBoxItem(role.Name, role);
                cb.Items.Add(cbi);
            }
            
            //Rol gridinin içinde dönerek ilgili roleID ye sahip rol bulunup,role.Name i Role hücresine set edilir.
            foreach(ITTGridRow gridRow in this.AppointmentDefinitionRolesGrid.Rows)
            {
                if (gridRow.Cells["RoleID"].Value != null)
                {
                    Guid roleID = new Guid(gridRow.Cells["RoleID"].Value.ToString());
                    TTRole role = TTObjectDefManager.Instance.Roles[roleID];
                    gridRow.Cells["Role"].Value = role;
                }
            }
            
            if(this._AppointmentDefinition.StateOnly == null)
                this.StateOnly.ControlValue = false;
            
            if(this._AppointmentDefinition.GiveToMaster == null)
                this.GiveToMaster.ControlValue = false;
            
            if(this._AppointmentDefinition.OverlapAllowed == null)
                this.OverlapAllowed.ControlValue = false;
            
            if(this._AppointmentDefinition.ScheduleOverlapAllowed == null)
                this.ScheduleOverlapAllowed.ControlValue = false;
            
            if(this._AppointmentDefinition.GiveFromResource == null)
                this.GiveFromResource.ControlValue = false;
            
            if(this._AppointmentDefinition.IsDescReqForNonScheduledApps == null)
                this.IsDescReqForNonScheduledApps.ControlValue = false;
#endregion AppointmentDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AppointmentDefinitionForm_PostScript
    base.PostScript(transDef);
            
            this._AppointmentDefinition.AppDefNameDisplayText = this._AppointmentDefinition.AppointmentDefinitionNameDisplayText;
#endregion AppointmentDefinitionForm_PostScript

            }
                }
}