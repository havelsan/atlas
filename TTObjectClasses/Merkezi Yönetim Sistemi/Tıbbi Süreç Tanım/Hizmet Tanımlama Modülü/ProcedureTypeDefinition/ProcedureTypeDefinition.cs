
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
    /// Hizmet Türleri Tanımlama
    /// </summary>
    public  partial class ProcedureTypeDefinition : TerminologyManagerDef, ITTListTreeObject
    {
        public partial class GetProcedureTypeDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return ProcedureTypeName;
        }
        
        bool ITTListObject.IsSelectable
        {
            get
            {
                return false;
            }
        }
        
        bool ITTListTreeObject.IsLeaf
        {
            get
            {
                return false;
            }
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ProcedureTypeDefinitionInfo;
        }
        
#endregion Methods

    }
}