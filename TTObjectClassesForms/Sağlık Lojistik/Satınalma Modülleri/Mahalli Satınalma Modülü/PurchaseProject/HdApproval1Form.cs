
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
    public partial class HdApproval1Form : TTForm
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
#region HdApproval1Form_ItemDetailsGrid_CellContentClick
   try
            {
                PurchaseProject myProject = _PurchaseProject;
                if (ItemDetailsGrid.CurrentCell.OwningColumn.Name == "Details" && _PurchaseProject.PurchaseProjectDetails.Count > 0)
                {
                    ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                    prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[ItemDetailsGrid.CurrentCell.RowIndex]);
                }
            }
            catch
            { }
#endregion HdApproval1Form_ItemDetailsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region HdApproval1Form_PreScript
    base.PreScript();

            bool authorizedForPurchasing = Convert.ToBoolean(TTObjectClasses.SystemParameter.GetParameterValue("AuthorizedForPurchasing", "false"));
            if (authorizedForPurchasing)
                this.DropStateButton(PurchaseProject.States.RegionCommandLogBureau);
            else
                this.DropStateButton(PurchaseProject.States.LogisticBureauApproval);
#endregion HdApproval1Form_PreScript

            }
                }
}