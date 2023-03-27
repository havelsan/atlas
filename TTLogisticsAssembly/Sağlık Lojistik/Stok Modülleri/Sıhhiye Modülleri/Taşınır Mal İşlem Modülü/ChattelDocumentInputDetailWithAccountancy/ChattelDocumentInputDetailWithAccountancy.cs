
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
    public  partial class ChattelDocumentInputDetailWithAccountancy : StockActionDetailIn
    {
        public partial class CensusReportNQL_ChatDocInputDetWithAccNoGAB_Class : TTReportNqlObject 
        {
        }

        public Currency? ConflictAmount
        {
            get
            {
                try
                {
#region ConflictAmount_GetScript                    
                    if(Amount.HasValue && SentAmount.HasValue)
                    return Amount.Value - SentAmount.Value;
                        
                        return null;
#endregion ConflictAmount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ConflictAmount") + " : " + ex.Message, ex);
                }
            }
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                StockLevelType = StockLevelType.NewStockLevel;
        }
        
#endregion Methods

    }
}