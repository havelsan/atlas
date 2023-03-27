
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
    /// Genel İş Listesi
    /// </summary>
    public partial class BaseActionWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region BaseActionWLCriteriaForm_Methods
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            this.LoadCriteria();
            this.FillStateBox();
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
            
            //STATE
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
            
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            Common.CheckWorklistDayLimit(dtStart, dtEnd);
            if(String.IsNullOrEmpty(this.ActionID.Text) == true)
                return BaseAction.GetByBaseActionWorklistDate(context, dtStart, dtEnd, sExpression);
            else
                return BaseAction.GetByWLFilterExpression(context, sExpression);
        }
        
        public override void OnSave()
        {
            try
            {
                //ID
                string sActionID = "";
                //STATE
                string sState = "";
                
                if(String.IsNullOrEmpty(this.ActionID.Text) == false)
                {
                    sActionID = this.ActionID.Text;
                }
                else
                {
                    //ID
                    sActionID = "";
                    //STATE
                    if(this.StatusBox.SelectedItem == null)
                        sState = "";
                    else
                        sState = this.StatusBox.SelectedItem.Value.ToString();
                }
                
                //ID
                this.SaveCriteria("ID","System.Int64",sActionID);
                
                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",sState);

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
        
#endregion BaseActionWLCriteriaForm_Methods
    }
}