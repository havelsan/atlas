
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
    /// GMDN Tanımları
    /// </summary>
    public  partial class GMDNDefinition : TerminologyManagerDef, ITTListObject
    {
        public partial class GetGMDNDefinitionsReportQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return ConceptCode + " " + Name_Tr;
        }
        
        bool ITTListObject.IsSelectable
        {
            get
            {
                return true;
            }
        }
        
#endregion Methods

    }
}