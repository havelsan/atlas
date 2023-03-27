
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
    public partial class StockWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            StockActionID.TextChanged += new TTControlEventDelegate(StockActionID_TextChanged);
            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click += new TTControlEventDelegate(ClearButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionID.TextChanged -= new TTControlEventDelegate(StockActionID_TextChanged);
            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
            ClearButton.Click -= new TTControlEventDelegate(ClearButton_Click);
            base.UnBindControlEvents();
        }

        private void StockActionID_TextChanged()
        {
#region StockWLCriteriaForm_StockActionID_TextChanged
   if(string.IsNullOrEmpty(StockActionID.Text) == false)
            {
                StatusBox.SelectedIndex = 0;
                UserSearchBox.SelectedValue = null;
                foreach(ListViewItem item in this.MResources.Items)
                {
                    item.Checked = false;
                }
            }
#endregion StockWLCriteriaForm_StockActionID_TextChanged
        }

        private void SelectAllButton_Click()
        {
#region StockWLCriteriaForm_SelectAllButton_Click
   foreach(ListViewItem item in this.MResources.Items)
            {
                item.Checked = true;
            }
#endregion StockWLCriteriaForm_SelectAllButton_Click
        }

        private void ClearButton_Click()
        {
#region StockWLCriteriaForm_ClearButton_Click
   foreach(ListViewItem item in this.MResources.Items)
            {
                item.Checked = false;
            }
#endregion StockWLCriteriaForm_ClearButton_Click
        }

#region StockWLCriteriaForm_Methods
        ListView _resourceListView = null;

        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            string filter = GetSelectedResourceStores();
            if(string.IsNullOrEmpty(StockActionID.Text))
            {
                if (string.IsNullOrEmpty(filter) == false)
                {
                    sExpression += " AND (STORE IN (" + GetSelectedResourceStores() + ")";
                    sExpression += " OR DESTINATIONSTORE IN (" + GetSelectedResourceStores() + "))";
                }
                if (this.UserSearchBox.SelectedObject != null)
                {
                    ResUser userSearch = (ResUser)this.UserSearchBox.SelectedObject;
                    TTUser ttUser = userSearch.GetMyTTUser();
                    sExpression += " AND STATEHISTORY(USERID='" + ttUser.UserID.ToString() + "').EXISTS";
                }
                return StockAction.StockActionWorkListNQL(context, dtStart, dtEnd, Guid.Empty, sExpression);
            }
            else
            {
                return StockAction.StockActionWorkListNQLNoDate(context, sExpression);
            }
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _resourceListView = (ListView )this.MResources;
            _resourceListView.CheckBoxes = true;

            this.FillResources();
            this.FillStateBox();
            this.LoadCriteria();
        }

        public override void OnSave()
        {
            this.SaveCriteria();
        }

        private void LoadCriteria()
        {

            CriteriaValue crValS = this.GetCriteriaValue("STATE_STATUS");
            if (crValS != null && !string.IsNullOrEmpty(crValS.Value))
            {
                TTComboBoxItem pItem = null;
                foreach (TTComboBoxItem item in this.StatusBox.Items)
                {
                    if (item.Value.ToString() == crValS.Value)
                        pItem = item;
                }

                this.StatusBox.SelectedItem = pItem;
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

            this.StatusBox.SelectedItem = it4;
        }

        private void SaveCriteria()
        {

            //STOCKACTIONID
            CriteriaValue crValID = this.GetCriteriaValue("STOCKACTIONID");
            if (crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.StockActionID.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("STOCKACTIONID");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.StockActionID.Text;
            }

            //STATE
            CriteriaValue crValS = this.GetCriteriaValue("CURRENTSTATE");
            if (crValS == null)
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
        }

        private void FillResources()
        {
            _resourceListView.Items.Clear();
            foreach (UserResource userResource in TTObjectClasses.Common.CurrentResource.UserResources)
            {
                ListViewItem item = new ListViewItem(userResource.Resource.Name);
                item.Tag = userResource;
                item.Checked = false;

                _resourceListView.Items.Add(item);
            }
        }

        private string GetSelectedResourceStores()
        {
            string retValue = string.Empty;
            List<Guid> storeIDs = new List<Guid>();
            foreach (ListViewItem item in _resourceListView.Items)
            {
                if (item.Checked)
                {
                    UserResource userResource = item.Tag as UserResource;
                    if (userResource != null && userResource.Resource != null)
                        if (userResource.Resource.Store != null)
                        storeIDs.Add(userResource.Resource.Store.ObjectID);
                }
            }

            if (storeIDs.Count > 0)
            {
                for (int i = 0; i < storeIDs.Count; i++)
                {
                    retValue += ConnectionManager.GuidToString(storeIDs[i]);
                    if (storeIDs.Count - 1 != i)
                        retValue += ", ";
                }
            }
            return retValue;
        }
        
#endregion StockWLCriteriaForm_Methods
    }
}