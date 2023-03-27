
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
    public partial class RCCommanderApprovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseProjectDetailsGrid.CellContentClick += new TTGridCellEventDelegate(PurchaseProjectDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseProjectDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(PurchaseProjectDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void PurchaseProjectDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RCCommanderApprovalForm_PurchaseProjectDetailsGrid_CellContentClick
   if (PurchaseProjectDetailsGrid.CurrentCell.OwningColumn.Name == "Details")
            {
                PurchaseProject myProject = _PurchaseProject;
                LogisticBureauAnalyseDetails lbad = new LogisticBureauAnalyseDetails();
                lbad.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[PurchaseProjectDetailsGrid.CurrentCell.RowIndex]);
            }
#endregion RCCommanderApprovalForm_PurchaseProjectDetailsGrid_CellContentClick
        }
    }
}