
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
    /// Ameliyat Yenidoğan Ek Hizmeti
    /// </summary>
    public  partial class SurgeryNewBornProcedure : BaseSurgeryProcedure
    {
#region Methods
      
        public override void SetPerformedDate()
        {
            if (Surgery.SurgeryStartTime != null && Surgery.SurgeryStartTime < CreationDate)
                CreationDate = Surgery.SurgeryStartTime;
            PerformedDate = Surgery.SurgeryEndTime;
        }

        #endregion Methods

    }
}