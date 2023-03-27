
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


namespace TTStorageManager.Security
{

    public partial class PatientPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
        {

            Patient patient = (Patient)securableObjectInstance;

            //NewPatein Ve Old patient aynı anda chekli ise yada ikisi de checkli değil ise All Pateint anlamında             

            if ((OldPatient.HasValue && OldPatient.Value) && (NewPatient.HasValue == false || NewPatient.Value == false) && ((ITTObject)patient).IsNew == true)
                return false;
            if ((OldPatient.HasValue == false || OldPatient.Value == false) && (NewPatient.HasValue && NewPatient.Value) && ((ITTObject)patient).IsNew == false)
                return false;

            if (IfPatientEditable.HasValue && IfPatientEditable.Value)
            {
                    return true;
            }

            if (Hospital.HasValue && Hospital.Value)
                return true;

            return false;
        }
            
#endregion Body
    }
}