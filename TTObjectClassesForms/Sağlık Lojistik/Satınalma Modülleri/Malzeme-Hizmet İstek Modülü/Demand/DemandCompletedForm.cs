
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
    /// Tamam
    /// </summary>
    public partial class DemandCompleted : TTForm
    {
        override protected void BindControlEvents()
        {
            ItemsGrid.CellContentClick += new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ItemsGrid.CellContentClick -= new TTGridCellEventDelegate(ItemsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DemandCompleted_ItemsGrid_CellContentClick
   if(ItemsGrid.CurrentCell == null)
                return;
            
            if(ItemsGrid.CurrentCell.OwningColumn == ItemsGrid.Columns[StockDetails.Name])
            {
                DemandDetail demandDetail = (DemandDetail)ItemsGrid.CurrentCell.OwningRow.TTObject;
                StockExaminationForm seForm = new StockExaminationForm();
                seForm.ShowReadOnly(this.FindForm(), demandDetail);
            }
#endregion DemandCompleted_ItemsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region DemandCompleted_PreScript
    base.PreScript();
            
//            this.CheckPurchasingProcess();
//            
//            if(_Demand.DemandType == DemandTypeEnum.AnnualPurchase)
//            {
//                IBFType.Visible = true;
//                IBFTypeLabel.Visible = true;
//                IBFYear.Visible = true;
//                IBFYearLabel.Visible = true;
//            }
#endregion DemandCompleted_PreScript

            }
            
#region DemandCompleted_Methods
        public void CheckPurchasingProcess()
        {
            
            foreach(ITTGridRow row in ItemsGrid.Rows)
            {
                if (_Demand.CurrentStateDefID == Demand.States.Rejected)
                    row.Cells["PurchasingProcess"].Value = "İstek Reddedildi";
                else
                {
                    DemandDetail dd = (DemandDetail)row.TTObject;
                    if (dd.PurchaseProjectDetail == null)
                        row.Cells["PurchasingProcess"].Value = "Tedarik Süreci Başlamadı";
                    else
                    {
                        PurchaseProject pp = dd.PurchaseProjectDetail.PurchaseProject;
                        row.Cells["PurchasingProcess"].Value = pp.CurrentStateDef.Description;
                    }
                }
            }
        }
        
#endregion DemandCompleted_Methods
    }
}