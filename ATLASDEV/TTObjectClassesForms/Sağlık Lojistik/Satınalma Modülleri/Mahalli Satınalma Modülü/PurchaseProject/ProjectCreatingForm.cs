
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
    public partial class ProjectCreatingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ItemDetailsGrid.CellContentClick += new TTGridCellEventDelegate(ItemDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ItemDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ItemDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectCreatingForm_ItemDetailsGrid_CellContentClick
   if (ItemDetailsGrid.CurrentCell.OwningColumn.Name == "Details")
            {
                PurchaseProject myProject = _PurchaseProject;
                ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[ItemDetailsGrid.CurrentCell.RowIndex]);
            }
#endregion ProjectCreatingForm_ItemDetailsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region ProjectCreatingForm_PreScript
    base.PreScript();
#endregion ProjectCreatingForm_PreScript

            }
                }
}