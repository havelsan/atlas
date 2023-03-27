
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
    /// Ãœrün Ağacı Tanımları
    /// </summary>
    public  partial class ProductTreeDefinition : TTDefinitionSet
    {
        public partial class GetProductTreeDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            
            
            


            if (Material != null)
            {
                IList products = _objectContext.QueryObjects(ObjectDef, "MATERIAL = " + ConnectionManager.GuidToString(Material.ObjectID));
                if (products.Count > 0)
                {
                    throw new TTException(SystemMessage.GetMessageV3(533,new string[] {((ProductTreeDefinition)products[0]).ToString()}));
                }
            }

#endregion PreInsert
        }

    }
}