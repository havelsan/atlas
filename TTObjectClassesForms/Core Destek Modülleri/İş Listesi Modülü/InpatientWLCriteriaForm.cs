
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
    /// Yatan Hasta İş Listesi
    /// </summary>
    public partial class InpatientWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click += new TTControlEventDelegate(ClearButton_Click);
            SecMasterSelectAll.Click += new TTControlEventDelegate(SecMasterSelectAll_Click);
            SecMasterClearButton.Click += new TTControlEventDelegate(SecMasterClearButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click -= new TTControlEventDelegate(ClearButton_Click);
            SecMasterSelectAll.Click -= new TTControlEventDelegate(SecMasterSelectAll_Click);
            SecMasterClearButton.Click -= new TTControlEventDelegate(SecMasterClearButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region InpatientWLCriteriaForm_SelectButton_Click
   if(!string.IsNullOrEmpty(this.PatientBox.Text))
                 SearchPatient(this.PatientBox.Text);
#endregion InpatientWLCriteriaForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region InpatientWLCriteriaForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion InpatientWLCriteriaForm_ttbutton1_Click
        }

        private void SelectAllButton_Click()
        {
#region InpatientWLCriteriaForm_SelectAllButton_Click
   this.CheckUnCheckAll(true);
#endregion InpatientWLCriteriaForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region InpatientWLCriteriaForm_ClearButton_Click
   this.CheckUnCheckAll(false);
#endregion InpatientWLCriteriaForm_ClearButton_Click
        }

        private void SecMasterSelectAll_Click()
        {
#region InpatientWLCriteriaForm_SecMasterSelectAll_Click
   this.CheckUnCheckAllSecMResources(true);
#endregion InpatientWLCriteriaForm_SecMasterSelectAll_Click
        }

        private void SecMasterClearButton_Click()
        {
#region InpatientWLCriteriaForm_SecMasterClearButton_Click
   this.CheckUnCheckAllSecMResources(false);
#endregion InpatientWLCriteriaForm_SecMasterClearButton_Click
        }

#region InpatientWLCriteriaForm_Methods
        ListView m_listResource = null;
        ListView secm_listResource = null;
        CheckedComboBox m_chCombo = new CheckedComboBox();
        CheckedComboBox secm_chCombo = new CheckedComboBox();

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            TextBox pBox = (TextBox)this.PatientBox;
            pBox.KeyUp += new KeyEventHandler(this.OnPatientBoxKeyUp);
            
            m_listResource = (ListView)this.MResources;
            m_listResource.CheckBoxes = true;
            
            secm_listResource = (ListView)this.SecMResources;
            secm_listResource.CheckBoxes = true;
            
            this.FillResources();
            this.LoadCriteria();
            this.FillStateBox();
            this.FillPatientStatusBox();
            this.InitCheckedCombo();
        }
        
        private void InitCheckedCombo()
        {
            this.m_chCombo.CheckOnClick = true;
            this.m_chCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.m_chCombo.DropDownHeight = 1;
            this.m_chCombo.FormattingEnabled = true;
            this.m_chCombo.IntegralHeight = false;
            //this.m_chCombo.Location = TestCombo.Location;
            this.m_chCombo.Name = "checkedComboBox1";
            //this.m_chCombo.Size = TestCombo.Size;
            this.m_chCombo.TabIndex = 10;
            this.m_chCombo.ValueSeparator = ", ";
            
            this.Controls.Add(this.m_chCombo);
            
            this.secm_chCombo.CheckOnClick = true;
            this.secm_chCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.secm_chCombo.DropDownHeight = 1;
            this.secm_chCombo.FormattingEnabled = true;
            this.secm_chCombo.IntegralHeight = false;
            //this.secm_chCombo.Location = SecMasterResourcesCombo.Location;
            this.secm_chCombo.Name = "checkedComboBox2";
            //this.secm_chCombo.Size = SecMasterResourcesCombo.Size;
            this.secm_chCombo.TabIndex = 10;
            this.secm_chCombo.ValueSeparator = ", ";
            
            this.Controls.Add(this.secm_chCombo);
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
        
        private void FillResources()
        {
            //fill resources here
            this.m_listResource.Items.Clear();
            SortedList<string,UserResource> sList = new SortedList<string,UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(),userResource);
            }
            
            foreach(KeyValuePair<string,UserResource> kvp in sList)
            {
                UserResource uRes =(UserResource)kvp.Value;
                ListViewItem item = new ListViewItem(uRes.Resource.Name);
                item.Tag = uRes;
                item.Checked = false;
                
                this.m_listResource.Items.Add(item);
            }
            
            this.secm_listResource.Items.Clear();
            SortedList<string,UserResource> secList = new SortedList<string,UserResource>();
            foreach (UserResource secUserResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(secUserResource.Resource is ResRoomGroup)
                {
                    if(secList.ContainsKey(secUserResource.Resource.Name + secUserResource.Resource.ObjectID.ToString()) == false)
                        secList.Add(secUserResource.Resource.Name + secUserResource.Resource.ObjectID.ToString(),secUserResource);
                }
            }
            
            foreach(KeyValuePair<string,UserResource> skvp in secList)
            {
                UserResource uSecRes =(UserResource)skvp.Value;
                ListViewItem sItem = new ListViewItem(uSecRes.Resource.Name);
                sItem.Tag = uSecRes;
                sItem.Checked = false;
                
                this.secm_listResource.Items.Add(sItem);
            }
        }
        
        private void FillLoadResourceCombo()
        {
            //fill resources here
            this.m_chCombo.Items.Clear();
            SortedList<string,UserResource> sList = new SortedList<string,UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(),userResource);
            }

            string[] values = null;
            CriteriaValue crValM1 = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM1 != null && !string.IsNullOrEmpty(crValM1.Value))
            {
                values = crValM1.Value.Split(',');
            }
            
            foreach(KeyValuePair<string,UserResource> kvp in sList)
            {
                TTComboBoxItem item = new TTComboBoxItem(kvp.Value.Resource.Name, kvp.Value);
                bool bChecked = false;
                
                if(values != null)
                {
                    foreach(string ID in values)
                    {
                        if(kvp.Value.Resource.ObjectID.Equals(ID))
                        {
                            bChecked = true;
                            break;
                        }
                    }
                }
                this.m_chCombo.Items.Add(item, bChecked);
            }
            
            this.secm_chCombo.Items.Clear();
            SortedList<string,UserResource> secList = new SortedList<string,UserResource>();
            foreach (UserResource secUserResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if(secUserResource.Resource is ResRoomGroup)
                {
                    if(secList.ContainsKey(secUserResource.Resource.Name + secUserResource.Resource.ObjectID.ToString()) == false)
                        secList.Add(secUserResource.Resource.Name + secUserResource.Resource.ObjectID.ToString(),secUserResource);
                }
            }

            string[] svalues = null;
            CriteriaValue crValM2 = this.GetCriteriaValue("SECONDARYMASTERRESOURCE");
            if(crValM2 != null && !string.IsNullOrEmpty(crValM2.Value))
            {
                svalues = crValM2.Value.Split(',');
            }
            
            foreach(KeyValuePair<string,UserResource> skvp in secList)
            {
                TTComboBoxItem sItem = new TTComboBoxItem(skvp.Value.Resource.Name, skvp.Value);
                bool sbChecked = false;
                
                if(svalues != null)
                {
                    foreach(string ID in svalues)
                    {
                        if(skvp.Value.Resource.ObjectID.Equals(ID))
                        {
                            sbChecked = true;
                            break;
                        }
                    }
                }
                this.secm_chCombo.Items.Add(sItem, sbChecked);
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
        
        private void FillPatientStatusBox()
        {
            ComboBox pBox = (ComboBox)this.PatientStatus;
            
            TTComboBoxItem it0 = new TTComboBoxItem("", "");
            pBox.Items.Add(it0);

            TTComboBoxItem it2 = new TTComboBoxItem("Yatan", "1");
            pBox.Items.Add(it2);
            
            TTComboBoxItem it3 = new TTComboBoxItem("Taburcu", "2");
            pBox.Items.Add(it3);
            
        }
        
        private void LoadCriteria()
        {
            this.DeSelectAllResources();
            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
            if(crValM != null && !string.IsNullOrEmpty(crValM.Value))
            {
                string[] values = crValM.Value.Split(',');
                foreach(string ID in values)
                {
                    this.SelectResource(ID);
                }
            }
            
            CriteriaValue scrValM = this.GetCriteriaValue("SECONDARYMASTERRESOURCE");
            if(scrValM != null && !string.IsNullOrEmpty(scrValM.Value))
            {
                string[] sValues = scrValM.Value.Split(',');
                foreach(string sID in sValues)
                {
                    this.SelectSecMasterResource(sID);
                }
            }

            this.FillLoadResourceCombo();
            
            this.chkPlan.Value = false;
            CriteriaValue crValPlan = this.GetCriteriaValue("ORDEROBJECT");
            if(crValPlan != null)
            {
                if(crValPlan.Value == "IS NULL")
                    this.chkPlan.Value = false;
                else
                    this.chkPlan.Value = true;
            }
            else
                this.chkPlan.Value = false;
            
            this.StatusBox.SelectedItem = null;
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
            
            this.chkEmergency.Value = false;
            CriteriaValue crValEmergency = this.GetCriteriaValue("EMERGENCY");
            if(crValEmergency != null)
            {
                if(crValEmergency.Value == "True")
                    this.chkEmergency.Value = true;
                else
                    this.chkEmergency.Value = false;
            }
            else
                this.chkEmergency.Value = false;
            
            this.PatientStatus.SelectedItem = null;
            CriteriaValue crValPatientStatus = this.GetCriteriaValue("THIS:EPISODE:PATIENTSTATUS");
            if(crValPatientStatus != null && !string.IsNullOrEmpty(crValPatientStatus.Value))
            {
                TTComboBoxItem pItem = null;
                foreach(TTComboBoxItem item in this.PatientStatus.Items)
                {
                    if (item.Value.ToString() == crValPatientStatus.Value.ToString())
                        pItem = item;
                }

                this.PatientStatus.SelectedItem = pItem;
            }
        }
        
        private void DeSelectAllResources()
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                item.Checked = false;
            }
            
            foreach (ListViewItem sItem in this.secm_listResource.Items)
            {
                sItem.Checked = false;
            }
        }
        
        private void SelectResource(string ID)
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if(ID == userResource.Resource.ObjectID.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        
        private void SelectSecMasterResource(string ID)
        {
            foreach (ListViewItem item in this.secm_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if(ID == userResource.Resource.ObjectID.ToString())
                {
                    item.Checked = true;
                    break;
                }
            }
        }
        
        private string PrivacyOfPatientExpression()
        {
            string appendExpression = String.Empty;
            if(this.chkPrivacyPatient.Value == false && this.PatientBox.Tag == null)
            {
                appendExpression = "AND (THIS:EPISODE:PATIENT.PRIVACY IS NULL OR THIS:EPISODE:PATIENT.PRIVACY = 0 OR THIS:EPISODE:PATIENT.PRIVACYENDDATE IS NULL OR THIS:EPISODE:PATIENT.PRIVACYENDDATE < GETDATE())";
            }
            else
            {
                appendExpression = "";
            }
            return appendExpression;
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            
             sExpression = PrivacyOfPatientExpression() + sExpression;
            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if(this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);

            IList episodeActionList = new List<TTReportNqlObject>();
            IList subactionProcedureList = new List<TTReportNqlObject>();
            
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                episodeActionList = EpisodeAction.GetByEpisodeActionWorklistDateReport(dtStart,dtEnd,Common.MinDateTime(),sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetBySPFWorklistDateReport(dtStart,dtEnd,Common.MinDateTime(),sExpression);
            }
            else
            {
                episodeActionList = EpisodeAction.GetByEpisodeActionFilterExpressionReport(sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetBySPFFilterExpressionReport(sExpression);
            }
            
            IList instanceList = new List<TTReportNqlObject>();
            
            foreach (TTReportNqlObject objEA in episodeActionList)
            {
                instanceList.Add(objEA);
            }
            
            foreach (TTReportNqlObject objSP in subactionProcedureList)
            {
                instanceList.Add(objSP);
            }
            return instanceList;
            
        }
        
        public override IList ExecuteReportNQL(string sExpression)
        {
             sExpression = PrivacyOfPatientExpression() + sExpression;
            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if(this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);

            IList episodeActionList = new List<TTReportNqlObject>();
            IList subactionProcedureList = new List<TTReportNqlObject>();
            
            episodeActionList = EpisodeAction.GetByEpisodeActionFilterExpressionReport(sExpression);
            subactionProcedureList = SubactionProcedureFlowable.GetBySPFFilterExpressionReport(sExpression);
            
            IList instanceList = new List<TTReportNqlObject>();
            
            foreach (TTReportNqlObject objEA in episodeActionList)
            {
                instanceList.Add(objEA);
            }
            
            foreach (TTReportNqlObject objSP in subactionProcedureList)
            {
                instanceList.Add(objSP);
            }
            return instanceList;
            
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            int maxDayCount = 7;
            string maxDayCountString = TTObjectClasses.SystemParameter.GetParameterValue("WorkListMaxDayToSearch","7");
            if(!int.TryParse(maxDayCountString,out maxDayCount))
                maxDayCount = 7;
            if(maxDayCount > 0)
            {
                if(Common.DateDiff(Common.DateIntervalEnum.Day,dtEnd,dtStart) > maxDayCount)
                    throw new Exception("İş Listesi Kriterlerinden 'Başlangıç Tarihi' ve  'Bitiş Tarihi' arasında " + maxDayCount.ToString() + " günden fazla iken sorgulama yapılamaz.");
            }
            
            sExpression = PrivacyOfPatientExpression() + sExpression;
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
        
        private void CheckUnCheckAll(bool bCheck)
        {
            for (int i = 0; i < this.m_chCombo.Items.Count; i++)
            {
                this.m_chCombo.SetItemChecked(i, bCheck);
            }
        }
        
        private void CheckUnCheckAllSecMResources(bool bCheck)
        {
            for (int i = 0; i < this.secm_chCombo.Items.Count; i++)
            {
                this.secm_chCombo.SetItemChecked(i, bCheck);
            }
        }
        
        public override void OnSave()
        {
            try
            {  //MASTERRESOURCE
                string sResources = "";
                //SECONDARYMASTERRESOURCE
                string secMasterResources = "";
                //EPISODE.PATIENT
                string sPID = "";
                //EMERGENCY
                string emValue = "";
                //EPISODE.PATIENTSTATUS
                string ptValue = "";
                //EPISODE.PATIENT.INPATIENTEPISODE
                string inptValue = "";
                //STATE
                string stateValue = "";
                //PLANLI GÖREVLER
                string orderObjectValue = "";
                //ID
                string IDValue = "";
                
                if(String.IsNullOrEmpty(this.ActionID.Text) == false)
                {
                    IDValue = this.ActionID.Text;
                }
                else
                {
                    //MASTERRESOURCE
                    
                    int nCounter = 0;
                    foreach(TTComboBoxItem item in this.m_chCombo.CheckedItems)
                    {
                        UserResource res = (UserResource)item.Value;
                        sResources += res.Resource.ObjectID.ToString();
                        if((nCounter + 1) < this.m_chCombo.CheckedItems.Count)
                            sResources += ",";
                        nCounter++;
                    }
                    
                    //SECONDARYMASTERRESOURCE
                    
                    int snCounter = 0;
                    foreach(TTComboBoxItem sItem in this.secm_chCombo.CheckedItems)
                    {
                        UserResource secRes = (UserResource)sItem.Value;
                        secMasterResources += secRes.Resource.ObjectID.ToString();
                        if((snCounter + 1) < this.secm_chCombo.CheckedItems.Count)
                            secMasterResources += ",";
                        snCounter++;
                    }
                    
                    //EPISODE.PATIENT
                    Patient pPat = this.PatientBox.Tag as Patient;
                    
                    if(pPat != null)
                        sPID = pPat.ObjectID.ToString();
                    
                    if(string.IsNullOrEmpty(this.PatientBox.Text))
                    {
                        sPID = "";
                        this.PatientBox.Tag = null;
                    }
                    
                    //EMERGENCY
                    if (this.chkEmergency.Value == true)
                        emValue = this.chkEmergency.Value.ToString();
                    else
                        emValue = "";

                    //EPISODE.PATIENTSTATUS
                    ptValue = this.PatientStatus.SelectedItem == null ? "" : this.PatientStatus.SelectedItem.Value.ToString();
                    
                    //EPISODE.PATIENT.INPATIENTEPISODE
                    if(this.PatientStatus.SelectedItem != null)
                        inptValue = this.PatientStatus.SelectedItem.Value.ToString() == "0" ? "IS NULL" : ""; // Ayaktansa Yatan Episodu olanlar gelmesin
                    else
                        inptValue = "";
                    
                    //STATE
                    if(this.StatusBox.SelectedItem == null)
                        stateValue = "";
                    else
                        stateValue = this.StatusBox.SelectedItem.Value.ToString();
                    
                    //PLANLI GÖREVLER
                    if(this.chkPlan.Value == false)
                        orderObjectValue = "IS NULL";
                    else
                        orderObjectValue = "";
                    
                }
                
                //ID
                this.SaveCriteria("ID","System.Int64",IDValue);
                
                //MASTERRESOURCE
                this.SaveCriteria("MASTERRESOURCE","System.String",sResources);
                
                //SECONDARYMASTERRESOURCE
                this.SaveCriteria("SECONDARYMASTERRESOURCE","System.String",secMasterResources);

                //EPISODE.PATIENT
                this.SaveCriteria("THIS:EPISODE:PATIENT","System.String",sPID);

                //EMERGENCY
                this.SaveCriteria("EMERGENCY","System.Boolean",emValue);

                //EPISODE.PATIENTSTATUS
                this.SaveCriteria("THIS:EPISODE:PATIENTSTATUS","System.String",ptValue);
                
                //EPISODE.PATIENT.INPATIENTEPISODE
                this.SaveCriteria("THIS:EPISODE:PATIENT.INPATIENTEPISODE","System.String",inptValue);
                
                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",stateValue);
                
                //PLANLI GÖREVLER
                this.SaveCriteria("ORDEROBJECT","System.String",orderObjectValue);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        public override void OnLoadCriteria()
        {
            this.LoadCriteria();
        }
        
#endregion InpatientWLCriteriaForm_Methods
    }
}