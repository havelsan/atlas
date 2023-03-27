
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
    public partial class DirectPurchaseActionWorkListForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            SelectButton.Click += new TTControlEventDelegate(SelectButton_Click);
            btnDelete.Click += new TTControlEventDelegate(btnDelete_Click);
            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click += new TTControlEventDelegate(ClearButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SelectButton.Click -= new TTControlEventDelegate(SelectButton_Click);
            btnDelete.Click -= new TTControlEventDelegate(btnDelete_Click);
            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click -= new TTControlEventDelegate(ClearButton_Click);
            base.UnBindControlEvents();
        }

        private void SelectButton_Click()
        {
#region DirectPurchaseActionWorkListForm_SelectButton_Click
   if (!string.IsNullOrEmpty(this.PatientBox.Text))
                SearchPatient(this.PatientBox.Text);
#endregion DirectPurchaseActionWorkListForm_SelectButton_Click
        }

        private void btnDelete_Click()
        {
#region DirectPurchaseActionWorkListForm_btnDelete_Click
   this.PatientBox.Text = "";
            this.PatientBox.Tag = null;
#endregion DirectPurchaseActionWorkListForm_btnDelete_Click
        }

        private void SelectAllButton_Click()
        {
#region DirectPurchaseActionWorkListForm_SelectAllButton_Click
   this.CheckUnCheckAll(true);
#endregion DirectPurchaseActionWorkListForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region DirectPurchaseActionWorkListForm_ClearButton_Click
   this.CheckUnCheckAll(false);
#endregion DirectPurchaseActionWorkListForm_ClearButton_Click
        }

#region DirectPurchaseActionWorkListForm_Methods
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
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression, List<TTObjectStateDef> selectedStateDefs)
        {
            IList directPurchaseActionList = null;
            
            bool querydirectPurchaseAction;
            if (selectedStateDefs == null)
            {
                querydirectPurchaseAction = true;
            }
            else
            {
                querydirectPurchaseAction = false;

                foreach (TTObjectStateDef stateDef in selectedStateDefs)
                {
                    if (querydirectPurchaseAction == false && stateDef.ObjectDef.IsOfType("DIRECTPURCHASEACTION"))
                    {
                        querydirectPurchaseAction = true;
                        break;
                    }
                }
            }

            if (String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                if (querydirectPurchaseAction)
                    directPurchaseActionList = DirectPurchaseAction.GetWorkListByDateReportNQL(dtStart, dtEnd, sExpression);
            }
            else
            {
                if (querydirectPurchaseAction)
                    directPurchaseActionList = DirectPurchaseAction.GetWorkListByFilterExpressionReport(sExpression);
            }

            IList instanceList = new List<TTReportNqlObject>();
            if (directPurchaseActionList != null)
                foreach (TTReportNqlObject objDPA in directPurchaseActionList)
                instanceList.Add(objDPA);
            return instanceList;
        }

        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return ExecuteReportNQL(dtStart, dtEnd, sExpression, null);
        }

        public override IList ExecuteReportNQL(string sExpression)
        {
            IList directPurchaseActionList = DirectPurchaseAction.GetWorkListByFilterExpressionReport(sExpression);
            
            IList instanceList = new List<TTReportNqlObject>();
            foreach (TTReportNqlObject objDPA in directPurchaseActionList)
                instanceList.Add(objDPA);
            return instanceList;
        }

        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            
            IList directPurchaseActionList;

            if (String.IsNullOrEmpty(this.ActionID.Text) == true)
            {
                directPurchaseActionList = DirectPurchaseAction.GetByWorkListDateQuery(context, dtStart, dtEnd, sExpression);
            }
            else
            {
                directPurchaseActionList = DirectPurchaseAction.GetByFilterExpressionQuery(context, sExpression);
            }

            return directPurchaseActionList;
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
                //PATIENT
                string sPID = "";
                //STATE
                string stateValue = "";
                //ActionID
                string sActionIDValue = "";
                //TenderNumber
                string sTenderNumberValue = "";

                if (String.IsNullOrEmpty(this.ActionID.Text) == false)
                {
                    sActionIDValue = this.ActionID.Text;
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

                    //PATIENT
                    Patient pPat = this.PatientBox.Tag as Patient;

                    if (pPat != null)
                        sPID = pPat.ObjectID.ToString();

                    if (string.IsNullOrEmpty(this.PatientBox.Text))
                    {
                        sPID = "";
                        this.PatientBox.Tag = null;
                    }

                    //STATE
                    if (this.StatusBox.SelectedItem == null)
                        stateValue = "";
                    else
                        stateValue = this.StatusBox.SelectedItem.Value.ToString();

                }

                //ACTIONID
                this.SaveCriteria("ID", "System.Int64", sActionIDValue);
                
                //TENDERNUMBER
                this.SaveCriteria("TENDERNUMBER", "System.Int64", sTenderNumberValue);
                
                //MASTERRESOURCE
                this.SaveCriteria("MASTERRESOURCE", "System.String", sResources);

                //PATIENT
                this.SaveCriteria("THIS:PATIENT", "System.String", sPID);

                //STATE
                this.SaveCriteria("CURRENTSTATE", "STATE", stateValue);


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
        
#endregion DirectPurchaseActionWorkListForm_Methods
    }
}