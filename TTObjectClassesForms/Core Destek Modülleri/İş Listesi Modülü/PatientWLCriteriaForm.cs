
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
    /// Filtre
    /// </summary>
    public partial class PatientWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click += new TTControlEventDelegate(ClearButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click -= new TTControlEventDelegate(ClearButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region PatientWLCriteriaForm_SelectButton_Click
   if( !string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
#endregion PatientWLCriteriaForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region PatientWLCriteriaForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion PatientWLCriteriaForm_ttbutton1_Click
        }

        private void SelectAllButton_Click()
        {
#region PatientWLCriteriaForm_SelectAllButton_Click
   foreach(ListViewItem item in this.MResources.Items)
            {
                item.Checked = true;
            }
#endregion PatientWLCriteriaForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region PatientWLCriteriaForm_ClearButton_Click
   foreach(ListViewItem item in this.MResources.Items)
            {
                item.Checked = false;
            }
#endregion PatientWLCriteriaForm_ClearButton_Click
        }

#region PatientWLCriteriaForm_Methods
        ListView m_listResource = null;
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            TextBox pBox = (TextBox)this.PatientBox;
            pBox.KeyUp += new KeyEventHandler(this.OnPatientBoxKeyUp);
            
            m_listResource = (ListView)this.MResources;
            m_listResource.CheckBoxes = true;
            
            this.FillResources();
            this.LoadCriteria();
            this.FillStateBox();
        }
        
        private void OnPatientBoxKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13 && !string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
        }
        
        private void SearchPatient(string sText)
        {
            Patient patient= PatientAdmission.GetPatientBySearch(sText);
            if(patient!=null)
            {
                this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
                this.PatientBox.Tag = patient;
            }
        }
        
        private BindingList<Patient.GetPatientByInjection_Class> GetReasultPatient()
        {
            BindingList<Patient.GetPatientByInjection_Class> patients =new BindingList<Patient.GetPatientByInjection_Class>();
            string[] sSearchTexts = this.PatientBox.Text.Split(' ');
            string sSQL = "";
            
            foreach(string s in sSearchTexts)
            {
                sSQL = " WHERE NAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
                patients = Patient.GetPatientByInjection(sSQL);
                
                if(patients.Count == 0)
                {
                    sSQL = " WHERE SURNAME = '" + s.ToUpper(TTUtils.CultureService.Culture) + "'";
                    patients = Patient.GetPatientByInjection(sSQL);
                }
                
                if(patients.Count > 0)
                    break;
            }
            
            return patients;
        }
        
        
        private void FillResources()
        {
            //fill resources here
            this.m_listResource.Items.Clear();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                ListViewItem item = new ListViewItem(userResource.Resource.Name);
                item.Tag = userResource;
                item.Checked = false;
                
                this.m_listResource.Items.Add(item);
            }
        }
        
        private void FillStateBox()
        {
            var pBox = this.StatusBox;
            
            TTComboBoxItem it0 = new TTComboBoxItem("", "");
            pBox.Items.Add(it0);
            
            TTComboBoxItem it1 = new TTComboBoxItem("İptaller", "CANCELLED");
            pBox.Items.Add(it1);

            TTComboBoxItem it2 = new TTComboBoxItem("Başarılı Tamamlanmış", "SUCCESSFUL");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Başarısız Tamamlanmış", "UNSUCCESSFUL");
            pBox.Items.Add(it3);
            
            TTComboBoxItem it4 = new TTComboBoxItem("Tamamlanmamış", "UNCOMPLETED");
            pBox.Items.Add(it4);
        }
        
        private void LoadCriteria()
        {
            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM != null && !string.IsNullOrEmpty(crValM.Value))
            {
                string[] values = crValM.Value.Split(',');
                foreach(string ID in values)
                {
                    this.SelectResource(ID);
                }
            }
            
            CriteriaValue crValP = this.GetCriteriaValue("EPISODE.PATIENT");
            if(crValP != null && !string.IsNullOrEmpty(crValP.Value))
            {
                try
                {
                    BindingList<Patient> plist = Patient.GetPatientByID(this.m_context, crValP.Value);
                    this.PatientBox.Text = plist[0].ID.Value.ToString() + " " + plist[0].FullName;
                    this.PatientBox.Tag = plist[0];
                }
                catch(Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
            
            CriteriaValue crValS = this.GetCriteriaValue("CURRENTSTATE");
            if(crValS != null && !string.IsNullOrEmpty(crValS.Value))
            {
                TTComboBoxItem pItem = null;
                foreach(TTComboBoxItem item in this.StatusBox.Items)
                {
                    if (item.Value.ToString() == crValS.Value.ToString())
                        pItem = item;
                }
                
                this.StatusBox.SelectedItem = pItem;
            }
            
            CriteriaValue crValE = this.GetCriteriaValue("EMERGENCY");
            if(crValE != null && !string.IsNullOrEmpty(crValE.Value))
            {
                this.Emergency.Value = bool.Parse(crValE.Value);
            }
            else
                this.Emergency.Value = null;
        }
        
        private void SelectResource(string ID)
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if(ID == userResource.ObjectID.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        
        private void SaveCriteria()
        {
            try
            {
                //MASTERRESOURCE
                string sResources = "";
                int nCounter = 0;
                foreach(ListViewItem item in this.m_listResource.CheckedItems)
                {
                    UserResource res = (UserResource)item.Tag;
                    sResources += res.Resource.ObjectID.ToString();
                    if((nCounter + 1) < this.m_listResource.CheckedItems.Count)
                        sResources += ",";
                    nCounter++;
                }
                
                CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
                if(crValM == null)
                {
                    CriteriaValue newCrVal = new CriteriaValue(this.m_context);
                    newCrVal.Value = this.StatusBox.Text;
                    newCrVal.User = Common.CurrentResource;
                    newCrVal.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                    newCrVal.PCriteriaValue = this.GetCriteriaDefinition("MASTERRESOURCE");
                    newCrVal.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValM.Value = sResources;
                }
                
                //EPISODE.PATIENT
                Patient pPat = this.PatientBox.Tag as Patient;
                string sPID = "";
                if(pPat != null)
                    sPID = pPat.ObjectID.ToString();
                
                if(string.IsNullOrEmpty(this.PatientBox.Text))
                    sPID = "";
                
                CriteriaValue crValP = this.GetCriteriaValue("EPISODE.PATIENT");
                if(crValP == null)
                {
                    CriteriaValue newCrValP = new CriteriaValue(this.m_context);
                    newCrValP.Value = sPID;
                    newCrValP.User = Common.CurrentResource;
                    newCrValP.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                    newCrValP.PCriteriaValue = this.GetCriteriaDefinition("EPISODE.PATIENT");
                    newCrValP.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValP.Value = sPID;
                }
                
                //ID
                CriteriaValue crValID = this.GetCriteriaValue("ID");
                if(crValID == null)
                {
                    CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                    newCrValID.Value = this.ActionID.Text;
                    newCrValID.User = Common.CurrentResource;
                    newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                    newCrValID.PCriteriaValue = this.GetCriteriaDefinition("ID");
                    newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValID.Value = this.ActionID.Text;
                }
                
                //STATE
                CriteriaValue crValS = this.GetCriteriaValue("CURRENTSTATE");
                if(crValS == null)
                {
                    CriteriaValue newCrValS = new CriteriaValue(this.m_context);
                    newCrValS.Value = this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString();
                    newCrValS.User = Common.CurrentResource;
                    newCrValS.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                    newCrValS.PCriteriaValue = this.GetCriteriaDefinition("CURRENTSTATE");
                    newCrValS.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValS.Value = this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString();
                }
                
                //EMERGENCY
                CriteriaValue crValEm = this.GetCriteriaValue("EMERGENCY");
                if(crValEm == null)
                {
                    CriteriaValue newCrValEm = new CriteriaValue(this.m_context);
                    newCrValEm.Value = this.Emergency.ControlValue.ToString();
                    newCrValEm.User = Common.CurrentResource;
                    newCrValEm.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                    newCrValEm.PCriteriaValue = this.GetCriteriaDefinition("EMERGENCY");
                    newCrValEm.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValEm.Value = this.Emergency.Value != null ? this.Emergency.Value.ToString() : null;
                }
                
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            IList episodeActionList = new List<EpisodeAction>();
            IList subactionProcedureList = new List<SubactionProcedureFlowable>();
            
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                return episodeActionList = EpisodeAction.GetByWorklistDate(context,dtStart,dtEnd,Common.MinDateTime(),sExpression);
            }
            else
            {
                return episodeActionList = EpisodeAction.GetByFilterExpression(context,sExpression);
            }
            //return EpisodeAction.GetActionsForWorklist(dtStart, dtEnd, sExpression);
        }
        
        public override void OnSave()
        {
            this.SaveCriteria();
        }
        
#endregion PatientWLCriteriaForm_Methods
    }
}