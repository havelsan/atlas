
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


namespace TTObjectClasses
{
    /// <summary>
    /// Ambalajlama İş İstek
    /// </summary>
    public  partial class PackagingDepartmentAction : CMRAction
    {
        protected void PreTransition_Carpenter2Completed()
        {
            // From State : Carpenter   To State : Completed
#region PreTransition_Carpenter2Completed
            
            
            
            foreach (UsedConsumedMaterail usedMaterial in UsedConsumedMaterails)
            {
                if (usedMaterial.SuppliedAmount == usedMaterial.Amount || usedMaterial.SuppliedAmount > usedMaterial.Amount)
                {
                    usedMaterial.CurrentStateDefID = UsedConsumedMaterail.States.Completed;
                    usedMaterial.Update();
                }
                else
                {
                    throw new TTUtils.TTException( SystemMessage.GetMessageV3(965, new string[] {usedMaterial.Material.Name.ToString()}));
                }
            }
            
           
            

#endregion PreTransition_Carpenter2Completed
        }

        protected void PostTransition_Carpenter2Completed()
        {
            // From State : Carpenter   To State : Completed
#region PostTransition_Carpenter2Completed
            
            if(UsedConsumedMaterails.Count>0)
            {
                ProductionConsumptionDocument productionConsumptionDocument = new ProductionConsumptionDocument(ObjectContext);
                productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.New;
                productionConsumptionDocument.Store = ResDivision.Store ;
                productionConsumptionDocument.DestinationStore = ((SectionRequirement)SectionRequirements[0]).Store ;
                productionConsumptionDocument.Update();
                
                foreach (UsedConsumedMaterail usedConsumedMaterial in UsedConsumedMaterails)
                {
                    if (usedConsumedMaterial.StockOut != null)
                    {
                        foreach (StockOutMaterial stockOutMaterial in usedConsumedMaterial.StockOut.StockOutMaterials)
                        {
                            ProductionConsumptionDocumentMaterialOut productionConsumptionDocumentMaterialOut = productionConsumptionDocument.ProductionConsumptionDocumentOutMaterials.AddNew();
                            productionConsumptionDocumentMaterialOut.Material = stockOutMaterial.Material;
                            productionConsumptionDocumentMaterialOut.Amount = stockOutMaterial.Amount;
                            productionConsumptionDocumentMaterialOut.StockLevelType = stockOutMaterial.StockLevelType ;
                            foreach (StockTransaction stockTransaction in stockOutMaterial.StockTransactions)
                            {
                                StockCollectedTrx stockCollectedTrx = new StockCollectedTrx(ObjectContext);
                                stockCollectedTrx.StockTransaction = stockTransaction;
                                productionConsumptionDocumentMaterialOut.StockCollectedTrxs.Add(stockCollectedTrx);
                            }
                        }
                    }
                }
                productionConsumptionDocument.CurrentStateDefID = ProductionConsumptionDocument.States.Approval;
            }

#endregion PostTransition_Carpenter2Completed
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PackagingDepartmentAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackagingDepartmentAction.States.Carpenter && toState == PackagingDepartmentAction.States.Completed)
                PreTransition_Carpenter2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PackagingDepartmentAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PackagingDepartmentAction.States.Carpenter && toState == PackagingDepartmentAction.States.Completed)
                PostTransition_Carpenter2Completed();
        }

    }
}