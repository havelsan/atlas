
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
    /// Demirbaş Durumu Değiştirme
    /// </summary>
    public partial class FixedAssetDataCorrectionForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            FixedAssetDefinition.SelectedObjectChanged += new TTControlEventDelegate(FixedAssetDefinition_SelectedObjectChanged);
            Store.SelectedObjectChanged += new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            FixedAssetDefinition.SelectedObjectChanged -= new TTControlEventDelegate(FixedAssetDefinition_SelectedObjectChanged);
            Store.SelectedObjectChanged -= new TTControlEventDelegate(Store_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void FixedAssetDefinition_SelectedObjectChanged()
        {
#region FixedAssetDataCorrectionForm_FixedAssetDefinition_SelectedObjectChanged
   if (this.FixedAssetDefinition.SelectedObject != null)
            {
                FixedAssetDefinition sFixedAssetDefinition = this.FixedAssetDefinition.SelectedObject as FixedAssetDefinition;
                if (this.Store.SelectedObject != null)
                {
                    IList stocks = Stock.GetStoreMaterial(_FixedAssetDataCorrection.ObjectContext, _FixedAssetDataCorrection.Store.ObjectID, sFixedAssetDefinition.ObjectID);
                    Stock fixedAssetStock = null;
                    if (stocks.Count == 1)
                    {
                        fixedAssetStock = (Stock)stocks[0];
                    }
                    else
                    {
                        throw new TTException("Hatalı Demirbaş Bilgi İşleme Haber Veriniz!");
                    }
                    this.FixedAssetMaterialDefinition.ListFilterExpression = "STOCK = " + ConnectionManager.GuidToString(fixedAssetStock.ObjectID);
                }
                else
                {
                    this.FixedAssetMaterialDefinition.ListFilterExpression = "FIXEDASSETDEFINITION = " + ConnectionManager.GuidToString(sFixedAssetDefinition.ObjectID) + " AND STOCK IS NOT NULL";
                }
            }
#endregion FixedAssetDataCorrectionForm_FixedAssetDefinition_SelectedObjectChanged
        }

        private void Store_SelectedObjectChanged()
        {
#region FixedAssetDataCorrectionForm_Store_SelectedObjectChanged
   if (this.Store.SelectedObject != null)
            {
                Store sStore = this.Store.SelectedObject as Store;
                this.FixedAssetMaterialDefinition.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(sStore.ObjectID) + " AND STOCKS.INHELD > 0";
            }
#endregion FixedAssetDataCorrectionForm_Store_SelectedObjectChanged
        }
    }
}