
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
    /// Nükleer Tıp Doktorda Formu
    /// </summary>
    public partial class NuclearMedicineToDoctorForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged += new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            cmdReport.Click += new TTControlEventDelegate(cmdReport_Click);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            GridNuclearMedicineMaterial.CellContentClick += new TTGridCellEventDelegate(GridNuclearMedicineMaterial_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttMasterResourceUserCheck.CheckedChanged -= new TTControlEventDelegate(ttMasterResourceUserCheck_CheckedChanged);
            cmdReport.Click -= new TTControlEventDelegate(cmdReport_Click);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            GridNuclearMedicineMaterial.CellContentClick -= new TTGridCellEventDelegate(GridNuclearMedicineMaterial_CellContentClick);
            base.UnBindControlEvents();
        }
        
        private void ttMasterResourceUserCheck_CheckedChanged()
        {
            /*
#region NuclearMedicineToDoctorForm_ttMasterResourceUserCheck_CheckedChanged
   if(this.ttMasterResourceUserCheck.Value == true)
            {
                this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._NuclearMedicine.MasterResource.ObjectID.ToString() + "'";
            }
            else
            {
                this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = null;
            }
#endregion NuclearMedicineToDoctorForm_ttMasterResourceUserCheck_CheckedChanged */
        } 
        
        private void cmdReport_Click()
        {
#region NuclearMedicineToDoctorForm_cmdReport_Click
   //this._NuclearMedicine.ShowViewer();
            
            string accessionNoStr = this._NuclearMedicine.NuclearMedicineTests[0].AccessionNo.ToString();
            string patientIdStr = this._NuclearMedicine.Episode.Patient.ID.ToString();
            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
#endregion NuclearMedicineToDoctorForm_cmdReport_Click
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region NuclearMedicineToDoctorForm_GridEpisodeDiagnosis_CellContentClick
            //            if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //            {
            //                
            //                NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
            //                nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
            //            }

            // DialysisOrderDetail ->
            //TODO:ShowEdit
            //if ( (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn != null) && (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum") )
            //{
            //    NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
            //    NuclearMedicine inp = (NuclearMedicine)GridEpisodeDiagnosis.CurrentCell.OwningRow.TTObject;
            //    nmcod.ShowEdit(this.FindForm(), inp);
            //}  

            //    public class _DialysisOrderForm : DialysisOrderForm
            //    {
            //        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
            //        {
            //            // <-- Automatically generated part.
            //
            //            if ((((ITTGridCell)OrderDetails.CurrentCell).OwningColumn != null) && (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //            {
            //                DialysisOrderDetail_CokluOzelDurumForm codf = new DialysisOrderDetail_CokluOzelDurumForm();
            //                DialysisOrderDetail inp = (DialysisOrderDetail)OrderDetails.CurrentCell.OwningRow.TTObject;
            //                codf.ShowEdit(this.FindForm(), inp);
            //            }
            //        
            //            // Automatically generated part. -->
            //        }
            //    }
            var a = 1;
            #endregion NuclearMedicineToDoctorForm_GridEpisodeDiagnosis_CellContentClick
        }

        private void GridNuclearMedicineMaterial_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NuclearMedicineToDoctorForm_GridNuclearMedicineMaterial_CellContentClick
   //            if (((ITTGridCell)GridNuclearMedicineMaterial.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
