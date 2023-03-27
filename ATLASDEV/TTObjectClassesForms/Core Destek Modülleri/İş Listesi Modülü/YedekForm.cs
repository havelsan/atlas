
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
    /// Yedek Form
    /// </summary>
    public partial class YedekForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region YedekForm_SelectButton_Click
   if(!string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
#endregion YedekForm_SelectButton_Click
        }

#region YedekForm_Methods
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
            this.FillPatientStatusBox();
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
        
        private void ShowSearchForm()
        {
            using(PatientSearchForm theForm = new PatientSearchForm())
            {
                Patient patient = (Patient)theForm.GetSelectedObject();
                if(patient != null)
                {
                    this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
                    this.PatientBox.Tag = patient;
                }
            }
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
            
            TTComboBoxItem it1 = new TTComboBoxItem("İptaller", "STATE_IS_CANCELLED");
            pBox.Items.Add(it1);

            TTComboBoxItem it2 = new TTComboBoxItem("Başarılı Tamamlanmış", "STATE_IS_SUCCESSFUL");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Başarısız Tamamlanmış", "STATE_IS_UNSUCCESSFUL");
            pBox.Items.Add(it3);
            
            TTComboBoxItem it4 = new TTComboBoxItem("Tamamlanmamış", "STATE_IS_UNCOMPLETED");
            pBox.Items.Add(it4);
        }
        
        private void FillPatientStatusBox()
        {
            ComboBox pBox = (ComboBox)this.PatientStatus;
            
            TTComboBoxItem it0 = new TTComboBoxItem("", "");
            pBox.Items.Add(it0);
            
            TTComboBoxItem it1 = new TTComboBoxItem("Ayaktan", "0");
            pBox.Items.Add(it1);

            TTComboBoxItem it2 = new TTComboBoxItem("Yatan", "1");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Taburcu", "2");
            pBox.Items.Add(it3);
            
        }
        
        private void LoadCriteria()
        {
//            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
//            if(crValM != null && !string.IsNullOrEmpty(crValM.Value))
//            {
//                string[] values = crValM.Value.Split(',');
//                foreach(string ID in values)
//                {
//                    this.SelectResource(ID);
//                }
//            }
//            
//            CriteriaValue crValP = this.GetCriteriaValue("EPISODE.PATIENT");
//            if(crValP != null && !string.IsNullOrEmpty(crValP.Value))
//            {
//                try
//                {
//                    BindingList<Patient> plist = Patient.GetPatientByID(this.m_context, crValP.Value);
//                    this.PatientBox.Text = plist[0].ID.Value.ToString() + " " + plist[0].FullName;
//                    this.PatientBox.Tag = plist[0];
//                }
//                catch(Exception ex)
//                {
//                    InfoBox.Show(ex);
//                }
//            }
//            
//            CriteriaValue crValS = this.GetCriteriaValue("STATE_STATUS");
//            if(crValS != null && !string.IsNullOrEmpty(crValS.Value))
//            {
//                TTComboBoxItem pItem = null;
//                foreach(TTComboBoxItem item in this.StatusBox.Items)
//                {
//                    if(item.Value == crValS.Value)
//                        pItem = item;
//                }
//                
//                this.StatusBox.SelectedItem = pItem;
//            }
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
                
                CriteriaValue crValP = this.GetCriteriaValue("EPISODE.PATIENT");
                if(crValP == null)
                {
                    CriteriaValue newCrValP = new CriteriaValue(this.m_context);
                    newCrValP.Value = sPID;
                    newCrValP.User = Common.CurrentResource;
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
                    newCrValID.PCriteriaValue = this.GetCriteriaDefinition("ID");
                    newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValID.Value = this.ActionID.Text;
                }
                
                //EMERGENCY
                CriteriaValue crValEmergency = this.GetCriteriaValue("EMERGENCY");
                if(crValEmergency == null)
                {
                    CriteriaValue newCrValEmergency = new CriteriaValue(this.m_context);
                    if (this.chkEmergency.Value == true)
                        newCrValEmergency.Value = this.chkEmergency.Value.ToString();
                    else
                        newCrValEmergency.Value = "";
                    newCrValEmergency.User = Common.CurrentResource;
                    newCrValEmergency.PCriteriaValue = this.GetCriteriaDefinition("EMERGENCY");
                    newCrValEmergency.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    if (this.chkEmergency.Value == true)
                        crValEmergency.Value = this.chkEmergency.Value.ToString();
                    else
                        crValEmergency.Value = "";
                }
                
                
                //EPISODE.PATIENTSTATUS
                CriteriaValue crValPatientStatus = this.GetCriteriaValue("EPISODE.PATIENTSTATUS");
                if(crValPatientStatus == null)
                {
                    CriteriaValue newCrValPatientStatus = new CriteriaValue(this.m_context);
                    newCrValPatientStatus.Value = this.PatientStatus.SelectedItem == null ? "" : this.PatientStatus.SelectedItem.Value.ToString(); //(this.PatientStatus.ControlValue != null ? ((PatientStatusEnum)this.PatientStatus.ControlValue).GetHashCode().ToString() : String.Empty);
                    newCrValPatientStatus.User = Common.CurrentResource;
                    newCrValPatientStatus.PCriteriaValue = this.GetCriteriaDefinition("EPISODE.PATIENTSTATUS");
                    newCrValPatientStatus.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValPatientStatus.Value = this.PatientStatus.SelectedItem == null ? "" : this.PatientStatus.SelectedItem.Value.ToString(); //(this.PatientStatus.ControlValue != null ? ((PatientStatusEnum)this.PatientStatus.ControlValue).GetHashCode().ToString() : String.Empty);
                }
                
                //STATE
                CriteriaValue crValS = this.GetCriteriaValue("STATE_STATUS");
                if(crValS == null)
                {
                    CriteriaValue newCrValS = new CriteriaValue(this.m_context);
                    newCrValS.Value = this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString();
                    newCrValS.User = Common.CurrentResource;
                    newCrValS.PCriteriaValue = this.GetCriteriaDefinition("STATE_STATUS");
                    newCrValS.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValS.Value = this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString();
                }
                
                //PLANLI GÖREVLER
                CriteriaValue crValPlan = this.GetCriteriaValue("ORDEROBJECT");
                if(crValPlan == null)
                {
                    CriteriaValue newCrValPlan = new CriteriaValue(this.m_context);
                    newCrValPlan.Value = (this.chkPlan.Value == false ? "IS NULL" : "");
                    newCrValPlan.User = Common.CurrentResource;
                    newCrValPlan.PCriteriaValue = this.GetCriteriaDefinition("ORDEROBJECT");
                    newCrValPlan.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValPlan.Value = (this.chkPlan.Value == false ? "IS NULL" : "");
                }
                
                //STATE
                CriteriaValue crValW = this.GetCriteriaValue("WORKLISTDATE");
                if(crValW == null)
                {
                    CriteriaValue newCrValW = new CriteriaValue(this.m_context);
                    newCrValW.Value = this.GetCriteriaDefinition("WORKLISTDATE").DefaultValue;
                    newCrValW.User = Common.CurrentResource;
                    newCrValW.PCriteriaValue = this.GetCriteriaDefinition("WORKLISTDATE");
                    newCrValW.PCriteriaValue.Criteria = this.m_ownerDefinition;
                }
                else
                {
                    crValW.Value = this.GetCriteriaDefinition("WORKLISTDATE").DefaultValue;
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if(this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);

            IList episodeActionList = new List<EpisodeAction>();
            IList subactionProcedureList = new List<SubactionProcedureFlowable>();
            
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                episodeActionList = EpisodeAction.GetByWorklistDate(context,dtStart,dtEnd,Common.MinDateTime(),sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetByWorklistDate(context,dtStart,dtEnd,Common.MinDateTime(),sExpression);
            }
            else
            {
                episodeActionList = EpisodeAction.GetByFilterExpression(context,sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetByFilterExpression(context,sExpression);
            }
            
            IList instanceList = new List<TTObject>();
            
            foreach (TTObject objEA in episodeActionList)
            {
                instanceList.Add(objEA);
            }
            
            foreach (TTObject objSP in subactionProcedureList)
            {
                instanceList.Add(objSP);
            }
            return instanceList;
        }
        
        public override void OnSave()
        {
            this.SaveCriteria();
        }
        
#endregion YedekForm_Methods
    }
}