
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class ResReusablePackageForm : TTDefinitionForm
    {
        private void MaterialSelection_SelectedObjectChanged()
        {
            // <-- Automatically generated part.
            if (this.MaterialSelection.SelectedObject != null)
            {
                var resReusableMaterial = this.MaterialSelection.SelectedObject as ResReusableMaterial;
                resReusableMaterial.ResReusablePackage = this._ResReusablePackage;

            }
            // Automatically generated part. -->
        }



        private void ReusableMaterialDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region ReusableMaterialDetails_CellContentClick
            if (columnIndex == 2 && rowIndex != -1)
            {
                ITTGridRow currentRow = this.ReusableMaterialDetails.Rows[rowIndex];
                if (currentRow.TTObject != null)
                {
                    var resReusableMaterial = currentRow.TTObject as ResReusableMaterial;
                    resReusableMaterial.ResReusablePackage = null;

                }
            }
            #endregion ReusableMaterialDetails_CellContentClick
        }


        override protected void BindControlEvents()
        {
            MaterialSelection.SelectedObjectChanged += new TTControlEventDelegate(MaterialSelection_SelectedObjectChanged);
            ReusableMaterialDetails.CellContentClick += new TTGridCellEventDelegate(ReusableMaterialDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaterialSelection.SelectedObjectChanged -= new TTControlEventDelegate(MaterialSelection_SelectedObjectChanged);
            ReusableMaterialDetails.CellContentClick -= new TTGridCellEventDelegate(ReusableMaterialDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        //private void FixedAssetDefinition_SelectedObjectChanged()
        //{
        //    #region FixedAssetDataCorrectionForm_FixedAssetDefinition_SelectedObjectChanged
        //    if (this.FixedAssetDefinition.SelectedObject != null)
        //    {
        //        FixedAssetDefinition sFixedAssetDefinition = this.FixedAssetDefinition.SelectedObject as FixedAssetDefinition;
        //        if (this.Store.SelectedObject != null)
        //        {
        //            IList stocks = Stock.GetStoreMaterial(_FixedAssetDataCorrection.ObjectContext, _FixedAssetDataCorrection.Store.ObjectID, sFixedAssetDefinition.ObjectID);
        //            Stock fixedAssetStock = null;
        //            if (stocks.Count == 1)
        //            {
        //                fixedAssetStock = (Stock)stocks[0];
        //            }
        //            else
        //            {
        //                throw new TTException("Hatalý Demirbaþ Bilgi Ýþleme Haber Veriniz!");
        //            }
        //            this.FixedAssetMaterialDefinition.ListFilterExpression = "STOCK = " + ConnectionManager.GuidToString(fixedAssetStock.ObjectID);
        //        }
        //        else
        //        {
        //            this.FixedAssetMaterialDefinition.ListFilterExpression = "FIXEDASSETDEFINITION = " + ConnectionManager.GuidToString(sFixedAssetDefinition.ObjectID) + " AND STOCK IS NOT NULL";
        //        }
        //    }
        //    #endregion FixedAssetDataCorrectionForm_FixedAssetDefinition_SelectedObjectChanged
        //}
    }
}