//            {
//                
//                NuclearMedicineCokluOzelDurum nmcod = new NuclearMedicineCokluOzelDurum();
//                nmcod.ShowEdit(this.FindForm(), this._NuclearMedicine);
//            }
#endregion NuclearMedicineToDoctorForm_GridNuclearMedicineMaterial_CellContentClick
        }

        protected override void PreScript()
        {
#region NuclearMedicineToDoctorForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
#endregion NuclearMedicineToDoctorForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region NuclearMedicineToDoctorForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            //if(this.ttMasterResourceUserCheck.Value != null && this.ttMasterResourceUserCheck.Value == true)
            //{
            //    this.RESPONSIBLEACADEMICSTAFF.ListFilterExpression = "USERRESOURCES.RESOURCE='" + this._NuclearMedicine.MasterResource.ObjectID.ToString() + "'";
            //}

            if (this._NuclearMedicine.CurrentStateDefID.Equals(NuclearMedicine.States.Doctor))
            {
                this.DropStateButton(NuclearMedicine.States.Approve);
            }
            if (this._NuclearMedicine.NuclearMedicineTests.Count > 0)
            {
                if (this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject != null)
                {
                    nucMedSelectedTesttxt.Text = this._NuclearMedicine.NuclearMedicineTests[0].ProcedureObject.Name;
                }
            }
            //this._NuclearMedicine.ResponsibleDoctor = Common.CurrentResource;

            //if (TTUser.CurrentUser.HasRight(this.RESPONSIBLEDOCTOR.ObjectDef, this._NuclearMedicine, (int)TTSecurityAuthority.RightsEnum.UpdateFormField))
            //{
            //    this._NuclearMedicine.ResponsibleDoctor = Common.CurrentResource;
            //    this.RESPONSIBLEDOCTOR.ReadOnly = true;
            //}
            
            
            ITTGridColumn directPurchaseDetailColumn = (ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"];
            
            string filterString = "";
            if(this._NuclearMedicine.Episode.Patient != null)
                filterString = "DIRECTPURCHASEACTIONDETAIL.DIRECTPURCHASEACTION.PATIENT = '" + this._NuclearMedicine.Episode.Patient.ObjectID.ToString() + "'";
            ((ITTListBoxColumn)directPurchaseDetailColumn).ListFilterExpression = filterString;
            
            
            MultiSelectForm msItem = new MultiSelectForm();

            IList<DPADetailFirmPriceOffer> dPADetailFirmPriceOffers = (IList<DPADetailFirmPriceOffer>) TTObjectClasses.DPADetailFirmPriceOffer.GetUnsedAndApproved22FMaterialByPatient(_NuclearMedicine.ObjectContext, this._NuclearMedicine.Episode.Patient.ObjectID);
            
            List<Guid> radioPharmaceuticalMaterialList = new List<Guid>();
            bool radioPharmaceutical = false;
            
            if(_NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.Count == 0)
            {
                foreach(NuclearMedicineTest nuclearMedicineTest in _NuclearMedicine.NuclearMedicineTests)
                {
                    if (nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials != null && nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials.Count > 0)
                    {
                        foreach (DPADetailFirmPriceOffer dPADetailFirmPriceOffer in dPADetailFirmPriceOffers)
                        {
                            if(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                            {
                                radioPharmaceuticalMaterialList.Add(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.ObjectID);
                                radioPharmaceutical = true;
                            }
                        }
                        if( !radioPharmaceutical )
                        {
                            if(TTObjectClasses.SystemParameter.GetParameterValue("ISRADYOFARMASOTIKMATERIALCONTROL", "TRUE") == "TRUE")
                                throw new Exception ("Bu Nükleer Tıp işlemi için doğrudan temin ile malzeme alınmalı ! ");
                            
                        }
                    }
                    radioPharmaceutical = false;
                }
            }
            
            foreach (DPADetailFirmPriceOffer dPADetailFirmPriceOffer in dPADetailFirmPriceOffers)
            {
                if(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DirectPurchaseAction.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
                {
                    foreach (NuclearMedicineTest nuclearMedicineTest in _NuclearMedicine.NuclearMedicineTests)
                    {
                        if (nuclearMedicineTest.NuclearMedicineTestDef.ObjectID == dPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.ObjectID && _NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.Count == 0)
                        {
                            foreach (NuclearMedicineGridPharmDefinition nM in nuclearMedicineTest.NuclearMedicineTestDef.PharmMaterials)
                            {
                                if (radioPharmaceuticalMaterialList.Contains(nM.RadioPharmaCeuticalMaterial.ObjectID) == false)
                                {
                                    if(TTObjectClasses.SystemParameter.GetParameterValue("ISRADYOFARMASOTIKMATERIALCONTROL", "TRUE") == "TRUE")
                                        throw new Exception("Bu Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik, devam edemezsiniz ! ");
                                    
                                }
                                
                            }
                        }
                    }
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.ProcedureSUTCode.SUTCode + " " + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.RadioPharmaceuticalMaterial.Name, dPADetailFirmPriceOffer.ObjectID.ToString());
                }
                else
                {
                    if(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode != null && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode) == false && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                        msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode + " " + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
                    else if(string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                        msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
                }
                
            }
            
            string key = msItem.GetMSItem(null,"Hastanın 22F Malzemesi Bulunmakta, Kullanmak İstediklerinizi Seçiniz", false, false, true);
            if (!string.IsNullOrEmpty(key))
            {
                foreach (string sp in msItem.MSSelectedItems.Keys)
                {
                    //  createSubProcedure = true;
                    
                    DPADetailFirmPriceOffer dpa = (DPADetailFirmPriceOffer)_NuclearMedicine.ObjectContext.GetObject(new Guid(sp),"DPADetailFirmPriceOffer");
                    
                    if(dpa.OfferedUBB != null)
                    {
                        SurgeryDirectPurchaseGrid sdp = new SurgeryDirectPurchaseGrid(_NuclearMedicine.ObjectContext);
                        sdp.DPADetailFirmPriceOffer = dpa;
                        _NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.Add(sdp);
                    }
                    else
                    {
                        RadyofarmasotikDirectPurchaseGrid rdp = new RadyofarmasotikDirectPurchaseGrid(_NuclearMedicine.ObjectContext);
                        rdp.DPADetailFirmPriceOffer = dpa;
                        _NuclearMedicine.NuclearMedicine_RadyofarmasotikDirectPurchaseGrids.Add(rdp);
                    }

                }
            }
#endregion NuclearMedicineToDoctorForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region NuclearMedicineToDoctorForm_PostScript
    base.PostScript(transDef);
            
            if(_NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach(SurgeryDirectPurchaseGrid sdg in _NuclearMedicine.NuclearMedicine_SurgeryDirectPurchaseGrids)
                {
                    if(materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            
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
            
            if( radioPharmaceutical )
            {
                if(TTObjectClasses.SystemParameter.GetParameterValue("ISRADYOFARMASOTIKMATERIALCONTROL", "TRUE") == "TRUE")
                    throw new Exception ("Yapılacak Nükleer Tıp işlemi için doğrudan temin ile alınan malzemeler eksik seçildi ! ");
                
            }
            
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
#endregion NuclearMedicineToDoctorForm_PostScript

            }
            
#region NuclearMedicineToDoctorForm_Methods
        //        protected override void OnShown(EventArgs e)
//        {
//            base.OnShown(e);
//            this.DrawUserButton("Onayla ve Raporla");
//        }
//
//        public void DrawUserButton(string buttonTitle)
//        {
//            this.AddManualStepButton(buttonTitle, new EventHandler(btnApproveWReport_Click));
//        }
//        void btnApproveWReport_Click(object sender, EventArgs e)
//        {
//            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//            TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//            cache.Add("VALUE", _NuclearMedicine.ObjectID.ToString());
//            parameters.Add("TTOBJECTID", cache);
//            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_NuclearMedicineResultReport), true, 1, parameters);
//            // TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef) NuclearMedicine.States.Approve;
//            // DoContextUpdate(transDef);
//        }
        
#endregion NuclearMedicineToDoctorForm_Methods
    }
}