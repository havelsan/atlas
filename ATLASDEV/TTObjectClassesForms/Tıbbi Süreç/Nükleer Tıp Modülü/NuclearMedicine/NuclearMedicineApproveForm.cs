
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
    /// Nükleer Tıp Onayda Formu
    /// </summary>
    public partial class NuclearMedicineApproveForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridNuclearMedicineMaterial.CellContentClick += new TTGridCellEventDelegate(GridNuclearMedicineMaterial_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridNuclearMedicineMaterial.CellContentClick -= new TTGridCellEventDelegate(GridNuclearMedicineMaterial_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridNuclearMedicineMaterial_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region NuclearMedicineApproveForm_GridNuclearMedicineMaterial_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridNuclearMedicineMaterial.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
            //{

            //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
            //    nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
            //}
            var a = 1;
            #endregion NuclearMedicineApproveForm_GridNuclearMedicineMaterial_CellContentClick
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region NuclearMedicineApproveForm_GridEpisodeDiagnosis_CellContentClick
            //TODO:ShowEdit
            //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //{

            //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
            //    nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
            //}
            var a = 1;
            #endregion NuclearMedicineApproveForm_GridEpisodeDiagnosis_CellContentClick
        }

        protected override void PreScript()
        {
#region NuclearMedicineApproveForm_PreScript
    base.PreScript();
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }

            this.DropStateButton(NuclearMedicine.States.Cancelled);
#endregion NuclearMedicineApproveForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineApproveForm_PostScript
    base.PostScript(transDef);
            
            
            List<Guid> radioPharmaceuticalMaterialList = new List<Guid>();
            bool radioPharmaceutical = false;
            
            foreach (RadyofarmasotikDirectPurchaseGrid radyofarmasotikDirectPurchaseGrid in _NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids)
            {
                radioPharmaceuticalMaterialList.Add(radyofarmasotikDirectPurchaseGrid.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.ObjectID);
            }
            
            foreach(NuclearMedicineTest nuclearMedicineTest in _NuclearMedicine.NuclearMedicineTests)
            {
                if (nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials != null && nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials.Count > 0)
                {
                    foreach(NuclearMedicineGridPharmDefinition nuclearMedicineGridPharmDefinition in nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials )
                    {
                        if(nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial != null && !radioPharmaceuticalMaterialList.Contains(nuclearMedicineGridPharmDefinition.RadioPharmaCeuticalMaterial.ObjectID))
                            radioPharmaceutical = true;
                    }
                }
            }
            
            if( radioPharmaceutical && TTObjectClasses.SystemParameter.GetParameterValue("ISRADYOFARMASOTIKMATERIALCONTROL", "TRUE") == "TRUE")
                throw new Exception ("Yapılacak Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik seçildi ! ");
            
            
            if(transDef != null)
            {
                if(transDef.ToStateDefID == NuclearMedicine.States.Reported)
                {
                    foreach (SurgeryDirectPurchaseGrid sdg in _NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids)
                    {
                        SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
                        titubbPrice.PatientPrice = 0;
                        titubbPrice.SubActionMaterial = sdg;

                        if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode != null)
                        {
                            titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                            titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                            titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                        }
                        //                else
                        //                {
                        //                    titubbPrice.ExternalCode = "KODSUZ";
                        //                    titubbPrice.Description = productDefinition.Name;
                        //                    titubbPrice.PayerPrice = 0;
                        //                }
                        titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
                    }
                    
                    foreach (RadyofarmasotikDirectPurchaseGrid rdg in _NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids)
                    {
                        SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(this._NuclearMedicine.ObjectContext);
                        titubbPrice.PatientPrice = 0;
                        titubbPrice.SubActionMaterial = rdg;

                        if (rdg.DPADetailFirmPriceOffer != null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail != null && rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode != null &&  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial != null)
                        {
                            titubbPrice.ExternalCode = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.SUTCode;
                            titubbPrice.Description = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.Name;
                            titubbPrice.PayerPrice = 0;
                        }
                        //  titubbPrice.ProductDefinition = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.pr;
                    }
                }
            }
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach (SurgeryDirectPurchaseGrid sdg in this._NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids)
            {
                sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
                sdg.Material = (Material)this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
                
            }
            foreach (RadyofarmasotikDirectPurchaseGrid rdg in _NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids)
            {
                rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
                rdg.Material = (Material)this._NuclearMedicine.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                // rdg.UBBCode =  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode != null ?  rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.ProductNumber : null;
                rdg.Amount = rdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
                
            }
#endregion NuclearMedicineApproveForm_PostScript

            }
                }
}