
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
    /// Majistral İlaç Hazırlama
    /// </summary>
    public partial class MagistralPreparationActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdCalculateAmount.Click += new TTControlEventDelegate(cmdCalculateAmount_Click);
            MagistralVolume.TextChanged += new TTControlEventDelegate(MagistralVolume_TextChanged);
            Sterilization.CheckedChanged += new TTControlEventDelegate(Sterilization_CheckedChanged);
            MagistralPreparationUsedDrugs.CellValueChanged += new TTGridCellEventDelegate(MagistralPreparationUsedDrugs_CellValueChanged);
            MagistralPreparationUsedChemicals.CellValueChanged += new TTGridCellEventDelegate(MagistralPreparationUsedChemicals_CellValueChanged);
            MagistralPreparationUsedMaterials.CellValueChanged += new TTGridCellEventDelegate(MagistralPreparationUsedMaterials_CellValueChanged);
            MagistralPreparationDetails.CellValueChanged += new TTGridCellEventDelegate(MagistralPreparationDetails_CellValueChanged);
            ProducedAmount.TextChanged += new TTControlEventDelegate(ProducedAmount_TextChanged);
            MagistralPackagingType.SelectedIndexChanged += new TTControlEventDelegate(MagistralPackagingType_SelectedIndexChanged);
            MagistralPackagingSubType.SelectedIndexChanged += new TTControlEventDelegate(MagistralPackagingSubType_SelectedIndexChanged);
            NightShift.CheckedChanged += new TTControlEventDelegate(NightShift_CheckedChanged);
            MagistralPreparationSubType.SelectedIndexChanged += new TTControlEventDelegate(MagistralPreparationSubType_SelectedIndexChanged);
            MagistralPreparationType.SelectedIndexChanged += new TTControlEventDelegate(MagistralPreparationType_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCalculateAmount.Click -= new TTControlEventDelegate(cmdCalculateAmount_Click);
            MagistralVolume.TextChanged -= new TTControlEventDelegate(MagistralVolume_TextChanged);
            Sterilization.CheckedChanged -= new TTControlEventDelegate(Sterilization_CheckedChanged);
            MagistralPreparationUsedDrugs.CellValueChanged -= new TTGridCellEventDelegate(MagistralPreparationUsedDrugs_CellValueChanged);
            MagistralPreparationUsedChemicals.CellValueChanged -= new TTGridCellEventDelegate(MagistralPreparationUsedChemicals_CellValueChanged);
            MagistralPreparationUsedMaterials.CellValueChanged -= new TTGridCellEventDelegate(MagistralPreparationUsedMaterials_CellValueChanged);
            MagistralPreparationDetails.CellValueChanged -= new TTGridCellEventDelegate(MagistralPreparationDetails_CellValueChanged);
            ProducedAmount.TextChanged -= new TTControlEventDelegate(ProducedAmount_TextChanged);
            MagistralPackagingType.SelectedIndexChanged -= new TTControlEventDelegate(MagistralPackagingType_SelectedIndexChanged);
            MagistralPackagingSubType.SelectedIndexChanged -= new TTControlEventDelegate(MagistralPackagingSubType_SelectedIndexChanged);
            NightShift.CheckedChanged -= new TTControlEventDelegate(NightShift_CheckedChanged);
            MagistralPreparationSubType.SelectedIndexChanged -= new TTControlEventDelegate(MagistralPreparationSubType_SelectedIndexChanged);
            MagistralPreparationType.SelectedIndexChanged -= new TTControlEventDelegate(MagistralPreparationType_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void cmdCalculateAmount_Click()
        {
#region MagistralPreparationActionForm_cmdCalculateAmount_Click
   double amountMag = (double)_MagistralPreparationAction.MagistralAmount ;
            double beforeAmount = 1;
            if (_MagistralPreparationAction.BeforeMagistralAmount != null)
            {
                beforeAmount = (double)_MagistralPreparationAction.BeforeMagistralAmount;
            }
            
            foreach (MagistralPreparationUsedDrug drug in _MagistralPreparationAction.MagistralPreparationUsedDrugs)
            {
                drug.Amount = (drug.Amount / beforeAmount ) * amountMag;
            }
            foreach (MagistralPreparationUsedChemical chemical in _MagistralPreparationAction.MagistralPreparationUsedChemicals)
            {
                chemical.Amount = (chemical.Amount / beforeAmount) * amountMag;
            }
            foreach (MagistralPreparationUsedMaterial materail in _MagistralPreparationAction.MagistralPreparationUsedMaterials)
            {
                materail.Amount = (materail.Amount / beforeAmount) * amountMag;
            }
            foreach (MagistralPreparationUsedDetail usedDetail in _MagistralPreparationAction.MagistralPreparationUsedDetails)
            {
                usedDetail.Amount = (usedDetail.Amount / beforeAmount) * amountMag;
            }
            foreach (MagistralPreparationDetail detail in _MagistralPreparationAction.MagistralPreparationDetails)
            {
                detail.Amount = amountMag;
            }
            _MagistralPreparationAction.BeforeMagistralAmount = amountMag;
            
            CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_cmdCalculateAmount_Click
        }

        private void MagistralVolume_TextChanged()
        {
#region MagistralPreparationActionForm_MagistralVolume_TextChanged
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_MagistralVolume_TextChanged
        }

        private void Sterilization_CheckedChanged()
        {
#region MagistralPreparationActionForm_Sterilization_CheckedChanged
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_Sterilization_CheckedChanged
        }

        private void MagistralPreparationUsedDrugs_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MagistralPreparationActionForm_MagistralPreparationUsedDrugs_CellValueChanged
   ITTGridCell currentCell = MagistralPreparationUsedDrugs.Rows[rowIndex].Cells[columnIndex];
            if (currentCell.OwningColumn.Name == "DrugAmount")
            {
                AddUsedDetails();
                CalculateMagistralPrice();
            }
#endregion MagistralPreparationActionForm_MagistralPreparationUsedDrugs_CellValueChanged
        }

        private void MagistralPreparationUsedChemicals_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MagistralPreparationActionForm_MagistralPreparationUsedChemicals_CellValueChanged
   ITTGridCell currentCell = MagistralPreparationUsedChemicals.Rows[rowIndex].Cells[columnIndex];
            if (currentCell.OwningColumn.Name == "ChemicalAmount")
            {
                AddUsedDetails();
                CalculateMagistralPrice();
            }
#endregion MagistralPreparationActionForm_MagistralPreparationUsedChemicals_CellValueChanged
        }

        private void MagistralPreparationUsedMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MagistralPreparationActionForm_MagistralPreparationUsedMaterials_CellValueChanged
   ITTGridCell currentCell = MagistralPreparationUsedMaterials.Rows[rowIndex].Cells[columnIndex];
            if (currentCell.OwningColumn.Name == "MaterialAmount")
            {
                AddUsedDetails();
                CalculateMagistralPrice();
            }
