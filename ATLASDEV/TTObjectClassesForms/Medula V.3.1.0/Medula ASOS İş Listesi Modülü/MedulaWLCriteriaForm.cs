
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
    /// Medula İş Listesi Kriterleri
    /// </summary>
    public partial class MedulaWLCriteriaForm : BaseCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region MedulaWLCriteriaForm_Methods
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
                    if((string)item.Value == crValS.Value)
                        pItem = item;
                }

                this.StatusBox.SelectedItem = pItem;
            }
            
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            return BaseMedulaWLAction.BaseMedulaWLActionWorkList(context, dtEnd, dtStart, sExpression);
        }
        
        public override void OnSave()
        {
            try
            {
                //ID
                this.SaveCriteria("MEDULAACTIONID","System.Int64",this.MedulaActionID.Text);
                

                //STATE
                this.SaveCriteria("CURRENTSTATE","STATE",this.StatusBox.SelectedItem == null ? "" : this.StatusBox.SelectedItem.Value.ToString());

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
        
#endregion MedulaWLCriteriaForm_Methods
    }
}