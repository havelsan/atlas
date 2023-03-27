
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
    /// El Senedi Dağıtım Belgesinde malzeme detaylarını tutan sınıftır
    /// </summary>
    public  partial class VoucherDistributingDocumentMaterial : StockActionDetailOut, IVoucherDistributingDocumentMaterial
    {
        public partial class GetVoucherByStoreIDForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetVoucherDistributeForMaterialRequestReportQuery_Class : TTReportNqlObject 
        {
        }

        #region Methods
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
        #region IVoucherDistributingDocumentMaterial Members
        public Currency? GetRequireMaterial()
        {
            return RequireMaterial;
        }
        public void SetRequireMaterial(Currency? value)
        {
            RequireMaterial = value;
        }
        #endregion
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
            {
                StockLevelType = StockLevelType.NewStockLevel;
                if (Amount == null)
                    Amount = 0;
            }
        }
        
#endregion Methods

    }
}