#endregion MagistralPreparationActionForm_MagistralPreparationUsedMaterials_CellValueChanged
        }

        private void MagistralPreparationDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MagistralPreparationActionForm_MagistralPreparationDetails_CellValueChanged
   ITTGridRow magistralPreparationRow = MagistralPreparationDetails.Rows[MagistralPreparationDetails.CurrentCell.RowIndex];
            if (MagistralPreparationDetails.CurrentCell == magistralPreparationRow.Cells["MagistralPreparationDef"])
            {
                MagistralPreparationDefinition magistralDefinition = ((MagistralPreparationDefinition)((MagistralPreparationDetail)magistralPreparationRow.TTObject).MagistralPreparationDef);
                
                foreach (MagistralDefUsedChemical chemical in magistralDefinition.MagistralDefUsedChemicals)
                {
                    MagistralPreparationUsedChemical usedChemical = new MagistralPreparationUsedChemical(_MagistralPreparationAction.ObjectContext);
                    usedChemical.MagistralChemicalDefinition = chemical.MagistralChemicalDefinition;
                    usedChemical.Amount = chemical.UnitAmount;
                    _MagistralPreparationAction.MagistralPreparationUsedChemicals.Add(usedChemical);
                }

                foreach (MagistralDefUsedDrug drug in magistralDefinition.MagistralDefUsedDrugs)
                {
                    MagistralPreparationUsedDrug usedDrug = new MagistralPreparationUsedDrug(_MagistralPreparationAction.ObjectContext);
                    usedDrug.DrugDefinition = drug.Drug ;
                    usedDrug.Amount = drug.UnitAmount;
                    _MagistralPreparationAction.MagistralPreparationUsedDrugs.Add(usedDrug);
                }

                foreach (MagistralDefUsedConsMat materail in magistralDefinition.MagistralDefUsedConsMats)
                {
                    MagistralPreparationUsedMaterial usedMaterial = new MagistralPreparationUsedMaterial(_MagistralPreparationAction.ObjectContext);
                    usedMaterial.ConsumableMaterial = materail.ConsumableMaterial ;
                    usedMaterial.Amount = materail.UnitAmount;
                    _MagistralPreparationAction.MagistralPreparationUsedMaterials.Add(usedMaterial);
                }

                _MagistralPreparationAction.MagistralPackagingType = magistralDefinition.MagistralPackagingType;
                _MagistralPreparationAction.MagistralPackagingSubType = magistralDefinition.MagistralPackagingSubType;
                _MagistralPreparationAction.MagistralPreparationType = magistralDefinition.MagistralPreparationType;
                _MagistralPreparationAction.MagistralPreparationSubType = magistralDefinition.MagistralPreparationSubType;
            }

            if (MagistralPreparationDetails.CurrentCell == magistralPreparationRow.Cells["Amount"])
            {
                if(MagistralPreparationDetails.CurrentCell.Value != null && ((double)MagistralPreparationDetails.CurrentCell.Value) != 0)
                {
                    double amountMag = ((double)MagistralPreparationDetails.CurrentCell.Value) ;
                    foreach (MagistralPreparationUsedDrug drug in _MagistralPreparationAction.MagistralPreparationUsedDrugs)
                    {
                        drug.Amount = drug.Amount * amountMag;
                    }
                    foreach (MagistralPreparationUsedChemical chemical in _MagistralPreparationAction.MagistralPreparationUsedChemicals)
                    {
                        chemical.Amount = chemical.Amount * amountMag;
                    }
                }
            }
