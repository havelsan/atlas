
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
    /// Kullanılan Malzeme Sekmesi
    /// </summary>
    public  partial class UsedConsumedMaterail : TTObject, IUsedConsumeMaterial
    {
        public partial class GetUsedMaterialsOfRepair_Class : TTReportNqlObject 
        {
        }

        public partial class GetColletedCMRAction_Class : TTReportNqlObject 
        {
        }

        #region Methods
        #region IUsedConsumeMaterial Members
        public Store GetStore()
        {
            return Store;
        }
        public void SetStore(Store value)
        {
            Store = value;
        }

        public StockOut GetStockOut()
        {
            return StockOut;
        }
        public void SetStockOut(StockOut value)
        {
            StockOut = value;
        }

        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }
        public void SetCurrentStateDef(TTObjectStateDef value)
        {
            CurrentStateDef = value;
        }

        public Material GetMaterial()
        {
            return Material;
        }
        public void SetMaterial(Material value)
        {
            Material = value;
        }

        public Currency? GetAmount()
        {
            return Amount;
        }
        public void SetAmount(Currency? value)
        {
            Amount = value;
        }

        public OuttableLot GetOuttableLot()
        {
            return OuttableLot;
        }
        public void SetOuttableLot(OuttableLot value)
        {
            OuttableLot = value;
        }
        #endregion
        #endregion
    }
}