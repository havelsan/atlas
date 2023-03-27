
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
    /// Ürün Ağacı Tanımları
    /// </summary>
    public partial class ProductTreeDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            ProductAnnualReqDets.CellContentClick += new TTGridCellEventDelegate(ProductAnnualReqDets_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ProductAnnualReqDets.CellContentClick -= new TTGridCellEventDelegate(ProductAnnualReqDets_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ProductAnnualReqDets_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProductTreeDefinitionForm_ProductAnnualReqDets_CellContentClick
   if (ProductAnnualReqDets.CurrentCell == null)
                return;
            
            if (ProductAnnualReqDets.CurrentCell.OwningColumn.Name == "Calculating")
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                objectID.Add("VALUE", _ProductTreeDefinition.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                parameters.Add("TTOBJECTID", objectID);

                BindingList<MainStoreDefinition> mainStores = MainStoreDefinition.GetAllMainStores(_ProductTreeDefinition.ObjectContext);
                MainStoreDefinition mainStore = null;
                if (mainStores.Count > 0)
                    mainStore = mainStores[0];

                if (mainStore  != null)
                {
                    TTReportTool.PropertyCache<object> mainStoreID = new TTReportTool.PropertyCache<object>();
                    mainStoreID.Add("VALUE", mainStore.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                    parameters.Add("MAINSTOREID", mainStoreID);
                }
                
                TTReportTool.PropertyCache<object> ibfAmount = new TTReportTool.PropertyCache<object>();
                ibfAmount.Add("VALUE", ProductAnnualReqDets.Rows[ProductAnnualReqDets.CurrentCell.RowIndex].Cells[1].Value.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                parameters.Add("IBFAmount", ibfAmount);
                
                TTReportTool.PropertyCache<object> ibfYear = new TTReportTool.PropertyCache<object>();
                ibfYear.Add("VALUE", ProductAnnualReqDets.Rows[ProductAnnualReqDets.CurrentCell.RowIndex].Cells[0].Value.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                parameters.Add("IBFYear", ibfYear);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_İBFMiktarFormu), true, 1, parameters);
                if (mainStore != null)
                {
                    IList insufficientList = ProductTreeDetail.GetIBFAmountReportQuery(objectID.ToString(), mainStore.ObjectID.ToString());
                    if (insufficientList.Count > 0)
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IBFInsufficientAmountReport), true, 1, parameters);
                }
            }
            
            if (ProductAnnualReqDets.CurrentCell.OwningColumn.Name == "cmdRefresh")
            {
                ProductAnnualReqDet prd = (ProductAnnualReqDet)ProductAnnualReqDets.CurrentCell.OwningRow.TTObject;
                if(string.IsNullOrEmpty(prd.LossPercentage.ToString()) == false)
                {
                    if(prd.LossPercentage > 10)
                    {
                        InfoBox.Show("Fire oranı %5'ten fazla olamaz");
                        prd.LossPercentage = 0;
                        return;
                    }
                    else
                    {
                        string perc = "1,0" + prd.LossPercentage.ToString();
                        prd.RequirementAmount = Convert.ToDouble(prd.RequirementAmount) * Convert.ToDouble(perc);
                    }
                }
            }
#endregion ProductTreeDefinitionForm_ProductAnnualReqDets_CellContentClick
        }
    }
}