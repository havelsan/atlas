
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
    /// Radyoloji Kriter Formu
    /// </summary>
    public partial class RadWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region RadWLCriteriaForm_Methods
        CheckedComboBox equipmentsCheckedCombo = new CheckedComboBox();
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FillEquipmentCombo(); //Burası da değişti.
            CriteriaValue crValNo = this.GetCriteriaValue("ACCESSIONNO");
            if(crValNo != null && !string.IsNullOrEmpty(crValNo.Value))
            {
                try
                {
                    txtAccessionNo.Text = crValNo.Value;
                }
                catch(Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
            
            //Burası sonradan eklendi.
            this.InitCheckedCombo();
            //
        }
        
        public override void OnSave()
        {
            base.OnSave();
            this.SaveCriteria("ACCESSIONNO","System.String",txtAccessionNo.Text);
            //this.SaveCriteria("EQUIPMENT","System.String",this.cboEquipments.SelectedItem == null ? "" : this.cboEquipments.SelectedItem.Value.ToString());

            if (this.checkEmergency.Value == true)
            {
                IList<ResClinic.GetEmergencyClinics_Class> emergencyClinicList = ResClinic.GetEmergencyClinics();
                string fromResourceFilter = "";
                if (emergencyClinicList != null && emergencyClinicList.Count > 0)
                {
                    int i = 0;
                    foreach (ResClinic.GetEmergencyClinics_Class emergencyClinic in emergencyClinicList)
                    {
                        i++;
                        fromResourceFilter += emergencyClinic.ObjectID.ToString();
                        if (i != emergencyClinicList.Count) fromResourceFilter += ",";
                    }
                }
                if (!String.IsNullOrEmpty(fromResourceFilter))
                {
                    this.SaveCriteria("FROMRESOURCE", "System.String", fromResourceFilter);
                }
            }
            else
            {
                CriteriaValue crValEmergency = this.GetCriteriaValue("FROMRESOURCE");
                CriteriaDefinition pDef = this.GetCriteriaDefinition("FROMRESOURCE");
                if(crValEmergency != null && pDef != null) pDef.CriteriaValues.Remove(crValEmergency);
            }
            
            
            //Burası sonradan eklendi.
            CriteriaValue crValEquipment = this.GetCriteriaValue("EQUIPMENT");
            CriteriaDefinition pDefEquipment = this.GetCriteriaDefinition("EQUIPMENT");
            if(crValEquipment != null && pDefEquipment != null) pDefEquipment.CriteriaValues.Remove(crValEquipment);
            
            if(this.equipmentsCheckedCombo.CheckedItems.Count > 0)
            {
                string equipmentFilter = "";
                int i = 0;
                foreach(TTComboBoxItem item in this.equipmentsCheckedCombo.CheckedItems)
                {
                    i++;
                    equipmentFilter += item.Value.ToString();
                    if(i != this.equipmentsCheckedCombo.CheckedItems.Count) equipmentFilter += ",";
                }
                if(!String.IsNullOrEmpty(equipmentFilter))
                {
                    this.SaveCriteria("EQUIPMENT","System.String", equipmentFilter);
                }
            }
        }
        
        private void LoadCriteria()
        {
            if (this.GetCriteriaValue("ACCESSIONNO") != null)
                this.txtAccessionNo.Text = this.GetCriteriaValue("ACCESSIONNO").Value;
            
            this.cboEquipments.SelectedItem = null;
            CriteriaValue crValEquipment = this.GetCriteriaValue("EQUIPMENT");
            if(crValEquipment != null && !string.IsNullOrEmpty(crValEquipment.Value))
            {
                TTComboBoxItem equipmentItem = null;
                foreach(TTComboBoxItem item in this.cboEquipments.Items)
                {
                    if (item.Value.ToString() == crValEquipment.Value.ToString())
                        equipmentItem = item;
                }

                this.cboEquipments.SelectedItem = equipmentItem;
            }
        }
        
        private void InitCheckedCombo()
        {
            this.equipmentsCheckedCombo.CheckOnClick = true;
            this.equipmentsCheckedCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.equipmentsCheckedCombo.DropDownHeight = 1;
            this.equipmentsCheckedCombo.FormattingEnabled = true;
            this.equipmentsCheckedCombo.IntegralHeight =false;
            //this.equipmentsCheckedCombo.Location = this.cboEquipments.Location;
            this.equipmentsCheckedCombo.Name = "equipmentsCheckedCombo";
            //this.equipmentsCheckedCombo.Size = this.cboEquipments.Size;
            this.equipmentsCheckedCombo.TabIndex = 15;
            this.equipmentsCheckedCombo.ValueSeparator = ", ";
            
            this.Controls.Add(this.equipmentsCheckedCombo);
        }
        
        
        private void FillEquipmentCombo()
        {
            //cihazlar listesi burada doldurulur.
            equipmentsCheckedCombo.Items.Clear();
            
            IList equipmentList = ResRadiologyEquipment.GetResEquipments(this.ObjectContext,"");
            foreach(ResEquipment resEquipment in equipmentList)
            {
                if(resEquipment is ResRadiologyEquipment)
                {
                    TTComboBoxItem item1 = new TTComboBoxItem(resEquipment.Name.ToString(), resEquipment.ObjectID.ToString());
                    equipmentsCheckedCombo.Items.Add(item1,false);
                }
            }
        }
        
        /*
        private void FillEquipmentCombo()
        {
            //fill resources here
            ComboBox eBox = (ComboBox)this.cboEquipments;
            eBox.Items.Clear();
            TTComboBoxItem item0 = new TTComboBoxItem("", "");
            eBox.Items.Add(item0);
            
            IList equipmentList = ResRadiologyEquipment.GetResEquipments(this.ObjectContext,"");
            foreach(ResEquipment resEquipment in equipmentList)
            {
                if(resEquipment is ResRadiologyEquipment)
                {
                    TTComboBoxItem item1 = new TTComboBoxItem(resEquipment.Name.ToString(), resEquipment.ObjectID.ToString());
                    eBox.Items.Add(item1);
                }
            }
        }
         */
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
                return RadiologyTest.WorkListNQL(context, dtStart, dtEnd, sExpression);
            else
                return RadiologyTest.GetByFilterExpression(context,sExpression);
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
                return RadiologyTest.GetByRadTestWorklistDateReport( sExpression);
            else
                return RadiologyTest.GetByRadTestFilterExpressionReport(sExpression);
        }
        
        public override IList ExecuteReportNQL(string sExpression)
        {
            return RadiologyTest.GetByRadTestFilterExpressionReport(sExpression);
        }
        
#endregion RadWLCriteriaForm_Methods
    }
}