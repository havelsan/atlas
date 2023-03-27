
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
    /// Sayım Emri için kullanılan temel sınıftır
    /// </summary>
    public  partial class CensusOrder : StockAction
    {
        public partial class GetCensusListReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetCensusOrderCensusReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetCensusOrderReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class CensusRecordReportRQ_Class : TTReportNqlObject 
        {
        }

        protected void PostTransition_StockCardRegistry2Completed()
        {
            // From State : StockCardRegistry   To State : Completed
#region PostTransition_StockCardRegistry2Completed
            


            bool fix = false;
            foreach (CensusOrderDetail censusOrderDetail in CensusOrderDetails)
            {
                if (censusOrderDetail.NewInheld != censusOrderDetail.CensusNewInheld || censusOrderDetail.UsedInheld != censusOrderDetail.CensusUsedInheld)
                {
                    fix = true;
                    break;
                }
            }
            if (fix)
            {
                CensusFixed censusFixed = new CensusFixed(ObjectContext);
                IList mainStores = MainStoreDefinition.GetAllMainStores(ObjectContext);
                if (mainStores.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M26236", "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz."));
                if (mainStores.Count == 1)
                {
                    censusFixed.Store = (MainStoreDefinition)mainStores[0];
                }
                else if (mainStores.Count > 1)
                {
                    censusFixed.Store = Store;
                }
                censusFixed.CurrentStateDefID = CensusFixed.States.New;

                foreach (CensusOrderDetail censusOrderDetail in CensusOrderDetails)
                {
                    if (censusOrderDetail.NewInheld != censusOrderDetail.CensusNewInheld)
                    {
                        if (censusOrderDetail.NewInheld > censusOrderDetail.CensusNewInheld)
                        {
                            CensusFixedMaterialOut censusFixedMaterialOut = new CensusFixedMaterialOut(ObjectContext);
                            censusFixedMaterialOut.Material = censusOrderDetail.Material;
                            censusFixedMaterialOut.Amount = censusOrderDetail.NewInheld;
                            censusFixedMaterialOut.CensusAmount = censusOrderDetail.CensusNewInheld;
                            censusFixedMaterialOut.OrderSequenceNumber = censusOrderDetail.OrderSequenceNumber;
                            censusFixedMaterialOut.StockLevelType = StockLevelType.NewStockLevel;
                            censusFixed.CensusFixedOutMaterials.Add(censusFixedMaterialOut);
                        }
                        if (censusOrderDetail.NewInheld < censusOrderDetail.CensusNewInheld)
                        {
                            CensusFixedMaterialIn censusFixedMaterialIn = new CensusFixedMaterialIn(ObjectContext);
                            censusFixedMaterialIn.Material = censusOrderDetail.Material;
                            censusFixedMaterialIn.Amount = censusOrderDetail.NewInheld;
                            censusFixedMaterialIn.CensusAmount = censusOrderDetail.CensusNewInheld;
                            censusFixedMaterialIn.OrderSequenceNumber = censusOrderDetail.OrderSequenceNumber;
                            censusFixedMaterialIn.UnitPrice = 0;
                            censusFixedMaterialIn.StockLevelType = StockLevelType.NewStockLevel;
                            censusFixed.CensusFixedInMaterials.Add(censusFixedMaterialIn);
                        }

                        if (censusOrderDetail.UsedInheld > censusOrderDetail.CensusUsedInheld)
                        {
                            CensusFixedMaterialOut censusFixedMaterialOut = new CensusFixedMaterialOut(ObjectContext);
                            censusFixedMaterialOut.Material = censusOrderDetail.Material;
                            censusFixedMaterialOut.Amount = censusOrderDetail.UsedInheld;
                            censusFixedMaterialOut.CensusAmount = censusOrderDetail.CensusUsedInheld;
                            censusFixedMaterialOut.OrderSequenceNumber = censusOrderDetail.OrderSequenceNumber;
                            censusFixedMaterialOut.StockLevelType = StockLevelType.UsedStockLevel;
                            censusFixed.CensusFixedOutMaterials.Add(censusFixedMaterialOut);
                        }
                        if (censusOrderDetail.UsedInheld < censusOrderDetail.CensusUsedInheld)
                        {
                            CensusFixedMaterialIn censusFixedMaterialIn = new CensusFixedMaterialIn(ObjectContext);
                            censusFixedMaterialIn.Material = censusOrderDetail.Material;
                            censusFixedMaterialIn.Amount = censusOrderDetail.UsedInheld;
                            censusFixedMaterialIn.CensusAmount = censusOrderDetail.CensusUsedInheld;
                            censusFixedMaterialIn.OrderSequenceNumber = censusOrderDetail.OrderSequenceNumber;
                            censusFixedMaterialIn.UnitPrice = 0;
                            censusFixedMaterialIn.StockLevelType = StockLevelType.UsedStockLevel;
                            censusFixed.CensusFixedInMaterials.Add(censusFixedMaterialIn);
                        }
                    }
                }
            }



#endregion PostTransition_StockCardRegistry2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CensusOrder).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CensusOrder.States.StockCardRegistry && toState == CensusOrder.States.Completed)
                PostTransition_StockCardRegistry2Completed();
        }

    }
}