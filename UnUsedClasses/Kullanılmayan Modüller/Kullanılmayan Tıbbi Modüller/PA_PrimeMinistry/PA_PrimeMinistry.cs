﻿
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
    /// Başbakanlık(F022)  Kabul
    /// </summary>
    public  partial class PA_PrimeMinistry : PatientAdmission
    {
        protected void PostTransition_DocumentApproval2Completed()
        {
            // From State : DocumentApproval   To State : Completed
#region PostTransition_DocumentApproval2Completed
   
#endregion PostTransition_DocumentApproval2Completed
        }

#region Methods
        protected override void SetPatientGroup(){

        }
        
#endregion Methods
        

    }
}