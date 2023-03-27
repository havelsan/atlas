
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
    /// XXXXXX Logo Tanımlama
    /// </summary>
    public  partial class HospitalEmblemDefinition : TerminologyManagerDef
    {
        public partial class GetHospitalEmblemDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class GetHospitalEmblemByName_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("Emblem");
            localPropertyNamesList.Add("Name");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}