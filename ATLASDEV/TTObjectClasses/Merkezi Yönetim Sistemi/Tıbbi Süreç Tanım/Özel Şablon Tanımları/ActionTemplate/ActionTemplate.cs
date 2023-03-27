
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
    public  partial class ActionTemplate : TTObject
    {
        public partial class GetActionTemplate_Class : TTReportNqlObject 
        {
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                ID.GetNextValue();
            }
        }
        
#endregion Methods

    }
}