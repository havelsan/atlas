
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
    /// Kuvvet
    /// </summary>
    public  partial class ForcesCommand : TerminologyManagerDef
    {
        public partial class OLAP_ForcesCommand_Class : TTReportNqlObject 
        {
        }

        public partial class GetForcesCommandNQL_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public override string ToString()
        {
            return Code + " " + Name;
        }
        
           public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ForceCommand;
        }
        
#endregion Methods

    }
}