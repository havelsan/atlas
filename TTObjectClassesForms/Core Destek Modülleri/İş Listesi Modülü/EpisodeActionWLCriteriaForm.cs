
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
    public partial class EpisodeActionWLCriteriaForm : BaseCriteriaForm
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
#region EpisodeActionWLCriteriaForm_SelectButton_Click
   if (!string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
#endregion EpisodeActionWLCriteriaForm_SelectButton_Click
        }

        private void ttbutton1_Click()
        {
#region EpisodeActionWLCriteriaForm_ttbutton1_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion EpisodeActionWLCriteriaForm_ttbutton1_Click
        }

        private void SelectAllButton_Click()
        {
#region EpisodeActionWLCriteriaForm_SelectAllButton_Click
   this.CheckUnCheckAll(true);
#endregion EpisodeActionWLCriteriaForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region EpisodeActionWLCriteriaForm_ClearButton_Click
   this.CheckUnCheckAll(false);
#endregion EpisodeActionWLCriteriaForm_ClearButton_Click
        }

#region EpisodeActionWLCriteriaForm_Methods
        ListView m_listResource = null;
        CheckedComboBox m_chCombo = new CheckedComboBox();

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
        }

        private void OnPatientBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && !string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
        }

        private void SearchPatient(string sText)
        {
            Patient patient = PatientAdmission.GetPatientBySearch(sText);
            if (patient != null)
            {
                this.PatientBox.Text = patient.ID.Value.ToString() + " " + patient.FullName;
                this.PatientBox.Tag = patient;
            }
        }

        private void FillResources()
        {
            //fill resources here
            this.m_listResource.Items.Clear();
            SortedList<string, UserResource> sList = new SortedList<string, UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if (sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(), userResource);
            }

            foreach (KeyValuePair<string, UserResource> kvp in sList)
            {
                UserResource uRes = (UserResource)kvp.Value;
                ListViewItem item = new ListViewItem(uRes.Resource.Name);
                item.Tag = uRes;
                item.Checked = false;

                this.m_listResource.Items.Add(item);
            }
        }

        private void FillLoadResourceCombo()
        {
            //fill resources here
            this.m_chCombo.Items.Clear();
            SortedList<string, UserResource> sList = new SortedList<string, UserResource>();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                if (sList.ContainsKey(userResource.Resource.Name + userResource.Resource.ObjectID.ToString()) == false)
                    sList.Add(userResource.Resource.Name + userResource.Resource.ObjectID.ToString(), userResource);
            }

            string[] values = null;
            CriteriaValue crValM1 = this.GetCriteriaValue("MASTERRESOURCE");
            if (crValM1 != null && !string.IsNullOrEmpty(crValM1.Value))
            {
                values = crValM1.Value.Split(',');
            }

            foreach (KeyValuePair<string, UserResource> kvp in sList)
            {
                TTComboBoxItem item = new TTComboBoxItem(kvp.Value.Resource.Name, kvp.Value);
                bool bChecked = false;

                if (values != null)
                {
                    foreach (string ID in values)
                    {
                        if (kvp.Value.Resource.ObjectID.Equals(ID))
                        {
                            bChecked = true;
                            break;
                        }
                    }
                }
                this.m_chCombo.Items.Add(item, bChecked);
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

            pBox.SelectedItem = it4;
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

            pBox.SelectedItem = it0;

        }

        private void LoadCriteria()
        {
            this.DeSelectAllResources();
            CriteriaValue crValM = this.GetCriteriaValue("MASTERRESOURCE");
            if (crValM != null && !string.IsNullOrEmpty(crValM.Value))
            {
                string[] values = crValM.Value.Split(',');
                foreach (string ID in values)
                {
                    this.SelectResource(ID);
                }
            }


            this.FillLoadResourceCombo();

            this.chkPlan.Value = false;
            CriteriaValue crValPlan = this.GetCriteriaValue("ORDEROBJECT");
            if (crValPlan != null)
            {
                if (crValPlan.Value == "IS NULL")
                    this.chkPlan.Value = false;
                else
                    this.chkPlan.Value = true;
            }
            else
                this.chkPlan.Value = false;

            CriteriaValue crValS = this.GetCriteriaValue("CURRENTSTATE");
            if (crValS != null)
            {
                this.StatusBox.SelectedItem = null;
                if (!string.IsNullOrEmpty(crValS.Value))
                {
                    TTComboBoxItem pItem = null;
                    foreach (TTComboBoxItem item in this.StatusBox.Items)
                    {
                        if (item.Value.ToString() == crValS.Value.ToString())
                            pItem = item;
                    }
                    this.StatusBox.SelectedItem = pItem;
                }
            }

            this.chkEmergency.Value = false;
            CriteriaValue crValEmergency = this.GetCriteriaValue("EMERGENCY");
            if (crValEmergency != null)
            {
                if (crValEmergency.Value == "True")
                    this.chkEmergency.Value = true;
                else
                    this.chkEmergency.Value = false;
            }
            else
                this.chkEmergency.Value = false;

            CriteriaValue crValPatientStatus = this.GetCriteriaValue("THIS:EPISODE:PATIENTSTATUS");
            if (crValPatientStatus != null)
            {
                this.PatientStatus.SelectedItem = null;
                if (!string.IsNullOrEmpty(crValPatientStatus.Value))
                {
                    TTComboBoxItem pItem = null;
                    foreach (TTComboBoxItem item in this.PatientStatus.Items)
                    {
                        if (item.Value.ToString() == crValPatientStatus.Value.ToString())
                            pItem = item;
                    }

                    this.PatientStatus.SelectedItem = pItem;
                }
            }
            
            this.chkPrivacyPatient.Value = false;
            CriteriaValue crValPrivacyPatient = this.GetCriteriaValue("THIS:EPISODE:PATIENT.PRIVACY");
            if (crValPrivacyPatient != null)
            {
                if (crValPrivacyPatient.Value == "True")
                    this.chkPrivacyPatient.Value = true;
                else
                    this.chkPrivacyPatient.Value = false;
            }
            else
                this.chkPrivacyPatient.Value = false;

            this.chkOnlyAuthorizedUser.Value = false;
            CriteriaValue chkOnlyAuthorizedUser = this.GetCriteriaValue("THIS:PROCEDUREDOCTOR");
            if (chkOnlyAuthorizedUser != null)
            {
                if (chkOnlyAuthorizedUser.Value == "True")
                    this.chkOnlyAuthorizedUser.Value = true;
                else
                    this.chkOnlyAuthorizedUser.Value = false;
            }
            else
                this.chkOnlyAuthorizedUser.Value = false;
        }

        private void DeSelectAllResources()
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                item.Checked = false;
            }
        }

        private void SelectResource(string ID)
        {
            foreach (ListViewItem item in this.m_listResource.Items)
            {
                UserResource userResource = (UserResource)item.Tag;
                if (ID == userResource.Resource.ObjectID.ToString())
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

        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression, List<TTObjectStateDef> selectedStateDefs)
        {
            Common.CheckWorklistDayLimit(dtStart, dtEnd);
            
            sExpression = PrivacyOfPatientExpression() + sExpression;
            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if (this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);
    
            IList episodeActionList = null;
            IList subactionProcedureList = null;
            bool queryEpisodeAction, querySubAction;
            if (selectedStateDefs == null)
            {
                queryEpisodeAction = true;
                querySubAction = true;
            }
            else
            {
                queryEpisodeAction = false;
                querySubAction = false;

                foreach (TTObjectStateDef stateDef in selectedStateDefs)
                {
                    if (queryEpisodeAction == false && stateDef.ObjectDef.IsOfType("EPISODEACTION"))
                    {
                        queryEpisodeAction = true;
                        if (querySubAction)
                            break;
                    }
                    if (querySubAction == false && stateDef.ObjectDef.IsOfType("SUBACTIONPROCEDUREFLOWABLE"))
                    {
                        querySubAction = true;
                        if (queryEpisodeAction)
                            break;
                    }
                }

            }

            if (String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                if (queryEpisodeAction)
                    episodeActionList = EpisodeAction.GetByEpisodeActionWorklistDateReport(dtStart, dtEnd, Common.MinDateTime(), sExpression);
                if (querySubAction)
                    subactionProcedureList = SubactionProcedureFlowable.GetBySPFWorklistDateReport(dtStart, dtEnd, Common.MinDateTime(), sExpression);
            }
            else
            {
                if (queryEpisodeAction)
                    episodeActionList = EpisodeAction.GetByEpisodeActionFilterExpressionReport(sExpression);
                if (querySubAction)
                    subactionProcedureList = SubactionProcedureFlowable.GetBySPFFilterExpressionReport(sExpression);
            }

            IList instanceList = new List<TTReportNqlObject>();
            if (episodeActionList != null)
                foreach (TTReportNqlObject objEA in episodeActionList)
                    instanceList.Add(objEA);
            if (subactionProcedureList != null)
                foreach (TTReportNqlObject objSP in subactionProcedureList)
                    instanceList.Add(objSP);
            return instanceList;
        }

        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return ExecuteReportNQL(dtStart, dtEnd, sExpression, null);
        }

        public override IList ExecuteReportNQL(string sExpression)
        {
            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if (this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);

            sExpression = PrivacyOfPatientExpression() + sExpression;
            IList episodeActionList = EpisodeAction.GetByEpisodeActionFilterExpressionReport(sExpression);
            IList subactionProcedureList = SubactionProcedureFlowable.GetBySPFFilterExpressionReport(sExpression);

            IList instanceList = new List<TTReportNqlObject>();
            foreach (TTReportNqlObject objEA in episodeActionList)
                instanceList.Add(objEA);
            foreach (TTReportNqlObject objSP in subactionProcedureList)
                instanceList.Add(objSP);
            return instanceList;

        }

        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            
            Common.CheckWorklistDayLimit(dtStart, dtEnd);
            sExpression = PrivacyOfPatientExpression() + sExpression;

            //Bir iş listesi açıkken listele deyip, listeleme bitmeden başka bir iş listesi açılıp listele denildiğinde sorun çıkarabilir.
            //Çünkü Common.OnlyAuthorizedUser değişkeni static değişken.
            //if (this.chkOnlyAuthorizedUser.Value == true)
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", true);
            //else
            //    SessionExtension.AddToSession("OnlyAuthorizedUser", false);

            IList episodeActionList;
            IList subactionProcedureList;

            if (String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                episodeActionList = EpisodeAction.GetByWorklistDate(context, dtStart, dtEnd, Common.MinDateTime(), sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetByWorklistDate(context, dtStart, dtEnd, Common.MinDateTime(), sExpression);
            }
            else
            {
                episodeActionList = EpisodeAction.GetByFilterExpression(context, sExpression);
                subactionProcedureList = SubactionProcedureFlowable.GetByFilterExpression(context, sExpression);
            }

            IList instanceList = new List<TTObject>();
            if (episodeActionList.Count > 0)
            {
                List<Guid> episodeObjectIDs = new List<Guid>();
                List<Guid> episodeActionIDs = new List<Guid>();
                foreach (EpisodeAction objEA in episodeActionList)
                {
                    instanceList.Add(objEA);
                    episodeObjectIDs.Add((Guid)objEA["EPISODE"]);
                    episodeActionIDs.Add(objEA.ObjectID);
                }

                TTObjectDef objectDef = TTObjectDefManager.Instance.ObjectDefs[typeof(Patient).Name];
                TTObjectRelationDef objectRelationDefEpisode = objectDef.AllChildRelationDefs[new Guid("596e92d0-29fe-4e31-8384-09c780bb8ee5")];
                context.AddRelationDefForLoadChildrenLocally(objectRelationDefEpisode);
                IList episodes = Episode.GetEpisodes(context, episodeObjectIDs);

                List<Guid> patientObjectIDs = new List<Guid>();
                foreach (Episode episode in episodes)
                    patientObjectIDs.Add((Guid)episode["PATIENT"]);
                Patient.GetPatients(context, patientObjectIDs);

                objectDef = TTObjectDefManager.Instance.ObjectDefs[typeof(Episode).Name];
                TTObjectRelationDef objectRelationDefPatientAuthorizedResource = objectDef.AllChildRelationDefs[new Guid("b713c2f5-81fe-4da9-af6f-71d00d7f17e3")];
                context.AddRelationDefForLoadChildrenLocally(objectRelationDefPatientAuthorizedResource);
                PatientAuthorizedResource.GetPatientAuthorizedResourcesByEpisodes(context, episodeObjectIDs);

                objectDef = TTObjectDefManager.Instance.ObjectDefs[typeof(BaseAction).Name];
                TTObjectRelationDef objectRelationDefAuthorizedUser = objectDef.AllChildRelationDefs[new Guid("a390d02c-4ec7-4688-9d1a-2fd1b92b4bec")];
                context.AddRelationDefForLoadChildrenLocally(objectRelationDefAuthorizedUser);
                AuthorizedUser.GetAuthorizedUsersByEpisodeActions(context, episodeObjectIDs);
            }

            foreach (TTObject objSP in subactionProcedureList)
                instanceList.Add(objSP);
            return instanceList;
        }

        private void CheckUnCheckAll(bool bCheck)
        {
            for (int i = 0; i < this.m_chCombo.Items.Count; i++)
            {
                this.m_chCombo.SetItemChecked(i, bCheck);
            }
        }

        public override void OnSave()
        {
            try
            {  //MASTERRESOURCE
                string sResources = "";
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
                //KISISEL GÖREVLER - PROCEDUREDOCTOR
                string sProcedureDoctor = "";
                
                if (String.IsNullOrEmpty(this.ActionID.Text) == false)
                {
                    IDValue = this.ActionID.Text;
                }
                else
                {
                    //MASTERRESOURCE

                    int nCounter = 0;
                    foreach (TTComboBoxItem item in this.m_chCombo.CheckedItems)
                    {
                        UserResource res = (UserResource)item.Value;
                        sResources += res.Resource.ObjectID.ToString();
                        if ((nCounter + 1) < this.m_chCombo.CheckedItems.Count)
                            sResources += ",";
                        nCounter++;
                    }

                    //EPISODE.PATIENT
                    Patient pPat = this.PatientBox.Tag as Patient;

                    if (pPat != null)
                        sPID = pPat.ObjectID.ToString();

                    if (string.IsNullOrEmpty(this.PatientBox.Text))
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
                    if (this.PatientStatus.SelectedItem != null)
                        inptValue = this.PatientStatus.SelectedItem.Value.ToString() == "0" ? "IS NULL" : ""; // Ayaktansa Yatan Episodu olanlar gelmesin
                    else
                        inptValue = "";

                    //STATE
                    if (this.StatusBox.SelectedItem == null)
                        stateValue = "";
                    else
                        stateValue = this.StatusBox.SelectedItem.Value.ToString();

                    //PLANLI GÖREVLER
                    if (this.chkPlan.Value == false)
                        orderObjectValue = "IS NULL";
                    else
                        orderObjectValue = "";
                    
                    //KISISEL GÖREVLER
                    if (this.chkOnlyAuthorizedUser.Value == true)
                        sProcedureDoctor = TTObjectClasses.Common.CurrentResource.ObjectID.ToString();
                    else
                        sProcedureDoctor = "";
                    
                }

                //ID
                this.SaveCriteria("ID", "System.Int64", IDValue);

                //MASTERRESOURCE
                this.SaveCriteria("MASTERRESOURCE", "System.String", sResources);

                //EPISODE.PATIENT
                this.SaveCriteria("THIS:EPISODE:PATIENT", "System.String", sPID);

                //EMERGENCY
                this.SaveCriteria("EMERGENCY", "System.Boolean", emValue);

                //EPISODE.PATIENTSTATUS
                this.SaveCriteria("THIS:EPISODE:PATIENTSTATUS", "System.String", ptValue);

                //EPISODE.PATIENT.INPATIENTEPISODE
                this.SaveCriteria("THIS:EPISODE:PATIENT.INPATIENTEPISODE", "System.String", inptValue);

                //STATE
                this.SaveCriteria("CURRENTSTATE", "STATE", stateValue);

                //PLANLI GÖREVLER
                this.SaveCriteria("ORDEROBJECT", "System.String", orderObjectValue);                
                
                //KISISEL GÖREVLER
                this.SaveCriteria("THIS:PROCEDUREDOCTOR", "System.String", sProcedureDoctor);
            }
            catch (Exception ex)
            {
                InfoBox.Show(ex);
            }
        }

        public override void OnLoadCriteria()
        {
            this.LoadCriteria();
        }


        public override StateStatusEnum? GetStateStatus()
        {
            if (this.StatusBox.SelectedItem == null || this.StatusBox.SelectedItem.Value == null)
                return null;

            switch (this.StatusBox.SelectedItem.Value.ToString())
            {
                case "CANCELLED":
                    return StateStatusEnum.Cancelled;
                case "SUCCESSFUL":
                    return StateStatusEnum.CompletedSuccessfully;
                case "UNSUCCESSFUL":
                    return StateStatusEnum.CompletedUnsuccessfully;
                case "UNCOMPLETED":
                    return StateStatusEnum.Uncompleted;
                default:
                    return null;
            }
        }
        
#endregion EpisodeActionWLCriteriaForm_Methods
    }
}