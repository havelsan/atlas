
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// New Form
//    /// </summary>
//    public partial class ProtocolPriceCalculationForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            CalculateButon.Click += new TTControlEventDelegate(CalculateButon_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            CalculateButon.Click -= new TTControlEventDelegate(CalculateButon_Click);
//            base.UnBindControlEvents();
//        }

//        private void CalculateButon_Click()
//        {
//#region ProtocolPriceCalculationForm_CalculateButon_Click
//   ProtocolDefinition selectedProtocol = null;
//            PackageDefinition selectedPackage = null;
//            ProcedureDefinition selectedProcedure = null;
//            Material selectedMaterial = null;
//            ArrayList pricingDetailList = new ArrayList();
//            double totalPatientPrice = 0;
//            double totalPayerPrice = 0;
//            double pPrice = 0;


//            if (this.PROTOCOL.SelectedObjectID != null)
//            {
                
//                selectedProtocol = (ProtocolDefinition)_ProtocolPriceCalculation.ObjectContext.QueryObjects("PROTOCOLDEFINITION", "OBJECTID = '" + this.PROTOCOL.SelectedObjectID + "'")[0];
                
//                if (this.PROCEDURE.SelectedObjectID != null)
//                {
//                    selectedProcedure = (ProcedureDefinition)_ProtocolPriceCalculation.ObjectContext.QueryObjects("PROCEDUREDEFINITION","OBJECTID = '" + this.PROCEDURE.SelectedObjectID + "'")[0];
//                    pricingDetailList = (ArrayList)selectedProtocol.CalculatePrice(selectedProcedure, (PatientStatusEnum)_ProtocolPriceCalculation.PATIENTSTATUS, null, DateTime.Now, null);
//                    foreach(ManipulatedPrice pp in pricingDetailList)
//                    {
//                        totalPatientPrice = totalPatientPrice + (double)pp.PatientPrice;
//                        totalPayerPrice = totalPayerPrice + (double)pp.PayerPrice;
//                    }
                    
//                    _ProtocolPriceCalculation.PATIENTPRICE = totalPatientPrice;
//                    _ProtocolPriceCalculation.PAYERPRICE = totalPayerPrice;
//                }
                
//                if (this.MATERIAL.SelectedObjectID != null)
//                {
//                    selectedMaterial = (Material)_ProtocolPriceCalculation.ObjectContext.QueryObjects("MATERIAL","OBJECTID = '" + this.MATERIAL.SelectedObjectID + "'")[0];
//                    pricingDetailList = (ArrayList)selectedProtocol.CalculatePrice(selectedMaterial, (PatientStatusEnum)_ProtocolPriceCalculation.PATIENTSTATUS, null, DateTime.Now, null);
//                    foreach(ManipulatedPrice pp in pricingDetailList)
//                    {
//                        totalPatientPrice = totalPatientPrice + (double)pp.PatientPrice;
//                        totalPayerPrice = totalPayerPrice + (double)pp.PayerPrice;
//                    }
                    
//                    _ProtocolPriceCalculation.PATIENTPRICE = totalPatientPrice;
//                    _ProtocolPriceCalculation.PAYERPRICE = totalPayerPrice;
//                }
//            }
            
            
//            //Paket kapsam kontrolu
//            if(this.PACKAGE.SelectedObjectID != null)
//            {
//                selectedPackage = (PackageDefinition) _ProtocolPriceCalculation.ObjectContext.QueryObjects("PACKAGEDEFINITION", "OBJECTID = '" + this.PACKAGE.SelectedObjectID + "'")[0];
//                if (this.PROCEDURE.SelectedObjectID != null)
//                {
//                    selectedProcedure = (ProcedureDefinition)_ProtocolPriceCalculation.ObjectContext.QueryObjects("PROCEDUREDEFINITION","OBJECTID = '" + this.PROCEDURE.SelectedObjectID + "'")[0];
//                    _ProtocolPriceCalculation.ISINCLUDED = selectedPackage.IsIncluded(selectedProcedure,0);

//                    pricingDetailList = selectedPackage.CalculatePackagePrice(selectedProcedure, DateTime.Now);
//                    foreach(ManipulatedPrice pp in pricingDetailList)
//                    {
//                        pPrice = pPrice + (double) pp.Price;
//                    }
//                    _ProtocolPriceCalculation.PACKAGEPRICE = pPrice;
//                }
                
//                if (this.MATERIAL.SelectedObjectID != null)
//                {
//                    selectedMaterial = (Material)_ProtocolPriceCalculation.ObjectContext.QueryObjects("MATERIAL","OBJECTID = '" + this.MATERIAL.SelectedObjectID + "'")[0];
//                    _ProtocolPriceCalculation.ISINCLUDED = selectedPackage.IsIncluded(selectedMaterial, 0);
                    
//                    pricingDetailList = selectedPackage.CalculatePackagePrice(selectedMaterial,DateTime.Now);
//                    foreach(ManipulatedPrice pp in pricingDetailList)
//                    {
//                        pPrice = pPrice + (double) pp.Price;
//                    }
//                    _ProtocolPriceCalculation.PACKAGEPRICE = pPrice;
//                }
          
//            }
//#endregion ProtocolPriceCalculationForm_CalculateButon_Click
//        }
//    }
//}