
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_RetiredOfficerFamily")] 

    /// <summary>
    /// Emekli Subay Ailesi Kabul 
    /// </summary>
    public  partial class PA_RetiredOfficerFamily : PA_MilitaryRetiredFamily
    {
        public class PA_RetiredOfficerFamilyList : TTObjectCollection<PA_RetiredOfficerFamily> { }
                    
        public class ChildPA_RetiredOfficerFamilyCollection : TTObject.TTChildObjectCollection<PA_RetiredOfficerFamily>
        {
            public ChildPA_RetiredOfficerFamilyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_RetiredOfficerFamilyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_RETIREDOFFICERFAMILY", dataRow) { }
        protected PA_RetiredOfficerFamily(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_RETIREDOFFICERFAMILY", dataRow, isImported) { }
        public PA_RetiredOfficerFamily(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_RetiredOfficerFamily(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_RetiredOfficerFamily() : base() { }

    }
}