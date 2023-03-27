
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PA_Donor")] 

    /// <summary>
    /// Donöri Kabulü
    /// </summary>
    public  partial class PA_Donor : PA_CivilianConsignment
    {
        public class PA_DonorList : TTObjectCollection<PA_Donor> { }
                    
        public class ChildPA_DonorCollection : TTObject.TTChildObjectCollection<PA_Donor>
        {
            public ChildPA_DonorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPA_DonorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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

    /// <summary>
    /// SGK Kapsam Dışı
    /// </summary>
        public bool? IsNotSGK
        {
            get { return (bool?)this["ISNOTSGK"]; }
            set { this["ISNOTSGK"] = value; }
        }

        protected PA_Donor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PA_Donor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PA_Donor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PA_Donor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PA_Donor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PA_DONOR", dataRow) { }
        protected PA_Donor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PA_DONOR", dataRow, isImported) { }
        public PA_Donor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PA_Donor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PA_Donor() : base() { }

    }
}