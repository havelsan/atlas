
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
    public partial class StockMergeTransactionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
            {
                if (Interface.GetStore() == null)
                    throw new Exception(SystemMessage.GetMessage(521));

                if (Interface.GetStore() is MainStoreDefinition && Interface.GetDestinationStore() != null)
                    throw new Exception(SystemMessage.GetMessage(524));

                if ((Interface.GetStore() is MainStoreDefinition) == false && (Interface.GetDestinationStore() is MainStoreDefinition) == false)
                    throw new Exception(SystemMessage.GetMessage(525));


                foreach (IStockMergeMaterialOut stockMergeMaterialOut in Interface.GetStockMergeOutMaterialsList())
                {
                    if (stockTransactionDef.DoOperation(Interface, stockMergeMaterialOut))
                    {
                        stockMergeMaterialOut.SetStatus(StockActionDetailStatusEnum.Completed);
                        stockMergeMaterialOut.GetStockMergeMaterialIn().SetStatus(StockActionDetailStatusEnum.Completed);
                    }
                }
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}