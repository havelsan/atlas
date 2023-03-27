
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
    public partial class DemandWorkListForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region DemandWorkListForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return Demand.WorkListNQL(context, dtStart, dtEnd, sExpression);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FillStateBox();
            this.LoadCriteria();
        }
        
        public override void OnSave()
        {
            try
            {
                //ID
                this.SaveCriteria("REQUESTNO", "System.Int64", this.txtRequestNo.Text);

                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString());
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
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
        
        private void SaveCriteria()
        {
            //REQUESTNO
            CriteriaValue crValID = this.GetCriteriaValue("REQUESTNO");
            if(crValID == null)
            {
                CriteriaValue newCrValID = new CriteriaValue(this.m_context);
                newCrValID.Value = this.txtRequestNo.Text;
                newCrValID.User = Common.CurrentResource;
                newCrValID.SpecialPanel = this.m_ownerDefinition.LastSpecialPanel;
                newCrValID.PCriteriaValue = this.GetCriteriaDefinition("REQUESTNO");
                newCrValID.PCriteriaValue.Criteria = this.m_ownerDefinition;
            }
            else
            {
                crValID.Value = this.txtRequestNo.Text;
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
        
#endregion DemandWorkListForm_Methods
    }
}