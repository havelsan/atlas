
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
    /// Malzeme Durumu
    /// </summary>
    public  partial class StockLevelType : TerminologyManagerDef
    {
        public partial class GetStockLevelTypeList_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static StockLevelType NewStockLevel;
        public static StockLevelType UsedStockLevel;
        public static StockLevelType HekStockLevel;
        public static StockLevelType RedundantLevel;

        static StockLevelType()
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            IList ttObjects = null;

            ttObjects = StockLevelType.GetStockLevelType(objectContext, StockLevelTypeEnum.New);
            if (ttObjects != null && ttObjects.Count > 0)
                NewStockLevel = (StockLevelType)ttObjects[0];

            ttObjects = StockLevelType.GetStockLevelType(objectContext, StockLevelTypeEnum.Used);
            if (ttObjects != null && ttObjects.Count > 0)
                UsedStockLevel = (StockLevelType)ttObjects[0];

            ttObjects = StockLevelType.GetStockLevelType(objectContext, StockLevelTypeEnum.Hek);
            if (ttObjects != null && ttObjects.Count > 0)
                HekStockLevel = (StockLevelType)ttObjects[0];

            ttObjects = StockLevelType.GetStockLevelType(objectContext, StockLevelTypeEnum.Redundant);
            if (ttObjects != null && ttObjects.Count > 0)
                RedundantLevel = (StockLevelType)ttObjects[0];

        }


        public override string ToString()
        {
            if(StockLevelTypeStatus.HasValue)
            {
            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(StockLevelTypeEnum).Name];
                return dataType.EnumValueDefs[(int)StockLevelTypeStatus.Value].DisplayText;
            }
            return base.ToString();
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.StockLevelTypeDefinitionInfo;
        }
        
#endregion Methods

    }
}