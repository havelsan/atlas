
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
    /// İBF Detayları
    /// </summary>
    public partial class AnnualRequirementDetailInListForm : TTForm
    {
        override protected void BindControlEvents()
        {
            DemandDetailsGrid.CellContentClick += new TTGridCellEventDelegate(DemandDetailsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DemandDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(DemandDetailsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void DemandDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AnnualRequirementDetailInListForm_DemandDetailsGrid_CellContentClick
   if (((ITTGridCell)DemandDetailsGrid.CurrentCell).OwningColumn.Name == "ServiceDemands")
            {
                AnnualRequirementDetailInList ard = _AnnualRequirementDetailInList;
                Demand d = ((DemandDetail)ard.DemandDetails[DemandDetailsGrid.CurrentCell.RowIndex]).Demand;
                DemandApproveForm daf = new DemandApproveForm();
                daf.ShowEdit(this.FindForm(), d);
            }
#endregion AnnualRequirementDetailInListForm_DemandDetailsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region AnnualRequirementDetailInListForm_PreScript
    base.PreScript();
            
            this.DropStateButton(AnnualRequirementDetailInList.States.Cancelled);
#endregion AnnualRequirementDetailInListForm_PreScript

            }
                }
}