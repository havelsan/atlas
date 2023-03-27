
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
    public  partial class FirstInStockAction : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "SELECTEDSTOCKACTION":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region SELECTEDSTOCKACTION_SetScript
                        if (value == true)
                        {
                            foreach (FirstInStockAction inStockAction in ExpireDateCorrectionAction.FirstInStockActions)
                            {
                                if (inStockAction.ObjectID.Equals(ObjectID) == false)
                                    inStockAction.SelectedStockAction = false;
                            }
                            TTObjectContext contex = new TTObjectContext(true);
                            StockTransaction trx = (StockTransaction)contex.GetObject((Guid)StockTransactionObjectID, typeof(StockTransaction));
                            ExpireDateCorrectionAction.OldExpirationDate = trx.ExpirationDate;
                            contex.Dispose();
                        }
#endregion SELECTEDSTOCKACTION_SetScript
                    }
                    break;

            }
        }

    }
}