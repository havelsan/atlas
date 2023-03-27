
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
    public  partial class DistributionDepStoreMat : StockActionDetailIn, IDistributionDepStoreMat
    {
#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
            {
                StockLevelType = StockLevelType.NewStockLevel;
                if(Amount == null)
                    Amount = 0;
                if (UnitPrice == null)
                    UnitPrice = 0;
            }
        }
        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion
        #region IDistributionDepStore Members

        public void AddFixedassetDetail(FixedAssetOutDetail fad, TTObjectContext objectContext)
        {
            FixedAssetMaterialDefinition fam = fad.FixedAssetMaterialDefinition;
            FixedAssetInDetail fin = new FixedAssetInDetail(objectContext);
            fin.Description = fam.Description;
            fin.FixedAssetNO = fam.FixedAssetNO;
            fin.Frequency = fam.Frequency;
            fin.GuarantyEndDate = fam.GuarantyEndDate;
            fin.GuarantyStartDate = fam.GuarantyStartDate;
            fin.Mark = fam.Mark;
            fin.Model = fam.Model;
            fin.Power = fam.Power;
            fin.ProductionDate = fam.ProductionDate;
            fin.SerialNumber = fam.SerialNumber;
            fin.Status = fam.Status;
            fin.Voltage = fam.Voltage;
            fin.TransferredFromXXXXXXSite = true;
            fin.TransferedFixedAssetMaterial = fam;
            fin.StockActionDetail = this;
        }


        #endregion
        #region IDistributionDepStoreMat Members
        public Currency? GetAcceptedAmount()
        {
            return AcceptedAmount ;
        }

        public void SetAcceptedAmount(Currency? value)
        {
            AcceptedAmount = value;
        }
        #endregion
        #endregion Methods

    }
}