#endregion MagistralPreparationActionForm_MagistralPreparationDetails_CellValueChanged
        }

        private void ProducedAmount_TextChanged()
        {
#region MagistralPreparationActionForm_ProducedAmount_TextChanged
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_ProducedAmount_TextChanged
        }

        private void MagistralPackagingType_SelectedIndexChanged()
        {
#region MagistralPreparationActionForm_MagistralPackagingType_SelectedIndexChanged
   this._MagistralPreparationAction.MagistralPackagingSubType = null;
   AddUsedDetails();
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_MagistralPackagingType_SelectedIndexChanged
        }

        private void MagistralPackagingSubType_SelectedIndexChanged()
        {
#region MagistralPreparationActionForm_MagistralPackagingSubType_SelectedIndexChanged
   AddUsedDetails();
            CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_MagistralPackagingSubType_SelectedIndexChanged
        }

        private void NightShift_CheckedChanged()
        {
#region MagistralPreparationActionForm_NightShift_CheckedChanged
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_NightShift_CheckedChanged
        }

        private void MagistralPreparationSubType_SelectedIndexChanged()
        {
#region MagistralPreparationActionForm_MagistralPreparationSubType_SelectedIndexChanged
   CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_MagistralPreparationSubType_SelectedIndexChanged
        }

        private void MagistralPreparationType_SelectedIndexChanged()
        {
#region MagistralPreparationActionForm_MagistralPreparationType_SelectedIndexChanged
   this._MagistralPreparationAction.MagistralPreparationSubType = null;
            ControlVisibility();
            CalculateMagistralPrice();
#endregion MagistralPreparationActionForm_MagistralPreparationType_SelectedIndexChanged
        }

