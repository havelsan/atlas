
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
    /// Hemşire Güncesi Sekmesi
    /// </summary>
    public  partial class NursingAppProgresses : TTObject
    {
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

#region Methods
        // override public bool IsPropertyReadonly(TTObjectPropertyDef propDef)
//        {
//            if(propDef.PropertyDefID==new Guid("2e0c9501-36ad-40c8-a2fb-9374ba827754"))//Description
//                if(((ITTObject)this).IsNew!=true)
//                return true;
//            
//            return false;
//        }
//        
//        protected override bool IsReadOnly()
//        {
//            if(((ITTObject)this).IsNew!=true)
//                return true;
//            
//            return false;
//        }
        
#endregion Methods

    }
}