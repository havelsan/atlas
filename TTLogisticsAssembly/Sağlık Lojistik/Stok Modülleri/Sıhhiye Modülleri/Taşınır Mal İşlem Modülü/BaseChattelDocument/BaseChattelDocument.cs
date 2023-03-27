
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
    public abstract partial class BaseChattelDocument : StockAction, IBaseChattelDocument
    {
        #region Methods
        #region IBaseChattelDocument Members
        public DateTime? GetBaseDateTime()
        {
            return BaseDateTime;
        }

        public string GetBaseNumber()
        {
            return BaseNumber;
        }

        public string GetSpendingUnit()
        {
            return SpendingUnit;
        }

        public string GetSpendingUnitCode()
        {
            return SpendingUnitCode;
        }
        #endregion

        #endregion
    }
}