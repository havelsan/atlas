
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
    /// Zimmet Sekmesi
    /// </summary>
    public  partial class DispensaryDebit : TTObject
    {
        protected override void PreDelete()
        {
#region PreDelete
            
            
            base.PreDelete();
            if(((ITTObject)this).IsNew == false)
                throw new Exception(SystemMessage.GetMessage(986));
#endregion PreDelete
        }

#region Methods
        public override bool IsPropertyReadonly(TTObjectPropertyDef propDef)
        {
            if(((ITTObject)this).IsNew == true)
                return false;
            return true;
        }
        
#endregion Methods

    }
}