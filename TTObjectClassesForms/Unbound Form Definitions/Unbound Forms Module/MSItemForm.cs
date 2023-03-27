
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
    /// Liste
    /// </summary>
    public partial class MSItemForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            OkButton.Click += new TTControlEventDelegate(OkButton_Click);
            Cancelbutton.Click += new TTControlEventDelegate(Cancelbutton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OkButton.Click -= new TTControlEventDelegate(OkButton_Click);
            Cancelbutton.Click -= new TTControlEventDelegate(Cancelbutton_Click);
            base.UnBindControlEvents();
        }

        private void OkButton_Click()
        {
#region MSItemForm_OkButton_Click
   this.Close();
#endregion MSItemForm_OkButton_Click
        }

        private void Cancelbutton_Click()
        {
#region MSItemForm_Cancelbutton_Click
   this.lvwMSitem.SelectedItems.Clear();
            this.Close();
#endregion MSItemForm_Cancelbutton_Click
        }

#region MSItemForm_Methods
        public SortedList<object,object> SelectedMSItemList(SortedList<object,object> MSItemList,Boolean multiSelect,string ListTitle)
        {
            this.lvwMSitem.MultiSelect=multiSelect;
            SortedList<object,object> selectedMSItemList = new  SortedList<object,object>();
            this.lvwMSitem.Columns[0].Text=ListTitle.ToString();
            foreach  (System.Collections.Generic.KeyValuePair<object,object> mSItem in  MSItemList)
            {
                ITTListViewItem listViewItem = new TTListViewItem();
                listViewItem.Text=mSItem.Key.ToString();
                listViewItem.Tag=mSItem.Value;
                this.lvwMSitem.Items.Add(listViewItem);
            }
         
            this.ShowDialog();
            if (this.lvwMSitem.SelectedItems.Count>1 && multiSelect==false)
            {
                throw new Exception("Birden fazla seçim yapılmaz");
            }
            foreach (ITTListViewItem  selectedItem in this.lvwMSitem.SelectedItems)
            {
                
                selectedMSItemList.Add(selectedItem.Text,selectedItem.Tag);
            }
            return selectedMSItemList;
        }
        
#endregion MSItemForm_Methods
    }
}