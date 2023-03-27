
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
    /// Ayıklama İşlemi için kullanılan temel sınıftır
    /// </summary>
    public  partial class ShellingProcedure : StockAction, IStockInTransaction, IStockOutTransaction
    {
        protected void PostTransition_SortingClassification2Completed()
        {
            // From State : SortingClassification   To State : Completed
#region PostTransition_SortingClassification2Completed
            
            
            

            CensusFixed censusFixed = new CensusFixed(ObjectContext);
            censusFixed.Store = Store;
            censusFixed.Description = Description;
            censusFixed.MasterAction = this;

            int i = 1;
            foreach (ShellingProcedureMaterialOut shellingProcedureMaterialOut in ShellingProcedureOutMaterials)
            {
                CensusFixedMaterialOut censusFixedMaterialOut = censusFixed.CensusFixedOutMaterials.AddNew();
                censusFixedMaterialOut.Material = shellingProcedureMaterialOut.Material;
                censusFixedMaterialOut.Amount = shellingProcedureMaterialOut.Amount;
                censusFixedMaterialOut.StockLevelType = shellingProcedureMaterialOut.StockLevelType;
                censusFixedMaterialOut.OrderSequenceNumber = i;
                censusFixedMaterialOut.CardAmount = shellingProcedureMaterialOut.Amount;
                censusFixedMaterialOut.CensusAmount = 0;
                foreach (FixedAssetOutDetail fixedAssetOutDetail in shellingProcedureMaterialOut.FixedAssetOutDetails)
                {
                    FixedAssetOutDetail fixedAssetOutDetail2 = censusFixedMaterialOut.FixedAssetOutDetails.AddNew();
                    fixedAssetOutDetail2.FixedAssetMaterialDefinition = fixedAssetOutDetail.FixedAssetMaterialDefinition;
                    fixedAssetOutDetail2.Accountancy = fixedAssetOutDetail.FixedAssetMaterialDefinition.Accountancy;
                    fixedAssetOutDetail2.Resource = null;
                    fixedAssetOutDetail.FixedAssetMaterialDefinition.Status = FixedAssetStatusEnum.Destroyed;
                }
                i++;
            }

            foreach (ShellingProcedureMaterialIn shellingProcedureMaterialIn in ShellingProcedureInMaterials)
            {
                CensusFixedMaterialIn censusFixedMaterialIn = censusFixed.CensusFixedInMaterials.AddNew();
                censusFixedMaterialIn.Material = shellingProcedureMaterialIn.Material;
                censusFixedMaterialIn.Amount = shellingProcedureMaterialIn.Amount;
                censusFixedMaterialIn.StockLevelType = shellingProcedureMaterialIn.StockLevelType;
                censusFixedMaterialIn.UnitPrice = shellingProcedureMaterialIn.UnitPrice;
                censusFixedMaterialIn.OrderSequenceNumber = i;
                censusFixedMaterialIn.CardAmount = 0;
                censusFixedMaterialIn.CensusAmount = shellingProcedureMaterialIn.Amount;
                i++;
            }
            censusFixed.CurrentStateDefID = CensusFixed.States.New;


#endregion PostTransition_SortingClassification2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ShellingProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ShellingProcedure.States.SortingClassification && toState == ShellingProcedure.States.Completed)
                PostTransition_SortingClassification2Completed();
        }
        #region Methods
        #region IStockInTransaction Members
        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public StockActionDetailIn.ChildStockActionDetailInCollection GetStockActionInDetails()
        {
            return StockActionInDetails;
        }

        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }
        #endregion
        #region IStockOutTransaction Members
        public StockActionDetailOut.ChildStockActionDetailOutCollection GetStockActionOutDetails()
        {
            return StockActionOutDetails;
        }
        #endregion
        #endregion
    }
}