#region MagistralPreparationActionForm_Methods
        private void ControlVisibility()
        {
            if (MagistralPreparationType.SelectedItem != null)
            {
                this._MagistralPreparationAction.Volume = null;
                this._MagistralPreparationAction.ProducedAmount = null;
                MagistralPreparationType magistralPreparationType = (MagistralPreparationType)this._MagistralPreparationAction.ObjectContext.GetObject((Guid)MagistralPreparationType.SelectedItem.Value, typeof(MagistralPreparationType));
                switch (magistralPreparationType.ObjectID.ToString())
                {
                    case "e9431e89-223d-49bc-a946-a7ec7bf37fec": //Bölünmüş Tozlar
                        //MagistralPreparationType.Size = new Size(372, MagistralPreparationType.Size.Height);
                        labelVolume.Visible = false;
                        labelVolumeGram.Visible = false;
                        MagistralVolume.Visible = false;

                        //MagistralPreparationSubType.Size = new Size(266, MagistralPreparationSubType.Size.Height);
                        labelProducedAmount.Visible = true;
                        ProducedAmount.Visible = true;
                        this._MagistralPreparationAction.ProducedAmount = 1;
                        break;
                    case "b30cef6f-1e92-4975-8aa6-abad82cf9a0f": //Granüller
                    case "38892a5d-bd5c-421b-927d-1b70587687e5": //Sıcakta Hazırlanan çözeltiler
                    case "d4fcb7ba-e7ee-42fe-990c-c95cbb9e8f56": //Soğukta Hazırlanan çözeltiler
                    case "f5b98a2b-18c6-4c83-8390-08fc7d029c17": //Dahili ve harici olarak kullanılan, yağlı, yarı katı ve katı farmasötik formüller         
                        //MagistralPreparationType.Size = new Size(266, MagistralPreparationType.Size.Height);
                        labelVolume.Visible = true;
                        labelVolumeGram.Visible = true;
                        MagistralVolume.Visible = true;

                        //MagistralPreparationSubType.Size = new Size(372, MagistralPreparationSubType.Size.Height);
                        labelProducedAmount.Visible = false;
                        ProducedAmount.Visible = false;
                        break;
                    default:
                       // MagistralPreparationType.Size = new Size(372, MagistralPreparationType.Size.Height);
                        //MagistralPreparationSubType.Size = new Size(372, MagistralPreparationSubType.Size.Height);
                        labelVolume.Visible = false;
                        labelVolumeGram.Visible = false;
                        MagistralVolume.Visible = false;
                        labelProducedAmount.Visible = false;
                        ProducedAmount.Visible = false;
                        break;
                }
            }
        }

        private void AddUsedDetails()
        {
            MagistralPreparationAction mpa = this._MagistralPreparationAction;
            mpa.MagistralPreparationUsedDetails.DeleteChildren();
            //foreach (MagistralPreparationUsedDetail magistralPreparationUsedDetail in mpa.MagistralPreparationUsedDetails)
            //{
            //    ITTObject deletedObject = mpa.ObjectContext.GetObject(magistralPreparationUsedDetail.ObjectID, magistralPreparationUsedDetail.ObjectDef);
            //    deletedObject.Delete();
            //}
            if (mpa.MagistralPackagingSubType != null)
            {
                MagistralPreparationUsedDetail magistralPreparationUsedDetail = mpa.MagistralPreparationUsedDetails.AddNew();
                magistralPreparationUsedDetail.Material = mpa.MagistralPackagingSubType.Material;
                magistralPreparationUsedDetail.Amount = 1;
                magistralPreparationUsedDetail.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            }

            if (mpa.MagistralPreparationUsedMaterials.Count > 0)
            {
                foreach (MagistralPreparationUsedMaterial  magistralPreparationUsedMaterial in mpa.MagistralPreparationUsedMaterials)
                {
                    MagistralPreparationUsedDetail magistralPreparationUsedDetail = mpa.MagistralPreparationUsedDetails.AddNew();
                    magistralPreparationUsedDetail.Material = magistralPreparationUsedMaterial.ConsumableMaterial;
                    magistralPreparationUsedDetail.Amount = magistralPreparationUsedMaterial.Amount;
                    magistralPreparationUsedDetail.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                }
            }
            
            if (mpa.MagistralPreparationUsedDrugs.Count > 0)
            {
                foreach (MagistralPreparationUsedDrug magistralPreparationUsedDrug in mpa.MagistralPreparationUsedDrugs)
                {
                    MagistralPreparationUsedDetail magistralPreparationUsedDetail = mpa.MagistralPreparationUsedDetails.AddNew();
                    magistralPreparationUsedDetail.Material = magistralPreparationUsedDrug.DrugDefinition;
                    magistralPreparationUsedDetail.Amount = magistralPreparationUsedDrug.Amount;
                    magistralPreparationUsedDetail.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                }
            }

            if (mpa.MagistralPreparationUsedChemicals.Count > 0)
            {
                foreach (MagistralPreparationUsedChemical magistralPreparationUsedChemical in mpa.MagistralPreparationUsedChemicals)
                {
                    MagistralPreparationUsedDetail magistralPreparationUsedDetail = mpa.MagistralPreparationUsedDetails.AddNew();
                    magistralPreparationUsedDetail.Material = magistralPreparationUsedChemical.MagistralChemicalDefinition.Material;
                    magistralPreparationUsedDetail.Amount = magistralPreparationUsedChemical.Amount;
                    magistralPreparationUsedDetail.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                }
            }
        }

        private void CalculateMagistralPrice()
        {

            MagistralPreparationAction mpa = this._MagistralPreparationAction;
            double retValue = 0;
            if (mpa.MagistralPreparationType != null)
            {
                if (mpa.MagistralPreparationSubType != null)
                {
                    if (mpa.MagistralPreparationSubType.MagistralShareOfOverhead != null)
                        if (mpa.MagistralPreparationSubType.MagistralShareOfOverhead.Price.HasValue)
                            retValue += mpa.MagistralPreparationSubType.MagistralShareOfOverhead.Price.Value;
                    if (mpa.ProducedAmount.HasValue && mpa.ProducedAmount.Value > 0)
                        retValue += mpa.MagistralPreparationSubType.Price.Value * mpa.ProducedAmount.Value;
                }
                else
                {
                    if (mpa.MagistralPreparationType.MagistralShareOfOverhead != null)
                        if (mpa.MagistralPreparationType.MagistralShareOfOverhead.Price.HasValue)
                            retValue += mpa.MagistralPreparationType.MagistralShareOfOverhead.Price.Value;
                    if (mpa.MagistralPreparationType.Price.HasValue)
                        retValue += mpa.MagistralPreparationType.Price.Value;
                }

                if (mpa.Volume.HasValue && mpa.Volume.Value > 0)
                {
                    if (mpa.Volume.Value > mpa.MagistralPreparationType.Amount.Value)
                    {
                        double diffAmount = mpa.Volume.Value - mpa.MagistralPreparationType.Amount.Value;
                        int rest = Convert.ToInt32(diffAmount / mpa.MagistralPreparationType.AdditionalAmount);
                        retValue += mpa.MagistralPreparationType.AdditionalPrice.Value * rest;
                    }
                }

            }

            if (mpa.MagistralPreparationUsedDetails.Count > 0)
            {
                foreach (MagistralPreparationUsedDetail magistralPreparationUsedDetail in mpa.MagistralPreparationUsedDetails)
                {
                    if (magistralPreparationUsedDetail.Material != null)
                    {
                        if (magistralPreparationUsedDetail.Amount != null )
                        {
                            IList pricingListDefinitions = PricingListDefinition.GetByCode(mpa.ObjectContext, "3");
                            if (pricingListDefinitions.Count > 0)
                            {
                                IList pricingDetails = magistralPreparationUsedDetail.Material.GetMaterialPricingDetail((PricingListDefinition)pricingListDefinitions[0], TTObjectDefManager.ServerTime);
                                foreach (PricingDetailDefinition pricingDetailDefinition in pricingDetails)
                                    retValue += magistralPreparationUsedDetail.Amount.Value * pricingDetailDefinition.Price.Value;
                            }
                        }
                    }
                }
            }

            if (mpa.NightShift.HasValue && mpa.NightShift.Value == true)
            {
                retValue += retValue * 1.5;
            }

            if (mpa.Sterilization.HasValue && mpa.Sterilization.Value == true)
            {
                retValue += 4.50;
            }
            
            mpa.MagistralPrice = retValue;
        }
        
#endregion MagistralPreparationActionForm_Methods
    }
}