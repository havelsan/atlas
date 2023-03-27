
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
    /// Bölüm Listesi
    /// </summary>
    public partial class TTList_DepartmentListDefinition : TTList
    {
#region Methods
        override public bool CanFilterInactiveItems
        {
            get { return true; }
        }
        
        //override public bool IsObjectSelectable(object obj)
        //{
        //    bool? value = ((ResDepartment)obj).IsActive;
        //    if (value.HasValue)
        //        return value.Value;
        //    return true;
        //}
        
#endregion Methods
    }
}