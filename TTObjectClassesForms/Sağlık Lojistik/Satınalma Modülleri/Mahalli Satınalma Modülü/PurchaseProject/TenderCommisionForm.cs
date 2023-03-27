
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
    public partial class TenderCommisionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseProjectDetailItems.CellContentClick += new TTGridCellEventDelegate(PurchaseProjectDetailItems_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseProjectDetailItems.CellContentClick -= new TTGridCellEventDelegate(PurchaseProjectDetailItems_CellContentClick);
            base.UnBindControlEvents();
        }

        private void PurchaseProjectDetailItems_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region TenderCommisionForm_PurchaseProjectDetailItems_CellContentClick
   if (PurchaseProjectDetailItems.CurrentCell == null)
                return;

            PurchaseProject myProject = _PurchaseProject;
            switch (PurchaseProjectDetailItems.CurrentCell.OwningColumn.Name)
            {
                case "Details":
                    ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                    prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[PurchaseProjectDetailItems.CurrentCell.RowIndex]);
                    break;

                //                case "Release":
                //                    PurchaseProjectDetail ppd = (PurchaseProjectDetail)ItemDetailsGrid.CurrentCell.OwningRow.TTObject;
                //                    ppd.DemandDetails.Clear();
                //                    ((ITTObject)ppd).Delete();
                //                    _PurchaseProject.SetOrderNOs();
                //                    break;

                default:
                    break;

            }
#endregion TenderCommisionForm_PurchaseProjectDetailItems_CellContentClick
        }
    }
}