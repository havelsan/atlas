
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
    /// CPT4 Tanımları
    /// </summary>
    public  partial class CPT4Definition : TerminologyManagerDef, ITTListTreeObject
    {
        public partial class GetCPT4Definitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return CPTCode + " " + OriginalName;
        }
        
        bool ITTListObject.IsSelectable
        {
            get
            {
                return ((ITTListTreeObject)this).IsLeaf;
            }
        }
        
        bool ITTListTreeObject.IsLeaf
        {
            get
            {
                if (IsLeaf.HasValue)
                    return IsLeaf.Value;
                return true;
            }
        }
           public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.CPT4DefinitionInfo;
        }
        
#endregion Methods

    }
}