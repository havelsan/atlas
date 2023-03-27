
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
    public partial class PMAddingPatientShareForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridProcedure.CellValueChanged += new TTGridCellEventDelegate(GridProcedure_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridProcedure.CellValueChanged -= new TTGridCellEventDelegate(GridProcedure_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridProcedure_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PMAddingPatientShareForm_GridProcedure_CellValueChanged
   if(this.GridProcedure.CurrentCell != null && this.GridProcedure.CurrentCell.OwningColumn != null)
            {
                if(this.GridProcedure.CurrentCell.OwningColumn.Name == "ttlistboxcolumn1" || this.GridProcedure.CurrentCell.OwningColumn.Name == "RROBOTICSURGERYPACKAGE")
                {
                    if(rowIndex < this.GridProcedure.Rows.Count && rowIndex > -1)
                    {
                        TTObjectClasses.PMAddingPSProcedure psProcedure = (TTObjectClasses.PMAddingPSProcedure) this.GridProcedure.CurrentCell.OwningRow.TTObject;
                        if(psProcedure.ProcedureObject != null && psProcedure.RoboticSurgeryPackage.HasValue && (bool)psProcedure.RoboticSurgeryPackage == true)
                        {
                            IList pricingListDefinition = PricingListDefinition.GetByCode(psProcedure.ObjectContext, "7");  // Robotik Cerrahi Fiyat Listesi
                            ArrayList pricingDetailList = new ArrayList();
                            if(SubEpisode.IsSGKSubEpisode(_PMAddingPatientShare.SubEpisode))  //SGK lı hasta
                            {
                                if(pricingListDefinition.Count > 0)
                                {
                                    PricingListDefinition pld = (PricingListDefinition) pricingListDefinition[0];
                                    ProcedureDefinition pd = (ProcedureDefinition) psProcedure.ProcedureObject;
                                    ProcedureDefinition procedure = ProcedureDefinition.GetActiveByCode(this._PMAddingPatientShare.ObjectContext,"P"+pd.Code);
                                    if(procedure == null)
                                    {
                                        InfoBox.Show(pd.Code + " kodlu hizmetin tanımlı paket hizmeti bulunmamaktadır.");
                                        psProcedure.PatientPrice = null;
                                        //psProcedure.RoboticSurgeryPackage = null;
                                    }
                                    if(procedure != null)
                                    {
                                        pricingDetailList = procedure.GetProcedurePricingDetail(pld,DateTime.Now);
                                        if(pricingDetailList.Count > 0)
                                        {
                                            psProcedure.PatientPrice = ((PricingDetailDefinition)pricingDetailList[0]).Price;
                                        }
                                        else
                                        {
                                            InfoBox.Show("P"+pd.Code + " kodlu paket hizmetinin Robotik Cerrahi Fiyat Listesi ile eşleştirilmiş kaydı bulunmamaktadır.");
                                            psProcedure.PatientPrice = null;
                                            //psProcedure.RoboticSurgeryPackage = null;
                                        }
                                    }
                                }
                            }
                            else // Ücretli Hasta
                            {
                                IList pricingListDefinitions = null;
                                if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "TRUE")   //Universite XXXXXX
                                {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(psProcedure.ObjectContext, "6");
                                }
                                else if(TTObjectClasses.SystemParameter.GetParameterValue("UNIVERSITEXXXXXX","FALSE") == "FALSE")   // Sağlık Bakanlığı
                                {
                                    pricingListDefinitions = PricingListDefinition.GetByCode(psProcedure.ObjectContext, "5");
                                }
                                
                                if(pricingListDefinitions.Count > 0)
                                {
                                    PricingListDefinition pld = (PricingListDefinition)pricingListDefinitions[0];
                                    ProcedureDefinition pd = (ProcedureDefinition) psProcedure.ProcedureObject;
                                    ProcedureDefinition procedure = ProcedureDefinition.GetActiveByCode(this._PMAddingPatientShare.ObjectContext, "P" + pd.Code);
                                    if(procedure == null)
                                    {
                                        InfoBox.Show(pd.Code + " kodlu hizmetin tanımlı paket hizmeti bulunmamaktadır.");
                                        psProcedure.PatientPrice = null;
                                        //psProcedure.RoboticSurgeryPackage = null;
                                    }
                                    else
                                    {
                                        pricingDetailList = procedure.GetProcedurePricingDetail(pld, DateTime.Now);
                                        if(pricingDetailList.Count > 0)
                                        {
                                            // Kamu Satış Tarifesi Fiyat Listesi için tanımlı fiyat 1,5 ile çarpılır.
                                            psProcedure.PatientPrice = (((PricingDetailDefinition)pricingDetailList[0]).Price * 3)/2;
                                        }
                                        else
                                        {
                                            // SUT Fiyat Listesi için tanımlı fiyat 3 ile çarpılır.
                                            PricingListDefinition SUTPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(_PMAddingPatientShare.ObjectContext, TTObjectClasses.SystemParameter.GetParameterValue("SUTPRICELISTOBJECTID", "").ToString())[0];
                                            pricingDetailList = procedure.GetProcedurePricingDetail(SUTPriceList,DateTime.Now);
                                            if(pricingDetailList.Count > 0)
                                                psProcedure.PatientPrice = (((PricingDetailDefinition)pricingDetailList[0]).Price) * 3;
                                            else
                                            {
                                                InfoBox.Show("P"+pd.Code + " kodlu paket hizmetinin SUT Fiyat Listesi ile eşleştirilmiş kaydı bulunmamaktadır.");
                                                psProcedure.PatientPrice = null;
                                                //psProcedure.RoboticSurgeryPackage = null;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            psProcedure.PatientPrice = null;
                        }
                    }
                }
            }
#endregion PMAddingPatientShareForm_GridProcedure_CellValueChanged
        }

        protected override void PreScript()
        {
#region PMAddingPatientShareForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
#endregion PMAddingPatientShareForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PMAddingPatientShareForm_PostScript
    base.PostScript(transDef);
            if(transDef != null && transDef.FromStateDefID == PMAddingPatientShare.States.New && transDef.ToStateDefID == PMAddingPatientShare.States.Completed)
            {
                if(this._PMAddingPatientShare.PMAddingPSProcedures.Count == 0 && this._PMAddingPatientShare.PMAddingPSMaterials.Count == 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(1241));
                
                foreach (PMAddingPSProcedure addingProcedure in this._PMAddingPatientShare.PMAddingPSProcedures)
                {
                    // Hasta Fiyatı girilmişse, girilen fiyatı kullanması için SubActionProcPricingDet oluşturuluyor
                    if(addingProcedure.PatientPrice != null)
                    {
                        SubActionProcPricingDet subActionProcPricingDet = new SubActionProcPricingDet(this._PMAddingPatientShare.ObjectContext);
                        subActionProcPricingDet.Description = addingProcedure.ProcedureObject.Name;
                        subActionProcPricingDet.ExternalCode = addingProcedure.ProcedureObject.Code;
                        subActionProcPricingDet.PatientPrice = addingProcedure.PatientPrice;
                        addingProcedure.SetPerformedDate();
                        subActionProcPricingDet.SubActionProcedure = addingProcedure;
                    }
                }
                
                foreach (PMAddingPSMaterial addingMaterial in this._PMAddingPatientShare.PMAddingPSMaterials)
                {
                    // Hasta Fiyatı girilmişse, girilen fiyatı kullanması için SubActionMatPricingDet oluşturuluyor
                    if(addingMaterial.PatientPrice != null)
                    {
                        SubActionMatPricingDet subActionMatPricingDet = new SubActionMatPricingDet(this._PMAddingPatientShare.ObjectContext);
                        subActionMatPricingDet.Amount = addingMaterial.Amount;
                        subActionMatPricingDet.Description = addingMaterial.Material.Name;
                        subActionMatPricingDet.ExternalCode = addingMaterial.Material.Code;
                        subActionMatPricingDet.PatientPrice = addingMaterial.PatientPrice;
                        subActionMatPricingDet.SubActionMaterial = addingMaterial;
                    }
                }
            }
#endregion PMAddingPatientShareForm_PostScript

            }
                }
}