
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
    public partial interface IStockActionDetail : IAttributeInterface, ITTCoreObject
    {
        StockActionDetailStatusEnum? GetStatus();
        void SetStatus(StockActionDetailStatusEnum? value);

        Material GetMaterial();

        StockAction GetStockAction();

        StockLevelType GetStockLevelType();

        Currency? GetAmount();
        void SetAmount(Currency? value);
    }
}