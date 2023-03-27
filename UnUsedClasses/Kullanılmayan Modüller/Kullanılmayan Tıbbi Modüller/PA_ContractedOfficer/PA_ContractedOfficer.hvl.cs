
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_ContractedOfficer")] 

    /// <summary>
    /// Sözleşmeli Subay Kabul
    /// </summary>
    public  partial class PA_ContractedOfficer : PA_Officer
    {
        public class PA_ContractedOfficerList : TTObjectCollection<PA_ContractedOfficer> { }
                    
        public class ChildPA_ContractedOfficerCollection : TTObject.TTChildObjectCollection<PA_ContractedOfficer>
        {
            public ChildPA_ContractedOfficerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_ContractedOfficerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("2a43b5c5-e070-4e5f-a792-63e6cdf9e97c"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("fe3624fd-600f-44e6-a59b-87ff7a9d2532"); } }
        }

        protected PA_ContractedOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_ContractedOfficer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_ContractedOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_ContractedOfficer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_ContractedOfficer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_CONTRACTEDOFFICER", dataRow) { }
        protected PA_ContractedOfficer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_CONTRACTEDOFFICER", dataRow, isImported) { }
        public PA_ContractedOfficer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_ContractedOfficer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_ContractedOfficer() : base() { }

    }
}