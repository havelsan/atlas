
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
    /// Kurum Anlaşma Hizmet Grup Detayları
    /// </summary>
    public  partial class ProtocolDetailProcedureDefinition : TerminologyManagerDef
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();
            
            if(StartAge != null && EndAge == null)
                EndAge = 200;
            else if(StartAge == null && EndAge != null)
                StartAge = 0;

#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            base.PreUpdate();
            
            if(StartAge != null && EndAge == null)
                EndAge = 200;
            else if(StartAge == null && EndAge != null)
                StartAge = 0;

#endregion PreUpdate
        }

    }
}