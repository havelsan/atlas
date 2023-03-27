
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_ContractedOfficerFamily")] 

    /// <summary>
    /// Sözleşmeli Subay Ailesi Kabul
    /// </summary>
    public  partial class PA_ContractedOfficerFamily : PA_OfficerFamily
    {
        public class PA_ContractedOfficerFamilyList : TTObjectCollection<PA_ContractedOfficerFamily> { }
                    
        public class ChildPA_ContractedOfficerFamilyCollection : TTObject.TTChildObjectCollection<PA_ContractedOfficerFamily>
        {
            public ChildPA_ContractedOfficerFamilyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_ContractedOfficerFamilyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_CONTRACTEDOFFICERFAMILY", dataRow) { }
        protected PA_ContractedOfficerFamily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_CONTRACTEDOFFICERFAMILY", dataRow, isImported) { }
        public PA_ContractedOfficerFamily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_ContractedOfficerFamily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_ContractedOfficerFamily() : base() { }

    }
}