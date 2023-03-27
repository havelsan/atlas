
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
    /// İlk Muayene Kayıt
    /// </summary>
    public partial class FirstExaminationRegistryForm : RUL_BaseForm
    {
        override protected void BindControlEvents()
        {
            CommisionGrid.CellValueChanged += new TTGridCellEventDelegate(CommisionGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CommisionGrid.CellValueChanged -= new TTGridCellEventDelegate(CommisionGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void CommisionGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region FirstExaminationRegistryForm_CommisionGrid_CellValueChanged
   if(CommisionGrid.CurrentCell.OwningColumn == CommisionGrid.Columns[Name.Name])
            {
                if (CommisionGrid.Rows[rowIndex].Cells["Name"].Value != null)
                {
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].ReadOnly = true;
                }
                else
                {
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].ReadOnly = false;
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].Value = null ;
                }
            }
#endregion FirstExaminationRegistryForm_CommisionGrid_CellValueChanged
        }
    }
}