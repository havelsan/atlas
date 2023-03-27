
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
    /// Mevcut İnceleme ve Yeterli Miktar Tespit Etme
    /// </summary>
    public partial class MilitaryDrugProductionReviewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region MilitaryDrugProductionReviewForm_PreScript
    if (this._MilitaryDrugProductionProcedure.ProducedMaterial != null)
            {
                int producedMaterialAmount = 999999999;
                foreach (ProductTreeDetail productTreeDetail in this._MilitaryDrugProductionProcedure.ProducedMaterial.ProductTreeDetails)
                {
                    ITTGridRow row = ProductTreeDetails.Rows.Add();
                    row.Cells["ConsumableMaterial"].Value = productTreeDetail.ConsumableMaterial.ObjectID;
                    row.Cells["DistributionType"].Value = productTreeDetail.ConsumableMaterial.StockCard.DistributionType.ObjectID;
                    row.Cells["RequiredAmount"].Value = productTreeDetail.Amount;

                    if (this.DestinationStore.SelectedValue != null)
                    {
                        IList stocks = productTreeDetail.ConsumableMaterial.Stocks.Select("STORE = " + ConnectionManager.GuidToString(this.DestinationStore.SelectedObjectID.Value));
                        double storeInheld = 0;
                        if (stocks != null && stocks.Count > 0)
                            storeInheld = ((Stock)stocks[0]).Inheld.Value;
                        row.Cells["StoreInheld"].Value = storeInheld;
                        int producedAmount = 0;
                        if (storeInheld > 0)
                        {
                            double coefficient = productTreeDetail.Amount.Value / this._MilitaryDrugProductionProcedure.ProducedMaterial.SampleAmount.Value;
                            producedAmount = Convert.ToInt32(storeInheld / coefficient);
                        }
                        row.Cells["ProducedAmount"].Value = producedAmount;

                        if (producedAmount < producedMaterialAmount)
                            producedMaterialAmount = producedAmount;
                    }
                }

                this._MilitaryDrugProductionProcedure.ProducedMaterialAmount = producedMaterialAmount;
            }
#endregion MilitaryDrugProductionReviewForm_PreScript

            }
                }
}