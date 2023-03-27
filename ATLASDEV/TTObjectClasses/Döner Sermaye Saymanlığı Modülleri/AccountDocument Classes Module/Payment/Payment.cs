
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
    /// Ödeme tiplerinin ana sınıfıdır
    /// </summary>
    public  partial class Payment : TTObject
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();
            
            if(Price <= 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(936));

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            base.PreUpdate();
            
            if(Price <= 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(936));

#endregion PreUpdate
        }

    }
}