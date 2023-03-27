
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
    /// New Form
    /// </summary>
    public partial class FolderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            Files.CellValueChanged += new TTGridCellEventDelegate(Files_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            Files.CellValueChanged -= new TTGridCellEventDelegate(Files_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region FolderForm_ttbutton2_Click
   BindingList<StockCard> list = StockCard.GetStockCardByStockCardClass(_Folder.ObjectContext, new string[] {Guid.NewGuid().ToString(), Guid.NewGuid().ToString()});
            MessageBox.Show(list.Count.ToString());
#endregion FolderForm_ttbutton2_Click
        }

        private void ttbutton1_Click()
        {
#region FolderForm_ttbutton1_Click
   this.ParentFolder.ReadOnly = !this.ParentFolder.ReadOnly;
                this.Files.Columns[0].ReadOnly = !this.Files.Columns[0].ReadOnly;
                this.Files.Columns[2].Required = !this.Files.Columns[2].Required;
                if (this.Files.CurrentCell != null)
                {
                    if (this.Files.CurrentCell.BackColor == Color.Yellow)
                        this.Files.CurrentCell.BackColor = Color.Empty;
                    else                    
                        this.Files.CurrentCell.BackColor = Color.Yellow;
                }
#endregion FolderForm_ttbutton1_Click
        }

        private void Files_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region FolderForm_Files_CellValueChanged
   MessageBox.Show(rowIndex + "," + columnIndex);
#endregion FolderForm_Files_CellValueChanged
        }
    }
}