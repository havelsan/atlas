
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
    /// Flitre
    /// </summary>
    public partial class CMRActionWLCriterialForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region CMRActionWLCriterialForm_Methods
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            
            if(string.IsNullOrEmpty(ActionID.Text))
            {
               return CMRAction.CMRActionWorkListNQL(context, dtStart, dtEnd, sExpression);
            }
            return CMRAction.CMRActionWorkListNQLNoDate(context, sExpression);
        }
     
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FillStateBox();
            this.OnLoadCriteria();
            this.StatusBox.SelectedIndex = 4 ;
        }
        
        public override void OnSave()
        {
            try
            {
                //ID
                this.SaveCriteria("REQUESTNO", "System.String", this.ActionID.Text);

                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString());
            }
            catch(Exception ex)
            {
                InfoBox.Show(this, ex);
            }
        }
        
        public override void OnLoadCriteria()
        {
            base.OnLoadCriteria();
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
        
#endregion CMRActionWLCriterialForm_Methods
    }
}