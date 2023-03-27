
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
    /// MSB İlaç Üretim İşlemi - Kalite Kontrol Hammadde
    /// </summary>
    public partial class MilitaryDrugProductionProcedureForm : MilitaryDrugProductionBaseForm
    {
        override protected void BindControlEvents()
        {
            ReviewInheldButton.Click += new TTControlEventDelegate(ReviewInheldButton_Click);
            AddProductButton.Click += new TTControlEventDelegate(AddProductButton_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ReviewInheldButton.Click -= new TTControlEventDelegate(ReviewInheldButton_Click);
            AddProductButton.Click -= new TTControlEventDelegate(AddProductButton_Click);
            base.UnBindControlEvents();
        }

        private void ReviewInheldButton_Click()
        {
#region MilitaryDrugProductionProcedureForm_ReviewInheldButton_Click
   if (this._MilitaryDrugProductionProcedure.ProducedMaterial == null || this._MilitaryDrugProductionProcedure.ProductAnnualReqDet == null)
            {
                InfoBox.Show("Üretilen İlaç/Malzeme ve İBF Yılı seçili olmalıdır.");
                return;
            }

            MilitaryDrugProductionReviewForm form = new MilitaryDrugProductionReviewForm();
            form.ShowEdit(this, this._ttObject, true);
#endregion MilitaryDrugProductionProcedureForm_ReviewInheldButton_Click
        }

        private void AddProductButton_Click()
        {
#region MilitaryDrugProductionProcedureForm_AddProductButton_Click
   if (this._MilitaryDrugProductionProcedure.ProducedMaterial != null && this._MilitaryDrugProductionProcedure.ProducedMaterial.ProductTreeDetails.Count > 0)
            {
                if (this._MilitaryDrugProductionProcedure.ProducedMaterialAmount.HasValue && this._MilitaryDrugProductionProcedure.ProducedMaterialAmount.Value > 0)
                {
                    string errMessage = string.Empty;
                    foreach (ProductTreeDetail productTreeDetail in this._MilitaryDrugProductionProcedure.ProducedMaterial.ProductTreeDetails)
                    {
                        decimal stockInheld = Convert.ToDecimal(productTreeDetail.ConsumableMaterial.StockInheld(this._MilitaryDrugProductionProcedure.Store));
                        double coefficient = this._MilitaryDrugProductionProcedure.ProducedMaterialAmount.Value / this._MilitaryDrugProductionProcedure.ProducedMaterial.SampleAmount.Value;
                        if (stockInheld < Convert.ToDecimal(productTreeDetail.Amount * coefficient))
                        {
                            errMessage += "\r\nMalzeme Adı : " + productTreeDetail.ConsumableMaterial.Name + "\r\n";
                            errMessage += "Depo Mevcudu : " + stockInheld + "\r\n";
                            errMessage += "Gerekli Miktar : " + Convert.ToDecimal(productTreeDetail.Amount * coefficient);
                        }
                    }
                    if (string.IsNullOrEmpty(errMessage) == false)
                    {
                        InfoBox.Show(this, "Aşağıdaki malzemeler için yeterli mevcut deponuzda bulunmamaktadır.\r\n" + errMessage);
                        return;
                    }

                    foreach (ProductTreeDetail productTreeDetail in this._MilitaryDrugProductionProcedure.ProducedMaterial.ProductTreeDetails)
                    {
                        double coefficient = this._MilitaryDrugProductionProcedure.ProducedMaterialAmount.Value / this._MilitaryDrugProductionProcedure.ProducedMaterial.SampleAmount.Value;

                        MilitaryDrugProductionProcedureMaterialOut outMaterial = new MilitaryDrugProductionProcedureMaterialOut(this._MilitaryDrugProductionProcedure.ObjectContext);
                        outMaterial.Material = productTreeDetail.ConsumableMaterial;
                        outMaterial.Amount = productTreeDetail.Amount * coefficient;
                        outMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                        this._MilitaryDrugProductionProcedure.MilitaryDrugProductionProcedureOutMaterials.Add(outMaterial);

                    }
                    this.ProducedMaterial.ReadOnly = true;
                    this.ProducedMaterialAmount.ReadOnly = true;
                    this.AddProductButton.Enabled = false;
                }
            }
#endregion MilitaryDrugProductionProcedureForm_AddProductButton_Click
        }

        protected override void PreScript()
        {
#region MilitaryDrugProductionProcedureForm_PreScript
    base.PreScript();
            tttabcontrol1.HideTabPage(CompletedAnalysisTestPage);
#endregion MilitaryDrugProductionProcedureForm_PreScript

            }
                }
}