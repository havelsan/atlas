
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
    /// Madde Dilim Fıkra
    /// </summary>
    public  partial class MatterSliceAnectodeGrid : TTObject
    {
#region Methods
        public virtual MatterSliceAnectodeGrid PrepareMatterSliceAnectodeGridForRemoteMethod(bool withNewObjectID)
        {
            if(withNewObjectID)
            {
                MatterSliceAnectodeGrid sendingMatterSliceAnectodeGrid = (MatterSliceAnectodeGrid)Clone();
            
                return sendingMatterSliceAnectodeGrid;
            }
            else
            {
                return this;
            }
        }
        
#endregion Methods

    }
}